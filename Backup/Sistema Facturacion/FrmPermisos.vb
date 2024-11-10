Public Class FrmPermisos
    Public MiConexion As New SqlClient.SqlConnection(Conexion), RContraseña As Boolean
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


        Dim Contraseña As String, Usuario As String, BDContraseña As String

        RContraseña = False

        If Me.CboUsuario.Text = "" Then
            MsgBox("Seleccione un Usuario", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Not Me.txtPassword.Text = "" Then
            Contraseña = Me.txtPassword.Text
            Usuario = Me.CboUsuario.Text

            MiConexion.Open()
            SqlUsuario = "SELECT Usuario, Contraseña, Nivel FROM Usuarios WHERE (Usuario = '" & Usuario & "')"

            DataAdapterUsuario = New SqlClient.SqlDataAdapter(SqlUsuario, MiConexion)
            DataAdapterUsuario.Fill(DataSetUsuario, "Usuarios")
            If Not DataSetUsuario.Tables("Usuarios").Rows.Count = 0 Then
                BDContraseña = DataSetUsuario.Tables("Usuarios").Rows(0)("Contraseña")
                Acceso = DataSetUsuario.Tables("Usuarios").Rows(0)("Nivel")

                If BDContraseña = Contraseña Then
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////SI LA CONTRASEÑA ES ADMINISTRADOR DESBLOQUEO EL PRECIO///////////////////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    RContraseña = True
                    Me.txtPassword.Text = ""
                    Me.Close()
                Else
                    MsgBox("Contraseña Incorrecta", MsgBoxStyle.Exclamation, "Sistema Facturacion")
                    MiConexion.Close()
                    RContraseña = False
                    Exit Sub
                End If


            End If




            MiConexion.Close()

        Else
            MsgBox("Digite la Contraseña", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RContraseña = False
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