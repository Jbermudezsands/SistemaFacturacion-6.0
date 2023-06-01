Public Class FrmEscolaridad
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmEscolaridad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT dbo.Escolaridad.* FROM  dbo.Escolaridad"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Escolaridad")
        If Not DataSet.Tables("Escolaridad").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("Escolaridad")
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CboCodigoLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoLinea.TextChanged
        Dim SQL As String = "SELECT dbo.Escolaridad.* FROM dbo.Escolaridad WHERE (Cod_Escolaridad = '" & Me.CboCodigoLinea.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Escolaridad")
        If Not DataSet.Tables("Escolaridad").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Escolaridad").Rows(0)("Nombre_Escolaridad")) Then
                Me.TxtNombre.Text = DataSet.Tables("Escolaridad").Rows(0)("Nombre_Escolaridad")
            End If
        Else
            Me.TxtNombre.Text = ""
        End If
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoLinea.Text = ""
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        Try


            If Me.CboCodigoLinea.Text = "" Then
                MsgBox("Se necesita el Codigo de la Escolaridad", MsgBoxStyle.Critical, "Sistema de Facturacion")
                Exit Sub
            End If

            If Me.TxtNombre.Text = "" Then
                MsgBox("Se necesita el Nombre de la Escolaridad", MsgBoxStyle.Critical, "Sistema de Facturacion")
                Exit Sub
            End If

            SQLProveedor = "SELECT dbo.Escolaridad.* FROM dbo.Escolaridad WHERE (Cod_Escolaridad = '" & Me.CboCodigoLinea.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Escolaridad")
            If Not DataSet.Tables("Escolaridad").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                StrSqlUpdate = "UPDATE [Escolaridad] SET [Nombre_Escolaridad] = '" & Me.TxtNombre.Text & "' WHERE (Cod_Escolaridad = '" & Me.CboCodigoLinea.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO [Escolaridad] ([Cod_Escolaridad] ,[Nombre_Escolaridad]) " & _
                               "VALUES('" & Me.CboCodigoLinea.Text & "','" & Me.TxtNombre.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If
            Dim Sql As String = "SELECT dbo.Escolaridad.* FROM  dbo.Escolaridad"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataSet.Tables("Escolaridad").Clear()
            DataAdapter.Fill(DataSet, "Escolaridad")
            If Not DataSet.Tables("Escolaridad").Rows.Count = 0 Then

                Me.CboCodigoLinea.DataSource = DataSet.Tables("Escolaridad")

            End If

            Me.CboCodigoLinea.Text = ""

        Catch ex As Exception
            MsgBox(Err.Number)
        End Try
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar la Escolaridad?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        SQLProveedor = "SELECT dbo.Escolaridad.* FROM dbo.Escolaridad WHERE (Cod_Escolaridad = '" & Me.CboCodigoLinea.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Escolaridad")
        If Not DataSet.Tables("Escolaridad").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Escolaridad] WHERE (Cod_Escolaridad = '" & Me.CboCodigoLinea.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        Dim Sql As String = "SELECT dbo.Escolaridad.* FROM  dbo.Escolaridad"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Escolaridad")
        If Not DataSet.Tables("Escolaridad").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("Escolaridad")

        End If

        Me.CboCodigoLinea.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoEscolaridad"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoLinea.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class