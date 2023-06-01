Imports System.Data.SqlClient
Public Class frmDBBackup

    Private Enum Estado_Conexion
        NoComprobada
        Establecida
        NoEstablecida
    End Enum

    Dim EC As Estado_Conexion
    Dim CSBuilder As New SqlConnectionStringBuilder

    'Controlar los eventro de cambio de texto en las cajas de texto.
    Private Sub txts_TextChanged(sender As Object, e As EventArgs) Handles _
        txtServer.TextChanged, txtDB.TextChanged, txtUsername.TextChanged, txtPassword.TextChanged

        'Cada cambio del contenido provocará que el estado de la conexión sea "NoComprobada"
        EC = Estado_Conexion.NoComprobada
        pbConnStatus.BackgroundImage = My.Resources.light_yellow
        lblConnStatus.Text = "Conexión no comprobada."

        'Si los TextBox contienen información habilitamos btnTestConnection, de lo contrario lo deshabilitamos.
        If Not String.IsNullOrEmpty(txtServer.Text) And Not String.IsNullOrEmpty(txtDB.Text) And Not String.IsNullOrEmpty(txtUsername.Text) And Not String.IsNullOrEmpty(txtPassword.Text) Then
            btnTestConnection.Enabled = True
        Else
            btnTestConnection.Enabled = False
        End If

    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click

        'Deshabilitamos btnTestConnection durante la prueba e informamos
        btnTestConnection.Enabled = False
        lblConnStatus.Text = "Comprobando la conexión..."
        lblConnStatus.Refresh()

        'Construimos la cadena de conexión
        With CSBuilder
            .DataSource = txtServer.Text : .InitialCatalog = txtDB.Text : .IntegratedSecurity = False
            .UserID = txtUsername.Text : .Password = txtPassword.Text
        End With

        Dim Cnx As New SqlConnection(CSBuilder.ConnectionString)

        Try
            'Intentamos establecer conexión con el servidor de datos.
            'Si no hay errores, cambiamos la información del estado de la conexión.
            'Y habilitamos las opciones de respaldo
            Cnx.Open()
            My.Application.DoEvents()
            EC = Estado_Conexion.Establecida
            pbConnStatus.BackgroundImage = My.Resources.light_green
            lblConnStatus.Text = "Conexión establecida exitosamente."

            'Ahora obtenemos la información de la base de datos ejecutando el procedimiento almacenado sp_spaceused
            Dim Cmd As New SqlCommand("sp_spaceused", Cnx)
            Cmd.CommandType = CommandType.StoredProcedure

            Dim Dt As New DataTable
            Dim Da As SqlDataAdapter = New SqlDataAdapter(Cmd)

            Da.Fill(Dt)

            Dim Dr As DataRow = Dt.Rows.Item(0)

            lblDBName.Text = Dr.Item("database_name").ToString.Trim
            lblDBSize.Text = Dr.Item("database_size").ToString.Trim
            lblUnallocatedSize.Text = Dr.Item("unallocated space").ToString.Trim

            btnSelectDir.Enabled = True
            txtBackupName.Enabled = True

        Catch ex As Exception

            'Mostramos los errores que se hayan presentado y cambiamos el estado de la conexión
            MessageBox.Show(ex.Message, "Error en la conexión", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Opcional
            EC = Estado_Conexion.NoEstablecida
            pbConnStatus.BackgroundImage = My.Resources.light_red
            lblConnStatus.Text = "Error en la conexión"

            btnSelectDir.Enabled = False
            txtBackupName.Enabled = False

        Finally

            btnTestConnection.Enabled = True
            Cnx.Close()

        End Try

    End Sub

    Private Sub txtBackupName_TextChanged(sender As Object, e As EventArgs) Handles txtBackupName.TextChanged
        If Not String.IsNullOrEmpty(txtBackupName.Text) Then
            btnBackup.Enabled = True
        Else
            btnBackup.Enabled = False
        End If
    End Sub

    Private Sub btnSelectDir_Click(sender As Object, e As EventArgs) Handles btnSelectDir.Click
        'Mostramos un cuadro de diálogo para que el usuario seleccione la carpeta donde se guardará el respaldo
        Dim FBD As New FolderBrowserDialog
        If FBD.ShowDialog() = DialogResult.OK Then
            txtPath.Text = FBD.SelectedPath 'Asignamos la dirección de la carpeta a txtPath
        End If
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click

        'Verificamos que la conexión sea válida
        If EC = Estado_Conexion.Establecida Then

            'Deshabilitando el botón btnBackup durante el respaldo
            btnBackup.Text = "Respaldando..."
            btnBackup.Enabled = False
            btnBackup.Refresh()

            'Variable de texto que contiene la consulta de respaldo a ejecutarse en el servidor
            Dim Query As String = "BACKUP DATABASE " & txtDB.Text.Trim & " TO DISK = '" & txtPath.Text & "\" & txtBackupName.Text & ".bak' WITH FORMAT,  MEDIANAME  = '" & txtBackupName.Text & "', NAME = '" & txtBackupName.Text & "'"

            Try
                'Creamos la conexión y el comando que ejecutará la consulta 
                Dim Cnx As New SqlConnection(CSBuilder.ConnectionString)
                Dim Cmd As New SqlCommand(Query, Cnx)

                Cnx.Open()
                Cmd.ExecuteNonQuery()

                MessageBox.Show("Se ha respaldado la base de datos correctamente.", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

                btnBackup.Text = "Respaldar"
                btnBackup.Enabled = True

            End Try
        Else
            MessageBox.Show("No se ha establecido ninguna conexión con el servidor de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

    End Sub

 
    Private Sub frmDBBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Cadena() As String, SubCadena As String, Cadena2() As String
        Dim i As Integer, j As Integer
        Cadena = Split(Conexion, ";")
        For i = 0 To UBound(Cadena)
            SubCadena = Cadena(i)
            '///////////////////////////////////BUSCO EL SERVIDO Y DATOS DE SQL ///////////////////////////
            Cadena2 = Split(SubCadena, "=")
            If Cadena2.Length = 2 Then
                Select Case Cadena2(0)
                    Case "Password" : Me.txtPassword.Text = Cadena2(1)
                    Case "User ID" : Me.txtUsername.Text = Cadena2(1)
                    Case "Initial Catalog" : Me.txtDB.Text = Cadena2(1)
                    Case "Data Source" : Me.txtServer.Text = Cadena2(1)
                End Select
            End If


        Next i





    End Sub
End Class