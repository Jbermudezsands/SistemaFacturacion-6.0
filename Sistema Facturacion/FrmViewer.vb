Public Class FrmViewer
    Inherits System.Windows.Forms.Form
    Public s_Default_Printer As String = ""
    Private Sub mnuPrinterSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrinterSetup.Click
        If Not (Me.arvMain.Document Is Nothing) Then
            Me.dlgPrint.Document = Me.arvMain.Document.Printer
            dlgPrint.ShowDialog(Me)
        End If
    End Sub
    Private Sub FrmViewer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If s_Default_Printer <> "" Then
            Establecer_Impresora(s_Default_Printer)
        End If
    End Sub 'ExportDocument
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