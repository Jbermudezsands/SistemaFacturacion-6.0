Public Class FrmRecepcion
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Año As String, Mes As String, Dia As String, ConsecutivoFacturaSerie As Boolean = False, Numero_Recepcion As String, PesoBruto As Double = 0, Procesar As Boolean = False, Tara As Double
    Delegate Sub delegado(ByVal data As String)
    Private Sub Siguiente()
        If Me.TrueDBGridComponentes.RowCount <> 0 Then
            Dim Iposicion As Double
            Iposicion = Me.TrueDBGridComponentes.RowCount
            Me.TrueDBGridComponentes.Row = Iposicion
            Me.TrueDBGridComponentes.Columns(1).Text = Me.CboCodigoProducto.Columns(0).Text
            Me.TrueDBGridComponentes.Columns(2).Text = Me.CboCodigoProducto.Columns(1).Text
            Me.TrueDBGridComponentes.Col = 5
        End If

    End Sub

    Private Sub FrmRecepcion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Button10_Click(sender, e)
    End Sub


    Private Sub FrmRecepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Ruta As String, LeeArchivo As String

        Procesar = False
        DataSet.Reset()

        Me.CmbTipoPesada.Text = "PESADA BASCULA"
        Me.CmdPesada.Visible = False

        If Quien = "Recepcion" Then
            Me.CboTipoRecepcion.Text = "Recepcion"
            sql = "SELECT * FROM Proveedor WHERE (InventarioFisico = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProveedores")
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")
            Me.LblSucursal.Text = "RECEPCION DE PRODUCTOS"

            Me.CboCodigoProveedor.Columns(0).Caption = "Codigo"
            Me.CboCodigoProveedor.Columns(1).Caption = "Proveedor"
            Me.CboCodigoProveedor.Columns(2).Caption = "Origen"

            Me.GroupBox2.Visible = False
            Me.GroupBoxRecolector.Visible = True
            Me.GroupBoxRecolector.Location = New Point(535, 140)

        ElseIf Quien = "SalidaBascula" Then
            Me.CboTipoRecepcion.Text = "Salidabascula"

            sql = "SELECT * FROM Clientes"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "ListaClientes")
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaClientes")
            Me.LblSucursal.Text = "SALIDA DE PRODUCTOS"

            Me.CboCodigoProveedor.Columns(0).Caption = "Codigo"
            Me.CboCodigoProveedor.Columns(1).Caption = "Clientes"
            Me.CboCodigoProveedor.Columns(2).Caption = "Origen"
            Me.BtnProcesar.Visible = False
            Me.GroupBoxRecolector.Visible = True

        ElseIf Quien = "Repesaje" Then
            Me.CboTipoRecepcion.Text = "Repesaje"

            sql = "SELECT * FROM Proveedor WHERE (InventarioFisico = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProveedores")
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")

            Me.LblSucursal.Text = "REPESAJE DE PRODUCTOS"

            Me.CboCodigoProveedor.Columns(0).Caption = "Codigo"
            Me.CboCodigoProveedor.Columns(1).Caption = "Proveedor"
            Me.CboCodigoProveedor.Columns(2).Caption = "Origen"

            Me.BtnProcesar.Visible = False
            Me.GroupBoxRecolector.Visible = True
        End If





        MiConexion.Open()

        sql = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            ConsecutivoFacturaSerie = DataSet.Tables("DatosEmpresa").Rows(0)("ConsecutivoFacSerie")
        End If




        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM   Bodegas"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT IdVehiculo, Placa, Marca, TipoVehiculo FROM Vehiculo WHERE(Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.CboPlaca.DataSource = DataSet.Tables("Placa")
        If Not DataSet.Tables("Placa").Rows.Count = 0 Then
            Me.CboPlaca.Text = DataSet.Tables("Placa").Rows(0)("Placa")
        End If
        Me.CboPlaca.Columns(0).Caption = "Placa"
        Me.CboPlaca.Splits.Item(0).DisplayColumns("IdVehiculo").Visible = False


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        Me.CboConductor.DataSource = DataSet.Tables("Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            Me.CboConductor.Text = DataSet.Tables("Conductor").Rows(0)("Nombre")
        End If
        Me.CboConductor.Columns(0).Caption = "Codigo"
        Me.CboConductor.Splits.Item(0).DisplayColumns("Codigo").Visible = False

        MiConexion.Close()


        ''////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ''///////////////////////CARGO LOS SERIES////////////////////////////////////////////////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SqlString = "SELECT DISTINCT Serie FROM ConsecutivoSerie ORDER BY Serie DESC"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivoSerie")
        CmbSerie.DataSource = DataSet.Tables("ConsecutivoSerie")
        If Not DataSet.Tables("ConsecutivoSerie").Rows.Count = 0 Then
            Me.CmbSerie.Text = DataSet.Tables("ConsecutivoSerie").Rows(0)("Serie")
        End If
        MiConexion.Close()


        If Me.ConsecutivoFacturaSerie = True Then
            Me.CmbSerie.Visible = True
        End If


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion  WHERE (NumeroRecepcion = N'-100000')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"

        Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 300
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Calidad"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Calidad").Visible = False
        Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Estado").Visible = False

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75





        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
        Año = Microsoft.VisualBasic.DateAndTime.Year(Now)
        Mes = Microsoft.VisualBasic.DateAndTime.Month(Now)
        Dia = Microsoft.VisualBasic.DateAndTime.Day(Now)



        If UsuarioBodegaCompra <> "" Then

            Me.CboCodigoBodega.Text = UsuarioBodegaCompra

            '/////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////CARGO LOS PRODUCTOS //////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'DataSet.Tables("ListaProductos").Reset()
            SqlProductos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto FROM  DetalleBodegas INNER JOIN Productos ON DetalleBodegas.Cod_Productos = Productos.Cod_Productos WHERE  (DetalleBodegas.Cod_Bodegas = '" & UsuarioBodega & "') AND (Productos.Tipo_Producto = 'Productos')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProductos")
            If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
                Me.CboCodigoProducto.Text = DataSet.Tables("ListaProductos").Rows(0)("Descripcion_Producto")
                Me.CboCodigoProducto.Splits(0).DisplayColumns(1).Width = 400
            End If
        Else

            SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProductos")
            If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
                Me.CboCodigoProducto.Text = DataSet.Tables("ListaProductos").Rows(0)("Descripcion_Producto")
            End If
            Me.CboCodigoProducto.Splits(0).DisplayColumns(1).Width = 400
        End If

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiaRecepcion()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO ENCABEZADO DE RECEPCION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.BindingDetalle.Count <> 0 Then
            GrabaRecepcion(Me.TxtNumeroEnsamble.Text)
            Bitacora(Now, NombreUsuario, "Recepcion", "Se Agrego la Recepcion: " & Me.TxtNumeroEnsamble.Text)
            LimpiaRecepcion()
        Else
            MsgBox("Seleccione Productos para poder Grabar", MsgBoxStyle.Critical, "Zeus Inventario")
        End If

        If Me.CboTipoRecepcion.Text = "RePesaje" Then
            Me.Close()
        End If
    End Sub

    Private Sub CboConductor_TextChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboConductor.TextChanged

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Codigo As String

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS CONDUCTORES////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Codigo = Me.CboConductor.Columns("Codigo").Text
        SqlString = "SELECT Codigo, Nombre, Cedula, Licencia, Activo, ListaNegra, RazonListaNegra FROM Conductor WHERE (Activo = 1) AND (Codigo = '" & Codigo & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            Me.TxtCedula.Text = DataSet.Tables("Conductor").Rows(0)("Cedula")
        End If
        Me.CboConductor.Columns(0).Caption = "Codigo"
        'Me.CboCodigoBodega.Columns(1).Caption = "Placa"

        MiConexion.Close()
    End Sub

    Private Sub CboPlaca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPlaca.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Codigo As String

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        SqlString = "SELECT Placa, Marca, TipoVehiculo FROM Vehiculo WHERE(Activo = 1) AND (Placa = '" & Me.CboPlaca.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        If Not DataSet.Tables("Placa").Rows.Count = 0 Then
            Me.TxtMarca.Text = DataSet.Tables("Placa").Rows(0)("Marca")
        End If
        Me.CboPlaca.Columns(0).Caption = "Placa"
    End Sub

    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = ""

        If Quien = "Recepcion" Then
            SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') AND (InventarioFisico = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedor")
            If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
                Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")

                If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                    Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor") & " " & DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                End If

            End If

        ElseIf Quien = "SalidaBascula" Then
            SqlProveedor = "SELECT * FROM Clientes WHERE (Cod_Cliente = '" & Me.CboCodigoProveedor.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Clientes")
            If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
                Me.txtnombre.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")

                If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                    Me.txtnombre.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente") & " " & DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                End If

            End If


        ElseIf Quien = "Repesaje" Then
            SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') AND (InventarioFisico = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedor")
            If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
                Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")

                If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                    Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor") & " " & DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                End If

            End If


        End If


        '////////////////////////////////////////////////BUSCO DATOS DEL CONDUCTOR ///////////////////////////////////
        SqlProveedor = "SELECT DISTINCT Conductor, Id_identificacion, Id_Vehiculo, Cod_Bodega, Observaciones, SubTotal, Telefono,Cod_SubProveedor  FROM Recepcion WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') ORDER BY Conductor"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Datos")
        If Not DataSet.Tables("Datos").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Conductor")) Then
                Me.CboConductor.Text = DataSet.Tables("Datos").Rows(0)("Conductor")
            End If
            If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Id_identificacion")) Then
                Me.txtid.Text = DataSet.Tables("Datos").Rows(0)("Id_identificacion")
            End If

            If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Id_Vehiculo")) Then
                Me.CboPlaca.Text = DataSet.Tables("Datos").Rows(0)("Id_Vehiculo")
            End If
            If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Cod_SubProveedor")) Then
                CodigoSubProveedor = DataSet.Tables("Datos").Rows(0)("Cod_SubProveedor")
            End If
        End If

    End Sub

    Public Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        My.Forms.FrmPuertos.Pregunta = "Recepcion"
        My.Forms.FrmPuertos.ShowDialog()
    End Sub

    Public Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.sp.Close()
        Me.LblEstado.Text = "DESCONECT"
        Me.LblEstado.ForeColor = Color.Black
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim ArepBitacoraRecepcion As New ArepBitacoraRecepcion, Sqldatos As String, RutaLogo As String
        Dim Fecha As String, Criterios As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Posicion As Double = 0, DescripcionAnterior As String = ""

        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")


        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, Calidad, Estado, Precio, PesoKg, PesoNetoKg, PesoNetoKg * Precio as TotalPagar, Merma, Tara  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"

        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            ArepBitacoraRecepcion.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepBitacoraRecepcion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepBitacoraRecepcion.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepBitacoraRecepcion.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If
        End If

        ArepBitacoraRecepcion.LblLote.Text = Me.Año & "-" & Me.Mes & "-" & Me.Dia & "-" & Me.CboCodigoProveedor.Text

        ArepBitacoraRecepcion.LblOrden.Text = Me.TxtNumeroEnsamble.Text
        ArepBitacoraRecepcion.LblFechaOrden.Text = Format(CDate(Me.DTPFecha.Text), "dd/MM/yyyy")
        If Me.TxtRecolector.Text <> "" Then
            ArepBitacoraRecepcion.LblCodRecolector.Text = Me.TxtRecolector.Text
        End If
        If Me.TxtTelefonoRecolector.Text <> "" Then
            ArepBitacoraRecepcion.LblNombreRecolector.Text = Me.TxtTelefonoRecolector.Text
        End If
        If Me.TxtCedulaRecolector.Text <> "" Then
            ArepBitacoraRecepcion.LblCedulaRecolector.Text = Me.TxtCedulaRecolector.Text
        End If

        ArepBitacoraRecepcion.LblTipoCompra.Text = Me.CboTipoRecepcion.Text
        'ArepBitacoraRecepcion.LblCodProveedor.Text = Me.CboCodigoProveedor.Text
        ArepBitacoraRecepcion.LblNombres.Text = Me.txtnombre.Text
        'ArepBitacoraRecepcion.LblApellidos.Text = Me.txtapellido.Text
        'ArepBitacoraRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepBitacoraRecepcion.LblPila.Text = Me.txtapellido.Text
        'ArepBitacoraRecepcion.LblConductor.Text = Me.CboConductor.Text
        'ArepBitacoraRecepcion.LblCedula.Text = Me.txtid.Text
        'ArepBitacoraRecepcion.LblPlaca.Text = Me.txtplaca.Text



        SQL.ConnectionString = Conexion
        SQL.SQL = SqlString

        Bitacora(Now, NombreUsuario, "Recepcion", "Se Imprimio la Tickets: " & Me.TxtNumeroEnsamble.Text)

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepBitacoraRecepcion.Document
        My.Application.DoEvents()
        ArepBitacoraRecepcion.DataSource = SQL
        ArepBitacoraRecepcion.Run(False)
        ViewerForm.Show()
        'ViewerForm.arvMain.Document.Print(False, False, False)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim ArepRecepcion As New ArepRecepcion, CodigoProducto As String, Sqldatos As String, RutaLogo As String
        Dim oDataRow As DataRow, Fecha As String, Registros As Double, i As Double, Buscar_Fila() As DataRow, Criterios As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Posicion As Double = 0, DescripcionAnterior As String = ""


        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")


        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, PesoKg  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '-100000') AND (Fecha = CONVERT(DATETIME, '2013-10-12 00:00:00', 102)) AND (TipoRecepcion = N'Recepcion') ORDER BY Cantidad"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Reporte")

        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, PesoKg  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') ORDER BY Cod_Productos DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")
        Registros = DataSet.Tables("Recepcion").Rows.Count
        i = 0

        Do While Registros > i

            CodigoProducto = DataSet.Tables("Recepcion").Rows(i)("Cod_Productos")

            '//////////////////////////////////////////BUSCO SI NO EXISTE PARA AGREGAR UNO NUEVO ///////////////////////////
            Criterios = "Cod_Productos= '" & CodigoProducto & "'"
            Buscar_Fila = DataSet.Tables("Reporte").Select(Criterios)
            If Buscar_Fila.Length = 0 Then
                oDataRow = DataSet.Tables("Reporte").NewRow
                oDataRow("id_Eventos") = DataSet.Tables("Recepcion").Rows(i)("id_Eventos")
                oDataRow("NumeroRecepcion") = DataSet.Tables("Recepcion").Rows(i)("NumeroRecepcion")
                oDataRow("Fecha") = DataSet.Tables("Recepcion").Rows(i)("Fecha")
                oDataRow("TipoRecepcion") = DataSet.Tables("Recepcion").Rows(i)("TipoRecepcion")
                oDataRow("Cod_Productos") = DataSet.Tables("Recepcion").Rows(i)("Cod_Productos")
                oDataRow("Descripcion_Producto") = DataSet.Tables("Recepcion").Rows(i)("Descripcion_Producto")
                oDataRow("Codigo_Beams") = DataSet.Tables("Recepcion").Rows(i)("Codigo_Beams")
                oDataRow("Cantidad") = DataSet.Tables("Recepcion").Rows(i)("Cantidad")
                oDataRow("PesoKg") = DataSet.Tables("Recepcion").Rows(i)("PesoKg")
                oDataRow("Unidad_Medida") = DataSet.Tables("Recepcion").Rows(i)("id_Eventos") & "-" & DataSet.Tables("Recepcion").Rows(i)("PesoKg") & "Kg"
                DataSet.Tables("Reporte").Rows.Add(oDataRow)
            Else
                Posicion = DataSet.Tables("Reporte").Rows.IndexOf(Buscar_Fila(0))
                DescripcionAnterior = DataSet.Tables("Reporte").Rows(Posicion)("Unidad_Medida")
                DataSet.Tables("Reporte").Rows(Posicion)("Unidad_Medida") = DescripcionAnterior & " , " & DataSet.Tables("Recepcion").Rows(i)("id_Eventos") & "-" & DataSet.Tables("Recepcion").Rows(i)("PesoKg") & "Kg"
                DataSet.Tables("Reporte").Rows(Posicion)("Cantidad") = DataSet.Tables("Reporte").Rows(Posicion)("Cantidad") + DataSet.Tables("Recepcion").Rows(i)("Cantidad")
                DataSet.Tables("Reporte").Rows(Posicion)("PesoKg") = DataSet.Tables("Reporte").Rows(Posicion)("PesoKg") + DataSet.Tables("Recepcion").Rows(i)("PesoKg")
            End If

            i = i + 1
        Loop


        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepRecepcion.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepRecepcion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepRecepcion.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepRecepcion.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        ArepRecepcion.LblLote.Text = Me.Año & "-" & Me.Mes & "-" & Me.Dia & "-" & Me.CboCodigoProveedor.Text
        ArepRecepcion.LblNotas.Text = Me.txtobservaciones.Text
        ArepRecepcion.LblOrden.Text = Me.TxtNumeroEnsamble.Text
        ArepRecepcion.LblFechaOrden.Text = Format(CDate(Me.DTPFecha.Text), "dd/MM/yyyy")
        ArepRecepcion.LblTipoCompra.Text = Me.CboTipoRecepcion.Text
        'ArepRecepcion.LblCodProveedor.Text = Me.CboCodigoProveedor.Text
        ArepRecepcion.LblNombres.Text = Me.txtnombre.Text
        ArepRecepcion.LblApellidos.Text = Me.txtapellido.Text
        'ArepRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepRecepcion.LblNombres.Text = Me.txtnombre.Text
        'ArepRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepRecepcion.LblPila.Text = Me.txtapellido.Text
        'ArepRecepcion.LblConductor.Text = Me.CboConductor.Text
        'ArepRecepcion.LblCedula.Text = Me.txtid.Text
        'ArepRecepcion.LblPlaca.Text = Me.txtplaca.Text


        Bitacora(Now, NombreUsuario, "Recepcion", "Se Imprimio la Recepcion: " & Me.TxtNumeroEnsamble.Text)

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepRecepcion.Document
        My.Application.DoEvents()

        ArepRecepcion.DataSource = DataSet.Tables("Reporte")
        ArepRecepcion.Run(False)
        ViewerForm.Show()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim SQLProveedor As String, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, Posicion As Double, CodigoLinea As String = ""
        Dim CodigoIngreso As String = "", SqlString As String = "", Fecha As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Ingreso?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado <> 6 Then
            Exit Sub
        End If

        Posicion = Me.BindingDetalle.Position
        If Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Linea")) Then
            CodigoLinea = Me.BindingDetalle.Item(Posicion)("Linea")
        End If

        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")

        SQLProveedor = "SELECT  *  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') AND (id_Eventos = " & CodigoLinea & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Deducciones")
        If Not DataSet.Tables("Deducciones").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Close()
            StrSqlUpdate = "DELETE FROM [Detalle_Recepcion] WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') AND (id_Eventos = " & CodigoLinea & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

        Bitacora(Now, NombreUsuario, "Recepcion", "Se Elimino la Linea en la Recepcion No: " & Me.TxtNumeroEnsamble.Text)


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion   WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"

        Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Calidad"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75

    End Sub

    Private Sub sp_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sp.DataReceived
        Dim s As String '= sp.ReadExisting, Pesada As Double

        Dim escribeport3 As New delegado(AddressOf Me.mostar)



        s = sp.ReadLine


        If Len(s) = 19 Then
            If Mid(s, 1, 5) <> "GROSS" Then
                Exit Sub
            End If
        End If

        Select Case Mid(s, 1, 4)
            Case "TARA" : Exit Sub
            Case "NETO" : Exit Sub
            Case "TEL:2263-5025" : Exit Sub
            Case "" : Exit Sub

        End Select

        If Len(s) > 5 Then
            s = SoloNumeros(s)


            If s = "2263-5025" Then  ''''SOBRE PASA EL " Then  SOLO EMTRIDES---
                Exit Sub
            End If


            If s <> "" Then
                Me.Invoke(escribeport3, s)
            End If

        End If

    End Sub


    Sub mostar(ByVal d As String)
        Dim Posicion As Double
        Dim Cadena As String, Pesada As Double, PesoEntero As Double, PesoDecimal As Double

        'Cadena = Mid(d, 7, Len(d))
        'Pesada = CDbl(Cadena)
        Cadena = d
        Pesada = SoloNumeros(Cadena)
        '-------------------------------SI SE ACTIVA EL REDONDEO CAMBIO LA PESADA
        If Me.ChkTaraSaco.Checked = True Then
            PesoEntero = Int(Pesada)
            PesoDecimal = Format(Pesada - PesoEntero, "##0.00")
            'If PesoDecimal >= 0.01 And PesoDecimal <= 0.4 Then
            '    PesoDecimal = 0
            'ElseIf PesoDecimal >= 0.41 And PesoDecimal <= 0.5 Then
            '    'PesoDecimal = 0.5
            'ElseIf PesoDecimal >= 0.51 And PesoDecimal <= 0.9 Then
            '    PesoDecimal = 0.5
            'ElseIf PesoDecimal >= 0.91 And PesoDecimal <= 0.99 Then
            '    'PesoDecimal = 1
            'End If

            Pesada = PesoEntero + PesoDecimal
        End If

        'Posicion = Me.BindingDetalle.Position
        Posicion = Me.TrueDBGridComponentes.Row
        Me.TrueDBGridComponentes.Columns(5).Text = Pesada
        'Me.LblPeso.Text = Pesada & " Kg"
        My.Application.DoEvents()
        GrabaLecturaPeso(Pesada)
        'Me.BindingDetalle.Position = Posicion + 1
        Me.TrueDBGridComponentes.Row = Posicion + 1
    End Sub

    Private Sub CmdPesada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPesada.Click
        Dim Pesada As Double, Posicion As Double


        Posicion = Me.TrueDBGridComponentes.Row

        FrmTeclado.ShowDialog()
        Pesada = FrmTeclado.Numero
        Me.LblPeso.Text = Pesada & " Kg"
        'Pesada = 100

        Me.TrueDBGridComponentes.Columns(5).Text = Pesada
        My.Application.DoEvents()
        GrabaLecturaPeso(Pesada)
        Me.TrueDBGridComponentes.Row = Posicion + 1



        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Locked = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If Quien = "Recepcion" Then
            Quien = "CodigoProveedor"
            My.Forms.FrmConsultas.ShowDialog()
            Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo

        ElseIf Quien = "SalidaBascula" Then
            Quien = "CodigoCliente"
            My.Forms.FrmConsultas.ShowDialog()
            Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo

        ElseIf Quien = "Repesaje" Then
            Quien = "CodigoProveedor"
            My.Forms.FrmConsultas.ShowDialog()
            Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
        End If





    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        FrmTeclado.ShowDialog()
        If FrmTeclado.Numero <> 0 Then
            Me.CboCodigoProveedor.Text = FrmTeclado.Numero
        End If
    End Sub

    Private Sub CboCodigoProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProducto.TextChanged

    End Sub

    Private Sub CboCodigoBodega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoBodega.TextChanged

    End Sub

    Private Sub C1Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button5.Click
        Quien = "Vehiculo"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboPlaca.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Quien = "Conductor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboConductor.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        CboCodigoProducto.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Quien = "Recepcion" Then
            My.Forms.FrmConsultas.ShowDialog()
            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                Me.DTPFecha.Text = FrmConsultas.Fecha
                Me.CboConductor.Text = FrmConsultas.Conductor
                Me.CboCodigoProveedor.Text = FrmConsultas.CodProveedor
                Me.CboTipoRecepcion.Text = FrmConsultas.TipoCompra
                Me.TxtNumeroEnsamble.Text = FrmConsultas.Codigo
            End If

        ElseIf Quien = "SalidaBascula" Then
            My.Forms.FrmConsultas.ShowDialog()
            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                Me.DTPFecha.Text = FrmConsultas.Fecha
                Me.CboConductor.Text = FrmConsultas.Conductor
                Me.CboCodigoProveedor.Text = FrmConsultas.CodProveedor
                Me.CboTipoRecepcion.Text = FrmConsultas.TipoCompra
                Me.TxtNumeroEnsamble.Text = FrmConsultas.Codigo
            End If

        ElseIf Quien = "Repesaje" Then
            My.Forms.FrmConsultas.ShowDialog()
            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                Me.DTPFecha.Text = FrmConsultas.Fecha
                Me.CboConductor.Text = FrmConsultas.Conductor
                Me.CboCodigoProveedor.Text = FrmConsultas.CodProveedor
                Me.CboTipoRecepcion.Text = FrmConsultas.TipoCompra
                Me.TxtNumeroEnsamble.Text = FrmConsultas.Codigo
            End If
        End If
        My.Application.DoEvents()
        Siguiente()

    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, TipoCompra As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sql As String


        If Quien = "NumeroCompras" Then
            Exit Sub
        ElseIf Quien = "MetodoPago" Then
            Exit Sub
        End If

        Try



            If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then

                Procesar = False

                TipoCompra = Me.CboTipoRecepcion.Text
                Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")

                If TipoCompra = "Recepcion" Then
                    SqlCompras = "SELECT Proveedor.Nombre_Proveedor, Recepcion.* FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor  " & _
                                 "WHERE (Recepcion.NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Recepcion.Fecha BETWEEN CONVERT(DATETIME, '" & Fecha & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Fecha & " 23:59:00', 102)) AND (Recepcion.TipoRecepcion = '" & TipoCompra & "')"

                ElseIf TipoCompra = "SalidaBascula" Then
                    SqlCompras = "SELECT Clientes.Nombre_Cliente + ' ' + Apellido_Cliente As Nombre_Proveedor, Recepcion.* FROM Recepcion INNER JOIN Clientes ON Recepcion.Cod_Proveedor = Clientes.Cod_Cliente  " & _
                                 "WHERE (Recepcion.NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Recepcion.Fecha BETWEEN CONVERT(DATETIME, '" & Fecha & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Fecha & " 23:59:00', 102)) AND (Recepcion.TipoRecepcion = '" & TipoCompra & "')"
                ElseIf TipoCompra = "Repesaje" Then
                    SqlCompras = "SELECT Proveedor.Nombre_Proveedor, Recepcion.* FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor  " & _
                                 "WHERE (Recepcion.NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Recepcion.Fecha BETWEEN CONVERT(DATETIME, '" & Fecha & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Fecha & " 23:59:00', 102)) AND (Recepcion.TipoRecepcion = '" & TipoCompra & "')"

                End If

                DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                DataAdapter.Fill(DataSet, "Recepcion")
                If Not DataSet.Tables("Recepcion").Rows.Count = 0 Then
                    '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                    Me.CboCodigoProveedor.Text = DataSet.Tables("Recepcion").Rows(0)("Cod_Proveedor")
                    Me.CboConductor.Text = DataSet.Tables("Recepcion").Rows(0)("Conductor")
                    Me.txtid.Text = DataSet.Tables("Recepcion").Rows(0)("Id_identificacion")
                    Me.CboPlaca.Text = DataSet.Tables("Recepcion").Rows(0)("Id_Vehiculo")
                    Me.txtobservaciones.Text = DataSet.Tables("Recepcion").Rows(0)("Observaciones")
                    Me.txtsubtotal.Text = TotalRecepcion(Me.TxtNumeroEnsamble.Text, Me.DTPFecha.Text, Me.CboTipoRecepcion.Text)
                    Me.LblHora.Text = Format(DataSet.Tables("Recepcion").Rows(0)("FechaHora"), "hh:mm:ss tt")
                    Me.Timer1.Stop()

                    If DataSet.Tables("Recepcion").Rows(0)("Contabilizado") = "True" Then
                        Me.Button6.Enabled = False
                        Me.Button7.Enabled = False
                        Me.Button10.Enabled = False
                        Me.Button11.Enabled = False
                        Me.BtnProcesar.Enabled = False
                        Me.TrueDBGridComponentes.Enabled = False
                        Me.GroupBox6.Enabled = False
                        Me.GroupBox1.Enabled = False
                        Me.GroupBox2.Enabled = False
                        Me.GroupBox9.Enabled = False
                    ElseIf DataSet.Tables("Recepcion").Rows(0)("Procesado") = "True" Then
                        Me.Button6.Enabled = False
                        Me.Button7.Enabled = False
                        Me.Button10.Enabled = False
                        Me.Button11.Enabled = False
                        Me.BtnProcesar.Enabled = False
                        Me.TrueDBGridComponentes.Enabled = False
                        Me.GroupBox6.Enabled = False
                        Me.GroupBox1.Enabled = False
                        Me.GroupBox2.Enabled = False
                        Me.GroupBox9.Enabled = False
                    Else
                        Me.Button6.Enabled = True
                        Me.Button7.Enabled = True
                        Me.Button10.Enabled = True
                        Me.Button11.Enabled = True
                        Me.BtnProcesar.Enabled = True
                        Me.TrueDBGridComponentes.Enabled = True
                        Me.GroupBox6.Enabled = True
                        Me.GroupBox1.Enabled = True
                        Me.GroupBox2.Enabled = True
                        Me.GroupBox9.Enabled = True
                    End If

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion  WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                    DataAdapter.Fill(DataSet, "DetalleRecepcion")
                    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
                    Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"

                    Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
                    Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Calidad"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
                    Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
                    Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
                    'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75


                End If
            End If



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub BtnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click
        Procesar = True

        Me.CmdFacturar_Click(sender, e)
        Bitacora(Now, NombreUsuario, "Recepcion", "Se Proceso la Recepcion No: " & Me.TxtNumeroEnsamble.Text)
        Me.Button7_Click(sender, e)
    End Sub

    Private Sub CmdFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFacturar.Click
        Dim ComandoUpdate As New SqlClient.SqlCommand
        Dim ConsecutivoCompra As Double, NumeroCompra As String, iPosicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioFOB As Double, PrecioCosto As Double, Cantidad As Double
        Dim PrecioNeto As Double, Importe As Double
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Fecha As String, MontoIva As Double, Sql As String




        ConsecutivoCompra = BuscaConsecutivo("Compra")
        NumeroCompra = Format(ConsecutivoCompra, "0000#")
        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaEncabezadoCompras(NumeroCompra, CDate(Me.DTPFecha.Text), "Mercancia Recibida", Me.CboCodigoProveedor.Text, Me.CboCodigoBodega.Text, Me.txtnombre.Text, "-", CDate(Me.DTPFecha.Text), 0, 0, 0, 0, "Cordobas", "Procesado por Bascula " & Me.TxtNumeroEnsamble.Text, "")


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(Precio) AS Precio, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ  FROM Detalle_Recepcion GROUP BY NumeroRecepcion, TipoRecepcion, Cod_Productos, Descripcion_Producto " & _
              "HAVING (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (TipoRecepcion = 'Recepcion')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")


        Registros = DataSet.Tables("DetalleRecepcion").Rows.Count
        iPosicion = 0

        Do While iPosicion < Registros
            CodigoProducto = DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("Cod_Productos")

            'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            '    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            'End If
            PrecioFOB = 0 'Me.BindingDetalle.Item(iPosicion)("FOB")
            PrecioCosto = 0 'Me.BindingDetalle.Item(iPosicion)("Precio_Costo")
            Descuento = 0
            If Not IsDBNull(DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("PesoNetoKg")) Then
                Cantidad = DataSet.Tables("DetalleRecepcion").Rows(iPosicion)("PesoNetoKg")
                PrecioUnitario = 0 'PrecioCosto / Cantidad
            End If
            PrecioNeto = PrecioUnitario * Cantidad
            Importe = PrecioCosto - Descuento

            GrabaDetalleCompraLiquidacion(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioUnitario, Importe, Cantidad, "Cordobas", CDate(Me.DTPFecha.Text))
            ExistenciasCostos(CodigoProducto, Cantidad, PrecioUnitario, "Mercancia Recibida", Me.CboCodigoBodega.Text)


            iPosicion = iPosicion + 1
        Loop

        MiConexion.Close()

        StrSqlUpdate = "UPDATE [Recepcion] SET [Numero_Compra] = '" & NumeroCompra & "' ,[Tipo_Compra] = 'Mercancia Recibida' ,[Fecha_Compra] = '" & CDate(Me.DTPFecha.Text) & "' ,[Procesado] = 1 WHERE  (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (TipoRecepcion = 'Recepcion')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        MsgBox("Se ha Procesado con la Compra " & NumeroCompra, MsgBoxStyle.Information, "Zeus Facturacion")
    End Sub

    Private Sub CmbTipoPesada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoPesada.SelectedIndexChanged

        Select Case Me.CmbTipoPesada.Text

            Case "PESADA BASCULA"
                Me.Button11.Enabled = True
                Me.Button10.Enabled = True
                Me.CmdPesada.Visible = False

            Case "PESADA MANUAL"
                Me.Button11.Enabled = False
                Me.Button10.Enabled = False
                Me.CmdPesada.Visible = True


        End Select
    End Sub

    Private Sub CboTipoRecepcion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoRecepcion.SelectedIndexChanged

    End Sub

    Private Sub ChkTaraSaco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTaraSaco.CheckedChanged
        Bitacora(Now, NombreUsuario, "Recepcion", "Cambio Calculo de Tara en la Recepcion No: " & Me.TxtNumeroEnsamble.Text)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub C1Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button4.Click
        Quien = "Recolector"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtRecolector.Text = My.Forms.FrmConsultas.Nombre_Recolector
        Me.TxtTelefonoRecolector.Text = My.Forms.FrmConsultas.Telefono_Recolector
        Me.TxtCedulaRecolector.Text = My.Forms.FrmConsultas.Cecula_Recolector
        Me.ListBoxRecolector.Visible = False

    End Sub

    Private Sub TxtRecolector_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRecolector.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ListBoxRecolector.Visible = False
        End If
    End Sub



    Private Sub TxtRecolector_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRecolector.LostFocus
        Me.ListBoxRecolector.Visible = False

    End Sub

    Private Sub TxtRecolector_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRecolector.TextChanged
        Dim SqlString As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        Me.ListBoxRecolector.Visible = True
        Me.ListBoxRecolector.Location = New Point(74, 51)
        SqlString = "SELECT  NombreRecolector As Descripcion, TelefonoRecolector, CedulaRecolector FROM Recepcion WHERE  (NombreRecolector LIKE '%" & Me.TxtRecolector.Text & "%')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consultas")
        Me.ListBoxRecolector.DataSource = DataSet.Tables("Consultas")
        If DataSet.Tables("Consultas").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("Consultas").Rows(0)("TelefonoRecolector")) Then
                Me.TxtTelefonoRecolector.Text = DataSet.Tables("Consultas").Rows(0)("TelefonoRecolector")
            End If

            If Not IsDBNull(DataSet.Tables("Consultas").Rows(0)("CedulaRecolector")) Then
                Me.TxtCedulaRecolector.Text = DataSet.Tables("Consultas").Rows(0)("CedulaRecolector")
            End If
        End If


    End Sub

    Private Sub ListBoxRecolector_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxRecolector.DoubleClick
        Me.TxtRecolector.Text = Me.ListBoxRecolector.Text
        Me.ListBoxRecolector.Visible = False


    End Sub



    Private Sub ListBoxRecolector_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxRecolector.LostFocus
        Me.TxtRecolector.Text = Me.ListBoxRecolector.Text
        Me.ListBoxRecolector.Visible = False
    End Sub


    Private Sub ListBoxRecolector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxRecolector.SelectedIndexChanged

    End Sub

    Private Sub ChkTaraSaco_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkTaraSaco.Click
        If Me.ChkTaraSaco.Checked = True Then
            Me.BtnTara.Visible = False
        Else
            Me.BtnTara.Visible = True
        End If
    End Sub

    Private Sub BtnTara_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTara.Click
        Button10_Click(sender, e)
        My.Forms.FrmTara.ShowDialog()
        Button11_Click(sender, e)
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TrueDBGridComponentes_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TrueDBGridComponentes.ControlAdded

    End Sub
End Class