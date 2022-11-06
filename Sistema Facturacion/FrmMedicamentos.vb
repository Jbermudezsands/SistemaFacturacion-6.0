Imports System.Data.SqlClient
Public Class FrmMedicamentos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdPreConsultas As Double, HoraInicio As Date, IdConsultorio As Double, IdDoctor As Double
    Public dsMedicamento As New DataSet, daMedicamento As New SqlClient.SqlDataAdapter, CmdBuilderMedicamento As New SqlCommandBuilder
    Private Sub CmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGuardar.Click

    End Sub

    Private Sub FrmMedicamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class