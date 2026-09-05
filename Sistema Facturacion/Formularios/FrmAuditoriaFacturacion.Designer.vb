' =====================================================================================
' FrmAuditoriaFacturacion.Designer.vb
' Diseño de formulario (.NET Framework 4.0 - Windows Forms estándar)
'
' NOTA: Este archivo contiene ÚNICAMENTE el diseño visual (InitializeComponent).
' No hay lógica de eventos, no hay handlers, no hay código de negocio.
'
' Cambios respecto a la versión anterior:
'   - Se quitó el SplitContainer: ahora "Registros" y "Evidencia" son paneles
'     independientes (grpRegistros / grpEvidencia), cada uno con Location/Size propios,
'     Anchor configurado y sin Dock forzado entre ellos -> se pueden mover/redimensionar
'     libremente desde el diseñador arrastrándolos.
'   - Botones con estilo "moderno": FlatStyle.Flat, sin borde de sistema, color de
'     fondo sólido, texto blanco, tipografía Segoe UI, y un botón primario (Ejecutar)
'     distinto de los secundarios.
'
' Si usas DevExpress (como en Zeus Nóminas), sustituciones sugeridas:
'   - Panel               -> DevExpress.XtraEditors.PanelControl
'   - Button               -> DevExpress.XtraEditors.SimpleButton (con LookAndFeel Flat)
'   - ProgressBar          -> DevExpress.XtraEditors.ProgressBarControl
'   - DataGridView         -> DevExpress.XtraGrid.GridControl + GridView
'   - GroupBox             -> DevExpress.XtraEditors.GroupControl
'   - Label                -> DevExpress.XtraEditors.LabelControl
' =====================================================================================

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAuditoriaFacturacion
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

    ' -----------------------------------------------------------------------------
    ' Controles principales
    ' -----------------------------------------------------------------------------


    ' Barra de título / acciones
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents btnDetener As System.Windows.Forms.Button
    Friend WithEvents btnReparar As System.Windows.Forms.Button
    Friend WithEvents btnMarcarRevisado As System.Windows.Forms.Button

    ' Estado y progreso
    Friend WithEvents lblEstadoCaption As System.Windows.Forms.Label
    Friend WithEvents lblEstadoValor As System.Windows.Forms.Label
    Friend WithEvents pbAuditoria As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label

    ' Panel resumen (4 tarjetas)
    Friend WithEvents pnlResumen As System.Windows.Forms.Panel
    Friend WithEvents pnlCardControles As System.Windows.Forms.Panel
    Friend WithEvents lblCardControlesTitulo As System.Windows.Forms.Label
    Friend WithEvents lblControlesValor As System.Windows.Forms.Label
    Friend WithEvents pnlCardHallazgos As System.Windows.Forms.Panel
    Friend WithEvents lblCardHallazgosTitulo As System.Windows.Forms.Label
    Friend WithEvents lblHallazgosValor As System.Windows.Forms.Label
    Friend WithEvents pnlCardReparables As System.Windows.Forms.Panel
    Friend WithEvents lblCardReparablesTitulo As System.Windows.Forms.Label
    Friend WithEvents lblReparablesValor As System.Windows.Forms.Label
    Friend WithEvents pnlCardCostos As System.Windows.Forms.Panel
    Friend WithEvents lblCardCostosTitulo As System.Windows.Forms.Label
    Friend WithEvents lblCostosValor As System.Windows.Forms.Label

    ' Grid de Controles
    Friend WithEvents grpControles As System.Windows.Forms.GroupBox
    Friend WithEvents dgvControles As System.Windows.Forms.DataGridView
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeveridad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCasos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstadoControl As System.Windows.Forms.DataGridViewTextBoxColumn

    ' Grid de Registros del control seleccionado (panel independiente, sin splitter)
    Friend WithEvents grpRegistros As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRegistros As System.Windows.Forms.DataGridView
    Friend WithEvents colDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstadoRegistro As System.Windows.Forms.DataGridViewTextBoxColumn

    ' Panel de Evidencia del Registro (panel independiente, sin splitter)
    Friend WithEvents grpEvidencia As System.Windows.Forms.GroupBox
    Friend WithEvents lblDocumentoCaption As System.Windows.Forms.Label
    Friend WithEvents lblDocumentoValor As System.Windows.Forms.Label
    Friend WithEvents lblFechaCaption As System.Windows.Forms.Label
    Friend WithEvents lblFechaValor As System.Windows.Forms.Label
    Friend WithEvents lblTipoCaption As System.Windows.Forms.Label
    Friend WithEvents lblTipoValor As System.Windows.Forms.Label
    Friend WithEvents lblProductoCaption As System.Windows.Forms.Label
    Friend WithEvents lblProductoValor As System.Windows.Forms.Label
    Friend WithEvents lblCantidadCaption As System.Windows.Forms.Label
    Friend WithEvents lblCantidadValor As System.Windows.Forms.Label
    Friend WithEvents lblPrecioUnitarioCaption As System.Windows.Forms.Label
    Friend WithEvents lblPrecioUnitarioValor As System.Windows.Forms.Label
    Friend WithEvents lblCostoUnitarioCaption As System.Windows.Forms.Label
    Friend WithEvents lblCostoUnitarioValor As System.Windows.Forms.Label
    Friend WithEvents lblMotivoCaption As System.Windows.Forms.Label
    Friend WithEvents txtMotivoValor As System.Windows.Forms.TextBox
    Friend WithEvents lblAccionCaption As System.Windows.Forms.Label
    Friend WithEvents lblAccionValor As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlToolbar = New System.Windows.Forms.Panel()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.btnDetener = New System.Windows.Forms.Button()
        Me.btnReparar = New System.Windows.Forms.Button()
        Me.btnMarcarRevisado = New System.Windows.Forms.Button()
        Me.lblEstadoCaption = New System.Windows.Forms.Label()
        Me.lblEstadoValor = New System.Windows.Forms.Label()
        Me.pbAuditoria = New System.Windows.Forms.ProgressBar()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.pnlResumen = New System.Windows.Forms.Panel()
        Me.pnlCardControles = New System.Windows.Forms.Panel()
        Me.lblCardControlesTitulo = New System.Windows.Forms.Label()
        Me.lblControlesValor = New System.Windows.Forms.Label()
        Me.pnlCardHallazgos = New System.Windows.Forms.Panel()
        Me.lblCardHallazgosTitulo = New System.Windows.Forms.Label()
        Me.lblHallazgosValor = New System.Windows.Forms.Label()
        Me.pnlCardReparables = New System.Windows.Forms.Panel()
        Me.lblCardReparablesTitulo = New System.Windows.Forms.Label()
        Me.lblReparablesValor = New System.Windows.Forms.Label()
        Me.pnlCardCostos = New System.Windows.Forms.Panel()
        Me.lblCardCostosTitulo = New System.Windows.Forms.Label()
        Me.lblCostosValor = New System.Windows.Forms.Label()
        Me.grpControles = New System.Windows.Forms.GroupBox()
        Me.dgvControles = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeveridad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCasos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstadoControl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpRegistros = New System.Windows.Forms.GroupBox()
        Me.dgvRegistros = New System.Windows.Forms.DataGridView()
        Me.colDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstadoRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpEvidencia = New System.Windows.Forms.GroupBox()
        Me.lblDocumentoCaption = New System.Windows.Forms.Label()
        Me.lblDocumentoValor = New System.Windows.Forms.Label()
        Me.lblFechaCaption = New System.Windows.Forms.Label()
        Me.lblFechaValor = New System.Windows.Forms.Label()
        Me.lblTipoCaption = New System.Windows.Forms.Label()
        Me.lblTipoValor = New System.Windows.Forms.Label()
        Me.lblProductoCaption = New System.Windows.Forms.Label()
        Me.lblProductoValor = New System.Windows.Forms.Label()
        Me.lblCantidadCaption = New System.Windows.Forms.Label()
        Me.lblCantidadValor = New System.Windows.Forms.Label()
        Me.lblPrecioUnitarioCaption = New System.Windows.Forms.Label()
        Me.lblPrecioUnitarioValor = New System.Windows.Forms.Label()
        Me.lblCostoUnitarioCaption = New System.Windows.Forms.Label()
        Me.lblCostoUnitarioValor = New System.Windows.Forms.Label()
        Me.lblMotivoCaption = New System.Windows.Forms.Label()
        Me.txtMotivoValor = New System.Windows.Forms.TextBox()
        Me.lblAccionCaption = New System.Windows.Forms.Label()
        Me.lblAccionValor = New System.Windows.Forms.Label()
        Me.pnlToolbar.SuspendLayout()
        Me.pnlResumen.SuspendLayout()
        Me.pnlCardControles.SuspendLayout()
        Me.pnlCardHallazgos.SuspendLayout()
        Me.pnlCardReparables.SuspendLayout()
        Me.pnlCardCostos.SuspendLayout()
        Me.grpControles.SuspendLayout()
        CType(Me.dgvControles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRegistros.SuspendLayout()
        CType(Me.dgvRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpEvidencia.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.Color.White
        Me.pnlToolbar.Controls.Add(Me.btnEjecutar)
        Me.pnlToolbar.Controls.Add(Me.btnDetener)
        Me.pnlToolbar.Controls.Add(Me.btnReparar)
        Me.pnlToolbar.Controls.Add(Me.btnMarcarRevisado)
        Me.pnlToolbar.Controls.Add(Me.lblEstadoCaption)
        Me.pnlToolbar.Controls.Add(Me.lblEstadoValor)
        Me.pnlToolbar.Controls.Add(Me.pbAuditoria)
        Me.pnlToolbar.Controls.Add(Me.lblPorcentaje)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.pnlToolbar.Size = New System.Drawing.Size(1109, 96)
        Me.pnlToolbar.TabIndex = 4
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnEjecutar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEjecutar.FlatAppearance.BorderSize = 0
        Me.btnEjecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEjecutar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.btnEjecutar.ForeColor = System.Drawing.Color.White
        Me.btnEjecutar.Location = New System.Drawing.Point(16, 10)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(168, 34)
        Me.btnEjecutar.TabIndex = 0
        Me.btnEjecutar.Text = "▶  Ejecutar Auditoría"
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'btnDetener
        '
        Me.btnDetener.BackColor = System.Drawing.Color.White
        Me.btnDetener.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDetener.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDetener.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetener.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDetener.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnDetener.Location = New System.Drawing.Point(192, 10)
        Me.btnDetener.Name = "btnDetener"
        Me.btnDetener.Size = New System.Drawing.Size(110, 34)
        Me.btnDetener.TabIndex = 1
        Me.btnDetener.Text = "◼  Detener"
        Me.btnDetener.UseVisualStyleBackColor = False
        '
        'btnReparar
        '
        Me.btnReparar.BackColor = System.Drawing.Color.White
        Me.btnReparar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReparar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.btnReparar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnReparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReparar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnReparar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.btnReparar.Location = New System.Drawing.Point(310, 10)
        Me.btnReparar.Name = "btnReparar"
        Me.btnReparar.Size = New System.Drawing.Size(110, 34)
        Me.btnReparar.TabIndex = 2
        Me.btnReparar.Text = "🛠  Reparar"
        Me.btnReparar.UseVisualStyleBackColor = False
        '
        'btnMarcarRevisado
        '
        Me.btnMarcarRevisado.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnMarcarRevisado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMarcarRevisado.FlatAppearance.BorderSize = 0
        Me.btnMarcarRevisado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnMarcarRevisado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarcarRevisado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMarcarRevisado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnMarcarRevisado.Location = New System.Drawing.Point(428, 10)
        Me.btnMarcarRevisado.Name = "btnMarcarRevisado"
        Me.btnMarcarRevisado.Size = New System.Drawing.Size(150, 34)
        Me.btnMarcarRevisado.TabIndex = 3
        Me.btnMarcarRevisado.Text = "✓  Marcar Revisado"
        Me.btnMarcarRevisado.UseVisualStyleBackColor = False
        '
        'lblEstadoCaption
        '
        Me.lblEstadoCaption.AutoSize = True
        Me.lblEstadoCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblEstadoCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblEstadoCaption.Location = New System.Drawing.Point(16, 54)
        Me.lblEstadoCaption.Name = "lblEstadoCaption"
        Me.lblEstadoCaption.Size = New System.Drawing.Size(45, 15)
        Me.lblEstadoCaption.TabIndex = 4
        Me.lblEstadoCaption.Text = "Estado:"
        '
        'lblEstadoValor
        '
        Me.lblEstadoValor.AutoSize = True
        Me.lblEstadoValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEstadoValor.Location = New System.Drawing.Point(74, 54)
        Me.lblEstadoValor.Name = "lblEstadoValor"
        Me.lblEstadoValor.Size = New System.Drawing.Size(127, 15)
        Me.lblEstadoValor.TabIndex = 5
        Me.lblEstadoValor.Text = "Auditoría no ejecutada"
        '
        'pbAuditoria
        '
        Me.pbAuditoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAuditoria.Location = New System.Drawing.Point(16, 74)
        Me.pbAuditoria.Name = "pbAuditoria"
        Me.pbAuditoria.Size = New System.Drawing.Size(1069, 10)
        Me.pbAuditoria.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbAuditoria.TabIndex = 6
        Me.pbAuditoria.Value = 75
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.lblPorcentaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblPorcentaje.Location = New System.Drawing.Point(1691, 71)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(30, 15)
        Me.lblPorcentaje.TabIndex = 7
        Me.lblPorcentaje.Text = "75%"
        '
        'pnlResumen
        '
        Me.pnlResumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlResumen.Controls.Add(Me.pnlCardControles)
        Me.pnlResumen.Controls.Add(Me.pnlCardHallazgos)
        Me.pnlResumen.Controls.Add(Me.pnlCardReparables)
        Me.pnlResumen.Controls.Add(Me.pnlCardCostos)
        Me.pnlResumen.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlResumen.Location = New System.Drawing.Point(0, 96)
        Me.pnlResumen.Name = "pnlResumen"
        Me.pnlResumen.Padding = New System.Windows.Forms.Padding(16, 12, 16, 12)
        Me.pnlResumen.Size = New System.Drawing.Size(1109, 96)
        Me.pnlResumen.TabIndex = 3
        '
        'pnlCardControles
        '
        Me.pnlCardControles.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlCardControles.Controls.Add(Me.lblCardControlesTitulo)
        Me.pnlCardControles.Controls.Add(Me.lblControlesValor)
        Me.pnlCardControles.Location = New System.Drawing.Point(16, 12)
        Me.pnlCardControles.Name = "pnlCardControles"
        Me.pnlCardControles.Size = New System.Drawing.Size(190, 72)
        Me.pnlCardControles.TabIndex = 0
        '
        'lblCardControlesTitulo
        '
        Me.lblCardControlesTitulo.AutoSize = True
        Me.lblCardControlesTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardControlesTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCardControlesTitulo.Location = New System.Drawing.Point(14, 12)
        Me.lblCardControlesTitulo.Name = "lblCardControlesTitulo"
        Me.lblCardControlesTitulo.Size = New System.Drawing.Size(140, 13)
        Me.lblCardControlesTitulo.TabIndex = 0
        Me.lblCardControlesTitulo.Text = "CONTROLES EJECUTADOS"
        '
        'lblControlesValor
        '
        Me.lblControlesValor.AutoSize = True
        Me.lblControlesValor.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!)
        Me.lblControlesValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblControlesValor.Location = New System.Drawing.Point(14, 32)
        Me.lblControlesValor.Name = "lblControlesValor"
        Me.lblControlesValor.Size = New System.Drawing.Size(32, 37)
        Me.lblControlesValor.TabIndex = 1
        Me.lblControlesValor.Text = "0"
        '
        'pnlCardHallazgos
        '
        Me.pnlCardHallazgos.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlCardHallazgos.Controls.Add(Me.lblCardHallazgosTitulo)
        Me.pnlCardHallazgos.Controls.Add(Me.lblHallazgosValor)
        Me.pnlCardHallazgos.Location = New System.Drawing.Point(216, 12)
        Me.pnlCardHallazgos.Name = "pnlCardHallazgos"
        Me.pnlCardHallazgos.Size = New System.Drawing.Size(190, 72)
        Me.pnlCardHallazgos.TabIndex = 1
        '
        'lblCardHallazgosTitulo
        '
        Me.lblCardHallazgosTitulo.AutoSize = True
        Me.lblCardHallazgosTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardHallazgosTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCardHallazgosTitulo.Location = New System.Drawing.Point(14, 12)
        Me.lblCardHallazgosTitulo.Name = "lblCardHallazgosTitulo"
        Me.lblCardHallazgosTitulo.Size = New System.Drawing.Size(72, 13)
        Me.lblCardHallazgosTitulo.TabIndex = 0
        Me.lblCardHallazgosTitulo.Text = "HALLAZGOS"
        '
        'lblHallazgosValor
        '
        Me.lblHallazgosValor.AutoSize = True
        Me.lblHallazgosValor.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!)
        Me.lblHallazgosValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.lblHallazgosValor.Location = New System.Drawing.Point(14, 32)
        Me.lblHallazgosValor.Name = "lblHallazgosValor"
        Me.lblHallazgosValor.Size = New System.Drawing.Size(32, 37)
        Me.lblHallazgosValor.TabIndex = 1
        Me.lblHallazgosValor.Text = "0"
        '
        'pnlCardReparables
        '
        Me.pnlCardReparables.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlCardReparables.Controls.Add(Me.lblCardReparablesTitulo)
        Me.pnlCardReparables.Controls.Add(Me.lblReparablesValor)
        Me.pnlCardReparables.Location = New System.Drawing.Point(416, 12)
        Me.pnlCardReparables.Name = "pnlCardReparables"
        Me.pnlCardReparables.Size = New System.Drawing.Size(190, 72)
        Me.pnlCardReparables.TabIndex = 2
        '
        'lblCardReparablesTitulo
        '
        Me.lblCardReparablesTitulo.AutoSize = True
        Me.lblCardReparablesTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardReparablesTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCardReparablesTitulo.Location = New System.Drawing.Point(14, 12)
        Me.lblCardReparablesTitulo.Name = "lblCardReparablesTitulo"
        Me.lblCardReparablesTitulo.Size = New System.Drawing.Size(74, 13)
        Me.lblCardReparablesTitulo.TabIndex = 0
        Me.lblCardReparablesTitulo.Text = "REPARABLES"
        '
        'lblReparablesValor
        '
        Me.lblReparablesValor.AutoSize = True
        Me.lblReparablesValor.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!)
        Me.lblReparablesValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.lblReparablesValor.Location = New System.Drawing.Point(14, 32)
        Me.lblReparablesValor.Name = "lblReparablesValor"
        Me.lblReparablesValor.Size = New System.Drawing.Size(32, 37)
        Me.lblReparablesValor.TabIndex = 1
        Me.lblReparablesValor.Text = "0"
        '
        'pnlCardCostos
        '
        Me.pnlCardCostos.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlCardCostos.Controls.Add(Me.lblCardCostosTitulo)
        Me.pnlCardCostos.Controls.Add(Me.lblCostosValor)
        Me.pnlCardCostos.Location = New System.Drawing.Point(616, 12)
        Me.pnlCardCostos.Name = "pnlCardCostos"
        Me.pnlCardCostos.Size = New System.Drawing.Size(190, 72)
        Me.pnlCardCostos.TabIndex = 3
        '
        'lblCardCostosTitulo
        '
        Me.lblCardCostosTitulo.AutoSize = True
        Me.lblCardCostosTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardCostosTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCardCostosTitulo.Location = New System.Drawing.Point(14, 12)
        Me.lblCardCostosTitulo.Name = "lblCardCostosTitulo"
        Me.lblCardCostosTitulo.Size = New System.Drawing.Size(48, 13)
        Me.lblCardCostosTitulo.TabIndex = 0
        Me.lblCardCostosTitulo.Text = "COSTOS"
        '
        'lblCostosValor
        '
        Me.lblCostosValor.AutoSize = True
        Me.lblCostosValor.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!)
        Me.lblCostosValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCostosValor.Location = New System.Drawing.Point(14, 36)
        Me.lblCostosValor.Name = "lblCostosValor"
        Me.lblCostosValor.Size = New System.Drawing.Size(123, 25)
        Me.lblCostosValor.TabIndex = 1
        Me.lblCostosValor.Text = "PENDIENTES"
        '
        'grpControles
        '
        Me.grpControles.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grpControles.Controls.Add(Me.dgvControles)
        Me.grpControles.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.grpControles.Location = New System.Drawing.Point(12, 198)
        Me.grpControles.Name = "grpControles"
        Me.grpControles.Size = New System.Drawing.Size(745, 188)
        Me.grpControles.TabIndex = 2
        Me.grpControles.TabStop = False
        Me.grpControles.Text = "Controles"
        '
        'dgvControles
        '
        Me.dgvControles.AllowUserToAddRows = False
        Me.dgvControles.AllowUserToDeleteRows = False
        Me.dgvControles.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvControles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvControles.BackgroundColor = System.Drawing.Color.White
        Me.dgvControles.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvControles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvControles.ColumnHeadersHeight = 32
        Me.dgvControles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colSeveridad, Me.colDescripcion, Me.colCasos, Me.colEstadoControl})
        Me.dgvControles.EnableHeadersVisualStyles = False
        Me.dgvControles.GridColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvControles.Location = New System.Drawing.Point(15, 22)
        Me.dgvControles.MultiSelect = False
        Me.dgvControles.Name = "dgvControles"
        Me.dgvControles.ReadOnly = True
        Me.dgvControles.RowHeadersVisible = False
        Me.dgvControles.RowTemplate.Height = 28
        Me.dgvControles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvControles.Size = New System.Drawing.Size(711, 150)
        Me.dgvControles.TabIndex = 0
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        '
        'colSeveridad
        '
        Me.colSeveridad.HeaderText = "Severidad"
        Me.colSeveridad.Name = "colSeveridad"
        Me.colSeveridad.ReadOnly = True
        '
        'colDescripcion
        '
        Me.colDescripcion.FillWeight = 220.0!
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'colCasos
        '
        Me.colCasos.HeaderText = "Casos"
        Me.colCasos.Name = "colCasos"
        Me.colCasos.ReadOnly = True
        '
        'colEstadoControl
        '
        Me.colEstadoControl.HeaderText = "Estado"
        Me.colEstadoControl.Name = "colEstadoControl"
        Me.colEstadoControl.ReadOnly = True
        '
        'grpRegistros
        '
        Me.grpRegistros.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grpRegistros.Controls.Add(Me.dgvRegistros)
        Me.grpRegistros.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.grpRegistros.Location = New System.Drawing.Point(12, 392)
        Me.grpRegistros.Name = "grpRegistros"
        Me.grpRegistros.Size = New System.Drawing.Size(745, 200)
        Me.grpRegistros.TabIndex = 1
        Me.grpRegistros.TabStop = False
        Me.grpRegistros.Text = "Registros del Control Seleccionado"
        '
        'dgvRegistros
        '
        Me.dgvRegistros.AllowUserToAddRows = False
        Me.dgvRegistros.AllowUserToDeleteRows = False
        Me.dgvRegistros.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRegistros.BackgroundColor = System.Drawing.Color.White
        Me.dgvRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRegistros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvRegistros.ColumnHeadersHeight = 32
        Me.dgvRegistros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDocumento, Me.colFecha, Me.colProducto, Me.colCantidad, Me.colCosto, Me.colEstadoRegistro})
        Me.dgvRegistros.EnableHeadersVisualStyles = False
        Me.dgvRegistros.GridColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvRegistros.Location = New System.Drawing.Point(8, 22)
        Me.dgvRegistros.MultiSelect = False
        Me.dgvRegistros.Name = "dgvRegistros"
        Me.dgvRegistros.ReadOnly = True
        Me.dgvRegistros.RowHeadersVisible = False
        Me.dgvRegistros.RowTemplate.Height = 28
        Me.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRegistros.Size = New System.Drawing.Size(718, 150)
        Me.dgvRegistros.TabIndex = 0
        '
        'colDocumento
        '
        Me.colDocumento.HeaderText = "Documento"
        Me.colDocumento.Name = "colDocumento"
        Me.colDocumento.ReadOnly = True
        '
        'colFecha
        '
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        '
        'colProducto
        '
        Me.colProducto.HeaderText = "Producto"
        Me.colProducto.Name = "colProducto"
        Me.colProducto.ReadOnly = True
        '
        'colCantidad
        '
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.ReadOnly = True
        '
        'colCosto
        '
        Me.colCosto.HeaderText = "Costo"
        Me.colCosto.Name = "colCosto"
        Me.colCosto.ReadOnly = True
        '
        'colEstadoRegistro
        '
        Me.colEstadoRegistro.HeaderText = "Estado"
        Me.colEstadoRegistro.Name = "colEstadoRegistro"
        Me.colEstadoRegistro.ReadOnly = True
        '
        'grpEvidencia
        '
        Me.grpEvidencia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grpEvidencia.Controls.Add(Me.lblDocumentoCaption)
        Me.grpEvidencia.Controls.Add(Me.lblDocumentoValor)
        Me.grpEvidencia.Controls.Add(Me.lblFechaCaption)
        Me.grpEvidencia.Controls.Add(Me.lblFechaValor)
        Me.grpEvidencia.Controls.Add(Me.lblTipoCaption)
        Me.grpEvidencia.Controls.Add(Me.lblTipoValor)
        Me.grpEvidencia.Controls.Add(Me.lblProductoCaption)
        Me.grpEvidencia.Controls.Add(Me.lblProductoValor)
        Me.grpEvidencia.Controls.Add(Me.lblCantidadCaption)
        Me.grpEvidencia.Controls.Add(Me.lblCantidadValor)
        Me.grpEvidencia.Controls.Add(Me.lblPrecioUnitarioCaption)
        Me.grpEvidencia.Controls.Add(Me.lblPrecioUnitarioValor)
        Me.grpEvidencia.Controls.Add(Me.lblCostoUnitarioCaption)
        Me.grpEvidencia.Controls.Add(Me.lblCostoUnitarioValor)
        Me.grpEvidencia.Controls.Add(Me.lblMotivoCaption)
        Me.grpEvidencia.Controls.Add(Me.txtMotivoValor)
        Me.grpEvidencia.Controls.Add(Me.lblAccionCaption)
        Me.grpEvidencia.Controls.Add(Me.lblAccionValor)
        Me.grpEvidencia.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.grpEvidencia.Location = New System.Drawing.Point(763, 198)
        Me.grpEvidencia.Name = "grpEvidencia"
        Me.grpEvidencia.Size = New System.Drawing.Size(334, 394)
        Me.grpEvidencia.TabIndex = 0
        Me.grpEvidencia.TabStop = False
        Me.grpEvidencia.Text = "Evidencia del Registro"
        '
        'lblDocumentoCaption
        '
        Me.lblDocumentoCaption.AutoSize = True
        Me.lblDocumentoCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblDocumentoCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblDocumentoCaption.Location = New System.Drawing.Point(16, 30)
        Me.lblDocumentoCaption.Name = "lblDocumentoCaption"
        Me.lblDocumentoCaption.Size = New System.Drawing.Size(74, 15)
        Me.lblDocumentoCaption.TabIndex = 0
        Me.lblDocumentoCaption.Text = "Documento:"
        '
        'lblDocumentoValor
        '
        Me.lblDocumentoValor.AutoSize = True
        Me.lblDocumentoValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDocumentoValor.Location = New System.Drawing.Point(125, 30)
        Me.lblDocumentoValor.Name = "lblDocumentoValor"
        Me.lblDocumentoValor.Size = New System.Drawing.Size(13, 15)
        Me.lblDocumentoValor.TabIndex = 1
        Me.lblDocumentoValor.Text = "0"
        '
        'lblFechaCaption
        '
        Me.lblFechaCaption.AutoSize = True
        Me.lblFechaCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblFechaCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblFechaCaption.Location = New System.Drawing.Point(191, 30)
        Me.lblFechaCaption.Name = "lblFechaCaption"
        Me.lblFechaCaption.Size = New System.Drawing.Size(41, 15)
        Me.lblFechaCaption.TabIndex = 2
        Me.lblFechaCaption.Text = "Fecha:"
        '
        'lblFechaValor
        '
        Me.lblFechaValor.AutoSize = True
        Me.lblFechaValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFechaValor.Location = New System.Drawing.Point(229, 30)
        Me.lblFechaValor.Name = "lblFechaValor"
        Me.lblFechaValor.Size = New System.Drawing.Size(65, 15)
        Me.lblFechaValor.TabIndex = 3
        Me.lblFechaValor.Text = "11/08/2026"
        '
        'lblTipoCaption
        '
        Me.lblTipoCaption.AutoSize = True
        Me.lblTipoCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblTipoCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblTipoCaption.Location = New System.Drawing.Point(16, 56)
        Me.lblTipoCaption.Name = "lblTipoCaption"
        Me.lblTipoCaption.Size = New System.Drawing.Size(34, 15)
        Me.lblTipoCaption.TabIndex = 4
        Me.lblTipoCaption.Text = "Tipo:"
        '
        'lblTipoValor
        '
        Me.lblTipoValor.AutoSize = True
        Me.lblTipoValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTipoValor.Location = New System.Drawing.Point(125, 56)
        Me.lblTipoValor.Name = "lblTipoValor"
        Me.lblTipoValor.Size = New System.Drawing.Size(46, 15)
        Me.lblTipoValor.TabIndex = 5
        Me.lblTipoValor.Text = "Factura"
        '
        'lblProductoCaption
        '
        Me.lblProductoCaption.AutoSize = True
        Me.lblProductoCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblProductoCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblProductoCaption.Location = New System.Drawing.Point(16, 80)
        Me.lblProductoCaption.Name = "lblProductoCaption"
        Me.lblProductoCaption.Size = New System.Drawing.Size(59, 15)
        Me.lblProductoCaption.TabIndex = 6
        Me.lblProductoCaption.Text = "Producto:"
        '
        'lblProductoValor
        '
        Me.lblProductoValor.AutoSize = True
        Me.lblProductoValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblProductoValor.Location = New System.Drawing.Point(125, 80)
        Me.lblProductoValor.Name = "lblProductoValor"
        Me.lblProductoValor.Size = New System.Drawing.Size(37, 15)
        Me.lblProductoValor.TabIndex = 7
        Me.lblProductoValor.Text = "00125"
        '
        'lblCantidadCaption
        '
        Me.lblCantidadCaption.AutoSize = True
        Me.lblCantidadCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblCantidadCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCantidadCaption.Location = New System.Drawing.Point(18, 111)
        Me.lblCantidadCaption.Name = "lblCantidadCaption"
        Me.lblCantidadCaption.Size = New System.Drawing.Size(57, 15)
        Me.lblCantidadCaption.TabIndex = 8
        Me.lblCantidadCaption.Text = "Cantidad:"
        '
        'lblCantidadValor
        '
        Me.lblCantidadValor.AutoSize = True
        Me.lblCantidadValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCantidadValor.Location = New System.Drawing.Point(125, 111)
        Me.lblCantidadValor.Name = "lblCantidadValor"
        Me.lblCantidadValor.Size = New System.Drawing.Size(13, 15)
        Me.lblCantidadValor.TabIndex = 9
        Me.lblCantidadValor.Text = "0"
        '
        'lblPrecioUnitarioCaption
        '
        Me.lblPrecioUnitarioCaption.AutoSize = True
        Me.lblPrecioUnitarioCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblPrecioUnitarioCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblPrecioUnitarioCaption.Location = New System.Drawing.Point(18, 135)
        Me.lblPrecioUnitarioCaption.Name = "lblPrecioUnitarioCaption"
        Me.lblPrecioUnitarioCaption.Size = New System.Drawing.Size(88, 15)
        Me.lblPrecioUnitarioCaption.TabIndex = 10
        Me.lblPrecioUnitarioCaption.Text = "Precio Unitario:"
        '
        'lblPrecioUnitarioValor
        '
        Me.lblPrecioUnitarioValor.AutoSize = True
        Me.lblPrecioUnitarioValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPrecioUnitarioValor.Location = New System.Drawing.Point(125, 135)
        Me.lblPrecioUnitarioValor.Name = "lblPrecioUnitarioValor"
        Me.lblPrecioUnitarioValor.Size = New System.Drawing.Size(13, 15)
        Me.lblPrecioUnitarioValor.TabIndex = 11
        Me.lblPrecioUnitarioValor.Text = "0"
        '
        'lblCostoUnitarioCaption
        '
        Me.lblCostoUnitarioCaption.AutoSize = True
        Me.lblCostoUnitarioCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblCostoUnitarioCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCostoUnitarioCaption.Location = New System.Drawing.Point(18, 159)
        Me.lblCostoUnitarioCaption.Name = "lblCostoUnitarioCaption"
        Me.lblCostoUnitarioCaption.Size = New System.Drawing.Size(85, 15)
        Me.lblCostoUnitarioCaption.TabIndex = 12
        Me.lblCostoUnitarioCaption.Text = "Costo Unitario:"
        '
        'lblCostoUnitarioValor
        '
        Me.lblCostoUnitarioValor.AutoSize = True
        Me.lblCostoUnitarioValor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblCostoUnitarioValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblCostoUnitarioValor.Location = New System.Drawing.Point(125, 159)
        Me.lblCostoUnitarioValor.Name = "lblCostoUnitarioValor"
        Me.lblCostoUnitarioValor.Size = New System.Drawing.Size(31, 15)
        Me.lblCostoUnitarioValor.TabIndex = 13
        Me.lblCostoUnitarioValor.Text = "0.00"
        '
        'lblMotivoCaption
        '
        Me.lblMotivoCaption.AutoSize = True
        Me.lblMotivoCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblMotivoCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblMotivoCaption.Location = New System.Drawing.Point(18, 183)
        Me.lblMotivoCaption.Name = "lblMotivoCaption"
        Me.lblMotivoCaption.Size = New System.Drawing.Size(48, 15)
        Me.lblMotivoCaption.TabIndex = 14
        Me.lblMotivoCaption.Text = "Motivo:"
        '
        'txtMotivoValor
        '
        Me.txtMotivoValor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMotivoValor.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtMotivoValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotivoValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMotivoValor.Location = New System.Drawing.Point(18, 201)
        Me.txtMotivoValor.Multiline = True
        Me.txtMotivoValor.Name = "txtMotivoValor"
        Me.txtMotivoValor.ReadOnly = True
        Me.txtMotivoValor.Size = New System.Drawing.Size(296, 123)
        Me.txtMotivoValor.TabIndex = 15
        Me.txtMotivoValor.Text = "El movimiento requiere costo histórico y Costo_Unitario = 0."
        '
        'lblAccionCaption
        '
        Me.lblAccionCaption.AutoSize = True
        Me.lblAccionCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblAccionCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblAccionCaption.Location = New System.Drawing.Point(22, 336)
        Me.lblAccionCaption.Name = "lblAccionCaption"
        Me.lblAccionCaption.Size = New System.Drawing.Size(105, 15)
        Me.lblAccionCaption.TabIndex = 16
        Me.lblAccionCaption.Text = "Acción disponible:"
        '
        'lblAccionValor
        '
        Me.lblAccionValor.AutoSize = True
        Me.lblAccionValor.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.lblAccionValor.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!)
        Me.lblAccionValor.ForeColor = System.Drawing.Color.White
        Me.lblAccionValor.Location = New System.Drawing.Point(22, 357)
        Me.lblAccionValor.Name = "lblAccionValor"
        Me.lblAccionValor.Padding = New System.Windows.Forms.Padding(10, 4, 10, 4)
        Me.lblAccionValor.Size = New System.Drawing.Size(134, 23)
        Me.lblAccionValor.TabIndex = 17
        Me.lblAccionValor.Text = "REVISIÓN MANUAL"
        '
        'FrmAuditoriaFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1109, 661)
        Me.Controls.Add(Me.grpEvidencia)
        Me.Controls.Add(Me.grpRegistros)
        Me.Controls.Add(Me.grpControles)
        Me.Controls.Add(Me.pnlResumen)
        Me.Controls.Add(Me.pnlToolbar)
        Me.MinimumSize = New System.Drawing.Size(840, 700)
        Me.Name = "FrmAuditoriaFacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auditoría del Sistema de Facturación"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.pnlResumen.ResumeLayout(False)
        Me.pnlCardControles.ResumeLayout(False)
        Me.pnlCardControles.PerformLayout()
        Me.pnlCardHallazgos.ResumeLayout(False)
        Me.pnlCardHallazgos.PerformLayout()
        Me.pnlCardReparables.ResumeLayout(False)
        Me.pnlCardReparables.PerformLayout()
        Me.pnlCardCostos.ResumeLayout(False)
        Me.pnlCardCostos.PerformLayout()
        Me.grpControles.ResumeLayout(False)
        CType(Me.dgvControles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRegistros.ResumeLayout(False)
        CType(Me.dgvRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpEvidencia.ResumeLayout(False)
        Me.grpEvidencia.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

End Class
