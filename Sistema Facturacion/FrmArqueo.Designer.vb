<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArqueo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArqueo))
        Me.TxtCajero = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTFecha = New System.Windows.Forms.DateTimePicker
        Me.CmdIniciar = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TdbGridCordobas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TdbGridDolares = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtSubTotalCordobas = New System.Windows.Forms.TextBox
        Me.TxtSumaFacturaDolares = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSubTotalDolares = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TdbGridChequeCordobas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TdbGridChequeDolares = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtCordobasDolares = New System.Windows.Forms.TextBox
        Me.TxtValorFacturas = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtDiferencia = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TxtTotalChequeCordobas = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtTotalChequeDolares = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtObservaciones = New System.Windows.Forms.TextBox
        Me.TxtPracticadoPor = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.CboCajero = New C1.Win.C1List.C1Combo
        Me.LblCajero = New System.Windows.Forms.Label
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.BindingDetalleCordobas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalleDolares = New System.Windows.Forms.BindingSource(Me.components)
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.BindingDetalleChequeDolares = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalleChequeCordobas = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtSumaFacturaCordobas = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.BtnProcesar = New System.Windows.Forms.Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TdbGridCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TdbGridDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TdbGridChequeCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TdbGridChequeDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleChequeDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleChequeCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCajero
        '
        Me.TxtCajero.Enabled = False
        Me.TxtCajero.Location = New System.Drawing.Point(366, 74)
        Me.TxtCajero.Name = "TxtCajero"
        Me.TxtCajero.Size = New System.Drawing.Size(214, 20)
        Me.TxtCajero.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(266, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre del Cajero"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(645, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha"
        '
        'DTFecha
        '
        Me.DTFecha.CustomFormat = "dd/MM/yyyy  hh:mm:ss"
        Me.DTFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTFecha.Location = New System.Drawing.Point(688, 74)
        Me.DTFecha.Name = "DTFecha"
        Me.DTFecha.Size = New System.Drawing.Size(143, 20)
        Me.DTFecha.TabIndex = 4
        '
        'CmdIniciar
        '
        Me.CmdIniciar.Image = CType(resources.GetObject("CmdIniciar.Image"), System.Drawing.Image)
        Me.CmdIniciar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdIniciar.Location = New System.Drawing.Point(1052, 62)
        Me.CmdIniciar.Name = "CmdIniciar"
        Me.CmdIniciar.Size = New System.Drawing.Size(75, 45)
        Me.CmdIniciar.TabIndex = 123
        Me.CmdIniciar.Text = "Iniciar"
        Me.CmdIniciar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdIniciar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(537, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 13)
        Me.Label9.TabIndex = 126
        Me.Label9.Text = "ARQUEO DE CAJAS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(10, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(79, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 125
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1242, 60)
        Me.PictureBox1.TabIndex = 124
        Me.PictureBox1.TabStop = False
        '
        'TdbGridCordobas
        '
        Me.TdbGridCordobas.AlternatingRows = True
        Me.TdbGridCordobas.Caption = "DETALLE EFECTIVO CORDOBAS"
        Me.TdbGridCordobas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TdbGridCordobas.Images.Add(CType(resources.GetObject("TdbGridCordobas.Images"), System.Drawing.Image))
        Me.TdbGridCordobas.Location = New System.Drawing.Point(13, 110)
        Me.TdbGridCordobas.Name = "TdbGridCordobas"
        Me.TdbGridCordobas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbGridCordobas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbGridCordobas.PreviewInfo.ZoomFactor = 75
        Me.TdbGridCordobas.PrintInfo.PageSettings = CType(resources.GetObject("TdbGridCordobas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TdbGridCordobas.Size = New System.Drawing.Size(257, 248)
        Me.TdbGridCordobas.TabIndex = 215
        Me.TdbGridCordobas.Text = "C1TrueDBGrid1"
        Me.TdbGridCordobas.PropBag = resources.GetString("TdbGridCordobas.PropBag")
        '
        'TdbGridDolares
        '
        Me.TdbGridDolares.AlternatingRows = True
        Me.TdbGridDolares.Caption = "DETALLE EFECTIVO DOLARES"
        Me.TdbGridDolares.GroupByCaption = "Drag a column header here to group by that column"
        Me.TdbGridDolares.Images.Add(CType(resources.GetObject("TdbGridDolares.Images"), System.Drawing.Image))
        Me.TdbGridDolares.Location = New System.Drawing.Point(277, 110)
        Me.TdbGridDolares.Name = "TdbGridDolares"
        Me.TdbGridDolares.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbGridDolares.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbGridDolares.PreviewInfo.ZoomFactor = 75
        Me.TdbGridDolares.PrintInfo.PageSettings = CType(resources.GetObject("TdbGridDolares.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TdbGridDolares.Size = New System.Drawing.Size(257, 249)
        Me.TdbGridDolares.TabIndex = 216
        Me.TdbGridDolares.Text = "C1TrueDBGrid1"
        Me.TdbGridDolares.PropBag = resources.GetString("TdbGridDolares.PropBag")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(143, 362)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 217
        Me.Label3.Text = "SubTotal"
        '
        'TxtSubTotalCordobas
        '
        Me.TxtSubTotalCordobas.BackColor = System.Drawing.Color.White
        Me.TxtSubTotalCordobas.ForeColor = System.Drawing.Color.Black
        Me.TxtSubTotalCordobas.Location = New System.Drawing.Point(210, 361)
        Me.TxtSubTotalCordobas.Name = "TxtSubTotalCordobas"
        Me.TxtSubTotalCordobas.Size = New System.Drawing.Size(60, 20)
        Me.TxtSubTotalCordobas.TabIndex = 218
        Me.TxtSubTotalCordobas.Text = "0.00"
        Me.TxtSubTotalCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSumaFacturaDolares
        '
        Me.TxtSumaFacturaDolares.BackColor = System.Drawing.Color.White
        Me.TxtSumaFacturaDolares.Location = New System.Drawing.Point(1059, 361)
        Me.TxtSumaFacturaDolares.Name = "TxtSumaFacturaDolares"
        Me.TxtSumaFacturaDolares.Size = New System.Drawing.Size(67, 20)
        Me.TxtSumaFacturaDolares.TabIndex = 220
        Me.TxtSumaFacturaDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(956, 368)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 219
        Me.Label4.Text = "Sum Fact/Rec $"
        '
        'TxtSubTotalDolares
        '
        Me.TxtSubTotalDolares.BackColor = System.Drawing.Color.White
        Me.TxtSubTotalDolares.Location = New System.Drawing.Point(471, 361)
        Me.TxtSubTotalDolares.Name = "TxtSubTotalDolares"
        Me.TxtSubTotalDolares.Size = New System.Drawing.Size(61, 20)
        Me.TxtSubTotalDolares.TabIndex = 222
        Me.TxtSubTotalDolares.Text = "0.00"
        Me.TxtSubTotalDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(406, 365)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 221
        Me.Label5.Text = "SubTotal $"
        '
        'TdbGridChequeCordobas
        '
        Me.TdbGridChequeCordobas.AlternatingRows = True
        Me.TdbGridChequeCordobas.Caption = "DETALLE CHEQUE/TARJETAS CORDOBAS"
        Me.TdbGridChequeCordobas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TdbGridChequeCordobas.Images.Add(CType(resources.GetObject("TdbGridChequeCordobas.Images"), System.Drawing.Image))
        Me.TdbGridChequeCordobas.Location = New System.Drawing.Point(540, 110)
        Me.TdbGridChequeCordobas.Name = "TdbGridChequeCordobas"
        Me.TdbGridChequeCordobas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbGridChequeCordobas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbGridChequeCordobas.PreviewInfo.ZoomFactor = 75
        Me.TdbGridChequeCordobas.PrintInfo.PageSettings = CType(resources.GetObject("TdbGridChequeCordobas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TdbGridChequeCordobas.Size = New System.Drawing.Size(291, 249)
        Me.TdbGridChequeCordobas.TabIndex = 223
        Me.TdbGridChequeCordobas.Text = "C1TrueDBGrid1"
        Me.TdbGridChequeCordobas.PropBag = resources.GetString("TdbGridChequeCordobas.PropBag")
        '
        'TdbGridChequeDolares
        '
        Me.TdbGridChequeDolares.AlternatingRows = True
        Me.TdbGridChequeDolares.Caption = "DETALLE CHEQUE/TARJETAS DOLARES"
        Me.TdbGridChequeDolares.GroupByCaption = "Drag a column header here to group by that column"
        Me.TdbGridChequeDolares.Images.Add(CType(resources.GetObject("TdbGridChequeDolares.Images"), System.Drawing.Image))
        Me.TdbGridChequeDolares.Location = New System.Drawing.Point(835, 110)
        Me.TdbGridChequeDolares.Name = "TdbGridChequeDolares"
        Me.TdbGridChequeDolares.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbGridChequeDolares.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbGridChequeDolares.PreviewInfo.ZoomFactor = 75
        Me.TdbGridChequeDolares.PrintInfo.PageSettings = CType(resources.GetObject("TdbGridChequeDolares.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TdbGridChequeDolares.Size = New System.Drawing.Size(291, 248)
        Me.TdbGridChequeDolares.TabIndex = 224
        Me.TdbGridChequeDolares.Text = "C1TrueDBGrid1"
        Me.TdbGridChequeDolares.PropBag = resources.GetString("TdbGridChequeDolares.PropBag")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(927, 422)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 225
        Me.Label6.Text = "Total Cord y Dolares"
        '
        'TxtCordobasDolares
        '
        Me.TxtCordobasDolares.BackColor = System.Drawing.Color.White
        Me.TxtCordobasDolares.Location = New System.Drawing.Point(1036, 419)
        Me.TxtCordobasDolares.Name = "TxtCordobasDolares"
        Me.TxtCordobasDolares.Size = New System.Drawing.Size(90, 20)
        Me.TxtCordobasDolares.TabIndex = 226
        Me.TxtCordobasDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtValorFacturas
        '
        Me.TxtValorFacturas.BackColor = System.Drawing.Color.White
        Me.TxtValorFacturas.Location = New System.Drawing.Point(1036, 443)
        Me.TxtValorFacturas.Name = "TxtValorFacturas"
        Me.TxtValorFacturas.Size = New System.Drawing.Size(90, 20)
        Me.TxtValorFacturas.TabIndex = 228
        Me.TxtValorFacturas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(940, 446)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 227
        Me.Label7.Text = "MontoRecibidos"
        '
        'TxtDiferencia
        '
        Me.TxtDiferencia.BackColor = System.Drawing.Color.White
        Me.TxtDiferencia.Location = New System.Drawing.Point(1036, 467)
        Me.TxtDiferencia.Name = "TxtDiferencia"
        Me.TxtDiferencia.Size = New System.Drawing.Size(90, 20)
        Me.TxtDiferencia.TabIndex = 230
        Me.TxtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(975, 470)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 229
        Me.Label8.Text = "Diferencia"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(1144, 182)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 66)
        Me.Button2.TabIndex = 231
        Me.Button2.Tag = "27"
        Me.Button2.Text = "Imprimir"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtTotalChequeCordobas
        '
        Me.TxtTotalChequeCordobas.BackColor = System.Drawing.Color.White
        Me.TxtTotalChequeCordobas.Location = New System.Drawing.Point(737, 394)
        Me.TxtTotalChequeCordobas.Name = "TxtTotalChequeCordobas"
        Me.TxtTotalChequeCordobas.Size = New System.Drawing.Size(90, 20)
        Me.TxtTotalChequeCordobas.TabIndex = 233
        Me.TxtTotalChequeCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(617, 396)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 13)
        Me.Label10.TabIndex = 232
        Me.Label10.Text = "Total Cheq mas Tarjetas"
        '
        'TxtTotalChequeDolares
        '
        Me.TxtTotalChequeDolares.BackColor = System.Drawing.Color.White
        Me.TxtTotalChequeDolares.Location = New System.Drawing.Point(1054, 394)
        Me.TxtTotalChequeDolares.Name = "TxtTotalChequeDolares"
        Me.TxtTotalChequeDolares.Size = New System.Drawing.Size(73, 20)
        Me.TxtTotalChequeDolares.TabIndex = 237
        Me.TxtTotalChequeDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(989, 396)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 236
        Me.Label11.Text = "SubTotal $"
        '
        'TextBox10
        '
        Me.TextBox10.BackColor = System.Drawing.Color.White
        Me.TextBox10.Location = New System.Drawing.Point(908, 394)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(68, 20)
        Me.TextBox10.TabIndex = 235
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(836, 396)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 234
        Me.Label12.Text = "SubTotal C$"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 404)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 238
        Me.Label13.Text = "Observaciones"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtObservaciones.Location = New System.Drawing.Point(13, 420)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(257, 59)
        Me.TxtObservaciones.TabIndex = 239
        '
        'TxtPracticadoPor
        '
        Me.TxtPracticadoPor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPracticadoPor.Location = New System.Drawing.Point(280, 458)
        Me.TxtPracticadoPor.Name = "TxtPracticadoPor"
        Me.TxtPracticadoPor.Size = New System.Drawing.Size(107, 20)
        Me.TxtPracticadoPor.TabIndex = 241
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(285, 442)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 240
        Me.Label14.Text = "Arqueado Por"
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
        Me.CboCajero.Location = New System.Drawing.Point(78, 73)
        Me.CboCajero.MatchEntryTimeout = CType(2000, Long)
        Me.CboCajero.MaxDropDownItems = CType(5, Short)
        Me.CboCajero.MaxLength = 32767
        Me.CboCajero.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCajero.Name = "CboCajero"
        Me.CboCajero.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCajero.Size = New System.Drawing.Size(160, 21)
        Me.CboCajero.TabIndex = 243
        Me.CboCajero.PropBag = resources.GetString("CboCajero.PropBag")
        '
        'LblCajero
        '
        Me.LblCajero.AutoSize = True
        Me.LblCajero.Location = New System.Drawing.Point(26, 78)
        Me.LblCajero.Name = "LblCajero"
        Me.LblCajero.Size = New System.Drawing.Size(37, 13)
        Me.LblCajero.TabIndex = 242
        Me.LblCajero.Text = "Cajero"
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(911, 75)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(76, 20)
        Me.TxtNumeroEnsamble.TabIndex = 245
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(861, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 244
        Me.Label15.Text = "Numero"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(993, 63)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 32)
        Me.Button6.TabIndex = 246
        Me.Button6.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(1144, 115)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(75, 65)
        Me.CmdGrabar.TabIndex = 247
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'TxtSumaFacturaCordobas
        '
        Me.TxtSumaFacturaCordobas.BackColor = System.Drawing.Color.White
        Me.TxtSumaFacturaCordobas.ForeColor = System.Drawing.Color.Black
        Me.TxtSumaFacturaCordobas.Location = New System.Drawing.Point(759, 361)
        Me.TxtSumaFacturaCordobas.Name = "TxtSumaFacturaCordobas"
        Me.TxtSumaFacturaCordobas.Size = New System.Drawing.Size(72, 20)
        Me.TxtSumaFacturaCordobas.TabIndex = 249
        Me.TxtSumaFacturaCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(660, 364)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 13)
        Me.Label16.TabIndex = 248
        Me.Label16.Text = "Sum Fact/Rec C$"
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(1144, 419)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(75, 66)
        Me.BtnSalir.TabIndex = 251
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnProcesar
        '
        Me.BtnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnProcesar.Location = New System.Drawing.Point(1144, 251)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Size = New System.Drawing.Size(75, 66)
        Me.BtnProcesar.TabIndex = 252
        Me.BtnProcesar.Tag = "28"
        Me.BtnProcesar.Text = "Procesar"
        Me.BtnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnProcesar.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(468, 463)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(434, 23)
        Me.ProgressBar.TabIndex = 253
        '
        'FrmArqueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1236, 505)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.BtnProcesar)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.TxtSumaFacturaCordobas)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TxtNumeroEnsamble)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CboCajero)
        Me.Controls.Add(Me.LblCajero)
        Me.Controls.Add(Me.TxtPracticadoPor)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtObservaciones)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtTotalChequeDolares)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtTotalChequeCordobas)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TxtDiferencia)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtValorFacturas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtCordobasDolares)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TdbGridChequeDolares)
        Me.Controls.Add(Me.TdbGridChequeCordobas)
        Me.Controls.Add(Me.TxtSubTotalDolares)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtSumaFacturaDolares)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtSubTotalCordobas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TdbGridDolares)
        Me.Controls.Add(Me.TdbGridCordobas)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmdIniciar)
        Me.Controls.Add(Me.DTFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCajero)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmArqueo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmArqueo"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TdbGridCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TdbGridDolares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TdbGridChequeCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TdbGridChequeDolares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleDolares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleChequeDolares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleChequeCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCajero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmdIniciar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TdbGridCordobas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TdbGridDolares As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotalCordobas As System.Windows.Forms.TextBox
    Friend WithEvents TxtSumaFacturaDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotalDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TdbGridChequeCordobas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TdbGridChequeDolares As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCordobasDolares As System.Windows.Forms.TextBox
    Friend WithEvents TxtValorFacturas As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtTotalChequeCordobas As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalChequeDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TxtPracticadoPor As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CboCajero As C1.Win.C1List.C1Combo
    Friend WithEvents LblCajero As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents BindingDetalleCordobas As System.Windows.Forms.BindingSource
    Friend WithEvents BindingDetalleDolares As System.Windows.Forms.BindingSource
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents BindingDetalleChequeDolares As System.Windows.Forms.BindingSource
    Friend WithEvents BindingDetalleChequeCordobas As System.Windows.Forms.BindingSource
    Friend WithEvents TxtSumaFacturaCordobas As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnProcesar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
End Class
