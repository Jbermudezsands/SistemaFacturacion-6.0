<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagos))
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TxtImporteAplicado = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPorAplicar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtImporteRecibido = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.TxtDescuento = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtNetoPagar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtSubTotal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BindingFacturas = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtMonedaFactura = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.OptRet2Porciento = New System.Windows.Forms.CheckBox
        Me.OptRet1Porciento = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.OptRet10Porciento = New System.Windows.Forms.CheckBox
        Me.TxtObservaciones = New System.Windows.Forms.TextBox
        Me.OptRet7Porciento = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(277, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(245, 13)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "SOLICITUD DE PAGO A  PROVEEDORES"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(105, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 165
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-2, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(799, 60)
        Me.PictureBox1.TabIndex = 164
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 48)
        Me.GroupBox1.TabIndex = 167
        Me.GroupBox1.TabStop = False
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
        Me.DTPFecha.Location = New System.Drawing.Point(58, 14)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtTelefono)
        Me.GroupBox2.Controls.Add(Me.TxtDireccion)
        Me.GroupBox2.Controls.Add(Me.TxtApellidos)
        Me.GroupBox2.Controls.Add(Me.TxtNombres)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoProveedor)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 120)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(281, 158)
        Me.GroupBox2.TabIndex = 168
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion del Proveedor"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(12, 123)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(253, 20)
        Me.TxtTelefono.TabIndex = 132
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(12, 97)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(253, 20)
        Me.TxtDireccion.TabIndex = 131
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(12, 71)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(253, 20)
        Me.TxtApellidos.TabIndex = 130
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(12, 45)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(253, 20)
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
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Facturas"
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(12, 313)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(648, 147)
        Me.TrueDBGridComponentes.TabIndex = 171
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'TxtImporteAplicado
        '
        Me.TxtImporteAplicado.Enabled = False
        Me.TxtImporteAplicado.Location = New System.Drawing.Point(306, 287)
        Me.TxtImporteAplicado.Name = "TxtImporteAplicado"
        Me.TxtImporteAplicado.Size = New System.Drawing.Size(87, 20)
        Me.TxtImporteAplicado.TabIndex = 191
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(220, 291)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "Importe Aplicado "
        '
        'TxtPorAplicar
        '
        Me.TxtPorAplicar.Enabled = False
        Me.TxtPorAplicar.Location = New System.Drawing.Point(469, 287)
        Me.TxtPorAplicar.Name = "TxtPorAplicar"
        Me.TxtPorAplicar.Size = New System.Drawing.Size(87, 20)
        Me.TxtPorAplicar.TabIndex = 189
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(409, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 188
        Me.Label5.Text = "Por Aplicar"
        '
        'TxtImporteRecibido
        '
        Me.TxtImporteRecibido.Enabled = False
        Me.TxtImporteRecibido.Location = New System.Drawing.Point(112, 287)
        Me.TxtImporteRecibido.Name = "TxtImporteRecibido"
        Me.TxtImporteRecibido.Size = New System.Drawing.Size(88, 20)
        Me.TxtImporteRecibido.TabIndex = 187
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(21, 290)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 186
        Me.Label7.Text = "Importe Recibido   "
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 14)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 197
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(6, 87)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonAgregar.TabIndex = 196
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
        Me.Button8.Location = New System.Drawing.Point(6, 160)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 195
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Enabled = False
        Me.TxtDescuento.Location = New System.Drawing.Point(245, 470)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(67, 20)
        Me.TxtDescuento.TabIndex = 203
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(181, 473)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 202
        Me.Label10.Text = "Retencion  "
        '
        'TxtNetoPagar
        '
        Me.TxtNetoPagar.Enabled = False
        Me.TxtNetoPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetoPagar.Location = New System.Drawing.Point(451, 466)
        Me.TxtNetoPagar.Name = "TxtNetoPagar"
        Me.TxtNetoPagar.Size = New System.Drawing.Size(105, 26)
        Me.TxtNetoPagar.TabIndex = 201
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(342, 469)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 20)
        Me.Label6.TabIndex = 200
        Me.Label6.Text = "Total a Pagar"
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Enabled = False
        Me.TxtSubTotal.Location = New System.Drawing.Point(79, 468)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.Size = New System.Drawing.Size(67, 20)
        Me.TxtSubTotal.TabIndex = 199
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(21, 473)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 198
        Me.Label4.Text = "Sub Total   "
        '
        'TrueDBGridMetodo
        '
        Me.TrueDBGridMetodo.AllowAddNew = True
        Me.TrueDBGridMetodo.AllowDelete = True
        Me.TrueDBGridMetodo.AlternatingRows = True
        Me.TrueDBGridMetodo.Caption = "Metodos de Pago"
        Me.TrueDBGridMetodo.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridMetodo.Images.Add(CType(resources.GetObject("TrueDBGridMetodo.Images"), System.Drawing.Image))
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(343, 159)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridMetodo.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridMetodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(316, 119)
        Me.TrueDBGridMetodo.TabIndex = 204
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'TxtMonedaFactura
        '
        Me.TxtMonedaFactura.FormattingEnabled = True
        Me.TxtMonedaFactura.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.TxtMonedaFactura.Location = New System.Drawing.Point(676, 86)
        Me.TxtMonedaFactura.Name = "TxtMonedaFactura"
        Me.TxtMonedaFactura.Size = New System.Drawing.Size(78, 21)
        Me.TxtMonedaFactura.TabIndex = 230
        Me.TxtMonedaFactura.Text = "Cordobas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(680, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 229
        Me.Label13.Text = "Moneda"
        '
        'OptRet2Porciento
        '
        Me.OptRet2Porciento.AutoSize = True
        Me.OptRet2Porciento.Location = New System.Drawing.Point(299, 140)
        Me.OptRet2Porciento.Name = "OptRet2Porciento"
        Me.OptRet2Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet2Porciento.TabIndex = 232
        Me.OptRet2Porciento.Text = "Retener 2%"
        Me.OptRet2Porciento.UseVisualStyleBackColor = True
        '
        'OptRet1Porciento
        '
        Me.OptRet1Porciento.AutoSize = True
        Me.OptRet1Porciento.Location = New System.Drawing.Point(299, 120)
        Me.OptRet1Porciento.Name = "OptRet1Porciento"
        Me.OptRet1Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet1Porciento.TabIndex = 231
        Me.OptRet1Porciento.Text = "Retener 1%"
        Me.OptRet1Porciento.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CmdNuevo)
        Me.GroupBox3.Controls.Add(Me.ButtonAgregar)
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Location = New System.Drawing.Point(678, 110)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(91, 242)
        Me.GroupBox3.TabIndex = 233
        Me.GroupBox3.TabStop = False
        '
        'OptRet10Porciento
        '
        Me.OptRet10Porciento.AutoSize = True
        Me.OptRet10Porciento.Location = New System.Drawing.Point(392, 139)
        Me.OptRet10Porciento.Name = "OptRet10Porciento"
        Me.OptRet10Porciento.Size = New System.Drawing.Size(87, 17)
        Me.OptRet10Porciento.TabIndex = 234
        Me.OptRet10Porciento.Text = "Retener 10%"
        Me.OptRet10Porciento.UseVisualStyleBackColor = True
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(666, 376)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(103, 116)
        Me.TxtObservaciones.TabIndex = 235
        '
        'OptRet7Porciento
        '
        Me.OptRet7Porciento.AutoSize = True
        Me.OptRet7Porciento.Location = New System.Drawing.Point(392, 121)
        Me.OptRet7Porciento.Name = "OptRet7Porciento"
        Me.OptRet7Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet7Porciento.TabIndex = 236
        Me.OptRet7Porciento.Text = "Retener 7%"
        Me.OptRet7Porciento.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(666, 358)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 237
        Me.Label8.Text = "Observaciones"
        '
        'FrmPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 497)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.OptRet7Porciento)
        Me.Controls.Add(Me.TxtObservaciones)
        Me.Controls.Add(Me.OptRet10Porciento)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.OptRet2Porciento)
        Me.Controls.Add(Me.OptRet1Porciento)
        Me.Controls.Add(Me.TxtMonedaFactura)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TrueDBGridMetodo)
        Me.Controls.Add(Me.TxtDescuento)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtNetoPagar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtSubTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtImporteAplicado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPorAplicar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtImporteRecibido)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Pagos a Proveedores"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtImporteAplicado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPorAplicar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteRecibido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtNetoPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BindingFacturas As System.Windows.Forms.BindingSource
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BindingMetodo As System.Windows.Forms.BindingSource
    Friend WithEvents TxtMonedaFactura As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents OptRet2Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents OptRet1Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptRet10Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents OptRet7Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
