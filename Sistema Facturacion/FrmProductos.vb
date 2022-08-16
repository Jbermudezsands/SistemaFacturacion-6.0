Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient

Public Class FrmProductos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public MiConexionContabilidad As New SqlClient.SqlConnection(ConexionContabilidad)
    Public CodComponente As Double, RutaCompartida As String
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder
    Public Function ExisteUnidadMedida(ByVal Cod_Producto As String, ByVal Unidad_Medida As String) As Boolean
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String

        SqlString = "SELECT  * FROM UnidadMedidaProductos WHERE (Cod_Productos = '" & Cod_Producto & "') AND (Unidad_Medida = '" & Unidad_Medida & "')"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If Not DataSet.Tables("Producto").Rows.Count = 0 Then
            ExisteUnidadMedida = True
        Else
            ExisteUnidadMedida = False
        End If

        MiConexion.Close()


    End Function




    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProducto.Text = My.Forms.FrmConsultas.Codigo
        Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoProducto
        Me.TxtNombreProducto.Text = My.Forms.FrmConsultas.Descripcion

    End Sub

    Public Sub InsertarRowGridIngresos(ByVal Cod_Productos As String, ByVal Unidad_Medida As String)
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.tdbGridUnidadMedida.Row

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("UnidadMedida").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then

            If ExisteUnidadMedida(Cod_Productos, Unidad_Medida) = True Then
                MsgBox("Esta unidad de Medida esta Asignada", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                Exit Sub
            End If

            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("UnidadMedida").AcceptChanges()
            da.Update(ds.Tables("UnidadMedida"))

            ActualizarGridInsertRowIngresos()

            Me.tdbGridUnidadMedida.Row = iPosicion

        Else
            oTabla = ds.Tables("UnidadMedida").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("UnidadMedida").AcceptChanges()
                da.Update(ds.Tables("UnidadMedida"))
            End If
        End If




    End Sub
    Public Sub ActualizarGridInsertRowIngresos()
        Dim SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem(), item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()


        ds.Tables("UnidadMedida").Reset()
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Cod_Productos, Unidad_Medida, Cantidad_Unidades, Precio_Unitario, Unidad_Defecto FROM UnidadMedidaProductos WHERE  (Cod_Productos = '" & TextBox.Text & "') ORDER BY Unidad_Medida"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "UnidadMedida")
        Me.tdbGridUnidadMedida.DataSource = ds.Tables("DetalleIngresos")
        Me.tdbGridUnidadMedida.DataSource = ds.Tables("UnidadMedida")
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cod_Productos").Visible = False
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Medida").Width = 100
        Me.tdbGridUnidadMedida.Columns("Unidad_Medida").Caption = "Unidad Medida"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cantidad_Unidades").Width = 100
        Me.tdbGridUnidadMedida.Columns("Cantidad_Unidades").Caption = "Cant Unidades"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 100
        Me.tdbGridUnidadMedida.Columns("Precio_Unitario").Caption = "Precio Unitario"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Defecto").Width = 100
        Me.tdbGridUnidadMedida.Columns("Unidad_Defecto").Caption = "Defecto"

    End Sub





    Private Sub CboCodigoProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim CodigoProducto As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
        'Dim CodLinea As String, SqlLinea As String, CodImpuesto As String, SqlImpuesto As String


        'If Me.CboCodigoProducto.Text = "" Then
        '    Me.TxtUbicacion.Text = ""
        '    Me.TxtCtaInventario.Text = ""
        '    Me.TxtNombreProducto.Text = ""
        '    Me.CboTipoProducto.Text = ""
        '    Me.CboLinea.Text = ""
        '    Me.CboUnidad.Text = ""
        '    Me.TxtPrecioCompra.Text = ""
        '    Me.TxtDescuento.Text = ""
        '    Me.CboExistencia.Text = ""
        '    Me.TxtCtaCosto.Text = ""
        '    Me.TxtPrecioVenta.Text = ""
        '    Me.CboIva.Text = ""
        '    Me.CboActivo.Text = ""
        '    Me.TxtCuentaVenta.Text = ""
        '    Me.TxtMinimo.Text = "0.00"
        '    Me.TxtReorden.Text = "0.00"
        '    CodComponente = 0
        '    Exit Sub
        'End If

        'CodigoProducto = Me.CboCodigoProducto.Text
        'SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "') "
        'MiConexion.Open()
        'DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        'DataAdapter.Fill(DataSet, "Producto")
        'If Not DataSet.Tables("Producto").Rows.Count = 0 Then
        '    Me.TxtUbicacion.Text = DataSet.Tables("Producto").Rows(0)("Ubicacion")
        '    Me.TxtCtaInventario.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Inventario")
        '    Me.TxtNombreProducto.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
        '    Me.CboTipoProducto.Text = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")

        '    '////////BUSCO LA LINEA DEL PRODUCTO//////////
        '    CodLinea = DataSet.Tables("Producto").Rows(0)("Cod_Linea")
        '    SqlLinea = "SELECT  * FROM Lineas WHERE (Cod_Linea = '" & CodLinea & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
        '    DataAdapter.Fill(DataSet, "LineaProducto")
        '    If Not DataSet.Tables("LineaProducto").Rows.Count = 0 Then
        '        Me.CboLinea.Text = DataSet.Tables("LineaProducto").Rows(0)("Descripcion_Linea")


        '    End If

        '    Me.CboUnidad.Text = DataSet.Tables("Producto").Rows(0)("Unidad_Medida")
        '    Me.TxtPrecioCompra.Text = DataSet.Tables("Producto").Rows(0)("Precio_Lista")
        '    Me.TxtDescuento.Text = DataSet.Tables("Producto").Rows(0)("Descuento")
        '    If DataSet.Tables("Producto").Rows(0)("Existencia_Negativa") = True Then
        '        Me.CboExistencia.Text = "SI"
        '    Else
        '        Me.CboExistencia.Text = "NO"
        '    End If
        '    Me.TxtCtaCosto.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Costo")
        '    Me.TxtPrecioVenta.Text = DataSet.Tables("Producto").Rows(0)("Precio_Venta")

        '    '////////BUSCO EL IMPUESTO DEL PRODUCTO///////////////////////
        '    CodImpuesto = DataSet.Tables("Producto").Rows(0)("Cod_Iva")
        '    SqlImpuesto = "SELECT * FROM Impuestos WHERE (Cod_Iva = '" & CodImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlImpuesto, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto")
        '    If Not DataSet.Tables("Impuesto").Rows.Count = 0 Then
        '        Me.CboIva.Text = DataSet.Tables("Impuesto").Rows(0)("Descripcion_Iva")
        '    End If


        '    If DataSet.Tables("Producto").Rows(0)("Activo") = True Then
        '        Me.CboActivo.Text = "Activo"
        '    Else
        '        Me.CboActivo.Text = "Inactivo"
        '    End If
        '    Me.TxtCuentaVenta.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Ventas")
        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Minimo")) Then
        '        Me.TxtMinimo.Text = Val(DataSet.Tables("Producto").Rows(0)("Minimo"))
        '    Else
        '        Me.TxtMinimo.Text = "0.00"
        '    End If
        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Reorden")) Then
        '        Me.TxtReorden.Text = DataSet.Tables("Producto").Rows(0)("Reorden")
        '    Else
        '        Me.TxtReorden.Text = "0.00"
        '    End If



        '    MiConexion.Close()
        'End If

        'MiConexion.Close()


    End Sub

    Private Sub FrmProductos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String
        Dim SqlLinea As String = "SELECT * FROM Lineas ", SqlImpuestos As String = "SELECT * FROM Impuestos"
        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
        End If
        Me.CboCodigoProducto.Splits.Item(0).DisplayColumns(1).Width = 350

        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
        DataAdapterProductos.Fill(DataSet, "LineaProductos")
        Me.CboLinea.DataSource = DataSet.Tables("LineaProductos")
        Me.CboLinea.DisplayMember = "Descripcion_Linea"

        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlImpuestos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "Impuestos")
        Me.CboIva.DataSource = DataSet.Tables("Impuestos")
        Me.CboIva.DisplayMember = "Descripcion_Iva"

        Bloqueo(Me, Acceso, "Vendedores")
    End Sub

    Private Sub FrmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String
        Dim SqlLinea As String = "SELECT * FROM Lineas ", SqlImpuestos As String = "SELECT * FROM Impuestos"
        Dim SqlDatos As String, DataAdapter As New SqlClient.SqlDataAdapter

        Me.OpenFileDialog1.Filter = "Image Files (*.jpg)|*.jpg"

        Me.TabControl.SelectedTab = Generales

        '//////////////////////////////////BUSCO LOS DATOS DE LA EMPRESA PARA IMPRIMIRLOS///////////////////////////////////
        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("RutaCompartida")) Then
                RutaCompartida = DataSet.Tables("DatosEmpresa").Rows(0)("RutaCompartida")
            End If
        End If


        Select Case Acceso
            Case "Vendedores"
                Me.CmdNuevo.Enabled = False
                Me.ButtonAgregar.Enabled = False
                Me.ButtonBorrar.Enabled = False
                Me.Button4.Enabled = False
                Me.Button5.Enabled = False
                Me.Button11.Enabled = False
                Me.CmdPrecios.Enabled = False
                Me.cmdAddDocente.Enabled = False
                Me.CmdAgregar.Enabled = False
                Me.CmdBorrarFoto.Enabled = False
                Me.TxtExistenciaValores.Visible = False
                Me.TxtExistenciaValoresD.Visible = False
                Me.TxtCostoPromedio.Visible = False
                Me.TxtCostoPromedioDolar.Visible = False
                Me.TxtUltimoPrecioCompra.Visible = False
                Me.GroupBox10.Visible = False

        End Select

        Me.CboTipoProducto.Text = "Productos"
        Me.CboActivo.Text = "Activo"
        Me.CboExistencia.Text = "NO"
        If ExisteConexion = True Then
            Me.TxtCtaCosto.Text = BuscaPrimerCuentaContable("Costos")
            Me.TxtCtaInventario.Text = BuscaPrimerCuentaContable("Inventario")
            Me.TxtCuentaVenta.Text = BuscaPrimerCuentaContable("Ingresos - Ventas")
            Me.TxtIngresoAjuste.Text = BuscaPrimerCuentaContable("Ingresos - Ventas")
            Me.TxtGastoAjuste.Text = BuscaPrimerCuentaContable("Gastos")
        Else
            Me.TxtCtaCosto.Text = "4101"
            Me.TxtCtaInventario.Text = "1141"
            Me.TxtCuentaVenta.Text = "4101"
            Me.TxtIngresoAjuste.Text = "4101"
            Me.TxtGastoAjuste.Text = "5101"
        End If



        DataSet.Reset()
        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
        End If
        Me.CboCodigoProducto.Splits.Item(0).DisplayColumns(1).Width = 350

        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
        DataAdapterProductos.Fill(DataSet, "LineaProductos")
        Me.CboLinea.DataSource = DataSet.Tables("LineaProductos")
        If DataSet.Tables("LineaProductos").Rows.Count <> 0 Then
            Me.CboLinea.Text = DataSet.Tables("LineaProductos").Rows(0)("Descripcion_Linea")
        End If
        Me.CboLinea.DisplayMember = "Descripcion_Linea"

        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlImpuestos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "Impuestos")
        Me.CboIva.DataSource = DataSet.Tables("Impuestos")
        If DataSet.Tables("Impuestos").Rows.Count <> 0 Then
            Me.CboIva.Text = DataSet.Tables("Impuestos").Rows(0)("Descripcion_Iva")
        End If
        Me.CboIva.DisplayMember = "Descripcion_Iva"

        'Me.TabControl.TabPages(3).PageVisible = False
        'Me.TabControl.TabPages.Remove(Me.TabControl.TabPages(3))
        Me.Componentes.Parent = Nothing


        SqlProductos = "SELECT  * FROM  Rubro"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "Rubros")
        If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
            Me.CboRubro.DataSource = DataSet.Tables("Rubros")
            Me.CboRubro.Text = DataSet.Tables("Rubros").Rows(0)("Nombre_Rubro")
        End If


        SqlProductos = "SELECT Cod_Productos, Unidad_Medida, Cantidad_Unidades, Precio_Unitario, Unidad_Defecto FROM UnidadMedidaProductos WHERE  (Cod_Productos = '-10000') ORDER BY Unidad_Medida"
        ds = New DataSet
        da = New SqlDataAdapter(SqlProductos, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "UnidadMedida")
        Me.tdbGridUnidadMedida.DataSource = ds.Tables("UnidadMedida")
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cod_Productos").Visible = False
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Medida").Width = 100
        Me.tdbGridUnidadMedida.Columns("Unidad_Medida").Caption = "Unidad Medida"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cantidad_Unidades").Width = 100
        Me.tdbGridUnidadMedida.Columns("Cantidad_Unidades").Caption = "Cant Unidades"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 100
        Me.tdbGridUnidadMedida.Columns("Precio_Unitario").Caption = "Precio Unitario"
        Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Defecto").Width = 100
        Me.tdbGridUnidadMedida.Columns("Unidad_Defecto").Caption = "Defecto"

        '/////////////////////////////////////////UNIDAD DE MEDIDA /////////////////////////////////////////////////////////////
        SqlProductos = "SELECT DISTINCT Unidad_Medida  FROM UnidadMedidaProductos WHERE (Unidad_Medida <> ' ') AND (Unidad_Medida <> '0') UNION SELECT DISTINCT Unidad_Medida FROM Productos WHERE  (Unidad_Medida <> ' ') AND (Unidad_Medida <> '0') ORDER BY Unidad_Medida"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "UNIDAD")
        Me.CboUnidad.DataSource = DataSet.Tables("UNIDAD")
        If Not DataSet.Tables("UNIDAD").Rows.Count = 0 Then
            Me.CboUnidad.Text = DataSet.Tables("UNIDAD").Rows(0)("Unidad_Medida")
        End If
        Me.CboUnidad.DisplayMember = "Unidad_Medida"

        Me.CboCodigoProducto.Splits.Item(0).DisplayColumns(1).Width = 350

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CboCodigoProducto.Text = ""
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CuentaInventario"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaInventario.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCosto"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaCosto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TxtCuentaVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCuentaVenta.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CuentaVentas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCuentaVenta.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoProducto.Text = ""
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim SQLProductos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim CodBodega As String = "", CodRubro As String = "", Iposicion = 0
        'Try


        If Me.CboCodigoProducto.Text = "" Then
            MsgBox("Se necesita el Codigo del Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Se necesita el Tipo de Producto", MsgBoxStyle.Exclamation, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.CboActivo.Text = "" Then
            MsgBox("Se necesita un Estado para el Producto", MsgBoxStyle.Exclamation, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.CboExistencia.Text = "" Then
            MsgBox("Se necesita conocer si se permiten negativos", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TxtNombreProducto.Text = "" Then
            MsgBox(" Se necesita un nombre para el Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.CboLinea.Text = "" Then
            MsgBox(" El producto necesita una Linea", MsgBoxStyle.Exclamation, "Sistema de Facturacion")
            Exit Sub
        End If

        Me.TxtNombreProducto.Text = Replace(Me.TxtNombreProducto.Text, "'", "")
        If Me.CboRubro.Text <> "" Then
            CodRubro = Me.CboRubro.Columns(0).Text
        End If

        If Not IsNumeric(Me.TxtMerma.Text) Then
            Me.TxtMerma.Text = 0
        End If

        If Not IsNumeric(Me.TxtDesperdicio.Text) Then
            Me.TxtDesperdicio.Text = 0
        End If


        SQLProductos = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedores")
        If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Productos] SET [Descripcion_Producto] = '" & Me.TxtNombreProducto.Text & "',[Ubicacion] = '" & Me.TxtUbicacion.Text & "',[Cod_Linea] = '" & Me.CboLinea.Columns(0).Text & "',[Tipo_Producto] = '" & Me.CboTipoProducto.Text & "',[Cod_Cuenta_Inventario] = '" & Me.TxtCtaInventario.Text & "' ,[Cod_Cuenta_Costo] = '" & Me.TxtCtaCosto.Text & "',[Cod_Cuenta_Ventas] = '" & Me.TxtCuentaVenta.Text & "',[Unidad_Medida] = '" & Me.CboUnidad.Text & "',[Precio_Venta] = '" & CDbl(Me.TxtPrecioVenta.Text) & "',[Precio_Lista] = '" & CDbl(Me.TxtPrecioCompra.Text) & "',[Descuento] = '" & Me.TxtDescuento.Text & "',[Existencia_Negativa] = '" & Me.CboExistencia.Text & "',[Cod_Iva] = '" & Me.CboIva.Text & "' ,[Activo] = '" & Me.CboActivo.Text & "' ,[Minimo] = '" & Me.TxtMinimo.Text & "' ,[Reorden] = '" & Me.TxtReorden.Text & "',[Nota] = '" & Me.TxtNota.Text & "',[Cod_Cuenta_GastoAjuste]= '" & Me.TxtGastoAjuste.Text & "',[Cod_Cuenta_IngresoAjuste]= '" & Me.TxtIngresoAjuste.Text & "',[CodComponente]= " & CodComponente & ",[Cod_Rubro]= '" & CodRubro & "', [Porcentaje_Aumento]= " & Me.TxtAumento.Value & ",  [Rendimiento]= " & Me.TxtRendimiento.Text & " ,[Merma]= " & Me.TxtMerma.Text & " ,  [Desperdicio]= " & Me.TxtDesperdicio.Text & "    WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Productos] ([Cod_Productos],[Descripcion_Producto],[Ubicacion],[Cod_Linea],[Tipo_Producto],[Cod_Cuenta_Inventario],[Cod_Cuenta_Costo],[Cod_Cuenta_Ventas],[Unidad_Medida],[Precio_Venta],[Precio_Lista],[Descuento],[Existencia_Negativa],[Cod_Iva],[Activo],[Minimo],[Reorden],[Nota],[Cod_Cuenta_GastoAjuste],[Cod_Cuenta_IngresoAjuste],[CodComponente],[Cod_Rubro],[Porcentaje_Aumento],[Rendimiento],[Merma],[Desperdicio]) " & _
                           "VALUES('" & Me.CboCodigoProducto.Text & "','" & Me.TxtNombreProducto.Text & "','" & Me.TxtUbicacion.Text & "','" & Me.CboLinea.Columns(0).Text & "','" & Me.CboTipoProducto.Text & "' ,'" & Me.TxtCtaInventario.Text & "','" & Me.TxtCtaCosto.Text & "','" & Me.TxtCuentaVenta.Text & "','" & Me.CboUnidad.Text & "','" & CDbl(Me.TxtPrecioVenta.Text) & "','" & CDbl(Me.TxtPrecioCompra.Text) & "','" & Me.TxtDescuento.Text & "','" & Me.CboExistencia.Text & "','" & Me.CboIva.Text & "','" & Me.CboActivo.Text & "','" & Me.TxtMinimo.Text & "' ,'" & Me.TxtReorden.Text & "','" & Me.TxtNota.Text & "','" & Me.TxtGastoAjuste.Text & "','" & Me.TxtIngresoAjuste.Text & "'," & CodComponente & ",'" & CodRubro & "'," & Me.TxtAumento.Value & "," & Me.TxtRendimiento.Text & ", " & Me.TxtMerma.Text & " ," & Me.TxtDesperdicio.Text & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////BUSCO LAS BODEGAS//////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Iposicion = 0
            SQLProductos = "SELECT  *  FROM Bodegas "
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas")
            Do While Iposicion < DataSet.Tables("Bodegas").Rows.Count
                CodBodega = DataSet.Tables("Bodegas").Rows(Iposicion)("Cod_Bodega")

                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////////BUSCO SI EXISTE EN LAS BODEGAS DETALLES///////////////////////////////////////////////////////
                '(//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SQLProductos = "SELECT  * FROM DetalleBodegas WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "') AND (Cod_Bodegas = '" & CodBodega & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
                DataAdapter.Fill(DataSet, "DetalleBodegas")
                If DataSet.Tables("DetalleBodegas").Rows.Count = 0 Then
                    StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " & _
                                   "VALUES('" & CodBodega & "','" & Me.CboCodigoProducto.Text & "') "
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                End If
                DataSet.Tables("DetalleBodegas").Reset()
                Iposicion = Iposicion + 1
            Loop

            MiConexion.Close()

        End If
        ActualizaComboProducto()
        Me.CboCodigoProducto.Text = ""

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

    End Sub

    Private Sub CboCodigoProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboCodigoProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim CodigoProducto As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
            Dim CodLinea As String, SqlLinea As String, CodImpuesto As String, SqlImpuesto As String, RutaOrigen As String
            Dim SqlString As String, Existencia As Double, iPosicionFila As Double, CodigoBodega As String
            Dim ExistenciaValores As Double, ExistenciaValoresDolar As Double, CodRubro As String, ExistenciaBodega As Double
            Dim StrSQLUpdate As String, ComandoUpdate As New SqlClient.SqlCommand
            Dim iResultado As Integer, CostoProducto As Double = 0, CostoProductoD As Double = 0
            Dim DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String

            SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "') "
            MiConexion.Close()
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
            DataAdapter.Fill(DataSet, "Producto")
            If DataSet.Tables("Producto").Rows.Count = 0 Then


                Dim CodigoAlterno As String = Me.CboCodigoProducto.Text

                SQl = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
                DataAdapter.Fill(DataSet, "Alternos")
                If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                    MsgBox("El Codigo " & CodigoAlterno & " es un Codigo Alternativo de " & DataSet.Tables("Alternos").Rows(0)("Cod_Producto"))
                    Me.CboCodigoProducto.Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
                Else
                    Me.TxtUbicacion.Text = ""
                    Me.TxtCtaInventario.Text = ""
                    Me.TxtNombreProducto.Text = ""
                    Me.CboTipoProducto.Text = ""
                    Me.CboLinea.Text = ""
                    Me.CboUnidad.Text = ""
                    Me.TxtPrecioCompra.Text = ""
                    Me.TxtDescuento.Text = ""
                    Me.CboExistencia.Text = ""
                    Me.TxtCtaCosto.Text = ""
                    Me.TxtPrecioVenta.Text = ""
                    Me.CboIva.Text = ""
                    Me.CboActivo.Text = ""
                    Me.TxtCuentaVenta.Text = ""
                    Me.TxtMinimo.Text = "0.00"
                    Me.TxtReorden.Text = "0.00"
                    CodComponente = 0

                    'If Me.CboCodigoProducto.Text = "" Then
                    Me.TxtUbicacion.Text = ""
                    'Me.TxtCtaInventario.Text = ""
                    Me.TxtNombreProducto.Text = ""
                    'Me.CboTipoProducto.Text = ""
                    Me.CboLinea.Text = ""
                    Me.CboUnidad.Text = ""
                    Me.TxtPrecioCompra.Text = ""
                    Me.TxtDescuento.Text = ""
                    Me.CboExistencia.Text = ""
                    Me.TxtCtaCosto.Text = ""
                    Me.TxtPrecioVenta.Text = ""
                    Me.CboIva.Text = ""
                    Me.CboActivo.Text = ""
                    'Me.TxtCuentaVenta.Text = ""
                    Me.TxtMinimo.Text = "0.00"
                    Me.TxtReorden.Text = "0.00"
                    CodComponente = 0

                    Me.CboTipoProducto.Text = "Productos"
                    Me.CboActivo.Text = "Activo"
                    Me.CboExistencia.Text = "NO"
                    If ExisteConexion = True Then
                        Me.TxtCtaCosto.Text = BuscaPrimerCuentaContable("Costos")
                        Me.TxtCtaInventario.Text = BuscaPrimerCuentaContable("Inventario")
                        Me.TxtCuentaVenta.Text = BuscaPrimerCuentaContable("Ingresos - Ventas")
                        Me.TxtIngresoAjuste.Text = BuscaPrimerCuentaContable("Ingresos - Ventas")
                        Me.TxtGastoAjuste.Text = BuscaPrimerCuentaContable("Gastos")
                    Else
                        Me.TxtCtaCosto.Text = "4101"
                        Me.TxtCtaInventario.Text = "1141"
                        Me.TxtCuentaVenta.Text = "4101"
                        Me.TxtIngresoAjuste.Text = "4101"
                        Me.TxtGastoAjuste.Text = "5101"
                    End If

                    'Me.TabControl.TabPages(3).PageVisible = False
                    'Me.TabControl.TabPages.Remove(Me.TabControl.TabPages(3))
                    Me.Componentes.Parent = Nothing

                    '/////////////////////////////////LINEA DE PRODUCTOS ///////////////////////////////////////////////////////////////
                    SqlString = "SELECT * FROM Lineas "
                    DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapterProductos.Fill(DataSet, "LineaProductos")
                    Me.CboLinea.DataSource = DataSet.Tables("LineaProductos")
                    If DataSet.Tables("LineaProductos").Rows.Count <> 0 Then
                        Me.CboLinea.Text = DataSet.Tables("LineaProductos").Rows(0)("Descripcion_Linea")
                    End If
                    Me.CboLinea.DisplayMember = "Descripcion_Linea"

                    SqlString = "SELECT * FROM Impuestos"
                    DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapterProductos.Fill(DataSet, "Impuestos")
                    Me.CboIva.DataSource = DataSet.Tables("Impuestos")
                    If DataSet.Tables("Impuestos").Rows.Count <> 0 Then
                        Me.CboIva.Text = DataSet.Tables("Impuestos").Rows(0)("Descripcion_Iva")
                    End If
                    Me.CboIva.DisplayMember = "Descripcion_Iva"

                    SqlProductos = "SELECT  * FROM  Rubro"
                    DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                    DataAdapterProductos.Fill(DataSet, "Rubros")
                    If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
                        Me.CboRubro.DataSource = DataSet.Tables("Rubros")
                        Me.CboRubro.Text = DataSet.Tables("Rubros").Rows(0)("Nombre_Rubro")
                    End If

                    '/////////////////////////////////////////UNIDAD DE MEDIDA /////////////////////////////////////////////////////////////
                    SqlProductos = "SELECT DISTINCT Unidad_Medida  FROM Productos WHERE  (Unidad_Medida <> ' ') ORDER BY Unidad_Medida"
                    DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                    DataAdapterProductos.Fill(DataSet, "UNIDAD")
                    Me.CboUnidad.DataSource = DataSet.Tables("UNIDAD")
                    If Not DataSet.Tables("UNIDAD").Rows.Count = 0 Then
                        Me.CboUnidad.Text = DataSet.Tables("UNIDAD").Rows(0)("Unidad_Medida")
                    End If
                    Me.CboUnidad.DisplayMember = "Unidad_Medida"

                    Exit Sub

                End If
            Else   'If Not DataSet.Tables("Producto").Rows.Count = 0 Then

                CodigoProducto = Me.CboCodigoProducto.Text
                ActualizaCostoPromedio(CodigoProducto)

                'SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "') "
                'MiConexion.Close()
                'MiConexion.Open()
                'DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
                'DataAdapter.Fill(DataSet, "Producto")
                'If Not DataSet.Tables("Producto").Rows.Count = 0 Then
                CodComponente = DataSet.Tables("Producto").Rows(0)("CodComponente")
                'CostoPromedio = DataSet.Tables("Producto").Rows(0)("Costo_Promedio")

                Me.TxtNombreProducto.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
                Me.CboTipoProducto.Text = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
                Me.CboUnidad.Text = DataSet.Tables("Producto").Rows(0)("Unidad_Medida")
                Me.TxtPrecioCompra.Text = DataSet.Tables("Producto").Rows(0)("Precio_Lista")
                Me.TxtDescuento.Text = DataSet.Tables("Producto").Rows(0)("Descuento")
                Me.CboExistencia.Text = DataSet.Tables("Producto").Rows(0)("Existencia_Negativa")
                Me.TxtCtaCosto.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Costo")
                Me.TxtPrecioVenta.Text = DataSet.Tables("Producto").Rows(0)("Precio_Venta")
                Me.CboActivo.Text = DataSet.Tables("Producto").Rows(0)("Activo")
                Me.TxtCuentaVenta.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Ventas")
                Me.TxtUltimoPrecioCompra.Text = Format(DataSet.Tables("Producto").Rows(0)("Ultimo_Precio_Compra"), "##,##0.00")
                Me.TxtCostoPromedioDolar.Text = Format(DataSet.Tables("Producto").Rows(0)("Costo_Promedio_Dolar"), "##,##0.000")

                If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Minimo")) Then
                    Me.TxtMinimo.Text = Val(DataSet.Tables("Producto").Rows(0)("Minimo"))
                Else
                    Me.TxtMinimo.Text = "0.00"
                End If
                If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Reorden")) Then
                    Me.TxtReorden.Text = DataSet.Tables("Producto").Rows(0)("Reorden")
                Else
                    Me.TxtReorden.Text = "0.00"
                End If
                If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Nota")) Then
                    Me.TxtNota.Text = DataSet.Tables("Producto").Rows(0)("Nota")
                End If

                If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_GastoAjuste")) Then
                    Me.TxtGastoAjuste.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_GastoAjuste")
                End If

                If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_IngresoAjuste")) Then
                    Me.TxtIngresoAjuste.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_IngresoAjuste")
                End If

                CostoProducto = CostoPromedio(CodigoProducto)
                CostoProductoD = CostoPromedioDolar



                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////BUSCO LAS BODEGAS DEL PRODUCTO/////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////

                SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
                            "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Bodegas")

                '//////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////
                Existencia = 0
                iPosicionFila = 0
                Do While iPosicionFila < (DataSet.Tables("Bodegas").Rows.Count)
                    My.Application.DoEvents()
                    CodigoBodega = DataSet.Tables("Bodegas").Rows(iPosicionFila)("Cod_Bodegas")


                    ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)
                    Existencia = Existencia + ExistenciaBodega
                    MiConexion.Close()
                    '///////////ACTUALIZO LA EXISTENCIA PARA CADA BODEGA ////////////////////////////////////////
                    StrSQLUpdate = "UPDATE [DetalleBodegas]  SET [Existencia] = '" & ExistenciaBodega & "', [Costo] = '" & CostoProducto & "'  WHERE (Cod_Productos = '" & CodigoProducto & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()


                    iPosicionFila = iPosicionFila + 1
                Loop



                DataSet.Tables("Bodegas").Reset()
                SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia,DetalleBodegas.Costo FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
                            "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Bodegas")
                '//////////////////////////////////////////////////////CARGO LAS EXISTENCIAS DE BODEGAS /////////////////////////////
                Me.BindingBodegas.DataSource = DataSet.Tables("Bodegas")
                Me.TrueDBGridConsultas.DataSource = Me.BindingBodegas
                Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 80
                Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 70
                Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 70
                Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"

                Select Case Acceso
                    Case "Vendedores"
                        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False

                End Select


                '///////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////CARGO LOS HISTORICOS DE VENTAS/////////////////////////////////////////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlString = "SELECT  Facturas.Numero_Factura, Facturas.Tipo_Factura, Facturas.Fecha_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente,  Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario FROM   Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura And Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura  " & _
                            "WHERE (Facturas.Tipo_Factura <> 'Cotizacion') AND (Detalle_Facturas.Cod_Producto = '" & CodigoProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Ventas")
                Me.BindingHistoricosVentas.DataSource = DataSet.Tables("Ventas")
                Me.TruDbGridHistoricosVentas.DataSource = Me.BindingHistoricosVentas
                Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(0).Width = 111
                Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(2).Width = 91
                Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(3).Width = 271
                Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(4).Width = 100
                Me.TruDbGridHistoricosVentas.Columns(3).NumberFormat = "##,##0.00"

                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////CARGO LOS HISTORICOS DE COMPRAS/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                SqlString = "SELECT Compras.Numero_Compra, Compras.Tipo_Compra,Compras.Fecha_Compra, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres,  Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario FROM Compras INNER JOIN Proveedor ON Compras.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN Detalle_Compras ON Compras.Numero_Compra = Detalle_Compras.Numero_Compra AND Compras.Fecha_Compra = Detalle_Compras.Fecha_Compra And Compras.Tipo_Compra = Detalle_Compras.Tipo_Compra  " & _
                            "WHERE (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Compras")
                Me.BindingHistoricoCompras.DataSource = DataSet.Tables("Compras")
                Me.TruDbGridHistoricosCompras.DataSource = Me.BindingHistoricoCompras
                Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(0).Width = 111
                Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(2).Width = 91
                Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(3).Width = 271
                Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(4).Width = 100
                Me.TruDbGridHistoricosCompras.Columns(3).NumberFormat = "##,##0.00"


                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////BUSCO LOS COMPONENTES DEL PRODUCTO/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                SqlString = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Componentes")
                Me.BindingComponentes.DataSource = DataSet.Tables("Componentes")
                Me.TrueDBGridComponentes.DataSource = Me.BindingComponentes

                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Visible = False
                Me.TrueDBGridComponentes.Columns(1).Caption = "Componente"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 74
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 182
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 68
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 74

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////////////////////BUSCO LOS IMPUESTOS DEL PRODUCTO////////////////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlString = "SELECT  Impuestos.Cod_Iva, Impuestos.Descripcion_Iva, Impuestos.Impuesto, Impuestos.TipoImpuesto, ImpuestosProductos.Cod_Productos FROM  ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  " & _
                "WHERE  (ImpuestosProductos.Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "ListaImpuestos")
                Me.BindingImpuestos.DataSource = DataSet.Tables("ListaImpuestos")
                Me.TDGridImpuestos.DataSource = Me.BindingImpuestos
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Width = 94
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Locked = True
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Width = 166
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Locked = True
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Width = 100
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Locked = True
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Width = 100
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Locked = True
                Me.TDGridImpuestos.Splits(0).DisplayColumns(4).Visible = False

                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////BUSCO LOS CODIGOS ALTERNATIVOS/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                SqlString = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Producto = '" & CodigoProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Alternativos")
                Me.BindingCodigoAlternos.DataSource = DataSet.Tables("Alternativos")
                Me.TdGridAlternativos.DataSource = Me.BindingCodigoAlternos

                Me.TdGridAlternativos.Columns(0).Caption = "Codigo Alternos"
                Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(0).Width = 100
                Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(1).Visible = False
                Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(1).Locked = True
                Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(2).Width = 350


                'Compras = Format(BuscaCompra(CodigoProducto, FechaIni, FechaFin), "####0.00")
                'Ventas = Format(BuscaVenta(CodigoProducto, FechaIni, FechaFin), "####0.00")
                'Inicial = Format(BuscaInventarioInicial(CodigoProducto, FechaIni), "####0.00")

                Me.TxtUbicacion.Text = DataSet.Tables("Producto").Rows(0)("Ubicacion")
                If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Inventario")) Then
                    Me.TxtCtaInventario.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Inventario")
                End If

                Me.TxtExistenciaUnidades.Text = Format(Existencia, "##,##0.00")
                ExistenciaValores = Math.Abs(Existencia * CostoProducto)
                Me.TxtExistenciaValores.Text = Format(ExistenciaValores, "##,##0.00")
                ExistenciaValoresDolar = Math.Abs(Existencia * CostoProductoD)
                Me.TxtExistenciaValoresD.Text = Format(ExistenciaValoresDolar, "##,##0.000")
                'Me.TxtCostoPromedio.Text = Format(DataSet.Tables("Producto").Rows(0)("Costo_Promedio"), "##,##0.0000")
                Me.TxtCostoPromedio.Text = Format(CostoPromedio(CodigoProducto), "##,##0.000")

                '////////BUSCO LA LINEA DEL PRODUCTO//////////
                If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Linea")) Then
                    CodLinea = DataSet.Tables("Producto").Rows(0)("Cod_Linea")
                Else
                    CodLinea = ""
                End If
                SqlLinea = "SELECT  * FROM Lineas WHERE (Cod_Linea = '" & CodLinea & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
                DataAdapter.Fill(DataSet, "LineaProducto")
                If Not DataSet.Tables("LineaProducto").Rows.Count = 0 Then
                    Me.CboLinea.Text = DataSet.Tables("LineaProducto").Rows(0)("Descripcion_Linea")
                End If


                '////////BUSCO EL RUBRO DEL PRODUCTO//////////
                If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Rubro")) Then
                    CodRubro = DataSet.Tables("Producto").Rows(0)("Cod_Rubro")
                Else
                    CodRubro = ""
                End If
                SqlLinea = "SELECT  * FROM Rubro WHERE (Codigo_Rubro = '" & CodRubro & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
                DataAdapter.Fill(DataSet, "Rubro")
                If Not DataSet.Tables("Rubro").Rows.Count = 0 Then
                    Me.CboRubro.Text = DataSet.Tables("Rubro").Rows(0)("Nombre_Rubro")
                End If




                '////////BUSCO EL IMPUESTO DEL PRODUCTO///////////////////////
                CodImpuesto = DataSet.Tables("Producto").Rows(0)("Cod_Iva")
                SqlImpuesto = "SELECT * FROM Impuestos WHERE (Cod_Iva = '" & CodImpuesto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlImpuesto, MiConexion)
                DataAdapter.Fill(DataSet, "Impuesto")
                If Not DataSet.Tables("Impuesto").Rows.Count = 0 Then
                    Me.CboIva.Text = DataSet.Tables("Impuesto").Rows(0)("Descripcion_Iva")
                End If



                'If Dir(RutaCompartida) = True Then
                '    RutaOrigen = RutaCompartida & "\Fotos\" & Me.CboCodigoProducto.Text & ".bmp"
                '    If System.IO.File.Exists(RutaOrigen) = True Then
                '        Me.ImgFoto.ImageLocation = RutaOrigen
                '    End If
                'Else
                RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & Me.CboCodigoProducto.Text & ".bmp"
                If System.IO.File.Exists(RutaOrigen) = True Then
                    Me.ImgFoto.ImageLocation = RutaOrigen
                End If
                'End If
                MiConexion.Close()
                'Else

                'Dim CodigoAlterno As String = Me.CboCodigoProducto.Text

                'SQl = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
                'DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
                'DataAdapter.Fill(DataSet, "Alternos")
                'If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                '    MsgBox("El Codigo " & CodigoAlterno & " es un Codigo Alternativo de " & DataSet.Tables("Alternos").Rows(0)("Cod_Producto"))
                '    Me.CboCodigoProducto.Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
                'Else
                '    Me.TxtUbicacion.Text = ""
                '    Me.TxtCtaInventario.Text = ""
                '    Me.TxtNombreProducto.Text = ""
                '    Me.CboTipoProducto.Text = ""
                '    Me.CboLinea.Text = ""
                '    Me.CboUnidad.Text = ""
                '    Me.TxtPrecioCompra.Text = ""
                '    Me.TxtDescuento.Text = ""
                '    Me.CboExistencia.Text = ""
                '    Me.TxtCtaCosto.Text = ""
                '    Me.TxtPrecioVenta.Text = ""
                '    Me.CboIva.Text = ""
                '    Me.CboActivo.Text = ""
                '    Me.TxtCuentaVenta.Text = ""
                '    Me.TxtMinimo.Text = "0.00"
                '    Me.TxtReorden.Text = "0.00"
                '    CodComponente = 0
                'End If

            End If

            MiConexion.Close()






        End If
    End Sub

    Private Sub CboCodigoProducto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProducto.SelectedValueChanged

    End Sub



    Private Sub CboCodigoProducto_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProducto.TextChanged

        Me.TextBox.Text = Me.CboCodigoProducto.Text
        'Dim CodigoProducto As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
        'Dim CodLinea As String, SqlLinea As String, CodImpuesto As String, SqlImpuesto As String, RutaOrigen As String
        'Dim SqlString As String, Existencia As Double, iPosicionFila As Double, CodigoBodega As String
        'Dim ExistenciaValores As Double, ExistenciaValoresDolar As Double, CodRubro As String, ExistenciaBodega As Double
        'Dim StrSQLUpdate As String, ComandoUpdate As New SqlClient.SqlCommand
        'Dim iResultado As Integer, CostoProducto As Double = 0, CostoProductoD As Double = 0
        'Dim DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String

        'SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "') "
        'MiConexion.Close()
        'MiConexion.Open()
        'DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        'DataAdapter.Fill(DataSet, "Producto")
        'If DataSet.Tables("Producto").Rows.Count = 0 Then


        '    Dim CodigoAlterno As String = Me.CboCodigoProducto.Text

        '    SQl = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        '    DataAdapter.Fill(DataSet, "Alternos")
        '    If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
        '        MsgBox("El Codigo " & CodigoAlterno & " es un Codigo Alternativo de " & DataSet.Tables("Alternos").Rows(0)("Cod_Producto"))
        '        Me.CboCodigoProducto.Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
        '    Else
        '        Me.TxtUbicacion.Text = ""
        '        Me.TxtCtaInventario.Text = ""
        '        Me.TxtNombreProducto.Text = ""
        '        'Me.CboTipoProducto.Text = ""
        '        Me.CboLinea.Text = ""
        '        Me.CboUnidad.Text = ""
        '        Me.TxtPrecioCompra.Text = ""
        '        Me.TxtDescuento.Text = ""
        '        Me.CboExistencia.Text = ""
        '        Me.TxtCtaCosto.Text = ""
        '        Me.TxtPrecioVenta.Text = ""
        '        Me.CboIva.Text = ""
        '        Me.CboActivo.Text = ""
        '        Me.TxtCuentaVenta.Text = ""
        '        Me.TxtMinimo.Text = "0.00"
        '        Me.TxtReorden.Text = "0.00"
        '        CodComponente = 0

        '        'If Me.CboCodigoProducto.Text = "" Then
        '        Me.TxtUbicacion.Text = ""
        '        'Me.TxtCtaInventario.Text = ""
        '        Me.TxtNombreProducto.Text = ""
        '        'Me.CboTipoProducto.Text = ""
        '        Me.CboLinea.Text = ""
        '        Me.CboUnidad.Text = ""
        '        Me.TxtPrecioCompra.Text = ""
        '        Me.TxtDescuento.Text = ""
        '        Me.CboExistencia.Text = ""
        '        Me.TxtCtaCosto.Text = ""
        '        Me.TxtPrecioVenta.Text = ""
        '        Me.CboIva.Text = ""
        '        Me.CboActivo.Text = ""
        '        'Me.TxtCuentaVenta.Text = ""
        '        Me.TxtMinimo.Text = "0.00"
        '        Me.TxtReorden.Text = "0.00"
        '        CodComponente = 0

        '        Me.CboTipoProducto.Text = "Productos"
        '        Me.CboActivo.Text = "Activo"
        '        Me.CboExistencia.Text = "NO"
        '        If ExisteConexion = True Then
        '            Me.TxtCtaCosto.Text = BuscaPrimerCuentaContable("Costos")
        '            Me.TxtCtaInventario.Text = BuscaPrimerCuentaContable("Inventario")
        '            Me.TxtCuentaVenta.Text = BuscaPrimerCuentaContable("Ingresos - Ventas")
        '            Me.TxtIngresoAjuste.Text = BuscaPrimerCuentaContable("Ingresos - Ventas")
        '            Me.TxtGastoAjuste.Text = BuscaPrimerCuentaContable("Gastos")
        '        Else
        '            Me.TxtCtaCosto.Text = "4101"
        '            Me.TxtCtaInventario.Text = "1141"
        '            Me.TxtCuentaVenta.Text = "4101"
        '            Me.TxtIngresoAjuste.Text = "4101"
        '            Me.TxtGastoAjuste.Text = "5101"
        '        End If

        '        Me.TabControl.TabPages(3).PageVisible = False

        '        '/////////////////////////////////LINEA DE PRODUCTOS ///////////////////////////////////////////////////////////////
        '        SqlString = "SELECT * FROM Lineas "
        '        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '        DataAdapterProductos.Fill(DataSet, "LineaProductos")
        '        Me.CboLinea.DataSource = DataSet.Tables("LineaProductos")
        '        If DataSet.Tables("LineaProductos").Rows.Count <> 0 Then
        '            Me.CboLinea.Text = DataSet.Tables("LineaProductos").Rows(0)("Descripcion_Linea")
        '        End If
        '        Me.CboLinea.DisplayMember = "Descripcion_Linea"

        '        SqlString = "SELECT * FROM Impuestos"
        '        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '        DataAdapterProductos.Fill(DataSet, "Impuestos")
        '        Me.CboIva.DataSource = DataSet.Tables("Impuestos")
        '        If DataSet.Tables("Impuestos").Rows.Count <> 0 Then
        '            Me.CboIva.Text = DataSet.Tables("Impuestos").Rows(0)("Descripcion_Iva")
        '        End If
        '        Me.CboIva.DisplayMember = "Descripcion_Iva"

        '        SqlProductos = "SELECT  * FROM  Rubro"
        '        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        '        DataAdapterProductos.Fill(DataSet, "Rubros")
        '        If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
        '            Me.CboRubro.DataSource = DataSet.Tables("Rubros")
        '            Me.CboRubro.Text = DataSet.Tables("Rubros").Rows(0)("Nombre_Rubro")
        '        End If

        '        '/////////////////////////////////////////UNIDAD DE MEDIDA /////////////////////////////////////////////////////////////
        '        SqlProductos = "SELECT DISTINCT Unidad_Medida  FROM Productos WHERE  (Unidad_Medida <> ' ') ORDER BY Unidad_Medida"
        '        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        '        DataAdapterProductos.Fill(DataSet, "UNIDAD")
        '        Me.CboUnidad.DataSource = DataSet.Tables("UNIDAD")
        '        If Not DataSet.Tables("UNIDAD").Rows.Count = 0 Then
        '            Me.CboUnidad.Text = DataSet.Tables("UNIDAD").Rows(0)("Unidad_Medida")
        '        End If
        '        Me.CboUnidad.DisplayMember = "Unidad_Medida"

        '        Exit Sub

        '    End If
        'Else   'If Not DataSet.Tables("Producto").Rows.Count = 0 Then

        '    CodigoProducto = Me.CboCodigoProducto.Text
        '    'ActualizaCostoPromedio(CodigoProducto)

        '    If CodigoProducto = "26188" Then
        '        CodigoProducto = "26188"
        '    End If

        '    'SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "') "
        '    'MiConexion.Close()
        '    'MiConexion.Open()
        '    'DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        '    'DataAdapter.Fill(DataSet, "Producto")
        '    'If Not DataSet.Tables("Producto").Rows.Count = 0 Then
        '    CodComponente = DataSet.Tables("Producto").Rows(0)("CodComponente")
        '    'CostoPromedio = DataSet.Tables("Producto").Rows(0)("Costo_Promedio")

        '    Me.TxtNombreProducto.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
        '    Me.CboTipoProducto.Text = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
        '    Me.CboUnidad.Text = DataSet.Tables("Producto").Rows(0)("Unidad_Medida")
        '    Me.TxtPrecioCompra.Text = DataSet.Tables("Producto").Rows(0)("Precio_Lista")
        '    Me.TxtDescuento.Text = DataSet.Tables("Producto").Rows(0)("Descuento")
        '    Me.CboExistencia.Text = DataSet.Tables("Producto").Rows(0)("Existencia_Negativa")
        '    Me.TxtCtaCosto.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Costo")
        '    Me.TxtPrecioVenta.Text = DataSet.Tables("Producto").Rows(0)("Precio_Venta")
        '    Me.CboActivo.Text = DataSet.Tables("Producto").Rows(0)("Activo")
        '    Me.TxtCuentaVenta.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Ventas")
        '    Me.TxtUltimoPrecioCompra.Text = Format(DataSet.Tables("Producto").Rows(0)("Ultimo_Precio_Compra"), "##,##0.00")
        '    Me.TxtCostoPromedioDolar.Text = Format(DataSet.Tables("Producto").Rows(0)("Costo_Promedio_Dolar"), "##,##0.000")

        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Minimo")) Then
        '        Me.TxtMinimo.Text = Val(DataSet.Tables("Producto").Rows(0)("Minimo"))
        '    Else
        '        Me.TxtMinimo.Text = "0.00"
        '    End If
        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Reorden")) Then
        '        Me.TxtReorden.Text = DataSet.Tables("Producto").Rows(0)("Reorden")
        '    Else
        '        Me.TxtReorden.Text = "0.00"
        '    End If
        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Nota")) Then
        '        Me.TxtNota.Text = DataSet.Tables("Producto").Rows(0)("Nota")
        '    End If

        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_GastoAjuste")) Then
        '        Me.TxtGastoAjuste.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_GastoAjuste")
        '    End If

        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_IngresoAjuste")) Then
        '        Me.TxtIngresoAjuste.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_IngresoAjuste")
        '    End If

        '    CostoProducto = CostoPromedio(CodigoProducto)
        '    CostoProductoD = CostoPromedioDolar



        '    '//////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////BUSCO LAS BODEGAS DEL PRODUCTO/////////////////////////////////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////////

        '    SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
        '                "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Bodegas")

        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
        '    '/////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    Existencia = 0
        '    iPosicionFila = 0
        '    Do While iPosicionFila < (DataSet.Tables("Bodegas").Rows.Count)
        '        My.Application.DoEvents()
        '        CodigoBodega = DataSet.Tables("Bodegas").Rows(iPosicionFila)("Cod_Bodegas")


        '        ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)
        '        Existencia = Existencia + ExistenciaBodega
        '        MiConexion.Close()
        '        '///////////ACTUALIZO LA EXISTENCIA PARA CADA BODEGA ////////////////////////////////////////
        '        StrSQLUpdate = "UPDATE [DetalleBodegas]  SET [Existencia] = '" & ExistenciaBodega & "', [Costo] = '" & CostoProducto & "'  WHERE (Cod_Productos = '" & CodigoProducto & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
        '        MiConexion.Open()
        '        ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
        '        iResultado = ComandoUpdate.ExecuteNonQuery
        '        MiConexion.Close()


        '        iPosicionFila = iPosicionFila + 1
        '    Loop



        '    DataSet.Tables("Bodegas").Reset()
        '    SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia,DetalleBodegas.Costo FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
        '                "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Bodegas")
        '    '//////////////////////////////////////////////////////CARGO LAS EXISTENCIAS DE BODEGAS /////////////////////////////
        '    Me.BindingBodegas.DataSource = DataSet.Tables("Bodegas")
        '    Me.TrueDBGridConsultas.DataSource = Me.BindingBodegas
        '    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 80
        '    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
        '    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 70
        '    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 70
        '    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"

        '    Select Case Acceso
        '        Case "Vendedores"
        '            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False

        '    End Select


        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '////////CARGO LOS HISTORICOS DE VENTAS/////////////////////////////////////////////////////////////////////
        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    SqlString = "SELECT  Facturas.Numero_Factura, Facturas.Tipo_Factura, Facturas.Fecha_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente,  Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario FROM   Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura And Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura  " & _
        '                "WHERE (Facturas.Tipo_Factura <> 'Cotizacion') AND (Detalle_Facturas.Cod_Producto = '" & CodigoProducto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Ventas")
        '    Me.BindingHistoricosVentas.DataSource = DataSet.Tables("Ventas")
        '    Me.TruDbGridHistoricosVentas.DataSource = Me.BindingHistoricosVentas
        '    Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(0).Width = 111
        '    Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(2).Width = 91
        '    Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(3).Width = 271
        '    Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(4).Width = 100
        '    Me.TruDbGridHistoricosVentas.Columns(3).NumberFormat = "##,##0.00"

        '    '//////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////CARGO LOS HISTORICOS DE COMPRAS/////////////////////////////////////////////////
        '    '/////////////////////////////////////////////////////////////////////////////////////////////

        '    SqlString = "SELECT Compras.Numero_Compra, Compras.Tipo_Compra,Compras.Fecha_Compra, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres,  Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario FROM Compras INNER JOIN Proveedor ON Compras.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN Detalle_Compras ON Compras.Numero_Compra = Detalle_Compras.Numero_Compra AND Compras.Fecha_Compra = Detalle_Compras.Fecha_Compra And Compras.Tipo_Compra = Detalle_Compras.Tipo_Compra  " & _
        '                "WHERE (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Compras")
        '    Me.BindingHistoricoCompras.DataSource = DataSet.Tables("Compras")
        '    Me.TruDbGridHistoricosCompras.DataSource = Me.BindingHistoricoCompras
        '    Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(0).Width = 111
        '    Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(2).Width = 91
        '    Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(3).Width = 271
        '    Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(4).Width = 100
        '    Me.TruDbGridHistoricosCompras.Columns(3).NumberFormat = "##,##0.00"


        '    '//////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////BUSCO LOS COMPONENTES DEL PRODUCTO/////////////////////////////////////////////////
        '    '/////////////////////////////////////////////////////////////////////////////////////////////

        '    SqlString = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Componentes")
        '    Me.BindingComponentes.DataSource = DataSet.Tables("Componentes")
        '    Me.TrueDBGridComponentes.DataSource = Me.BindingComponentes

        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Visible = False
        '    Me.TrueDBGridComponentes.Columns(1).Caption = "Componente"
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 74
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 182
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 68
        '    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 74

        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////////////////////////////BUSCO LOS IMPUESTOS DEL PRODUCTO////////////////////////////////////////////
        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    SqlString = "SELECT  Impuestos.Cod_Iva, Impuestos.Descripcion_Iva, Impuestos.Impuesto, Impuestos.TipoImpuesto, ImpuestosProductos.Cod_Productos FROM  ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  " & _
        '    "WHERE  (ImpuestosProductos.Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "ListaImpuestos")
        '    Me.BindingImpuestos.DataSource = DataSet.Tables("ListaImpuestos")
        '    Me.TDGridImpuestos.DataSource = Me.BindingImpuestos
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Width = 94
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Locked = True
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Width = 166
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Locked = True
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Width = 100
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Locked = True
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Width = 100
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Locked = True
        '    Me.TDGridImpuestos.Splits(0).DisplayColumns(4).Visible = False

        '    '//////////////////////////////////////////////////////////////////////////////////////////////
        '    '///////////////BUSCO LOS CODIGOS ALTERNATIVOS/////////////////////////////////////////////////
        '    '/////////////////////////////////////////////////////////////////////////////////////////////

        '    SqlString = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Producto = '" & CodigoProducto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Alternativos")
        '    Me.BindingCodigoAlternos.DataSource = DataSet.Tables("Alternativos")
        '    Me.TdGridAlternativos.DataSource = Me.BindingCodigoAlternos

        '    Me.TdGridAlternativos.Columns(0).Caption = "Codigo Alternos"
        '    Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(0).Width = 100
        '    Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(1).Visible = False
        '    Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(1).Locked = True
        '    Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(2).Width = 350


        '    'Compras = Format(BuscaCompra(CodigoProducto, FechaIni, FechaFin), "####0.00")
        '    'Ventas = Format(BuscaVenta(CodigoProducto, FechaIni, FechaFin), "####0.00")
        '    'Inicial = Format(BuscaInventarioInicial(CodigoProducto, FechaIni), "####0.00")

        '    Me.TxtUbicacion.Text = DataSet.Tables("Producto").Rows(0)("Ubicacion")
        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Inventario")) Then
        '        Me.TxtCtaInventario.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Inventario")
        '    End If

        '    Me.TxtExistenciaUnidades.Text = Format(Existencia, "##,##0.00")
        '    ExistenciaValores = Math.Abs(Existencia * CostoProducto)
        '    Me.TxtExistenciaValores.Text = Format(ExistenciaValores, "##,##0.00")
        '    ExistenciaValoresDolar = Math.Abs(Existencia * CostoProductoD)
        '    Me.TxtExistenciaValoresD.Text = Format(ExistenciaValoresDolar, "##,##0.000")
        '    'Me.TxtCostoPromedio.Text = Format(DataSet.Tables("Producto").Rows(0)("Costo_Promedio"), "##,##0.0000")
        '    Me.TxtCostoPromedio.Text = Format(CostoPromedio(CodigoProducto), "##,##0.000")

        '    '////////BUSCO LA LINEA DEL PRODUCTO//////////
        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Linea")) Then
        '        CodLinea = DataSet.Tables("Producto").Rows(0)("Cod_Linea")
        '    Else
        '        CodLinea = ""
        '    End If
        '    SqlLinea = "SELECT  * FROM Lineas WHERE (Cod_Linea = '" & CodLinea & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
        '    DataAdapter.Fill(DataSet, "LineaProducto")
        '    If Not DataSet.Tables("LineaProducto").Rows.Count = 0 Then
        '        Me.CboLinea.Text = DataSet.Tables("LineaProducto").Rows(0)("Descripcion_Linea")
        '    End If


        '    '////////BUSCO EL RUBRO DEL PRODUCTO//////////
        '    If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Rubro")) Then
        '        CodRubro = DataSet.Tables("Producto").Rows(0)("Cod_Rubro")
        '    Else
        '        CodRubro = ""
        '    End If
        '    SqlLinea = "SELECT  * FROM Rubro WHERE (Codigo_Rubro = '" & CodRubro & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
        '    DataAdapter.Fill(DataSet, "Rubro")
        '    If Not DataSet.Tables("Rubro").Rows.Count = 0 Then
        '        Me.CboRubro.Text = DataSet.Tables("Rubro").Rows(0)("Nombre_Rubro")
        '    End If




        '    '////////BUSCO EL IMPUESTO DEL PRODUCTO///////////////////////
        '    CodImpuesto = DataSet.Tables("Producto").Rows(0)("Cod_Iva")
        '    SqlImpuesto = "SELECT * FROM Impuestos WHERE (Cod_Iva = '" & CodImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlImpuesto, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto")
        '    If Not DataSet.Tables("Impuesto").Rows.Count = 0 Then
        '        Me.CboIva.Text = DataSet.Tables("Impuesto").Rows(0)("Descripcion_Iva")
        '    End If



        '    'If Dir(RutaCompartida) = True Then
        '    '    RutaOrigen = RutaCompartida & "\Fotos\" & Me.CboCodigoProducto.Text & ".bmp"
        '    '    If System.IO.File.Exists(RutaOrigen) = True Then
        '    '        Me.ImgFoto.ImageLocation = RutaOrigen
        '    '    End If
        '    'Else
        '    RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & Me.CboCodigoProducto.Text & ".bmp"
        '    If System.IO.File.Exists(RutaOrigen) = True Then
        '        Me.ImgFoto.ImageLocation = RutaOrigen
        '    End If
        '    'End If
        '    MiConexion.Close()

        '    Exit Sub
        '    'Else

        '    'Dim CodigoAlterno As String = Me.CboCodigoProducto.Text

        '    'SQl = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        '    'DataAdapter.Fill(DataSet, "Alternos")
        '    'If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
        '    '    MsgBox("El Codigo " & CodigoAlterno & " es un Codigo Alternativo de " & DataSet.Tables("Alternos").Rows(0)("Cod_Producto"))
        '    '    Me.CboCodigoProducto.Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
        '    'Else
        '    '    Me.TxtUbicacion.Text = ""
        '    '    Me.TxtCtaInventario.Text = ""
        '    '    Me.TxtNombreProducto.Text = ""
        '    '    Me.CboTipoProducto.Text = ""
        '    '    Me.CboLinea.Text = ""
        '    '    Me.CboUnidad.Text = ""
        '    '    Me.TxtPrecioCompra.Text = ""
        '    '    Me.TxtDescuento.Text = ""
        '    '    Me.CboExistencia.Text = ""
        '    '    Me.TxtCtaCosto.Text = ""
        '    '    Me.TxtPrecioVenta.Text = ""
        '    '    Me.CboIva.Text = ""
        '    '    Me.CboActivo.Text = ""
        '    '    Me.TxtCuentaVenta.Text = ""
        '    '    Me.TxtMinimo.Text = "0.00"
        '    '    Me.TxtReorden.Text = "0.00"
        '    '    CodComponente = 0
        '    'End If

        'End If

        'MiConexion.Close()
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProducto.Text = My.Forms.FrmConsultas.Codigo
        Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoProducto
        Me.TxtNombreProducto.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Try


            Resultado = MsgBox("¿Esta Seguro de Eliminar el Producto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

            If Not Resultado = "6" Then
                Exit Sub
            End If




            SQLProveedor = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Columns(0).Text & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedores")
            If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


                StrSqlUpdate = "DELETE FROM [Productos] WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Columns(0).Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()


            End If

            SQLProveedor = "SELECT Productos.*  FROM Productos"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProductos")
            If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
            End If

            ActualizaComboProducto()
            Me.CboCodigoProducto.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CboLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLinea.TextChanged

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdInventario.Click
        Quien = "CuentaInventario"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaInventario.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub cmdAddDocente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub cmdBorrarDocente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrarFoto.Click
        Dim RutaOrigen As String, Resultado As Double
        Resultado = MsgBox("¿Esta Seguro de Eliminar la Foto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & Me.CboCodigoProducto.Text & ".bmp"
        If System.IO.File.Exists(RutaOrigen) = True Then
            System.IO.File.Delete(RutaOrigen)
            ImgFoto.ImageLocation = ""
            ImgFoto.Refresh()
        Else
            MsgBox("El archivo no Existe", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If
    End Sub

    Private Sub CmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAgregar.Click
        Dim RutaOrigen As String = "", RutaDestino As String
        Dim ancho = 200, alto As Integer = 200


        Me.OpenFileDialog1.ShowDialog()
        RutaOrigen = Me.OpenFileDialog1.FileName.ToString()
        If RutaOrigen = "OpenFileDialog1" Then
            Exit Sub
        End If

        '--------------------------------------VERIFICO EL ANCHO Y ALTO PARA CAMBIARLO -------------------------------
        Dim fs As FileStream = New FileStream(RutaOrigen, FileMode.Open, FileAccess.Read, FileShare.Read)
        Dim LaImagen As System.Drawing.Image
        LaImagen = System.Drawing.Image.FromStream(fs)
        'este calculo es para que la foto no pierda proporciones
        'alto = Math.Floor((100 / LaImagen.Width) * LaImagen.Height)
        alto = 52
        Dim NuevoBitmap As Bitmap = New Bitmap(ancho, alto)
        Dim Graficos As Graphics = Graphics.FromImage(NuevoBitmap)
        Graficos.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        Graficos.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Graficos.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        Dim Rectangulo As Rectangle = New Rectangle(0, 0, ancho, alto)
        Graficos.DrawImage(LaImagen, Rectangulo)



        Me.ImgFoto.ImageLocation = RutaOrigen
        If System.IO.Directory.Exists(RutaCompartida) = True Then
            RutaDestino = RutaCompartida & "\" & Trim(Me.CboCodigoProducto.Text) & ".jpg"
        Else
            RutaDestino = My.Application.Info.DirectoryPath & "\Fotos\" & Trim(Me.CboCodigoProducto.Text) & ".jpg"
        End If



        If System.IO.File.Exists(RutaDestino) = True Then
            System.IO.File.Delete(RutaDestino)
            System.IO.File.Copy(RutaOrigen, RutaDestino)
            'NuevoBitmap.Save(RutaDestino, NuevoBitmap.RawFormat)
            fs.Close()
            fs = Nothing
        Else
            System.IO.File.Copy(RutaOrigen, RutaDestino)
            'NuevoBitmap.Save(RutaDestino, NuevoBitmap.RawFormat)
            fs.Close()
            fs = Nothing
        End If

    End Sub

    Private Sub Button4_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdINgresoAjuste.Click
        Quien = "CuentaIngresoAjuste"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtIngresoAjuste.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdGastosAjuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGastosAjuste.Click
        Quien = "CuentaGastoAjuste"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtGastoAjuste.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button4_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim CodigoBodega As String, CodigoProducto As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, DatasetBodegas As New DataSet

        If Me.CboCodigoProducto.Text = "" Then
            MsgBox("Debe Seleccionar una Bodega", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        CodigoProducto = Me.CboCodigoProducto.Text



        SQL = "SELECT *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "MultiBodega")


        If DatasetBodegas.Tables("MultiBodega").Rows.Count = 0 Then
            MsgBox("Para Agregar una Bodega, es necesario que exista el Producto", MsgBoxStyle.Critical, "Sistema de Factuacion")
            DatasetBodegas.Tables("MultiBodega").Reset()
            Exit Sub
        Else
            DatasetBodegas.Tables("MultiBodega").Reset()
        End If

        Quien = "Bodegas"
        My.Forms.FrmConsultas.ShowDialog()
        CodigoBodega = My.Forms.FrmConsultas.Codigo

        SQL = "SELECT  *  FROM DetalleBodegas WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "Detalles")
        If Not DatasetBodegas.Tables("Detalles").Rows.Count = 0 Then
            '///////////SI EXISTE EL  LO ACTUALIZO////////////////
            MsgBox("Ya Existe esta Bodega relacionada al producto", MsgBoxStyle.Critical, "Sistema Facturacion")

        Else
            MiConexion.Close()
            If CodigoBodega = "-----0-----" Then
                Exit Sub
            End If

            If CodigoProducto <> "" Then
                '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " & _
                               "VALUES('" & CodigoBodega & "','" & CodigoProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

        End If

        ActualizaBodegaProducto()
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim CodigoBodega As String, CodigoProducto As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, DatasetBodegas As New DataSet, ExistenciaBodega As Double

        Resultado = MsgBox("¿Esta Seguro de Eliminar el producto de la bodega?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        If Me.CboCodigoProducto.Text = "" Then
            MsgBox("Debe Seleccionar un Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        CodigoProducto = Me.CboCodigoProducto.Text


        SQL = "SELECT *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "MultiBodega")


        If DatasetBodegas.Tables("MultiBodega").Rows.Count = 0 Then
            MsgBox("Para Agregar un Producto, es necesario que exista la Bodega", MsgBoxStyle.Critical, "Sistema de Factuacion")
            DatasetBodegas.Tables("MultiBodega").Reset()
            Exit Sub
        Else
            DatasetBodegas.Tables("MultiBodega").Reset()
        End If


        CodigoBodega = Me.TrueDBGridConsultas.Columns(0).Text



        SQL = "SELECT  *  FROM DetalleBodegas WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "Detalles")
        If Not DatasetBodegas.Tables("Detalles").Rows.Count = 0 Then
            '///////////SI EXISTE EL  LO ACTUALIZO////////////////

            ExistenciaBodega = DatasetBodegas.Tables("Detalles").Rows(0)("Existencia")

            If ExistenciaBodega <> 0 Then
                MsgBox("No se puede Eliminar una Bodega con Existencia", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            MiConexion.Close()
            If CodigoProducto <> "" Then
                '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                StrSqlUpdate = "DELETE FROM [DetalleBodegas] WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If


        Else

            MsgBox("Ya Existe este Producto en la Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")
        End If

        ActualizaBodegaProducto()
    End Sub

    Private Sub CboTipoProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoProducto.SelectedIndexChanged


        If Me.CboTipoProducto.Text = "Ensambles" Then
            'Me.TabControl.TabPages(3).PageVisible = True
            Me.Componentes.Parent = TabControl

        Else
            'Me.TabControl.TabPages(3).PageVisible = False
            Me.Componentes.Parent = Nothing

        End If
    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate




    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim CodigoProducto As String, SQLComponentes As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Dataset As New DataSet, Recuperable As Boolean = False, Requerido As Double, Desecho As Double


        CodigoProducto = Me.TrueDBGridComponentes.Columns(1).Text
        Requerido = Me.TrueDBGridComponentes.Columns(3).Text
        Recuperable = Me.TrueDBGridComponentes.Columns(4).Text
        Desecho = Me.TrueDBGridComponentes.Columns(5).Text

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////Agrego el Componente al Producto///////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SQLComponentes = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "') AND (Cod_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLComponentes, MiConexion)
        DataAdapter.Fill(Dataset, "Componentes")
        If Not Dataset.Tables("Componentes").Rows.Count = 0 Then
            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "UPDATE [Componentes]  SET [Requerido] = " & Requerido & " ,[Recuperable] = " & Val(Recuperable) & ",[Desecho] = " & Desecho & " " & _
                           "WHERE (Cod_Componente = '" & CodComponente & "') AND (Cod_Producto = '" & CodigoProducto & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
    End Sub

    Private Sub C1TrueDBGrid4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAgregarProducto.Click
        Dim CodigoProducto As String, NombreProducto As String, SQLComponentes As String, SQLProductos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Dataset As New DataSet, Recuperable As Boolean = False


        Quien = "CodigoProductosComponente"
        My.Forms.FrmConsultas.ShowDialog()
        CodigoProducto = My.Forms.FrmConsultas.Codigo
        NombreProducto = My.Forms.FrmConsultas.Descripcion


        If CodComponente = 0 Then
            '/////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////BUSCO EL CONSECUTIVO COMPONENTES/////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////

            SQLComponentes = "SELECT  * FROM  Consecutivos"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLComponentes, MiConexion)
            DataAdapter.Fill(Dataset, "ConsecutivoComponente")
            If Not Dataset.Tables("ConsecutivoComponente").Rows.Count = 0 Then
                CodComponente = Dataset.Tables("ConsecutivoComponente").Rows(0)("Componente") + 1

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////ACTUALIZO EL CONSECUTIVO///////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                MiConexion.Close()
                SQLProductos = "UPDATE [Consecutivos]  SET [Componente] = " & CodComponente & ""
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SQLProductos, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////Agrego el Componente al Producto///////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SQLComponentes = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "') AND (Cod_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLComponentes, MiConexion)
        DataAdapter.Fill(Dataset, "Componentes")
        If Dataset.Tables("Componentes").Rows.Count = 0 Then
            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Componentes] ([Cod_Componente],[Cod_Producto],[Descripcion_Producto],[Requerido],[Recuperable] ,[Desecho]) " & _
                           "VALUES('" & CodComponente & "', '" & CodigoProducto & "', '" & NombreProducto & "',1,0,0.001)"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////ACTUALIZO EL PRODUCTO CON EL COMPONENTE///////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQLProductos = "UPDATE [Productos] SET [CodComponente] = '" & CodComponente & "' WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQLProductos, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()



        Else
            MsgBox("EL PRODUCTO YA EXISTE EN LA LISTA DE COMPONENTES", MsgBoxStyle.Critical, "Sistema de Facturacion")
        End If


        ActualizaComponenteProducto(CodComponente)

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrarComponente.Click
        Dim CodigoProducto As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, DatasetBodegas As New DataSet

        Resultado = MsgBox("¿Esta Seguro de Eliminar el producto de la Lista de Componentes?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        If Me.CboCodigoProducto.Text = "" Then
            MsgBox("Debe Seleccionar un Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        CodigoProducto = Me.TrueDBGridComponentes.Columns(1).Text


        SQL = "SELECT *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "Componentes")


        If DatasetBodegas.Tables("Componentes").Rows.Count = 0 Then
            MsgBox("Para Eliminar el Componente debe existir el producto", MsgBoxStyle.Critical, "Sistema de Factuacion")
            DatasetBodegas.Tables("Componentes").Reset()
            Exit Sub
        Else
            DatasetBodegas.Tables("Componentes").Reset()
        End If


        'CodComponente = Me.TrueDBGridConsultas.Columns(0).Text

        SQL = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "') AND (Cod_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "Detalles")
        If Not DatasetBodegas.Tables("Detalles").Rows.Count = 0 Then
            '///////////SI EXISTE EL  LO ACTUALIZO////////////////
            MiConexion.Close()
            If CodigoProducto <> "" Then
                '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                StrSqlUpdate = "DELETE FROM [Componentes]    WHERE (Cod_Componente = '" & CodComponente & "') AND (Cod_Producto = '" & CodigoProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If


        Else

            MsgBox("Ya Existe este Producto en la Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")
        End If

        ActualizaComponenteProducto(CodComponente)

    End Sub

    Private Sub Componentes_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub TxtPrecioVenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrecioVenta.GotFocus
        Quien = "Cordobas"
    End Sub

    Private Sub TxtPrecioVenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrecioVenta.LostFocus
        Quien = Nothing
    End Sub

    Private Sub TxtPrecioVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecioVenta.TextChanged
        Dim TasaCambio As Double = 0, PrecioVenta As Double = 0

        If Quien = "Dolares" Then
            Exit Sub
        End If

        If Not IsNumeric(Me.TxtPrecioVenta.Text) Then
            MsgBox("El monto Digitado no es Numerico", MsgBoxStyle.Critical, "Zeus Factuacion")
            Exit Sub
        End If

        TasaCambio = BuscaTasaCambio(Now)
        If TasaCambio = 0 Then
            MsgBox("No Existe Tasa de Cambio para Hoy", MsgBoxStyle.Critical, "Zeus Facturacion")
        Else
            PrecioVenta = Me.TxtPrecioVenta.Text
            Me.TxtPrecioCompra.Text = Format(PrecioVenta / TasaCambio, "##,##0.00")
            Quien = "Cordobas"
        End If

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub cmdAddDocente_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddDocente.Click
        Dim CodigoImpuestos As String, DescripcionImpuesto As String, TasaImpuesto As Double, TipoImpuesto As String
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        Quien = "CodigoImpuestos"
        My.Forms.FrmConsultas.ShowDialog()
        CodigoImpuestos = My.Forms.FrmConsultas.Codigo
        DescripcionImpuesto = My.Forms.FrmConsultas.DescripcionImpuestos
        TasaImpuesto = My.Forms.FrmConsultas.TasaImpuestos
        TipoImpuesto = My.Forms.FrmConsultas.TipoImpuesto

        SqlString = "SELECT  Cod_Iva, Cod_Productos FROM ImpuestosProductos WHERE  (Cod_Iva = '" & CodigoImpuestos & "') AND (Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Impuestos")
        If DataSet.Tables("Impuestos").Rows.Count <> 0 Then
            MsgBox("Este impuesto ya fue asignado para este producto", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        Else
            StrSqlUpdate = "INSERT INTO [ImpuestosProductos] ([Cod_Iva],[Cod_Productos]) " & _
                        "VALUES ('" & CodigoImpuestos & "' ,'" & Me.CboCodigoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////BUSCO LOS IMPUESTOS DEL PRODUCTO////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  Impuestos.Cod_Iva, Impuestos.Descripcion_Iva, Impuestos.Impuesto, Impuestos.TipoImpuesto, ImpuestosProductos.Cod_Productos FROM  ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  " & _
        "WHERE  (ImpuestosProductos.Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ListaImpuestos")
        Me.BindingImpuestos.DataSource = DataSet.Tables("ListaImpuestos")
        Me.TDGridImpuestos.DataSource = Me.BindingImpuestos
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Width = 94
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Locked = True
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Width = 166
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Locked = True
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Width = 100
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Locked = True
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Width = 100
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Locked = True
        Me.TDGridImpuestos.Splits(0).DisplayColumns(4).Visible = False





    End Sub

    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim SqlString As String, CodigoImpuestos As String, Respuesta As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        CodigoImpuestos = Me.TDGridImpuestos.Columns(0).Text

        Respuesta = MsgBox("Desea quitar el impuesto del producto?", MsgBoxStyle.YesNo, "Zeus Facturacion")
        If Respuesta <> 6 Then
            Exit Sub
        End If

        StrSqlUpdate = "DELETE FROM [ImpuestosProductos] WHERE (Cod_Iva='" & CodigoImpuestos & "') and (Cod_Productos='" & Me.CboCodigoProducto.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////BUSCO LOS IMPUESTOS DEL PRODUCTO////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  Impuestos.Cod_Iva, Impuestos.Descripcion_Iva, Impuestos.Impuesto, Impuestos.TipoImpuesto, ImpuestosProductos.Cod_Productos FROM  ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  " & _
        "WHERE  (ImpuestosProductos.Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ListaImpuestos")
        Me.BindingImpuestos.DataSource = DataSet.Tables("ListaImpuestos")
        Me.TDGridImpuestos.DataSource = Me.BindingImpuestos
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Width = 94
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Locked = True
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Width = 166
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Locked = True
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Width = 100
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Locked = True
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Width = 100
        Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Locked = True
        Me.TDGridImpuestos.Splits(0).DisplayColumns(4).Visible = False
    End Sub

    Private Sub TxtNombreProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombreProducto.TextChanged
        Me.TxtNombreProducto.Text = Replace(Me.TxtNombreProducto.Text, "'", "")
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CuentaVentas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCuentaVenta.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrecios.Click
        My.Forms.FrmPreciosProductos.CodProducto = Me.CboCodigoProducto.Text
        My.Forms.FrmPreciosProductos.NombreProducto = Me.TxtNombreProducto.Text
        My.Forms.FrmPreciosProductos.ShowDialog()

    End Sub


    Private Sub TdGridAlternativos_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TdGridAlternativos.BeforeColUpdate
        Dim CodigoAlterno As String = Me.TdGridAlternativos.Columns(0).Text
        Dim Sql As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////BUSCO SI EL PRODUCTO EXISTE COMO PRODUCTO /////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodigoAlterno & "') "
        MiConexion.Close()
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If Not DataSet.Tables("Producto").Rows.Count = 0 Then
            MsgBox("Un Codigo Alterno, no puede ser de un Producto Existente!!!", MsgBoxStyle.Critical, "Zeus Facturacion")
            e.Cancel = True
        End If
        MiConexion.Close()

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////BUSCO SI EL PRODUCTO EXISTE COMO PRODUCTO ALTERNO /////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT   * FROM Codigos_Alternos WHERE  (Cod_Alternativo = '" & CodigoAlterno & "') AND (Cod_Producto = '" & Me.CboCodigoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Alternos")
        If DataSet.Tables("Alternos").Rows.Count <> 0 Then
            StrSqlUpdate = "UPDATE Codigos_Alternos SET [Descripcion_Producto] = '" & Me.TdGridAlternativos.Columns(2).Text & "' WHERE (Cod_Alternativo = '" & CodigoAlterno & "') AND (Cod_Producto = '" & Me.CboCodigoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            If Me.CboCodigoProducto.Text <> DataSet.Tables("Alternos").Rows(0)("Cod_Producto") Then
                MsgBox("El codigo Alterno, Existe con Otro Producto. SE ACTUALIZO CON ESTE CODIGO  " & DataSet.Tables("Alternos").Rows(0)("Cod_Producto").ToString, MsgBoxStyle.Information, "Zeus Facturacion")
            End If
        Else
            StrSqlUpdate = "INSERT INTO Codigos_Alternos([Cod_Alternativo],[Cod_Producto],[Descripcion_Producto]) " & _
                           "VALUES ('" & CodigoAlterno & "','" & Me.CboCodigoProducto.Text & "','" & Me.TdGridAlternativos.Columns(1).Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If


    End Sub


    Private Sub TdGridAlternativos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TdGridAlternativos.Click

    End Sub

    Private Sub Button12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrarAlterno.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String
        Dim CodigoAlterno As String = Me.TdGridAlternativos.Columns(0).Text

        Try


            Resultado = MsgBox("¿Esta Seguro de Eliminar el Producto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")
            If Not Resultado = "6" Then
                Exit Sub
            End If

            SQLProveedor = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Alternos")
            If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


                StrSqlUpdate = "DELETE FROM [Codigos_Alternos]  WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()


            End If

            SQLProveedor = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Producto = '" & Me.CboCodigoProducto.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Alternativos")
            Me.BindingCodigoAlternos.DataSource = DataSet.Tables("Alternativos")
            Me.TdGridAlternativos.DataSource = Me.BindingCodigoAlternos

            Me.TdGridAlternativos.Columns(0).Caption = "Codigo Alternos"
            Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(0).Width = 100
            Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(1).Visible = False
            Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(2).Width = 350




        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox.TextChanged
        Dim CodigoProducto As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
        Dim CodLinea As String, SqlLinea As String, CodImpuesto As String, SqlImpuesto As String, RutaOrigen As String
        Dim SqlString As String, Existencia As Double, iPosicionFila As Double, CodigoBodega As String
        Dim ExistenciaValores As Double, ExistenciaValoresDolar As Double, CodRubro As String, ExistenciaBodega As Double
        Dim StrSQLUpdate As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim iResultado As Integer, CostoProducto As Double = 0, CostoProductoD As Double = 0
        Dim DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String

        SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & TextBox.Text & "') "
        MiConexion.Close()
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If DataSet.Tables("Producto").Rows.Count = 0 Then


            Dim CodigoAlterno As String = Me.CboCodigoProducto.Text

            SQl = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
            DataAdapter.Fill(DataSet, "Alternos")
            If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
                MsgBox("El Codigo " & CodigoAlterno & " es un Codigo Alternativo de " & DataSet.Tables("Alternos").Rows(0)("Cod_Producto"))
                Me.CboCodigoProducto.Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
            Else
                Me.TxtMerma.Text = ""
                Me.TxtDesperdicio.Text = ""
                Me.TxtUbicacion.Text = ""
                Me.TxtCtaInventario.Text = ""
                Me.TxtNombreProducto.Text = ""
                'Me.CboTipoProducto.Text = ""
                Me.CboLinea.Text = ""
                Me.CboUnidad.Text = ""
                Me.TxtPrecioCompra.Text = "0.00"
                Me.TxtDescuento.Text = ""
                Me.CboExistencia.Text = ""
                Me.TxtCtaCosto.Text = ""
                Me.TxtPrecioVenta.Text = "0.00"
                Me.CboIva.Text = ""
                Me.CboActivo.Text = ""
                Me.TxtCuentaVenta.Text = ""
                Me.TxtMinimo.Text = "0.00"
                Me.TxtReorden.Text = "0.00"
                CodComponente = 0

                'If Me.CboCodigoProducto.Text = "" Then
                Me.TxtUbicacion.Text = ""
                'Me.TxtCtaInventario.Text = ""
                Me.TxtNombreProducto.Text = ""
                'Me.CboTipoProducto.Text = ""
                Me.CboLinea.Text = ""
                Me.CboUnidad.Text = ""
                Me.TxtPrecioCompra.Text = "0.00"
                Me.TxtDescuento.Text = "0.00"
                Me.CboExistencia.Text = ""
                Me.TxtCtaCosto.Text = ""
                Me.TxtPrecioVenta.Text = "0.00"
                Me.CboIva.Text = ""
                Me.CboActivo.Text = ""
                'Me.TxtCuentaVenta.Text = ""
                Me.TxtMinimo.Text = "0.00"
                Me.TxtReorden.Text = "0.00"
                CodComponente = 0
                Me.TxtAumento.Value = "0.00"

                Me.CboTipoProducto.Text = "Productos"
                Me.CboActivo.Text = "Activo"
                Me.CboExistencia.Text = "NO"
                If ExisteConexion = True Then
                    Me.TxtCtaCosto.Text = BuscaPrimerCuentaContable("Costos")
                    Me.TxtCtaInventario.Text = BuscaPrimerCuentaContable("Inventario")
                    Me.TxtCuentaVenta.Text = BuscaPrimerCuentaContable("Ingresos - Ventas")
                    Me.TxtIngresoAjuste.Text = BuscaPrimerCuentaContable("Ingresos - Ventas")
                    Me.TxtGastoAjuste.Text = BuscaPrimerCuentaContable("Gastos")
                Else
                    Me.TxtCtaCosto.Text = "4101"
                    Me.TxtCtaInventario.Text = "1141"
                    Me.TxtCuentaVenta.Text = "4101"
                    Me.TxtIngresoAjuste.Text = "4101"
                    Me.TxtGastoAjuste.Text = "5101"
                End If


                '/////////////////////////////////LINEA DE PRODUCTOS ///////////////////////////////////////////////////////////////
                SqlString = "SELECT * FROM Lineas "
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapterProductos.Fill(DataSet, "LineaProductos")
                Me.CboLinea.DataSource = DataSet.Tables("LineaProductos")
                If DataSet.Tables("LineaProductos").Rows.Count <> 0 Then
                    Me.CboLinea.Text = DataSet.Tables("LineaProductos").Rows(0)("Descripcion_Linea")
                End If
                Me.CboLinea.DisplayMember = "Descripcion_Linea"

                SqlString = "SELECT * FROM Impuestos"
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapterProductos.Fill(DataSet, "Impuestos")
                Me.CboIva.DataSource = DataSet.Tables("Impuestos")
                If DataSet.Tables("Impuestos").Rows.Count <> 0 Then
                    Me.CboIva.Text = DataSet.Tables("Impuestos").Rows(0)("Descripcion_Iva")
                End If
                Me.CboIva.DisplayMember = "Descripcion_Iva"

                SqlProductos = "SELECT  * FROM  Rubro"
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapterProductos.Fill(DataSet, "Rubros")
                If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
                    Me.CboRubro.DataSource = DataSet.Tables("Rubros")
                    Me.CboRubro.Text = DataSet.Tables("Rubros").Rows(0)("Nombre_Rubro")
                End If

                '/////////////////////////////////////////UNIDAD DE MEDIDA /////////////////////////////////////////////////////////////
                SqlProductos = "SELECT DISTINCT Unidad_Medida FROM UnidadMedidaProductos  WHERE (Unidad_Medida <> ' ') AND (Unidad_Medida <> '0') UNION SELECT DISTINCT Unidad_Medida FROM Productos WHERE (Unidad_Medida <> ' ') AND (Unidad_Medida <> '0') ORDER BY Unidad_Medida"
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapterProductos.Fill(DataSet, "UNIDAD")
                Me.CboUnidad.DataSource = DataSet.Tables("UNIDAD")
                If Not DataSet.Tables("UNIDAD").Rows.Count = 0 Then
                    Me.CboUnidad.Text = DataSet.Tables("UNIDAD").Rows(0)("Unidad_Medida")
                    Me.LblUnidadMedida.Text = DataSet.Tables("UNIDAD").Rows(0)("Unidad_Medida")
                End If
                Me.CboUnidad.DisplayMember = "Unidad_Medida"

                SqlString = "SELECT Cod_Productos, Unidad_Medida, Cantidad_Unidades, Precio_Unitario, Unidad_Defecto FROM UnidadMedidaProductos WHERE (Cod_Productos = '-10000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                ds = New DataSet
                da = New SqlDataAdapter(SqlString, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "UnidadMedida")
                Me.tdbGridUnidadMedida.DataSource = ds.Tables("UnidadMedida")
                Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cod_Productos").Visible = False
                Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Medida").Width = 100
                Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cantidad_Unidades").Button = True
                Me.tdbGridUnidadMedida.Columns("Unidad_Medida").Caption = "Unidad Medida"
                Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cantidad_Unidades").Width = 100
                Me.tdbGridUnidadMedida.Columns("Cantidad_Unidades").Caption = "Cant Unidades"
                Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 100
                Me.tdbGridUnidadMedida.Columns("Precio_Unitario").Caption = "Precio Unitario"
                Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Defecto").Width = 100
                Me.tdbGridUnidadMedida.Columns("Unidad_Defecto").Caption = "Defecto"

                Exit Sub

            End If
        Else   'If Not DataSet.Tables("Producto").Rows.Count = 0 Then

            CodigoProducto = Me.TextBox.Text
            'ActualizaCostoPromedio(CodigoProducto)

            If CodigoProducto = "26188" Then
                CodigoProducto = "26188"
            End If

            'SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "') "
            'MiConexion.Close()
            'MiConexion.Open()
            'DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
            'DataAdapter.Fill(DataSet, "Producto")
            'If Not DataSet.Tables("Producto").Rows.Count = 0 Then
            CodComponente = DataSet.Tables("Producto").Rows(0)("CodComponente")
            'CostoPromedio = DataSet.Tables("Producto").Rows(0)("Costo_Promedio")

            Me.TxtNombreProducto.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
            Me.CboTipoProducto.Text = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
            Me.CboUnidad.Text = DataSet.Tables("Producto").Rows(0)("Unidad_Medida")
            Me.LblUnidadMedida.Text = DataSet.Tables("Producto").Rows(0)("Unidad_Medida")
            Me.TxtPrecioCompra.Text = DataSet.Tables("Producto").Rows(0)("Precio_Lista")
            Me.TxtDescuento.Text = DataSet.Tables("Producto").Rows(0)("Descuento")
            Me.CboExistencia.Text = DataSet.Tables("Producto").Rows(0)("Existencia_Negativa")
            Me.TxtCtaCosto.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Costo")
            Me.TxtPrecioVenta.Text = DataSet.Tables("Producto").Rows(0)("Precio_Venta")
            Me.CboActivo.Text = DataSet.Tables("Producto").Rows(0)("Activo")
            Me.TxtCuentaVenta.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Ventas")
            Me.TxtUltimoPrecioCompra.Text = Format(DataSet.Tables("Producto").Rows(0)("Ultimo_Precio_Compra"), "##,##0.00")
            Me.TxtCostoPromedioDolar.Text = Format(DataSet.Tables("Producto").Rows(0)("Costo_Promedio_Dolar"), "##,##0.000")
            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Porcentaje_Aumento")) Then
                Me.TxtAumento.Value = Format(DataSet.Tables("Producto").Rows(0)("Porcentaje_Aumento"), "##,##0.00")
            End If



            If Me.CboTipoProducto.Text = "Ensambles" Then
                Me.Componentes.Parent = TabControl
            End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Rendimiento")) Then
                Me.TxtRendimiento.Text = DataSet.Tables("Producto").Rows(0)("Rendimiento")
            End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Minimo")) Then
                Me.TxtMinimo.Text = Val(DataSet.Tables("Producto").Rows(0)("Minimo"))
            Else
                Me.TxtMinimo.Text = "0.00"
            End If
            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Reorden")) Then
                Me.TxtReorden.Text = DataSet.Tables("Producto").Rows(0)("Reorden")
            Else
                Me.TxtReorden.Text = "0.00"
            End If
            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Nota")) Then
                Me.TxtNota.Text = DataSet.Tables("Producto").Rows(0)("Nota")
            End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_GastoAjuste")) Then
                Me.TxtGastoAjuste.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_GastoAjuste")
            End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_IngresoAjuste")) Then
                Me.TxtIngresoAjuste.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_IngresoAjuste")
            End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Merma")) Then
                Me.TxtMerma.Text = DataSet.Tables("Producto").Rows(0)("Merma")
            Else
                Me.TxtMerma.Text = "0.00"
            End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Desperdicio")) Then
                Me.TxtDesperdicio.Text = DataSet.Tables("Producto").Rows(0)("Desperdicio")
            Else
                Me.TxtDesperdicio.Text = "0.00"
            End If

            CostoProducto = CostoPromedio(CodigoProducto)
            CostoProductoD = CostoPromedioDolar



            '//////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////BUSCO LAS BODEGAS DEL PRODUCTO/////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
                        "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas")

            '//////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////
            Existencia = 0
            iPosicionFila = 0
            Do While iPosicionFila < (DataSet.Tables("Bodegas").Rows.Count)
                My.Application.DoEvents()
                CodigoBodega = DataSet.Tables("Bodegas").Rows(iPosicionFila)("Cod_Bodegas")


                ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)
                'ExistenciaBodega = BuscaExistenciaBodegaLote(CodigoProducto, CodigoBodega)
                Existencia = Existencia + ExistenciaBodega
                MiConexion.Close()

                '///////////ACTUALIZO LA EXISTENCIA PARA CADA BODEGA ////////////////////////////////////////
                StrSQLUpdate = "UPDATE [DetalleBodegas]  SET [Existencia] = '" & ExistenciaBodega & "', [Costo] = '" & CostoProducto & "'  WHERE (Cod_Productos = '" & CodigoProducto & "') AND (Cod_Bodegas = '" & CodigoBodega & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSQLUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()


                iPosicionFila = iPosicionFila + 1
            Loop



            DataSet.Tables("Bodegas").Reset()
            SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia,DetalleBodegas.Costo FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
                        "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas")
            '//////////////////////////////////////////////////////CARGO LAS EXISTENCIAS DE BODEGAS /////////////////////////////
            Me.BindingBodegas.DataSource = DataSet.Tables("Bodegas")
            Me.TrueDBGridConsultas.DataSource = Me.BindingBodegas
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 80
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 70
            Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 70
            Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"

            Select Case Acceso
                Case "Vendedores"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False

            End Select


            '///////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////CARGO LOS HISTORICOS DE VENTAS/////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  Facturas.Numero_Factura, Facturas.Tipo_Factura, Facturas.Fecha_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente,  Detalle_Facturas.Cantidad, Detalle_Facturas.Precio_Unitario FROM   Facturas INNER JOIN  Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura And Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura  " & _
                        "WHERE (Facturas.Tipo_Factura <> 'Cotizacion') AND (Detalle_Facturas.Cod_Producto = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Ventas")
            Me.BindingHistoricosVentas.DataSource = DataSet.Tables("Ventas")
            Me.TruDbGridHistoricosVentas.DataSource = Me.BindingHistoricosVentas
            Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(0).Width = 111
            Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(2).Width = 91
            Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(3).Width = 271
            Me.TruDbGridHistoricosVentas.Splits.Item(0).DisplayColumns(4).Width = 100
            Me.TruDbGridHistoricosVentas.Columns(3).NumberFormat = "##,##0.00"

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////CARGO LOS HISTORICOS DE COMPRAS/////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT Compras.Numero_Compra, Compras.Tipo_Compra,Compras.Fecha_Compra, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres,  Detalle_Compras.Cantidad, Detalle_Compras.Precio_Unitario FROM Compras INNER JOIN Proveedor ON Compras.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN Detalle_Compras ON Compras.Numero_Compra = Detalle_Compras.Numero_Compra AND Compras.Fecha_Compra = Detalle_Compras.Fecha_Compra And Compras.Tipo_Compra = Detalle_Compras.Tipo_Compra  " & _
                        "WHERE (Detalle_Compras.Cod_Producto = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Compras")
            Me.BindingHistoricoCompras.DataSource = DataSet.Tables("Compras")
            Me.TruDbGridHistoricosCompras.DataSource = Me.BindingHistoricoCompras
            Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(0).Width = 111
            Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(2).Width = 91
            Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(3).Width = 271
            Me.TruDbGridHistoricosCompras.Splits.Item(0).DisplayColumns(4).Width = 100
            Me.TruDbGridHistoricosCompras.Columns(3).NumberFormat = "##,##0.00"


            If Me.CboTipoProducto.Text = "Ensambles" Then
                '//////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////BUSCO LOS COMPONENTES DEL PRODUCTO/////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////
                Me.Componentes.Parent = Me.TabControl
                SqlString = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Componentes")
                Me.BindingComponentes.DataSource = DataSet.Tables("Componentes")
                Me.TrueDBGridComponentes.DataSource = Me.BindingComponentes

                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Visible = False
                Me.TrueDBGridComponentes.Columns(1).Caption = "Componente"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 74
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 182
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 62
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 68
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 74

            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////BUSCO LOS IMPUESTOS DEL PRODUCTO////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  Impuestos.Cod_Iva, Impuestos.Descripcion_Iva, Impuestos.Impuesto, Impuestos.TipoImpuesto, ImpuestosProductos.Cod_Productos FROM  ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  " & _
            "WHERE  (ImpuestosProductos.Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ListaImpuestos")
            Me.BindingImpuestos.DataSource = DataSet.Tables("ListaImpuestos")
            Me.TDGridImpuestos.DataSource = Me.BindingImpuestos
            If DataSet.Tables("ListaImpuestos").Rows.Count <> 0 Then

                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Width = 94
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(0).Locked = True
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Width = 166
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(1).Locked = True
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Width = 100
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(2).Locked = True
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Width = 100
                Me.TDGridImpuestos.Splits(0).DisplayColumns.Item(3).Locked = True
                Me.TDGridImpuestos.Splits(0).DisplayColumns(4).Visible = False
            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////BUSCO LOS CODIGOS ALTERNATIVOS/////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Producto = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Alternativos")
            Me.BindingCodigoAlternos.DataSource = DataSet.Tables("Alternativos")
            Me.TdGridAlternativos.DataSource = Me.BindingCodigoAlternos

            Me.TdGridAlternativos.Columns(0).Caption = "Codigo Alternos"
            Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(0).Width = 100
            Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(1).Visible = False
            Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(1).Locked = True
            Me.TdGridAlternativos.Splits.Item(0).DisplayColumns(2).Width = 350

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////BUSCO LAS UNIDADES DE MEDIDA DE LA TABLA/////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT Cod_Productos, Unidad_Medida, Cantidad_Unidades, Precio_Unitario, Unidad_Defecto FROM UnidadMedidaProductos WHERE (Cod_Productos = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "UnidadMedida")
            Me.tdbGridUnidadMedida.DataSource = ds.Tables("UnidadMedida")
            Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cod_Productos").Visible = False
            Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Medida").Width = 100
            Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Medida").Button = True
            Me.tdbGridUnidadMedida.Columns("Unidad_Medida").Caption = "Unidad Medida"
            Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Cantidad_Unidades").Width = 100
            Me.tdbGridUnidadMedida.Columns("Cantidad_Unidades").Caption = "Cant Unidades"
            Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Precio_Unitario").Width = 100
            Me.tdbGridUnidadMedida.Columns("Precio_Unitario").Caption = "Precio Unitario"
            Me.tdbGridUnidadMedida.Splits.Item(0).DisplayColumns("Unidad_Defecto").Width = 100
            Me.tdbGridUnidadMedida.Columns("Unidad_Defecto").Caption = "Defecto"


            Me.TxtUbicacion.Text = DataSet.Tables("Producto").Rows(0)("Ubicacion")
            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Inventario")) Then
                Me.TxtCtaInventario.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_Inventario")
            End If

            Me.TxtExistenciaUnidades.Text = Format(Existencia, "##,##0.00")
            ExistenciaValores = Math.Abs(Existencia * CostoProducto)
            Me.TxtExistenciaValores.Text = Format(ExistenciaValores, "##,##0.00")
            ExistenciaValoresDolar = Math.Abs(Existencia * CostoProductoD)
            Me.TxtExistenciaValoresD.Text = Format(ExistenciaValoresDolar, "##,##0.000")
            'Me.TxtCostoPromedio.Text = Format(DataSet.Tables("Producto").Rows(0)("Costo_Promedio"), "##,##0.0000")
            Me.TxtCostoPromedio.Text = Format(CostoProducto, "##,##0.000")
            Me.TxtCostoPromedioDolar.Text = Format(CostoProductoD, "##,##0.000")

            '////////BUSCO LA LINEA DEL PRODUCTO//////////
            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Linea")) Then
                CodLinea = DataSet.Tables("Producto").Rows(0)("Cod_Linea")
            Else
                CodLinea = ""
            End If
            SqlLinea = "SELECT  * FROM Lineas WHERE (Cod_Linea = '" & CodLinea & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
            DataAdapter.Fill(DataSet, "LineaProducto")
            If Not DataSet.Tables("LineaProducto").Rows.Count = 0 Then
                Me.CboLinea.Text = DataSet.Tables("LineaProducto").Rows(0)("Descripcion_Linea")
            End If


            '////////BUSCO EL RUBRO DEL PRODUCTO//////////
            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Rubro")) Then
                CodRubro = DataSet.Tables("Producto").Rows(0)("Cod_Rubro")
            Else
                CodRubro = ""
            End If
            SqlLinea = "SELECT  * FROM Rubro WHERE (Codigo_Rubro = '" & CodRubro & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlLinea, MiConexion)
            DataAdapter.Fill(DataSet, "Rubro")
            If Not DataSet.Tables("Rubro").Rows.Count = 0 Then
                Me.CboRubro.Text = DataSet.Tables("Rubro").Rows(0)("Nombre_Rubro")
            End If




            '////////BUSCO EL IMPUESTO DEL PRODUCTO///////////////////////
            CodImpuesto = DataSet.Tables("Producto").Rows(0)("Cod_Iva")
            SqlImpuesto = "SELECT * FROM Impuestos WHERE (Cod_Iva = '" & CodImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlImpuesto, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto")
            If Not DataSet.Tables("Impuesto").Rows.Count = 0 Then
                Me.CboIva.Text = DataSet.Tables("Impuesto").Rows(0)("Descripcion_Iva")
            End If

            RutaOrigen = RutaCompartida & "\" & Trim(Me.CboCodigoProducto.Text) & ".jpg"

            'If Dir(RutaCompartida, FileAttribute.Directory) <> "" Then
            If System.IO.Directory.Exists(RutaCompartida) = True Then
                RutaOrigen = RutaCompartida & "\" & Trim(Me.CboCodigoProducto.Text) & ".jpg"
                If Dir(RutaOrigen) <> "" Then
                    Me.ImgFoto.ImageLocation = RutaOrigen
                Else
                    RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & Me.CboCodigoProducto.Text & ".jpg"
                    If System.IO.File.Exists(RutaOrigen) = True Then
                        Me.ImgFoto.ImageLocation = RutaOrigen
                    End If
                End If
            Else
                RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & Me.CboCodigoProducto.Text & ".jpg"
                If System.IO.File.Exists(RutaOrigen) = True Then
                    Me.ImgFoto.ImageLocation = RutaOrigen
                End If
            End If

            MiConexion.Close()

            Exit Sub
            'Else

            'Dim CodigoAlterno As String = Me.CboCodigoProducto.Text

            'SQl = "SELECT  *  FROM Codigos_Alternos WHERE (Cod_Alternativo = '" & CodigoAlterno & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
            'DataAdapter.Fill(DataSet, "Alternos")
            'If Not DataSet.Tables("Alternos").Rows.Count = 0 Then
            '    MsgBox("El Codigo " & CodigoAlterno & " es un Codigo Alternativo de " & DataSet.Tables("Alternos").Rows(0)("Cod_Producto"))
            '    Me.CboCodigoProducto.Text = DataSet.Tables("Alternos").Rows(0)("Cod_Producto")
            'Else
            '    Me.TxtUbicacion.Text = ""
            '    Me.TxtCtaInventario.Text = ""
            '    Me.TxtNombreProducto.Text = ""
            '    Me.CboTipoProducto.Text = ""
            '    Me.CboLinea.Text = ""
            '    Me.CboUnidad.Text = ""
            '    Me.TxtPrecioCompra.Text = ""
            '    Me.TxtDescuento.Text = ""
            '    Me.CboExistencia.Text = ""
            '    Me.TxtCtaCosto.Text = ""
            '    Me.TxtPrecioVenta.Text = ""
            '    Me.CboIva.Text = ""
            '    Me.CboActivo.Text = ""
            '    Me.TxtCuentaVenta.Text = ""
            '    Me.TxtMinimo.Text = "0.00"
            '    Me.TxtReorden.Text = "0.00"
            '    CodComponente = 0
            'End If

        End If

        'Me.TabControl.TabPages(3).PageVisible = False
        'Me.TabControl.TabPages.Remove(Me.TabControl.TabPages(3))
        'Me.TabControl.TabPages(3).Parent = Nothing


        MiConexion.Close()
        Quien = Nothing

    End Sub

    Private Sub Button12_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGenerar.Click
        Dim SqlDatos As String = "", CodLinea As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, Registro As Double
        Dim CodigoProducto As Double

        CodLinea = Me.CboLinea.Columns(0).Text

        SqlDatos = "SELECT Productos.* FROM Productos WHERE (Cod_Linea = '" & CodLinea & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Codigo")

        If Not DataSet.Tables("Codigo").Rows.Count = 0 Then
            Registro = DataSet.Tables("Codigo").Rows.Count
            If IsNumeric(DataSet.Tables("Codigo").Rows(Registro - 1)("Cod_Productos")) Then
                CodigoProducto = DataSet.Tables("Codigo").Rows(Registro - 1)("Cod_Productos") + 1
            End If

        Else
            CodigoProducto = CodLinea & "001"

        End If

        Me.CboCodigoProducto.Text = CodigoProducto

    End Sub

    Private Sub TxtPrecioCompra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrecioCompra.GotFocus
        Quien = "Dolares"
    End Sub

    Private Sub TxtPrecioCompra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrecioCompra.LostFocus
        Quien = Nothing
    End Sub

    Private Sub TxtPrecioCompra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecioCompra.TextChanged
        Dim TasaCambio As Double = 0, PrecioVenta As Double = 0

        If Quien = "Cordobas" Then
            Exit Sub
        End If

        If Me.TxtPrecioCompra.Text = "" Then
            Me.TxtPrecioCompra.Text = "0.00"
        End If

        If Not IsNumeric(Me.TxtPrecioCompra.Text) Then
            MsgBox("El monto Digitado no es Numerico", MsgBoxStyle.Critical, "Zeus Factuacion")
            Exit Sub
        End If

        TasaCambio = BuscaTasaCambio(Now)
        If TasaCambio = 0 Then
            MsgBox("No Existe Tasa de Cambio para Hoy", MsgBoxStyle.Critical, "Zeus Facturacion")
        Else
            PrecioVenta = Me.TxtPrecioCompra.Text
            Me.TxtPrecioVenta.Text = Format(PrecioVenta * TasaCambio, "##,##0.00")
            Quien = "Dolares"
        End If
    End Sub

    Private Sub tdbGridUnidadMedida_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs)
        InsertarRowGridIngresos(Me.TextBox.Text, Me.tdbGridUnidadMedida.Columns("Unidad_Medida").Text)
    End Sub

    Private Sub tdbGridUnidadMedida_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs)
        If Me.TextBox.Text = "" Then
            MsgBox("Necesita Seleccionar un Producto", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Me.tdbGridUnidadMedida.Columns("Cod_Productos").Text = Me.TextBox.Text
    End Sub

    Private Sub TDGridImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridImpuestos.Click

    End Sub

    Private Sub tdbGridUnidadMedida_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs)
        If Me.TextBox.Text = "" Then
            MsgBox("Necesita Seleccionar un Producto", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Quien = "UnidadMedida"
        My.Forms.FrmConsultas.CodProducto = Me.TextBox.Text
        My.Forms.FrmConsultas.ShowDialog()

        If ExisteUnidadMedida(Me.TextBox.Text, My.Forms.FrmConsultas.Descripcion) = True Then
            MsgBox("Esta unidad de Medida esta Asignada", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If
        Me.tdbGridUnidadMedida.Columns("Unidad_Medida").Text = My.Forms.FrmConsultas.Descripcion
        Me.tdbGridUnidadMedida.Columns("Cod_Productos").Text = Me.TextBox.Text
    End Sub


    Private Sub tdbGridUnidadMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button12_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Resultado As Double, CodProducto As String, iPosicion As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim idDetalle As Double, NombreProducto As String, Descuento As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaFactura As String, oDataRow As DataRow, oTablaBorrados As DataTable
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroFactura As String

        Try

            Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

            If Not Resultado = "6" Then
                Exit Sub
            End If





            CodProducto = Me.TrueDBGridComponentes.Columns(0).Text

            Bitacora(Now, NombreUsuario, Me.CboTipoProducto.Text, "Se elimino Producto: " & CodProducto & " " & Me.TextBox.Text)

            iPosicion = Me.tdbGridUnidadMedida.Row

            If Me.tdbGridUnidadMedida.RowCount <> 0 Then

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                oDataRow = ds.Tables("UnidadMedida").Rows(iPosicion)
                oDataRow.Delete()

                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
                oTablaBorrados = ds.Tables("UnidadMedida").GetChanges(DataRowState.Deleted)
                If Not IsNothing(oTablaBorrados) Then
                    '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
                    da.Update(oTablaBorrados)
                End If
                ds.Tables("UnidadMedida").AcceptChanges()
                da.Update(ds.Tables("UnidadMedida"))



            End If




        Catch ex As Exception
            MsgBox("Para borrar es necesario Grabar" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        My.Forms.FrmPreciosProductos.ValidarRegistros = True
        My.Forms.FrmPreciosProductos.CodProducto = Me.CboCodigoProducto.Text
        My.Forms.FrmPreciosProductos.NombreProducto = Me.TxtNombreProducto.Text
        My.Forms.FrmPreciosProductos.ShowDialog()
    End Sub
End Class
