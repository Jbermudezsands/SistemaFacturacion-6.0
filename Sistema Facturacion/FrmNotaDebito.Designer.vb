<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNotaDebito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNotaDebito))
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
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Button3 = New System.Windows.Forms.Button
        Me.TxtCuentas = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbTipo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.CmbTurno = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtGrado = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtAño = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CmbCodigo = New C1.Win.C1List.C1Combo
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.C1Combo3 = New C1.Win.C1List.C1Combo
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CmbCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.C1Combo3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Button1.Location = New System.Drawing.Point(276, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 38)
        Me.Button1.TabIndex = 127
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCtaxCobrar
        '
        Me.TxtCtaxCobrar.Location = New System.Drawing.Point(122, 177)
        Me.TxtCtaxCobrar.Name = "TxtCtaxCobrar"
        Me.TxtCtaxCobrar.Size = New System.Drawing.Size(148, 20)
        Me.TxtCtaxCobrar.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 132
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(122, 151)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(148, 20)
        Me.TxtTelefono.TabIndex = 124
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
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
        Me.LblDireccion.Size = New System.Drawing.Size(92, 13)
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
        Me.LblNombre.Size = New System.Drawing.Size(84, 13)
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
        Me.LblCodigo.Size = New System.Drawing.Size(80, 13)
        Me.LblCodigo.TabIndex = 128
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(415, 238)
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
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(95, 237)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 122
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(179, 237)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 123
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(15, 238)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 121
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(367, 233)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 124
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(108, -77)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(160, 13)
        Me.LblTitulo.TabIndex = 127
        Me.LblTitulo.Text = "REGISTRO DE  CLIENTES"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(-13, -102)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 126
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-24, -102)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(492, 60)
        Me.PictureBox1.TabIndex = 125
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(139, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "REGISTRO NOTA DEBITO Y CREDITO "
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(17, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 129
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox4.Location = New System.Drawing.Point(-6, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(597, 60)
        Me.PictureBox4.TabIndex = 128
        Me.PictureBox4.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(5, 66)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(437, 147)
        Me.TabControl1.TabIndex = 131
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.TxtCuentas)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.CmbTipo)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.CmbTurno)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.TxtGrado)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.TxtAño)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.CmbCodigo)
        Me.TabPage1.Controls.Add(Me.TxtDescripcion)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(429, 121)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Nota Debito y Credito"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(260, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 32)
        Me.Button3.TabIndex = 144
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxtCuentas
        '
        Me.TxtCuentas.Location = New System.Drawing.Point(106, 77)
        Me.TxtCuentas.Name = "TxtCuentas"
        Me.TxtCuentas.Size = New System.Drawing.Size(148, 20)
        Me.TxtCuentas.TabIndex = 142
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "Cuentas Contables"
        '
        'CmbTipo
        '
        Me.CmbTipo.FormattingEnabled = True
        Me.CmbTipo.Items.AddRange(New Object() {"Debito Clientes", "Credito Clientes", "Debito Proveedores", "Credito Proveedores", "Debito Clientes Dif $", "Credito Clientes Dif $", "Debito Clientes Dif C$", "Credito Clientes Dif C$", "Debito Proveedores Dif $", "Credito Proveedores Dif $", "Debito Proveedores Dif C$", "Credito Proveedores Dif C$"})
        Me.CmbTipo.Location = New System.Drawing.Point(296, 25)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(118, 21)
        Me.CmbTipo.TabIndex = 141
        Me.CmbTipo.Text = "Debito Clientes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(261, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Tipo"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(220, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 32)
        Me.Button2.TabIndex = 138
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmbTurno
        '
        Me.CmbTurno.FormattingEnabled = True
        Me.CmbTurno.Items.AddRange(New Object() {"Matutino", "Vespertino"})
        Me.CmbTurno.Location = New System.Drawing.Point(278, 283)
        Me.CmbTurno.Name = "CmbTurno"
        Me.CmbTurno.Size = New System.Drawing.Size(111, 21)
        Me.CmbTurno.TabIndex = 137
        Me.CmbTurno.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(237, 287)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 136
        Me.Label15.Text = "Turno"
        '
        'TxtGrado
        '
        Me.TxtGrado.Location = New System.Drawing.Point(114, 310)
        Me.TxtGrado.Name = "TxtGrado"
        Me.TxtGrado.Size = New System.Drawing.Size(108, 20)
        Me.TxtGrado.TabIndex = 132
        Me.TxtGrado.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 310)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 133
        Me.Label14.Text = "Grado"
        Me.Label14.Visible = False
        '
        'TxtAño
        '
        Me.TxtAño.Location = New System.Drawing.Point(114, 284)
        Me.TxtAño.Name = "TxtAño"
        Me.TxtAño.Size = New System.Drawing.Size(108, 20)
        Me.TxtAño.TabIndex = 134
        Me.TxtAño.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 284)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 135
        Me.Label13.Text = "Año"
        Me.Label13.Visible = False
        '
        'CmbCodigo
        '
        Me.CmbCodigo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbCodigo.Caption = ""
        Me.CmbCodigo.CaptionHeight = 17
        Me.CmbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbCodigo.ColumnCaptionHeight = 17
        Me.CmbCodigo.ColumnFooterHeight = 17
        Me.CmbCodigo.ContentHeight = 15
        Me.CmbCodigo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbCodigo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbCodigo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCodigo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbCodigo.EditorHeight = 15
        Me.CmbCodigo.Images.Add(CType(resources.GetObject("CmbCodigo.Images"), System.Drawing.Image))
        Me.CmbCodigo.ItemHeight = 15
        Me.CmbCodigo.Location = New System.Drawing.Point(106, 25)
        Me.CmbCodigo.MatchEntryTimeout = CType(2000, Long)
        Me.CmbCodigo.MaxDropDownItems = CType(5, Short)
        Me.CmbCodigo.MaxLength = 32767
        Me.CmbCodigo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbCodigo.Name = "CmbCodigo"
        Me.CmbCodigo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbCodigo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbCodigo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbCodigo.Size = New System.Drawing.Size(108, 21)
        Me.CmbCodigo.TabIndex = 120
        Me.CmbCodigo.PropBag = resources.GetString("CmbCodigo.PropBag")
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(106, 54)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(312, 20)
        Me.TxtDescripcion.TabIndex = 121
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(35, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Descripcion"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(22, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 128
        Me.Label16.Text = "Codigo Nb y Cr"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.C1Combo3)
        Me.GroupBox2.Controls.Add(Me.TextBox7)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.TextBox8)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TextBox9)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.TextBox10)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(401, 195)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'C1Combo3
        '
        Me.C1Combo3.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo3.Caption = ""
        Me.C1Combo3.CaptionHeight = 17
        Me.C1Combo3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo3.ColumnCaptionHeight = 17
        Me.C1Combo3.ColumnFooterHeight = 17
        Me.C1Combo3.ContentHeight = 15
        Me.C1Combo3.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo3.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo3.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo3.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo3.EditorHeight = 15
        Me.C1Combo3.Images.Add(CType(resources.GetObject("C1Combo3.Images"), System.Drawing.Image))
        Me.C1Combo3.ItemHeight = 15
        Me.C1Combo3.Location = New System.Drawing.Point(281, 45)
        Me.C1Combo3.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo3.MaxDropDownItems = CType(5, Short)
        Me.C1Combo3.MaxLength = 32767
        Me.C1Combo3.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo3.Name = "C1Combo3"
        Me.C1Combo3.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo3.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo3.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo3.Size = New System.Drawing.Size(105, 21)
        Me.C1Combo3.TabIndex = 121
        Me.C1Combo3.Visible = False
        Me.C1Combo3.PropBag = resources.GetString("C1Combo3.PropBag")
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(279, 76)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(107, 20)
        Me.TextBox7.TabIndex = 103
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(225, 79)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 102
        Me.Label17.Text = "R.U.C"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(225, 53)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 13)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "Intereses"
        Me.Label18.Visible = False
        '
        'TextBox8
        '
        Me.TextBox8.Enabled = False
        Me.TextBox8.Location = New System.Drawing.Point(112, 102)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(107, 20)
        Me.TextBox8.TabIndex = 100
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 105)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 13)
        Me.Label19.TabIndex = 99
        Me.Label19.Text = "Credito Disponible"
        '
        'TextBox9
        '
        Me.TextBox9.Enabled = False
        Me.TextBox9.Location = New System.Drawing.Point(112, 76)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(107, 20)
        Me.TextBox9.TabIndex = 98
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 79)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Credito Acumulado"
        '
        'TextBox10
        '
        Me.TextBox10.AcceptsReturn = True
        Me.TextBox10.Location = New System.Drawing.Point(112, 50)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(107, 20)
        Me.TextBox10.TabIndex = 96
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 53)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Limite de Credito"
        '
        'FrmNotaDebito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 311)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNotaDebito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNotaDebito"
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.CmbCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.C1Combo3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtGrado As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtAño As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmbCodigo As C1.Win.C1List.C1Combo
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents C1Combo3 As C1.Win.C1List.C1Combo
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCuentas As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
