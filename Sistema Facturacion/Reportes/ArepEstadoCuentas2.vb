Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepEstadoCuentas2 

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Me.LblCargo.Text = Me.TxtTotalCargo.Text
        Me.LblAbono.Text = Me.TxtTotalAbono.Text
        Me.LblMora.Text = Me.TxtTotalMora.Text
        Me.LblSaldoFinal.Text = Me.TxtTotalSaldoFinal.Text

    End Sub
End Class
