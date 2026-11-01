Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

'=====================================================================================================
'  CUENTAS POR PAGAR - ACCESO A DATOS
'  Una sola ida a SQL Server con consultas parametrizadas (antes: 5 a 7 consultas POR COMPRA con SQL
'  armado por concatenación). Los montos float se convierten a decimal en SQL.
'=====================================================================================================
Public Class CxPRepositorio

    Private ReadOnly _cadenaConexion As String

    Public Property TiempoEsperaSegundos As Integer = 180

    Public Sub New(cadenaConexion As String)
        If String.IsNullOrWhiteSpace(cadenaConexion) Then Throw New ArgumentException("Cadena de conexión vacía.", NameOf(cadenaConexion))
        _cadenaConexion = cadenaConexion
    End Sub

    ' Una compra es de contado cuando alguna de sus formas de pago cubre todo el monto.
    Private Const CondicionCredito As String =
"NOT EXISTS (SELECT 1 FROM Detalle_MetodoCompras DM
             WHERE DM.Numero_Compra = C.Numero_Compra AND DM.Fecha_Compra = C.Fecha_Compra
               AND DM.Tipo_Compra = C.Tipo_Compra AND DM.Monto = C.SubTotal + C.IVA)"

    Private Const SqlCarga As String =
"SET NOCOUNT ON;

-- 1) Proveedor
SELECT Cod_Proveedor,
       LTRIM(RTRIM(ISNULL(Nombre_Proveedor, N'') + N' ' + ISNULL(Apellido_Proveedor, N''))) AS Nombre
FROM Proveedor
WHERE Cod_Proveedor = @Proveedor;

-- 2) Compras a crédito (mercancía recibida y cuentas)
SELECT C.Numero_Compra, C.Tipo_Compra, C.Fecha_Compra, C.Fecha_Vencimiento, C.MonedaCompra, C.Cod_Proveedor,
       C.Su_Referencia, C.Observaciones,
       CAST(ISNULL(C.SubTotal, 0) AS decimal(19, 4)) + CAST(ISNULL(C.IVA, 0) AS decimal(19, 4)) AS Monto,
       CAST(0 AS decimal(19, 4)) AS NetoPagar
FROM Compras C
WHERE C.Cod_Proveedor = @Proveedor
  AND C.Tipo_Compra IN ('Mercancia Recibida', 'Cuenta')
  AND C.Fecha_Compra <= @FechaFin
  AND " & CondicionCredito & ";

-- 3) Devoluciones de compra a crédito
SELECT C.Numero_Compra, C.Tipo_Compra, C.Fecha_Compra, C.Fecha_Vencimiento, C.MonedaCompra, C.Cod_Proveedor,
       C.Su_Referencia, C.Observaciones,
       CAST(ISNULL(C.SubTotal, 0) AS decimal(19, 4)) + CAST(ISNULL(C.IVA, 0) AS decimal(19, 4)) AS Monto,
       CAST(ISNULL(C.NetoPagar, 0) AS decimal(19, 4)) AS NetoPagar
FROM Compras C
WHERE C.Cod_Proveedor = @Proveedor
  AND C.Tipo_Compra = 'Devolucion de Compra'
  AND C.Fecha_Compra <= @FechaFin
  AND " & CondicionCredito & ";

-- 4) Pagos (recibos de pago)
SELECT R.Cod_Proveedor, D.CodReciboPago, D.Fecha_Recibo, D.Numero_Compra,
       CAST(ISNULL(D.MontoPagado, 0) AS decimal(19, 4)) AS Monto, R.MonedaRecibo
FROM DetalleReciboPago D
INNER JOIN ReciboPago R ON R.CodReciboPago = D.CodReciboPago AND R.Fecha_Recibo = D.Fecha_Recibo
WHERE R.Cod_Proveedor = @Proveedor
  AND D.Fecha_Recibo <= @FechaFin;

-- 5) Notas de débito y crédito de proveedores (IndiceNota.Cod_Cliente guarda el código del proveedor)
--    NotaDebito.CodigoNB se repite entre tipos; se elige el tipo cuya descripción coincide con la de la nota.
SELECT I.Cod_Cliente, DN.Numero_Nota, DN.Fecha_Nota, DN.Tipo_Nota, ND.Tipo, DN.Numero_Factura,
       CAST(ISNULL(DN.Monto, 0) AS decimal(19, 4)) AS Monto, I.MonedaNota
FROM Detalle_Nota DN
INNER JOIN IndiceNota I ON I.Numero_Nota = DN.Numero_Nota AND I.Fecha_Nota = DN.Fecha_Nota AND I.Tipo_Nota = DN.Tipo_Nota
CROSS APPLY (SELECT TOP (1) T.Tipo
             FROM NotaDebito T
             WHERE T.CodigoNB = DN.Tipo_Nota
             ORDER BY CASE WHEN LTRIM(RTRIM(T.Descripcion)) = LTRIM(RTRIM(DN.Descripcion)) THEN 0 ELSE 1 END, T.Tipo) ND
