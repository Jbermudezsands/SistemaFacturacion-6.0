Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Data
Imports System


Public Class ArepControlProductos
    Inherits ActiveReport3
    Private ComprasSubReport As SubReporteCompras2 = Nothing
    Private FacturasSubReport As SubReporteFacturas2 = Nothing, Inicial As Double



    Private Sub ArepMovimientoProductos_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////ENLAZO EL OBJETO SUB REPORT, CON EL SUB REPORTE CREADO COMO OBJETO////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        If ComprasSubReport Is Nothing Then
            ComprasSubReport = New SubReporteCompras2
            Me.SrpCompras.Report = ComprasSubReport
            Me.SrpCompras.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        If FacturasSubReport Is Nothing Then
            FacturasSubReport = New SubReporteFacturas2
            Me.SrpFacturas.Report = FacturasSubReport
            Me.SrpFacturas.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim SQLString As String, CodProductos As String = "", FechaIni As String, FechaFin As String
        Dim CodBodega1 As String = "", CodBodega2 As String = ""

        FechaIni = Format(My.Forms.FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        FechaFin = Format(My.Forms.FrmReportes.DTPFechaFin.Value, "yyyy-MM-dd")
        CodBodega1 = My.Forms.FrmReportes.CmbRango1.Text
        CodBodega2 = My.Forms.FrmReportes.CmbRango2.Text

        CodProductos = Me.TxtCodProducto.Text

        If My.Forms.FrmReportes.CmbRango1.Text = "" And My.Forms.FrmReportes.CmbRango2.Text = "" Then
            SQLString = "SELECT Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega,Facturas.Cod_Cliente FROM  Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                        "WHERE (Detalle_Facturas.Tipo_Factura <> N'Cotizacion' AND Detalle_Facturas.Tipo_Factura <> N'Orden de Trabajo') AND (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Detalle_Facturas.Cod_Producto BETWEEN '" & CodProductos & "' AND '" & CodProductos & "') ORDER BY Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Cod_Producto"
        Else
            SQLString = "SELECT  Detalle_Facturas.Numero_Factura, Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega,Facturas.Cod_Cliente FROM Detalle_Facturas INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                        "WHERE (Detalle_Facturas.Tipo_Factura <> N'Cotizacion' AND Detalle_Facturas.Tipo_Factura <> N'Orden de Trabajo') AND (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Detalle_Facturas.Cod_Producto BETWEEN '" & CodProductos & "' AND '" & CodProductos & "') AND (Facturas.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') ORDER BY Detalle_Facturas.Fecha_Factura, Detalle_Facturas.Cod_Producto"

        End If
        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SrpFacturas.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SrpFacturas.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SQLString
        My.Application.DoEvents()
        If My.Forms.FrmReportes.CmbRango1.Text = "" And My.Forms.FrmReportes.CmbRango2.Text = "" Then
            SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Compras.Cod_Proveedor FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                        "WHERE  (Productos.Cod_Productos BETWEEN '" & CodProductos & "' AND '" & CodProductos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Detalle_Compras.Tipo_Compra <> 'Orden de Compra') ORDER BY Detalle_Compras.Fecha_Compra"
        Else
            SQLString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Compras.Cod_Proveedor FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                        "WHERE (Productos.Cod_Productos BETWEEN '" & CodProductos & "' AND '" & CodProductos & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Compras.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') AND (Detalle_Compras.Tipo_Compra <> 'Orden de Compra') ORDER BY Detalle_Compras.Fecha_Compra"
        End If
        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SrpCompras.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SrpCompras.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SQLString
        My.Application.DoEvents()

        My.Forms.FrmReportes.Text = "Procesando: " & CodProductos
        My.Forms.FrmReportes.ProgressBar.Value = My.Forms.FrmReportes.ProgressBar.Value + 1
        My.Application.DoEvents()

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim FechaIni As String
        My.Application.DoEvents()

        FechaIni = Format(My.Forms.FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        Inicial = BuscaInventarioInicialEntreBodega(Me.TxtCodProducto.Text, FechaIni, My.Forms.FrmReportes.CmbRango1.Text, My.Forms.FrmReportes.CmbRango2.Text)
        'inicial = BuscaInventarioInicialBodega(Me.TxtCodProducto.Text,FechaIni,
        Me.TxtSaldoInicial.Text = Format(Inicial, "##,##0.00")
        TotalUnidades = Inicial

    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Dim SQLString As String, CodProductos As String = "", FechaIni As String, FechaFin As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, CantidadCompras As Double = 0, ImporteCompras As Double = 0
        Dim DevolucionCantidadCompras As Double, DevolucionImporteCompras As Double, CantidadFacturas As Double = 0, ImporteFacturas As Double = 0
        Dim CodBodega1 As String = "", CodBodega2 As String = ""
        Dim DevolucionCantidadFacturas As Double = 0, DevolucionImporteFacturas As Double = 0
        Dim Registros As Double = 0, i As Double = 0

        'CostoPromedio = CostoBodega(CodProducto, CodBodega)
        'Compras = BuscaCompraBodega(CodProducto, FechaIni, FechaFin, CodBodega)
        'Ventas = BuscaVentaBodega(CodProducto, FechaIni, FechaFin, CodBodega)
        'Inicial = BuscaInventarioInicialBodega(CodProducto, FechaIni, CodBodega)
        'Existencia = Inicial + Compras - Ventas

        FechaIni = Format(My.Forms.FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        FechaFin = Format(My.Forms.FrmReportes.DTPFechaFin.Value, "yyyy-MM-dd")

        CodBodega1 = My.Forms.FrmReportes.CmbRango1.Text
        CodBodega2 = My.Forms.FrmReportes.CmbRango2.Text

        CodProductos = Me.TxtCodProducto.Text

        FechaIni = Format(My.Forms.FrmReportes.DTPFechaIni.Value, "yyyy-MM-dd")
        Inicial = BuscaInventarioInicialEntreBodega(Me.TxtCodProducto.Text, FechaIni, CodBodega1, CodBodega2)

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////SUMO EL TOTAL DE COMPRAS ////////////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If My.Forms.FrmReportes.CmbRango1.Text = "" And My.Forms.FrmReportes.CmbRango2.Text = "" Then
            SQLString = "SELECT MAX(Fecha_Compra) AS Expr1, SUM(Cantidad) AS Cantidad, SUM(Importe) AS Importe, Cod_Producto FROM Detalle_Compras GROUP BY Cod_Producto, Tipo_Compra  " & _
                        "HAVING (Tipo_Compra <> N'Devolucion de Compra') AND (Cod_Producto = '" & CodProductos & "') AND (MAX(Fecha_Compra) BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Detalle_Compras.Tipo_Compra <> 'Orden de Compra')"
        Else

            SQLString = "SELECT  Detalle_Compras.Cantidad, Detalle_Compras.Importe, Compras.Fecha_Compra FROM  Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                        "WHERE (Detalle_Compras.Cod_Producto = '" & CodProductos & "') AND (Compras.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') AND (Detalle_Compras.Tipo_Compra <> 'Devolucion de Compra') AND (Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Detalle_Compras.Tipo_Compra <> 'Orden de Compra')"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, Conexion)
        DataAdapter.Fill(DataSet, "Compras")
        Registros = DataSet.Tables("Compras").Rows.Count
        i = 0
        CantidadCompras = 0
        ImporteCompras = 0
        Do While Registros > i
            CantidadCompras = DataSet.Tables("Compras").Rows(i)("Cantidad") + CantidadCompras
            ImporteCompras = DataSet.Tables("Compras").Rows(i)("Importe") + ImporteCompras
            i = i + 1
        Loop





        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////SUMO EL TOTAL DE DEVOLUCIONES DE COMPRAS ////////////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If My.Forms.FrmReportes.CmbRango1.Text = "" And My.Forms.FrmReportes.CmbRango2.Text = "" Then
            SQLString = "SELECT MAX(Fecha_Compra) AS Expr1, SUM(Cantidad) AS Cantidad, SUM(Importe) AS Importe, Cod_Producto FROM Detalle_Compras GROUP BY Cod_Producto, Tipo_Compra  " & _
                              "HAVING (Tipo_Compra = N'Devolucion de Compra') AND (Cod_Producto = '" & CodProductos & "') AND (MAX(Fecha_Compra) BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102))"
        Else
            SQLString = "SELECT  MAX(Detalle_Compras.Fecha_Compra) AS Expr1, SUM(Detalle_Compras.Cantidad) AS Cantidad, SUM(Detalle_Compras.Importe) AS Importe, Detalle_Compras.Cod_Producto, Compras.Cod_Bodega FROM Detalle_Compras INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra GROUP BY Detalle_Compras.Cod_Producto, Detalle_Compras.Tipo_Compra, Compras.Cod_Bodega " & _
                        "HAVING (Detalle_Compras.Tipo_Compra = 'Devolucion de Compra') AND (Detalle_Compras.Cod_Producto = '" & CodProductos & "') AND (MAX(Detalle_Compras.Fecha_Compra) BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Compras.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "')"
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, Conexion)
        DataAdapter.Fill(DataSet, "DevolucionCompras")
        Registros = DataSet.Tables("DevolucionCompras").Rows.Count
        DevolucionCantidadCompras = 0
        DevolucionImporteCompras = 0
        i = 0
        Do While Registros > i
            DevolucionCantidadCompras = DataSet.Tables("DevolucionCompras").Rows(i)("Cantidad") + DevolucionCantidadCompras
            DevolucionImporteCompras = DataSet.Tables("DevolucionCompras").Rows(i)("Importe") + DevolucionImporteCompras
            i = i + 1
        Loop


        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////SUMO EL TOTAL DE FACTURAS ////////////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If My.Forms.FrmReportes.CmbRango1.Text = "" And My.Forms.FrmReportes.CmbRango2.Text = "" Then
            SQLString = "SELECT Cod_Producto, MAX(Tipo_Factura) AS Tipo_Factura, SUM(Cantidad) AS Cantidad, SUM(Importe) AS Importe  FROM Detalle_Facturas WHERE  (Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) GROUP BY Cod_Producto HAVING (MAX(Tipo_Factura) <> 'Cotizacion' AND MAX(Tipo_Factura) <> 'Devolucion de Venta') AND (Cod_Producto = '" & CodProductos & "') "
        Else
            'SQLString = "SELECT  Detalle_Facturas.Cod_Producto, MAX(Detalle_Facturas.Tipo_Factura) AS Tipo_Factura, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Importe) AS Importe, Facturas.Cod_Bodega FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
            '            "WHERE (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) GROUP BY Detalle_Facturas.Cod_Producto, Facturas.Cod_Bodega HAVING (MAX(Detalle_Facturas.Tipo_Factura) <> 'Cotizacion') AND (MAX(Detalle_Facturas.Tipo_Factura) <> 'Devolucion de Venta') AND (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Facturas.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') "

            SQLString = "SELECT Detalle_Facturas.Cod_Producto, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Importe) AS Importe, Facturas.Cod_Bodega FROM  Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                        "WHERE (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Detalle_Facturas.Tipo_Factura <> 'Cotizacion') AND (Detalle_Facturas.Tipo_Factura <> 'Devolucion de Venta') GROUP BY Detalle_Facturas.Cod_Producto, Facturas.Cod_Bodega HAVING  (Detalle_Facturas.Cod_Producto = '" & CodProductos & "') AND (Facturas.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "')"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, Conexion)
        DataAdapter.Fill(DataSet, "Facturas")
        Registros = DataSet.Tables("Facturas").Rows.Count
        CantidadFacturas = 0
        ImporteFacturas = 0
        i = 0
        Do While Registros > i
            CantidadFacturas = DataSet.Tables("Facturas").Rows(i)("Cantidad") + CantidadFacturas
            ImporteFacturas = DataSet.Tables("Facturas").Rows(i)("Importe") + ImporteFacturas
            i = i + 1
        Loop



        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////SUMO EL TOTAL DE LAS DEVOLUCINES DE FACTURA////////////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If My.Forms.FrmReportes.CmbRango1.Text = "" And My.Forms.FrmReportes.CmbRango2.Text = "" Then
            SQLString = "SELECT Cod_Producto, SUM(Cantidad) AS Cantidad, SUM(Importe) AS Importe, Tipo_Factura  FROM Detalle_Facturas WHERE (Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) GROUP BY Cod_Producto, Tipo_Factura HAVING  (Cod_Producto = '" & CodProductos & "') AND (Tipo_Factura = N'Devolucion de Venta') "
        Else
            SQLString = "SELECT  Detalle_Facturas.Cod_Producto, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Importe) AS Importe FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura " & _
                        "WHERE (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & FechaIni & "', 102) AND CONVERT(DATETIME, '" & FechaFin & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & CodBodega1 & "' AND '" & CodBodega2 & "') AND (Detalle_Facturas.Tipo_Factura = N'Devolucion de Venta') GROUP BY Detalle_Facturas.Cod_Producto HAVING (Detalle_Facturas.Cod_Producto = '" & CodProductos & "')"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, Conexion)
        DataAdapter.Fill(DataSet, "DevolucionFacturas")
        Registros = DataSet.Tables("DevolucionFacturas").Rows.Count
        DevolucionCantidadFacturas = 0
        DevolucionImporteFacturas = 0
        i = 0
        Do While Registros > i
            DevolucionCantidadFacturas = DataSet.Tables("DevolucionFacturas").Rows(i)("Cantidad") + DevolucionCantidadFacturas
            DevolucionImporteFacturas = DataSet.Tables("DevolucionFacturas").Rows(i)("Importe") + DevolucionImporteFacturas
            i = i + 1
        Loop

        'Inicial = BuscaInventarioInicialBodega(CodProducto, FechaIni, CodBodega)

        Me.LblTotalCantidad1.Text = Format(Inicial + CantidadCompras + DevolucionCantidadFacturas, "##,##0.00")
        Me.LblTotalImporte1l.Text = Format(ImporteCompras + DevolucionImporteFacturas, "##,##0.00")

        Me.LblTotalCantidad2.Text = Format(CantidadFacturas + DevolucionCantidadCompras, "##,##0.00")
        Me.LblTotalImporte2.Text = Format(ImporteFacturas + DevolucionImporteCompras, "##,##0.00")

        Me.LblTotalCantidad3.Text = Format(Inicial + CantidadCompras + DevolucionCantidadFacturas - CantidadFacturas - DevolucionCantidadCompras, "##,##0.00")
        Me.LblTotalImporte3.Text = Format(Math.Abs(ImporteCompras + DevolucionImporteFacturas - ImporteFacturas - DevolucionImporteCompras), "##,##0.00")

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
