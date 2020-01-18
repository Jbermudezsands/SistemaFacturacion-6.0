<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevoLote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNuevoLote))
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.LblApellido = New System.Windows.Forms.Label
        Me.CboCodigoVendedor = New C1.Win.C1List.C1Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.ChkActivo = New System.Windows.Forms.CheckBox
        Me.ChkEfectivo = New System.Windows.Forms.CheckBox
        Me.CboMunicipio = New C1.Win.C1List.C1Combo
        Me.Label9 = New System.Windows.Forms.Label
        Me.CboDepartamento = New C1.Win.C1List.C1Combo
        Me.Label8 = New System.Windows.Forms.Label
        Me.CboEndoso = New C1.Win.C1List.C1Combo
        Me.Label3 = New System.Windows.Forms.Label
        Me.ChkInventario = New System.Windows.Forms.CheckBox
        Me.CmbTurno = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtGrado = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtAño = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CboCodigoCliente = New C1.Win.C1List.C1Combo
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtCtaxCobrar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.LblDireccion = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.LblCodigo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNumeroLote = New System.Windows.Forms.TextBox
        Me.TxtNombreLote = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEndoso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(102, 20)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(136, 13)
        Me.LblTitulo.TabIndex = 113
        Me.LblTitulo.Text = "REGISTRO DE LOTES"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(-3, -4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 112
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-3, -4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(515, 60)
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(122, 78)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(275, 20)
        Me.TxtApellidos.TabIndex = 122
        '
        'LblApellido
        '
        Me.LblApellido.AutoSize = True
        Me.LblApellido.Location = New System.Drawing.Point(22, 78)
        Me.LblApellido.Name = "LblApellido"
        Me.LblApellido.Size = New System.Drawing.Size(84, 13)
        Me.LblApellido.TabIndex = 133
        Me.LblApellido.Text = "Apellido Clientes"
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
        Me.CboCodigoVendedor.Location = New System.Drawing.Point(122, 252)
        Me.CboCodigoVendedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoVendedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoVendedor.MaxLength = 32767
        Me.CboCodigoVendedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoVendedor.Name = "CboCodigoVendedor"
        Me.CboCodigoVendedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoVendedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.Size = New System.Drawing.Size(151, 21)
        Me.CboCodigoVendedor.TabIndex = 194
        Me.CboCodigoVendedor.PropBag = resources.GetString("CboCodigoVendedor.PropBag")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(53, 252)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 149
        Me.Label18.Text = "Vendedor"
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(392, 24)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 147
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'ChkEfectivo
        '
        Me.ChkEfectivo.AutoSize = True
        Me.ChkEfectivo.Location = New System.Drawing.Point(122, 326)
        Me.ChkEfectivo.Name = "ChkEfectivo"
        Me.ChkEfectivo.Size = New System.Drawing.Size(101, 17)
        Me.ChkEfectivo.TabIndex = 146
        Me.ChkEfectivo.Text = "Cliente Contado"
        Me.ChkEfectivo.UseVisualStyleBackColor = True
        '
        'CboMunicipio
        '
        Me.CboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboMunicipio.Caption = ""
        Me.CboMunicipio.CaptionHeight = 17
        Me.CboMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboMunicipio.ColumnCaptionHeight = 17
        Me.CboMunicipio.ColumnFooterHeight = 17
        Me.CboMunicipio.ContentHeight = 15
        Me.CboMunicipio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboMunicipio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboMunicipio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMunicipio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboMunicipio.EditorHeight = 15
        Me.CboMunicipio.Images.Add(CType(resources.GetObject("CboMunicipio.Images"), System.Drawing.Image))
        Me.CboMunicipio.ItemHeight = 15
        Me.CboMunicipio.Location = New System.Drawing.Point(124, 173)
        Me.CboMunicipio.MatchEntryTimeout = CType(2000, Long)
        Me.CboMunicipio.MaxDropDownItems = CType(5, Short)
        Me.CboMunicipio.MaxLength = 32767
        Me.CboMunicipio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboMunicipio.Name = "CboMunicipio"
        Me.CboMunicipio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboMunicipio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboMunicipio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboMunicipio.Size = New System.Drawing.Size(150, 21)
        Me.CboMunicipio.TabIndex = 145
        Me.CboMunicipio.PropBag = resources.GetString("CboMunicipio.PropBag")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(54, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 144
        Me.Label9.Text = "Municipio"
        '
        'CboDepartamento
        '
        Me.CboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDepartamento.Caption = ""
        Me.CboDepartamento.CaptionHeight = 17
        Me.CboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDepartamento.ColumnCaptionHeight = 17
        Me.CboDepartamento.ColumnFooterHeight = 17
        Me.CboDepartamento.ContentHeight = 15
        Me.CboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDepartamento.EditorHeight = 15
        Me.CboDepartamento.Images.Add(CType(resources.GetObject("CboDepartamento.Images"), System.Drawing.Image))
        Me.CboDepartamento.ItemHeight = 15
        Me.CboDepartamento.Location = New System.Drawing.Point(124, 148)
        Me.CboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.CboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.CboDepartamento.MaxLength = 32767
        Me.CboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDepartamento.Size = New System.Drawing.Size(150, 21)
        Me.CboDepartamento.TabIndex = 143
        Me.CboDepartamento.PropBag = resources.GetString("CboDepartamento.PropBag")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 142
        Me.Label8.Text = "Departamento"
        '
        'CboEndoso
        '
        Me.CboEndoso.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEndoso.Caption = ""
        Me.CboEndoso.CaptionHeight = 17
        Me.CboEndoso.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEndoso.ColumnCaptionHeight = 17
        Me.CboEndoso.ColumnFooterHeight = 17
        Me.CboEndoso.ContentHeight = 15
        Me.CboEndoso.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEndoso.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEndoso.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEndoso.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEndoso.EditorHeight = 15
        Me.CboEndoso.Images.Add(CType(resources.GetObject("CboEndoso.Images"), System.Drawing.Image))
        Me.CboEndoso.ItemHeight = 15
        Me.CboEndoso.Location = New System.Drawing.Point(123, 225)
        Me.CboEndoso.MatchEntryTimeout = CType(2000, Long)
        Me.CboEndoso.MaxDropDownItems = CType(5, Short)
        Me.CboEndoso.MaxLength = 32767
        Me.CboEndoso.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEndoso.Name = "CboEndoso"
        Me.CboEndoso.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEndoso.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEndoso.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEndoso.Size = New System.Drawing.Size(150, 21)
        Me.CboEndoso.TabIndex = 139
        Me.CboEndoso.PropBag = resources.GetString("CboEndoso.PropBag")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Compañia Endoso"
        '
        'ChkInventario
        '
        Me.ChkInventario.AutoSize = True
        Me.ChkInventario.Location = New System.Drawing.Point(123, 305)
        Me.ChkInventario.Name = "ChkInventario"
        Me.ChkInventario.Size = New System.Drawing.Size(172, 17)
        Me.ChkInventario.TabIndex = 138
        Me.ChkInventario.Text = "Cuenta Ajuste Inventario Fisico"
        Me.ChkInventario.UseVisualStyleBackColor = True
        '
        'CmbTurno
        '
        Me.CmbTurno.FormattingEnabled = True
        Me.CmbTurno.Items.AddRange(New Object() {"Matutino", "Vespertino"})
        Me.CmbTurno.Location = New System.Drawing.Point(510, 54)
        Me.CmbTurno.Name = "CmbTurno"
        Me.CmbTurno.Size = New System.Drawing.Size(111, 21)
        Me.CmbTurno.TabIndex = 137
        Me.CmbTurno.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(507, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 136
        Me.Label15.Text = "Turno"
        '
        'TxtGrado
        '
        Me.TxtGrado.Location = New System.Drawing.Point(491, 174)
        Me.TxtGrado.Name = "TxtGrado"
        Me.TxtGrado.Size = New System.Drawing.Size(108, 20)
        Me.TxtGrado.TabIndex = 132
        Me.TxtGrado.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(516, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 133
        Me.Label14.Text = "Grado"
        Me.Label14.Visible = False
        '
        'TxtAño
        '
        Me.TxtAño.Location = New System.Drawing.Point(503, 101)
        Me.TxtAño.Name = "TxtAño"
        Me.TxtAño.Size = New System.Drawing.Size(108, 20)
        Me.TxtAño.TabIndex = 134
        Me.TxtAño.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(516, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 135
        Me.Label13.Text = "Año"
        Me.Label13.Visible = False
        '
        'CboCodigoCliente
        '
        Me.CboCodigoCliente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoCliente.Caption = ""
        Me.CboCodigoCliente.CaptionHeight = 17
        Me.CboCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoCliente.ColumnCaptionHeight = 17
        Me.CboCodigoCliente.ColumnFooterHeight = 17
        Me.CboCodigoCliente.ContentHeight = 15
        Me.CboCodigoCliente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoCliente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoCliente.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoCliente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoCliente.EditorHeight = 15
        Me.CboCodigoCliente.Images.Add(CType(resources.GetObject("CboCodigoCliente.Images"), System.Drawing.Image))
        Me.CboCodigoCliente.ItemHeight = 15
        Me.CboCodigoCliente.Location = New System.Drawing.Point(122, 25)
        Me.CboCodigoCliente.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoCliente.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoCliente.MaxLength = 32767
        Me.CboCodigoCliente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoCliente.Name = "CboCodigoCliente"
        Me.CboCodigoCliente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoCliente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoCliente.TabIndex = 120
        Me.CboCodigoCliente.PropBag = resources.GetString("CboCodigoCliente.PropBag")
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(279, 263)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 38)
        Me.Button1.TabIndex = 127
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCtaxCobrar
        '
        Me.TxtCtaxCobrar.Location = New System.Drawing.Point(125, 281)
        Me.TxtCtaxCobrar.Name = "TxtCtaxCobrar"
        Me.TxtCtaxCobrar.Size = New System.Drawing.Size(148, 20)
        Me.TxtCtaxCobrar.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "Cuenta  x Cobrar"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(123, 199)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(148, 20)
        Me.TxtTelefono.TabIndex = 124
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Telefono"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(123, 101)
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(274, 44)
        Me.TxtDireccion.TabIndex = 123
        '
        'LblDireccion
        '
        Me.LblDireccion.AutoSize = True
        Me.LblDireccion.Location = New System.Drawing.Point(17, 101)
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Size = New System.Drawing.Size(92, 13)
        Me.LblDireccion.TabIndex = 130
        Me.LblDireccion.Text = "Direccion Clientes"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(122, 54)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(275, 20)
        Me.TxtNombre.TabIndex = 121
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Location = New System.Drawing.Point(22, 54)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(84, 13)
        Me.LblNombre.TabIndex = 129
        Me.LblNombre.Text = "Nombre Clientes"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(340, 8)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 38)
        Me.Button6.TabIndex = 126
        Me.Button6.UseVisualStyleBackColor = True
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(26, 25)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(80, 13)
        Me.LblCodigo.TabIndex = 128
        Me.LblCodigo.Text = "Codigo Clientes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Numero Lote"
        '
        'TxtNumeroLote
        '
        Me.TxtNumeroLote.AcceptsReturn = True
        Me.TxtNumeroLote.Location = New System.Drawing.Point(85, 79)
        Me.TxtNumeroLote.Name = "TxtNumeroLote"
        Me.TxtNumeroLote.Size = New System.Drawing.Size(213, 20)
        Me.TxtNumeroLote.TabIndex = 132
        '
        'TxtNombreLote
        '
        Me.TxtNombreLote.Location = New System.Drawing.Point(85, 105)
        Me.TxtNombreLote.Name = "TxtNombreLote"
        Me.TxtNombreLote.Size = New System.Drawing.Size(213, 20)
        Me.TxtNombreLote.TabIndex = 134
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Nombre Lote"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Fecha Vence"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(85, 131)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 136
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(-258, 161)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 34)
        Me.Button2.TabIndex = 206
        Me.Button2.Text = "Grabar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(229, 172)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 205
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(8, 169)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 34)
        Me.Button3.TabIndex = 207
        Me.Button3.Text = "Grabar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmNuevoLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 217)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.DTPFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtNombreLote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNumeroLote)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNuevoLote"
        Me.Text = "FrmNuevoLote"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEndoso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents LblApellido As System.Windows.Forms.Label
    Friend WithEvents CboCodigoVendedor As C1.Win.C1List.C1Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEfectivo As System.Windows.Forms.CheckBox
    Friend WithEvents CboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CboEndoso As C1.Win.C1List.C1Combo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkInventario As System.Windows.Forms.CheckBox
    Friend WithEvents CmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtGrado As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtAño As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoCliente As C1.Win.C1List.C1Combo
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCtaxCobrar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents LblDireccion As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroLote As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombreLote As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
