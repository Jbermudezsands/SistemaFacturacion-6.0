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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OptDescuento = New System.Windows.Forms.RadioButton()
        Me.OptServicio = New System.Windows.Forms.RadioButton()
        Me.TxtNombreProducto = New System.Windows.Forms.TextBox()
        Me.CboCodigoProducto = New C1.Win.C1List.C1Combo()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.OptSubTotal = New System.Windows.Forms.RadioButton()
        Me.OptUnidades = New System.Windows.Forms.RadioButton()
        Me.OptImporteFijo = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CboRubro = New C1.Win.C1List.C1Combo()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtPrecioDolar = New System.Windows.Forms.TextBox()
        Me.ChkGrabado = New System.Windows.Forms.CheckBox()
        Me.TxtPrecioCordobas = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TxtCuentaVenta = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtCtaCosto = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.ButtonAgregar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.CboActivo = New System.Windows.Forms.ComboBox()
        Me.CboIva = New System.Windows.Forms.ComboBox()
        Me.CmdNuevo = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSubtitulo = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlFormulario = New System.Windows.Forms.Panel()
        Me.lblCuentaVenta = New System.Windows.Forms.Label()
        Me.lblCuentaCosto = New System.Windows.Forms.Label()
        Me.lblTablaIVA = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.LblDescripcion2 = New System.Windows.Forms.Label()
        Me.pnlTipoCalculo = New System.Windows.Forms.Panel()
        Me.LblDescripcion = New System.Windows.Forms.Label()
        Me.lblNombreServicio = New System.Windows.Forms.Label()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.lblCodigoServicio = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboCodigoProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CboRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlFormulario.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptDescuento)
        Me.GroupBox1.Controls.Add(Me.OptServicio)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 44)
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
        Me.TxtNombreProducto.Location = New System.Drawing.Point(23, 121)
        Me.TxtNombreProducto.Multiline = True
        Me.TxtNombreProducto.Name = "TxtNombreProducto"
        Me.TxtNombreProducto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNombreProducto.Size = New System.Drawing.Size(417, 74)
        Me.TxtNombreProducto.TabIndex = 168
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
        Me.CboCodigoProducto.Location = New System.Drawing.Point(23, 74)
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
        Me.Button6.Location = New System.Drawing.Point(199, 71)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(31, 24)
        Me.Button6.TabIndex = 167
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.OptSubTotal)
        Me.GroupBox2.Controls.Add(Me.OptUnidades)
        Me.GroupBox2.Controls.Add(Me.OptImporteFijo)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 203)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 34)
        Me.GroupBox2.TabIndex = 173
        Me.GroupBox2.TabStop = False
        '
        'OptSubTotal
        '
        Me.OptSubTotal.AutoSize = True
        Me.OptSubTotal.Location = New System.Drawing.Point(314, 11)
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
        Me.OptUnidades.Location = New System.Drawing.Point(148, 11)
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
        Me.OptImporteFijo.Location = New System.Drawing.Point(6, 11)
        Me.OptImporteFijo.Name = "OptImporteFijo"
        Me.OptImporteFijo.Size = New System.Drawing.Size(79, 17)
        Me.OptImporteFijo.TabIndex = 1
        Me.OptImporteFijo.Text = "Importe Fijo"
        Me.OptImporteFijo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(23, 130)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(247, 54)
        Me.GroupBox3.TabIndex = 174
        Me.GroupBox3.TabStop = False
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
        Me.CboRubro.Location = New System.Drawing.Point(243, 71)
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
        Me.GroupBox4.Location = New System.Drawing.Point(25, 202)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(185, 109)
        Me.GroupBox4.TabIndex = 175
        Me.GroupBox4.TabStop = False
        '
        'TxtPrecioDolar
        '
        Me.TxtPrecioDolar.Location = New System.Drawing.Point(240, 285)
        Me.TxtPrecioDolar.Multiline = True
        Me.TxtPrecioDolar.Name = "TxtPrecioDolar"
        Me.TxtPrecioDolar.Size = New System.Drawing.Size(186, 21)
        Me.TxtPrecioDolar.TabIndex = 176
        '
        'ChkGrabado
        '
        Me.ChkGrabado.AutoSize = True
        Me.ChkGrabado.Location = New System.Drawing.Point(149, 310)
        Me.ChkGrabado.Name = "ChkGrabado"
        Me.ChkGrabado.Size = New System.Drawing.Size(67, 17)
        Me.ChkGrabado.TabIndex = 175
        Me.ChkGrabado.Text = "Grabado"
        Me.ChkGrabado.UseVisualStyleBackColor = True
        Me.ChkGrabado.Visible = False
        '
        'TxtPrecioCordobas
        '
        Me.TxtPrecioCordobas.Location = New System.Drawing.Point(23, 285)
        Me.TxtPrecioCordobas.Multiline = True
        Me.TxtPrecioCordobas.Name = "TxtPrecioCordobas"
        Me.TxtPrecioCordobas.Size = New System.Drawing.Size(193, 21)
        Me.TxtPrecioCordobas.TabIndex = 173
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(9, 395)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(436, 53)
        Me.GroupBox5.TabIndex = 176
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Visible = False
        '
        'TxtCuentaVenta
        '
        Me.TxtCuentaVenta.Location = New System.Drawing.Point(240, 394)
        Me.TxtCuentaVenta.Name = "TxtCuentaVenta"
        Me.TxtCuentaVenta.Size = New System.Drawing.Size(159, 20)
        Me.TxtCuentaVenta.TabIndex = 23
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(195, 386)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 28)
        Me.Button1.TabIndex = 20
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCtaCosto
        '
        Me.TxtCtaCosto.Location = New System.Drawing.Point(23, 392)
        Me.TxtCtaCosto.Name = "TxtCtaCosto"
        Me.TxtCtaCosto.Size = New System.Drawing.Size(169, 20)
        Me.TxtCtaCosto.TabIndex = 19
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(405, 389)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 28)
        Me.Button2.TabIndex = 24
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(477, 328)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 179
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        Me.ButtonBorrar.Visible = False
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(477, 130)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonAgregar.TabIndex = 178
        Me.ButtonAgregar.Tag = "25"
        Me.ButtonAgregar.Text = "Guardar"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        Me.ButtonAgregar.Visible = False
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(477, 427)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 180
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'CboActivo
        '
        Me.CboActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboActivo.FormattingEnabled = True
        Me.CboActivo.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.CboActivo.Location = New System.Drawing.Point(23, 338)
        Me.CboActivo.Name = "CboActivo"
        Me.CboActivo.Size = New System.Drawing.Size(193, 21)
        Me.CboActivo.TabIndex = 181
        '
        'CboIva
        '
        Me.CboIva.FormattingEnabled = True
        Me.CboIva.Location = New System.Drawing.Point(240, 337)
        Me.CboIva.Name = "CboIva"
        Me.CboIva.Size = New System.Drawing.Size(186, 21)
        Me.CboIva.TabIndex = 184
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(477, 60)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 185
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        Me.CmdNuevo.Visible = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblSubtitulo)
        Me.pnlHeader.Controls.Add(Me.lblTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(663, 60)
        Me.pnlHeader.TabIndex = 186
        '
        'lblSubtitulo
        '
        Me.lblSubtitulo.AutoSize = True
        Me.lblSubtitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubtitulo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.lblSubtitulo.Location = New System.Drawing.Point(22, 34)
        Me.lblSubtitulo.Name = "lblSubtitulo"
        Me.lblSubtitulo.Size = New System.Drawing.Size(86, 13)
        Me.lblSubtitulo.TabIndex = 1
        Me.lblSubtitulo.Text = "Mantenimiento"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(18, 10)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(211, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Servicios y misceláneos"
        '
        'pnlFormulario
        '
        Me.pnlFormulario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFormulario.BackColor = System.Drawing.Color.White
        Me.pnlFormulario.Controls.Add(Me.TxtCuentaVenta)
        Me.pnlFormulario.Controls.Add(Me.TxtPrecioDolar)
        Me.pnlFormulario.Controls.Add(Me.Button2)
        Me.pnlFormulario.Controls.Add(Me.Button1)
        Me.pnlFormulario.Controls.Add(Me.ChkGrabado)
        Me.pnlFormulario.Controls.Add(Me.TxtCtaCosto)
        Me.pnlFormulario.Controls.Add(Me.CboRubro)
        Me.pnlFormulario.Controls.Add(Me.CboIva)
        Me.pnlFormulario.Controls.Add(Me.TxtPrecioCordobas)
        Me.pnlFormulario.Controls.Add(Me.CboActivo)
        Me.pnlFormulario.Controls.Add(Me.lblCuentaVenta)
        Me.pnlFormulario.Controls.Add(Me.lblCuentaCosto)
        Me.pnlFormulario.Controls.Add(Me.lblTablaIVA)
        Me.pnlFormulario.Controls.Add(Me.lblActivo)
        Me.pnlFormulario.Controls.Add(Me.LblDescripcion2)
        Me.pnlFormulario.Controls.Add(Me.GroupBox2)
        Me.pnlFormulario.Controls.Add(Me.pnlTipoCalculo)
        Me.pnlFormulario.Controls.Add(Me.TxtNombreProducto)
        Me.pnlFormulario.Controls.Add(Me.LblDescripcion)
        Me.pnlFormulario.Controls.Add(Me.Button6)
        Me.pnlFormulario.Controls.Add(Me.CboCodigoProducto)
        Me.pnlFormulario.Controls.Add(Me.lblNombreServicio)
        Me.pnlFormulario.Controls.Add(Me.lblRubro)
        Me.pnlFormulario.Controls.Add(Me.GroupBox1)
        Me.pnlFormulario.Controls.Add(Me.lblCodigoServicio)
        Me.pnlFormulario.Location = New System.Drawing.Point(6, 13)
        Me.pnlFormulario.Name = "pnlFormulario"
        Me.pnlFormulario.Size = New System.Drawing.Size(470, 424)
        Me.pnlFormulario.TabIndex = 187
        '
        'lblCuentaVenta
        '
        Me.lblCuentaVenta.AutoSize = True
        Me.lblCuentaVenta.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblCuentaVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCuentaVenta.Location = New System.Drawing.Point(240, 372)
        Me.lblCuentaVenta.Name = "lblCuentaVenta"
        Me.lblCuentaVenta.Size = New System.Drawing.Size(75, 13)
        Me.lblCuentaVenta.TabIndex = 20
        Me.lblCuentaVenta.Text = "Cuenta venta"
        '
        'lblCuentaCosto
        '
        Me.lblCuentaCosto.AutoSize = True
        Me.lblCuentaCosto.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblCuentaCosto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCuentaCosto.Location = New System.Drawing.Point(20, 372)
        Me.lblCuentaCosto.Name = "lblCuentaCosto"
        Me.lblCuentaCosto.Size = New System.Drawing.Size(75, 13)
        Me.lblCuentaCosto.TabIndex = 17
        Me.lblCuentaCosto.Text = "Cuenta costo"
        '
        'lblTablaIVA
        '
        Me.lblTablaIVA.AutoSize = True
        Me.lblTablaIVA.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTablaIVA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTablaIVA.Location = New System.Drawing.Point(240, 320)
        Me.lblTablaIVA.Name = "lblTablaIVA"
        Me.lblTablaIVA.Size = New System.Drawing.Size(62, 13)
        Me.lblTablaIVA.TabIndex = 15
        Me.lblTablaIVA.Text = "Tabla I.V.A."
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblActivo.Location = New System.Drawing.Point(20, 320)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(38, 13)
        Me.lblActivo.TabIndex = 13
        Me.lblActivo.Text = "Activo"
        '
        'LblDescripcion2
        '
        Me.LblDescripcion2.AutoSize = True
        Me.LblDescripcion2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LblDescripcion2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblDescripcion2.Location = New System.Drawing.Point(240, 268)
        Me.LblDescripcion2.Name = "LblDescripcion2"
        Me.LblDescripcion2.Size = New System.Drawing.Size(91, 13)
        Me.LblDescripcion2.TabIndex = 11
        Me.LblDescripcion2.Text = "Precio unitario $"
        '
        'pnlTipoCalculo
        '
        Me.pnlTipoCalculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlTipoCalculo.Location = New System.Drawing.Point(23, 201)
        Me.pnlTipoCalculo.Name = "pnlTipoCalculo"
        Me.pnlTipoCalculo.Size = New System.Drawing.Size(420, 45)
        Me.pnlTipoCalculo.TabIndex = 8
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.LblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblDescripcion.Location = New System.Drawing.Point(20, 268)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(98, 13)
        Me.LblDescripcion.TabIndex = 9
        Me.LblDescripcion.Text = "Precio unitario C$"
        '
        'lblNombreServicio
        '
        Me.lblNombreServicio.AutoSize = True
        Me.lblNombreServicio.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblNombreServicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblNombreServicio.Location = New System.Drawing.Point(20, 105)
        Me.lblNombreServicio.Name = "lblNombreServicio"
        Me.lblNombreServicio.Size = New System.Drawing.Size(108, 13)
        Me.lblNombreServicio.TabIndex = 6
        Me.lblNombreServicio.Text = "Nombre del servicio"
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblRubro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblRubro.Location = New System.Drawing.Point(250, 55)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(39, 13)
        Me.lblRubro.TabIndex = 4
        Me.lblRubro.Text = "Rubro"
        '
        'lblCodigoServicio
        '
        Me.lblCodigoServicio.AutoSize = True
        Me.lblCodigoServicio.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblCodigoServicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCodigoServicio.Location = New System.Drawing.Point(20, 55)
        Me.lblCodigoServicio.Name = "lblCodigoServicio"
        Me.lblCodigoServicio.Size = New System.Drawing.Size(102, 13)
        Me.lblCodigoServicio.TabIndex = 1
        Me.lblCodigoServicio.Text = "Código de servicio"
        '
        'pnlBody
        '
        Me.pnlBody.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlBody.Controls.Add(Me.pnlAcciones)
        Me.pnlBody.Controls.Add(Me.pnlFormulario)
        Me.pnlBody.Location = New System.Drawing.Point(7, 61)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlBody.Size = New System.Drawing.Size(644, 450)
        Me.pnlBody.TabIndex = 188
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.btnEliminar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnNuevo)
        Me.pnlAcciones.Location = New System.Drawing.Point(482, 13)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(150, 424)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.Location = New System.Drawing.Point(10, 381)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(130, 36)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnEliminar.Location = New System.Drawing.Point(10, 98)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(130, 36)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(10, 54)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(130, 36)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnNuevo.Location = New System.Drawing.Point(10, 10)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(130, 36)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "+ Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'FrmServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 510)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.MaximizeBox = False
        Me.Name = "FrmServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "j k"
        Me.Text = "Mantenimiento de Servicios y Miscelaneos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboCodigoProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CboRubro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlFormulario.ResumeLayout(False)
        Me.pnlFormulario.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptServicio As System.Windows.Forms.RadioButton
    Friend WithEvents OptDescuento As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNombreProducto As System.Windows.Forms.TextBox
    Friend WithEvents CboCodigoProducto As C1.Win.C1List.C1Combo
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptImporteFijo As System.Windows.Forms.RadioButton
    Friend WithEvents OptUnidades As System.Windows.Forms.RadioButton
    Friend WithEvents OptSubTotal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrecioCordobas As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCuentaVenta As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCtaCosto As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents ChkGrabado As System.Windows.Forms.CheckBox
    Friend WithEvents CboActivo As System.Windows.Forms.ComboBox
    Friend WithEvents CboIva As System.Windows.Forms.ComboBox
    Friend WithEvents TxtPrecioDolar As System.Windows.Forms.TextBox
    Friend WithEvents CboRubro As C1.Win.C1List.C1Combo
    Friend WithEvents CmdNuevo As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblSubtitulo As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlFormulario As Panel
    Friend WithEvents lblCuentaVenta As Label
    Friend WithEvents lblCuentaCosto As Label
    Friend WithEvents lblTablaIVA As Label
    Friend WithEvents lblActivo As Label
    Friend WithEvents LblDescripcion2 As Label
    Friend WithEvents LblDescripcion As Label
    Friend WithEvents pnlTipoCalculo As Panel
    Friend WithEvents lblNombreServicio As Label
    Friend WithEvents lblRubro As Label
    Friend WithEvents lblCodigoServicio As Label
    Friend WithEvents pnlBody As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
End Class
