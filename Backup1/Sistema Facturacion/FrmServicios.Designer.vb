<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmServicios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmServicios))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.OptDescuento = New System.Windows.Forms.RadioButton
        Me.OptServicio = New System.Windows.Forms.RadioButton
        Me.TxtNombreProducto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CboCodigoProducto = New C1.Win.C1List.C1Combo
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OptSubTotal = New System.Windows.Forms.RadioButton
        Me.OptUnidades = New System.Windows.Forms.RadioButton
        Me.OptImporteFijo = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CboRubro = New C1.Win.C1List.C1Combo
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtPrecioDolar = New System.Windows.Forms.TextBox
        Me.LblDescripcion2 = New System.Windows.Forms.Label
        Me.ChkGrabado = New System.Windows.Forms.CheckBox
        Me.TxtPrecioCordobas = New System.Windows.Forms.TextBox
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TxtCuentaVenta = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtCtaCosto = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.CboActivo = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CboIva = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboCodigoProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CboRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(0, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(749, 60)
        Me.PictureBox1.TabIndex = 162
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 163
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(162, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 13)
        Me.Label9.TabIndex = 164
        Me.Label9.Text = "SERVICIOS Y MISCELANEOS"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptDescuento)
        Me.GroupBox1.Controls.Add(Me.OptServicio)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 44)
        Me.GroupBox1.TabIndex = 165
        Me.GroupBox1.TabStop = False
        '
        'OptDescuento
        '
        Me.OptDescuento.AutoSize = True
        Me.OptDescuento.Location = New System.Drawing.Point(101, 14)
        Me.OptDescuento.Name = "OptDescuento"
        Me.OptDescuento.Size = New System.Drawing.Size(77, 17)
        Me.OptDescuento.TabIndex = 166
        Me.OptDescuento.Text = "Descuento"
        Me.OptDescuento.UseVisualStyleBackColor = True
        '
        'OptServicio
        '
        Me.OptServicio.AutoSize = True
        Me.OptServicio.Checked = True
        Me.OptServicio.Location = New System.Drawing.Point(12, 14)
        Me.OptServicio.Name = "OptServicio"
        Me.OptServicio.Size = New System.Drawing.Size(63, 17)
        Me.OptServicio.TabIndex = 0
        Me.OptServicio.TabStop = True
        Me.OptServicio.Text = "Servicio"
        Me.OptServicio.UseVisualStyleBackColor = True
        '
        'TxtNombreProducto
        '
        Me.TxtNombreProducto.Location = New System.Drawing.Point(232, 127)
        Me.TxtNombreProducto.Multiline = True
        Me.TxtNombreProducto.Name = "TxtNombreProducto"
        Me.TxtNombreProducto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNombreProducto.Size = New System.Drawing.Size(250, 94)
        Me.TxtNombreProducto.TabIndex = 168
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(237, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 170
        Me.Label3.Text = "Nombre Servicio"
        '
        'CboCodigoProducto
        '
        Me.CboCodigoProducto.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoProducto.Caption = ""
        Me.CboCodigoProducto.CaptionHeight = 17
        Me.CboCodigoProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoProducto.ColumnCaptionHeight = 17
        Me.CboCodigoProducto.ColumnFooterHeight = 17
        Me.CboCodigoProducto.ContentHeight = 15
        Me.CboCodigoProducto.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoProducto.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoProducto.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoProducto.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoProducto.EditorHeight = 15
        Me.CboCodigoProducto.Images.Add(CType(resources.GetObject("CboCodigoProducto.Images"), System.Drawing.Image))
        Me.CboCodigoProducto.ItemHeight = 15
        Me.CboCodigoProducto.Location = New System.Drawing.Point(17, 128)
        Me.CboCodigoProducto.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoProducto.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoProducto.MaxLength = 32767
        Me.CboCodigoProducto.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoProducto.Name = "CboCodigoProducto"
        Me.CboCodigoProducto.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoProducto.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoProducto.Size = New System.Drawing.Size(170, 21)
        Me.CboCodigoProducto.TabIndex = 166
        Me.CboCodigoProducto.PropBag = resources.GetString("CboCodigoProducto.PropBag")
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(189, 111)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 38)
        Me.Button6.TabIndex = 167
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 169
        Me.Label1.Text = "Codigo Servicio"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptSubTotal)
        Me.GroupBox2.Controls.Add(Me.OptUnidades)
        Me.GroupBox2.Controls.Add(Me.OptImporteFijo)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 242)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(473, 40)
        Me.GroupBox2.TabIndex = 173
        Me.GroupBox2.TabStop = False
        '
        'OptSubTotal
        '
        Me.OptSubTotal.AutoSize = True
        Me.OptSubTotal.Location = New System.Drawing.Point(362, 17)
        Me.OptSubTotal.Name = "OptSubTotal"
        Me.OptSubTotal.Size = New System.Drawing.Size(71, 17)
        Me.OptSubTotal.TabIndex = 3
        Me.OptSubTotal.Text = "Sub Total"
        Me.OptSubTotal.UseVisualStyleBackColor = True
        '
        'OptUnidades
        '
        Me.OptUnidades.AutoSize = True
        Me.OptUnidades.Checked = True
        Me.OptUnidades.Location = New System.Drawing.Point(172, 13)
        Me.OptUnidades.Name = "OptUnidades"
        Me.OptUnidades.Size = New System.Drawing.Size(109, 17)
        Me.OptUnidades.TabIndex = 2
        Me.OptUnidades.TabStop = True
        Me.OptUnidades.Text = "Unids/Fracciones"
        Me.OptUnidades.UseVisualStyleBackColor = True
        '
        'OptImporteFijo
        '
        Me.OptImporteFijo.AutoSize = True
        Me.OptImporteFijo.Location = New System.Drawing.Point(6, 13)
        Me.OptImporteFijo.Name = "OptImporteFijo"
        Me.OptImporteFijo.Size = New System.Drawing.Size(79, 17)
        Me.OptImporteFijo.TabIndex = 1
        Me.OptImporteFijo.Text = "Importe Fijo"
        Me.OptImporteFijo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.CboRubro)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 288)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(247, 54)
        Me.GroupBox3.TabIndex = 174
        Me.GroupBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Rubros"
        '
        'CboRubro
        '
        Me.CboRubro.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboRubro.Caption = ""
        Me.CboRubro.CaptionHeight = 17
        Me.CboRubro.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboRubro.ColumnCaptionHeight = 17
        Me.CboRubro.ColumnFooterHeight = 17
        Me.CboRubro.ContentHeight = 15
        Me.CboRubro.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboRubro.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboRubro.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboRubro.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboRubro.EditorHeight = 15
        Me.CboRubro.Images.Add(CType(resources.GetObject("CboRubro.Images"), System.Drawing.Image))
        Me.CboRubro.ItemHeight = 15
        Me.CboRubro.Location = New System.Drawing.Point(53, 16)
        Me.CboRubro.MatchEntryTimeout = CType(2000, Long)
        Me.CboRubro.MaxDropDownItems = CType(5, Short)
        Me.CboRubro.MaxLength = 32767
        Me.CboRubro.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboRubro.Name = "CboRubro"
        Me.CboRubro.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboRubro.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboRubro.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboRubro.Size = New System.Drawing.Size(170, 21)
        Me.CboRubro.TabIndex = 167
        Me.CboRubro.PropBag = resources.GetString("CboRubro.PropBag")
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtPrecioDolar)
        Me.GroupBox4.Controls.Add(Me.LblDescripcion2)
        Me.GroupBox4.Controls.Add(Me.ChkGrabado)
        Me.GroupBox4.Controls.Add(Me.TxtPrecioCordobas)
        Me.GroupBox4.Controls.Add(Me.LblDescripcion)
        Me.GroupBox4.Location = New System.Drawing.Point(305, 288)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(185, 109)
        Me.GroupBox4.TabIndex = 175
        Me.GroupBox4.TabStop = False
        '
        'TxtPrecioDolar
        '
        Me.TxtPrecioDolar.Location = New System.Drawing.Point(8, 79)
        Me.TxtPrecioDolar.Multiline = True
        Me.TxtPrecioDolar.Name = "TxtPrecioDolar"
        Me.TxtPrecioDolar.Size = New System.Drawing.Size(85, 21)
        Me.TxtPrecioDolar.TabIndex = 176
        '
        'LblDescripcion2
        '
        Me.LblDescripcion2.AutoSize = True
        Me.LblDescripcion2.Location = New System.Drawing.Point(8, 62)
        Me.LblDescripcion2.Name = "LblDescripcion2"
        Me.LblDescripcion2.Size = New System.Drawing.Size(85, 13)
        Me.LblDescripcion2.TabIndex = 177
        Me.LblDescripcion2.Text = "Precio Unitario $"
        '
        'ChkGrabado
        '
        Me.ChkGrabado.AutoSize = True
        Me.ChkGrabado.Location = New System.Drawing.Point(105, 33)
        Me.ChkGrabado.Name = "ChkGrabado"
        Me.ChkGrabado.Size = New System.Drawing.Size(67, 17)
        Me.ChkGrabado.TabIndex = 175
        Me.ChkGrabado.Text = "Grabado"
        Me.ChkGrabado.UseVisualStyleBackColor = True
        Me.ChkGrabado.Visible = False
        '
        'TxtPrecioCordobas
        '
        Me.TxtPrecioCordobas.Location = New System.Drawing.Point(6, 33)
        Me.TxtPrecioCordobas.Multiline = True
        Me.TxtPrecioCordobas.Name = "TxtPrecioCordobas"
        Me.TxtPrecioCordobas.Size = New System.Drawing.Size(85, 21)
        Me.TxtPrecioCordobas.TabIndex = 173
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Location = New System.Drawing.Point(6, 16)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(92, 13)
        Me.LblDescripcion.TabIndex = 174
        Me.LblDescripcion.Text = "Precio Unitario C$"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TxtCuentaVenta)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.TxtCtaCosto)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 395)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(481, 53)
        Me.GroupBox5.TabIndex = 176
        Me.GroupBox5.TabStop = False
        '
        'TxtCuentaVenta
        '
        Me.TxtCuentaVenta.Location = New System.Drawing.Point(319, 16)
        Me.TxtCuentaVenta.Name = "TxtCuentaVenta"
        Me.TxtCuentaVenta.Size = New System.Drawing.Size(112, 20)
        Me.TxtCuentaVenta.TabIndex = 23
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(198, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 34)
        Me.Button1.TabIndex = 20
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(241, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Cuenta Venta"
        '
        'TxtCtaCosto
        '
        Me.TxtCtaCosto.Location = New System.Drawing.Point(83, 16)
        Me.TxtCtaCosto.Name = "TxtCtaCosto"
        Me.TxtCtaCosto.Size = New System.Drawing.Size(112, 20)
        Me.TxtCtaCosto.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Cuenta Costo"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(431, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 38)
        Me.Button2.TabIndex = 24
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(520, 309)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 179
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(520, 138)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonAgregar.TabIndex = 178
        Me.ButtonAgregar.Tag = "25"
        Me.ButtonAgregar.Text = "Guardar"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(520, 65)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 177
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(520, 382)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 180
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CboActivo
        '
        Me.CboActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboActivo.FormattingEnabled = True
        Me.CboActivo.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.CboActivo.Location = New System.Drawing.Point(81, 350)
        Me.CboActivo.Name = "CboActivo"
        Me.CboActivo.Size = New System.Drawing.Size(123, 21)
        Me.CboActivo.TabIndex = 181
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 353)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 182
        Me.Label13.Text = "Activo"
        '
        'CboIva
        '
        Me.CboIva.FormattingEnabled = True
        Me.CboIva.Location = New System.Drawing.Point(81, 376)
        Me.CboIva.Name = "CboIva"
        Me.CboIva.Size = New System.Drawing.Size(123, 21)
        Me.CboIva.TabIndex = 184
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 380)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 183
        Me.Label14.Text = "Tabla I.V.A"
        '
        'FrmServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 470)
        Me.Controls.Add(Me.CboIva)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.CboActivo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtNombreProducto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboCodigoProducto)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "j k"
        Me.Text = "Mantenimiento de Servicios y Miscelaneos"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboCodigoProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CboRubro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptServicio As System.Windows.Forms.RadioButton
    Friend WithEvents OptDescuento As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNombreProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoProducto As C1.Win.C1List.C1Combo
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptImporteFijo As System.Windows.Forms.RadioButton
    Friend WithEvents OptUnidades As System.Windows.Forms.RadioButton
    Friend WithEvents OptSubTotal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrecioCordobas As System.Windows.Forms.TextBox
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCuentaVenta As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents ChkGrabado As System.Windows.Forms.CheckBox
    Friend WithEvents CboActivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CboIva As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioDolar As System.Windows.Forms.TextBox
    Friend WithEvents LblDescripcion2 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboRubro As C1.Win.C1List.C1Combo
End Class
