<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCuentasXCobrar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentasXCobrar))
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlFiltros = New System.Windows.Forms.Panel()
        Me.PnlLineaFiltros = New System.Windows.Forms.Panel()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.ChkRegistrosCero = New System.Windows.Forms.CheckBox()
        Me.PnlMoneda = New System.Windows.Forms.Panel()
        Me.OptDolares = New System.Windows.Forms.RadioButton()
        Me.OptCordobas = New System.Windows.Forms.RadioButton()
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblNombres = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CboCodigoCliente = New C1.Win.C1List.C1Combo()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.PnlAcciones = New System.Windows.Forms.Panel()
        Me.TlpResumen = New System.Windows.Forms.TableLayoutPanel()
        Me.PnlCargos = New System.Windows.Forms.Panel()
        Me.TxtCargos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PnlAbonos = New System.Windows.Forms.Panel()
        Me.TxtAbonos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PnlNotas = New System.Windows.Forms.Panel()
        Me.TxtNB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PnlMora = New System.Windows.Forms.Panel()
        Me.TxtMora = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlSaldo = New System.Windows.Forms.Panel()
        Me.TxtSaldoFinal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnlGrid = New System.Windows.Forms.Panel()
        Me.TDGridImpuestos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStripGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AsignarFacturaAlReciboToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularNotasDeDebitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularNotasDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjustarDiferencialCambiarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnlEstado = New System.Windows.Forms.Panel()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.LblLeyendaVencido = New System.Windows.Forms.Label()
        Me.LblLeyendaFavor = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.PnlLineaEstado = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CmdAjustes = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.ToolTipCxC = New System.Windows.Forms.ToolTip(Me.components)
        Me.PnlHeader.SuspendLayout()
        Me.PnlFiltros.SuspendLayout()
        Me.PnlMoneda.SuspendLayout()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TlpResumen.SuspendLayout()
        Me.PnlCargos.SuspendLayout()
        Me.PnlAbonos.SuspendLayout()
        Me.PnlNotas.SuspendLayout()
        Me.PnlMora.SuspendLayout()
        Me.PnlSaldo.SuspendLayout()
        Me.PnlGrid.SuspendLayout()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripGrid.SuspendLayout()
        Me.PnlEstado.SuspendLayout()
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
        Me.PnlHeader.Size = New System.Drawing.Size(1236, 60)
        Me.PnlHeader.TabIndex = 0
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(20, 36)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(316, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Saldo por factura, abonos, notas y mora a la fecha de corte"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(17, 6)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(201, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Cuentas por Cobrar"
        '
        'PnlFiltros
        '
        Me.PnlFiltros.BackColor = System.Drawing.Color.White
        Me.PnlFiltros.Controls.Add(Me.PnlLineaFiltros)
        Me.PnlFiltros.Controls.Add(Me.CmdGrabar)
        Me.PnlFiltros.Controls.Add(Me.ChkRegistrosCero)
        Me.PnlFiltros.Controls.Add(Me.PnlMoneda)
        Me.PnlFiltros.Controls.Add(Me.DTPFechaFin)
        Me.PnlFiltros.Controls.Add(Me.Label6)
        Me.PnlFiltros.Controls.Add(Me.LblNombres)
        Me.PnlFiltros.Controls.Add(Me.Button2)
        Me.PnlFiltros.Controls.Add(Me.CboCodigoCliente)
        Me.PnlFiltros.Controls.Add(Me.LblCodigo)
        Me.PnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlFiltros.Location = New System.Drawing.Point(0, 60)
        Me.PnlFiltros.Name = "PnlFiltros"
        Me.PnlFiltros.Size = New System.Drawing.Size(1236, 96)
        Me.PnlFiltros.TabIndex = 1
        '
        'PnlLineaFiltros
        '
        Me.PnlLineaFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.PnlLineaFiltros.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlLineaFiltros.Location = New System.Drawing.Point(0, 95)
        Me.PnlLineaFiltros.Name = "PnlLineaFiltros"
        Me.PnlLineaFiltros.Size = New System.Drawing.Size(1236, 1)
        Me.PnlLineaFiltros.TabIndex = 9
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.CmdGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGrabar.FlatAppearance.BorderSize = 0
        Me.CmdGrabar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.CmdGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.ForeColor = System.Drawing.Color.White
        Me.CmdGrabar.Location = New System.Drawing.Point(1080, 43)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(140, 42)
        Me.CmdGrabar.TabIndex = 6
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Consultar"
        Me.CmdGrabar.UseVisualStyleBackColor = False
        '
        'ChkRegistrosCero
        '
        Me.ChkRegistrosCero.AutoSize = True
        Me.ChkRegistrosCero.Checked = True
        Me.ChkRegistrosCero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRegistrosCero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ChkRegistrosCero.Location = New System.Drawing.Point(436, 57)
        Me.ChkRegistrosCero.Name = "ChkRegistrosCero"
        Me.ChkRegistrosCero.Size = New System.Drawing.Size(215, 19)
        Me.ChkRegistrosCero.TabIndex = 5
        Me.ChkRegistrosCero.Text = "Ocultar documentos con saldo cero"
        Me.ChkRegistrosCero.UseVisualStyleBackColor = True
        '
        'PnlMoneda
        '
        Me.PnlMoneda.Controls.Add(Me.OptDolares)
        Me.PnlMoneda.Controls.Add(Me.OptCordobas)
        Me.PnlMoneda.Location = New System.Drawing.Point(230, 52)
        Me.PnlMoneda.Name = "PnlMoneda"
        Me.PnlMoneda.Size = New System.Drawing.Size(190, 28)
        Me.PnlMoneda.TabIndex = 4
        '
        'OptDolares
        '
        Me.OptDolares.AutoSize = True
        Me.OptDolares.Location = New System.Drawing.Point(100, 4)
        Me.OptDolares.Name = "OptDolares"
        Me.OptDolares.Size = New System.Drawing.Size(64, 19)
        Me.OptDolares.TabIndex = 1
        Me.OptDolares.Text = "Dólares"
        Me.OptDolares.UseVisualStyleBackColor = True
        '
        'OptCordobas
        '
        Me.OptCordobas.AutoSize = True
        Me.OptCordobas.Checked = True
        Me.OptCordobas.Location = New System.Drawing.Point(4, 4)
        Me.OptCordobas.Name = "OptCordobas"
        Me.OptCordobas.Size = New System.Drawing.Size(76, 19)
        Me.OptCordobas.TabIndex = 0
        Me.OptCordobas.TabStop = True
        Me.OptCordobas.Text = "Córdobas"
        Me.OptCordobas.UseVisualStyleBackColor = True
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(96, 54)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(118, 23)
        Me.DTPFechaFin.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(20, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Corte al"
        '
        'LblNombres
        '
        Me.LblNombres.AutoSize = True
        Me.LblNombres.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.LblNombres.Location = New System.Drawing.Point(396, 15)
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Size = New System.Drawing.Size(0, 20)
        Me.LblNombres.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(352, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 26)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = False
        '
        'CboCodigoCliente
        '
        Me.CboCodigoCliente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoCliente.Caption = ""
        Me.CboCodigoCliente.CaptionHeight = 17
        Me.CboCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoCliente.ColumnCaptionHeight = 17
        Me.CboCodigoCliente.ColumnFooterHeight = 17
        Me.CboCodigoCliente.ContentHeight = 18
        Me.CboCodigoCliente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoCliente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoCliente.EditorFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoCliente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoCliente.EditorHeight = 18
        Me.CboCodigoCliente.Images.Add(CType(resources.GetObject("CboCodigoCliente.Images"), System.Drawing.Image))
        Me.CboCodigoCliente.ItemHeight = 18
        Me.CboCodigoCliente.Location = New System.Drawing.Point(96, 14)
        Me.CboCodigoCliente.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoCliente.MaxDropDownItems = CType(10, Short)
        Me.CboCodigoCliente.MaxLength = 32767
        Me.CboCodigoCliente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoCliente.Name = "CboCodigoCliente"
        Me.CboCodigoCliente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoCliente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.Size = New System.Drawing.Size(250, 24)
        Me.CboCodigoCliente.TabIndex = 1
        Me.CboCodigoCliente.PropBag = resources.GetString("CboCodigoCliente.PropBag")
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.LblCodigo.Location = New System.Drawing.Point(20, 18)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(44, 15)
        Me.LblCodigo.TabIndex = 0
        Me.LblCodigo.Text = "Cliente"
        '
        'PnlAcciones
        '
        Me.PnlAcciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlAcciones.Location = New System.Drawing.Point(0, 156)
        Me.PnlAcciones.Name = "PnlAcciones"
        Me.PnlAcciones.Size = New System.Drawing.Size(1236, 52)
        Me.PnlAcciones.TabIndex = 2
        '
        'TlpResumen
        '
        Me.TlpResumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TlpResumen.ColumnCount = 5
        Me.TlpResumen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpResumen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpResumen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpResumen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpResumen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TlpResumen.Controls.Add(Me.PnlCargos, 0, 0)
        Me.TlpResumen.Controls.Add(Me.PnlAbonos, 1, 0)
        Me.TlpResumen.Controls.Add(Me.PnlNotas, 2, 0)
        Me.TlpResumen.Controls.Add(Me.PnlMora, 3, 0)
        Me.TlpResumen.Controls.Add(Me.PnlSaldo, 4, 0)
        Me.TlpResumen.Dock = System.Windows.Forms.DockStyle.Top
        Me.TlpResumen.Location = New System.Drawing.Point(0, 208)
        Me.TlpResumen.Name = "TlpResumen"
        Me.TlpResumen.Padding = New System.Windows.Forms.Padding(12, 0, 12, 8)
        Me.TlpResumen.RowCount = 1
        Me.TlpResumen.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpResumen.Size = New System.Drawing.Size(1236, 77)
        Me.TlpResumen.TabIndex = 3
        '
        'PnlCargos
        '
        Me.PnlCargos.BackColor = System.Drawing.Color.White
        Me.PnlCargos.Controls.Add(Me.TxtCargos)
        Me.PnlCargos.Controls.Add(Me.Label3)
        Me.PnlCargos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlCargos.Location = New System.Drawing.Point(16, 0)
        Me.PnlCargos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PnlCargos.Name = "PnlCargos"
        Me.PnlCargos.Size = New System.Drawing.Size(234, 69)
        Me.PnlCargos.TabIndex = 0
        '
        'TxtCargos
        '
        Me.TxtCargos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCargos.BackColor = System.Drawing.Color.White
        Me.TxtCargos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCargos.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCargos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtCargos.Location = New System.Drawing.Point(12, 34)
        Me.TxtCargos.Name = "TxtCargos"
        Me.TxtCargos.ReadOnly = True
        Me.TxtCargos.Size = New System.Drawing.Size(210, 28)
        Me.TxtCargos.TabIndex = 1
        Me.TxtCargos.TabStop = False
        Me.TxtCargos.Text = "0.00"
        Me.TxtCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CARGOS"
        '
        'PnlAbonos
        '
        Me.PnlAbonos.BackColor = System.Drawing.Color.White
        Me.PnlAbonos.Controls.Add(Me.TxtAbonos)
        Me.PnlAbonos.Controls.Add(Me.Label4)
        Me.PnlAbonos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlAbonos.Location = New System.Drawing.Point(258, 0)
        Me.PnlAbonos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PnlAbonos.Name = "PnlAbonos"
        Me.PnlAbonos.Size = New System.Drawing.Size(234, 69)
        Me.PnlAbonos.TabIndex = 1
        '
        'TxtAbonos
        '
        Me.TxtAbonos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtAbonos.BackColor = System.Drawing.Color.White
        Me.TxtAbonos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAbonos.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAbonos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.TxtAbonos.Location = New System.Drawing.Point(12, 34)
        Me.TxtAbonos.Name = "TxtAbonos"
        Me.TxtAbonos.ReadOnly = True
        Me.TxtAbonos.Size = New System.Drawing.Size(210, 28)
        Me.TxtAbonos.TabIndex = 1
        Me.TxtAbonos.TabStop = False
        Me.TxtAbonos.Text = "0.00"
        Me.TxtAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ABONOS"
        '
        'PnlNotas
        '
        Me.PnlNotas.BackColor = System.Drawing.Color.White
        Me.PnlNotas.Controls.Add(Me.TxtNB)
        Me.PnlNotas.Controls.Add(Me.Label7)
        Me.PnlNotas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlNotas.Location = New System.Drawing.Point(500, 0)
        Me.PnlNotas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PnlNotas.Name = "PnlNotas"
        Me.PnlNotas.Size = New System.Drawing.Size(234, 69)
        Me.PnlNotas.TabIndex = 2
        '
        'TxtNB
        '
        Me.TxtNB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNB.BackColor = System.Drawing.Color.White
        Me.TxtNB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNB.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtNB.Location = New System.Drawing.Point(12, 34)
        Me.TxtNB.Name = "TxtNB"
        Me.TxtNB.ReadOnly = True
        Me.TxtNB.Size = New System.Drawing.Size(210, 28)
        Me.TxtNB.TabIndex = 1
        Me.TxtNB.TabStop = False
        Me.TxtNB.Text = "0.00"
        Me.TxtNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "NOTAS DB / CR"
        '
        'PnlMora
        '
        Me.PnlMora.BackColor = System.Drawing.Color.White
        Me.PnlMora.Controls.Add(Me.TxtMora)
        Me.PnlMora.Controls.Add(Me.Label1)
        Me.PnlMora.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMora.Location = New System.Drawing.Point(742, 0)
        Me.PnlMora.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PnlMora.Name = "PnlMora"
        Me.PnlMora.Size = New System.Drawing.Size(234, 69)
        Me.PnlMora.TabIndex = 3
        '
        'TxtMora
        '
        Me.TxtMora.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMora.BackColor = System.Drawing.Color.White
        Me.TxtMora.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMora.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.TxtMora.Location = New System.Drawing.Point(12, 34)
        Me.TxtMora.Name = "TxtMora"
        Me.TxtMora.ReadOnly = True
        Me.TxtMora.Size = New System.Drawing.Size(210, 28)
        Me.TxtMora.TabIndex = 1
        Me.TxtMora.TabStop = False
        Me.TxtMora.Text = "0.00"
        Me.TxtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MORA"
        '
        'PnlSaldo
        '
        Me.PnlSaldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.PnlSaldo.Controls.Add(Me.TxtSaldoFinal)
        Me.PnlSaldo.Controls.Add(Me.Label5)
        Me.PnlSaldo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlSaldo.Location = New System.Drawing.Point(984, 0)
        Me.PnlSaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PnlSaldo.Name = "PnlSaldo"
        Me.PnlSaldo.Size = New System.Drawing.Size(236, 69)
        Me.PnlSaldo.TabIndex = 4
        '
        'TxtSaldoFinal
        '
        Me.TxtSaldoFinal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSaldoFinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.TxtSaldoFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaldoFinal.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldoFinal.ForeColor = System.Drawing.Color.White
        Me.TxtSaldoFinal.Location = New System.Drawing.Point(12, 34)
        Me.TxtSaldoFinal.Name = "TxtSaldoFinal"
        Me.TxtSaldoFinal.ReadOnly = True
        Me.TxtSaldoFinal.Size = New System.Drawing.Size(212, 28)
        Me.TxtSaldoFinal.TabIndex = 1
        Me.TxtSaldoFinal.TabStop = False
        Me.TxtSaldoFinal.Text = "0.00"
        Me.TxtSaldoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "SALDO FINAL"
        '
        'PnlGrid
        '
        Me.PnlGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PnlGrid.Controls.Add(Me.TDGridImpuestos)
        Me.PnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlGrid.Location = New System.Drawing.Point(0, 315)
        Me.PnlGrid.Name = "PnlGrid"
        Me.PnlGrid.Padding = New System.Windows.Forms.Padding(16, 0, 16, 10)
        Me.PnlGrid.Size = New System.Drawing.Size(1236, 266)
        Me.PnlGrid.TabIndex = 4
        '
        'TDGridImpuestos
        '
        Me.TDGridImpuestos.AllowUpdate = False
        Me.TDGridImpuestos.AlternatingRows = True
        Me.TDGridImpuestos.CaptionHeight = 17
        Me.TDGridImpuestos.ContextMenuStrip = Me.ContextMenuStripGrid
        Me.TDGridImpuestos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TDGridImpuestos.FilterBar = True
        Me.TDGridImpuestos.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.TDGridImpuestos.Images.Add(CType(resources.GetObject("TDGridImpuestos.Images"), System.Drawing.Image))
        Me.TDGridImpuestos.Location = New System.Drawing.Point(16, 0)
        Me.TDGridImpuestos.Name = "TDGridImpuestos"
        Me.TDGridImpuestos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridImpuestos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridImpuestos.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridImpuestos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridImpuestos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridImpuestos.RowHeight = 15
        Me.TDGridImpuestos.Size = New System.Drawing.Size(1204, 256)
        Me.TDGridImpuestos.TabIndex = 0
        Me.TDGridImpuestos.Text = "C1TrueDBGrid1"
        Me.TDGridImpuestos.PropBag = resources.GetString("TDGridImpuestos.PropBag")
        '
        'ContextMenuStripGrid
        '
        Me.ContextMenuStripGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsignarFacturaAlReciboToolStripMenuItem, Me.AnularNotasDeDebitoToolStripMenuItem, Me.AnularNotasDeCreditoToolStripMenuItem, Me.AjustarDiferencialCambiarioToolStripMenuItem, Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem})
        Me.ContextMenuStripGrid.Name = "ContextMenuStripGrid"
        Me.ContextMenuStripGrid.Size = New System.Drawing.Size(249, 114)
        '
        'AsignarFacturaAlReciboToolStripMenuItem
        '
        Me.AsignarFacturaAlReciboToolStripMenuItem.Name = "AsignarFacturaAlReciboToolStripMenuItem"
        Me.AsignarFacturaAlReciboToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AsignarFacturaAlReciboToolStripMenuItem.Text = "Asignar Factura al Recibo"
        '
        'AnularNotasDeDebitoToolStripMenuItem
        '
        Me.AnularNotasDeDebitoToolStripMenuItem.Name = "AnularNotasDeDebitoToolStripMenuItem"
        Me.AnularNotasDeDebitoToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AnularNotasDeDebitoToolStripMenuItem.Text = "Crear Recibo"
        '
        'AnularNotasDeCreditoToolStripMenuItem
        '
        Me.AnularNotasDeCreditoToolStripMenuItem.Name = "AnularNotasDeCreditoToolStripMenuItem"
        Me.AnularNotasDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AnularNotasDeCreditoToolStripMenuItem.Text = "Anular Notas de Credito"
        '
        'AjustarDiferencialCambiarioToolStripMenuItem
        '
        Me.AjustarDiferencialCambiarioToolStripMenuItem.Name = "AjustarDiferencialCambiarioToolStripMenuItem"
        Me.AjustarDiferencialCambiarioToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AjustarDiferencialCambiarioToolStripMenuItem.Text = "Ajustar Diferencial Cambiario"
        '
        'AsignarFacturaALaNotaDeCreditoToolStripMenuItem
        '
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Name = "AsignarFacturaALaNotaDeCreditoToolStripMenuItem"
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Text = "Asignar Factura a la Nota Credito"
        '
        'PnlEstado
        '
        Me.PnlEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PnlEstado.Controls.Add(Me.LblEstado)
        Me.PnlEstado.Controls.Add(Me.LblLeyendaVencido)
        Me.PnlEstado.Controls.Add(Me.LblLeyendaFavor)
        Me.PnlEstado.Controls.Add(Me.ProgressBar)
        Me.PnlEstado.Controls.Add(Me.PnlLineaEstado)
        Me.PnlEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlEstado.Location = New System.Drawing.Point(0, 285)
        Me.PnlEstado.Name = "PnlEstado"
        Me.PnlEstado.Padding = New System.Windows.Forms.Padding(16, 4, 16, 6)
        Me.PnlEstado.Size = New System.Drawing.Size(1236, 30)
        Me.PnlEstado.TabIndex = 5
        '
        'LblEstado
        '
        Me.LblEstado.AutoEllipsis = True
        Me.LblEstado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.LblEstado.Location = New System.Drawing.Point(16, 5)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.LblEstado.Size = New System.Drawing.Size(734, 19)
        Me.LblEstado.TabIndex = 0
        Me.LblEstado.Text = "Seleccione un cliente y presione Consultar (F5)."
        Me.LblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblEstado.Visible = False
        '
        'LblLeyendaVencido
        '
        Me.LblLeyendaVencido.Dock = System.Windows.Forms.DockStyle.Right
        Me.LblLeyendaVencido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.LblLeyendaVencido.Location = New System.Drawing.Point(750, 5)
        Me.LblLeyendaVencido.Name = "LblLeyendaVencido"
        Me.LblLeyendaVencido.Size = New System.Drawing.Size(110, 19)
        Me.LblLeyendaVencido.TabIndex = 1
        Me.LblLeyendaVencido.Text = "● Vencido"
        Me.LblLeyendaVencido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblLeyendaFavor
        '
        Me.LblLeyendaFavor.Dock = System.Windows.Forms.DockStyle.Right
        Me.LblLeyendaFavor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.LblLeyendaFavor.Location = New System.Drawing.Point(860, 5)
        Me.LblLeyendaFavor.Name = "LblLeyendaFavor"
        Me.LblLeyendaFavor.Size = New System.Drawing.Size(130, 19)
        Me.LblLeyendaFavor.TabIndex = 2
        Me.LblLeyendaFavor.Text = "● Saldo a favor"
        Me.LblLeyendaFavor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Right
        Me.ProgressBar.Location = New System.Drawing.Point(990, 5)
        Me.ProgressBar.MarqueeAnimationSpeed = 25
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(230, 19)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar.TabIndex = 3
        Me.ProgressBar.Visible = False
        '
        'PnlLineaEstado
        '
        Me.PnlLineaEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.PnlLineaEstado.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlLineaEstado.Location = New System.Drawing.Point(16, 4)
        Me.PnlLineaEstado.Name = "PnlLineaEstado"
        Me.PnlLineaEstado.Size = New System.Drawing.Size(1204, 1)
        Me.PnlLineaEstado.TabIndex = 4
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Enabled = False
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(16, 165)
        Me.Button5.Name = "Button5"
        Me.Button5.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Button5.Size = New System.Drawing.Size(124, 34)
        Me.Button5.TabIndex = 10
        Me.Button5.Tag = "25"
        Me.Button5.Text = "Nota débito"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(146, 165)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Button1.Size = New System.Drawing.Size(130, 34)
        Me.Button1.TabIndex = 11
        Me.Button1.Tag = "26"
        Me.Button1.Text = "Nota crédito"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(282, 165)
        Me.Button3.Name = "Button3"
        Me.Button3.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Button3.Size = New System.Drawing.Size(108, 34)
        Me.Button3.TabIndex = 12
        Me.Button3.Tag = "28"
        Me.Button3.Text = "Recibos"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = False
        '
        'CmdAjustes
        '
        Me.CmdAjustes.BackColor = System.Drawing.Color.White
        Me.CmdAjustes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdAjustes.Enabled = False
        Me.CmdAjustes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.CmdAjustes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdAjustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAjustes.Image = CType(resources.GetObject("CmdAjustes.Image"), System.Drawing.Image)
        Me.CmdAjustes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAjustes.Location = New System.Drawing.Point(396, 165)
        Me.CmdAjustes.Name = "CmdAjustes"
        Me.CmdAjustes.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.CmdAjustes.Size = New System.Drawing.Size(108, 34)
        Me.CmdAjustes.TabIndex = 13
        Me.CmdAjustes.Tag = "28"
        Me.CmdAjustes.Text = "Ajustes"
        Me.CmdAjustes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAjustes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdAjustes.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(510, 165)
        Me.Button4.Name = "Button4"
        Me.Button4.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Button4.Size = New System.Drawing.Size(130, 34)
        Me.Button4.TabIndex = 14
        Me.Button4.Tag = "28"
        Me.Button4.Text = "Ajustes total"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(1004, 165)
        Me.Button6.Name = "Button6"
        Me.Button6.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Button6.Size = New System.Drawing.Size(104, 34)
        Me.Button6.TabIndex = 15
        Me.Button6.Tag = "27"
        Me.Button6.Text = "Imprimir"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(1114, 165)
        Me.Button8.Name = "Button8"
        Me.Button8.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Button8.Size = New System.Drawing.Size(104, 34)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(620, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Fecha Inicio"
        Me.Label2.Visible = False
        '
        'DTPFechaIni
        '
        Me.DTPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaIni.Location = New System.Drawing.Point(700, 170)
        Me.DTPFechaIni.Name = "DTPFechaIni"
        Me.DTPFechaIni.Size = New System.Drawing.Size(104, 23)
        Me.DTPFechaIni.TabIndex = 21
        Me.DTPFechaIni.Visible = False
        '
        'FrmCuentasXCobrar
        '
        Me.AcceptButton = Me.CmdGrabar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1236, 581)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CmdAjustes)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPFechaIni)
        Me.Controls.Add(Me.PnlGrid)
        Me.Controls.Add(Me.PnlEstado)
        Me.Controls.Add(Me.TlpResumen)
        Me.Controls.Add(Me.PnlAcciones)
        Me.Controls.Add(Me.PnlFiltros)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(980, 620)
        Me.Name = "FrmCuentasXCobrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas x Cobrar"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlFiltros.ResumeLayout(False)
        Me.PnlFiltros.PerformLayout()
        Me.PnlMoneda.ResumeLayout(False)
        Me.PnlMoneda.PerformLayout()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TlpResumen.ResumeLayout(False)
        Me.PnlCargos.ResumeLayout(False)
        Me.PnlCargos.PerformLayout()
        Me.PnlAbonos.ResumeLayout(False)
        Me.PnlAbonos.PerformLayout()
        Me.PnlNotas.ResumeLayout(False)
        Me.PnlNotas.PerformLayout()
        Me.PnlMora.ResumeLayout(False)
        Me.PnlMora.PerformLayout()
        Me.PnlSaldo.ResumeLayout(False)
        Me.PnlSaldo.PerformLayout()
        Me.PnlGrid.ResumeLayout(False)
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripGrid.ResumeLayout(False)
        Me.PnlEstado.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents PnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents PnlLineaFiltros As System.Windows.Forms.Panel
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents CboCodigoCliente As C1.Win.C1List.C1Combo
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LblNombres As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents PnlMoneda As System.Windows.Forms.Panel
    Friend WithEvents OptCordobas As System.Windows.Forms.RadioButton
    Friend WithEvents OptDolares As System.Windows.Forms.RadioButton
    Friend WithEvents ChkRegistrosCero As System.Windows.Forms.CheckBox
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents PnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CmdAjustes As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TlpResumen As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PnlCargos As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCargos As System.Windows.Forms.TextBox
    Friend WithEvents PnlAbonos As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAbonos As System.Windows.Forms.TextBox
    Friend WithEvents PnlNotas As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtNB As System.Windows.Forms.TextBox
    Friend WithEvents PnlMora As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMora As System.Windows.Forms.TextBox
    Friend WithEvents PnlSaldo As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtSaldoFinal As System.Windows.Forms.TextBox
    Friend WithEvents PnlGrid As System.Windows.Forms.Panel
    Friend WithEvents TDGridImpuestos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ContextMenuStripGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AsignarFacturaAlReciboToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularNotasDeDebitoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularNotasDeCreditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjustarDiferencialCambiarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsignarFacturaALaNotaDeCreditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PnlEstado As System.Windows.Forms.Panel
    Friend WithEvents PnlLineaEstado As System.Windows.Forms.Panel
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblLeyendaVencido As System.Windows.Forms.Label
    Friend WithEvents LblLeyendaFavor As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolTipCxC As System.Windows.Forms.ToolTip
End Class
