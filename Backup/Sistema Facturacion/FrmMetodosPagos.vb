Public Class FrmMetodosPagos
    Public Numero As String = "", Fecha As String = ""

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.DtpFechavence.Value = Now
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Numero = Me.TxtNumeroTarjeta.Text
        Fecha = Me.DtpFechavence.Value
        Me.Close()
    End Sub
End Class