Imports System.Windows.Forms
Imports System.Drawing

Partial Class FrmPlanPago
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    ' ---- Controles: Panel general con scroll ----
    Friend WithEvents pnlContenedor As Panel

    ' ---- Tarjeta 1: Datos de la factura ----
    Friend WithEvents pnlDatosFactura As Panel
    Friend WithEvents lblTituloDatos As Label
    Friend WithEvents pnlSepDatos As Panel
    Friend WithEvents lblNumeroFactura As Label
    Friend WithEvents txtNumeroFactura As TextBox
    Friend WithEvents lblFechaFactura As Label
    Friend WithEvents dtpFechaFactura As DateTimePicker
    Friend WithEvents lblVencimientoActual As Label
    Friend WithEvents dtpVencimientoActual As DateTimePicker
    Friend WithEvents lblMontoCredito As Label
    Friend WithEvents txtMontoCredito As TextBox

    ' ---- Tarjeta 2: Condiciones del plan ----
    Friend WithEvents pnlCondicionesPlan As Panel
    Friend WithEvents lblTituloCondiciones As Label
    Friend WithEvents pnlSepCondiciones As Panel
    Friend WithEvents lblCuotas As Label
    Friend WithEvents nudCuotas As NumericUpDown
    Friend WithEvents lblFrecuencia As Label
    Friend WithEvents cboFrecuencia As ComboBox
    Friend WithEvents lblInteres As Label
    Friend WithEvents nudInteres As NumericUpDown
    Friend WithEvents lblMora As Label
    Friend WithEvents nudMora As NumericUpDown
    Friend WithEvents lblMantenimiento As Label
    Friend WithEvents nudMantenimiento As NumericUpDown
    Friend WithEvents btnCrear As Button

    ' ---- Tarjeta 3: Detalle del plan ----
    Friend WithEvents pnlDetallePlan As Panel
    Friend WithEvents lblTituloDetalle As Label
    Friend WithEvents pnlSepDetalle As Panel

    ' ---- Barra inferior de acciones ----
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnAnular As Button
    Friend WithEvents btnSalir As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlanPago))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlDetallePlan = New System.Windows.Forms.Panel()
        Me.TrueDBGridDetallePlan = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlSepDetalle = New System.Windows.Forms.Panel()
        Me.lblTituloDetalle = New System.Windows.Forms.Label()
        Me.pnlCondicionesPlan = New System.Windows.Forms.Panel()
        Me.btnCrear = New System.Windows.Forms.Button()
        Me.nudMantenimiento = New System.Windows.Forms.NumericUpDown()
        Me.lblMantenimiento = New System.Windows.Forms.Label()
        Me.nudMora = New System.Windows.Forms.NumericUpDown()
        Me.lblMora = New System.Windows.Forms.Label()
        Me.nudInteres = New System.Windows.Forms.NumericUpDown()
        Me.lblInteres = New System.Windows.Forms.Label()
        Me.cboFrecuencia = New System.Windows.Forms.ComboBox()
        Me.lblFrecuencia = New System.Windows.Forms.Label()
        Me.nudCuotas = New System.Windows.Forms.NumericUpDown()
        Me.lblCuotas = New System.Windows.Forms.Label()
        Me.pnlSepCondiciones = New System.Windows.Forms.Panel()
        Me.lblTituloCondiciones = New System.Windows.Forms.Label()
        Me.pnlDatosFactura = New System.Windows.Forms.Panel()
        Me.TxtMonedaFactura = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMontoCredito = New System.Windows.Forms.TextBox()
        Me.lblMontoCredito = New System.Windows.Forms.Label()
        Me.dtpVencimientoActual = New System.Windows.Forms.DateTimePicker()
        Me.lblVencimientoActual = New System.Windows.Forms.Label()
        Me.dtpFechaFactura = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaFactura = New System.Windows.Forms.Label()
        Me.txtNumeroFactura = New System.Windows.Forms.TextBox()
        Me.lblNumeroFactura = New System.Windows.Forms.Label()
        Me.pnlSepDatos = New System.Windows.Forms.Panel()
        Me.lblTituloDatos = New System.Windows.Forms.Label()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlDetallePlan.SuspendLayout()
        CType(Me.TrueDBGridDetallePlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCondicionesPlan.SuspendLayout()
        CType(Me.nudMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosFactura.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.AutoScroll = True
        Me.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlContenedor.Controls.Add(Me.pnlAcciones)
        Me.pnlContenedor.Controls.Add(Me.pnlDetallePlan)
        Me.pnlContenedor.Controls.Add(Me.pnlCondicionesPlan)
        Me.pnlContenedor.Controls.Add(Me.pnlDatosFactura)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContenedor.Size = New System.Drawing.Size(993, 461)
        Me.pnlContenedor.TabIndex = 0
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.btnAnular)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Location = New System.Drawing.Point(805, 6)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(177, 443)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(25, 392)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(140, 40)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAnular
        '
        Me.btnAnular.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnular.FlatAppearance.BorderSize = 0
        Me.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnular.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAnular.ForeColor = System.Drawing.Color.White
        Me.btnAnular.Location = New System.Drawing.Point(25, 68)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(140, 40)
        Me.btnAnular.TabIndex = 1
        Me.btnAnular.Text = "ANULAR"
        Me.btnAnular.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(25, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(140, 40)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'pnlDetallePlan
        '
        Me.pnlDetallePlan.BackColor = System.Drawing.Color.White
        Me.pnlDetallePlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetallePlan.Controls.Add(Me.TrueDBGridDetallePlan)
        Me.pnlDetallePlan.Controls.Add(Me.pnlSepDetalle)
        Me.pnlDetallePlan.Controls.Add(Me.lblTituloDetalle)
        Me.pnlDetallePlan.Location = New System.Drawing.Point(12, 192)
        Me.pnlDetallePlan.Name = "pnlDetallePlan"
        Me.pnlDetallePlan.Size = New System.Drawing.Size(787, 257)
        Me.pnlDetallePlan.TabIndex = 1
        '
        'TrueDBGridDetallePlan
        '
        Me.TrueDBGridDetallePlan.AllowUpdate = False
        Me.TrueDBGridDetallePlan.AlternatingRows = True
        Me.TrueDBGridDetallePlan.CaptionHeight = 17
        Me.TrueDBGridDetallePlan.FilterBar = True
        Me.TrueDBGridDetallePlan.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridDetallePlan.Images.Add(CType(resources.GetObject("TrueDBGridDetallePlan.Images"), System.Drawing.Image))
        Me.TrueDBGridDetallePlan.Location = New System.Drawing.Point(10, 33)
        Me.TrueDBGridDetallePlan.Name = "TrueDBGridDetallePlan"
        Me.TrueDBGridDetallePlan.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridDetallePlan.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridDetallePlan.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridDetallePlan.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridDetallePlan.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridDetallePlan.RowHeight = 15
        Me.TrueDBGridDetallePlan.Size = New System.Drawing.Size(768, 212)
        Me.TrueDBGridDetallePlan.TabIndex = 130
        Me.TrueDBGridDetallePlan.Text = "C1TrueDBGrid1"
        Me.TrueDBGridDetallePlan.PropBag = resources.GetString("TrueDBGridDetallePlan.PropBag")
        '
        'pnlSepDetalle
        '
        Me.pnlSepDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.pnlSepDetalle.Location = New System.Drawing.Point(20, 26)
        Me.pnlSepDetalle.Name = "pnlSepDetalle"
        Me.pnlSepDetalle.Size = New System.Drawing.Size(620, 1)
        Me.pnlSepDetalle.TabIndex = 1
        '
        'lblTituloDetalle
        '
        Me.lblTituloDetalle.AutoSize = True
        Me.lblTituloDetalle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.lblTituloDetalle.Location = New System.Drawing.Point(20, 4)
        Me.lblTituloDetalle.Name = "lblTituloDetalle"
        Me.lblTituloDetalle.Size = New System.Drawing.Size(146, 20)
        Me.lblTituloDetalle.TabIndex = 2
        Me.lblTituloDetalle.Text = "DETALLE DEL PLAN"
        '
        'pnlCondicionesPlan
        '
        Me.pnlCondicionesPlan.BackColor = System.Drawing.Color.White
        Me.pnlCondicionesPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCondicionesPlan.Controls.Add(Me.btnCrear)
        Me.pnlCondicionesPlan.Controls.Add(Me.nudMantenimiento)
        Me.pnlCondicionesPlan.Controls.Add(Me.lblMantenimiento)
        Me.pnlCondicionesPlan.Controls.Add(Me.nudMora)
        Me.pnlCondicionesPlan.Controls.Add(Me.lblMora)
        Me.pnlCondicionesPlan.Controls.Add(Me.nudInteres)
        Me.pnlCondicionesPlan.Controls.Add(Me.lblInteres)
        Me.pnlCondicionesPlan.Controls.Add(Me.cboFrecuencia)
        Me.pnlCondicionesPlan.Controls.Add(Me.lblFrecuencia)
        Me.pnlCondicionesPlan.Controls.Add(Me.nudCuotas)
        Me.pnlCondicionesPlan.Controls.Add(Me.lblCuotas)
        Me.pnlCondicionesPlan.Controls.Add(Me.pnlSepCondiciones)
        Me.pnlCondicionesPlan.Controls.Add(Me.lblTituloCondiciones)
        Me.pnlCondicionesPlan.Location = New System.Drawing.Point(336, 6)
        Me.pnlCondicionesPlan.Name = "pnlCondicionesPlan"
        Me.pnlCondicionesPlan.Size = New System.Drawing.Size(455, 180)
        Me.pnlCondicionesPlan.TabIndex = 2
        '
        'btnCrear
        '
        Me.btnCrear.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCrear.FlatAppearance.BorderSize = 0
        Me.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrear.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnCrear.ForeColor = System.Drawing.Color.White
        Me.btnCrear.Location = New System.Drawing.Point(296, 35)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(140, 38)
        Me.btnCrear.TabIndex = 0
        Me.btnCrear.Text = "CREAR"
        Me.btnCrear.UseVisualStyleBackColor = False
        '
        'nudMantenimiento
        '
        Me.nudMantenimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudMantenimiento.DecimalPlaces = 2
        Me.nudMantenimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nudMantenimiento.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.nudMantenimiento.Location = New System.Drawing.Point(130, 142)
        Me.nudMantenimiento.Name = "nudMantenimiento"
        Me.nudMantenimiento.Size = New System.Drawing.Size(150, 23)
        Me.nudMantenimiento.TabIndex = 1
        Me.nudMantenimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMantenimiento
        '
        Me.lblMantenimiento.AutoSize = True
        Me.lblMantenimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMantenimiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblMantenimiento.Location = New System.Drawing.Point(20, 150)
        Me.lblMantenimiento.Name = "lblMantenimiento"
        Me.lblMantenimiento.Size = New System.Drawing.Size(105, 15)
        Me.lblMantenimiento.TabIndex = 2
        Me.lblMantenimiento.Text = "% Mantenimiento:"
        '
        'nudMora
        '
        Me.nudMora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudMora.DecimalPlaces = 2
        Me.nudMora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nudMora.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.nudMora.Location = New System.Drawing.Point(130, 115)
        Me.nudMora.Name = "nudMora"
        Me.nudMora.Size = New System.Drawing.Size(150, 23)
        Me.nudMora.TabIndex = 3
        Me.nudMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMora
        '
        Me.lblMora.AutoSize = True
        Me.lblMora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblMora.Location = New System.Drawing.Point(20, 123)
        Me.lblMora.Name = "lblMora"
        Me.lblMora.Size = New System.Drawing.Size(51, 15)
        Me.lblMora.TabIndex = 4
        Me.lblMora.Text = "% Mora:"
        '
        'nudInteres
        '
        Me.nudInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudInteres.DecimalPlaces = 2
        Me.nudInteres.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nudInteres.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.nudInteres.Location = New System.Drawing.Point(130, 89)
        Me.nudInteres.Name = "nudInteres"
        Me.nudInteres.Size = New System.Drawing.Size(150, 23)
        Me.nudInteres.TabIndex = 5
        Me.nudInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInteres
        '
        Me.lblInteres.AutoSize = True
        Me.lblInteres.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblInteres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblInteres.Location = New System.Drawing.Point(20, 97)
        Me.lblInteres.Name = "lblInteres"
        Me.lblInteres.Size = New System.Drawing.Size(58, 15)
        Me.lblInteres.TabIndex = 6
        Me.lblInteres.Text = "% Interés:"
        '
        'cboFrecuencia
        '
        Me.cboFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFrecuencia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboFrecuencia.FormattingEnabled = True
        Me.cboFrecuencia.Items.AddRange(New Object() {"Semanal", "Quincenal", "Mensual"})
        Me.cboFrecuencia.Location = New System.Drawing.Point(130, 63)
        Me.cboFrecuencia.Name = "cboFrecuencia"
        Me.cboFrecuencia.Size = New System.Drawing.Size(150, 23)
        Me.cboFrecuencia.TabIndex = 7
        '
        'lblFrecuencia
        '
        Me.lblFrecuencia.AutoSize = True
        Me.lblFrecuencia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFrecuencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblFrecuencia.Location = New System.Drawing.Point(20, 71)
        Me.lblFrecuencia.Name = "lblFrecuencia"
        Me.lblFrecuencia.Size = New System.Drawing.Size(67, 15)
        Me.lblFrecuencia.TabIndex = 8
        Me.lblFrecuencia.Text = "Frecuencia:"
        '
        'nudCuotas
        '
        Me.nudCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nudCuotas.Location = New System.Drawing.Point(130, 36)
        Me.nudCuotas.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.nudCuotas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCuotas.Name = "nudCuotas"
        Me.nudCuotas.Size = New System.Drawing.Size(150, 23)
        Me.nudCuotas.TabIndex = 9
        Me.nudCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudCuotas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCuotas
        '
        Me.lblCuotas.AutoSize = True
        Me.lblCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCuotas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblCuotas.Location = New System.Drawing.Point(20, 44)
        Me.lblCuotas.Name = "lblCuotas"
        Me.lblCuotas.Size = New System.Drawing.Size(47, 15)
        Me.lblCuotas.TabIndex = 10
        Me.lblCuotas.Text = "Cuotas:"
        '
        'pnlSepCondiciones
        '
        Me.pnlSepCondiciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.pnlSepCondiciones.Location = New System.Drawing.Point(20, 28)
        Me.pnlSepCondiciones.Name = "pnlSepCondiciones"
        Me.pnlSepCondiciones.Size = New System.Drawing.Size(620, 1)
        Me.pnlSepCondiciones.TabIndex = 11
        '
        'lblTituloCondiciones
        '
        Me.lblTituloCondiciones.AutoSize = True
        Me.lblTituloCondiciones.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloCondiciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.lblTituloCondiciones.Location = New System.Drawing.Point(20, 4)
        Me.lblTituloCondiciones.Name = "lblTituloCondiciones"
        Me.lblTituloCondiciones.Size = New System.Drawing.Size(185, 20)
        Me.lblTituloCondiciones.TabIndex = 12
        Me.lblTituloCondiciones.Text = "CONDICIONES DEL PLAN"
        '
        'pnlDatosFactura
        '
        Me.pnlDatosFactura.BackColor = System.Drawing.Color.White
        Me.pnlDatosFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDatosFactura.Controls.Add(Me.TxtMonedaFactura)
        Me.pnlDatosFactura.Controls.Add(Me.Label1)
        Me.pnlDatosFactura.Controls.Add(Me.txtMontoCredito)
        Me.pnlDatosFactura.Controls.Add(Me.lblMontoCredito)
        Me.pnlDatosFactura.Controls.Add(Me.dtpVencimientoActual)
        Me.pnlDatosFactura.Controls.Add(Me.lblVencimientoActual)
        Me.pnlDatosFactura.Controls.Add(Me.dtpFechaFactura)
        Me.pnlDatosFactura.Controls.Add(Me.lblFechaFactura)
        Me.pnlDatosFactura.Controls.Add(Me.txtNumeroFactura)
        Me.pnlDatosFactura.Controls.Add(Me.lblNumeroFactura)
        Me.pnlDatosFactura.Controls.Add(Me.pnlSepDatos)
        Me.pnlDatosFactura.Controls.Add(Me.lblTituloDatos)
        Me.pnlDatosFactura.Location = New System.Drawing.Point(12, 6)
        Me.pnlDatosFactura.Name = "pnlDatosFactura"
        Me.pnlDatosFactura.Size = New System.Drawing.Size(318, 180)
        Me.pnlDatosFactura.TabIndex = 3
        '
        'TxtMonedaFactura
        '
        Me.TxtMonedaFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMonedaFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtMonedaFactura.Location = New System.Drawing.Point(136, 147)
        Me.TxtMonedaFactura.Name = "TxtMonedaFactura"
        Me.TxtMonedaFactura.Size = New System.Drawing.Size(130, 23)
        Me.TxtMonedaFactura.TabIndex = 10
        Me.TxtMonedaFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(20, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Moneda Factura:"
        '
        'txtMontoCredito
        '
        Me.txtMontoCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMontoCredito.Location = New System.Drawing.Point(136, 119)
        Me.txtMontoCredito.Name = "txtMontoCredito"
        Me.txtMontoCredito.Size = New System.Drawing.Size(130, 23)
        Me.txtMontoCredito.TabIndex = 0
        Me.txtMontoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoCredito
        '
        Me.lblMontoCredito.AutoSize = True
        Me.lblMontoCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMontoCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblMontoCredito.Location = New System.Drawing.Point(20, 121)
        Me.lblMontoCredito.Name = "lblMontoCredito"
        Me.lblMontoCredito.Size = New System.Drawing.Size(102, 15)
        Me.lblMontoCredito.TabIndex = 1
        Me.lblMontoCredito.Text = "Monto de crédito:"
        '
        'dtpVencimientoActual
        '
        Me.dtpVencimientoActual.Enabled = False
        Me.dtpVencimientoActual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpVencimientoActual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVencimientoActual.Location = New System.Drawing.Point(136, 91)
        Me.dtpVencimientoActual.Name = "dtpVencimientoActual"
        Me.dtpVencimientoActual.Size = New System.Drawing.Size(130, 23)
        Me.dtpVencimientoActual.TabIndex = 2
        '
        'lblVencimientoActual
        '
        Me.lblVencimientoActual.AutoSize = True
        Me.lblVencimientoActual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblVencimientoActual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblVencimientoActual.Location = New System.Drawing.Point(20, 93)
        Me.lblVencimientoActual.Name = "lblVencimientoActual"
        Me.lblVencimientoActual.Size = New System.Drawing.Size(111, 15)
        Me.lblVencimientoActual.TabIndex = 3
        Me.lblVencimientoActual.Text = "Vencimiento actual:"
        '
        'dtpFechaFactura
        '
        Me.dtpFechaFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFactura.Location = New System.Drawing.Point(136, 67)
        Me.dtpFechaFactura.Name = "dtpFechaFactura"
        Me.dtpFechaFactura.Size = New System.Drawing.Size(130, 23)
        Me.dtpFechaFactura.TabIndex = 4
        '
        'lblFechaFactura
        '
        Me.lblFechaFactura.AutoSize = True
        Me.lblFechaFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFechaFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblFechaFactura.Location = New System.Drawing.Point(20, 69)
        Me.lblFechaFactura.Name = "lblFechaFactura"
        Me.lblFechaFactura.Size = New System.Drawing.Size(97, 15)
        Me.lblFechaFactura.TabIndex = 5
        Me.lblFechaFactura.Text = "Fecha de factura:"
        '
        'txtNumeroFactura
        '
        Me.txtNumeroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNumeroFactura.Location = New System.Drawing.Point(136, 42)
        Me.txtNumeroFactura.Name = "txtNumeroFactura"
        Me.txtNumeroFactura.Size = New System.Drawing.Size(130, 23)
        Me.txtNumeroFactura.TabIndex = 6
        '
        'lblNumeroFactura
        '
        Me.lblNumeroFactura.AutoSize = True
        Me.lblNumeroFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNumeroFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.lblNumeroFactura.Location = New System.Drawing.Point(20, 44)
        Me.lblNumeroFactura.Name = "lblNumeroFactura"
        Me.lblNumeroFactura.Size = New System.Drawing.Size(110, 15)
        Me.lblNumeroFactura.TabIndex = 7
        Me.lblNumeroFactura.Text = "Número de factura:"
        '
        'pnlSepDatos
        '
        Me.pnlSepDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.pnlSepDatos.Location = New System.Drawing.Point(20, 28)
        Me.pnlSepDatos.Name = "pnlSepDatos"
        Me.pnlSepDatos.Size = New System.Drawing.Size(620, 1)
        Me.pnlSepDatos.TabIndex = 8
        '
        'lblTituloDatos
        '
        Me.lblTituloDatos.AutoSize = True
        Me.lblTituloDatos.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloDatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.lblTituloDatos.Location = New System.Drawing.Point(20, 6)
        Me.lblTituloDatos.Name = "lblTituloDatos"
        Me.lblTituloDatos.Size = New System.Drawing.Size(175, 20)
        Me.lblTituloDatos.TabIndex = 9
        Me.lblTituloDatos.Text = "DATOS DE LA FACTURA"
        '
        'FrmPlanPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(993, 461)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(716, 500)
        Me.Name = "FrmPlanPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plan de Pago"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlDetallePlan.ResumeLayout(False)
        Me.pnlDetallePlan.PerformLayout()
        CType(Me.TrueDBGridDetallePlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCondicionesPlan.ResumeLayout(False)
        Me.pnlCondicionesPlan.PerformLayout()
        CType(Me.nudMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosFactura.ResumeLayout(False)
        Me.pnlDatosFactura.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TrueDBGridDetallePlan As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtMonedaFactura As TextBox
    Friend WithEvents Label1 As Label
End Class
