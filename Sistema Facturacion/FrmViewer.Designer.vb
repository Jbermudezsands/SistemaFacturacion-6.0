<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmViewer
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.arvMain = New DataDynamics.ActiveReports.Viewer.Viewer
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuExport = New System.Windows.Forms.MenuItem
        Me.mnuPrinterSetup = New System.Windows.Forms.MenuItem
        Me.dlgPrint = New System.Windows.Forms.PrintDialog
        Me.SuspendLayout()
        '
        'arvMain
        '
        Me.arvMain.BackColor = System.Drawing.SystemColors.Control
        Me.arvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.arvMain.Document = New DataDynamics.ActiveReports.Document.Document("ARNet Document")
        Me.arvMain.Location = New System.Drawing.Point(0, 0)
        Me.arvMain.Name = "arvMain"
        Me.arvMain.ReportViewer.CurrentPage = 0
        Me.arvMain.ReportViewer.MultiplePageCols = 3
        Me.arvMain.ReportViewer.MultiplePageRows = 2
        Me.arvMain.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal
        Me.arvMain.Size = New System.Drawing.Size(731, 491)
        Me.arvMain.TabIndex = 0
        Me.arvMain.TableOfContents.Text = "Table Of Contents"
        Me.arvMain.TableOfContents.Width = 200
        Me.arvMain.TabTitleLength = 35
        Me.arvMain.Toolbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExport, Me.mnuPrinterSetup})
        Me.mnuFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuFile.Text = "&File"
        '
        'mnuExport
        '
        Me.mnuExport.Index = 0
        Me.mnuExport.Text = "Export..."
        '
        'mnuPrinterSetup
        '
        Me.mnuPrinterSetup.Index = 1
        Me.mnuPrinterSetup.Text = "Printer Setup..."
        '
        'FrmViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 491)
        Me.Controls.Add(Me.arvMain)
        Me.Menu = Me.mnuMain
        Me.Name = "FrmViewer"
        Me.Text = "Impresion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents arvMain As DataDynamics.ActiveReports.Viewer.Viewer
    Private WithEvents mnuMain As System.Windows.Forms.MainMenu
    Private WithEvents mnuFile As System.Windows.Forms.MenuItem
    Private WithEvents mnuExport As System.Windows.Forms.MenuItem
    Private WithEvents mnuPrinterSetup As System.Windows.Forms.MenuItem
    Private WithEvents dlgPrint As System.Windows.Forms.PrintDialog
End Class
