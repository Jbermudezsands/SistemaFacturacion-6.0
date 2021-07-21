Public Class FrmConsultas
    Public DataSet As New DataSet, TipoEnsamble As String, CodIva As String, TipoCompra As String, CodCajero As String, Nombres As String, Apellidos As String
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Codigo As String, Descripcion As String, TipoProducto As String, CodComponente As Double, Precio As Double
    Public MiconexionContabilidad As New SqlClient.SqlConnection(ConexionContabilidad), Cantidad As Double, CodProducto As String, Fecha As Date, FechaHora As Date, Nombre_Recolector As String, Telefono_Recolector As String, Cecula_Recolector As String
    Public DescripcionImpuestos As String, TasaImpuestos As Double, TipoImpuesto As String, CodigoCliente As String, Tipo As String, CodigoProveedor As String, NumFactura As String, Conductor As String, CodProveedor As String
    Public CodBodega As String

    Private Sub C1TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Codigo = ""
            TipoProducto = ""

            Me.Size = New System.Drawing.Size(507, 424)
            Me.TrueDBGridConsultas.Size = New System.Drawing.Size(471, 222)
            Me.ButtonSalir.Location = New Point(400, 305)

            'For Each col As C1.Win.C1TrueDBGrid.C1DataColumn In Me.TrueDBGridConsultas.Columns
            '    col.FilterText = ""
            'Next

            MiConexion.Close()

            Dim DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String

            Select Case Quien
                Case "CodigoProductosBodega"
                    Dim CodigoBodega As String = ""


                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)

                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)

                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Lista, Existencia_Unidades,Cod_Iva FROM Productos"
                    SQlProductos = "SELECT DISTINCT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, Productos.Precio_Lista, DetalleBodegas.Existencia, Productos.Cod_Iva FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodBodega & "') AND (Productos.Activo = N'Activo') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Precio $"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 620

                    MiConexion.Close()
                Case "Recolector"

                    DataSet.Reset()
                    MiConexion.Open()
                    SQlProductos = "SELECT DISTINCT NombreRecolector, TelefonoRecolector , CedulaRecolector FROM Recepcion WHERE(NombreRecolector Is Not NULL) ORDER BY NombreRecolector"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()
                Case "LiquidacionLeche"
                    SQlProductos = "SELECT LiquidacionLeche.NumeroLiquidacion, LiquidacionLeche.FechaInicio, LiquidacionLeche.FechaFin, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombres FROM LiquidacionLeche INNER JOIN Clientes ON LiquidacionLeche.Cod_Proveedor = Clientes.Cod_Cliente "
                    Me.TrueDBGridConsultas.Columns(0).Caption = "No.Liquidacion"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "FechaInicio"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "CuentasContables"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas "
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "TipoNomina"
                    SQlProductos = "SELECT  CodTipoNomina, TipoNomina, PeriodoNomina FROM TipoNomina "
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Periodo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65


                    MiConexion.Close()

                Case "CodigoProductosDetalle"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Costo_Promedio, Existencia_Unidades,Cod_Iva FROM Productos Where (Tipo_Producto <> 'Ensambles')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Costo Prom"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False

                    MiConexion.Close()

                Case "CodigoProductor"
                    SQlProductos = "SELECT  CodProductor, NombreProductor, ApellidoProductor FROM Productor WHERE (TipoProductor = 'Productor')"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 100

                Case "RecepcionPlanilla"
                    If FrmCompras.CboTipoProducto.Text <> "" Then
                        SQlProductos = "SELECT Compras.Numero_Compra AS Numero, Compras.Nombre_Proveedor + ' ' + Compras.Apellido_Proveedor AS Proveedor, Compras.Fecha_Compra AS Fecha, Compras.Tipo_Compra AS Tipo  FROM  Compras WHERE (Compras.Activo = 1) AND (Tipo_Compra = 'Recepcion') ORDER BY Numero  "
                    Else
                        SQlProductos = "SELECT Compras.Numero_Compra AS Numero, Compras.Nombre_Proveedor + ' ' + Compras.Apellido_Proveedor AS Proveedor, Compras.Fecha_Compra AS Fecha, Compras.Tipo_Compra AS Tipo  FROM  Compras WHERE (Compras.Activo = 1) AND (Tipo_Compra = '" & FrmRecepcionPlanilla.CboTipoProducto.Text & "') ORDER BY Numero  "
                    End If
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 110



                Case "Ruta"
                    SQlProductos = "SELECT   CodRuta, Nombre_Ruta FROM Ruta_Distribucion"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo Ruta"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Nombre Ruta"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 150

                Case "Repesaje"
                    SQlProductos = "SELECT Recepcion.NumeroRecepcion, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Conductor, Proveedor.Cod_Proveedor,Recepcion.TipoRecepcion FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor " & _
                                   "WHERE(Recepcion.Cancelar = 0) AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "') ORDER BY Recepcion.NumeroRecepcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Recepcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Proveedor"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 150
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False

                Case "SalidaBascula"
                    'SQlProductos = "SELECT Recepcion.NumeroRecepcion, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Conductor, Proveedor.Cod_Proveedor,Recepcion.TipoRecepcion FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor " & _
                    '               "WHERE(Recepcion.Cancelar = 0) AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "') ORDER BY Recepcion.NumeroRecepcion"
                    SQlProductos = "SELECT Recepcion.NumeroRecepcion, Recepcion.Fecha, Clientes.Cod_Cliente, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombres, Conductor.Nombre AS Conductor, Conductor.Cedula, Recepcion.TipoRecepcion FROM Recepcion INNER JOIN Clientes ON Recepcion.Cod_Proveedor = Clientes.Cod_Cliente INNER JOIN Conductor ON Recepcion.Conductor = Conductor.Codigo  " & _
                                   "WHERE (Recepcion.Cancelar = 0) AND (Recepcion.TipoRecepcion =  '" & FrmRecepcion.CboTipoRecepcion.Text & "') ORDER BY Recepcion.NumeroRecepcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    'Me.TrueDBGridConsultas.Columns(0).Caption = "Recepcion"
                    'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    'Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
                    'Me.TrueDBGridConsultas.Columns(2).Caption = "Proveedor"
                    'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 150
                    'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False

                Case "Recepcion"
                    SQlProductos = "SELECT Recepcion.NumeroRecepcion, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Conductor, Proveedor.Cod_Proveedor,Recepcion.TipoRecepcion FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor " & _
                                   "WHERE(Recepcion.Cancelar = 0) AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "') ORDER BY Recepcion.NumeroRecepcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Recepcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Proveedor"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 150
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False

                Case "Conductor"
                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)
                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)

                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta FROM Productos "
                    SQlProductos = "SELECT  Codigo, Nombre, Cedula, Licencia  FROM Conductor WHERE (Activo = 1) AND (ListaNegra = 0)"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 700
                    MiConexion.Close()
                Case "Vehiculo"
                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)
                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)

                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta FROM Productos "
                    SQlProductos = "SELECT  Placa, Marca, TipoVehiculo FROM Vehiculo WHERE (Activo = 1)"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Placa"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Marca"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 700
                    MiConexion.Close()

                Case "CodigoServicios"
                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)
                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)

                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta FROM Productos "
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta FROM Productos WHERE (Tipo_Producto = 'Servicio') AND (Tipo_Producto <> 'Descuento')"

                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 700
                    MiConexion.Close()

                Case "ProyectosFactura"
                    SQlProductos = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin FROM Proyectos WHERE(Activo = 1)"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 250
                    MiConexion.Close()

                Case "Proyectos"
                    SQlProductos = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin, Moneda, VentaEstimada, CostoEstimado, Activo FROM Proyectos ORDER BY CodigoProyectos "
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 250
                    MiConexion.Close()

                Case "NB"

                    SQlProductos = "SELECT IndiceNota.Numero_Nota, IndiceNota.Fecha_Nota, IndiceNota.Nombre_Cliente, NotaDebito.Tipo FROM IndiceNota INNER JOIN Clientes ON IndiceNota.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN NotaDebito ON IndiceNota.Tipo_Nota = NotaDebito.CodigoNB WHERE (Clientes.Cod_Cliente =  '" & CodigoCliente & "') AND (IndiceNota.Activo = 1) AND (IndiceNota.Contabilizado = 0) AND (NotaDebito.Tipo Like '%" & Tipo & "%') ORDER BY IndiceNota.Numero_Nota"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 250
                    MiConexion.Close()

                Case "NBPROVEEDORES"

                    'SQlProductos = "SELECT IndiceNota.Numero_Nota, IndiceNota.Fecha_Nota, IndiceNota.Nombre_Cliente, NotaDebito.Tipo FROM IndiceNota INNER JOIN Proveedor ON IndiceNota.Cod_Cliente = Proveedor.Cod_Proveedor INNER JOIN NotaDebito ON IndiceNota.Tipo_Nota = NotaDebito.CodigoNB WHERE (Clientes.Cod_Cliente =  '" & CodigoCliente & "') AND (IndiceNota.Activo = 1) AND (IndiceNota.Contabilizado = 0) AND (NotaDebito.Tipo = '%" & Tipo & "%') ORDER BY IndiceNota.Numero_Nota"
                    SQlProductos = "SELECT  IndiceNota.Numero_Nota, IndiceNota.Fecha_Nota, IndiceNota.Nombre_Cliente, NotaDebito.Tipo, IndiceNota.Cod_Cliente, IndiceNota.Activo, IndiceNota.Contabilizado FROM IndiceNota INNER JOIN NotaDebito ON IndiceNota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN  Proveedor ON IndiceNota.Cod_Cliente = Proveedor.Cod_Proveedor WHERE   (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (NotaDebito.Tipo LIKE '%" & Tipo & "%') ORDER BY IndiceNota.Numero_Nota"

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 250
                    MiConexion.Close()
                Case "ProductosLiquidacion"

                    Dim CodigoBodega As String
                    CodigoBodega = FrmLiquidacion.CboCodigoBodega.Text


                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Costo_Promedio, Existencia_Unidades,Cod_Iva FROM Productos Where (Tipo_Producto <> 'Ensambles')"
                    SQlProductos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, DetalleBodegas.Costo, DetalleBodegas.Existencia_Unidades, Productos.Cod_Iva FROM  Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos  " & _
                                   "WHERE (Productos.Tipo_Producto <> 'Ensambles') AND (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Costo Prom"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False

                    MiConexion.Close()

                Case "Recibos"
                    SQlProductos = "SELECT Fecha_Recibo, CodReciboPago, NombreCliente FROM Recibo WHERE (Activo = 1) AND (Contabilizado = 0)"

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Fecha Recibo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Numero Recibo"
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Nombre Cliente"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 250
                    MiConexion.Close()

                Case "Pagos"
                    SQlProductos = "SELECT ReciboPago.Fecha_Recibo, ReciboPago.CodReciboPago, Proveedor.Nombre_Proveedor, Proveedor.Cod_Proveedor FROM ReciboPago INNER JOIN Proveedor ON ReciboPago.Cod_Proveedor = Proveedor.Cod_Proveedor "  'WHERE (ReciboPago.Activo = 1) AND (ReciboPago.Contabilizado = 0)

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Fecha Recibo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Numero Recibo"
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Nombre Proveedor"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 250
                    MiConexion.Close()


                Case "CodigoTipoPrecio"
                    SQlProductos = "SELECT  * FROM TipoPrecio"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "Liquidacion"
                    SQlProductos = "SELECT Numero_Liquidacion, Fecha_Liquidacion, Nombre_Proveedor, Apellido_Proveedor FROM Liquidacion WHERE  (Activo = 1) ORDER BY Numero_Liquidacion"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Numero"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Nombres"
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Apellidos"

                Case "CodigoProductosCordobasPlantilla"
                    Dim CodigoBodega As String = ""
                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)


                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)


                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta, Existencia_Unidades,Cod_Iva FROM Productos "
                    CodigoBodega = FrmPlantillas.CboCodigoBodega.Text
                    SQlProductos = "SELECT DISTINCT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, Productos.Precio_Venta, DetalleBodegas.Existencia, Productos.Cod_Iva FROM  Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') AND (Productos.Activo = N'Activo') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Precio C$"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 620

                    MiConexion.Close()


                Case "CodigoProductosFacturaPlantilla"
                    Dim CodigoBodega As String = ""
                    CodigoBodega = FrmPlantillas.CboCodigoBodega.Text

                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)

                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)

                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Lista, Existencia_Unidades,Cod_Iva FROM Productos"
                    SQlProductos = "SELECT DISTINCT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, Productos.Precio_Lista, DetalleBodegas.Existencia, Productos.Cod_Iva FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') AND (Productos.Activo = N'Activo') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Precio $"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 620

                    MiConexion.Close()


                Case "CodigoProductosCordobas"
                    Dim CodigoBodega As String = ""
                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)


                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)


                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta, Existencia_Unidades,Cod_Iva FROM Productos "
                    CodigoBodega = FrmFacturas.CboCodigoBodega.Text
                    SQlProductos = "SELECT DISTINCT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, Productos.Precio_Venta, DetalleBodegas.Existencia, Productos.Cod_Iva FROM  Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') AND (Productos.Activo = N'Activo') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Precio C$"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 620

                    MiConexion.Close()

                Case "CodigoProductosSolicitud"
                    Dim CodigoBodega As String = ""
                    CodigoBodega = FrmNuevaSolicitud.CboCodigoBodega.Text

                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)

                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)

                    SQlProductos = "SELECT DISTINCT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') AND (Productos.Activo = N'Activo') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65

                    MiConexion.Close()

                Case "CodigoProductosFactura"
                    Dim CodigoBodega As String = ""
                    CodigoBodega = FrmFacturas.CboCodigoBodega.Text

                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)

                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)

                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Lista, Existencia_Unidades,Cod_Iva FROM Productos"
                    SQlProductos = "SELECT DISTINCT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, Productos.Precio_Lista, DetalleBodegas.Existencia, Productos.Cod_Iva FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos WHERE (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') AND (Productos.Activo = N'Activo') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Precio $"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 620

                    MiConexion.Close()
                Case "Arqueo"
                    SQlProductos = "SELECT CodArqueo, FechaArqueo, Cod_Cajero FROM Arqueo ORDER BY CodArqueo"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195
                Case "CodigoCajero"
                    SQlProductos = "SELECT Cod_Cajero, Nombre_Cajero + ' ' + Apellido_Cajero AS Nombres FROM  Cajeros ORDER BY Cod_Cajero"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195

                Case "FacturasHistoricos"
                    If FrmFacturasHistoricos.CboTipoProducto.Text <> "" Then
                        SQlProductos = "SELECT Facturas.Numero_Factura AS Numero, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente, Facturas.Fecha_Factura AS Fecha, Facturas.Tipo_Factura AS Tipo  FROM  Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Activo = 0) AND (Facturas.Tipo_Factura = '" & FrmFacturasHistoricos.CboTipoProducto.Text & "') ORDER BY Numero  "
                    Else
                        SQlProductos = "SELECT Facturas.Numero_Factura AS Numero, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente, Facturas.Fecha_Factura AS Fecha, Facturas.Tipo_Factura AS Tipo  FROM  Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Activo = 0) ORDER BY Numero  "
                    End If
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 110


                Case "DevFacturas"

                    SQlProductos = "SELECT Facturas.Numero_Factura AS Numero, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente, Facturas.Fecha_Factura AS Fecha, Facturas.Tipo_Factura AS Tipo  FROM  Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Activo = 1) AND (Facturas.Tipo_Factura = 'Factura') ORDER BY Numero  "

                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 110

                Case "Facturas"
                    If FrmFacturas.CboTipoProducto.Text <> "" Then
                        SQlProductos = "SELECT Facturas.Numero_Factura AS Numero, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente, Facturas.Fecha_Factura AS Fecha, Facturas.Tipo_Factura AS Tipo  FROM  Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Activo = 1) AND (Facturas.Tipo_Factura = '" & FrmFacturas.CboTipoProducto.Text & "') ORDER BY Numero  "
                        If FrmFacturas.CboTipoProducto.Text = "Cotizacion" Then
                            Select Case Acceso
                                Case "Vendedores"
                                    SQlProductos = "SELECT Facturas.Numero_Factura AS Numero, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente, Facturas.Fecha_Factura AS Fecha, Facturas.Tipo_Factura AS Tipo  FROM  Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Activo = 1) AND (Facturas.Tipo_Factura = '" & FrmFacturas.CboTipoProducto.Text & "') AND (Facturas.Cod_Vendedor = '" & FrmFacturas.CboCodigoVendedor.Text & "') ORDER BY Numero  "

                            End Select
                        End If

                    Else
                        SQlProductos = "SELECT Facturas.Numero_Factura AS Numero, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente, Facturas.Fecha_Factura AS Fecha, Facturas.Tipo_Factura AS Tipo  FROM  Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Activo = 1) ORDER BY Numero  "
                    End If
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 110

                Case "Transferencias"
                    If FrmTransferencias.CboTipoProducto.Text <> "" Then
                        SQlProductos = "SELECT Facturas.Numero_Factura AS Numero, Facturas.Fecha_Factura AS Fecha, Bodegas.Nombre_Bodega, Facturas.Tipo_Factura AS Tipo FROM  Facturas INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega WHERE (Facturas.Activo = 1) AND (Facturas.Tipo_Factura = 'Transferencia Enviada') ORDER BY Numero"
                    Else
                        SQlProductos = "SELECT Facturas.Numero_Factura AS Numero, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente, Facturas.Fecha_Factura AS Fecha, Facturas.Tipo_Factura AS Tipo  FROM  Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Activo = 1) ORDER BY Numero  "
                    End If
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 195
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 110
                Case "Plantillas"
                    If FrmPlantillas.CboTipoProducto.Text <> "" Then
                        SQlProductos = "SELECT NumeroPlantilla, Fecha_Plantilla, Tipo_Plantilla,Referencia_Plantilla FROM Plantilla WHERE (Tipo_Plantilla = '" & FrmPlantillas.CboTipoProducto.Text & "') ORDER BY NumeroPlantilla"
                    Else
                        SQlProductos = "SELECT NumeroPlantilla, Fecha_Plantilla, Tipo_Plantilla, Referencia_Plantilla FROM Plantilla ORDER BY NumeroPlantilla"
                    End If
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 85
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 85
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 75
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 190
                Case "CodigoNotas"
                    SQlProductos = "SELECT * FROM NotaDebito "
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 100

                Case "CodigoCliente"
                    If CodigoClienteNumero = True Then
                        SQlProductos = "SELECT  Cod_Cliente, Nombre_Cliente, Apellido_Cliente,REPLACE(STR(Cod_Cliente), ' ', '0') AS Orden  FROM Clientes WHERE (Activo = 1) ORDER BY Orden"
                    Else
                        SQlProductos = "SELECT  Cod_Cliente, Nombre_Cliente, Apellido_Cliente FROM Clientes WHERE (Activo = 1)"
                    End If
                    '
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 100
                    If CodigoClienteNumero = True Then
                        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    End If

                Case "CuentasPagarCompras"
                    SQlProductos = "SELECT Numero_Compra, Fecha_Compra, MontoCredito FROM Compras WHERE (Cod_Proveedor = '" & FrmCompras.TxtCodigoProveedor.Text & "') AND (MontoCredito <> 0) AND (Tipo_Compra = 'Mercancia Recibida') ORDER BY Fecha_Compra"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 100

                Case "Compras"
                    If TipoCompra = "" Then
                        SQlProductos = "SELECT Compras.Numero_Compra AS Numero, Compras.Nombre_Proveedor + ' ' + Compras.Apellido_Proveedor AS Proveedor, Compras.Fecha_Compra AS Fecha, Compras.Tipo_Compra AS Tipo, Compras.FechaHora  FROM  Compras INNER JOIN  Proveedor ON Compras.Cod_Proveedor = Proveedor.Cod_Proveedor WHERE (Compras.Activo = 1) ORDER BY Numero  "
                    Else
                        SQlProductos = "SELECT Compras.Numero_Compra AS Numero, Compras.Nombre_Proveedor + ' ' + Compras.Apellido_Proveedor AS Proveedor, Compras.Fecha_Compra AS Fecha, Compras.Tipo_Compra AS Tipo, Compras.FechaHora  FROM  Compras INNER JOIN  Proveedor ON Compras.Cod_Proveedor = Proveedor.Cod_Proveedor WHERE (Compras.Activo = 1) AND (Compras.Tipo_Compra = '" & TipoCompra & "') ORDER BY Numero  "
                    End If

                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 110

                Case "ComprasHistorico"
                    If My.Forms.FrmComprasHistorico.CboTipoProducto.Text <> "" Then
                        SQlProductos = "SELECT Compras.Numero_Compra AS Numero, Compras.Nombre_Proveedor + ' ' + Compras.Apellido_Proveedor AS Proveedor, Compras.Fecha_Compra AS Fecha, Compras.Tipo_Compra AS Tipo  FROM  Compras INNER JOIN  Proveedor ON Compras.Cod_Proveedor = Proveedor.Cod_Proveedor WHERE (Compras.Activo = 0) AND (Compras.Tipo_Compra = '" & My.Forms.FrmComprasHistorico.CboTipoProducto.Text & "') ORDER BY Numero  "
                    Else
                        SQlProductos = "SELECT Compras.Numero_Compra AS Numero, Compras.Nombre_Proveedor + ' ' + Compras.Apellido_Proveedor AS Proveedor, Compras.Fecha_Compra AS Fecha, Compras.Tipo_Compra AS Tipo  FROM  Compras INNER JOIN  Proveedor ON Compras.Cod_Proveedor = Proveedor.Cod_Proveedor WHERE (Compras.Activo = 0) ORDER BY Numero"
                    End If
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 110

                Case "Bodegas"
                    SQlProductos = "SELECT  * FROM   Bodegas"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 200

                Case "CodigoProductosDetalle"
                    Dim CodigoBodega As String
                    CodigoBodega = FrmTransferencias.CboCodigoBodega.Text


                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Costo_Promedio, Existencia_Unidades,Cod_Iva FROM Productos Where (Tipo_Producto <> 'Ensambles')"
                    SQlProductos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, DetalleBodegas.Costo, DetalleBodegas.Existencia as Existencia_Unidades, Productos.Cod_Iva FROM  Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos  " & _
                                   "WHERE (Productos.Tipo_Producto <> 'Ensambles') AND (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Costo Prom"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False

                    MiConexion.Close()

                Case "CodigoProductosCompra"
                    Dim CodigoBodega As String
                    CodigoBodega = FrmCompras.CboCodigoBodega.Text


                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Costo_Promedio, Existencia_Unidades,Cod_Iva FROM Productos Where (Tipo_Producto <> 'Ensambles')"
                    SQlProductos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Productos.Tipo_Producto, DetalleBodegas.Costo, DetalleBodegas.Existencia_Unidades, Productos.Cod_Iva FROM  Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos  " & _
                                   "WHERE (Productos.Tipo_Producto <> 'Ensambles') AND (DetalleBodegas.Cod_Bodegas = '" & CodigoBodega & "') ORDER BY Productos.Cod_Productos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Costo Prom"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False

                    MiConexion.Close()

                Case "MetodoPago"
                    SQlProductos = "SELECT  NombrePago, TipoPago FROM  MetodoPago"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100

                Case "Ensamble"
                    SQlProductos = "SELECT * FROM Ensamble WHERE (Activo = 1) AND (Tipo_Ensamble = N'Ensamble Recibido')"

                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo Ensamble"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(8).Visible = False

                Case "Ensambles"
                    SQlProductos = "SELECT  *  FROM Ensamble WHERE (Activo = 1) AND (Tipo_Ensamble = '" & FrmEnsamble.CboTipoProducto.Text & "')"

                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo Ensamble"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(8).Visible = False

                Case "CodigoProductosEnsamble"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, CodComponente FROM Productos WHERE (Tipo_Producto = 'Ensambles')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"


                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 220
                Case "CodigoProductosComponente"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto FROM Productos WHERE (Cod_Productos <> '" & FrmProductos.CboCodigoProducto.Text & "')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()
                Case "CuentaPagarInteres"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Cuentas x Pagar')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CuentaCobrarInteres"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Cuentas x Cobrar')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "Cuenta"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas "
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "Bodegas"
                    SQlProductos = "SELECT  * FROM   Bodegas"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 250
                    MiConexion.Close()

                Case "CodigoProducto"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto FROM Productos "
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()
                Case "CuentaBancos"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Bancos')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CuentaCaja"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Caja')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CuentaGastoAjuste"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Gastos')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CuentaIngresoAjuste"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Ingresos - Ventas')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CuentaInventario"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Inventario')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CodigoVendedor"
                    SQlProductos = "SELECT Cod_Vendedor, Nombre_Vendedor AS Nombres, Apellido_Vendedor AS Apellidos FROM   Vendedores"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()
                Case "CodigoImpuestos"
                    SQlProductos = "SELECT * FROM Impuestos"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                Case "CodigoRubro"
                    SQlProductos = "SELECT  * FROM  Rubro"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                Case "CodigoTarea"
                    SQlProductos = "SELECT  * FROM  Tareas"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                Case "CodigoLinea"
                    SQlProductos = "SELECT Cod_Linea, Descripcion_Linea FROM Lineas"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CuentaGeneral"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas "
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CuentaPagar"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Cuentas x Pagar')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                Case "CuentaCobrar"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas As Descripcion, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Cuentas x Cobrar')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()
                Case "CodigoProveedor"
                    SQlProductos = "SELECT Cod_Proveedor As Codigo, Nombre_Proveedor As Nombres, Apellido_Proveedor As Apellidos FROM Proveedor"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "CodigoProductos"
                    Me.Size = New System.Drawing.Size(988, 424)
                    Me.Location = New Point(160, 160)
                    Me.TrueDBGridConsultas.Size = New System.Drawing.Size(950, 222)
                    Me.ButtonSalir.Location = New Point(880, 305)

                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta FROM Productos "
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"

                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 700
                    MiConexion.Close()


                Case "CuentaInventario"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Inventario')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "CuentaCosto"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Costos')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "CuentaVentas"
                    SQlProductos = "SELECT CodCuentas , DescripcionCuentas, TipoCuenta FROM Cuentas WHERE (TipoCuenta = 'Ingresos - Ventas')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiconexionContabilidad)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()


            End Select

            For Each col As C1.Win.C1TrueDBGrid.C1DataColumn In Me.TrueDBGridConsultas.Columns
                col.FilterText = ""
            Next


            Me.TrueDBGridConsultas.AlternatingRows = True
            Me.TrueDBGridConsultas.AllowFilter = False

            Me.TrueDBGridConsultas.Styles.Item(0).GradientMode = C1.Win.C1TrueDBGrid.GradientModeEnum.Vertical
            Me.StartPosition = FormStartPosition.CenterScreen

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Fecha = Format(Now, "dd/MM/yyyy")
        Codigo = "-----0-----"
        Me.Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Posicion As Integer

        Codigo = "-----0-----"
        TipoProducto = ""

        Select Case Quien
            Case "CodigoProductosBodega"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")

            Case "Recolector"
                Posicion = Me.BindingConsultas.Position

                If Not IsDBNull(Me.BindingConsultas.Item(Posicion)("NombreRecolector")) Then
                    Me.Nombre_Recolector = Me.BindingConsultas.Item(Posicion)("NombreRecolector")
                End If
                If Not IsDBNull(Me.BindingConsultas.Item(Posicion)("TelefonoRecolector")) Then
                    Me.Telefono_Recolector = Me.BindingConsultas.Item(Posicion)("TelefonoRecolector")
                End If

                If Not IsDBNull(Me.BindingConsultas.Item(Posicion)("CedulaRecolector")) Then
                    Me.Cecula_Recolector = Me.BindingConsultas.Item(Posicion)("CedulaRecolector")
                End If

            Case "LiquidacionLeche"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroLiquidacion")
            Case "CuentasContables"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion")
            Case "TipoNomina"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodTipoNomina")
                Nombres = Me.BindingConsultas.Item(Posicion)("TipoNomina")
            Case "CodigoProductor"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodProductor")
                Nombres = Me.BindingConsultas.Item(Posicion)("NombreProductor")
                Apellidos = Me.BindingConsultas.Item(Posicion)("ApellidoProductor")
            Case "RecepcionPlanilla"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
            Case "Ruta"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodRuta")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombre_Ruta")
            Case "Repesaje"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroRecepcion")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                Conductor = Me.BindingConsultas.Item(Posicion)("Conductor")
                CodProveedor = Me.BindingConsultas.Item(Posicion)("Cod_Proveedor")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("TipoRecepcion")
            Case "SalidaBascula"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroRecepcion")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                Conductor = Me.BindingConsultas.Item(Posicion)("Conductor")
                CodProveedor = Me.BindingConsultas.Item(Posicion)("Cod_Cliente")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("TipoRecepcion")
            Case "Recepcion"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroRecepcion")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                Conductor = Me.BindingConsultas.Item(Posicion)("Conductor")
                CodProveedor = Me.BindingConsultas.Item(Posicion)("Cod_Proveedor")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("TipoRecepcion")
            Case "Conductor"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombre")
            Case "Vehiculo"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Placa")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Marca")
            Case "ProyectosFactura"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodigoProyectos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("NombreProyectos")
            Case "Proyectos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodigoProyectos")

            Case "NB"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero_Nota")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Nota")

            Case "NBPROVEEDORES"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero_Nota")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Nota")
            Case "ProductosLiquidacion"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                If Not IsDBNull(Me.BindingConsultas.Item(Posicion)("Costo")) Then
                    Precio = Me.BindingConsultas.Item(Posicion)("Costo")
                Else
                    Precio = 0
                End If
                If Not IsDBNull(Me.BindingConsultas.Item(Posicion)("Cod_Iva")) Then
                    CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
                Else
                    CodIva = 0
                    MsgBox("El producto no tiene asignada la tabla iva", MsgBoxStyle.Critical, "Zeus Facturacion")
                End If
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "Recibos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodReciboPago")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Recibo")
                Nombres = Me.BindingConsultas.Item(Posicion)("NombreCliente")
            Case "Pagos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodReciboPago")
                CodigoProveedor = Me.BindingConsultas.Item(Posicion)("Cod_Proveedor")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Recibo")
                Nombres = Me.BindingConsultas.Item(Posicion)("Nombre_Proveedor")
            Case "CodigoTipoPrecio"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_TipoPrecio")
            Case "Liquidacion"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero_Liquidacion")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Liquidacion")
                Nombres = Me.BindingConsultas.Item(Posicion)("Nombre_Proveedor")
                Apellidos = Me.BindingConsultas.Item(Posicion)("Apellido_Proveedor")
            Case "CodigoProductosCordobasPlantilla"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Precio_Venta")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
            Case "CodigoProductosFacturaPlantilla"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Precio_Lista")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
            Case "CodigoProductosCordobas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Precio_Venta")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
            Case "CodigoProductosFactura"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Precio_Lista")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
            Case "CodigoProductosSolicitud"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
            Case "Arqueo"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodArqueo")
                Fecha = Me.BindingConsultas.Item(Posicion)("FechaArqueo")
                CodCajero = Me.BindingConsultas.Item(Posicion)("Cod_Cajero")

            Case "CodigoCajero"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Cajero")
            Case "FacturasHistoricos"
                Posicion = Me.BindingConsultas.Position
                Nombres = Me.BindingConsultas.Item(Posicion)("Cliente")
                If Me.BindingConsultas.Item(Posicion)("Cliente") = "******CANCELADO ******" Then
                    MsgBox(Me.BindingConsultas.Item(Posicion)("Tipo") & " CANCELADA", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Nombres = Me.BindingConsultas.Item(Posicion)("Cliente")
                Else
                    Posicion = Me.BindingConsultas.Position
                    Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                    Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                    TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
                End If
            Case "Facturas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                NumFactura = Me.BindingConsultas.Item(Posicion)("Numero")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
            Case "Plantillas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroPlantilla")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Plantilla")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo_Plantilla")
            Case "CodigoNotas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodigoNB")
            Case "CodigoCliente"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Cliente")

            Case "Compras"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                FechaHora = Me.BindingConsultas.Item(Posicion)("FechaHora")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
            Case "ComprasHistorico"
                Posicion = Me.BindingConsultas.Position
                Nombres = Me.BindingConsultas.Item(Posicion)("Proveedor")
                If Me.BindingConsultas.Item(Posicion)("Proveedor") = "******CANCELADO ******" Then
                    MsgBox(Me.BindingConsultas.Item(Posicion)("Tipo") & " CANCELADA", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Nombres = Me.BindingConsultas.Item(Posicion)("Proveedor")
                Else
                    Posicion = Me.BindingConsultas.Position
                    Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                    Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                    TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
                End If

            Case "Bodegas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Bodega")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombre_Bodega")
            Case "CodigoProductosDetalle"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = 0 'Me.BindingConsultas.Item(Posicion)("Costo")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "CodigoProductosCompra"

                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")

                'If TieneMovimientos(Codigo, My.Forms.FrmCompras.DTPFechaHora.Value) = True Then
                '    MsgBox(Mensaje, MsgBoxStyle.Critical, "Zeus Facturacion")
                '    Codigo = "-----0-----"
                '    Exit Sub
                'End If

                If Not IsDBNull(Me.BindingConsultas.Item(Posicion)("Costo")) Then
                    Precio = Me.BindingConsultas.Item(Posicion)("Costo")
                Else
                    Precio = 0
                End If
                If Not IsDBNull(Me.BindingConsultas.Item(Posicion)("Cod_Iva")) Then
                    CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
                Else
                    CodIva = 0
                    MsgBox("El producto no tiene asignada la tabla iva", MsgBoxStyle.Critical, "Zeus Facturacion")
                End If
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "MetodoPago"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NombrePago")

            Case "Ensamble"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_ReciboEnsamble")
                Cantidad = Me.BindingConsultas.Item(Posicion)("Cantidad_Principal")
                CodProducto = Me.BindingConsultas.Item(Posicion)("Cod_ProductoEnsamble")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Ensamble")
                CodComponente = Me.BindingConsultas.Item(Posicion)("Cod_Componente")
                TipoEnsamble = Me.BindingConsultas.Item(Posicion)("Tipo_Ensamble")
            Case "Ensambles"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_ReciboEnsamble")
                Cantidad = Me.BindingConsultas.Item(Posicion)("Cantidad_Principal")
                CodProducto = Me.BindingConsultas.Item(Posicion)("Cod_ProductoEnsamble")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Ensamble")
                CodComponente = Me.BindingConsultas.Item(Posicion)("Cod_Componente")
            Case "CodigoProductosEnsamble"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                CodComponente = Me.BindingConsultas.Item(Posicion)("CodComponente")
            Case "CodigoProductosComponente"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
            Case "CuentaPagarInteres"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaCobrarInteres"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")

            Case "Bodegas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Bodega")
            Case "CodigoProducto"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "CodigoServicios"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "CuentaBancos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion")
            Case "CuentaCaja"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaGastoAjuste"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaIngresoAjuste"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")

            Case "Cuenta"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion")
            Case "CodigoImpuestos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
                DescripcionImpuestos = Me.BindingConsultas.Item(Posicion)("Descripcion_Iva")
                TasaImpuestos = Me.BindingConsultas.Item(Posicion)("Impuesto")
                TipoImpuesto = Me.BindingConsultas.Item(Posicion)("TipoImpuesto")
            Case "CodigoRubro"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo_Rubro")
            Case "CodigoTarea"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodigoTarea")
            Case "CodigoLinea"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Linea")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Linea")
            Case "CuentaGeneral"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaPagar"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaCobrar"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")

            Case "CodigoProveedor"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombres")
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Apellidos")

            Case "CodigoProductos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")


                'Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                'Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                'TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "CuentaInventario"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaCosto"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaVentas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")

            Case "Transferencias"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
        End Select

        Me.Close()
    End Sub


    Private Sub TrueDBGridConsultas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridConsultas.DoubleClick
        Button2_Click(sender, e)
    End Sub
    Private Function getFilter() As String
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Dim tmp As String = ""
        Dim n As Integer

        For Each col In Me.TrueDBGridConsultas.Columns

            If Trim(col.FilterText) <> "" Then
                n = n + 1
                If n > 1 Then
                    tmp = tmp & " AND "
                End If
                tmp = tmp & col.DataField & " LIKE '" & col.FilterText & "*'"
            End If
        Next col

        getFilter = tmp

    End Function


    Private Sub TrueDBGridConsultas_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridConsultas.FilterChange
        Dim sb As New System.Text.StringBuilder()
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn


        For Each dc In Me.TrueDBGridConsultas.Columns
            If dc.FilterText.Length > 0 Then
                If sb.Length > 0 Then
                    sb.Append(" AND ")
                End If
                sb.Append((dc.DataField + " LIKE " + "'%" + dc.FilterText + "%'"))
            End If
        Next dc


        Me.DataSet.Tables("Consultas").DefaultView.RowFilter = sb.ToString()

    End Sub


    Private Sub TrueDBGridConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridConsultas.Click

    End Sub

    Private Sub TrueDBGridConsultas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TrueDBGridConsultas.KeyPress

    End Sub

    Private Sub TrueDBGridConsultas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TrueDBGridConsultas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2_Click(sender, e)
        End If
    End Sub


End Class