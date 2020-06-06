Public Class FrmRevalorizar

    Private Sub FrmRevalorizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        If Me.OptCuentasCobrarRe.Checked = True Then
            Quien = "CodigoCliente"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtRebalorizaDesde.Text = My.Forms.FrmConsultas.Codigo
        ElseIf Me.OptCuentasPagarRe.Checked = True Then
            Quien = "CuentaPagar"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtRebalorizaDesde.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        If Me.OptCuentasCobrarRe.Checked = True Then
            Quien = "CodigoCliente"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtRebalorizarHasta.Text = My.Forms.FrmConsultas.Codigo
        ElseIf Me.OptCuentasPagarRe.Checked = True Then
            Quien = "CuentaPagar"
            My.Forms.FrmConsultas.ShowDialog()
            Me.TxtRebalorizarHasta.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click

    End Sub

    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        If Me.OptCuentasCobrarRe.Checked = True Then

        ElseIf Me.OptCuentasPagarRe.Checked = True Then



        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class