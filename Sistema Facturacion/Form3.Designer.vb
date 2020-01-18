<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.C1NavBar1 = New C1.Win.C1Command.C1NavBar
        Me.C1NavBarPanel1 = New C1.Win.C1Command.C1NavBarPanel
        Me.C1MainMenu1 = New C1.Win.C1Command.C1MainMenu
        Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink
        Me.C1PictureBox1 = New C1.Win.C1Input.C1PictureBox
        Me.C1Ribbon1 = New C1.Win.C1Ribbon.C1Ribbon
        Me.RibbonApplicationMenu1 = New C1.Win.C1Ribbon.RibbonApplicationMenu
        Me.RibbonQat1 = New C1.Win.C1Ribbon.RibbonQat
        Me.RibbonConfigToolBar1 = New C1.Win.C1Ribbon.RibbonConfigToolBar
        Me.RibbonTab1 = New C1.Win.C1Ribbon.RibbonTab
        Me.RibbonGroup1 = New C1.Win.C1Ribbon.RibbonGroup
        CType(Me.C1NavBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1NavBar1.SuspendLayout()
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1NavBar1
        '
        Me.C1NavBar1.Controls.Add(Me.C1NavBarPanel1)
        Me.C1NavBar1.Location = New System.Drawing.Point(12, 79)
        Me.C1NavBar1.Name = "C1NavBar1"
        Me.C1NavBar1.Size = New System.Drawing.Size(200, 300)
        Me.C1NavBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2003Blue
        '
        'C1NavBarPanel1
        '
        Me.C1NavBarPanel1.Button.Image = CType(resources.GetObject("resource.Image"), System.Drawing.Image)
        Me.C1NavBarPanel1.Button.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.C1NavBarPanel1.Button.SmallImage = CType(resources.GetObject("resource.SmallImage"), System.Drawing.Image)
        Me.C1NavBarPanel1.Button.Text = "Notes"
        Me.C1NavBarPanel1.ID = 1
        Me.C1NavBarPanel1.Name = "C1NavBarPanel1"
        Me.C1NavBarPanel1.Size = New System.Drawing.Size(198, 202)
        '
        'C1MainMenu1
        '
        Me.C1MainMenu1.CommandHolder = Me.C1CommandHolder1
        Me.C1MainMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink1})
        Me.C1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.C1MainMenu1.Name = "C1MainMenu1"
        Me.C1MainMenu1.Size = New System.Drawing.Size(595, 18)
        Me.C1MainMenu1.VisualStyleBase = C1.Win.C1Command.VisualStyle.OfficeXP
        '
        'C1CommandHolder1
        '
        Me.C1CommandHolder1.Owner = Me
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Text = "New Command"
        '
        'C1PictureBox1
        '
        Me.C1PictureBox1.Location = New System.Drawing.Point(342, 107)
        Me.C1PictureBox1.Name = "C1PictureBox1"
        Me.C1PictureBox1.Size = New System.Drawing.Size(118, 95)
        Me.C1PictureBox1.TabIndex = 2
        Me.C1PictureBox1.TabStop = False
        '
        'C1Ribbon1
        '
        Me.C1Ribbon1.ApplicationMenuHolder = Me.RibbonApplicationMenu1
        Me.C1Ribbon1.ConfigToolBarHolder = Me.RibbonConfigToolBar1
        Me.C1Ribbon1.Location = New System.Drawing.Point(0, 18)
        Me.C1Ribbon1.Name = "C1Ribbon1"
        Me.C1Ribbon1.QatHolder = Me.RibbonQat1
        Me.C1Ribbon1.Size = New System.Drawing.Size(595, 141)
        Me.C1Ribbon1.TabIndex = 3
        Me.C1Ribbon1.Tabs.Add(Me.RibbonTab1)
        '
        'RibbonApplicationMenu1
        '
        Me.RibbonApplicationMenu1.ID = "RibbonApplicationMenu1"
        '
        'RibbonQat1
        '
        Me.RibbonQat1.ID = "RibbonQat1"
        '
        'RibbonConfigToolBar1
        '
        Me.RibbonConfigToolBar1.ID = "RibbonConfigToolBar1"
        '
        'RibbonTab1
        '
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup1)
        Me.RibbonTab1.ID = "RibbonTab1"
        Me.RibbonTab1.Text = "Tab"
        '
        'RibbonGroup1
        '
        Me.RibbonGroup1.ID = "RibbonGroup1"
        Me.RibbonGroup1.Text = "Group"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 401)
        Me.Controls.Add(Me.C1Ribbon1)
        Me.Controls.Add(Me.C1PictureBox1)
        Me.Controls.Add(Me.C1NavBar1)
        Me.Controls.Add(Me.C1MainMenu1)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.C1NavBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1NavBar1.ResumeLayout(False)
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1NavBar1 As C1.Win.C1Command.C1NavBar
    Friend WithEvents C1NavBarPanel1 As C1.Win.C1Command.C1NavBarPanel
    Friend WithEvents C1MainMenu1 As C1.Win.C1Command.C1MainMenu
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents C1Ribbon1 As C1.Win.C1Ribbon.C1Ribbon
    Friend WithEvents RibbonApplicationMenu1 As C1.Win.C1Ribbon.RibbonApplicationMenu
    Friend WithEvents RibbonConfigToolBar1 As C1.Win.C1Ribbon.RibbonConfigToolBar
    Friend WithEvents RibbonQat1 As C1.Win.C1Ribbon.RibbonQat
    Friend WithEvents RibbonTab1 As C1.Win.C1Ribbon.RibbonTab
    Friend WithEvents RibbonGroup1 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents C1PictureBox1 As C1.Win.C1Input.C1PictureBox
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
End Class
