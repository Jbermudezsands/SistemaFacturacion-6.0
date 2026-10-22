Imports System.Data
Imports System.Data.SqlClient

Public Class ReporteLotesVencimientoService

    Private ReadOnly _conexion As String

    Public Sub New(ByVal cadenaConexion As String)

        If String.IsNullOrEmpty(cadenaConexion) Then
            Throw New ArgumentException(
                "La cadena de conexión no puede estar vacía.")
        End If

        _conexion = cadenaConexion

    End Sub

    ''' <summary>
    ''' Lotes activos con existencia que vencen dentro del intervalo
    ''' del filtro, ordenados por fecha de vencimiento.
    ''' </summary>
    Public Function ObtenerLotes(
        ByVal filtro As FiltroReporteLotesVencimiento
    ) As List(Of LoteVencimiento)

        ValidarFiltro(filtro)

        Dim lotes As New List(Of LoteVencimiento)

        Using cn As New SqlConnection(_conexion),
              cmd As New SqlCommand(ConstruirConsulta(filtro), cn)

            cmd.CommandTimeout = 120

            cmd.Parameters.Add("@FechaDesde", SqlDbType.DateTime).Value =
                filtro.FechaDesde.Date
            cmd.Parameters.Add("@FechaHasta", SqlDbType.DateTime).Value =
                filtro.FechaHasta.Date
            cmd.Parameters.Add("@FechaCorte", SqlDbType.DateTime).Value =
                filtro.FechaCorte.Date

            If filtro.FiltrarPorBodega Then
                cmd.Parameters.Add("@BodegaDesde", SqlDbType.NVarChar, 50).Value =
                    filtro.CodigoBodegaDesde
                cmd.Parameters.Add("@BodegaHasta", SqlDbType.NVarChar, 50).Value =
                    filtro.CodigoBodegaHasta
            End If

            If filtro.FiltrarPorLinea Then
                cmd.Parameters.Add("@LineaDesde", SqlDbType.NVarChar, 50).Value =
                    filtro.CodigoLineaDesde
                cmd.Parameters.Add("@LineaHasta", SqlDbType.NVarChar, 50).Value =
                    filtro.CodigoLineaHasta
            End If

            cn.Open()

            Using lector As SqlDataReader = cmd.ExecuteReader()
                While lector.Read()

                    Dim lote As New LoteVencimiento
                    lote.CodProducto = Convert.ToString(lector("Cod_Producto"))
                    lote.DescripcionProducto =
                        Convert.ToString(lector("Descripcion_Producto"))
                    lote.CodLinea = Convert.ToString(lector("Cod_Linea"))
                    lote.DescripcionLinea =
                        Convert.ToString(lector("Descripcion_Linea"))
                    lote.NumeroLote = Convert.ToString(lector("Numero_Lote"))
                    lote.FechaVence = Convert.ToDateTime(lector("FechaVence"))
                    lote.CodBodega = Convert.ToString(lector("Cod_Bodega"))
                    lote.Existencia = Convert.ToDouble(lector("Existencia"))

                    lotes.Add(lote)

                End While
            End Using

        End Using

        Return lotes

    End Function

    ''' <summary>
    ''' Misma información que ObtenerLotes, con los nombres de campo
    ''' que usa el reporte ArepProductoVencimiento.
    ''' </summary>
    Public Function ObtenerTablaReporte(
        ByVal filtro As FiltroReporteLotesVencimiento
    ) As DataTable

        Dim tabla As New DataTable("LotesVencimiento")

        tabla.Columns.Add("Cod_Producto", GetType(String))
        tabla.Columns.Add("Descripcion_Producto", GetType(String))
        tabla.Columns.Add("Cod_Linea", GetType(String))
        tabla.Columns.Add("Descripcion_Linea", GetType(String))
        tabla.Columns.Add("Numero_Lote", GetType(String))
        tabla.Columns.Add("FechaVence", GetType(Date))
        tabla.Columns.Add("Cod_Bodega", GetType(String))
        tabla.Columns.Add("Cantidad", GetType(Double))

        For Each lote As LoteVencimiento In ObtenerLotes(filtro)

            tabla.Rows.Add(
                lote.CodProducto,
                lote.DescripcionProducto,
                lote.CodLinea,
                lote.DescripcionLinea,
                lote.NumeroLote,
                lote.FechaVence,
                lote.CodBodega,
                lote.Existencia)

        Next

        Return tabla

    End Function

    Private Shared Sub ValidarFiltro(
        ByVal filtro As FiltroReporteLotesVencimiento)

        If filtro Is Nothing Then
            Throw New ArgumentNullException("filtro")
        End If

        If filtro.FechaDesde.Date > filtro.FechaHasta.Date Then
            Throw New ArgumentException(
                "La fecha inicial no puede ser mayor que la fecha final.")
        End If

        If filtro.FiltrarPorBodega AndAlso String.Compare(
            filtro.CodigoBodegaDesde, filtro.CodigoBodegaHasta,
            StringComparison.Ordinal) > 0 Then
            Throw New ArgumentException(
                "La bodega inicial no puede ser mayor que la bodega final.")
        End If

        If filtro.FiltrarPorLinea AndAlso String.Compare(
            filtro.CodigoLineaDesde, filtro.CodigoLineaHasta,
            StringComparison.Ordinal) > 0 Then
            Throw New ArgumentException(
                "La línea inicial no puede ser mayor que la línea final.")
        End If

    End Sub

    ' Una sola consulta: calcula la existencia por producto, bodega y lote
    ' a partir de compras y facturas, y la cruza con los lotes que vencen
    ' en el intervalo. La existencia válida es el menor valor entre la
    ' existencia del lote y la total de la bodega, igual que
    ' BuscaExistenciaBodegaLote.
    Private Shared Function ConstruirConsulta(
        ByVal filtro As FiltroReporteLotesVencimiento) As String

        Dim filtroBodegaCompra As String = String.Empty
        Dim filtroBodegaFactura As String = String.Empty
        Dim filtroLinea As String = String.Empty

        If filtro.FiltrarPorBodega Then
            filtroBodegaCompra =
                "AND C.Cod_Bodega BETWEEN @BodegaDesde AND @BodegaHasta "
            filtroBodegaFactura =
                "AND F.Cod_Bodega BETWEEN @BodegaDesde AND @BodegaHasta "
        End If

        If filtro.FiltrarPorLinea Then
            filtroLinea =
                "AND P.Cod_Linea BETWEEN @LineaDesde AND @LineaHasta "
        End If

        Return _
            "WITH Movimientos AS (" &
            "SELECT DC.Cod_Producto, " &
            "REPLACE(UPPER(ISNULL(DC.Numero_Lote, 'SINLOTE')), ' ', '') AS Lote, " &
            "C.Cod_Bodega, " &
            "CASE " &
            "WHEN C.Tipo_Compra IN ('Mercancia Recibida', 'Transferencia Recibida') THEN DC.Cantidad " &
            "WHEN C.Tipo_Compra = 'Devolucion de Compra' THEN -DC.Cantidad " &
            "ELSE 0 END AS Cantidad " &
            "FROM Detalle_Compras DC " &
            "INNER JOIN Compras C " &
            "ON DC.Numero_Compra = C.Numero_Compra " &
            "AND DC.Fecha_Compra = C.Fecha_Compra " &
            "AND DC.Tipo_Compra = C.Tipo_Compra " &
            "WHERE C.Fecha_Compra < DATEADD(DAY, 1, @FechaCorte) " &
            filtroBodegaCompra &
            "UNION ALL " &
            "SELECT DF.Cod_Producto, " &
            "REPLACE(UPPER(ISNULL(DF.CodTarea, 'SINLOTE')), ' ', ''), " &
            "F.Cod_Bodega, " &
            "CASE " &
            "WHEN F.Tipo_Factura IN ('Factura', 'Salida Bodega', 'Transferencia Enviada') THEN -DF.Cantidad " &
            "WHEN F.Tipo_Factura = 'Devolucion de Venta' THEN DF.Cantidad " &
            "ELSE 0 END " &
            "FROM Detalle_Facturas DF " &
            "INNER JOIN Facturas F " &
            "ON DF.Numero_Factura = F.Numero_Factura " &
            "AND DF.Fecha_Factura = F.Fecha_Factura " &
            "AND DF.Tipo_Factura = F.Tipo_Factura " &
            "WHERE F.Fecha_Factura < DATEADD(DAY, 1, @FechaCorte) " &
            filtroBodegaFactura &
            "), " &
            "ExistenciaLote AS (" &
            "SELECT Cod_Producto, Cod_Bodega, Lote, SUM(Cantidad) AS Existencia " &
            "FROM Movimientos " &
            "GROUP BY Cod_Producto, Cod_Bodega, Lote" &
            "), " &
            "ExistenciaBodega AS (" &
            "SELECT Cod_Producto, Cod_Bodega, SUM(Existencia) AS Existencia " &
            "FROM ExistenciaLote " &
            "GROUP BY Cod_Producto, Cod_Bodega" &
            ") " &
            "SELECT EL.Cod_Producto, " &
            "P.Descripcion_Producto, " &
            "ISNULL(P.Cod_Linea, '') AS Cod_Linea, " &
            "ISNULL(LI.Descripcion_Linea, '') AS Descripcion_Linea, " &
            "L.Numero_Lote, " &
            "L.FechaVence, " &
            "EL.Cod_Bodega, " &
            "CASE WHEN EL.Existencia < EB.Existencia " &
            "THEN EL.Existencia ELSE EB.Existencia END AS Existencia " &
            "FROM ExistenciaLote EL " &
            "INNER JOIN ExistenciaBodega EB " &
            "ON EL.Cod_Producto = EB.Cod_Producto " &
            "AND EL.Cod_Bodega = EB.Cod_Bodega " &
            "INNER JOIN Lote L " &
            "ON REPLACE(UPPER(L.Numero_Lote), ' ', '') = EL.Lote " &
            "INNER JOIN Productos P " &
            "ON P.Cod_Productos = EL.Cod_Producto " &
            "LEFT JOIN Lineas LI " &
            "ON LI.Cod_Linea = P.Cod_Linea " &
            "WHERE L.Activo = 1 " &
            "AND L.FechaVence >= @FechaDesde " &
            "AND L.FechaVence < DATEADD(DAY, 1, @FechaHasta) " &
            "AND EL.Existencia > 0 " &
            "AND EB.Existencia > 0 " &
            filtroLinea &
            "ORDER BY P.Cod_Linea, L.FechaVence, EL.Cod_Producto, EL.Cod_Bodega"

    End Function

End Class
