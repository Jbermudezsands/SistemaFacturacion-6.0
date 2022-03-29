Public Class FrmConsultorio
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Id_Consultorio As Double, CodigoMinsa As Double
    Private Sub Limpiar_Consultorio()
        Id_Consultorio = -1
        Me.TxtNombre.Text = ""
        Me.CboCodigoDoctor.Text = ""
        Me.LblIdConsultorio.Text = ""
    End Sub


    Private Sub FrmConsultorio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT Codigo_Minsa, Nombre_Doctor + ' ' + Apellido_Doctor AS Nombres FROM Doctores WHERE  (Tipo = 'Doctor') AND (Activo = 1)"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Doctor")
        If Not DataSet.Tables("Doctor").Rows.Count = 0 Then
            Me.CboCodigoDoctor.DataSource = DataSet.Tables("Doctor")
        End If

        Id_Consultorio = -1


    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        CodigoMinsa = Me.CboCodigoDoctor.Columns(0).Text
        Grabar_Consultorio(Id_Consultorio, CodigoMinsa, Me.TxtNombre.Text)
        Limpiar_Consultorio()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Limpiar_Consultorio()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Eliminar_Consultorio(Id_Consultorio)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Quien = "Doctores"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoDoctor.Text = My.Forms.FrmConsultas.Descripcion2
        Me.TxtNombre.Text = My.Forms.FrmConsultas.Descripcion

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "Consultorio"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoDoctor.Text = My.Forms.FrmConsultas.Descripcion2
        Me.TxtNombre.Text = My.Forms.FrmConsultas.Descripcion
        Me.Id_Consultorio = My.Forms.FrmConsultas.IdConsulta
        Me.LblIdConsultorio.Text = Me.Id_Consultorio
    End Sub
End Class