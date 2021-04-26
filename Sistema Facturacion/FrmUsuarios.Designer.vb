<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUsuarios))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblContraseña = New System.Windows.Forms.Label
        Me.TxtContraseña = New System.Windows.Forms.TextBox
        Me.CboUsuario = New C1.Win.C1List.C1Combo
        Me.Button2 = New System.Windows.Forms.Button
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.TxtConfirmar = New System.Windows.Forms.TextBox
        Me.LblConfirmar = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.Label11 = New System.Windows.Forms.Label
        Me.LblTipoFactura = New System.Windows.Forms.Label
        Me.CboTipoProducto = New System.Windows.Forms.ComboBox
        Me.CboCodigoVendedor = New C1.Win.C1List.C1Combo
        Me.LblVendedor = New System.Windows.Forms.Label
        Me.CboCodigoCliente = New C1.Win.C1List.C1Combo
        Me.LblCodigo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbSerie = New C1.Win.C1List.C1Combo
        Me.CboNivel = New C1.Win.C1List.C1Combo
        Me.Label4 = New System.Windows.Forms.Label
        Me.CboProveedor = New C1.Win.C1List.C1Combo
        Me.Label6 = New System.Windows.Forms.Label
        Me.CboTipoCompra = New System.Windows.Forms.ComboBox
        Me.CboCodigoBodegaCompra = New C1.Win.C1List.C1Combo
        Me.Label5 = New System.Windows.Forms.Label
        Me.ChkNotificacion = New System.Windows.Forms.CheckBox
        CType(Me.CboUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboNivel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoBodegaCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nivel"
        '
        'LblContraseña
        '
        Me.LblContraseña.AutoSize = True
        Me.LblContraseña.Location = New System.Drawing.Point(34, 313)
        Me.LblContraseña.Name = "LblContraseña"
        Me.LblContraseña.Size = New System.Drawing.Size(61, 13)
        Me.LblContraseña.TabIndex = 2
        Me.LblContraseña.Text = "Contraseña"
        '
        'TxtContraseña
        '
        Me.TxtContraseña.Location = New System.Drawing.Point(101, 310)
        Me.TxtContraseña.Name = "TxtContraseña"
        Me.TxtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtContraseña.Size = New System.Drawing.Size(203, 20)
        Me.TxtContraseña.TabIndex = 4
        '
        'CboUsuario
        '
        Me.CboUsuario.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboUsuario.Caption = ""
        Me.CboUsuario.CaptionHeight = 17
        Me.CboUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboUsuario.ColumnCaptionHeight = 17
        Me.CboUsuario.ColumnFooterHeight = 17
        Me.CboUsuario.ContentHeight = 15
        Me.CboUsuario.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboUsuario.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboUsuario.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboUsuario.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboUsuario.EditorHeight = 15
        Me.CboUsuario.Images.Add(CType(resources.GetObject("CboUsuario.Images"), System.Drawing.Image))
        Me.CboUsuario.ItemHeight = 15
        Me.CboUsuario.Location = New System.Drawing.Point(101, 75)
        Me.CboUsuario.MatchEntryTimeout = CType(2000, Long)
        Me.CboUsuario.MaxDropDownItems = CType(5, Short)
        Me.CboUsuario.MaxLength = 32767
        Me.CboUsuario.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboUsuario.Name = "CboUsuario"
        Me.CboUsuario.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboUsuario.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboUsuario.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboUsuario.Size = New System.Drawing.Size(203, 21)
        Me.CboUsuario.TabIndex = 5
        Me.CboUsuario.PropBag = resources.GetString("CboUsuario.PropBag")
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(226, 355)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 68)
        Me.Button2.TabIndex = 64
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(12, 354)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 63
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'TxtConfirmar
        '
        Me.TxtConfirmar.Location = New System.Drawing.Point(102, 332)
        Me.TxtConfirmar.Name = "TxtConfirmar"
        Me.TxtConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmar.Size = New System.Drawing.Size(203, 20)
        Me.TxtConfirmar.TabIndex = 66
        Me.TxtConfirmar.Visible = False
        '
        'LblConfirmar
        '
        Me.LblConfirmar.AutoSize = True
        Me.LblConfirmar.Location = New System.Drawing.Point(44, 332)
        Me.LblConfirmar.Name = "LblConfirmar"
        Me.LblConfirmar.Size = New System.Drawing.Size(51, 13)
        Me.LblConfirmar.TabIndex = 65
        Me.LblConfirmar.Text = "Confirmar"
        Me.LblConfirmar.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(57, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 68
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(3, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(315, 60)
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(79, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 13)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "REGISTRO DE USUARIOS"
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(101, 356)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 70
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
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
        Me.CboCodigoBodega.Location = New System.Drawing.Point(102, 122)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(202, 21)
        Me.CboCodigoBodega.TabIndex = 157
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(51, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 156
        Me.Label11.Text = "Bodega"
        '
        'LblTipoFactura
        '
        Me.LblTipoFactura.AutoSize = True
        Me.LblTipoFactura.Location = New System.Drawing.Point(33, 171)
        Me.LblTipoFactura.Name = "LblTipoFactura"
        Me.LblTipoFactura.Size = New System.Drawing.Size(64, 13)
        Me.LblTipoFactura.TabIndex = 158
        Me.LblTipoFactura.Text = "TipoFactura"
        '
        'CboTipoProducto
        '
        Me.CboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoProducto.FormattingEnabled = True
        Me.CboTipoProducto.Items.AddRange(New Object() {"Cotizacion", "Factura", "Devolucion de Venta", "Orden de Trabajo", "Salida Bodega"})
        Me.CboTipoProducto.Location = New System.Drawing.Point(101, 168)
        Me.CboTipoProducto.Name = "CboTipoProducto"
        Me.CboTipoProducto.Size = New System.Drawing.Size(203, 21)
        Me.CboTipoProducto.TabIndex = 159
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
        Me.CboCodigoVendedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoVendedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoVendedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoVendedor.EditorHeight = 15
        Me.CboCodigoVendedor.Images.Add(CType(resources.GetObject("CboCodigoVendedor.Images"), System.Drawing.Image))
        Me.CboCodigoVendedor.ItemHeight = 15
        Me.CboCodigoVendedor.Location = New System.Drawing.Point(102, 192)
        Me.CboCodigoVendedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoVendedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoVendedor.MaxLength = 32767
        Me.CboCodigoVendedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoVendedor.Name = "CboCodigoVendedor"
        Me.CboCodigoVendedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoVendedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.Size = New System.Drawing.Size(202, 21)
        Me.CboCodigoVendedor.TabIndex = 195
        Me.CboCodigoVendedor.PropBag = resources.GetString("CboCodigoVendedor.PropBag")
        '
        'LblVendedor
        '
        Me.LblVendedor.AutoSize = True
        Me.LblVendedor.Location = New System.Drawing.Point(43, 192)
        Me.LblVendedor.Name = "LblVendedor"
        Me.LblVendedor.Size = New System.Drawing.Size(53, 13)
        Me.LblVendedor.TabIndex = 194
        Me.LblVendedor.Text = "Vendedor"
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
        Me.CboCodigoCliente.Location = New System.Drawing.Point(102, 216)
        Me.CboCodigoCliente.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoCliente.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoCliente.MaxLength = 32767
        Me.CboCodigoCliente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoCliente.Name = "CboCodigoCliente"
        Me.CboCodigoCliente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoCliente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.Size = New System.Drawing.Size(202, 21)
        Me.CboCodigoCliente.TabIndex = 197
        Me.CboCodigoCliente.PropBag = resources.GetString("CboCodigoCliente.PropBag")
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(16, 216)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(80, 13)
        Me.LblCodigo.TabIndex = 198
        Me.LblCodigo.Text = "Codigo Clientes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 199
        Me.Label3.Text = "Serie Factura"
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
        Me.CmbSerie.Location = New System.Drawing.Point(102, 145)
        Me.CmbSerie.MatchEntryTimeout = CType(2000, Long)
        Me.CmbSerie.MaxDropDownItems = CType(5, Short)
        Me.CmbSerie.MaxLength = 32767
        Me.CmbSerie.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbSerie.Name = "CmbSerie"
        Me.CmbSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbSerie.Size = New System.Drawing.Size(49, 21)
        Me.CmbSerie.TabIndex = 212
        Me.CmbSerie.PropBag = resources.GetString("CmbSerie.PropBag")
        '
        'CboNivel
        '
        Me.CboNivel.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboNivel.Caption = ""
        Me.CboNivel.CaptionHeight = 17
        Me.CboNivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboNivel.ColumnCaptionHeight = 17
        Me.CboNivel.ColumnFooterHeight = 17
        Me.CboNivel.ContentHeight = 15
        Me.CboNivel.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboNivel.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboNivel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboNivel.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboNivel.EditorHeight = 15
        Me.CboNivel.Images.Add(CType(resources.GetObject("CboNivel.Images"), System.Drawing.Image))
        Me.CboNivel.ItemHeight = 15
        Me.CboNivel.Location = New System.Drawing.Point(102, 98)
        Me.CboNivel.MatchEntryTimeout = CType(2000, Long)
        Me.CboNivel.MaxDropDownItems = CType(5, Short)
        Me.CboNivel.MaxLength = 32767
        Me.CboNivel.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboNivel.Name = "CboNivel"
        Me.CboNivel.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboNivel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboNivel.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboNivel.Size = New System.Drawing.Size(202, 21)
        Me.CboNivel.TabIndex = 213
        Me.CboNivel.PropBag = resources.GetString("CboNivel.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 219
        Me.Label4.Text = "Proveedor"
        '
        'CboProveedor
        '
        Me.CboProveedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboProveedor.Caption = ""
        Me.CboProveedor.CaptionHeight = 17
        Me.CboProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboProveedor.ColumnCaptionHeight = 17
        Me.CboProveedor.ColumnFooterHeight = 17
        Me.CboProveedor.ContentHeight = 15
        Me.CboProveedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboProveedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboProveedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboProveedor.EditorHeight = 15
        Me.CboProveedor.Images.Add(CType(resources.GetObject("CboProveedor.Images"), System.Drawing.Image))
        Me.CboProveedor.ItemHeight = 15
        Me.CboProveedor.Location = New System.Drawing.Point(103, 264)
        Me.CboProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboProveedor.MaxLength = 32767
        Me.CboProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboProveedor.Name = "CboProveedor"
        Me.CboProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboProveedor.Size = New System.Drawing.Size(202, 21)
        Me.CboProveedor.TabIndex = 218
        Me.CboProveedor.PropBag = resources.GetString("CboProveedor.PropBag")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "Tipo Compra"
        '
        'CboTipoCompra
        '
        Me.CboTipoCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCompra.FormattingEnabled = True
        Me.CboTipoCompra.Items.AddRange(New Object() {"Orden de Compra", "Mercancia Recibida", "Devolucion de Compra", "Cuenta", "Cuenta DB"})
        Me.CboTipoCompra.Location = New System.Drawing.Point(102, 240)
        Me.CboTipoCompra.Name = "CboTipoCompra"
        Me.CboTipoCompra.Size = New System.Drawing.Size(202, 21)
        Me.CboTipoCompra.TabIndex = 220
        '
        'CboCodigoBodegaCompra
        '
        Me.CboCodigoBodegaCompra.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodegaCompra.Caption = ""
        Me.CboCodigoBodegaCompra.CaptionHeight = 17
        Me.CboCodigoBodegaCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodegaCompra.ColumnCaptionHeight = 17
        Me.CboCodigoBodegaCompra.ColumnFooterHeight = 17
        Me.CboCodigoBodegaCompra.ContentHeight = 15
        Me.CboCodigoBodegaCompra.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodegaCompra.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodegaCompra.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodegaCompra.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodegaCompra.EditorHeight = 15
        Me.CboCodigoBodegaCompra.Images.Add(CType(resources.GetObject("CboCodigoBodegaCompra.Images"), System.Drawing.Image))
        Me.CboCodigoBodegaCompra.ItemHeight = 15
        Me.CboCodigoBodegaCompra.Location = New System.Drawing.Point(103, 287)
        Me.CboCodigoBodegaCompra.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodegaCompra.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodegaCompra.MaxLength = 32767
        Me.CboCodigoBodegaCompra.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodegaCompra.Name = "CboCodigoBodegaCompra"
        Me.CboCodigoBodegaCompra.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodegaCompra.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodegaCompra.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodegaCompra.Size = New System.Drawing.Size(202, 21)
        Me.CboCodigoBodegaCompra.TabIndex = 222
        Me.CboCodigoBodegaCompra.PropBag = resources.GetString("CboCodigoBodegaCompra.PropBag")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(53, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 221
        Me.Label5.Text = "Bodega"
        '
        'ChkNotificacion
        '
        Me.ChkNotificacion.AutoSize = True
        Me.ChkNotificacion.Location = New System.Drawing.Point(170, 148)
        Me.ChkNotificacion.Name = "ChkNotificacion"
        Me.ChkNotificacion.Size = New System.Drawing.Size(129, 17)
        Me.ChkNotificacion.TabIndex = 223
        Me.ChkNotificacion.Text = "Recibir Notificaciones"
        Me.ChkNotificacion.UseVisualStyleBackColor = True
        '
        'FrmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 427)
        Me.Controls.Add(Me.ChkNotificacion)
        Me.Controls.Add(Me.CboCodigoBodegaCompra)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CboTipoCompra)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CboProveedor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CboNivel)
        Me.Controls.Add(Me.CmbSerie)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblCodigo)
        Me.Controls.Add(Me.CboCodigoCliente)
        Me.Controls.Add(Me.CboCodigoVendedor)
        Me.Controls.Add(Me.LblVendedor)
        Me.Controls.Add(Me.CboTipoProducto)
        Me.Controls.Add(Me.LblTipoFactura)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TxtConfirmar)
        Me.Controls.Add(Me.LblConfirmar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.CboUsuario)
        Me.Controls.Add(Me.TxtContraseña)
        Me.Controls.Add(Me.LblContraseña)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Usuarios"
        CType(Me.CboUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboNivel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoBodegaCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblContraseña As System.Windows.Forms.Label
    Friend WithEvents TxtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents CboUsuario As C1.Win.C1List.C1Combo
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents TxtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents LblConfirmar As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblTipoFactura As System.Windows.Forms.Label
    Friend WithEvents CboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents CboCodigoVendedor As C1.Win.C1List.C1Combo
    Friend WithEvents LblVendedor As System.Windows.Forms.Label
    Friend WithEvents CboCodigoCliente As C1.Win.C1List.C1Combo
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents CboNivel As C1.Win.C1List.C1Combo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CboProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboTipoCompra As System.Windows.Forms.ComboBox
    Friend WithEvents CboCodigoBodegaCompra As C1.Win.C1List.C1Combo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkNotificacion As System.Windows.Forms.CheckBox
End Class
