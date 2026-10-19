Public Class FrmTransferenciaBodegas
    Inherits System.Windows.Forms.Form

#Region "Campos de controles"
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblFlecha As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button

    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button

    Friend WithEvents grpBodegas As System.Windows.Forms.GroupBox
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox

    Friend WithEvents pnlHerramientas As System.Windows.Forms.Panel
    Friend WithEvents btnEscanear As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button

    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents pnlGridContenedor As System.Windows.Forms.Panel
    Friend WithEvents lblListado As System.Windows.Forms.Label
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnBorrarLinea As System.Windows.Forms.Button

    Friend WithEvents pnlTotal As System.Windows.Forms.Panel
    Friend WithEvents lblTotalTitulo As System.Windows.Forms.Label
    Friend WithEvents txtTotalCosto As System.Windows.Forms.TextBox

    Friend WithEvents grpObservaciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox

    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
#End Region

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblFlecha = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grpBodegas = New System.Windows.Forms.GroupBox()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.pnlHerramientas = New System.Windows.Forms.Panel()
        Me.btnEscanear = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.pnlGridContenedor = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnBorrarLinea = New System.Windows.Forms.Button()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.lblListado = New System.Windows.Forms.Label()
        Me.pnlTotal = New System.Windows.Forms.Panel()
        Me.lblTotalTitulo = New System.Windows.Forms.Label()
        Me.txtTotalCosto = New System.Windows.Forms.TextBox()
        Me.grpObservaciones = New System.Windows.Forms.GroupBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.grpBodegas.SuspendLayout()
        Me.pnlHerramientas.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        Me.pnlGridContenedor.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotal.SuspendLayout()
        Me.grpObservaciones.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 98, 173)
        Me.pnlHeader.Controls.Add(Me.lblTitulo)
        Me.pnlHeader.Controls.Add(Me.btnCerrar)
        Me.pnlHeader.Controls.Add(Me.lblFlecha)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(900, 64)
        Me.pnlHeader.TabIndex = 0
        '
        'lblFlecha
        '
        Me.lblFlecha.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblFlecha.ForeColor = System.Drawing.Color.White
        Me.lblFlecha.Location = New System.Drawing.Point(8, 0)
        Me.lblFlecha.Name = "lblFlecha"
        Me.lblFlecha.Size = New System.Drawing.Size(56, 64)
        Me.lblFlecha.TabIndex = 0
        Me.lblFlecha.Text = "<->"
        Me.lblFlecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(56, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(796, 64)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "TRANSFERENCIAS DE BODEGAS"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.FromArgb(41, 98, 173)
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 70, 70)
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Location = New System.Drawing.Point(852, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(48, 64)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.TabStop = False
        Me.btnCerrar.Text = "X"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.White
        Me.pnlFiltros.Controls.Add(Me.lblTipo)
        Me.pnlFiltros.Controls.Add(Me.cboTipo)
        Me.pnlFiltros.Controls.Add(Me.lblFecha)
        Me.pnlFiltros.Controls.Add(Me.dtpFecha)
        Me.pnlFiltros.Controls.Add(Me.lblNumero)
        Me.pnlFiltros.Controls.Add(Me.txtNumero)
        Me.pnlFiltros.Controls.Add(Me.btnBuscar)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 64)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(900, 54)
        Me.pnlFiltros.TabIndex = 1
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.lblTipo.Location = New System.Drawing.Point(20, 16)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 15)
        Me.lblTipo.TabIndex = 0
        Me.lblTipo.Text = "Tipo"
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboTipo.Items.AddRange(New Object() {"Transferencia Enviada", "Transferencia Recibida"})
        Me.cboTipo.Location = New System.Drawing.Point(65, 12)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(190, 25)
        Me.cboTipo.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.lblFecha.Location = New System.Drawing.Point(275, 16)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 15)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha.Location = New System.Drawing.Point(320, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(120, 25)
        Me.dtpFecha.TabIndex = 3
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNumero.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.lblNumero.Location = New System.Drawing.Point(610, 16)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(50, 15)
        Me.lblNumero.TabIndex = 4
        Me.lblNumero.Text = "Número"
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtNumero.Location = New System.Drawing.Point(665, 12)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(110, 25)
        Me.txtNumero.TabIndex = 5
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(41, 98, 173)
        Me.btnBuscar.Location = New System.Drawing.Point(782, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(30, 30)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Q"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'grpBodegas
        '
        Me.grpBodegas.Controls.Add(Me.lblOrigen)
        Me.grpBodegas.Controls.Add(Me.cboOrigen)
        Me.grpBodegas.Controls.Add(Me.lblDestino)
        Me.grpBodegas.Controls.Add(Me.cboDestino)
        Me.grpBodegas.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBodegas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.grpBodegas.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41)
        Me.grpBodegas.Location = New System.Drawing.Point(0, 118)
        Me.grpBodegas.Name = "grpBodegas"
        Me.grpBodegas.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.grpBodegas.Size = New System.Drawing.Size(900, 66)
        Me.grpBodegas.TabIndex = 2
        Me.grpBodegas.TabStop = False
        Me.grpBodegas.Text = "Bodegas de Transferencias"
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOrigen.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.lblOrigen.Location = New System.Drawing.Point(16, 34)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(80, 15)
        Me.lblOrigen.TabIndex = 0
        Me.lblOrigen.Text = "Bodega Origen"
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOrigen.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboOrigen.Items.AddRange(New Object() {"01 - Matagalpa", "02 - Managua"})
        Me.cboOrigen.Location = New System.Drawing.Point(140, 30)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(130, 25)
        Me.cboOrigen.TabIndex = 1
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDestino.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.lblDestino.Location = New System.Drawing.Point(560, 34)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(86, 15)
        Me.lblDestino.TabIndex = 2
        Me.lblDestino.Text = "Bodega Destino"
        '
        'cboDestino
        '
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDestino.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboDestino.Items.AddRange(New Object() {"01 - Matagalpa", "02 - Managua"})
        Me.cboDestino.Location = New System.Drawing.Point(690, 30)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(130, 25)
        Me.cboDestino.TabIndex = 3
        '
        'pnlHerramientas
        '
        Me.pnlHerramientas.Controls.Add(Me.btnEscanear)
        Me.pnlHerramientas.Controls.Add(Me.btnAgregar)
        Me.pnlHerramientas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHerramientas.Location = New System.Drawing.Point(0, 184)
        Me.pnlHerramientas.Name = "pnlHerramientas"
        Me.pnlHerramientas.Size = New System.Drawing.Size(900, 44)
        Me.pnlHerramientas.TabIndex = 3
        '
        'btnEscanear
        '
        Me.btnEscanear.BackColor = System.Drawing.Color.White
        Me.btnEscanear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.btnEscanear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.btnEscanear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEscanear.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEscanear.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41)
        Me.btnEscanear.Location = New System.Drawing.Point(20, 6)
        Me.btnEscanear.Name = "btnEscanear"
        Me.btnEscanear.Size = New System.Drawing.Size(130, 32)
        Me.btnEscanear.TabIndex = 0
        Me.btnEscanear.TabStop = False
        Me.btnEscanear.Text = "Escanear"
        Me.btnEscanear.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.White
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41)
        Me.btnAgregar.Location = New System.Drawing.Point(160, 6)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(150, 32)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.TabStop = False
        Me.btnAgregar.Text = "+  Agregar línea"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.pnlGrid.Controls.Add(Me.pnlGridContenedor)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrid.Location = New System.Drawing.Point(0, 228)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Padding = New System.Windows.Forms.Padding(20, 4, 20, 4)
        Me.pnlGrid.Size = New System.Drawing.Size(900, 260)
        Me.pnlGrid.TabIndex = 4
        '
        'pnlGridContenedor
        '
        Me.pnlGridContenedor.BackColor = System.Drawing.Color.White
        Me.pnlGridContenedor.Controls.Add(Me.dgvProductos)
        Me.pnlGridContenedor.Controls.Add(Me.pnlAcciones)
        Me.pnlGridContenedor.Controls.Add(Me.lblListado)
        Me.pnlGridContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGridContenedor.Location = New System.Drawing.Point(20, 4)
        Me.pnlGridContenedor.Name = "pnlGridContenedor"
        Me.pnlGridContenedor.Size = New System.Drawing.Size(860, 252)
        Me.pnlGridContenedor.TabIndex = 0
        '
        'lblListado
        '
        Me.lblListado.BackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.lblListado.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblListado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblListado.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.lblListado.Location = New System.Drawing.Point(0, 0)
        Me.lblListado.Name = "lblListado"
        Me.lblListado.Size = New System.Drawing.Size(860, 28)
        Me.lblListado.TabIndex = 0
        Me.lblListado.Text = "LISTADO DE PRODUCTOS"
        Me.lblListado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnBorrarLinea)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 210)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(860, 42)
        Me.pnlAcciones.TabIndex = 2
        '
        'btnBorrarLinea
        '
        Me.btnBorrarLinea.BackColor = System.Drawing.Color.White
        Me.btnBorrarLinea.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.btnBorrarLinea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.btnBorrarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrarLinea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBorrarLinea.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69)
        Me.btnBorrarLinea.Location = New System.Drawing.Point(8, 6)
        Me.btnBorrarLinea.Name = "btnBorrarLinea"
        Me.btnBorrarLinea.Size = New System.Drawing.Size(150, 30)
        Me.btnBorrarLinea.TabIndex = 0
        Me.btnBorrarLinea.TabStop = False
        Me.btnBorrarLinea.Text = "Borrar línea"
        Me.btnBorrarLinea.UseVisualStyleBackColor = False
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToResizeRows = False
        Me.dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.dgvProductos.BackgroundColor = System.Drawing.Color.White
        Me.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(41, 98, 173)
        Me.dgvProductos.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.dgvProductos.ColumnHeadersHeight = 34
        Me.dgvProductos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.dgvProductos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(33, 37, 41)
        Me.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductos.EnableHeadersVisualStyles = False
        Me.dgvProductos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgvProductos.GridColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.dgvProductos.Location = New System.Drawing.Point(0, 28)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.RowHeadersVisible = False
        Me.dgvProductos.RowTemplate.Height = 30
        Me.dgvProductos.Size = New System.Drawing.Size(860, 182)
        Me.dgvProductos.TabIndex = 1
        '
        'pnlTotal
        '
        Me.pnlTotal.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.pnlTotal.Controls.Add(Me.lblTotalTitulo)
        Me.pnlTotal.Controls.Add(Me.txtTotalCosto)
        Me.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTotal.Location = New System.Drawing.Point(0, 488)
        Me.pnlTotal.Name = "pnlTotal"
        Me.pnlTotal.Size = New System.Drawing.Size(900, 48)
        Me.pnlTotal.TabIndex = 5
        '
        'lblTotalTitulo
        '
        Me.lblTotalTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41)
        Me.lblTotalTitulo.Location = New System.Drawing.Point(560, 9)
        Me.lblTotalTitulo.Name = "lblTotalTitulo"
        Me.lblTotalTitulo.Size = New System.Drawing.Size(140, 30)
        Me.lblTotalTitulo.TabIndex = 0
        Me.lblTotalTitulo.Text = "TOTAL COSTO"
        Me.lblTotalTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalCosto
        '
        Me.txtTotalCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCosto.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalCosto.ForeColor = System.Drawing.Color.FromArgb(41, 98, 173)
        Me.txtTotalCosto.Location = New System.Drawing.Point(710, 8)
        Me.txtTotalCosto.Name = "txtTotalCosto"
        Me.txtTotalCosto.ReadOnly = True
        Me.txtTotalCosto.Size = New System.Drawing.Size(130, 29)
        Me.txtTotalCosto.TabIndex = 1
        Me.txtTotalCosto.Text = "0.00"
        Me.txtTotalCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpObservaciones
        '
        Me.grpObservaciones.Controls.Add(Me.txtObservaciones)
        Me.grpObservaciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpObservaciones.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.grpObservaciones.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41)
        Me.grpObservaciones.Location = New System.Drawing.Point(0, 536)
        Me.grpObservaciones.Name = "grpObservaciones"
        Me.grpObservaciones.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.grpObservaciones.Size = New System.Drawing.Size(900, 74)
        Me.grpObservaciones.TabIndex = 6
        Me.grpObservaciones.TabStop = False
        Me.grpObservaciones.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObservaciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtObservaciones.Location = New System.Drawing.Point(12, 24)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(876, 42)
        Me.txtObservaciones.TabIndex = 0
        '
        'pnlBotones
        '
        Me.pnlBotones.BackColor = System.Drawing.Color.White
        Me.pnlBotones.Controls.Add(Me.btnNuevo)
        Me.pnlBotones.Controls.Add(Me.btnGrabar)
        Me.pnlBotones.Controls.Add(Me.btnAnular)
        Me.pnlBotones.Controls.Add(Me.btnImprimir)
        Me.pnlBotones.Controls.Add(Me.btnSalir)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotones.Location = New System.Drawing.Point(0, 610)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(900, 78)
        Me.pnlBotones.TabIndex = 7
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.White
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(41, 98, 173)
        Me.btnNuevo.Location = New System.Drawing.Point(20, 10)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(80, 58)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.TabStop = False
        Me.btnNuevo.Text = "+" & Microsoft.VisualBasic.Constants.vbCrLf & "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.Color.White
        Me.btnGrabar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.btnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGrabar.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.btnGrabar.Location = New System.Drawing.Point(110, 10)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(80, 58)
        Me.btnGrabar.TabIndex = 1
        Me.btnGrabar.TabStop = False
        Me.btnGrabar.Text = "Disk" & Microsoft.VisualBasic.Constants.vbCrLf & "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'btnAnular
        '
        Me.btnAnular.BackColor = System.Drawing.Color.White
        Me.btnAnular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnular.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAnular.ForeColor = System.Drawing.Color.FromArgb(255, 193, 7)
        Me.btnAnular.Location = New System.Drawing.Point(200, 10)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(80, 58)
        Me.btnAnular.TabIndex = 2
        Me.btnAnular.TabStop = False
        Me.btnAnular.Text = "X" & Microsoft.VisualBasic.Constants.vbCrLf & "Anular"
        Me.btnAnular.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.White
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230)
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 240, 250)
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125)
        Me.btnImprimir.Location = New System.Drawing.Point(290, 10)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 58)
        Me.btnImprimir.TabIndex = 3
        Me.btnImprimir.TabStop = False
        Me.btnImprimir.Text = "Print" & Microsoft.VisualBasic.Constants.vbCrLf & "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(220, 53, 69)
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(770, 10)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(110, 58)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.TabStop = False
        Me.btnSalir.Text = "->  Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'FrmTransferenciaBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(900, 688)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.pnlTotal)
        Me.Controls.Add(Me.grpObservaciones)
        Me.Controls.Add(Me.pnlBotones)
        Me.Controls.Add(Me.pnlHerramientas)
        Me.Controls.Add(Me.grpBodegas)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTransferenciaBodegas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencias de Bodegas"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.grpBodegas.ResumeLayout(False)
        Me.grpBodegas.PerformLayout()
        Me.pnlHerramientas.ResumeLayout(False)
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGridContenedor.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotal.ResumeLayout(False)
        Me.grpObservaciones.ResumeLayout(False)
        Me.grpObservaciones.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub FrmTransferenciaBodegas_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        ' Columnas del grid (se agregan aquí, fuera de InitializeComponent, para no romper el diseñador)
        Me.dgvProductos.Columns.Clear()
        Me.dgvProductos.Columns.Add("Codigo", "Código")
        Me.dgvProductos.Columns.Add("Descripcion", "Descripción")
        Me.dgvProductos.Columns.Add("Lote", "Lote")
        Me.dgvProductos.Columns.Add("Cantidad", "Cantidad")
        Me.dgvProductos.Columns.Add("CostoUnitario", "Costo Unit.")
        Me.dgvProductos.Columns.Add("CostoNeto", "Costo Neto")
        Me.dgvProductos.Columns.Add("Importe", "Importe")

        Me.dgvProductos.Columns("Descripcion").FillWeight = 220
        Me.dgvProductos.Columns("Cantidad").DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgvProductos.Columns("CostoUnitario").DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgvProductos.Columns("CostoNeto").DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgvProductos.Columns("Importe").DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
