Public Class FrmAccesosAddPerfil
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQLClientes As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer



        SQLClientes = "SELECT  NombrePerfil FROM Perfil WHERE (NombrePerfil = '" & Me.TxtPerfil.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLClientes, MiConexion)
        DataAdapter.Fill(DataSet, "Perfil")
        If DataSet.Tables("Perfil").Rows.Count = 0 Then
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Perfil] ([NombrePerfil]) VALUES ('" & Me.TxtPerfil.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else

            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "UPDATE [Perfil] SET [NombrePerfil] = '" & Me.TxtPerfil.Text & "' WHERE (NombrePerfil = '" & Me.TxtPerfil.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        Me.Close()
    End Sub
End Class