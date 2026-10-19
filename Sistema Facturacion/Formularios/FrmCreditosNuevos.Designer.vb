<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCreditosNuevos
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
        Me.LblNumeroPrestamo = New System.Windows.Forms.Label()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlDatos = New System.Windows.Forms.Panel()
        Me.TxtCodBeneficiario = New System.Windows.Forms.TextBox()
        Me.TxtCodSucursal = New System.Windows.Forms.TextBox()
        Me.TxtFinanciamiento = New System.Windows.Forms.TextBox()
        Me.TxtConsecutivo = New System.Windows.Forms.TextBox()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.LblNombreProductor = New System.Windows.Forms.Label()
        Me.BtnBuscarProductor = New System.Windows.Forms.Button()
        Me.CboCodigoProductor = New System.Windows.Forms.ComboBox()
        Me.LblBeneficiario = New System.Windows.Forms.Label()
        Me.BtnBuscarFinanciamiento = New System.Windows.Forms.Button()
        Me.CboFinanciamiento = New System.Windows.Forms.ComboBox()
        Me.LblFinanciamiento = New System.Windows.Forms.Label()
        Me.BtnBuscarSucursal = New System.Windows.Forms.Button()
        Me.CboSucursal = New System.Windows.Forms.ComboBox()
        Me.LblSucursal = New System.Windows.Forms.Label()
        Me.LblTituloDatos = New System.Windows.Forms.Label()
        Me.PnlCondiciones = New System.Windows.Forms.Panel()
        Me.DtpFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Chkvence = New System.Windows.Forms.CheckBox()
        Me.OptCS = New System.Windows.Forms.RadioButton()
        Me.OptUS = New System.Windows.Forms.RadioButton()
        Me.LblMoneda = New System.Windows.Forms.Label()
        Me.LblPorcentaje = New System.Windows.Forms.Label()
        Me.TxtInteresDiario = New System.Windows.Forms.TextBox()
        Me.LblInteres = New System.Windows.Forms.Label()
        Me.TxtModalidad = New System.Windows.Forms.TextBox()
        Me.LblModalidad = New System.Windows.Forms.Label()
        Me.CboTipoPrestamos = New System.Windows.Forms.ComboBox()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.LblTituloCondiciones = New System.Windows.Forms.Label()
        Me.PnlPlan = New System.Windows.Forms.Panel()
        Me.ChkCuotaNivelada = New System.Windows.Forms.CheckBox()
        Me.ChkCadaMes = New System.Windows.Forms.CheckBox()
        Me.DtpFechaINI = New System.Windows.Forms.DateTimePicker()
        Me.LblFechaIni = New System.Windows.Forms.Label()
        Me.CboDias = New System.Windows.Forms.ComboBox()
        Me.LblDias = New System.Windows.Forms.Label()
        Me.TxtCuota = New System.Windows.Forms.TextBox()
        Me.LblCuota = New System.Windows.Forms.Label()
        Me.TxtNumeroCuotas = New System.Windows.Forms.NumericUpDown()
        Me.LblCuotas = New System.Windows.Forms.Label()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.LblMonto = New System.Windows.Forms.Label()
        Me.LblTituloPlan = New System.Windows.Forms.Label()
        Me.TDGridCredito = New System.Windows.Forms.DataGridView()
        Me.PnlAcciones = New System.Windows.Forms.Panel()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnCalcular = New System.Windows.Forms.Button()
        Me.LblTotales = New System.Windows.Forms.Label()
        Me.PnlHeader.SuspendLayout()
        Me.PnlDatos.SuspendLayout()
        Me.PnlCondiciones.SuspendLayout()
        Me.PnlPlan.SuspendLayout()
        CType(Me.TxtNumeroCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDGridCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.LblNumeroPrestamo)
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.LblTitulo)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(1000, 64)
        Me.PnlHeader.TabIndex = 0
        '
        'LblNumeroPrestamo
        '
        Me.LblNumeroPrestamo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNumeroPrestamo.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumeroPrestamo.ForeColor = System.Drawing.Color.White
        Me.LblNumeroPrestamo.Location = New System.Drawing.Point(560, 20)
        Me.LblNumeroPrestamo.Name = "LblNumeroPrestamo"
        Me.LblNumeroPrestamo.Size = New System.Drawing.Size(424, 24)
        Me.LblNumeroPrestamo.TabIndex = 2
        Me.LblNumeroPrestamo.Text = "Préstamo Nº —"
        Me.LblNumeroPrestamo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(18, 38)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(214, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Registro y cálculo del plan de pagos"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(14, 6)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(178, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Nuevo préstamo"
        '
        'PnlDatos
        '
        Me.PnlDatos.BackColor = System.Drawing.Color.White
        Me.PnlDatos.Controls.Add(Me.TxtCodBeneficiario)
        Me.PnlDatos.Controls.Add(Me.TxtCodSucursal)
        Me.PnlDatos.Controls.Add(Me.TxtFinanciamiento)
        Me.PnlDatos.Controls.Add(Me.TxtConsecutivo)
        Me.PnlDatos.Controls.Add(Me.LblNumero)
        Me.PnlDatos.Controls.Add(Me.LblNombreProductor)
        Me.PnlDatos.Controls.Add(Me.BtnBuscarProductor)
        Me.PnlDatos.Controls.Add(Me.CboCodigoProductor)
        Me.PnlDatos.Controls.Add(Me.LblBeneficiario)
        Me.PnlDatos.Controls.Add(Me.BtnBuscarFinanciamiento)
        Me.PnlDatos.Controls.Add(Me.CboFinanciamiento)
        Me.PnlDatos.Controls.Add(Me.LblFinanciamiento)
        Me.PnlDatos.Controls.Add(Me.BtnBuscarSucursal)
        Me.PnlDatos.Controls.Add(Me.CboSucursal)
        Me.PnlDatos.Controls.Add(Me.LblSucursal)
        Me.PnlDatos.Controls.Add(Me.LblTituloDatos)
        Me.PnlDatos.Location = New System.Drawing.Point(16, 80)
        Me.PnlDatos.Name = "PnlDatos"
        Me.PnlDatos.Size = New System.Drawing.Size(476, 205)
        Me.PnlDatos.TabIndex = 1
        '
        'LblTituloDatos
        '
        Me.LblTituloDatos.AutoSize = True
        Me.LblTituloDatos.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloDatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloDatos.Location = New System.Drawing.Point(14, 12)
        Me.LblTituloDatos.Name = "LblTituloDatos"
        Me.LblTituloDatos.Size = New System.Drawing.Size(108, 17)
        Me.LblTituloDatos.TabIndex = 0
        Me.LblTituloDatos.Text = "Datos generales"
        '
        'LblSucursal
        '
        Me.LblSucursal.AutoSize = True
        Me.LblSucursal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblSucursal.Location = New System.Drawing.Point(16, 51)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(51, 15)
        Me.LblSucursal.TabIndex = 1
        Me.LblSucursal.Text = "Sucursal"
        '
        'CboSucursal
        '
        Me.CboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboSucursal.FormattingEnabled = True
        Me.CboSucursal.Location = New System.Drawing.Point(130, 48)
        Me.CboSucursal.Name = "CboSucursal"
        Me.CboSucursal.Size = New System.Drawing.Size(290, 23)
        Me.CboSucursal.TabIndex = 2
        '
        'BtnBuscarSucursal
        '
        Me.BtnBuscarSucursal.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnBuscarSucursal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarSucursal.FlatAppearance.BorderSize = 0
        Me.BtnBuscarSucursal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnBuscarSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscarSucursal.Location = New System.Drawing.Point(426, 47)
        Me.BtnBuscarSucursal.Name = "BtnBuscarSucursal"
        Me.BtnBuscarSucursal.Size = New System.Drawing.Size(34, 25)
        Me.BtnBuscarSucursal.TabIndex = 3
        Me.BtnBuscarSucursal.TabStop = False
        Me.BtnBuscarSucursal.Text = "..."
        Me.BtnBuscarSucursal.UseVisualStyleBackColor = False
        '
        'LblFinanciamiento
        '
        Me.LblFinanciamiento.AutoSize = True
        Me.LblFinanciamiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblFinanciamiento.Location = New System.Drawing.Point(16, 85)
        Me.LblFinanciamiento.Name = "LblFinanciamiento"
        Me.LblFinanciamiento.Size = New System.Drawing.Size(89, 15)
        Me.LblFinanciamiento.TabIndex = 4
        Me.LblFinanciamiento.Text = "Financiamiento"
        '
        'CboFinanciamiento
        '
        Me.CboFinanciamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFinanciamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboFinanciamiento.FormattingEnabled = True
        Me.CboFinanciamiento.Location = New System.Drawing.Point(130, 82)
        Me.CboFinanciamiento.Name = "CboFinanciamiento"
        Me.CboFinanciamiento.Size = New System.Drawing.Size(290, 23)
        Me.CboFinanciamiento.TabIndex = 5
        '
        'BtnBuscarFinanciamiento
        '
        Me.BtnBuscarFinanciamiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnBuscarFinanciamiento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarFinanciamiento.FlatAppearance.BorderSize = 0
        Me.BtnBuscarFinanciamiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnBuscarFinanciamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscarFinanciamiento.Location = New System.Drawing.Point(426, 81)
        Me.BtnBuscarFinanciamiento.Name = "BtnBuscarFinanciamiento"
        Me.BtnBuscarFinanciamiento.Size = New System.Drawing.Size(34, 25)
        Me.BtnBuscarFinanciamiento.TabIndex = 6
        Me.BtnBuscarFinanciamiento.TabStop = False
        Me.BtnBuscarFinanciamiento.Text = "..."
        Me.BtnBuscarFinanciamiento.UseVisualStyleBackColor = False
        '
        'LblBeneficiario
        '
        Me.LblBeneficiario.AutoSize = True
        Me.LblBeneficiario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblBeneficiario.Location = New System.Drawing.Point(16, 119)
        Me.LblBeneficiario.Name = "LblBeneficiario"
        Me.LblBeneficiario.Size = New System.Drawing.Size(70, 15)
        Me.LblBeneficiario.TabIndex = 7
        Me.LblBeneficiario.Text = "Beneficiario"
        '
        'CboCodigoProductor
        '
        Me.CboCodigoProductor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboCodigoProductor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboCodigoProductor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboCodigoProductor.FormattingEnabled = True
        Me.CboCodigoProductor.Location = New System.Drawing.Point(130, 116)
        Me.CboCodigoProductor.Name = "CboCodigoProductor"
        Me.CboCodigoProductor.Size = New System.Drawing.Size(290, 23)
        Me.CboCodigoProductor.TabIndex = 8
        '
        'BtnBuscarProductor
        '
        Me.BtnBuscarProductor.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnBuscarProductor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarProductor.FlatAppearance.BorderSize = 0
        Me.BtnBuscarProductor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnBuscarProductor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscarProductor.Location = New System.Drawing.Point(426, 115)
        Me.BtnBuscarProductor.Name = "BtnBuscarProductor"
        Me.BtnBuscarProductor.Size = New System.Drawing.Size(34, 25)
        Me.BtnBuscarProductor.TabIndex = 9
        Me.BtnBuscarProductor.TabStop = False
        Me.BtnBuscarProductor.Text = "..."
        Me.BtnBuscarProductor.UseVisualStyleBackColor = False
        '
        'LblNombreProductor
        '
        Me.LblNombreProductor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreProductor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.LblNombreProductor.Location = New System.Drawing.Point(130, 143)
        Me.LblNombreProductor.Name = "LblNombreProductor"
        Me.LblNombreProductor.Size = New System.Drawing.Size(330, 18)
        Me.LblNombreProductor.TabIndex = 10
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblNumero.Location = New System.Drawing.Point(16, 172)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(75, 15)
        Me.LblNumero.TabIndex = 11
        Me.LblNumero.Text = "Nº préstamo"
        '
        'TxtConsecutivo
        '
        Me.TxtConsecutivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtConsecutivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConsecutivo.Location = New System.Drawing.Point(130, 169)
        Me.TxtConsecutivo.Name = "TxtConsecutivo"
        Me.TxtConsecutivo.ReadOnly = True
        Me.TxtConsecutivo.Size = New System.Drawing.Size(60, 23)
        Me.TxtConsecutivo.TabIndex = 12
        Me.TxtConsecutivo.TabStop = False
        Me.TxtConsecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtFinanciamiento
        '
        Me.TxtFinanciamiento.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtFinanciamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFinanciamiento.Location = New System.Drawing.Point(196, 169)
        Me.TxtFinanciamiento.Name = "TxtFinanciamiento"
        Me.TxtFinanciamiento.ReadOnly = True
        Me.TxtFinanciamiento.Size = New System.Drawing.Size(60, 23)
        Me.TxtFinanciamiento.TabIndex = 13
        Me.TxtFinanciamiento.TabStop = False
        Me.TxtFinanciamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCodSucursal
        '
        Me.TxtCodSucursal.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtCodSucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCodSucursal.Location = New System.Drawing.Point(262, 169)
        Me.TxtCodSucursal.Name = "TxtCodSucursal"
        Me.TxtCodSucursal.ReadOnly = True
        Me.TxtCodSucursal.Size = New System.Drawing.Size(60, 23)
        Me.TxtCodSucursal.TabIndex = 14
        Me.TxtCodSucursal.TabStop = False
        Me.TxtCodSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCodBeneficiario
        '
        Me.TxtCodBeneficiario.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtCodBeneficiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCodBeneficiario.Location = New System.Drawing.Point(328, 169)
        Me.TxtCodBeneficiario.Name = "TxtCodBeneficiario"
        Me.TxtCodBeneficiario.ReadOnly = True
        Me.TxtCodBeneficiario.Size = New System.Drawing.Size(92, 23)
        Me.TxtCodBeneficiario.TabIndex = 15
        Me.TxtCodBeneficiario.TabStop = False
        Me.TxtCodBeneficiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PnlCondiciones
        '
        Me.PnlCondiciones.BackColor = System.Drawing.Color.White
        Me.PnlCondiciones.Controls.Add(Me.DtpFechaVencimiento)
        Me.PnlCondiciones.Controls.Add(Me.Chkvence)
        Me.PnlCondiciones.Controls.Add(Me.OptCS)
        Me.PnlCondiciones.Controls.Add(Me.OptUS)
        Me.PnlCondiciones.Controls.Add(Me.LblMoneda)
        Me.PnlCondiciones.Controls.Add(Me.LblPorcentaje)
        Me.PnlCondiciones.Controls.Add(Me.TxtInteresDiario)
        Me.PnlCondiciones.Controls.Add(Me.LblInteres)
        Me.PnlCondiciones.Controls.Add(Me.TxtModalidad)
        Me.PnlCondiciones.Controls.Add(Me.LblModalidad)
        Me.PnlCondiciones.Controls.Add(Me.CboTipoPrestamos)
        Me.PnlCondiciones.Controls.Add(Me.LblTipo)
        Me.PnlCondiciones.Controls.Add(Me.LblTituloCondiciones)
        Me.PnlCondiciones.Location = New System.Drawing.Point(508, 80)
        Me.PnlCondiciones.Name = "PnlCondiciones"
        Me.PnlCondiciones.Size = New System.Drawing.Size(476, 205)
        Me.PnlCondiciones.TabIndex = 2
        '
        'LblTituloCondiciones
        '
        Me.LblTituloCondiciones.AutoSize = True
        Me.LblTituloCondiciones.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloCondiciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloCondiciones.Location = New System.Drawing.Point(14, 12)
        Me.LblTituloCondiciones.Name = "LblTituloCondiciones"
        Me.LblTituloCondiciones.Size = New System.Drawing.Size(151, 17)
        Me.LblTituloCondiciones.TabIndex = 0
        Me.LblTituloCondiciones.Text = "Condiciones del crédito"
        '
        'LblTipo
        '
        Me.LblTipo.AutoSize = True
        Me.LblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblTipo.Location = New System.Drawing.Point(16, 51)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(96, 15)
        Me.LblTipo.TabIndex = 1
        Me.LblTipo.Text = "Tipo de préstamo"
        '
        'CboTipoPrestamos
        '
        Me.CboTipoPrestamos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboTipoPrestamos.FormattingEnabled = True
        Me.CboTipoPrestamos.Location = New System.Drawing.Point(140, 48)
        Me.CboTipoPrestamos.Name = "CboTipoPrestamos"
        Me.CboTipoPrestamos.Size = New System.Drawing.Size(316, 23)
        Me.CboTipoPrestamos.TabIndex = 2
        '
        'LblModalidad
        '
        Me.LblModalidad.AutoSize = True
        Me.LblModalidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblModalidad.Location = New System.Drawing.Point(16, 85)
        Me.LblModalidad.Name = "LblModalidad"
        Me.LblModalidad.Size = New System.Drawing.Size(64, 15)
        Me.LblModalidad.TabIndex = 3
        Me.LblModalidad.Text = "Modalidad"
        '
        'TxtModalidad
        '
        Me.TxtModalidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtModalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtModalidad.Location = New System.Drawing.Point(140, 82)
        Me.TxtModalidad.Name = "TxtModalidad"
        Me.TxtModalidad.ReadOnly = True
        Me.TxtModalidad.Size = New System.Drawing.Size(316, 23)
        Me.TxtModalidad.TabIndex = 4
        Me.TxtModalidad.TabStop = False
        '
        'LblInteres
        '
        Me.LblInteres.AutoSize = True
        Me.LblInteres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblInteres.Location = New System.Drawing.Point(16, 119)
        Me.LblInteres.Name = "LblInteres"
        Me.LblInteres.Size = New System.Drawing.Size(77, 15)
        Me.LblInteres.TabIndex = 5
        Me.LblInteres.Text = "Interés diario"
        '
        'TxtInteresDiario
        '
        Me.TxtInteresDiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteresDiario.Location = New System.Drawing.Point(140, 116)
        Me.TxtInteresDiario.Name = "TxtInteresDiario"
        Me.TxtInteresDiario.Size = New System.Drawing.Size(90, 23)
        Me.TxtInteresDiario.TabIndex = 6
        Me.TxtInteresDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblPorcentaje
        '
        Me.LblPorcentaje.AutoSize = True
        Me.LblPorcentaje.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPorcentaje.Location = New System.Drawing.Point(234, 119)
        Me.LblPorcentaje.Name = "LblPorcentaje"
        Me.LblPorcentaje.Size = New System.Drawing.Size(17, 15)
        Me.LblPorcentaje.TabIndex = 7
        Me.LblPorcentaje.Text = "%"
        '
        'LblMoneda
        '
        Me.LblMoneda.AutoSize = True
        Me.LblMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblMoneda.Location = New System.Drawing.Point(280, 119)
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Size = New System.Drawing.Size(51, 15)
        Me.LblMoneda.TabIndex = 8
        Me.LblMoneda.Text = "Moneda"
        '
        'OptUS
        '
        Me.OptUS.AutoSize = True
        Me.OptUS.Checked = True
        Me.OptUS.Location = New System.Drawing.Point(340, 117)
        Me.OptUS.Name = "OptUS"
        Me.OptUS.Size = New System.Drawing.Size(45, 19)
        Me.OptUS.TabIndex = 9
        Me.OptUS.TabStop = True
        Me.OptUS.Text = "US$"
        Me.OptUS.UseVisualStyleBackColor = True
        '
        'OptCS
        '
        Me.OptCS.AutoSize = True
        Me.OptCS.Location = New System.Drawing.Point(400, 117)
        Me.OptCS.Name = "OptCS"
        Me.OptCS.Size = New System.Drawing.Size(40, 19)
        Me.OptCS.TabIndex = 10
        Me.OptCS.Text = "C$"
        Me.OptCS.UseVisualStyleBackColor = True
        '
        'Chkvence
        '
        Me.Chkvence.AutoSize = True
        Me.Chkvence.Location = New System.Drawing.Point(16, 163)
        Me.Chkvence.Name = "Chkvence"
        Me.Chkvence.Size = New System.Drawing.Size(163, 19)
        Me.Chkvence.TabIndex = 11
        Me.Chkvence.Text = "Pago único al vencimiento"
        Me.Chkvence.UseVisualStyleBackColor = True
        '
        'DtpFechaVencimiento
        '
        Me.DtpFechaVencimiento.Enabled = False
        Me.DtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaVencimiento.Location = New System.Drawing.Point(226, 160)
        Me.DtpFechaVencimiento.Name = "DtpFechaVencimiento"
        Me.DtpFechaVencimiento.Size = New System.Drawing.Size(130, 23)
        Me.DtpFechaVencimiento.TabIndex = 12
        '
        'PnlPlan
        '
        Me.PnlPlan.BackColor = System.Drawing.Color.White
        Me.PnlPlan.Controls.Add(Me.ChkCuotaNivelada)
        Me.PnlPlan.Controls.Add(Me.ChkCadaMes)
        Me.PnlPlan.Controls.Add(Me.DtpFechaINI)
        Me.PnlPlan.Controls.Add(Me.LblFechaIni)
        Me.PnlPlan.Controls.Add(Me.CboDias)
        Me.PnlPlan.Controls.Add(Me.LblDias)
        Me.PnlPlan.Controls.Add(Me.TxtCuota)
        Me.PnlPlan.Controls.Add(Me.LblCuota)
        Me.PnlPlan.Controls.Add(Me.TxtNumeroCuotas)
        Me.PnlPlan.Controls.Add(Me.LblCuotas)
        Me.PnlPlan.Controls.Add(Me.TxtMonto)
        Me.PnlPlan.Controls.Add(Me.LblMonto)
        Me.PnlPlan.Controls.Add(Me.LblTituloPlan)
        Me.PnlPlan.Location = New System.Drawing.Point(16, 297)
        Me.PnlPlan.Name = "PnlPlan"
        Me.PnlPlan.Size = New System.Drawing.Size(968, 110)
        Me.PnlPlan.TabIndex = 3
        '
        'LblTituloPlan
        '
        Me.LblTituloPlan.AutoSize = True
        Me.LblTituloPlan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloPlan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloPlan.Location = New System.Drawing.Point(14, 12)
        Me.LblTituloPlan.Name = "LblTituloPlan"
        Me.LblTituloPlan.Size = New System.Drawing.Size(92, 17)
        Me.LblTituloPlan.TabIndex = 0
        Me.LblTituloPlan.Text = "Plan de pagos"
        '
        'LblMonto
        '
        Me.LblMonto.AutoSize = True
        Me.LblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblMonto.Location = New System.Drawing.Point(16, 44)
        Me.LblMonto.Name = "LblMonto"
        Me.LblMonto.Size = New System.Drawing.Size(116, 15)
        Me.LblMonto.TabIndex = 1
        Me.LblMonto.Text = "Monto del préstamo"
        '
        'TxtMonto
        '
        Me.TxtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMonto.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.Location = New System.Drawing.Point(16, 64)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(150, 23)
        Me.TxtMonto.TabIndex = 2
        Me.TxtMonto.Text = "0.00"
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblCuotas
        '
        Me.LblCuotas.AutoSize = True
        Me.LblCuotas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblCuotas.Location = New System.Drawing.Point(182, 44)
        Me.LblCuotas.Name = "LblCuotas"
        Me.LblCuotas.Size = New System.Drawing.Size(74, 15)
        Me.LblCuotas.TabIndex = 3
        Me.LblCuotas.Text = "Nº de cuotas"
        '
        'TxtNumeroCuotas
        '
        Me.TxtNumeroCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumeroCuotas.Location = New System.Drawing.Point(182, 64)
        Me.TxtNumeroCuotas.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.TxtNumeroCuotas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtNumeroCuotas.Name = "TxtNumeroCuotas"
        Me.TxtNumeroCuotas.Size = New System.Drawing.Size(90, 23)
        Me.TxtNumeroCuotas.TabIndex = 4
        Me.TxtNumeroCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtNumeroCuotas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblCuota
        '
        Me.LblCuota.AutoSize = True
        Me.LblCuota.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblCuota.Location = New System.Drawing.Point(288, 44)
        Me.LblCuota.Name = "LblCuota"
        Me.LblCuota.Size = New System.Drawing.Size(100, 15)
        Me.LblCuota.TabIndex = 5
        Me.LblCuota.Text = "Cuota (principal)"
        '
        'TxtCuota
        '
        Me.TxtCuota.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCuota.Location = New System.Drawing.Point(288, 64)
        Me.TxtCuota.Name = "TxtCuota"
        Me.TxtCuota.ReadOnly = True
        Me.TxtCuota.Size = New System.Drawing.Size(130, 23)
        Me.TxtCuota.TabIndex = 6
        Me.TxtCuota.TabStop = False
        Me.TxtCuota.Text = "0.00"
        Me.TxtCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDias
        '
        Me.LblDias.AutoSize = True
        Me.LblDias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblDias.Location = New System.Drawing.Point(434, 44)
        Me.LblDias.Name = "LblDias"
        Me.LblDias.Size = New System.Drawing.Size(106, 15)
        Me.LblDias.TabIndex = 7
        Me.LblDias.Text = "Días / día del mes"
        '
        'CboDias
        '
        Me.CboDias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboDias.FormattingEnabled = True
        Me.CboDias.Items.AddRange(New Object() {"1", "7", "10", "14", "15", "30", "45", "60", "90", "120", "180", "365"})
        Me.CboDias.Location = New System.Drawing.Point(434, 64)
        Me.CboDias.Name = "CboDias"
        Me.CboDias.Size = New System.Drawing.Size(110, 23)
        Me.CboDias.TabIndex = 8
        '
        'LblFechaIni
        '
        Me.LblFechaIni.AutoSize = True
        Me.LblFechaIni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblFechaIni.Location = New System.Drawing.Point(560, 44)
        Me.LblFechaIni.Name = "LblFechaIni"
        Me.LblFechaIni.Size = New System.Drawing.Size(71, 15)
        Me.LblFechaIni.TabIndex = 9
        Me.LblFechaIni.Text = "Fecha inicial"
        '
        'DtpFechaINI
        '
        Me.DtpFechaINI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaINI.Location = New System.Drawing.Point(560, 64)
        Me.DtpFechaINI.Name = "DtpFechaINI"
        Me.DtpFechaINI.Size = New System.Drawing.Size(130, 23)
        Me.DtpFechaINI.TabIndex = 10
        '
        'ChkCadaMes
        '
        Me.ChkCadaMes.AutoSize = True
        Me.ChkCadaMes.Location = New System.Drawing.Point(712, 52)
        Me.ChkCadaMes.Name = "ChkCadaMes"
        Me.ChkCadaMes.Size = New System.Drawing.Size(137, 19)
        Me.ChkCadaMes.TabIndex = 11
        Me.ChkCadaMes.Text = "Día fijo de cada mes"
        Me.ChkCadaMes.UseVisualStyleBackColor = True
        '
        'ChkCuotaNivelada
        '
        Me.ChkCuotaNivelada.AutoSize = True
        Me.ChkCuotaNivelada.Location = New System.Drawing.Point(712, 78)
        Me.ChkCuotaNivelada.Name = "ChkCuotaNivelada"
        Me.ChkCuotaNivelada.Size = New System.Drawing.Size(108, 19)
        Me.ChkCuotaNivelada.TabIndex = 12
        Me.ChkCuotaNivelada.Text = "Cuota nivelada"
        Me.ChkCuotaNivelada.UseVisualStyleBackColor = True
        '
        'TDGridCredito
        '
        Me.TDGridCredito.AllowUserToAddRows = False
        Me.TDGridCredito.AllowUserToDeleteRows = False
        Me.TDGridCredito.AllowUserToResizeRows = False
        Me.TDGridCredito.BackgroundColor = System.Drawing.Color.White
        Me.TDGridCredito.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TDGridCredito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.TDGridCredito.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.TDGridCredito.ColumnHeadersHeight = 32
        Me.TDGridCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.TDGridCredito.EnableHeadersVisualStyles = False
        Me.TDGridCredito.GridColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TDGridCredito.Location = New System.Drawing.Point(16, 419)
        Me.TDGridCredito.MultiSelect = False
        Me.TDGridCredito.Name = "TDGridCredito"
        Me.TDGridCredito.ReadOnly = True
        Me.TDGridCredito.RowHeadersVisible = False
        Me.TDGridCredito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TDGridCredito.Size = New System.Drawing.Size(968, 213)
        Me.TDGridCredito.TabIndex = 4
        '
        'PnlAcciones
        '
        Me.PnlAcciones.BackColor = System.Drawing.Color.White
        Me.PnlAcciones.Controls.Add(Me.BtnSalir)
        Me.PnlAcciones.Controls.Add(Me.BtnGuardar)
        Me.PnlAcciones.Controls.Add(Me.BtnImprimir)
        Me.PnlAcciones.Controls.Add(Me.BtnCalcular)
        Me.PnlAcciones.Controls.Add(Me.LblTotales)
        Me.PnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlAcciones.Location = New System.Drawing.Point(0, 644)
        Me.PnlAcciones.Name = "PnlAcciones"
        Me.PnlAcciones.Size = New System.Drawing.Size(1000, 56)
        Me.PnlAcciones.TabIndex = 5
        '
        'LblTotales
        '
        Me.LblTotales.AutoSize = True
        Me.LblTotales.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTotales.Location = New System.Drawing.Point(16, 20)
        Me.LblTotales.Name = "LblTotales"
        Me.LblTotales.Size = New System.Drawing.Size(180, 15)
        Me.LblTotales.TabIndex = 0
        Me.LblTotales.Text = "Calcule el plan para ver totales"
        '
        'BtnCalcular
        '
        Me.BtnCalcular.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.BtnCalcular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCalcular.FlatAppearance.BorderSize = 0
        Me.BtnCalcular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCalcular.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCalcular.ForeColor = System.Drawing.Color.White
        Me.BtnCalcular.Location = New System.Drawing.Point(564, 10)
        Me.BtnCalcular.Name = "BtnCalcular"
        Me.BtnCalcular.Size = New System.Drawing.Size(96, 36)
        Me.BtnCalcular.TabIndex = 1
        Me.BtnCalcular.Text = "Calcular"
        Me.BtnCalcular.UseVisualStyleBackColor = False
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
        Me.BtnImprimir.Location = New System.Drawing.Point(672, 10)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(96, 36)
        Me.BtnImprimir.TabIndex = 2
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardar.FlatAppearance.BorderSize = 0
        Me.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Location = New System.Drawing.Point(780, 10)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(96, 36)
        Me.BtnGuardar.TabIndex = 3
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = False
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
        Me.BtnSalir.Location = New System.Drawing.Point(888, 10)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(96, 36)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'FrmCreditosNuevos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.BtnSalir
        Me.ClientSize = New System.Drawing.Size(1000, 700)
        Me.Controls.Add(Me.TDGridCredito)
        Me.Controls.Add(Me.PnlPlan)
        Me.Controls.Add(Me.PnlCondiciones)
        Me.Controls.Add(Me.PnlDatos)
        Me.Controls.Add(Me.PnlAcciones)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCreditosNuevos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zeus Crédito - Nuevo préstamo"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlDatos.ResumeLayout(False)
        Me.PnlDatos.PerformLayout()
        Me.PnlCondiciones.ResumeLayout(False)
        Me.PnlCondiciones.PerformLayout()
        Me.PnlPlan.ResumeLayout(False)
        Me.PnlPlan.PerformLayout()
        CType(Me.TxtNumeroCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDGridCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlAcciones.ResumeLayout(False)
        Me.PnlAcciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents LblNumeroPrestamo As System.Windows.Forms.Label
    Friend WithEvents PnlDatos As System.Windows.Forms.Panel
    Friend WithEvents LblTituloDatos As System.Windows.Forms.Label
    Friend WithEvents LblSucursal As System.Windows.Forms.Label
    Friend WithEvents CboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents BtnBuscarSucursal As System.Windows.Forms.Button
    Friend WithEvents LblFinanciamiento As System.Windows.Forms.Label
    Friend WithEvents CboFinanciamiento As System.Windows.Forms.ComboBox
    Friend WithEvents BtnBuscarFinanciamiento As System.Windows.Forms.Button
    Friend WithEvents LblBeneficiario As System.Windows.Forms.Label
    Friend WithEvents CboCodigoProductor As System.Windows.Forms.ComboBox
    Friend WithEvents BtnBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents LblNombreProductor As System.Windows.Forms.Label
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents TxtConsecutivo As System.Windows.Forms.TextBox
    Friend WithEvents TxtFinanciamiento As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodSucursal As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents PnlCondiciones As System.Windows.Forms.Panel
    Friend WithEvents LblTituloCondiciones As System.Windows.Forms.Label
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents CboTipoPrestamos As System.Windows.Forms.ComboBox
    Friend WithEvents LblModalidad As System.Windows.Forms.Label
    Friend WithEvents TxtModalidad As System.Windows.Forms.TextBox
    Friend WithEvents LblInteres As System.Windows.Forms.Label
    Friend WithEvents TxtInteresDiario As System.Windows.Forms.TextBox
    Friend WithEvents LblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents LblMoneda As System.Windows.Forms.Label
    Friend WithEvents OptUS As System.Windows.Forms.RadioButton
    Friend WithEvents OptCS As System.Windows.Forms.RadioButton
    Friend WithEvents Chkvence As System.Windows.Forms.CheckBox
    Friend WithEvents DtpFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents PnlPlan As System.Windows.Forms.Panel
    Friend WithEvents LblTituloPlan As System.Windows.Forms.Label
    Friend WithEvents LblMonto As System.Windows.Forms.Label
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents LblCuotas As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroCuotas As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblCuota As System.Windows.Forms.Label
    Friend WithEvents TxtCuota As System.Windows.Forms.TextBox
    Friend WithEvents LblDias As System.Windows.Forms.Label
    Friend WithEvents CboDias As System.Windows.Forms.ComboBox
    Friend WithEvents LblFechaIni As System.Windows.Forms.Label
    Friend WithEvents DtpFechaINI As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkCadaMes As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCuotaNivelada As System.Windows.Forms.CheckBox
    Friend WithEvents TDGridCredito As System.Windows.Forms.DataGridView
    Friend WithEvents PnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents LblTotales As System.Windows.Forms.Label
    Friend WithEvents BtnCalcular As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
End Class
