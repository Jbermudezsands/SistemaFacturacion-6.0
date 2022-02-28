<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLiquidacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLiquidacion))
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdEditar = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.CmdFacturar = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.Procesar = New System.Windows.Forms.Button
        Me.TxtMontoIva = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtTotalFob = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.TxtTotalCosto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxtGastosAduana = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtCustodio = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtOtrosGastos = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtFletesInternos = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtAgente = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtFletes = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtAlmacen = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtTransporte = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtSeguro = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button7 = New System.Windows.Forms.Button
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.CmbMoneda = New System.Windows.Forms.ComboBox
        Me.CmbImpuesto = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.TDGridImpuestos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TxtTasaCambio = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CmbGastos = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtIVA = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtISC = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtDAI = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtSPE = New System.Windows.Forms.TextBox
        Me.TxtSSA = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtTSI = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxtGastoImpuesto = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ChkProrratearPeso = New System.Windows.Forms.CheckBox
        Me.TxtTotalPeso = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(400, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(211, 20)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "Liquidacion de Productos"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(22, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(59, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 165
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1073, 60)
        Me.PictureBox1.TabIndex = 164
        Me.PictureBox1.TabStop = False
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(789, 66)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 32)
        Me.Button6.TabIndex = 6
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(707, 70)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(76, 20)
        Me.TxtNumeroEnsamble.TabIndex = 168
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(657, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 167
        Me.Label3.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(707, 102)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(664, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Fecha"
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos"
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(12, 153)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(863, 153)
        Me.TrueDBGridComponentes.TabIndex = 172
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtApellidos)
        Me.GroupBox2.Controls.Add(Me.TxtNombres)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoProveedor)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 101)
        Me.GroupBox2.TabIndex = 173
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion del Proveedor"
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(6, 71)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(256, 20)
        Me.TxtApellidos.TabIndex = 3
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(6, 45)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(256, 20)
        Me.TxtNombres.TabIndex = 2
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(6, 19)
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(176, 20)
        Me.TxtCodigoProveedor.TabIndex = 1
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(232, 16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(85, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Ctas x Pagar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(194, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 32)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdEditar)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.CmdFacturar)
        Me.GroupBox1.Controls.Add(Me.ButtonBorrar)
        Me.GroupBox1.Controls.Add(Me.CmdNuevo)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ButtonAgregar)
        Me.GroupBox1.Location = New System.Drawing.Point(875, 169)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(172, 319)
        Me.GroupBox1.TabIndex = 193
        Me.GroupBox1.TabStop = False
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditar.Image = CType(resources.GetObject("cmdEditar.Image"), System.Drawing.Image)
        Me.cmdEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdEditar.Location = New System.Drawing.Point(89, 94)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(75, 67)
        Me.cmdEditar.TabIndex = 41
        Me.cmdEditar.Tag = "28"
        Me.cmdEditar.Text = "Prorratear"
        Me.cmdEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(51, 241)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 43
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CmdFacturar
        '
        Me.CmdFacturar.Enabled = False
        Me.CmdFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFacturar.Image = CType(resources.GetObject("CmdFacturar.Image"), System.Drawing.Image)
        Me.CmdFacturar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdFacturar.Location = New System.Drawing.Point(89, 167)
        Me.CmdFacturar.Name = "CmdFacturar"
        Me.CmdFacturar.Size = New System.Drawing.Size(75, 66)
        Me.CmdFacturar.TabIndex = 42
        Me.CmdFacturar.Text = "Comprar"
        Me.CmdFacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdFacturar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(8, 92)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 40
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(8, 19)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 37
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(8, 167)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 66)
        Me.Button2.TabIndex = 39
        Me.Button2.Tag = "27"
        Me.Button2.Text = "Imprimir"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(89, 19)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonAgregar.TabIndex = 38
        Me.ButtonAgregar.Tag = "25"
        Me.ButtonAgregar.Text = "Guardar"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'Procesar
        '
        Me.Procesar.Location = New System.Drawing.Point(1187, 415)
        Me.Procesar.Name = "Procesar"
        Me.Procesar.Size = New System.Drawing.Size(75, 23)
        Me.Procesar.TabIndex = 210
        Me.Procesar.Text = "Procesar"
        Me.Procesar.UseVisualStyleBackColor = True
        Me.Procesar.Visible = False
        '
        'TxtMontoIva
        '
        Me.TxtMontoIva.Location = New System.Drawing.Point(1181, 341)
        Me.TxtMontoIva.Name = "TxtMontoIva"
        Me.TxtMontoIva.Size = New System.Drawing.Size(100, 20)
        Me.TxtMontoIva.TabIndex = 209
        Me.TxtMontoIva.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(462, 331)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 194
        Me.Label1.Text = "TOTAL FOB"
        '
        'TxtTotalFob
        '
        Me.TxtTotalFob.Enabled = False
        Me.TxtTotalFob.Location = New System.Drawing.Point(552, 331)
        Me.TxtTotalFob.Name = "TxtTotalFob"
        Me.TxtTotalFob.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalFob.TabIndex = 195
        Me.TxtTotalFob.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button4.Location = New System.Drawing.Point(7, 326)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(94, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Borrar Linea"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TxtTotalCosto
        '
        Me.TxtTotalCosto.AcceptsReturn = True
        Me.TxtTotalCosto.Enabled = False
        Me.TxtTotalCosto.Location = New System.Drawing.Point(770, 332)
        Me.TxtTotalCosto.Name = "TxtTotalCosto"
        Me.TxtTotalCosto.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalCosto.TabIndex = 198
        Me.TxtTotalCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(654, 332)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 16)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "TOTAL COSTO"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtGastosAduana)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.TxtCustodio)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.TxtOtrosGastos)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.TxtFletesInternos)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.TxtAgente)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.TxtFletes)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.TxtAlmacen)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TxtTransporte)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.TxtSeguro)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 360)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(335, 133)
        Me.GroupBox3.TabIndex = 200
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Gastos e Impuestos de Liquidacion"
        '
        'TxtGastosAduana
        '
        Me.TxtGastosAduana.Location = New System.Drawing.Point(264, 62)
        Me.TxtGastosAduana.Name = "TxtGastosAduana"
        Me.TxtGastosAduana.Size = New System.Drawing.Size(58, 20)
        Me.TxtGastosAduana.TabIndex = 25
        Me.TxtGastosAduana.Text = "0.00"
        Me.TxtGastosAduana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(182, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Gtos Aduana"
        '
        'TxtCustodio
        '
        Me.TxtCustodio.Location = New System.Drawing.Point(264, 41)
        Me.TxtCustodio.Name = "TxtCustodio"
        Me.TxtCustodio.Size = New System.Drawing.Size(58, 20)
        Me.TxtCustodio.TabIndex = 23
        Me.TxtCustodio.Text = "0.00"
        Me.TxtCustodio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(182, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Custodio"
        '
        'TxtOtrosGastos
        '
        Me.TxtOtrosGastos.Location = New System.Drawing.Point(264, 84)
        Me.TxtOtrosGastos.Name = "TxtOtrosGastos"
        Me.TxtOtrosGastos.Size = New System.Drawing.Size(58, 20)
        Me.TxtOtrosGastos.TabIndex = 21
        Me.TxtOtrosGastos.Text = "0.00"
        Me.TxtOtrosGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(182, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Otros Gastos"
        '
        'TxtFletesInternos
        '
        Me.TxtFletesInternos.Location = New System.Drawing.Point(264, 19)
        Me.TxtFletesInternos.Name = "TxtFletesInternos"
        Me.TxtFletesInternos.Size = New System.Drawing.Size(58, 20)
        Me.TxtFletesInternos.TabIndex = 19
        Me.TxtFletesInternos.Text = "0.00"
        Me.TxtFletesInternos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(182, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Fletes Internos"
        '
        'TxtAgente
        '
        Me.TxtAgente.Location = New System.Drawing.Point(100, 108)
        Me.TxtAgente.Name = "TxtAgente"
        Me.TxtAgente.Size = New System.Drawing.Size(66, 20)
        Me.TxtAgente.TabIndex = 17
        Me.TxtAgente.Text = "0.00"
        Me.TxtAgente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Agente Aduanero"
        '
        'TxtFletes
        '
        Me.TxtFletes.Location = New System.Drawing.Point(100, 22)
        Me.TxtFletes.Name = "TxtFletes"
        Me.TxtFletes.Size = New System.Drawing.Size(66, 20)
        Me.TxtFletes.TabIndex = 15
        Me.TxtFletes.Text = "0.00"
        Me.TxtFletes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(32, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Fletes"
        '
        'TxtAlmacen
        '
        Me.TxtAlmacen.Location = New System.Drawing.Point(100, 66)
        Me.TxtAlmacen.Name = "TxtAlmacen"
        Me.TxtAlmacen.Size = New System.Drawing.Size(66, 20)
        Me.TxtAlmacen.TabIndex = 11
        Me.TxtAlmacen.Text = "0.00"
        Me.TxtAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Almacen"
        '
        'TxtTransporte
        '
        Me.TxtTransporte.Location = New System.Drawing.Point(100, 87)
        Me.TxtTransporte.Name = "TxtTransporte"
        Me.TxtTransporte.Size = New System.Drawing.Size(66, 20)
        Me.TxtTransporte.TabIndex = 10
        Me.TxtTransporte.Text = "0.00"
        Me.TxtTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Transporte"
        '
        'TxtSeguro
        '
        Me.TxtSeguro.Location = New System.Drawing.Point(100, 44)
        Me.TxtSeguro.Name = "TxtSeguro"
        Me.TxtSeguro.Size = New System.Drawing.Size(66, 20)
        Me.TxtSeguro.TabIndex = 9
        Me.TxtSeguro.Text = "0.00"
        Me.TxtSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Seguro"
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(789, 129)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(37, 38)
        Me.Button7.TabIndex = 203
        Me.Button7.UseVisualStyleBackColor = True
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
        Me.CboCodigoBodega.Location = New System.Drawing.Point(660, 137)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(123, 21)
        Me.CboCodigoBodega.TabIndex = 202
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(606, 137)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 201
        Me.Label20.Text = "Bodega"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(457, 68)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 13)
        Me.Label21.TabIndex = 204
        Me.Label21.Text = "Moneda Liquidacion"
        '
        'CmbMoneda
        '
        Me.CmbMoneda.FormattingEnabled = True
        Me.CmbMoneda.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.CmbMoneda.Location = New System.Drawing.Point(561, 65)
        Me.CmbMoneda.Name = "CmbMoneda"
        Me.CmbMoneda.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmbMoneda.Size = New System.Drawing.Size(86, 21)
        Me.CmbMoneda.TabIndex = 205
        '
        'CmbImpuesto
        '
        Me.CmbImpuesto.FormattingEnabled = True
        Me.CmbImpuesto.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.CmbImpuesto.Location = New System.Drawing.Point(560, 88)
        Me.CmbImpuesto.Name = "CmbImpuesto"
        Me.CmbImpuesto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmbImpuesto.Size = New System.Drawing.Size(86, 21)
        Me.CmbImpuesto.TabIndex = 207
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(458, 113)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 13)
        Me.Label22.TabIndex = 206
        Me.Label22.Text = "Moneda Gastos"
        '
        'TDGridImpuestos
        '
        Me.TDGridImpuestos.AlternatingRows = True
        Me.TDGridImpuestos.Caption = "Listado de Impuestos"
        Me.TDGridImpuestos.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridImpuestos.Images.Add(CType(resources.GetObject("TDGridImpuestos.Images"), System.Drawing.Image))
        Me.TDGridImpuestos.Location = New System.Drawing.Point(609, 358)
        Me.TDGridImpuestos.Name = "TDGridImpuestos"
        Me.TDGridImpuestos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridImpuestos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridImpuestos.PreviewInfo.ZoomFactor = 75
        Me.TDGridImpuestos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridImpuestos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridImpuestos.Size = New System.Drawing.Size(202, 133)
        Me.TDGridImpuestos.TabIndex = 208
        Me.TDGridImpuestos.Text = "C1TrueDBGrid1"
        Me.TDGridImpuestos.PropBag = resources.GetString("TDGridImpuestos.PropBag")
        '
        'TxtTasaCambio
        '
        Me.TxtTasaCambio.Location = New System.Drawing.Point(534, 134)
        Me.TxtTasaCambio.Name = "TxtTasaCambio"
        Me.TxtTasaCambio.Size = New System.Drawing.Size(66, 20)
        Me.TxtTasaCambio.TabIndex = 211
        Me.TxtTasaCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(456, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 210
        Me.Label8.Text = "Tasa Aduana"
        '
        'CmbGastos
        '
        Me.CmbGastos.FormattingEnabled = True
        Me.CmbGastos.Items.AddRange(New Object() {"Cordobas", "Dolares"})
        Me.CmbGastos.Location = New System.Drawing.Point(560, 111)
        Me.CmbGastos.Name = "CmbGastos"
        Me.CmbGastos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmbGastos.Size = New System.Drawing.Size(86, 21)
        Me.CmbGastos.TabIndex = 213
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(457, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 13)
        Me.Label16.TabIndex = 212
        Me.Label16.Text = "Moneda Impuestos"
        '
        'TxtIVA
        '
        Me.TxtIVA.Location = New System.Drawing.Point(1187, 494)
        Me.TxtIVA.Name = "TxtIVA"
        Me.TxtIVA.Size = New System.Drawing.Size(94, 20)
        Me.TxtIVA.TabIndex = 219
        Me.TxtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtIVA.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(1081, 497)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 13)
        Me.Label17.TabIndex = 218
        Me.Label17.Text = "Base Imponible IVA"
        Me.Label17.Visible = False
        '
        'TxtISC
        '
        Me.TxtISC.Location = New System.Drawing.Point(1187, 473)
        Me.TxtISC.Name = "TxtISC"
        Me.TxtISC.Size = New System.Drawing.Size(94, 20)
        Me.TxtISC.TabIndex = 217
        Me.TxtISC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtISC.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(1081, 476)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 13)
        Me.Label18.TabIndex = 216
        Me.Label18.Text = "Base Imponible ISC"
        Me.Label18.Visible = False
        '
        'TxtDAI
        '
        Me.TxtDAI.Location = New System.Drawing.Point(1187, 451)
        Me.TxtDAI.Name = "TxtDAI"
        Me.TxtDAI.Size = New System.Drawing.Size(94, 20)
        Me.TxtDAI.TabIndex = 215
        Me.TxtDAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDAI.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(1081, 454)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 13)
        Me.Label19.TabIndex = 214
        Me.Label19.Text = "Base Imponible DAI"
        Me.Label19.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(875, 66)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(164, 99)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 220
        Me.PictureBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.TxtSPE)
        Me.GroupBox4.Controls.Add(Me.TxtSSA)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.TxtTSI)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.TxtGastoImpuesto)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Location = New System.Drawing.Point(375, 360)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(176, 133)
        Me.GroupBox4.TabIndex = 221
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Boletin de Liquidacion"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(62, 98)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 35
        Me.Label26.Text = "SPE"
        '
        'TxtSPE
        '
        Me.TxtSPE.Location = New System.Drawing.Point(92, 95)
        Me.TxtSPE.Name = "TxtSPE"
        Me.TxtSPE.Size = New System.Drawing.Size(58, 20)
        Me.TxtSPE.TabIndex = 34
        Me.TxtSPE.Text = "0.00"
        Me.TxtSPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSSA
        '
        Me.TxtSSA.Location = New System.Drawing.Point(92, 47)
        Me.TxtSSA.Name = "TxtSSA"
        Me.TxtSSA.Size = New System.Drawing.Size(58, 20)
        Me.TxtSSA.TabIndex = 33
        Me.TxtSSA.Text = "0.00"
        Me.TxtSSA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(58, 50)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(28, 13)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "SSA"
        '
        'TxtTSI
        '
        Me.TxtTSI.Location = New System.Drawing.Point(92, 71)
        Me.TxtTSI.Name = "TxtTSI"
        Me.TxtTSI.Size = New System.Drawing.Size(58, 20)
        Me.TxtTSI.TabIndex = 31
        Me.TxtTSI.Text = "0.00"
        Me.TxtTSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(62, 74)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(24, 13)
        Me.Label24.TabIndex = 30
        Me.Label24.Text = "TSI"
        '
        'TxtGastoImpuesto
        '
        Me.TxtGastoImpuesto.Location = New System.Drawing.Point(92, 24)
        Me.TxtGastoImpuesto.Name = "TxtGastoImpuesto"
        Me.TxtGastoImpuesto.Size = New System.Drawing.Size(58, 20)
        Me.TxtGastoImpuesto.TabIndex = 29
        Me.TxtGastoImpuesto.Text = "0.00"
        Me.TxtGastoImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(10, 27)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 13)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = "Gasto Impuesto"
        '
        'ChkProrratearPeso
        '
        Me.ChkProrratearPeso.AutoSize = True
        Me.ChkProrratearPeso.Location = New System.Drawing.Point(121, 331)
        Me.ChkProrratearPeso.Name = "ChkProrratearPeso"
        Me.ChkProrratearPeso.Size = New System.Drawing.Size(117, 17)
        Me.ChkProrratearPeso.TabIndex = 222
        Me.ChkProrratearPeso.Text = "Prorratear por Peso"
        Me.ChkProrratearPeso.UseVisualStyleBackColor = True
        '
        'TxtTotalPeso
        '
        Me.TxtTotalPeso.Enabled = False
        Me.TxtTotalPeso.Location = New System.Drawing.Point(352, 330)
        Me.TxtTotalPeso.Name = "TxtTotalPeso"
        Me.TxtTotalPeso.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalPeso.TabIndex = 224
        Me.TxtTotalPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(251, 330)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(102, 16)
        Me.Label27.TabIndex = 223
        Me.Label27.Text = "TOTAL PESO"
        '
        'FrmLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 500)
        Me.Controls.Add(Me.TxtTotalPeso)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.ChkProrratearPeso)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Procesar)
        Me.Controls.Add(Me.TxtIVA)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtISC)
        Me.Controls.Add(Me.TxtMontoIva)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtDAI)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.CmbGastos)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtTasaCambio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TDGridImpuestos)
        Me.Controls.Add(Me.CmbImpuesto)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.CmbMoneda)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TxtTotalCosto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TxtTotalFob)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.DTPFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TxtNumeroEnsamble)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidacion de Productos"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalFob As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TxtTotalCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdFacturar As System.Windows.Forms.Button
    Friend WithEvents cmdEditar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTransporte As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtSeguro As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents CmbImpuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtFletes As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TDGridImpuestos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtMontoIva As System.Windows.Forms.TextBox
    Friend WithEvents TxtTasaCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtAgente As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtFletesInternos As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtOtrosGastos As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtCustodio As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtGastosAduana As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Procesar As System.Windows.Forms.Button
    Friend WithEvents CmbGastos As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtISC As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtDAI As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSSA As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtTSI As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtGastoImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtSPE As System.Windows.Forms.TextBox
    Friend WithEvents ChkProrratearPeso As System.Windows.Forms.CheckBox
    Friend WithEvents TxtTotalPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
