<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventarioFisico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInventarioFisico))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTPFechaConteo = New System.Windows.Forms.DateTimePicker
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.CmdIniciar = New System.Windows.Forms.Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.BindingInventario = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Label2 = New System.Windows.Forms.Label
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.CmdImprimir = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TDBGridLotes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.DTPFechaLote = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.C1Button3 = New C1.Win.C1Input.C1Button
        Me.FrameTipo = New System.Windows.Forms.GroupBox
        Me.OptActualizaInv = New System.Windows.Forms.RadioButton
        Me.OptInventarioIni = New System.Windows.Forms.RadioButton
        Me.ChkProductos = New System.Windows.Forms.CheckBox
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtRuta = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.C1Button2 = New C1.Win.C1Input.C1Button
        Me.CmdLeer = New C1.Win.C1Input.C1Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.CmdNuevo = New System.Windows.Forms.Button
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.TDBGridLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.FrameTipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(16, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(72, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 117
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(237, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(229, 13)
        Me.Label9.TabIndex = 116
        Me.Label9.Text = "INVENTARIO FISICO DE PRODUCTOS"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(0, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(872, 60)
        Me.PictureBox1.TabIndex = 115
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Fecha de Conteo"
        '
        'DTPFechaConteo
        '
        Me.DTPFechaConteo.CustomFormat = ""
        Me.DTPFechaConteo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaConteo.Location = New System.Drawing.Point(108, 73)
        Me.DTPFechaConteo.Name = "DTPFechaConteo"
        Me.DTPFechaConteo.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaConteo.TabIndex = 119
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(765, 392)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(90, 74)
        Me.Button8.TabIndex = 120
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(161, 379)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 68)
        Me.Button1.TabIndex = 121
        Me.Button1.Tag = "28"
        Me.Button1.Text = "Procesar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CmdIniciar
        '
        Me.CmdIniciar.Image = CType(resources.GetObject("CmdIniciar.Image"), System.Drawing.Image)
        Me.CmdIniciar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdIniciar.Location = New System.Drawing.Point(674, 63)
        Me.CmdIniciar.Name = "CmdIniciar"
        Me.CmdIniciar.Size = New System.Drawing.Size(85, 42)
        Me.CmdIniciar.TabIndex = 122
        Me.CmdIniciar.Tag = "29"
        Me.CmdIniciar.Text = "Iniciar"
        Me.CmdIniciar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdIniciar.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(252, 392)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(507, 26)
        Me.ProgressBar.TabIndex = 123
        Me.ProgressBar.Visible = False
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "Tasa de Cambios"
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(6, 3)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(698, 222)
        Me.TrueDBGridConsultas.TabIndex = 129
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(237, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Bodega"
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
        Me.CboCodigoBodega.Location = New System.Drawing.Point(287, 73)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(198, 21)
        Me.CboCodigoBodega.TabIndex = 136
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(15, 379)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(72, 68)
        Me.CmdGrabar.TabIndex = 137
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Guardar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'CmdImprimir
        '
        Me.CmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdImprimir.Image = CType(resources.GetObject("CmdImprimir.Image"), System.Drawing.Image)
        Me.CmdImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdImprimir.Location = New System.Drawing.Point(93, 379)
        Me.CmdImprimir.Name = "CmdImprimir"
        Me.CmdImprimir.Size = New System.Drawing.Size(62, 66)
        Me.CmdImprimir.TabIndex = 188
        Me.CmdImprimir.Tag = "27"
        Me.CmdImprimir.Text = "Imprimir"
        Me.CmdImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdImprimir.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 111)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(747, 262)
        Me.TabControl1.TabIndex = 190
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TrueDBGridConsultas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(739, 236)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Inventario Fisico"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TDBGridLotes)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(739, 236)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Importacion Lotes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TDBGridLotes
        '
        Me.TDBGridLotes.AlternatingRows = True
        Me.TDBGridLotes.FilterBar = True
        Me.TDBGridLotes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDBGridLotes.Images.Add(CType(resources.GetObject("TDBGridLotes.Images"), System.Drawing.Image))
        Me.TDBGridLotes.Location = New System.Drawing.Point(8, 79)
        Me.TDBGridLotes.Name = "TDBGridLotes"
        Me.TDBGridLotes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDBGridLotes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDBGridLotes.PreviewInfo.ZoomFactor = 75
        Me.TDBGridLotes.PrintInfo.PageSettings = CType(resources.GetObject("TDBGridLotes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDBGridLotes.Size = New System.Drawing.Size(727, 147)
        Me.TDBGridLotes.TabIndex = 127
        Me.TDBGridLotes.Text = "C1TrueDBGrid1"
        Me.TDBGridLotes.PropBag = resources.GetString("TDBGridLotes.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.DTPFechaLote)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.C1Button1)
        Me.GroupBox2.Controls.Add(Me.C1Button3)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(725, 71)
        Me.GroupBox2.TabIndex = 126
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones de Importacion"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton4)
        Me.GroupBox3.Location = New System.Drawing.Point(222, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(158, 71)
        Me.GroupBox3.TabIndex = 124
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo Importacion"
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(17, 20)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(102, 17)
        Me.RadioButton4.TabIndex = 125
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Inventario Inicial"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'DTPFechaLote
        '
        Me.DTPFechaLote.CustomFormat = ""
        Me.DTPFechaLote.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaLote.Location = New System.Drawing.Point(103, 22)
        Me.DTPFechaLote.Name = "DTPFechaLote"
        Me.DTPFechaLote.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaLote.TabIndex = 122
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Fecha Compra"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(386, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(133, 20)
        Me.TextBox1.TabIndex = 110
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(393, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Ruta Base de Datos"
        '
        'C1Button1
        '
        Me.C1Button1.Image = CType(resources.GetObject("C1Button1.Image"), System.Drawing.Image)
        Me.C1Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button1.Location = New System.Drawing.Point(619, 12)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(88, 48)
        Me.C1Button1.TabIndex = 108
        Me.C1Button1.Tag = "28"
        Me.C1Button1.Text = "Procesar"
        Me.C1Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button3
        '
        Me.C1Button3.Image = CType(resources.GetObject("C1Button3.Image"), System.Drawing.Image)
        Me.C1Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button3.Location = New System.Drawing.Point(525, 12)
        Me.C1Button3.Name = "C1Button3"
        Me.C1Button3.Size = New System.Drawing.Size(88, 48)
        Me.C1Button3.TabIndex = 107
        Me.C1Button3.Tag = "25"
        Me.C1Button3.Text = "Leer Archivo"
        Me.C1Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button3.UseVisualStyleBackColor = True
        Me.C1Button3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'FrameTipo
        '
        Me.FrameTipo.Controls.Add(Me.OptActualizaInv)
        Me.FrameTipo.Controls.Add(Me.OptInventarioIni)
        Me.FrameTipo.Location = New System.Drawing.Point(222, 0)
        Me.FrameTipo.Name = "FrameTipo"
        Me.FrameTipo.Size = New System.Drawing.Size(158, 71)
        Me.FrameTipo.TabIndex = 124
        Me.FrameTipo.TabStop = False
        Me.FrameTipo.Text = "Tipo Importacion"
        '
        'OptActualizaInv
        '
        Me.OptActualizaInv.AutoSize = True
        Me.OptActualizaInv.Location = New System.Drawing.Point(17, 43)
        Me.OptActualizaInv.Name = "OptActualizaInv"
        Me.OptActualizaInv.Size = New System.Drawing.Size(121, 17)
        Me.OptActualizaInv.TabIndex = 126
        Me.OptActualizaInv.TabStop = True
        Me.OptActualizaInv.Text = "Actualizar Inventario"
        Me.OptActualizaInv.UseVisualStyleBackColor = True
        '
        'OptInventarioIni
        '
        Me.OptInventarioIni.AutoSize = True
        Me.OptInventarioIni.Checked = True
        Me.OptInventarioIni.Location = New System.Drawing.Point(17, 20)
        Me.OptInventarioIni.Name = "OptInventarioIni"
        Me.OptInventarioIni.Size = New System.Drawing.Size(102, 17)
        Me.OptInventarioIni.TabIndex = 125
        Me.OptInventarioIni.TabStop = True
        Me.OptInventarioIni.Text = "Inventario Inicial"
        Me.OptInventarioIni.UseVisualStyleBackColor = True
        '
        'ChkProductos
        '
        Me.ChkProductos.AutoSize = True
        Me.ChkProductos.Location = New System.Drawing.Point(24, 45)
        Me.ChkProductos.Name = "ChkProductos"
        Me.ChkProductos.Size = New System.Drawing.Size(139, 17)
        Me.ChkProductos.TabIndex = 123
        Me.ChkProductos.Text = "Solo Importar Productos"
        Me.ChkProductos.UseVisualStyleBackColor = True
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(103, 22)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 122
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Fecha Compra"
        '
        'TxtRuta
        '
        Me.TxtRuta.Enabled = False
        Me.TxtRuta.Location = New System.Drawing.Point(386, 33)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.Size = New System.Drawing.Size(286, 20)
        Me.TxtRuta.TabIndex = 110
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(393, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Ruta Base de Datos"
        '
        'C1Button2
        '
        Me.C1Button2.Image = CType(resources.GetObject("C1Button2.Image"), System.Drawing.Image)
        Me.C1Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button2.Location = New System.Drawing.Point(772, 14)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(88, 48)
        Me.C1Button2.TabIndex = 108
        Me.C1Button2.Tag = "28"
        Me.C1Button2.Text = "Procesar"
        Me.C1Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button2.UseVisualStyleBackColor = True
        Me.C1Button2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CmdLeer
        '
        Me.CmdLeer.Image = CType(resources.GetObject("CmdLeer.Image"), System.Drawing.Image)
        Me.CmdLeer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdLeer.Location = New System.Drawing.Point(678, 14)
        Me.CmdLeer.Name = "CmdLeer"
        Me.CmdLeer.Size = New System.Drawing.Size(88, 48)
        Me.CmdLeer.TabIndex = 107
        Me.CmdLeer.Tag = "25"
        Me.CmdLeer.Text = "Leer Archivo"
        Me.CmdLeer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdLeer.UseVisualStyleBackColor = True
        Me.CmdLeer.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdNuevo.Location = New System.Drawing.Point(765, 133)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(90, 71)
        Me.CmdNuevo.TabIndex = 230
        Me.CmdNuevo.Text = "Bascula"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        Me.CmdNuevo.Visible = False
        '
        'FrmInventarioFisico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 464)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdImprimir)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.CmdIniciar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.DTPFechaConteo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmInventarioFisico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmInventarioFisico"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingInventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.TDBGridLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.FrameTipo.ResumeLayout(False)
        Me.FrameTipo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaConteo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmdIniciar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents BindingInventario As System.Windows.Forms.BindingSource
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents CmdImprimir As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents FrameTipo As System.Windows.Forms.GroupBox
    Friend WithEvents OptActualizaInv As System.Windows.Forms.RadioButton
    Friend WithEvents OptInventarioIni As System.Windows.Forms.RadioButton
    Friend WithEvents ChkProductos As System.Windows.Forms.CheckBox
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdLeer As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents DTPFechaLote As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button3 As C1.Win.C1Input.C1Button
    Friend WithEvents TDBGridLotes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
End Class
