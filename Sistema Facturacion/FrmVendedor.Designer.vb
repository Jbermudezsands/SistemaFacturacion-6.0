<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVendedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVendedor))
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboCodigoVendedor = New C1.Win.C1List.C1Combo()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtApellidos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCtaxCobrar = New System.Windows.Forms.TextBox()
        Me.CmdCuentas = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.OptRecuperacionVentas = New System.Windows.Forms.RadioButton()
        Me.OptGrupoVendedores = New System.Windows.Forms.RadioButton()
        Me.OptVentas = New System.Windows.Forms.RadioButton()
        Me.OptRecuperacion = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtRecuperacion2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtComision2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtRecuperacion1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtComision1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GrpRestaurante = New System.Windows.Forms.GroupBox()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.CboTipo = New System.Windows.Forms.ComboBox()
        Me.LblCajero = New System.Windows.Forms.Label()
        Me.CboCajero = New System.Windows.Forms.ComboBox()
        Me.CmdNuevo = New System.Windows.Forms.Button()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.PnlHeader.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GrpRestaurante.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.LblTitulo)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(480, 60)
        Me.PnlHeader.TabIndex = 0
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(20, 36)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(216, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Registro y configuración de vendedores"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(17, 6)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(126, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Vendedores"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(146, 34)
        Me.TabControl1.Location = New System.Drawing.Point(20, 72)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(440, 304)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CboCodigoVendedor)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TxtNombre)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.TxtApellidos)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TxtDireccion)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TxtTelefono)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.TxtCtaxCobrar)
        Me.TabPage1.Controls.Add(Me.CmdCuentas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 38)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(432, 262)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'CboCodigoVendedor
        '
        Me.CboCodigoVendedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoVendedor.Caption = ""
        Me.CboCodigoVendedor.CaptionHeight = 17
        Me.CboCodigoVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoVendedor.ColumnCaptionHeight = 17
        Me.CboCodigoVendedor.ColumnFooterHeight = 17
        Me.CboCodigoVendedor.ContentHeight = 15
        Me.CboCodigoVendedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoVendedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoVendedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoVendedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoVendedor.EditorHeight = 15
        Me.CboCodigoVendedor.Images.Add(CType(resources.GetObject("CboCodigoVendedor.Images"), System.Drawing.Image))
        Me.CboCodigoVendedor.ItemHeight = 15
        Me.CboCodigoVendedor.Location = New System.Drawing.Point(140, 20)
        Me.CboCodigoVendedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoVendedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoVendedor.MaxLength = 32767
        Me.CboCodigoVendedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoVendedor.Name = "CboCodigoVendedor"
        Me.CboCodigoVendedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoVendedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.Size = New System.Drawing.Size(226, 21)
        Me.CboCodigoVendedor.TabIndex = 1
        Me.CboCodigoVendedor.PropBag = resources.GetString("CboCodigoVendedor.PropBag")
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(374, 18)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(30, 25)
        Me.Button6.TabIndex = 2
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre"
        '
        'TxtNombre
        '
        Me.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNombre.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtNombre.Location = New System.Drawing.Point(140, 58)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(264, 25)
        Me.TxtNombre.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(16, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Apellido"
        '
        'TxtApellidos
        '
        Me.TxtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApellidos.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApellidos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtApellidos.Location = New System.Drawing.Point(140, 96)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(264, 25)
        Me.TxtApellidos.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "E-Mail"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDireccion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDireccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtDireccion.Location = New System.Drawing.Point(140, 134)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(264, 25)
        Me.TxtDireccion.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(16, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Teléfono"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTelefono.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTelefono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtTelefono.Location = New System.Drawing.Point(140, 172)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(264, 25)
        Me.TxtTelefono.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(16, 214)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cuenta x Pagar"
        '
        'TxtCtaxCobrar
        '
        Me.TxtCtaxCobrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCtaxCobrar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCtaxCobrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtCtaxCobrar.Location = New System.Drawing.Point(140, 210)
        Me.TxtCtaxCobrar.Name = "TxtCtaxCobrar"
        Me.TxtCtaxCobrar.Size = New System.Drawing.Size(226, 25)
        Me.TxtCtaxCobrar.TabIndex = 7
        '
        'CmdCuentas
        '
        Me.CmdCuentas.BackColor = System.Drawing.Color.White
        Me.CmdCuentas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdCuentas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.CmdCuentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCuentas.Image = CType(resources.GetObject("CmdCuentas.Image"), System.Drawing.Image)
        Me.CmdCuentas.Location = New System.Drawing.Point(374, 210)
        Me.CmdCuentas.Name = "CmdCuentas"
        Me.CmdCuentas.Size = New System.Drawing.Size(30, 25)
        Me.CmdCuentas.TabIndex = 8
        Me.CmdCuentas.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 38)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(432, 262)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Comisiones"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.OptRecuperacionVentas)
        Me.GroupBox4.Controls.Add(Me.OptGrupoVendedores)
        Me.GroupBox4.Controls.Add(Me.OptVentas)
        Me.GroupBox4.Controls.Add(Me.OptRecuperacion)
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(16, 148)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(400, 76)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipos de Comisiones"
        '
        'OptRecuperacionVentas
        '
        Me.OptRecuperacionVentas.AutoSize = True
        Me.OptRecuperacionVentas.Location = New System.Drawing.Point(12, 46)
        Me.OptRecuperacionVentas.Name = "OptRecuperacionVentas"
        Me.OptRecuperacionVentas.Size = New System.Drawing.Size(187, 21)
        Me.OptRecuperacionVentas.TabIndex = 3
        Me.OptRecuperacionVentas.TabStop = True
        Me.OptRecuperacionVentas.Text = "Por Recuperación y Ventas"
        Me.OptRecuperacionVentas.UseVisualStyleBackColor = True
        '
        'OptGrupoVendedores
        '
        Me.OptGrupoVendedores.AutoSize = True
        Me.OptGrupoVendedores.Location = New System.Drawing.Point(245, 20)
        Me.OptGrupoVendedores.Name = "OptGrupoVendedores"
        Me.OptGrupoVendedores.Size = New System.Drawing.Size(164, 21)
        Me.OptGrupoVendedores.TabIndex = 2
        Me.OptGrupoVendedores.TabStop = True
        Me.OptGrupoVendedores.Text = "Por Grupo Vendedores"
        Me.OptGrupoVendedores.UseVisualStyleBackColor = True
        '
        'OptVentas
        '
        Me.OptVentas.AutoSize = True
        Me.OptVentas.Location = New System.Drawing.Point(150, 20)
        Me.OptVentas.Name = "OptVentas"
        Me.OptVentas.Size = New System.Drawing.Size(91, 21)
        Me.OptVentas.TabIndex = 1
        Me.OptVentas.TabStop = True
        Me.OptVentas.Text = "Por Ventas"
        Me.OptVentas.UseVisualStyleBackColor = True
        '
        'OptRecuperacion
        '
        Me.OptRecuperacion.AutoSize = True
        Me.OptRecuperacion.Checked = True
        Me.OptRecuperacion.Location = New System.Drawing.Point(12, 20)
        Me.OptRecuperacion.Name = "OptRecuperacion"
        Me.OptRecuperacion.Size = New System.Drawing.Size(132, 21)
        Me.OptRecuperacion.TabIndex = 0
        Me.OptRecuperacion.TabStop = True
        Me.OptRecuperacion.Text = "Por Recuperación"
        Me.OptRecuperacion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.TxtComision2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.TxtComision1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 130)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuración Comisiones"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.TxtRecuperacion2)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(150, 70)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 50)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango en días Recuperación"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(106, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 17)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "%"
        '
        'TxtRecuperacion2
        '
        Me.TxtRecuperacion2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRecuperacion2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecuperacion2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtRecuperacion2.Location = New System.Drawing.Point(52, 18)
        Me.TxtRecuperacion2.Name = "TxtRecuperacion2"
        Me.TxtRecuperacion2.Size = New System.Drawing.Size(50, 25)
        Me.TxtRecuperacion2.TabIndex = 1
        Me.TxtRecuperacion2.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 17)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Desde"
        '
        'TxtComision2
        '
        Me.TxtComision2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtComision2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComision2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtComision2.Location = New System.Drawing.Point(78, 88)
        Me.TxtComision2.Name = "TxtComision2"
        Me.TxtComision2.Size = New System.Drawing.Size(38, 25)
        Me.TxtComision2.TabIndex = 3
        Me.TxtComision2.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 17)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Comisión 2"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(120, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(19, 17)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "%"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TxtRecuperacion1)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(150, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(240, 50)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rango en días Recuperación"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(106, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 17)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "%"
        '
        'TxtRecuperacion1
        '
        Me.TxtRecuperacion1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRecuperacion1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecuperacion1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtRecuperacion1.Location = New System.Drawing.Point(52, 18)
        Me.TxtRecuperacion1.Name = "TxtRecuperacion1"
        Me.TxtRecuperacion1.Size = New System.Drawing.Size(50, 25)
        Me.TxtRecuperacion1.TabIndex = 1
        Me.TxtRecuperacion1.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 17)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Hasta"
        '
        'TxtComision1
        '
        Me.TxtComision1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtComision1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComision1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtComision1.Location = New System.Drawing.Point(78, 30)
        Me.TxtComision1.Name = "TxtComision1"
        Me.TxtComision1.Size = New System.Drawing.Size(38, 25)
        Me.TxtComision1.TabIndex = 0
        Me.TxtComision1.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Comisión 1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(120, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 17)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "%"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.GrpRestaurante)
        Me.TabPage3.Location = New System.Drawing.Point(4, 38)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(432, 262)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Opciones"
        '
        'GrpRestaurante
        '
        Me.GrpRestaurante.Controls.Add(Me.LblTipo)
        Me.GrpRestaurante.Controls.Add(Me.CboTipo)
        Me.GrpRestaurante.Controls.Add(Me.LblCajero)
        Me.GrpRestaurante.Controls.Add(Me.CboCajero)
        Me.GrpRestaurante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.GrpRestaurante.Location = New System.Drawing.Point(16, 16)
        Me.GrpRestaurante.Name = "GrpRestaurante"
        Me.GrpRestaurante.Size = New System.Drawing.Size(400, 110)
        Me.GrpRestaurante.TabIndex = 0
        Me.GrpRestaurante.TabStop = False
        Me.GrpRestaurante.Text = "Restaurante"
        '
        'LblTipo
        '
        Me.LblTipo.AutoSize = True
        Me.LblTipo.Location = New System.Drawing.Point(16, 34)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(34, 17)
        Me.LblTipo.TabIndex = 0
        Me.LblTipo.Text = "Tipo"
        '
        'CboTipo
        '
        Me.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CboTipo.FormattingEnabled = True
        Me.CboTipo.Items.AddRange(New Object() {"Mesero", "Cajero", "Administrador"})
        Me.CboTipo.Location = New System.Drawing.Point(120, 30)
        Me.CboTipo.Name = "CboTipo"
        Me.CboTipo.Size = New System.Drawing.Size(262, 25)
        Me.CboTipo.TabIndex = 1
        '
        'LblCajero
        '
        Me.LblCajero.AutoSize = True
        Me.LblCajero.Location = New System.Drawing.Point(16, 72)
        Me.LblCajero.Name = "LblCajero"
        Me.LblCajero.Size = New System.Drawing.Size(46, 17)
        Me.LblCajero.TabIndex = 2
        Me.LblCajero.Text = "Cajero"
        '
        'CboCajero
        '
        Me.CboCajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCajero.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCajero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CboCajero.FormattingEnabled = True
        Me.CboCajero.Location = New System.Drawing.Point(120, 68)
        Me.CboCajero.Name = "CboCajero"
        Me.CboCajero.Size = New System.Drawing.Size(262, 25)
        Me.CboCajero.TabIndex = 3
        '
        'CmdNuevo
        '
        Me.CmdNuevo.BackColor = System.Drawing.Color.White
        Me.CmdNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.CmdNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.CmdNuevo.Location = New System.Drawing.Point(20, 388)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(100, 42)
        Me.CmdNuevo.TabIndex = 2
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.UseVisualStyleBackColor = False
        '
        'CmdGrabar
        '
        Me.CmdGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.CmdGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGrabar.FlatAppearance.BorderSize = 0
        Me.CmdGrabar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.CmdGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.ForeColor = System.Drawing.Color.White
        Me.CmdGrabar.Location = New System.Drawing.Point(130, 388)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(100, 42)
        Me.CmdGrabar.TabIndex = 3
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Guardar"
        Me.CmdGrabar.UseVisualStyleBackColor = False
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.BackColor = System.Drawing.Color.White
        Me.ButtonBorrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonBorrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ButtonBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBorrar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBorrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ButtonBorrar.Location = New System.Drawing.Point(240, 388)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(100, 42)
        Me.ButtonBorrar.TabIndex = 4
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Button8.Location = New System.Drawing.Point(360, 388)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(100, 42)
        Me.Button8.TabIndex = 5
        Me.Button8.Text = "Salir"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'FrmVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(480, 446)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVendedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendedores"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GrpRestaurante.ResumeLayout(False)
        Me.GrpRestaurante.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoVendedor As C1.Win.C1List.C1Combo
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaxCobrar As System.Windows.Forms.TextBox
    Friend WithEvents CmdCuentas As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents OptRecuperacionVentas As System.Windows.Forms.RadioButton
    Friend WithEvents OptGrupoVendedores As System.Windows.Forms.RadioButton
    Friend WithEvents OptVentas As System.Windows.Forms.RadioButton
    Friend WithEvents OptRecuperacion As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtRecuperacion2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtComision2 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtRecuperacion1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtComision1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GrpRestaurante As System.Windows.Forms.GroupBox
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents CboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents LblCajero As System.Windows.Forms.Label
    Friend WithEvents CboCajero As System.Windows.Forms.ComboBox
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
