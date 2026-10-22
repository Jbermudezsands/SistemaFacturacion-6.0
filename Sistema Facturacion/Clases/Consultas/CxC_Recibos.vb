Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text.RegularExpressions

'=====================================================================================================
'  RECIBOS DE CAJA - lógica única para grabar, editar, anular y consultar recibos.
'
'  Se usa desde FrmRecibos, FrmAgregarRecibo (Cuentas x Cobrar) o cualquier otra pantalla:
'
'     Dim servicio As New Recibos(Conexion)
'     Dim recibo As New ReciboCaja With {.Fecha = Today, .CodCliente = "1001", .Moneda = "Cordobas"}
'     recibo.Lineas.Add(New ReciboLinea With {.NumeroFactura = "M73238", .NombrePago = "Efectivo C$", .MontoPagado = 100D})
'     Dim r = servicio.Grabar(recibo)
'     If r.Exito Then ... r.Numero ... Else MsgBox(r.Mensaje)
'
'  Reglas:
'   - Todo se graba en UNA transacción: número, encabezado, detalle, métodos de pago, notas de
'     retención y aplicaciones del plan de pagos. Si algo falla no queda nada a medias.
'   - El consecutivo se toma dentro de la transacción con una sola instrucción UPDATE (no se repite
'     aunque dos cajeros graben al mismo tiempo).
'   - Un recibo NUEVO nunca se une a uno existente: si el número ya existe, se rechaza (manual) o se
'     toma el siguiente consecutivo (automático).
'   - El saldo de las facturas se valida con el mismo motor de Cuentas x Cobrar (CxCServicio).
'=====================================================================================================

'-----------------------------------------------------------------------------------------------------
' Modelos
'-----------------------------------------------------------------------------------------------------
Public Class ReciboAplicacionPlan
    Public Property IdDetallePago As Integer
    Public Property NumeroCuota As Integer
    Public Property MontoAplicado As Decimal
End Class

Public Class ReciboLinea
    ''' <summary>0 = línea nueva. Al editar, el idDetalleRecibo existente.</summary>
    Public Property IdDetalleRecibo As Decimal
    Public Property NumeroFactura As String = "0"
    Public Property NombrePago As String = ""
    Public Property Descripcion As String = ""
    Public Property NumeroTarjeta As String = ""
    Public Property FechaVence As Date?
    ''' <summary>Monto pagado en la moneda del recibo.</summary>
    Public Property MontoPagado As Decimal
    Public Property MontoFactura As Decimal
    Public Property AplicaFactura As Decimal
    Public Property SaldoFactura As Decimal
    Public Property TasaCambio As Decimal = 1D
    ''' <summary>Nota de débito que se paga con esta línea (cuando no es una factura).</summary>
    Public Property NumeroNota As String = ""
    Public ReadOnly Property AplicacionesPlan As New List(Of ReciboAplicacionPlan)

    ''' <summary>True si la línea paga una factura (no "0"/"0000" ni una nota "NB...").</summary>
    Public ReadOnly Property PagaFactura As Boolean
        Get
            Dim n = ClaveCxC.Normalizar(NumeroFactura)
            Return Not (ClaveCxC.EsSinFactura(n) OrElse n.StartsWith("NB", StringComparison.Ordinal))
        End Get
    End Property
End Class

Public Class ReciboCaja
    ''' <summary>Vacío o "-----0-----" = recibo nuevo. Al editar, el número existente.</summary>
    Public Property Numero As String = ""
    Public Property Fecha As Date = Date.Today
    Public Property CodCliente As String = ""
    Public Property Cajero As String = ""
    Public Property NombreCliente As String = ""
    Public Property Apellidos As String = ""
    Public Property Direccion As String = ""
    Public Property Telefono As String = ""
    Public Property Observaciones As String = ""
    ''' <summary>"Cordobas" o "Dolares".</summary>
    Public Property Moneda As String = "Cordobas"
    Public Property Descuento As Decimal
    ''' <summary>Serie del recibo (vacío = consecutivo sin serie).</summary>
    Public Property Serie As String = ""
    ''' <summary>Mayor que 0 = número digitado por el usuario (consecutivo manual).</summary>
    Public Property ConsecutivoManual As Decimal
    Public Property RetencionAlcaldia1 As Boolean
    Public Property RetencionIR2 As Boolean
    ''' <summary>Usuario para la bitácora del plan de pagos y la anulación.</summary>
    Public Property Usuario As String = ""
    Public ReadOnly Property Lineas As New List(Of ReciboLinea)
    ''' <summary>Al editar: idDetalleRecibo de las líneas que el usuario quitó.</summary>
    Public ReadOnly Property LineasEliminadas As New List(Of Decimal)

    Public ReadOnly Property EsNuevo As Boolean
        Get
            Dim n = If(Numero, "").Trim()
            Return n = "" OrElse n = Recibos.SinNumero
        End Get
    End Property

    Public ReadOnly Property SubTotal As Decimal
        Get
            Return DineroCxC.Redondear(Lineas.Sum(Function(l) l.MontoPagado))
        End Get
    End Property

    Public ReadOnly Property Total As Decimal
        Get
            Return DineroCxC.Redondear(SubTotal - Descuento)
        End Get
    End Property
End Class

Public Class ReciboSaldoFactura
    Public Property Saldo As Decimal
    ''' <summary>SubTotal + IVA convertido a la moneda pedida (tasa de la fecha de la factura).</summary>
    Public Property Monto As Decimal
End Class

Public Class ReciboRetencion
    Public Property Porcentaje As Decimal
    Public Property CodigoNota As String = ""
    Public Property DescripcionNota As String = ""
    Public Property NumeroFactura As String = ""
    ''' <summary>SubTotal sin IVA de la factura, en la moneda del recibo.</summary>
    Public Property Base As Decimal
    Public Property Monto As Decimal
    ''' <summary>Número de la nota de crédito creada (se llena al grabar).</summary>
    Public Property NumeroNota As String = ""
End Class

Public Class ReciboResultado
    Public Property Exito As Boolean
    Public Property Numero As String = ""
    Public Property Mensaje As String = ""
    Public ReadOnly Property Advertencias As New List(Of String)
    Public ReadOnly Property Retenciones As New List(Of ReciboRetencion)
End Class

Public Class ConfiguracionRecibos
    ''' <summary>DatosEmpresa.ConsecutivoReciboManual</summary>
    Public Property ConsecutivoManual As Boolean
    ''' <summary>DatosEmpresa.ConsecutivoReciboSerie</summary>
    Public Property UsaSerie As Boolean
End Class

''' <summary>Error de negocio: el mensaje se muestra tal cual al usuario.</summary>
Public Class ReciboException
    Inherits Exception
    Public Sub New(mensaje As String)
        MyBase.New(mensaje)
    End Sub
End Class

