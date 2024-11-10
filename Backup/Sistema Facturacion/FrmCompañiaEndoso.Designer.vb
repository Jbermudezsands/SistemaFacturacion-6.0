<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompañiaEndoso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompañiaEndoso))
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
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.LblApellido = New System.Windows.Forms.Label
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
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.C1Combo1 = New C1.Win.C1List.C1Combo
        Me.TxtRUC = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtLimite = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TxtAdress = New System.Windows.Forms.TextBox
        Me.TxtPhone = New System.Windows.Forms.TextBox
        Me.TxtCorreo = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.C1Combo5 = New C1.Win.C1List.C1Combo
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.C1Combo6 = New C1.Win.C1List.C1Combo
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.TextBox13 = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.TextBox9 = New System.Windows.Forms.TextBox
        CType(Me.CboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEndoso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.C1Combo5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Combo6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Label9.Location = New System.Drawing.Point(17, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 144
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
        Me.Label8.Location = New System.Drawing.Point(17, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 142
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
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 140
        '
        'ChkInventario
        '
        Me.ChkInventario.AutoSize = True
        Me.ChkInventario.Location = New System.Drawing.Point(123, 286)
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
        Me.Label15.Size = New System.Drawing.Size(0, 13)
        Me.Label15.TabIndex = 136
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
        Me.Label14.Size = New System.Drawing.Size(0, 13)
        Me.Label14.TabIndex = 133
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
        Me.Label13.Size = New System.Drawing.Size(0, 13)
        Me.Label13.TabIndex = 135
        Me.Label13.Visible = False
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
        Me.LblApellido.Location = New System.Drawing.Point(16, 78)
        Me.LblApellido.Name = "LblApellido"
        Me.LblApellido.Size = New System.Drawing.Size(0, 13)
        Me.LblApellido.TabIndex = 133
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
        Me.Button1.Location = New System.Drawing.Point(279, 242)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 38)
        Me.Button1.TabIndex = 127
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCtaxCobrar
        '
        Me.TxtCtaxCobrar.Location = New System.Drawing.Point(125, 260)
        Me.TxtCtaxCobrar.Name = "TxtCtaxCobrar"
        Me.TxtCtaxCobrar.Size = New System.Drawing.Size(148, 20)
        Me.TxtCtaxCobrar.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 260)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 132
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
        Me.Label4.Location = New System.Drawing.Point(18, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 131
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
        Me.LblDireccion.Size = New System.Drawing.Size(0, 13)
        Me.LblDireccion.TabIndex = 130
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
        Me.LblNombre.Location = New System.Drawing.Point(16, 54)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(0, 13)
        Me.LblNombre.TabIndex = 129
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
        Me.LblCodigo.Location = New System.Drawing.Point(16, 25)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(0, 13)
        Me.LblCodigo.TabIndex = 128
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(467, 324)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Referencia Credito"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.C1Combo1)
        Me.GroupBox1.Controls.Add(Me.TxtRUC)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtLimite)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(401, 195)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'C1Combo1
        '
        Me.C1Combo1.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo1.Caption = ""
        Me.C1Combo1.CaptionHeight = 17
        Me.C1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo1.ColumnCaptionHeight = 17
        Me.C1Combo1.ColumnFooterHeight = 17
        Me.C1Combo1.ContentHeight = 15
        Me.C1Combo1.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo1.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo1.EditorHeight = 15
        Me.C1Combo1.Images.Add(CType(resources.GetObject("C1Combo1.Images"), System.Drawing.Image))
        Me.C1Combo1.ItemHeight = 15
        Me.C1Combo1.Location = New System.Drawing.Point(281, 45)
        Me.C1Combo1.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo1.MaxDropDownItems = CType(5, Short)
        Me.C1Combo1.MaxLength = 32767
        Me.C1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo1.Name = "C1Combo1"
        Me.C1Combo1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo1.Size = New System.Drawing.Size(105, 21)
        Me.C1Combo1.TabIndex = 121
        Me.C1Combo1.Visible = False
        Me.C1Combo1.PropBag = resources.GetString("C1Combo1.PropBag")
        '
        'TxtRUC
        '
        Me.TxtRUC.Location = New System.Drawing.Point(279, 76)
        Me.TxtRUC.Name = "TxtRUC"
        Me.TxtRUC.Size = New System.Drawing.Size(107, 20)
        Me.TxtRUC.TabIndex = 103
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(225, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 13)
        Me.Label11.TabIndex = 102
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(225, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 13)
        Me.Label12.TabIndex = 101
        Me.Label12.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(112, 102)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(107, 20)
        Me.TextBox3.TabIndex = 100
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 99
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(112, 76)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(107, 20)
        Me.TextBox2.TabIndex = 98
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 97
        '
        'TxtLimite
        '
        Me.TxtLimite.AcceptsReturn = True
        Me.TxtLimite.Location = New System.Drawing.Point(112, 50)
        Me.TxtLimite.Name = "TxtLimite"
        Me.TxtLimite.Size = New System.Drawing.Size(107, 20)
        Me.TxtLimite.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CboMunicipio)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.CboDepartamento)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.CboEndoso)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.ChkInventario)
        Me.TabPage1.Controls.Add(Me.CmbTurno)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.TxtGrado)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.TxtAño)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.TxtApellidos)
        Me.TabPage1.Controls.Add(Me.LblApellido)
        Me.TabPage1.Controls.Add(Me.CboCodigoCliente)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.TxtCtaxCobrar)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.TxtTelefono)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TxtDireccion)
        Me.TabPage1.Controls.Add(Me.LblDireccion)
        Me.TabPage1.Controls.Add(Me.TxtNombre)
        Me.TabPage1.Controls.Add(Me.LblNombre)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.LblCodigo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(467, 324)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro del Cliente"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 65)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(475, 203)
        Me.TabControl1.TabIndex = 121
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TxtAdress)
        Me.TabPage2.Controls.Add(Me.TxtPhone)
        Me.TabPage2.Controls.Add(Me.TxtCorreo)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.C1Combo5)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(467, 177)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Datos Endoso"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TxtAdress
        '
        Me.TxtAdress.Location = New System.Drawing.Point(123, 106)
        Me.TxtAdress.Multiline = True
        Me.TxtAdress.Name = "TxtAdress"
        Me.TxtAdress.Size = New System.Drawing.Size(274, 44)
        Me.TxtAdress.TabIndex = 135
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(122, 52)
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(209, 20)
        Me.TxtPhone.TabIndex = 134
        '
        'TxtCorreo
        '
        Me.TxtCorreo.AcceptsReturn = True
        Me.TxtCorreo.Location = New System.Drawing.Point(122, 78)
        Me.TxtCorreo.Name = "TxtCorreo"
        Me.TxtCorreo.Size = New System.Drawing.Size(275, 20)
        Me.TxtCorreo.TabIndex = 122
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 78)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 13)
        Me.Label20.TabIndex = 133
        Me.Label20.Text = "Correo"
        '
        'C1Combo5
        '
        Me.C1Combo5.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo5.Caption = ""
        Me.C1Combo5.CaptionHeight = 17
        Me.C1Combo5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo5.ColumnCaptionHeight = 17
        Me.C1Combo5.ColumnFooterHeight = 17
        Me.C1Combo5.ContentHeight = 15
        Me.C1Combo5.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo5.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo5.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo5.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo5.EditorHeight = 15
        Me.C1Combo5.Images.Add(CType(resources.GetObject("C1Combo5.Images"), System.Drawing.Image))
        Me.C1Combo5.ItemHeight = 15
        Me.C1Combo5.Location = New System.Drawing.Point(122, 25)
        Me.C1Combo5.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo5.MaxDropDownItems = CType(5, Short)
        Me.C1Combo5.MaxLength = 32767
        Me.C1Combo5.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo5.Name = "C1Combo5"
        Me.C1Combo5.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo5.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo5.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo5.Size = New System.Drawing.Size(209, 21)
        Me.C1Combo5.TabIndex = 120
        Me.C1Combo5.PropBag = resources.GetString("C1Combo5.PropBag")
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(17, 101)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 13)
        Me.Label23.TabIndex = 130
        Me.Label23.Text = "Direccion "
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(16, 54)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 13)
        Me.Label24.TabIndex = 129
        Me.Label24.Text = "Telefono"
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(340, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 38)
        Me.Button3.TabIndex = 126
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 25)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 13)
        Me.Label25.TabIndex = 128
        Me.Label25.Text = "Nombre"
        '
        'C1Combo6
        '
        Me.C1Combo6.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo6.Caption = ""
        Me.C1Combo6.CaptionHeight = 17
        Me.C1Combo6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo6.ColumnCaptionHeight = 17
        Me.C1Combo6.ColumnFooterHeight = 17
        Me.C1Combo6.ContentHeight = 15
        Me.C1Combo6.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo6.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo6.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo6.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo6.EditorHeight = 15
        Me.C1Combo6.Images.Add(CType(resources.GetObject("C1Combo6.Images"), System.Drawing.Image))
        Me.C1Combo6.ItemHeight = 15
        Me.C1Combo6.Location = New System.Drawing.Point(281, 45)
        Me.C1Combo6.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo6.MaxDropDownItems = CType(5, Short)
        Me.C1Combo6.MaxLength = 32767
        Me.C1Combo6.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo6.Name = "C1Combo6"
        Me.C1Combo6.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo6.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo6.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo6.Size = New System.Drawing.Size(105, 21)
        Me.C1Combo6.TabIndex = 121
        Me.C1Combo6.Visible = False
        Me.C1Combo6.PropBag = resources.GetString("C1Combo6.PropBag")
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(279, 76)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(107, 20)
        Me.TextBox10.TabIndex = 103
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(225, 79)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(36, 13)
        Me.Label28.TabIndex = 102
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(225, 53)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(50, 13)
        Me.Label29.TabIndex = 101
        Me.Label29.Visible = False
        '
        'TextBox11
        '
        Me.TextBox11.Enabled = False
        Me.TextBox11.Location = New System.Drawing.Point(112, 102)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(107, 20)
        Me.TextBox11.TabIndex = 100
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(10, 105)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(92, 13)
        Me.Label30.TabIndex = 99
        '
        'TextBox12
        '
        Me.TextBox12.Enabled = False
        Me.TextBox12.Location = New System.Drawing.Point(112, 76)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(107, 20)
        Me.TextBox12.TabIndex = 98
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(10, 79)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(96, 13)
        Me.Label31.TabIndex = 97
        '
        'TextBox13
        '
        Me.TextBox13.AcceptsReturn = True
        Me.TextBox13.Location = New System.Drawing.Point(112, 50)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(107, 20)
        Me.TextBox13.TabIndex = 96
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(10, 53)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(85, 13)
        Me.Label32.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(515, 60)
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(168, 25)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(127, 13)
        Me.LblTitulo.TabIndex = 124
        Me.LblTitulo.Text = "COMPAÑIA ENDOSO"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 123
        Me.PictureBox2.TabStop = False
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(87, 285)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 126
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(171, 285)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 127
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 285)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 125
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(408, 287)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 128
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(122, 54)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(275, 20)
        Me.TextBox9.TabIndex = 121
        '
        'FrmCompañiaEndoso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 366)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmCompañiaEndoso"
        Me.Text = "FrmCompañiaEndoso"
        CType(Me.CboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEndoso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.C1Combo5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Combo6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents LblApellido As System.Windows.Forms.Label
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
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents C1Combo1 As C1.Win.C1List.C1Combo
    Friend WithEvents TxtRUC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtLimite As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TxtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents C1Combo5 As C1.Win.C1List.C1Combo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents C1Combo6 As C1.Win.C1List.C1Combo
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
    Friend WithEvents TxtAdress As System.Windows.Forms.TextBox
End Class
