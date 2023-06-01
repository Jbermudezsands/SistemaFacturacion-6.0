<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcesar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcesar))
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.CmdProcesar = New System.Windows.Forms.Button
        Me.CmdConsultar = New System.Windows.Forms.Button
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(167, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(219, 13)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "PROCESAR FACTURAS Y COMPRAS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(6, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(79, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 128
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-3, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(973, 61)
        Me.PictureBox1.TabIndex = 127
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ProgressBar)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.CmdProcesar)
        Me.GroupBox1.Controls.Add(Me.CmdConsultar)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(603, 119)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 13)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "Procesando la Factura J04539"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(23, 63)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(442, 23)
        Me.ProgressBar.TabIndex = 188
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(146, 33)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(104, 17)
        Me.RadioButton2.TabIndex = 187
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Modulo Facturas"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(23, 31)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(104, 17)
        Me.RadioButton1.TabIndex = 186
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Modulo Compras"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'CmdProcesar
        '
        Me.CmdProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdProcesar.Image = CType(resources.GetObject("CmdProcesar.Image"), System.Drawing.Image)
        Me.CmdProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdProcesar.Location = New System.Drawing.Point(507, 72)
        Me.CmdProcesar.Name = "CmdProcesar"
        Me.CmdProcesar.Size = New System.Drawing.Size(90, 34)
        Me.CmdProcesar.TabIndex = 185
        Me.CmdProcesar.Text = "Procesar"
        Me.CmdProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdProcesar.UseVisualStyleBackColor = True
        '
        'CmdConsultar
        '
        Me.CmdConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdConsultar.Image = CType(resources.GetObject("CmdConsultar.Image"), System.Drawing.Image)
        Me.CmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdConsultar.Location = New System.Drawing.Point(507, 24)
        Me.CmdConsultar.Name = "CmdConsultar"
        Me.CmdConsultar.Size = New System.Drawing.Size(90, 34)
        Me.CmdConsultar.TabIndex = 184
        Me.CmdConsultar.Text = "Consultar"
        Me.CmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdConsultar.UseVisualStyleBackColor = True
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "MESES PENDIENTES"
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(13, 190)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(605, 222)
        Me.TrueDBGridConsultas.TabIndex = 131
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'FrmProcesar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 443)
        Me.Controls.Add(Me.TrueDBGridConsultas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmProcesar"
        Me.Text = "FrmProcesar"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdProcesar As System.Windows.Forms.Button
    Friend WithEvents CmdConsultar As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
