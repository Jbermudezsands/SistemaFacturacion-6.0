<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRegistroDebito
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroDebito))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblMoneda = New System.Windows.Forms.Label()
        Me.CmbCodigo = New C1.Win.C1List.C1Combo()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblFactura = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtCodCliente = New System.Windows.Forms.TextBox()
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CmbSerie = New C1.Win.C1List.C1Combo()
        Me.ChkFactura = New System.Windows.Forms.CheckBox()
        Me.ChkSseries = New System.Windows.Forms.CheckBox()
        Me.PrintNota = New System.Drawing.Printing.PrintDocument()
        Me.ChkTipoCuenta = New System.Windows.Forms.CheckBox()
        Me.PnlDatos = New System.Windows.Forms.Panel()
        Me.LblDescripcion = New System.Windows.Forms.Label()
        Me.PnlAcciones = New System.Windows.Forms.Panel()
        Me.LblOpciones = New System.Windows.Forms.Label()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDatos.SuspendLayout()
        Me.PnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(66, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 25)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "NOTAS DE DÉBITO"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(16, 12)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 132
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.PictureBox4.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(640, 64)
        Me.PictureBox4.TabIndex = 131
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(14, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(330, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Fecha"
        '
        'LblNombre
        '
        Me.LblNombre.AutoEllipsis = True
        Me.LblNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.LblNombre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.LblNombre.Location = New System.Drawing.Point(14, 30)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.LblNombre.Size = New System.Drawing.Size(300, 26)
        Me.LblNombre.TabIndex = 136
        Me.LblNombre.Text = "JUAN BERMUDEZ HERNANDEZ"
        Me.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(402, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 15)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "NO."
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.LblNumero.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.LblNumero.Location = New System.Drawing.Point(68, 42)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(37, 15)
        Me.LblNumero.TabIndex = 138
        Me.LblNumero.Text = "10000"
        Me.LblNumero.Visible = False
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(330, 30)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(130, 25)
        Me.DTPFecha.TabIndex = 139
        '
        'LblMoneda
        '
        Me.LblMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblMoneda.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.LblMoneda.Location = New System.Drawing.Point(476, 30)
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Size = New System.Drawing.Size(114, 26)
        Me.LblMoneda.TabIndex = 140
        Me.LblMoneda.Text = "Córdobas"
        Me.LblMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbCodigo
        '
        Me.CmbCodigo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbCodigo.Caption = ""
        Me.CmbCodigo.CaptionHeight = 17
        Me.CmbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbCodigo.ColumnCaptionHeight = 17
        Me.CmbCodigo.ColumnFooterHeight = 17
        Me.CmbCodigo.ContentHeight = 20
        Me.CmbCodigo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbCodigo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbCodigo.EditorFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCodigo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbCodigo.EditorHeight = 20
        Me.CmbCodigo.Images.Add(CType(resources.GetObject("CmbCodigo.Images"), System.Drawing.Image))
        Me.CmbCodigo.ItemHeight = 19
        Me.CmbCodigo.Location = New System.Drawing.Point(14, 88)
        Me.CmbCodigo.MatchEntryTimeout = CType(2000, Long)
        Me.CmbCodigo.MaxDropDownItems = CType(5, Short)
        Me.CmbCodigo.MaxLength = 32767
        Me.CmbCodigo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbCodigo.Name = "CmbCodigo"
        Me.CmbCodigo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbCodigo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbCodigo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbCodigo.Size = New System.Drawing.Size(110, 26)
        Me.CmbCodigo.TabIndex = 141
        Me.CmbCodigo.PropBag = resources.GetString("CmbCodigo.PropBag")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(14, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 15)
        Me.Label16.TabIndex = 142
        Me.Label16.Text = "Código"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDescripcion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(134, 88)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(326, 25)
        Me.TxtDescripcion.TabIndex = 143
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(476, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "Monto"
        '
        'TxtMonto
        '
        Me.TxtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMonto.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.Location = New System.Drawing.Point(476, 88)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(114, 27)
        Me.TxtMonto.TabIndex = 145
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(14, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 15)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "Observaciones"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtObservaciones.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObservaciones.Location = New System.Drawing.Point(14, 148)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(446, 44)
        Me.TxtObservaciones.TabIndex = 147
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(476, 130)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 15)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "Factura No."
        '
        'LblFactura
        '
        Me.LblFactura.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.LblFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFactura.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.LblFactura.Location = New System.Drawing.Point(476, 148)
        Me.LblFactura.Name = "LblFactura"
        Me.LblFactura.Size = New System.Drawing.Size(114, 44)
        Me.LblFactura.TabIndex = 149
        Me.LblFactura.Text = "00023"
        Me.LblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.Location = New System.Drawing.Point(514, 16)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(110, 38)
        Me.Button8.TabIndex = 177
        Me.Button8.Text = "  Salir"
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(16, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 38)
        Me.Button1.TabIndex = 178
        Me.Button1.Text = "  Grabar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(252, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 38)
        Me.Button2.TabIndex = 179
        Me.Button2.Text = "  Anular"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TxtCodCliente
        '
        Me.TxtCodCliente.Location = New System.Drawing.Point(500, 300)
        Me.TxtCodCliente.Name = "TxtCodCliente"
        Me.TxtCodCliente.Size = New System.Drawing.Size(100, 25)
        Me.TxtCodCliente.TabIndex = 180
        Me.TxtCodCliente.Visible = False
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.TxtNumeroEnsamble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroEnsamble.ForeColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(436, 20)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(132, 23)
        Me.TxtNumeroEnsamble.TabIndex = 181
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        Me.TxtNumeroEnsamble.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(576, 17)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 30)
        Me.Button3.TabIndex = 182
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(134, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(110, 38)
        Me.Button4.TabIndex = 183
        Me.Button4.Text = "  Imprimir"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = False
        '
        'CmbSerie
        '
        Me.CmbSerie.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbSerie.Caption = ""
        Me.CmbSerie.CaptionHeight = 17
        Me.CmbSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbSerie.ColumnCaptionHeight = 17
        Me.CmbSerie.ColumnFooterHeight = 17
        Me.CmbSerie.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CmbSerie.ContentHeight = 20
        Me.CmbSerie.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbSerie.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbSerie.DropDownWidth = 100
        Me.CmbSerie.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbSerie.EditorFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSerie.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbSerie.EditorHeight = 20
        Me.CmbSerie.Images.Add(CType(resources.GetObject("CmbSerie.Images"), System.Drawing.Image))
        Me.CmbSerie.ItemHeight = 17
        Me.CmbSerie.Location = New System.Drawing.Point(436, 20)
        Me.CmbSerie.MatchEntryTimeout = CType(2000, Long)
        Me.CmbSerie.MaxDropDownItems = CType(5, Short)
        Me.CmbSerie.MaxLength = 32767
        Me.CmbSerie.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbSerie.Name = "CmbSerie"
        Me.CmbSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbSerie.Size = New System.Drawing.Size(50, 26)
        Me.CmbSerie.TabIndex = 213
        Me.CmbSerie.Visible = False
        Me.CmbSerie.PropBag = resources.GetString("CmbSerie.PropBag")
        '
        'ChkFactura
        '
        Me.ChkFactura.AutoSize = True
        Me.ChkFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.ChkFactura.Location = New System.Drawing.Point(94, 300)
        Me.ChkFactura.Name = "ChkFactura"
        Me.ChkFactura.Size = New System.Drawing.Size(99, 19)
        Me.ChkFactura.TabIndex = 214
        Me.ChkFactura.Text = "Quitar factura"
        Me.ChkFactura.UseVisualStyleBackColor = True
        '
        'ChkSseries
        '
        Me.ChkSseries.AutoSize = True
        Me.ChkSseries.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkSseries.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSseries.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.ChkSseries.Location = New System.Drawing.Point(214, 300)
        Me.ChkSseries.Name = "ChkSseries"
        Me.ChkSseries.Size = New System.Drawing.Size(142, 19)
        Me.ChkSseries.TabIndex = 215
        Me.ChkSseries.Text = "Consecutivo sin series"
        Me.ChkSseries.UseVisualStyleBackColor = True
        '
        'PrintNota
        '
        '
        'ChkTipoCuenta
        '
        Me.ChkTipoCuenta.AutoSize = True
        Me.ChkTipoCuenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkTipoCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkTipoCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.ChkTipoCuenta.Location = New System.Drawing.Point(384, 300)
        Me.ChkTipoCuenta.Name = "ChkTipoCuenta"
        Me.ChkTipoCuenta.Size = New System.Drawing.Size(89, 19)
        Me.ChkTipoCuenta.TabIndex = 216
        Me.ChkTipoCuenta.Text = "Tipo cuenta"
        Me.ChkTipoCuenta.UseVisualStyleBackColor = True
        '
        'PnlDatos
        '
        Me.PnlDatos.BackColor = System.Drawing.Color.White
        Me.PnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlDatos.Controls.Add(Me.Label2)
        Me.PnlDatos.Controls.Add(Me.LblNombre)
        Me.PnlDatos.Controls.Add(Me.Label3)
        Me.PnlDatos.Controls.Add(Me.DTPFecha)
        Me.PnlDatos.Controls.Add(Me.LblMoneda)
        Me.PnlDatos.Controls.Add(Me.Label16)
        Me.PnlDatos.Controls.Add(Me.CmbCodigo)
        Me.PnlDatos.Controls.Add(Me.LblDescripcion)
        Me.PnlDatos.Controls.Add(Me.TxtDescripcion)
        Me.PnlDatos.Controls.Add(Me.Label7)
        Me.PnlDatos.Controls.Add(Me.TxtMonto)
        Me.PnlDatos.Controls.Add(Me.Label8)
        Me.PnlDatos.Controls.Add(Me.TxtObservaciones)
        Me.PnlDatos.Controls.Add(Me.Label9)
        Me.PnlDatos.Controls.Add(Me.LblFactura)
        Me.PnlDatos.Location = New System.Drawing.Point(16, 80)
        Me.PnlDatos.Name = "PnlDatos"
        Me.PnlDatos.Size = New System.Drawing.Size(608, 208)
        Me.PnlDatos.TabIndex = 1
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblDescripcion.Location = New System.Drawing.Point(134, 70)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(69, 15)
        Me.LblDescripcion.TabIndex = 217
        Me.LblDescripcion.Text = "Descripción"
        '
        'PnlAcciones
        '
        Me.PnlAcciones.BackColor = System.Drawing.Color.White
        Me.PnlAcciones.Controls.Add(Me.Button1)
        Me.PnlAcciones.Controls.Add(Me.Button4)
        Me.PnlAcciones.Controls.Add(Me.Button2)
        Me.PnlAcciones.Controls.Add(Me.Button8)
        Me.PnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlAcciones.Location = New System.Drawing.Point(0, 334)
        Me.PnlAcciones.Name = "PnlAcciones"
        Me.PnlAcciones.Size = New System.Drawing.Size(640, 70)
        Me.PnlAcciones.TabIndex = 2
        '
        'LblOpciones
        '
        Me.LblOpciones.AutoSize = True
        Me.LblOpciones.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOpciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.LblOpciones.Location = New System.Drawing.Point(16, 302)
        Me.LblOpciones.Name = "LblOpciones"
        Me.LblOpciones.Size = New System.Drawing.Size(60, 15)
        Me.LblOpciones.TabIndex = 218
        Me.LblOpciones.Text = "Opciones:"
        '
        'FrmRegistroDebito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(640, 404)
        Me.Controls.Add(Me.PnlAcciones)
        Me.Controls.Add(Me.LblOpciones)
        Me.Controls.Add(Me.ChkTipoCuenta)
        Me.Controls.Add(Me.ChkSseries)
        Me.Controls.Add(Me.ChkFactura)
        Me.Controls.Add(Me.TxtCodCliente)
        Me.Controls.Add(Me.PnlDatos)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TxtNumeroEnsamble)
        Me.Controls.Add(Me.CmbSerie)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblNumero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistroDebito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notas de Débito y Crédito"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDatos.ResumeLayout(False)
        Me.PnlDatos.PerformLayout()
        Me.PnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblMoneda As System.Windows.Forms.Label
    Friend WithEvents CmbCodigo As C1.Win.C1List.C1Combo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblFactura As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtCodCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents ChkFactura As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSseries As System.Windows.Forms.CheckBox
    Friend WithEvents PrintNota As System.Drawing.Printing.PrintDocument
    Friend WithEvents ChkTipoCuenta As System.Windows.Forms.CheckBox
    Friend WithEvents PnlDatos As System.Windows.Forms.Panel
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents PnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents LblOpciones As System.Windows.Forms.Label
End Class
