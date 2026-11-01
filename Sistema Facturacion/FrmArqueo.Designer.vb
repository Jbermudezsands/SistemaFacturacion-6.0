<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArqueo
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento.
    'Solo contiene asignaciones de propiedades (sin bucles) para que el diseñador lo abra sin problemas.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArqueo))
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblNumeroArqueo = New System.Windows.Forms.Label()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlDatos = New System.Windows.Forms.Panel()
        Me.BtnIniciar = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtNumeroArqueo = New System.Windows.Forms.TextBox()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.TxtFondoApertura = New System.Windows.Forms.TextBox()
        Me.LblFondo = New System.Windows.Forms.Label()
        Me.DTFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.CboCajero = New System.Windows.Forms.ComboBox()
        Me.LblCajero = New System.Windows.Forms.Label()
        Me.TdbGridCordobas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TdbGridDolares = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TdbGridChequeCordobas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TdbGridChequeDolares = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.LblSubTotalCordobas = New System.Windows.Forms.Label()
        Me.TxtSubTotalCordobas = New System.Windows.Forms.TextBox()
        Me.LblSubTotalDolares = New System.Windows.Forms.Label()
        Me.TxtSubTotalDolares = New System.Windows.Forms.TextBox()
        Me.LblChequeCordobas = New System.Windows.Forms.Label()
        Me.TxtTotalChequeCordobas = New System.Windows.Forms.TextBox()
        Me.LblChequeDolares = New System.Windows.Forms.Label()
        Me.TxtTotalChequeDolares = New System.Windows.Forms.TextBox()
        Me.PnlCierre = New System.Windows.Forms.Panel()
        Me.TxtPracticadoPor = New System.Windows.Forms.TextBox()
        Me.LblPracticadoPor = New System.Windows.Forms.Label()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.LblTituloCierre = New System.Windows.Forms.Label()
        Me.PnlResumen = New System.Windows.Forms.Panel()
        Me.TxtDiferencia = New System.Windows.Forms.TextBox()
        Me.LblDiferencia = New System.Windows.Forms.Label()
        Me.TxtValorFacturas = New System.Windows.Forms.TextBox()
        Me.LblTotalEsperado = New System.Windows.Forms.Label()
        Me.TxtCordobasDolares = New System.Windows.Forms.TextBox()
        Me.LblTotalContado = New System.Windows.Forms.Label()
        Me.TxtTasaCambio = New System.Windows.Forms.TextBox()
        Me.LblTasa = New System.Windows.Forms.Label()
        Me.TxtSumaFacturaDolares = New System.Windows.Forms.TextBox()
        Me.LblEsperadoDolares = New System.Windows.Forms.Label()
        Me.TxtSumaFacturaCordobas = New System.Windows.Forms.TextBox()
        Me.LblEsperadoCordobas = New System.Windows.Forms.Label()
        Me.LblTituloResumen = New System.Windows.Forms.Label()
        Me.PnlAcciones = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.BindingDetalleCordobas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalleDolares = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalleChequeCordobas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalleChequeDolares = New System.Windows.Forms.BindingSource(Me.components)
        Me.PnlHeader.SuspendLayout()
        Me.PnlDatos.SuspendLayout()
        CType(Me.TdbGridCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TdbGridDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TdbGridChequeCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TdbGridChequeDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlCierre.SuspendLayout()
        Me.PnlResumen.SuspendLayout()
        Me.PnlAcciones.SuspendLayout()
        CType(Me.BindingDetalleCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleChequeCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleChequeDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.LblNumeroArqueo)
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.LblTitulo)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(1100, 64)
        Me.PnlHeader.TabIndex = 0
        '
        'LblNumeroArqueo
        '
        Me.LblNumeroArqueo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNumeroArqueo.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumeroArqueo.ForeColor = System.Drawing.Color.White
        Me.LblNumeroArqueo.Location = New System.Drawing.Point(660, 20)
        Me.LblNumeroArqueo.Name = "LblNumeroArqueo"
        Me.LblNumeroArqueo.Size = New System.Drawing.Size(424, 24)
        Me.LblNumeroArqueo.TabIndex = 2
        Me.LblNumeroArqueo.Text = "Arqueo Nº —"
        Me.LblNumeroArqueo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(18, 38)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(250, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Conteo de efectivo, cheques y tarjetas del cajero"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(14, 6)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(150, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Arqueo de caja"
        '
        'PnlDatos
        '
        Me.PnlDatos.BackColor = System.Drawing.Color.White
        Me.PnlDatos.Controls.Add(Me.BtnIniciar)
        Me.PnlDatos.Controls.Add(Me.BtnBuscar)
        Me.PnlDatos.Controls.Add(Me.TxtNumeroArqueo)
        Me.PnlDatos.Controls.Add(Me.LblNumero)
        Me.PnlDatos.Controls.Add(Me.TxtFondoApertura)
        Me.PnlDatos.Controls.Add(Me.LblFondo)
        Me.PnlDatos.Controls.Add(Me.DTFecha)
        Me.PnlDatos.Controls.Add(Me.LblFecha)
        Me.PnlDatos.Controls.Add(Me.CboCajero)
        Me.PnlDatos.Controls.Add(Me.LblCajero)
        Me.PnlDatos.Location = New System.Drawing.Point(16, 76)
        Me.PnlDatos.Name = "PnlDatos"
        Me.PnlDatos.Size = New System.Drawing.Size(1068, 72)
        Me.PnlDatos.TabIndex = 1
        '
        'LblCajero
        '
        Me.LblCajero.AutoSize = True
        Me.LblCajero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblCajero.Location = New System.Drawing.Point(16, 12)
        Me.LblCajero.Name = "LblCajero"
        Me.LblCajero.Size = New System.Drawing.Size(41, 15)
        Me.LblCajero.TabIndex = 0
        Me.LblCajero.Text = "Cajero"
        '
        'CboCajero
        '
        Me.CboCajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboCajero.FormattingEnabled = True
        Me.CboCajero.Location = New System.Drawing.Point(16, 34)
        Me.CboCajero.Name = "CboCajero"
        Me.CboCajero.Size = New System.Drawing.Size(300, 23)
        Me.CboCajero.TabIndex = 1
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblFecha.Location = New System.Drawing.Point(332, 12)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(38, 15)
        Me.LblFecha.TabIndex = 2
        Me.LblFecha.Text = "Fecha"
        '
        'DTFecha
        '
        Me.DTFecha.CustomFormat = "dd/MM/yyyy"
        Me.DTFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTFecha.Location = New System.Drawing.Point(332, 34)
        Me.DTFecha.Name = "DTFecha"
        Me.DTFecha.Size = New System.Drawing.Size(130, 23)
        Me.DTFecha.TabIndex = 3
        '
        'LblFondo
        '
        Me.LblFondo.AutoSize = True
        Me.LblFondo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblFondo.Location = New System.Drawing.Point(478, 12)
        Me.LblFondo.Name = "LblFondo"
        Me.LblFondo.Size = New System.Drawing.Size(99, 15)
        Me.LblFondo.TabIndex = 4
        Me.LblFondo.Text = "Fondo apertura C$"
        '
        'TxtFondoApertura
        '
        Me.TxtFondoApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFondoApertura.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFondoApertura.Location = New System.Drawing.Point(478, 34)
        Me.TxtFondoApertura.Name = "TxtFondoApertura"
        Me.TxtFondoApertura.Size = New System.Drawing.Size(120, 23)
        Me.TxtFondoApertura.TabIndex = 5
        Me.TxtFondoApertura.Text = "0.00"
        Me.TxtFondoApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblNumero.Location = New System.Drawing.Point(614, 12)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(66, 15)
        Me.LblNumero.TabIndex = 6
        Me.LblNumero.Text = "Nº de arqueo"
        '
        'TxtNumeroArqueo
        '
        Me.TxtNumeroArqueo.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtNumeroArqueo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumeroArqueo.Location = New System.Drawing.Point(614, 34)
        Me.TxtNumeroArqueo.Name = "TxtNumeroArqueo"
        Me.TxtNumeroArqueo.ReadOnly = True
        Me.TxtNumeroArqueo.Size = New System.Drawing.Size(90, 23)
        Me.TxtNumeroArqueo.TabIndex = 7
        Me.TxtNumeroArqueo.TabStop = False
        Me.TxtNumeroArqueo.Text = "-----0-----"
        Me.TxtNumeroArqueo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscar.FlatAppearance.BorderSize = 0
        Me.BtnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscar.Location = New System.Drawing.Point(710, 33)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(34, 25)
        Me.BtnBuscar.TabIndex = 8
        Me.BtnBuscar.TabStop = False
        Me.BtnBuscar.Text = "..."
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnIniciar
        '
        Me.BtnIniciar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.BtnIniciar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIniciar.FlatAppearance.BorderSize = 0
        Me.BtnIniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BtnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnIniciar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIniciar.ForeColor = System.Drawing.Color.White
        Me.BtnIniciar.Location = New System.Drawing.Point(768, 28)
        Me.BtnIniciar.Name = "BtnIniciar"
        Me.BtnIniciar.Size = New System.Drawing.Size(130, 36)
        Me.BtnIniciar.TabIndex = 9
        Me.BtnIniciar.Text = "Iniciar arqueo"
        Me.BtnIniciar.UseVisualStyleBackColor = False
        '
        'TdbGridCordobas
        '
        Me.TdbGridCordobas.AlternatingRows = True
        Me.TdbGridCordobas.Caption = "EFECTIVO CORDOBAS"
        Me.TdbGridCordobas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TdbGridCordobas.Images.Add(CType(resources.GetObject("TdbGridCordobas.Images"), System.Drawing.Image))
        Me.TdbGridCordobas.Location = New System.Drawing.Point(16, 160)
        Me.TdbGridCordobas.Name = "TdbGridCordobas"
        Me.TdbGridCordobas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbGridCordobas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbGridCordobas.PreviewInfo.ZoomFactor = 75.0R
        Me.TdbGridCordobas.PrintInfo.PageSettings = CType(resources.GetObject("TdbGridCordobas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TdbGridCordobas.Size = New System.Drawing.Size(252, 200)
        Me.TdbGridCordobas.TabIndex = 2
        Me.TdbGridCordobas.Text = "C1TrueDBGrid1"
        Me.TdbGridCordobas.PropBag = resources.GetString("TdbGridCordobas.PropBag")
        '
        'TdbGridDolares
        '
        Me.TdbGridDolares.AlternatingRows = True
        Me.TdbGridDolares.Caption = "EFECTIVO DOLARES"
        Me.TdbGridDolares.GroupByCaption = "Drag a column header here to group by that column"
        Me.TdbGridDolares.Images.Add(CType(resources.GetObject("TdbGridDolares.Images"), System.Drawing.Image))
        Me.TdbGridDolares.Location = New System.Drawing.Point(276, 160)
        Me.TdbGridDolares.Name = "TdbGridDolares"
        Me.TdbGridDolares.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbGridDolares.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbGridDolares.PreviewInfo.ZoomFactor = 75.0R
        Me.TdbGridDolares.PrintInfo.PageSettings = CType(resources.GetObject("TdbGridDolares.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TdbGridDolares.Size = New System.Drawing.Size(252, 200)
        Me.TdbGridDolares.TabIndex = 3
        Me.TdbGridDolares.Text = "C1TrueDBGrid1"
        Me.TdbGridDolares.PropBag = resources.GetString("TdbGridDolares.PropBag")
        '
        'TdbGridChequeCordobas
        '
        Me.TdbGridChequeCordobas.AlternatingRows = True
        Me.TdbGridChequeCordobas.Caption = "CHEQUES / TARJETAS CORDOBAS"
        Me.TdbGridChequeCordobas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TdbGridChequeCordobas.Images.Add(CType(resources.GetObject("TdbGridChequeCordobas.Images"), System.Drawing.Image))
        Me.TdbGridChequeCordobas.Location = New System.Drawing.Point(536, 160)
        Me.TdbGridChequeCordobas.Name = "TdbGridChequeCordobas"
        Me.TdbGridChequeCordobas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbGridChequeCordobas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbGridChequeCordobas.PreviewInfo.ZoomFactor = 75.0R
        Me.TdbGridChequeCordobas.PrintInfo.PageSettings = CType(resources.GetObject("TdbGridChequeCordobas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TdbGridChequeCordobas.Size = New System.Drawing.Size(282, 200)
        Me.TdbGridChequeCordobas.TabIndex = 4
        Me.TdbGridChequeCordobas.Text = "C1TrueDBGrid1"
        Me.TdbGridChequeCordobas.PropBag = resources.GetString("TdbGridChequeCordobas.PropBag")
        '
        'TdbGridChequeDolares
        '
        Me.TdbGridChequeDolares.AlternatingRows = True
        Me.TdbGridChequeDolares.Caption = "CHEQUES / TARJETAS DOLARES"
        Me.TdbGridChequeDolares.GroupByCaption = "Drag a column header here to group by that column"
        Me.TdbGridChequeDolares.Images.Add(CType(resources.GetObject("TdbGridChequeDolares.Images"), System.Drawing.Image))
        Me.TdbGridChequeDolares.Location = New System.Drawing.Point(826, 160)
        Me.TdbGridChequeDolares.Name = "TdbGridChequeDolares"
        Me.TdbGridChequeDolares.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbGridChequeDolares.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbGridChequeDolares.PreviewInfo.ZoomFactor = 75.0R
        Me.TdbGridChequeDolares.PrintInfo.PageSettings = CType(resources.GetObject("TdbGridChequeDolares.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TdbGridChequeDolares.Size = New System.Drawing.Size(258, 200)
        Me.TdbGridChequeDolares.TabIndex = 5
        Me.TdbGridChequeDolares.Text = "C1TrueDBGrid1"
        Me.TdbGridChequeDolares.PropBag = resources.GetString("TdbGridChequeDolares.PropBag")
        '
        'LblSubTotalCordobas
        '
        Me.LblSubTotalCordobas.AutoSize = True
        Me.LblSubTotalCordobas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblSubTotalCordobas.Location = New System.Drawing.Point(16, 369)
        Me.LblSubTotalCordobas.Name = "LblSubTotalCordobas"
        Me.LblSubTotalCordobas.Size = New System.Drawing.Size(67, 15)
        Me.LblSubTotalCordobas.TabIndex = 6
        Me.LblSubTotalCordobas.Text = "Subtotal C$"
        '
        'TxtSubTotalCordobas
        '
        Me.TxtSubTotalCordobas.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtSubTotalCordobas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSubTotalCordobas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotalCordobas.Location = New System.Drawing.Point(158, 366)
        Me.TxtSubTotalCordobas.Name = "TxtSubTotalCordobas"
        Me.TxtSubTotalCordobas.ReadOnly = True
        Me.TxtSubTotalCordobas.Size = New System.Drawing.Size(110, 23)
        Me.TxtSubTotalCordobas.TabIndex = 7
        Me.TxtSubTotalCordobas.TabStop = False
        Me.TxtSubTotalCordobas.Text = "0.00"
        Me.TxtSubTotalCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSubTotalDolares
        '
        Me.LblSubTotalDolares.AutoSize = True
        Me.LblSubTotalDolares.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblSubTotalDolares.Location = New System.Drawing.Point(276, 369)
        Me.LblSubTotalDolares.Name = "LblSubTotalDolares"
        Me.LblSubTotalDolares.Size = New System.Drawing.Size(73, 15)
        Me.LblSubTotalDolares.TabIndex = 8
        Me.LblSubTotalDolares.Text = "Subtotal US$"
        '
        'TxtSubTotalDolares
        '
        Me.TxtSubTotalDolares.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtSubTotalDolares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSubTotalDolares.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotalDolares.Location = New System.Drawing.Point(418, 366)
        Me.TxtSubTotalDolares.Name = "TxtSubTotalDolares"
        Me.TxtSubTotalDolares.ReadOnly = True
        Me.TxtSubTotalDolares.Size = New System.Drawing.Size(110, 23)
        Me.TxtSubTotalDolares.TabIndex = 9
        Me.TxtSubTotalDolares.TabStop = False
        Me.TxtSubTotalDolares.Text = "0.00"
        Me.TxtSubTotalDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblChequeCordobas
        '
        Me.LblChequeCordobas.AutoSize = True
        Me.LblChequeCordobas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblChequeCordobas.Location = New System.Drawing.Point(536, 369)
        Me.LblChequeCordobas.Name = "LblChequeCordobas"
        Me.LblChequeCordobas.Size = New System.Drawing.Size(115, 15)
        Me.LblChequeCordobas.TabIndex = 10
        Me.LblChequeCordobas.Text = "Total cheq./tarj. C$"
        '
        'TxtTotalChequeCordobas
        '
        Me.TxtTotalChequeCordobas.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtTotalChequeCordobas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalChequeCordobas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalChequeCordobas.Location = New System.Drawing.Point(708, 366)
        Me.TxtTotalChequeCordobas.Name = "TxtTotalChequeCordobas"
        Me.TxtTotalChequeCordobas.ReadOnly = True
        Me.TxtTotalChequeCordobas.Size = New System.Drawing.Size(110, 23)
        Me.TxtTotalChequeCordobas.TabIndex = 11
        Me.TxtTotalChequeCordobas.TabStop = False
        Me.TxtTotalChequeCordobas.Text = "0.00"
        Me.TxtTotalChequeCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblChequeDolares
        '
        Me.LblChequeDolares.AutoSize = True
        Me.LblChequeDolares.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblChequeDolares.Location = New System.Drawing.Point(826, 369)
        Me.LblChequeDolares.Name = "LblChequeDolares"
        Me.LblChequeDolares.Size = New System.Drawing.Size(121, 15)
        Me.LblChequeDolares.TabIndex = 12
        Me.LblChequeDolares.Text = "Total cheq./tarj. US$"
        '
        'TxtTotalChequeDolares
        '
        Me.TxtTotalChequeDolares.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtTotalChequeDolares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalChequeDolares.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalChequeDolares.Location = New System.Drawing.Point(974, 366)
        Me.TxtTotalChequeDolares.Name = "TxtTotalChequeDolares"
        Me.TxtTotalChequeDolares.ReadOnly = True
        Me.TxtTotalChequeDolares.Size = New System.Drawing.Size(110, 23)
        Me.TxtTotalChequeDolares.TabIndex = 13
        Me.TxtTotalChequeDolares.TabStop = False
        Me.TxtTotalChequeDolares.Text = "0.00"
        Me.TxtTotalChequeDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PnlCierre
        '
        Me.PnlCierre.BackColor = System.Drawing.Color.White
        Me.PnlCierre.Controls.Add(Me.TxtPracticadoPor)
        Me.PnlCierre.Controls.Add(Me.LblPracticadoPor)
        Me.PnlCierre.Controls.Add(Me.TxtObservaciones)
        Me.PnlCierre.Controls.Add(Me.LblObservaciones)
        Me.PnlCierre.Controls.Add(Me.LblTituloCierre)
        Me.PnlCierre.Location = New System.Drawing.Point(16, 398)
        Me.PnlCierre.Name = "PnlCierre"
        Me.PnlCierre.Size = New System.Drawing.Size(520, 190)
        Me.PnlCierre.TabIndex = 14
        '
        'LblTituloCierre
        '
        Me.LblTituloCierre.AutoSize = True
        Me.LblTituloCierre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloCierre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloCierre.Location = New System.Drawing.Point(14, 10)
        Me.LblTituloCierre.Name = "LblTituloCierre"
        Me.LblTituloCierre.Size = New System.Drawing.Size(103, 17)
        Me.LblTituloCierre.TabIndex = 0
        Me.LblTituloCierre.Text = "Cierre del arqueo"
        '
        'LblObservaciones
        '
        Me.LblObservaciones.AutoSize = True
        Me.LblObservaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblObservaciones.Location = New System.Drawing.Point(16, 38)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(80, 15)
        Me.LblObservaciones.TabIndex = 1
        Me.LblObservaciones.Text = "Observaciones"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtObservaciones.Location = New System.Drawing.Point(16, 58)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(488, 66)
        Me.TxtObservaciones.TabIndex = 2
        '
        'LblPracticadoPor
        '
        Me.LblPracticadoPor.AutoSize = True
        Me.LblPracticadoPor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblPracticadoPor.Location = New System.Drawing.Point(16, 132)
        Me.LblPracticadoPor.Name = "LblPracticadoPor"
        Me.LblPracticadoPor.Size = New System.Drawing.Size(76, 15)
        Me.LblPracticadoPor.TabIndex = 3
        Me.LblPracticadoPor.Text = "Arqueado por"
        '
        'TxtPracticadoPor
        '
        Me.TxtPracticadoPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPracticadoPor.Location = New System.Drawing.Point(16, 152)
        Me.TxtPracticadoPor.MaxLength = 100
        Me.TxtPracticadoPor.Name = "TxtPracticadoPor"
        Me.TxtPracticadoPor.Size = New System.Drawing.Size(488, 23)
        Me.TxtPracticadoPor.TabIndex = 4
        '
        'PnlResumen
        '
        Me.PnlResumen.BackColor = System.Drawing.Color.White
        Me.PnlResumen.Controls.Add(Me.TxtDiferencia)
        Me.PnlResumen.Controls.Add(Me.LblDiferencia)
        Me.PnlResumen.Controls.Add(Me.TxtValorFacturas)
        Me.PnlResumen.Controls.Add(Me.LblTotalEsperado)
        Me.PnlResumen.Controls.Add(Me.TxtCordobasDolares)
        Me.PnlResumen.Controls.Add(Me.LblTotalContado)
        Me.PnlResumen.Controls.Add(Me.TxtTasaCambio)
        Me.PnlResumen.Controls.Add(Me.LblTasa)
        Me.PnlResumen.Controls.Add(Me.TxtSumaFacturaDolares)
        Me.PnlResumen.Controls.Add(Me.LblEsperadoDolares)
        Me.PnlResumen.Controls.Add(Me.TxtSumaFacturaCordobas)
        Me.PnlResumen.Controls.Add(Me.LblEsperadoCordobas)
        Me.PnlResumen.Controls.Add(Me.LblTituloResumen)
        Me.PnlResumen.Location = New System.Drawing.Point(544, 398)
        Me.PnlResumen.Name = "PnlResumen"
        Me.PnlResumen.Size = New System.Drawing.Size(540, 190)
        Me.PnlResumen.TabIndex = 15
        '
        'LblTituloResumen
        '
        Me.LblTituloResumen.AutoSize = True
        Me.LblTituloResumen.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloResumen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloResumen.Location = New System.Drawing.Point(14, 10)
        Me.LblTituloResumen.Name = "LblTituloResumen"
        Me.LblTituloResumen.Size = New System.Drawing.Size(122, 17)
        Me.LblTituloResumen.TabIndex = 0
        Me.LblTituloResumen.Text = "Resumen del arqueo"
        '
        'LblEsperadoCordobas
        '
        Me.LblEsperadoCordobas.AutoSize = True
        Me.LblEsperadoCordobas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblEsperadoCordobas.Location = New System.Drawing.Point(16, 41)
        Me.LblEsperadoCordobas.Name = "LblEsperadoCordobas"
        Me.LblEsperadoCordobas.Size = New System.Drawing.Size(240, 15)
        Me.LblEsperadoCordobas.TabIndex = 1
        Me.LblEsperadoCordobas.Text = "Efectivo esperado C$ (facturas + recibos)"
        '
        'TxtSumaFacturaCordobas
        '
        Me.TxtSumaFacturaCordobas.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtSumaFacturaCordobas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSumaFacturaCordobas.Location = New System.Drawing.Point(372, 38)
        Me.TxtSumaFacturaCordobas.Name = "TxtSumaFacturaCordobas"
        Me.TxtSumaFacturaCordobas.ReadOnly = True
        Me.TxtSumaFacturaCordobas.Size = New System.Drawing.Size(144, 23)
        Me.TxtSumaFacturaCordobas.TabIndex = 2
        Me.TxtSumaFacturaCordobas.TabStop = False
        Me.TxtSumaFacturaCordobas.Text = "0.00"
        Me.TxtSumaFacturaCordobas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblEsperadoDolares
        '
        Me.LblEsperadoDolares.AutoSize = True
        Me.LblEsperadoDolares.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblEsperadoDolares.Location = New System.Drawing.Point(16, 66)
        Me.LblEsperadoDolares.Name = "LblEsperadoDolares"
        Me.LblEsperadoDolares.Size = New System.Drawing.Size(246, 15)
        Me.LblEsperadoDolares.TabIndex = 3
        Me.LblEsperadoDolares.Text = "Efectivo esperado US$ (facturas + recibos)"
        '
        'TxtSumaFacturaDolares
        '
        Me.TxtSumaFacturaDolares.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtSumaFacturaDolares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSumaFacturaDolares.Location = New System.Drawing.Point(372, 63)
        Me.TxtSumaFacturaDolares.Name = "TxtSumaFacturaDolares"
        Me.TxtSumaFacturaDolares.ReadOnly = True
        Me.TxtSumaFacturaDolares.Size = New System.Drawing.Size(144, 23)
        Me.TxtSumaFacturaDolares.TabIndex = 4
        Me.TxtSumaFacturaDolares.TabStop = False
        Me.TxtSumaFacturaDolares.Text = "0.00"
        Me.TxtSumaFacturaDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTasa
        '
        Me.LblTasa.AutoSize = True
        Me.LblTasa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblTasa.Location = New System.Drawing.Point(16, 91)
        Me.LblTasa.Name = "LblTasa"
        Me.LblTasa.Size = New System.Drawing.Size(130, 15)
        Me.LblTasa.TabIndex = 5
        Me.LblTasa.Text = "Tasa de cambio del día"
        '
        'TxtTasaCambio
        '
        Me.TxtTasaCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtTasaCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTasaCambio.Location = New System.Drawing.Point(372, 88)
        Me.TxtTasaCambio.Name = "TxtTasaCambio"
        Me.TxtTasaCambio.ReadOnly = True
        Me.TxtTasaCambio.Size = New System.Drawing.Size(144, 23)
        Me.TxtTasaCambio.TabIndex = 6
        Me.TxtTasaCambio.TabStop = False
        Me.TxtTasaCambio.Text = "0.0000"
        Me.TxtTasaCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalContado
        '
        Me.LblTotalContado.AutoSize = True
        Me.LblTotalContado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblTotalContado.Location = New System.Drawing.Point(16, 116)
        Me.LblTotalContado.Name = "LblTotalContado"
        Me.LblTotalContado.Size = New System.Drawing.Size(224, 15)
        Me.LblTotalContado.TabIndex = 7
        Me.LblTotalContado.Text = "Total contado C$ (efectivo + cheq./tarj.)"
        '
        'TxtCordobasDolares
        '
        Me.TxtCordobasDolares.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtCordobasDolares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCordobasDolares.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCordobasDolares.Location = New System.Drawing.Point(372, 113)
        Me.TxtCordobasDolares.Name = "TxtCordobasDolares"
        Me.TxtCordobasDolares.ReadOnly = True
        Me.TxtCordobasDolares.Size = New System.Drawing.Size(144, 23)
        Me.TxtCordobasDolares.TabIndex = 8
        Me.TxtCordobasDolares.TabStop = False
        Me.TxtCordobasDolares.Text = "0.00"
        Me.TxtCordobasDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalEsperado
        '
        Me.LblTotalEsperado.AutoSize = True
        Me.LblTotalEsperado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblTotalEsperado.Location = New System.Drawing.Point(16, 141)
        Me.LblTotalEsperado.Name = "LblTotalEsperado"
        Me.LblTotalEsperado.Size = New System.Drawing.Size(207, 15)
        Me.LblTotalEsperado.TabIndex = 9
        Me.LblTotalEsperado.Text = "Total esperado C$ (incluye el fondo)"
        '
        'TxtValorFacturas
        '
        Me.TxtValorFacturas.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtValorFacturas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtValorFacturas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValorFacturas.Location = New System.Drawing.Point(372, 138)
        Me.TxtValorFacturas.Name = "TxtValorFacturas"
        Me.TxtValorFacturas.ReadOnly = True
        Me.TxtValorFacturas.Size = New System.Drawing.Size(144, 23)
        Me.TxtValorFacturas.TabIndex = 10
        Me.TxtValorFacturas.TabStop = False
        Me.TxtValorFacturas.Text = "0.00"
        Me.TxtValorFacturas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDiferencia
        '
        Me.LblDiferencia.AutoSize = True
        Me.LblDiferencia.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiferencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblDiferencia.Location = New System.Drawing.Point(16, 166)
        Me.LblDiferencia.Name = "LblDiferencia"
        Me.LblDiferencia.Size = New System.Drawing.Size(220, 15)
        Me.LblDiferencia.TabIndex = 11
        Me.LblDiferencia.Text = "Diferencia (esperado - contado)"
        '
        'TxtDiferencia
        '
        Me.TxtDiferencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDiferencia.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiferencia.Location = New System.Drawing.Point(372, 163)
        Me.TxtDiferencia.Name = "TxtDiferencia"
        Me.TxtDiferencia.ReadOnly = True
        Me.TxtDiferencia.Size = New System.Drawing.Size(144, 25)
        Me.TxtDiferencia.TabIndex = 12
        Me.TxtDiferencia.TabStop = False
        Me.TxtDiferencia.Text = "0.00"
        Me.TxtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PnlAcciones
        '
        Me.PnlAcciones.BackColor = System.Drawing.Color.White
        Me.PnlAcciones.Controls.Add(Me.BtnSalir)
        Me.PnlAcciones.Controls.Add(Me.BtnImprimir)
        Me.PnlAcciones.Controls.Add(Me.BtnGrabar)
        Me.PnlAcciones.Controls.Add(Me.BtnNuevo)
        Me.PnlAcciones.Controls.Add(Me.LblEstado)
        Me.PnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlAcciones.Location = New System.Drawing.Point(0, 600)
        Me.PnlAcciones.Name = "PnlAcciones"
        Me.PnlAcciones.Size = New System.Drawing.Size(1100, 56)
        Me.PnlAcciones.TabIndex = 16
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblEstado.Location = New System.Drawing.Point(16, 20)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(250, 15)
        Me.LblEstado.TabIndex = 0
        Me.LblEstado.Text = "Seleccione cajero y fecha para iniciar el arqueo"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevo.FlatAppearance.BorderSize = 0
        Me.BtnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnNuevo.Location = New System.Drawing.Point(664, 10)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(96, 36)
        Me.BtnNuevo.TabIndex = 1
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.BtnGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGrabar.FlatAppearance.BorderSize = 0
        Me.BtnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGrabar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.ForeColor = System.Drawing.Color.White
        Me.BtnGrabar.Location = New System.Drawing.Point(772, 10)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(96, 36)
        Me.BtnGrabar.TabIndex = 2
        Me.BtnGrabar.Tag = "25"
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.FlatAppearance.BorderSize = 0
        Me.BtnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprimir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnImprimir.Location = New System.Drawing.Point(880, 10)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(96, 36)
        Me.BtnImprimir.TabIndex = 3
        Me.BtnImprimir.Tag = "27"
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSalir.FlatAppearance.BorderSize = 0
        Me.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.BtnSalir.Location = New System.Drawing.Point(988, 10)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(96, 36)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'FrmArqueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(1100, 656)
        Me.Controls.Add(Me.PnlResumen)
        Me.Controls.Add(Me.PnlCierre)
        Me.Controls.Add(Me.TxtTotalChequeDolares)
        Me.Controls.Add(Me.LblChequeDolares)
        Me.Controls.Add(Me.TxtTotalChequeCordobas)
        Me.Controls.Add(Me.LblChequeCordobas)
        Me.Controls.Add(Me.TxtSubTotalDolares)
        Me.Controls.Add(Me.LblSubTotalDolares)
        Me.Controls.Add(Me.TxtSubTotalCordobas)
        Me.Controls.Add(Me.LblSubTotalCordobas)
        Me.Controls.Add(Me.TdbGridChequeDolares)
        Me.Controls.Add(Me.TdbGridChequeCordobas)
        Me.Controls.Add(Me.TdbGridDolares)
        Me.Controls.Add(Me.TdbGridCordobas)
        Me.Controls.Add(Me.PnlDatos)
        Me.Controls.Add(Me.PnlAcciones)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmArqueo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zeus Facturación - Arqueo de caja"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlDatos.ResumeLayout(False)
        Me.PnlDatos.PerformLayout()
        CType(Me.TdbGridCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TdbGridDolares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TdbGridChequeCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TdbGridChequeDolares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlCierre.ResumeLayout(False)
        Me.PnlCierre.PerformLayout()
        Me.PnlResumen.ResumeLayout(False)
        Me.PnlResumen.PerformLayout()
        Me.PnlAcciones.ResumeLayout(False)
        Me.PnlAcciones.PerformLayout()
        CType(Me.BindingDetalleCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleDolares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleChequeCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleChequeDolares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblNumeroArqueo As System.Windows.Forms.Label
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PnlDatos As System.Windows.Forms.Panel
    Friend WithEvents BtnIniciar As System.Windows.Forms.Button
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroArqueo As System.Windows.Forms.TextBox
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents TxtFondoApertura As System.Windows.Forms.TextBox
    Friend WithEvents LblFondo As System.Windows.Forms.Label
    Friend WithEvents DTFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents CboCajero As System.Windows.Forms.ComboBox
    Friend WithEvents LblCajero As System.Windows.Forms.Label
    Friend WithEvents TdbGridCordobas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TdbGridDolares As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TdbGridChequeCordobas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TdbGridChequeDolares As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents LblSubTotalCordobas As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotalCordobas As System.Windows.Forms.TextBox
    Friend WithEvents LblSubTotalDolares As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotalDolares As System.Windows.Forms.TextBox
    Friend WithEvents LblChequeCordobas As System.Windows.Forms.Label
    Friend WithEvents TxtTotalChequeCordobas As System.Windows.Forms.TextBox
    Friend WithEvents LblChequeDolares As System.Windows.Forms.Label
    Friend WithEvents TxtTotalChequeDolares As System.Windows.Forms.TextBox
    Friend WithEvents PnlCierre As System.Windows.Forms.Panel
    Friend WithEvents TxtPracticadoPor As System.Windows.Forms.TextBox
    Friend WithEvents LblPracticadoPor As System.Windows.Forms.Label
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents LblObservaciones As System.Windows.Forms.Label
    Friend WithEvents LblTituloCierre As System.Windows.Forms.Label
    Friend WithEvents PnlResumen As System.Windows.Forms.Panel
    Friend WithEvents TxtDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblDiferencia As System.Windows.Forms.Label
    Friend WithEvents TxtValorFacturas As System.Windows.Forms.TextBox
    Friend WithEvents LblTotalEsperado As System.Windows.Forms.Label
    Friend WithEvents TxtCordobasDolares As System.Windows.Forms.TextBox
    Friend WithEvents LblTotalContado As System.Windows.Forms.Label
    Friend WithEvents TxtTasaCambio As System.Windows.Forms.TextBox
    Friend WithEvents LblTasa As System.Windows.Forms.Label
    Friend WithEvents TxtSumaFacturaDolares As System.Windows.Forms.TextBox
    Friend WithEvents LblEsperadoDolares As System.Windows.Forms.Label
    Friend WithEvents TxtSumaFacturaCordobas As System.Windows.Forms.TextBox
    Friend WithEvents LblEsperadoCordobas As System.Windows.Forms.Label
    Friend WithEvents LblTituloResumen As System.Windows.Forms.Label
    Friend WithEvents PnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents BindingDetalleCordobas As System.Windows.Forms.BindingSource
    Friend WithEvents BindingDetalleDolares As System.Windows.Forms.BindingSource
    Friend WithEvents BindingDetalleChequeCordobas As System.Windows.Forms.BindingSource
    Friend WithEvents BindingDetalleChequeDolares As System.Windows.Forms.BindingSource
End Class
