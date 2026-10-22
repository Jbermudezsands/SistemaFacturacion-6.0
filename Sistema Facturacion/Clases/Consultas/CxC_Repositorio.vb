Option Strict On
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

'=====================================================================================================
'  CUENTAS POR COBRAR - ACCESO A DATOS
'  Una sola ida a SQL Server con 6 consultas parametrizadas (antes: 5 a 7 consultas POR FACTURA).
'  Los montos float se convierten a decimal en SQL para no arrastrar errores de punto flotante.
'=====================================================================================================
Public Class CxCRepositorio

    Private ReadOnly _cadenaConexion As String

    Public Property TiempoEsperaSegundos As Integer = 180

    Public Sub New(cadenaConexion As String)
        If String.IsNullOrWhiteSpace(cadenaConexion) Then Throw New ArgumentException("Cadena de conexión vacía.", NameOf(cadenaConexion))
        _cadenaConexion = cadenaConexion
    End Sub

    Private Const SqlCarga As String =
"SET NOCOUNT ON;

IF OBJECT_ID('tempdb..#CliCxC') IS NOT NULL DROP TABLE #CliCxC;

SELECT C.Cod_Cliente,
       LTRIM(RTRIM(ISNULL(C.Nombre_Cliente, N'') + N' ' + ISNULL(C.Apellido_Cliente, N''))) AS Nombre,
       C.InteresMoratorio
INTO #CliCxC
FROM Clientes C
WHERE (@CliIni IS NULL OR C.Cod_Cliente >= @CliIni)
  AND (@CliFin IS NULL OR C.Cod_Cliente <= @CliFin)
  AND (@ZonaIni IS NULL OR C.{0} >= @ZonaIni)
  AND (@ZonaFin IS NULL OR C.{0} <= @ZonaFin);

CREATE CLUSTERED INDEX IX_CliCxC ON #CliCxC (Cod_Cliente);

-- 1) Clientes
SELECT Cod_Cliente, Nombre, InteresMoratorio FROM #CliCxC;

-- 2) Facturas (crédito y contado; las de contado se compensan con su detalle de pago)
SELECT F.Numero_Factura, F.Fecha_Factura, F.Fecha_Vencimiento, F.MonedaFactura, F.Cod_Cliente, F.Cod_Vendedor,
       LTRIM(RTRIM(ISNULL(V.Nombre_Vendedor, N'') + N' ' + ISNULL(V.Apellido_Vendedor, N''))) AS NombreVendedor,
       CAST(ISNULL(F.SubTotal, 0) AS decimal(19, 4)) + CAST(ISNULL(F.IVA, 0) AS decimal(19, 4)) AS Monto
FROM Facturas F
INNER JOIN #CliCxC C ON C.Cod_Cliente = F.Cod_Cliente
LEFT JOIN Vendedores V ON V.Cod_Vendedor = F.Cod_Vendedor
WHERE F.Tipo_Factura = N'Factura'
  AND F.Nombre_Cliente <> N'******CANCELADO'
  AND F.Fecha_Factura <= @FechaFin;

-- 3) Recibos
SELECT R.Cod_Cliente, D.CodReciboPago, D.Fecha_Recibo, D.Numero_Factura, D.Numero_Nota,
       CAST(ISNULL(D.MontoPagado, 0) AS decimal(19, 4)) AS Monto, R.MonedaRecibo
FROM DetalleRecibo D
INNER JOIN Recibo R ON R.CodReciboPago = D.CodReciboPago AND R.Fecha_Recibo = D.Fecha_Recibo
INNER JOIN #CliCxC C ON C.Cod_Cliente = R.Cod_Cliente
WHERE D.Fecha_Recibo <= @FechaFin;

-- 4) Notas de débito y crédito de clientes
--    NotaDebito.CodigoNB se repite (1-8 existe como débito y como crédito); unir solo por código
--    duplicaba la nota como débito Y crédito. Se elige el tipo cuya descripción coincide con la de la nota.
SELECT I.Cod_Cliente, DN.Numero_Nota, DN.Fecha_Nota, DN.Tipo_Nota, ND.Tipo, DN.Numero_Factura,
       CAST(ISNULL(DN.Monto, 0) AS decimal(19, 4)) AS Monto, I.MonedaNota, DN.Descripcion, I.Observaciones
