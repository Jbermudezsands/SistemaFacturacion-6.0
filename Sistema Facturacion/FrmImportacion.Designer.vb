<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportacion))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TrueDBGridClientes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.OptProveedores = New System.Windows.Forms.RadioButton
        Me.OptClientes = New System.Windows.Forms.RadioButton
        Me.TxtRutaClientes = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.C1Button3 = New C1.Win.C1Input.C1Button
        Me.C1Button4 = New C1.Win.C1Input.C1Button
        Me.TrueDBGridPrecios = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.C1Button5 = New C1.Win.C1Input.C1Button
        Me.TDGridCtasXCobrar = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.LblMoneda = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbSerie = New C1.Win.C1List.C1Combo
        Me.ChkImportarSaldos = New System.Windows.Forms.CheckBox
        Me.BtnLeerCtaxCob = New C1.Win.C1Input.C1Button
        Me.DtpFechaCtasXCobrar = New System.Windows.Forms.DateTimePicker
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.OptCtasxCobrar = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtRutaCtaxCobrar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnProcesarCtaxCob = New C1.Win.C1Input.C1Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkLotes = New System.Windows.Forms.CheckBox
        Me.FrameTipo = New System.Windows.Forms.GroupBox
        Me.OptActualizaInv = New System.Windows.Forms.RadioButton
        Me.OptInventarioIni = New System.Windows.Forms.RadioButton
        Me.ChkProductos = New System.Windows.Forms.CheckBox
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtRuta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.C1Button2 = New C1.Win.C1Input.C1Button
        Me.CmdLeer = New C1.Win.C1Input.C1Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.TxtRutaContratos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.C1Button6 = New C1.Win.C1Input.C1Button
        Me.C1Button7 = New C1.Win.C1Input.C1Button
        Me.TrueDBGridContratos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrueDBGridPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TDGridCtasXCobrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.FrameTipo.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.TrueDBGridContratos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(9, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(70, 57)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(326, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(195, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "IMPORTACION DE PRODUCTOS"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(955, 57)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(6, 83)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(903, 279)
        Me.TrueDBGridConsultas.TabIndex = 107
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'TrueDBGridClientes
        '
        Me.TrueDBGridClientes.AllowUpdate = False
        Me.TrueDBGridClientes.AlternatingRows = True
        Me.TrueDBGridClientes.FilterBar = True
        Me.TrueDBGridClientes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridClientes.Images.Add(CType(resources.GetObject("TrueDBGridClientes.Images"), System.Drawing.Image))
        Me.TrueDBGridClientes.Location = New System.Drawing.Point(6, 92)
        Me.TrueDBGridClientes.Name = "TrueDBGridClientes"
        Me.TrueDBGridClientes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridClientes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridClientes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridClientes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridClientes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridClientes.Size = New System.Drawing.Size(892, 267)
        Me.TrueDBGridClientes.TabIndex = 125
        Me.TrueDBGridClientes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridClientes.PropBag = resources.GetString("TrueDBGridClientes.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.TxtRutaClientes)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.C1Button3)
        Me.GroupBox2.Controls.Add(Me.C1Button4)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(876, 80)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.OptProveedores)
        Me.GroupBox3.Controls.Add(Me.OptClientes)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(158, 71)
        Me.GroupBox3.TabIndex = 125
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo Importacion"
        '
        'OptProveedores
        '
        Me.OptProveedores.AutoSize = True
        Me.OptProveedores.Location = New System.Drawing.Point(17, 43)
        Me.OptProveedores.Name = "OptProveedores"
        Me.OptProveedores.Size = New System.Drawing.Size(85, 17)
        Me.OptProveedores.TabIndex = 126
        Me.OptProveedores.TabStop = True
        Me.OptProveedores.Text = "Proveedores"
        Me.OptProveedores.UseVisualStyleBackColor = True
        '
        'OptClientes
        '
        Me.OptClientes.AutoSize = True
        Me.OptClientes.Checked = True
        Me.OptClientes.Location = New System.Drawing.Point(17, 20)
        Me.OptClientes.Name = "OptClientes"
        Me.OptClientes.Size = New System.Drawing.Size(62, 17)
        Me.OptClientes.TabIndex = 125
        Me.OptClientes.TabStop = True
        Me.OptClientes.Text = "Clientes"
        Me.OptClientes.UseVisualStyleBackColor = True
        '
        'TxtRutaClientes
        '
        Me.TxtRutaClientes.Enabled = False
        Me.TxtRutaClientes.Location = New System.Drawing.Point(187, 33)
        Me.TxtRutaClientes.Name = "TxtRutaClientes"
        Me.TxtRutaClientes.Size = New System.Drawing.Size(485, 20)
        Me.TxtRutaClientes.TabIndex = 110
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(193, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Ruta Base de Datos"
        '
        'C1Button3
        '
        Me.C1Button3.Image = CType(resources.GetObject("C1Button3.Image"), System.Drawing.Image)
        Me.C1Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button3.Location = New System.Drawing.Point(772, 14)
        Me.C1Button3.Name = "C1Button3"
        Me.C1Button3.Size = New System.Drawing.Size(88, 48)
        Me.C1Button3.TabIndex = 108
        Me.C1Button3.Tag = "28"
        Me.C1Button3.Text = "Procesar"
        Me.C1Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button3.UseVisualStyleBackColor = True
        Me.C1Button3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button4
        '
        Me.C1Button4.Image = CType(resources.GetObject("C1Button4.Image"), System.Drawing.Image)
        Me.C1Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button4.Location = New System.Drawing.Point(678, 14)
        Me.C1Button4.Name = "C1Button4"
        Me.C1Button4.Size = New System.Drawing.Size(88, 48)
        Me.C1Button4.TabIndex = 107
        Me.C1Button4.Tag = "25"
        Me.C1Button4.Text = "Leer Archivo"
        Me.C1Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button4.UseVisualStyleBackColor = True
        Me.C1Button4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TrueDBGridPrecios
        '
        Me.TrueDBGridPrecios.AllowUpdate = False
        Me.TrueDBGridPrecios.AlternatingRows = True
        Me.TrueDBGridPrecios.FilterBar = True
        Me.TrueDBGridPrecios.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridPrecios.Images.Add(CType(resources.GetObject("TrueDBGridPrecios.Images"), System.Drawing.Image))
        Me.TrueDBGridPrecios.Location = New System.Drawing.Point(9, 89)
        Me.TrueDBGridPrecios.Name = "TrueDBGridPrecios"
        Me.TrueDBGridPrecios.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridPrecios.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridPrecios.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridPrecios.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridPrecios.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridPrecios.Size = New System.Drawing.Size(892, 267)
        Me.TrueDBGridPrecios.TabIndex = 127
        Me.TrueDBGridPrecios.Text = "C1TrueDBGrid1"
        Me.TrueDBGridPrecios.PropBag = resources.GetString("TrueDBGridPrecios.PropBag")
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.C1Button1)
        Me.GroupBox5.Controls.Add(Me.C1Button5)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(876, 80)
        Me.GroupBox5.TabIndex = 126
        Me.GroupBox5.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButton2)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(158, 71)
        Me.GroupBox4.TabIndex = 126
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo Importacion"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(11, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(60, 17)
        Me.RadioButton2.TabIndex = 125
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Precios"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(187, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(485, 20)
        Me.TextBox1.TabIndex = 110
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Ruta de Archivos"
        '
        'C1Button1
        '
        Me.C1Button1.Image = CType(resources.GetObject("C1Button1.Image"), System.Drawing.Image)
        Me.C1Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button1.Location = New System.Drawing.Point(772, 14)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(88, 48)
        Me.C1Button1.TabIndex = 108
        Me.C1Button1.Tag = "28"
        Me.C1Button1.Text = "Procesar"
        Me.C1Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button5
        '
        Me.C1Button5.Image = CType(resources.GetObject("C1Button5.Image"), System.Drawing.Image)
        Me.C1Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button5.Location = New System.Drawing.Point(678, 14)
        Me.C1Button5.Name = "C1Button5"
        Me.C1Button5.Size = New System.Drawing.Size(88, 48)
        Me.C1Button5.TabIndex = 107
        Me.C1Button5.Tag = "25"
        Me.C1Button5.Text = "Leer Archivo"
        Me.C1Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button5.UseVisualStyleBackColor = True
        Me.C1Button5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TDGridCtasXCobrar
        '
        Me.TDGridCtasXCobrar.AllowUpdate = False
        Me.TDGridCtasXCobrar.AlternatingRows = True
        Me.TDGridCtasXCobrar.FilterBar = True
        Me.TDGridCtasXCobrar.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridCtasXCobrar.Images.Add(CType(resources.GetObject("TDGridCtasXCobrar.Images"), System.Drawing.Image))
        Me.TDGridCtasXCobrar.Location = New System.Drawing.Point(9, 89)
        Me.TDGridCtasXCobrar.Name = "TDGridCtasXCobrar"
        Me.TDGridCtasXCobrar.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridCtasXCobrar.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridCtasXCobrar.PreviewInfo.ZoomFactor = 75
        Me.TDGridCtasXCobrar.PrintInfo.PageSettings = CType(resources.GetObject("TDGridCtasXCobrar.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridCtasXCobrar.Size = New System.Drawing.Size(892, 267)
        Me.TDGridCtasXCobrar.TabIndex = 128
        Me.TDGridCtasXCobrar.Text = "C1TrueDBGrid1"
        Me.TDGridCtasXCobrar.PropBag = resources.GetString("TDGridCtasXCobrar.PropBag")
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.LblMoneda)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.CmbSerie)
        Me.GroupBox6.Controls.Add(Me.ChkImportarSaldos)
        Me.GroupBox6.Controls.Add(Me.BtnLeerCtaxCob)
        Me.GroupBox6.Controls.Add(Me.DtpFechaCtasXCobrar)
        Me.GroupBox6.Controls.Add(Me.GroupBox7)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.TxtRutaCtaxCobrar)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.BtnProcesarCtaxCob)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(876, 80)
        Me.GroupBox6.TabIndex = 127
        Me.GroupBox6.TabStop = False
        '
        'LblMoneda
        '
        Me.LblMoneda.AutoSize = True
        Me.LblMoneda.ForeColor = System.Drawing.Color.Navy
        Me.LblMoneda.Location = New System.Drawing.Point(395, 58)
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Size = New System.Drawing.Size(52, 13)
        Me.LblMoneda.TabIndex = 217
        Me.LblMoneda.Text = "Cordobas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(302, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 216
        Me.Label7.Text = "SERIE"
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
        Me.CmbSerie.Location = New System.Drawing.Point(343, 52)
        Me.CmbSerie.MatchEntryTimeout = CType(2000, Long)
        Me.CmbSerie.MaxDropDownItems = CType(5, Short)
        Me.CmbSerie.MaxLength = 32767
        Me.CmbSerie.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbSerie.Name = "CmbSerie"
        Me.CmbSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbSerie.Size = New System.Drawing.Size(43, 21)
        Me.CmbSerie.TabIndex = 215
        Me.CmbSerie.Visible = False
        Me.CmbSerie.PropBag = resources.GetString("CmbSerie.PropBag")
        '
        'ChkImportarSaldos
        '
        Me.ChkImportarSaldos.AutoSize = True
        Me.ChkImportarSaldos.Checked = True
        Me.ChkImportarSaldos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkImportarSaldos.Enabled = False
        Me.ChkImportarSaldos.Location = New System.Drawing.Point(173, 56)
        Me.ChkImportarSaldos.Name = "ChkImportarSaldos"
        Me.ChkImportarSaldos.Size = New System.Drawing.Size(123, 17)
        Me.ChkImportarSaldos.TabIndex = 128
        Me.ChkImportarSaldos.Text = "Solo Importar Saldos"
        Me.ChkImportarSaldos.UseVisualStyleBackColor = True
        '
        'BtnLeerCtaxCob
        '
        Me.BtnLeerCtaxCob.Image = CType(resources.GetObject("BtnLeerCtaxCob.Image"), System.Drawing.Image)
        Me.BtnLeerCtaxCob.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnLeerCtaxCob.Location = New System.Drawing.Point(678, 14)
        Me.BtnLeerCtaxCob.Name = "BtnLeerCtaxCob"
        Me.BtnLeerCtaxCob.Size = New System.Drawing.Size(88, 48)
        Me.BtnLeerCtaxCob.TabIndex = 127
        Me.BtnLeerCtaxCob.Tag = "25"
        Me.BtnLeerCtaxCob.Text = "Leer Archivo"
        Me.BtnLeerCtaxCob.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnLeerCtaxCob.UseVisualStyleBackColor = True
        Me.BtnLeerCtaxCob.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'DtpFechaCtasXCobrar
        '
        Me.DtpFechaCtasXCobrar.CustomFormat = ""
        Me.DtpFechaCtasXCobrar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaCtasXCobrar.Location = New System.Drawing.Point(173, 30)
        Me.DtpFechaCtasXCobrar.Name = "DtpFechaCtasXCobrar"
        Me.DtpFechaCtasXCobrar.Size = New System.Drawing.Size(104, 20)
        Me.DtpFechaCtasXCobrar.TabIndex = 127
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.OptCtasxCobrar)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(158, 71)
        Me.GroupBox7.TabIndex = 126
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tipo Importacion"
        '
        'OptCtasxCobrar
        '
        Me.OptCtasxCobrar.AutoSize = True
        Me.OptCtasxCobrar.Checked = True
        Me.OptCtasxCobrar.Location = New System.Drawing.Point(11, 17)
        Me.OptCtasxCobrar.Name = "OptCtasxCobrar"
        Me.OptCtasxCobrar.Size = New System.Drawing.Size(106, 17)
        Me.OptCtasxCobrar.TabIndex = 125
        Me.OptCtasxCobrar.TabStop = True
        Me.OptCtasxCobrar.Text = "Cuentas x Cobrar"
        Me.OptCtasxCobrar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(170, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "Fecha Compra"
        '
        'TxtRutaCtaxCobrar
        '
        Me.TxtRutaCtaxCobrar.Enabled = False
        Me.TxtRutaCtaxCobrar.Location = New System.Drawing.Point(302, 26)
        Me.TxtRutaCtaxCobrar.Name = "TxtRutaCtaxCobrar"
        Me.TxtRutaCtaxCobrar.Size = New System.Drawing.Size(370, 20)
        Me.TxtRutaCtaxCobrar.TabIndex = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(299, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Ruta de Archivos"
        '
        'BtnProcesarCtaxCob
        '
        Me.BtnProcesarCtaxCob.Image = CType(resources.GetObject("BtnProcesarCtaxCob.Image"), System.Drawing.Image)
        Me.BtnProcesarCtaxCob.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnProcesarCtaxCob.Location = New System.Drawing.Point(772, 14)
        Me.BtnProcesarCtaxCob.Name = "BtnProcesarCtaxCob"
        Me.BtnProcesarCtaxCob.Size = New System.Drawing.Size(88, 48)
        Me.BtnProcesarCtaxCob.TabIndex = 108
        Me.BtnProcesarCtaxCob.Tag = "28"
        Me.BtnProcesarCtaxCob.Text = "Procesar"
        Me.BtnProcesarCtaxCob.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnProcesarCtaxCob.UseVisualStyleBackColor = True
        Me.BtnProcesarCtaxCob.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(9, 459)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(682, 23)
        Me.ProgressBar.TabIndex = 109
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(9, 61)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(926, 392)
        Me.TabControl1.TabIndex = 110
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TrueDBGridConsultas)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(918, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Imp Inventario Inicial"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkLotes)
        Me.GroupBox1.Controls.Add(Me.FrameTipo)
        Me.GroupBox1.Controls.Add(Me.ChkProductos)
        Me.GroupBox1.Controls.Add(Me.DTPFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtRuta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.C1Button2)
        Me.GroupBox1.Controls.Add(Me.CmdLeer)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(876, 71)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones de Importacion"
        '
        'ChkLotes
        '
        Me.ChkLotes.AutoSize = True
        Me.ChkLotes.Enabled = False
        Me.ChkLotes.Location = New System.Drawing.Point(387, 50)
        Me.ChkLotes.Name = "ChkLotes"
        Me.ChkLotes.Size = New System.Drawing.Size(114, 17)
        Me.ChkLotes.TabIndex = 125
        Me.ChkLotes.Text = "Importar con Lotes"
        Me.ChkLotes.UseVisualStyleBackColor = True
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Fecha Compra"
        '
        'TxtRuta
        '
        Me.TxtRuta.Enabled = False
        Me.TxtRuta.Location = New System.Drawing.Point(386, 27)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.Size = New System.Drawing.Size(286, 20)
        Me.TxtRuta.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Ruta Base de Datos"
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
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TrueDBGridClientes)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(918, 366)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Imp Clientes/Proveedores"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TrueDBGridPrecios)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(918, 366)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Precios"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.TDGridCtasXCobrar)
        Me.TabPage4.Controls.Add(Me.GroupBox6)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(918, 366)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Ctas x Cobrar"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.TxtRutaContratos)
        Me.TabPage5.Controls.Add(Me.Label8)
        Me.TabPage5.Controls.Add(Me.C1Button6)
        Me.TabPage5.Controls.Add(Me.C1Button7)
        Me.TabPage5.Controls.Add(Me.TrueDBGridContratos)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(918, 366)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Contratos"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TxtRutaContratos
        '
        Me.TxtRutaContratos.Enabled = False
        Me.TxtRutaContratos.Location = New System.Drawing.Point(6, 44)
        Me.TxtRutaContratos.Name = "TxtRutaContratos"
        Me.TxtRutaContratos.Size = New System.Drawing.Size(667, 20)
        Me.TxtRutaContratos.TabIndex = 132
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Ruta de Archivos"
        '
        'C1Button6
        '
        Me.C1Button6.Image = CType(resources.GetObject("C1Button6.Image"), System.Drawing.Image)
        Me.C1Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button6.Location = New System.Drawing.Point(773, 25)
        Me.C1Button6.Name = "C1Button6"
        Me.C1Button6.Size = New System.Drawing.Size(88, 48)
        Me.C1Button6.TabIndex = 130
        Me.C1Button6.Tag = "28"
        Me.C1Button6.Text = "Procesar"
        Me.C1Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button6.UseVisualStyleBackColor = True
        Me.C1Button6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button7
        '
        Me.C1Button7.Image = CType(resources.GetObject("C1Button7.Image"), System.Drawing.Image)
        Me.C1Button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button7.Location = New System.Drawing.Point(679, 25)
        Me.C1Button7.Name = "C1Button7"
        Me.C1Button7.Size = New System.Drawing.Size(88, 48)
        Me.C1Button7.TabIndex = 129
        Me.C1Button7.Tag = "25"
        Me.C1Button7.Text = "Leer Archivo"
        Me.C1Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.C1Button7.UseVisualStyleBackColor = True
        Me.C1Button7.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TrueDBGridContratos
        '
        Me.TrueDBGridContratos.AllowUpdate = False
        Me.TrueDBGridContratos.AlternatingRows = True
        Me.TrueDBGridContratos.FilterBar = True
        Me.TrueDBGridContratos.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridContratos.Images.Add(CType(resources.GetObject("TrueDBGridContratos.Images"), System.Drawing.Image))
        Me.TrueDBGridContratos.Location = New System.Drawing.Point(6, 91)
        Me.TrueDBGridContratos.Name = "TrueDBGridContratos"
        Me.TrueDBGridContratos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridContratos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridContratos.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridContratos.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridContratos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridContratos.Size = New System.Drawing.Size(892, 267)
        Me.TrueDBGridContratos.TabIndex = 128
        Me.TrueDBGridContratos.Text = "C1TrueDBGrid1"
        Me.TrueDBGridContratos.PropBag = resources.GetString("TrueDBGridContratos.PropBag")
        '
        'FrmImportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 488)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmImportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmImportacion"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrueDBGridPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TDGridCtasXCobrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FrameTipo.ResumeLayout(False)
        Me.FrameTipo.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.TrueDBGridContratos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    'Friend WithEvents DefaultToolTipController1 As DevExpress.Utils.DefaultToolTipController
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRutaClientes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents C1Button3 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button4 As C1.Win.C1Input.C1Button
    Friend WithEvents TrueDBGridClientes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button5 As C1.Win.C1Input.C1Button
    Friend WithEvents TrueDBGridPrecios As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents OptCtasxCobrar As System.Windows.Forms.RadioButton
    Friend WithEvents TxtRutaCtaxCobrar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnProcesarCtaxCob As C1.Win.C1Input.C1Button
    Friend WithEvents BtnLeerCtaxCob As C1.Win.C1Input.C1Button
    Friend WithEvents TDGridCtasXCobrar As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ChkImportarSaldos As System.Windows.Forms.CheckBox
    Friend WithEvents DtpFechaCtasXCobrar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents LblMoneda As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FrameTipo As System.Windows.Forms.GroupBox
    Friend WithEvents OptActualizaInv As System.Windows.Forms.RadioButton
    Friend WithEvents OptInventarioIni As System.Windows.Forms.RadioButton
    Friend WithEvents ChkProductos As System.Windows.Forms.CheckBox
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdLeer As C1.Win.C1Input.C1Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptProveedores As System.Windows.Forms.RadioButton
    Friend WithEvents OptClientes As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TrueDBGridContratos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtRutaContratos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents C1Button6 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button7 As C1.Win.C1Input.C1Button
    Friend WithEvents ChkLotes As System.Windows.Forms.CheckBox
End Class
