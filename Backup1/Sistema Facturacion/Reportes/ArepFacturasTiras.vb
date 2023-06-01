Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepFacturasTiras 

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format

    End Sub

    Private Sub ArepFacturasTiras_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageStart
        If FrmFacturas.CboReferencia.Text <> "" Then
            Me.Label6.Text = FrmFacturas.CboReferencia.Text
            Me.LblTipoCompra.Text = "Orden"
            Me.LblNota.Visible = True
        Else
            Me.LblNota.Visible = False
        End If
    End Sub
End Class