FROM Detalle_Nota DN
INNER JOIN IndiceNota I ON I.Numero_Nota = DN.Numero_Nota AND I.Fecha_Nota = DN.Fecha_Nota AND I.Tipo_Nota = DN.Tipo_Nota
INNER JOIN #CliCxC C ON C.Cod_Cliente = I.Cod_Cliente
CROSS APPLY (SELECT TOP (1) T.Tipo
             FROM NotaDebito T
             WHERE T.CodigoNB = DN.Tipo_Nota
             ORDER BY CASE WHEN LTRIM(RTRIM(T.Descripcion)) = LTRIM(RTRIM(DN.Descripcion)) THEN 0 ELSE 1 END, T.Tipo) ND
WHERE DN.Fecha_Nota <= @FechaFin
  AND (ND.Tipo LIKE N'%Debito Clientes%' OR ND.Tipo LIKE N'%Credito Clientes%');

-- 5) Pagos de contado (detalle de método de pago de la factura)
SELECT F.Cod_Cliente, DM.Numero_Factura, DM.Fecha_Factura,
       CAST(ISNULL(DM.Monto, 0) AS decimal(19, 4)) AS Monto, MP.Moneda
FROM Detalle_MetodoFacturas DM
INNER JOIN MetodoPago MP ON MP.NombrePago = DM.NombrePago
INNER JOIN Facturas F ON F.Numero_Factura = DM.Numero_Factura AND F.Fecha_Factura = DM.Fecha_Factura AND F.Tipo_Factura = DM.Tipo_Factura
INNER JOIN #CliCxC C ON C.Cod_Cliente = F.Cod_Cliente
WHERE DM.Tipo_Factura = N'Factura'
  AND F.Nombre_Cliente <> N'******CANCELADO'
  AND F.Fecha_Factura <= @FechaFin;

-- 6) Tasas de cambio
SELECT FechaTasa, CAST(MontoTasa AS decimal(19, 8)) AS MontoTasa
FROM TasaCambio
WHERE FechaTasa <= @FechaFin AND MontoTasa IS NOT NULL AND MontoTasa <> 0;

