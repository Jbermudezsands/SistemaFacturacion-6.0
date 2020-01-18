Public Class FrmPlantillas
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoIva As String, CantidadAnterior As Double, PrecioAnterior As Double
    Public DataSetListBox As New DataSet
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub FrmPlantillas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Plantilla Ventas/Compras")
    End Sub

    Private Sub FrmPlantillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy")


        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS VENDEDORES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DataSet.Reset()
        SqlString = "SELECT Cod_Vendedor, Nombre_Vendedor + ' ' + Apellido_Vendedor AS Nombres FROM Vendedores"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Vendedores")
        CboCodigoVendedor.DataSource = DataSet.Tables("Vendedores")
        If Not DataSet.Tables("Vendedores").Rows.Count = 0 Then
            Me.CboCodigoVendedor.Text = DataSet.Tables("Vendedores").Rows(0)("Cod_Vendedor")
        End If
        MiConexion.Close()

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        Me.CboCodigoBodega2.DataSource = DataSet.Tables("Bodegas")
        If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
            Me.CboCodigoBodega2.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"
        Me.CboCodigoBodega2.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega2.Columns(1).Caption = "Nombre Bodega"

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Plantilla.Cantidad, Detalle_Plantilla.Precio_Unitario, Detalle_Plantilla.Descuento,Detalle_Plantilla.Precio_Neto, Detalle_Plantilla.Importe, Detalle_Plantilla.id_Detalle_Plantilla FROM  Detalle_Plantilla INNER JOIN Productos ON Detalle_Plantilla.Cod_Producto = Productos.Cod_Productos  WHERE (Detalle_Plantilla.Numero_Plantilla = N'-1')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleFactura")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFactura")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
        Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Columns(2).Caption = "Cantidad"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
        Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
        Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
        Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////MONEDA FACTURA//////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            Me.TxtMonedaFactura.Text = DataSet.Tables("DatosEmpresa").Rows(0)("MonedaFactura")
            Me.TxtMonedaImprime.Text = DataSet.Tables("DatosEmpresa").Rows(0)("ModedaImprimeFactura")

        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////CREO EL DATASET PARA EL LISTADO DE CLIENTES 77//////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        CrearDataSet()

        Me.LstClientes.Splits.Item(0).DisplayColumns(0).Width = 73
        Me.LstClientes.Splits.Item(0).DisplayColumns(1).Width = 155


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DataSet As New DataSet
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim oDataRow As DataRow
        'Dim Buscar_Fila() As DataRow

        My.Forms.FrmConsultas.Codigo = "-----0-----"

        If Me.CboTipoProducto.Text = "Cotizacion" Then
            Quien = "CodigoCliente"
            My.Forms.FrmConsultas.ShowDialog()
            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
            End If
        ElseIf Me.CboTipoProducto.Text = "Factura" Then
            Quien = "CodigoCliente"
            My.Forms.FrmConsultas.ShowDialog()
            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
            End If
        Else

            Quien = "CodigoProveedor"
            My.Forms.FrmConsultas.ShowDialog()
            If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                Me.TxtCodigoClientes.Text = My.Forms.FrmConsultas.Codigo
            End If
        End If

        'If (DataSetListBox.Tables("PlanillaClientes").Rows.Count <> 0) Then
        '    Buscar_Fila = DataSetListBox.Tables("PlanillaClientes").Select("Cod_Cliente LIKE '" & Me.TxtCodigoClientes.Text & "'")
        '    If Buscar_Fila.Length = 0 Then
        '        MsgBox("Ya Se encuentra en la lista", MsgBoxStyle.Critical, "Zeus Facturacion")
        '        Exit Sub
        '    End If
        'End If

        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            'If DataSet.Tables("PlantillaClientes").Rows.Count = 0 Then
            oDataRow = DataSetListBox.Tables("PlantillaClientes").NewRow
            oDataRow("Cod_Cliente") = Me.TxtCodigoClientes.Text
            oDataRow("Nombre_Cliente") = Me.TxtNombres.Text
            DataSetListBox.Tables("PlantillaClientes").Rows.Add(oDataRow)
            'End If

            'Me.LstClientes.DataSource = DataSetListBox.Tables("PlantillaClientes")
            Me.BindingConsultas.DataSource = DataSetListBox.Tables("PlantillaClientes")
            Me.LstClientes.DataSource = Me.BindingConsultas.DataSource

            Me.LstClientes.Splits.Item(0).DisplayColumns(0).Width = 73
            Me.LstClientes.Splits.Item(0).DisplayColumns(1).Width = 155
        End If
    End Sub
    Private Sub CrearDataSet()
        Dim tablaArbol As DataTable

        DataSetListBox = New DataSet("DataSetArbol")

        tablaArbol = DataSetListBox.Tables.Add("PlantillaClientes")
        tablaArbol.Columns.Add("Cod_Cliente", GetType(String))
        tablaArbol.Columns.Add("Nombre_Cliente", GetType(String))



        'InsertarDataRow("Nodo 1", 1, 0)
        'InsertarDataRow("Nodo 1.1", 2, 1)
        'InsertarDataRow("Nodo 1.1.1", 3, 2)
        'InsertarDataRow("Nodo 1.1.2", 4, 2)
        'InsertarDataRow("Nodo 1.2", 5, 1)

        'InsertarDataRow("Nodo 2", 6, 0)
        'InsertarDataRow("Nodo 2.1", 7, 6)
        'InsertarDataRow("Nodo 2.2", 8, 6)

        'InsertarDataRow("Nodo 3", 9, 0)
        'InsertarDataRow("Nodo 3.1", 10, 9)
        'InsertarDataRow("Nodo 3.2", 11, 9)
    End Sub


    Private Sub InsertarDataRow(ByVal column1 As String, ByVal column2 As String)
        Dim nuevaFila As DataRow

        nuevaFila = DataSetListBox.Tables("TablaArbol").NewRow()

        nuevaFila("Cod_Cliente") = column1
        nuevaFila("Nombre_Cliente") = column2

        DataSetListBox.Tables("TablaArbol").Rows.Add(nuevaFila)
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Quien = "Bodegas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoBodega.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TxtCodigoClientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptTodos.CheckedChanged
        If Me.OptTodos.Checked = True Then
            Me.TxtCodigoClientes.Enabled = False
            Me.TxtNombres.Enabled = False
            Me.TxtApellidos.Enabled = False
            Me.TxtDireccion.Enabled = False
            Me.TxtTelefono.Enabled = False
            Me.Button1.Enabled = False

            Me.TxtCodigoClientes.Text = ""
            Me.TxtNombres.Text = ""
            Me.TxtApellidos.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
        Else
            Me.Button1.Enabled = True
            Me.TxtCodigoClientes.Enabled = True
            Me.TxtNombres.Enabled = True
            Me.TxtApellidos.Enabled = True
            Me.TxtDireccion.Enabled = True
            Me.TxtTelefono.Enabled = True



        End If
    End Sub

    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProducto As String, SqlString As String

        Try




            Select Case Me.TrueDBGridComponentes.Col

                Case 0
                    If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
                        Exit Sub
                    Else
                        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                        SqlString = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Productos")
                        If DataSet.Tables("Productos").Rows.Count <> 0 Then
                            Me.TrueDBGridComponentes.Columns(1).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                            Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(0)("Costo_Promedio")

                        Else
                            MsgBox("Este Producto no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Quien = "CodigoProductosDetalle"
                            My.Forms.FrmConsultas.ShowDialog()
                            Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
                            Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
                            Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio

                        End If
                    End If

                    If Acceso <> "Administrador" Then
                        If Me.CboTipoProducto.Text = "Cotizacion" Then
                            Me.GroupBox3.Enabled = False
                            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                        Else

                            Me.GroupBox3.Enabled = True
                            Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True

                        End If
                    End If

            End Select

            ActualizaMETODOPlantilla()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterDelete
        ActualizaMETODOPlantilla()
    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlProveedor As String, CodProducto As String
        Dim ConsecutivoFactura As Double, NumeroFactura As String
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double


        Try



            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Tiene que Seleccionar el Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub

            End If



            If Me.CboCodigoBodega.Text = "" Then
                MsgBox("Es necesario que seleccione el tipo de Factura", MsgBoxStyle.Critical, "Sistema Facturacion")
                Exit Sub
            End If

            If Me.OptSeleccionado.Checked = True Then
                If Me.TxtCodigoClientes.Text = "" Then
                    Exit Sub
                Else
                    SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Clientes")
                    If DataSet.Tables("Clientes").Rows.Count = 0 Then
                        Exit Sub
                    End If
                End If
            End If


            If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
                Exit Sub
            Else
                CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                If DataSet.Tables("Productos").Rows.Count = 0 Then
                    Exit Sub
                End If
            End If



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                'Select Case Me.CboTipoProducto.Text
                'Case "Plantilla"
                ConsecutivoFactura = BuscaConsecutivo("Plantilla")
                'End Select
            Else
                ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            End If

            NumeroFactura = Format(ConsecutivoFactura, "0000#")


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            GrabaPlantillas(NumeroFactura)

            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                Quien = "NumeroFacturas"
                Me.TxtNumeroEnsamble.Text = NumeroFactura
            End If




            Me.Button7.Enabled = True
            Me.CboCodigoBodega.Enabled = True


            CodigoProducto = 0
            PrecioUnitario = 0
            Descuento = 0
            PrecioNeto = 0
            Importe = 0
            Cantidad = 0

            Me.TrueDBGridComponentes.Col = 0

            If Acceso <> "Administrador" Then
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////BLOQUEO LOS PRECIOS DESPUES DE ACTUALIZAR////////////////////////////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If Me.CboTipoProducto.Text = "Cotizacion" Then
                    Me.GroupBox3.Enabled = False
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                Else

                    Me.GroupBox3.Enabled = True
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True

                End If
            End If

            ActualizaMETODOPlantilla()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
        Dim Cols As Double, iPosicion As Double

        Try


            Cols = e.ColIndex
            Select Case Cols
                Case 2
                    If Not IsNumeric(Me.TrueDBGridComponentes.Columns(2).Text) Then
                        Me.TrueDBGridComponentes.Columns(2).Text = 0
                    End If

                    If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                        iPosicion = Me.BindingDetalle.Position
                        CantidadAnterior = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                    Else
                        CantidadAnterior = 0
                    End If
                Case 3
                    If Not IsNumeric(Me.TrueDBGridComponentes.Columns(3).Text) Then
                        Me.TrueDBGridComponentes.Columns(3).Text = 0
                    End If


                    If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
                        iPosicion = Me.BindingDetalle.Position
                        PrecioAnterior = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                    Else
                        PrecioAnterior = 0
                    End If
            End Select

            ActualizaMETODOPlantilla()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim Cols As Double, Precio As Double, Cantidad As Double, Descuento As Double, SubTotal As Double, Neto As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Tasa As Double, SqlProveedor As String
        Dim CodProducto As String, Sql As String, RespuestaIVA As String = "Sumando IVA del Producto", CodImpuesto As String = "", TasaImpuesto As Double
        Dim TipoProducto As String = "Productos", TipoDescuento As String = "ImporteFijo"
        Dim PrecioDescDolar As Double, PrecioDescCordobas As Double, PorcientoDescuento As Double

        Try


            Cols = e.ColIndex



            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////BUSCO LA CONFIGURACION DEL PRECIO///////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Sql = "SELECT  * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If DataSet.Tables("DatosEmpresa").Rows.Count <> 0 Then
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("IvaProducto")) Then
                    RespuestaIVA = DataSet.Tables("DatosEmpresa").Rows(0)("IvaProducto")
                End If
            End If

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////BUSCO EL CODIGO DEL IMPUESTO PARA EL PRODUCTO///////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If DataSet.Tables("Productos").Rows.Count <> 0 Then
                CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                TipoProducto = DataSet.Tables("Productos").Rows(0)("Tipo_Producto")
                TipoDescuento = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")
                PrecioDescCordobas = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                PrecioDescDolar = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
            End If



            Descuento = 0
            Tasa = 0

            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
            DataSet.Reset()
            Select Case Cols
                Case 0

                    CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                    SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Productos")
                    If DataSet.Tables("Productos").Rows.Count = 0 Then
                        MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                        Exit Sub
                    Else
                        CodImpuesto = DataSet.Tables("Productos").Rows(0)("Cod_Iva")
                        Me.TrueDBGridComponentes.Columns(1).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                        Me.TrueDBGridComponentes.Columns(3).Text = DataSet.Tables("Productos").Rows(0)("Ultimo_Precio_Compra")
                    End If
                    DataSet.Tables("Productos").Clear()


                Case 1
                    If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                        Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                    End If

                Case 2
                    If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                        Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                    End If
                Case 3
                    If Me.TrueDBGridComponentes.Columns(4).Text <> "" Then
                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns(4).Text) / 100)
                    End If
                    If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                        Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                    End If
                Case 4

                    If Me.TrueDBGridComponentes.Columns(4).Text <> "" Then
                        Descuento = (CDbl(Me.TrueDBGridComponentes.Columns(4).Text) / 100)
                    End If
                    If Me.TrueDBGridComponentes.Columns(2).Text <> "" Then
                        Cantidad = Me.TrueDBGridComponentes.Columns(2).Text
                    End If



            End Select



            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////BUSCO EL PORCENTAJE DEL IMPUESTO////////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Sql = "SELECT  * FROM Impuestos WHERE (Cod_Iva = '" & CodImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto")
            If DataSet.Tables("Impuesto").Rows.Count <> 0 Then
                TasaImpuesto = DataSet.Tables("Impuesto").Rows(0)("Impuesto")
            Else
                TasaImpuesto = 0
            End If




            If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
                If RespuestaIVA = "Sumando IVA del Producto" Then
                    Precio = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
                Else
                    If Me.OptExsonerado.Checked = False Then
                        Precio = CDbl(Me.TrueDBGridComponentes.Columns(3).Text) / (1 + TasaImpuesto)
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.00")
                    Else
                        Precio = CDbl(Me.TrueDBGridComponentes.Columns(3).Text)
                    End If
                End If
            Else
                Precio = 0
            End If


            '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
            Select Case TipoDescuento
                Case "ImporteFijo"
                    Me.TrueDBGridComponentes.Columns(2).Text = 1
                    Cantidad = 1
                    Me.TrueDBGridComponentes.Columns(4).Text = ""
                    If Me.TxtMonedaFactura.Text = "Cordobas" Then
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescCordobas, "##,##0.00")
                        Precio = PrecioDescCordobas
                    Else
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescDolar, "##,##0.00")
                        Precio = PrecioDescDolar
                    End If

                Case "SubTotal"
                    Me.TrueDBGridComponentes.Columns(2).Text = 1
                    Cantidad = 1
                    Me.TrueDBGridComponentes.Columns(4).Text = ""
                    If Val(Me.TxtSubTotal.Text) <> 0 Then
                        SubTotal = Me.TxtSubTotal.Text
                    End If
                    If PrecioDescCordobas <> 0 Then
                        PorcientoDescuento = (PrecioDescCordobas / 100)
                    End If
                    Precio = SubTotal * PorcientoDescuento
                    Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.00")


            End Select

            SubTotal = Cantidad * Precio
            Neto = SubTotal * (1 - Descuento)

            Select Case TipoProducto
                Case "Productos"
                    SubTotal = Cantidad * Precio
                    Neto = SubTotal * (1 - Descuento)
                Case "Descuento"
                    Neto = Math.Abs(Cantidad * Precio) * -1

            End Select

            Me.TrueDBGridComponentes.Columns(5).Text = Format(Precio * (1 - Descuento), "##,##0.00")
            Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.00")


            If Me.OptSeleccionado.Checked = True Then
                If Me.TxtCodigoClientes.Text = "" Then
                    MsgBox("Es necesario que seleccione un Cliente", MsgBoxStyle.Critical, "Sistema Facturacion")
                    Me.TrueDBGridComponentes.Enabled = False
                    Exit Sub
                Else

                    SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Clientes")
                    If DataSet.Tables("Clientes").Rows.Count = 0 Then
                        MsgBox("El Codigo del Cliente no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                        Me.TrueDBGridComponentes.Enabled = False
                        Exit Sub
                    End If
                End If
            End If


            If Me.TrueDBGridComponentes.Columns(0).Text = "" Then
                MsgBox("Necesita Seleccionar un producto", MsgBoxStyle.Critical, "Sistema Facturacion")
                Exit Sub
            Else

                CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                If DataSet.Tables("Productos").Rows.Count = 0 Then
                    MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                    Exit Sub
                End If
            End If


            ActualizaMETODOPlantilla()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeDelete
        Dim SQlString As String, iPosicion As Double, TipoFactura As String, Fecha As String
        Dim Descripcion_Producto As String, CodigoProducto As String, NumeroFactura As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, IdDetalle As Double

        Try



            iPosicion = Me.BindingDetalle.Position

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")) Then
                IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Factura")
            Else
                IdDetalle = -1
            End If

            Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
            TipoFactura = Me.CboTipoProducto.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            NumeroFactura = Me.TxtNumeroEnsamble.Text


            MiConexion.Close()
            If IdDetalle = -1 Then
                SQlString = "DELETE FROM  Detalle_Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "') AND (Cod_Producto = '" & CodigoProducto & "') AND (Descripcion_Producto = '" & Descripcion_Producto & "')"
            Else
                SQlString = "DELETE FROM  Detalle_Facturas WHERE (Numero_Factura = '" & NumeroFactura & "') AND (Fecha_Factura = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Factura = '" & TipoFactura & "') AND (Cod_Producto = '" & CodigoProducto & "') AND (Descripcion_Producto = '" & Descripcion_Producto & "') AND (id_Detalle_Factura = " & IdDetalle & ")"
            End If
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlString, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            ActualizaMETODOPlantilla()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlProveedor As String
        Dim CodProducto As String, TipoProducto As String = "Servicio", TipoDescuento As String = "ImporteFijo", PrecioDescCordobas As Double, PrecioDescDolar As Double
        Dim Cantidad As Double, Precio As Double, SubTotal As Double, PorcientoDescuento As Double, Neto As Double

        Try

            If Me.TxtMonedaFactura.Text = "Dolares" Then
                Quien = "CodigoProductosFacturaPlantilla"
            Else
                Quien = "CodigoProductosCordobasPlantilla"
            End If
            My.Forms.FrmConsultas.ShowDialog()
            Me.TrueDBGridComponentes.Columns(0).Text = My.Forms.FrmConsultas.Codigo
            Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Descripcion
            Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Precio
            Me.TrueDBGridComponentes.Col = 2

            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////BUSCO EL CODIGO PARA EL PRODUCTO///////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            CodProducto = My.Forms.FrmConsultas.Codigo
            SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Productos")
            If DataSet.Tables("Productos").Rows.Count <> 0 Then
                TipoProducto = DataSet.Tables("Productos").Rows(0)("Tipo_Producto")
                TipoDescuento = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")
                PrecioDescCordobas = DataSet.Tables("Productos").Rows(0)("Precio_Venta")
                PrecioDescDolar = DataSet.Tables("Productos").Rows(0)("Precio_Lista")
            End If

            '///////////////////////////////////////DEFINO EL TIPO DE SERVICIO O DESCUENTO ////////////////////////////////////////////
            Select Case TipoDescuento
                Case "ImporteFijo"
                    Me.TrueDBGridComponentes.Columns(2).Text = 1
                    Cantidad = 1
                    Me.TrueDBGridComponentes.Columns(4).Text = ""
                    If Me.TxtMonedaFactura.Text = "Cordobas" Then
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescCordobas, "##,##0.00")
                        Precio = PrecioDescCordobas
                    Else
                        Me.TrueDBGridComponentes.Columns(3).Text = Format(PrecioDescDolar, "##,##0.00")
                        Precio = PrecioDescDolar
                    End If

                Case "SubTotal"
                    Me.TrueDBGridComponentes.Columns(2).Text = 1
                    Cantidad = 1
                    Me.TrueDBGridComponentes.Columns(4).Text = ""
                    If Val(Me.TxtSubTotal.Text) <> 0 Then
                        SubTotal = Me.TxtSubTotal.Text
                    End If
                    If PrecioDescCordobas <> 0 Then
                        PorcientoDescuento = (PrecioDescCordobas / 100)
                    End If
                    Precio = SubTotal * PorcientoDescuento
                    Me.TrueDBGridComponentes.Columns(3).Text = Format(Precio, "##,##0.00")


            End Select



            Select Case TipoProducto
                Case "Servicio"
                    SubTotal = Cantidad * Precio
                    Neto = SubTotal
                    Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                    Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.00")
                Case "Descuento"
                    Neto = Math.Abs(Cantidad * Precio) * -1
                    Me.TrueDBGridComponentes.Columns(5).Text = Format(Cantidad * Precio, "##,##0.00")
                    Me.TrueDBGridComponentes.Columns(6).Text = Format(Neto, "##,##0.00")

            End Select




            If Acceso <> "Administrador" Then
                If Me.CboTipoProducto.Text = "Cotizacion" Then
                    Me.GroupBox3.Enabled = False
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                Else

                    Me.GroupBox3.Enabled = True
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True

                End If
            End If

            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = False




        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim ConsecutivoFactura As Double, iPosicion As Double, Registros As Double, NumeroFactura As String
        Dim Monto As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim DiferenciaCantidad As Double, DiferenciaPrecio As Double, Descripcion_Producto As String, IdDetalle As Double = -1
        Dim CodigoCliente As String, NombreCliente As String

        Try



            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                ConsecutivoFactura = BuscaConsecutivo("Plantilla")
            Else
                ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            End If

            NumeroFactura = Format(ConsecutivoFactura, "0000#")



            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////
            GrabaPlantillas(NumeroFactura)


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO LOS CLIENTES /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////
            Registros = Me.DataSetListBox.Tables("PlantillaClientes").Rows.Count
            iPosicion = 0
            Monto = 0
            Do While iPosicion < Registros
                CodigoCliente = DataSetListBox.Tables("PlantillaClientes").Rows(iPosicion)("Cod_Cliente")
                NombreCliente = DataSetListBox.Tables("PlantillaClientes").Rows(iPosicion)("Nombre_Cliente")
                GrabaPlantillaClientes(NumeroFactura, Format(Me.DTPFecha.Value, "dd/MM/yyyy"), Me.CboTipoProducto.Text, CodigoCliente, NombreCliente)

                iPosicion = iPosicion + 1
            Loop

            Me.DataSetListBox.Tables.Clear()


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL DETALLE DE LA FACTURA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


            Registros = Me.BindingDetalle.Count
            'iPosicion = Me.BindingDetalle.Position

            'Me.BindingDetalle.MoveFirst()
            Registros = Me.BindingDetalle.Count
            iPosicion = 0
            Monto = 0
            Do While iPosicion < Registros

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Plantilla")) Then
                    IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Plantilla")
                Else
                    IdDetalle = -1
                End If

                CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")

                PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                End If
                PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")

                '/////////////////////////////////GRABO EL DETALLE///////////////////////////////////////////////////////////////////////////
                GrabaDetallePlantilla(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle)

                Select Case Me.CboTipoProducto.Text
                    Case "Factura"
                        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
                        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    Case "Devolucion de Venta"
                        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                End Select

                iPosicion = iPosicion + 1
            Loop


            ActualizaMETODOPlantilla()

            MsgBox("Se ha grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema Facturacion")
            LimpiarPlantillas()
            'Me.Button7.Enabled = True
            'Me.CboCodigoBodega.Enabled = True

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, Resultado As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Factura?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")


        MiConexion.Close()
        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////BORRA EL ENCABEZADO DE LA PLANILLA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "DELETE FROM [Plantilla] WHERE  (NumeroPlantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Plantilla = '" & Me.CboTipoProducto.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////BORRA EL DETALLE DE LA PLANILLA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        SqlCompras = "DELETE FROM [Detalle_Plantilla] WHERE (Numero_Plantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Plantilla = '" & Me.CboTipoProducto.Text & "') "
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        LimpiarPlantillas()
        'Me.Button7.Enabled = True
        'Me.CboCodigoBodega.Enabled = True
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "Plantillas"
        My.Forms.FrmConsultas.ShowDialog()


        Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
        Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoCompra
        Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo
        Me.CboCodigoBodega.Enabled = False
        Me.Button7.Enabled = False
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, TipoFactura As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        If Quien = "NumeroFacturas" Then
            Exit Sub
        End If


        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then

            'Me.LstClientes.Items.Clear()
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE LOS CLIENTES/////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Me.LstClientes.ClearItems()
            DataSetListBox.Tables("PlantillaClientes").Clear()
            SqlCompras = "SELECT  Cod_Cliente, Nombre_Cliente FROM PlantillaClientes WHERE (NumeroPlantilla = '-1000') AND (FechaPlantilla = '" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "') AND (Tipo_Plantilla = 'Factura') ORDER BY Cod_Cliente"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSetListBox, "PlantillaClientes")
            Me.LstClientes.DataSource = DataSetListBox.Tables("PlantillaClientes")
            Me.LstClientes.Splits.Item(0).DisplayColumns(0).Width = 73
            Me.LstClientes.Splits.Item(0).DisplayColumns(1).Width = 155

            TipoFactura = Me.CboTipoProducto.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            SqlCompras = "SELECT  * FROM Plantilla WHERE (NumeroPlantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Plantilla = '" & TipoFactura & "')  AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "Facturas")
            If Not DataSet.Tables("Facturas").Rows.Count = 0 Then
                '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Cod_Vendedor")) Then
                    Me.CboCodigoVendedor.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Vendedor")
                End If
                Me.TxtCodigoClientes.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Cliente")
                Me.TxtNombres.Text = DataSet.Tables("Facturas").Rows(0)("Nombre_Plantilla")
                Me.TxtMonedaFactura.Text = DataSet.Tables("Facturas").Rows(0)("MonedaPlantilla")
                'If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Cod_Cliente2")) Then
                '    Me.TxtCodigoClientes2.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Cliente2")
                'End If
                'If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Nombre_Plantilla2")) Then
                '    Me.TxtNombres2.Text = DataSet.Tables("Facturas").Rows(0)("Nombre_Plantilla2")
                'End If
                'Me.TxtApellidos.Text = DataSet.Tables("Facturas").Rows(0)("Apellido_Plantilla")
                Me.TxtDireccion.Text = DataSet.Tables("Facturas").Rows(0)("Direccion_Plantilla")
                Me.TxtTelefono.Text = DataSet.Tables("Facturas").Rows(0)("Telefono_Plantilla")
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Referencia_Plantilla")) Then
                    Me.TxtReferencia.Text = DataSet.Tables("Facturas").Rows(0)("Referencia_Plantilla")
                End If
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Seleccion_Cliente")) Then
                    If DataSet.Tables("Facturas").Rows(0)("Seleccion_Cliente") = "Todos" Then
                        Me.OptTodos.Checked = True
                    Else
                        Me.OptSeleccionado.Checked = True
                    End If
                End If

                '////////////////////////VENCIMIENTO DE LA FACTURA/////////////////////////////
                Me.TxtDiasVencimiento.Value = DataSet.Tables("Facturas").Rows(0)("Dias_Vencimiento")
                If Not IsDBNull(DataSet.Tables("Facturas").Rows(0)("Observaciones")) Then
                    Me.TxtObservaciones.Text = DataSet.Tables("Facturas").Rows(0)("Observaciones")
                End If
                Me.TxtSubTotal.Text = DataSet.Tables("Facturas").Rows(0)("SubTotal")
                Me.TxtIva.Text = DataSet.Tables("Facturas").Rows(0)("IVA")
                Me.TxtPagado.Text = DataSet.Tables("Facturas").Rows(0)("Pagado")
                Me.TxtNetoPagar.Text = DataSet.Tables("Facturas").Rows(0)("NetoPagar")
                Me.CboCodigoBodega.Text = DataSet.Tables("Facturas").Rows(0)("Cod_Bodega")


                '///////////////////////////////////////BUSCO EL DETALLE DE LA FACTURA///////////////////////////////////////////////////////
                SqlCompras = "SELECT Productos.Cod_Productos, Detalle_Plantilla.Descripcion_Producto, Detalle_Plantilla.Cantidad, Detalle_Plantilla.Precio_Unitario,Detalle_Plantilla.Descuento, Detalle_Plantilla.Precio_Neto, Detalle_Plantilla.Importe, Detalle_Plantilla.id_Detalle_Plantilla FROM Detalle_Plantilla INNER JOIN Productos ON Detalle_Plantilla.Cod_Producto = Productos.Cod_Productos " & _
                             "WHERE (Detalle_Plantilla.Numero_Plantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Plantilla.Fecha_Plantilla = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Detalle_Plantilla.Tipo_Plantilla = '" & TipoFactura & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                DataAdapter.Fill(DataSet, "DetalleFacturas")
                Me.BindingDetalle.DataSource = DataSet.Tables("DetalleFacturas")
                Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 74
                Me.TrueDBGridComponentes.Columns(1).Caption = "Descripcion"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 259
                'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
                Me.TrueDBGridComponentes.Columns(2).Caption = "Cantidad"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 64
                Me.TrueDBGridComponentes.Columns(3).Caption = "Precio Unit"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = False
                Me.TrueDBGridComponentes.Columns(4).Caption = "%Desc"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 43
                Me.TrueDBGridComponentes.Columns(5).Caption = "Precio Neto"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 65
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
                Me.TrueDBGridComponentes.Columns(6).Caption = "Importe"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 61
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Visible = False


                'DataSetListBox()
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////////////CARGO EL DETALLE LOS CLIENTES/////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlCompras = "SELECT  Cod_Cliente, Nombre_Cliente FROM PlantillaClientes WHERE (NumeroPlantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (FechaPlantilla = '" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "') AND (Tipo_Plantilla = '" & TipoFactura & "') ORDER BY Cod_Cliente"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                DataAdapter.Fill(DataSetListBox, "PlantillaClientes")
                Me.LstClientes.DataSource = DataSetListBox.Tables("PlantillaClientes")
                Me.LstClientes.Splits.Item(0).DisplayColumns(0).Width = 73
                Me.LstClientes.Splits.Item(0).DisplayColumns(1).Width = 155

            End If

            ActualizaMETODOPlantilla()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String, iPosicion As Double, Registros As Double
        Dim ArepPlantillas As New ArepPlantillas, SqlDatos As String, SQlDetalle As String, Fecha As String, Monto As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, TasaCambio As Double
        Dim ConsecutivoFactura As Double, NumeroFactura As String, MonedaImprime As String, MonedaFactura As String
        Dim ArepCotizacionFoto As New ArepCotizacionFoto, IdDetalle As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim DiferenciaCantidad As Double, DiferenciaPrecio As Double, Descripcion_Producto As String


        Try

            If Me.CboTipoProducto.Text = "" Then
                MsgBox("Seleccione un Tipo", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If


            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                ConsecutivoFactura = BuscaConsecutivo("Plantilla")
            Else
                ConsecutivoFactura = Me.TxtNumeroEnsamble.Text
            End If
            NumeroFactura = Format(ConsecutivoFactura, "0000#")




            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL ENCABEZADO DE LA PLANTILLA   /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
            GrabaPlantillas(NumeroFactura)

            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////GRABO EL DETALLE DE LA PLANTILLA /////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////7


            Registros = Me.BindingDetalle.Count
            'iPosicion = Me.BindingDetalle.Position

            'Me.BindingDetalle.MoveFirst()
            Registros = Me.BindingDetalle.Count
            iPosicion = 0
            Monto = 0
            Do While iPosicion < Registros

                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Plantilla")) Then
                    IdDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Plantilla")
                Else
                    IdDetalle = -1
                End If

                CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")

                PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
                If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
                    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
                End If
                PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
                Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                Descripcion_Producto = Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto")
                GrabaDetallePlantilla(NumeroFactura, CodigoProducto, Descripcion_Producto, PrecioUnitario, Descuento, PrecioNeto, Importe, Cantidad, IdDetalle)

                Select Case Me.CboTipoProducto.Text
                    Case "Factura"
                        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        DiferenciaPrecio = CDbl(PrecioAnterior) - CDbl(PrecioNeto)
                        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                    Case "Devolucion de Venta"
                        DiferenciaCantidad = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        DiferenciaPrecio = CDbl(Cantidad) - CDbl(CantidadAnterior)
                        ExistenciasCostos(CodigoProducto, DiferenciaCantidad, PrecioNeto, Me.CboTipoProducto.Text, Me.CboCodigoBodega.Text)
                End Select

                iPosicion = iPosicion + 1
            Loop

            ActualizaMETODOPlantilla()

            SqlDatos = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")

            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

                ArepPlantillas.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                ArepPlantillas.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")



                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                    ArepPlantillas.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")

                End If
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                    RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                    If Dir(RutaLogo) <> "" Then
                        ArepPlantillas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)

                    End If

                End If
            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ArepPlantillas.LblVendedor.Text = Me.CboCodigoVendedor.Columns(1).Text
            ArepPlantillas.Label1.Text = "Cliente"
            ArepPlantillas.LblNotas.Text = Me.TxtObservaciones.Text
            ArepPlantillas.LblOrden.Text = Me.TxtNumeroEnsamble.Text
            ArepPlantillas.LblFechaOrden.Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
            ArepPlantillas.LblTipoCompra.Text = "PLANTILLAS DE " & Me.CboTipoProducto.Text
            ArepPlantillas.LblCodProveedor.Text = Me.TxtCodigoClientes.Text
            ArepPlantillas.LblNombres.Text = Me.TxtNombres.Text
            ArepPlantillas.LblApellidos.Text = Me.TxtApellidos.Text
            ArepPlantillas.LblDireccionProveedor.Text = Me.TxtDireccion.Text
            ArepPlantillas.LblTelefono.Text = Me.TxtTelefono.Text
            ArepPlantillas.LblFechaVence.Text = Me.TxtDiasVencimiento.Value
            ArepPlantillas.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            If Me.OptTodos.Checked = True Then
                ArepPlantillas.LblCodProveedor.Text = "Todos los Clientes"
            End If

            MonedaFactura = Me.TxtMonedaFactura.Text
            MonedaImprime = Me.TxtMonedaImprime.Text
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    TasaCambio = 1
                Else
                    TasaCambio = (1 / BuscaTasaCambio(Me.DTPFecha.Value))
                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Cordobas" Then
                    TasaCambio = BuscaTasaCambio(Me.DTPFecha.Value)
                Else
                    TasaCambio = 1
                End If
            End If

            ArepPlantillas.LblSubTotal.Text = Format(CDbl(Val(Me.TxtSubTotal.Text)) * TasaCambio, "##,##0.00")
            ArepPlantillas.LblIva.Text = Format(CDbl(Val(Me.TxtIva.Text)) * TasaCambio, "##,##0.00")
            ArepPlantillas.LblPagado.Text = Format(CDbl(Val(Me.TxtPagado.Text)) * TasaCambio, "##,##0.00")
            ArepPlantillas.LblTotal.Text = Format(CDbl(Val(Me.TxtNetoPagar.Text)) * TasaCambio, "##,##0.00")
            ArepPlantillas.LblDescuento.Text = Format(CDbl(Val(Me.TxtDescuento.Text)) * TasaCambio, "##,##0.00")



            SQlDetalle = ""

            If MonedaFactura = "Cordobas" Then
                If MonedaImprime = "Cordobas" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////

                    SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Plantilla.Cantidad, Detalle_Plantilla.Precio_Unitario, Detalle_Plantilla.Descuento,Detalle_Plantilla.Precio_Neto, Detalle_Plantilla.Importe, Detalle_Plantilla.id_Detalle_Plantilla FROM  Detalle_Plantilla INNER JOIN Productos ON Detalle_Plantilla.Cod_Producto = Productos.Cod_Productos " & _
                                 "WHERE (Numero_Plantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Plantilla = '" & Me.CboTipoProducto.Text & "') "

 
                ElseIf MonedaImprime = "Dolares" Then
                    SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Plantilla.Cantidad, Detalle_Plantilla.Precio_Unitario* " & (1 / TasaCambio) & " AS Precio_Unitario, Detalle_Plantilla.Descuento* " & (1 / TasaCambio) & " AS Descuento,Detalle_Plantilla.Precio_Neto* " & (1 / TasaCambio) & " AS Precio_Neto, Detalle_Plantilla.Importe* " & (1 / TasaCambio) & " AS Importe, Detalle_Plantilla.id_Detalle_Plantilla FROM  Detalle_Plantilla INNER JOIN Productos ON Detalle_Plantilla.Cod_Producto = Productos.Cod_Productos " & _
                                 "WHERE (Numero_Plantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Plantilla = '" & Me.CboTipoProducto.Text & "') "

                End If
            ElseIf MonedaFactura = "Dolares" Then
                If MonedaImprime = "Dolares" Then
                    '///////////////////////////////////////BUSCO EL DETALLE DE LA COMPRA///////////////////////////////////////////////////////

                    SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Plantilla.Cantidad, Detalle_Plantilla.Precio_Unitario, Detalle_Plantilla.Descuento,Detalle_Plantilla.Precio_Neto, Detalle_Plantilla.Importe, Detalle_Plantilla.id_Detalle_Plantilla FROM  Detalle_Plantilla INNER JOIN Productos ON Detalle_Plantilla.Cod_Producto = Productos.Cod_Productos " & _
                                 "WHERE (Numero_Plantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Plantilla = '" & Me.CboTipoProducto.Text & "') "
                ElseIf MonedaImprime = "Cordobas" Then
                    SQlDetalle = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Plantilla.Cantidad, Detalle_Plantilla.Precio_Unitario* " & TasaCambio & " AS Precio_Unitario, Detalle_Plantilla.Descuento* " & TasaCambio & " AS Descuento,Detalle_Plantilla.Precio_Neto* " & TasaCambio & " AS Precio_Neto, Detalle_Plantilla.Importe* " & TasaCambio & " AS Importe, Detalle_Plantilla.id_Detalle_Plantilla FROM  Detalle_Plantilla INNER JOIN Productos ON Detalle_Plantilla.Cod_Producto = Productos.Cod_Productos " & _
                                 "WHERE (Numero_Plantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Tipo_Plantilla = '" & Me.CboTipoProducto.Text & "') "

                End If
            End If


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////VERIFICO QUE TIPO DE IMPRESION ESTA CONFIGURADA/////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            SQL.ConnectionString = Conexion
            SQL.SQL = SQlDetalle
            ArepPlantillas.DataSource = SQL
            ArepPlantillas.Document.Name = "Reporte de " & Me.CboTipoProducto.Text

            Dim ViewerForm As New FrmViewer()
            ViewerForm.arvMain.Document = ArepPlantillas.Document
            ViewerForm.Show()
            ArepPlantillas.Run(True)
            'ArepFacturas.Run(False)
            'ArepFacturas.Show()


            LimpiarPlantillas()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProcesar.Click
        Dim SqlString As String = ""
        Dim DataSetClientes As New DataSet, DataAdapterClientes As New SqlClient.SqlDataAdapter
        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            If Me.OptTodos.Checked = True Then
                SqlString = "SELECT *  FROM Clientes"
                DataAdapterClientes = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapterClientes.Fill(DataSetClientes, "Clientes")
                My.Forms.FrmProcesarPlantilla.BindingClientes.DataSource = DataSetClientes.Tables("Clientes")
            Else
                SqlString = "SELECT  *  FROM PlantillaClientes WHERE (NumeroPlantilla = '" & Me.TxtNumeroEnsamble.Text & " ')"
                DataAdapterClientes = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapterClientes.Fill(DataSetClientes, "Clientes")
                My.Forms.FrmProcesarPlantilla.BindingClientes.DataSource = DataSetClientes.Tables("Clientes")
            End If
            My.Forms.FrmProcesarPlantilla.Text = "Procesando Plantilla No: " & Me.TxtNumeroEnsamble.Text
            My.Forms.FrmProcesarPlantilla.ShowDialog()
        Else
            MsgBox("Seleccione una Plantilla para procesarla", MsgBoxStyle.Critical, "Zeus Facturacion")
        End If


    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OptSeleccionado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptSeleccionado.CheckedChanged

    End Sub

    Private Sub OptExsonerado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptExsonerado.CheckedChanged
        ActualizaMETODOPlantilla()
    End Sub

    Private Sub TxtCodigoClientes_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoClientes.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Try

            Select Case Me.CboTipoProducto.Text
                Case "Cotizacion"
                    SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Clientes")
                    If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
                        Me.TxtNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")
                        If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                            'Me.TxtApellidos.Text = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                            Me.TxtNombres.Text = Me.TxtNombres.Text & " " & DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                        End If
                        'If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                        '    Me.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
                        'End If
                        'If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                        '    Me.TxtTelefono.Text = DataSet.Tables("Clientes").Rows(0)("Telefono")
                        'End If
                        Me.TrueDBGridComponentes.Enabled = True
                    End If

                Case "Factura"
                    SqlProveedor = "SELECT  * FROM Clientes  WHERE (Cod_Cliente = '" & Me.TxtCodigoClientes.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Clientes")
                    If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
                        Me.TxtNombres.Text = DataSet.Tables("Clientes").Rows(0)("Nombre_Cliente")
                        If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")) Then
                            'Me.TxtApellidos.Text = DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                            Me.TxtNombres.Text = Me.TxtNombres.Text & " " & DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                        End If
                        'If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")) Then
                        '    Me.TxtDireccion.Text = DataSet.Tables("Clientes").Rows(0)("Direccion_Cliente")
                        'End If
                        'If Not IsDBNull(DataSet.Tables("Clientes").Rows(0)("Telefono")) Then
                        '    Me.TxtTelefono.Text = DataSet.Tables("Clientes").Rows(0)("Telefono")
                        'End If
                        Me.TrueDBGridComponentes.Enabled = True
                    End If

                Case "Orden de Compra"
                    SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoClientes.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Proveedor")
                    If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
                        Me.TxtNombres.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
                        If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                            'Me.TxtApellidos.Text = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                            Me.TxtNombres.Text = Me.TxtNombres.Text & " " & DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                        End If
                        'Me.TxtDireccion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
                        'Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono")
                        Me.TrueDBGridComponentes.Enabled = True
                    End If
                Case "Compras"
                    SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoClientes.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Proveedor")
                    If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
                        Me.TxtNombres.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
                        If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                            'Me.TxtApellidos.Text = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                            Me.TxtNombres.Text = Me.TxtNombres.Text & " " & DataSet.Tables("Clientes").Rows(0)("Apellido_Cliente")
                        End If
                        'Me.TxtDireccion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
                        'Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono")
                        Me.TrueDBGridComponentes.Enabled = True
                    End If

                Case Else
                    Me.TxtNombres.Text = ""
                    Me.TxtApellidos.Text = ""
                    Me.TxtDireccion.Text = ""
                    Me.TxtTelefono.Text = ""
                    Me.TrueDBGridComponentes.Enabled = False

            End Select





        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Posicion As Integer, SqlString As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, CodigoCliente As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, TipoFactura As String

        TipoFactura = Me.CboTipoProducto.Text

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE LOS CLIENTES/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  Cod_Cliente, Nombre_Cliente FROM PlantillaClientes WHERE (NumeroPlantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (FechaPlantilla = '" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "') AND (Tipo_Plantilla = '" & TipoFactura & "') ORDER BY Cod_Cliente"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSetListBox, "PlantillaClientes")
        Me.LstClientes.DataSource = DataSetListBox.Tables("PlantillaClientes")
        Me.LstClientes.Splits.Item(0).DisplayColumns(0).Width = 73
        Me.LstClientes.Splits.Item(0).DisplayColumns(1).Width = 155


        MiConexion.Close()
        Posicion = Me.LstClientes.SelectedIndex
        If Posicion < 0 Then
            MsgBox("Seleccione un Cliente", MsgBoxStyle.Critical, "Seleccione un Cliente")
            Exit Sub
        End If

        CodigoCliente = DataSetListBox.Tables("PlantillaClientes").Rows(Posicion)("Cod_Cliente")
        DataSetListBox.Tables("PlantillaClientes").Rows(Posicion).Delete()

        ' **************************************************************************************************************************************
        '///////////////////////////////////////BUSCO SI YA ESTA GRABADO PARA ELIMINARLO ////////////////////////////////////////////////////////
        ' **************************************************************************************************************************************
        SqlString = "SELECT  * FROM PlantillaClientes WHERE (Cod_Cliente = '" & CodigoCliente & "') AND (NumeroPlantilla = '" & Me.TxtNumeroEnsamble.Text & "')"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")

        If Not DataSet.Tables("Consultas").Rows.Count = 0 Then
            MiConexion.Close()
            StrSqlUpdate = "DELETE FROM [PlantillaClientes] WHERE (Cod_Cliente = '" & CodigoCliente & "') AND (NumeroPlantilla = '" & Me.TxtNumeroEnsamble.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        DataSetListBox.Tables("PlantillaClientes").Clear()
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE LOS CLIENTES/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  Cod_Cliente, Nombre_Cliente FROM PlantillaClientes WHERE (NumeroPlantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (FechaPlantilla = '" & Format(Me.DTPFecha.Value, "dd/MM/yyyy") & "') AND (Tipo_Plantilla = '" & TipoFactura & "') ORDER BY Cod_Cliente"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSetListBox, "PlantillaClientes")
        Me.LstClientes.DataSource = DataSetListBox.Tables("PlantillaClientes")
        Me.LstClientes.Splits.Item(0).DisplayColumns(0).Width = 73
        Me.LstClientes.Splits.Item(0).DisplayColumns(1).Width = 155
    End Sub

    Private Sub Button3_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub CmdBorrarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrarLinea.Click
        Dim Resultado As Double, CodProducto As String, iPosicion As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim SqlString As String, idDetalle As Double, NombreProducto As String, Descuento As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaFactura As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado = 7 Then
            Exit Sub
        End If

        FechaFactura = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
        iPosicion = Me.BindingDetalle.Position
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("id_Detalle_Plantilla")) Then
            idDetalle = Me.BindingDetalle.Item(iPosicion)("id_Detalle_Plantilla")
        Else
            idDetalle = -1
        End If
        PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        End If
        PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        NombreProducto = Replace(Me.BindingDetalle.Item(iPosicion)("Descripcion_Producto"), "'", "")

        Me.BindingDetalle.RemoveCurrent()

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LA PLANTILLA///////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT * FROM Detalle_Plantilla WHERE (Numero_Plantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "')  AND (Descripcion_Producto = '" & NombreProducto & "') AND (id_Detalle_Plantilla = '" & idDetalle & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Close()
            StrSqlUpdate = " DELETE FROM Detalle_Plantilla WHERE (Numero_Plantilla = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Plantilla = CONVERT(DATETIME, '" & FechaFactura & "', 102)) AND (Cod_Producto = '" & CodProducto & "') AND (Descripcion_Producto = '" & NombreProducto & "') AND (id_Detalle_Plantilla = '" & idDetalle & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        ActualizaMETODOPlantilla()
    End Sub
End Class