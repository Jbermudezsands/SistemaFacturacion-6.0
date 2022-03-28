Public Class FrmConsultorio
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Id_Consultorio As Double
    Private Sub FrmConsultorio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT Codigo_Minsa, Nombre_Doctor + ' ' + Apellido_Doctor AS Nombres FROM Doctores WHERE  (Tipo = 'Doctor') AND (Activo = 1)"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Doctor")
        If Not DataSet.Tables("Doctor").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("Doctor")
        End If

        Id_Consultorio = 1


    End Sub
End Class