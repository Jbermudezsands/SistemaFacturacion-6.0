Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepMovimientoProyectos 
    Private ComprasSubReport As SubReporteCompras = Nothing
    Private FacturasSubReport As SubReporteFacturas = Nothing
    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim FechaIni As String, Inicial As Double

        My.Application.DoEvents()

        FechaIni = Format(My.Forms.FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        If FrmReportes.CmbAgrupado.Text = "Bodega" Then
            Inicial = BuscaInventarioInicialProyectos(Me.TxtCodProducto.Text, FechaIni, My.Forms.FrmReportes.CmbRango1.Text, My.Forms.FrmReportes.CmbRango2.Text)
        Else
            Inicial = BuscaInventarioInicialProyectos(Me.TxtCodProducto.Text, FechaIni)
        End If
        Me.TxtSaldoInicial.Text = Format(Inicial, "##,##0.00")
        Me.TxtImporteInicial.Text = Format(MontoInicial, "##,##0.00")
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim SQLString As String, CodProyectos As String = "", FechaIni As String, FechaFin As String
        Dim CodBodega1 As String = "", CodBodega2 As String = ""

        FechaIni = Format(My.Forms.FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        FechaFin = Format(My.Forms.FrmReportes.DTPFechaFin.Value, "yyyy-MM-dd")
        CodBodega1 = My.Forms.FrmReportes.CmbRango1.Text
        CodBodega2 = My.Forms.FrmReportes.CmbRango2.Text

        CodProyectos = Me.TxtCodProducto.Text
        TotalMontoFacturas = 0
        TotalMontoCompras = 0
        CantidadCompra = 0
        CantidadSalida = 0

        If My.Forms.FrmReportes.CmbRango1.Text = "" And My.Forms.FrmReportes.CmbRango2.Text = "" Then
            SQLString = "SELECT Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Costo_Unitario * Detalle_Facturas.Cantidad AS Importe, Facturas.Cod_Bodega,Precio_Unitario FROM  Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                        "WHERE (Detalle_Facturas.Tipo_Factura <> N'Cotizacion') AND (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Facturas.CodigoProyecto BETWEEN '" & CodProyectos & "' AND '" & CodProyectos & "')  ORDER BY Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Cod_Producto"  'AND (Detalle_Facturas.Costo_Unitario * Detalle_Facturas.Cantidad <> 0)
        Else
            SQLString = "SELECT  Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Costo_Unitario * Detalle_Facturas.Cantidad AS Importe, Facturas.Cod_Bodega,Precio_Unitario FROM Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                        "WHERE (Detalle_Facturas.Tipo_Factura <> N'Cotizacion') AND (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Facturas.CodigoProyecto BETWEEN '" & CodProyectos & "' AND '" & CodProyectos & "') AND (Facturas.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "')  ORDER BY Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Cod_Producto"  'AND (Detalle_Facturas.Costo_Unitario * Detalle_Facturas.Cantidad <> 0)

        End If


        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SrpFacturas.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SrpFacturas.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SQLString
        My.Application.DoEvents()

        If My.Forms.FrmReportes.CmbRango1.Text = "" And My.Forms.FrmReportes.CmbRango2.Text = "" Then
            'SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
            '            "WHERE  (Productos.Cod_Productos BETWEEN '" & CodProductos & "' AND '" & CodProductos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) ORDER BY Detalle_Compras.Fecha_Compra"
            If FrmReportes.OptCordobas.Checked = True Then
                'SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                '            "WHERE (Productos.Cod_Productos BETWEEN '" & CodProductos & "' AND '" & CodProductos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Compras.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') ORDER BY Detalle_Compras.Fecha_Compra"
                SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto ELSE (Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto)* TasaCambio.MontoTasa END AS Importe FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra INNER JOIN TasaCambio ON Compras.Fecha_Compra = TasaCambio.FechaTasa  " & _
                            "WHERE (Compras.CodigoProyecto BETWEEN '" & CodProyectos & "' AND '" & CodProyectos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) ORDER BY Detalle_Compras.Fecha_Compra"
            Else
                SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, CASE WHEN Compras.MonedaCompra = 'Dolares' THEN Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto ELSE (Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto)/ TasaCambio.MontoTasa END AS Importe FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra INNER JOIN TasaCambio ON Compras.Fecha_Compra = TasaCambio.FechaTasa  " & _
                            "WHERE (Compras.CodigoProyecto BETWEEN '" & CodProyectos & "' AND '" & CodProyectos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102))  ORDER BY Detalle_Compras.Fecha_Compra"

            End If

        Else

            If FrmReportes.OptCordobas.Checked = True Then
                'SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                '            "WHERE (Productos.Cod_Productos BETWEEN '" & CodProductos & "' AND '" & CodProductos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Compras.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') ORDER BY Detalle_Compras.Fecha_Compra"
                SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto ELSE (Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto)* TasaCambio.MontoTasa END AS Importe FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra INNER JOIN TasaCambio ON Compras.Fecha_Compra = TasaCambio.FechaTasa  " & _
                            "WHERE (Compras.CodigoProyecto BETWEEN '" & CodProyectos & "' AND '" & CodProyectos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Compras.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') ORDER BY Detalle_Compras.Fecha_Compra"
            Else
                SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, CASE WHEN Compras.MonedaCompra = 'Dolares' THEN Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto ELSE (Detalle_Compras.Cantidad * Detalle_Compras.Precio_Neto)/ TasaCambio.MontoTasa END AS Importe FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra INNER JOIN TasaCambio ON Compras.Fecha_Compra = TasaCambio.FechaTasa  " & _
                            "WHERE (Compras.CodigoProyecto BETWEEN '" & CodProyectos & "' AND '" & CodProyectos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Compras.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') ORDER BY Detalle_Compras.Fecha_Compra"

            End If
        End If
        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SrpCompras.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SrpCompras.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SQLString
        My.Application.DoEvents()

        My.Forms.FrmReportes.Text = "Procesando: " & CodProyectos
        My.Forms.FrmReportes.ProgressBar.Value = My.Forms.FrmReportes.ProgressBar.Value + 1
        My.Application.DoEvents()
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Dim SQLString As String = "", CodProductos As String = "", FechaIni As String, FechaFin As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, ImporteCompras As Double = 0
        Dim DevolucionCantidadCompras As Double = 0, DevolucionImporteCompras As Double = 0, ImporteFacturas As Double = 0
        Dim CodBodega1 As String = "", CodBodega2 As String = ""
        Dim DevolucionCantidadFacturas As Double = 0, DevolucionImporteFacturas As Double = 0
        Dim Registros As Double = 0, i As Double = 0, CantidadInicial As Double = 0, ImporteInicial As Double = 0

        FechaIni = Format(My.Forms.FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        FechaFin = Format(My.Forms.FrmReportes.DTPFechaFin.Value, "yyyy-MM-dd")

        CodBodega1 = My.Forms.FrmReportes.CmbRango1.Text
        CodBodega2 = My.Forms.FrmReportes.CmbRango2.Text

        CodProductos = Me.TxtCodProducto.Text


        If Me.TxtSaldoInicial.Text <> "" Then
            CantidadInicial = Me.TxtSaldoInicial.Text
        End If
        If Me.TxtImporteInicial.Text <> "" Then
            ImporteInicial = Me.TxtImporteInicial.Text
        End If

        Me.LblTotalCantidad1.Text = Format(CantidadCompra, "##,##0.00")
        Me.LblTotalImporte1l.Text = Format(TotalMontoCompras, "##,##0.00")

        Me.LblTotalCantidad2.Text = Format(CantidadSalida, "##,##0.00")
        Me.LblTotalImporte2.Text = Format(TotalMontoFacturas, "##,##0.00")

        Me.LblTotalCantidad3.Text = Format(CantidadCompra - CantidadSalida + CantidadInicial, "##,##0.00")
        'Me.LblTotalImporte3.Text = Format(Math.Abs(ImporteCompras + DevolucionImporteFacturas - ImporteFacturas - DevolucionImporteCompras), "##,##0.00")
        Me.LblTotalImporte3.Text = Format(Math.Abs(TotalMontoCompras - TotalMontoFacturas + ImporteInicial), "##,##0.00") 'TotalMontoFacturas

    End Sub
    Private Sub ArepMovimientoProductos_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////ENLAZO EL OBJETO SUB REPORT, CON EL SUB REPORTE CREADO COMO OBJETO////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If ComprasSubReport Is Nothing Then
            ComprasSubReport = New SubReporteCompras
            Me.SrpCompras.Report = ComprasSubReport
            Me.SrpCompras.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        If FacturasSubReport Is Nothing Then
            FacturasSubReport = New SubReporteFacturas
            Me.SrpFacturas.Report = FacturasSubReport
            Me.SrpFacturas.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If
    End Sub
End Class
