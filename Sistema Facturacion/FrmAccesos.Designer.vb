<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccesos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAccesos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkEditar = New System.Windows.Forms.CheckBox
        Me.ChkImprimir = New System.Windows.Forms.CheckBox
        Me.ChkProcesar = New System.Windows.Forms.CheckBox
        Me.ChkAnular = New System.Windows.Forms.CheckBox
        Me.ChkEliminar = New System.Windows.Forms.CheckBox
        Me.ChkGrabar = New System.Windows.Forms.CheckBox
        Me.ChkAbrir = New System.Windows.Forms.CheckBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ListBox = New System.Windows.Forms.ListBox
        Me.ListBoxOpciones = New System.Windows.Forms.ListBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.ChkCambiarBodega = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkCambiarBodega)
        Me.GroupBox1.Controls.Add(Me.ChkEditar)
        Me.GroupBox1.Controls.Add(Me.ChkImprimir)
        Me.GroupBox1.Controls.Add(Me.ChkProcesar)
        Me.GroupBox1.Controls.Add(Me.ChkAnular)
        Me.GroupBox1.Controls.Add(Me.ChkEliminar)
        Me.GroupBox1.Controls.Add(Me.ChkGrabar)
        Me.GroupBox1.Controls.Add(Me.ChkAbrir)
        Me.GroupBox1.Location = New System.Drawing.Point(429, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(107, 176)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Accesos"
        '
        'ChkEditar
        '
        Me.ChkEditar.AutoSize = True
        Me.ChkEditar.Location = New System.Drawing.Point(8, 155)
        Me.ChkEditar.Name = "ChkEditar"
        Me.ChkEditar.Size = New System.Drawing.Size(53, 17)
        Me.ChkEditar.TabIndex = 6
        Me.ChkEditar.Text = "Editar"
        Me.ChkEditar.UseVisualStyleBackColor = True
        Me.ChkEditar.Visible = False
        '
        'ChkImprimir
        '
        Me.ChkImprimir.AutoSize = True
        Me.ChkImprimir.Location = New System.Drawing.Point(7, 110)
        Me.ChkImprimir.Name = "ChkImprimir"
        Me.ChkImprimir.Size = New System.Drawing.Size(61, 17)
        Me.ChkImprimir.TabIndex = 5
        Me.ChkImprimir.Text = "Imprimir"
        Me.ChkImprimir.UseVisualStyleBackColor = True
        Me.ChkImprimir.Visible = False
        '
        'ChkProcesar
        '
        Me.ChkProcesar.AutoSize = True
        Me.ChkProcesar.Location = New System.Drawing.Point(7, 89)
        Me.ChkProcesar.Name = "ChkProcesar"
        Me.ChkProcesar.Size = New System.Drawing.Size(68, 17)
        Me.ChkProcesar.TabIndex = 4
        Me.ChkProcesar.Text = "Procesar"
        Me.ChkProcesar.UseVisualStyleBackColor = True
        Me.ChkProcesar.Visible = False
        '
        'ChkAnular
        '
        Me.ChkAnular.AutoSize = True
        Me.ChkAnular.Location = New System.Drawing.Point(7, 133)
        Me.ChkAnular.Name = "ChkAnular"
        Me.ChkAnular.Size = New System.Drawing.Size(56, 17)
        Me.ChkAnular.TabIndex = 3
        Me.ChkAnular.Text = "Anular"
        Me.ChkAnular.UseVisualStyleBackColor = True
        Me.ChkAnular.Visible = False
        '
        'ChkEliminar
        '
        Me.ChkEliminar.AutoSize = True
        Me.ChkEliminar.Location = New System.Drawing.Point(7, 66)
        Me.ChkEliminar.Name = "ChkEliminar"
        Me.ChkEliminar.Size = New System.Drawing.Size(62, 17)
        Me.ChkEliminar.TabIndex = 2
        Me.ChkEliminar.Text = "Eliminar"
        Me.ChkEliminar.UseVisualStyleBackColor = True
        '
        'ChkGrabar
        '
        Me.ChkGrabar.AutoSize = True
        Me.ChkGrabar.Location = New System.Drawing.Point(7, 43)
        Me.ChkGrabar.Name = "ChkGrabar"
        Me.ChkGrabar.Size = New System.Drawing.Size(58, 17)
        Me.ChkGrabar.TabIndex = 1
        Me.ChkGrabar.Text = "Grabar"
        Me.ChkGrabar.UseVisualStyleBackColor = True
        '
        'ChkAbrir
        '
        Me.ChkAbrir.AutoSize = True
        Me.ChkAbrir.Location = New System.Drawing.Point(7, 20)
        Me.ChkAbrir.Name = "ChkAbrir"
        Me.ChkAbrir.Size = New System.Drawing.Size(47, 17)
        Me.ChkAbrir.TabIndex = 0
        Me.ChkAbrir.Text = "Abrir"
        Me.ChkAbrir.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(18, 1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 195
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(212, 27)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(140, 13)
        Me.LblTitulo.TabIndex = 194
        Me.LblTitulo.Text = "PERFILES DE ACCESO"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(18, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 193
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-3, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(766, 60)
        Me.PictureBox1.TabIndex = 192
        Me.PictureBox1.TabStop = False
        '
        'ListBox
        '
        Me.ListBox.FormattingEnabled = True
        Me.ListBox.Location = New System.Drawing.Point(12, 67)
        Me.ListBox.Name = "ListBox"
        Me.ListBox.Size = New System.Drawing.Size(228, 264)
        Me.ListBox.TabIndex = 196
        '
        'ListBoxOpciones
        '
        Me.ListBoxOpciones.FormattingEnabled = True
        Me.ListBoxOpciones.Location = New System.Drawing.Point(250, 67)
        Me.ListBoxOpciones.Name = "ListBoxOpciones"
        Me.ListBoxOpciones.Size = New System.Drawing.Size(167, 264)
        Me.ListBoxOpciones.TabIndex = 197
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(429, 290)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 201
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(429, 249)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 34)
        Me.Button7.TabIndex = 200
        Me.Button7.Text = "Guardar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(12, 335)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 54)
        Me.Button1.TabIndex = 202
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(82, 335)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 54)
        Me.Button2.TabIndex = 203
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ChkCambiarBodega
        '
        Me.ChkCambiarBodega.AutoSize = True
        Me.ChkCambiarBodega.Location = New System.Drawing.Point(7, 178)
        Me.ChkCambiarBodega.Name = "ChkCambiarBodega"
        Me.ChkCambiarBodega.Size = New System.Drawing.Size(92, 17)
        Me.ChkCambiarBodega.TabIndex = 7
        Me.ChkCambiarBodega.Text = "Cmbiar Bdega"
        Me.ChkCambiarBodega.UseVisualStyleBackColor = True
        Me.ChkCambiarBodega.Visible = False
        '
        'FrmAccesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 399)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ListBoxOpciones)
        Me.Controls.Add(Me.ListBox)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmAccesos"
        Me.Text = "Control de Perfiles y Permisos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ListBox As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxOpciones As System.Windows.Forms.ListBox
    Friend WithEvents ChkEliminar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGrabar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAbrir As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAnular As System.Windows.Forms.CheckBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ChkProcesar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEditar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCambiarBodega As System.Windows.Forms.CheckBox
End Class
