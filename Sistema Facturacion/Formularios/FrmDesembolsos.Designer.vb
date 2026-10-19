<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDesembolsos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDesembolsos))
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblSubtitulo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.Panel()
        Me.LblSeccionPrestamo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumPrestamo = New System.Windows.Forms.TextBox()
        Me.CmdButtonSucursal = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTipoPrestamo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtFechaPrestamo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodSocio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNombreSocio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtFechaUltMov = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TdbgrDebitos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtSaldo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtDesembolso = New System.Windows.Forms.TextBox()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.CmdDesemolsar = New System.Windows.Forms.Button()
        Me.PnlHeader.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.TdbgrDebitos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.TDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.PnlHeader.Controls.Add(Me.Label10)
        Me.PnlHeader.Controls.Add(Me.LblSubtitulo)
        Me.PnlHeader.Controls.Add(Me.Label8)
        Me.PnlHeader.Controls.Add(Me.DtpFecha)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(780, 72)
        Me.PnlHeader.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(19, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(268, 30)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Desembolso de préstamos"
        '
        'LblSubtitulo
        '
        Me.LblSubtitulo.AutoSize = True
        Me.LblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblSubtitulo.Location = New System.Drawing.Point(22, 44)
        Me.LblSubtitulo.Name = "LblSubtitulo"
        Me.LblSubtitulo.Size = New System.Drawing.Size(292, 15)
        Me.LblSubtitulo.TabIndex = 1
        Me.LblSubtitulo.Text = "Registro de desembolsos y movimientos del préstamo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(604, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Fecha de entrega"
        '
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(604, 34)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(156, 23)
        Me.DtpFecha.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.LblSeccionPrestamo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtNumPrestamo)
        Me.GroupBox1.Controls.Add(Me.CmdButtonSucursal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtTipoPrestamo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtFechaPrestamo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtCodSocio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtNombreSocio)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtFechaUltMov)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(748, 152)
        Me.GroupBox1.TabIndex = 0
        '
        'LblSeccionPrestamo
        '
        Me.LblSeccionPrestamo.AutoSize = True
        Me.LblSeccionPrestamo.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeccionPrestamo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.LblSeccionPrestamo.Location = New System.Drawing.Point(14, 12)
        Me.LblSeccionPrestamo.Name = "LblSeccionPrestamo"
        Me.LblSeccionPrestamo.Size = New System.Drawing.Size(193, 19)
        Me.LblSeccionPrestamo.TabIndex = 20
        Me.LblSeccionPrestamo.Text = "Datos generales del préstamo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(16, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Número de préstamo"
        '
        'TxtNumPrestamo
        '
        Me.TxtNumPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumPrestamo.Location = New System.Drawing.Point(16, 60)
        Me.TxtNumPrestamo.Name = "TxtNumPrestamo"
        Me.TxtNumPrestamo.Size = New System.Drawing.Size(140, 23)
        Me.TxtNumPrestamo.TabIndex = 0
        '
        'CmdButtonSucursal
        '
        Me.CmdButtonSucursal.BackColor = System.Drawing.Color.White
        Me.CmdButtonSucursal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdButtonSucursal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.CmdButtonSucursal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.CmdButtonSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdButtonSucursal.Font = New System.Drawing.Font("Segoe MDL2 Assets", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdButtonSucursal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.CmdButtonSucursal.Location = New System.Drawing.Point(160, 59)
        Me.CmdButtonSucursal.Name = "CmdButtonSucursal"
        Me.CmdButtonSucursal.Size = New System.Drawing.Size(34, 25)
        Me.CmdButtonSucursal.TabIndex = 1
        Me.CmdButtonSucursal.Text = ""
        Me.CmdButtonSucursal.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(210, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 15)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Tipo de préstamo"
        '
        'TxtTipoPrestamo
        '
        Me.TxtTipoPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTipoPrestamo.Location = New System.Drawing.Point(210, 60)
        Me.TxtTipoPrestamo.Name = "TxtTipoPrestamo"
        Me.TxtTipoPrestamo.Size = New System.Drawing.Size(300, 23)
        Me.TxtTipoPrestamo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(526, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Fecha de entrega"
        '
        'TxtFechaPrestamo
        '
        Me.TxtFechaPrestamo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechaPrestamo.Location = New System.Drawing.Point(526, 60)
        Me.TxtFechaPrestamo.Name = "TxtFechaPrestamo"
        Me.TxtFechaPrestamo.Size = New System.Drawing.Size(206, 23)
        Me.TxtFechaPrestamo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Código de socio"
        '
        'TxtCodSocio
        '
        Me.TxtCodSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCodSocio.Location = New System.Drawing.Point(16, 112)
        Me.TxtCodSocio.Name = "TxtCodSocio"
        Me.TxtCodSocio.Size = New System.Drawing.Size(178, 23)
        Me.TxtCodSocio.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(210, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 15)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Nombre del socio"
        '
        'TxtNombreSocio
        '
        Me.TxtNombreSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNombreSocio.Location = New System.Drawing.Point(210, 112)
        Me.TxtNombreSocio.Name = "TxtNombreSocio"
        Me.TxtNombreSocio.Size = New System.Drawing.Size(300, 23)
        Me.TxtNombreSocio.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(526, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 15)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Fecha último movimiento"
        '
        'TxtFechaUltMov
        '
        Me.TxtFechaUltMov.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechaUltMov.Location = New System.Drawing.Point(526, 112)
        Me.TxtFechaUltMov.Name = "TxtFechaUltMov"
        Me.TxtFechaUltMov.Size = New System.Drawing.Size(206, 23)
        Me.TxtFechaUltMov.TabIndex = 6
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 252)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(14, 5)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(748, 250)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.TdbgrDebitos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(8)
        Me.TabPage1.Size = New System.Drawing.Size(740, 218)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Débitos"
        '
        'TdbgrDebitos
        '
        Me.TdbgrDebitos.AllowUpdate = False
        Me.TdbgrDebitos.Caption = "Débitos y desembolsos del préstamo"
        Me.TdbgrDebitos.CaptionHeight = 17
        Me.TdbgrDebitos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TdbgrDebitos.GroupByCaption = "Arrastre aquí un encabezado de columna para agrupar"
        Me.TdbgrDebitos.Images.Add(CType(resources.GetObject("TdbgrDebitos.Images"), System.Drawing.Image))
        Me.TdbgrDebitos.Location = New System.Drawing.Point(8, 8)
        Me.TdbgrDebitos.Name = "TdbgrDebitos"
        Me.TdbgrDebitos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TdbgrDebitos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TdbgrDebitos.PreviewInfo.ZoomFactor = 75.0R
        Me.TdbgrDebitos.RowHeight = 15
        Me.TdbgrDebitos.Size = New System.Drawing.Size(724, 202)
        Me.TdbgrDebitos.TabIndex = 0
        Me.TdbgrDebitos.Text = "C1TrueDBGrid1"
        Me.TdbgrDebitos.PropBag = resources.GetString("TdbgrDebitos.PropBag")
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.TDBGrid1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(8)
        Me.TabPage2.Size = New System.Drawing.Size(740, 218)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Créditos"
        '
        'TDBGrid1
        '
        Me.TDBGrid1.Caption = "Créditos y cuotas del préstamo"
        Me.TDBGrid1.CaptionHeight = 17
        Me.TDBGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TDBGrid1.GroupByCaption = "Arrastre aquí un encabezado de columna para agrupar"
        Me.TDBGrid1.Images.Add(CType(resources.GetObject("TDBGrid1.Images"), System.Drawing.Image))
        Me.TDBGrid1.Location = New System.Drawing.Point(8, 8)
        Me.TDBGrid1.Name = "TDBGrid1"
        Me.TDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.TDBGrid1.RowHeight = 15
        Me.TDBGrid1.Size = New System.Drawing.Size(724, 202)
        Me.TDBGrid1.TabIndex = 1
        Me.TDBGrid1.Text = "C1TrueDBGrid2"
        Me.TDBGrid1.PropBag = resources.GetString("TDBGrid1.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TxtSaldo)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TxtDesembolso)
        Me.GroupBox2.Controls.Add(Me.CmdCerrar)
        Me.GroupBox2.Controls.Add(Me.CmdDesemolsar)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 514)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(748, 82)
        Me.GroupBox2.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(16, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Saldo actual"
        '
        'TxtSaldo
        '
        Me.TxtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSaldo.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TxtSaldo.Location = New System.Drawing.Point(16, 32)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.Size = New System.Drawing.Size(180, 29)
        Me.TxtSaldo.TabIndex = 0
        Me.TxtSaldo.Text = "0.00"
        Me.TxtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(212, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 15)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Monto a desembolsar"
        '
        'TxtDesembolso
        '
        Me.TxtDesembolso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDesembolso.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesembolso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.TxtDesembolso.Location = New System.Drawing.Point(212, 32)
        Me.TxtDesembolso.Name = "TxtDesembolso"
        Me.TxtDesembolso.Size = New System.Drawing.Size(180, 29)
        Me.TxtDesembolso.TabIndex = 1
        Me.TxtDesembolso.Text = "0.00"
        Me.TxtDesembolso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmdCerrar
        '
        Me.CmdCerrar.BackColor = System.Drawing.Color.White
        Me.CmdCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.CmdCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.CmdCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.CmdCerrar.Location = New System.Drawing.Point(516, 27)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(100, 36)
        Me.CmdCerrar.TabIndex = 3
        Me.CmdCerrar.Text = "Salir"
        Me.CmdCerrar.UseVisualStyleBackColor = False
        '
        'CmdDesemolsar
        '
        Me.CmdDesemolsar.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.CmdDesemolsar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdDesemolsar.FlatAppearance.BorderSize = 0
        Me.CmdDesemolsar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(175, Byte), Integer))
        Me.CmdDesemolsar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.CmdDesemolsar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdDesemolsar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDesemolsar.ForeColor = System.Drawing.Color.White
        Me.CmdDesemolsar.Location = New System.Drawing.Point(624, 27)
        Me.CmdDesemolsar.Name = "CmdDesemolsar"
        Me.CmdDesemolsar.Size = New System.Drawing.Size(108, 36)
        Me.CmdDesemolsar.TabIndex = 2
        Me.CmdDesemolsar.Text = "Desembolsar"
        Me.CmdDesemolsar.UseVisualStyleBackColor = False
        '
        'FrmDesembolsos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.CancelButton = Me.CmdCerrar
        Me.ClientSize = New System.Drawing.Size(780, 612)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDesembolsos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desembolso de préstamos"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.TdbgrDebitos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.TDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents LblSubtitulo As System.Windows.Forms.Label
    Friend WithEvents LblSeccionPrestamo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodSocio As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtFechaPrestamo As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmdButtonSucursal As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTipoPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreSocio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtFechaUltMov As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TdbgrDebitos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDesembolso As System.Windows.Forms.TextBox
    Friend WithEvents CmdDesemolsar As System.Windows.Forms.Button
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
