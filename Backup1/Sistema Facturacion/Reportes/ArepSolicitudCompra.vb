Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepSolicitudCompra 
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Me.LblImpreso.Text = "Impreso: " & Format(Now, "Long Date")
    End Sub

End Class
