<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRutaDistribucion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRutaDistribucion))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Button2 = New System.Windows.Forms.Button
        Me.CmbTurno = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtGrado = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtAño = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CmbCodigo = New C1.Win.C1List.C1Combo
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CmbCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(5, 64)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(414, 129)
        Me.TabControl1.TabIndex = 139
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.CmbTurno)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.TxtGrado)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.TxtAño)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.CmbCodigo)
        Me.TabPage1.Controls.Add(Me.TxtDescripcion)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(406, 103)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Nota Debito y Credito"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(192, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 32)
        Me.Button2.TabIndex = 138
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmbTurno
        '
        Me.CmbTurno.FormattingEnabled = True
        Me.CmbTurno.Items.AddRange(New Object() {"Matutino", "Vespertino"})
        Me.CmbTurno.Location = New System.Drawing.Point(278, 283)
        Me.CmbTurno.Name = "CmbTurno"
        Me.CmbTurno.Size = New System.Drawing.Size(111, 21)
        Me.CmbTurno.TabIndex = 137
        Me.CmbTurno.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(237, 287)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 136
        Me.Label15.Text = "Turno"
        '
        'TxtGrado
        '
        Me.TxtGrado.Location = New System.Drawing.Point(114, 310)
        Me.TxtGrado.Name = "TxtGrado"
        Me.TxtGrado.Size = New System.Drawing.Size(108, 20)
        Me.TxtGrado.TabIndex = 132
        Me.TxtGrado.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 310)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 133
        Me.Label14.Text = "Grado"
        Me.Label14.Visible = False
        '
        'TxtAño
        '
        Me.TxtAño.Location = New System.Drawing.Point(114, 284)
        Me.TxtAño.Name = "TxtAño"
        Me.TxtAño.Size = New System.Drawing.Size(108, 20)
        Me.TxtAño.TabIndex = 134
        Me.TxtAño.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 284)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 135
        Me.Label13.Text = "Año"
        Me.Label13.Visible = False
        '
        'CmbCodigo
        '
        Me.CmbCodigo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbCodigo.Caption = ""
        Me.CmbCodigo.CaptionHeight = 17
        Me.CmbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbCodigo.ColumnCaptionHeight = 17
        Me.CmbCodigo.ColumnFooterHeight = 17
        Me.CmbCodigo.ContentHeight = 15
        Me.CmbCodigo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbCodigo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbCodigo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCodigo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbCodigo.EditorHeight = 15
        Me.CmbCodigo.Images.Add(CType(resources.GetObject("CmbCodigo.Images"), System.Drawing.Image))
        Me.CmbCodigo.ItemHeight = 15
        Me.CmbCodigo.Location = New System.Drawing.Point(75, 20)
        Me.CmbCodigo.MatchEntryTimeout = CType(2000, Long)
        Me.CmbCodigo.MaxDropDownItems = CType(5, Short)
        Me.CmbCodigo.MaxLength = 32767
        Me.CmbCodigo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbCodigo.Name = "CmbCodigo"
        Me.CmbCodigo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbCodigo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbCodigo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbCodigo.Size = New System.Drawing.Size(108, 21)
        Me.CmbCodigo.TabIndex = 120
        Me.CmbCodigo.PropBag = resources.GetString("CmbCodigo.PropBag")
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(75, 49)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(312, 20)
        Me.TxtDescripcion.TabIndex = 121
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Descripcion"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 128
        Me.Label16.Text = "Codigo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(140, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 13)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "RUTA DE DISTRIBUCION"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(17, -2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 137
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox4.Location = New System.Drawing.Point(-6, -2)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(597, 60)
        Me.PictureBox4.TabIndex = 136
        Me.PictureBox4.TabStop = False
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(95, 203)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 133
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(179, 203)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 134
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(15, 204)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 132
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(344, 199)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 135
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'FrmRutaDistribucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 273)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Name = "FrmRutaDistribucion"
        Me.Text = "FrmRutaDistribucion"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.CmbCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtGrado As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtAño As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmbCodigo As C1.Win.C1List.C1Combo
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
