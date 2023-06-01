<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultas))
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BindingConsultas = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Image = CType(resources.GetObject("ButtonSalir.Image"), System.Drawing.Image)
        Me.ButtonSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonSalir.Location = New System.Drawing.Point(400, 305)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(83, 69)
        Me.ButtonSalir.TabIndex = 27
        Me.ButtonSalir.Text = "Salir"
        Me.ButtonSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonSalir.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(12, 308)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 69)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Pegar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AllowUpdate = False
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "CONSULTAS"
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(12, 80)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(471, 222)
        Me.TrueDBGridConsultas.TabIndex = 28
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(-8, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(983, 73)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(205, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "CONSULTAS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(10, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(83, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 31
        Me.PictureBox2.TabStop = False
        '
        'FrmConsultas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 386)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TrueDBGridConsultas)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.Button2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConsultas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultas"
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Protected WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BindingConsultas As System.Windows.Forms.BindingSource
End Class
