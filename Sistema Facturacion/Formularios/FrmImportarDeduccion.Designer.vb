<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportarDeduccion
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblSubtitulo = New System.Windows.Forms.Label()
        Me.pnlCardFiltros = New System.Windows.Forms.Panel()
        Me.TxtNumeroPlanilla = New System.Windows.Forms.TextBox()
        Me.lblCapTipoDeduccion = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.cboTipoDeduccion = New System.Windows.Forms.ComboBox()
        Me.lblCapCentroAcopio = New System.Windows.Forms.Label()
        Me.cboCentroAcopio = New System.Windows.Forms.ComboBox()
        Me.lblCapPagarA = New System.Windows.Forms.Label()
        Me.lblCapPeriodoDesde = New System.Windows.Forms.Label()
        Me.dtpPeriodoDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblCapPeriodoHasta = New System.Windows.Forms.Label()
        Me.dtpPeriodoHasta = New System.Windows.Forms.DateTimePicker()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlCardFiltros.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblTitulo)
        Me.pnlHeader.Controls.Add(Me.lblSubtitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(847, 64)
        Me.pnlHeader.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(24, 11)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(322, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Importar Deduccion Planilla de Leche"
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
        'pnlCardFiltros
        '
        Me.pnlCardFiltros.BackColor = System.Drawing.Color.White
        Me.pnlCardFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardFiltros.Controls.Add(Me.LblTotal)
        Me.pnlCardFiltros.Controls.Add(Me.TxtNumeroPlanilla)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapTipoDeduccion)
        Me.pnlCardFiltros.Controls.Add(Me.btnCargar)
        Me.pnlCardFiltros.Controls.Add(Me.cboTipoDeduccion)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapCentroAcopio)
        Me.pnlCardFiltros.Controls.Add(Me.cboCentroAcopio)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapPagarA)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapPeriodoDesde)
        Me.pnlCardFiltros.Controls.Add(Me.dtpPeriodoDesde)
        Me.pnlCardFiltros.Controls.Add(Me.lblCapPeriodoHasta)
        Me.pnlCardFiltros.Controls.Add(Me.dtpPeriodoHasta)
        Me.pnlCardFiltros.Controls.Add(Me.btnAbrir)
        Me.pnlCardFiltros.Location = New System.Drawing.Point(7, 68)
        Me.pnlCardFiltros.Name = "pnlCardFiltros"
        Me.pnlCardFiltros.Size = New System.Drawing.Size(828, 177)
        Me.pnlCardFiltros.TabIndex = 2
        '
        'TxtNumeroPlanilla
        '
        Me.TxtNumeroPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumeroPlanilla.Enabled = False
        Me.TxtNumeroPlanilla.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtNumeroPlanilla.Location = New System.Drawing.Point(338, 94)
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
        'btnCargar
        '
        Me.btnCargar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCargar.BackColor = System.Drawing.Color.RosyBrown
        Me.btnCargar.FlatAppearance.BorderSize = 0
        Me.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCargar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!)
        Me.btnCargar.ForeColor = System.Drawing.Color.White
        Me.btnCargar.Location = New System.Drawing.Point(338, 133)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(160, 38)
        Me.btnCargar.TabIndex = 5
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = False
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
        Me.lblCapCentroAcopio.Location = New System.Drawing.Point(335, 16)
        Me.lblCapCentroAcopio.Name = "lblCapCentroAcopio"
        Me.lblCapCentroAcopio.Size = New System.Drawing.Size(111, 13)
        Me.lblCapCentroAcopio.TabIndex = 2
        Me.lblCapCentroAcopio.Text = "CENTRO DE ACOPIO"
        '
        'cboCentroAcopio
        '
        Me.cboCentroAcopio.BackColor = System.Drawing.Color.White
        Me.cboCentroAcopio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentroAcopio.Enabled = False
        Me.cboCentroAcopio.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cboCentroAcopio.Location = New System.Drawing.Point(338, 34)
        Me.cboCentroAcopio.Name = "cboCentroAcopio"
        Me.cboCentroAcopio.Size = New System.Drawing.Size(280, 25)
        Me.cboCentroAcopio.TabIndex = 3
        '
        'lblCapPagarA
        '
        Me.lblCapPagarA.AutoSize = True
        Me.lblCapPagarA.Font = New System.Drawing.Font("Segoe UI", 7.75!, System.Drawing.FontStyle.Bold)
        Me.lblCapPagarA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCapPagarA.Location = New System.Drawing.Point(335, 76)
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
        'btnAbrir
        '
        Me.btnAbrir.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnAbrir.FlatAppearance.BorderSize = 0
        Me.btnAbrir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!)
        Me.btnAbrir.ForeColor = System.Drawing.Color.White
        Me.btnAbrir.Location = New System.Drawing.Point(20, 134)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(160, 36)
        Me.btnAbrir.TabIndex = 16
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = False
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDetalle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvDetalle.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDetalle.ColumnHeadersHeight = 40
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDetalle.EnableHeadersVisualStyles = False
        Me.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.dgvDetalle.Location = New System.Drawing.Point(7, 251)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowTemplate.Height = 34
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(829, 324)
        Me.dgvDetalle.TabIndex = 5
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotal.Location = New System.Drawing.Point(715, 140)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(41, 21)
        Me.LblTotal.TabIndex = 20
        Me.LblTotal.Text = "0.00"
        '
        'FrmImportarDeduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 587)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.pnlCardFiltros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "FrmImportarDeduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmImportarDeduccion"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlCardFiltros.ResumeLayout(False)
        Me.pnlCardFiltros.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblSubtitulo As Label
    Friend WithEvents pnlCardFiltros As Panel
    Friend WithEvents TxtNumeroPlanilla As TextBox
    Friend WithEvents lblCapTipoDeduccion As Label
    Friend WithEvents btnCargar As Button
    Friend WithEvents cboTipoDeduccion As ComboBox
    Friend WithEvents lblCapCentroAcopio As Label
    Friend WithEvents cboCentroAcopio As ComboBox
    Friend WithEvents lblCapPagarA As Label
    Friend WithEvents lblCapPeriodoDesde As Label
    Friend WithEvents dtpPeriodoDesde As DateTimePicker
    Friend WithEvents lblCapPeriodoHasta As Label
    Friend WithEvents dtpPeriodoHasta As DateTimePicker
    Friend WithEvents btnAbrir As Button
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents LblTotal As Label
End Class
