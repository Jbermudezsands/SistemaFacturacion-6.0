<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevaSolicitud
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNuevaSolicitud))
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbldatosre = New System.Windows.Forms.Label
        Me.Grupo = New System.Windows.Forms.GroupBox
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.DtpHoraManual = New System.Windows.Forms.DateTimePicker
        Me.DTPFecha = New System.Windows.Forms.Label
        Me.LblHora = New System.Windows.Forms.Label
        Me.CboDepartamento = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTPFechaRequerido = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtConcepto = New System.Windows.Forms.TextBox
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnOrdenCompra = New System.Windows.Forms.Button
        Me.BtnAutorizar = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button3 = New System.Windows.Forms.Button
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CboRubro = New C1.Win.C1List.C1Combo
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.CboGerencia = New System.Windows.Forms.ComboBox
        Me.C1Button4 = New C1.Win.C1Input.C1Button
        Me.CboProyecto = New C1.Win.C1List.C1Combo
        Me.Label12 = New System.Windows.Forms.Label
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Gerencia Solicitante"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(310, 21)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(150, 13)
        Me.LblTitulo.TabIndex = 114
        Me.LblTitulo.Text = "SOLICITUD DE COMPRA"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(9, -9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 73)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 113
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-2, -9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(779, 73)
        Me.PictureBox1.TabIndex = 112
        Me.PictureBox1.TabStop = False
        '
        'lbldatosre
        '
        Me.lbldatosre.AutoSize = True
        Me.lbldatosre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatosre.ForeColor = System.Drawing.Color.Black
        Me.lbldatosre.Location = New System.Drawing.Point(35, -2)
        Me.lbldatosre.Name = "lbldatosre"
        Me.lbldatosre.Size = New System.Drawing.Size(181, 20)
        Me.lbldatosre.TabIndex = 176
        Me.lbldatosre.Text = "DATOS DE SOLICITUD"
        '
        'Grupo
        '
        Me.Grupo.BackColor = System.Drawing.Color.Transparent
        Me.Grupo.Controls.Add(Me.TxtNumeroEnsamble)
        Me.Grupo.Controls.Add(Me.DtpHoraManual)
        Me.Grupo.Controls.Add(Me.DTPFecha)
        Me.Grupo.Controls.Add(Me.LblHora)
        Me.Grupo.Controls.Add(Me.lbldatosre)
        Me.Grupo.Location = New System.Drawing.Point(9, 70)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(753, 65)
        Me.Grupo.TabIndex = 247
        Me.Grupo.TabStop = False
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(633, 19)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(97, 29)
        Me.TxtNumeroEnsamble.TabIndex = 185
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'DtpHoraManual
        '
        Me.DtpHoraManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpHoraManual.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpHoraManual.Location = New System.Drawing.Point(20, 72)
        Me.DtpHoraManual.Name = "DtpHoraManual"
        Me.DtpHoraManual.Size = New System.Drawing.Size(188, 35)
        Me.DtpHoraManual.TabIndex = 184
        Me.DtpHoraManual.Visible = False
        '
        'DTPFecha
        '
        Me.DTPFecha.AutoSize = True
        Me.DTPFecha.BackColor = System.Drawing.Color.Transparent
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.ForeColor = System.Drawing.Color.Black
        Me.DTPFecha.Location = New System.Drawing.Point(13, 22)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(169, 33)
        Me.DTPFecha.TabIndex = 182
        Me.DTPFecha.Text = "20/10/2017"
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.Black
        Me.LblHora.Location = New System.Drawing.Point(197, 22)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(205, 33)
        Me.LblHora.TabIndex = 181
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'CboDepartamento
        '
        Me.CboDepartamento.DisplayMember = "DepartamentoSolicitud"
        Me.CboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDepartamento.FormattingEnabled = True
        Me.CboDepartamento.Location = New System.Drawing.Point(123, 170)
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.Size = New System.Drawing.Size(211, 21)
        Me.CboDepartamento.TabIndex = 249
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 248
        Me.Label1.Text = "Departamento"
        '
        'DTPFechaRequerido
        '
        Me.DTPFechaRequerido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaRequerido.Location = New System.Drawing.Point(123, 197)
        Me.DTPFechaRequerido.Name = "DTPFechaRequerido"
        Me.DTPFechaRequerido.Size = New System.Drawing.Size(117, 20)
        Me.DTPFechaRequerido.TabIndex = 251
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 250
        Me.Label2.Text = "Fecha Requerido"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 252
        Me.Label3.Text = "Concepto"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(123, 253)
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConcepto.Size = New System.Drawing.Size(344, 56)
        Me.TxtConcepto.TabIndex = 253
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos"
        Me.TrueDBGridComponentes.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveNone
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(12, 325)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(617, 167)
        Me.TrueDBGridComponentes.TabIndex = 254
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(6, 14)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(114, 56)
        Me.Button7.TabIndex = 255
        Me.Button7.Text = "Grabar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button12.Location = New System.Drawing.Point(7, 74)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(114, 57)
        Me.Button12.TabIndex = 256
        Me.Button12.Text = "Imprimir"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button12.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnOrdenCompra)
        Me.GroupBox1.Controls.Add(Me.BtnAutorizar)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Location = New System.Drawing.Point(635, 151)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(127, 366)
        Me.GroupBox1.TabIndex = 257
        Me.GroupBox1.TabStop = False
        '
        'BtnOrdenCompra
        '
        Me.BtnOrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOrdenCompra.Image = CType(resources.GetObject("BtnOrdenCompra.Image"), System.Drawing.Image)
        Me.BtnOrdenCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOrdenCompra.Location = New System.Drawing.Point(6, 135)
        Me.BtnOrdenCompra.Name = "BtnOrdenCompra"
        Me.BtnOrdenCompra.Size = New System.Drawing.Size(114, 54)
        Me.BtnOrdenCompra.TabIndex = 264
        Me.BtnOrdenCompra.Text = "Orden Compra"
        Me.BtnOrdenCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnOrdenCompra.UseVisualStyleBackColor = True
        Me.BtnOrdenCompra.Visible = False
        '
        'BtnAutorizar
        '
        Me.BtnAutorizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAutorizar.Image = CType(resources.GetObject("BtnAutorizar.Image"), System.Drawing.Image)
        Me.BtnAutorizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAutorizar.Location = New System.Drawing.Point(6, 134)
        Me.BtnAutorizar.Name = "BtnAutorizar"
        Me.BtnAutorizar.Size = New System.Drawing.Size(114, 54)
        Me.BtnAutorizar.TabIndex = 258
        Me.BtnAutorizar.Text = "Autorizar"
        Me.BtnAutorizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAutorizar.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(6, 302)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(114, 55)
        Me.Button9.TabIndex = 257
        Me.Button9.Text = "Salir"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button3.Location = New System.Drawing.Point(9, 494)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(94, 23)
        Me.Button3.TabIndex = 258
        Me.Button3.Text = "Borrar Linea"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CboCodigoBodega
        '
        Me.CboCodigoBodega.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega.Caption = ""
        Me.CboCodigoBodega.CaptionHeight = 17
        Me.CboCodigoBodega.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega.ColumnCaptionHeight = 17
        Me.CboCodigoBodega.ColumnFooterHeight = 17
        Me.CboCodigoBodega.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCodigoBodega.ContentHeight = 15
        Me.CboCodigoBodega.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega.EditorHeight = 15
        Me.CboCodigoBodega.Images.Add(CType(resources.GetObject("CboCodigoBodega.Images"), System.Drawing.Image))
        Me.CboCodigoBodega.ItemHeight = 15
        Me.CboCodigoBodega.Location = New System.Drawing.Point(123, 226)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(121, 21)
        Me.CboCodigoBodega.TabIndex = 260
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(39, 226)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 259
        Me.Label11.Text = "Bodega Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(266, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Rubros"
        Me.Label4.Visible = False
        '
        'CboRubro
        '
        Me.CboRubro.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboRubro.Caption = ""
        Me.CboRubro.CaptionHeight = 17
        Me.CboRubro.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboRubro.ColumnCaptionHeight = 17
        Me.CboRubro.ColumnFooterHeight = 17
        Me.CboRubro.ContentHeight = 15
        Me.CboRubro.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboRubro.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboRubro.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboRubro.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboRubro.EditorHeight = 15
        Me.CboRubro.Images.Add(CType(resources.GetObject("CboRubro.Images"), System.Drawing.Image))
        Me.CboRubro.ItemHeight = 15
        Me.CboRubro.Location = New System.Drawing.Point(313, 197)
        Me.CboRubro.MatchEntryTimeout = CType(2000, Long)
        Me.CboRubro.MaxDropDownItems = CType(5, Short)
        Me.CboRubro.MaxLength = 32767
        Me.CboRubro.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboRubro.Name = "CboRubro"
        Me.CboRubro.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboRubro.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboRubro.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboRubro.Size = New System.Drawing.Size(170, 21)
        Me.CboRubro.TabIndex = 261
        Me.CboRubro.Visible = False
        Me.CboRubro.PropBag = resources.GetString("CboRubro.PropBag")
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Check3.png")
        Me.ImageList.Images.SetKeyName(1, "Uncheked3.png")
        '
        'CboGerencia
        '
        Me.CboGerencia.DisplayMember = "GerenciaSolicitud"
        Me.CboGerencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboGerencia.FormattingEnabled = True
        Me.CboGerencia.Location = New System.Drawing.Point(123, 143)
        Me.CboGerencia.Name = "CboGerencia"
        Me.CboGerencia.Size = New System.Drawing.Size(211, 21)
        Me.CboGerencia.TabIndex = 263
        '
        'C1Button4
        '
        Me.C1Button4.Image = CType(resources.GetObject("C1Button4.Image"), System.Drawing.Image)
        Me.C1Button4.Location = New System.Drawing.Point(456, 225)
        Me.C1Button4.Name = "C1Button4"
        Me.C1Button4.Size = New System.Drawing.Size(39, 24)
        Me.C1Button4.TabIndex = 266
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
        Me.CboProyecto.Location = New System.Drawing.Point(313, 226)
        Me.CboProyecto.MatchEntryTimeout = CType(2000, Long)
        Me.CboProyecto.MaxDropDownItems = CType(5, Short)
        Me.CboProyecto.MaxLength = 32767
        Me.CboProyecto.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboProyecto.Name = "CboProyecto"
        Me.CboProyecto.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboProyecto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboProyecto.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboProyecto.Size = New System.Drawing.Size(137, 21)
        Me.CboProyecto.TabIndex = 265
        Me.CboProyecto.PropBag = resources.GetString("CboProyecto.PropBag")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(263, 228)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 264
        Me.Label12.Text = "Proyecto"
        '
        'FrmNuevaSolicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 528)
        Me.Controls.Add(Me.C1Button4)
        Me.Controls.Add(Me.CboProyecto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CboGerencia)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CboRubro)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.TxtConcepto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTPFechaRequerido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboDepartamento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Grupo)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNuevaSolicitud"
        Me.Text = "Nueva Solicitud"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo.ResumeLayout(False)
        Me.Grupo.PerformLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbldatosre As System.Windows.Forms.Label
    Friend WithEvents Grupo As System.Windows.Forms.GroupBox
    Friend WithEvents DtpHoraManual As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFecha As System.Windows.Forms.Label
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents CboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaRequerido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CboRubro As C1.Win.C1List.C1Combo
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents CboGerencia As System.Windows.Forms.ComboBox
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents BtnAutorizar As System.Windows.Forms.Button
    Friend WithEvents BtnOrdenCompra As System.Windows.Forms.Button
    Friend WithEvents C1Button4 As C1.Win.C1Input.C1Button
    Friend WithEvents CboProyecto As C1.Win.C1List.C1Combo
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
