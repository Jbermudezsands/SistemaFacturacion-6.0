<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDeduccionPlanilla
    Inherits System.Windows.Forms.Form

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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblSubtitulo = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.pnlCardFiltros = New System.Windows.Forms.Panel()
        Me.TxtNumeroPlanilla = New System.Windows.Forms.TextBox()
        Me.lblCapTipoDeduccion = New System.Windows.Forms.Label()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.cboTipoDeduccion = New System.Windows.Forms.ComboBox()
        Me.lblCapCentroAcopio = New System.Windows.Forms.Label()
        Me.cboCentroAcopio = New System.Windows.Forms.ComboBox()
        Me.lblCapPagarA = New System.Windows.Forms.Label()
        Me.lblCapPeriodoDesde = New System.Windows.Forms.Label()
        Me.dtpPeriodoDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblCapPeriodoHasta = New System.Windows.Forms.Label()
        Me.dtpPeriodoHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblCapPrecio = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblCapTipoCalculo = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblCapRedondeo = New System.Windows.Forms.Label()
        Me.cboRedondeo = New System.Windows.Forms.ComboBox()
        Me.btnDistribuir = New System.Windows.Forms.Button()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCardFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblTitulo)
        Me.pnlHeader.Controls.Add(Me.lblSubtitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(964, 64)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(24, 11)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(243, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Deduccion Planilla de Leche"
        '
        'lblSubtitulo
        '
        Me.lblSubtitulo.AutoSize = True
        Me.lblSubtitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubtitulo.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblSubtitulo.Location = New System.Drawing.Point(26, 37)
        Me.lblSubtitulo.Name = "lblSubtitulo"
        Me.lblSubtitulo.Size = New System.Drawing.Size(206, 15)
        Me.lblSubtitulo.TabIndex = 1
        Me.lblSubtitulo.Text = "Planilla de Leche ›  Otras deducciones"
        '
        'pnlBody
        '
        Me.pnlBody.AutoScroll = True
        Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlBody.Controls.Add(Me.dgvDetalle)
        Me.pnlBody.Controls.Add(Me.pnlCardFiltros)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 64)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(24)
        Me.pnlBody.Size = New System.Drawing.Size(964, 497)
        Me.pnlBody.TabIndex = 1
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDetalle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvDetalle.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvDetalle.ColumnHeadersHeight = 40
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvDetalle.EnableHeadersVisualStyles = False
        Me.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.dgvDetalle.Location = New System.Drawing.Point(6, 189)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowTemplate.Height = 34
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(949, 296)
        Me.dgvDetalle.TabIndex = 4
        '
        'pnlCardFiltros
        '
        Me.pnlCardFiltros.BackColor = System.Drawing.Color.White
        Me.pnlCardFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardFiltros.Controls.Add(Me.Label1)
        Me.pnlCardFiltros.Controls.Add(Me.LblTotal)
        Me.pnlCardFiltros.Controls.Add(Me.TxtNumeroPlanilla)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapTipoDeduccion)
        Me.pnlCardFiltros.Controls.Add(Me.btnEjecutar)
        Me.pnlCardFiltros.Controls.Add(Me.cboTipoDeduccion)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapCentroAcopio)
        Me.pnlCardFiltros.Controls.Add(Me.cboCentroAcopio)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapPagarA)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapPeriodoDesde)
        Me.pnlCardFiltros.Controls.Add(Me.dtpPeriodoDesde)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapPeriodoHasta)
        Me.pnlCardFiltros.Controls.Add(Me.dtpPeriodoHasta)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapPrecio)
        Me.pnlCardFiltros.Controls.Add(Me.txtMonto)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapTipoCalculo)
        Me.pnlCardFiltros.Controls.Add(Me.cboTipo)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapRedondeo)
        Me.pnlCardFiltros.Controls.Add(Me.cboRedondeo)
        Me.pnlCardFiltros.Controls.Add(Me.btnDistribuir)
        Me.pnlCardFiltros.Location = New System.Drawing.Point(6, 6)
        Me.pnlCardFiltros.Name = "pnlCardFiltros"
        Me.pnlCardFiltros.Size = New System.Drawing.Size(952, 177)
        Me.pnlCardFiltros.TabIndex = 0
        '
        'TxtNumeroPlanilla
        '
        Me.TxtNumeroPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumeroPlanilla.Enabled = False
        Me.TxtNumeroPlanilla.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtNumeroPlanilla.Location = New System.Drawing.Point(623, 35)
        Me.TxtNumeroPlanilla.Name = "TxtNumeroPlanilla"
        Me.TxtNumeroPlanilla.Size = New System.Drawing.Size(170, 24)
        Me.TxtNumeroPlanilla.TabIndex = 17
        Me.TxtNumeroPlanilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCapTipoDeduccion
        '
        Me.lblCapTipoDeduccion.AutoSize = True
        Me.lblCapTipoDeduccion.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapTipoDeduccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapTipoDeduccion.Location = New System.Drawing.Point(20, 16)
        Me.lblCapTipoDeduccion.Name = "lblCapTipoDeduccion"
        Me.lblCapTipoDeduccion.Size = New System.Drawing.Size(115, 13)
        Me.lblCapTipoDeduccion.TabIndex = 0
        Me.lblCapTipoDeduccion.Text = "TIPO DE DEDUCCIÓN"
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnEjecutar.BackColor = System.Drawing.Color.RosyBrown
        Me.btnEjecutar.FlatAppearance.BorderSize = 0
        Me.btnEjecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEjecutar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!)
        Me.btnEjecutar.ForeColor = System.Drawing.Color.White
        Me.btnEjecutar.Location = New System.Drawing.Point(198, 132)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(160, 38)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'cboTipoDeduccion
        '
        Me.cboTipoDeduccion.BackColor = System.Drawing.Color.White
        Me.cboTipoDeduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDeduccion.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboTipoDeduccion.Location = New System.Drawing.Point(20, 34)
        Me.cboTipoDeduccion.Name = "cboTipoDeduccion"
        Me.cboTipoDeduccion.Size = New System.Drawing.Size(280, 25)
        Me.cboTipoDeduccion.TabIndex = 1
        '
        'lblCapCentroAcopio
        '
        Me.lblCapCentroAcopio.AutoSize = True
        Me.lblCapCentroAcopio.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapCentroAcopio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapCentroAcopio.Location = New System.Drawing.Point(320, 16)
        Me.lblCapCentroAcopio.Name = "lblCapCentroAcopio"
        Me.lblCapCentroAcopio.Size = New System.Drawing.Size(111, 13)
        Me.lblCapCentroAcopio.TabIndex = 2
        Me.lblCapCentroAcopio.Text = "CENTRO DE ACOPIO"
        '
        'cboCentroAcopio
        '
        Me.cboCentroAcopio.BackColor = System.Drawing.Color.White
        Me.cboCentroAcopio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentroAcopio.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboCentroAcopio.Location = New System.Drawing.Point(320, 34)
        Me.cboCentroAcopio.Name = "cboCentroAcopio"
        Me.cboCentroAcopio.Size = New System.Drawing.Size(280, 25)
        Me.cboCentroAcopio.TabIndex = 3
        '
        'lblCapPagarA
        '
        Me.lblCapPagarA.AutoSize = True
        Me.lblCapPagarA.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapPagarA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapPagarA.Location = New System.Drawing.Point(620, 16)
        Me.lblCapPagarA.Name = "lblCapPagarA"
        Me.lblCapPagarA.Size = New System.Drawing.Size(91, 13)
        Me.lblCapPagarA.TabIndex = 4
        Me.lblCapPagarA.Text = "Numero Planilla"
        '
        'lblCapPeriodoDesde
        '
        Me.lblCapPeriodoDesde.AutoSize = True
        Me.lblCapPeriodoDesde.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapPeriodoDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapPeriodoDesde.Location = New System.Drawing.Point(20, 76)
        Me.lblCapPeriodoDesde.Name = "lblCapPeriodoDesde"
        Me.lblCapPeriodoDesde.Size = New System.Drawing.Size(91, 13)
        Me.lblCapPeriodoDesde.TabIndex = 6
        Me.lblCapPeriodoDesde.Text = "PERÍODO DESDE"
        '
        'dtpPeriodoDesde
        '
        Me.dtpPeriodoDesde.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtpPeriodoDesde.Enabled = False
        Me.dtpPeriodoDesde.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpPeriodoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriodoDesde.Location = New System.Drawing.Point(20, 94)
        Me.dtpPeriodoDesde.Name = "dtpPeriodoDesde"
        Me.dtpPeriodoDesde.Size = New System.Drawing.Size(140, 24)
        Me.dtpPeriodoDesde.TabIndex = 7
        '
        'lblCapPeriodoHasta
        '
        Me.lblCapPeriodoHasta.AutoSize = True
        Me.lblCapPeriodoHasta.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapPeriodoHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapPeriodoHasta.Location = New System.Drawing.Point(180, 76)
        Me.lblCapPeriodoHasta.Name = "lblCapPeriodoHasta"
        Me.lblCapPeriodoHasta.Size = New System.Drawing.Size(42, 13)
        Me.lblCapPeriodoHasta.TabIndex = 8
        Me.lblCapPeriodoHasta.Text = "HASTA"
        '
        'dtpPeriodoHasta
        '
        Me.dtpPeriodoHasta.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtpPeriodoHasta.Enabled = False
        Me.dtpPeriodoHasta.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpPeriodoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriodoHasta.Location = New System.Drawing.Point(180, 94)
        Me.dtpPeriodoHasta.Name = "dtpPeriodoHasta"
        Me.dtpPeriodoHasta.Size = New System.Drawing.Size(140, 24)
        Me.dtpPeriodoHasta.TabIndex = 9
        '
        'lblCapPrecio
        '
        Me.lblCapPrecio.AutoSize = True
        Me.lblCapPrecio.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapPrecio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapPrecio.Location = New System.Drawing.Point(340, 76)
        Me.lblCapPrecio.Name = "lblCapPrecio"
        Me.lblCapPrecio.Size = New System.Drawing.Size(49, 13)
        Me.lblCapPrecio.TabIndex = 10
        Me.lblCapPrecio.Text = "MONTO"
        '
        'txtMonto
        '
        Me.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonto.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtMonto.Location = New System.Drawing.Point(340, 94)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(170, 24)
        Me.txtMonto.TabIndex = 11
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCapTipoCalculo
        '
        Me.lblCapTipoCalculo.AutoSize = True
        Me.lblCapTipoCalculo.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapTipoCalculo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapTipoCalculo.Location = New System.Drawing.Point(530, 76)
        Me.lblCapTipoCalculo.Name = "lblCapTipoCalculo"
        Me.lblCapTipoCalculo.Size = New System.Drawing.Size(101, 13)
        Me.lblCapTipoCalculo.TabIndex = 12
        Me.lblCapTipoCalculo.Text = "TIPO DE CÁLCULO"
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboTipo.Location = New System.Drawing.Point(530, 94)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(210, 25)
        Me.cboTipo.TabIndex = 13
        '
        'lblCapRedondeo
        '
        Me.lblCapRedondeo.AutoSize = True
        Me.lblCapRedondeo.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapRedondeo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapRedondeo.Location = New System.Drawing.Point(760, 76)
        Me.lblCapRedondeo.Name = "lblCapRedondeo"
        Me.lblCapRedondeo.Size = New System.Drawing.Size(67, 13)
        Me.lblCapRedondeo.TabIndex = 14
        Me.lblCapRedondeo.Text = "REDONDEO"
        '
        'cboRedondeo
        '
        Me.cboRedondeo.BackColor = System.Drawing.Color.White
        Me.cboRedondeo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRedondeo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboRedondeo.Location = New System.Drawing.Point(760, 94)
        Me.cboRedondeo.Name = "cboRedondeo"
        Me.cboRedondeo.Size = New System.Drawing.Size(172, 25)
        Me.cboRedondeo.TabIndex = 15
        '
        'btnDistribuir
        '
        Me.btnDistribuir.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnDistribuir.FlatAppearance.BorderSize = 0
        Me.btnDistribuir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnDistribuir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDistribuir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!)
        Me.btnDistribuir.ForeColor = System.Drawing.Color.White
        Me.btnDistribuir.Location = New System.Drawing.Point(20, 134)
        Me.btnDistribuir.Name = "btnDistribuir"
        Me.btnDistribuir.Size = New System.Drawing.Size(160, 36)
        Me.btnDistribuir.TabIndex = 16
        Me.btnDistribuir.Text = "Distribuir"
        Me.btnDistribuir.UseVisualStyleBackColor = False
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotal.Location = New System.Drawing.Point(759, 140)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(41, 21)
        Me.LblTotal.TabIndex = 18
        Me.LblTotal.Text = "0.00"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(646, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "TOTAL DEDUCCIÓN"
        '
        'FrmDeduccionPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(964, 561)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(900, 600)
        Me.Name = "FrmDeduccionPlanilla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deducción Planilla Leche"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCardFiltros.ResumeLayout(False)
        Me.pnlCardFiltros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblSubtitulo As System.Windows.Forms.Label

    Friend WithEvents pnlBody As System.Windows.Forms.Panel

    Friend WithEvents pnlCardFiltros As System.Windows.Forms.Panel
    Friend WithEvents lblCapTipoDeduccion As System.Windows.Forms.Label
    Friend WithEvents cboTipoDeduccion As System.Windows.Forms.ComboBox
    Friend WithEvents lblCapCentroAcopio As System.Windows.Forms.Label
    Friend WithEvents cboCentroAcopio As System.Windows.Forms.ComboBox
    Friend WithEvents lblCapPagarA As System.Windows.Forms.Label
    Friend WithEvents lblCapPeriodoDesde As System.Windows.Forms.Label
    Friend WithEvents dtpPeriodoDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCapPeriodoHasta As System.Windows.Forms.Label
    Friend WithEvents dtpPeriodoHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCapPrecio As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents lblCapTipoCalculo As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCapRedondeo As System.Windows.Forms.Label
    Friend WithEvents cboRedondeo As System.Windows.Forms.ComboBox
    Friend WithEvents btnDistribuir As System.Windows.Forms.Button
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button

    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents TxtNumeroPlanilla As TextBox
    Friend WithEvents LblTotal As Label
    Friend WithEvents Label1 As Label
End Class
