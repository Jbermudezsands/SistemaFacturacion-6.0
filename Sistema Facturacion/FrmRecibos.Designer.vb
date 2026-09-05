<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRecibos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim lblSeccionCliente As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecibos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbSerie = New C1.Win.C1List.C1Combo()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.TxtApellidos = New System.Windows.Forms.TextBox()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtCodigoClientes = New System.Windows.Forms.TextBox()
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TxtImporteAplicado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPorAplicar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtImporteRecibido = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.CmdNuevo = New System.Windows.Forms.Button()
        Me.ButtonAgregar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.CboCajero = New C1.Win.C1List.C1Combo()
        Me.LblCajero = New System.Windows.Forms.Label()
        Me.TDBGridDetalle = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.BindingFacturas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalleRecibo = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtTipoRecibo = New System.Windows.Forms.TextBox()
        Me.TxtMonedaFactura = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblLetras = New System.Windows.Forms.Label()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.OptRet2Porciento = New System.Windows.Forms.CheckBox()
        Me.OptRet1Porciento = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlCliente = New System.Windows.Forms.Panel()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.lblSeccionDetalle = New System.Windows.Forms.Label()
        Me.tarjetaPorAplicar = New System.Windows.Forms.Panel()
        Me.lblPorAplicar = New System.Windows.Forms.Label()
        Me.TxtNetoPagar = New System.Windows.Forms.TextBox()
        Me.tarjetaDescuento = New System.Windows.Forms.Panel()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.TxtDescuento = New System.Windows.Forms.TextBox()
        Me.tarjetaSubTotal = New System.Windows.Forms.Panel()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.TxtSubTotal = New System.Windows.Forms.TextBox()
        Me.pnlTotales = New System.Windows.Forms.TableLayoutPanel()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        lblSeccionCliente = New System.Windows.Forms.Label()
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
        Me.pnlHeader.SuspendLayout()
        Me.pnlCliente.SuspendLayout()
        Me.pnlDetalle.SuspendLayout()
        Me.tarjetaPorAplicar.SuspendLayout()
        Me.tarjetaDescuento.SuspendLayout()
        Me.tarjetaSubTotal.SuspendLayout()
        Me.pnlTotales.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSeccionCliente
        '
        lblSeccionCliente.AutoSize = True
        lblSeccionCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        lblSeccionCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(168, Byte), Integer))
        lblSeccionCliente.Location = New System.Drawing.Point(9, 6)
        lblSeccionCliente.Name = "lblSeccionCliente"
        lblSeccionCliente.Size = New System.Drawing.Size(136, 15)
        lblSeccionCliente.TabIndex = 0
        lblSeccionCliente.Text = "Informacion del cliente"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbSerie)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox1.Controls.Add(Me.LblNumero)
        Me.GroupBox1.Controls.Add(Me.DTPFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(457, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 39)
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
        Me.CmbSerie.Location = New System.Drawing.Point(246, 13)
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
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(377, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 32)
        Me.Button6.TabIndex = 127
        Me.Button6.UseVisualStyleBackColor = False
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(295, 14)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(76, 20)
        Me.TxtNumeroEnsamble.TabIndex = 122
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.BackColor = System.Drawing.Color.White
        Me.LblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.LblNumero.Location = New System.Drawing.Point(196, 20)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(44, 13)
        Me.LblNumero.TabIndex = 121
        Me.LblNumero.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(68, 15)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(25, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.TxtTelefono)
        Me.GroupBox2.Controls.Add(Me.TxtDireccion)
        Me.GroupBox2.Controls.Add(Me.TxtApellidos)
        Me.GroupBox2.Controls.Add(Me.TxtNombres)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoClientes)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(737, 80)
        Me.GroupBox2.TabIndex = 171
        Me.GroupBox2.TabStop = False
        '
        'TxtTelefono
        '
        Me.TxtTelefono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TxtTelefono.Location = New System.Drawing.Point(572, 45)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(160, 20)
        Me.TxtTelefono.TabIndex = 132
        '
        'TxtDireccion
        '
        Me.TxtDireccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TxtDireccion.Location = New System.Drawing.Point(12, 45)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(560, 20)
        Me.TxtDireccion.TabIndex = 131
        '
        'TxtApellidos
        '
        Me.TxtApellidos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TxtApellidos.Location = New System.Drawing.Point(461, 21)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(270, 20)
        Me.TxtApellidos.TabIndex = 130
        '
        'TxtNombres
        '
        Me.TxtNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TxtNombres.Location = New System.Drawing.Point(139, 20)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(320, 20)
        Me.TxtNombres.TabIndex = 129
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(100, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 25)
        Me.Button1.TabIndex = 128
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCodigoClientes
        '
        Me.TxtCodigoClientes.BackColor = System.Drawing.Color.White
        Me.TxtCodigoClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TxtCodigoClientes.Location = New System.Drawing.Point(12, 19)
        Me.TxtCodigoClientes.Name = "TxtCodigoClientes"
        Me.TxtCodigoClientes.Size = New System.Drawing.Size(85, 20)
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
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(1142, 124)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75.0R
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
        Me.TxtImporteAplicado.Location = New System.Drawing.Point(1253, 67)
        Me.TxtImporteAplicado.Name = "TxtImporteAplicado"
        Me.TxtImporteAplicado.Size = New System.Drawing.Size(87, 20)
        Me.TxtImporteAplicado.TabIndex = 211
        Me.TxtImporteAplicado.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1167, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Importe Aplicado "
        Me.Label1.Visible = False
        '
        'TxtPorAplicar
        '
        Me.TxtPorAplicar.Enabled = False
        Me.TxtPorAplicar.Location = New System.Drawing.Point(1225, 41)
        Me.TxtPorAplicar.Name = "TxtPorAplicar"
        Me.TxtPorAplicar.Size = New System.Drawing.Size(87, 20)
        Me.TxtPorAplicar.TabIndex = 209
        Me.TxtPorAplicar.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(1165, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 208
        Me.Label5.Text = "Por Aplicar"
        Me.Label5.Visible = False
        '
        'TxtImporteRecibido
        '
        Me.TxtImporteRecibido.Enabled = False
        Me.TxtImporteRecibido.Location = New System.Drawing.Point(1243, 95)
        Me.TxtImporteRecibido.Name = "TxtImporteRecibido"
        Me.TxtImporteRecibido.Size = New System.Drawing.Size(88, 20)
        Me.TxtImporteRecibido.TabIndex = 207
        Me.TxtImporteRecibido.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(1152, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "Importe Recibido   "
        Me.Label7.Visible = False
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Facturas"
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(1131, 299)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(544, 147)
        Me.TrueDBGridComponentes.TabIndex = 212
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.Visible = False
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'CmdNuevo
        '
        Me.CmdNuevo.BackColor = System.Drawing.Color.White
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 14)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(62, 67)
        Me.CmdNuevo.TabIndex = 221
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = False
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
        Me.ButtonAgregar.Text = "Imprimir"
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
        Me.CboCajero.Location = New System.Drawing.Point(589, 108)
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
        Me.LblCajero.Location = New System.Drawing.Point(546, 116)
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
        Me.TDBGridDetalle.BackColor = System.Drawing.Color.White
        Me.TDBGridDetalle.Caption = "Detalle de Recibos"
        Me.TDBGridDetalle.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDBGridDetalle.Images.Add(CType(resources.GetObject("TDBGridDetalle.Images"), System.Drawing.Image))
        Me.TDBGridDetalle.Location = New System.Drawing.Point(13, 23)
        Me.TDBGridDetalle.Name = "TDBGridDetalle"
        Me.TDBGridDetalle.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDBGridDetalle.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDBGridDetalle.PreviewInfo.ZoomFactor = 75.0R
        Me.TDBGridDetalle.PrintInfo.PageSettings = CType(resources.GetObject("TDBGridDetalle.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDBGridDetalle.Size = New System.Drawing.Size(620, 146)
        Me.TDBGridDetalle.TabIndex = 224
        Me.TDBGridDetalle.Text = "C1TrueDBGrid1"
        Me.TDBGridDetalle.PropBag = resources.GetString("TDBGridDetalle.PropBag")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ProgressBar1)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Location = New System.Drawing.Point(749, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(125, 104)
        Me.GroupBox3.TabIndex = 225
        Me.GroupBox3.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 15)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(102, 10)
        Me.ProgressBar1.TabIndex = 223
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(11, 66)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(102, 32)
        Me.Button3.TabIndex = 224
        Me.Button3.Text = "Plan Pagos"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(12, 31)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 32)
        Me.Button2.TabIndex = 222
        Me.Button2.Text = "Abonos"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TxtTipoRecibo
        '
        Me.TxtTipoRecibo.Location = New System.Drawing.Point(458, 146)
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
        Me.TxtMonedaFactura.Location = New System.Drawing.Point(633, 139)
        Me.TxtMonedaFactura.Name = "TxtMonedaFactura"
        Me.TxtMonedaFactura.Size = New System.Drawing.Size(78, 21)
        Me.TxtMonedaFactura.TabIndex = 228
        Me.TxtMonedaFactura.Text = "Cordobas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(581, 142)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 227
        Me.Label13.Text = "Moneda"
        '
        'LblLetras
        '
        Me.LblLetras.AutoSize = True
        Me.LblLetras.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLetras.Location = New System.Drawing.Point(15, 171)
        Me.LblLetras.Name = "LblLetras"
        Me.LblLetras.Size = New System.Drawing.Size(44, 14)
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
        Me.TxtObservaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.TxtObservaciones.Location = New System.Drawing.Point(494, 411)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(386, 52)
        Me.TxtObservaciones.TabIndex = 231
        '
        'OptRet2Porciento
        '
        Me.OptRet2Porciento.AutoSize = True
        Me.OptRet2Porciento.Location = New System.Drawing.Point(128, 110)
        Me.OptRet2Porciento.Name = "OptRet2Porciento"
        Me.OptRet2Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet2Porciento.TabIndex = 187
        Me.OptRet2Porciento.Text = "Retener 2%"
        Me.OptRet2Porciento.UseVisualStyleBackColor = True
        '
        'OptRet1Porciento
        '
        Me.OptRet1Porciento.AutoSize = True
        Me.OptRet1Porciento.BackColor = System.Drawing.Color.White
        Me.OptRet1Porciento.Location = New System.Drawing.Point(22, 109)
        Me.OptRet1Porciento.Name = "OptRet1Porciento"
        Me.OptRet1Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet1Porciento.TabIndex = 186
        Me.OptRet1Porciento.Text = "Retener 1%"
        Me.OptRet1Porciento.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.CmdNuevo)
        Me.GroupBox4.Controls.Add(Me.ButtonAgregar)
        Me.GroupBox4.Controls.Add(Me.ButtonBorrar)
        Me.GroupBox4.Controls.Add(Me.Button8)
        Me.GroupBox4.Location = New System.Drawing.Point(658, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(204, 169)
        Me.GroupBox4.TabIndex = 233
        Me.GroupBox4.TabStop = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblTitulo)
        Me.pnlHeader.Controls.Add(Me.GroupBox1)
        Me.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlHeader.Location = New System.Drawing.Point(4, 1)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(881, 55)
        Me.pnlHeader.TabIndex = 235
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(16, 16)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(127, 21)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Recibos de caja"
        '
        'pnlCliente
        '
        Me.pnlCliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlCliente.BackColor = System.Drawing.Color.White
        Me.pnlCliente.Controls.Add(lblSeccionCliente)
        Me.pnlCliente.Controls.Add(Me.OptRet2Porciento)
        Me.pnlCliente.Controls.Add(Me.GroupBox2)
        Me.pnlCliente.Controls.Add(Me.OptRet1Porciento)
        Me.pnlCliente.Controls.Add(Me.CboCajero)
        Me.pnlCliente.Controls.Add(Me.LblCajero)
        Me.pnlCliente.Controls.Add(Me.GroupBox3)
        Me.pnlCliente.Location = New System.Drawing.Point(4, 62)
        Me.pnlCliente.Name = "pnlCliente"
        Me.pnlCliente.Size = New System.Drawing.Size(883, 136)
        Me.pnlCliente.TabIndex = 236
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.pnlDetalle.Controls.Add(Me.lblSeccionDetalle)
        Me.pnlDetalle.Controls.Add(Me.TDBGridDetalle)
        Me.pnlDetalle.Controls.Add(Me.LblLetras)
        Me.pnlDetalle.Controls.Add(Me.GroupBox4)
        Me.pnlDetalle.Location = New System.Drawing.Point(4, 203)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(886, 190)
        Me.pnlDetalle.TabIndex = 237
        '
        'lblSeccionDetalle
        '
        Me.lblSeccionDetalle.AutoSize = True
        Me.lblSeccionDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeccionDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.lblSeccionDetalle.Location = New System.Drawing.Point(8, 5)
        Me.lblSeccionDetalle.Name = "lblSeccionDetalle"
        Me.lblSeccionDetalle.Size = New System.Drawing.Size(107, 15)
        Me.lblSeccionDetalle.TabIndex = 0
        Me.lblSeccionDetalle.Text = "Detalle de recibos"
        '
        'tarjetaPorAplicar
        '
        Me.tarjetaPorAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tarjetaPorAplicar.Controls.Add(Me.lblPorAplicar)
        Me.tarjetaPorAplicar.Controls.Add(Me.TxtNetoPagar)
        Me.tarjetaPorAplicar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tarjetaPorAplicar.Location = New System.Drawing.Point(307, 3)
        Me.tarjetaPorAplicar.Name = "tarjetaPorAplicar"
        Me.tarjetaPorAplicar.Size = New System.Drawing.Size(173, 57)
        Me.tarjetaPorAplicar.TabIndex = 3
        '
        'lblPorAplicar
        '
        Me.lblPorAplicar.AutoSize = True
        Me.lblPorAplicar.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblPorAplicar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.lblPorAplicar.Location = New System.Drawing.Point(12, 6)
        Me.lblPorAplicar.Name = "lblPorAplicar"
        Me.lblPorAplicar.Size = New System.Drawing.Size(82, 15)
        Me.lblPorAplicar.TabIndex = 0
        Me.lblPorAplicar.Text = "Total Recibido"
        '
        'TxtNetoPagar
        '
        Me.TxtNetoPagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtNetoPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNetoPagar.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetoPagar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.TxtNetoPagar.Location = New System.Drawing.Point(15, 25)
        Me.TxtNetoPagar.Name = "TxtNetoPagar"
        Me.TxtNetoPagar.ReadOnly = True
        Me.TxtNetoPagar.Size = New System.Drawing.Size(138, 26)
        Me.TxtNetoPagar.TabIndex = 216
        Me.TxtNetoPagar.Text = "0.00"
        Me.TxtNetoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tarjetaDescuento
        '
        Me.tarjetaDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tarjetaDescuento.Controls.Add(Me.lblDescuento)
        Me.tarjetaDescuento.Controls.Add(Me.TxtDescuento)
        Me.tarjetaDescuento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tarjetaDescuento.Location = New System.Drawing.Point(155, 3)
        Me.tarjetaDescuento.Margin = New System.Windows.Forms.Padding(3, 3, 8, 3)
        Me.tarjetaDescuento.Name = "tarjetaDescuento"
        Me.tarjetaDescuento.Size = New System.Drawing.Size(141, 57)
        Me.tarjetaDescuento.TabIndex = 1
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblDescuento.Location = New System.Drawing.Point(12, 5)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(63, 15)
        Me.lblDescuento.TabIndex = 0
        Me.lblDescuento.Text = "Descuento"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescuento.Enabled = False
        Me.TxtDescuento.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.TxtDescuento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtDescuento.Location = New System.Drawing.Point(15, 25)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.ReadOnly = True
        Me.TxtDescuento.Size = New System.Drawing.Size(103, 20)
        Me.TxtDescuento.TabIndex = 218
        Me.TxtDescuento.Text = "0.00"
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tarjetaSubTotal
        '
        Me.tarjetaSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tarjetaSubTotal.Controls.Add(Me.lblSubTotal)
        Me.tarjetaSubTotal.Controls.Add(Me.TxtSubTotal)
        Me.tarjetaSubTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tarjetaSubTotal.Location = New System.Drawing.Point(3, 3)
        Me.tarjetaSubTotal.Margin = New System.Windows.Forms.Padding(3, 3, 8, 3)
        Me.tarjetaSubTotal.Name = "tarjetaSubTotal"
        Me.tarjetaSubTotal.Size = New System.Drawing.Size(141, 57)
        Me.tarjetaSubTotal.TabIndex = 0
        '
        'lblSubTotal
        '
        Me.lblSubTotal.AutoSize = True
        Me.lblSubTotal.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lblSubTotal.Location = New System.Drawing.Point(12, 5)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(54, 15)
        Me.lblSubTotal.TabIndex = 0
        Me.lblSubTotal.Text = "Sub total"
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.BackColor = System.Drawing.Color.White
        Me.TxtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubTotal.Enabled = False
        Me.TxtSubTotal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.TxtSubTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtSubTotal.Location = New System.Drawing.Point(15, 25)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.ReadOnly = True
        Me.TxtSubTotal.Size = New System.Drawing.Size(117, 20)
        Me.TxtSubTotal.TabIndex = 214
        Me.TxtSubTotal.Text = "0.00"
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlTotales
        '
        Me.pnlTotales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTotales.ColumnCount = 3
        Me.pnlTotales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57895!))
        Me.pnlTotales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57895!))
        Me.pnlTotales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.84211!))
        Me.pnlTotales.Controls.Add(Me.tarjetaSubTotal, 0, 0)
        Me.pnlTotales.Controls.Add(Me.tarjetaDescuento, 1, 0)
        Me.pnlTotales.Controls.Add(Me.tarjetaPorAplicar, 2, 0)
        Me.pnlTotales.Location = New System.Drawing.Point(5, 401)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.RowCount = 1
        Me.pnlTotales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlTotales.Size = New System.Drawing.Size(483, 63)
        Me.pnlTotales.TabIndex = 238
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.lblObservaciones.Location = New System.Drawing.Point(499, 395)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 239
        Me.lblObservaciones.Text = "Observaciones"
        '
        'FrmRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(897, 468)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.pnlTotales)
        Me.Controls.Add(Me.pnlDetalle)
        Me.Controls.Add(Me.pnlCliente)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.TxtObservaciones)
        Me.Controls.Add(Me.TxtMonedaFactura)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtTipoRecibo)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.TxtImporteAplicado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPorAplicar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtImporteRecibido)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TrueDBGridMetodo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRecibos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibos"
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
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlCliente.ResumeLayout(False)
        Me.pnlCliente.PerformLayout()
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        Me.tarjetaPorAplicar.ResumeLayout(False)
        Me.tarjetaPorAplicar.PerformLayout()
        Me.tarjetaDescuento.ResumeLayout(False)
        Me.tarjetaDescuento.PerformLayout()
        Me.tarjetaSubTotal.ResumeLayout(False)
        Me.tarjetaSubTotal.PerformLayout()
        Me.pnlTotales.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents OptRet2Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents OptRet1Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents pnlHeader As Panel
    Private WithEvents lblTitulo As Label
    Private WithEvents pnlCliente As Panel
    Friend WithEvents Button3 As Button
    Private WithEvents pnlDetalle As Panel
    Private WithEvents lblSeccionDetalle As Label
    Private WithEvents tarjetaPorAplicar As Panel
    Private WithEvents lblPorAplicar As Label
    Friend WithEvents TxtNetoPagar As TextBox
    Private WithEvents tarjetaDescuento As Panel
    Private WithEvents lblDescuento As Label
    Friend WithEvents TxtDescuento As TextBox
    Private WithEvents tarjetaSubTotal As Panel
    Private WithEvents lblSubTotal As Label
    Friend WithEvents TxtSubTotal As TextBox
    Private WithEvents pnlTotales As TableLayoutPanel
    Private WithEvents lblObservaciones As Label
End Class
