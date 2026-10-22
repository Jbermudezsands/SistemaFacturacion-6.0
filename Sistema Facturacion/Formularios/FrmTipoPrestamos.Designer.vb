<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoPrestamos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipoPrestamos))
        Me.PicEncabezado = New System.Windows.Forms.PictureBox()
        Me.PicIcono = New System.Windows.Forms.PictureBox()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlGeneral = New System.Windows.Forms.Panel()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.CboCodigoLinea = New C1.Win.C1List.C1Combo()
        Me.CmdBuscarTipo = New System.Windows.Forms.Button()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblModalidad = New System.Windows.Forms.Label()
        Me.CboCodigoModalidad = New C1.Win.C1List.C1Combo()
        Me.CmdBuscarModalidad = New System.Windows.Forms.Button()
        Me.GrpIntereses = New System.Windows.Forms.GroupBox()
        Me.ChkInteresUnico = New System.Windows.Forms.CheckBox()
        Me.TxtInteresUnico = New System.Windows.Forms.TextBox()
        Me.LblInteresAnual = New System.Windows.Forms.Label()
        Me.TxtInteresAnual = New System.Windows.Forms.TextBox()
        Me.LblInteresMensual = New System.Windows.Forms.Label()
        Me.TxtInteresMensual = New System.Windows.Forms.TextBox()
        Me.LblInteresDiario = New System.Windows.Forms.Label()
        Me.TxtInteresDiario = New System.Windows.Forms.TextBox()
        Me.GrpInteresesDiario = New System.Windows.Forms.GroupBox()
        Me.LblDeslizamiento = New System.Windows.Forms.Label()
        Me.TxtInteresDeslizamiento = New System.Windows.Forms.TextBox()
        Me.LblMora = New System.Windows.Forms.Label()
        Me.TxtInteresMora = New System.Windows.Forms.TextBox()
        Me.LblCantidadPrestamos = New System.Windows.Forms.Label()
        Me.TxtCantidadPrestamos = New System.Windows.Forms.NumericUpDown()
        Me.LblMaximoCuotas = New System.Windows.Forms.Label()
        Me.TxtMaximoCuotas = New System.Windows.Forms.NumericUpDown()
        Me.PnlAcciones = New System.Windows.Forms.Panel()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.CmdEliminar = New System.Windows.Forms.Button()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        CType(Me.PicEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlGeneral.SuspendLayout()
        CType(Me.CboCodigoLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoModalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpIntereses.SuspendLayout()
        Me.GrpInteresesDiario.SuspendLayout()
        CType(Me.TxtCantidadPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMaximoCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicEncabezado
        '
        Me.PicEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.PicEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.PicEncabezado.Name = "PicEncabezado"
        Me.PicEncabezado.Size = New System.Drawing.Size(480, 52)
        Me.PicEncabezado.TabIndex = 21
        Me.PicEncabezado.TabStop = False
        '
        'PicIcono
        '
        Me.PicIcono.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PicIcono.Image = CType(resources.GetObject("PicIcono.Image"), System.Drawing.Image)
        Me.PicIcono.Location = New System.Drawing.Point(16, 7)
        Me.PicIcono.Name = "PicIcono"
        Me.PicIcono.Size = New System.Drawing.Size(40, 40)
        Me.PicIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicIcono.TabIndex = 23
        Me.PicIcono.TabStop = False
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(66, 12)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(194, 25)
        Me.LblTitulo.TabIndex = 22
        Me.LblTitulo.Text = "TIPO DE PRÉSTAMOS"
        '
        'PnlGeneral
        '
        Me.PnlGeneral.BackColor = System.Drawing.Color.White
        Me.PnlGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlGeneral.Controls.Add(Me.LblCodigo)
        Me.PnlGeneral.Controls.Add(Me.CboCodigoLinea)
        Me.PnlGeneral.Controls.Add(Me.CmdBuscarTipo)
        Me.PnlGeneral.Controls.Add(Me.LblNombre)
        Me.PnlGeneral.Controls.Add(Me.TxtNombre)
        Me.PnlGeneral.Controls.Add(Me.LblModalidad)
        Me.PnlGeneral.Controls.Add(Me.CboCodigoModalidad)
        Me.PnlGeneral.Controls.Add(Me.CmdBuscarModalidad)
        Me.PnlGeneral.Location = New System.Drawing.Point(12, 58)
        Me.PnlGeneral.Name = "PnlGeneral"
        Me.PnlGeneral.Size = New System.Drawing.Size(448, 176)
        Me.PnlGeneral.TabIndex = 1
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblCodigo.Location = New System.Drawing.Point(14, 12)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(123, 15)
        Me.LblCodigo.TabIndex = 90
        Me.LblCodigo.Text = "Código tipo préstamo"
        '
        'CboCodigoLinea
        '
        Me.CboCodigoLinea.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoLinea.Caption = ""
        Me.CboCodigoLinea.CaptionHeight = 17
        Me.CboCodigoLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoLinea.ColumnCaptionHeight = 17
        Me.CboCodigoLinea.ColumnFooterHeight = 17
        Me.CboCodigoLinea.ContentHeight = 20
        Me.CboCodigoLinea.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoLinea.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoLinea.EditorFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoLinea.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoLinea.EditorHeight = 20
        Me.CboCodigoLinea.Images.Add(CType(resources.GetObject("CboCodigoLinea.Images"), System.Drawing.Image))
        Me.CboCodigoLinea.ItemHeight = 19
        Me.CboCodigoLinea.Location = New System.Drawing.Point(14, 30)
        Me.CboCodigoLinea.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoLinea.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoLinea.MaxLength = 32767
        Me.CboCodigoLinea.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoLinea.Name = "CboCodigoLinea"
        Me.CboCodigoLinea.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoLinea.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoLinea.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoLinea.Size = New System.Drawing.Size(370, 26)
        Me.CboCodigoLinea.TabIndex = 87
        Me.CboCodigoLinea.PropBag = resources.GetString("CboCodigoLinea.PropBag")
        '
        'CmdBuscarTipo
        '
        Me.CmdBuscarTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.CmdBuscarTipo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdBuscarTipo.FlatAppearance.BorderSize = 0
        Me.CmdBuscarTipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdBuscarTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBuscarTipo.Image = CType(resources.GetObject("CmdBuscarTipo.Image"), System.Drawing.Image)
        Me.CmdBuscarTipo.Location = New System.Drawing.Point(394, 28)
        Me.CmdBuscarTipo.Name = "CmdBuscarTipo"
        Me.CmdBuscarTipo.Size = New System.Drawing.Size(36, 29)
        Me.CmdBuscarTipo.TabIndex = 164
        Me.CmdBuscarTipo.UseVisualStyleBackColor = False
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblNombre.Location = New System.Drawing.Point(14, 66)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(128, 15)
        Me.LblNombre.TabIndex = 91
        Me.LblNombre.Text = "Nombre tipo préstamo"
        '
        'TxtNombre
        '
        Me.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNombre.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(14, 84)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(416, 25)
        Me.TxtNombre.TabIndex = 88
        '
        'LblModalidad
        '
        Me.LblModalidad.AutoSize = True
        Me.LblModalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModalidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblModalidad.Location = New System.Drawing.Point(14, 120)
        Me.LblModalidad.Name = "LblModalidad"
        Me.LblModalidad.Size = New System.Drawing.Size(107, 15)
        Me.LblModalidad.TabIndex = 92
        Me.LblModalidad.Text = "Tipo de modalidad"
        '
        'CboCodigoModalidad
        '
        Me.CboCodigoModalidad.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoModalidad.Caption = ""
        Me.CboCodigoModalidad.CaptionHeight = 17
        Me.CboCodigoModalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoModalidad.ColumnCaptionHeight = 17
        Me.CboCodigoModalidad.ColumnFooterHeight = 17
        Me.CboCodigoModalidad.ContentHeight = 20
        Me.CboCodigoModalidad.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoModalidad.DisplayMember = "Modalidad"
        Me.CboCodigoModalidad.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoModalidad.EditorFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoModalidad.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoModalidad.EditorHeight = 20
        Me.CboCodigoModalidad.Images.Add(CType(resources.GetObject("CboCodigoModalidad.Images"), System.Drawing.Image))
        Me.CboCodigoModalidad.ItemHeight = 19
        Me.CboCodigoModalidad.Location = New System.Drawing.Point(14, 138)
        Me.CboCodigoModalidad.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoModalidad.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoModalidad.MaxLength = 32767
        Me.CboCodigoModalidad.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoModalidad.Name = "CboCodigoModalidad"
        Me.CboCodigoModalidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoModalidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoModalidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoModalidad.Size = New System.Drawing.Size(370, 26)
        Me.CboCodigoModalidad.TabIndex = 174
        Me.CboCodigoModalidad.PropBag = resources.GetString("CboCodigoModalidad.PropBag")
        '
        'CmdBuscarModalidad
        '
        Me.CmdBuscarModalidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.CmdBuscarModalidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdBuscarModalidad.FlatAppearance.BorderSize = 0
        Me.CmdBuscarModalidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdBuscarModalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdBuscarModalidad.Image = CType(resources.GetObject("CmdBuscarModalidad.Image"), System.Drawing.Image)
        Me.CmdBuscarModalidad.Location = New System.Drawing.Point(394, 136)
        Me.CmdBuscarModalidad.Name = "CmdBuscarModalidad"
        Me.CmdBuscarModalidad.Size = New System.Drawing.Size(36, 29)
        Me.CmdBuscarModalidad.TabIndex = 175
        Me.CmdBuscarModalidad.UseVisualStyleBackColor = False
        '
        'GrpIntereses
        '
        Me.GrpIntereses.BackColor = System.Drawing.Color.White
        Me.GrpIntereses.Controls.Add(Me.ChkInteresUnico)
        Me.GrpIntereses.Controls.Add(Me.TxtInteresUnico)
        Me.GrpIntereses.Controls.Add(Me.LblInteresAnual)
        Me.GrpIntereses.Controls.Add(Me.TxtInteresAnual)
        Me.GrpIntereses.Controls.Add(Me.LblInteresMensual)
        Me.GrpIntereses.Controls.Add(Me.TxtInteresMensual)
        Me.GrpIntereses.Controls.Add(Me.LblInteresDiario)
        Me.GrpIntereses.Controls.Add(Me.TxtInteresDiario)
        Me.GrpIntereses.Controls.Add(Me.GrpInteresesDiario)
        Me.GrpIntereses.Controls.Add(Me.LblCantidadPrestamos)
        Me.GrpIntereses.Controls.Add(Me.TxtCantidadPrestamos)
        Me.GrpIntereses.Controls.Add(Me.LblMaximoCuotas)
        Me.GrpIntereses.Controls.Add(Me.TxtMaximoCuotas)
        Me.GrpIntereses.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpIntereses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GrpIntereses.Location = New System.Drawing.Point(16, 240)
        Me.GrpIntereses.Name = "GrpIntereses"
        Me.GrpIntereses.Size = New System.Drawing.Size(448, 214)
        Me.GrpIntereses.TabIndex = 2
        Me.GrpIntereses.TabStop = False
        Me.GrpIntereses.Text = "Intereses y límites"
        '
        'ChkInteresUnico
        '
        Me.ChkInteresUnico.AutoSize = True
        Me.ChkInteresUnico.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkInteresUnico.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkInteresUnico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.ChkInteresUnico.Location = New System.Drawing.Point(16, 33)
        Me.ChkInteresUnico.Name = "ChkInteresUnico"
        Me.ChkInteresUnico.Size = New System.Drawing.Size(94, 19)
        Me.ChkInteresUnico.TabIndex = 103
        Me.ChkInteresUnico.Text = "Interés único"
        Me.ChkInteresUnico.UseVisualStyleBackColor = True
        '
        'TxtInteresUnico
        '
        Me.TxtInteresUnico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteresUnico.Enabled = False
        Me.TxtInteresUnico.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteresUnico.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtInteresUnico.Location = New System.Drawing.Point(140, 30)
        Me.TxtInteresUnico.Name = "TxtInteresUnico"
        Me.TxtInteresUnico.Size = New System.Drawing.Size(110, 25)
        Me.TxtInteresUnico.TabIndex = 104
        Me.TxtInteresUnico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblInteresAnual
        '
        Me.LblInteresAnual.AutoSize = True
        Me.LblInteresAnual.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInteresAnual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblInteresAnual.Location = New System.Drawing.Point(16, 72)
        Me.LblInteresAnual.Name = "LblInteresAnual"
        Me.LblInteresAnual.Size = New System.Drawing.Size(74, 15)
        Me.LblInteresAnual.TabIndex = 93
        Me.LblInteresAnual.Text = "Interés anual"
        '
        'TxtInteresAnual
        '
        Me.TxtInteresAnual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteresAnual.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteresAnual.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtInteresAnual.Location = New System.Drawing.Point(140, 69)
        Me.TxtInteresAnual.Name = "TxtInteresAnual"
        Me.TxtInteresAnual.Size = New System.Drawing.Size(110, 25)
        Me.TxtInteresAnual.TabIndex = 105
        Me.TxtInteresAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblInteresMensual
        '
        Me.LblInteresMensual.AutoSize = True
        Me.LblInteresMensual.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInteresMensual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblInteresMensual.Location = New System.Drawing.Point(16, 104)
        Me.LblInteresMensual.Name = "LblInteresMensual"
        Me.LblInteresMensual.Size = New System.Drawing.Size(90, 15)
        Me.LblInteresMensual.TabIndex = 95
        Me.LblInteresMensual.Text = "Interés mensual"
        '
        'TxtInteresMensual
        '
        Me.TxtInteresMensual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteresMensual.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteresMensual.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtInteresMensual.Location = New System.Drawing.Point(140, 101)
        Me.TxtInteresMensual.Name = "TxtInteresMensual"
        Me.TxtInteresMensual.Size = New System.Drawing.Size(110, 25)
        Me.TxtInteresMensual.TabIndex = 106
        Me.TxtInteresMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblInteresDiario
        '
        Me.LblInteresDiario.AutoSize = True
        Me.LblInteresDiario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInteresDiario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblInteresDiario.Location = New System.Drawing.Point(16, 136)
        Me.LblInteresDiario.Name = "LblInteresDiario"
        Me.LblInteresDiario.Size = New System.Drawing.Size(75, 15)
        Me.LblInteresDiario.TabIndex = 97
        Me.LblInteresDiario.Text = "Interés diario"
        '
        'TxtInteresDiario
        '
        Me.TxtInteresDiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteresDiario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteresDiario.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtInteresDiario.Location = New System.Drawing.Point(140, 133)
        Me.TxtInteresDiario.Name = "TxtInteresDiario"
        Me.TxtInteresDiario.Size = New System.Drawing.Size(110, 25)
        Me.TxtInteresDiario.TabIndex = 107
        Me.TxtInteresDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GrpInteresesDiario
        '
        Me.GrpInteresesDiario.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.GrpInteresesDiario.Controls.Add(Me.LblDeslizamiento)
        Me.GrpInteresesDiario.Controls.Add(Me.TxtInteresDeslizamiento)
        Me.GrpInteresesDiario.Controls.Add(Me.LblMora)
        Me.GrpInteresesDiario.Controls.Add(Me.TxtInteresMora)
        Me.GrpInteresesDiario.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpInteresesDiario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GrpInteresesDiario.Location = New System.Drawing.Point(272, 26)
        Me.GrpInteresesDiario.Name = "GrpInteresesDiario"
        Me.GrpInteresesDiario.Size = New System.Drawing.Size(160, 132)
        Me.GrpInteresesDiario.TabIndex = 108
        Me.GrpInteresesDiario.TabStop = False
        Me.GrpInteresesDiario.Text = "Intereses diarios"
        '
        'LblDeslizamiento
        '
        Me.LblDeslizamiento.AutoSize = True
        Me.LblDeslizamiento.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDeslizamiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblDeslizamiento.Location = New System.Drawing.Point(12, 24)
        Me.LblDeslizamiento.Name = "LblDeslizamiento"
        Me.LblDeslizamiento.Size = New System.Drawing.Size(94, 15)
        Me.LblDeslizamiento.TabIndex = 95
        Me.LblDeslizamiento.Text = "% Deslizamiento"
        '
        'TxtInteresDeslizamiento
        '
        Me.TxtInteresDeslizamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteresDeslizamiento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteresDeslizamiento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtInteresDeslizamiento.Location = New System.Drawing.Point(12, 42)
        Me.TxtInteresDeslizamiento.Name = "TxtInteresDeslizamiento"
        Me.TxtInteresDeslizamiento.Size = New System.Drawing.Size(136, 25)
        Me.TxtInteresDeslizamiento.TabIndex = 109
        Me.TxtInteresDeslizamiento.Text = "1.64383561643"
        Me.TxtInteresDeslizamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMora
        '
        Me.LblMora.AutoSize = True
        Me.LblMora.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblMora.Location = New System.Drawing.Point(12, 76)
        Me.LblMora.Name = "LblMora"
        Me.LblMora.Size = New System.Drawing.Size(64, 15)
        Me.LblMora.TabIndex = 97
        Me.LblMora.Text = "% de mora"
        '
        'TxtInteresMora
        '
        Me.TxtInteresMora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteresMora.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteresMora.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtInteresMora.Location = New System.Drawing.Point(12, 94)
        Me.TxtInteresMora.Name = "TxtInteresMora"
        Me.TxtInteresMora.Size = New System.Drawing.Size(136, 25)
        Me.TxtInteresMora.TabIndex = 110
        Me.TxtInteresMora.Text = "1.64383561643"
        Me.TxtInteresMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblCantidadPrestamos
        '
        Me.LblCantidadPrestamos.AutoSize = True
        Me.LblCantidadPrestamos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadPrestamos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblCantidadPrestamos.Location = New System.Drawing.Point(16, 178)
        Me.LblCantidadPrestamos.Name = "LblCantidadPrestamos"
        Me.LblCantidadPrestamos.Size = New System.Drawing.Size(129, 15)
        Me.LblCantidadPrestamos.TabIndex = 99
        Me.LblCantidadPrestamos.Text = "Cantidad de préstamos"
        '
        'TxtCantidadPrestamos
        '
        Me.TxtCantidadPrestamos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCantidadPrestamos.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadPrestamos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtCantidadPrestamos.Location = New System.Drawing.Point(160, 175)
        Me.TxtCantidadPrestamos.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.TxtCantidadPrestamos.Name = "TxtCantidadPrestamos"
        Me.TxtCantidadPrestamos.Size = New System.Drawing.Size(90, 25)
        Me.TxtCantidadPrestamos.TabIndex = 111
        Me.TxtCantidadPrestamos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMaximoCuotas
        '
        Me.LblMaximoCuotas.AutoSize = True
        Me.LblMaximoCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMaximoCuotas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblMaximoCuotas.Location = New System.Drawing.Point(272, 178)
        Me.LblMaximoCuotas.Name = "LblMaximoCuotas"
        Me.LblMaximoCuotas.Size = New System.Drawing.Size(104, 15)
        Me.LblMaximoCuotas.TabIndex = 101
        Me.LblMaximoCuotas.Text = "Máximo de cuotas"
        '
        'TxtMaximoCuotas
        '
        Me.TxtMaximoCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMaximoCuotas.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaximoCuotas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtMaximoCuotas.Location = New System.Drawing.Point(376, 175)
        Me.TxtMaximoCuotas.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.TxtMaximoCuotas.Name = "TxtMaximoCuotas"
        Me.TxtMaximoCuotas.Size = New System.Drawing.Size(56, 25)
        Me.TxtMaximoCuotas.TabIndex = 112
        Me.TxtMaximoCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PnlAcciones
        '
        Me.PnlAcciones.BackColor = System.Drawing.Color.White
        Me.PnlAcciones.Controls.Add(Me.CmdGuardar)
        Me.PnlAcciones.Controls.Add(Me.CmdEliminar)
        Me.PnlAcciones.Controls.Add(Me.CmdCerrar)
        Me.PnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlAcciones.Location = New System.Drawing.Point(0, 462)
        Me.PnlAcciones.Name = "PnlAcciones"
        Me.PnlAcciones.Size = New System.Drawing.Size(472, 70)
        Me.PnlAcciones.TabIndex = 3
        '
        'CmdGuardar
        '
        Me.CmdGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.FlatAppearance.BorderSize = 0
        Me.CmdGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGuardar.ForeColor = System.Drawing.Color.White
        Me.CmdGuardar.Image = CType(resources.GetObject("CmdGuardar.Image"), System.Drawing.Image)
        Me.CmdGuardar.Location = New System.Drawing.Point(118, 16)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(110, 38)
        Me.CmdGuardar.TabIndex = 166
        Me.CmdGuardar.Text = "  Guardar"
        Me.CmdGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdGuardar.UseVisualStyleBackColor = False
        '
        'CmdEliminar
        '
        Me.CmdEliminar.BackColor = System.Drawing.Color.White
        Me.CmdEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CmdEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.CmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdEliminar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.CmdEliminar.Image = CType(resources.GetObject("CmdEliminar.Image"), System.Drawing.Image)
        Me.CmdEliminar.Location = New System.Drawing.Point(236, 16)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(110, 38)
        Me.CmdEliminar.TabIndex = 167
        Me.CmdEliminar.Text = "  Eliminar"
        Me.CmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdEliminar.UseVisualStyleBackColor = False
        '
        'CmdCerrar
        '
        Me.CmdCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CmdCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCerrar.FlatAppearance.BorderSize = 0
        Me.CmdCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.CmdCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCerrar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CmdCerrar.Image = CType(resources.GetObject("CmdCerrar.Image"), System.Drawing.Image)
        Me.CmdCerrar.Location = New System.Drawing.Point(354, 16)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(110, 38)
        Me.CmdCerrar.TabIndex = 168
        Me.CmdCerrar.Text = "  Cerrar"
        Me.CmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdCerrar.UseVisualStyleBackColor = False
        '
        'FrmTipoPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.CmdCerrar
        Me.ClientSize = New System.Drawing.Size(472, 532)
        Me.Controls.Add(Me.PnlAcciones)
        Me.Controls.Add(Me.GrpIntereses)
        Me.Controls.Add(Me.PnlGeneral)
        Me.Controls.Add(Me.PicIcono)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PicEncabezado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmTipoPrestamos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo de Préstamos"
        CType(Me.PicEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicIcono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlGeneral.ResumeLayout(False)
        Me.PnlGeneral.PerformLayout()
        CType(Me.CboCodigoLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoModalidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpIntereses.ResumeLayout(False)
        Me.GrpIntereses.PerformLayout()
        Me.GrpInteresesDiario.ResumeLayout(False)
        Me.GrpInteresesDiario.PerformLayout()
        CType(Me.TxtCantidadPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMaximoCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicEncabezado As System.Windows.Forms.PictureBox
    Friend WithEvents PicIcono As System.Windows.Forms.PictureBox
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PnlGeneral As System.Windows.Forms.Panel
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents CboCodigoLinea As C1.Win.C1List.C1Combo
    Friend WithEvents CmdBuscarTipo As System.Windows.Forms.Button
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblModalidad As System.Windows.Forms.Label
    Friend WithEvents CboCodigoModalidad As C1.Win.C1List.C1Combo
    Friend WithEvents CmdBuscarModalidad As System.Windows.Forms.Button
    Friend WithEvents GrpIntereses As System.Windows.Forms.GroupBox
    Friend WithEvents ChkInteresUnico As System.Windows.Forms.CheckBox
    Friend WithEvents TxtInteresUnico As System.Windows.Forms.TextBox
    Friend WithEvents LblInteresAnual As System.Windows.Forms.Label
    Friend WithEvents TxtInteresAnual As System.Windows.Forms.TextBox
    Friend WithEvents LblInteresMensual As System.Windows.Forms.Label
    Friend WithEvents TxtInteresMensual As System.Windows.Forms.TextBox
    Friend WithEvents LblInteresDiario As System.Windows.Forms.Label
    Friend WithEvents TxtInteresDiario As System.Windows.Forms.TextBox
    Friend WithEvents GrpInteresesDiario As System.Windows.Forms.GroupBox
    Friend WithEvents LblDeslizamiento As System.Windows.Forms.Label
    Friend WithEvents TxtInteresDeslizamiento As System.Windows.Forms.TextBox
    Friend WithEvents LblMora As System.Windows.Forms.Label
    Friend WithEvents TxtInteresMora As System.Windows.Forms.TextBox
    Friend WithEvents LblCantidadPrestamos As System.Windows.Forms.Label
    Friend WithEvents TxtCantidadPrestamos As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblMaximoCuotas As System.Windows.Forms.Label
    Friend WithEvents TxtMaximoCuotas As System.Windows.Forms.NumericUpDown
    Friend WithEvents PnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
End Class
