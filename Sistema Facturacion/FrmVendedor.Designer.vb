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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CboCodigoVendedor = New C1.Win.C1List.C1Combo
        Me.CmdCuentas = New System.Windows.Forms.Button
        Me.TxtCtaxCobrar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.OptRecuperacionVentas = New System.Windows.Forms.RadioButton
        Me.OptGrupoVendedores = New System.Windows.Forms.RadioButton
        Me.OptVentas = New System.Windows.Forms.RadioButton
        Me.OptRecuperacion = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtRecuperacion2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtComision2 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtRecuperacion1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtComision1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CboCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 80)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(405, 245)
        Me.TabControl1.TabIndex = 121
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TxtApellidos)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.CboCodigoVendedor)
        Me.TabPage1.Controls.Add(Me.CmdCuentas)
        Me.TabPage1.Controls.Add(Me.TxtCtaxCobrar)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.TxtTelefono)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TxtDireccion)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TxtNombre)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(397, 219)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro de Vendedor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(122, 78)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(252, 20)
        Me.TxtApellidos.TabIndex = 122
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Apellido Vendedor"
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
        Me.CboCodigoVendedor.Location = New System.Drawing.Point(122, 25)
        Me.CboCodigoVendedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoVendedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoVendedor.MaxLength = 32767
        Me.CboCodigoVendedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoVendedor.Name = "CboCodigoVendedor"
        Me.CboCodigoVendedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoVendedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoVendedor.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoVendedor.TabIndex = 120
        Me.CboCodigoVendedor.PropBag = resources.GetString("CboCodigoVendedor.PropBag")
        '
        'CmdCuentas
        '
        Me.CmdCuentas.Image = CType(resources.GetObject("CmdCuentas.Image"), System.Drawing.Image)
        Me.CmdCuentas.Location = New System.Drawing.Point(277, 133)
        Me.CmdCuentas.Name = "CmdCuentas"
        Me.CmdCuentas.Size = New System.Drawing.Size(37, 38)
        Me.CmdCuentas.TabIndex = 127
        Me.CmdCuentas.UseVisualStyleBackColor = True
        '
        'TxtCtaxCobrar
        '
        Me.TxtCtaxCobrar.Location = New System.Drawing.Point(123, 151)
        Me.TxtCtaxCobrar.Name = "TxtCtaxCobrar"
        Me.TxtCtaxCobrar.Size = New System.Drawing.Size(148, 20)
        Me.TxtCtaxCobrar.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "Cuenta  x Pagar"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(123, 125)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(148, 20)
        Me.TxtTelefono.TabIndex = 124
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 125)
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
        Me.TxtDireccion.Size = New System.Drawing.Size(252, 21)
        Me.TxtDireccion.TabIndex = 123
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "E-Mail"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(122, 54)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(252, 20)
        Me.TxtNombre.TabIndex = 121
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Nombre Vendedor"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "CodigoVendedor"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(397, 219)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Comisiones"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.OptRecuperacionVentas)
        Me.GroupBox4.Controls.Add(Me.OptGrupoVendedores)
        Me.GroupBox4.Controls.Add(Me.OptVentas)
        Me.GroupBox4.Controls.Add(Me.OptRecuperacion)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 141)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(388, 72)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipos de Comisiones"
        '
        'OptRecuperacionVentas
        '
        Me.OptRecuperacionVentas.AutoSize = True
        Me.OptRecuperacionVentas.Location = New System.Drawing.Point(11, 40)
        Me.OptRecuperacionVentas.Name = "OptRecuperacionVentas"
        Me.OptRecuperacionVentas.Size = New System.Drawing.Size(155, 17)
        Me.OptRecuperacionVentas.TabIndex = 12
        Me.OptRecuperacionVentas.TabStop = True
        Me.OptRecuperacionVentas.Text = "Por Recuperacion y Ventas"
        Me.OptRecuperacionVentas.UseVisualStyleBackColor = True
        '
        'OptGrupoVendedores
        '
        Me.OptGrupoVendedores.AutoSize = True
        Me.OptGrupoVendedores.Location = New System.Drawing.Point(209, 16)
        Me.OptGrupoVendedores.Name = "OptGrupoVendedores"
        Me.OptGrupoVendedores.Size = New System.Drawing.Size(133, 17)
        Me.OptGrupoVendedores.TabIndex = 11
        Me.OptGrupoVendedores.TabStop = True
        Me.OptGrupoVendedores.Text = "Por Grupo Vendedores"
        Me.OptGrupoVendedores.UseVisualStyleBackColor = True
        '
        'OptVentas
        '
        Me.OptVentas.AutoSize = True
        Me.OptVentas.Location = New System.Drawing.Point(126, 16)
        Me.OptVentas.Name = "OptVentas"
        Me.OptVentas.Size = New System.Drawing.Size(77, 17)
        Me.OptVentas.TabIndex = 10
        Me.OptVentas.TabStop = True
        Me.OptVentas.Text = "Por Ventas"
        Me.OptVentas.UseVisualStyleBackColor = True
        '
        'OptRecuperacion
        '
        Me.OptRecuperacion.AutoSize = True
        Me.OptRecuperacion.Checked = True
        Me.OptRecuperacion.Location = New System.Drawing.Point(11, 16)
        Me.OptRecuperacion.Name = "OptRecuperacion"
        Me.OptRecuperacion.Size = New System.Drawing.Size(111, 17)
        Me.OptRecuperacion.TabIndex = 9
        Me.OptRecuperacion.TabStop = True
        Me.OptRecuperacion.Text = "Por Recuperacion"
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
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 129)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuracion Comisiones"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.TxtRecuperacion2)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(133, 65)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 49)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango en dias Recuperacion"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(100, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "%"
        '
        'TxtRecuperacion2
        '
        Me.TxtRecuperacion2.Location = New System.Drawing.Point(45, 19)
        Me.TxtRecuperacion2.Name = "TxtRecuperacion2"
        Me.TxtRecuperacion2.Size = New System.Drawing.Size(51, 20)
        Me.TxtRecuperacion2.TabIndex = 4
        Me.TxtRecuperacion2.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Desde"
        '
        'TxtComision2
        '
        Me.TxtComision2.Location = New System.Drawing.Point(77, 82)
        Me.TxtComision2.Name = "TxtComision2"
        Me.TxtComision2.Size = New System.Drawing.Size(34, 20)
        Me.TxtComision2.TabIndex = 5
        Me.TxtComision2.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Comision 2"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(115, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "%"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TxtRecuperacion1)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(131, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 49)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rango en dias Recuperacion"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(102, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "%"
        '
        'TxtRecuperacion1
        '
        Me.TxtRecuperacion1.Location = New System.Drawing.Point(47, 19)
        Me.TxtRecuperacion1.Name = "TxtRecuperacion1"
        Me.TxtRecuperacion1.Size = New System.Drawing.Size(51, 20)
        Me.TxtRecuperacion1.TabIndex = 6
        Me.TxtRecuperacion1.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Hasta"
        '
        'TxtComision1
        '
        Me.TxtComision1.Location = New System.Drawing.Point(75, 27)
        Me.TxtComision1.Name = "TxtComision1"
        Me.TxtComision1.Size = New System.Drawing.Size(34, 20)
        Me.TxtComision1.TabIndex = 1
        Me.TxtComision1.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Comision 1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(113, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(135, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(185, 13)
        Me.Label9.TabIndex = 124
        Me.Label9.Text = "REGISTRO DE  VENDEDORES"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(11, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 123
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(0, -4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(439, 78)
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(92, 331)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 126
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(176, 331)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 127
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(11, 331)
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
        Me.Button8.Location = New System.Drawing.Point(338, 333)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 128
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'FrmVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 411)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmVendedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendedores"
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
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoVendedor As C1.Win.C1List.C1Combo
    Friend WithEvents CmdCuentas As System.Windows.Forms.Button
    Friend WithEvents TxtCtaxCobrar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtComision1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRecuperacion1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRecuperacion2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtComision2 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents OptRecuperacionVentas As System.Windows.Forms.RadioButton
    Friend WithEvents OptGrupoVendedores As System.Windows.Forms.RadioButton
    Friend WithEvents OptVentas As System.Windows.Forms.RadioButton
    Friend WithEvents OptRecuperacion As System.Windows.Forms.RadioButton
End Class
