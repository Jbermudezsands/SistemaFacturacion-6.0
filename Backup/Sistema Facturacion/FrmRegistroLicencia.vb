Public Class FrmRegistroLicencia

    Private Sub CmdRutoLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRutoLogo.Click
        Dim RutaBD As String
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRuta.Text = RutaBD
    End Sub

    Private Sub CmdProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProcesar.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class