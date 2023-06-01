<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuirofano
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQuirofano))
        Me.ImgFoto = New System.Windows.Forms.PictureBox
        Me.BtnConsultar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtLetra = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnSalida = New System.Windows.Forms.Button
        Me.BtnIngreso = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.DTPFecha = New System.Windows.Forms.Label
        Me.LblHora = New System.Windows.Forms.Label
        Me.lbldatosre = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblFecha2 = New System.Windows.Forms.Label
        Me.LblHora2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtDireccionEmergencia = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtTelefonoEmergencia = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtNombreEmergencia = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.CmdCerrar = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Generales = New System.Windows.Forms.TabPage
        Me.Personal = New System.Windows.Forms.TabPage
        Me.CboTipoCirugia = New C1.Win.C1List.C1Combo
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTecnico = New System.Windows.Forms.TextBox
        Me.txtNombreTecnico = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtIdDoctorAyudante = New System.Windows.Forms.TextBox
        Me.txtNombreAyudante = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtIdAnestecista = New System.Windows.Forms.TextBox
        Me.txtNombreAnestecista = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtIdCirujano = New System.Windows.Forms.TextBox
        Me.txtNombreCirujano = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtProntuario = New System.Windows.Forms.TextBox
        Me.TxtDiagnostico = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmdGuardar = New System.Windows.Forms.Button
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Generales.SuspendLayout()
        Me.Personal.SuspendLayout()
        CType(Me.CboTipoCirugia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImgFoto
        '
        Me.ImgFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImgFoto.Location = New System.Drawing.Point(31, 22)
        Me.ImgFoto.Name = "ImgFoto"
        Me.ImgFoto.Size = New System.Drawing.Size(160, 178)
        Me.ImgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgFoto.TabIndex = 240
        Me.ImgFoto.TabStop = False
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Image = CType(resources.GetObject("BtnConsultar.Image"), System.Drawing.Image)
        Me.BtnConsultar.Location = New System.Drawing.Point(239, 14)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(29, 30)
        Me.BtnConsultar.TabIndex = 239
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 232
        Me.Label1.Text = "Numero Expediente:"
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(121, 73)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(218, 20)
        Me.TxtApellidos.TabIndex = 237
        '
        'TxtLetra
        '
        Me.TxtLetra.Location = New System.Drawing.Point(121, 19)
        Me.TxtLetra.Name = "TxtLetra"
        Me.TxtLetra.Size = New System.Drawing.Size(40, 20)
        Me.TxtLetra.TabIndex = 233
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(67, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 238
        Me.Label3.Text = "Apellidos:"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(167, 19)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(69, 20)
        Me.TxtCodigo.TabIndex = 234
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(121, 48)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(218, 20)
        Me.TxtNombres.TabIndex = 235
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 236
        Me.Label2.Text = "Nombres:"
        '
        'BtnSalida
        '
        Me.BtnSalida.Image = CType(resources.GetObject("BtnSalida.Image"), System.Drawing.Image)
        Me.BtnSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalida.Location = New System.Drawing.Point(331, 5)
        Me.BtnSalida.Name = "BtnSalida"
        Me.BtnSalida.Size = New System.Drawing.Size(85, 39)
        Me.BtnSalida.TabIndex = 242
        Me.BtnSalida.Text = "Salida"
        Me.BtnSalida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalida.UseVisualStyleBackColor = True
        '
        'BtnIngreso
        '
        Me.BtnIngreso.Image = CType(resources.GetObject("BtnIngreso.Image"), System.Drawing.Image)
        Me.BtnIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIngreso.Location = New System.Drawing.Point(331, 7)
        Me.BtnIngreso.Name = "BtnIngreso"
        Me.BtnIngreso.Size = New System.Drawing.Size(85, 37)
        Me.BtnIngreso.TabIndex = 241
        Me.BtnIngreso.Text = "Ingreso"
        Me.BtnIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnIngreso.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.DTPFecha)
        Me.GroupBox9.Controls.Add(Me.LblHora)
        Me.GroupBox9.Controls.Add(Me.lbldatosre)
        Me.GroupBox9.Location = New System.Drawing.Point(676, 12)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(405, 91)
        Me.GroupBox9.TabIndex = 243
        Me.GroupBox9.TabStop = False
        '
        'DTPFecha
        '
        Me.DTPFecha.AutoSize = True
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.ForeColor = System.Drawing.Color.Green
        Me.DTPFecha.Location = New System.Drawing.Point(25, 38)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(169, 33)
        Me.DTPFecha.TabIndex = 182
        Me.DTPFecha.Text = "20/10/2017"
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.Green
        Me.LblHora.Location = New System.Drawing.Point(194, 38)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(205, 33)
        Me.LblHora.TabIndex = 181
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'lbldatosre
        '
        Me.lbldatosre.AutoSize = True
        Me.lbldatosre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatosre.ForeColor = System.Drawing.Color.Green
        Me.lbldatosre.Location = New System.Drawing.Point(114, -3)
        Me.lbldatosre.Name = "lbldatosre"
        Me.lbldatosre.Size = New System.Drawing.Size(200, 20)
        Me.lbldatosre.TabIndex = 176
        Me.lbldatosre.Text = "REGISTRO DE INGRESO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblFecha2)
        Me.GroupBox1.Controls.Add(Me.LblHora2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(676, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 91)
        Me.GroupBox1.TabIndex = 244
        Me.GroupBox1.TabStop = False
        '
        'LblFecha2
        '
        Me.LblFecha2.AutoSize = True
        Me.LblFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha2.ForeColor = System.Drawing.Color.Navy
        Me.LblFecha2.Location = New System.Drawing.Point(25, 38)
        Me.LblFecha2.Name = "LblFecha2"
        Me.LblFecha2.Size = New System.Drawing.Size(169, 33)
        Me.LblFecha2.TabIndex = 182
        Me.LblFecha2.Text = "20/10/2017"
        '
        'LblHora2
        '
        Me.LblHora2.AutoSize = True
        Me.LblHora2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora2.ForeColor = System.Drawing.Color.Navy
        Me.LblHora2.Location = New System.Drawing.Point(194, 38)
        Me.LblHora2.Name = "LblHora2"
        Me.LblHora2.Size = New System.Drawing.Size(205, 33)
        Me.LblHora2.TabIndex = 181
        Me.LblHora2.Text = "10:23:55 p.m."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(114, -3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 20)
        Me.Label6.TabIndex = 176
        Me.Label6.Text = "REGISTRO DE SALIDA"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtDireccionEmergencia)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TxtTelefonoEmergencia)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.TxtNombreEmergencia)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 116)
        Me.GroupBox2.TabIndex = 245
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Caso de Emergencia"
        '
        'TxtDireccionEmergencia
        '
        Me.TxtDireccionEmergencia.Location = New System.Drawing.Point(67, 64)
        Me.TxtDireccionEmergencia.Multiline = True
        Me.TxtDireccionEmergencia.Name = "TxtDireccionEmergencia"
        Me.TxtDireccionEmergencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDireccionEmergencia.Size = New System.Drawing.Size(218, 46)
        Me.TxtDireccionEmergencia.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 208
        Me.Label19.Text = "Direccion;"
        '
        'TxtTelefonoEmergencia
        '
        Me.TxtTelefonoEmergencia.Location = New System.Drawing.Point(67, 42)
        Me.TxtTelefonoEmergencia.Name = "TxtTelefonoEmergencia"
        Me.TxtTelefonoEmergencia.Size = New System.Drawing.Size(168, 20)
        Me.TxtTelefonoEmergencia.TabIndex = 19
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 206
        Me.Label18.Text = "Telefono;"
        '
        'TxtNombreEmergencia
        '
        Me.TxtNombreEmergencia.Location = New System.Drawing.Point(67, 20)
        Me.TxtNombreEmergencia.Name = "TxtNombreEmergencia"
        Me.TxtNombreEmergencia.Size = New System.Drawing.Size(218, 20)
        Me.TxtNombreEmergencia.TabIndex = 18
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Nombres:"
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Image = CType(resources.GetObject("CmdCerrar.Image"), System.Drawing.Image)
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.Location = New System.Drawing.Point(1006, 330)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(75, 34)
        Me.CmdCerrar.TabIndex = 246
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Generales)
        Me.TabControl1.Controls.Add(Me.Personal)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(197, 22)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(473, 285)
        Me.TabControl1.TabIndex = 247
        '
        'Generales
        '
        Me.Generales.Controls.Add(Me.Label1)
        Me.Generales.Controls.Add(Me.Label2)
        Me.Generales.Controls.Add(Me.GroupBox2)
        Me.Generales.Controls.Add(Me.TxtNombres)
        Me.Generales.Controls.Add(Me.BtnIngreso)
        Me.Generales.Controls.Add(Me.TxtCodigo)
        Me.Generales.Controls.Add(Me.Label3)
        Me.Generales.Controls.Add(Me.TxtLetra)
        Me.Generales.Controls.Add(Me.BtnSalida)
        Me.Generales.Controls.Add(Me.TxtApellidos)
        Me.Generales.Controls.Add(Me.BtnConsultar)
        Me.Generales.Location = New System.Drawing.Point(4, 22)
        Me.Generales.Name = "Generales"
        Me.Generales.Padding = New System.Windows.Forms.Padding(3)
        Me.Generales.Size = New System.Drawing.Size(465, 259)
        Me.Generales.TabIndex = 0
        Me.Generales.Text = "Paciente"
        Me.Generales.UseVisualStyleBackColor = True
        '
        'Personal
        '
        Me.Personal.Controls.Add(Me.CboTipoCirugia)
        Me.Personal.Controls.Add(Me.Label10)
        Me.Personal.Controls.Add(Me.txtTecnico)
        Me.Personal.Controls.Add(Me.txtNombreTecnico)
        Me.Personal.Controls.Add(Me.Button4)
        Me.Personal.Controls.Add(Me.Label9)
        Me.Personal.Controls.Add(Me.txtIdDoctorAyudante)
        Me.Personal.Controls.Add(Me.txtNombreAyudante)
        Me.Personal.Controls.Add(Me.Button3)
        Me.Personal.Controls.Add(Me.Label7)
        Me.Personal.Controls.Add(Me.txtIdAnestecista)
        Me.Personal.Controls.Add(Me.txtNombreAnestecista)
        Me.Personal.Controls.Add(Me.Button2)
        Me.Personal.Controls.Add(Me.Label5)
        Me.Personal.Controls.Add(Me.txtIdCirujano)
        Me.Personal.Controls.Add(Me.txtNombreCirujano)
        Me.Personal.Controls.Add(Me.Button1)
        Me.Personal.Controls.Add(Me.Label8)
        Me.Personal.Location = New System.Drawing.Point(4, 22)
        Me.Personal.Name = "Personal"
        Me.Personal.Padding = New System.Windows.Forms.Padding(3)
        Me.Personal.Size = New System.Drawing.Size(465, 259)
        Me.Personal.TabIndex = 1
        Me.Personal.Text = "Medicos"
        Me.Personal.UseVisualStyleBackColor = True
        '
        'CboTipoCirugia
        '
        Me.CboTipoCirugia.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTipoCirugia.Caption = ""
        Me.CboTipoCirugia.CaptionHeight = 17
        Me.CboTipoCirugia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipoCirugia.ColumnCaptionHeight = 17
        Me.CboTipoCirugia.ColumnFooterHeight = 17
        Me.CboTipoCirugia.ContentHeight = 15
        Me.CboTipoCirugia.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipoCirugia.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboTipoCirugia.DropDownWidth = 500
        Me.CboTipoCirugia.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipoCirugia.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoCirugia.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipoCirugia.EditorHeight = 15
        Me.CboTipoCirugia.Images.Add(CType(resources.GetObject("CboTipoCirugia.Images"), System.Drawing.Image))
        Me.CboTipoCirugia.ItemHeight = 15
        Me.CboTipoCirugia.Location = New System.Drawing.Point(84, 13)
        Me.CboTipoCirugia.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipoCirugia.MaxDropDownItems = CType(5, Short)
        Me.CboTipoCirugia.MaxLength = 32767
        Me.CboTipoCirugia.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipoCirugia.Name = "CboTipoCirugia"
        Me.CboTipoCirugia.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTipoCirugia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTipoCirugia.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipoCirugia.Size = New System.Drawing.Size(158, 21)
        Me.CboTipoCirugia.TabIndex = 360
        Me.CboTipoCirugia.PropBag = resources.GetString("CboTipoCirugia.PropBag")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 359
        Me.Label10.Text = "Tipo Cirugia"
        '
        'txtTecnico
        '
        Me.txtTecnico.Location = New System.Drawing.Point(339, 125)
        Me.txtTecnico.Name = "txtTecnico"
        Me.txtTecnico.Size = New System.Drawing.Size(77, 20)
        Me.txtTecnico.TabIndex = 358
        '
        'txtNombreTecnico
        '
        Me.txtNombreTecnico.Enabled = False
        Me.txtNombreTecnico.Location = New System.Drawing.Point(84, 126)
        Me.txtNombreTecnico.Name = "txtNombreTecnico"
        Me.txtNombreTecnico.Size = New System.Drawing.Size(213, 20)
        Me.txtNombreTecnico.TabIndex = 357
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(303, 123)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(29, 30)
        Me.Button4.TabIndex = 356
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 355
        Me.Label9.Text = "Tecnico"
        '
        'txtIdDoctorAyudante
        '
        Me.txtIdDoctorAyudante.Location = New System.Drawing.Point(339, 95)
        Me.txtIdDoctorAyudante.Name = "txtIdDoctorAyudante"
        Me.txtIdDoctorAyudante.Size = New System.Drawing.Size(77, 20)
        Me.txtIdDoctorAyudante.TabIndex = 354
        '
        'txtNombreAyudante
        '
        Me.txtNombreAyudante.Enabled = False
        Me.txtNombreAyudante.Location = New System.Drawing.Point(84, 96)
        Me.txtNombreAyudante.Name = "txtNombreAyudante"
        Me.txtNombreAyudante.Size = New System.Drawing.Size(213, 20)
        Me.txtNombreAyudante.TabIndex = 353
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(303, 93)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 30)
        Me.Button3.TabIndex = 352
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 351
        Me.Label7.Text = "Ayudante"
        '
        'txtIdAnestecista
        '
        Me.txtIdAnestecista.Location = New System.Drawing.Point(339, 65)
        Me.txtIdAnestecista.Name = "txtIdAnestecista"
        Me.txtIdAnestecista.Size = New System.Drawing.Size(77, 20)
        Me.txtIdAnestecista.TabIndex = 350
        '
        'txtNombreAnestecista
        '
        Me.txtNombreAnestecista.Enabled = False
        Me.txtNombreAnestecista.Location = New System.Drawing.Point(84, 66)
        Me.txtNombreAnestecista.Name = "txtNombreAnestecista"
        Me.txtNombreAnestecista.Size = New System.Drawing.Size(213, 20)
        Me.txtNombreAnestecista.TabIndex = 349
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(303, 63)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 30)
        Me.Button2.TabIndex = 348
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 347
        Me.Label5.Text = "Anestecista"
        '
        'txtIdCirujano
        '
        Me.txtIdCirujano.Location = New System.Drawing.Point(339, 39)
        Me.txtIdCirujano.Name = "txtIdCirujano"
        Me.txtIdCirujano.Size = New System.Drawing.Size(77, 20)
        Me.txtIdCirujano.TabIndex = 346
        '
        'txtNombreCirujano
        '
        Me.txtNombreCirujano.Enabled = False
        Me.txtNombreCirujano.Location = New System.Drawing.Point(84, 40)
        Me.txtNombreCirujano.Name = "txtNombreCirujano"
        Me.txtNombreCirujano.Size = New System.Drawing.Size(213, 20)
        Me.txtNombreCirujano.TabIndex = 345
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(303, 35)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 30)
        Me.Button1.TabIndex = 344
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 343
        Me.Label8.Text = "Cirujano"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.txtProntuario)
        Me.TabPage1.Controls.Add(Me.TxtDiagnostico)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(465, 259)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Consulta"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 114)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 251
        Me.Label15.Text = "Diagnostico"
        '
        'txtProntuario
        '
        Me.txtProntuario.Location = New System.Drawing.Point(6, 22)
        Me.txtProntuario.Multiline = True
        Me.txtProntuario.Name = "txtProntuario"
        Me.txtProntuario.Size = New System.Drawing.Size(419, 78)
        Me.txtProntuario.TabIndex = 248
        '
        'TxtDiagnostico
        '
        Me.TxtDiagnostico.Location = New System.Drawing.Point(9, 130)
        Me.TxtDiagnostico.Multiline = True
        Me.TxtDiagnostico.Name = "TxtDiagnostico"
        Me.TxtDiagnostico.Size = New System.Drawing.Size(416, 78)
        Me.TxtDiagnostico.TabIndex = 250
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 249
        Me.Label13.Text = "Prontuario"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CmdGuardar)
        Me.TabPage2.Controls.Add(Me.TrueDBGridComponentes)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.Button6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(465, 259)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Medicamentos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos"
        Me.TrueDBGridComponentes.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveNone
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(8, 6)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(449, 167)
        Me.TrueDBGridComponentes.TabIndex = 249
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(380, 179)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 34)
        Me.Button5.TabIndex = 248
        Me.Button5.Text = "Quitar"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(299, 179)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 34)
        Me.Button6.TabIndex = 247
        Me.Button6.Text = "Agregar"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(826, 208)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(164, 110)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 254
        Me.PictureBox3.TabStop = False
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Image = CType(resources.GetObject("CmdGuardar.Image"), System.Drawing.Image)
        Me.CmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdGuardar.Location = New System.Drawing.Point(8, 179)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(82, 34)
        Me.CmdGuardar.TabIndex = 362
        Me.CmdGuardar.Text = "Facturar"
        Me.CmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'FrmQuirofano
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 376)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.ImgFoto)
        Me.Name = "FrmQuirofano"
        Me.Text = "FrmQuirofano"
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Generales.ResumeLayout(False)
        Me.Generales.PerformLayout()
        Me.Personal.ResumeLayout(False)
        Me.Personal.PerformLayout()
        CType(Me.CboTipoCirugia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImgFoto As System.Windows.Forms.PictureBox
    Friend WithEvents BtnConsultar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtLetra As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnSalida As System.Windows.Forms.Button
    Friend WithEvents BtnIngreso As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFecha As System.Windows.Forms.Label
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents lbldatosre As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblFecha2 As System.Windows.Forms.Label
    Friend WithEvents LblHora2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDireccionEmergencia As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefonoEmergencia As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreEmergencia As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Generales As System.Windows.Forms.TabPage
    Friend WithEvents Personal As System.Windows.Forms.TabPage
    Friend WithEvents txtNombreCirujano As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIdCirujano As System.Windows.Forms.TextBox
    Friend WithEvents txtIdAnestecista As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreAnestecista As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTecnico As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreTecnico As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtIdDoctorAyudante As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreAyudante As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CboTipoCirugia As C1.Win.C1List.C1Combo
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtProntuario As System.Windows.Forms.TextBox
    Friend WithEvents TxtDiagnostico As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
End Class
