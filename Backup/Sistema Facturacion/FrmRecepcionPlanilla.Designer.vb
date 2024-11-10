<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecepcionPlanilla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecepcionPlanilla))
        Me.CmdTransferencias = New System.Windows.Forms.Button
        Me.TxtMonedaImprime = New System.Windows.Forms.TextBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.Label11 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.TxtPagado = New System.Windows.Forms.TextBox
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.DTVencimiento = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.TxtNetoPagar = New System.Windows.Forms.TextBox
        Me.TxtIva = New System.Windows.Forms.TextBox
        Me.TxtSubTotal = New System.Windows.Forms.TextBox
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboTipoProducto = New System.Windows.Forms.ComboBox
        Me.TxtMonedaFactura = New System.Windows.Forms.TextBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CmdFacturar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtObservaciones = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdTransferencias
        '
        Me.CmdTransferencias.Image = CType(resources.GetObject("CmdTransferencias.Image"), System.Drawing.Image)
        Me.CmdTransferencias.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdTransferencias.Location = New System.Drawing.Point(247, 251)
        Me.CmdTransferencias.Name = "CmdTransferencias"
        Me.CmdTransferencias.Size = New System.Drawing.Size(93, 32)
        Me.CmdTransferencias.TabIndex = 245
        Me.CmdTransferencias.Text = "Transferencias"
        Me.CmdTransferencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdTransferencias.UseVisualStyleBackColor = True
        Me.CmdTransferencias.Visible = False
        '
        'TxtMonedaImprime
        '
        Me.TxtMonedaImprime.Enabled = False
        Me.TxtMonedaImprime.Location = New System.Drawing.Point(16, 431)
        Me.TxtMonedaImprime.Name = "TxtMonedaImprime"
        Me.TxtMonedaImprime.Size = New System.Drawing.Size(73, 20)
        Me.TxtMonedaImprime.TabIndex = 254
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(203, 393)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 253
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(664, 145)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(37, 38)
        Me.Button7.TabIndex = 252
        Me.Button7.UseVisualStyleBackColor = True
        '
        'CboCodigoBodega
        '
        Me.CboCodigoBodega.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega.Caption = ""
        Me.CboCodigoBodega.CaptionHeight = 17
        Me.CboCodigoBodega.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega.ColumnCaptionHeight = 17
        Me.CboCodigoBodega.ColumnFooterHeight = 17
        Me.CboCodigoBodega.ContentHeight = 15
        Me.CboCodigoBodega.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega.EditorHeight = 15
        Me.CboCodigoBodega.Images.Add(CType(resources.GetObject("CboCodigoBodega.Images"), System.Drawing.Image))
        Me.CboCodigoBodega.ItemHeight = 15
        Me.CboCodigoBodega.Location = New System.Drawing.Point(521, 149)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(137, 21)
        Me.CboCodigoBodega.TabIndex = 251
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(471, 149)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 250
        Me.Label11.Text = "Bodega"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(339, 130)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(123, 95)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 249
        Me.PictureBox3.TabStop = False
        '
        'TxtPagado
        '
        Me.TxtPagado.Enabled = False
        Me.TxtPagado.Location = New System.Drawing.Point(483, 435)
        Me.TxtPagado.Name = "TxtPagado"
        Me.TxtPagado.Size = New System.Drawing.Size(67, 20)
        Me.TxtPagado.TabIndex = 248
        Me.TxtPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TrueDBGridMetodo
        '
        Me.TrueDBGridMetodo.AllowAddNew = True
        Me.TrueDBGridMetodo.AllowDelete = True
        Me.TrueDBGridMetodo.AlternatingRows = True
        Me.TrueDBGridMetodo.Caption = "Metodos de Pago"
        Me.TrueDBGridMetodo.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridMetodo.Images.Add(CType(resources.GetObject("TrueDBGridMetodo.Images"), System.Drawing.Image))
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(481, 185)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridMetodo.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridMetodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(220, 98)
        Me.TrueDBGridMetodo.TabIndex = 247
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.Visible = False
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'DTVencimiento
        '
        Me.DTVencimiento.CustomFormat = ""
        Me.DTVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTVencimiento.Location = New System.Drawing.Point(572, 123)
        Me.DTVencimiento.Name = "DTVencimiento"
        Me.DTVencimiento.Size = New System.Drawing.Size(104, 20)
        Me.DTVencimiento.TabIndex = 246
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(468, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 244
        Me.Label8.Text = "Fecha Vencimiento"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(339, 231)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(138, 45)
        Me.GroupBox3.TabIndex = 243
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Forma de Pago"
        Me.GroupBox3.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(71, 19)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(65, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Contado"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(7, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Credito"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'TxtNetoPagar
        '
        Me.TxtNetoPagar.Enabled = False
        Me.TxtNetoPagar.Location = New System.Drawing.Point(626, 435)
        Me.TxtNetoPagar.Name = "TxtNetoPagar"
        Me.TxtNetoPagar.Size = New System.Drawing.Size(75, 20)
        Me.TxtNetoPagar.TabIndex = 242
        Me.TxtNetoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIva
        '
        Me.TxtIva.Enabled = False
        Me.TxtIva.Location = New System.Drawing.Point(356, 434)
        Me.TxtIva.Name = "TxtIva"
        Me.TxtIva.Size = New System.Drawing.Size(73, 20)
        Me.TxtIva.TabIndex = 241
        Me.TxtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Enabled = False
        Me.TxtSubTotal.Location = New System.Drawing.Point(235, 433)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.Size = New System.Drawing.Size(67, 20)
        Me.TxtSubTotal.TabIndex = 240
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AllowDelete = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos"
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(18, 289)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(685, 140)
        Me.TrueDBGridComponentes.TabIndex = 239
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.TxtTelefono)
        Me.GroupBox2.Controls.Add(Me.TxtDireccion)
        Me.GroupBox2.Controls.Add(Me.TxtApellidos)
        Me.GroupBox2.Controls.Add(Me.TxtNombres)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoProveedor)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 150)
        Me.GroupBox2.TabIndex = 238
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion del Proveedor"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(237, 16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 147
        Me.Button5.Text = "Ctas x Pagar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(12, 123)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(256, 20)
        Me.TxtTelefono.TabIndex = 132
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(12, 97)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(256, 20)
        Me.TxtDireccion.TabIndex = 131
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(12, 71)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(256, 20)
        Me.TxtApellidos.TabIndex = 130
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(12, 45)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(256, 20)
        Me.TxtNombres.TabIndex = 129
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(194, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 32)
        Me.Button1.TabIndex = 128
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(12, 19)
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(176, 20)
        Me.TxtCodigoProveedor.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(327, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(188, 13)
        Me.Label9.TabIndex = 237
        Me.Label9.Text = "RECEPCION DEL PRODUCTOR"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboTipoProducto)
        Me.GroupBox1.Controls.Add(Me.TxtMonedaFactura)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(687, 48)
        Me.GroupBox1.TabIndex = 235
        Me.GroupBox1.TabStop = False
        '
        'CboTipoProducto
        '
        Me.CboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CboTipoProducto.Enabled = False
        Me.CboTipoProducto.FormattingEnabled = True
        Me.CboTipoProducto.Items.AddRange(New Object() {"Orden de Compra", "Mercancia Recibida", "Devolucion de Compra", "Transferencia Recibida"})
        Me.CboTipoProducto.Location = New System.Drawing.Point(43, 13)
        Me.CboTipoProducto.Name = "CboTipoProducto"
        Me.CboTipoProducto.Size = New System.Drawing.Size(135, 21)
        Me.CboTipoProducto.TabIndex = 128
        Me.CboTipoProducto.Text = "Recepcion"
        '
        'TxtMonedaFactura
        '
        Me.TxtMonedaFactura.Enabled = False
        Me.TxtMonedaFactura.Location = New System.Drawing.Point(619, 15)
        Me.TxtMonedaFactura.Name = "TxtMonedaFactura"
        Me.TxtMonedaFactura.Size = New System.Drawing.Size(59, 20)
        Me.TxtMonedaFactura.TabIndex = 199
        Me.TxtMonedaFactura.Text = "Cordobas"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(488, 10)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 32)
        Me.Button6.TabIndex = 127
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(406, 14)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(76, 20)
        Me.TxtNumeroEnsamble.TabIndex = 122
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(531, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 198
        Me.Label13.Text = "Moneda Compra"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(227, 14)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(2, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(916, 60)
        Me.PictureBox1.TabIndex = 236
        Me.PictureBox1.TabStop = False
        '
        'CmdFacturar
        '
        Me.CmdFacturar.Enabled = False
        Me.CmdFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFacturar.Image = CType(resources.GetObject("CmdFacturar.Image"), System.Drawing.Image)
        Me.CmdFacturar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdFacturar.Location = New System.Drawing.Point(733, 144)
        Me.CmdFacturar.Name = "CmdFacturar"
        Me.CmdFacturar.Size = New System.Drawing.Size(75, 66)
        Me.CmdFacturar.TabIndex = 261
        Me.CmdFacturar.Text = "Comprar"
        Me.CmdFacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdFacturar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(733, 76)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 260
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtObservaciones)
        Me.GroupBox4.Location = New System.Drawing.Point(709, 302)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(198, 127)
        Me.GroupBox4.TabIndex = 259
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Observaciones"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(9, 19)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(186, 102)
        Me.TxtObservaciones.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(810, 143)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 66)
        Me.Button2.TabIndex = 258
        Me.Button2.Text = "Imprimir"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(733, 211)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 257
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(810, 76)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonAgregar.TabIndex = 256
        Me.ButtonAgregar.Text = "Guardar"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(810, 212)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 255
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(308, 437)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "IVA      "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(169, 437)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Sub Total   "
        '
        'FrmRecepcionPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 484)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmdFacturar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.CmdTransferencias)
        Me.Controls.Add(Me.TxtMonedaImprime)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.TxtPagado)
        Me.Controls.Add(Me.TrueDBGridMetodo)
        Me.Controls.Add(Me.DTVencimiento)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TxtNetoPagar)
        Me.Controls.Add(Me.TxtIva)
        Me.Controls.Add(Me.TxtSubTotal)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmRecepcionPlanilla"
        Me.Text = "FrmRecepcionPlanilla"
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdTransferencias As System.Windows.Forms.Button
    Friend WithEvents TxtMonedaImprime As System.Windows.Forms.TextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtPagado As System.Windows.Forms.TextBox
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DTVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNetoPagar As System.Windows.Forms.TextBox
    Friend WithEvents TxtIva As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMonedaFactura As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdFacturar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BindingMetodo As System.Windows.Forms.BindingSource
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
End Class
