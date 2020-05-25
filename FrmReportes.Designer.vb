<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportes))
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ListBox = New System.Windows.Forms.ListBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTPFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CodigoProducto2X = New C1.Win.C1List.C1Combo
        Me.CboCodProducto = New C1.Win.C1List.C1Combo
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CmbRango2 = New C1.Win.C1List.C1Combo
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbRango1 = New C1.Win.C1List.C1Combo
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbAgrupado = New System.Windows.Forms.ComboBox
        Me.ListaImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LblProcesando = New System.Windows.Forms.Label
        Me.GroupClientes = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.CmbClientes2 = New C1.Win.C1List.C1Combo
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbClientes = New C1.Win.C1List.C1Combo
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupVendedor = New System.Windows.Forms.GroupBox
        Me.CmdClientes2 = New System.Windows.Forms.Button
        Me.CmdClientes1 = New System.Windows.Forms.Button
        Me.CmbVendedores2 = New C1.Win.C1List.C1Combo
        Me.Label9 = New System.Windows.Forms.Label
        Me.CmbVendedores = New C1.Win.C1List.C1Combo
        Me.Label10 = New System.Windows.Forms.Label
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OptDolares = New System.Windows.Forms.RadioButton
        Me.OptCordobas = New System.Windows.Forms.RadioButton
        Me.C1Combo1 = New C1.Win.C1List.C1Combo
        Me.C1Combo2 = New C1.Win.C1List.C1Combo
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBoxProductos = New System.Windows.Forms.GroupBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.CboCodProducto2 = New C1.Win.C1List.C1Combo
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.CboProducto = New C1.Win.C1List.C1Combo
        Me.C1Combo3 = New C1.Win.C1List.C1Combo
        Me.GroupBoxNotas = New System.Windows.Forms.GroupBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.CmbNotas2 = New C1.Win.C1List.C1Combo
        Me.Label15 = New System.Windows.Forms.Label
        Me.CmbNotas = New C1.Win.C1List.C1Combo
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBoxLinea = New System.Windows.Forms.GroupBox
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.CboCodigoLinea2 = New C1.Win.C1List.C1Combo
        Me.Label17 = New System.Windows.Forms.Label
        Me.CboCodigoLinea = New C1.Win.C1List.C1Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBoxTipo = New System.Windows.Forms.GroupBox
        Me.CmbTipoHasta = New C1.Win.C1List.C1Combo
        Me.Label19 = New System.Windows.Forms.Label
        Me.CmbTipoDesde = New C1.Win.C1List.C1Combo
        Me.Label20 = New System.Windows.Forms.Label
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodigoProducto2X, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CmbRango2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbRango1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupClientes.SuspendLayout()
        CType(Me.CmbClientes2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupVendedor.SuspendLayout()
        CType(Me.CmbVendedores2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Combo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxProductos.SuspendLayout()
        CType(Me.CboCodProducto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Combo3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxNotas.SuspendLayout()
        CType(Me.CmbNotas2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxLinea.SuspendLayout()
        CType(Me.CboCodigoLinea2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxTipo.SuspendLayout()
        CType(Me.CmbTipoHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbTipoDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(243, 26)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(152, 13)
        Me.LblTitulo.TabIndex = 166
        Me.LblTitulo.Text = "REPORTES GENERALES"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(22, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 165
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(766, 60)
        Me.PictureBox1.TabIndex = 164
        Me.PictureBox1.TabStop = False
        '
        'ListBox
        '
        Me.ListBox.FormattingEnabled = True
        Me.ListBox.Location = New System.Drawing.Point(12, 65)
        Me.ListBox.Name = "ListBox"
        Me.ListBox.Size = New System.Drawing.Size(260, 264)
        Me.ListBox.TabIndex = 167
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(12, 334)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 66)
        Me.Button2.TabIndex = 189
        Me.Button2.Text = "Imprimir"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(578, 334)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 188
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DTPFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(280, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 52)
        Me.GroupBox1.TabIndex = 190
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de Fechas"
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(241, 20)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(97, 20)
        Me.DTPFechaFin.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(181, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Fin"
        '
        'DTPFechaIni
        '
        Me.DTPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaIni.Location = New System.Drawing.Point(78, 19)
        Me.DTPFechaIni.Name = "DTPFechaIni"
        Me.DTPFechaIni.Size = New System.Drawing.Size(97, 20)
        Me.DTPFechaIni.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicio"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(22, -1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 191
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CodigoProducto2X
        '
        Me.CodigoProducto2X.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CodigoProducto2X.Caption = ""
        Me.CodigoProducto2X.CaptionHeight = 17
        Me.CodigoProducto2X.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CodigoProducto2X.ColumnCaptionHeight = 17
        Me.CodigoProducto2X.ColumnFooterHeight = 17
        Me.CodigoProducto2X.ContentHeight = 15
        Me.CodigoProducto2X.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CodigoProducto2X.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CodigoProducto2X.DropDownWidth = 500
        Me.CodigoProducto2X.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CodigoProducto2X.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodigoProducto2X.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CodigoProducto2X.EditorHeight = 15
        Me.CodigoProducto2X.Images.Add(CType(resources.GetObject("CodigoProducto2X.Images"), System.Drawing.Image))
        Me.CodigoProducto2X.ItemHeight = 15
        Me.CodigoProducto2X.Location = New System.Drawing.Point(61, 46)
        Me.CodigoProducto2X.MatchEntryTimeout = CType(2000, Long)
        Me.CodigoProducto2X.MaxDropDownItems = CType(5, Short)
        Me.CodigoProducto2X.MaxLength = 32767
        Me.CodigoProducto2X.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CodigoProducto2X.Name = "CodigoProducto2X"
        Me.CodigoProducto2X.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CodigoProducto2X.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CodigoProducto2X.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CodigoProducto2X.Size = New System.Drawing.Size(158, 21)
        Me.CodigoProducto2X.TabIndex = 72
        Me.CodigoProducto2X.PropBag = resources.GetString("CodigoProducto2X.PropBag")
        '
        'CboCodProducto
        '
        Me.CboCodProducto.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodProducto.Caption = ""
        Me.CboCodProducto.CaptionHeight = 17
        Me.CboCodProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodProducto.ColumnCaptionHeight = 17
        Me.CboCodProducto.ColumnFooterHeight = 17
        Me.CboCodProducto.ContentHeight = 15
        Me.CboCodProducto.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodProducto.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodProducto.DropDownWidth = 300
        Me.CboCodProducto.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodProducto.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodProducto.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodProducto.EditorHeight = 15
        Me.CboCodProducto.Images.Add(CType(resources.GetObject("CboCodProducto.Images"), System.Drawing.Image))
        Me.CboCodProducto.ItemHeight = 15
        Me.CboCodProducto.Location = New System.Drawing.Point(61, 18)
        Me.CboCodProducto.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodProducto.MaxDropDownItems = CType(5, Short)
        Me.CboCodProducto.MaxLength = 32767
        Me.CboCodProducto.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodProducto.Name = "CboCodProducto"
        Me.CboCodProducto.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodProducto.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodProducto.Size = New System.Drawing.Size(158, 21)
        Me.CboCodProducto.TabIndex = 61
        Me.CboCodProducto.PropBag = resources.GetString("CboCodProducto.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 66
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 63
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CmbRango2)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.CmbRango1)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.CmbAgrupado)
        Me.GroupBox3.Location = New System.Drawing.Point(280, 216)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(352, 84)
        Me.GroupBox3.TabIndex = 193
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango de Productos"
        '
        'CmbRango2
        '
        Me.CmbRango2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbRango2.Caption = ""
        Me.CmbRango2.CaptionHeight = 17
        Me.CmbRango2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbRango2.ColumnCaptionHeight = 17
        Me.CmbRango2.ColumnFooterHeight = 17
        Me.CmbRango2.ContentHeight = 15
        Me.CmbRango2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbRango2.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbRango2.DropDownWidth = 300
        Me.CmbRango2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbRango2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbRango2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbRango2.EditorHeight = 15
        Me.CmbRango2.Images.Add(CType(resources.GetObject("CmbRango2.Images"), System.Drawing.Image))
        Me.CmbRango2.ItemHeight = 15
        Me.CmbRango2.Location = New System.Drawing.Point(184, 51)
        Me.CmbRango2.MatchEntryTimeout = CType(2000, Long)
        Me.CmbRango2.MaxDropDownItems = CType(5, Short)
        Me.CmbRango2.MaxLength = 32767
        Me.CmbRango2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbRango2.Name = "CmbRango2"
        Me.CmbRango2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbRango2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbRango2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbRango2.Size = New System.Drawing.Size(119, 21)
        Me.CmbRango2.TabIndex = 67
        Me.CmbRango2.PropBag = resources.GetString("CmbRango2.PropBag")
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(309, 46)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(37, 30)
        Me.Button4.TabIndex = 68
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(140, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Hasta"
        '
        'CmbRango1
        '
        Me.CmbRango1.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbRango1.Caption = ""
        Me.CmbRango1.CaptionHeight = 17
        Me.CmbRango1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbRango1.ColumnCaptionHeight = 17
        Me.CmbRango1.ColumnFooterHeight = 17
        Me.CmbRango1.ContentHeight = 15
        Me.CmbRango1.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbRango1.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbRango1.DropDownWidth = 300
        Me.CmbRango1.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbRango1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbRango1.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbRango1.EditorHeight = 15
        Me.CmbRango1.Images.Add(CType(resources.GetObject("CmbRango1.Images"), System.Drawing.Image))
        Me.CmbRango1.ItemHeight = 15
        Me.CmbRango1.Location = New System.Drawing.Point(184, 19)
        Me.CmbRango1.MatchEntryTimeout = CType(2000, Long)
        Me.CmbRango1.MaxDropDownItems = CType(5, Short)
        Me.CmbRango1.MaxLength = 32767
        Me.CmbRango1.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbRango1.Name = "CmbRango1"
        Me.CmbRango1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbRango1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbRango1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbRango1.Size = New System.Drawing.Size(119, 21)
        Me.CmbRango1.TabIndex = 64
        Me.CmbRango1.PropBag = resources.GetString("CmbRango1.PropBag")
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(309, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 30)
        Me.Button3.TabIndex = 65
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(140, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Desde"
        '
        'CmbAgrupado
        '
        Me.CmbAgrupado.FormattingEnabled = True
        Me.CmbAgrupado.Items.AddRange(New Object() {"Codigo Producto", "Linea", "Bodega", "Rubro"})
        Me.CmbAgrupado.Location = New System.Drawing.Point(10, 20)
        Me.CmbAgrupado.Name = "CmbAgrupado"
        Me.CmbAgrupado.Size = New System.Drawing.Size(121, 21)
        Me.CmbAgrupado.TabIndex = 0
        '
        'ListaImagenes
        '
        Me.ListaImagenes.ImageStream = CType(resources.GetObject("ListaImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.ListaImagenes.Images.SetKeyName(0, "Cry.png")
        Me.ListaImagenes.Images.SetKeyName(1, "Bad.png")
        Me.ListaImagenes.Images.SetKeyName(2, "Happy.png")
        Me.ListaImagenes.Images.SetKeyName(3, "Ok.png")
        Me.ListaImagenes.Images.SetKeyName(4, "Ou.png")
        Me.ListaImagenes.Images.SetKeyName(5, "Scared.png")
        Me.ListaImagenes.Images.SetKeyName(6, "Smiling.png")
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'LblProcesando
        '
        Me.LblProcesando.AutoSize = True
        Me.LblProcesando.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProcesando.ForeColor = System.Drawing.Color.Blue
        Me.LblProcesando.Location = New System.Drawing.Point(201, 391)
        Me.LblProcesando.Name = "LblProcesando"
        Me.LblProcesando.Size = New System.Drawing.Size(237, 24)
        Me.LblProcesando.TabIndex = 195
        Me.LblProcesando.Text = "Procesando, Espere......"
        Me.LblProcesando.Visible = False
        '
        'GroupClientes
        '
        Me.GroupClientes.Controls.Add(Me.Button6)
        Me.GroupClientes.Controls.Add(Me.Button7)
        Me.GroupClientes.Controls.Add(Me.CmbClientes2)
        Me.GroupClientes.Controls.Add(Me.Label7)
        Me.GroupClientes.Controls.Add(Me.CmbClientes)
        Me.GroupClientes.Controls.Add(Me.Label8)
        Me.GroupClientes.Location = New System.Drawing.Point(820, 217)
        Me.GroupClientes.Name = "GroupClientes"
        Me.GroupClientes.Size = New System.Drawing.Size(277, 86)
        Me.GroupClientes.TabIndex = 196
        Me.GroupClientes.TabStop = False
        Me.GroupClientes.Text = "Rango de Clientes"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(225, 46)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 30)
        Me.Button6.TabIndex = 68
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(225, 11)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(37, 30)
        Me.Button7.TabIndex = 67
        Me.Button7.UseVisualStyleBackColor = True
        '
        'CmbClientes2
        '
        Me.CmbClientes2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbClientes2.Caption = ""
        Me.CmbClientes2.CaptionHeight = 17
        Me.CmbClientes2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbClientes2.ColumnCaptionHeight = 17
        Me.CmbClientes2.ColumnFooterHeight = 17
        Me.CmbClientes2.ContentHeight = 15
        Me.CmbClientes2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbClientes2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbClientes2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbClientes2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbClientes2.EditorHeight = 15
        Me.CmbClientes2.Images.Add(CType(resources.GetObject("CmbClientes2.Images"), System.Drawing.Image))
        Me.CmbClientes2.ItemHeight = 15
        Me.CmbClientes2.Location = New System.Drawing.Point(61, 46)
        Me.CmbClientes2.MatchEntryTimeout = CType(2000, Long)
        Me.CmbClientes2.MaxDropDownItems = CType(5, Short)
        Me.CmbClientes2.MaxLength = 32767
        Me.CmbClientes2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbClientes2.Name = "CmbClientes2"
        Me.CmbClientes2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbClientes2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbClientes2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbClientes2.Size = New System.Drawing.Size(158, 21)
        Me.CmbClientes2.TabIndex = 64
        Me.CmbClientes2.PropBag = resources.GetString("CmbClientes2.PropBag")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Hasta"
        '
        'CmbClientes
        '
        Me.CmbClientes.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbClientes.Caption = ""
        Me.CmbClientes.CaptionHeight = 17
        Me.CmbClientes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbClientes.ColumnCaptionHeight = 17
        Me.CmbClientes.ColumnFooterHeight = 17
        Me.CmbClientes.ContentHeight = 15
        Me.CmbClientes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbClientes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbClientes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbClientes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbClientes.EditorHeight = 15
        Me.CmbClientes.Images.Add(CType(resources.GetObject("CmbClientes.Images"), System.Drawing.Image))
        Me.CmbClientes.ItemHeight = 15
        Me.CmbClientes.Location = New System.Drawing.Point(61, 19)
        Me.CmbClientes.MatchEntryTimeout = CType(2000, Long)
        Me.CmbClientes.MaxDropDownItems = CType(5, Short)
        Me.CmbClientes.MaxLength = 32767
        Me.CmbClientes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbClientes.Name = "CmbClientes"
        Me.CmbClientes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbClientes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbClientes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbClientes.Size = New System.Drawing.Size(158, 21)
        Me.CmbClientes.TabIndex = 61
        Me.CmbClientes.PropBag = resources.GetString("CmbClientes.PropBag")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Desde"
        '
        'GroupVendedor
        '
        Me.GroupVendedor.Controls.Add(Me.CmdClientes2)
        Me.GroupVendedor.Controls.Add(Me.CmdClientes1)
        Me.GroupVendedor.Controls.Add(Me.CmbVendedores2)
        Me.GroupVendedor.Controls.Add(Me.Label9)
        Me.GroupVendedor.Controls.Add(Me.CmbVendedores)
        Me.GroupVendedor.Controls.Add(Me.Label10)
        Me.GroupVendedor.Location = New System.Drawing.Point(1114, 103)
        Me.GroupVendedor.Name = "GroupVendedor"
        Me.GroupVendedor.Size = New System.Drawing.Size(277, 85)
        Me.GroupVendedor.TabIndex = 197
        Me.GroupVendedor.TabStop = False
        Me.GroupVendedor.Text = "Rango de Vendedores"
        '
        'CmdClientes2
        '
        Me.CmdClientes2.Image = CType(resources.GetObject("CmdClientes2.Image"), System.Drawing.Image)
        Me.CmdClientes2.Location = New System.Drawing.Point(225, 46)
        Me.CmdClientes2.Name = "CmdClientes2"
        Me.CmdClientes2.Size = New System.Drawing.Size(37, 30)
        Me.CmdClientes2.TabIndex = 74
        Me.CmdClientes2.UseVisualStyleBackColor = True
        '
        'CmdClientes1
        '
        Me.CmdClientes1.Image = CType(resources.GetObject("CmdClientes1.Image"), System.Drawing.Image)
        Me.CmdClientes1.Location = New System.Drawing.Point(225, 10)
        Me.CmdClientes1.Name = "CmdClientes1"
        Me.CmdClientes1.Size = New System.Drawing.Size(37, 30)
        Me.CmdClientes1.TabIndex = 73
        Me.CmdClientes1.UseVisualStyleBackColor = True
        '
        'CmbVendedores2
        '
        Me.CmbVendedores2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbVendedores2.Caption = ""
        Me.CmbVendedores2.CaptionHeight = 17
        Me.CmbVendedores2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbVendedores2.ColumnCaptionHeight = 17
        Me.CmbVendedores2.ColumnFooterHeight = 17
        Me.CmbVendedores2.ContentHeight = 15
        Me.CmbVendedores2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbVendedores2.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbVendedores2.DropDownWidth = 300
        Me.CmbVendedores2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbVendedores2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbVendedores2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbVendedores2.EditorHeight = 15
        Me.CmbVendedores2.Images.Add(CType(resources.GetObject("CmbVendedores2.Images"), System.Drawing.Image))
        Me.CmbVendedores2.ItemHeight = 15
        Me.CmbVendedores2.Location = New System.Drawing.Point(61, 46)
        Me.CmbVendedores2.MatchEntryTimeout = CType(2000, Long)
        Me.CmbVendedores2.MaxDropDownItems = CType(5, Short)
        Me.CmbVendedores2.MaxLength = 32767
        Me.CmbVendedores2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbVendedores2.Name = "CmbVendedores2"
        Me.CmbVendedores2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbVendedores2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbVendedores2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbVendedores2.Size = New System.Drawing.Size(158, 21)
        Me.CmbVendedores2.TabIndex = 64
        Me.CmbVendedores2.PropBag = resources.GetString("CmbVendedores2.PropBag")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Hasta"
        '
        'CmbVendedores
        '
        Me.CmbVendedores.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbVendedores.Caption = ""
        Me.CmbVendedores.CaptionHeight = 17
        Me.CmbVendedores.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbVendedores.ColumnCaptionHeight = 17
        Me.CmbVendedores.ColumnFooterHeight = 17
        Me.CmbVendedores.ContentHeight = 15
        Me.CmbVendedores.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbVendedores.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbVendedores.DropDownWidth = 300
        Me.CmbVendedores.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbVendedores.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbVendedores.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbVendedores.EditorHeight = 15
        Me.CmbVendedores.Images.Add(CType(resources.GetObject("CmbVendedores.Images"), System.Drawing.Image))
        Me.CmbVendedores.ItemHeight = 15
        Me.CmbVendedores.Location = New System.Drawing.Point(61, 19)
        Me.CmbVendedores.MatchEntryTimeout = CType(2000, Long)
        Me.CmbVendedores.MaxDropDownItems = CType(5, Short)
        Me.CmbVendedores.MaxLength = 32767
        Me.CmbVendedores.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbVendedores.Name = "CmbVendedores"
        Me.CmbVendedores.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbVendedores.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbVendedores.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbVendedores.Size = New System.Drawing.Size(158, 21)
        Me.CmbVendedores.TabIndex = 61
        Me.CmbVendedores.PropBag = resources.GetString("CmbVendedores.PropBag")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Desde"
        '
        'Imagen
        '
        Me.Imagen.BackColor = System.Drawing.Color.White
        Me.Imagen.Image = CType(resources.GetObject("Imagen.Image"), System.Drawing.Image)
        Me.Imagen.Location = New System.Drawing.Point(10, 65)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(660, 267)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Imagen.TabIndex = 198
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        'ProgressBar
        '
        Me.ProgressBar.AccessibleDescription = ""
        Me.ProgressBar.Location = New System.Drawing.Point(93, 339)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(477, 23)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 199
        Me.ProgressBar.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptDolares)
        Me.GroupBox2.Controls.Add(Me.OptCordobas)
        Me.GroupBox2.Location = New System.Drawing.Point(280, 298)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(171, 32)
        Me.GroupBox2.TabIndex = 200
        Me.GroupBox2.TabStop = False
        '
        'OptDolares
        '
        Me.OptDolares.AutoSize = True
        Me.OptDolares.Location = New System.Drawing.Point(95, 8)
        Me.OptDolares.Name = "OptDolares"
        Me.OptDolares.Size = New System.Drawing.Size(61, 17)
        Me.OptDolares.TabIndex = 1
        Me.OptDolares.Text = "Dolares"
        Me.OptDolares.UseVisualStyleBackColor = True
        '
        'OptCordobas
        '
        Me.OptCordobas.AutoSize = True
        Me.OptCordobas.Checked = True
        Me.OptCordobas.Location = New System.Drawing.Point(15, 9)
        Me.OptCordobas.Name = "OptCordobas"
        Me.OptCordobas.Size = New System.Drawing.Size(70, 17)
        Me.OptCordobas.TabIndex = 0
        Me.OptCordobas.TabStop = True
        Me.OptCordobas.Text = "Cordobas"
        Me.OptCordobas.UseVisualStyleBackColor = True
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
        Me.C1Combo1.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.C1Combo1.DropDownWidth = 500
        Me.C1Combo1.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo1.EditorHeight = 15
        Me.C1Combo1.Images.Add(CType(resources.GetObject("C1Combo1.Images"), System.Drawing.Image))
        Me.C1Combo1.ItemHeight = 15
        Me.C1Combo1.Location = New System.Drawing.Point(60, 44)
        Me.C1Combo1.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo1.MaxDropDownItems = CType(5, Short)
        Me.C1Combo1.MaxLength = 32767
        Me.C1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo1.Name = "C1Combo1"
        Me.C1Combo1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo1.Size = New System.Drawing.Size(158, 21)
        Me.C1Combo1.TabIndex = 72
        Me.C1Combo1.PropBag = resources.GetString("C1Combo1.PropBag")
        '
        'C1Combo2
        '
        Me.C1Combo2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo2.Caption = ""
        Me.C1Combo2.CaptionHeight = 17
        Me.C1Combo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo2.ColumnCaptionHeight = 17
        Me.C1Combo2.ColumnFooterHeight = 17
        Me.C1Combo2.ContentHeight = 15
        Me.C1Combo2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo2.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.C1Combo2.DropDownWidth = 500
        Me.C1Combo2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo2.EditorHeight = 15
        Me.C1Combo2.Images.Add(CType(resources.GetObject("C1Combo2.Images"), System.Drawing.Image))
        Me.C1Combo2.ItemHeight = 15
        Me.C1Combo2.Location = New System.Drawing.Point(61, 17)
        Me.C1Combo2.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo2.MaxDropDownItems = CType(5, Short)
        Me.C1Combo2.MaxLength = 32767
        Me.C1Combo2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo2.Name = "C1Combo2"
        Me.C1Combo2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo2.Size = New System.Drawing.Size(158, 21)
        Me.C1Combo2.TabIndex = 71
        Me.C1Combo2.PropBag = resources.GetString("C1Combo2.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 66
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 63
        '
        'GroupBoxProductos
        '
        Me.GroupBoxProductos.Controls.Add(Me.Button5)
        Me.GroupBoxProductos.Controls.Add(Me.Button1)
        Me.GroupBoxProductos.Controls.Add(Me.CboCodProducto2)
        Me.GroupBoxProductos.Controls.Add(Me.Label13)
        Me.GroupBoxProductos.Controls.Add(Me.CboCodProducto)
        Me.GroupBoxProductos.Controls.Add(Me.Label14)
        Me.GroupBoxProductos.Location = New System.Drawing.Point(819, 6)
        Me.GroupBoxProductos.Name = "GroupBoxProductos"
        Me.GroupBoxProductos.Size = New System.Drawing.Size(278, 85)
        Me.GroupBoxProductos.TabIndex = 201
        Me.GroupBoxProductos.TabStop = False
        Me.GroupBoxProductos.Text = "Rango de Productos"
        Me.GroupBoxProductos.Visible = False
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(225, 46)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(37, 30)
        Me.Button5.TabIndex = 68
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(225, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 30)
        Me.Button1.TabIndex = 67
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CboCodProducto2
        '
        Me.CboCodProducto2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodProducto2.Caption = ""
        Me.CboCodProducto2.CaptionHeight = 17
        Me.CboCodProducto2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodProducto2.ColumnCaptionHeight = 17
        Me.CboCodProducto2.ColumnFooterHeight = 17
        Me.CboCodProducto2.ContentHeight = 15
        Me.CboCodProducto2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodProducto2.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodProducto2.DropDownWidth = 300
        Me.CboCodProducto2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodProducto2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodProducto2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodProducto2.EditorHeight = 15
        Me.CboCodProducto2.Images.Add(CType(resources.GetObject("CboCodProducto2.Images"), System.Drawing.Image))
        Me.CboCodProducto2.ItemHeight = 15
        Me.CboCodProducto2.Location = New System.Drawing.Point(61, 46)
        Me.CboCodProducto2.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodProducto2.MaxDropDownItems = CType(5, Short)
        Me.CboCodProducto2.MaxLength = 32767
        Me.CboCodProducto2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodProducto2.Name = "CboCodProducto2"
        Me.CboCodProducto2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodProducto2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodProducto2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodProducto2.Size = New System.Drawing.Size(158, 21)
        Me.CboCodProducto2.TabIndex = 64
        Me.CboCodProducto2.PropBag = resources.GetString("CboCodProducto2.PropBag")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Hasta"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Desde"
        '
        'CboProducto
        '
        Me.CboProducto.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboProducto.Caption = ""
        Me.CboProducto.CaptionHeight = 17
        Me.CboProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboProducto.ColumnCaptionHeight = 17
        Me.CboProducto.ColumnFooterHeight = 17
        Me.CboProducto.ContentHeight = 15
        Me.CboProducto.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboProducto.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboProducto.DropDownWidth = 300
        Me.CboProducto.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboProducto.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboProducto.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboProducto.EditorHeight = 15
        Me.CboProducto.Images.Add(CType(resources.GetObject("CboProducto.Images"), System.Drawing.Image))
        Me.CboProducto.ItemHeight = 15
        Me.CboProducto.Location = New System.Drawing.Point(61, 19)
        Me.CboProducto.MatchEntryTimeout = CType(2000, Long)
        Me.CboProducto.MaxDropDownItems = CType(5, Short)
        Me.CboProducto.MaxLength = 32767
        Me.CboProducto.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboProducto.Name = "CboProducto"
        Me.CboProducto.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboProducto.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboProducto.Size = New System.Drawing.Size(158, 21)
        Me.CboProducto.TabIndex = 61
        Me.CboProducto.PropBag = resources.GetString("CboProducto.PropBag")
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
        Me.C1Combo3.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.C1Combo3.DropDownWidth = 300
        Me.C1Combo3.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo3.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo3.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo3.EditorHeight = 15
        Me.C1Combo3.Images.Add(CType(resources.GetObject("C1Combo3.Images"), System.Drawing.Image))
        Me.C1Combo3.ItemHeight = 15
        Me.C1Combo3.Location = New System.Drawing.Point(61, 46)
        Me.C1Combo3.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo3.MaxDropDownItems = CType(5, Short)
        Me.C1Combo3.MaxLength = 32767
        Me.C1Combo3.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo3.Name = "C1Combo3"
        Me.C1Combo3.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo3.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo3.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo3.Size = New System.Drawing.Size(158, 21)
        Me.C1Combo3.TabIndex = 64
        Me.C1Combo3.PropBag = resources.GetString("C1Combo3.PropBag")
        '
        'GroupBoxNotas
        '
        Me.GroupBoxNotas.Controls.Add(Me.Button9)
        Me.GroupBoxNotas.Controls.Add(Me.Button10)
        Me.GroupBoxNotas.Controls.Add(Me.CmbNotas2)
        Me.GroupBoxNotas.Controls.Add(Me.Label15)
        Me.GroupBoxNotas.Controls.Add(Me.CmbNotas)
        Me.GroupBoxNotas.Controls.Add(Me.Label16)
        Me.GroupBoxNotas.Location = New System.Drawing.Point(820, 315)
        Me.GroupBoxNotas.Name = "GroupBoxNotas"
        Me.GroupBoxNotas.Size = New System.Drawing.Size(277, 85)
        Me.GroupBoxNotas.TabIndex = 202
        Me.GroupBoxNotas.TabStop = False
        Me.GroupBoxNotas.Text = "Rango Notas"
        '
        'Button9
        '
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.Location = New System.Drawing.Point(225, 46)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(37, 30)
        Me.Button9.TabIndex = 74
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.Location = New System.Drawing.Point(225, 10)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(37, 30)
        Me.Button10.TabIndex = 73
        Me.Button10.UseVisualStyleBackColor = True
        '
        'CmbNotas2
        '
        Me.CmbNotas2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbNotas2.Caption = ""
        Me.CmbNotas2.CaptionHeight = 17
        Me.CmbNotas2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbNotas2.ColumnCaptionHeight = 17
        Me.CmbNotas2.ColumnFooterHeight = 17
        Me.CmbNotas2.ContentHeight = 15
        Me.CmbNotas2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbNotas2.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbNotas2.DropDownWidth = 300
        Me.CmbNotas2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbNotas2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbNotas2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbNotas2.EditorHeight = 15
        Me.CmbNotas2.Images.Add(CType(resources.GetObject("CmbNotas2.Images"), System.Drawing.Image))
        Me.CmbNotas2.ItemHeight = 15
        Me.CmbNotas2.Location = New System.Drawing.Point(61, 46)
        Me.CmbNotas2.MatchEntryTimeout = CType(2000, Long)
        Me.CmbNotas2.MaxDropDownItems = CType(5, Short)
        Me.CmbNotas2.MaxLength = 32767
        Me.CmbNotas2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbNotas2.Name = "CmbNotas2"
        Me.CmbNotas2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbNotas2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbNotas2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbNotas2.Size = New System.Drawing.Size(158, 21)
        Me.CmbNotas2.TabIndex = 64
        Me.CmbNotas2.PropBag = resources.GetString("CmbNotas2.PropBag")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "Hasta"
        '
        'CmbNotas
        '
        Me.CmbNotas.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbNotas.Caption = ""
        Me.CmbNotas.CaptionHeight = 17
        Me.CmbNotas.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbNotas.ColumnCaptionHeight = 17
        Me.CmbNotas.ColumnFooterHeight = 17
        Me.CmbNotas.ContentHeight = 15
        Me.CmbNotas.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbNotas.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbNotas.DropDownWidth = 300
        Me.CmbNotas.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbNotas.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbNotas.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbNotas.EditorHeight = 15
        Me.CmbNotas.Images.Add(CType(resources.GetObject("CmbNotas.Images"), System.Drawing.Image))
        Me.CmbNotas.ItemHeight = 15
        Me.CmbNotas.Location = New System.Drawing.Point(61, 19)
        Me.CmbNotas.MatchEntryTimeout = CType(2000, Long)
        Me.CmbNotas.MaxDropDownItems = CType(5, Short)
        Me.CmbNotas.MaxLength = 32767
        Me.CmbNotas.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbNotas.Name = "CmbNotas"
        Me.CmbNotas.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbNotas.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbNotas.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbNotas.Size = New System.Drawing.Size(158, 21)
        Me.CmbNotas.TabIndex = 61
        Me.CmbNotas.PropBag = resources.GetString("CmbNotas.PropBag")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(17, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 63
        Me.Label16.Text = "Desde"
        '
        'GroupBoxLinea
        '
        Me.GroupBoxLinea.Controls.Add(Me.Button11)
        Me.GroupBoxLinea.Controls.Add(Me.Button12)
        Me.GroupBoxLinea.Controls.Add(Me.CboCodigoLinea2)
        Me.GroupBoxLinea.Controls.Add(Me.Label17)
        Me.GroupBoxLinea.Controls.Add(Me.CboCodigoLinea)
        Me.GroupBoxLinea.Controls.Add(Me.Label18)
        Me.GroupBoxLinea.Location = New System.Drawing.Point(1103, 12)
        Me.GroupBoxLinea.Name = "GroupBoxLinea"
        Me.GroupBoxLinea.Size = New System.Drawing.Size(278, 85)
        Me.GroupBoxLinea.TabIndex = 203
        Me.GroupBoxLinea.TabStop = False
        Me.GroupBoxLinea.Text = "Rango de Lineas"
        Me.GroupBoxLinea.Visible = False
        '
        'Button11
        '
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.Location = New System.Drawing.Point(225, 46)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(37, 30)
        Me.Button11.TabIndex = 68
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.Location = New System.Drawing.Point(225, 11)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(37, 30)
        Me.Button12.TabIndex = 67
        Me.Button12.UseVisualStyleBackColor = True
        '
        'CboCodigoLinea2
        '
        Me.CboCodigoLinea2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoLinea2.Caption = ""
        Me.CboCodigoLinea2.CaptionHeight = 17
        Me.CboCodigoLinea2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoLinea2.ColumnCaptionHeight = 17
        Me.CboCodigoLinea2.ColumnFooterHeight = 17
        Me.CboCodigoLinea2.ContentHeight = 15
        Me.CboCodigoLinea2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoLinea2.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoLinea2.DropDownWidth = 300
        Me.CboCodigoLinea2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoLinea2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoLinea2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoLinea2.EditorHeight = 15
        Me.CboCodigoLinea2.Images.Add(CType(resources.GetObject("CboCodigoLinea2.Images"), System.Drawing.Image))
        Me.CboCodigoLinea2.ItemHeight = 15
        Me.CboCodigoLinea2.Location = New System.Drawing.Point(61, 46)
        Me.CboCodigoLinea2.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoLinea2.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoLinea2.MaxLength = 32767
        Me.CboCodigoLinea2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoLinea2.Name = "CboCodigoLinea2"
        Me.CboCodigoLinea2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoLinea2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoLinea2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoLinea2.Size = New System.Drawing.Size(158, 21)
        Me.CboCodigoLinea2.TabIndex = 64
        Me.CboCodigoLinea2.PropBag = resources.GetString("CboCodigoLinea2.PropBag")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(20, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 66
        Me.Label17.Text = "Hasta"
        '
        'CboCodigoLinea
        '
        Me.CboCodigoLinea.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoLinea.Caption = ""
        Me.CboCodigoLinea.CaptionHeight = 17
        Me.CboCodigoLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoLinea.ColumnCaptionHeight = 17
        Me.CboCodigoLinea.ColumnFooterHeight = 17
        Me.CboCodigoLinea.ContentHeight = 15
        Me.CboCodigoLinea.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoLinea.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoLinea.DropDownWidth = 300
        Me.CboCodigoLinea.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoLinea.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoLinea.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoLinea.EditorHeight = 15
        Me.CboCodigoLinea.Images.Add(CType(resources.GetObject("CboCodigoLinea.Images"), System.Drawing.Image))
        Me.CboCodigoLinea.ItemHeight = 15
        Me.CboCodigoLinea.Location = New System.Drawing.Point(61, 18)
        Me.CboCodigoLinea.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoLinea.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoLinea.MaxLength = 32767
        Me.CboCodigoLinea.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoLinea.Name = "CboCodigoLinea"
        Me.CboCodigoLinea.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoLinea.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoLinea.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoLinea.Size = New System.Drawing.Size(158, 21)
        Me.CboCodigoLinea.TabIndex = 61
        Me.CboCodigoLinea.PropBag = resources.GetString("CboCodigoLinea.PropBag")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 63
        Me.Label18.Text = "Desde"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.AccessibleDescription = ""
        Me.ProgressBar1.Location = New System.Drawing.Point(289, 368)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(281, 17)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 204
        Me.ProgressBar1.Visible = False
        '
        'GroupBoxTipo
        '
        Me.GroupBoxTipo.Controls.Add(Me.CmbTipoHasta)
        Me.GroupBoxTipo.Controls.Add(Me.Label19)
        Me.GroupBoxTipo.Controls.Add(Me.CmbTipoDesde)
        Me.GroupBoxTipo.Controls.Add(Me.Label20)
        Me.GroupBoxTipo.Location = New System.Drawing.Point(820, 97)
        Me.GroupBoxTipo.Name = "GroupBoxTipo"
        Me.GroupBoxTipo.Size = New System.Drawing.Size(278, 85)
        Me.GroupBoxTipo.TabIndex = 205
        Me.GroupBoxTipo.TabStop = False
        Me.GroupBoxTipo.Text = "Rango por Tipo"
        Me.GroupBoxTipo.Visible = False
        '
        'CmbTipoHasta
        '
        Me.CmbTipoHasta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbTipoHasta.Caption = ""
        Me.CmbTipoHasta.CaptionHeight = 17
        Me.CmbTipoHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbTipoHasta.ColumnCaptionHeight = 17
        Me.CmbTipoHasta.ColumnFooterHeight = 17
        Me.CmbTipoHasta.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CmbTipoHasta.ContentHeight = 15
        Me.CmbTipoHasta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbTipoHasta.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbTipoHasta.DropDownWidth = 300
        Me.CmbTipoHasta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoHasta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipoHasta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbTipoHasta.EditorHeight = 15
        Me.CmbTipoHasta.Images.Add(CType(resources.GetObject("CmbTipoHasta.Images"), System.Drawing.Image))
        Me.CmbTipoHasta.ItemHeight = 15
        Me.CmbTipoHasta.Location = New System.Drawing.Point(61, 46)
        Me.CmbTipoHasta.MatchEntryTimeout = CType(2000, Long)
        Me.CmbTipoHasta.MaxDropDownItems = CType(5, Short)
        Me.CmbTipoHasta.MaxLength = 32767
        Me.CmbTipoHasta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbTipoHasta.Name = "CmbTipoHasta"
        Me.CmbTipoHasta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbTipoHasta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbTipoHasta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbTipoHasta.Size = New System.Drawing.Size(158, 21)
        Me.CmbTipoHasta.TabIndex = 64
        Me.CmbTipoHasta.PropBag = resources.GetString("CmbTipoHasta.PropBag")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(20, 46)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "Hasta"
        '
        'CmbTipoDesde
        '
        Me.CmbTipoDesde.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbTipoDesde.Caption = ""
        Me.CmbTipoDesde.CaptionHeight = 17
        Me.CmbTipoDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbTipoDesde.ColumnCaptionHeight = 17
        Me.CmbTipoDesde.ColumnFooterHeight = 17
        Me.CmbTipoDesde.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CmbTipoDesde.ContentHeight = 15
        Me.CmbTipoDesde.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbTipoDesde.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbTipoDesde.DropDownWidth = 300
        Me.CmbTipoDesde.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoDesde.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTipoDesde.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbTipoDesde.EditorHeight = 15
        Me.CmbTipoDesde.Images.Add(CType(resources.GetObject("CmbTipoDesde.Images"), System.Drawing.Image))
        Me.CmbTipoDesde.ItemHeight = 15
        Me.CmbTipoDesde.Location = New System.Drawing.Point(61, 18)
        Me.CmbTipoDesde.MatchEntryTimeout = CType(2000, Long)
        Me.CmbTipoDesde.MaxDropDownItems = CType(5, Short)
        Me.CmbTipoDesde.MaxLength = 32767
        Me.CmbTipoDesde.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbTipoDesde.Name = "CmbTipoDesde"
        Me.CmbTipoDesde.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbTipoDesde.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbTipoDesde.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbTipoDesde.Size = New System.Drawing.Size(158, 21)
        Me.CmbTipoDesde.TabIndex = 61
        Me.CmbTipoDesde.PropBag = resources.GetString("CmbTipoDesde.PropBag")
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(17, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 13)
        Me.Label20.TabIndex = 63
        Me.Label20.Text = "Desde"
        '
        'FrmReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 424)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.LblProcesando)
        Me.Controls.Add(Me.GroupClientes)
        Me.Controls.Add(Me.GroupVendedor)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBoxProductos)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListBox)
        Me.Controls.Add(Me.GroupBoxNotas)
        Me.Controls.Add(Me.GroupBoxLinea)
        Me.Controls.Add(Me.GroupBoxTipo)
        Me.Name = "FrmReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodigoProducto2X, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CmbRango2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbRango1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupClientes.ResumeLayout(False)
        Me.GroupClientes.PerformLayout()
        CType(Me.CmbClientes2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupVendedor.ResumeLayout(False)
        Me.GroupVendedor.PerformLayout()
        CType(Me.CmbVendedores2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Combo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxProductos.ResumeLayout(False)
        Me.GroupBoxProductos.PerformLayout()
        CType(Me.CboCodProducto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Combo3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxNotas.ResumeLayout(False)
        Me.GroupBoxNotas.PerformLayout()
        CType(Me.CmbNotas2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxLinea.ResumeLayout(False)
        Me.GroupBoxLinea.PerformLayout()
        CType(Me.CboCodigoLinea2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxTipo.ResumeLayout(False)
        Me.GroupBoxTipo.PerformLayout()
        CType(Me.CmbTipoHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbTipoDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ListBox As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbAgrupado As System.Windows.Forms.ComboBox
    Friend WithEvents CmbRango2 As C1.Win.C1List.C1Combo
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbRango1 As C1.Win.C1List.C1Combo
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ListaImagenes As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LblProcesando As System.Windows.Forms.Label
    Friend WithEvents GroupClientes As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CmbClientes2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbClientes As C1.Win.C1List.C1Combo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupVendedor As System.Windows.Forms.GroupBox
    Friend WithEvents CmbVendedores2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbVendedores As C1.Win.C1List.C1Combo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CodigoProducto2X As C1.Win.C1List.C1Combo
    Friend WithEvents CboCodProducto As C1.Win.C1List.C1Combo
    Friend WithEvents CmdClientes2 As System.Windows.Forms.Button
    Friend WithEvents CmdClientes1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptDolares As System.Windows.Forms.RadioButton
    Friend WithEvents OptCordobas As System.Windows.Forms.RadioButton
    Friend WithEvents C1Combo1 As C1.Win.C1List.C1Combo
    Friend WithEvents C1Combo2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxProductos As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CboCodProducto2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    'Friend WithEvents CboCodProducto As C1.Win.C1List.C1Combo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CboProducto As C1.Win.C1List.C1Combo
    Friend WithEvents C1Combo3 As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBoxNotas As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents CmbNotas2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CmbNotas As C1.Win.C1List.C1Combo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxLinea As System.Windows.Forms.GroupBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents CboCodigoLinea2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoLinea As C1.Win.C1List.C1Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBoxTipo As System.Windows.Forms.GroupBox
    Friend WithEvents CmbTipoHasta As C1.Win.C1List.C1Combo
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoDesde As C1.Win.C1List.C1Combo
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class
