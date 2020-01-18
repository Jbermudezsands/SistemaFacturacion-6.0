Public Class FrmViewer


    Inherits System.Windows.Forms.Form

    Private Sub mnuPrinterSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrinterSetup.Click
        If Not (Me.arvMain.Document Is Nothing) Then
            Me.dlgPrint.Document = Me.arvMain.Document.Printer
            dlgPrint.ShowDialog(Me)
        End If
    End Sub

    Private Sub ExportDocument()
        Dim exportForm As New ExportForm(arvMain.Document)
        exportForm.ShowDialog(Me)
    End Sub 'ExportDocument

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        Me.ExportDocument()
    End Sub

    Private Sub arvMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles arvMain.Load

    End Sub
End Class