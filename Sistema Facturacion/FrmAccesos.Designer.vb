<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccesos
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
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnlEstado = New System.Windows.Forms.Panel()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.PnlCuerpo = New System.Windows.Forms.Panel()
        Me.TlpCuerpo = New System.Windows.Forms.TableLayoutPanel()
        Me.CardPerfiles = New System.Windows.Forms.Panel()
        Me.PnlPerfiles = New System.Windows.Forms.Panel()
        Me.BtnEliminarPerfil = New System.Windows.Forms.Button()
        Me.BtnNuevoPerfil = New System.Windows.Forms.Button()
        Me.LstPerfiles = New System.Windows.Forms.ListBox()
        Me.LblPerfilesTitulo = New System.Windows.Forms.Label()
        Me.CardModulos = New System.Windows.Forms.Panel()
        Me.PnlModulos = New System.Windows.Forms.Panel()
        Me.LstModulos = New System.Windows.Forms.ListBox()
        Me.PnlBusqueda = New System.Windows.Forms.Panel()
        Me.TxtBuscarModulo = New System.Windows.Forms.TextBox()
        Me.LblModulosTitulo = New System.Windows.Forms.Label()
        Me.CardPermisos = New System.Windows.Forms.Panel()
        Me.PnlPermisos = New System.Windows.Forms.Panel()
        Me.FlpPermisos = New System.Windows.Forms.FlowLayoutPanel()
        Me.ChkAbrir = New System.Windows.Forms.CheckBox()
        Me.ChkGrabar = New System.Windows.Forms.CheckBox()
        Me.ChkEliminar = New System.Windows.Forms.CheckBox()
        Me.ChkAnular = New System.Windows.Forms.CheckBox()
        Me.ChkProcesar = New System.Windows.Forms.CheckBox()
        Me.ChkImprimir = New System.Windows.Forms.CheckBox()
        Me.ChkEditar = New System.Windows.Forms.CheckBox()
        Me.ChkCambiarBodega = New System.Windows.Forms.CheckBox()
        Me.ChkVerCosto = New System.Windows.Forms.CheckBox()
        Me.LblContexto = New System.Windows.Forms.Label()
        Me.LblPermisosTitulo = New System.Windows.Forms.Label()
        Me.PnlHeader.SuspendLayout()
        Me.PnlEstado.SuspendLayout()
        Me.PnlCuerpo.SuspendLayout()
        Me.TlpCuerpo.SuspendLayout()
        Me.CardPerfiles.SuspendLayout()
        Me.PnlPerfiles.SuspendLayout()
        Me.CardModulos.SuspendLayout()
        Me.PnlModulos.SuspendLayout()
        Me.PnlBusqueda.SuspendLayout()
        Me.CardPermisos.SuspendLayout()
        Me.PnlPermisos.SuspendLayout()
        Me.FlpPermisos.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.BtnSalir)
        Me.PnlHeader.Controls.Add(Me.BtnGuardar)
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.LblTitulo)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(940, 60)
        Me.PnlHeader.TabIndex = 0
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.BackColor = System.Drawing.Color.White
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BtnSalir.Location = New System.Drawing.Point(834, 12)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 36)
        Me.BtnSalir.TabIndex = 1
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.FlatAppearance.BorderSize = 0
        Me.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Location = New System.Drawing.Point(706, 12)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(120, 36)
        Me.BtnGuardar.TabIndex = 0
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(20, 36)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(341, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Defina qué puede hacer cada perfil en cada módulo del sistema"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(17, 6)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(179, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Perfiles y Accesos"
        '
        'PnlEstado
        '
        Me.PnlEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PnlEstado.Controls.Add(Me.LblEstado)
        Me.PnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlEstado.Location = New System.Drawing.Point(0, 470)
        Me.PnlEstado.Name = "PnlEstado"
        Me.PnlEstado.Padding = New System.Windows.Forms.Padding(22, 0, 22, 0)
        Me.PnlEstado.Size = New System.Drawing.Size(940, 30)
        Me.PnlEstado.TabIndex = 2
        '
        'LblEstado
        '
        Me.LblEstado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.LblEstado.Location = New System.Drawing.Point(22, 0)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(896, 30)
        Me.LblEstado.TabIndex = 0
        Me.LblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnlCuerpo
        '
        Me.PnlCuerpo.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PnlCuerpo.Controls.Add(Me.TlpCuerpo)
        Me.PnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlCuerpo.Location = New System.Drawing.Point(0, 60)
        Me.PnlCuerpo.Name = "PnlCuerpo"
        Me.PnlCuerpo.Padding = New System.Windows.Forms.Padding(16, 16, 16, 8)
        Me.PnlCuerpo.Size = New System.Drawing.Size(940, 410)
        Me.PnlCuerpo.TabIndex = 1
        '
        'TlpCuerpo
        '
        Me.TlpCuerpo.ColumnCount = 3
        Me.TlpCuerpo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.0!))
        Me.TlpCuerpo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TlpCuerpo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TlpCuerpo.Controls.Add(Me.CardPerfiles, 0, 0)
        Me.TlpCuerpo.Controls.Add(Me.CardModulos, 1, 0)
        Me.TlpCuerpo.Controls.Add(Me.CardPermisos, 2, 0)
        Me.TlpCuerpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TlpCuerpo.Location = New System.Drawing.Point(16, 16)
        Me.TlpCuerpo.Name = "TlpCuerpo"
        Me.TlpCuerpo.RowCount = 1
        Me.TlpCuerpo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TlpCuerpo.Size = New System.Drawing.Size(908, 386)
        Me.TlpCuerpo.TabIndex = 0
        '
        'CardPerfiles
        '
        Me.CardPerfiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CardPerfiles.Controls.Add(Me.PnlPerfiles)
        Me.CardPerfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CardPerfiles.Location = New System.Drawing.Point(0, 0)
        Me.CardPerfiles.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.CardPerfiles.Name = "CardPerfiles"
        Me.CardPerfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.CardPerfiles.Size = New System.Drawing.Size(246, 386)
        Me.CardPerfiles.TabIndex = 0
        '
        'PnlPerfiles
        '
        Me.PnlPerfiles.BackColor = System.Drawing.Color.White
        Me.PnlPerfiles.Controls.Add(Me.BtnEliminarPerfil)
        Me.PnlPerfiles.Controls.Add(Me.BtnNuevoPerfil)
        Me.PnlPerfiles.Controls.Add(Me.LstPerfiles)
        Me.PnlPerfiles.Controls.Add(Me.LblPerfilesTitulo)
        Me.PnlPerfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlPerfiles.Location = New System.Drawing.Point(1, 1)
        Me.PnlPerfiles.Name = "PnlPerfiles"
        Me.PnlPerfiles.Size = New System.Drawing.Size(244, 384)
        Me.PnlPerfiles.TabIndex = 0
        '
        'BtnEliminarPerfil
        '
        Me.BtnEliminarPerfil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminarPerfil.BackColor = System.Drawing.Color.White
        Me.BtnEliminarPerfil.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminarPerfil.Enabled = False
        Me.BtnEliminarPerfil.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.BtnEliminarPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnEliminarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEliminarPerfil.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminarPerfil.ForeColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.BtnEliminarPerfil.Location = New System.Drawing.Point(158, 5)
        Me.BtnEliminarPerfil.Name = "BtnEliminarPerfil"
        Me.BtnEliminarPerfil.Size = New System.Drawing.Size(74, 30)
        Me.BtnEliminarPerfil.TabIndex = 1
        Me.BtnEliminarPerfil.Text = "Eliminar"
        Me.BtnEliminarPerfil.UseVisualStyleBackColor = False
        '
        'BtnNuevoPerfil
        '
        Me.BtnNuevoPerfil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNuevoPerfil.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.BtnNuevoPerfil.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNuevoPerfil.FlatAppearance.BorderSize = 0
        Me.BtnNuevoPerfil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.BtnNuevoPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.BtnNuevoPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNuevoPerfil.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevoPerfil.ForeColor = System.Drawing.Color.White
        Me.BtnNuevoPerfil.Location = New System.Drawing.Point(78, 5)
        Me.BtnNuevoPerfil.Name = "BtnNuevoPerfil"
        Me.BtnNuevoPerfil.Size = New System.Drawing.Size(74, 30)
        Me.BtnNuevoPerfil.TabIndex = 0
        Me.BtnNuevoPerfil.Text = "Nuevo"
        Me.BtnNuevoPerfil.UseVisualStyleBackColor = False
        '
        'LstPerfiles
        '
        Me.LstPerfiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstPerfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstPerfiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LstPerfiles.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstPerfiles.FormattingEnabled = True
        Me.LstPerfiles.IntegralHeight = False
        Me.LstPerfiles.ItemHeight = 32
        Me.LstPerfiles.Location = New System.Drawing.Point(0, 40)
        Me.LstPerfiles.Name = "LstPerfiles"
        Me.LstPerfiles.Size = New System.Drawing.Size(244, 344)
        Me.LstPerfiles.TabIndex = 0
        '
        'LblPerfilesTitulo
        '
        Me.LblPerfilesTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblPerfilesTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPerfilesTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.LblPerfilesTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LblPerfilesTitulo.Name = "LblPerfilesTitulo"
        Me.LblPerfilesTitulo.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.LblPerfilesTitulo.Size = New System.Drawing.Size(244, 40)
        Me.LblPerfilesTitulo.TabIndex = 2
        Me.LblPerfilesTitulo.Text = "1. Perfil"
        Me.LblPerfilesTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CardModulos
        '
        Me.CardModulos.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CardModulos.Controls.Add(Me.PnlModulos)
        Me.CardModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CardModulos.Location = New System.Drawing.Point(254, 0)
        Me.CardModulos.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.CardModulos.Name = "CardModulos"
        Me.CardModulos.Padding = New System.Windows.Forms.Padding(1)
        Me.CardModulos.Size = New System.Drawing.Size(282, 386)
        Me.CardModulos.TabIndex = 1
        '
        'PnlModulos
        '
        Me.PnlModulos.BackColor = System.Drawing.Color.White
        Me.PnlModulos.Controls.Add(Me.LstModulos)
        Me.PnlModulos.Controls.Add(Me.PnlBusqueda)
        Me.PnlModulos.Controls.Add(Me.LblModulosTitulo)
        Me.PnlModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlModulos.Location = New System.Drawing.Point(1, 1)
        Me.PnlModulos.Name = "PnlModulos"
        Me.PnlModulos.Size = New System.Drawing.Size(280, 384)
        Me.PnlModulos.TabIndex = 0
        '
        'LstModulos
        '
        Me.LstModulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstModulos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LstModulos.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstModulos.FormattingEnabled = True
        Me.LstModulos.IntegralHeight = False
        Me.LstModulos.ItemHeight = 32
        Me.LstModulos.Location = New System.Drawing.Point(0, 84)
        Me.LstModulos.Name = "LstModulos"
        Me.LstModulos.Size = New System.Drawing.Size(280, 300)
        Me.LstModulos.TabIndex = 1
        '
        'PnlBusqueda
        '
        Me.PnlBusqueda.Controls.Add(Me.TxtBuscarModulo)
        Me.PnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlBusqueda.Location = New System.Drawing.Point(0, 40)
        Me.PnlBusqueda.Name = "PnlBusqueda"
        Me.PnlBusqueda.Padding = New System.Windows.Forms.Padding(12, 2, 12, 8)
        Me.PnlBusqueda.Size = New System.Drawing.Size(280, 44)
        Me.PnlBusqueda.TabIndex = 0
        '
        'TxtBuscarModulo
        '
        Me.TxtBuscarModulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtBuscarModulo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscarModulo.Location = New System.Drawing.Point(12, 2)
        Me.TxtBuscarModulo.Name = "TxtBuscarModulo"
        Me.TxtBuscarModulo.Size = New System.Drawing.Size(256, 25)
        Me.TxtBuscarModulo.TabIndex = 0
        '
        'LblModulosTitulo
        '
        Me.LblModulosTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblModulosTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModulosTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.LblModulosTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LblModulosTitulo.Name = "LblModulosTitulo"
        Me.LblModulosTitulo.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.LblModulosTitulo.Size = New System.Drawing.Size(280, 40)
        Me.LblModulosTitulo.TabIndex = 2
        Me.LblModulosTitulo.Text = "2. Módulo"
        Me.LblModulosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CardPermisos
        '
        Me.CardPermisos.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CardPermisos.Controls.Add(Me.PnlPermisos)
        Me.CardPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CardPermisos.Location = New System.Drawing.Point(544, 0)
        Me.CardPermisos.Margin = New System.Windows.Forms.Padding(0)
        Me.CardPermisos.Name = "CardPermisos"
        Me.CardPermisos.Padding = New System.Windows.Forms.Padding(1)
        Me.CardPermisos.Size = New System.Drawing.Size(364, 386)
        Me.CardPermisos.TabIndex = 2
        '
        'PnlPermisos
        '
        Me.PnlPermisos.BackColor = System.Drawing.Color.White
        Me.PnlPermisos.Controls.Add(Me.FlpPermisos)
        Me.PnlPermisos.Controls.Add(Me.LblContexto)
        Me.PnlPermisos.Controls.Add(Me.LblPermisosTitulo)
        Me.PnlPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlPermisos.Location = New System.Drawing.Point(1, 1)
        Me.PnlPermisos.Name = "PnlPermisos"
        Me.PnlPermisos.Size = New System.Drawing.Size(362, 384)
        Me.PnlPermisos.TabIndex = 0
        '
        'FlpPermisos
        '
        Me.FlpPermisos.Controls.Add(Me.ChkAbrir)
        Me.FlpPermisos.Controls.Add(Me.ChkGrabar)
        Me.FlpPermisos.Controls.Add(Me.ChkEliminar)
        Me.FlpPermisos.Controls.Add(Me.ChkAnular)
        Me.FlpPermisos.Controls.Add(Me.ChkProcesar)
        Me.FlpPermisos.Controls.Add(Me.ChkImprimir)
        Me.FlpPermisos.Controls.Add(Me.ChkEditar)
        Me.FlpPermisos.Controls.Add(Me.ChkCambiarBodega)
        Me.FlpPermisos.Controls.Add(Me.ChkVerCosto)
        Me.FlpPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlpPermisos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlpPermisos.Location = New System.Drawing.Point(0, 98)
        Me.FlpPermisos.Name = "FlpPermisos"
        Me.FlpPermisos.Padding = New System.Windows.Forms.Padding(14, 6, 14, 6)
        Me.FlpPermisos.Size = New System.Drawing.Size(362, 286)
        Me.FlpPermisos.TabIndex = 0
        Me.FlpPermisos.WrapContents = False
        '
        'ChkAbrir
        '
        Me.ChkAbrir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkAbrir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAbrir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkAbrir.Location = New System.Drawing.Point(17, 9)
        Me.ChkAbrir.Name = "ChkAbrir"
        Me.ChkAbrir.Size = New System.Drawing.Size(320, 26)
        Me.ChkAbrir.TabIndex = 0
        Me.ChkAbrir.Text = "Abrir"
        Me.ChkAbrir.UseVisualStyleBackColor = True
        '
        'ChkGrabar
        '
        Me.ChkGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkGrabar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkGrabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkGrabar.Location = New System.Drawing.Point(17, 41)
        Me.ChkGrabar.Name = "ChkGrabar"
        Me.ChkGrabar.Size = New System.Drawing.Size(320, 26)
        Me.ChkGrabar.TabIndex = 1
        Me.ChkGrabar.Text = "Grabar"
        Me.ChkGrabar.UseVisualStyleBackColor = True
        '
        'ChkEliminar
        '
        Me.ChkEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkEliminar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkEliminar.Location = New System.Drawing.Point(17, 73)
        Me.ChkEliminar.Name = "ChkEliminar"
        Me.ChkEliminar.Size = New System.Drawing.Size(320, 26)
        Me.ChkEliminar.TabIndex = 2
        Me.ChkEliminar.Text = "Eliminar"
        Me.ChkEliminar.UseVisualStyleBackColor = True
        '
        'ChkAnular
        '
        Me.ChkAnular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkAnular.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAnular.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkAnular.Location = New System.Drawing.Point(17, 105)
        Me.ChkAnular.Name = "ChkAnular"
        Me.ChkAnular.Size = New System.Drawing.Size(320, 26)
        Me.ChkAnular.TabIndex = 3
        Me.ChkAnular.Text = "Anular"
        Me.ChkAnular.UseVisualStyleBackColor = True
        '
        'ChkProcesar
        '
        Me.ChkProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkProcesar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkProcesar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkProcesar.Location = New System.Drawing.Point(17, 137)
        Me.ChkProcesar.Name = "ChkProcesar"
        Me.ChkProcesar.Size = New System.Drawing.Size(320, 26)
        Me.ChkProcesar.TabIndex = 4
        Me.ChkProcesar.Text = "Procesar"
        Me.ChkProcesar.UseVisualStyleBackColor = True
        '
        'ChkImprimir
        '
        Me.ChkImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkImprimir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkImprimir.Location = New System.Drawing.Point(17, 169)
        Me.ChkImprimir.Name = "ChkImprimir"
        Me.ChkImprimir.Size = New System.Drawing.Size(320, 26)
        Me.ChkImprimir.TabIndex = 5
        Me.ChkImprimir.Text = "Imprimir"
        Me.ChkImprimir.UseVisualStyleBackColor = True
        '
        'ChkEditar
        '
        Me.ChkEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkEditar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEditar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkEditar.Location = New System.Drawing.Point(17, 201)
        Me.ChkEditar.Name = "ChkEditar"
        Me.ChkEditar.Size = New System.Drawing.Size(320, 26)
        Me.ChkEditar.TabIndex = 6
        Me.ChkEditar.Text = "Editar"
        Me.ChkEditar.UseVisualStyleBackColor = True
        '
        'ChkCambiarBodega
        '
        Me.ChkCambiarBodega.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkCambiarBodega.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCambiarBodega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkCambiarBodega.Location = New System.Drawing.Point(17, 233)
        Me.ChkCambiarBodega.Name = "ChkCambiarBodega"
        Me.ChkCambiarBodega.Size = New System.Drawing.Size(320, 26)
        Me.ChkCambiarBodega.TabIndex = 7
        Me.ChkCambiarBodega.Text = "Cambiar bodega"
        Me.ChkCambiarBodega.UseVisualStyleBackColor = True
        '
        'ChkVerCosto
        '
        Me.ChkVerCosto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkVerCosto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkVerCosto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ChkVerCosto.Location = New System.Drawing.Point(17, 265)
        Me.ChkVerCosto.Name = "ChkVerCosto"
        Me.ChkVerCosto.Size = New System.Drawing.Size(320, 26)
        Me.ChkVerCosto.TabIndex = 8
        Me.ChkVerCosto.Text = "Ver costo"
        Me.ChkVerCosto.UseVisualStyleBackColor = True
        '
        'LblContexto
        '
        Me.LblContexto.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblContexto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.LblContexto.Location = New System.Drawing.Point(0, 40)
        Me.LblContexto.Name = "LblContexto"
        Me.LblContexto.Padding = New System.Windows.Forms.Padding(14, 0, 14, 0)
        Me.LblContexto.Size = New System.Drawing.Size(362, 58)
        Me.LblContexto.TabIndex = 2
        '
        'LblPermisosTitulo
        '
        Me.LblPermisosTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblPermisosTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPermisosTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.LblPermisosTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LblPermisosTitulo.Name = "LblPermisosTitulo"
        Me.LblPermisosTitulo.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.LblPermisosTitulo.Size = New System.Drawing.Size(362, 40)
        Me.LblPermisosTitulo.TabIndex = 3
        Me.LblPermisosTitulo.Text = "3. Permisos"
        Me.LblPermisosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmAccesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(940, 500)
        Me.Controls.Add(Me.PnlCuerpo)
        Me.Controls.Add(Me.PnlEstado)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(860, 440)
        Me.Name = "FrmAccesos"
        Me.Text = "Control de Perfiles y Permisos"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlEstado.ResumeLayout(False)
        Me.PnlCuerpo.ResumeLayout(False)
        Me.TlpCuerpo.ResumeLayout(False)
        Me.CardPerfiles.ResumeLayout(False)
        Me.PnlPerfiles.ResumeLayout(False)
        Me.CardModulos.ResumeLayout(False)
        Me.PnlModulos.ResumeLayout(False)
        Me.PnlBusqueda.ResumeLayout(False)
        Me.PnlBusqueda.PerformLayout()
        Me.CardPermisos.ResumeLayout(False)
        Me.PnlPermisos.ResumeLayout(False)
        Me.FlpPermisos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PnlEstado As System.Windows.Forms.Panel
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents PnlCuerpo As System.Windows.Forms.Panel
    Friend WithEvents TlpCuerpo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CardPerfiles As System.Windows.Forms.Panel
    Friend WithEvents PnlPerfiles As System.Windows.Forms.Panel
    Friend WithEvents LstPerfiles As System.Windows.Forms.ListBox
    Friend WithEvents BtnEliminarPerfil As System.Windows.Forms.Button
    Friend WithEvents BtnNuevoPerfil As System.Windows.Forms.Button
    Friend WithEvents LblPerfilesTitulo As System.Windows.Forms.Label
    Friend WithEvents CardModulos As System.Windows.Forms.Panel
    Friend WithEvents PnlModulos As System.Windows.Forms.Panel
    Friend WithEvents LstModulos As System.Windows.Forms.ListBox
    Friend WithEvents PnlBusqueda As System.Windows.Forms.Panel
    Friend WithEvents TxtBuscarModulo As System.Windows.Forms.TextBox
    Friend WithEvents LblModulosTitulo As System.Windows.Forms.Label
    Friend WithEvents CardPermisos As System.Windows.Forms.Panel
    Friend WithEvents PnlPermisos As System.Windows.Forms.Panel
    Friend WithEvents FlpPermisos As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ChkAbrir As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGrabar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEliminar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAnular As System.Windows.Forms.CheckBox
    Friend WithEvents ChkProcesar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEditar As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCambiarBodega As System.Windows.Forms.CheckBox
    Friend WithEvents ChkVerCosto As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents LblContexto As System.Windows.Forms.Label
    Friend WithEvents LblPermisosTitulo As System.Windows.Forms.Label
End Class
