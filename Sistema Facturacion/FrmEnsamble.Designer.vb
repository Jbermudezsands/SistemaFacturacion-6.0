<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnsamble
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
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblNumeroEnsamble = New System.Windows.Forms.Label()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlDocumento = New System.Windows.Forms.Panel()
        Me.LblNombreBodegaDestino = New System.Windows.Forms.Label()
        Me.CboBodegaDestino = New System.Windows.Forms.ComboBox()
        Me.LblBodegaDestino = New System.Windows.Forms.Label()
        Me.LblNombreBodegaOrigen = New System.Windows.Forms.Label()
        Me.CboCodigoBodega = New System.Windows.Forms.ComboBox()
        Me.LblBodegaOrigen = New System.Windows.Forms.Label()
        Me.BtnBuscarEnsamble = New System.Windows.Forms.Button()
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.CboTipoProducto = New System.Windows.Forms.ComboBox()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.LblTituloDocumento = New System.Windows.Forms.Label()
        Me.PnlProducto = New System.Windows.Forms.Panel()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.LblUnidadMedida = New System.Windows.Forms.Label()
        Me.TxtRendimiento = New System.Windows.Forms.TextBox()
        Me.LblRendimiento = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.LblCantidad = New System.Windows.Forms.Label()
        Me.CmdEnsambles = New System.Windows.Forms.Button()
        Me.CmdAgregarProducto = New System.Windows.Forms.Button()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.LblDescripcion = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.LblTituloProducto = New System.Windows.Forms.Label()
        Me.PnlComponentes = New System.Windows.Forms.Panel()
        Me.GridComponentes = New System.Windows.Forms.DataGridView()
        Me.PnlFiltros = New System.Windows.Forms.Panel()
        Me.BtnSeries = New System.Windows.Forms.Button()
        Me.LblResumen = New System.Windows.Forms.Label()
        Me.LblTituloComponentes = New System.Windows.Forms.Label()
        Me.PnlAcciones = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.CmdDesahacer = New System.Windows.Forms.Button()
        Me.CmdOrden = New System.Windows.Forms.Button()
        Me.CmdProcesar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.CmdNuevo = New System.Windows.Forms.Button()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.PnlHeader.SuspendLayout()
        Me.PnlDocumento.SuspendLayout()
        Me.PnlProducto.SuspendLayout()
        Me.PnlComponentes.SuspendLayout()
        CType(Me.GridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.LblNumeroEnsamble)
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.LblTitulo)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(980, 58)
        Me.PnlHeader.TabIndex = 0
        '
        'LblNumeroEnsamble
        '
        Me.LblNumeroEnsamble.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNumeroEnsamble.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumeroEnsamble.ForeColor = System.Drawing.Color.White
        Me.LblNumeroEnsamble.Location = New System.Drawing.Point(540, 17)
        Me.LblNumeroEnsamble.Name = "LblNumeroEnsamble"
        Me.LblNumeroEnsamble.Size = New System.Drawing.Size(424, 24)
        Me.LblNumeroEnsamble.TabIndex = 2
        Me.LblNumeroEnsamble.Text = "Ensamble Nº —"
        Me.LblNumeroEnsamble.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(18, 36)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(327, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Órdenes de ensamble, ensambles recibidos y desensambles"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(14, 4)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(230, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Control de ensambles"
        '
        'PnlDocumento
        '
        Me.PnlDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlDocumento.BackColor = System.Drawing.Color.White
        Me.PnlDocumento.Controls.Add(Me.LblNombreBodegaDestino)
        Me.PnlDocumento.Controls.Add(Me.CboBodegaDestino)
        Me.PnlDocumento.Controls.Add(Me.LblBodegaDestino)
        Me.PnlDocumento.Controls.Add(Me.LblNombreBodegaOrigen)
        Me.PnlDocumento.Controls.Add(Me.CboCodigoBodega)
        Me.PnlDocumento.Controls.Add(Me.LblBodegaOrigen)
        Me.PnlDocumento.Controls.Add(Me.BtnBuscarEnsamble)
        Me.PnlDocumento.Controls.Add(Me.TxtNumeroEnsamble)
        Me.PnlDocumento.Controls.Add(Me.LblNumero)
        Me.PnlDocumento.Controls.Add(Me.DTPFecha)
        Me.PnlDocumento.Controls.Add(Me.LblFecha)
        Me.PnlDocumento.Controls.Add(Me.CboTipoProducto)
        Me.PnlDocumento.Controls.Add(Me.LblTipo)
        Me.PnlDocumento.Controls.Add(Me.LblTituloDocumento)
        Me.PnlDocumento.Location = New System.Drawing.Point(16, 66)
        Me.PnlDocumento.Name = "PnlDocumento"
        Me.PnlDocumento.Size = New System.Drawing.Size(948, 96)
        Me.PnlDocumento.TabIndex = 1
        '
        'LblTituloDocumento
        '
        Me.LblTituloDocumento.AutoSize = True
        Me.LblTituloDocumento.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloDocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloDocumento.Location = New System.Drawing.Point(14, 8)
        Me.LblTituloDocumento.Name = "LblTituloDocumento"
        Me.LblTituloDocumento.Size = New System.Drawing.Size(129, 17)
        Me.LblTituloDocumento.TabIndex = 0
        Me.LblTituloDocumento.Text = "Datos del documento"
        '
        'LblTipo
        '
        Me.LblTipo.AutoSize = True
        Me.LblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblTipo.Location = New System.Drawing.Point(16, 40)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(29, 15)
        Me.LblTipo.TabIndex = 1
        Me.LblTipo.Text = "Tipo"
        '
        'CboTipoProducto
        '
        Me.CboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboTipoProducto.FormattingEnabled = True
        Me.CboTipoProducto.Items.AddRange(New Object() {"Orden de Ensamble", "Ensamble Recibido", "Deshacer Ensamble"})
        Me.CboTipoProducto.Location = New System.Drawing.Point(110, 36)
        Me.CboTipoProducto.Name = "CboTipoProducto"
        Me.CboTipoProducto.Size = New System.Drawing.Size(170, 23)
        Me.CboTipoProducto.TabIndex = 2
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblFecha.Location = New System.Drawing.Point(310, 40)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(38, 15)
        Me.LblFecha.TabIndex = 3
        Me.LblFecha.Text = "Fecha"
        '
        'DTPFecha
        '
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(356, 36)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(120, 23)
        Me.DTPFecha.TabIndex = 4
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblNumero.Location = New System.Drawing.Point(506, 40)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(51, 15)
        Me.LblNumero.TabIndex = 5
        Me.LblNumero.Text = "Número"
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtNumeroEnsamble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(566, 36)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.ReadOnly = True
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(100, 23)
        Me.TxtNumeroEnsamble.TabIndex = 6
        Me.TxtNumeroEnsamble.TabStop = False
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        Me.TxtNumeroEnsamble.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnBuscarEnsamble
        '
        Me.BtnBuscarEnsamble.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnBuscarEnsamble.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarEnsamble.FlatAppearance.BorderSize = 0
        Me.BtnBuscarEnsamble.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnBuscarEnsamble.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscarEnsamble.Location = New System.Drawing.Point(672, 35)
        Me.BtnBuscarEnsamble.Name = "BtnBuscarEnsamble"
        Me.BtnBuscarEnsamble.Size = New System.Drawing.Size(34, 25)
        Me.BtnBuscarEnsamble.TabIndex = 7
        Me.BtnBuscarEnsamble.TabStop = False
        Me.BtnBuscarEnsamble.Text = "..."
        Me.BtnBuscarEnsamble.UseVisualStyleBackColor = False
        '
        'LblBodegaOrigen
        '
        Me.LblBodegaOrigen.AutoSize = True
        Me.LblBodegaOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblBodegaOrigen.Location = New System.Drawing.Point(16, 68)
        Me.LblBodegaOrigen.Name = "LblBodegaOrigen"
        Me.LblBodegaOrigen.Size = New System.Drawing.Size(80, 15)
        Me.LblBodegaOrigen.TabIndex = 8
        Me.LblBodegaOrigen.Text = "Bodega origen"
        '
        'CboCodigoBodega
        '
        Me.CboCodigoBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCodigoBodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboCodigoBodega.FormattingEnabled = True
        Me.CboCodigoBodega.Location = New System.Drawing.Point(110, 64)
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.Size = New System.Drawing.Size(120, 23)
        Me.CboCodigoBodega.TabIndex = 9
        '
        'LblNombreBodegaOrigen
        '
        Me.LblNombreBodegaOrigen.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreBodegaOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.LblNombreBodegaOrigen.Location = New System.Drawing.Point(238, 67)
        Me.LblNombreBodegaOrigen.Name = "LblNombreBodegaOrigen"
        Me.LblNombreBodegaOrigen.Size = New System.Drawing.Size(230, 18)
        Me.LblNombreBodegaOrigen.TabIndex = 10
        '
        'LblBodegaDestino
        '
        Me.LblBodegaDestino.AutoSize = True
        Me.LblBodegaDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblBodegaDestino.Location = New System.Drawing.Point(506, 68)
        Me.LblBodegaDestino.Name = "LblBodegaDestino"
        Me.LblBodegaDestino.Size = New System.Drawing.Size(87, 15)
        Me.LblBodegaDestino.TabIndex = 11
        Me.LblBodegaDestino.Text = "Bodega destino"
        '
        'CboBodegaDestino
        '
        Me.CboBodegaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBodegaDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboBodegaDestino.FormattingEnabled = True
        Me.CboBodegaDestino.Location = New System.Drawing.Point(600, 64)
        Me.CboBodegaDestino.Name = "CboBodegaDestino"
        Me.CboBodegaDestino.Size = New System.Drawing.Size(120, 23)
        Me.CboBodegaDestino.TabIndex = 12
        '
        'LblNombreBodegaDestino
        '
        Me.LblNombreBodegaDestino.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreBodegaDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.LblNombreBodegaDestino.Location = New System.Drawing.Point(728, 67)
        Me.LblNombreBodegaDestino.Name = "LblNombreBodegaDestino"
        Me.LblNombreBodegaDestino.Size = New System.Drawing.Size(210, 18)
        Me.LblNombreBodegaDestino.TabIndex = 13
        '
        'PnlProducto
        '
        Me.PnlProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlProducto.BackColor = System.Drawing.Color.White
        Me.PnlProducto.Controls.Add(Me.TxtNumero)
        Me.PnlProducto.Controls.Add(Me.LblUnidadMedida)
        Me.PnlProducto.Controls.Add(Me.TxtRendimiento)
        Me.PnlProducto.Controls.Add(Me.LblRendimiento)
        Me.PnlProducto.Controls.Add(Me.TxtCantidad)
        Me.PnlProducto.Controls.Add(Me.LblCantidad)
        Me.PnlProducto.Controls.Add(Me.CmdEnsambles)
        Me.PnlProducto.Controls.Add(Me.CmdAgregarProducto)
        Me.PnlProducto.Controls.Add(Me.TxtDescripcion)
        Me.PnlProducto.Controls.Add(Me.LblDescripcion)
        Me.PnlProducto.Controls.Add(Me.TxtCodigo)
        Me.PnlProducto.Controls.Add(Me.LblCodigo)
        Me.PnlProducto.Controls.Add(Me.LblTituloProducto)
        Me.PnlProducto.Location = New System.Drawing.Point(16, 170)
        Me.PnlProducto.Name = "PnlProducto"
        Me.PnlProducto.Size = New System.Drawing.Size(948, 96)
        Me.PnlProducto.TabIndex = 2
        '
        'LblTituloProducto
        '
        Me.LblTituloProducto.AutoSize = True
        Me.LblTituloProducto.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloProducto.Location = New System.Drawing.Point(14, 8)
        Me.LblTituloProducto.Name = "LblTituloProducto"
        Me.LblTituloProducto.Size = New System.Drawing.Size(130, 17)
        Me.LblTituloProducto.TabIndex = 0
        Me.LblTituloProducto.Text = "Producto a ensamblar"
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblCodigo.Location = New System.Drawing.Point(16, 40)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(46, 15)
        Me.LblCodigo.TabIndex = 1
        Me.LblCodigo.Text = "Código"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCodigo.Location = New System.Drawing.Point(110, 36)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(120, 23)
        Me.TxtCodigo.TabIndex = 2
        Me.TxtCodigo.TabStop = False
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblDescripcion.Location = New System.Drawing.Point(250, 40)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(69, 15)
        Me.LblDescripcion.TabIndex = 3
        Me.LblDescripcion.Text = "Descripción"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDescripcion.Location = New System.Drawing.Point(326, 36)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(340, 23)
        Me.TxtDescripcion.TabIndex = 4
        Me.TxtDescripcion.TabStop = False
        '
        'CmdAgregarProducto
        '
        Me.CmdAgregarProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.CmdAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdAgregarProducto.FlatAppearance.BorderSize = 0
        Me.CmdAgregarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdAgregarProducto.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAgregarProducto.ForeColor = System.Drawing.Color.White
        Me.CmdAgregarProducto.Location = New System.Drawing.Point(688, 33)
        Me.CmdAgregarProducto.Name = "CmdAgregarProducto"
        Me.CmdAgregarProducto.Size = New System.Drawing.Size(116, 30)
        Me.CmdAgregarProducto.TabIndex = 5
        Me.CmdAgregarProducto.Tag = "30"
        Me.CmdAgregarProducto.Text = "Productos"
        Me.CmdAgregarProducto.UseVisualStyleBackColor = False
        '
        'CmdEnsambles
        '
        Me.CmdEnsambles.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CmdEnsambles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdEnsambles.FlatAppearance.BorderSize = 0
        Me.CmdEnsambles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.CmdEnsambles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEnsambles.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEnsambles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.CmdEnsambles.Location = New System.Drawing.Point(812, 33)
        Me.CmdEnsambles.Name = "CmdEnsambles"
        Me.CmdEnsambles.Size = New System.Drawing.Size(116, 30)
        Me.CmdEnsambles.TabIndex = 6
        Me.CmdEnsambles.Text = "Ensambles"
        Me.CmdEnsambles.UseVisualStyleBackColor = False
        '
        'LblCantidad
        '
        Me.LblCantidad.AutoSize = True
        Me.LblCantidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblCantidad.Location = New System.Drawing.Point(16, 68)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(55, 15)
        Me.LblCantidad.TabIndex = 7
        Me.LblCantidad.Text = "Cantidad"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCantidad.Location = New System.Drawing.Point(110, 64)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(120, 23)
        Me.TxtCantidad.TabIndex = 8
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblRendimiento
        '
        Me.LblRendimiento.AutoSize = True
        Me.LblRendimiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblRendimiento.Location = New System.Drawing.Point(250, 68)
        Me.LblRendimiento.Name = "LblRendimiento"
        Me.LblRendimiento.Size = New System.Drawing.Size(120, 15)
        Me.LblRendimiento.TabIndex = 9
        Me.LblRendimiento.Text = "Rendimiento ensamble"
        '
        'TxtRendimiento
        '
        Me.TxtRendimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRendimiento.Location = New System.Drawing.Point(396, 64)
        Me.TxtRendimiento.Name = "TxtRendimiento"
        Me.TxtRendimiento.Size = New System.Drawing.Size(110, 23)
        Me.TxtRendimiento.TabIndex = 10
        Me.TxtRendimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblUnidadMedida
        '
        Me.LblUnidadMedida.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnidadMedida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.LblUnidadMedida.Location = New System.Drawing.Point(514, 67)
        Me.LblUnidadMedida.Name = "LblUnidadMedida"
        Me.LblUnidadMedida.Size = New System.Drawing.Size(120, 18)
        Me.LblUnidadMedida.TabIndex = 11
        '
        'TxtNumero
        '
        Me.TxtNumero.Location = New System.Drawing.Point(700, 64)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(100, 23)
        Me.TxtNumero.TabIndex = 12
        Me.TxtNumero.TabStop = False
        Me.TxtNumero.Text = "0"
        Me.TxtNumero.Visible = False
        '
        'PnlComponentes
        '
        Me.PnlComponentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlComponentes.BackColor = System.Drawing.Color.White
        Me.PnlComponentes.Controls.Add(Me.GridComponentes)
        Me.PnlComponentes.Controls.Add(Me.PnlFiltros)
        Me.PnlComponentes.Controls.Add(Me.BtnSeries)
        Me.PnlComponentes.Controls.Add(Me.LblResumen)
        Me.PnlComponentes.Controls.Add(Me.LblTituloComponentes)
        Me.PnlComponentes.Location = New System.Drawing.Point(16, 274)
        Me.PnlComponentes.Name = "PnlComponentes"
        Me.PnlComponentes.Size = New System.Drawing.Size(948, 182)
        Me.PnlComponentes.TabIndex = 3
        '
        'LblTituloComponentes
        '
        Me.LblTituloComponentes.AutoSize = True
        Me.LblTituloComponentes.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloComponentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloComponentes.Location = New System.Drawing.Point(14, 10)
        Me.LblTituloComponentes.Name = "LblTituloComponentes"
        Me.LblTituloComponentes.Size = New System.Drawing.Size(147, 17)
        Me.LblTituloComponentes.TabIndex = 0
        Me.LblTituloComponentes.Text = "Listado de componentes"
        '
        'LblResumen
        '
        Me.LblResumen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblResumen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblResumen.Location = New System.Drawing.Point(600, 12)
        Me.LblResumen.Name = "LblResumen"
        Me.LblResumen.Size = New System.Drawing.Size(220, 18)
        Me.LblResumen.TabIndex = 1
        Me.LblResumen.Text = "0 componentes"
        Me.LblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnSeries
        '
        Me.BtnSeries.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnSeries.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSeries.FlatAppearance.BorderSize = 0
        Me.BtnSeries.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSeries.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSeries.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnSeries.Location = New System.Drawing.Point(832, 6)
        Me.BtnSeries.Name = "BtnSeries"
        Me.BtnSeries.Size = New System.Drawing.Size(100, 28)
        Me.BtnSeries.TabIndex = 2
        Me.BtnSeries.Text = "Series"
        Me.BtnSeries.UseVisualStyleBackColor = False
        '
        'PnlFiltros
        '
        Me.PnlFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PnlFiltros.Location = New System.Drawing.Point(16, 38)
        Me.PnlFiltros.Name = "PnlFiltros"
        Me.PnlFiltros.Size = New System.Drawing.Size(916, 28)
        Me.PnlFiltros.TabIndex = 3
        '
        'GridComponentes
        '
        Me.GridComponentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComponentes.AllowUserToAddRows = False
        Me.GridComponentes.AllowUserToDeleteRows = False
        Me.GridComponentes.AllowUserToResizeRows = False
        Me.GridComponentes.BackgroundColor = System.Drawing.Color.White
        Me.GridComponentes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridComponentes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GridComponentes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridComponentes.ColumnHeadersHeight = 32
        Me.GridComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridComponentes.EnableHeadersVisualStyles = False
        Me.GridComponentes.GridColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.GridComponentes.Location = New System.Drawing.Point(16, 66)
        Me.GridComponentes.MultiSelect = False
        Me.GridComponentes.Name = "GridComponentes"
        Me.GridComponentes.ReadOnly = True
        Me.GridComponentes.RowHeadersVisible = False
        Me.GridComponentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridComponentes.Size = New System.Drawing.Size(916, 108)
        Me.GridComponentes.TabIndex = 4
        '
        'PnlAcciones
        '
        Me.PnlAcciones.BackColor = System.Drawing.Color.White
        Me.PnlAcciones.Controls.Add(Me.BtnSalir)
        Me.PnlAcciones.Controls.Add(Me.CmdDesahacer)
        Me.PnlAcciones.Controls.Add(Me.CmdOrden)
        Me.PnlAcciones.Controls.Add(Me.CmdProcesar)
        Me.PnlAcciones.Controls.Add(Me.BtnImprimir)
        Me.PnlAcciones.Controls.Add(Me.ButtonBorrar)
        Me.PnlAcciones.Controls.Add(Me.CmdGrabar)
        Me.PnlAcciones.Controls.Add(Me.CmdNuevo)
        Me.PnlAcciones.Controls.Add(Me.LblEstado)
        Me.PnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlAcciones.Location = New System.Drawing.Point(0, 464)
        Me.PnlAcciones.Name = "PnlAcciones"
        Me.PnlAcciones.Size = New System.Drawing.Size(980, 56)
        Me.PnlAcciones.TabIndex = 4
        '
        'LblEstado
        '
        Me.LblEstado.AutoEllipsis = True
        Me.LblEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblEstado.Location = New System.Drawing.Point(16, 10)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(296, 36)
        Me.LblEstado.TabIndex = 0
        Me.LblEstado.Text = "Seleccione el tipo de ensamble"
        Me.LblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmdNuevo
        '
        Me.CmdNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CmdNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdNuevo.FlatAppearance.BorderSize = 0
        Me.CmdNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.CmdNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.CmdNuevo.Location = New System.Drawing.Point(324, 10)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(96, 36)
        Me.CmdNuevo.TabIndex = 1
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.UseVisualStyleBackColor = False
        '
        'CmdGrabar
        '
        Me.CmdGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.CmdGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGrabar.FlatAppearance.BorderSize = 0
        Me.CmdGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.CmdGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGrabar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.ForeColor = System.Drawing.Color.White
        Me.CmdGrabar.Location = New System.Drawing.Point(432, 10)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(96, 36)
        Me.CmdGrabar.TabIndex = 2
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Guardar"
        Me.CmdGrabar.UseVisualStyleBackColor = False
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ButtonBorrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonBorrar.FlatAppearance.BorderSize = 0
        Me.ButtonBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ButtonBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBorrar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBorrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.ButtonBorrar.Location = New System.Drawing.Point(540, 10)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(96, 36)
        Me.ButtonBorrar.TabIndex = 3
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.UseVisualStyleBackColor = False
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
        Me.BtnImprimir.Location = New System.Drawing.Point(648, 10)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(96, 36)
        Me.BtnImprimir.TabIndex = 4
        Me.BtnImprimir.Tag = "27"
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'CmdProcesar
        '
        Me.CmdProcesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.CmdProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdProcesar.FlatAppearance.BorderSize = 0
        Me.CmdProcesar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdProcesar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdProcesar.ForeColor = System.Drawing.Color.White
        Me.CmdProcesar.Location = New System.Drawing.Point(756, 10)
        Me.CmdProcesar.Name = "CmdProcesar"
        Me.CmdProcesar.Size = New System.Drawing.Size(96, 36)
        Me.CmdProcesar.TabIndex = 5
        Me.CmdProcesar.Text = "Procesar"
        Me.CmdProcesar.UseVisualStyleBackColor = False
        Me.CmdProcesar.Visible = False
        '
        'CmdOrden
        '
        Me.CmdOrden.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.CmdOrden.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdOrden.FlatAppearance.BorderSize = 0
        Me.CmdOrden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdOrden.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOrden.ForeColor = System.Drawing.Color.White
        Me.CmdOrden.Location = New System.Drawing.Point(756, 10)
        Me.CmdOrden.Name = "CmdOrden"
        Me.CmdOrden.Size = New System.Drawing.Size(96, 36)
        Me.CmdOrden.TabIndex = 6
        Me.CmdOrden.Tag = "28"
        Me.CmdOrden.Text = "Procesar"
        Me.CmdOrden.UseVisualStyleBackColor = False
        Me.CmdOrden.Visible = False
        '
        'CmdDesahacer
        '
        Me.CmdDesahacer.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.CmdDesahacer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdDesahacer.FlatAppearance.BorderSize = 0
        Me.CmdDesahacer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.CmdDesahacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdDesahacer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDesahacer.ForeColor = System.Drawing.Color.White
        Me.CmdDesahacer.Location = New System.Drawing.Point(756, 10)
        Me.CmdDesahacer.Name = "CmdDesahacer"
        Me.CmdDesahacer.Size = New System.Drawing.Size(96, 36)
        Me.CmdDesahacer.TabIndex = 7
        Me.CmdDesahacer.Tag = "28"
        Me.CmdDesahacer.Text = "Deshacer"
        Me.CmdDesahacer.UseVisualStyleBackColor = False
        Me.CmdDesahacer.Visible = False
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
        Me.BtnSalir.Location = New System.Drawing.Point(864, 10)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(96, 36)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'FrmEnsamble
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(980, 520)
        Me.Controls.Add(Me.PnlComponentes)
        Me.Controls.Add(Me.PnlProducto)
        Me.Controls.Add(Me.PnlDocumento)
        Me.Controls.Add(Me.PnlAcciones)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MaximizeBox = True
        Me.MinimizeBox = False
        Me.Name = "FrmEnsamble"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Control de Ensambles"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlDocumento.ResumeLayout(False)
        Me.PnlDocumento.PerformLayout()
        Me.PnlProducto.ResumeLayout(False)
        Me.PnlProducto.PerformLayout()
        Me.PnlComponentes.ResumeLayout(False)
        Me.PnlComponentes.PerformLayout()
        CType(Me.GridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents LblNumeroEnsamble As System.Windows.Forms.Label
    Friend WithEvents PnlDocumento As System.Windows.Forms.Panel
    Friend WithEvents LblTituloDocumento As System.Windows.Forms.Label
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents CboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarEnsamble As System.Windows.Forms.Button
    Friend WithEvents LblBodegaOrigen As System.Windows.Forms.Label
    Friend WithEvents CboCodigoBodega As System.Windows.Forms.ComboBox
    Friend WithEvents LblNombreBodegaOrigen As System.Windows.Forms.Label
    Friend WithEvents LblBodegaDestino As System.Windows.Forms.Label
    Friend WithEvents CboBodegaDestino As System.Windows.Forms.ComboBox
    Friend WithEvents LblNombreBodegaDestino As System.Windows.Forms.Label
    Friend WithEvents PnlProducto As System.Windows.Forms.Panel
    Friend WithEvents LblTituloProducto As System.Windows.Forms.Label
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents CmdAgregarProducto As System.Windows.Forms.Button
    Friend WithEvents CmdEnsambles As System.Windows.Forms.Button
    Friend WithEvents LblCantidad As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents LblRendimiento As System.Windows.Forms.Label
    Friend WithEvents TxtRendimiento As System.Windows.Forms.TextBox
    Friend WithEvents LblUnidadMedida As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents PnlComponentes As System.Windows.Forms.Panel
    Friend WithEvents LblTituloComponentes As System.Windows.Forms.Label
    Friend WithEvents LblResumen As System.Windows.Forms.Label
    Friend WithEvents BtnSeries As System.Windows.Forms.Button
    Friend WithEvents PnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents GridComponentes As System.Windows.Forms.DataGridView
    Friend WithEvents PnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents CmdProcesar As System.Windows.Forms.Button
    Friend WithEvents CmdOrden As System.Windows.Forms.Button
    Friend WithEvents CmdDesahacer As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
End Class
