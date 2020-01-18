Public Class FrmPermisos
    Public MiConexion As New SqlClient.SqlConnection(Conexion), RContrase�a As Boolean
    Private Sub FrmPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQLUsuarios = "SELECT  Usuario FROM Usuarios WHERE  (Nivel = N'Administrador')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQLUsuarios, MiConexion)
        DataAdapter.Fill(DataSet, "ListaUsuarios")
        If Not DataSet.Tables("ListaUsuarios").Rows.Count = 0 Then
            Me.CboUsuario.DataSource = DataSet.Tables("ListaUsuarios")
        End If


    End Sub

    Private Sub cmdEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEntrar.Click
        Dim DataSetUsuario As New DataSet
        Dim DataAdapterUsuario As New SqlClient.SqlDataAdapter
        Dim SqlUsuario As String


        Dim Contrase�a As String, Usuario As String, BDContrase�a As String

        RContrase�a = False

        If Me.CboUsuario.Text = "" Then
            MsgBox("Seleccione un Usuario", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Not Me.txtPassword.Text = "" Then
            Contrase�a = Me.txtPassword.Text
            Usuario = Me.CboUsuario.Text

            MiConexion.Open()
            SqlUsuario = "SELECT Usuario, Contrase�a, Nivel FROM Usuarios WHERE (Usuario = '" & Usuario & "')"

            DataAdapterUsuario = New SqlClient.SqlDataAdapter(SqlUsuario, MiConexion)
            DataAdapterUsuario.Fill(DataSetUsuario, "Usuarios")
            If Not DataSetUsuario.Tables("Usuarios").Rows.Count = 0 Then
                BDContrase�a = DataSetUsuario.Tables("Usuarios").Rows(0)("Contrase�a")
                Acceso = DataSetUsuario.Tables("Usuarios").Rows(0)("Nivel")

                If BDContrase�a = Contrase�a Then
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////SI LA CONTRASE�A ES ADMINISTRADOR DESBLOQUEO EL PRECIO///////////////////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    RContrase�a = True
                    Me.txtPassword.Text = ""
                    Me.Close()
                Else
                    MsgBox("Contrase�a Incorrecta", MsgBoxStyle.Exclamation, "Sistema Facturacion")
                    MiConexion.Close()
                    RContrase�a = False
                    Exit Sub
                End If


            End If




            MiConexion.Close()

        Else
            MsgBox("Digite la Contrase�a", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RContrase�a = False
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdEntrar_Click(sender, e)
        End If
    End Sub





    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class