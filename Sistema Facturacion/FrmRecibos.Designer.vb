<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecibos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecibos))
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmbSerie = New C1.Win.C1List.C1Combo
        Me.Button6 = New System.Windows.Forms.Button
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.LblNumero = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtCodigoClientes = New System.Windows.Forms.TextBox
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TxtImporteAplicado = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPorAplicar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtImporteRecibido = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TxtDescuento = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtNetoPagar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtSubTotal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.CboCajero = New C1.Win.C1List.C1Combo
        Me.LblCajero = New System.Windows.Forms.Label
        Me.TDBGridDetalle = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BindingFacturas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalleRecibo = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Button2 = New System.Windows.Forms.Button
        Me.TxtTipoRecibo = New System.Windows.Forms.TextBox
        Me.TxtMonedaFactura = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.LblLetras = New System.Windows.Forms.Label
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.TxtObservaciones = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.OptRet2Porciento = New System.Windows.Forms.CheckBox
        Me.OptRet1Porciento = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDBGridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(301, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 13)
        Me.Label9.TabIndex = 169
        Me.Label9.Text = "RECIBOS DE CAJA"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(11, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(97, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 168
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-3, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(795, 60)
        Me.PictureBox1.TabIndex = 167
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbSerie)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox1.Controls.Add(Me.LblNumero)
        Me.GroupBox1.Controls.Add(Me.DTPFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 48)
        Me.GroupBox1.TabIndex = 170
        Me.GroupBox1.TabStop = False
        '
        'CmbSerie
        '
        Me.CmbSerie.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbSerie.Caption = ""
        Me.CmbSerie.CaptionHeight = 17
        Me.CmbSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbSerie.ColumnCaptionHeight = 17
        Me.CmbSerie.ColumnFooterHeight = 17
        Me.CmbSerie.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CmbSerie.ContentHeight = 15
        Me.CmbSerie.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbSerie.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbSerie.DropDownWidth = 100
        Me.CmbSerie.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbSerie.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSerie.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbSerie.EditorHeight = 15
        Me.CmbSerie.Images.Add(CType(resources.GetObject("CmbSerie.Images"), System.Drawing.Image))
        Me.CmbSerie.ItemHeight = 15
        Me.CmbSerie.Location = New System.Drawing.Point(357, 13)
        Me.CmbSerie.MatchEntryTimeout = CType(2000, Long)
        Me.CmbSerie.MaxDropDownItems = CType(5, Short)
        Me.CmbSerie.MaxLength = 32767
        Me.CmbSerie.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbSerie.Name = "CmbSerie"
        Me.CmbSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbSerie.Size = New System.Drawing.Size(43, 21)
        Me.CmbSerie.TabIndex = 212
        Me.CmbSerie.Visible = False
        Me.CmbSerie.PropBag = resources.GetString("CmbSerie.PropBag")
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
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.Location = New System.Drawing.Point(307, 20)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(44, 13)
        Me.LblNumero.TabIndex = 121
        Me.LblNumero.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(58, 14)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtTelefono)
        Me.GroupBox2.Controls.Add(Me.TxtDireccion)
        Me.GroupBox2.Controls.Add(Me.TxtApellidos)
        Me.GroupBox2.Controls.Add(Me.TxtNombres)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoClientes)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 117)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(277, 158)
        Me.GroupBox2.TabIndex = 171
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion del Cliente"
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
        'TxtCodigoClientes
        '
        Me.TxtCodigoClientes.Location = New System.Drawing.Point(12, 19)
        Me.TxtCodigoClientes.Name = "TxtCodigoClientes"
        Me.TxtCodigoClientes.Size = New System.Drawing.Size(176, 20)
        Me.TxtCodigoClientes.TabIndex = 0
        '
        'TrueDBGridMetodo
        '
        Me.TrueDBGridMetodo.AllowAddNew = True
        Me.TrueDBGridMetodo.AllowDelete = True
        Me.TrueDBGridMetodo.AlternatingRows = True
        Me.TrueDBGridMetodo.Caption = "Metodos de Pago"
        Me.TrueDBGridMetodo.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridMetodo.Images.Add(CType(resources.GetObject("TrueDBGridMetodo.Images"), System.Drawing.Image))
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(925, 126)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridMetodo.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridMetodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(249, 146)
        Me.TrueDBGridMetodo.TabIndex = 205
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.Visible = False
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'TxtImporteAplicado
        '
        Me.TxtImporteAplicado.Enabled = False
        Me.TxtImporteAplicado.Location = New System.Drawing.Point(297, 284)
        Me.TxtImporteAplicado.Name = "TxtImporteAplicado"
        Me.TxtImporteAplicado.Size = New System.Drawing.Size(87, 20)
        Me.TxtImporteAplicado.TabIndex = 211
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(211, 288)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Importe Aplicado "
        '
        'TxtPorAplicar
        '
        Me.TxtPorAplicar.Enabled = False
        Me.TxtPorAplicar.Location = New System.Drawing.Point(460, 284)
        Me.TxtPorAplicar.Name = "TxtPorAplicar"
        Me.TxtPorAplicar.Size = New System.Drawing.Size(87, 20)
        Me.TxtPorAplicar.TabIndex = 209
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(400, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 208
        Me.Label5.Text = "Por Aplicar"
        '
        'TxtImporteRecibido
        '
        Me.TxtImporteRecibido.Enabled = False
        Me.TxtImporteRecibido.Location = New System.Drawing.Point(103, 284)
        Me.TxtImporteRecibido.Name = "TxtImporteRecibido"
        Me.TxtImporteRecibido.Size = New System.Drawing.Size(88, 20)
        Me.TxtImporteRecibido.TabIndex = 207
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 287)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "Importe Recibido   "
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Facturas"
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(925, 301)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(544, 147)
        Me.TrueDBGridComponentes.TabIndex = 212
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.Visible = False
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Location = New System.Drawing.Point(258, 465)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(67, 20)
        Me.TxtDescuento.TabIndex = 218
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(194, 468)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 217
        Me.Label10.Text = "Descuento   "
        '
        'TxtNetoPagar
        '
        Me.TxtNetoPagar.Enabled = False
        Me.TxtNetoPagar.Location = New System.Drawing.Point(471, 465)
        Me.TxtNetoPagar.Name = "TxtNetoPagar"
        Me.TxtNetoPagar.Size = New System.Drawing.Size(75, 20)
        Me.TxtNetoPagar.TabIndex = 216
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(395, 468)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 215
        Me.Label6.Text = "Total Recibido "
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Enabled = False
        Me.TxtSubTotal.Location = New System.Drawing.Point(80, 463)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.Size = New System.Drawing.Size(67, 20)
        Me.TxtSubTotal.TabIndex = 214
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(22, 468)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "Sub Total   "
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 14)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(62, 67)
        Me.CmdNuevo.TabIndex = 221
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(74, 14)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(62, 67)
        Me.ButtonAgregar.TabIndex = 220
        Me.ButtonAgregar.Tag = "25"
        Me.ButtonAgregar.Text = "Recibir"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(61, 92)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 219
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CboCajero
        '
        Me.CboCajero.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCajero.Caption = ""
        Me.CboCajero.CaptionHeight = 17
        Me.CboCajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCajero.ColumnCaptionHeight = 17
        Me.CboCajero.ColumnFooterHeight = 17
        Me.CboCajero.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCajero.ContentHeight = 15
        Me.CboCajero.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCajero.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCajero.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCajero.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCajero.EditorHeight = 15
        Me.CboCajero.Images.Add(CType(resources.GetObject("CboCajero.Images"), System.Drawing.Image))
        Me.CboCajero.ItemHeight = 15
        Me.CboCajero.Location = New System.Drawing.Point(353, 254)
        Me.CboCajero.MatchEntryTimeout = CType(2000, Long)
        Me.CboCajero.MaxDropDownItems = CType(5, Short)
        Me.CboCajero.MaxLength = 32767
        Me.CboCajero.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCajero.Name = "CboCajero"
        Me.CboCajero.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCajero.Size = New System.Drawing.Size(121, 21)
        Me.CboCajero.TabIndex = 223
        Me.CboCajero.PropBag = resources.GetString("CboCajero.PropBag")
        '
        'LblCajero
        '
        Me.LblCajero.AutoSize = True
        Me.LblCajero.Location = New System.Drawing.Point(301, 259)
        Me.LblCajero.Name = "LblCajero"
        Me.LblCajero.Size = New System.Drawing.Size(37, 13)
        Me.LblCajero.TabIndex = 222
        Me.LblCajero.Text = "Cajero"
        '
        'TDBGridDetalle
        '
        Me.TDBGridDetalle.AllowAddNew = True
        Me.TDBGridDetalle.AllowDelete = True
        Me.TDBGridDetalle.AlternatingRows = True
        Me.TDBGridDetalle.Caption = "Detalle de Recibos"
        Me.TDBGridDetalle.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDBGridDetalle.Images.Add(CType(resources.GetObject("TDBGridDetalle.Images"), System.Drawing.Image))
        Me.TDBGridDetalle.Location = New System.Drawing.Point(11, 311)
        Me.TDBGridDetalle.Name = "TDBGridDetalle"
        Me.TDBGridDetalle.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDBGridDetalle.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDBGridDetalle.PreviewInfo.ZoomFactor = 75
        Me.TDBGridDetalle.PrintInfo.PageSettings = CType(resources.GetObject("TDBGridDetalle.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDBGridDetalle.Size = New System.Drawing.Size(535, 146)
        Me.TDBGridDetalle.TabIndex = 224
        Me.TDBGridDetalle.Text = "C1TrueDBGrid1"
        Me.TDBGridDetalle.PropBag = resources.GetString("TDBGridDetalle.PropBag")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ProgressBar1)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Location = New System.Drawing.Point(374, 144)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(155, 104)
        Me.GroupBox3.TabIndex = 225
        Me.GroupBox3.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 15)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(140, 10)
        Me.ProgressBar1.TabIndex = 223
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(36, 31)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 67)
        Me.Button2.TabIndex = 222
        Me.Button2.Text = "Abonos"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtTipoRecibo
        '
        Me.TxtTipoRecibo.Location = New System.Drawing.Point(297, 124)
        Me.TxtTipoRecibo.Name = "TxtTipoRecibo"
        Me.TxtTipoRecibo.Size = New System.Drawing.Size(100, 20)
        Me.TxtTipoRecibo.TabIndex = 226
        Me.TxtTipoRecibo.Text = "Recibos de Caja"
        Me.TxtTipoRecibo.Visible = False
        '
        'TxtMonedaFactura
        '
        Me.TxtMonedaFactura.FormattingEnabled = True
        Me.TxtMonedaFactura.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.TxtMonedaFactura.Location = New System.Drawing.Point(472, 117)
        Me.TxtMonedaFactura.Name = "TxtMonedaFactura"
        Me.TxtMonedaFactura.Size = New System.Drawing.Size(78, 21)
        Me.TxtMonedaFactura.TabIndex = 228
        Me.TxtMonedaFactura.Text = "Cordobas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(420, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 227
        Me.Label13.Text = "Moneda"
        '
        'LblLetras
        '
        Me.LblLetras.AutoSize = True
        Me.LblLetras.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLetras.Location = New System.Drawing.Point(22, 492)
        Me.LblLetras.Name = "LblLetras"
        Me.LblLetras.Size = New System.Drawing.Size(42, 14)
        Me.LblLetras.TabIndex = 229
        Me.LblLetras.Text = "Label8"
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(138, 13)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(62, 66)
        Me.ButtonBorrar.TabIndex = 230
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(563, 375)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(204, 80)
        Me.TxtObservaciones.TabIndex = 231
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(566, 358)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 232
        Me.Label8.Text = "Observaciones"
        '
        'OptRet2Porciento
        '
        Me.OptRet2Porciento.AutoSize = True
        Me.OptRet2Porciento.Location = New System.Drawing.Point(288, 228)
        Me.OptRet2Porciento.Name = "OptRet2Porciento"
        Me.OptRet2Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet2Porciento.TabIndex = 187
        Me.OptRet2Porciento.Text = "Retener 2%"
        Me.OptRet2Porciento.UseVisualStyleBackColor = True
        '
        'OptRet1Porciento
        '
        Me.OptRet1Porciento.AutoSize = True
        Me.OptRet1Porciento.Location = New System.Drawing.Point(288, 208)
        Me.OptRet1Porciento.Name = "OptRet1Porciento"
        Me.OptRet1Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet1Porciento.TabIndex = 186
        Me.OptRet1Porciento.Text = "Retener 1%"
        Me.OptRet1Porciento.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CmdNuevo)
        Me.GroupBox4.Controls.Add(Me.ButtonAgregar)
        Me.GroupBox4.Controls.Add(Me.ButtonBorrar)
        Me.GroupBox4.Controls.Add(Me.Button8)
        Me.GroupBox4.Location = New System.Drawing.Point(563, 180)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(204, 169)
        Me.GroupBox4.TabIndex = 233
        Me.GroupBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(565, 63)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(204, 111)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 234
        Me.PictureBox3.TabStop = False
        '
        'FrmRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 515)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.OptRet2Porciento)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.OptRet1Porciento)
        Me.Controls.Add(Me.TxtObservaciones)
        Me.Controls.Add(Me.LblLetras)
        Me.Controls.Add(Me.TxtMonedaFactura)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtTipoRecibo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TDBGridDetalle)
        Me.Controls.Add(Me.CboCajero)
        Me.Controls.Add(Me.LblCajero)
        Me.Controls.Add(Me.TxtDescuento)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtNetoPagar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtSubTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.TxtImporteAplicado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPorAplicar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtImporteRecibido)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TrueDBGridMetodo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRecibos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibos"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDBGridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoClientes As System.Windows.Forms.TextBox
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtImporteAplicado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPorAplicar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteRecibido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtNetoPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents BindingFacturas As System.Windows.Forms.BindingSource
    Friend WithEvents BindingMetodo As System.Windows.Forms.BindingSource
    Friend WithEvents CboCajero As C1.Win.C1List.C1Combo
    Friend WithEvents LblCajero As System.Windows.Forms.Label
    Friend WithEvents TDBGridDetalle As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BindingDetalleRecibo As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtTipoRecibo As System.Windows.Forms.TextBox
    Friend WithEvents TxtMonedaFactura As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblLetras As System.Windows.Forms.Label
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OptRet2Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents OptRet1Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
