Public Class FrmRecibosCaja
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Private pnlHeader As System.Windows.Forms.Panel
    Private lblTitulo As System.Windows.Forms.Label
    Private btnNuevo As System.Windows.Forms.Button
    Private btnImprimir As System.Windows.Forms.Button
    Private btnEliminar As System.Windows.Forms.Button

    Private pnlDatosGenerales As System.Windows.Forms.Panel
    Private lblFecha As System.Windows.Forms.Label
    Private dtpFecha As System.Windows.Forms.DateTimePicker
    Private lblNumero As System.Windows.Forms.Label
    Private cboTipoRecibo As System.Windows.Forms.ComboBox
    Private txtNumero As System.Windows.Forms.TextBox
    Private lblMoneda As System.Windows.Forms.Label
    Private cboMoneda As System.Windows.Forms.ComboBox

    Private pnlCliente As System.Windows.Forms.Panel
    Private lblSeccionCliente As System.Windows.Forms.Label
    Private btnAbono As System.Windows.Forms.Button
    Private btnPlanPago As System.Windows.Forms.Button
    Private txtBuscarCliente As System.Windows.Forms.TextBox
    Private btnBuscarCliente As System.Windows.Forms.Button
    Private txtDireccion As System.Windows.Forms.TextBox
    Private txtRucCedula As System.Windows.Forms.TextBox
    Private chkRetener1 As System.Windows.Forms.CheckBox
    Private chkRetener2 As System.Windows.Forms.CheckBox
    Private lblCajero As System.Windows.Forms.Label

    Private pnlDetalle As System.Windows.Forms.Panel
    Private lblSeccionDetalle As System.Windows.Forms.Label
    Private btnAgregarFila As System.Windows.Forms.Button
    Private dgvDetalle As System.Windows.Forms.DataGridView
    Private colNombrePago As System.Windows.Forms.DataGridViewTextBoxColumn
    Private colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Private colNumeroFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Private colMontoPagado As System.Windows.Forms.DataGridViewTextBoxColumn

    Private pnlTotales As System.Windows.Forms.TableLayoutPanel
    Private tarjetaSubTotal As System.Windows.Forms.Panel
    Private lblSubTotal As System.Windows.Forms.Label
    Private lblValorSubTotal As System.Windows.Forms.Label
    Private tarjetaDescuento As System.Windows.Forms.Panel
    Private lblDescuento As System.Windows.Forms.Label
    Private lblValorDescuento As System.Windows.Forms.Label
    Private tarjetaTotalRecibido As System.Windows.Forms.Panel
    Private lblTotalRecibido As System.Windows.Forms.Label
    Private lblValorTotalRecibido As System.Windows.Forms.Label
    Private tarjetaPorAplicar As System.Windows.Forms.Panel
    Private lblPorAplicar As System.Windows.Forms.Label
    Private lblValorPorAplicar As System.Windows.Forms.Label

    Private lblObservaciones As System.Windows.Forms.Label
    Private txtObservaciones As System.Windows.Forms.TextBox

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.pnlDatosGenerales = New System.Windows.Forms.Panel()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.cboTipoRecibo = New System.Windows.Forms.ComboBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.pnlCliente = New System.Windows.Forms.Panel()
        Me.lblSeccionCliente = New System.Windows.Forms.Label()
        Me.btnAbono = New System.Windows.Forms.Button()
        Me.btnPlanPago = New System.Windows.Forms.Button()
        Me.txtBuscarCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtRucCedula = New System.Windows.Forms.TextBox()
        Me.chkRetener1 = New System.Windows.Forms.CheckBox()
        Me.chkRetener2 = New System.Windows.Forms.CheckBox()
        Me.lblCajero = New System.Windows.Forms.Label()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.lblSeccionDetalle = New System.Windows.Forms.Label()
        Me.btnAgregarFila = New System.Windows.Forms.Button()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.colNombrePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumeroFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMontoPagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlTotales = New System.Windows.Forms.TableLayoutPanel()
        Me.tarjetaSubTotal = New System.Windows.Forms.Panel()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.lblValorSubTotal = New System.Windows.Forms.Label()
        Me.tarjetaDescuento = New System.Windows.Forms.Panel()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.lblValorDescuento = New System.Windows.Forms.Label()
        Me.tarjetaTotalRecibido = New System.Windows.Forms.Panel()
        Me.lblTotalRecibido = New System.Windows.Forms.Label()
        Me.lblValorTotalRecibido = New System.Windows.Forms.Label()
        Me.tarjetaPorAplicar = New System.Windows.Forms.Panel()
        Me.lblPorAplicar = New System.Windows.Forms.Label()
        Me.lblValorPorAplicar = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlDatosGenerales.SuspendLayout()
        Me.pnlCliente.SuspendLayout()
        Me.pnlDetalle.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotales.SuspendLayout()
        Me.tarjetaSubTotal.SuspendLayout()
        Me.tarjetaDescuento.SuspendLayout()
        Me.tarjetaTotalRecibido.SuspendLayout()
        Me.tarjetaPorAplicar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblTitulo)
        Me.pnlHeader.Controls.Add(Me.btnNuevo)
        Me.pnlHeader.Controls.Add(Me.btnImprimir)
        Me.pnlHeader.Controls.Add(Me.btnEliminar)
        Me.pnlHeader.Location = New System.Drawing.Point(20, 20)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(910, 56)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55)
        Me.lblTitulo.Location = New System.Drawing.Point(16, 16)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(140, 21)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Recibos de caja"
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackColor = System.Drawing.Color.White
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 229, 233)
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55)
        Me.btnNuevo.Location = New System.Drawing.Point(608, 12)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(90, 32)
        Me.btnNuevo.TabIndex = 1
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.Color.White
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 229, 233)
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55)
        Me.btnImprimir.Location = New System.Drawing.Point(706, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(90, 32)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.White
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 229, 233)
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnEliminar.Location = New System.Drawing.Point(804, 12)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(90, 32)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'pnlDatosGenerales
        '
        Me.pnlDatosGenerales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.pnlDatosGenerales.Controls.Add(Me.lblFecha)
        Me.pnlDatosGenerales.Controls.Add(Me.dtpFecha)
        Me.pnlDatosGenerales.Controls.Add(Me.lblNumero)
        Me.pnlDatosGenerales.Controls.Add(Me.cboTipoRecibo)
        Me.pnlDatosGenerales.Controls.Add(Me.txtNumero)
        Me.pnlDatosGenerales.Controls.Add(Me.lblMoneda)
        Me.pnlDatosGenerales.Controls.Add(Me.cboMoneda)
        Me.pnlDatosGenerales.Location = New System.Drawing.Point(20, 88)
        Me.pnlDatosGenerales.Name = "pnlDatosGenerales"
        Me.pnlDatosGenerales.Size = New System.Drawing.Size(910, 50)
        Me.pnlDatosGenerales.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblFecha.Location = New System.Drawing.Point(0, 0)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(35, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha.Location = New System.Drawing.Point(0, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(140, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblNumero.Location = New System.Drawing.Point(320, 0)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(45, 13)
        Me.lblNumero.TabIndex = 2
        Me.lblNumero.Text = "Numero"
        '
        'cboTipoRecibo
        '
        Me.cboTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRecibo.Items.AddRange(New Object() {"B"})
        Me.cboTipoRecibo.Location = New System.Drawing.Point(320, 20)
        Me.cboTipoRecibo.Name = "cboTipoRecibo"
        Me.cboTipoRecibo.Size = New System.Drawing.Size(55, 21)
        Me.cboTipoRecibo.TabIndex = 3
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(380, 20)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(150, 20)
        Me.txtNumero.TabIndex = 4
        Me.txtNumero.Text = "0"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblMoneda.Location = New System.Drawing.Point(650, 0)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblMoneda.TabIndex = 5
        Me.lblMoneda.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.cboMoneda.Location = New System.Drawing.Point(650, 20)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(150, 21)
        Me.cboMoneda.TabIndex = 6
        '
        'pnlCliente
        '
        Me.pnlCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.pnlCliente.BackColor = System.Drawing.Color.White
        Me.pnlCliente.Controls.Add(Me.lblSeccionCliente)
        Me.pnlCliente.Controls.Add(Me.btnAbono)
        Me.pnlCliente.Controls.Add(Me.btnPlanPago)
        Me.pnlCliente.Controls.Add(Me.txtBuscarCliente)
        Me.pnlCliente.Controls.Add(Me.btnBuscarCliente)
        Me.pnlCliente.Controls.Add(Me.txtDireccion)
        Me.pnlCliente.Controls.Add(Me.txtRucCedula)
        Me.pnlCliente.Controls.Add(Me.chkRetener1)
        Me.pnlCliente.Controls.Add(Me.chkRetener2)
        Me.pnlCliente.Controls.Add(Me.lblCajero)
        Me.pnlCliente.Location = New System.Drawing.Point(20, 150)
        Me.pnlCliente.Name = "pnlCliente"
        Me.pnlCliente.Size = New System.Drawing.Size(910, 160)
        Me.pnlCliente.TabIndex = 2
        '
        'lblSeccionCliente
        '
        Me.lblSeccionCliente.AutoSize = True
        Me.lblSeccionCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeccionCliente.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblSeccionCliente.Location = New System.Drawing.Point(16, 12)
        Me.lblSeccionCliente.Name = "lblSeccionCliente"
        Me.lblSeccionCliente.Size = New System.Drawing.Size(140, 15)
        Me.lblSeccionCliente.TabIndex = 0
        Me.lblSeccionCliente.Text = "Informacion del cliente"
        '
        'btnAbono
        '
        Me.btnAbono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.btnAbono.BackColor = System.Drawing.Color.White
        Me.btnAbono.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnAbono.FlatAppearance.BorderSize = 2
        Me.btnAbono.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbono.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAbono.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.btnAbono.Location = New System.Drawing.Point(666, 8)
        Me.btnAbono.Name = "btnAbono"
        Me.btnAbono.Size = New System.Drawing.Size(100, 32)
        Me.btnAbono.TabIndex = 1
        Me.btnAbono.Text = "Abono"
        Me.btnAbono.UseVisualStyleBackColor = False
        '
        'btnPlanPago
        '
        Me.btnPlanPago.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.btnPlanPago.BackColor = System.Drawing.Color.White
        Me.btnPlanPago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 229, 233)
        Me.btnPlanPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlanPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPlanPago.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55)
        Me.btnPlanPago.Location = New System.Drawing.Point(774, 8)
        Me.btnPlanPago.Name = "btnPlanPago"
        Me.btnPlanPago.Size = New System.Drawing.Size(120, 32)
        Me.btnPlanPago.TabIndex = 2
        Me.btnPlanPago.Text = "Plan de pago"
        Me.btnPlanPago.UseVisualStyleBackColor = False
        '
        'txtBuscarCliente
        '
        Me.txtBuscarCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.txtBuscarCliente.Location = New System.Drawing.Point(16, 44)
        Me.txtBuscarCliente.Name = "txtBuscarCliente"
        Me.txtBuscarCliente.Size = New System.Drawing.Size(830, 20)
        Me.txtBuscarCliente.TabIndex = 3
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 229, 233)
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarCliente.Location = New System.Drawing.Point(858, 44)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(36, 24)
        Me.btnBuscarCliente.TabIndex = 4
        Me.btnBuscarCliente.Text = "..."
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.Location = New System.Drawing.Point(16, 78)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(437, 20)
        Me.txtDireccion.TabIndex = 5
        '
        'txtRucCedula
        '
        Me.txtRucCedula.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.txtRucCedula.Location = New System.Drawing.Point(465, 78)
        Me.txtRucCedula.Name = "txtRucCedula"
        Me.txtRucCedula.Size = New System.Drawing.Size(429, 20)
        Me.txtRucCedula.TabIndex = 6
        '
        'chkRetener1
        '
        Me.chkRetener1.AutoSize = True
        Me.chkRetener1.Location = New System.Drawing.Point(16, 116)
        Me.chkRetener1.Name = "chkRetener1"
        Me.chkRetener1.Size = New System.Drawing.Size(85, 17)
        Me.chkRetener1.TabIndex = 7
        Me.chkRetener1.Text = "Retener 1%"
        Me.chkRetener1.UseVisualStyleBackColor = True
        '
        'chkRetener2
        '
        Me.chkRetener2.AutoSize = True
        Me.chkRetener2.Location = New System.Drawing.Point(120, 116)
        Me.chkRetener2.Name = "chkRetener2"
        Me.chkRetener2.Size = New System.Drawing.Size(85, 17)
        Me.chkRetener2.TabIndex = 8
        Me.chkRetener2.Text = "Retener 2%"
        Me.chkRetener2.UseVisualStyleBackColor = True
        '
        'lblCajero
        '
        Me.lblCajero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.lblCajero.AutoSize = True
        Me.lblCajero.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblCajero.Location = New System.Drawing.Point(800, 118)
        Me.lblCajero.Name = "lblCajero"
        Me.lblCajero.Size = New System.Drawing.Size(65, 13)
        Me.lblCajero.TabIndex = 9
        Me.lblCajero.Text = "Cajero: 001"
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Anchor = CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.pnlDetalle.BackColor = System.Drawing.Color.White
        Me.pnlDetalle.Controls.Add(Me.lblSeccionDetalle)
        Me.pnlDetalle.Controls.Add(Me.btnAgregarFila)
        Me.pnlDetalle.Controls.Add(Me.dgvDetalle)
        Me.pnlDetalle.Location = New System.Drawing.Point(20, 322)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(910, 260)
        Me.pnlDetalle.TabIndex = 3
        '
        'lblSeccionDetalle
        '
        Me.lblSeccionDetalle.AutoSize = True
        Me.lblSeccionDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeccionDetalle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblSeccionDetalle.Location = New System.Drawing.Point(16, 12)
        Me.lblSeccionDetalle.Name = "lblSeccionDetalle"
        Me.lblSeccionDetalle.Size = New System.Drawing.Size(120, 15)
        Me.lblSeccionDetalle.TabIndex = 0
        Me.lblSeccionDetalle.Text = "Detalle de recibos"
        '
        'btnAgregarFila
        '
        Me.btnAgregarFila.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarFila.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 229, 233)
        Me.btnAgregarFila.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarFila.Location = New System.Drawing.Point(864, 8)
        Me.btnAgregarFila.Name = "btnAgregarFila"
        Me.btnAgregarFila.Size = New System.Drawing.Size(30, 24)
        Me.btnAgregarFila.TabIndex = 1
        Me.btnAgregarFila.Text = "+"
        Me.btnAgregarFila.UseVisualStyleBackColor = True
        '
        'dgvDetalle
        '
        Me.dgvDetalle.Anchor = CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNombrePago, Me.colDescripcion, Me.colNumeroFactura, Me.colMontoPagado})
        Me.dgvDetalle.EnableHeadersVisualStyles = False
        Me.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(226, 229, 233)
        Me.dgvDetalle.Location = New System.Drawing.Point(16, 44)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.Size = New System.Drawing.Size(878, 200)
        Me.dgvDetalle.TabIndex = 2
        '
        'colNombrePago
        '
        Me.colNombrePago.FillWeight = 25.0!
        Me.colNombrePago.HeaderText = "Nombre pago"
        Me.colNombrePago.Name = "colNombrePago"
        '
        'colDescripcion
        '
        Me.colDescripcion.FillWeight = 35.0!
        Me.colDescripcion.HeaderText = "Descripcion"
        Me.colDescripcion.Name = "colDescripcion"
        '
        'colNumeroFactura
        '
        Me.colNumeroFactura.FillWeight = 20.0!
        Me.colNumeroFactura.HeaderText = "No. factura"
        Me.colNumeroFactura.Name = "colNumeroFactura"
        '
        'colMontoPagado
        '
        Me.colMontoPagado.FillWeight = 20.0!
        Me.colMontoPagado.HeaderText = "Monto"
        Me.colMontoPagado.Name = "colMontoPagado"
        '
        'pnlTotales
        '
        Me.pnlTotales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.pnlTotales.ColumnCount = 4
        Me.pnlTotales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.pnlTotales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.pnlTotales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.pnlTotales.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.pnlTotales.Controls.Add(Me.tarjetaSubTotal, 0, 0)
        Me.pnlTotales.Controls.Add(Me.tarjetaDescuento, 1, 0)
        Me.pnlTotales.Controls.Add(Me.tarjetaTotalRecibido, 2, 0)
        Me.pnlTotales.Controls.Add(Me.tarjetaPorAplicar, 3, 0)
        Me.pnlTotales.Location = New System.Drawing.Point(20, 594)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.RowCount = 1
        Me.pnlTotales.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlTotales.Size = New System.Drawing.Size(910, 66)
        Me.pnlTotales.TabIndex = 4
        '
        'tarjetaSubTotal
        '
        Me.tarjetaSubTotal.BackColor = System.Drawing.Color.White
        Me.tarjetaSubTotal.Controls.Add(Me.lblSubTotal)
        Me.tarjetaSubTotal.Controls.Add(Me.lblValorSubTotal)
        Me.tarjetaSubTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tarjetaSubTotal.Location = New System.Drawing.Point(3, 3)
        Me.tarjetaSubTotal.Margin = New System.Windows.Forms.Padding(3, 3, 8, 3)
        Me.tarjetaSubTotal.Name = "tarjetaSubTotal"
        Me.tarjetaSubTotal.Size = New System.Drawing.Size(214, 60)
        Me.tarjetaSubTotal.TabIndex = 0
        '
        'lblSubTotal
        '
        Me.lblSubTotal.AutoSize = True
        Me.lblSubTotal.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblSubTotal.Location = New System.Drawing.Point(12, 8)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(52, 15)
        Me.lblSubTotal.TabIndex = 0
        Me.lblSubTotal.Text = "Sub total"
        '
        'lblValorSubTotal
        '
        Me.lblValorSubTotal.AutoSize = True
        Me.lblValorSubTotal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblValorSubTotal.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55)
        Me.lblValorSubTotal.Location = New System.Drawing.Point(12, 28)
        Me.lblValorSubTotal.Name = "lblValorSubTotal"
        Me.lblValorSubTotal.Size = New System.Drawing.Size(75, 20)
        Me.lblValorSubTotal.TabIndex = 1
        Me.lblValorSubTotal.Text = "C$ 0.00"
        '
        'tarjetaDescuento
        '
        Me.tarjetaDescuento.BackColor = System.Drawing.Color.White
        Me.tarjetaDescuento.Controls.Add(Me.lblDescuento)
        Me.tarjetaDescuento.Controls.Add(Me.lblValorDescuento)
        Me.tarjetaDescuento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tarjetaDescuento.Location = New System.Drawing.Point(230, 3)
        Me.tarjetaDescuento.Margin = New System.Windows.Forms.Padding(3, 3, 8, 3)
        Me.tarjetaDescuento.Name = "tarjetaDescuento"
        Me.tarjetaDescuento.Size = New System.Drawing.Size(214, 60)
        Me.tarjetaDescuento.TabIndex = 1
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblDescuento.Location = New System.Drawing.Point(12, 8)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(62, 15)
        Me.lblDescuento.TabIndex = 0
        Me.lblDescuento.Text = "Descuento"
        '
        'lblValorDescuento
        '
        Me.lblValorDescuento.AutoSize = True
        Me.lblValorDescuento.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblValorDescuento.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55)
        Me.lblValorDescuento.Location = New System.Drawing.Point(12, 28)
        Me.lblValorDescuento.Name = "lblValorDescuento"
        Me.lblValorDescuento.Size = New System.Drawing.Size(75, 20)
        Me.lblValorDescuento.TabIndex = 1
        Me.lblValorDescuento.Text = "C$ 0.00"
        '
        'tarjetaTotalRecibido
        '
        Me.tarjetaTotalRecibido.BackColor = System.Drawing.Color.White
        Me.tarjetaTotalRecibido.Controls.Add(Me.lblTotalRecibido)
        Me.tarjetaTotalRecibido.Controls.Add(Me.lblValorTotalRecibido)
        Me.tarjetaTotalRecibido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tarjetaTotalRecibido.Location = New System.Drawing.Point(457, 3)
        Me.tarjetaTotalRecibido.Margin = New System.Windows.Forms.Padding(3, 3, 8, 3)
        Me.tarjetaTotalRecibido.Name = "tarjetaTotalRecibido"
        Me.tarjetaTotalRecibido.Size = New System.Drawing.Size(214, 60)
        Me.tarjetaTotalRecibido.TabIndex = 2
        '
        'lblTotalRecibido
        '
        Me.lblTotalRecibido.AutoSize = True
        Me.lblTotalRecibido.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblTotalRecibido.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblTotalRecibido.Location = New System.Drawing.Point(12, 8)
        Me.lblTotalRecibido.Name = "lblTotalRecibido"
        Me.lblTotalRecibido.Size = New System.Drawing.Size(82, 15)
        Me.lblTotalRecibido.TabIndex = 0
        Me.lblTotalRecibido.Text = "Total recibido"
        '
        'lblValorTotalRecibido
        '
        Me.lblValorTotalRecibido.AutoSize = True
        Me.lblValorTotalRecibido.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblValorTotalRecibido.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55)
        Me.lblValorTotalRecibido.Location = New System.Drawing.Point(12, 28)
        Me.lblValorTotalRecibido.Name = "lblValorTotalRecibido"
        Me.lblValorTotalRecibido.Size = New System.Drawing.Size(75, 20)
        Me.lblValorTotalRecibido.TabIndex = 1
        Me.lblValorTotalRecibido.Text = "C$ 0.00"
        '
        'tarjetaPorAplicar
        '
        Me.tarjetaPorAplicar.BackColor = System.Drawing.Color.FromArgb(239, 246, 255)
        Me.tarjetaPorAplicar.Controls.Add(Me.lblPorAplicar)
        Me.tarjetaPorAplicar.Controls.Add(Me.lblValorPorAplicar)
        Me.tarjetaPorAplicar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tarjetaPorAplicar.Location = New System.Drawing.Point(684, 3)
        Me.tarjetaPorAplicar.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.tarjetaPorAplicar.Name = "tarjetaPorAplicar"
        Me.tarjetaPorAplicar.Size = New System.Drawing.Size(223, 60)
        Me.tarjetaPorAplicar.TabIndex = 3
        '
        'lblPorAplicar
        '
        Me.lblPorAplicar.AutoSize = True
        Me.lblPorAplicar.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblPorAplicar.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.lblPorAplicar.Location = New System.Drawing.Point(12, 8)
        Me.lblPorAplicar.Name = "lblPorAplicar"
        Me.lblPorAplicar.Size = New System.Drawing.Size(63, 15)
        Me.lblPorAplicar.TabIndex = 0
        Me.lblPorAplicar.Text = "Por aplicar"
        '
        'lblValorPorAplicar
        '
        Me.lblValorPorAplicar.AutoSize = True
        Me.lblValorPorAplicar.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblValorPorAplicar.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235)
        Me.lblValorPorAplicar.Location = New System.Drawing.Point(12, 28)
        Me.lblValorPorAplicar.Name = "lblValorPorAplicar"
        Me.lblValorPorAplicar.Size = New System.Drawing.Size(75, 20)
        Me.lblValorPorAplicar.TabIndex = 1
        Me.lblValorPorAplicar.Text = "C$ 0.00"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128)
        Me.lblObservaciones.Location = New System.Drawing.Point(20, 672)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(85, 13)
        Me.lblObservaciones.TabIndex = 5
        Me.lblObservaciones.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(20, 692)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(910, 48)
        Me.txtObservaciones.TabIndex = 6
        '
        'FrmRecibosCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(243, 244, 246)
        Me.ClientSize = New System.Drawing.Size(950, 760)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.pnlTotales)
        Me.Controls.Add(Me.pnlDetalle)
        Me.Controls.Add(Me.pnlCliente)
        Me.Controls.Add(Me.pnlDatosGenerales)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(900, 700)
        Me.Name = "FrmRecibosCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibos de Caja"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlDatosGenerales.ResumeLayout(False)
        Me.pnlDatosGenerales.PerformLayout()
        Me.pnlCliente.ResumeLayout(False)
        Me.pnlCliente.PerformLayout()
        Me.pnlDetalle.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotales.ResumeLayout(False)
        Me.tarjetaSubTotal.ResumeLayout(False)
        Me.tarjetaSubTotal.PerformLayout()
        Me.tarjetaDescuento.ResumeLayout(False)
        Me.tarjetaDescuento.PerformLayout()
        Me.tarjetaTotalRecibido.ResumeLayout(False)
        Me.tarjetaTotalRecibido.PerformLayout()
        Me.tarjetaPorAplicar.ResumeLayout(False)
        Me.tarjetaPorAplicar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

End Class
