<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroTransporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroTransporte))
        Me.CmbContrato1 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Button2 = New System.Windows.Forms.Button
        Me.CboCodigoConductor = New C1.Win.C1List.C1Combo
        Me.LblCodigo = New System.Windows.Forms.Label
        Me.CboPlaca = New C1.Win.C1List.C1Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtCodigoClientes = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.ButtonGrabar = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.CboCodigoConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbContrato1
        '
        Me.CmbContrato1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbContrato1.FormattingEnabled = True
        Me.CmbContrato1.Location = New System.Drawing.Point(101, 107)
        Me.CmbContrato1.Name = "CmbContrato1"
        Me.CmbContrato1.Size = New System.Drawing.Size(121, 21)
        Me.CmbContrato1.TabIndex = 265
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 264
        Me.Label5.Text = "Tipo Servicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 262
        Me.Label2.Text = "Fecha Inicio"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(100, 81)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 263
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(315, 128)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 30)
        Me.Button2.TabIndex = 283
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CboCodigoConductor
        '
        Me.CboCodigoConductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoConductor.Caption = ""
        Me.CboCodigoConductor.CaptionHeight = 17
        Me.CboCodigoConductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoConductor.ColumnCaptionHeight = 17
        Me.CboCodigoConductor.ColumnFooterHeight = 17
        Me.CboCodigoConductor.ContentHeight = 15
        Me.CboCodigoConductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoConductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoConductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoConductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoConductor.EditorHeight = 15
        Me.CboCodigoConductor.Images.Add(CType(resources.GetObject("CboCodigoConductor.Images"), System.Drawing.Image))
        Me.CboCodigoConductor.ItemHeight = 15
        Me.CboCodigoConductor.Location = New System.Drawing.Point(100, 134)
        Me.CboCodigoConductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoConductor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoConductor.MaxLength = 32767
        Me.CboCodigoConductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoConductor.Name = "CboCodigoConductor"
        Me.CboCodigoConductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoConductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoConductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoConductor.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoConductor.TabIndex = 281
        Me.CboCodigoConductor.PropBag = resources.GetString("CboCodigoConductor.PropBag")
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(38, 142)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(56, 13)
        Me.LblCodigo.TabIndex = 282
        Me.LblCodigo.Text = "Conductor"
        '
        'CboPlaca
        '
        Me.CboPlaca.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboPlaca.Caption = ""
        Me.CboPlaca.CaptionHeight = 17
        Me.CboPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboPlaca.ColumnCaptionHeight = 17
        Me.CboPlaca.ColumnFooterHeight = 17
        Me.CboPlaca.ContentHeight = 15
        Me.CboPlaca.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboPlaca.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboPlaca.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPlaca.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboPlaca.EditorHeight = 15
        Me.CboPlaca.Images.Add(CType(resources.GetObject("CboPlaca.Images"), System.Drawing.Image))
        Me.CboPlaca.ItemHeight = 15
        Me.CboPlaca.Location = New System.Drawing.Point(100, 164)
        Me.CboPlaca.MatchEntryTimeout = CType(2000, Long)
        Me.CboPlaca.MaxDropDownItems = CType(5, Short)
        Me.CboPlaca.MaxLength = 32767
        Me.CboPlaca.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboPlaca.Name = "CboPlaca"
        Me.CboPlaca.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboPlaca.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboPlaca.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboPlaca.Size = New System.Drawing.Size(209, 21)
        Me.CboPlaca.TabIndex = 284
        Me.CboPlaca.PropBag = resources.GetString("CboPlaca.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 285
        Me.Label1.Text = "Placa"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(315, 160)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 30)
        Me.Button1.TabIndex = 286
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCodigoClientes
        '
        Me.TxtCodigoClientes.Location = New System.Drawing.Point(101, 191)
        Me.TxtCodigoClientes.Name = "TxtCodigoClientes"
        Me.TxtCodigoClientes.Size = New System.Drawing.Size(152, 20)
        Me.TxtCodigoClientes.TabIndex = 287
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 289
        Me.Label3.Text = "Numero Contrato"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(101, 217)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(251, 20)
        Me.TextBox1.TabIndex = 290
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(259, 185)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 30)
        Me.Button3.TabIndex = 291
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonGrabar
        '
        Me.ButtonGrabar.Image = CType(resources.GetObject("ButtonGrabar.Image"), System.Drawing.Image)
        Me.ButtonGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonGrabar.Location = New System.Drawing.Point(10, 247)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Size = New System.Drawing.Size(78, 68)
        Me.ButtonGrabar.TabIndex = 292
        Me.ButtonGrabar.Tag = "25"
        Me.ButtonGrabar.Text = "Grabar"
        Me.ButtonGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonGrabar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(305, 249)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 293
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(119, 22)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(180, 13)
        Me.LblTitulo.TabIndex = 296
        Me.LblTitulo.Text = "REGISTRO DE TRANSPORTE"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, -4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 295
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(1, -4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(515, 60)
        Me.PictureBox1.TabIndex = 294
        Me.PictureBox1.TabStop = False
        '
        'FrmRegistroTransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 327)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonGrabar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCodigoClientes)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CboPlaca)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CboCodigoConductor)
        Me.Controls.Add(Me.LblCodigo)
        Me.Controls.Add(Me.CmbContrato1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPFecha)
        Me.Name = "FrmRegistroTransporte"
        Me.Text = "FrmRegistroTransporte"
        CType(Me.CboCodigoConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbContrato1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CboCodigoConductor As C1.Win.C1List.C1Combo
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents CboPlaca As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoClientes As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ButtonGrabar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
