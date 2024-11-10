<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMargenes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMargenes))
        Me.C1NavBar1 = New C1.Win.C1Command.C1NavBar
        Me.C1NavBarPanel1 = New C1.Win.C1Command.C1NavBarPanel
        Me.TxtMargen = New System.Windows.Forms.TextBox
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.C1NavBarPanel2 = New C1.Win.C1Command.C1NavBarPanel
        Me.C1NavBarHorizontalRule1 = New C1.Win.C1Command.C1NavBarHorizontalRule
        Me.C1NavBarSectionHeader1 = New C1.Win.C1Command.C1NavBarSectionHeader
        Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder
        Me.C1Chart1 = New C1.Win.C1Chart.C1Chart
        CType(Me.C1NavBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1NavBar1.SuspendLayout()
        Me.C1NavBarPanel1.SuspendLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1NavBarPanel2.SuspendLayout()
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1NavBar1
        '
        Me.C1NavBar1.Controls.Add(Me.C1NavBarPanel1)
        Me.C1NavBar1.Controls.Add(Me.C1NavBarPanel2)
        Me.C1NavBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1NavBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1NavBar1.Name = "C1NavBar1"
        Me.C1NavBar1.ShowOptionsMenu = False
        Me.C1NavBar1.Size = New System.Drawing.Size(561, 442)
        Me.C1NavBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue
        Me.C1NavBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'C1NavBarPanel1
        '
        Me.C1NavBarPanel1.Button.Image = CType(resources.GetObject("resource.Image"), System.Drawing.Image)
        Me.C1NavBarPanel1.Button.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1NavBarPanel1.Button.SmallImage = CType(resources.GetObject("resource.SmallImage"), System.Drawing.Image)
        Me.C1NavBarPanel1.Button.Text = "Margenes "
        Me.C1NavBarPanel1.Controls.Add(Me.TxtMargen)
        Me.C1NavBarPanel1.Controls.Add(Me.TrueDBGridConsultas)
        Me.C1NavBarPanel1.ID = 1
        Me.C1NavBarPanel1.Name = "C1NavBarPanel1"
        Me.C1NavBarPanel1.Size = New System.Drawing.Size(559, 312)
        '
        'TxtMargen
        '
        Me.TxtMargen.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtMargen.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMargen.ForeColor = System.Drawing.Color.Maroon
        Me.TxtMargen.Location = New System.Drawing.Point(430, 272)
        Me.TxtMargen.Name = "TxtMargen"
        Me.TxtMargen.Size = New System.Drawing.Size(114, 39)
        Me.TxtMargen.TabIndex = 30
        Me.TxtMargen.Text = "0.00"
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AllowUpdate = False
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "CONSULTAS"
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(4, 15)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(548, 251)
        Me.TrueDBGridConsultas.TabIndex = 29
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'C1NavBarPanel2
        '
        Me.C1NavBarPanel2.Button.Image = CType(resources.GetObject("resource.Image1"), System.Drawing.Image)
        Me.C1NavBarPanel2.Button.Text = "Graficos"
        Me.C1NavBarPanel2.Controls.Add(Me.C1Chart1)
        Me.C1NavBarPanel2.Controls.Add(Me.C1NavBarHorizontalRule1)
        Me.C1NavBarPanel2.ID = 2
        Me.C1NavBarPanel2.Name = "C1NavBarPanel2"
        Me.C1NavBarPanel2.Size = New System.Drawing.Size(559, 312)
        '
        'C1NavBarHorizontalRule1
        '
        Me.C1NavBarHorizontalRule1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1NavBarHorizontalRule1.Location = New System.Drawing.Point(0, 0)
        Me.C1NavBarHorizontalRule1.Name = "C1NavBarHorizontalRule1"
        Me.C1NavBarHorizontalRule1.Size = New System.Drawing.Size(559, 2)
        '
        'C1NavBarSectionHeader1
        '
        Me.C1NavBarSectionHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1NavBarSectionHeader1.Location = New System.Drawing.Point(0, 0)
        Me.C1NavBarSectionHeader1.Name = "C1NavBarSectionHeader1"
        Me.C1NavBarSectionHeader1.Size = New System.Drawing.Size(0, 19)
        Me.C1NavBarSectionHeader1.Text = "C1NavBarSectionHeader1"
        '
        'C1CommandHolder1
        '
        Me.C1CommandHolder1.Owner = Me
        '
        'C1Chart1
        '
        Me.C1Chart1.Location = New System.Drawing.Point(11, 8)
        Me.C1Chart1.Name = "C1Chart1"
        Me.C1Chart1.PropBag = resources.GetString("C1Chart1.PropBag")
        Me.C1Chart1.Size = New System.Drawing.Size(530, 286)
        Me.C1Chart1.TabIndex = 3
        '
        'FrmMargenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 442)
        Me.Controls.Add(Me.C1NavBar1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMargenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Margenes"
        CType(Me.C1NavBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1NavBar1.ResumeLayout(False)
        Me.C1NavBarPanel1.ResumeLayout(False)
        Me.C1NavBarPanel1.PerformLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1NavBarPanel2.ResumeLayout(False)
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1NavBar1 As C1.Win.C1Command.C1NavBar
    Friend WithEvents C1NavBarPanel1 As C1.Win.C1Command.C1NavBarPanel
    Friend WithEvents C1NavBarPanel2 As C1.Win.C1Command.C1NavBarPanel
    Friend WithEvents C1NavBarSectionHeader1 As C1.Win.C1Command.C1NavBarSectionHeader
    Friend WithEvents C1NavBarHorizontalRule1 As C1.Win.C1Command.C1NavBarHorizontalRule
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtMargen As System.Windows.Forms.TextBox
    Friend WithEvents C1Chart1 As C1.Win.C1Chart.C1Chart
End Class
