<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTransferencias
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransferencias))
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.CmdNuevo = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CboCodigoBodega2 = New C1.Win.C1List.C1Combo()
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CboTipoProducto = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtTotalCosto = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.C1Button2 = New C1.Win.C1Input.C1Button()
        Me.C1Button3 = New C1.Win.C1Input.C1Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlHerramientas = New System.Windows.Forms.Panel()
        Me.btnBorrarLinea = New System.Windows.Forms.Button()
        Me.btnEscanear = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.pnlGridContenedor = New System.Windows.Forms.Panel()
        Me.lblListado = New System.Windows.Forms.Label()
        Me.pnlTotal = New System.Windows.Forms.Panel()
        Me.lblTotalTitulo = New System.Windows.Forms.Label()
        Me.grpObservaciones = New System.Windows.Forms.GroupBox()
        Me.grpBodegas = New System.Windows.Forms.GroupBox()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.lblDestino = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoBodega2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHerramientas.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.pnlGridContenedor.SuspendLayout()
        Me.pnlTotal.SuspendLayout()
        Me.grpObservaciones.SuspendLayout()
        Me.grpBodegas.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(886, 293)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 96
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(889, 367)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 97
        Me.ButtonBorrar.Tag = "26"
        Me.ButtonBorrar.Text = "Anular"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(889, 220)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 95
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(889, 542)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 98
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(89, 55)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 100
        Me.PictureBox2.TabStop = False
        '
        'CboCodigoBodega2
        '
        Me.CboCodigoBodega2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboCodigoBodega2.Caption = ""
        Me.CboCodigoBodega2.CaptionHeight = 17
        Me.CboCodigoBodega2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega2.ColumnCaptionHeight = 17
        Me.CboCodigoBodega2.ColumnFooterHeight = 17
        Me.CboCodigoBodega2.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCodigoBodega2.ContentHeight = 15
        Me.CboCodigoBodega2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega2.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoBodega2.DropDownWidth = 300
        Me.CboCodigoBodega2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega2.EditorHeight = 15
        Me.CboCodigoBodega2.Images.Add(CType(resources.GetObject("CboCodigoBodega2.Images"), System.Drawing.Image))
        Me.CboCodigoBodega2.ItemHeight = 15
        Me.CboCodigoBodega2.Location = New System.Drawing.Point(621, 28)
        Me.CboCodigoBodega2.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega2.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega2.MaxLength = 32767
        Me.CboCodigoBodega2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega2.Name = "CboCodigoBodega2"
        Me.CboCodigoBodega2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega2.Size = New System.Drawing.Size(121, 21)
        Me.CboCodigoBodega2.TabIndex = 185
        Me.CboCodigoBodega2.PropBag = resources.GetString("CboCodigoBodega2.PropBag")
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
        Me.CboCodigoBodega.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoBodega.DropDownWidth = 300
        Me.CboCodigoBodega.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega.EditorHeight = 15
        Me.CboCodigoBodega.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.CboCodigoBodega.Images.Add(CType(resources.GetObject("CboCodigoBodega.Images"), System.Drawing.Image))
        Me.CboCodigoBodega.ItemHeight = 15
        Me.CboCodigoBodega.Location = New System.Drawing.Point(121, 24)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(121, 21)
        Me.CboCodigoBodega.TabIndex = 183
        Me.CboCodigoBodega.Tag = "30"
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.CboTipoProducto)
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DTPFecha)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(862, 48)
        Me.GroupBox2.TabIndex = 160
        Me.GroupBox2.TabStop = False
        '
        'CboTipoProducto
        '
        Me.CboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CboTipoProducto.Enabled = False
        Me.CboTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.CboTipoProducto.FormattingEnabled = True
        Me.CboTipoProducto.Items.AddRange(New Object() {"Transferencia Recibida", "Transferencia Enviada"})
        Me.CboTipoProducto.Location = New System.Drawing.Point(43, 13)
        Me.CboTipoProducto.Name = "CboTipoProducto"
        Me.CboTipoProducto.Size = New System.Drawing.Size(190, 25)
        Me.CboTipoProducto.TabIndex = 128
        Me.CboTipoProducto.Text = "Transferencia Enviada"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(812, 10)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 32)
        Me.Button6.TabIndex = 127
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNumeroEnsamble.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TxtNumeroEnsamble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(700, 16)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(110, 24)
        Me.TxtNumeroEnsamble.TabIndex = 122
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        Me.TxtNumeroEnsamble.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(632, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(337, 16)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 24)
        Me.DTPFecha.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(294, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tipo"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(889, 440)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 67)
        Me.Button1.TabIndex = 166
        Me.Button1.Tag = "27"
        Me.Button1.Text = "Imprimir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtObservaciones.Location = New System.Drawing.Point(6, 20)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(843, 41)
        Me.TxtObservaciones.TabIndex = 0
        '
        'TxtTotalCosto
        '
        Me.TxtTotalCosto.AcceptsReturn = True
        Me.TxtTotalCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotalCosto.BackColor = System.Drawing.SystemColors.Control
        Me.TxtTotalCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalCosto.Enabled = False
        Me.TxtTotalCosto.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.TxtTotalCosto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.TxtTotalCosto.Location = New System.Drawing.Point(708, 12)
        Me.TxtTotalCosto.Name = "TxtTotalCosto"
        Me.TxtTotalCosto.Size = New System.Drawing.Size(130, 27)
        Me.TxtTotalCosto.TabIndex = 200
        Me.TxtTotalCosto.Text = "0.00"
        Me.TxtTotalCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(688, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(150, 32)
        Me.Button4.TabIndex = 201
        Me.Button4.Text = "Borrar Linea"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'C1Button2
        '
        Me.C1Button2.Image = CType(resources.GetObject("C1Button2.Image"), System.Drawing.Image)
        Me.C1Button2.Location = New System.Drawing.Point(292, 25)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(39, 24)
        Me.C1Button2.TabIndex = 212
        Me.C1Button2.UseVisualStyleBackColor = True
        '
        'C1Button3
        '
        Me.C1Button3.Image = CType(resources.GetObject("C1Button3.Image"), System.Drawing.Image)
        Me.C1Button3.Location = New System.Drawing.Point(337, 25)
        Me.C1Button3.Name = "C1Button3"
        Me.C1Button3.Size = New System.Drawing.Size(39, 24)
        Me.C1Button3.TabIndex = 213
        Me.C1Button3.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(-4, -1)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(999, 64)
        Me.lblTitulo.TabIndex = 214
        Me.lblTitulo.Text = "TRANSFERENCIAS DE BODEGAS"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlHerramientas
        '
        Me.pnlHerramientas.Controls.Add(Me.Button4)
        Me.pnlHerramientas.Controls.Add(Me.btnBorrarLinea)
        Me.pnlHerramientas.Controls.Add(Me.btnEscanear)
        Me.pnlHerramientas.Controls.Add(Me.btnAgregar)
        Me.pnlHerramientas.Location = New System.Drawing.Point(5, 172)
        Me.pnlHerramientas.Name = "pnlHerramientas"
        Me.pnlHerramientas.Size = New System.Drawing.Size(859, 44)
        Me.pnlHerramientas.TabIndex = 215
        '
        'btnBorrarLinea
        '
        Me.btnBorrarLinea.BackColor = System.Drawing.Color.White
        Me.btnBorrarLinea.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnBorrarLinea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnBorrarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrarLinea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBorrarLinea.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnBorrarLinea.Location = New System.Drawing.Point(410, 8)
        Me.btnBorrarLinea.Name = "btnBorrarLinea"
        Me.btnBorrarLinea.Size = New System.Drawing.Size(150, 30)
        Me.btnBorrarLinea.TabIndex = 0
        Me.btnBorrarLinea.TabStop = False
        Me.btnBorrarLinea.Text = "Borrar línea"
        Me.btnBorrarLinea.UseVisualStyleBackColor = False
        Me.btnBorrarLinea.Visible = False
        '
        'btnEscanear
        '
        Me.btnEscanear.BackColor = System.Drawing.Color.White
        Me.btnEscanear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnEscanear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnEscanear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEscanear.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEscanear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnEscanear.Location = New System.Drawing.Point(20, 6)
        Me.btnEscanear.Name = "btnEscanear"
        Me.btnEscanear.Size = New System.Drawing.Size(130, 32)
        Me.btnEscanear.TabIndex = 0
        Me.btnEscanear.TabStop = False
        Me.btnEscanear.Text = "Escanear"
        Me.btnEscanear.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.White
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnAgregar.Location = New System.Drawing.Point(160, 6)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(150, 32)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.TabStop = False
        Me.btnAgregar.Text = "+  Agregar línea"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AllowDelete = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(0, 31)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(818, 229)
        Me.TrueDBGridComponentes.TabIndex = 165
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlGrid.Controls.Add(Me.pnlGridContenedor)
        Me.pnlGrid.Location = New System.Drawing.Point(6, 215)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Padding = New System.Windows.Forms.Padding(20, 4, 20, 4)
        Me.pnlGrid.Size = New System.Drawing.Size(858, 271)
        Me.pnlGrid.TabIndex = 216
        '
        'pnlGridContenedor
        '
        Me.pnlGridContenedor.BackColor = System.Drawing.Color.White
        Me.pnlGridContenedor.Controls.Add(Me.lblListado)
        Me.pnlGridContenedor.Controls.Add(Me.TrueDBGridComponentes)
        Me.pnlGridContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGridContenedor.Location = New System.Drawing.Point(20, 4)
        Me.pnlGridContenedor.Name = "pnlGridContenedor"
        Me.pnlGridContenedor.Size = New System.Drawing.Size(818, 263)
        Me.pnlGridContenedor.TabIndex = 0
        '
        'lblListado
        '
        Me.lblListado.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblListado.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblListado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblListado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblListado.Location = New System.Drawing.Point(0, 0)
        Me.lblListado.Name = "lblListado"
        Me.lblListado.Size = New System.Drawing.Size(818, 28)
        Me.lblListado.TabIndex = 0
        Me.lblListado.Text = "LISTADO DE PRODUCTOS"
        Me.lblListado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTotal
        '
        Me.pnlTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlTotal.Controls.Add(Me.lblTotalTitulo)
        Me.pnlTotal.Controls.Add(Me.TxtTotalCosto)
        Me.pnlTotal.Location = New System.Drawing.Point(5, 490)
        Me.pnlTotal.Name = "pnlTotal"
        Me.pnlTotal.Size = New System.Drawing.Size(858, 48)
        Me.pnlTotal.TabIndex = 217
        '
        'lblTotalTitulo
        '
        Me.lblTotalTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblTotalTitulo.Location = New System.Drawing.Point(475, 9)
        Me.lblTotalTitulo.Name = "lblTotalTitulo"
        Me.lblTotalTitulo.Size = New System.Drawing.Size(140, 30)
        Me.lblTotalTitulo.TabIndex = 0
        Me.lblTotalTitulo.Text = "TOTAL COSTO"
        Me.lblTotalTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpObservaciones
        '
        Me.grpObservaciones.Controls.Add(Me.TxtObservaciones)
        Me.grpObservaciones.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.grpObservaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.grpObservaciones.Location = New System.Drawing.Point(6, 542)
        Me.grpObservaciones.Name = "grpObservaciones"
        Me.grpObservaciones.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.grpObservaciones.Size = New System.Drawing.Size(862, 74)
        Me.grpObservaciones.TabIndex = 218
        Me.grpObservaciones.TabStop = False
        Me.grpObservaciones.Text = "Observaciones"
        '
        'grpBodegas
        '
        Me.grpBodegas.Controls.Add(Me.CboCodigoBodega2)
        Me.grpBodegas.Controls.Add(Me.lblOrigen)
        Me.grpBodegas.Controls.Add(Me.lblDestino)
        Me.grpBodegas.Controls.Add(Me.CboCodigoBodega)
        Me.grpBodegas.Controls.Add(Me.C1Button2)
        Me.grpBodegas.Controls.Add(Me.C1Button3)
        Me.grpBodegas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.grpBodegas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.grpBodegas.Location = New System.Drawing.Point(6, 108)
        Me.grpBodegas.Name = "grpBodegas"
        Me.grpBodegas.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.grpBodegas.Size = New System.Drawing.Size(858, 62)
        Me.grpBodegas.TabIndex = 219
        Me.grpBodegas.TabStop = False
        Me.grpBodegas.Text = "Bodegas de Transferencias"
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblOrigen.Location = New System.Drawing.Point(20, 30)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(86, 15)
        Me.lblOrigen.TabIndex = 0
        Me.lblOrigen.Text = "Bodega Origen"
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lblDestino.Location = New System.Drawing.Point(525, 30)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(90, 15)
        Me.lblDestino.TabIndex = 2
        Me.lblDestino.Text = "Bodega Destino"
        '
        'FrmTransferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 618)
        Me.Controls.Add(Me.grpBodegas)
        Me.Controls.Add(Me.grpObservaciones)
        Me.Controls.Add(Me.pnlTotal)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.pnlHerramientas)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.PictureBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTransferencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBodeguero"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoBodega2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHerramientas.ResumeLayout(False)
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGridContenedor.ResumeLayout(False)
        Me.pnlTotal.ResumeLayout(False)
        Me.pnlTotal.PerformLayout()
        Me.grpObservaciones.ResumeLayout(False)
        Me.grpObservaciones.PerformLayout()
        Me.grpBodegas.ResumeLayout(False)
        Me.grpBodegas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CboCodigoBodega2 As C1.Win.C1List.C1Combo
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents TxtTotalCosto As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button3 As C1.Win.C1Input.C1Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlHerramientas As Panel
    Friend WithEvents btnEscanear As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlGrid As Panel
    Friend WithEvents pnlGridContenedor As Panel
    Friend WithEvents btnBorrarLinea As Button
    Friend WithEvents lblListado As Label
    Friend WithEvents pnlTotal As Panel
    Friend WithEvents lblTotalTitulo As Label
    Friend WithEvents grpObservaciones As GroupBox
    Friend WithEvents grpBodegas As GroupBox
    Friend WithEvents lblOrigen As Label
    Friend WithEvents lblDestino As Label
End Class
