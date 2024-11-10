<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConductor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConductor))
        Me.CboActivo = New System.Windows.Forms.ComboBox
        Me.ButtonGrabar = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.LblApellido = New System.Windows.Forms.Label
        Me.CboCodigoConductor = New C1.Win.C1List.C1Combo
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblCodigo = New System.Windows.Forms.Label
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TxtCedula = New System.Windows.Forms.TextBox
        Me.TxtLicencia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CboLstaNegra = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtMotivo = New System.Windows.Forms.TextBox
        Me.TxtCtaxPagar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.ChkConductores = New System.Windows.Forms.CheckBox
        CType(Me.CboCodigoConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CboActivo
        '
        Me.CboActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboActivo.FormattingEnabled = True
        Me.CboActivo.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.CboActivo.Location = New System.Drawing.Point(110, 163)
        Me.CboActivo.Name = "CboActivo"
        Me.CboActivo.Size = New System.Drawing.Size(121, 21)
        Me.CboActivo.TabIndex = 268
        '
        'ButtonGrabar
        '
        Me.ButtonGrabar.Image = CType(resources.GetObject("ButtonGrabar.Image"), System.Drawing.Image)
        Me.ButtonGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonGrabar.Location = New System.Drawing.Point(99, 321)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Size = New System.Drawing.Size(78, 68)
        Me.ButtonGrabar.TabIndex = 265
        Me.ButtonGrabar.Tag = "25"
        Me.ButtonGrabar.Text = "Grabar"
        Me.ButtonGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(183, 321)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 266
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Image = CType(resources.GetObject("ButtonNuevo.Image"), System.Drawing.Image)
        Me.ButtonNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonNuevo.Location = New System.Drawing.Point(18, 321)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 67)
        Me.ButtonNuevo.TabIndex = 264
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(311, 321)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 267
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'LblApellido
        '
        Me.LblApellido.AutoSize = True
        Me.LblApellido.Location = New System.Drawing.Point(49, 110)
        Me.LblApellido.Name = "LblApellido"
        Me.LblApellido.Size = New System.Drawing.Size(40, 13)
        Me.LblApellido.TabIndex = 262
        Me.LblApellido.Text = "Cedula"
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
        Me.CboCodigoConductor.Location = New System.Drawing.Point(110, 60)
        Me.CboCodigoConductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoConductor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoConductor.MaxLength = 32767
        Me.CboCodigoConductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoConductor.Name = "CboCodigoConductor"
        Me.CboCodigoConductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoConductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoConductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoConductor.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoConductor.TabIndex = 258
        Me.CboCodigoConductor.PropBag = resources.GetString("CboCodigoConductor.PropBag")
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(111, 87)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(275, 20)
        Me.TxtNombre.TabIndex = 259
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Location = New System.Drawing.Point(49, 86)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(44, 13)
        Me.LblNombre.TabIndex = 261
        Me.LblNombre.Text = "Nombre"
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(53, 60)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.LblCodigo.TabIndex = 260
        Me.LblCodigo.Text = "Codigo"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(119, 20)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(192, 13)
        Me.LblTitulo.TabIndex = 257
        Me.LblTitulo.Text = "CATALOGO DE CONDUCTORES"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, -6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 256
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(1, -6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(515, 60)
        Me.PictureBox1.TabIndex = 255
        Me.PictureBox1.TabStop = False
        '
        'TxtCedula
        '
        Me.TxtCedula.Location = New System.Drawing.Point(110, 112)
        Me.TxtCedula.Name = "TxtCedula"
        Me.TxtCedula.Size = New System.Drawing.Size(275, 20)
        Me.TxtCedula.TabIndex = 269
        '
        'TxtLicencia
        '
        Me.TxtLicencia.Location = New System.Drawing.Point(110, 137)
        Me.TxtLicencia.Name = "TxtLicencia"
        Me.TxtLicencia.Size = New System.Drawing.Size(275, 20)
        Me.TxtLicencia.TabIndex = 271
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 270
        Me.Label1.Text = "Licencia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 272
        Me.Label2.Text = "Activo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 274
        Me.Label3.Text = "Lista Negra"
        '
        'CboLstaNegra
        '
        Me.CboLstaNegra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLstaNegra.FormattingEnabled = True
        Me.CboLstaNegra.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.CboLstaNegra.Location = New System.Drawing.Point(110, 190)
        Me.CboLstaNegra.Name = "CboLstaNegra"
        Me.CboLstaNegra.Size = New System.Drawing.Size(121, 21)
        Me.CboLstaNegra.TabIndex = 273
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 275
        Me.Label4.Text = "Motivo Lta Negra"
        '
        'TxtMotivo
        '
        Me.TxtMotivo.Location = New System.Drawing.Point(110, 217)
        Me.TxtMotivo.Multiline = True
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.Size = New System.Drawing.Size(275, 62)
        Me.TxtMotivo.TabIndex = 276
        '
        'TxtCtaxPagar
        '
        Me.TxtCtaxPagar.Location = New System.Drawing.Point(111, 285)
        Me.TxtCtaxPagar.Name = "TxtCtaxPagar"
        Me.TxtCtaxPagar.Size = New System.Drawing.Size(120, 20)
        Me.TxtCtaxPagar.TabIndex = 278
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 277
        Me.Label5.Text = "Cuenta x Pagar"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(237, 281)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 30)
        Me.Button1.TabIndex = 279
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(322, 55)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 30)
        Me.Button2.TabIndex = 280
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ChkConductores
        '
        Me.ChkConductores.AutoSize = True
        Me.ChkConductores.Location = New System.Drawing.Point(241, 163)
        Me.ChkConductores.Name = "ChkConductores"
        Me.ChkConductores.Size = New System.Drawing.Size(146, 17)
        Me.ChkConductores.TabIndex = 281
        Me.ChkConductores.Text = "Conductor Evacuaciones"
        Me.ChkConductores.UseVisualStyleBackColor = True
        '
        'FrmConductor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 399)
        Me.Controls.Add(Me.ChkConductores)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtCtaxPagar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtMotivo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboLstaNegra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtLicencia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCedula)
        Me.Controls.Add(Me.CboActivo)
        Me.Controls.Add(Me.ButtonGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblApellido)
        Me.Controls.Add(Me.CboCodigoConductor)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.LblCodigo)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmConductor"
        Me.Text = "FrmConductor"
        CType(Me.CboCodigoConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboActivo As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents LblApellido As System.Windows.Forms.Label
    Friend WithEvents CboCodigoConductor As C1.Win.C1List.C1Combo
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCedula As System.Windows.Forms.TextBox
    Friend WithEvents TxtLicencia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboLstaNegra As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents TxtCtaxPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ChkConductores As System.Windows.Forms.CheckBox
End Class
