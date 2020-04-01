Imports System.Data.SqlClient

Public Class FrmNuevaSolicitud
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public ds As New DataSet, da As New SqlClient.SqlDataAdapter, CmdBuilder As New SqlCommandBuilder, NumeroSolicitud As String
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
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()


        ds.Tables("DetalleSolicitud").Reset()
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Autorizado, Numero_Solicitud FROM Detalle_Solicitud WHERE (Numero_Solicitud = '" & Me.TxtNumeroEnsamble.Text & "') ORDER BY Id_DetalleSolicitud"
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
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 280
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Solicitud").Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Width = 60

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
 

    End Sub
    Public Sub GrabarSolicitud(ByVal Numero_Solicitud As String, ByVal Fecha_Solicitud As Date, ByVal Gerencia_Solicitante As String, ByVal Departamento As String, ByVal Cod_Rubro As String, ByVal Concepto As String, ByVal Estado_Solicitud As String, ByVal Codigo_Bodega As String, ByVal Fecha_Requerido As Date)
        Dim SQLClientes As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        MiConexion.Close()

        SQLClientes = "SELECT Solicitud_Compra.* FROM Solicitud_Compra WHERE (Numero_Solicitud = '" & Numero_Solicitud & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Solicitud")
        If Not DataSet.Tables("Solicitud").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Solicitud_Compra] SET [Gerencia_Solicitante] = '" & Gerencia_Solicitante & "',[Departamento_Solicitante] = '" & Departamento & "' ,[Codigo_Rubro] = '" & Cod_Rubro & "',[Concepto] = '" & Concepto & "' ,[Estado_Solicitud] = '" & Estado_Solicitud & "',[Cod_Bodega] = '" & Codigo_Bodega & "', [Fecha_Requerido] = '" & Fecha_Requerido & "'  WHERE (Numero_Solicitud = '" & Numero_Solicitud & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Solicitud_Compra] ([Numero_Solicitud],[Fecha_Solicitud],[Fecha_Hora_Solicitud] ,[Gerencia_Solicitante],[Departamento_Solicitante],[Codigo_Rubro],[Concepto] ,[Estado_Solicitud] ,[Cod_Bodega], [Fecha_Requerido]) " & _
                           "VALUES ('" & Numero_Solicitud & "', CONVERT(DATETIME, '" & Format(Fecha_Solicitud, "yyyy-MM-dd") & "', 102)  ,CONVERT(DATETIME, '" & Format(Fecha_Solicitud, "yyyy-MM-dd HH:mm:ss") & "', 102) , '" & Gerencia_Solicitante & "', '" & Departamento & "' ,'" & Cod_Rubro & "' ,'" & Concepto & "','" & Estado_Solicitud & "' ,'" & Codigo_Bodega & "', CONVERT(DATETIME, '" & Format(Fecha_Requerido, "yyyy-MM-dd") & "', 102))"
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

        MiConexion.Close()
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LOS VENDEDORES////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT DISTINCT Gerencia_Solicitante FROM Solicitud_Compra ORDER BY Gerencia_Solicitante"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Gerencia")
        Me.CboGerencia.DataSource = DataSet.Tables("Gerencia")
        Me.CboGerencia.Text = DataSet.Tables("Gerencia").Rows(0)("Gerencia_Solicitante")
        MiConexion.Close()

        Sql = "SELECT DISTINCT Departamento_Solicitante FROM Solicitud_Compra ORDER BY Departamento_Solicitante"
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







        If My.Forms.FrmListaSolicitud.Nuevo = True Then
            Me.Timer1.Enabled = True
            Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
            Me.DTPFechaRequerido.Value = Format(Now, "dd/MM/yyyy")
            Me.TxtConcepto.Text = ""
            Me.TxtNumeroEnsamble.Text = "-----0-----"

            SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Autorizado, Numero_Solicitud FROM Detalle_Solicitud WHERE (Descripcion_Producto = N'-100000')"
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
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 280
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Solicitud").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Width = 60

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
        End If

    End Sub

    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        Dim Fecha_Solicitud As Date

        Fecha_Solicitud = CDate(Me.DTPFecha.Text + " " + Me.LblHora.Text)

        GrabarSolicitud(Me.TxtNumeroEnsamble.Text, Fecha_Solicitud, Me.CboGerencia.Text, Me.CboDepartamento.Text, Me.CboRubro.Text, Me.TxtConcepto.Text, "Procesado", Me.CboCodigoBodega.Text, Me.DTPFechaRequerido.Value)

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
        Quien = "CodigoProductosSolicitud"
        My.Forms.FrmConsultas.ShowDialog()

        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.TrueDBGridComponentes.Columns("Cod_Producto").Text = My.Forms.FrmConsultas.Codigo
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
        Me.Close()
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim Sql As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()

        MiConexion.Close()
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////CARGO LAS SOLICUTIDS////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT  Numero_Solicitud, Fecha_Solicitud, Fecha_Hora_Solicitud, Gerencia_Solicitante, Departamento_Solicitante, Codigo_Rubro, Concepto, Estado_Solicitud,  Cod_Bodega, Fecha_Requerido FROM Solicitud_Compra " & _
              "WHERE  (Numero_Solicitud = '" & Me.TxtNumeroEnsamble.Text & "')"
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Gerencia")

        If DataSet.Tables("Gerencia").Rows.Count <> 0 Then
            Me.CboGerencia.Text = DataSet.Tables("Gerencia").Rows(0)("Gerencia_Solicitante")
            Me.CboDepartamento.Text = DataSet.Tables("Gerencia").Rows(0)("Departamento_Solicitante")
            Me.DTPFecha.Text = DataSet.Tables("Gerencia").Rows(0)("Fecha_Solicitud")
            Me.DTPFechaRequerido.Value = DataSet.Tables("Gerencia").Rows(0)("Fecha_Requerido")
            Me.CboCodigoBodega.Text = DataSet.Tables("Gerencia").Rows(0)("Cod_Bodega")
            Me.CboRubro.Text = DataSet.Tables("Gerencia").Rows(0)("Codigo_Rubro")
            Me.TxtConcepto.Text = DataSet.Tables("Gerencia").Rows(0)("Concepto")

            Me.Timer1.Enabled = False
            Me.LblHora.Text = Format(DataSet.Tables("Gerencia").Rows(0)("Fecha_Hora_Solicitud"), "hh:mm:ss tt")


            SqlString = "SELECT Cod_Producto, Descripcion_Producto, Cantidad, Autorizado, Numero_Solicitud FROM Detalle_Solicitud WHERE (Numero_Solicitud =  '" & Me.TxtNumeroEnsamble.Text & "')"
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
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Descripcion_Producto").Width = 280
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Numero_Solicitud").Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Autorizado").Width = 60

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
        End If




        MiConexion.Close()


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub
End Class