Imports System.Data.SqlClient

Public Class FrmLiquidacion
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder, EsSolicitud As Boolean = False
    Public MiConexion As New SqlClient.SqlConnection(Conexion), TotalFob As Double, TotalCosto As Double, FacturaLotes As Boolean = False
    Public DatasetLiquidacion As New DataSet
    Public Sub InsertarRowGrid()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridComponentes.Row
        CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("DetalleCompra").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("DetalleCompra").AcceptChanges()
            da.Update(ds.Tables("DetalleCompra"))



            Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = ds.Tables("DetalleCompra").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("DetalleCompra").AcceptChanges()
                da.Update(ds.Tables("DetalleCompra"))
            End If
        End If

        ActualizarGridInsertRow()



    End Sub
    Public Sub ActualizarGridInsertRow()
        Dim SqlCompras As String, TipoCompra As String, SqlString As String
        Dim Fecha As String

        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")


        If FacturaLotes = False Then

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE LIQUIDACION/////////////////////////////////////////////////////////////////
            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Detalle_Liquidacion.Cod_Producto, Detalle_Liquidacion.Descripcion_Producto, Detalle_Liquidacion.Cantidad, Detalle_Liquidacion.Precio_Compra, Detalle_Liquidacion.Peso_Compra, Detalle_Liquidacion.FOB,Detalle_Liquidacion.Gasto_Compra,Detalle_Liquidacion.Gasto_Impuesto, Detalle_Liquidacion.Precio_Costo, Detalle_Liquidacion.Numero_Liquidacion, Detalle_Liquidacion.Fecha_Liquidacion, Detalle_Liquidacion.Id_Detalle_Liquidacion  FROM Detalle_Liquidacion WHERE (Detalle_Liquidacion.Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Liquidacion.Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102))"
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleCompra")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
            Me.TrueDBGridComponentes.Columns("Peso_Compra").Caption = "Peso"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Peso_Compra").Width = 64
            Me.TrueDBGridComponentes.Columns("Precio_Compra").Caption = "Precio Comp"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Width = 70
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Locked = False
            Me.TrueDBGridComponentes.Columns("FOB").Caption = "FOB"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Locked = True
            Me.TrueDBGridComponentes.Columns("Gasto_Compra").Caption = "Gastos"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Compra").Width = 65
            Me.TrueDBGridComponentes.Columns("Gasto_Impuesto").Caption = "Gtos Imptos"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Impuesto").Width = 65
            Me.TrueDBGridComponentes.Columns("Precio_Costo").Caption = "Precio Costo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Width = 70
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Locked = True

            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Liquidacion").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Liquidacion").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_Detalle_Liquidacion").Visible = False
            'Me.TrueDBGridComponentes.Columns(7).NumberFormat = "##,##0.00"

        Else

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////CARGO EL DETALLE DE LIQUIDACION/////////////////////////////////////////////////////////////////
            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT Detalle_Liquidacion.Cod_Producto, Detalle_Liquidacion.Descripcion_Producto, Detalle_Liquidacion.Cantidad, Detalle_Liquidacion.Precio_Compra, Detalle_Liquidacion.Peso_Compra, Detalle_Liquidacion.FOB,Detalle_Liquidacion.Gasto_Compra,Detalle_Liquidacion.Gasto_Impuesto, Detalle_Liquidacion.Precio_Costo, Detalle_Liquidacion.Numero_Lote, Detalle_Liquidacion.Fecha_Vence, Detalle_Liquidacion.Numero_Liquidacion, Detalle_Liquidacion.Fecha_Liquidacion, Detalle_Liquidacion.Id_Detalle_Liquidacion FROM Detalle_Liquidacion WHERE (Detalle_Liquidacion.Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Liquidacion.Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102))"
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleCompra")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Numero_Lote").Caption = "Lotes"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Width = 64
            Me.TrueDBGridComponentes.Columns("Fecha_Vence").Caption = "Fecha Vence"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Width = 70
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
            Me.TrueDBGridComponentes.Columns("Peso_Compra").Caption = "Peso"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Peso_Compra").Width = 64
            Me.TrueDBGridComponentes.Columns("Precio_Compra").Caption = "Precio Comp"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Width = 70
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Locked = False
            Me.TrueDBGridComponentes.Columns("FOB").Caption = "FOB"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Locked = True
            Me.TrueDBGridComponentes.Columns("Gasto_Compra").Caption = "Gastos"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Compra").Width = 65
            Me.TrueDBGridComponentes.Columns("Gasto_Impuesto").Caption = "Gtos Imptos"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Impuesto").Width = 65
            Me.TrueDBGridComponentes.Columns("Precio_Costo").Caption = "Precio Costo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Width = 70
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Locked = True

            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Liquidacion").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Liquidacion").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_Detalle_Liquidacion").Visible = False


        End If

    End Sub




    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TxtCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TxtNombres.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                Me.TxtApellidos.Text = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
            End If

        Else

            Me.TxtNombres.Text = ""
            Me.TxtApellidos.Text = ""


        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Quien = "CuentasPagarCompras"
        My.Forms.FrmConsultas.ShowDialog()
    End Sub

    Private Sub FrmLiquidacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Liquidacion")
    End Sub

    Private Sub FrmLiquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlImpuestos As String
        Dim SqlString As String, SqlDatos As String


        Me.CmbImpuesto.Text = "Dolares"
        Me.CmbMoneda.Text = "Dolares"
        Me.CmbGastos.Text = "Dolares"
        Me.TxtISC.Text = ""
        Me.TxtIVA.Text = ""
        Me.TxtDAI.Text = ""

        Me.TxtTasaCambio.Text = BuscaTasaCambio(Me.DTPFecha.Value)

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  * FROM   Bodegas"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Bodegas")
        Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
        If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
            Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
        End If
        Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
        Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LOS IMPUESTOS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlImpuestos = "SELECT Cod_Iva, Descripcion_Iva FROM Impuestos"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlImpuestos, MiConexion)
        DataAdapter.Fill(DataSet, "ImpuestosSeguro")
        If Not DataSet.Tables("ImpuestosSeguro").Rows.Count = 0 Then
            'Me.CmbSeguro.DataSource = DataSet.Tables("ImpuestosSeguro")
            'Me.CmbSeguro.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosTransporte")
        If Not DataSet.Tables("ImpuestosTransporte").Rows.Count = 0 Then
            'Me.CmbTransporte.DataSource = DataSet.Tables("ImpuestosTransporte")
            'Me.CmbTransporte.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosAlmacen")
        If Not DataSet.Tables("ImpuestosAlmacen").Rows.Count = 0 Then
            'Me.CmbAlmacen.DataSource = DataSet.Tables("ImpuestosAlmacen")
            'Me.CmbAlmacen.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosIVA")
        If Not DataSet.Tables("ImpuestosIVA").Rows.Count = 0 Then
            'Me.CmbIVA.DataSource = DataSet.Tables("ImpuestosIVA")
            'Me.CmbIVA.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosDAI")
        If Not DataSet.Tables("ImpuestosDAI").Rows.Count = 0 Then
            'Me.CmbDAI.DataSource = DataSet.Tables("ImpuestosDAI")
            'Me.CmbDAI.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosIEC")
        If Not DataSet.Tables("ImpuestosIEC").Rows.Count = 0 Then
            'Me.CmbIEC.DataSource = DataSet.Tables("ImpuestosIEC")
            'Me.CmbIEC.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosFletes")
        If Not DataSet.Tables("ImpuestosFletes").Rows.Count = 0 Then
            'Me.CmbFletes.DataSource = DataSet.Tables("ImpuestosFletes")
            'Me.CmbFletes.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosHC")
        If Not DataSet.Tables("ImpuestosHC").Rows.Count = 0 Then
            'Me.CmbHC.DataSource = DataSet.Tables("ImpuestosHC")
            'Me.CmbHC.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosIG")
        If Not DataSet.Tables("ImpuestosIG").Rows.Count = 0 Then
            'Me.CmbIG.DataSource = DataSet.Tables("ImpuestosIG")
            'Me.CmbIG.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosITF")
        If Not DataSet.Tables("ImpuestosITF").Rows.Count = 0 Then
            'Me.CmbITF.DataSource = DataSet.Tables("ImpuestosITF")
            'Me.CmbITF.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosGA")
        If Not DataSet.Tables("ImpuestosGA").Rows.Count = 0 Then
            'Me.CmbGA.DataSource = DataSet.Tables("ImpuestosGA")
            'Me.CmbGA.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosTSM")
        If Not DataSet.Tables("ImpuestosTSM").Rows.Count = 0 Then
            'Me.CmbTSM.DataSource = DataSet.Tables("ImpuestosTSM")
            'Me.CmbTSM.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosOG")
        If Not DataSet.Tables("ImpuestosOG").Rows.Count = 0 Then
            'Me.CmbOG.DataSource = DataSet.Tables("ImpuestosOG")
            'Me.CmbOG.DisplayMember = "Descripcion_Iva"
        End If

        DataAdapter.Fill(DataSet, "ImpuestosOH")
        If Not DataSet.Tables("ImpuestosOH").Rows.Count = 0 Then
            'Me.CmbOH.DataSource = DataSet.Tables("ImpuestosOH")
            'Me.CmbOH.DisplayMember = "Descripcion_Iva"
        End If

        Me.DTPFecha.Value = Now

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////MONEDA FACTURA//////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            FacturaLotes = DataSet.Tables("DatosEmpresa").Rows(0)("Factura_Tarea")
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE LIQUIDACION/////////////////////////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If FacturaLotes = False Then
            SqlString = "SELECT Detalle_Liquidacion.Cod_Producto, Detalle_Liquidacion.Descripcion_Producto, Detalle_Liquidacion.Cantidad, Detalle_Liquidacion.Precio_Compra, Detalle_Liquidacion.Peso_Compra, Detalle_Liquidacion.FOB, Detalle_Liquidacion.Gasto_Compra,Detalle_Liquidacion.Gasto_Impuesto, Detalle_Liquidacion.Precio_Costo, Detalle_Liquidacion.Numero_Liquidacion, Detalle_Liquidacion.Fecha_Liquidacion, Detalle_Liquidacion.Id_Detalle_Liquidacion  FROM Detalle_Liquidacion  WHERE (Detalle_Liquidacion.Numero_Liquidacion = N'-1')"
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleCompra")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
            Me.TrueDBGridComponentes.Columns("Peso_Compra").Caption = "Peso"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Peso_Compra").Width = 64
            Me.TrueDBGridComponentes.Columns("Precio_Compra").Caption = "Precio Comp"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Width = 70
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Locked = False
            'Me.TrueDBGridComponentes.Columns(3).NumberFormat = "##,##0.00"
            Me.TrueDBGridComponentes.Columns("FOB").Caption = "FOB"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Locked = True
            Me.TrueDBGridComponentes.Columns("Gasto_Compra").Caption = "Gastos"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Compra").Width = 65
            'Me.TrueDBGridComponentes.Columns(5).NumberFormat = "##,##0.00"
            Me.TrueDBGridComponentes.Columns("Gasto_Impuesto").Caption = "Gtos Imptos"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Impuesto").Width = 65
            'Me.TrueDBGridComponentes.Columns(6).NumberFormat = "##,##0.00"
            Me.TrueDBGridComponentes.Columns("Precio_Costo").Caption = "Precio Costo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Width = 70
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Locked = True

            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Liquidacion").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Liquidacion").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_Detalle_Liquidacion").Visible = False
            'Me.TrueDBGridComponentes.Columns(7).NumberFormat = "##,##0.00"
        Else
            SqlString = "SELECT Detalle_Liquidacion.Cod_Producto, Detalle_Liquidacion.Descripcion_Producto, Detalle_Liquidacion.Cantidad, Detalle_Liquidacion.Precio_Compra, Detalle_Liquidacion.Peso_Compra, Detalle_Liquidacion.FOB, Detalle_Liquidacion.Gasto_Compra,Detalle_Liquidacion.Gasto_Impuesto, Detalle_Liquidacion.Precio_Costo, Detalle_Liquidacion.Numero_Lote, Detalle_Liquidacion.Fecha_Vence, Detalle_Liquidacion.Numero_Liquidacion, Detalle_Liquidacion.Fecha_Liquidacion, Detalle_Liquidacion.Id_Detalle_Liquidacion FROM Detalle_Liquidacion WHERE (Detalle_Liquidacion.Numero_Liquidacion = N'-1')"
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleCompra")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Numero_Lote").Caption = "Lotes"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Width = 64
            Me.TrueDBGridComponentes.Columns("Fecha_Vence").Caption = "Fecha Vence"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Width = 70
            Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
            Me.TrueDBGridComponentes.Columns("Peso_Compra").Caption = "Peso"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Peso_Compra").Width = 64
            Me.TrueDBGridComponentes.Columns("Precio_Compra").Caption = "Precio Comp"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Width = 70
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Locked = False
            'Me.TrueDBGridComponentes.Columns(3).NumberFormat = "##,##0.00"
            Me.TrueDBGridComponentes.Columns("FOB").Caption = "FOB"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Width = 65
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Locked = True
            Me.TrueDBGridComponentes.Columns("Gasto_Compra").Caption = "Gastos"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Compra").Width = 65
            'Me.TrueDBGridComponentes.Columns(5).NumberFormat = "##,##0.00"
            Me.TrueDBGridComponentes.Columns("Gasto_Impuesto").Caption = "Gtos Imptos"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Impuesto").Width = 65
            'Me.TrueDBGridComponentes.Columns(6).NumberFormat = "##,##0.00"
            Me.TrueDBGridComponentes.Columns("Precio_Costo").Caption = "Precio Costo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Width = 70
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Locked = True
            'Me.TrueDBGridComponentes.Columns(7).NumberFormat = "##,##0.00"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Liquidacion").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Liquidacion").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_Detalle_Liquidacion").Visible = False
        End If



    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub DTPFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFecha.ValueChanged

    End Sub

    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodProducto As String, SqlString As String, Cantidad As Double, PrecioCompra As Double, Descuento As Double, FOB As Double

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
                            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                            Me.TrueDBGridComponentes.Columns("Precio_Costo").Text = DataSet.Tables("Productos").Rows(0)("Costo_Promedio")
                        Else
                            MsgBox("Este Producto no Existe", MsgBoxStyle.Critical, "Zeus Facturacion")
                            Quien = "CodigoProductosDetalle"
                            My.Forms.FrmConsultas.ShowDialog()
                            Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = My.Forms.FrmConsultas.Codigo
                            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
                            Me.TrueDBGridComponentes.Columns("Precio_Compra").Text = My.Forms.FrmConsultas.Precio
                        End If
                    End If
                Case 2
                    If Val(Me.TrueDBGridComponentes.Columns("Cantidad").Text) <> 0 Then
                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Precio_Compra").Text) <> 0 Then
                        PrecioCompra = Me.TrueDBGridComponentes.Columns("Precio_Compra").Text
                    End If

                    'If Val(Me.TrueDBGridComponentes.Columns(4).Text) <> 0 Then
                    '    Descuento = Me.TrueDBGridComponentes.Columns(4).Text
                    'End If

                    FOB = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))

                    Me.TrueDBGridComponentes.Columns("FOB").Text = FOB

                Case 3
                    If Val(Me.TrueDBGridComponentes.Columns("Cantidad").Text) <> 0 Then
                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Precio_Compra").Text) <> 0 Then
                        PrecioCompra = Me.TrueDBGridComponentes.Columns("Precio_Compra").Text
                    End If

                    'If Val(Me.TrueDBGridComponentes.Columns(4).Text) <> 0 Then
                    '    Descuento = Me.TrueDBGridComponentes.Columns(4).Text
                    'End If

                    FOB = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))
                    Me.TrueDBGridComponentes.Columns("FOB").Text = FOB

                Case 4
                    If Val(Me.TrueDBGridComponentes.Columns("Cantidad").Text) <> 0 Then
                        Cantidad = Me.TrueDBGridComponentes.Columns("Cantidad").Text
                    End If

                    If Val(Me.TrueDBGridComponentes.Columns("Precio_Compra").Text) <> 0 Then
                        PrecioCompra = Me.TrueDBGridComponentes.Columns("Precio_Compra").Text
                    End If

                    'If Val(Me.TrueDBGridComponentes.Columns(4).Text) <> 0 Then
                    '    Descuento = Me.TrueDBGridComponentes.Columns(4).Text
                    'End If

                    FOB = (Cantidad * PrecioCompra) * (1 - (Descuento / 100))
                    Me.TrueDBGridComponentes.Columns("FOB").Text = FOB

            End Select

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TrueDBGridComponentes_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterDelete

    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlProveedor As String, CodProducto As String, IposicionFila As Double
        Dim iPosicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim FOB As Double, PrecioCompra As Double




        If Me.TxtCodigoProveedor.Text <> "" Then

            SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.TxtCodigoProveedor.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedor")
            If DataSet.Tables("Proveedor").Rows.Count = 0 Then
                Exit Sub
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



        Registros = Me.BindingDetalle.Count
        iPosicion = Me.BindingDetalle.Position


        'CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Productos")
        'PrecioUnitario = Me.BindingDetalle.Item(iPosicion)("Precio_Unitario")
        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
        '    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
        'End If
        'PrecioNeto = Me.BindingDetalle.Item(iPosicion)("Precio_Neto")
        'Importe = Me.BindingDetalle.Item(iPosicion)("Importe")
        'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
        '    Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
        'End If


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        InsertarRowGrid()


        CodigoProducto = 0
        PrecioUnitario = 0
        Descuento = 0
        PrecioNeto = 0
        Importe = 0
        Cantidad = 0

        Me.TrueDBGridComponentes.Col = 0
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComponentes.BeforeColUpdate
        Dim ConsecutivoCompra As Double, NumeroCompra As String
        Dim SqlProveedor As String, CodProducto As String, IposicionFila As Double
        Dim iPosicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim FOB As Double, PrecioCompra As Double

        If Me.TrueDBGridComponentes.Columns("Cantidad").Text = "" Then
            MsgBox("Digite la Cantidad", MsgBoxStyle.Critical, "Zeus Facturacion")
            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 0
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA LIQUIDACION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            ConsecutivoCompra = BuscaConsecutivo("Liquidacion")
        Else
            ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        End If

        NumeroCompra = Format(ConsecutivoCompra, "0000#")

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA LIQUIDACION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaEncabezadoLiquidacion(NumeroCompra)

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroLiquidacion"
            Me.TxtNumeroEnsamble.Text = NumeroCompra
        End If

        Me.TrueDBGridComponentes.Columns("Numero_Liquidacion").Text = NumeroCompra
        Me.TrueDBGridComponentes.Columns("Fecha_Liquidacion").Text = Format(Me.DTPFecha.Value, "dd/MM/yyyy")
    End Sub

    Private Sub TrueDBGridComponentes_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeUpdate
        Dim ConsecutivoCompra As Double, NumeroCompra As String
        Dim SqlProveedor As String, CodProducto As String, IposicionFila As Double
        Dim iPosicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim FOB As Double, PrecioCompra As Double, Peso As Double


        Registros = Me.BindingDetalle.Count
        iPosicion = Me.BindingDetalle.Position

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////SUMO LOS TOTALES /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        PrecioCompra = 0
        FOB = 0
        IposicionFila = 0
        Peso = 0

        Do While IposicionFila < Registros
            My.Application.DoEvents()
            If Not IsDBNull(Me.BindingDetalle.Item(IposicionFila)("Precio_Costo")) Then
                PrecioCompra = PrecioCompra + Me.BindingDetalle.Item(IposicionFila)("Precio_Costo")
            End If

            If Not IsDBNull(Me.BindingDetalle.Item(IposicionFila)("FOB")) Then
                FOB = FOB + Me.BindingDetalle.Item(IposicionFila)("FOB")
            End If

            If Not IsDBNull(Me.BindingDetalle.Item(IposicionFila)("Peso_Compra")) Then
                Peso = Peso + Me.BindingDetalle.Item(IposicionFila)("Peso_Compra")
            End If


            Me.TxtTotalCosto.Text = PrecioCompra
            Me.TxtTotalFob.Text = FOB
            Me.TxtTotalPeso.Text = Peso
            IposicionFila = IposicionFila + 1
        Loop


        If Me.CmbImpuesto.Text = "" Then
            MsgBox("Se necesita la mondeda del impuesto,", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If



    End Sub

    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick


        If e.ColIndex = 0 Then
            Quien = "ProductosLiquidacion"
            My.Forms.FrmConsultas.ShowDialog()

            Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = My.Forms.FrmConsultas.Codigo
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
            Me.TrueDBGridComponentes.Columns("Precio_Compra").Text = My.Forms.FrmConsultas.Precio

        ElseIf e.ColIndex = 8 Then

            Dim Posicion As Double
            If Me.BindingDetalle.Count <> 0 Then
                My.Forms.FrmLotes.TipoDocumento = "Mercancia Recibida"
                Posicion = Me.BindingDetalle.Position
                My.Forms.FrmLotes.CodigoProducto = Me.BindingDetalle.Item(Posicion)("Cod_Producto")
                My.Forms.FrmLotes.NombreProducto = Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                My.Forms.FrmLotes.NumeroDocumento = Me.TxtNumeroEnsamble.Text
                My.Forms.FrmLotes.Fecha = Me.DTPFecha.Value
                My.Forms.FrmLotes.LblProducto.Text = Me.BindingDetalle.Item(Posicion)("Cod_Producto") + " " + Me.BindingDetalle.Item(Posicion)("Descripcion_Producto")
                If Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Cantidad")) Then
                    My.Forms.FrmLotes.Cantidad = Me.BindingDetalle.Item(Posicion)("Cantidad")
                    My.Forms.FrmLotes.LblCantidad.Text = Me.BindingDetalle.Item(Posicion)("Cantidad")
                End If

                My.Forms.FrmLotes.TipoDocumento = "Mercancia Recibida"
                My.Forms.FrmLotes.ShowDialog()

                Me.TrueDBGridComponentes.Columns("Numero_Lote").Text = My.Forms.FrmLotes.NumeroLote
                Me.TrueDBGridComponentes.Columns("Fecha_Vence").Text = My.Forms.FrmLotes.FechaVence


            End If

        End If
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Quien = "Bodegas"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoBodega.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub TxtSeguro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSeguro.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SQLString As String, Registro As Double = 0

        SQLString = "SELECT * FROM Liquidacion INNER JOIN Impuestos ON Liquidacion.CodSeguro = Impuestos.Cod_Iva WHERE(Not (Liquidacion.Seguro Is NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Buscar")

        If DataSet.Tables("Buscar").Rows.Count <> 0 Then
            Registro = DataSet.Tables("Buscar").Rows.Count
            'Me.CmbSeguro.Text = DataSet.Tables("Buscar").Rows(Registro)("Descripcion_Iva")
        End If


    End Sub

    Private Sub cmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditar.Click
        Dim PrecioCompra As Double, FOB As Double, IposicionFila As Double, Registros As Double, Registros2 As Double
        Dim TotalFOB As Double, TotalCosto As Double, TotalImpuestos As Double, Porciento As Double
        Dim CodProducto As String, SqlString As String, TotalGastos As Double, iPosicion As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, TasaImpuesto As Double, Encontrado As Boolean = False
        Dim oDataRow As DataRow, CodigoIva As String, Registros3 As Double, iPosicion3 As Double, CodIvaDetaLLE As String
        Dim TotalIva As Double = 0, Tasacambio As Double, GastosImpuestos As Double, GastosPorciento As Double
        Dim OtrosImp As Double, TotalPeso As Double, Peso As Double


        If Me.CmbImpuesto.Text = "" Then
            MsgBox("Se necesita la mondeda del impuesto,", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Tasacambio = Me.TxtTasaCambio.Text

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////SUMO LOS TOTALES /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        TotalGastos = CDbl(Me.TxtSeguro.Text) + CDbl(Me.TxtTransporte.Text) + CDbl(Me.TxtAlmacen.Text) + CDbl(Me.TxtFletes.Text) + CDbl(Me.TxtAgente.Text) + CDbl(Me.TxtFletesInternos.Text) + CDbl(Me.TxtCustodio.Text) + CDbl(Me.TxtGastosAduana.Text) + CDbl(Me.TxtOtrosGastos.Text)
        GastosImpuestos = CDbl(Me.TxtSeguro.Text) + CDbl(Me.TxtFletes.Text) + CDbl(Me.TxtGastosAduana.Text) + CDbl(Me.TxtTSI.Text) + CDbl(Me.TxtSSA.Text) + CDbl(Me.TxtSPE.Text)

        PrecioCompra = 0
        FOB = 0
        Peso = 0
        TotalCosto = 0
        TotalFOB = Me.TxtTotalFob.Text
        If Me.TxtTotalPeso.Text <> "" Then
            TotalPeso = Me.TxtTotalPeso.Text
        End If

        If TotalFOB = 0 Then
            MsgBox("No se ha Totalizado", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        DatasetLiquidacion.Reset()
        SqlString = "SELECT Cod_Iva, Monto FROM ImpuestosLiquidacion WHERE (Fecha_Liquidacion = CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd") & "', 102)) AND (Numero_Liquidacion = '-100000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DatasetLiquidacion, "ImpuestosDetalle")
        TotalIva = 0


        IposicionFila = 0
        Registros = Me.BindingDetalle.Count
        Do While IposicionFila < Registros
            My.Application.DoEvents()

            If Me.TrueDBGridComponentes.Row = IposicionFila Then
                If Registros >= 1 Then
                    If Me.TrueDBGridComponentes.Row = 0 Then
                        Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row + 1
                    Else
                        Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row - 1
                    End If
                End If
            End If

            If Me.ChkProrratearPeso.Checked = False Then
                FOB = Me.BindingDetalle.Item(IposicionFila)("FOB")
                Porciento = Format((FOB / TotalFOB), "##,##0.000000")
            Else
                Peso = Me.BindingDetalle.Item(IposicionFila)("Peso_Compra")
                Porciento = Format((Peso / TotalPeso), "##,##0.000000")
            End If


            CodProducto = Me.BindingDetalle.Item(IposicionFila)("Cod_Producto")

            'SqlString = "SELECT  * FROM  Productos INNER JOIN Impuestos ON Productos.Cod_Iva = Impuestos.Cod_Iva WHERE (Productos.Cod_Productos = '" & CodProducto & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "IVA")
            'If DataSet.Tables("IVA").Rows.Count <> 0 Then
            '    TasaIva = DataSet.Tables("IVA").Rows(0)("Impuesto")
            'Else
            '    TasaIva = 0
            'End If

            'MontoIva = MontoIva + FOB * TasaIva
            'Me.TxtMontoIva.Text = MontoIva

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////BUSCO LOS IMPUESTOS PARA CADA PRODUCTO/////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  * FROM ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ImpuestosProductos")
            Registros2 = DataSet.Tables("ImpuestosProductos").Rows.Count
            iPosicion = 0
            TotalImpuestos = 0
            TotalIva = 0
            Do While iPosicion < Registros2
                TasaImpuesto = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Impuesto")

                If Me.CmbImpuesto.Text = Me.CmbMoneda.Text Then
                    If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                        TotalIva = TotalIva + CDbl(Format((FOB + (GastosImpuestos * Porciento)) * TasaImpuesto, "##0.00"))
                    Else
                        TotalImpuestos = TotalImpuestos + CDbl(Format((FOB + GastosImpuestos * Porciento) * TasaImpuesto, "##0.00"))
                    End If


                ElseIf Me.CmbMoneda.Text = "Dolares" Then
                    If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                        TotalIva = TotalIva + CDbl(Format(((FOB + (GastosImpuestos * Porciento)) * Tasacambio) * TasaImpuesto, "##0.00"))
                    Else
                        TotalImpuestos = TotalImpuestos + CDbl(Format(((FOB + (GastosImpuestos * Porciento)) * Tasacambio) * TasaImpuesto, "##0.00"))
                    End If

                ElseIf Me.CmbMoneda.Text = "Cordobas" Then
                    If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                        TotalIva = TotalIva + CDbl(Format(((FOB + (GastosImpuestos * Porciento)) / Tasacambio) * TasaImpuesto, "##0.00"))
                    Else
                        TotalImpuestos = TotalImpuestos + CDbl(Format(((FOB + (GastosImpuestos * Porciento)) / Tasacambio) * TasaImpuesto, "##0.00"))
                    End If

                End If



                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////AQUI AGREGO EL DETALLE de los impuestos///////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                Registros3 = DatasetLiquidacion.Tables("ImpuestosDetalle").Rows.Count
                CodigoIva = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva")
                Encontrado = False
                iPosicion3 = 0
                Do While iPosicion3 < Registros3

                    CodIvaDetaLLE = DatasetLiquidacion.Tables("ImpuestosDetalle").Rows(iPosicion3)("Cod_Iva")
                    If CodigoIva = CodIvaDetaLLE Then
                        oDataRow = DatasetLiquidacion.Tables("ImpuestosDetalle").Rows(iPosicion3)

                        If Me.CmbImpuesto.Text = Me.CmbMoneda.Text Then
                            If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                                oDataRow("Monto") = oDataRow("Monto") + CDbl(Format((FOB + (GastosImpuestos * Porciento)) * TasaImpuesto, "##0.00"))
                            Else
                                oDataRow("Monto") = oDataRow("Monto") + CDbl(Format((FOB + (GastosImpuestos * Porciento)) * TasaImpuesto, "##0.00"))
                            End If
                        ElseIf Me.CmbMoneda.Text = "Dolares" Then
                            If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                                oDataRow("Monto") = oDataRow("Monto") + CDbl(Format(((FOB + (GastosImpuestos * Porciento)) * Tasacambio) * TasaImpuesto, "##0.00"))
                            Else
                                oDataRow("Monto") = oDataRow("Monto") + CDbl(Format(((FOB + (GastosImpuestos * Porciento)) * Tasacambio) * TasaImpuesto, "##0.00"))
                            End If

                        ElseIf Me.CmbMoneda.Text = "Cordobas" Then
                            If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                                oDataRow("Monto") = oDataRow("Monto") + CDbl(Format(((FOB + (GastosImpuestos * Porciento)) / Tasacambio) * TasaImpuesto, "##0.00"))
                            Else
                                oDataRow("Monto") = oDataRow("Monto") + CDbl(Format(((FOB + (GastosImpuestos * Porciento)) / Tasacambio) * TasaImpuesto, "##0.00"))
                            End If

                        End If
                        'DataSet.Tables("ImpuestosDetalle").Rows.Add(oDataRow)
                        Encontrado = True
                    End If
                    'CodigoIva = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva")
                    'Criterio = "Cod_Iva='" & CodigoIva & "'"
                    'DataSet.Tables("ImpuestosDetalle").Rows.Find(Criterio)
                    iPosicion3 = iPosicion3 + 1
                Loop

                If Encontrado = False Then
                    oDataRow = DatasetLiquidacion.Tables("ImpuestosDetalle").NewRow
                    oDataRow("Cod_Iva") = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva")
                    'oDataRow("Monto") = CDbl(Format(FOB * TasaImpuesto, "##0.00"))

                    If Me.CmbImpuesto.Text = Me.CmbMoneda.Text Then
                        If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                            oDataRow("Monto") = CDbl(Format((FOB + GastosImpuestos * Porciento) * TasaImpuesto, "##0.00"))
                        Else
                            oDataRow("Monto") = CDbl(Format((FOB + GastosImpuestos * Porciento) * TasaImpuesto, "##0.00"))
                        End If
                    ElseIf Me.CmbMoneda.Text = "Dolares" Then
                        If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                            oDataRow("Monto") = CDbl(Format(((FOB + GastosImpuestos * Porciento) * Tasacambio) * TasaImpuesto, "##0.00"))
                        Else
                            oDataRow("Monto") = CDbl(Format(((FOB + GastosImpuestos * Porciento) * Tasacambio) * TasaImpuesto, "##0.00"))
                        End If

                    ElseIf Me.CmbMoneda.Text = "Cordobas" Then
                        If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                            oDataRow("Monto") = CDbl(Format(((FOB + GastosImpuestos * Porciento) / Tasacambio) * TasaImpuesto, "##0.00"))
                        Else
                            oDataRow("Monto") = CDbl(Format(((FOB + GastosImpuestos * Porciento) / Tasacambio) * TasaImpuesto, "##0.00"))
                        End If
                    End If
                    DatasetLiquidacion.Tables("ImpuestosDetalle").Rows.Add(oDataRow)
                    Encontrado = True
                End If


                iPosicion = iPosicion + 1
            Loop
            DataSet.Tables("ImpuestosProductos").Clear()


            Me.TDGridImpuestos.DataSource = DatasetLiquidacion.Tables("ImpuestosDetalle")

            If Tasacambio = 0 Then
                Tasacambio = 1
            End If

            TotalGastos = CDbl(Me.TxtSeguro.Text) + CDbl(Me.TxtTransporte.Text) + CDbl(Me.TxtAlmacen.Text) + CDbl(Me.TxtFletes.Text) + CDbl(Me.TxtAgente.Text) + CDbl(Me.TxtFletesInternos.Text) + CDbl(Me.TxtCustodio.Text) + CDbl(Me.TxtGastosAduana.Text) + CDbl(Me.TxtOtrosGastos.Text) + CDbl(Me.TxtTSI.Text) + CDbl(Me.TxtSSA.Text)
            GastosImpuestos = CDbl(Me.TxtSeguro.Text) + CDbl(Me.TxtFletes.Text) + CDbl(Me.TxtGastosAduana.Text) + CDbl(Me.TxtTSI.Text) + CDbl(Me.TxtSSA.Text)

            FOB = Me.BindingDetalle.Item(IposicionFila)("FOB")
            Porciento = (FOB / TotalFOB)

            If Me.CmbMoneda.Text = "Dolares" Then
                If Me.CmbGastos.Text = "Cordobas" Then
                    TotalGastos = TotalGastos / Tasacambio
                End If
            ElseIf Me.CmbGastos.Text = "Dolares" Then
                TotalGastos = TotalGastos * Tasacambio
            End If

            If Me.CmbMoneda.Text = "Dolares" Then
                If Me.CmbImpuesto.Text = "Cordobas" Then
                    TotalImpuestos = TotalImpuestos / Tasacambio
                    TotalIva = TotalIva / Tasacambio
                End If
            ElseIf Me.CmbImpuesto.Text = "Dolares" Then
                TotalImpuestos = TotalImpuestos * Tasacambio
                TotalIva = TotalIva * Tasacambio
            End If

            If IsNumeric(Me.TxtGastoImpuesto.Text) Then
                TotalImpuestos = TotalImpuestos + CDbl(Me.TxtGastoImpuesto.Text)
            End If

            If (TotalImpuestos + TotalGastos) <> 0 Then
                PrecioCompra = CDbl(FOB) + CDbl(TotalImpuestos) + CDbl(TotalGastos * Porciento)
            Else
                PrecioCompra = FOB
            End If

            Me.TrueDBGridComponentes.Item(IposicionFila)("Precio_Costo") = PrecioCompra
            Me.TrueDBGridComponentes.Item(IposicionFila)("Gasto_Compra") = TotalGastos * Porciento
            Me.TrueDBGridComponentes.Item(IposicionFila)("Gasto_Impuesto") = TotalImpuestos * Porciento

            ds.Tables("DetalleCompra").Rows(IposicionFila)("Precio_Compra") = PrecioCompra
            ds.Tables("DetalleCompra").Rows(IposicionFila)("Gasto_Compra") = TotalGastos * Porciento
            ds.Tables("DetalleCompra").Rows(IposicionFila)("Gasto_Impuesto") = TotalImpuestos * Porciento

            'Me.BindingDetalle.Item(IposicionFila)("Precio_Costo") = PrecioCompra
            'Me.BindingDetalle.Item(IposicionFila)("Gasto_Compra") = TotalGastos * Porciento
            'Me.BindingDetalle.Item(IposicionFila)("Gasto_Impuesto") = TotalImpuestos



            TotalCosto = TotalCosto + PrecioCompra

            IposicionFila = IposicionFila + 1
            TotalImpuestos = 0
        Loop


        Me.TxtTotalCosto.Text = Format(TotalCosto, "##,##0.00000")

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        InsertarRowGrid()


    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim ConsecutivoCompra As Double, NumeroCompra As String, Iposicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioCosto As Double, Cantidad As Double, FOB As Double
        Dim TasaCambio As Double, SqlString As String, Registros2 As Double, iPosicion2 As Double, TotalImpuestos As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, TasaImpuesto As Double, CodigoIva As String = ""
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, GastoImpuesto As Double
        Dim NumeroLote As String, FechaLote As Date

        If Me.CmbImpuesto.Text = "" Then
            MsgBox("Se necesita la mondeda del impuesto,", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA LIQUIDACION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            ConsecutivoCompra = BuscaConsecutivo("Liquidacion")
        Else
            ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        End If

        NumeroCompra = Format(ConsecutivoCompra, "0000#")

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA LIQUIDACION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaEncabezadoLiquidacion(NumeroCompra)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////


        Registros = Me.BindingDetalle.Count
        Iposicion = 0


        If Me.TxtTasaCambio.Text <> "" Then
            TasaCambio = Me.TxtTasaCambio.Text
        Else
            TasaCambio = BuscaTasaCambio(Me.DTPFecha.Text)
        End If

        Do While Iposicion < Registros
            CodigoProducto = Me.BindingDetalle.Item(Iposicion)("Cod_Producto")
            PrecioUnitario = Me.BindingDetalle.Item(Iposicion)("Precio_Compra")
            If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Gasto_Compra")) Then
                Descuento = Me.BindingDetalle.Item(Iposicion)("Gasto_Compra")
            End If
            If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Precio_Costo")) Then
                PrecioCosto = Me.BindingDetalle.Item(Iposicion)("Precio_Costo")
            End If
            FOB = Me.BindingDetalle.Item(Iposicion)("FOB")
            Cantidad = Me.BindingDetalle.Item(Iposicion)("Cantidad")
            If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Gasto_Impuesto")) Then
                GastoImpuesto = Me.BindingDetalle.Item(Iposicion)("Gasto_Impuesto")
            End If

            'If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Numero_Lote")) Then
            '    NumeroLote = Me.BindingDetalle.Item(Iposicion)("Numero_Lote")
            'End If

            'If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Numero_Lote")) Then
            '    FechaLote = Me.BindingDetalle.Item(Iposicion)("Fecha_Vence")
            'End If


            'GrabaDetalleLiquidacion(NumeroCompra, Me.DTPFecha.Text, CodigoProducto, Cantidad, PrecioUnitario, Descuento, FOB, PrecioCosto, TasaCambio, GastoImpuesto, NumeroLote, FechaLote)


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////BUSCO LOS IMPUESTOS PARA CADA PRODUCTO/////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  * FROM ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  WHERE (Cod_Productos = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ImpuestosProductos")
            Registros2 = DataSet.Tables("ImpuestosProductos").Rows.Count
            iPosicion2 = 0
            TotalImpuestos = 0
            Do While iPosicion2 < Registros2
                TasaImpuesto = DataSet.Tables("ImpuestosProductos").Rows(iPosicion2)("Impuesto")
                TotalImpuestos = TotalImpuestos + (FOB * TasaImpuesto)
                CodigoIva = DataSet.Tables("ImpuestosProductos").Rows(iPosicion2)("Cod_Iva")

                MiConexion.Close()
                StrSqlUpdate = "DELETE FROM [ImpuestosLiquidacion] WHERE (Numero_Liquidacion = '" & NumeroCompra & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd") & "', 102)) AND (Cod_Producto = '" & CodigoProducto & "') AND (Cod_Iva = '" & CodigoIva & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////AQUI AGREGO EL DETALLE de los impuestos///////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                GrabaDetalleImpuestosLiquidacion(NumeroCompra, Me.DTPFecha.Value, CodigoProducto, CodigoIva, (FOB * TasaImpuesto))

                iPosicion2 = iPosicion2 + 1
            Loop
            DataSet.Tables("ImpuestosProductos").Reset()







            Iposicion = Iposicion + 1
        Loop

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroLiquidacion"
            Me.TxtNumeroEnsamble.Text = NumeroCompra
        End If


        MsgBox("Se ha Grabado con Exito!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")
        Me.CmdFacturar.Enabled = True
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQLString As String, ArepLiquidacion As New ArepLiquidacion, SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim Fecha As String, Sqldatos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, RutaLogo As String
        Dim ConsecutivoCompra As Double, NumeroCompra As String, Iposicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioCosto As Double, Cantidad As Double, FOB As Double
        Dim TasaCambio As Double, GastoImpuesto As Double, Registros2 As Double, iPosicion2 As Double, TotalImpuestos As Double, CodigoIva As String, TasaImpuesto As Double
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroLote As String, FechaLote As Date



        If Me.CmbImpuesto.Text = "" Then
            MsgBox("Se necesita la mondeda del impuesto,", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            ConsecutivoCompra = BuscaConsecutivo("Liquidacion")
        Else
            ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        End If

        NumeroCompra = Format(ConsecutivoCompra, "0000#")

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaEncabezadoLiquidacion(NumeroCompra)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////


        Registros = Me.BindingDetalle.Count
        Iposicion = 0

        TasaCambio = BuscaTasaCambio(Me.DTPFecha.Text)

        Do While Iposicion < Registros
            CodigoProducto = Me.BindingDetalle.Item(Iposicion)("Cod_Producto")
            PrecioUnitario = Me.BindingDetalle.Item(Iposicion)("Precio_Compra")
            If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Gasto_Compra")) Then
                Descuento = Me.BindingDetalle.Item(Iposicion)("Gasto_Compra")
            End If

            If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Precio_Costo")) Then
                PrecioCosto = Me.BindingDetalle.Item(Iposicion)("Precio_Costo")
            End If
            FOB = Me.BindingDetalle.Item(Iposicion)("FOB")
            Cantidad = Me.BindingDetalle.Item(Iposicion)("Cantidad")

            If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Gasto_Impuesto")) Then
                GastoImpuesto = Me.BindingDetalle.Item(Iposicion)("Gasto_Impuesto")
            End If

            'If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Numero_Lote")) Then
            '    NumeroLote = Me.BindingDetalle.Item(Iposicion)("Numero_Lote")
            'End If

            'If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Numero_Lote")) Then
            '    FechaLote = Me.BindingDetalle.Item(Iposicion)("Fecha_Vence")
            'End If

            GrabaDetalleLiquidacion(NumeroCompra, Me.DTPFecha.Text, CodigoProducto, Cantidad, PrecioUnitario, Descuento, FOB, PrecioCosto, TasaCambio, GastoImpuesto, NumeroLote, FechaLote)
            Iposicion = Iposicion + 1


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////BUSCO LOS IMPUESTOS PARA CADA PRODUCTO/////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQLString = "SELECT  * FROM ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  WHERE (Cod_Productos = '" & CodigoProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
            DataAdapter.Fill(DataSet, "ImpuestosProductos")
            Registros2 = DataSet.Tables("ImpuestosProductos").Rows.Count
            iPosicion2 = 0
            TotalImpuestos = 0
            Do While iPosicion2 < Registros2
                TasaImpuesto = DataSet.Tables("ImpuestosProductos").Rows(iPosicion2)("Impuesto")
                TotalImpuestos = TotalImpuestos + (FOB * TasaImpuesto)
                CodigoIva = DataSet.Tables("ImpuestosProductos").Rows(iPosicion2)("Cod_Iva")

                MiConexion.Close()
                StrSqlUpdate = "DELETE FROM [ImpuestosLiquidacion] WHERE (Numero_Liquidacion = '" & NumeroCompra & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd") & "', 102)) AND (Cod_Producto = '" & CodigoProducto & "') AND (Cod_Iva = '" & CodigoIva & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////AQUI AGREGO EL DETALLE de los impuestos///////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                GrabaDetalleImpuestosLiquidacion(NumeroCompra, Me.DTPFecha.Value, CodigoProducto, CodigoIva, (FOB * TasaImpuesto))

                iPosicion2 = iPosicion2 + 1
            Loop
            DataSet.Tables("ImpuestosProductos").Reset()


        Loop

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Quien = "NumeroCompras"
            Me.TxtNumeroEnsamble.Text = NumeroCompra
        End If



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO LOS DATOS DE LA EMPRESA/////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepLiquidacion.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepLiquidacion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepLiquidacion.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepLiquidacion.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////CARGO EL DETALLE DE LOS IMPUESTOS///////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SQLString = "SELECT MAX(Cod_Iva) AS Cod_Iva, SUM(Monto) AS Monto, MAX(Numero_Liquidacion) AS Numero_Liquidacion FROM ImpuestosLiquidacion WHERE (Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "TotalImpuesto")
        If DataSet.Tables("TotalImpuesto").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("TotalImpuesto").Rows(0)("Monto")) Then
                ArepLiquidacion.LblTotal.Text = Format(DataSet.Tables("TotalImpuesto").Rows(0)("Monto"), "##,##0.00")
            End If

        End If

        ArepLiquidacion.NumeroLiquidacion = Me.TxtNumeroEnsamble.Text
        ArepLiquidacion.FechaLiquidacion = Me.DTPFecha.Value



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////IMPRIMO LA LIQUIDACION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then

            ArepLiquidacion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text

            SQLString = "SELECT  * FROM Liquidacion INNER JOIN Detalle_Liquidacion ON Liquidacion.Numero_Liquidacion = Detalle_Liquidacion.Numero_Liquidacion AND Liquidacion.Fecha_Liquidacion = Detalle_Liquidacion.Fecha_Liquidacion INNER JOIN Productos ON Detalle_Liquidacion.Cod_Producto = Productos.Cod_Productos  " & _
                        "WHERE (Liquidacion.Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Liquidacion.Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102))"
            SQL.ConnectionString = Conexion
            SQL.SQL = SQLString
            ArepLiquidacion.DataSource = SQL
            ArepLiquidacion.Document.Name = "Reporte de Liquidacion"

            Dim ViewerForm As New FrmViewer()

            ViewerForm.arvMain.Document = ArepLiquidacion.Document
            ViewerForm.Show()
            ArepLiquidacion.Run(True)

        Else
            MsgBox("Debe Grabar Primero", MsgBoxStyle.Critical, "Zeus Facturacion")
        End If





        Me.CmdFacturar.Enabled = True
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiaLiquidacion()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "Liquidacion"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtNombres.Text = My.Forms.FrmConsultas.Nombres
        Me.TxtApellidos.Text = My.Forms.FrmConsultas.Apellidos
        Me.DTPFecha.Value = My.Forms.FrmConsultas.Fecha
        Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultas.Codigo

    End Sub
    Function NombreMetodoPago(ByVal Moneda As String, ByVal TipoPago As String) As String
        Dim sqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        NombreMetodoPago = ""

        sqlString = "SELECT  NombrePago, TipoPago, Cod_Cuenta, Moneda  FROM MetodoPago WHERE (TipoPago = '" & TipoPago & "') AND (Moneda = '" & Moneda & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sqlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoPago")
        If DataSet.Tables("MetodoPago").Rows.Count <> 0 Then
            NombreMetodoPago = DataSet.Tables("MetodoPago").Rows(0)("NombrePago")
        End If

    End Function

    Private Sub CmdFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFacturar.Click
        Dim ComandoUpdate As New SqlClient.SqlCommand
        Dim ConsecutivoCompra As Double, NumeroCompra As String, iPosicion As Double, Registros As Double
        Dim CodigoProducto As String, PrecioUnitario As Double, Descuento As Double, PrecioFOB As Double, PrecioCosto As Double, Cantidad As Double
        Dim PrecioNeto As Double, Importe As Double
        Dim StrSqlUpdate As String, iResultado As Integer, SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Fecha As String, MontoIva As Double, NombrePago As String, Monto As Double, NumeroTarjeta As Double = 0, FechaVenceTarjeta As Date
        Dim GastosImpuestos As Double = 0, NumeroLote As String, FechaLote As Date


        ConsecutivoCompra = BuscaConsecutivo("Compra")
        NumeroCompra = Format(ConsecutivoCompra, "0000#")
        Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        '----------------------------------------------------------------------------------------------------------------------------------------
        '----------------------------------------CONSULTO EL MONTO DE IVA -----------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------------------------------------------
        SqlString = "SELECT SUM(Monto) AS IVA FROM ImpuestosLiquidacion " & _
                    "WHERE (Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Cod_Iva = '15%')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ImpuestosDetalle")
        If DataSet.Tables("ImpuestosDetalle").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("ImpuestosDetalle").Rows(0)("IVA")) Then
                MontoIva = DataSet.Tables("ImpuestosDetalle").Rows(0)("IVA")
            End If
        Else
            MontoIva = 0
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL ENCABEZADO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaEncabezadoCompras(NumeroCompra, Me.DTPFecha.Value, "Mercancia Recibida", Me.TxtCodigoProveedor.Text, Me.CboCodigoBodega.Text, Me.TxtNombres.Text, Me.TxtApellidos.Text, Me.DTPFecha.Value, Val(Me.TxtTotalCosto.Text), MontoIva, MontoIva + Val(Me.TxtTotalCosto.Text), MontoIva + Val(Me.TxtTotalCosto.Text), Me.CmbMoneda.Text, "Procesado por Liquidacion " & Me.TxtNumeroEnsamble.Text, "", False)



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS METODOS DE PAGO /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        'If Me.CmbMoneda.Text = "Dolares" Then
        '    NombrePago = NombreMetodoPago(Me.CmbMoneda.Text, "Efectivo")
        'End If

        'NumeroTarjeta = 0
        'FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
        'GrabaMetodoDetalleCompraLiquidacion(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta, "Efectivo", Me.DTPFecha.Value, "Mercancia Recibida")



        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        Registros = Me.BindingDetalle.Count
        iPosicion = 0
        GastosImpuestos = 0
        Do While iPosicion < Registros
            CodigoProducto = Me.BindingDetalle.Item(iPosicion)("Cod_Producto")

            'If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Descuento")) Then
            '    Descuento = Me.BindingDetalle.Item(iPosicion)("Descuento")
            'End If
            PrecioFOB = Me.BindingDetalle.Item(iPosicion)("FOB")
            PrecioCosto = Me.BindingDetalle.Item(iPosicion)("Precio_Costo")
            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Cantidad")) Then
                Cantidad = Me.BindingDetalle.Item(iPosicion)("Cantidad")
                PrecioUnitario = PrecioCosto / Cantidad
            End If

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Numero_Lote")) Then
                NumeroLote = Me.BindingDetalle.Item(iPosicion)("Numero_Lote")
            End If

            If Not IsDBNull(Me.BindingDetalle.Item(iPosicion)("Numero_Lote")) Then
                FechaLote = Me.BindingDetalle.Item(iPosicion)("Fecha_Vence")
            End If


            PrecioNeto = PrecioUnitario * Cantidad
            Importe = PrecioCosto - Descuento

            GastosImpuestos = GastosImpuestos + Me.BindingDetalle.Item(iPosicion)("Gasto_Impuesto")
            GrabaDetalleCompraLiquidacion(NumeroCompra, CodigoProducto, PrecioUnitario, Descuento, PrecioUnitario, Importe, Cantidad, Me.CmbMoneda.Text, Me.DTPFecha.Value, NumeroLote, FechaLote)
            ExistenciasCostos(CodigoProducto, Cantidad, PrecioUnitario, "Mercancia Recibida", Me.CboCodigoBodega.Text)

            iPosicion = iPosicion + 1
        Loop

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO LOS METODOS DE PAGO IMPUESTOS/////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        Monto = CDbl(Me.TxtAlmacen.Text) + CDbl(Me.TxtTransporte.Text) + CDbl(Me.TxtFletesInternos.Text) + CDbl(Me.TxtCustodio.Text) + CDbl(Me.TxtGastosAduana.Text) + CDbl(Me.TxtOtrosGastos.Text) + CDbl(Me.TxtAgente.Text)
        If Me.CmbMoneda.Text = "Dolares" Then
            NombrePago = NombreMetodoPago(Me.CmbMoneda.Text, "Efectivo")
        End If
        Monto = GastosImpuestos + Monto
        NumeroTarjeta = 0
        FechaVenceTarjeta = Format(Now, "dd/MM/yyyy")
        GrabaMetodoDetalleCompraLiquidacion(NumeroCompra, NombrePago, Monto, NumeroTarjeta, FechaVenceTarjeta, "Efectivo", Me.DTPFecha.Value, "Mercancia Recibida")


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////DESACTIVO LA LIQUIDACION/////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////
        MiConexion.Close()
        StrSqlUpdate = "UPDATE [Liquidacion] SET [Activo] = 0  WHERE (Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd") & "', 102))"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        LimpiaLiquidacion()

    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Me.CmdFacturar.Enabled = False
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaLiquidacion As String, SqlString

        If Quien = "NumeroLiquidacion" Then
            Exit Sub
        End If


        FechaLiquidacion = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")
            SqlCompras = "SELECT Liquidacion.* FROM Liquidacion INNER JOIN Proveedor ON Liquidacion.Cod_Proveedor = Proveedor.Cod_Proveedor WHERE (Liquidacion.Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Liquidacion.Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102))"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
            DataAdapter.Fill(DataSet, "Liquidacion")
            If Not DataSet.Tables("Liquidacion").Rows.Count = 0 Then

                '///////////////////////////////TOTAL FOB ///////////////////////////////////////
                SqlCompras = "SELECT SUM(Cantidad * Precio_Compra) AS FOB,SUM(Precio_Costo) AS Precio_Costo FROM Detalle_Liquidacion WHERE (Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102))"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                DataAdapter.Fill(DataSet, "FOB")
                If Not DataSet.Tables("FOB").Rows.Count = 0 Then
                    If Not IsDBNull(DataSet.Tables("FOB").Rows(0)("FOB")) Then
                        Me.TxtTotalFob.Text = DataSet.Tables("FOB").Rows(0)("FOB")
                    End If
                    If Not IsDBNull(DataSet.Tables("FOB").Rows(0)("Precio_Costo")) Then
                        Me.TxtTotalCosto.Text = DataSet.Tables("FOB").Rows(0)("Precio_Costo")
                    End If
                End If


                '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                Me.TxtCodigoProveedor.Text = DataSet.Tables("Liquidacion").Rows(0)("Cod_Proveedor")
                Me.TxtNombres.Text = DataSet.Tables("Liquidacion").Rows(0)("Nombre_Proveedor")
                Me.TxtApellidos.Text = DataSet.Tables("Liquidacion").Rows(0)("Apellido_Proveedor")

                Me.CboCodigoBodega.Caption = DataSet.Tables("Liquidacion").Rows(0)("CodBodega")
                Me.CmbMoneda.Text = DataSet.Tables("Liquidacion").Rows(0)("MonedaLiquidacion")
                Me.CmbImpuesto.Text = DataSet.Tables("Liquidacion").Rows(0)("MonedaImpuestos")
                Me.TxtSeguro.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("Seguro"), "##,##0.00")

                Me.TxtTransporte.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("Transporte"), "##,##0.00")
                Me.TxtAlmacen.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("Almacen"), "##,##0.00")
                Me.TxtFletes.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("Fletes"), "##,##0.00")
                Me.TxtAgente.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("GtoAgenteAduana"), "##,##0.00")
                Me.TxtFletesInternos.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("GtoFletesInternos"), "##,##0.00")
                Me.TxtCustodio.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("GtoCustodio"), "##,##0.00")
                Me.TxtGastosAduana.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("GtoAduana"), "##,##0.00")
                Me.TxtOtrosGastos.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("GtoOtros"), "##,##0.00")
                If Not IsDBNull(DataSet.Tables("Liquidacion").Rows(0)("TotalPeso")) Then
                    Me.TxtTotalPeso.Text = Format(DataSet.Tables("Liquidacion").Rows(0)("TotalPeso"), "##,##0.00")
                Else
                    Me.TxtTotalPeso.Text = 0
                End If

                If Not IsDBNull(DataSet.Tables("Liquidacion").Rows(0)("Prorrateo_Peso")) Then
                    Me.ChkProrratearPeso.Checked = DataSet.Tables("Liquidacion").Rows(0)("Prorrateo_Peso")
                Else
                    Me.ChkProrratearPeso.Checked = False
                End If


                If FacturaLotes = False Then

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////CARGO EL DETALLE DE LIQUIDACION/////////////////////////////////////////////////////////////////
                    ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    SqlString = "SELECT Detalle_Liquidacion.Cod_Producto, Detalle_Liquidacion.Descripcion_Producto, Detalle_Liquidacion.Cantidad, Detalle_Liquidacion.Precio_Compra, Detalle_Liquidacion.Peso_Compra, Detalle_Liquidacion.FOB,Detalle_Liquidacion.Gasto_Compra,Detalle_Liquidacion.Gasto_Impuesto, Detalle_Liquidacion.Precio_Costo, Detalle_Liquidacion.Numero_Liquidacion, Detalle_Liquidacion.Fecha_Liquidacion, Detalle_Liquidacion.Id_Detalle_Liquidacion FROM Detalle_Liquidacion WHERE (Detalle_Liquidacion.Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Liquidacion.Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102))"
                    ds = New DataSet
                    da = New SqlDataAdapter(SqlString, MiConexion)
                    CmdBuilder = New SqlCommandBuilder(da)
                    da.Fill(ds, "DetalleCompra")
                    Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
                    Me.TrueDBGridComponentes.Columns("Peso_Compra").Caption = "Peso"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Peso_Compra").Width = 64
                    Me.TrueDBGridComponentes.Columns("Precio_Compra").Caption = "Precio Comp"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Width = 70
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Locked = False
                    'Me.TrueDBGridComponentes.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridComponentes.Columns("FOB").Caption = "FOB"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Width = 65
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Locked = True
                    Me.TrueDBGridComponentes.Columns("Gasto_Compra").Caption = "Gastos"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Compra").Width = 65
                    'Me.TrueDBGridComponentes.Columns(5).NumberFormat = "##,##0.00"
                    Me.TrueDBGridComponentes.Columns("Gasto_Impuesto").Caption = "Gtos Imptos"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Impuesto").Width = 65
                    'Me.TrueDBGridComponentes.Columns(6).NumberFormat = "##,##0.00"
                    Me.TrueDBGridComponentes.Columns("Precio_Costo").Caption = "Precio Costo"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Width = 70
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Locked = True

                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Liquidacion").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Liquidacion").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_Detalle_Liquidacion").Visible = False
                    'Me.TrueDBGridComponentes.Columns(7).NumberFormat = "##,##0.00"

                Else

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////CARGO EL DETALLE DE LIQUIDACION/////////////////////////////////////////////////////////////////
                    ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    SqlString = "SELECT Detalle_Liquidacion.Cod_Producto, Detalle_Liquidacion.Descripcion_Producto, Detalle_Liquidacion.Cantidad, Detalle_Liquidacion.Precio_Compra, Detalle_Liquidacion.Peso_Compra, Detalle_Liquidacion.FOB,Detalle_Liquidacion.Gasto_Compra,Detalle_Liquidacion.Gasto_Impuesto, Detalle_Liquidacion.Precio_Costo, Detalle_Liquidacion.Numero_Lote, Detalle_Liquidacion.Fecha_Vence, Detalle_Liquidacion.Numero_Liquidacion, Detalle_Liquidacion.Fecha_Liquidacion, Detalle_Liquidacion.Id_Detalle_Liquidacion FROM Detalle_Liquidacion  WHERE (Detalle_Liquidacion.Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Detalle_Liquidacion.Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102))"
                    ds = New DataSet
                    da = New SqlDataAdapter(SqlString, MiConexion)
                    CmdBuilder = New SqlCommandBuilder(da)
                    da.Fill(ds, "DetalleCompra")
                    Me.BindingDetalle.DataSource = ds.Tables("DetalleCompra")
                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 74
                    Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 259
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                    Me.TrueDBGridComponentes.Columns("Numero_Lote").Caption = "Lotes"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Lote").Width = 64
                    Me.TrueDBGridComponentes.Columns("Fecha_Vence").Caption = "Fecha Vence"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Vence").Width = 70
                    Me.TrueDBGridComponentes.Columns("Cantidad").Caption = "Cantidad"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 64
                    Me.TrueDBGridComponentes.Columns("Precio_Compra").Caption = "Precio Comp"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Width = 70
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Compra").Locked = False
                    Me.TrueDBGridComponentes.Columns("Peso_Compra").Caption = "Peso"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Peso_Compra").Width = 64
                    'Me.TrueDBGridComponentes.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridComponentes.Columns("FOB").Caption = "FOB"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Width = 65
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("FOB").Locked = True
                    Me.TrueDBGridComponentes.Columns("Gasto_Compra").Caption = "Gastos"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Compra").Width = 65
                    'Me.TrueDBGridComponentes.Columns(5).NumberFormat = "##,##0.00"
                    Me.TrueDBGridComponentes.Columns("Gasto_Impuesto").Caption = "Gtos Imptos"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Gasto_Impuesto").Width = 65
                    'Me.TrueDBGridComponentes.Columns(6).NumberFormat = "##,##0.00"
                    Me.TrueDBGridComponentes.Columns("Precio_Costo").Caption = "Precio Costo"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Width = 70
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio_Costo").Locked = True

                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Liquidacion").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Fecha_Liquidacion").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_Detalle_Liquidacion").Visible = False

                    'Me.TrueDBGridComponentes.Columns(7).NumberFormat = "##,##0.00"


                End If


                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////////CARGO EL DETALLE DE LOS IMPUESTOS///////////////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                SqlString = "SELECT  Cod_Iva, SUM(Monto) AS Monto  FROM ImpuestosLiquidacion WHERE (Fecha_Liquidacion = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') GROUP BY Cod_Iva"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "ImpuestosDetalle")
                Me.TDGridImpuestos.DataSource = DataSet.Tables("ImpuestosDetalle")
                Me.TDGridImpuestos.Splits.Item(0).DisplayColumns(0).Locked = True

            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim iPosicion As Double
        Dim SqlString As String, CodProducto As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaLiquidacion As String, Resultado As Integer
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim clickedButton As Button = sender
        Dim oDataRow As DataRow, oTablaBorrados As DataTable


        FechaLiquidacion = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If


        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
        iPosicion = Me.BindingDetalle.Position
        'Me.BindingDetalle.RemoveCurrent()

        ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ''////////////////////////////////BUSCO EL PRODUCTO PARA ELIMINARLO DE LA LIQUIDACION///////////////////////////////////////////////////////////
        ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT * FROM Detalle_Liquidacion WHERE (Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & FechaLiquidacion & "', 102)) AND (Cod_Producto = '" & CodProducto & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Detalle")
        'If Not DataSet.Tables("Detalle").Rows.Count = 0 Then
        '    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
        '    MiConexion.Close()
        '    StrSqlUpdate = "DELETE FROM [Detalle_Liquidacion]  WHERE (Numero_Liquidacion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha_Liquidacion = CONVERT(DATETIME, '" & FechaLiquidacion & "', 102)) AND (Cod_Producto = '" & CodProducto & "')"
        '    MiConexion.Open()
        '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        '    iResultado = ComandoUpdate.ExecuteNonQuery
        '    MiConexion.Close()
        'End If

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        oDataRow = ds.Tables("DetalleCompra").Rows(iPosicion)
        oDataRow.Delete()

        cmdEditar_Click(sender, e)

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
        oTablaBorrados = ds.Tables("DetalleCompra").GetChanges(DataRowState.Deleted)
        If Not IsNothing(oTablaBorrados) Then
            '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
            da.Update(oTablaBorrados)
        End If
        ds.Tables("DetalleCompra").AcceptChanges()
        da.Update(ds.Tables("DetalleCompra"))

        Me.cmdEditar_Click(New Object(), New EventArgs)

    End Sub

    Private Sub TDGridImpuestos_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridImpuestos.AfterColUpdate
        Dim CodIva As String, Monto As Double
        If e.ColIndex = 1 Then
            '/////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////DISTRIBICION DE IMPUESTOS /////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            CodIva = Me.TDGridImpuestos.Columns(0).Text
            Monto = Me.TDGridImpuestos.Columns(1).Text







        End If
    End Sub

    Private Sub TDGridImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridImpuestos.Click

    End Sub

    Private Sub Procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Procesar.Click
        Dim PrecioCompra As Double, FOB As Double, IposicionFila As Double, Registros As Double, Registros2 As Double
        Dim TotalFOB As Double, TotalCosto As Double, TotalImpuestos As Double, Porciento As Double
        Dim CodProducto As String, SqlString As String, TotalGastos As Double, iPosicion As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, TasaImpuesto As Double, Encontrado As Boolean = False
        Dim oDataRow As DataRow, CodigoIva As String, Registros3 As Double, iPosicion3 As Double, CodIvaDetaLLE As String
        Dim TotalIva As Double = 0


        If Me.CmbImpuesto.Text = "" Then
            MsgBox("Se necesita la mondeda del impuesto,", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////SUMO LOS TOTALES /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        TotalGastos = Val(Me.TxtSeguro.Text) + Val(Me.TxtTransporte.Text) + Val(Me.TxtAlmacen.Text) + Val(Me.TxtFletes.Text) + Val(Me.TxtAgente.Text) + Val(Me.TxtFletesInternos.Text) + Val(Me.TxtCustodio.Text) + Val(Me.TxtGastosAduana.Text)



        PrecioCompra = 0
        FOB = 0
        IposicionFila = 0
        Registros = Me.BindingDetalle.Count
        TotalCosto = 0
        TotalFOB = Me.TxtTotalFob.Text

        If TotalFOB = 0 Then
            MsgBox("No se ha Totalizado", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        SqlString = "SELECT Cod_Iva, Monto FROM ImpuestosLiquidacion WHERE (Fecha_Liquidacion = CONVERT(DATETIME, '1900-01-01 00:00:00', 102)) AND (Numero_Liquidacion = N'00032')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ImpuestosDetalle")
        TotalIva = 0
        Do While IposicionFila < Registros
            My.Application.DoEvents()
            FOB = Me.BindingDetalle.Item(IposicionFila)("FOB")
            Porciento = (FOB / TotalFOB)

            CodProducto = Me.BindingDetalle.Item(IposicionFila)("Cod_Producto")

            'SqlString = "SELECT  * FROM  Productos INNER JOIN Impuestos ON Productos.Cod_Iva = Impuestos.Cod_Iva WHERE (Productos.Cod_Productos = '" & CodProducto & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "IVA")
            'If DataSet.Tables("IVA").Rows.Count <> 0 Then
            '    TasaIva = DataSet.Tables("IVA").Rows(0)("Impuesto")
            'Else
            '    TasaIva = 0
            'End If

            'MontoIva = MontoIva + FOB * TasaIva
            'Me.TxtMontoIva.Text = MontoIva

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////BUSCO LOS IMPUESTOS PARA CADA PRODUCTO/////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  * FROM ImpuestosProductos INNER JOIN Impuestos ON ImpuestosProductos.Cod_Iva = Impuestos.Cod_Iva  WHERE (Cod_Productos = '" & CodProducto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ImpuestosProductos")
            Registros2 = DataSet.Tables("ImpuestosProductos").Rows.Count
            iPosicion = 0
            TotalImpuestos = 0
            TotalIva = 0
            Do While iPosicion < Registros2
                TasaImpuesto = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Impuesto")


                If DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva") = "15%" Then
                    TotalIva = TotalIva + CDbl(Format(FOB * TasaImpuesto, "##0.00"))
                Else
                    TotalImpuestos = TotalImpuestos + CDbl(Format(FOB * TasaImpuesto, "##0.00"))
                End If
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////AQUI AGREGO EL DETALLE de los impuestos///////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                Registros3 = DataSet.Tables("ImpuestosDetalle").Rows.Count
                CodigoIva = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva")
                Encontrado = False
                iPosicion3 = 0
                Do While iPosicion3 < Registros3

                    CodIvaDetaLLE = DataSet.Tables("ImpuestosDetalle").Rows(iPosicion3)("Cod_Iva")
                    If CodigoIva = CodIvaDetaLLE Then
                        oDataRow = DataSet.Tables("ImpuestosDetalle").Rows(iPosicion3)
                        'oDataRow("Cod_Iva") = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva")
                        oDataRow("Monto") = oDataRow("Monto") + CDbl(Format(FOB * TasaImpuesto, "##0.00"))
                        'DataSet.Tables("ImpuestosDetalle").Rows.Add(oDataRow)
                        Encontrado = True
                    End If
                    'CodigoIva = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva")
                    'Criterio = "Cod_Iva='" & CodigoIva & "'"
                    'DataSet.Tables("ImpuestosDetalle").Rows.Find(Criterio)
                    iPosicion3 = iPosicion3 + 1
                Loop

                If Encontrado = False Then
                    oDataRow = DataSet.Tables("ImpuestosDetalle").NewRow
                    oDataRow("Cod_Iva") = DataSet.Tables("ImpuestosProductos").Rows(iPosicion)("Cod_Iva")
                    oDataRow("Monto") = CDbl(Format(FOB * TasaImpuesto, "##0.00"))
                    DataSet.Tables("ImpuestosDetalle").Rows.Add(oDataRow)
                    Encontrado = True
                End If


                iPosicion = iPosicion + 1
            Loop
            DataSet.Tables("ImpuestosProductos").Clear()


            Me.TDGridImpuestos.DataSource = DataSet.Tables("ImpuestosDetalle")


            If (TotalImpuestos + TotalGastos) <> 0 Then
                PrecioCompra = CDbl(Format(FOB, "##0.00")) + CDbl(Format(TotalImpuestos, "##0.00")) + CDbl(Format((TotalGastos * Porciento), "##0.00"))
            Else
                PrecioCompra = FOB
            End If

            Me.BindingDetalle.Item(IposicionFila)("Precio_Costo") = Format(PrecioCompra, "##0.00")
            Me.BindingDetalle.Item(IposicionFila)("Gasto_Compra") = Format(TotalGastos * Porciento, "##0.00")
            Me.BindingDetalle.Item(IposicionFila)("Gasto_Impuesto") = Format(TotalImpuestos, "##0.00")

            TotalCosto = TotalCosto + PrecioCompra

            IposicionFila = IposicionFila + 1
            TotalImpuestos = 0
        Loop


        Me.TxtTotalCosto.Text = Format(TotalCosto, "##,##0.00")
    End Sub

    Private Sub CmbMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMoneda.SelectedIndexChanged

    End Sub

    Private Sub TrueDBGridComponentes_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.ClientSizeChanged

    End Sub

    Private Sub TrueDBGridComponentes_ContextMenuChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.ContextMenuChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkProrratearPeso.CheckedChanged

    End Sub

    Private Sub TxtTotalFob_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTotalFob.TextChanged

    End Sub

    Private Sub TrueDBGridComponentes_ContextMenuStripChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.ContextMenuStripChanged

    End Sub
End Class