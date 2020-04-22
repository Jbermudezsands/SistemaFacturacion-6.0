Public Class TipoNomina
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub TipoNomina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT  * FROM  TipoNomina"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        If Not DataSet.Tables("TipoNomina").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("TipoNomina")
        End If
    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged
        Dim SQL As String = "SELECT  *  FROM TipoNomina WHERE  (CodTipoNomina = '" & Me.CboCodigoCliente.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        If Not DataSet.Tables("TipoNomina").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("TipoNomina").Rows(0)("TipoNomina")) Then
                Me.TxtNombre.Text = DataSet.Tables("TipoNomina").Rows(0)("TipoNomina")
            End If

            If Not IsDBNull(DataSet.Tables("TipoNomina").Rows(0)("PeriodoNomina")) Then
                CmbTipoPlanilla.Text = DataSet.Tables("TipoNomina").Rows(0)("PeriodoNomina")
            End If
        Else
            Me.TxtNombre.Text = ""

        End If
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLRubros As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        SQLRubros = "SELECT  *  FROM TipoNomina WHERE  (CodTipoNomina = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLRubros, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        If Not DataSet.Tables("TipoNomina").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [TipoNomina] SET [TipoNomina] = '" & Me.TxtNombre.Text & "', [PeriodoNomina] = '" & Me.CmbTipoPlanilla.Text & "' WHERE (CodTipoNomina = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [TipoNomina] ([CodTipoNomina] ,[TipoNomina],[PeriodoNomina]) " & _
                           "VALUES('" & Me.CboCodigoCliente.Text & "','" & Me.TxtNombre.Text & "','" & Me.CmbTipoPlanilla.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If


        DataSet.Reset()
        Dim SQL As String = "SELECT  *  FROM TipoNomina"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        If Not DataSet.Tables("TipoNomina").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("TipoNomina")
        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Tipo de Nomina?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If


        SQLProveedor = "SELECT  *  FROM TipoNomina WHERE  (CodTipoNomina = '" & Me.CboCodigoCliente.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        If Not DataSet.Tables("TipoNomina").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [TipoNomina]  WHERE (CodTipoNomina = '" & Me.CboCodigoCliente.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        DataSet.Reset()
        Dim SQL As String = "SELECT  *  FROM TipoNomina "
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "TipoNomina")
        If Not DataSet.Tables("TipoNomina").Rows.Count = 0 Then
            Me.CboCodigoCliente.DataSource = DataSet.Tables("TipoNomina")
        End If

        Me.CboCodigoCliente.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "TipoNomina"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class