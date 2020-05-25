<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompras
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompras))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtMonedaFactura = New System.Windows.Forms.ComboBox
        Me.CboTipoProducto = New System.Windows.Forms.ComboBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmdTransferencias = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.CboReferencia = New System.Windows.Forms.ComboBox
        Me.OptExsonerado = New System.Windows.Forms.CheckBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSubTotal = New System.Windows.Forms.TextBox
        Me.TxtIva = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtNetoPagar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.DTVencimiento = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TxtPagado = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.Button7 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtObservaciones = New System.Windows.Forms.TextBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.CmdFacturar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmdProcesar = New System.Windows.Forms.Button
        Me.TxtMonedaImprime = New System.Windows.Forms.ComboBox
        Me.C1Button2 = New C1.Win.C1Input.C1Button
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.C1Button3 = New C1.Win.C1Input.C1Button
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.C1Button4 = New C1.Win.C1Input.C1Button
        Me.CboProyecto = New C1.Win.C1List.C1Combo
        Me.Label12 = New System.Windows.Forms.Label
        Me.DTPFechaHora = New System.Windows.Forms.DateTimePicker
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtMonedaFactura)
        Me.GroupBox1.Controls.Add(Me.CboTipoProducto)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(703, 48)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'TxtMonedaFactura
        '
        Me.TxtMonedaFactura.FormattingEnabled = True
        Me.TxtMonedaFactura.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.TxtMonedaFactura.Location = New System.Drawing.Point(622, 16)
        Me.TxtMonedaFactura.Name = "TxtMonedaFactura"
        Me.TxtMonedaFactura.Size = New System.Drawing.Size(75, 21)
        Me.TxtMonedaFactura.TabIndex = 199
        '
        'CboTipoProducto
        '
        Me.CboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoProducto.FormattingEnabled = True
        Me.CboTipoProducto.Items.AddRange(New Object() {"Orden de Compra", "Mercancia Recibida", "Devolucion de Compra", "Cuenta", "Cuenta DB"})
        Me.CboTipoProducto.Location = New System.Drawing.Point(43, 13)
        Me.CboTipoProducto.Name = "CboTipoProducto"
        Me.CboTipoProducto.Size = New System.Drawing.Size(135, 21)
        Me.CboTipoProducto.TabIndex = 128
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(488, 10)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 32)
        Me.Button6.TabIndex = 127
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(406, 14)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(76, 20)
        Me.TxtNumeroEnsamble.TabIndex = 122
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(531, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 198
        Me.Label13.Text = "Moneda Compra"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(227, 14)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        '
        'CmdTransferencias
        '
        Me.CmdTransferencias.Image = CType(resources.GetObject("CmdTransferencias.Image"), System.Drawing.Image)
        Me.CmdTransferencias.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdTransferencias.Location = New System.Drawing.Point(0, 75)
        Me.CmdTransferencias.Name = "CmdTransferencias"
        Me.CmdTransferencias.Size = New System.Drawing.Size(93, 32)
        Me.CmdTransferencias.TabIndex = 148
        Me.CmdTransferencias.Text = "Transferencias"
        Me.CmdTransferencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdTransferencias.UseVisualStyleBackColor = True
        Me.CmdTransferencias.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.CboReferencia)
        Me.GroupBox2.Controls.Add(Me.OptExsonerado)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.TxtTelefono)
        Me.GroupBox2.Controls.Add(Me.TxtDireccion)
        Me.GroupBox2.Controls.Add(Me.TxtApellidos)
        Me.GroupBox2.Controls.Add(Me.TxtNombres)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoProveedor)
        Me.GroupBox2.Controls.Add(Me.CmdTransferencias)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 150)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion del Proveedor"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 226
        Me.Label16.Text = "Referencia"
        '
        'CboReferencia
        '
        Me.CboReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboReferencia.FormattingEnabled = True
        Me.CboReferencia.Location = New System.Drawing.Point(86, 123)
        Me.CboReferencia.Name = "CboReferencia"
        Me.CboReferencia.Size = New System.Drawing.Size(135, 21)
        Me.CboReferencia.TabIndex = 225
        '
        'OptExsonerado
        '
        Me.OptExsonerado.AutoSize = True
        Me.OptExsonerado.Location = New System.Drawing.Point(234, 127)
        Me.OptExsonerado.Name = "OptExsonerado"
        Me.OptExsonerado.Size = New System.Drawing.Size(77, 17)
        Me.OptExsonerado.TabIndex = 149
        Me.OptExsonerado.Text = "Exonerado"
        Me.OptExsonerado.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(272, 45)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 32)
        Me.Button3.TabIndex = 209
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(237, 16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 147
        Me.Button5.Text = "Ctas x Pagar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(12, 97)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(209, 20)
        Me.TxtTelefono.TabIndex = 132
        Me.TxtTelefono.Visible = False
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(12, 97)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(256, 20)
        Me.TxtDireccion.TabIndex = 131
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(12, 71)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(256, 20)
        Me.TxtApellidos.TabIndex = 130
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(12, 45)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(256, 20)
        Me.TxtNombres.TabIndex = 129
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(194, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 32)
        Me.Button1.TabIndex = 128
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(12, 19)
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(176, 20)
        Me.TxtCodigoProveedor.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(14, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(78, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 116
        Me.PictureBox2.TabStop = False
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos"
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(14, 296)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(685, 167)
        Me.TrueDBGridComponentes.TabIndex = 133
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(173, 471)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Sub Total   "
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Enabled = False
        Me.TxtSubTotal.Location = New System.Drawing.Point(231, 466)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.Size = New System.Drawing.Size(67, 20)
        Me.TxtSubTotal.TabIndex = 135
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIva
        '
        Me.TxtIva.Enabled = False
        Me.TxtIva.Location = New System.Drawing.Point(352, 467)
        Me.TxtIva.Name = "TxtIva"
        Me.TxtIva.Size = New System.Drawing.Size(73, 20)
        Me.TxtIva.TabIndex = 137
        Me.TxtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(312, 471)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "IVA      "
        '
        'TxtNetoPagar
        '
        Me.TxtNetoPagar.Enabled = False
        Me.TxtNetoPagar.Location = New System.Drawing.Point(622, 468)
        Me.TxtNetoPagar.Name = "TxtNetoPagar"
        Me.TxtNetoPagar.Size = New System.Drawing.Size(75, 20)
        Me.TxtNetoPagar.TabIndex = 139
        Me.TxtNetoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(552, 474)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 138
        Me.Label6.Text = "Neto a Pagar "
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(10, 160)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 66)
        Me.Button2.TabIndex = 144
        Me.Button2.Tag = "27"
        Me.Button2.Text = "Imprimir"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(10, 88)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(62, 66)
        Me.ButtonBorrar.TabIndex = 142
        Me.ButtonBorrar.Tag = "26"
        Me.ButtonBorrar.Text = "Anular"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(78, 17)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(62, 66)
        Me.ButtonAgregar.TabIndex = 141
        Me.ButtonAgregar.Tag = "25"
        Me.ButtonAgregar.Text = "Guardar"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(41, 228)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 140
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(335, 222)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(138, 45)
        Me.GroupBox3.TabIndex = 145
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Forma de Pago"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(71, 19)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(65, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Contado"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(7, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Credito"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'DTVencimiento
        '
        Me.DTVencimiento.CustomFormat = ""
        Me.DTVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTVencimiento.Location = New System.Drawing.Point(568, 121)
        Me.DTVencimiento.Name = "DTVencimiento"
        Me.DTVencimiento.Size = New System.Drawing.Size(104, 20)
        Me.DTVencimiento.TabIndex = 149
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(464, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 148
        Me.Label8.Text = "Fecha Vencimiento"
        '
        'TrueDBGridMetodo
        '
        Me.TrueDBGridMetodo.AllowAddNew = True
        Me.TrueDBGridMetodo.AllowDelete = True
        Me.TrueDBGridMetodo.AlternatingRows = True
        Me.TrueDBGridMetodo.Caption = "Metodos de Pago"
        Me.TrueDBGridMetodo.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridMetodo.Images.Add(CType(resources.GetObject("TrueDBGridMetodo.Images"), System.Drawing.Image))
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(477, 206)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridMetodo.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridMetodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(232, 84)
        Me.TrueDBGridMetodo.TabIndex = 150
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.Visible = False
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'TxtPagado
        '
        Me.TxtPagado.Enabled = False
        Me.TxtPagado.Location = New System.Drawing.Point(479, 468)
        Me.TxtPagado.Name = "TxtPagado"
        Me.TxtPagado.Size = New System.Drawing.Size(67, 20)
        Me.TxtPagado.TabIndex = 152
        Me.TxtPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(431, 473)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 151
        Me.Label10.Text = "Pagado    "
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(335, 121)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(123, 95)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 153
        Me.PictureBox3.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(467, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 154
        Me.Label11.Text = "Bodega"
        '
        'CboCodigoBodega
        '
        Me.CboCodigoBodega.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega.Caption = ""
        Me.CboCodigoBodega.CaptionHeight = 17
        Me.CboCodigoBodega.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega.ColumnCaptionHeight = 17
        Me.CboCodigoBodega.ColumnFooterHeight = 17
        Me.CboCodigoBodega.ContentHeight = 15
        Me.CboCodigoBodega.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega.EditorHeight = 15
        Me.CboCodigoBodega.Images.Add(CType(resources.GetObject("CboCodigoBodega.Images"), System.Drawing.Image))
        Me.CboCodigoBodega.ItemHeight = 15
        Me.CboCodigoBodega.Location = New System.Drawing.Point(517, 147)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(137, 21)
        Me.CboCodigoBodega.TabIndex = 155
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(672, 102)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(37, 38)
        Me.Button7.TabIndex = 156
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtObservaciones)
        Me.GroupBox4.Location = New System.Drawing.Point(713, 375)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(165, 113)
        Me.GroupBox4.TabIndex = 157
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Observaciones"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(6, 19)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(148, 88)
        Me.TxtObservaciones.TabIndex = 0
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(199, 400)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 158
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(10, 17)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(62, 66)
        Me.CmdNuevo.TabIndex = 159
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'CmdFacturar
        '
        Me.CmdFacturar.Enabled = False
        Me.CmdFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFacturar.Image = CType(resources.GetObject("CmdFacturar.Image"), System.Drawing.Image)
        Me.CmdFacturar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdFacturar.Location = New System.Drawing.Point(78, 88)
        Me.CmdFacturar.Name = "CmdFacturar"
        Me.CmdFacturar.Size = New System.Drawing.Size(62, 66)
        Me.CmdFacturar.TabIndex = 201
        Me.CmdFacturar.Text = "Comprar"
        Me.CmdFacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdFacturar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-2, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(896, 60)
        Me.PictureBox1.TabIndex = 202
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(332, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(172, 13)
        Me.Label9.TabIndex = 203
        Me.Label9.Text = "OPERACIONES DE COMPRA"
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button4.Location = New System.Drawing.Point(12, 464)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(94, 23)
        Me.Button4.TabIndex = 204
        Me.Button4.Text = "Borrar Linea"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TxtReferencia
        '
        Me.TxtReferencia.AcceptsReturn = True
        Me.TxtReferencia.Location = New System.Drawing.Point(394, 270)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(76, 20)
        Me.TxtReferencia.TabIndex = 206
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(321, 273)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "Num Factura"
        '
        'CmdProcesar
        '
        Me.CmdProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdProcesar.Image = CType(resources.GetObject("CmdProcesar.Image"), System.Drawing.Image)
        Me.CmdProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdProcesar.Location = New System.Drawing.Point(78, 160)
        Me.CmdProcesar.Name = "CmdProcesar"
        Me.CmdProcesar.Size = New System.Drawing.Size(65, 66)
        Me.CmdProcesar.TabIndex = 207
        Me.CmdProcesar.Tag = "28"
        Me.CmdProcesar.Text = "Procesar"
        Me.CmdProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdProcesar.UseVisualStyleBackColor = True
        '
        'TxtMonedaImprime
        '
        Me.TxtMonedaImprime.FormattingEnabled = True
        Me.TxtMonedaImprime.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.TxtMonedaImprime.Location = New System.Drawing.Point(14, 269)
        Me.TxtMonedaImprime.Name = "TxtMonedaImprime"
        Me.TxtMonedaImprime.Size = New System.Drawing.Size(78, 21)
        Me.TxtMonedaImprime.TabIndex = 208
        '
        'C1Button2
        '
        Me.C1Button2.Image = CType(resources.GetObject("C1Button2.Image"), System.Drawing.Image)
        Me.C1Button2.Location = New System.Drawing.Point(101, 267)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(39, 24)
        Me.C1Button2.TabIndex = 211
        Me.C1Button2.UseVisualStyleBackColor = True
        Me.C1Button2.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'C1Button3
        '
        Me.C1Button3.Image = CType(resources.GetObject("C1Button3.Image"), System.Drawing.Image)
        Me.C1Button3.Location = New System.Drawing.Point(143, 267)
        Me.C1Button3.Name = "C1Button3"
        Me.C1Button3.Size = New System.Drawing.Size(39, 24)
        Me.C1Button3.TabIndex = 212
        Me.C1Button3.UseVisualStyleBackColor = True
        Me.C1Button3.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'C1Button1
        '
        Me.C1Button1.Image = CType(resources.GetObject("C1Button1.Image"), System.Drawing.Image)
        Me.C1Button1.Location = New System.Drawing.Point(660, 146)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(39, 24)
        Me.C1Button1.TabIndex = 213
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'C1Button4
        '
        Me.C1Button4.Image = CType(resources.GetObject("C1Button4.Image"), System.Drawing.Image)
        Me.C1Button4.Location = New System.Drawing.Point(660, 173)
        Me.C1Button4.Name = "C1Button4"
        Me.C1Button4.Size = New System.Drawing.Size(39, 24)
        Me.C1Button4.TabIndex = 216
        Me.C1Button4.UseVisualStyleBackColor = True
        Me.C1Button4.VisualStyle = C1.Win.C1Input.VisualStyle.System
        '
        'CboProyecto
        '
        Me.CboProyecto.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboProyecto.Caption = ""
        Me.CboProyecto.CaptionHeight = 17
        Me.CboProyecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboProyecto.ColumnCaptionHeight = 17
        Me.CboProyecto.ColumnFooterHeight = 17
        Me.CboProyecto.ContentHeight = 15
        Me.CboProyecto.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboProyecto.DisplayMember = "NombreProyectos"
        Me.CboProyecto.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboProyecto.DropDownWidth = 300
        Me.CboProyecto.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboProyecto.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboProyecto.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboProyecto.EditorHeight = 15
        Me.CboProyecto.Images.Add(CType(resources.GetObject("CboProyecto.Images"), System.Drawing.Image))
        Me.CboProyecto.ItemHeight = 15
        Me.CboProyecto.Location = New System.Drawing.Point(517, 174)
        Me.CboProyecto.MatchEntryTimeout = CType(2000, Long)
        Me.CboProyecto.MaxDropDownItems = CType(5, Short)
        Me.CboProyecto.MaxLength = 32767
        Me.CboProyecto.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboProyecto.Name = "CboProyecto"
        Me.CboProyecto.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboProyecto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboProyecto.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboProyecto.Size = New System.Drawing.Size(137, 21)
        Me.CboProyecto.TabIndex = 215
        Me.CboProyecto.PropBag = resources.GetString("CboProyecto.PropBag")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(467, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 214
        Me.Label12.Text = "Proyecto"
        '
        'DTPFechaHora
        '
        Me.DTPFechaHora.CustomFormat = ""
        Me.DTPFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaHora.Location = New System.Drawing.Point(959, 242)
        Me.DTPFechaHora.Name = "DTPFechaHora"
        Me.DTPFechaHora.Size = New System.Drawing.Size(101, 20)
        Me.DTPFechaHora.TabIndex = 217
        Me.DTPFechaHora.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CmdNuevo)
        Me.GroupBox5.Controls.Add(Me.ButtonAgregar)
        Me.GroupBox5.Controls.Add(Me.ButtonBorrar)
        Me.GroupBox5.Controls.Add(Me.CmdFacturar)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.CmdProcesar)
        Me.GroupBox5.Controls.Add(Me.Button8)
        Me.GroupBox5.Location = New System.Drawing.Point(721, 67)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(154, 302)
        Me.GroupBox5.TabIndex = 218
        Me.GroupBox5.TabStop = False
        '
        'FrmCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 502)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.DTPFechaHora)
        Me.Controls.Add(Me.C1Button4)
        Me.Controls.Add(Me.CboProyecto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.C1Button1)
        Me.Controls.Add(Me.C1Button3)
        Me.Controls.Add(Me.C1Button2)
        Me.Controls.Add(Me.TxtMonedaImprime)
        Me.Controls.Add(Me.TxtReferencia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.TxtPagado)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TrueDBGridMetodo)
        Me.Controls.Add(Me.DTVencimiento)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TxtNetoPagar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtIva)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtSubTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operaciones de Compras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtIva As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNetoPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents DTVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtPagado As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents BindingMetodo As System.Windows.Forms.BindingSource
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdTransferencias As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmdFacturar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents OptExsonerado As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdProcesar As System.Windows.Forms.Button
    Friend WithEvents TxtMonedaFactura As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMonedaImprime As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button3 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button4 As C1.Win.C1Input.C1Button
    Friend WithEvents CboProyecto As C1.Win.C1List.C1Combo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CboReferencia As System.Windows.Forms.ComboBox
    Friend WithEvents DTPFechaHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
End Class
