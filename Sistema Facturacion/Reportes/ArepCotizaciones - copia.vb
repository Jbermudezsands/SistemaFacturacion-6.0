Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepCotizaciones

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Dim TotalCotizacion As Double

        TotalCotizacion = Me.LblTotal.Text
        Me.LblLetras.Text = Letras(TotalCotizacion, Me.LblMoneda.Text)

    End Sub

    Private Sub ArepCotizaciones_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
