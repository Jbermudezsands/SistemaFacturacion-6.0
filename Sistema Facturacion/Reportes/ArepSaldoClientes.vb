Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepSaldoClientes 

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Saldo As Double = 0, MontoCredito As Double = 0, MontoPagado As Double = 0
        'MontoCredito = Me.TxtMontoCredito.Text
        'If Me.TxtMontoPagado.Text <> "" Then
        '    MontoPagado = Me.TxtMontoPagado.Text
        'Else
        '    Me.TxtMontoPagado.Text = "0.00"
        'End If
        'Saldo = MontoCredito - MontoPagado

        'Me.LblSaldo.Text = Format(Saldo, "##,##0.00")

        'My.Forms.FrmReportes.ProgressBar.Value = My.Forms.FrmReportes.ProgressBar.Value + 1

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format


    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Dim Saldo As Double = 0, MontoCredito As Double = 0, MontoPagado As Double = 0

        MontoCredito = Me.TxtTotalMontoCredito.Text
        If Me.TxtTotalPagado.Text <> "" Then
            MontoPagado = Me.TxtTotalPagado.Text
        End If
        Saldo = MontoCredito - MontoPagado
        'Me.TxtTotalSaldo.Text = Format(Saldo, "##,##0.00")
    End Sub
End Class
