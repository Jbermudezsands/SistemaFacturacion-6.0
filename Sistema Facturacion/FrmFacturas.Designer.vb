<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacturas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturas))
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtPagado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.DTVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TxtNetoPagar = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtIva = New System.Windows.Forms.TextBox()
        Me.LblIVA = New System.Windows.Forms.Label()
        Me.TxtSubTotal = New System.Windows.Forms.TextBox()
        Me.LblSubTotal = New System.Windows.Forms.Label()
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkAplicarCtaXCobrar = New System.Windows.Forms.CheckBox()
        Me.BtnFacturas = New C1.Win.C1Input.C1Button()
        Me.TxtNumeroFactura = New System.Windows.Forms.TextBox()
        Me.ChkPropina = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CboReferencia = New System.Windows.Forms.ComboBox()
        Me.OptRet2Porciento = New System.Windows.Forms.CheckBox()
        Me.OptRet1Porciento = New System.Windows.Forms.CheckBox()
        Me.OptExsonerado = New System.Windows.Forms.CheckBox()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.TxtApellidos = New System.Windows.Forms.TextBox()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtCodigoClientes = New System.Windows.Forms.TextBox()
        Me.CmdCuentasxCobrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbSerie = New C1.Win.C1List.C1Combo()
        Me.TxtMonedaFactura = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CboTipoProducto = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdNuevo = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtDescuento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.ButtonAgregar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.CboCodigoBodega2 = New C1.Win.C1List.C1Combo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CboCodigoVendedor = New C1.Win.C1List.C1Combo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmdFacturar = New System.Windows.Forms.Button()
        Me.CboCajero = New C1.Win.C1List.C1Combo()
        Me.LblCajero = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TxtMonedaImprime = New System.Windows.Forms.ComboBox()
        Me.C1Button1 = New C1.Win.C1Input.C1Button()
        Me.CmdProcesar = New System.Windows.Forms.Button()
        Me.ChkPorcientoTarjeta = New System.Windows.Forms.CheckBox()
        Me.C1Button2 = New C1.Win.C1Input.C1Button()
        Me.C1Button3 = New C1.Win.C1Input.C1Button()
        Me.C1Button4 = New C1.Win.C1Input.C1Button()
        Me.CboProyecto = New C1.Win.C1List.C1Combo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.C1Button5 = New C1.Win.C1Input.C1Button()
        Me.TxtRetencion2Porciento = New System.Windows.Forms.TextBox()
        Me.TxtRetencion1Porciento = New System.Windows.Forms.TextBox()
        Me.LblPropina = New System.Windows.Forms.Label()
        Me.TxtPropina = New System.Windows.Forms.TextBox()
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.DTPFechaHora = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BtnSalida = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.CboCodigoBodega2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(1184, 80)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 183
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(688, 81)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(37, 38)
        Me.Button7.TabIndex = 182
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'CboCodigoBodega
        '
        Me.CboCodigoBodega.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega.Caption = ""
        Me.CboCodigoBodega.CaptionHeight = 17
        Me.CboCodigoBodega.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega.ColumnCaptionHeight = 17
        Me.CboCodigoBodega.ColumnFooterHeight = 17
        Me.CboCodigoBodega.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCodigoBodega.ContentHeight = 15
        Me.CboCodigoBodega.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega.EditorHeight = 15
        Me.CboCodigoBodega.Images.Add(CType(resources.GetObject("CboCodigoBodega.Images"), System.Drawing.Image))
        Me.CboCodigoBodega.ItemHeight = 15
        Me.CboCodigoBodega.Location = New System.Drawing.Point(559, 132)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(121, 21)
        Me.CboCodigoBodega.TabIndex = 181
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(475, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 180
        Me.Label11.Text = "Bodega Origen"
        '
        'TxtPagado
        '
        Me.TxtPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPagado.Location = New System.Drawing.Point(493, 467)
        Me.TxtPagado.Name = "TxtPagado"
        Me.TxtPagado.ReadOnly = True
        Me.TxtPagado.Size = New System.Drawing.Size(60, 20)
        Me.TxtPagado.TabIndex = 178
        Me.TxtPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(445, 470)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 177
        Me.Label10.Text = "Pagado    "
        '
        'TrueDBGridMetodo
        '
        Me.TrueDBGridMetodo.AllowAddNew = True
        Me.TrueDBGridMetodo.AllowDelete = True
        Me.TrueDBGridMetodo.AlternatingRows = True
        Me.TrueDBGridMetodo.Caption = "Metodos de Pago"
        Me.TrueDBGridMetodo.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridMetodo.Images.Add(CType(resources.GetObject("TrueDBGridMetodo.Images"), System.Drawing.Image))
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(487, 219)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridMetodo.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridMetodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(220, 72)
        Me.TrueDBGridMetodo.TabIndex = 176
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.Visible = False
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'DTVencimiento
        '
        Me.DTVencimiento.CustomFormat = ""
        Me.DTVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTVencimiento.Location = New System.Drawing.Point(576, 106)
        Me.DTVencimiento.Name = "DTVencimiento"
        Me.DTVencimiento.Size = New System.Drawing.Size(104, 20)
        Me.DTVencimiento.TabIndex = 175
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(472, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 174
        Me.Label8.Text = "Fecha Vencimiento"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(20, 270)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 172
        Me.Button4.Text = "Borrar Linea"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(343, 219)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(138, 45)
        Me.GroupBox3.TabIndex = 171
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Forma de Pago"
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
        Me.TxtNetoPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetoPagar.Location = New System.Drawing.Point(630, 466)
        Me.TxtNetoPagar.Name = "TxtNetoPagar"
        Me.TxtNetoPagar.ReadOnly = True
        Me.TxtNetoPagar.Size = New System.Drawing.Size(75, 20)
        Me.TxtNetoPagar.TabIndex = 170
        Me.TxtNetoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(560, 469)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 169
        Me.Label6.Text = "Neto a Pagar "
        '
        'TxtIva
        '
        Me.TxtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIva.Location = New System.Drawing.Point(306, 467)
        Me.TxtIva.Name = "TxtIva"
        Me.TxtIva.ReadOnly = True
        Me.TxtIva.Size = New System.Drawing.Size(60, 20)
        Me.TxtIva.TabIndex = 168
        Me.TxtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblIVA
        '
        Me.LblIVA.AutoSize = True
        Me.LblIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblIVA.Location = New System.Drawing.Point(258, 470)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(42, 13)
        Me.LblIVA.TabIndex = 167
        Me.LblIVA.Text = "IVA      "
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotal.ForeColor = System.Drawing.Color.Black
        Me.TxtSubTotal.Location = New System.Drawing.Point(185, 466)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.ReadOnly = True
        Me.TxtSubTotal.Size = New System.Drawing.Size(60, 20)
        Me.TxtSubTotal.TabIndex = 166
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSubTotal
        '
        Me.LblSubTotal.AutoSize = True
        Me.LblSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblSubTotal.Location = New System.Drawing.Point(122, 469)
        Me.LblSubTotal.Name = "LblSubTotal"
        Me.LblSubTotal.Size = New System.Drawing.Size(62, 13)
        Me.LblSubTotal.TabIndex = 165
        Me.LblSubTotal.Text = "Sub Total   "
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos"
        Me.TrueDBGridComponentes.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveNone
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(22, 294)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(685, 167)
        Me.TrueDBGridComponentes.TabIndex = 164
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(340, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(177, 13)
        Me.Label9.TabIndex = 163
        Me.Label9.Text = "OPERACIONES DE FACTURA"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(22, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 162
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(980, 60)
        Me.PictureBox1.TabIndex = 161
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkAplicarCtaXCobrar)
        Me.GroupBox2.Controls.Add(Me.BtnFacturas)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroFactura)
        Me.GroupBox2.Controls.Add(Me.ChkPropina)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.CboReferencia)
        Me.GroupBox2.Controls.Add(Me.OptRet2Porciento)
        Me.GroupBox2.Controls.Add(Me.OptRet1Porciento)
        Me.GroupBox2.Controls.Add(Me.OptExsonerado)
        Me.GroupBox2.Controls.Add(Me.TxtTelefono)
        Me.GroupBox2.Controls.Add(Me.TxtDireccion)
        Me.GroupBox2.Controls.Add(Me.TxtApellidos)
        Me.GroupBox2.Controls.Add(Me.TxtNombres)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoClientes)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 158)
        Me.GroupBox2.TabIndex = 160
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion del Cliente"
        '
        'ChkAplicarCtaXCobrar
        '
        Me.ChkAplicarCtaXCobrar.AutoSize = True
        Me.ChkAplicarCtaXCobrar.Location = New System.Drawing.Point(205, 19)
        Me.ChkAplicarCtaXCobrar.Name = "ChkAplicarCtaXCobrar"
        Me.ChkAplicarCtaXCobrar.Size = New System.Drawing.Size(108, 17)
        Me.ChkAplicarCtaXCobrar.TabIndex = 228
        Me.ChkAplicarCtaXCobrar.Text = "Aplicar CtasXCob"
        Me.ChkAplicarCtaXCobrar.UseVisualStyleBackColor = True
        '
        'BtnFacturas
        '
        Me.BtnFacturas.Image = CType(resources.GetObject("BtnFacturas.Image"), System.Drawing.Image)
        Me.BtnFacturas.Location = New System.Drawing.Point(184, 125)
        Me.BtnFacturas.Name = "BtnFacturas"
        Me.BtnFacturas.Size = New System.Drawing.Size(39, 24)
        Me.BtnFacturas.TabIndex = 227
        Me.BtnFacturas.UseVisualStyleBackColor = True
        Me.BtnFacturas.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'TxtNumeroFactura
        '
        Me.TxtNumeroFactura.Location = New System.Drawing.Point(78, 126)
        Me.TxtNumeroFactura.Name = "TxtNumeroFactura"
        Me.TxtNumeroFactura.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumeroFactura.TabIndex = 226
        Me.TxtNumeroFactura.Visible = False
        '
        'ChkPropina
        '
        Me.ChkPropina.AutoSize = True
        Me.ChkPropina.Location = New System.Drawing.Point(227, 77)
        Me.ChkPropina.Name = "ChkPropina"
        Me.ChkPropina.Size = New System.Drawing.Size(62, 17)
        Me.ChkPropina.TabIndex = 225
        Me.ChkPropina.Text = "Propina"
        Me.ChkPropina.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 131)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 224
        Me.Label16.Text = "Referencia"
        '
        'CboReferencia
        '
        Me.CboReferencia.DropDownWidth = 300
        Me.CboReferencia.FormattingEnabled = True
        Me.CboReferencia.Location = New System.Drawing.Point(86, 126)
        Me.CboReferencia.Name = "CboReferencia"
        Me.CboReferencia.Size = New System.Drawing.Size(135, 21)
        Me.CboReferencia.TabIndex = 223
        '
        'OptRet2Porciento
        '
        Me.OptRet2Porciento.AutoSize = True
        Me.OptRet2Porciento.Location = New System.Drawing.Point(227, 119)
        Me.OptRet2Porciento.Name = "OptRet2Porciento"
        Me.OptRet2Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet2Porciento.TabIndex = 185
        Me.OptRet2Porciento.Text = "Retener 2%"
        Me.OptRet2Porciento.UseVisualStyleBackColor = True
        '
        'OptRet1Porciento
        '
        Me.OptRet1Porciento.AutoSize = True
        Me.OptRet1Porciento.Location = New System.Drawing.Point(227, 99)
        Me.OptRet1Porciento.Name = "OptRet1Porciento"
        Me.OptRet1Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet1Porciento.TabIndex = 184
        Me.OptRet1Porciento.Text = "Retener 1%"
        Me.OptRet1Porciento.UseVisualStyleBackColor = True
        '
        'OptExsonerado
        '
        Me.OptExsonerado.AutoSize = True
        Me.OptExsonerado.Location = New System.Drawing.Point(227, 139)
        Me.OptExsonerado.Name = "OptExsonerado"
        Me.OptExsonerado.Size = New System.Drawing.Size(77, 17)
        Me.OptExsonerado.TabIndex = 148
        Me.OptExsonerado.Text = "Exonerado"
        Me.OptExsonerado.UseVisualStyleBackColor = True
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(12, 99)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(209, 20)
        Me.TxtTelefono.TabIndex = 132
        Me.TxtTelefono.Visible = False
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(12, 97)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(209, 20)
        Me.TxtDireccion.TabIndex = 131
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(12, 71)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(210, 20)
        Me.TxtApellidos.TabIndex = 130
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(12, 45)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(292, 20)
        Me.TxtNombres.TabIndex = 129
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(165, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 32)
        Me.Button1.TabIndex = 128
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCodigoClientes
        '
        Me.TxtCodigoClientes.Location = New System.Drawing.Point(12, 18)
        Me.TxtCodigoClientes.Name = "TxtCodigoClientes"
        Me.TxtCodigoClientes.Size = New System.Drawing.Size(152, 20)
        Me.TxtCodigoClientes.TabIndex = 0
        '
        'CmdCuentasxCobrar
        '
        Me.CmdCuentasxCobrar.Location = New System.Drawing.Point(343, 89)
        Me.CmdCuentasxCobrar.Name = "CmdCuentasxCobrar"
        Me.CmdCuentasxCobrar.Size = New System.Drawing.Size(85, 23)
        Me.CmdCuentasxCobrar.TabIndex = 147
        Me.CmdCuentasxCobrar.Text = "Ctas x Cobrar"
        Me.CmdCuentasxCobrar.UseVisualStyleBackColor = True
        Me.CmdCuentasxCobrar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbSerie)
        Me.GroupBox1.Controls.Add(Me.TxtMonedaFactura)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.CboTipoProducto)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(700, 48)
        Me.GroupBox1.TabIndex = 159
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
        Me.CmbSerie.Location = New System.Drawing.Point(373, 14)
        Me.CmbSerie.MatchEntryTimeout = CType(2000, Long)
        Me.CmbSerie.MaxDropDownItems = CType(5, Short)
        Me.CmbSerie.MaxLength = 32767
        Me.CmbSerie.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbSerie.Name = "CmbSerie"
        Me.CmbSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbSerie.Size = New System.Drawing.Size(43, 21)
        Me.CmbSerie.TabIndex = 211
        Me.CmbSerie.Visible = False
        Me.CmbSerie.PropBag = resources.GetString("CmbSerie.PropBag")
        '
        'TxtMonedaFactura
        '
        Me.TxtMonedaFactura.FormattingEnabled = True
        Me.TxtMonedaFactura.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.TxtMonedaFactura.Location = New System.Drawing.Point(615, 17)
        Me.TxtMonedaFactura.Name = "TxtMonedaFactura"
        Me.TxtMonedaFactura.Size = New System.Drawing.Size(78, 21)
        Me.TxtMonedaFactura.TabIndex = 131
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(530, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Moneda Factura"
        '
        'CboTipoProducto
        '
        Me.CboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoProducto.FormattingEnabled = True
        Me.CboTipoProducto.Location = New System.Drawing.Point(43, 13)
        Me.CboTipoProducto.Name = "CboTipoProducto"
        Me.CboTipoProducto.Size = New System.Drawing.Size(135, 21)
        Me.CboTipoProducto.TabIndex = 128
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(491, 10)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 32)
        Me.Button6.TabIndex = 127
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(419, 14)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(70, 20)
        Me.TxtNumeroEnsamble.TabIndex = 122
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(330, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(222, 14)
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
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(9, 14)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(62, 66)
        Me.CmdNuevo.TabIndex = 189
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtDescuento)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.TxtObservaciones)
        Me.GroupBox4.Location = New System.Drawing.Point(720, 374)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(175, 113)
        Me.GroupBox4.TabIndex = 188
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Observaciones"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.ForeColor = System.Drawing.Color.Black
        Me.TxtDescuento.Location = New System.Drawing.Point(64, 30)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(67, 20)
        Me.TxtDescuento.TabIndex = 199
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDescuento.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(9, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 198
        Me.Label14.Text = "Descuento   "
        Me.Label14.Visible = False
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(5, 14)
        Me.TxtObservaciones.MaxLength = 250
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(160, 86)
        Me.TxtObservaciones.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(9, 158)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 66)
        Me.Button2.TabIndex = 187
        Me.Button2.Tag = "27"
        Me.Button2.Text = "Imprimir"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(9, 87)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(62, 66)
        Me.ButtonBorrar.TabIndex = 186
        Me.ButtonBorrar.Tag = "26"
        Me.ButtonBorrar.Text = "Anular"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(77, 14)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(62, 66)
        Me.ButtonAgregar.TabIndex = 185
        Me.ButtonAgregar.Tag = "25"
        Me.ButtonAgregar.Text = "Guardar"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(9, 234)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(62, 68)
        Me.Button8.TabIndex = 184
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CboCodigoBodega2
        '
        Me.CboCodigoBodega2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega2.Caption = ""
        Me.CboCodigoBodega2.CaptionHeight = 17
        Me.CboCodigoBodega2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega2.ColumnCaptionHeight = 17
        Me.CboCodigoBodega2.ColumnFooterHeight = 17
        Me.CboCodigoBodega2.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCodigoBodega2.ContentHeight = 15
        Me.CboCodigoBodega2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega2.EditorHeight = 15
        Me.CboCodigoBodega2.Images.Add(CType(resources.GetObject("CboCodigoBodega2.Images"), System.Drawing.Image))
        Me.CboCodigoBodega2.ItemHeight = 15
        Me.CboCodigoBodega2.Location = New System.Drawing.Point(559, 159)
        Me.CboCodigoBodega2.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega2.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega2.MaxLength = 32767
        Me.CboCodigoBodega2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega2.Name = "CboCodigoBodega2"
        Me.CboCodigoBodega2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega2.Size = New System.Drawing.Size(121, 21)
        Me.CboCodigoBodega2.TabIndex = 191
        Me.CboCodigoBodega2.Visible = False
        Me.CboCodigoBodega2.PropBag = resources.GetString("CboCodigoBodega2.PropBag")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(475, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 190
        Me.Label7.Text = "Bodega Destino"
        Me.Label7.Visible = False
        '
        'CboCodigoVendedor
        '
        Me.CboCodigoVendedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoVendedor.Caption = ""
        Me.CboCodigoVendedor.CaptionHeight = 17
        Me.CboCodigoVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoVendedor.ColumnCaptionHeight = 17
        Me.CboCodigoVendedor.ColumnFooterHeight = 17
        Me.CboCodigoVendedor.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCodigoVendedor.ContentHeight = 15
        Me.CboCodigoVendedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoVendedor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoVendedor.DropDownWidth = 300
        Me.CboCodigoVendedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoVendedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoVendedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoVendedor.EditorHeight = 15
        Me.CboCodigoVendedor.Images.Add(CType(resources.GetObject("CboCodigoVendedor.Images"), System.Drawing.Image))
        Me.CboCodigoVendedor.ItemHeight = 15
        Me.CboCodigoVendedor.Location = New System.Drawing.Point(559, 159)
        Me.CboCodigoVendedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoVendedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoVendedor.MaxLength = 32767
        Me.CboCodigoVendedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoVendedor.Name = "CboCodigoVendedor"
        Me.CboCodigoVendedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoVendedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.Size = New System.Drawing.Size(121, 21)
        Me.CboCodigoVendedor.TabIndex = 193
        Me.CboCodigoVendedor.Visible = False
        Me.CboCodigoVendedor.PropBag = resources.GetString("CboCodigoVendedor.PropBag")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(507, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 192
        Me.Label12.Text = "Vendedor"
        Me.Label12.Visible = False
        '
        'CmdFacturar
        '
        Me.CmdFacturar.Enabled = False
        Me.CmdFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFacturar.Image = CType(resources.GetObject("CmdFacturar.Image"), System.Drawing.Image)
        Me.CmdFacturar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdFacturar.Location = New System.Drawing.Point(77, 86)
        Me.CmdFacturar.Name = "CmdFacturar"
        Me.CmdFacturar.Size = New System.Drawing.Size(62, 66)
        Me.CmdFacturar.TabIndex = 194
        Me.CmdFacturar.Text = "Facturar"
        Me.CmdFacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdFacturar.UseVisualStyleBackColor = True
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
        Me.CboCajero.Location = New System.Drawing.Point(360, 270)
        Me.CboCajero.MatchEntryTimeout = CType(2000, Long)
        Me.CboCajero.MaxDropDownItems = CType(5, Short)
        Me.CboCajero.MaxLength = 32767
        Me.CboCajero.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCajero.Name = "CboCajero"
        Me.CboCajero.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCajero.Size = New System.Drawing.Size(121, 21)
        Me.CboCajero.TabIndex = 196
        Me.CboCajero.Visible = False
        Me.CboCajero.PropBag = resources.GetString("CboCajero.PropBag")
        '
        'LblCajero
        '
        Me.LblCajero.AutoSize = True
        Me.LblCajero.Location = New System.Drawing.Point(317, 274)
        Me.LblCajero.Name = "LblCajero"
        Me.LblCajero.Size = New System.Drawing.Size(37, 13)
        Me.LblCajero.TabIndex = 195
        Me.LblCajero.Text = "Cajero"
        Me.LblCajero.Visible = False
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button3.Location = New System.Drawing.Point(22, 462)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(94, 23)
        Me.Button3.TabIndex = 205
        Me.Button3.Text = "Borrar Linea"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxtMonedaImprime
        '
        Me.TxtMonedaImprime.FormattingEnabled = True
        Me.TxtMonedaImprime.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.TxtMonedaImprime.Location = New System.Drawing.Point(22, 267)
        Me.TxtMonedaImprime.Name = "TxtMonedaImprime"
        Me.TxtMonedaImprime.Size = New System.Drawing.Size(78, 21)
        Me.TxtMonedaImprime.TabIndex = 206
        '
        'C1Button1
        '
        Me.C1Button1.Image = CType(resources.GetObject("C1Button1.Image"), System.Drawing.Image)
        Me.C1Button1.Location = New System.Drawing.Point(106, 267)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(39, 24)
        Me.C1Button1.TabIndex = 207
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'CmdProcesar
        '
        Me.CmdProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdProcesar.Image = CType(resources.GetObject("CmdProcesar.Image"), System.Drawing.Image)
        Me.CmdProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdProcesar.Location = New System.Drawing.Point(76, 158)
        Me.CmdProcesar.Name = "CmdProcesar"
        Me.CmdProcesar.Size = New System.Drawing.Size(65, 66)
        Me.CmdProcesar.TabIndex = 208
        Me.CmdProcesar.Tag = "28"
        Me.CmdProcesar.Text = "Procesar"
        Me.CmdProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdProcesar.UseVisualStyleBackColor = True
        '
        'ChkPorcientoTarjeta
        '
        Me.ChkPorcientoTarjeta.AutoSize = True
        Me.ChkPorcientoTarjeta.Location = New System.Drawing.Point(244, 272)
        Me.ChkPorcientoTarjeta.Name = "ChkPorcientoTarjeta"
        Me.ChkPorcientoTarjeta.Size = New System.Drawing.Size(70, 17)
        Me.ChkPorcientoTarjeta.TabIndex = 209
        Me.ChkPorcientoTarjeta.Text = "% Tarjeta"
        Me.ChkPorcientoTarjeta.UseVisualStyleBackColor = True
        '
        'C1Button2
        '
        Me.C1Button2.Image = CType(resources.GetObject("C1Button2.Image"), System.Drawing.Image)
        Me.C1Button2.Location = New System.Drawing.Point(147, 267)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(39, 24)
        Me.C1Button2.TabIndex = 210
        Me.C1Button2.UseVisualStyleBackColor = True
        Me.C1Button2.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'C1Button3
        '
        Me.C1Button3.Image = CType(resources.GetObject("C1Button3.Image"), System.Drawing.Image)
        Me.C1Button3.Location = New System.Drawing.Point(188, 267)
        Me.C1Button3.Name = "C1Button3"
        Me.C1Button3.Size = New System.Drawing.Size(39, 24)
        Me.C1Button3.TabIndex = 211
        Me.C1Button3.UseVisualStyleBackColor = True
        Me.C1Button3.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'C1Button4
        '
        Me.C1Button4.Image = CType(resources.GetObject("C1Button4.Image"), System.Drawing.Image)
        Me.C1Button4.Location = New System.Drawing.Point(686, 184)
        Me.C1Button4.Name = "C1Button4"
        Me.C1Button4.Size = New System.Drawing.Size(39, 24)
        Me.C1Button4.TabIndex = 219
        Me.C1Button4.UseVisualStyleBackColor = True
        Me.C1Button4.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'CboProyecto
        '
        Me.CboProyecto.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboProyecto.Caption = ""
        Me.CboProyecto.CaptionHeight = 17
        Me.CboProyecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboProyecto.ColumnCaptionHeight = 17
        Me.CboProyecto.ColumnFooterHeight = 17
        Me.CboProyecto.ContentHeight = 15
        Me.CboProyecto.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboProyecto.DisplayMember = "NombreProyectos"
        Me.CboProyecto.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboProyecto.DropDownWidth = 300
        Me.CboProyecto.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboProyecto.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboProyecto.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboProyecto.EditorHeight = 15
        Me.CboProyecto.Images.Add(CType(resources.GetObject("CboProyecto.Images"), System.Drawing.Image))
        Me.CboProyecto.ItemHeight = 15
        Me.CboProyecto.Location = New System.Drawing.Point(543, 185)
        Me.CboProyecto.MatchEntryTimeout = CType(2000, Long)
        Me.CboProyecto.MaxDropDownItems = CType(5, Short)
        Me.CboProyecto.MaxLength = 32767
        Me.CboProyecto.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboProyecto.Name = "CboProyecto"
        Me.CboProyecto.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboProyecto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboProyecto.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboProyecto.Size = New System.Drawing.Size(137, 21)
        Me.CboProyecto.TabIndex = 218
        Me.CboProyecto.PropBag = resources.GetString("CboProyecto.PropBag")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(493, 187)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 217
        Me.Label15.Text = "Proyecto"
        '
        'C1Button5
        '
        Me.C1Button5.Image = CType(resources.GetObject("C1Button5.Image"), System.Drawing.Image)
        Me.C1Button5.Location = New System.Drawing.Point(686, 129)
        Me.C1Button5.Name = "C1Button5"
        Me.C1Button5.Size = New System.Drawing.Size(39, 24)
        Me.C1Button5.TabIndex = 220
        Me.C1Button5.UseVisualStyleBackColor = True
        Me.C1Button5.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'TxtRetencion2Porciento
        '
        Me.TxtRetencion2Porciento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRetencion2Porciento.Location = New System.Drawing.Point(147, 624)
        Me.TxtRetencion2Porciento.Name = "TxtRetencion2Porciento"
        Me.TxtRetencion2Porciento.ReadOnly = True
        Me.TxtRetencion2Porciento.Size = New System.Drawing.Size(73, 20)
        Me.TxtRetencion2Porciento.TabIndex = 222
        Me.TxtRetencion2Porciento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtRetencion2Porciento.Visible = False
        '
        'TxtRetencion1Porciento
        '
        Me.TxtRetencion1Porciento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRetencion1Porciento.ForeColor = System.Drawing.Color.Black
        Me.TxtRetencion1Porciento.Location = New System.Drawing.Point(22, 625)
        Me.TxtRetencion1Porciento.Name = "TxtRetencion1Porciento"
        Me.TxtRetencion1Porciento.ReadOnly = True
        Me.TxtRetencion1Porciento.Size = New System.Drawing.Size(67, 20)
        Me.TxtRetencion1Porciento.TabIndex = 221
        Me.TxtRetencion1Porciento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtRetencion1Porciento.Visible = False
        '
        'LblPropina
        '
        Me.LblPropina.AutoSize = True
        Me.LblPropina.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblPropina.Location = New System.Drawing.Point(1093, 395)
        Me.LblPropina.Name = "LblPropina"
        Me.LblPropina.Size = New System.Drawing.Size(43, 13)
        Me.LblPropina.TabIndex = 223
        Me.LblPropina.Text = "Propina"
        '
        'TxtPropina
        '
        Me.TxtPropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPropina.Location = New System.Drawing.Point(1142, 392)
        Me.TxtPropina.Name = "TxtPropina"
        Me.TxtPropina.ReadOnly = True
        Me.TxtPropina.Size = New System.Drawing.Size(49, 20)
        Me.TxtPropina.TabIndex = 224
        Me.TxtPropina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DTPFechaHora
        '
        Me.DTPFechaHora.CustomFormat = ""
        Me.DTPFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaHora.Location = New System.Drawing.Point(1184, 148)
        Me.DTPFechaHora.Name = "DTPFechaHora"
        Me.DTPFechaHora.Size = New System.Drawing.Size(101, 20)
        Me.DTPFechaHora.TabIndex = 225
        Me.DTPFechaHora.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BtnSalida)
        Me.GroupBox5.Controls.Add(Me.Button5)
        Me.GroupBox5.Controls.Add(Me.CmdNuevo)
        Me.GroupBox5.Controls.Add(Me.ButtonAgregar)
        Me.GroupBox5.Controls.Add(Me.ButtonBorrar)
        Me.GroupBox5.Controls.Add(Me.CmdFacturar)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.CmdProcesar)
        Me.GroupBox5.Controls.Add(Me.Button8)
        Me.GroupBox5.Location = New System.Drawing.Point(726, 60)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(152, 308)
        Me.GroupBox5.TabIndex = 226
        Me.GroupBox5.TabStop = False
        '
        'BtnSalida
        '
        Me.BtnSalida.Enabled = False
        Me.BtnSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalida.Image = CType(resources.GetObject("BtnSalida.Image"), System.Drawing.Image)
        Me.BtnSalida.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalida.Location = New System.Drawing.Point(76, 87)
        Me.BtnSalida.Name = "BtnSalida"
        Me.BtnSalida.Size = New System.Drawing.Size(62, 66)
        Me.BtnSalida.TabIndex = 210
        Me.BtnSalida.Text = "Salida"
        Me.BtnSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalida.UseVisualStyleBackColor = True
        Me.BtnSalida.Visible = False
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(77, 236)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(62, 66)
        Me.Button5.TabIndex = 209
        Me.Button5.Tag = "27"
        Me.Button5.Text = "Previo"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(343, 112)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(126, 96)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 227
        Me.PictureBox3.TabStop = False
        '
        'FrmFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 499)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.DTPFechaHora)
        Me.Controls.Add(Me.TxtPropina)
        Me.Controls.Add(Me.TxtRetencion2Porciento)
        Me.Controls.Add(Me.LblPropina)
        Me.Controls.Add(Me.TxtRetencion1Porciento)
        Me.Controls.Add(Me.C1Button5)
        Me.Controls.Add(Me.C1Button4)
        Me.Controls.Add(Me.CmdCuentasxCobrar)
        Me.Controls.Add(Me.CboProyecto)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.C1Button3)
        Me.Controls.Add(Me.C1Button2)
        Me.Controls.Add(Me.ChkPorcientoTarjeta)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.C1Button1)
        Me.Controls.Add(Me.TxtMonedaImprime)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CboCajero)
        Me.Controls.Add(Me.LblCajero)
        Me.Controls.Add(Me.CboCodigoVendedor)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CboCodigoBodega2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtPagado)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TrueDBGridMetodo)
        Me.Controls.Add(Me.DTVencimiento)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TxtNetoPagar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtIva)
        Me.Controls.Add(Me.LblIVA)
        Me.Controls.Add(Me.TxtSubTotal)
        Me.Controls.Add(Me.LblSubTotal)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propina"
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.CboCodigoBodega2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPagado As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DTVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNetoPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtIva As System.Windows.Forms.TextBox
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblSubTotal As System.Windows.Forms.Label
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdCuentasxCobrar As System.Windows.Forms.Button
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoClientes As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CboCodigoBodega2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BindingMetodo As System.Windows.Forms.BindingSource
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents CboCodigoVendedor As C1.Win.C1List.C1Combo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmdFacturar As System.Windows.Forms.Button
    Friend WithEvents CboCajero As C1.Win.C1List.C1Combo
    Friend WithEvents LblCajero As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents OptExsonerado As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TxtMonedaFactura As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMonedaImprime As System.Windows.Forms.ComboBox
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdProcesar As System.Windows.Forms.Button
    Friend WithEvents ChkPorcientoTarjeta As System.Windows.Forms.CheckBox
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents C1Button3 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button4 As C1.Win.C1Input.C1Button
    Friend WithEvents CboProyecto As C1.Win.C1List.C1Combo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents C1Button5 As C1.Win.C1Input.C1Button
    Friend WithEvents OptRet1Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents OptRet2Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents TxtRetencion2Porciento As System.Windows.Forms.TextBox
    Friend WithEvents TxtRetencion1Porciento As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CboReferencia As System.Windows.Forms.ComboBox
    Friend WithEvents LblPropina As System.Windows.Forms.Label
    Friend WithEvents TxtPropina As System.Windows.Forms.TextBox
    Friend WithEvents ChkPropina As System.Windows.Forms.CheckBox
    Friend WithEvents DTPFechaHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents BtnSalida As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroFactura As System.Windows.Forms.TextBox
    Friend WithEvents BtnFacturas As C1.Win.C1Input.C1Button
    Friend WithEvents ChkAplicarCtaXCobrar As System.Windows.Forms.CheckBox
End Class