DROP TABLE #CliCxC;"

    ''' <summary>Carga todos los documentos de los clientes del filtro hasta la fecha de corte.</summary>
    Public Function Cargar(filtro As CxCFiltro) As CxCDatos
        If filtro Is Nothing Then Throw New ArgumentNullException(NameOf(filtro))

        Dim campoZona = If(filtro.CampoZona = CampoZonaCxC.Municipio, "Municipio", "Departamento")
        Dim datos As New CxCDatos With {.FechaFin = filtro.FechaFin.Date}

        Using cn As New SqlConnection(_cadenaConexion)
            Using cmd As New SqlCommand(String.Format(SqlCarga, campoZona), cn)
                cmd.CommandTimeout = TiempoEsperaSegundos
                AgregarTexto(cmd, "@CliIni", filtro.ClienteDesde)
                AgregarTexto(cmd, "@CliFin", filtro.ClienteHasta)
                AgregarTexto(cmd, "@ZonaIni", filtro.ZonaDesde)
                AgregarTexto(cmd, "@ZonaFin", filtro.ZonaHasta)
                cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = filtro.FechaFin.Date

                cn.Open()
                Using r = cmd.ExecuteReader()
                    LeerClientes(r, datos)
                    r.NextResult() : LeerFacturas(r, datos)
                    r.NextResult() : LeerRecibos(r, datos)
                    r.NextResult() : LeerNotas(r, datos)
                    r.NextResult() : LeerPagosContado(r, datos)
                    r.NextResult() : LeerTasas(r, datos)
                End Using
            End Using
        End Using

        Return datos
    End Function

    ''' <summary>Lista de clientes para el combo del formulario (Codigo, Nombres).</summary>
    Public Function ListarClientes() As DataTable
        Const sql As String = "SELECT Cod_Cliente AS Codigo, LTRIM(RTRIM(ISNULL(Nombre_Cliente, N'') + N' ' + ISNULL(Apellido_Cliente, N''))) AS Nombres FROM Clientes ORDER BY Cod_Cliente"
        Dim tabla As New DataTable("Clientes")
        Using da As New SqlDataAdapter(sql, _cadenaConexion)
            da.Fill(tabla)
        End Using
        Return tabla
    End Function

    ''' <summary>Código de la nota de diferencial cambiario configurada (NotaDebito.Tipo).</summary>
    Public Function BuscarNotaPorTipo(tipo As String) As String
        Using cn As New SqlConnection(_cadenaConexion)
            Using cmd As New SqlCommand("SELECT TOP (1) CodigoNB FROM NotaDebito WHERE Tipo = @Tipo", cn)
                cmd.Parameters.Add("@Tipo", SqlDbType.NVarChar, 50).Value = tipo
                cn.Open()
                Dim valor = cmd.ExecuteScalar()
                If valor Is Nothing OrElse Convert.IsDBNull(valor) Then Return Nothing
                Return CStr(valor)
            End Using
        End Using
    End Function

    '------------------------------------------------------------------------------------------------
    Private Shared Sub AgregarTexto(cmd As SqlCommand, nombre As String, valor As String)
        Dim p = cmd.Parameters.Add(nombre, SqlDbType.NVarChar, 50)
        If String.IsNullOrWhiteSpace(valor) Then
            p.Value = DBNull.Value
        Else
            p.Value = valor.Trim()
        End If
    End Sub

    Private Shared Sub LeerClientes(r As SqlDataReader, datos As CxCDatos)
        While r.Read()
            Dim c As New CxCClienteDoc With {
                .Codigo = Texto(r, 0),
                .Nombre = Texto(r, 1),
                .InteresMoratorio = Numero(r, 2)
            }
            datos.Clientes(ClaveCxC.Normalizar(c.Codigo)) = c
        End While
    End Sub

    Private Shared Sub LeerFacturas(r As SqlDataReader, datos As CxCDatos)
        While r.Read()
            Dim fecha = r.GetDateTime(1)
            datos.Facturas.Add(New CxCFacturaDoc With {
                .Numero = Texto(r, 0),
                .Fecha = fecha,
                .FechaVence = If(r.IsDBNull(2), fecha, r.GetDateTime(2)),
                .Moneda = DineroCxC.MonedaDesdeTexto(Texto(r, 3)),
                .CodCliente = Texto(r, 4),
                .CodVendedor = Texto(r, 5),
                .NombreVendedor = Texto(r, 6),
                .Monto = Numero(r, 7)
            })
        End While
    End Sub

    Private Shared Sub LeerRecibos(r As SqlDataReader, datos As CxCDatos)
        While r.Read()
            datos.Recibos.Add(New CxCReciboDoc With {
                .CodCliente = Texto(r, 0),
                .CodRecibo = Texto(r, 1),
                .Fecha = r.GetDateTime(2),
                .NumeroFactura = Texto(r, 3),
                .NumeroNota = Texto(r, 4),
                .Monto = Numero(r, 5),
                .Moneda = DineroCxC.MonedaDesdeTexto(Texto(r, 6))
            })
        End While
    End Sub

    Private Shared Sub LeerNotas(r As SqlDataReader, datos As CxCDatos)
        While r.Read()
            datos.Notas.Add(New CxCNotaDoc With {
                .CodCliente = Texto(r, 0),
                .NumeroNota = Texto(r, 1),
                .Fecha = r.GetDateTime(2),
                .CodigoTipoNota = Texto(r, 3),
                .TipoNota = Texto(r, 4),
                .NumeroFactura = Texto(r, 5),
                .Monto = Numero(r, 6),
                .Moneda = DineroCxC.MonedaDesdeTexto(Texto(r, 7)),
                .Descripcion = Texto(r, 8),
                .Observaciones = Texto(r, 9)
            })
        End While
    End Sub

    Private Shared Sub LeerPagosContado(r As SqlDataReader, datos As CxCDatos)
        While r.Read()
            datos.PagosContado.Add(New CxCPagoContadoDoc With {
                .CodCliente = Texto(r, 0),
                .NumeroFactura = Texto(r, 1),
                .FechaFactura = r.GetDateTime(2),
                .Monto = Numero(r, 3),
                .Moneda = DineroCxC.MonedaDesdeTexto(Texto(r, 4))
            })
        End While
    End Sub

    Private Shared Sub LeerTasas(r As SqlDataReader, datos As CxCDatos)
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
