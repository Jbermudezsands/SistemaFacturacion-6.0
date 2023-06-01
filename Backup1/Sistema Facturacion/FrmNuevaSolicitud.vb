Imports System.Data.SqlClient

Public Class FrmNuevaSolicitud
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder, NumeroSolicitud As String
    Public Estatus As String = ""
    Public Sub InsertarRowGrid()
        Dim oTabla As DataTable, iPosicion As Double, CodigoProducto As String

        iPosicion = Me.TrueDBGridComponentes.Row
        CodigoProducto = Me.TrueDBGridComponentes.Columns("Cod_Producto").Text

        CmdBuilder.RefreshSchema()
        oTabla = ds.Tables("DetalleSolicitud").GetChanges(DataRowState.Added)
        If Not IsNothing(oTabla) Then
            '//////////////////SI  TIENE REGISTROS NUEVOS 
            da.Update(oTabla)
            ds.Tables("DetalleSolicitud").AcceptChanges()
            da.Update(ds.Tables("DetalleSolicitud"))

            ActualizarGridInsertRow()

            Me.TrueDBGridComponentes.Row = iPosicion

        Else
            oTabla = ds.Tables("DetalleSolicitud").GetChanges(DataRowState.Modified)
            If Not IsNothing(oTabla) Then
                da.Update(oTabla)
                ds.Tables("DetalleSolicitud").AcceptChanges()
                da.Update(ds.Tables("DetalleSolicitud"))
            End If
        End If

        'ActualizaDetalleBodega(Me.CboCodigoBodega.Text, CodigoProducto)


    End Sub
    Public Sub ActualizarGridInsertRow()
        Dim SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem(), item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()


        ds.Tables("DetalleSolicitud").Reset()
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Autorizado, Numero_Solicitud, Id_DetalleSolicitud, Orden_Compra, Comprado FROM Detalle_Solicitud WHERE (Numero_Solicitud = '" & Me.TxtNumeroEnsamble.Text & "') AND (Orden_Compra IS NULL) ORDER BY Id_DetalleSolicitud"
        ds = New DataSet
        da = New SqlDataAdapter(SqlString, MiConexion)
        CmdBuilder = New SqlCommandBuilder(da)
        da.Fill(ds, "DetalleSolicitud")
        Me.BindingDetalle.DataSource = ds.Tables("DetalleSolicitud")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
        Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Solicitud").Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_DetalleSolicitud").Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Orden_Compra").Visible = False

        If Estatus = "Autorizado" Then
            Me.BtnAutorizar.Visible = False
            Me.BtnOrdenCompra.Visible = True
            Me.TrueDBGridComponentes.Enabled = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 350
        ElseIf Estatus = "Grabado" Then
            Me.BtnAutorizar.Visible = True
            Me.BtnOrdenCompra.Visible = False
            Me.TrueDBGridComponentes.Enabled = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 300
        ElseIf Estatus = "Procesado" Then
            Me.BtnAutorizar.Visible = False
            Me.BtnOrdenCompra.Visible = False
            Me.Button7.Enabled = False
            Me.TrueDBGridComponentes.Enabled = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 300
        Else
            Me.BtnAutorizar.Visible = True
            Me.BtnOrdenCompra.Visible = False
            Me.TrueDBGridComponentes.Enabled = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 350
        End If

        Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
        Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.CycleOnClick = True
        With Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Values

            item.Value = "False"
            item.DisplayValue = Me.ImageList.Images(1)
            .Add(item)

            item = New C1.Win.C1TrueDBGrid.ValueItem()
            item.Value = "True"
            item.DisplayValue = Me.ImageList.Images(0)
            .Add(item)

            Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Translate = True
        End With

        Me.TrueDBGridComponentes.Columns("Comprado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
        Me.TrueDBGridComponentes.Columns("Comprado").ValueItems.CycleOnClick = True
        With Me.TrueDBGridComponentes.Columns("Comprado").ValueItems.Values
            item2.Value = "False"
            item2.DisplayValue = Me.ImageList.Images(1)
            .Add(item2)

            item2 = New C1.Win.C1TrueDBGrid.ValueItem()
            item2.Value = "True"
            item2.DisplayValue = Me.ImageList.Images(0)
            .Add(item2)

            Me.TrueDBGridComponentes.Columns("Comprado").ValueItems.Translate = True
        End With
 

    End Sub
    Public Sub GrabarSolicitud(ByVal Numero_Solicitud As String, ByVal Fecha_Solicitud As Date, ByVal Gerencia_Solicitante As String, ByVal Departamento As String, ByVal Cod_Rubro As String, ByVal Concepto As String, ByVal Estado_Solicitud As String, ByVal Codigo_Bodega As String, ByVal Fecha_Requerido As Date, ByVal CodigoProyecto As String, ByVal Actualizar As Boolean, ByVal SolicitudxCta As Boolean)
        Dim SQLClientes As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        MiConexion.Close()

        SQLClientes = "SELECT Solicitud_Compra.* FROM Solicitud_Compra WHERE (Numero_Solicitud = '" & Numero_Solicitud & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Solicitud")
        If Not DataSet.Tables("Solicitud").Rows.Count = 0 Then
            If Actualizar = True Then
                '//////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Solicitud_Compra] SET [Gerencia_Solicitante] = '" & Gerencia_Solicitante & "',[Departamento_Solicitante] = '" & Departamento & "' ,[Codigo_Rubro] = '" & Cod_Rubro & "',[Concepto] = '" & Concepto & "' ,[Estado_Solicitud] = '" & Estado_Solicitud & "',[Cod_Bodega] = '" & Codigo_Bodega & "', [Fecha_Requerido] = '" & Fecha_Requerido & "', [Solcitud_Cta_Contable] = '" & SolicitudxCta & "'  WHERE (Numero_Solicitud = '" & Numero_Solicitud & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Solicitud_Compra] ([Numero_Solicitud],[Fecha_Solicitud],[Fecha_Hora_Solicitud] ,[Gerencia_Solicitante],[Departamento_Solicitante],[Codigo_Rubro],[Concepto] ,[Estado_Solicitud] ,[Cod_Bodega], [Fecha_Requerido], [CodigoProyecto], [Solcitud_Cta_Contable]) " & _
                           "VALUES ('" & Numero_Solicitud & "', CONVERT(DATETIME, '" & Format(Fecha_Solicitud, "yyyy-MM-dd") & "', 102)  ,CONVERT(DATETIME, '" & Format(Fecha_Solicitud, "yyyy-MM-dd HH:mm:ss") & "', 102) , '" & Gerencia_Solicitante & "', '" & Departamento & "' ,'" & Cod_Rubro & "' ,'" & Concepto & "','" & Estado_Solicitud & "' ,'" & Codigo_Bodega & "', CONVERT(DATETIME, '" & Format(Fecha_Requerido, "yyyy-MM-dd") & "', 102), '" & CodigoProyecto & "' , '" & SolicitudxCta & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        Bitacora(Now, NombreUsuario, "Solicitud", "Grabo el solicitud: " & Numero_Solicitud)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub FrmNuevaSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()






        If My.Forms.FrmListaSolicitud.Nuevo = True Then


            MiConexion.Close()
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////CARGO la gerencia////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Sql = "SELECT GerenciaSolicitud  FROM GerenciaSolicitud "
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Gerencia")
            Me.CboGerencia.DataSource = DataSet.Tables("Gerencia")
            If Not DataSet.Tables("Gerencia").Rows.Count = 0 Then
                Me.CboGerencia.Text = DataSet.Tables("Gerencia").Rows(0)("GerenciaSolicitud")
            End If
            MiConexion.Close()

            Sql = "SELECT DepartamentoSolicitud FROM Departamento_Solicitante ORDER BY DepartamentoSolicitud"
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Departamento")
            Me.CboDepartamento.DataSource = DataSet.Tables("Departamento")
            MiConexion.Close()

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  * FROM   Bodegas"
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas")
            Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
            If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
                Me.CboCodigoBodega.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
            End If
            Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
            Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"

            Sql = "SELECT  * FROM  Rubro"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Rubros")
            If Not DataSet.Tables("Rubros").Rows.Count = 0 Then
                Me.CboRubro.DataSource = DataSet.Tables("Rubros")
                Me.CboRubro.Text = DataSet.Tables("Rubros").Rows(0)("Codigo_Rubro")
            End If

            '/////////////////////////////////////////////PROYECTOS ///////////////////////////////////////////////////////////
            SqlString = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin FROM Proyectos WHERE(Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Proyectos")
            If Not DataSet.Tables("Proyectos").Rows.Count = 0 Then
                Me.CboProyecto.DataSource = DataSet.Tables("Proyectos")
                Me.CboProyecto.Splits.Item(0).DisplayColumns(1).Width = 350
            End If

            Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
            Me.Timer1.Enabled = True

            Me.DTPFechaRequerido.Value = Format(Now, "dd/MM/yyyy")
            Me.TxtConcepto.Text = ""
            Me.TxtNumeroEnsamble.Text = "-----0-----"

            Me.CboCodigoBodega.Enabled = True
            Me.Button3.Enabled = True
            Me.Button7.Enabled = True

            SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Autorizado, Numero_Solicitud, Id_DetalleSolicitud, Orden_Compra FROM Detalle_Solicitud WHERE (Descripcion_Producto = N'-100000')"
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleSolicitud")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleSolicitud")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Locked = False
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 350
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Solicitud").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_DetalleSolicitud").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Orden_Compra").Visible = False

            Me.TrueDBGridComponentes.AllowAddNew = True

            Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
            Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.CycleOnClick = True
            With Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Values



                item.Value = "False"
                item.DisplayValue = Me.ImageList.Images(1)
                .Add(item)

                item = New C1.Win.C1TrueDBGrid.ValueItem()
                item.Value = "True"
                item.DisplayValue = Me.ImageList.Images(0)
                .Add(item)

                Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Translate = True
            End With



        Else
            'MiConexion.Close()
            ''////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ''///////////////////////CARGO la gerencia////////////////////////////////////////////////////////////////////////////////////////
            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'Sql = "SELECT GerenciaSolicitud  FROM GerenciaSolicitud "
            'MiConexion.Open()
            'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            'DataAdapter.Fill(DataSet, "Gerencia")
            'Me.CboGerencia.DataSource = DataSet.Tables("Gerencia")
            'MiConexion.Close()

            'Sql = "SELECT DepartamentoSolicitud FROM Departamento_Solicitante ORDER BY DepartamentoSolicitud"
            'MiConexion.Open()
            'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            'DataAdapter.Fill(DataSet, "Departamento")
            'Me.CboDepartamento.DataSource = DataSet.Tables("Departamento")
            'MiConexion.Close()

            ' ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ' ''//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
            ' ''////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ''SqlString = "SELECT  * FROM   Bodegas"
            ''MiConexion.Open()
            ''DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            ''DataAdapter.Fill(DataSet, "Bodegas")
            ''Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
            ''Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
            ''Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"

            'Sql = "SELECT  * FROM  Rubro"
            'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            'DataAdapter.Fill(DataSet, "Rubros")

            ''/////////////////////////////////////////////PROYECTOS ///////////////////////////////////////////////////////////
            'SqlString = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin FROM Proyectos WHERE(Activo = 1)"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "Proyectos")

        End If

    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim Fecha_Solicitud As Date, CodigoProyecto As String

        Fecha_Solicitud = CDate(Me.DTPFecha.Text + " " + Me.LblHora.Text)

        If Not Me.CboProyecto.Text = "" Then
            CodigoProyecto = Me.CboProyecto.Columns(0).Text
        Else
            CodigoProyecto = ""
        End If

        GrabarSolicitud(Me.TxtNumeroEnsamble.Text, Fecha_Solicitud, Me.CboGerencia.Text, Me.CboDepartamento.Text, Me.CboRubro.Text, Me.TxtConcepto.Text, "Grabado", Me.CboCodigoBodega.Text, Me.DTPFechaRequerido.Value, CodigoProyecto, False, Me.ChkSolcitudxCta.Checked)

        InsertarRowGrid()


    End Sub
    Public Function ConsecutivoSolicitud() As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String, Consecutivo As Double, NumeroSolicitud As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
            ConsecutivoSolicitud = Me.TxtNumeroEnsamble.Text
            Exit Function
        End If


        MiConexion.Close()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Solicitud FROM Consecutivos"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consecutivo")
        Consecutivo = 0
        If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
            Consecutivo = DataSet.Tables("Consecutivo").Rows(0)("Solicitud")
            Consecutivo = Consecutivo + 1
        End If

        NumeroSolicitud = Format(Consecutivo, "0000#")
        '//////////////////////////////////////////////////////////////
        '/////////////////////BUSCO SI EXISTE ESTE CONSECUTIVO EN LA SOLICITUD ////////////////

        SqlString = "SELECT  Solicitud_Compra.* FROM Solicitud_Compra WHERE  (Numero_Solicitud = '" & NumeroSolicitud & "')"
        'MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Solicitud")
        If Not DataSet.Tables("Solicitud").Rows.Count = 0 Then

            '//////////////////////////SI EXISTE BUSCO EL NUMERO SIGUIENTE ////////////////////////////////
            SqlString = "SELECT  Solicitud_Compra.* FROM Solicitud_Compra ORDER BY Numero_Solicitud DESC"
            'MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Solicitud2")
            Consecutivo = 0
            If Not DataSet.Tables("Solicitud2").Rows.Count = 0 Then
                Consecutivo = DataSet.Tables("Solicitud2").Rows(0)("Numero_Solicitud")
                Consecutivo = Consecutivo + 1
            End If


        End If

        StrSqlUpdate = "UPDATE [Consecutivos] SET [Solicitud] = " & Consecutivo & " "
        'MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()



        ConsecutivoSolicitud = Format(Consecutivo, "0000#")



    End Function






    Private Sub TrueDBGridComponentes_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeUpdate
        Dim Numero_Solicitud As String
        Dim Consecutivo As Double
        '////////////////////////////////////BUSCO EL CONSECUTIVO DE LA SOLICITUD ////////////////////////////////////////////

        Numero_Solicitud = ConsecutivoSolicitud()
        Me.TrueDBGridComponentes.Columns("Numero_Solicitud").Text = Numero_Solicitud
        Me.TxtNumeroEnsamble.Text = Numero_Solicitud

        Consecutivo = CDbl(Numero_Solicitud)
        'Consecutivo = Consecutivo + 1

        MiConexion.Close()





    End Sub

    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick
        Dim i As Double, CodigoProducto As String
        Quien = "CodigoProductosSolicitud"
        My.Forms.FrmConsultas.ShowDialog()

        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then

            CodigoProducto = My.Forms.FrmConsultas.Codigo
            '/////////////////////////////////////////////////////////////////////////////////
            '///////////////////////RECORRO EL GRID PARA BUSCAR CODIGO REPETIDOS ///////////////
            '/////////////////////////////////////////////////////////////////////////////////////////
            i = 0
            Do While Me.TrueDBGridComponentes.RowCount > i
                If Me.TrueDBGridComponentes.Item(i)("Cod_Producto") = CodigoProducto Then
                    MsgBox("Ya Existe este producto en la Solicitud", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                    Exit Sub
                End If

                i = i + 1
            Loop



            Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = CodigoProducto
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Text = My.Forms.FrmConsultas.Descripcion
            Me.TrueDBGridComponentes.Columns("Cantidad").Text = 1
            Me.TrueDBGridComponentes.Columns("Autorizado").Text = 0

        End If

    End Sub


    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Resultado As Double, CodProducto As String, iPosicion As Double, PrecioUnitario As Double, PrecioNeto As Double, Importe As Double, Cantidad As Double
        Dim idDetalle As Double, NombreProducto As String, Descuento As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaFactura As String, oDataRow As DataRow, oTablaBorrados As DataTable
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumeroFactura As String


        Resultado = MsgBox("¿Esta Seguro de Eliminar la Linea?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If



        FechaFactura = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")

        CodProducto = Me.TrueDBGridComponentes.Columns(0).Text

        Bitacora(Now, NombreUsuario, "Solicitud de Compra", "Se elimino la solicitud: " & CodProducto & " " & Me.TxtNumeroEnsamble.Text)

        iPosicion = Me.BindingDetalle.Position

        If Me.BindingDetalle.Count <> 0 Then

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////BORRO EL REGISTRO SELECCIONADO CARGANDOLO EN DATAROW ///////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            oDataRow = ds.Tables("DetalleSolicitud").Rows(iPosicion)
            oDataRow.Delete()

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////Obtengo las filas borradas/////////////////////////////////////////////////////////////////////////////////
            oTablaBorrados = ds.Tables("DetalleSolicitud").GetChanges(DataRowState.Deleted)
            If Not IsNothing(oTablaBorrados) Then
                '//////////////////SI NO TIENE REGISTROS EN BORRADOS ESTAN EN PANTALLA LOS CAMBIOS 77777777
                da.Update(oTablaBorrados)
            End If
            ds.Tables("DetalleSolicitud").AcceptChanges()
            da.Update(ds.Tables("DetalleSolicitud"))



        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim Registros As Double, i As Double

        Registros = Me.TrueDBGridComponentes.RowCount
        i = 0
        Do While Registros > i
            If Estatus = "Autorizado" Then
                Me.TrueDBGridComponentes.Item(i)("Comprado") = 0
                InsertarRowGrid()
            End If
            i = i + 1
        Loop


        Me.Close()
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim Sql As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem(), item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim CodigoProyecto As String = ""

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Exit Sub
        End If





        MiConexion.Close()
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LAS SOLICUTIDS////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT  Numero_Solicitud, Fecha_Solicitud, Fecha_Hora_Solicitud, Gerencia_Solicitante, Departamento_Solicitante, Codigo_Rubro, Concepto, Estado_Solicitud,  Cod_Bodega, CodigoProyecto, Fecha_Requerido, Solcitud_Cta_Contable  FROM Solicitud_Compra " & _
              "WHERE  (Numero_Solicitud = '" & Me.TxtNumeroEnsamble.Text & "')"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Gerencia")

        If DataSet.Tables("Gerencia").Rows.Count <> 0 Then


            MiConexion.Close()
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////CARGO la gerencia////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Sql = "SELECT GerenciaSolicitud  FROM GerenciaSolicitud "
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "GerenciaSolicitud")
            Me.CboGerencia.DataSource = DataSet.Tables("GerenciaSolicitud")
            MiConexion.Close()

            Sql = "SELECT DepartamentoSolicitud FROM Departamento_Solicitante ORDER BY DepartamentoSolicitud"
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Departamento")
            Me.CboDepartamento.DataSource = DataSet.Tables("Departamento")
            MiConexion.Close()

            ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ''//////////////////////////CARGO LAS BODEGAS////////////////////////////////////////////////////////////////////
            ''////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Sql = "SELECT  * FROM   Bodegas"
            MiConexion.Open()
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Bodegas")
            Me.CboCodigoBodega.DataSource = DataSet.Tables("Bodegas")
            Me.CboCodigoBodega.Columns(0).Caption = "Codigo"
            Me.CboCodigoBodega.Columns(1).Caption = "Nombre Bodega"

            Sql = "SELECT  * FROM  Rubro"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Rubros")
            Me.CboRubro.DataSource = DataSet.Tables("Rubros")

            '/////////////////////////////////////////////PROYECTOS ///////////////////////////////////////////////////////////
            Sql = "SELECT CodigoProyectos, NombreProyectos, FechaInicio, FechaFin FROM Proyectos WHERE(Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Proyectos")
            Me.CboProyecto.DataSource = DataSet.Tables("Proyectos")


            Me.ChkSolcitudxCta.Checked = DataSet.Tables("Gerencia").Rows(0)("Solcitud_Cta_Contable")
            Me.CboGerencia.Text = DataSet.Tables("Gerencia").Rows(0)("Gerencia_Solicitante")
            Me.CboDepartamento.Text = DataSet.Tables("Gerencia").Rows(0)("Departamento_Solicitante")
            Me.DTPFecha.Text = DataSet.Tables("Gerencia").Rows(0)("Fecha_Solicitud")
            Me.DTPFechaRequerido.Value = DataSet.Tables("Gerencia").Rows(0)("Fecha_Requerido")
            Me.CboCodigoBodega.Text = DataSet.Tables("Gerencia").Rows(0)("Cod_Bodega")
            If Not IsDBNull(DataSet.Tables("Gerencia").Rows(0)("CodigoProyecto")) Then
                CodigoProyecto = DataSet.Tables("Gerencia").Rows(0)("CodigoProyecto")
            End If
            Me.CboRubro.Text = DataSet.Tables("Gerencia").Rows(0)("Codigo_Rubro")
            Me.TxtConcepto.Text = DataSet.Tables("Gerencia").Rows(0)("Concepto")

            Sql = "SELECT  CodigoProyectos, NombreProyectos, FechaInicio, FechaFin, Moneda, VentaEstimada, CostoEstimado, Activo FROM Proyectos WHERE  (CodigoProyectos = '" & CodigoProyecto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "ConsultaProyectos")
            If DataSet.Tables("ConsultaProyectos").Rows.Count <> 0 Then
                Me.CboProyecto.Text = DataSet.Tables("ConsultaProyectos").Rows(0)("NombreProyectos")
            End If



            Me.Timer1.Enabled = False
            Me.LblHora.Text = Format(DataSet.Tables("Gerencia").Rows(0)("Fecha_Hora_Solicitud"), "hh:mm:ss tt")


            SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Autorizado, Comprado, Numero_Solicitud, Id_DetalleSolicitud, Orden_Compra FROM Detalle_Solicitud WHERE (Numero_Solicitud =  '" & Me.TxtNumeroEnsamble.Text & "') AND (Orden_Compra IS NULL)"
            ds = New DataSet
            da = New SqlDataAdapter(SqlString, MiConexion)
            CmdBuilder = New SqlCommandBuilder(da)
            da.Fill(ds, "DetalleSolicitud")
            Me.BindingDetalle.DataSource = ds.Tables("DetalleSolicitud")
            Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Locked = True
            Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Solicitud").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Locked = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_DetalleSolicitud").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Orden_Compra").Visible = False

            Me.CboCodigoBodega.Enabled = False
            Me.Button3.Enabled = False
            Me.Button7.Enabled = False

            Me.TrueDBGridComponentes.AllowAddNew = False

            If Estatus = "Autorizado" Then
                Me.BtnAutorizar.Visible = False
                Me.BtnOrdenCompra.Visible = True
                Me.TrueDBGridComponentes.Enabled = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Width = 60
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Locked = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Visible = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 300
            ElseIf Estatus = "Grabado" Then
                Me.BtnAutorizar.Visible = True
                Me.BtnOrdenCompra.Visible = False
                Me.Button7.Enabled = True
                Me.TrueDBGridComponentes.Enabled = True
                Me.TrueDBGridComponentes.AllowAddNew = True
                Me.Button3.Enabled = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Width = 60
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 350
            ElseIf Estatus = "Procesado" Then
                Me.BtnAutorizar.Visible = False
                Me.BtnOrdenCompra.Visible = False
                Me.TrueDBGridComponentes.Enabled = False

                ds.Tables("DetalleSolicitud").Reset()
                SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Autorizado, Comprado, Numero_Solicitud, Id_DetalleSolicitud, Orden_Compra FROM Detalle_Solicitud WHERE (Numero_Solicitud =  '" & Me.TxtNumeroEnsamble.Text & "')"
                ds = New DataSet
                da = New SqlDataAdapter(SqlString, MiConexion)
                CmdBuilder = New SqlCommandBuilder(da)
                da.Fill(ds, "DetalleSolicitud")
                Me.BindingDetalle.DataSource = ds.Tables("DetalleSolicitud")
                Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                Me.TrueDBGridComponentes.Columns("Cod_Producto").Caption = "Codigo"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Button = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Width = 63
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cod_Producto").Locked = True
                Me.TrueDBGridComponentes.Columns("Descripcion_Producto").Caption = "Descripcion"
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Solicitud").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Width = 60
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Id_DetalleSolicitud").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Orden_Compra").Visible = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Width = 60
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Locked = False
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Visible = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 300
            Else
                Me.BtnAutorizar.Visible = True
                Me.BtnOrdenCompra.Visible = False
                Me.TrueDBGridComponentes.Enabled = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Width = 60
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Locked = True
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 350
                Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Comprado").Visible = False
            End If

            Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
            Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.CycleOnClick = True
            With Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Values
                item.Value = "False"
                item.DisplayValue = Me.ImageList.Images(1)
                .Add(item)

                item = New C1.Win.C1TrueDBGrid.ValueItem()
                item.Value = "True"
                item.DisplayValue = Me.ImageList.Images(0)
                .Add(item)

                Me.TrueDBGridComponentes.Columns("Autorizado").ValueItems.Translate = True
            End With

            Me.TrueDBGridComponentes.Columns("Comprado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
            Me.TrueDBGridComponentes.Columns("Comprado").ValueItems.CycleOnClick = True
            With Me.TrueDBGridComponentes.Columns("Comprado").ValueItems.Values
                item2.Value = "False"
                item2.DisplayValue = Me.ImageList.Images(1)
                .Add(item2)

                item2 = New C1.Win.C1TrueDBGrid.ValueItem()
                item2.Value = "True"
                item2.DisplayValue = Me.ImageList.Images(0)
                .Add(item2)

                Me.TrueDBGridComponentes.Columns("Comprado").ValueItems.Translate = True
            End With


        End If




        MiConexion.Close()


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim Fecha_Solicitud As Date, CodigoProyecto As String

        If Not Me.CboProyecto.Text = "" Then
            CodigoProyecto = Me.CboProyecto.Columns(0).Text
        Else
            CodigoProyecto = ""
        End If

        Fecha_Solicitud = CDate(Me.DTPFecha.Text + " " + Me.LblHora.Text)
        GrabarSolicitud(Me.TxtNumeroEnsamble.Text, Fecha_Solicitud, Me.CboGerencia.Text, Me.CboDepartamento.Text, Me.CboRubro.Text, Me.TxtConcepto.Text, "Grabado", Me.CboCodigoBodega.Text, Me.DTPFechaRequerido.Value, CodigoProyecto, True, Me.ChkSolcitudxCta.Checked)
        Me.Close()

    End Sub

    Private Sub BtnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutorizar.Click
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim NumSolicitud As String, Resultado As Double, iPosicion As Double

        MiConexion.Close()


        iPosicion = My.Forms.FrmListaSolicitud.TDGridSolicitud.Row
        NumSolicitud = My.Forms.FrmListaSolicitud.TDGridSolicitud.Item(iPosicion)("Numero_Solicitud")

        ''''''''''''''''''''''''''''''''CAMBIO EL ESTATUS DE LA SOLICITUD---------------------------------------------
        StrSqlUpdate = "UPDATE [Solicitud_Compra] SET [Estado_Solicitud] = 'Autorizado' WHERE (Numero_Solicitud = '" & NumSolicitud & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery


        StrSqlUpdate = "UPDATE [Detalle_Solicitud] SET [Autorizado] = 'True'  WHERE (Numero_Solicitud = '" & NumSolicitud & "')"
        'MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        MsgBox("Autorizado con Exito!!!", MsgBoxStyle.Exclamation, "Zeus Facturacion")

        My.Forms.FrmListaSolicitud.BtnActualizar_Click(sender, e)
        Me.Close()
    End Sub

    Private Sub BtnOrdenCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOrdenCompra.Click
        Dim ConsecutivoCompra As Double, NumeroCompra As String
        Dim Fecha_Solicitud As Date, i As Double, Registros As Double, Descripcion As String
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, CodigoProveedor As String, Nombres As String, Apellidos As String
        Dim CodigoProducto As String, Comprado As Boolean, Cantidad As Double, iDetalleSolicitud As Double = 0
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Fecha_Compra As Date, Fecha_Vence As Date, Fecha_Hora As Date
        Dim CodigoProyecto As String

        Fecha_Solicitud = CDate(Me.DTPFecha.Text + " " + Me.LblHora.Text)
        Fecha_Compra = Format(Now, "dd/MM/yyyy")
        Fecha_Vence = Format(Now, "dd/MM/yyyy")
        Fecha_Hora = Now

        My.Forms.FrmFecha.ShowDialog()
        Fecha_Compra = Format(My.Forms.FrmFecha.DTPFechaRequerido.Value, "dd/MM/yyyy")

        ConsecutivoCompra = BuscaConsecutivo("Orden_Compra")
        NumeroCompra = Format(ConsecutivoCompra, "0000#")


        CodigoProyecto = ""
        If Not Me.CboProyecto.Text = "" Then
            CodigoProyecto = Me.CboProyecto.Columns(0).Text
        End If


        '//////////////////////////////////////SELECCIONO EL PRIMER PROVEEDOR PARA LLENAR LOS DATOS BASICOS DE LA ORDEN DE COMPRA PARA SU POSTERIOR CAMBIO ////////////////
        SqlString = "SELECT Cod_Proveedor, Nombre_Proveedor, Apellido_Proveedor, Direccion_Proveedor, Telefono, Cod_Cuenta_Proveedor, Cod_Cuenta_Pagar,  Cod_Cuenta_Cobrar, Merma, InventarioFisico, RUC, CodRuta FROM Proveedor ORDER BY Cod_Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If DataSet.Tables("Proveedor").Rows.Count <> 0 Then
            CodigoProveedor = DataSet.Tables("Proveedor").Rows(0)("Cod_Proveedor")
            Nombres = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
            Apellidos = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")

            '//////////////////////////////////GRABO LOS ENCABEZADOS ///////////////////////////////////////////////////////////////////////
            If Me.ChkSolcitudxCta.Checked = False Then
                GrabaEncabezadoCompras(NumeroCompra, Fecha_Compra, "Orden de Compra", CodigoProveedor, Me.CboCodigoBodega.Text, Nombres, Apellidos, Fecha_Compra, Val(0), Val(0), Val(0), Val(0), "Cordobas", "Procesado por la Solicitud de Compra " & Me.TxtNumeroEnsamble.Text, CodigoProyecto, Me.ChkSolcitudxCta.Checked)
            Else
                GrabaEncabezadoCompras(NumeroCompra, Fecha_Compra, "Orden de Compra", CodigoProveedor, Me.CboCodigoBodega.Text, Nombres, Apellidos, Fecha_Compra, Val(0), Val(0), Val(0), Val(0), "Cordobas", "Procesado por la Solicitud de Compra " & Me.TxtNumeroEnsamble.Text, CodigoProyecto, Me.ChkSolcitudxCta.Checked)
            End If


            Registros = Me.TrueDBGridComponentes.RowCount
            i = 0
            Do While Registros > i

                CodigoProducto = Me.TrueDBGridComponentes.Item(i)("Cod_Producto")
                Descripcion = Me.TrueDBGridComponentes.Item(i)("Descripcion_Producto")
                Comprado = Me.TrueDBGridComponentes.Item(i)("Comprado")
                Cantidad = Me.TrueDBGridComponentes.Item(i)("Cantidad")
                iDetalleSolicitud = Me.TrueDBGridComponentes.Item(i)("Id_DetalleSolicitud")


                MiConexion.Close()
                If Comprado = True Then
                    Me.TrueDBGridComponentes.Item(i)("Orden_Compra") = NumeroCompra


                    '/////////////////////////////////////ACTUALIZO EL REGISTRO //////////////////////////////////////
                    MiConexion.Close()
                    StrSqlUpdate = "UPDATE [Detalle_Solicitud] SET [Orden_Compra] = '" & NumeroCompra & "' ,[Comprado] = 1 WHERE (Numero_Solicitud = '" & Me.TxtNumeroEnsamble.Text & "') AND (Id_DetalleSolicitud = " & iDetalleSolicitud & ") AND (Orden_Compra IS NULL)"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery


                    If CodigoProducto = "" Then
                        MsgBox("No se Digito el Codigo del Producto, se Cancela el proceso", MsgBoxStyle.Critical, "Zeus factuacion")
                    Else
                        GrabaDetalleCompraSolicitud(NumeroCompra, CodigoProducto, 0, 0, 0, 0, Cantidad, "0000", "01/01/1900", Descripcion, "Cordobas", Fecha_Compra, "Orden de Compra")
                    End If
                    '////////////////////////////////////////GRABO EL DETALLE DE ORDEN DE COMPRA ////////////////////////////////

                End If
                i = i + 1
            Loop


            '//////////////////////////////////////CONSULTO SI TODOS LOS PRODUCTOS ESTAN COMPRADOS ////////////////
            SqlString = "SELECT * FROM Detalle_Solicitud WHERE (Numero_Solicitud = '" & Me.TxtNumeroEnsamble.Text & "') AND (Orden_Compra IS NULL) "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            MiConexion.Close()
            If DataSet.Tables("Consulta").Rows.Count = 0 Then
                '///////////////////////////////SI YA NO EXISTEN PRODUCTOS PENDIENTES POR COMPRAR PROCESO LA SOLICITUD ///////////////////////////////
                MiConexion.Open()
                StrSqlUpdate = "UPDATE [Solicitud_Compra] SET [Estado_Solicitud] = 'Procesado' WHERE (Numero_Solicitud = '" & Me.TxtNumeroEnsamble.Text & "')"
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

            Me.Hide()

            '//////////////////////////////////////////CARGO LA ORDEN DE COMPRA EN EL MODULO DE COMPRAS //////////////

            My.Forms.FrmCompras.EsSolicitud = True
            My.Forms.FrmCompras.Fecha_Compra = Fecha_Compra
            My.Forms.FrmCompras.FechaHoraCompra = Fecha_Hora
            My.Forms.FrmCompras.NumeroCompra = NumeroCompra
            My.Forms.FrmCompras.TipoCompra = "Orden de Compra"
            My.Forms.FrmCompras.ShowDialog()
            My.Forms.FrmCompras.EsSolicitud = False

            Me.Close()

            My.Forms.FrmListaSolicitud.BtnActualizar_Click(sender, e)

        Else
            MsgBox("Se Requiere un Proveedor almenos para generar Orden de compra", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If





    End Sub

    Private Sub Grupo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grupo.Enter

    End Sub

    Private Sub C1Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button4.Click
        Quien = "ProyectosFactura"
        My.Forms.FrmConsultas.ShowDialog()
        If Not My.Forms.FrmConsultas.Descripcion = "" Then
            Me.CboProyecto.Text = My.Forms.FrmConsultas.Descripcion
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, RutaLogo As String
        Dim ArepSolicitudCompra As New ArepSolicitudCompra, SqlDetalle As String, NumeroSolicitud As String, sQLDatos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            MsgBox("Debe Grabar primero la solicitud", MsgBoxStyle.Exclamation, "Zeus Facturacion")
            Exit Sub
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            ArepSolicitudCompra.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepSolicitudCompra.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepSolicitudCompra.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                ArepSolicitudCompra.LblTelefonos.Text = "Telefono: " & DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
            End If

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepSolicitudCompra.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If
        End If

        NumeroSolicitud = Me.TxtNumeroEnsamble.Text
        ArepSolicitudCompra.TxtProyecto.Text = Me.CboProyecto.Text

        SqlDetalle = "SELECT Detalle_Solicitud.Cod_Producto, Detalle_Solicitud.Descripcion_Producto, Detalle_Solicitud.Cantidad, Detalle_Solicitud.Autorizado, Detalle_Solicitud.Comprado, Detalle_Solicitud.Numero_Solicitud, Detalle_Solicitud.Id_DetalleSolicitud, Detalle_Solicitud.Orden_Compra, Solicitud_Compra.Fecha_Solicitud, Solicitud_Compra.Gerencia_Solicitante, Solicitud_Compra.Departamento_Solicitante, Solicitud_Compra.Codigo_Rubro, Solicitud_Compra.Concepto, Solicitud_Compra.Cod_Bodega, Solicitud_Compra.Fecha_Requerido, Solicitud_Compra.CodigoProyecto, Productos.Cod_Productos, Productos.Unidad_Medida, Solicitud_Compra.Solcitud_Cta_Contable FROM Detalle_Solicitud INNER JOIN Solicitud_Compra ON Detalle_Solicitud.Numero_Solicitud = Solicitud_Compra.Numero_Solicitud INNER JOIN Productos ON Detalle_Solicitud.Cod_Producto = Productos.Cod_Productos  " & _
                     "WHERE (Detalle_Solicitud.Numero_Solicitud = '" & NumeroSolicitud & "')"   '(Detalle_Solicitud.Orden_Compra IS NULL) AND 

        Sql.ConnectionString = Conexion
        Sql.SQL = SQlDetalle
        ArepSolicitudCompra.DataSource = SQL
        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepSolicitudCompra.Document
        ViewerForm.Show()
        ArepSolicitudCompra.Run(False)
    End Sub

    Private Sub CboProyecto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProyecto.TextChanged

    End Sub
End Class