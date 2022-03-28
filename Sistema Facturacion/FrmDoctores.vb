Public Class FrmDoctores
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Public Sub Limpiar_Doctores(ByVal LimpiarCodigo As Boolean)
        If LimpiarCodigo = True Then
            Me.TxtCodigoMinsa.Text = ""
        End If
        Me.Nombres.Text = ""
        Me.Apellidos.Text = ""
        Me.TxtDireccion.Text = ""
        Me.Telefono.Text = ""
        Me.Correo.Text = ""
        Me.CboEspecialidad.Text = ""
        Me.ChkActivo.Checked = False

    End Sub

    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click
        Grabar_Doctores(Me.TxtCodigoMinsa.Text, Nombres.Text, Apellidos.Text, Telefono.Text, Correo.Text, Me.CboEspecialidad.Text, Me.TxtDireccion.Text, "Doctor", Me.ChkActivo.Checked)
        Limpiar_Doctores(True)
    End Sub

    Private Sub TxtCodigoMinsa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoMinsa.TextChanged
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.TxtCodigoMinsa.Text = "-----0-----" Then
            Exit Sub
        End If

        If Me.TxtCodigoMinsa.Text <> "" Then
            SqlString = "SELECT dbo.Doctores.* FROM dbo.Doctores WHERE (Codigo_Minsa = '" & Me.TxtCodigoMinsa.Text & "') AND (Tipo = 'Doctor')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Doctores")
            If Not DataSet.Tables("Doctores").Rows.Count = 0 Then

                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Nombre_Doctor")) Then
                    Me.Nombres.Text = DataSet.Tables("Doctores").Rows(0)("Nombre_Doctor")
                End If
                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Apellido_Doctor")) Then
                    Me.Apellidos.Text = DataSet.Tables("Doctores").Rows(0)("Apellido_Doctor")
                End If
                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Telefono_Doctor")) Then
                    Me.Telefono.Text = DataSet.Tables("Doctores").Rows(0)("Telefono_Doctor")
                End If
                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Correo_Doctor")) Then
                    Me.Correo.Text = DataSet.Tables("Doctores").Rows(0)("Correo_Doctor")
                End If
                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Especialidad_Doctor")) Then
                    Me.CboEspecialidad.Text = DataSet.Tables("Doctores").Rows(0)("Especialidad_Doctor")
                End If
                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Direccion_Doctor")) Then
                    Me.TxtDireccion.Text = DataSet.Tables("Doctores").Rows(0)("Direccion_Doctor")
                End If

                If Not IsDBNull(DataSet.Tables("Doctores").Rows(0)("Activo")) Then
                    Me.ChkActivo.Checked = DataSet.Tables("Doctores").Rows(0)("Activo")
                End If
            Else
                Limpiar_Doctores(False)
            End If

        End If



    End Sub

    Private Sub CmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "Doctores"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCodigoMinsa.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub FrmDoctores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT DISTINCT Especialidad_Doctor  FROM Doctores"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Doctores")

        Me.CboEspecialidad.DataSource = DataSet.Tables("Doctores")


    End Sub
End Class