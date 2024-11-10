Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepLineaVendedorResumen

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Me.LblTotal.Text = "Total " & Me.TxtVendedor.Text
    End Sub
End Class
