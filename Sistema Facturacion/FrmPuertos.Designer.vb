<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPuertos
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
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.PnlConfig = New System.Windows.Forms.Panel()
        Me.LblTituloConfig = New System.Windows.Forms.Label()
        Me.LblPuerto = New System.Windows.Forms.Label()
        Me.CboPuerto = New System.Windows.Forms.ComboBox()
        Me.BtnActualizar = New System.Windows.Forms.Button()
        Me.LblVelocidad = New System.Windows.Forms.Label()
        Me.CboVelocidad = New System.Windows.Forms.ComboBox()
        Me.LblBits = New System.Windows.Forms.Label()
        Me.CboBits = New System.Windows.Forms.ComboBox()
        Me.LblParidad = New System.Windows.Forms.Label()
        Me.CboParidad = New System.Windows.Forms.ComboBox()
        Me.LblParada = New System.Windows.Forms.Label()
        Me.CboParada = New System.Windows.Forms.ComboBox()
        Me.LblFlujo = New System.Windows.Forms.Label()
        Me.CboFlujo = New System.Windows.Forms.ComboBox()
        Me.ChkDtrRts = New System.Windows.Forms.CheckBox()
        Me.ChkReconectar = New System.Windows.Forms.CheckBox()
        Me.PnlLectura = New System.Windows.Forms.Panel()
        Me.LblTituloLectura = New System.Windows.Forms.Label()
        Me.LblEstadoPuerto = New System.Windows.Forms.Label()
        Me.LblPesoPrueba = New System.Windows.Forms.Label()
        Me.consola = New System.Windows.Forms.TextBox()
        Me.PnlAcciones = New System.Windows.Forms.Panel()
        Me.BtnConectar = New System.Windows.Forms.Button()
        Me.BtnDesconectar = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.PnlHeader.SuspendLayout()
        Me.PnlConfig.SuspendLayout()
        Me.PnlLectura.SuspendLayout()
        Me.PnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.LblTitulo)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(760, 58)
        Me.PnlHeader.TabIndex = 0
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(14, 4)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(258, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Conexión de la báscula"
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(18, 36)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(300, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Seleccione el puerto y pruebe la lectura antes de pesar"
        '
        'PnlConfig
        '
        Me.PnlConfig.BackColor = System.Drawing.Color.White
        Me.PnlConfig.Controls.Add(Me.ChkReconectar)
        Me.PnlConfig.Controls.Add(Me.ChkDtrRts)
        Me.PnlConfig.Controls.Add(Me.CboFlujo)
        Me.PnlConfig.Controls.Add(Me.LblFlujo)
        Me.PnlConfig.Controls.Add(Me.CboParada)
        Me.PnlConfig.Controls.Add(Me.LblParada)
        Me.PnlConfig.Controls.Add(Me.CboParidad)
        Me.PnlConfig.Controls.Add(Me.LblParidad)
        Me.PnlConfig.Controls.Add(Me.CboBits)
        Me.PnlConfig.Controls.Add(Me.LblBits)
        Me.PnlConfig.Controls.Add(Me.CboVelocidad)
        Me.PnlConfig.Controls.Add(Me.LblVelocidad)
        Me.PnlConfig.Controls.Add(Me.BtnActualizar)
        Me.PnlConfig.Controls.Add(Me.CboPuerto)
        Me.PnlConfig.Controls.Add(Me.LblPuerto)
        Me.PnlConfig.Controls.Add(Me.LblTituloConfig)
        Me.PnlConfig.Location = New System.Drawing.Point(16, 70)
        Me.PnlConfig.Name = "PnlConfig"
        Me.PnlConfig.Size = New System.Drawing.Size(300, 340)
        Me.PnlConfig.TabIndex = 1
        '
        'LblTituloConfig
        '
        Me.LblTituloConfig.AutoSize = True
        Me.LblTituloConfig.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloConfig.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloConfig.Location = New System.Drawing.Point(14, 12)
        Me.LblTituloConfig.Name = "LblTituloConfig"
        Me.LblTituloConfig.Size = New System.Drawing.Size(140, 17)
        Me.LblTituloConfig.TabIndex = 0
        Me.LblTituloConfig.Text = "Parámetros del puerto"
        '
        'LblPuerto
        '
        Me.LblPuerto.AutoSize = True
        Me.LblPuerto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblPuerto.Location = New System.Drawing.Point(14, 40)
        Me.LblPuerto.Name = "LblPuerto"
        Me.LblPuerto.Size = New System.Drawing.Size(60, 15)
        Me.LblPuerto.TabIndex = 1
        Me.LblPuerto.Text = "Puerto"
        '
        'CboPuerto
        '
        Me.CboPuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPuerto.Location = New System.Drawing.Point(14, 58)
        Me.CboPuerto.Name = "CboPuerto"
        Me.CboPuerto.Size = New System.Drawing.Size(180, 23)
        Me.CboPuerto.TabIndex = 2
        '
        'BtnActualizar
        '
        Me.BtnActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnActualizar.FlatAppearance.BorderSize = 0
        Me.BtnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnActualizar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActualizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnActualizar.Location = New System.Drawing.Point(202, 57)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(84, 25)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Buscar"
        Me.BtnActualizar.UseVisualStyleBackColor = False
        '
        'LblVelocidad
        '
        Me.LblVelocidad.AutoSize = True
        Me.LblVelocidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblVelocidad.Location = New System.Drawing.Point(14, 94)
        Me.LblVelocidad.Name = "LblVelocidad"
        Me.LblVelocidad.Size = New System.Drawing.Size(60, 15)
        Me.LblVelocidad.TabIndex = 4
        Me.LblVelocidad.Text = "Velocidad (bps)"
        '
        'CboVelocidad
        '
        Me.CboVelocidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboVelocidad.Location = New System.Drawing.Point(14, 112)
        Me.CboVelocidad.Name = "CboVelocidad"
        Me.CboVelocidad.Size = New System.Drawing.Size(130, 23)
        Me.CboVelocidad.TabIndex = 5
        '
        'LblBits
        '
        Me.LblBits.AutoSize = True
        Me.LblBits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblBits.Location = New System.Drawing.Point(156, 94)
        Me.LblBits.Name = "LblBits"
        Me.LblBits.Size = New System.Drawing.Size(60, 15)
        Me.LblBits.TabIndex = 6
        Me.LblBits.Text = "Bits de datos"
        '
        'CboBits
        '
        Me.CboBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBits.Location = New System.Drawing.Point(156, 112)
        Me.CboBits.Name = "CboBits"
        Me.CboBits.Size = New System.Drawing.Size(130, 23)
        Me.CboBits.TabIndex = 7
        '
        'LblParidad
        '
        Me.LblParidad.AutoSize = True
        Me.LblParidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblParidad.Location = New System.Drawing.Point(14, 148)
        Me.LblParidad.Name = "LblParidad"
        Me.LblParidad.Size = New System.Drawing.Size(60, 15)
        Me.LblParidad.TabIndex = 8
        Me.LblParidad.Text = "Paridad"
        '
        'CboParidad
        '
        Me.CboParidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboParidad.Location = New System.Drawing.Point(14, 166)
        Me.CboParidad.Name = "CboParidad"
        Me.CboParidad.Size = New System.Drawing.Size(130, 23)
        Me.CboParidad.TabIndex = 9
        '
        'LblParada
        '
        Me.LblParada.AutoSize = True
        Me.LblParada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblParada.Location = New System.Drawing.Point(156, 148)
        Me.LblParada.Name = "LblParada"
        Me.LblParada.Size = New System.Drawing.Size(60, 15)
        Me.LblParada.TabIndex = 10
        Me.LblParada.Text = "Bits de parada"
        '
        'CboParada
        '
        Me.CboParada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboParada.Location = New System.Drawing.Point(156, 166)
        Me.CboParada.Name = "CboParada"
        Me.CboParada.Size = New System.Drawing.Size(130, 23)
        Me.CboParada.TabIndex = 11
        '
        'LblFlujo
        '
        Me.LblFlujo.AutoSize = True
        Me.LblFlujo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.LblFlujo.Location = New System.Drawing.Point(14, 202)
        Me.LblFlujo.Name = "LblFlujo"
        Me.LblFlujo.Size = New System.Drawing.Size(60, 15)
        Me.LblFlujo.TabIndex = 12
        Me.LblFlujo.Text = "Control de flujo"
        '
        'CboFlujo
        '
        Me.CboFlujo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFlujo.Location = New System.Drawing.Point(14, 220)
        Me.CboFlujo.Name = "CboFlujo"
        Me.CboFlujo.Size = New System.Drawing.Size(272, 23)
        Me.CboFlujo.TabIndex = 13
        '
        'ChkDtrRts
        '
        Me.ChkDtrRts.AutoSize = True
        Me.ChkDtrRts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ChkDtrRts.Location = New System.Drawing.Point(14, 262)
        Me.ChkDtrRts.Name = "ChkDtrRts"
        Me.ChkDtrRts.Size = New System.Drawing.Size(200, 19)
        Me.ChkDtrRts.TabIndex = 14
        Me.ChkDtrRts.Text = "Activar señales DTR / RTS"
        Me.ChkDtrRts.UseVisualStyleBackColor = True
        '
        'ChkReconectar
        '
        Me.ChkReconectar.AutoSize = True
        Me.ChkReconectar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ChkReconectar.Location = New System.Drawing.Point(14, 290)
        Me.ChkReconectar.Name = "ChkReconectar"
        Me.ChkReconectar.Size = New System.Drawing.Size(200, 19)
        Me.ChkReconectar.TabIndex = 15
        Me.ChkReconectar.Text = "Reconectar solo si se pierde el cable"
        Me.ChkReconectar.UseVisualStyleBackColor = True
        '
        'PnlLectura
        '
        Me.PnlLectura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlLectura.BackColor = System.Drawing.Color.White
        Me.PnlLectura.Controls.Add(Me.consola)
        Me.PnlLectura.Controls.Add(Me.LblPesoPrueba)
        Me.PnlLectura.Controls.Add(Me.LblEstadoPuerto)
        Me.PnlLectura.Controls.Add(Me.LblTituloLectura)
        Me.PnlLectura.Location = New System.Drawing.Point(328, 70)
        Me.PnlLectura.Name = "PnlLectura"
        Me.PnlLectura.Size = New System.Drawing.Size(416, 340)
        Me.PnlLectura.TabIndex = 2
        '
        'LblTituloLectura
        '
        Me.LblTituloLectura.AutoSize = True
        Me.LblTituloLectura.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloLectura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblTituloLectura.Location = New System.Drawing.Point(14, 12)
        Me.LblTituloLectura.Name = "LblTituloLectura"
        Me.LblTituloLectura.Size = New System.Drawing.Size(140, 17)
        Me.LblTituloLectura.TabIndex = 0
        Me.LblTituloLectura.Text = "Lectura en vivo"
        '
        'LblEstadoPuerto
        '
        Me.LblEstadoPuerto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEstadoPuerto.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.LblEstadoPuerto.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstadoPuerto.ForeColor = System.Drawing.Color.White
        Me.LblEstadoPuerto.Location = New System.Drawing.Point(14, 38)
        Me.LblEstadoPuerto.Name = "LblEstadoPuerto"
        Me.LblEstadoPuerto.Size = New System.Drawing.Size(388, 32)
        Me.LblEstadoPuerto.TabIndex = 1
        Me.LblEstadoPuerto.Text = "DESCONECTADO"
        Me.LblEstadoPuerto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPesoPrueba
        '
        Me.LblPesoPrueba.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblPesoPrueba.Font = New System.Drawing.Font("Segoe UI Semibold", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoPrueba.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.LblPesoPrueba.Location = New System.Drawing.Point(14, 76)
        Me.LblPesoPrueba.Name = "LblPesoPrueba"
        Me.LblPesoPrueba.Size = New System.Drawing.Size(388, 70)
        Me.LblPesoPrueba.TabIndex = 2
        Me.LblPesoPrueba.Text = "0.00"
        Me.LblPesoPrueba.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'consola
        '
        Me.consola.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.consola.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(36, Byte), Integer))
        Me.consola.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.consola.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consola.ForeColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.consola.Location = New System.Drawing.Point(14, 152)
        Me.consola.Multiline = True
        Me.consola.Name = "consola"
        Me.consola.ReadOnly = True
        Me.consola.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.consola.Size = New System.Drawing.Size(388, 176)
        Me.consola.TabIndex = 3
        '
        'PnlAcciones
        '
        Me.PnlAcciones.BackColor = System.Drawing.Color.White
        Me.PnlAcciones.Controls.Add(Me.Button9)
        Me.PnlAcciones.Controls.Add(Me.BtnDesconectar)
        Me.PnlAcciones.Controls.Add(Me.BtnConectar)
        Me.PnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlAcciones.Location = New System.Drawing.Point(0, 424)
        Me.PnlAcciones.Name = "PnlAcciones"
        Me.PnlAcciones.Size = New System.Drawing.Size(760, 56)
        Me.PnlAcciones.TabIndex = 3
        '
        'BtnConectar
        '
        Me.BtnConectar.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.BtnConectar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConectar.FlatAppearance.BorderSize = 0
        Me.BtnConectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.BtnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConectar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConectar.ForeColor = System.Drawing.Color.White
        Me.BtnConectar.Location = New System.Drawing.Point(16, 10)
        Me.BtnConectar.Name = "BtnConectar"
        Me.BtnConectar.Size = New System.Drawing.Size(96, 36)
        Me.BtnConectar.TabIndex = 0
        Me.BtnConectar.Text = "Conectar"
        Me.BtnConectar.UseVisualStyleBackColor = False
        '
        'BtnDesconectar
        '
        Me.BtnDesconectar.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BtnDesconectar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDesconectar.FlatAppearance.BorderSize = 0
        Me.BtnDesconectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnDesconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDesconectar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDesconectar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.BtnDesconectar.Location = New System.Drawing.Point(124, 10)
        Me.BtnDesconectar.Name = "BtnDesconectar"
        Me.BtnDesconectar.Size = New System.Drawing.Size(96, 36)
        Me.BtnDesconectar.TabIndex = 1
        Me.BtnDesconectar.Text = "Desconectar"
        Me.BtnDesconectar.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Button9.Location = New System.Drawing.Point(648, 10)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(96, 36)
        Me.Button9.TabIndex = 2
        Me.Button9.Text = "Salir"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'FrmPuertos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.CancelButton = Me.Button9
        Me.ClientSize = New System.Drawing.Size(760, 480)
        Me.Controls.Add(Me.PnlLectura)
        Me.Controls.Add(Me.PnlConfig)
        Me.Controls.Add(Me.PnlAcciones)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(776, 519)
        Me.Name = "FrmPuertos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Zeus Facturación - Puertos de la báscula"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlConfig.ResumeLayout(False)
        Me.PnlConfig.PerformLayout()
        Me.PnlLectura.ResumeLayout(False)
        Me.PnlLectura.PerformLayout()
        Me.PnlAcciones.ResumeLayout(False)
        Me.PnlAcciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents PnlConfig As System.Windows.Forms.Panel
    Friend WithEvents LblTituloConfig As System.Windows.Forms.Label
    Friend WithEvents LblPuerto As System.Windows.Forms.Label
    Friend WithEvents CboPuerto As System.Windows.Forms.ComboBox
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents LblVelocidad As System.Windows.Forms.Label
    Friend WithEvents CboVelocidad As System.Windows.Forms.ComboBox
    Friend WithEvents LblBits As System.Windows.Forms.Label
    Friend WithEvents CboBits As System.Windows.Forms.ComboBox
    Friend WithEvents LblParidad As System.Windows.Forms.Label
    Friend WithEvents CboParidad As System.Windows.Forms.ComboBox
    Friend WithEvents LblParada As System.Windows.Forms.Label
    Friend WithEvents CboParada As System.Windows.Forms.ComboBox
    Friend WithEvents LblFlujo As System.Windows.Forms.Label
    Friend WithEvents CboFlujo As System.Windows.Forms.ComboBox
    Friend WithEvents ChkDtrRts As System.Windows.Forms.CheckBox
    Friend WithEvents ChkReconectar As System.Windows.Forms.CheckBox
    Friend WithEvents PnlLectura As System.Windows.Forms.Panel
    Friend WithEvents LblTituloLectura As System.Windows.Forms.Label
    Friend WithEvents LblEstadoPuerto As System.Windows.Forms.Label
    Friend WithEvents LblPesoPrueba As System.Windows.Forms.Label
    Friend WithEvents consola As System.Windows.Forms.TextBox
    Friend WithEvents PnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents BtnConectar As System.Windows.Forms.Button
    Friend WithEvents BtnDesconectar As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
End Class
