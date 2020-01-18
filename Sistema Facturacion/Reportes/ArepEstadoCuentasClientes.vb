Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepEstadoCuentasClientes 
    Public Balance As Double = 0
    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Debito As Double = 0, Credito As Double = 0

        If Me.TxtDebito.Text <> "" Then
            Debito = Me.TxtDebito.Text
        End If

        If Me.TxtCredito.Text <> "" Then
            Credito = Me.TxtCredito.Text
        End If

        Balance = Balance + Debito - Credito
        Me.TxtBalance.Text = Format(Balance, "##,##0.00")

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim SaldoInicial As Double, CodigoCliente As String, Moneda As String

        CodigoCliente = Me.TxtCodigoCliente.Text
        If FrmReportes.OptCordobas.Checked = True Then
            Moneda = "Cordobas"
        Else
            Moneda = "Dolares"
        End If

        SaldoInicial = FrmReportes.SaldoInicialCliente(CodigoCliente, FrmReportes.DTPFechaIni.Value, Moneda)
        Me.TxtSaldoInicial.Text = Format(SaldoInicial, "##,##0.00")
        Balance = SaldoInicial
    End Sub
End Class