WHERE I.Cod_Cliente = @Proveedor
  AND DN.Fecha_Nota <= @FechaFin
  AND (ND.Tipo LIKE '%Debito Proveedores%' OR ND.Tipo LIKE '%Credito Proveedores%');

-- 6) Pagos de contado de compras a crédito (detalle de forma de pago de la compra)
SELECT DM.Numero_Compra, DM.Tipo_Compra, DM.Fecha_Compra,
       CAST(ISNULL(DM.Monto, 0) AS decimal(19, 4)) AS Monto, MP.Moneda
FROM Detalle_MetodoCompras DM
INNER JOIN MetodoPago MP ON MP.NombrePago = DM.NombrePago
INNER JOIN Compras C ON C.Numero_Compra = DM.Numero_Compra AND C.Fecha_Compra = DM.Fecha_Compra AND C.Tipo_Compra = DM.Tipo_Compra
WHERE C.Cod_Proveedor = @Proveedor
  AND DM.Tipo_Compra = 'Mercancia Recibida'
  AND C.Fecha_Compra <= @FechaFin;

-- 7) Tasas de cambio
SELECT FechaTasa, CAST(MontoTasa AS decimal(19, 8)) AS MontoTasa
FROM TasaCambio
WHERE FechaTasa <= @FechaFin AND MontoTasa IS NOT NULL AND MontoTasa <> 0;"

    ''' <summary>Carga todos los documentos del proveedor hasta la fecha de corte.</summary>
    Public Function Cargar(filtro As CxPFiltro) As CxPDatos
        If filtro Is Nothing Then Throw New ArgumentNullException(NameOf(filtro))

        Dim datos As New CxPDatos With {.FechaFin = filtro.FechaFin.Date}

        Using cn As New SqlConnection(_cadenaConexion)
            Using cmd As New SqlCommand(SqlCarga, cn)
                cmd.CommandTimeout = TiempoEsperaSegundos
                cmd.Parameters.Add("@Proveedor", SqlDbType.NVarChar, 50).Value = If(filtro.CodProveedor, "").Trim()
                cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = filtro.FechaFin.Date

                cn.Open()
                Using r = cmd.ExecuteReader()
                    LeerProveedores(r, datos)
                    r.NextResult() : LeerCompras(r, datos.Compras)
                    r.NextResult() : LeerCompras(r, datos.Devoluciones)
                    r.NextResult() : LeerPagos(r, datos)
                    r.NextResult() : LeerNotas(r, datos)
                    r.NextResult() : LeerPagosContado(r, datos)
                    r.NextResult() : LeerTasas(r, datos)
                End Using
            End Using
        End Using

        Return datos
    End Function

    ''' <summary>Lista de proveedores para el combo del formulario (Cod_Proveedor, Nombres).</summary>
    Public Function ListarProveedores() As DataTable
        Const sql As String = "SELECT Cod_Proveedor, LTRIM(RTRIM(ISNULL(Nombre_Proveedor, N'') + N' ' + ISNULL(Apellido_Proveedor, N''))) AS Nombres FROM Proveedor ORDER BY Cod_Proveedor"
        Dim tabla As New DataTable("Proveedores")
        Using da As New SqlDataAdapter(sql, _cadenaConexion)
            da.Fill(tabla)
        End Using
        Return tabla
    End Function

    ''' <summary>Datos de la empresa para el encabezado del reporte (vacíos si no hay registro).</summary>
    Public Function ObtenerEmpresa() As CxPEmpresa
        Dim empresa As New CxPEmpresa()
        Using cn As New SqlConnection(_cadenaConexion)
            Using cmd As New SqlCommand("SELECT TOP (1) Nombre_Empresa, Direccion_Empresa, Numero_Ruc, Ruta_Logo FROM DatosEmpresa", cn)
                cn.Open()
                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        empresa.Nombre = Texto(r, 0)
                        empresa.Direccion = Texto(r, 1)
                        If Not r.IsDBNull(2) Then empresa.Ruc = "Numero RUC " & Texto(r, 2)
                        empresa.RutaLogo = Texto(r, 3)
                    End If
                End Using
            End Using
        End Using
        Return empresa
    End Function

    ''' <summary>
    ''' Guarda en Compras lo pagado y el saldo a crédito (en la moneda de la compra), igual que hacía el
    ''' formulario anterior. Todo en una sola transacción. Devuelve cuántas compras se actualizaron.
    ''' </summary>
    Public Function ActualizarMontoCredito(lineas As IEnumerable(Of CxPLinea)) As Integer
        Dim actualizadas = 0
        Using cn As New SqlConnection(_cadenaConexion)
            cn.Open()
            Using tx = cn.BeginTransaction()
                Using cmd As New SqlCommand(
                    "UPDATE Compras SET Pagado = @Pagado, MontoCredito = @MontoCredito, AplicarCtasXPagar = 1 " &
                    "WHERE Numero_Compra = @Numero AND Tipo_Compra = @Tipo AND Fecha_Compra = @Fecha", cn, tx)
                    cmd.CommandTimeout = TiempoEsperaSegundos
                    Dim pPagado = cmd.Parameters.Add("@Pagado", SqlDbType.Decimal)
                    Dim pCredito = cmd.Parameters.Add("@MontoCredito", SqlDbType.Decimal)
                    For Each p In New SqlParameter() {pPagado, pCredito}
                        p.Precision = 19
                        p.Scale = 2
                    Next
                    Dim pNumero = cmd.Parameters.Add("@Numero", SqlDbType.NVarChar, 50)
                    Dim pTipo = cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50)
                    Dim pFecha = cmd.Parameters.Add("@Fecha", SqlDbType.DateTime)

                    For Each l As CxPLinea In lineas
                        If l.TipoLinea <> TipoLineaCxP.Compra Then Continue For
                        pPagado.Value = DineroCxC.Redondear(l.PagadoMonedaCompra)
                        pCredito.Value = DineroCxC.Redondear(l.MontoCompraOriginal - l.PagadoMonedaCompra)
                        pNumero.Value = l.NumeroCompra
                        pTipo.Value = l.TipoCompra
                        pFecha.Value = l.FechaCompra
                        If cmd.ExecuteNonQuery() > 0 Then actualizadas += 1
                    Next
                End Using
                tx.Commit()
            End Using
        End Using
        Return actualizadas
    End Function

    '------------------------------------------------------------------------------------------------
    Private Shared Sub LeerProveedores(r As SqlDataReader, datos As CxPDatos)
        While r.Read()
            Dim p As New CxPProveedorDoc With {.Codigo = Texto(r, 0), .Nombre = Texto(r, 1)}
            datos.Proveedores(ClaveCxC.Normalizar(p.Codigo)) = p
        End While
    End Sub

    Private Shared Sub LeerCompras(r As SqlDataReader, destino As List(Of CxPCompraDoc))
        While r.Read()
            Dim fecha = r.GetDateTime(2)
            destino.Add(New CxPCompraDoc With {
                .Numero = Texto(r, 0),
                .TipoCompra = Texto(r, 1),
                .Fecha = fecha,
                .FechaVence = If(r.IsDBNull(3), fecha, r.GetDateTime(3)),
                .Moneda = DineroCxC.MonedaDesdeTexto(Texto(r, 4)),
                .CodProveedor = Texto(r, 5),
                .Referencia = Texto(r, 6),
                .Observaciones = Texto(r, 7),
                .Monto = Numero(r, 8),
                .NetoPagar = Numero(r, 9)
            })
        End While
    End Sub

    Private Shared Sub LeerPagos(r As SqlDataReader, datos As CxPDatos)
        While r.Read()
            datos.Pagos.Add(New CxPPagoDoc With {
                .CodProveedor = Texto(r, 0),
                .CodRecibo = Texto(r, 1),
                .Fecha = r.GetDateTime(2),
                .NumeroCompra = Texto(r, 3),
                .Monto = Numero(r, 4),
                .Moneda = DineroCxC.MonedaDesdeTexto(Texto(r, 5))
            })
        End While
    End Sub

    Private Shared Sub LeerNotas(r As SqlDataReader, datos As CxPDatos)
        While r.Read()
            datos.Notas.Add(New CxPNotaDoc With {
                .CodProveedor = Texto(r, 0),
                .NumeroNota = Texto(r, 1),
                .Fecha = r.GetDateTime(2),
                .CodigoTipoNota = Texto(r, 3),
                .TipoNota = Texto(r, 4),
                .NumeroCompra = Texto(r, 5),
                .Monto = Numero(r, 6),
                .Moneda = DineroCxC.MonedaDesdeTexto(Texto(r, 7))
            })
        End While
    End Sub

    Private Shared Sub LeerPagosContado(r As SqlDataReader, datos As CxPDatos)
        While r.Read()
            datos.PagosContado.Add(New CxPPagoContadoDoc With {
                .NumeroCompra = Texto(r, 0),
                .TipoCompra = Texto(r, 1),
                .FechaCompra = r.GetDateTime(2),
                .Monto = Numero(r, 3),
                .Moneda = DineroCxC.MonedaDesdeTexto(Texto(r, 4))
            })
        End While
    End Sub

    Private Shared Sub LeerTasas(r As SqlDataReader, datos As CxPDatos)
        While r.Read()
            datos.Tasas.Agregar(r.GetDateTime(0), Numero(r, 1))
        End While
    End Sub

    Private Shared Function Texto(r As SqlDataReader, i As Integer) As String
        If r.IsDBNull(i) Then Return ""
        Return Convert.ToString(r.GetValue(i))
    End Function

    Private Shared Function Numero(r As SqlDataReader, i As Integer) As Decimal
        If r.IsDBNull(i) Then Return 0D
        Return Convert.ToDecimal(r.GetValue(i))
    End Function
End Class