'-----------------------------------------------------------------------------------------------------
' Servicio
'-----------------------------------------------------------------------------------------------------
Public Class Recibos

    Public Const SinNumero As String = "-----0-----"
    Private Const Tolerancia As Decimal = 0.005D
    Private Const DescripcionAntigua As String = "Generado Automaticamente por Recibos"

    Private ReadOnly _conexion As String

    ''' <summary>Si es True (por defecto) no deja pagar más que el saldo de la factura.</summary>
    Public Property ValidarSaldo As Boolean = True
    ''' <summary>Opcional: CodigoNB fijo de la nota "Alcaldia 1%". Vacío = se busca en NotaDebito.</summary>
    Public Property CodigoNotaAlcaldia1 As String = ""
    ''' <summary>Opcional: CodigoNB fijo de la nota "Retencion 2%". Vacío = se busca en NotaDebito.</summary>
    Public Property CodigoNotaRetencion2 As String = ""
    ''' <summary>Si es True, después de grabar/anular recalcula Facturas.MontoCredito con el motor de CxC.</summary>
    Public Property ActualizarMontoCredito As Boolean = True

    Public Sub New(cadenaConexion As String)
        _conexion = cadenaConexion
    End Sub

    '=================================================================================================
    ' CONFIGURACIÓN Y CONSECUTIVOS
    '=================================================================================================
    Public Function LeerConfiguracion() As ConfiguracionRecibos
        Dim cfg As New ConfiguracionRecibos
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Using cmd As New SqlCommand("SELECT TOP (1) ConsecutivoReciboManual, ConsecutivoReciboSerie FROM DatosEmpresa", cn)
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        cfg.ConsecutivoManual = Not rd.IsDBNull(0) AndAlso Convert.ToBoolean(rd.GetValue(0))
                        cfg.UsaSerie = Not rd.IsDBNull(1) AndAlso Convert.ToBoolean(rd.GetValue(1))
                    End If
                End Using
            End Using
        End Using
        Return cfg
    End Function

    ''' <summary>
    ''' Incrementa y devuelve un consecutivo en una sola instrucción (atómica).
    ''' serie vacía = tabla Consecutivos; con serie = tabla ConsecutivoSerie.
    ''' Devuelve 0 si no existe la fila (igual que BuscaConsecutivo / BuscaConsecutivoSerie).
    ''' </summary>
    Public Shared Function TomarConsecutivo(cn As SqlConnection, tx As SqlTransaction, campo As String, Optional serie As String = "") As Decimal
        If campo Is Nothing OrElse Not Regex.IsMatch(campo, "^[A-Za-z_][A-Za-z0-9_]*$") Then
            Throw New ArgumentException("Nombre de consecutivo no válido: " & campo)
        End If
        Dim sinSerie = String.IsNullOrEmpty(If(serie, "").Trim())
        ' Se usa "SET @n = campo = ..." en lugar de OUTPUT porque OUTPUT falla si la tabla
        ' tiene triggers (por ejemplo, los de la replicación).
        Dim sql = "DECLARE @n float; " &
                  "UPDATE " & If(sinSerie, "Consecutivos", "ConsecutivoSerie") &
                  " SET @n = [" & campo & "] = ISNULL([" & campo & "], 0) + 1" &
                  If(sinSerie, "", " WHERE Serie = @Serie") & "; SELECT @n;"
        Using cmd As New SqlCommand(sql, cn, tx)
            If Not sinSerie Then cmd.Parameters.Add("@Serie", SqlDbType.NVarChar, 50).Value = serie.Trim()
            Dim v = cmd.ExecuteScalar()
            If v Is Nothing OrElse Convert.IsDBNull(v) Then Return 0D
            Return Decimal.Truncate(Convert.ToDecimal(v))
        End Using
    End Function

    ''' <summary>Versión con conexión propia (para BuscaConsecutivo / BuscaConsecutivoSerie y Planilla).</summary>
    Public Shared Function TomarConsecutivo(cadenaConexion As String, campo As String, Optional serie As String = "") As Decimal
        Using cn As New SqlConnection(cadenaConexion)
            cn.Open()
            Return TomarConsecutivo(cn, Nothing, campo, serie)
        End Using
    End Function

    ''' <summary>Formato del número: serie + al menos 5 dígitos (igual que Format(n, "0000#")).</summary>
    Public Shared Function FormatearNumero(serie As String, consecutivo As Decimal) As String
        Return If(serie, "").Trim() & Decimal.Truncate(consecutivo).ToString("00000")
    End Function

    '=================================================================================================
    ' SALDOS (mismo motor que Cuentas x Cobrar)
    '=================================================================================================
    Private Function SaldosPorFactura(codCliente As String, fecha As Date, moneda As MonedaCxC) As Dictionary(Of String, ReciboSaldoFactura)
        Return SaldosDesdeResultado(New CxCServicio(_conexion).CalcularSaldos(CxCFiltro.PorCliente(codCliente, fecha, moneda)))
    End Function

    ''' <summary>Saldo y monto por número de factura a partir del resultado del motor de CxC.</summary>
    Public Shared Function SaldosDesdeResultado(r As CxCResultado) As Dictionary(Of String, ReciboSaldoFactura)
        Dim mapa As New Dictionary(Of String, ReciboSaldoFactura)(StringComparer.Ordinal)
        For Each l As CxCLinea In r.Lineas
            If l.TipoLinea <> TipoLineaCxC.Factura Then Continue For
            Dim clave = ClaveCxC.Normalizar(l.NumeroFactura)
            Dim info As ReciboSaldoFactura = Nothing
            If Not mapa.TryGetValue(clave, info) Then
                info = New ReciboSaldoFactura
                mapa.Add(clave, info)
            End If
            info.Saldo += l.Saldo
            info.Monto += l.Monto
        Next
        Return mapa
    End Function

    ''' <summary>Saldo pendiente de una factura en la moneda indicada (reemplaza a ValidarFacturaEnRecibo).
    ''' Devuelve Nothing si la factura no existe para ese cliente.</summary>
    Public Function SaldoFactura(codCliente As String, numeroFactura As String, fecha As Date, moneda As String) As Decimal?
        Dim mapa = SaldosPorFactura(codCliente, fecha, DineroCxC.MonedaDesdeTexto(moneda))
        Dim info As ReciboSaldoFactura = Nothing
        If mapa.TryGetValue(ClaveCxC.Normalizar(numeroFactura), info) Then Return info.Saldo
        Return Nothing
    End Function

    '=================================================================================================
    ' RETENCIONES (1 % Alcaldía y 2 % IR) — sobre el SubTotal sin IVA de cada factura pagada
    '=================================================================================================
    ''' <summary>Calcula (sin grabar) las retenciones que generará el recibo. Sirve para mostrarlas en pantalla.</summary>
    Public Function CalcularRetenciones(recibo As ReciboCaja, Optional advertencias As List(Of String) = Nothing) As List(Of ReciboRetencion)
        Dim saldos = SaldosPorFactura(recibo.CodCliente, recibo.Fecha, DineroCxC.MonedaDesdeTexto(recibo.Moneda))
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Return CalcularRetenciones(cn, recibo, saldos, If(advertencias, New List(Of String)))
        End Using
    End Function

    Private Function CalcularRetenciones(cn As SqlConnection, recibo As ReciboCaja, saldos As Dictionary(Of String, ReciboSaldoFactura),
                                         advertencias As List(Of String)) As List(Of ReciboRetencion)
        Dim lista As New List(Of ReciboRetencion)
        If Not recibo.RetencionAlcaldia1 AndAlso Not recibo.RetencionIR2 Then Return lista

        Dim tipos As New List(Of KeyValuePair(Of Decimal, String()))
        If recibo.RetencionAlcaldia1 Then tipos.Add(New KeyValuePair(Of Decimal, String())(0.01D, BuscarTipoRetencion(cn, "1", CodigoNotaAlcaldia1)))
        If recibo.RetencionIR2 Then tipos.Add(New KeyValuePair(Of Decimal, String())(0.02D, BuscarTipoRetencion(cn, "2", CodigoNotaRetencion2)))

        ' Una sola vez por factura aunque aparezca en varias líneas (varios métodos de pago).
        Dim facturas = recibo.Lineas.Where(Function(l) l.PagaFactura AndAlso l.MontoPagado <> 0D) _
                                    .Select(Function(l) l.NumeroFactura.Trim()) _
                                    .Distinct(StringComparer.OrdinalIgnoreCase).ToList()

        For Each numero As String In facturas
            Dim info As ReciboSaldoFactura = Nothing
            If Not saldos.TryGetValue(ClaveCxC.Normalizar(numero), info) Then Continue For   ' lo reporta Validar

            Dim subTotal As Decimal, iva As Decimal
            LeerSubTotalIva(cn, recibo.CodCliente, numero, subTotal, iva)
            Dim base = BaseRetencion(info.Monto, subTotal, iva)

            For Each t As KeyValuePair(Of Decimal, String()) In tipos
                Dim codigo = t.Value(0), descripcion = t.Value(1)
                Dim existente = NotaRetencionExistente(cn, recibo.CodCliente, numero, codigo, descripcion)
                If existente IsNot Nothing Then
                    ' Si la nota es de este mismo recibo (edición) no se avisa: simplemente se conserva.
                    If recibo.EsNuevo OrElse existente(1) <> EtiquetaRetencion(recibo.Numero, recibo.Fecha) Then
                        advertencias.Add(String.Format("La factura {0} ya tiene {1} (nota {2}); no se creó otra.", numero, descripcion, existente(0)))
                    End If
                    Continue For
                End If
                Dim monto = MontoRetencion(base, t.Key)
                If monto <= 0D Then Continue For
                lista.Add(New ReciboRetencion With {.Porcentaje = t.Key, .CodigoNota = codigo, .DescripcionNota = descripcion,
                                                    .NumeroFactura = numero, .Base = base, .Monto = monto})
            Next
        Next
        Return lista
    End Function

    ''' <summary>Devuelve {CodigoNB, Descripcion} del catálogo NotaDebito para "x%".
    ''' "Alcaldia 1%" coincide con 1; "Devolucion de facturas 15%" ya NO coincide (antes sí, con LIKE '%1%%').</summary>
    Private Shared Function BuscarTipoRetencion(cn As SqlConnection, porcentaje As String, codigoFijo As String) As String()
        Dim sql As String
        If Not String.IsNullOrEmpty(If(codigoFijo, "").Trim()) Then
            sql = "SELECT TOP (1) CodigoNB, Descripcion FROM NotaDebito WHERE Tipo = N'Credito Clientes' AND CodigoNB = @Codigo"
        Else
            sql = "SELECT TOP (1) CodigoNB, Descripcion FROM NotaDebito WHERE Tipo = N'Credito Clientes' " &
                  "AND (N' ' + Descripcion) LIKE N'%[^0-9]' + @Pct + N'[%]%' ORDER BY CodigoNB"
        End If
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar, 50).Value = If(codigoFijo, "").Trim()
            cmd.Parameters.Add("@Pct", SqlDbType.NVarChar, 5).Value = porcentaje
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then Return New String() {Convert.ToString(rd.GetValue(0)).Trim(), Convert.ToString(rd.GetValue(1)).Trim()}
            End Using
        End Using
        Throw New ReciboException(String.Format("No existe en el catálogo de notas (Credito Clientes) una nota para la retención del {0}%.", porcentaje))
    End Function

    Private Shared Sub LeerSubTotalIva(cn As SqlConnection, codCliente As String, numeroFactura As String, ByRef subTotal As Decimal, ByRef iva As Decimal)
        Const sql = "SELECT ISNULL(SUM(CAST(SubTotal AS decimal(19,4))),0), ISNULL(SUM(CAST(IVA AS decimal(19,4))),0) FROM Facturas " &
                    "WHERE Tipo_Factura = N'Factura' AND Numero_Factura = @Factura AND Cod_Cliente = @Cliente"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Factura", SqlDbType.NVarChar, 50).Value = numeroFactura
            cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 50).Value = codCliente
            Using rd = cmd.ExecuteReader()
                rd.Read()
                subTotal = rd.GetDecimal(0)
                iva = rd.GetDecimal(1)
            End Using
        End Using
    End Sub

    ''' <summary>{Numero_Nota, Observaciones} de una nota de retención ya registrada para la factura, o Nothing.</summary>
    Private Shared Function NotaRetencionExistente(cn As SqlConnection, codCliente As String, numeroFactura As String,
                                                   codigoNota As String, descripcion As String) As String()
        Const sql = "SELECT TOP (1) DN.Numero_Nota, ISNULL(I.Observaciones, N'') FROM Detalle_Nota DN " &
                    "INNER JOIN IndiceNota I ON I.Numero_Nota = DN.Numero_Nota AND I.Fecha_Nota = DN.Fecha_Nota AND I.Tipo_Nota = DN.Tipo_Nota " &
                    "WHERE I.Cod_Cliente = @Cliente AND DN.Numero_Factura = @Factura AND DN.Tipo_Nota = @Tipo AND ISNULL(DN.Monto,0) <> 0 " &
                    "AND (LTRIM(RTRIM(DN.Descripcion)) = @Descripcion OR DN.Descripcion = @Antigua)"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 50).Value = codCliente
            cmd.Parameters.Add("@Factura", SqlDbType.NVarChar, 50).Value = numeroFactura
            cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = codigoNota
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 50).Value = descripcion
            cmd.Parameters.Add("@Antigua", SqlDbType.NVarChar, 50).Value = DescripcionAntigua
            Using rd = cmd.ExecuteReader()
                If Not rd.Read() Then Return Nothing
                Return New String() {Convert.ToString(rd.GetValue(0)).Trim(), Convert.ToString(rd.GetValue(1))}
            End Using
        End Using
    End Function

    ''' <summary>Texto que enlaza la nota de retención con su recibo (IndiceNota.Observaciones).</summary>
    Public Shared Function EtiquetaRetencion(numeroRecibo As String, fecha As Date) As String
        Return "Retencion automatica recibo " & numeroRecibo.Trim() & " del " & fecha.ToString("dd/MM/yyyy")
    End Function

    ''' <summary>SubTotal sin IVA en la moneda del recibo; montoConvertido = SubTotal+IVA ya convertido por el motor.</summary>
    Public Shared Function BaseRetencion(montoConvertido As Decimal, subTotal As Decimal, iva As Decimal) As Decimal
        If subTotal + iva = 0D Then Return 0D
        Return DineroCxC.Redondear(montoConvertido * subTotal / (subTotal + iva))
    End Function

    Public Shared Function MontoRetencion(base As Decimal, porcentaje As Decimal) As Decimal
        Return DineroCxC.Redondear(base * porcentaje)
    End Function

    ''' <summary>"" si el pago cabe en el saldo; si no, el mensaje de error.</summary>
    Public Shared Function RevisarPago(numeroFactura As String, disponible As Decimal, pagado As Decimal, retenido As Decimal, moneda As String) As String
        If pagado + retenido <= disponible + Tolerancia Then Return ""
        Return String.Format("Factura {0}: saldo pendiente {1} {4}; está pagando {2}{3}.",
                             numeroFactura, DineroCxC.Formatear(disponible), DineroCxC.Formatear(pagado),
                             If(retenido > 0D, " + retención " & DineroCxC.Formatear(retenido), ""), moneda)
    End Function

    '=================================================================================================
    ' VALIDACIÓN
    '=================================================================================================
    ''' <summary>Devuelve la lista de errores (vacía = se puede grabar). No toca la base de datos salvo para leer.</summary>
    Public Function Validar(recibo As ReciboCaja) As List(Of String)
        Dim errores As New List(Of String)
        Dim retenciones As List(Of ReciboRetencion) = Nothing
        Try
            Validar(recibo, errores, New List(Of String), retenciones)
        Catch ex As ReciboException
            errores.Add(ex.Message)
        End Try
        Return errores
    End Function

    Private Sub Validar(recibo As ReciboCaja, errores As List(Of String), advertencias As List(Of String),
                        ByRef retenciones As List(Of ReciboRetencion))
        retenciones = New List(Of ReciboRetencion)

        If recibo Is Nothing Then errores.Add("No hay recibo.") : Return
        If String.IsNullOrEmpty(If(recibo.CodCliente, "").Trim()) Then errores.Add("Seleccione el cliente.")
        Dim moneda = If(recibo.Moneda, "").Trim()
        If moneda <> "Cordobas" AndAlso moneda <> "Dolares" Then errores.Add("La moneda del recibo debe ser Cordobas o Dolares.")

        Dim lineas = recibo.Lineas.Where(Function(l) l.MontoPagado <> 0D).ToList()
        If lineas.Count = 0 Then errores.Add("El recibo no tiene montos pagados.")
        For Each l As ReciboLinea In lineas
            If l.MontoPagado < 0D Then errores.Add(String.Format("Factura {0}: el monto pagado no puede ser negativo.", l.NumeroFactura))
            If String.IsNullOrEmpty(If(l.NombrePago, "").Trim()) Then errores.Add(String.Format("Factura {0}: falta el método de pago.", l.NumeroFactura))
            Dim aplicado = l.AplicacionesPlan.Sum(Function(a) a.MontoAplicado)
            If aplicado > l.MontoPagado + Tolerancia Then
                errores.Add(String.Format("Factura {0}: lo aplicado al plan de pagos ({1}) es mayor que lo pagado ({2}).",
                                          l.NumeroFactura, DineroCxC.Formatear(aplicado), DineroCxC.Formatear(l.MontoPagado)))
            End If
        Next
        If recibo.Descuento < 0D OrElse recibo.Descuento > recibo.SubTotal Then errores.Add("El descuento no es válido.")
        If Not recibo.EsNuevo AndAlso recibo.ConsecutivoManual > 0D Then errores.Add("Un recibo existente no puede cambiar de número.")
        If errores.Count > 0 Then Return

        Dim facturas = lineas.Where(Function(l) l.PagaFactura).ToList()
        If facturas.Count = 0 Then Return
        If Not ValidarSaldo AndAlso Not recibo.RetencionAlcaldia1 AndAlso Not recibo.RetencionIR2 Then Return

        Dim saldos = SaldosPorFactura(recibo.CodCliente, recibo.Fecha, DineroCxC.MonedaDesdeTexto(moneda))
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            retenciones = CalcularRetenciones(cn, recibo, saldos, advertencias)

            ' Al editar, el saldo ya descuenta lo que este mismo recibo había pagado: se suma de vuelta.
            Dim propio As Dictionary(Of String, Decimal) = If(recibo.EsNuevo, New Dictionary(Of String, Decimal)(StringComparer.Ordinal),
                                                             MontosPropiosPorFactura(cn, recibo))

            For Each grupo As IGrouping(Of String, ReciboLinea) In facturas.GroupBy(Function(l) ClaveCxC.Normalizar(l.NumeroFactura))
                Dim numero = grupo.First().NumeroFactura.Trim()
                Dim info As ReciboSaldoFactura = Nothing
                If Not saldos.TryGetValue(grupo.Key, info) Then
                    errores.Add(String.Format("La factura {0} no existe como factura de crédito del cliente {1} al {2:dd/MM/yyyy}.",
                                              numero, recibo.CodCliente, recibo.Fecha))
                    Continue For
                End If
                If Not ValidarSaldo Then Continue For

                Dim clave = grupo.Key
                Dim pagado = grupo.Sum(Function(l) l.MontoPagado)
                Dim retenido = retenciones.Where(Function(r) ClaveCxC.Normalizar(r.NumeroFactura) = clave).Sum(Function(r) r.Monto)
                Dim devuelto As Decimal = 0D
                propio.TryGetValue(clave, devuelto)
                Dim disponible = DineroCxC.Redondear(info.Saldo + devuelto)

                Dim problema = RevisarPago(numero, disponible, pagado, retenido, moneda)
                If problema <> "" Then errores.Add(problema)
            Next
        End Using
    End Sub

    ''' <summary>Lo que el recibo (en edición) ya tenía pagado por factura (sus notas de retención se conservan).</summary>
    Private Shared Function MontosPropiosPorFactura(cn As SqlConnection, recibo As ReciboCaja) As Dictionary(Of String, Decimal)
        Dim mapa As New Dictionary(Of String, Decimal)(StringComparer.Ordinal)
        Dim sql = "SELECT Numero_Factura, SUM(CAST(ISNULL(MontoPagado,0) AS decimal(19,4))) FROM DetalleRecibo " &
                  "WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha GROUP BY Numero_Factura"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = recibo.Numero.Trim()
            cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = recibo.Fecha.Date
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    Dim clave = ClaveCxC.Normalizar(If(rd.IsDBNull(0), "", rd.GetString(0)))
                    Dim actual As Decimal = 0D
                    mapa.TryGetValue(clave, actual)
                    mapa(clave) = actual + rd.GetDecimal(1)
                End While
            End Using
        End Using
        Return mapa
    End Function

    '=================================================================================================
    ' GRABAR (nuevo o edición)
    '=================================================================================================
    Public Function Grabar(recibo As ReciboCaja) As ReciboResultado
        Dim res As New ReciboResultado
        Dim errores As New List(Of String)
        Dim retenciones As List(Of ReciboRetencion) = Nothing

        Try
            Validar(recibo, errores, res.Advertencias, retenciones)
        Catch ex As ReciboException
            errores.Add(ex.Message)
        End Try
        If errores.Count > 0 Then
            res.Mensaje = String.Join(Environment.NewLine, errores)
            Return res
        End If

        Dim fecha = recibo.Fecha.Date
        Dim lineas = recibo.Lineas.Where(Function(l) l.MontoPagado <> 0D).ToList()
        Dim numero As String = ""

        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Using tx = cn.BeginTransaction(IsolationLevel.ReadCommitted)
                Try
                    If recibo.EsNuevo Then
                        numero = AsignarNumero(cn, tx, recibo, res.Advertencias)
                        InsertarEncabezado(cn, tx, recibo, numero)
                    Else
                        numero = recibo.Numero.Trim()
                        VerificarEditable(cn, tx, numero, fecha, recibo.CodCliente)
                        ActualizarEncabezado(cn, tx, recibo, numero)
                        For Each id As Decimal In recibo.LineasEliminadas
                            EliminarLinea(cn, tx, numero, fecha, id)
                        Next
                    End If

                    For Each l As ReciboLinea In lineas
                        GrabarLinea(cn, tx, recibo, numero, l)
                    Next

                    RegrabarMetodosPago(cn, tx, numero, fecha)

                    For Each r As ReciboRetencion In retenciones
                        r.NumeroNota = GrabarNotaRetencion(cn, tx, recibo, numero, r)
                        res.Retenciones.Add(r)
                    Next

                    tx.Commit()
                Catch ex As Exception
                    Try
                        tx.Rollback()
                    Catch
                    End Try
                    res.Retenciones.Clear()
                    res.Mensaje = If(TypeOf ex Is ReciboException, ex.Message, "No se grabó el recibo: " & ex.Message)
                    Return res
                End Try
            End Using
        End Using

        res.Exito = True
        res.Numero = numero
        res.Mensaje = "Recibo " & numero & " grabado."
        recibo.Numero = numero

        If ActualizarMontoCredito Then
            ActualizarMontoCreditoFacturas(recibo.CodCliente, lineas.Where(Function(l) l.PagaFactura).Select(Function(l) l.NumeroFactura), res.Advertencias)
        End If
        Return res
    End Function

    Private Shared Function AsignarNumero(cn As SqlConnection, tx As SqlTransaction, recibo As ReciboCaja, advertencias As List(Of String)) As String
        Dim serie = If(recibo.Serie, "").Trim()

        If recibo.ConsecutivoManual > 0D Then
            Dim numero = FormatearNumero(serie, recibo.ConsecutivoManual)
            Dim fechaExistente = FechaReciboExistente(cn, tx, numero)
            If fechaExistente.HasValue Then
                Throw New ReciboException(String.Format("El recibo {0} ya existe (fecha {1:dd/MM/yyyy}). Digite otro número.", numero, fechaExistente.Value))
            End If
            Return numero
        End If

        Dim campo = If(serie = "", "Recibo_Caja", "Recibo")
        For intento As Integer = 1 To 50
            Dim consecutivo = TomarConsecutivo(cn, tx, campo, serie)
            If consecutivo <= 0D Then
                Throw New ReciboException(If(serie = "", "No existe el registro de Consecutivos.",
                                             "No existe la serie '" & serie & "' en ConsecutivoSerie."))
            End If
            Dim numero = FormatearNumero(serie, consecutivo)
            If Not FechaReciboExistente(cn, tx, numero).HasValue Then Return numero
            advertencias.Add("El número " & numero & " ya estaba usado; se tomó el siguiente consecutivo.")
        Next
        Throw New ReciboException("No se encontró un número de recibo libre. Revise el consecutivo de recibos.")
    End Function

    ''' <summary>Fecha del recibo con ese número (cualquier fecha) o Nothing. Bloquea el número hasta el fin de la transacción.</summary>
    Private Shared Function FechaReciboExistente(cn As SqlConnection, tx As SqlTransaction, numero As String) As Date?
        Using cmd As New SqlCommand("SELECT TOP (1) Fecha_Recibo FROM Recibo WITH (UPDLOCK, HOLDLOCK) WHERE CodReciboPago = @Numero", cn, tx)
            cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
            Dim v = cmd.ExecuteScalar()
            If v Is Nothing OrElse Convert.IsDBNull(v) Then Return Nothing
            Return Convert.ToDateTime(v)
        End Using
    End Function

    Private Shared Sub VerificarEditable(cn As SqlConnection, tx As SqlTransaction, numero As String, fecha As Date, codCliente As String)
        Dim cliente As String = Nothing, activo As Boolean = False, existe As Boolean = False
        Using cmd As New SqlCommand("SELECT Cod_Cliente, ISNULL(Activo,1) FROM Recibo WITH (UPDLOCK) WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha", cn, tx)
            cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
            cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    existe = True
                    cliente = If(rd.IsDBNull(0), "", rd.GetString(0))
                    activo = Convert.ToBoolean(rd.GetValue(1))
                End If
            End Using
        End Using
        If Not existe Then Throw New ReciboException(String.Format("No existe el recibo {0} con fecha {1:dd/MM/yyyy}. Para cambiar la fecha, anúlelo y créelo de nuevo.", numero, fecha))
        If Not activo Then Throw New ReciboException("El recibo " & numero & " está anulado.")
        If ClaveCxC.Normalizar(cliente) <> ClaveCxC.Normalizar(codCliente) Then
            Throw New ReciboException(String.Format("El recibo {0} pertenece al cliente {1}. No se puede cambiar el cliente; anúlelo y créelo de nuevo.", numero, cliente))
        End If
        If Contar(cn, tx, "SELECT COUNT(*) FROM AplicacionPagoPlan A INNER JOIN DetalleRecibo D ON D.idDetalleRecibo = A.idDetalleRecibo " &
                          "WHERE D.CodReciboPago = @Numero AND D.Fecha_Recibo = @Fecha AND A.Anulado = 0", numero, fecha) > 0 Then
            Throw New ReciboException("El recibo " & numero & " tiene aplicaciones al plan de pagos y no se puede editar.")
        End If
        If Contar(cn, tx, "SELECT COUNT(*) FROM Detalle_MetodoRecibo WHERE CodRecibo = @Numero AND Fecha_Recibo = @Fecha AND Arqueado = 1", numero, fecha) > 0 Then
            Throw New ReciboException("El recibo " & numero & " ya fue arqueado y no se puede editar.")
        End If
    End Sub

    Private Shared Function Contar(cn As SqlConnection, tx As SqlTransaction, sql As String, numero As String, fecha As Date) As Integer
        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
            cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Shared Sub ParametrosEncabezado(cmd As SqlCommand, recibo As ReciboCaja, numero As String)
        cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
        cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = recibo.Fecha.Date
        cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 50).Value = recibo.CodCliente.Trim()
        cmd.Parameters.Add("@Cajero", SqlDbType.NVarChar, 50).Value = Texto(recibo.Cajero)
        cmd.Parameters.Add("@SubTotal", SqlDbType.Float).Value = CDbl(recibo.SubTotal)
        cmd.Parameters.Add("@Descuento", SqlDbType.Float).Value = CDbl(DineroCxC.Redondear(recibo.Descuento))
        cmd.Parameters.Add("@Total", SqlDbType.Float).Value = CDbl(recibo.Total)
        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, -1).Value = Texto(recibo.NombreCliente)
        cmd.Parameters.Add("@Apellidos", SqlDbType.NVarChar, -1).Value = Texto(recibo.Apellidos)
        cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar, -1).Value = Texto(recibo.Direccion)
        cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, -1).Value = Texto(recibo.Telefono)
        cmd.Parameters.Add("@Moneda", SqlDbType.NVarChar, 50).Value = recibo.Moneda.Trim()
        cmd.Parameters.Add("@Observaciones", SqlDbType.NVarChar, -1).Value = Texto(recibo.Observaciones)
    End Sub

    Private Shared Sub InsertarEncabezado(cn As SqlConnection, tx As SqlTransaction, recibo As ReciboCaja, numero As String)
        Const sql = "INSERT INTO Recibo (CodReciboPago, Fecha_Recibo, Cod_Cliente, Cod_Cajero, Sub_Total, Descuento, Total, NombreCliente, " &
                    "ApellidosCliente, DireccionCliente, TelefonoCliente, MonedaRecibo, Observaciones, Activo, Contabilizado, Marca) " &
                    "VALUES (@Numero, @Fecha, @Cliente, @Cajero, @SubTotal, @Descuento, @Total, @Nombre, @Apellidos, @Direccion, @Telefono, " &
                    "@Moneda, @Observaciones, 1, 0, 1)"
        Using cmd As New SqlCommand(sql, cn, tx)
            ParametrosEncabezado(cmd, recibo, numero)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub ActualizarEncabezado(cn As SqlConnection, tx As SqlTransaction, recibo As ReciboCaja, numero As String)
        Const sql = "UPDATE Recibo SET Cod_Cajero = @Cajero, Sub_Total = @SubTotal, Descuento = @Descuento, Total = @Total, " &
                    "NombreCliente = @Nombre, ApellidosCliente = @Apellidos, DireccionCliente = @Direccion, TelefonoCliente = @Telefono, " &
                    "MonedaRecibo = @Moneda, Observaciones = @Observaciones, Marca = 1 " &
                    "WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha AND Cod_Cliente = @Cliente"
        Using cmd As New SqlCommand(sql, cn, tx)
            ParametrosEncabezado(cmd, recibo, numero)
            If cmd.ExecuteNonQuery() <> 1 Then Throw New ReciboException("No se pudo actualizar el encabezado del recibo " & numero & ".")
        End Using
    End Sub

    Private Shared Sub EliminarLinea(cn As SqlConnection, tx As SqlTransaction, numero As String, fecha As Date, id As Decimal)
        If id <= 0D Then Return
        Using cmd As New SqlCommand("DELETE FROM DetalleRecibo WHERE idDetalleRecibo = @Id AND CodReciboPago = @Numero AND Fecha_Recibo = @Fecha", cn, tx)
            cmd.Parameters.Add("@Id", SqlDbType.Decimal).Value = id
            cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
            cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub GrabarLinea(cn As SqlConnection, tx As SqlTransaction, recibo As ReciboCaja, numero As String, l As ReciboLinea)
        Dim fecha = recibo.Fecha.Date
        Dim esNueva = l.IdDetalleRecibo <= 0D
        Dim sql As String
        If esNueva Then
            sql = "INSERT INTO DetalleRecibo (CodReciboPago, Fecha_Recibo, Numero_Factura, MontoPagado, NombrePago, Descripcion, NumeroTarjeta, " &
                  "FechaVence, MontoFactura, AplicaFactura, SaldoFactura, TasaCambio, Numero_Nota) " &
                  "VALUES (@Numero, @Fecha, @Factura, @Monto, @NombrePago, @Descripcion, @Tarjeta, @Vence, @MontoFactura, @Aplica, @Saldo, @Tasa, @Nota); " &
                  "SELECT CAST(SCOPE_IDENTITY() AS numeric(18,0));"
        Else
            If l.AplicacionesPlan.Count > 0 Then Throw New ReciboException("No se pueden agregar aplicaciones de plan de pagos a una línea ya grabada.")
            sql = "UPDATE DetalleRecibo SET Numero_Factura = @Factura, MontoPagado = @Monto, NombrePago = @NombrePago, Descripcion = @Descripcion, " &
                  "NumeroTarjeta = @Tarjeta, FechaVence = @Vence, MontoFactura = @MontoFactura, AplicaFactura = @Aplica, SaldoFactura = @Saldo, " &
                  "TasaCambio = @Tasa, Numero_Nota = @Nota " &
                  "WHERE idDetalleRecibo = @Id AND CodReciboPago = @Numero AND Fecha_Recibo = @Fecha; SELECT @@ROWCOUNT;"
        End If

        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
            cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha
            cmd.Parameters.Add("@Factura", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrEmpty(If(l.NumeroFactura, "").Trim()), "0", l.NumeroFactura.Trim())
            cmd.Parameters.Add("@Monto", SqlDbType.Float).Value = CDbl(DineroCxC.Redondear(l.MontoPagado))
            cmd.Parameters.Add("@NombrePago", SqlDbType.NVarChar, 50).Value = l.NombrePago.Trim()
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, -1).Value = Texto(l.Descripcion)
            cmd.Parameters.Add("@Tarjeta", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrEmpty(If(l.NumeroTarjeta, "").Trim()), "0", l.NumeroTarjeta.Trim())
            cmd.Parameters.Add("@Vence", SqlDbType.SmallDateTime).Value = If(l.FechaVence.HasValue, l.FechaVence.Value.Date, fecha)
            cmd.Parameters.Add("@MontoFactura", SqlDbType.Float).Value = CDbl(DineroCxC.Redondear(l.MontoFactura))
            cmd.Parameters.Add("@Aplica", SqlDbType.Float).Value = CDbl(DineroCxC.Redondear(l.AplicaFactura))
            cmd.Parameters.Add("@Saldo", SqlDbType.Float).Value = CDbl(DineroCxC.Redondear(l.SaldoFactura))
            cmd.Parameters.Add("@Tasa", SqlDbType.Float).Value = CDbl(If(l.TasaCambio = 0D, 1D, l.TasaCambio))
            cmd.Parameters.Add("@Nota", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrEmpty(If(l.NumeroNota, "").Trim()), CObj(DBNull.Value), l.NumeroNota.Trim())
            If Not esNueva Then cmd.Parameters.Add("@Id", SqlDbType.Decimal).Value = l.IdDetalleRecibo

            Dim v = cmd.ExecuteScalar()
            If esNueva Then
                l.IdDetalleRecibo = Convert.ToDecimal(v)
            ElseIf Convert.ToInt32(v) <> 1 Then
                Throw New ReciboException(String.Format("La línea {0} (factura {1}) ya no existe en el recibo {2}.", l.IdDetalleRecibo, l.NumeroFactura, numero))
            End If
        End Using

        If esNueva AndAlso l.AplicacionesPlan.Count > 0 Then
            Const sqlPlan = "INSERT INTO AplicacionPagoPlan (idDetallePago, idDetalleRecibo, MontoAplicado, UsuarioAplicacion, CodReciboPago, Fecha_Recibo, Numero_Factura) " &
                            "VALUES (@IdPago, @IdDetalle, @Monto, @Usuario, @Numero, @Fecha, @Factura)"
            For Each a As ReciboAplicacionPlan In l.AplicacionesPlan
                Using cmd As New SqlCommand(sqlPlan, cn, tx)
                    cmd.Parameters.Add("@IdPago", SqlDbType.Int).Value = a.IdDetallePago
                    cmd.Parameters.Add("@IdDetalle", SqlDbType.Decimal).Value = l.IdDetalleRecibo
                    Dim pMonto = cmd.Parameters.Add("@Monto", SqlDbType.Decimal)
                    pMonto.Precision = 18 : pMonto.Scale = 2 : pMonto.Value = DineroCxC.Redondear(a.MontoAplicado)
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrEmpty(recibo.Usuario), CObj(DBNull.Value), recibo.Usuario)
                    cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
                    cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha
                    cmd.Parameters.Add("@Factura", SqlDbType.NVarChar, 50).Value = If(String.IsNullOrEmpty(If(l.NumeroFactura, "").Trim()), "0", l.NumeroFactura.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            Next
        End If
    End Sub

    ''' <summary>Detalle_MetodoRecibo = suma del detalle por método de pago (siempre cuadra con el recibo).</summary>
    Private Shared Sub RegrabarMetodosPago(cn As SqlConnection, tx As SqlTransaction, numero As String, fecha As Date)
        Const sql = "DELETE FROM Detalle_MetodoRecibo WHERE CodRecibo = @Numero AND Fecha_Recibo = @Fecha; " &
                    "INSERT INTO Detalle_MetodoRecibo (CodRecibo, Fecha_Recibo, NombrePago, Monto, NumeroTarjeta, Fecha_Vence) " &
                    "SELECT @Numero, @Fecha, NombrePago, ROUND(SUM(ISNULL(MontoPagado,0)), 2), MAX(NumeroTarjeta), MAX(FechaVence) " &
                    "FROM DetalleRecibo WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha AND ISNULL(MontoPagado,0) <> 0 GROUP BY NombrePago;"
        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
            cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Function GrabarNotaRetencion(cn As SqlConnection, tx As SqlTransaction, recibo As ReciboCaja, numeroRecibo As String,
                                                r As ReciboRetencion) As String
        Dim fecha = recibo.Fecha.Date
        Dim serie = If(recibo.Serie, "").Trim()
        Dim numeroNota As String = ""
        For intento As Integer = 1 To 50
            ' Misma serie que el recibo (ConsecutivoSerie.NotaCredito), igual que las notas que hoy se hacen a mano (M28572...).
            Dim consecutivo = TomarConsecutivo(cn, tx, "NotaCredito", serie)
            If consecutivo <= 0D Then
                Throw New ReciboException(If(serie = "", "No existe el consecutivo de Notas de Crédito (tabla Consecutivos).",
                                             "No existe la serie '" & serie & "' en ConsecutivoSerie para Notas de Crédito."))
            End If
            numeroNota = FormatearNumero(serie, consecutivo)
            ' Los códigos 1..8 existen como débito y como crédito: se evita reutilizar un número+tipo ya usado.
            Using cmd As New SqlCommand("SELECT COUNT(*) FROM IndiceNota WITH (UPDLOCK, HOLDLOCK) WHERE Numero_Nota = @Nota AND Tipo_Nota = @Tipo", cn, tx)
                cmd.Parameters.Add("@Nota", SqlDbType.NVarChar, 50).Value = numeroNota
                cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = r.CodigoNota
                If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then Exit For
            End Using
            If intento = 50 Then Throw New ReciboException("No se encontró un número libre para la nota de retención.")
        Next

        Const sql = "INSERT INTO IndiceNota (Numero_Nota, Fecha_Nota, Tipo_Nota, MonedaNota, Cod_Cliente, Nombre_Cliente, Observaciones, Activo, Contabilizado, Marca, TipoCuenta) " &
                    "VALUES (@Nota, @Fecha, @Tipo, @Moneda, @Cliente, @Nombre, @Observaciones, 1, 0, 1, 0); " &
                    "INSERT INTO Detalle_Nota (Numero_Nota, Fecha_Nota, Tipo_Nota, Descripcion, Numero_Factura, Monto) " &
                    "VALUES (@Nota, @Fecha, @Tipo, @Descripcion, @Factura, @Monto);"
        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@Nota", SqlDbType.NVarChar, 50).Value = numeroNota
            cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha
            cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = r.CodigoNota
            cmd.Parameters.Add("@Moneda", SqlDbType.NVarChar, 50).Value = recibo.Moneda.Trim()
            cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 50).Value = recibo.CodCliente.Trim()
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, -1).Value = Texto(recibo.NombreCliente)
            cmd.Parameters.Add("@Observaciones", SqlDbType.NVarChar, -1).Value = EtiquetaRetencion(numeroRecibo, fecha)
            ' La descripción del catálogo ("Alcaldia 1%", "Retencion 2%") deja claro que es crédito y no débito.
            Dim descripcion = r.DescripcionNota
            If descripcion.Length > 50 Then descripcion = descripcion.Substring(0, 50)
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 50).Value = descripcion
            cmd.Parameters.Add("@Factura", SqlDbType.NVarChar, 50).Value = r.NumeroFactura
            cmd.Parameters.Add("@Monto", SqlDbType.Float).Value = CDbl(r.Monto)
            cmd.ExecuteNonQuery()
        End Using
        Return numeroNota
    End Function

    '=================================================================================================
    ' ANULAR
    '=================================================================================================
    ''' <summary>Anula el recibo, sus aplicaciones al plan de pagos y las notas de retención que generó. Todo en una transacción.</summary>
    Public Function Anular(numero As String, fecha As Date, codCliente As String, usuario As String, motivo As String) As ReciboResultado
        Dim res As New ReciboResultado With {.Numero = If(numero, "").Trim()}
        Dim facturas As New List(Of String)
        fecha = fecha.Date

        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Using tx = cn.BeginTransaction(IsolationLevel.ReadCommitted)
                Try
                    Using cmd As New SqlCommand("SELECT COUNT(*) FROM Recibo WITH (UPDLOCK) WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha AND Cod_Cliente = @Cliente AND Activo = 1", cn, tx)
                        ParametrosClave(cmd, res.Numero, fecha, codCliente)
                        If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then
                            Throw New ReciboException(String.Format("No existe el recibo {0} del {1:dd/MM/yyyy} activo para el cliente {2}.", res.Numero, fecha, codCliente))
                        End If
                    End Using

                    Using cmd As New SqlCommand("SELECT DISTINCT Numero_Factura FROM DetalleRecibo WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha", cn, tx)
                        ParametrosClave(cmd, res.Numero, fecha, codCliente)
                        Using rd = cmd.ExecuteReader()
                            While rd.Read()
                                If Not rd.IsDBNull(0) Then facturas.Add(rd.GetString(0))
                            End While
                        End Using
                    End Using

                    Const sql = "UPDATE Recibo SET Contabilizado = 1, Activo = 0, NombreCliente = '******CANCELADO', ApellidosCliente = '******' " &
                                "WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha AND Cod_Cliente = @Cliente AND Activo = 1; " &
                                "UPDATE DetalleRecibo SET MontoPagado = 0 WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha; " &
                                "UPDATE A SET A.Anulado = 1, A.FechaAnulacion = SYSDATETIME(), A.UsuarioAnulacion = @Usuario, A.MotivoAnulacion = @Motivo " &
                                "FROM AplicacionPagoPlan A INNER JOIN DetalleRecibo D ON D.idDetalleRecibo = A.idDetalleRecibo " &
                                "WHERE D.CodReciboPago = @Numero AND D.Fecha_Recibo = @Fecha AND A.Anulado = 0; " &
                                "UPDATE DN SET DN.Monto = 0 FROM Detalle_Nota DN INNER JOIN IndiceNota I ON I.Numero_Nota = DN.Numero_Nota " &
                                "AND I.Fecha_Nota = DN.Fecha_Nota AND I.Tipo_Nota = DN.Tipo_Nota WHERE I.Cod_Cliente = @Cliente AND I.Observaciones = @Etiqueta; " &
                                "UPDATE IndiceNota SET Activo = 0 WHERE Cod_Cliente = @Cliente AND Observaciones = @Etiqueta; " &
                                "SELECT @@ROWCOUNT;"
                    Using cmd As New SqlCommand(sql, cn, tx)
                        ParametrosClave(cmd, res.Numero, fecha, codCliente)
                        cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = Texto(usuario)
                        cmd.Parameters.Add("@Motivo", SqlDbType.NVarChar, 250).Value = Texto(motivo)
                        cmd.Parameters.Add("@Etiqueta", SqlDbType.NVarChar, -1).Value = EtiquetaRetencion(res.Numero, fecha)
                        Dim notas = Convert.ToInt32(cmd.ExecuteScalar())
                        If notas > 0 Then res.Advertencias.Add(String.Format("Se anularon {0} nota(s) de retención del recibo.", notas))
                    End Using

                    tx.Commit()
                Catch ex As Exception
                    Try
                        tx.Rollback()
                    Catch
                    End Try
                    res.Mensaje = If(TypeOf ex Is ReciboException, ex.Message, "No se anuló el recibo: " & ex.Message)
                    Return res
                End Try
            End Using
        End Using

        res.Exito = True
        res.Mensaje = "Recibo " & res.Numero & " anulado."
        If ActualizarMontoCredito Then ActualizarMontoCreditoFacturas(codCliente, facturas, res.Advertencias)
        Return res
    End Function

    Private Shared Sub ParametrosClave(cmd As SqlCommand, numero As String, fecha As Date, codCliente As String)
        cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = numero
        cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha
        cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 50).Value = If(codCliente, "").Trim()
    End Sub

    Public Function PuedeEditar(numero As String, fecha As Date) As Boolean
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Return Contar(cn, Nothing, "SELECT COUNT(*) FROM AplicacionPagoPlan A INNER JOIN DetalleRecibo D ON D.idDetalleRecibo = A.idDetalleRecibo " &
                                       "WHERE D.CodReciboPago = @Numero AND D.Fecha_Recibo = @Fecha AND A.Anulado = 0", numero, fecha.Date) = 0 AndAlso
                   Contar(cn, Nothing, "SELECT COUNT(*) FROM Detalle_MetodoRecibo WHERE CodRecibo = @Numero AND Fecha_Recibo = @Fecha AND Arqueado = 1", numero, fecha.Date) = 0
        End Using
    End Function

    '=================================================================================================
    ' CARGAR
    '=================================================================================================
    ''' <summary>Carga un recibo. Si no se indica la fecha, toma el más reciente con ese número. Nothing si no existe.</summary>
    Public Function Cargar(numero As String, Optional fecha As Date? = Nothing) As ReciboCaja
        Dim recibo As ReciboCaja = Nothing
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Dim sql = "SELECT TOP (1) CodReciboPago, Fecha_Recibo, Cod_Cliente, Cod_Cajero, Descuento, NombreCliente, ApellidosCliente, " &
                      "DireccionCliente, TelefonoCliente, MonedaRecibo, Observaciones FROM Recibo WHERE CodReciboPago = @Numero" &
                      If(fecha.HasValue, " AND Fecha_Recibo = @Fecha", "") & " ORDER BY Fecha_Recibo DESC"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = If(numero, "").Trim()
                If fecha.HasValue Then cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fecha.Value.Date
                Using rd = cmd.ExecuteReader()
                    If Not rd.Read() Then Return Nothing
                    recibo = New ReciboCaja With {
                        .Numero = rd.GetString(0), .Fecha = rd.GetDateTime(1), .CodCliente = Leer(rd, 2), .Cajero = Leer(rd, 3),
                        .Descuento = If(rd.IsDBNull(4), 0D, DineroCxC.Redondear(Convert.ToDecimal(rd.GetValue(4)))),
                        .NombreCliente = Leer(rd, 5), .Apellidos = Leer(rd, 6), .Direccion = Leer(rd, 7), .Telefono = Leer(rd, 8),
                        .Moneda = Leer(rd, 9), .Observaciones = Leer(rd, 10)}
                End Using
            End Using

            Const sqlDetalle = "SELECT idDetalleRecibo, Numero_Factura, MontoPagado, NombrePago, Descripcion, NumeroTarjeta, FechaVence, " &
                               "MontoFactura, AplicaFactura, SaldoFactura, TasaCambio, Numero_Nota FROM DetalleRecibo " &
                               "WHERE CodReciboPago = @Numero AND Fecha_Recibo = @Fecha ORDER BY idDetalleRecibo"
            Using cmd As New SqlCommand(sqlDetalle, cn)
                cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50).Value = recibo.Numero
                cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = recibo.Fecha
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        recibo.Lineas.Add(New ReciboLinea With {
                            .IdDetalleRecibo = Convert.ToDecimal(rd.GetValue(0)), .NumeroFactura = Leer(rd, 1), .MontoPagado = Dinero(rd, 2),
                            .NombrePago = Leer(rd, 3), .Descripcion = Leer(rd, 4), .NumeroTarjeta = Leer(rd, 5),
                            .FechaVence = If(rd.IsDBNull(6), CType(Nothing, Date?), rd.GetDateTime(6)),
                            .MontoFactura = Dinero(rd, 7), .AplicaFactura = Dinero(rd, 8), .SaldoFactura = Dinero(rd, 9),
                            .TasaCambio = If(rd.IsDBNull(10), 1D, Convert.ToDecimal(rd.GetValue(10))), .NumeroNota = Leer(rd, 11)})
                    End While
                End Using
            End Using
        End Using
        Return recibo
    End Function

    '=================================================================================================
    ' FACTURAS.MONTOCREDITO (dato de apoyo; el saldo real lo calcula CxCServicio)
    '=================================================================================================
    Public Sub ActualizarMontoCreditoFacturas(codCliente As String, facturas As IEnumerable(Of String), Optional advertencias As List(Of String) = Nothing)
        Dim claves = New HashSet(Of String)(facturas.Where(Function(f) Not ClaveCxC.EsSinFactura(f)).Select(Function(f) ClaveCxC.Normalizar(f)), StringComparer.Ordinal)
        If claves.Count = 0 Then Return
        Try
            Dim monedaPorFactura As New Dictionary(Of String, MonedaCxC)(StringComparer.Ordinal)
            Using cn As New SqlConnection(_conexion)
                cn.Open()
                Using cmd As New SqlCommand("SELECT Numero_Factura, MonedaFactura FROM Facturas WHERE Tipo_Factura = N'Factura' AND Cod_Cliente = @Cliente", cn)
                    cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 50).Value = codCliente
                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            Dim clave = ClaveCxC.Normalizar(Leer(rd, 0))
                            If claves.Contains(clave) Then monedaPorFactura(clave) = DineroCxC.MonedaDesdeTexto(Leer(rd, 1))
                        End While
                    End Using
                End Using

                Dim hoy = Date.Today
                For Each moneda As MonedaCxC In monedaPorFactura.Values.Distinct().ToList()
                    Dim saldos = SaldosPorFactura(codCliente, hoy, moneda)
                    For Each par As KeyValuePair(Of String, MonedaCxC) In monedaPorFactura
                        If par.Value <> moneda Then Continue For
                        Dim info As ReciboSaldoFactura = Nothing
                        If Not saldos.TryGetValue(par.Key, info) Then Continue For
                        Using cmd As New SqlCommand("UPDATE Facturas SET MontoCredito = @Saldo WHERE Tipo_Factura = N'Factura' AND Cod_Cliente = @Cliente " &
                                                    "AND UPPER(LTRIM(RTRIM(Numero_Factura))) = @Factura", cn)
                            cmd.Parameters.Add("@Saldo", SqlDbType.Float).Value = CDbl(info.Saldo)
                            cmd.Parameters.Add("@Cliente", SqlDbType.NVarChar, 50).Value = codCliente
                            cmd.Parameters.Add("@Factura", SqlDbType.NVarChar, 50).Value = par.Key
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                Next
            End Using
        Catch ex As Exception
            If advertencias IsNot Nothing Then advertencias.Add("El recibo quedó grabado, pero no se actualizó MontoCredito de las facturas: " & ex.Message)
        End Try
    End Sub

    '-------------------------------------------------------------------------------------------------
    Private Shared Function Texto(valor As String) As Object
        If valor Is Nothing Then Return ""
        Return valor.Trim()
    End Function

    Private Shared Function Leer(rd As SqlDataReader, i As Integer) As String
        If rd.IsDBNull(i) Then Return ""
        Return Convert.ToString(rd.GetValue(i)).Trim()
    End Function

    Private Shared Function Dinero(rd As SqlDataReader, i As Integer) As Decimal
        If rd.IsDBNull(i) Then Return 0D
        Return DineroCxC.Redondear(Convert.ToDecimal(rd.GetValue(i)))
    End Function

End Class
