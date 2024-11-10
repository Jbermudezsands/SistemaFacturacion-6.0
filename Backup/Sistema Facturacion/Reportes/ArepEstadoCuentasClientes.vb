Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepEstadoCuentasClientes 
    Public Balance As Double = 0, TipoReporte As String = ""
    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Debito As Double = 0, Credito As Double = 0

        If TipoReporte = "Proveedor" Then

            If Me.TxtDebito.Text <> "" Then
                Debito = Me.TxtDebito.Text
            End If

            If Me.TxtCredito.Text <> "" Then
                Credito = Me.TxtCredito.Text
            End If

            Balance = Balance + Credito - Debito

        Else
            If Me.TxtDebito.Text <> "" Then
                Debito = Me.TxtDebito.Text
            End If

            If Me.TxtCredito.Text <> "" Then
                Credito = Me.TxtCredito.Text
            End If

            Balance = Balance + Debito - Credito
        End If
        Me.TxtBalance.Text = Format(Balance, "##,##0.00")


    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim SaldoInicial As Double, CodigoCliente As String, Moneda As String

        CodigoCliente = Me.TxtCodigoCliente.Text

        If My.Forms.FrmReportes.OptCordobas.Checked = True Then
            Me.LblMoneda.Text = "Expresado en Cordobas"
        Else
            Me.LblMoneda.Text = "Expresado en Dolares"
        End If


        If FrmReportes.OptCordobas.Checked = True Then
            Moneda = "Cordobas"
        Else
            Moneda = "Dolares"
        End If

        If TipoReporte = "Proveedor" Then
            SaldoInicial = FrmReportes.SaldoInicialProveedor(CodigoCliente, FrmReportes.DTPFechaIni.Value, Moneda)
            Me.LblCodigo.Text = "Codigo Proveedor"
            Me.LblNombre.Text = "Nombre Proveedor"
            Me.Label1.Text = "Estado de Cuenta x Proveedor"
        Else
            SaldoInicial = FrmReportes.SaldoInicialCliente(CodigoCliente, FrmReportes.DTPFechaIni.Value, Moneda)
        End If
        Me.TxtSaldoInicial.Text = Format(SaldoInicial, "##,##0.00")
        Balance = SaldoInicial
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
