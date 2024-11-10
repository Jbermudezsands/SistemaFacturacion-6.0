Public Class FrmLotesInfo
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmLotesInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String = ""

        '////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////CARGO LA LISTA DE LOTES ////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////

        SqlString = "SELECT  *   FROM Lote"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lotes")

        Me.CboLotes.DataSource = DataSet.Tables("Lotes")



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Forms.FrmNuevoLote.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Forms.FrmListaLotes.ShowDialog()

        Me.CboLotes.Text = My.Forms.FrmListaLotes.NumeroLote
        'Me.DTPFechaLote.Value = My.Forms.FrmListaLotes.FechaVence
        'Me.TxtNombre.Text = My.Forms.FrmListaLotes.NombreLote

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboLotes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLotes.TextChanged
        Dim Sqlstring As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet


        Me.TxtNumeroLote.Text = Me.CboLotes.Text

        If Me.CboLotes.Text = "" Then
            Me.TxtNumeroLote.Text = ""
            Me.CboLotes.Text = ""
            Me.TxtNombre.Text = ""
            Me.ChkActivo.Visible = True

            '////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////CARGO LA LISTA DE LOTES ////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlString = "SELECT  *   FROM Lote"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Lotes")

            Me.CboLotes.DataSource = DataSet.Tables("Lotes")

        End If
    End Sub

    Private Sub TxtNumeroLote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroLote.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String = "", NumeroLote As String, iPosicion As Double, CodigoBodega As String, FechaVence As Date, ExistenciaLote As Double
        Dim CodigoProducto As String, DescripcionProducto As String
        Dim oDataRow As DataRow, i As Double, Registro As Double = 0


        NumeroLote = Me.TxtNumeroLote.Text


        My.Application.DoEvents()

        '////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////CARGO LA LISTA DE LOTES ////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  *   FROM Lote WHERE     (Numero_Lote = '" & NumeroLote & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Lotes")

        If DataSet.Tables("Lotes").Rows.Count Then
            If Not IsDBNull(DataSet.Tables("Lotes").Rows(0)("Nombre_Lote")) Then
                Me.TxtNombre.Text = DataSet.Tables("Lotes").Rows(0)("Nombre_Lote")
            End If
            Me.DTPFechaLote.Value = DataSet.Tables("Lotes").Rows(0)("FechaVence")

            If DataSet.Tables("Lotes").Rows(0)("Activo") = True Then
                Me.ChkActivo.Checked = True
            Else
                Me.ChkActivo.Checked = False
            End If



            ''*******************************************************************************************************************************
            ''/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
            ''*******************************************************************************************************************************
            SqlString = "SELECT Numero_Lote, FechaVence, Cantidad as Existencia, Numero_Lote As Codigo_Producto,Numero_Lote As Nombre_Producto, Numero_Lote As Codigo_Bodega   FROM Detalle_Lote WHERE (Numero_Documento = '-1000000000') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ExistenciaLotes")


            SqlString = "SELECT DISTINCT Detalle_Compras.Cod_Producto AS Cod_Producto, Detalle_Compras.Numero_Lote, Lote.FechaVence, Productos.Descripcion_Producto, Compras.Cod_Bodega FROM Detalle_Compras INNER JOIN Lote ON Detalle_Compras.Numero_Lote = Lote.Numero_Lote INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                        "WHERE  (Detalle_Compras.Numero_Lote = '" & NumeroLote & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "LotesDetalle")
            iPosicion = 0

            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Maximum = DataSet.Tables("LotesDetalle").Rows.Count

            Do While DataSet.Tables("LotesDetalle").Rows.Count > iPosicion

                My.Application.DoEvents()

                'CodigoProducto = DataSet.Tables("Lotes").Rows(iPosicion)("Cod_Producto")
                NumeroLote = DataSet.Tables("LotesDetalle").Rows(iPosicion)("Numero_Lote")
                CodigoProducto = DataSet.Tables("LotesDetalle").Rows(iPosicion)("Cod_Producto")
                DescripcionProducto = DataSet.Tables("LotesDetalle").Rows(iPosicion)("Descripcion_Producto")
                CodigoBodega = DataSet.Tables("LotesDetalle").Rows(iPosicion)("Cod_Bodega")



                If Not IsDBNull(DataSet.Tables("LotesDetalle").Rows(iPosicion)("FechaVence")) Then
                    FechaVence = DataSet.Tables("LotesDetalle").Rows(iPosicion)("FechaVence")
                End If

                ExistenciaLote = BuscaExistenciaBodegaLote(CodigoProducto, CodigoBodega, NumeroLote)

                oDataRow = DataSet.Tables("ExistenciaLotes").NewRow
                oDataRow("Numero_Lote") = NumeroLote
                oDataRow("FechaVence") = Format(FechaVence, "dd/MM/yyyy")
                oDataRow("Existencia") = ExistenciaLote
                oDataRow("Codigo_Producto") = CodigoProducto
                oDataRow("Nombre_Producto") = DescripcionProducto
                oDataRow("Codigo_Bodega") = CodigoBodega
                DataSet.Tables("ExistenciaLotes").Rows.Add(oDataRow)



                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
                iPosicion = iPosicion + 1
            Loop

            Me.BindingDetalle.DataSource = DataSet.Tables("ExistenciaLotes")
            Me.TDBGridLotes.DataSource = Me.BindingDetalle.DataSource


        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SqlClientes As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Respuesta As Double



        SqlClientes = "SELECT * FROM Lote WHERE  (Numero_Lote = '" & Me.TxtNumeroLote.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Clientes")
        If Not DataSet.Tables("Clientes").Rows.Count = 0 Then
            Respuesta = MsgBox("El Lote Existe, ¿Desea Modificarlo?", MsgBoxStyle.YesNo, "Zeus Facturacion")
            If Respuesta = 7 Then
                'Me.TxtNumeroLote.Text = ""
                'Me.TxtNombre.Text = ""
                Exit Sub
            End If

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Lote]  SET [Nombre_Lote] =  '" & Me.TxtNombre.Text & "' ,[FechaVence] = '" & Format(Me.DTPFechaLote.Value, "dd/MM/yyyy") & "', [Activo] =  '" & Me.ChkActivo.Checked & "'  WHERE (Numero_Lote = '" & Me.TxtNumeroLote.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else

            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Lote] ([Numero_Lote],[Nombre_Lote],[FechaVence]) VALUES ('" & Me.TxtNumeroLote.Text & "' ,'" & Me.TxtNombre.Text & "' ,'" & Format(Me.DTPFechaLote.Value, "dd/MM/yyyy") & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If


        Me.TxtNombre.Text = ""
        Me.TxtNumeroLote.Text = ""
    End Sub
End Class