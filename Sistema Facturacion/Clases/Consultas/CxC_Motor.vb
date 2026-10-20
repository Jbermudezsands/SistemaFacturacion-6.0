Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Linq

'=====================================================================================================
'  CUENTAS POR COBRAR - MOTOR DE CÁLCULO
'  No toca la base de datos ni la pantalla: recibe CxCDatos y devuelve resultados.
'  Paso 1: ResolverMovimientos  -> convierte cada documento a la moneda de consulta y lo asocia a
'          la línea de saldo a la que pertenece (factura, nota sin factura o recibo sin factura).
'  Paso 2: el saldo por factura, el estado de cuenta, el saldo de clientes y la antigüedad
'          se calculan sobre esos MISMOS movimientos, por eso siempre cuadran entre sí.
'=====================================================================================================
Public Class CxCMotor

    Private Const MaxEjemplos As Integer = 10

    '-------------------------------------------------------------------------------------------------
    ' PASO 1: movimientos
    '-------------------------------------------------------------------------------------------------
    Public Function ResolverMovimientos(datos As CxCDatos, destino As MonedaCxC, advertencias As List(Of String)) As List(Of CxCMovimiento)
        Dim movimientos As New List(Of CxCMovimiento)(datos.Facturas.Count * 3)
        Dim tasas = datos.Tasas
        tasas.LimpiarFaltantes()

        ' Índices de facturas
        Dim porNumero As New Dictionary(Of String, List(Of CxCFacturaDoc))(StringComparer.Ordinal)
        Dim porNumeroYFecha As New Dictionary(Of String, CxCFacturaDoc)(StringComparer.Ordinal)
        Dim duplicadas As New List(Of String)

        For Each f As CxCFacturaDoc In datos.Facturas
            Dim cli = ClaveCxC.Normalizar(f.CodCliente)
            Dim num = ClaveCxC.Normalizar(f.Numero)
            Dim llave = ClaveCxC.Componer(cli, num)
            Dim lista As List(Of CxCFacturaDoc) = Nothing
            If Not porNumero.TryGetValue(llave, lista) Then
                lista = New List(Of CxCFacturaDoc)
                porNumero.Add(llave, lista)
            ElseIf lista.Count = 1 Then
                duplicadas.Add(f.Numero.Trim() & " (cliente " & f.CodCliente.Trim() & ")")
            End If
            lista.Add(f)
            porNumeroYFecha(ClaveCxC.Componer(cli, num, ClaveCxC.Fecha(f.Fecha))) = f

            movimientos.Add(New CxCMovimiento With {
                .Tipo = TipoMovimientoCxC.Factura,
                .CodCliente = f.CodCliente,
                .Fecha = f.Fecha,
                .Numero = f.Numero,
                .NumeroFactura = f.Numero,
                .Concepto = "Venta",
                .Debito = tasas.Convertir(f.Monto, f.Moneda, destino, f.Fecha),
                .ClaveDocumento = ClaveFactura(f),
                .TipoLinea = TipoLineaCxC.Factura
            })
        Next

        ' Notas (antes que los recibos: un recibo puede abonar a una nota de débito sin factura)
        Dim notasDebitoSinFactura As New Dictionary(Of String, String)(StringComparer.Ordinal)
        Dim notasHuerfanas As New List(Of String)

        For Each n As CxCNotaDoc In datos.Notas
            Dim cli = ClaveCxC.Normalizar(n.CodCliente)
            Dim monto = If(n.AplicaEn(destino), tasas.Convertir(n.Monto, n.Moneda, destino, n.Fecha), 0D)
            Dim mov As New CxCMovimiento With {
                .Tipo = If(n.EsDebito, TipoMovimientoCxC.NotaDebito, TipoMovimientoCxC.NotaCredito),
                .CodCliente = n.CodCliente,
                .Fecha = n.Fecha,
                .Numero = n.NumeroNota,
                .NumeroFactura = n.NumeroFactura,
                .Concepto = ConceptoNota(n),
                .Debito = If(n.EsDebito, monto, 0D),
                .Credito = If(n.EsDebito, 0D, monto)
            }

            If ClaveCxC.EsSinFactura(n.NumeroFactura) Then
                Dim prefijo = If(n.EsDebito, "NB", "NC")
                mov.ClaveDocumento = ClaveCxC.Componer(prefijo, cli, ClaveCxC.Normalizar(n.NumeroNota), ClaveCxC.Fecha(n.Fecha))
                mov.TipoLinea = If(n.EsDebito, TipoLineaCxC.NotaDebitoSinFactura, TipoLineaCxC.NotaCreditoSinFactura)
                If n.EsDebito Then
                    notasDebitoSinFactura(ClaveCxC.Componer(cli, ClaveCxC.Normalizar(n.NumeroNota))) = mov.ClaveDocumento
                End If
            Else
                Dim f = BuscarFactura(porNumero, cli, n.NumeroFactura, n.Fecha)
                If f Is Nothing Then
                    notasHuerfanas.Add(n.NumeroNota.Trim() & " → factura " & n.NumeroFactura.Trim())
                    Continue For
                End If
                mov.ClaveDocumento = ClaveFactura(f)
                mov.TipoLinea = TipoLineaCxC.Factura
            End If
            movimientos.Add(mov)
        Next

        ' Recibos
        Dim recibosHuerfanos As New List(Of String)
        For Each rc As CxCReciboDoc In datos.Recibos
            Dim cli = ClaveCxC.Normalizar(rc.CodCliente)
            Dim mov As New CxCMovimiento With {
                .Tipo = TipoMovimientoCxC.Recibo,
                .CodCliente = rc.CodCliente,
                .Fecha = rc.Fecha,
                .Numero = rc.CodRecibo,
                .NumeroFactura = rc.NumeroFactura,
                .Credito = tasas.Convertir(rc.Monto, rc.Moneda, destino, rc.Fecha)
            }

            If ClaveCxC.EsSinFactura(rc.NumeroFactura) Then
                Dim claveNota As String = Nothing
                If ClaveCxC.Normalizar(rc.NumeroNota) <> "" AndAlso
                   notasDebitoSinFactura.TryGetValue(ClaveCxC.Componer(cli, ClaveCxC.Normalizar(rc.NumeroNota)), claveNota) Then
                    mov.ClaveDocumento = claveNota
                    mov.TipoLinea = TipoLineaCxC.NotaDebitoSinFactura
                    mov.Concepto = "Pago de la Nota No " & rc.NumeroNota.Trim()
                Else
                    mov.ClaveDocumento = ClaveCxC.Componer("R", cli, ClaveCxC.Normalizar(rc.CodRecibo), ClaveCxC.Fecha(rc.Fecha))
                    mov.TipoLinea = TipoLineaCxC.ReciboSinFactura
                    mov.Concepto = "Recibo sin factura"
                End If
            Else
                Dim f = BuscarFactura(porNumero, cli, rc.NumeroFactura, rc.Fecha)
                If f Is Nothing Then
                    recibosHuerfanos.Add(rc.CodRecibo.Trim() & " → factura " & rc.NumeroFactura.Trim())
                    Continue For
                End If
                mov.ClaveDocumento = ClaveFactura(f)
                mov.TipoLinea = TipoLineaCxC.Factura
                mov.Concepto = "Pago de la Factura No " & rc.NumeroFactura.Trim()
            End If
            movimientos.Add(mov)
        Next

        ' Pagos de contado (todas las formas de pago de la factura, no solo la primera)
        For Each p As CxCPagoContadoDoc In datos.PagosContado
            Dim cli = ClaveCxC.Normalizar(p.CodCliente)
            Dim f As CxCFacturaDoc = Nothing
            If Not porNumeroYFecha.TryGetValue(ClaveCxC.Componer(cli, ClaveCxC.Normalizar(p.NumeroFactura), ClaveCxC.Fecha(p.FechaFactura)), f) Then Continue For
            movimientos.Add(New CxCMovimiento With {
                .Tipo = TipoMovimientoCxC.PagoContado,
                .CodCliente = p.CodCliente,
                .Fecha = p.FechaFactura,
                .Numero = p.NumeroFactura,
                .NumeroFactura = p.NumeroFactura,
                .Concepto = "Pago De Contado Factura No: " & p.NumeroFactura.Trim(),
                .Credito = tasas.Convertir(p.Monto, p.Moneda, destino, p.FechaFactura),
                .ClaveDocumento = ClaveFactura(f),
                .TipoLinea = TipoLineaCxC.Factura
            })
        Next

        ' Advertencias
        If advertencias IsNot Nothing Then
            Dim sinTasa = tasas.FechasSinTasa()
            If sinTasa.Count > 0 Then
                advertencias.Add(String.Format("Faltan tasas de cambio para {0} fecha(s); esos documentos se calcularon en 0: {1}",
                                               sinTasa.Count, Ejemplos(sinTasa.Select(Function(d) d.ToString("dd/MM/yyyy")))))
            End If
            If recibosHuerfanos.Count > 0 Then
                advertencias.Add(String.Format("{0} línea(s) de recibo apuntan a facturas que no están en cartera (canceladas o de otro cliente) y no se tomaron en cuenta: {1}",
                                               recibosHuerfanos.Count, Ejemplos(recibosHuerfanos)))
            End If
            If notasHuerfanas.Count > 0 Then
                advertencias.Add(String.Format("{0} línea(s) de notas apuntan a facturas que no están en cartera y no se tomaron en cuenta: {1}",
                                               notasHuerfanas.Count, Ejemplos(notasHuerfanas)))
            End If
            If duplicadas.Count > 0 Then
                advertencias.Add(String.Format("Hay números de factura repetidos para el mismo cliente; los pagos se asignaron a la factura más reciente anterior al pago: {0}",
                                               Ejemplos(duplicadas)))
            End If
        End If

        Return movimientos
    End Function

    '-------------------------------------------------------------------------------------------------
    ' PASO 2a: saldo por factura (grid de Cuentas x Cobrar / reporte de cuentas por cobrar)
    '-------------------------------------------------------------------------------------------------
    Public Function CalcularSaldos(datos As CxCDatos, filtro As CxCFiltro) As CxCResultado
        Dim resultado As New CxCResultado(filtro)
        Dim movimientos = ResolverMovimientos(datos, filtro.Moneda, resultado.Advertencias)
        Dim lineas As New Dictionary(Of String, CxCLinea)(StringComparer.Ordinal)
        Dim incluirSinFactura = filtro.IncluirDocumentosSinFactura AndAlso Not filtro.FiltraVendedor

        For Each f As CxCFacturaDoc In datos.Facturas
            If Not filtro.VendedorEnRango(f.CodVendedor) Then Continue For
            lineas(ClaveFactura(f)) = New CxCLinea With {
                .TipoLinea = TipoLineaCxC.Factura,
                .FechaFactura = f.Fecha,
                .NumeroFactura = f.Numero,
                .FechaVence = f.FechaVence,
                .CodCliente = f.CodCliente,
                .CodVendedor = f.CodVendedor,
                .NombreVendedor = f.NombreVendedor,
                .MonedaFactura = f.Moneda
            }
        Next

        For Each m As CxCMovimiento In movimientos
            Dim linea As CxCLinea = Nothing
            If Not lineas.TryGetValue(m.ClaveDocumento, linea) Then
                If m.TipoLinea = TipoLineaCxC.Factura OrElse Not incluirSinFactura Then Continue For
                linea = New CxCLinea With {
                    .TipoLinea = m.TipoLinea,
                    .FechaFactura = m.Fecha,
                    .FechaVence = m.Fecha,
                    .NumeroFactura = "0000",
                    .CodCliente = m.CodCliente
                }
                lineas.Add(m.ClaveDocumento, linea)
            End If

            Select Case m.Tipo
                Case TipoMovimientoCxC.Factura
                    linea.Monto += m.Debito
                Case TipoMovimientoCxC.NotaDebito
                    linea.NotaDebitoMonto += m.Debito
                    AgregarUnico(linea.NotasDebito, m.Numero)
                Case TipoMovimientoCxC.NotaCredito
                    linea.NotaCreditoMonto += m.Credito
                    AgregarUnico(linea.NotasCredito, m.Numero)
                Case TipoMovimientoCxC.Recibo
                    linea.Abono += m.Credito
                    AgregarUnico(linea.Recibos, m.Numero)
                Case TipoMovimientoCxC.PagoContado
                    linea.Abono += m.Credito
            End Select
        Next

        For Each linea As CxCLinea In lineas.Values
            Dim cliente = datos.Cliente(linea.CodCliente)
            linea.NombreCliente = If(cliente Is Nothing, "", cliente.Nombre)
            linea.Saldo = linea.Monto - linea.Abono + linea.NotaDebitoMonto - linea.NotaCreditoMonto
            linea.NumeroRecibo = TextoRecibos(linea)
            linea.NotaDebito = TextoNotas(linea)

            If linea.Saldo = 0D Then
                linea.Dias = 0
            Else
                linea.Dias = CInt((filtro.FechaFin.Date - linea.FechaVence.Date).TotalDays)
            End If

            ' Mora solo sobre facturas vencidas con saldo pendiente (antes daba mora negativa si no estaba vencida)
            If linea.TipoLinea = TipoLineaCxC.Factura AndAlso linea.Dias > 0 AndAlso linea.Saldo > 0D AndAlso cliente IsNot Nothing Then
                linea.Moratorio = DineroCxC.Redondear(linea.Dias * linea.Saldo * (cliente.InteresMoratorio / 100D))
            End If
            linea.Total = linea.Saldo + linea.Moratorio
        Next

        resultado.Lineas.AddRange(lineas.Values.
            OrderBy(Function(l) ClaveCxC.Normalizar(l.CodCliente), StringComparer.Ordinal).
            ThenBy(Function(l) l.FechaFactura).
            ThenBy(Function(l) l.NumeroFactura, StringComparer.OrdinalIgnoreCase))
        Return resultado
    End Function

    '-------------------------------------------------------------------------------------------------
    ' PASO 2b: estado de cuenta por cliente (movimiento a movimiento, con saldo corrido)
    '-------------------------------------------------------------------------------------------------
    Public Function EstadoCuenta(datos As CxCDatos, filtro As CxCFiltro, fechaInicio As Date, advertencias As List(Of String)) As List(Of CxCEstadoCuentaFila)
        Dim filas As New List(Of CxCEstadoCuentaFila)
        Dim movimientos = MovimientosDelFiltro(datos, filtro, advertencias)
        Dim desde = fechaInicio.Date
        Dim hasta = filtro.FechaFin.Date

        For Each grupo As IGrouping(Of String, CxCMovimiento) In movimientos.GroupBy(Function(m) ClaveCxC.Normalizar(m.CodCliente)).OrderBy(Function(g) g.Key, StringComparer.Ordinal)
            Dim cliente = datos.Cliente(grupo.Key)
            Dim codigo = If(cliente Is Nothing, grupo.First().CodCliente, cliente.Codigo)
            Dim nombre = If(cliente Is Nothing, "", cliente.Nombre)
            Dim saldoInicial = grupo.Where(Function(m) m.Fecha.Date < desde).Sum(Function(m) m.Debito - m.Credito)
            Dim balance = saldoInicial

            Dim delPeriodo = grupo.Where(Function(m) m.Fecha.Date >= desde AndAlso m.Fecha.Date <= hasta).
                                  OrderBy(Function(m) m.Fecha).
                                  ThenBy(Function(m) CInt(m.Tipo)).
                                  ThenBy(Function(m) m.Numero, StringComparer.OrdinalIgnoreCase).
                                  ToList()

            If delPeriodo.Count = 0 Then
                If saldoInicial <> 0D Then
                    filas.Add(New CxCEstadoCuentaFila With {
                        .CodCliente = codigo, .NombreCliente = nombre, .Fecha = desde, .Numero = "",
                        .TipoDocumento = "", .Concepto = "Saldo anterior", .SaldoInicial = saldoInicial, .Balance = saldoInicial})
                End If
                Continue For
            End If

            For Each m As CxCMovimiento In delPeriodo
                balance += m.Debito - m.Credito
                filas.Add(New CxCEstadoCuentaFila With {
                    .CodCliente = codigo,
                    .NombreCliente = nombre,
                    .Fecha = m.Fecha,
                    .Numero = m.Numero,
                    .TipoDocumento = TipoDocumentoTexto(m.Tipo),
                    .Concepto = m.Concepto,
                    .SaldoInicial = saldoInicial,
                    .Debito = m.Debito,
                    .Credito = m.Credito,
                    .Balance = balance
                })
            Next
        Next
        Return filas
    End Function

    '-------------------------------------------------------------------------------------------------
    ' PASO 2c: saldo de clientes (saldo inicial, débitos, créditos y saldo final del periodo)
    '-------------------------------------------------------------------------------------------------
    Public Function SaldosClientes(datos As CxCDatos, filtro As CxCFiltro, fechaInicio As Date, advertencias As List(Of String)) As List(Of CxCSaldoClienteFila)
        Dim filas As New List(Of CxCSaldoClienteFila)
        Dim movimientos = MovimientosDelFiltro(datos, filtro, advertencias)
        Dim desde = fechaInicio.Date
        Dim hasta = filtro.FechaFin.Date

        For Each grupo As IGrouping(Of String, CxCMovimiento) In movimientos.GroupBy(Function(m) ClaveCxC.Normalizar(m.CodCliente)).OrderBy(Function(g) g.Key, StringComparer.Ordinal)
            Dim cliente = datos.Cliente(grupo.Key)
            Dim fila As New CxCSaldoClienteFila With {
                .CodCliente = If(cliente Is Nothing, grupo.First().CodCliente, cliente.Codigo),
                .NombreCliente = If(cliente Is Nothing, "", cliente.Nombre),
                .SaldoInicial = grupo.Where(Function(m) m.Fecha.Date < desde).Sum(Function(m) m.Debito - m.Credito),
                .Debito = grupo.Where(Function(m) m.Fecha.Date >= desde AndAlso m.Fecha.Date <= hasta).Sum(Function(m) m.Debito),
                .Credito = grupo.Where(Function(m) m.Fecha.Date >= desde AndAlso m.Fecha.Date <= hasta).Sum(Function(m) m.Credito)
            }
            If fila.SaldoInicial <> 0D OrElse fila.Debito <> 0D OrElse fila.Credito <> 0D Then filas.Add(fila)
        Next
        Return filas
    End Function

    '-------------------------------------------------------------------------------------------------
    ' PASO 2d: antigüedad de saldos, a partir del mismo resultado por factura
    '-------------------------------------------------------------------------------------------------
    Public Function Antiguedad(resultado As CxCResultado) As List(Of CxCAntiguedadFila)
        Dim porVendedor = resultado.Filtro.FiltraVendedor
        Dim filas As New List(Of CxCAntiguedadFila)

        Dim grupos = resultado.Lineas.GroupBy(Function(l) If(porVendedor,
                                                              ClaveCxC.Componer(ClaveCxC.Normalizar(l.CodVendedor), ClaveCxC.Normalizar(l.CodCliente)),
                                                              ClaveCxC.Normalizar(l.CodCliente)))
        For Each g As IGrouping(Of String, CxCLinea) In grupos
            Dim primera = g.First()
            Dim conVendedor = g.Where(Function(l) ClaveCxC.Normalizar(l.CodVendedor) <> "").
                                OrderByDescending(Function(l) ClaveCxC.Normalizar(l.CodVendedor), StringComparer.Ordinal).
                                FirstOrDefault()
            Dim fila As New CxCAntiguedadFila With {
                .CodCliente = primera.CodCliente,
                .NombreCliente = primera.NombreCliente,
                .CodVendedor = If(conVendedor Is Nothing, "", conVendedor.CodVendedor),
                .NombreVendedor = If(conVendedor Is Nothing, "", conVendedor.NombreVendedor)
            }
            For Each l As CxCLinea In g
                Select Case l.Dias
                    Case Is <= 0 : fila.Corriente += l.Saldo
                    Case 1 To 30 : fila.Dias30 += l.Saldo
                    Case 31 To 60 : fila.Dias60 += l.Saldo
                    Case 61 To 90 : fila.Dias90 += l.Saldo
                    Case Else : fila.Mas90 += l.Saldo
                End Select
            Next
            If fila.Corriente <> 0D OrElse fila.Dias30 <> 0D OrElse fila.Dias60 <> 0D OrElse fila.Dias90 <> 0D OrElse fila.Mas90 <> 0D Then
                filas.Add(fila)
            End If
        Next

        If porVendedor Then
            Return filas.OrderBy(Function(f) ClaveCxC.Normalizar(f.CodVendedor), StringComparer.Ordinal).
                         ThenBy(Function(f) ClaveCxC.Normalizar(f.CodCliente), StringComparer.Ordinal).ToList()
        End If
        Return filas.OrderBy(Function(f) ClaveCxC.Normalizar(f.CodCliente), StringComparer.Ordinal).ToList()
    End Function

    '-------------------------------------------------------------------------------------------------
    ' Auxiliares
    '-------------------------------------------------------------------------------------------------

    ''' <summary>Movimientos de los clientes del filtro (con vendedor: clientes que tienen facturas de esos vendedores).</summary>
    Private Function MovimientosDelFiltro(datos As CxCDatos, filtro As CxCFiltro, advertencias As List(Of String)) As List(Of CxCMovimiento)
        Dim movimientos = ResolverMovimientos(datos, filtro.Moneda, advertencias)
        If Not filtro.IncluirDocumentosSinFactura Then
            movimientos = movimientos.Where(Function(m) m.TipoLinea = TipoLineaCxC.Factura).ToList()
        End If
        If filtro.FiltraVendedor Then
            Dim clientes = New HashSet(Of String)(datos.Facturas.Where(Function(f) filtro.VendedorEnRango(f.CodVendedor)).
                                                                 Select(Function(f) ClaveCxC.Normalizar(f.CodCliente)), StringComparer.Ordinal)
            movimientos = movimientos.Where(Function(m) clientes.Contains(ClaveCxC.Normalizar(m.CodCliente))).ToList()
        End If
        Return movimientos
    End Function

    Private Shared Function ClaveFactura(f As CxCFacturaDoc) As String
        Return ClaveCxC.Componer("F", ClaveCxC.Normalizar(f.CodCliente), ClaveCxC.Normalizar(f.Numero), ClaveCxC.Fecha(f.Fecha))
    End Function

    ''' <summary>Si el número de factura se repite, toma la más reciente con fecha menor o igual al documento.</summary>
    Private Shared Function BuscarFactura(indice As Dictionary(Of String, List(Of CxCFacturaDoc)), cliente As String, numero As String, fechaDocumento As Date) As CxCFacturaDoc
        Dim lista As List(Of CxCFacturaDoc) = Nothing
        If Not indice.TryGetValue(ClaveCxC.Componer(cliente, ClaveCxC.Normalizar(numero)), lista) Then Return Nothing
        If lista.Count = 1 Then Return lista(0)
        Dim candidata = lista.Where(Function(f) f.Fecha.Date <= fechaDocumento.Date).OrderByDescending(Function(f) f.Fecha).FirstOrDefault()
        Return If(candidata, lista.OrderBy(Function(f) f.Fecha).First())
    End Function

    Private Shared Function ConceptoNota(n As CxCNotaDoc) As String
        Dim descripcion = n.Descripcion.Trim()
        Dim observaciones = n.Observaciones.Trim()
        If descripcion = "*******ANULADO*******" OrElse ClaveCxC.EsSinFactura(n.NumeroFactura) Then
            Return (descripcion & " " & observaciones).Trim()
        End If
        Return (descripcion & " Factura No " & n.NumeroFactura.Trim() & " " & observaciones).Trim()
    End Function

    Private Shared Function TipoDocumentoTexto(tipo As TipoMovimientoCxC) As String
        Select Case tipo
            Case TipoMovimientoCxC.Factura : Return "Factura"
            Case TipoMovimientoCxC.NotaDebito : Return "N/D"
            Case TipoMovimientoCxC.Recibo : Return "Recibo"
            Case TipoMovimientoCxC.NotaCredito : Return "N/C"
            Case Else : Return "Efectivo"
        End Select
    End Function

    Private Shared Function TextoRecibos(linea As CxCLinea) As String
        Select Case linea.TipoLinea
            Case TipoLineaCxC.Factura
                Return String.Join(",", linea.Recibos)
            Case Else
                Return If(linea.Recibos.Count = 0, "0000", String.Join(",", linea.Recibos))
        End Select
    End Function

    Private Shared Function TextoNotas(linea As CxCLinea) As String
        Dim nb = String.Join(",", linea.NotasDebito)
        Dim nc = String.Join(",", linea.NotasCredito)
        If nb = "" AndAlso nc = "" Then Return ""
        If nb = "" Then Return "NC:" & nc
        If nc = "" Then Return "NB:" & nb
        Return "NC:" & nc & " NB:" & nb
    End Function

    Private Shared Sub AgregarUnico(lista As List(Of String), valor As String)
        Dim v = If(valor, "").Trim()
        If v <> "" AndAlso Not lista.Contains(v) Then lista.Add(v)
    End Sub

    Private Shared Function Ejemplos(valores As IEnumerable(Of String)) As String
        Dim lista = valores.Take(MaxEjemplos + 1).ToList()
        Dim texto = String.Join(", ", lista.Take(MaxEjemplos))
        If lista.Count > MaxEjemplos Then texto &= ", ..."
        Return texto
    End Function
End Class
