<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransferenciaListado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransferenciaListado))
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.C1Button3 = New C1.Win.C1Input.C1Button
        Me.C1Button2 = New C1.Win.C1Input.C1Button
        Me.C1Button4 = New C1.Win.C1Input.C1Button
        Me.C1Button5 = New C1.Win.C1Input.C1Button
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(369, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(202, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "TRANSFERENCIAS DE BODEGAS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(89, 74)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 103
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(960, 74)
        Me.PictureBox1.TabIndex = 102
        Me.PictureBox1.TabStop = False
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AllowUpdate = False
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(12, 78)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(827, 360)
        Me.TrueDBGridConsultas.TabIndex = 105
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'C1Button1
        '
        Me.C1Button1.Image = CType(resources.GetObject("C1Button1.Image"), System.Drawing.Image)
        Me.C1Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button1.Location = New System.Drawing.Point(856, 78)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(88, 64)
        Me.C1Button1.TabIndex = 106
        Me.C1Button1.Text = "Nueva Transferencia"
        Me.C1Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.C1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button3
        '
        Me.C1Button3.Image = CType(resources.GetObject("C1Button3.Image"), System.Drawing.Image)
        Me.C1Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button3.Location = New System.Drawing.Point(856, 222)
        Me.C1Button3.Name = "C1Button3"
        Me.C1Button3.Size = New System.Drawing.Size(88, 68)
        Me.C1Button3.TabIndex = 108
        Me.C1Button3.Tag = "25"
        Me.C1Button3.Text = "Transferir"
        Me.C1Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button3.UseVisualStyleBackColor = True
        Me.C1Button3.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.C1Button3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button2
        '
        Me.C1Button2.Image = CType(resources.GetObject("C1Button2.Image"), System.Drawing.Image)
        Me.C1Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button2.Location = New System.Drawing.Point(856, 148)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(88, 68)
        Me.C1Button2.TabIndex = 109
        Me.C1Button2.Text = "Ver"
        Me.C1Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button2.UseVisualStyleBackColor = True
        Me.C1Button2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.C1Button2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button4
        '
        Me.C1Button4.Image = CType(resources.GetObject("C1Button4.Image"), System.Drawing.Image)
        Me.C1Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button4.Location = New System.Drawing.Point(856, 296)
        Me.C1Button4.Name = "C1Button4"
        Me.C1Button4.Size = New System.Drawing.Size(88, 68)
        Me.C1Button4.TabIndex = 110
        Me.C1Button4.Tag = "26"
        Me.C1Button4.Text = "Cancelar"
        Me.C1Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button4.UseVisualStyleBackColor = True
        Me.C1Button4.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.C1Button4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button5
        '
        Me.C1Button5.Image = CType(resources.GetObject("C1Button5.Image"), System.Drawing.Image)
        Me.C1Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button5.Location = New System.Drawing.Point(856, 370)
        Me.C1Button5.Name = "C1Button5"
        Me.C1Button5.Size = New System.Drawing.Size(88, 68)
        Me.C1Button5.TabIndex = 111
        Me.C1Button5.Text = "Salir"
        Me.C1Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button5.UseVisualStyleBackColor = True
        Me.C1Button5.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.C1Button5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'FrmTransferenciaListado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 451)
        Me.Controls.Add(Me.C1Button5)
        Me.Controls.Add(Me.C1Button4)
        Me.Controls.Add(Me.C1Button2)
        Me.Controls.Add(Me.C1Button3)
        Me.Controls.Add(Me.C1Button1)
        Me.Controls.Add(Me.TrueDBGridConsultas)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmTransferenciaListado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTransferenciaListado"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button3 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button4 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button5 As C1.Win.C1Input.C1Button
End Class
