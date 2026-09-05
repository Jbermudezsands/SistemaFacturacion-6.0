Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document


Public Class ArepVentasCategorias

    Public NombreReporte As String
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format

    End Sub

    Private Sub PageHeader1_Format(sender As Object, e As EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub ArepVentasCategorias_ReportStart(sender As Object, e As EventArgs) Handles Me.ReportStart
        If NombreReporte <> "" Then
            Me.Label1.Text = NombreReporte
        End If
    End Sub
End Class
