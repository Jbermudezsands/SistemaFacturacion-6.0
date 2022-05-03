<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExpediente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExpediente))
        Me.CmdCerrar = New System.Windows.Forms.Button
        Me.CmdGuardar = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ImgFoto = New System.Windows.Forms.PictureBox
        Me.CboComarca = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.DtpFechaNacimiento = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.CboUnidadSalud = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtDireccionEmergencia = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtTelefonoEmergencia = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtNombreEmergencia = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.CboOcupacion = New System.Windows.Forms.ComboBox
        Me.CboMunicipio = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.CboLocalidad = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.CboEscolaridad = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.CboEstadoCivil = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CboSexo = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtNombreMadre = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtNombrePadre = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtEdad = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmdQuitarFoto = New System.Windows.Forms.Button
        Me.CmdAgregarFoto = New System.Windows.Forms.Button
        Me.BtnConsultar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtLetra = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Button6 = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Image = CType(resources.GetObject("CmdCerrar.Image"), System.Drawing.Image)
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCerrar.Location = New System.Drawing.Point(830, 375)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(75, 34)
        Me.CmdCerrar.TabIndex = 25
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Image = CType(resources.GetObject("CmdGuardar.Image"), System.Drawing.Image)
        Me.CmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdGuardar.Location = New System.Drawing.Point(580, 375)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(75, 34)
        Me.CmdGuardar.TabIndex = 23
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = CType(resources.GetObject("CmdEliminar.Image"), System.Drawing.Image)
        Me.CmdEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEliminar.Location = New System.Drawing.Point(740, 375)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(75, 34)
        Me.CmdEliminar.TabIndex = 24
        Me.CmdEliminar.Text = "Eliminar"
        Me.CmdEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(892, 356)
        Me.TabControl1.TabIndex = 172
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(884, 330)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ImgFoto)
        Me.GroupBox1.Controls.Add(Me.CboComarca)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.DtpFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.CboUnidadSalud)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.DtpFecha)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.CboOcupacion)
        Me.GroupBox1.Controls.Add(Me.CboMunicipio)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.CboLocalidad)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.CboEscolaridad)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.CboEstadoCivil)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CboSexo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TxtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtTelefono)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtNombreMadre)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtNombrePadre)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtEdad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CmdQuitarFoto)
        Me.GroupBox1.Controls.Add(Me.CmdAgregarFoto)
        Me.GroupBox1.Controls.Add(Me.BtnConsultar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtApellidos)
        Me.GroupBox1.Controls.Add(Me.TxtLetra)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtCodigo)
        Me.GroupBox1.Controls.Add(Me.TxtNombres)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 318)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "  "
        '
        'ImgFoto
        '
        Me.ImgFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImgFoto.Location = New System.Drawing.Point(15, 19)
        Me.ImgFoto.Name = "ImgFoto"
        Me.ImgFoto.Size = New System.Drawing.Size(160, 178)
        Me.ImgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgFoto.TabIndex = 231
        Me.ImgFoto.TabStop = False
        '
        'CboComarca
        '
        Me.CboComarca.DisplayMember = "Nombre_Municipio"
        Me.CboComarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboComarca.FormattingEnabled = True
        Me.CboComarca.Location = New System.Drawing.Point(620, 167)
        Me.CboComarca.Name = "CboComarca"
        Me.CboComarca.Size = New System.Drawing.Size(139, 21)
        Me.CboComarca.TabIndex = 230
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(563, 169)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 229
        Me.Label21.Text = "Comarca:"
        '
        'DtpFechaNacimiento
        '
        Me.DtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaNacimiento.Location = New System.Drawing.Point(285, 96)
        Me.DtpFechaNacimiento.Name = "DtpFechaNacimiento"
        Me.DtpFechaNacimiento.Size = New System.Drawing.Size(123, 20)
        Me.DtpFechaNacimiento.TabIndex = 227
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(186, 100)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 228
        Me.Label20.Text = "Fecha Nacimiento:"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(438, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 28)
        Me.Button1.TabIndex = 226
        Me.Button1.Text = "Generar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CboUnidadSalud
        '
        Me.CboUnidadSalud.FormattingEnabled = True
        Me.CboUnidadSalud.Location = New System.Drawing.Point(620, 45)
        Me.CboUnidadSalud.Name = "CboUnidadSalud"
        Me.CboUnidadSalud.Size = New System.Drawing.Size(168, 21)
        Me.CboUnidadSalud.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtDireccionEmergencia)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TxtTelefonoEmergencia)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.TxtNombreEmergencia)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(541, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 116)
        Me.GroupBox2.TabIndex = 225
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
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(285, 119)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(123, 20)
        Me.DtpFecha.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(197, 123)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 13)
        Me.Label16.TabIndex = 223
        Me.Label16.Text = "Fecha Ingresos:"
        '
        'CboOcupacion
        '
        Me.CboOcupacion.DisplayMember = "Ocupacion"
        Me.CboOcupacion.FormattingEnabled = True
        Me.CboOcupacion.Location = New System.Drawing.Point(285, 192)
        Me.CboOcupacion.Name = "CboOcupacion"
        Me.CboOcupacion.Size = New System.Drawing.Size(168, 21)
        Me.CboOcupacion.TabIndex = 9
        '
        'CboMunicipio
        '
        Me.CboMunicipio.DisplayMember = "Nombre_Municipio"
        Me.CboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMunicipio.FormattingEnabled = True
        Me.CboMunicipio.Location = New System.Drawing.Point(620, 143)
        Me.CboMunicipio.Name = "CboMunicipio"
        Me.CboMunicipio.Size = New System.Drawing.Size(139, 21)
        Me.CboMunicipio.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(563, 147)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 220
        Me.Label15.Text = "Municipio:"
        '
        'CboLocalidad
        '
        Me.CboLocalidad.DisplayMember = "Nombre_Departamento"
        Me.CboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLocalidad.FormattingEnabled = True
        Me.CboLocalidad.Location = New System.Drawing.Point(620, 119)
        Me.CboLocalidad.Name = "CboLocalidad"
        Me.CboLocalidad.Size = New System.Drawing.Size(139, 21)
        Me.CboLocalidad.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(560, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 218
        Me.Label14.Text = "Localidadl:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(218, 195)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 216
        Me.Label13.Text = "Ocupacion:"
        '
        'CboEscolaridad
        '
        Me.CboEscolaridad.FormattingEnabled = True
        Me.CboEscolaridad.Items.AddRange(New Object() {"Primaria", "Secundaria", "Superior", "Ninguna"})
        Me.CboEscolaridad.Location = New System.Drawing.Point(430, 168)
        Me.CboEscolaridad.Name = "CboEscolaridad"
        Me.CboEscolaridad.Size = New System.Drawing.Size(73, 21)
        Me.CboEscolaridad.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(365, 171)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 214
        Me.Label12.Text = "Escolaridad:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(528, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 212
        Me.Label11.Text = "Unidad de Salud:"
        '
        'CboEstadoCivil
        '
        Me.CboEstadoCivil.FormattingEnabled = True
        Me.CboEstadoCivil.Items.AddRange(New Object() {"Soloter@", "Casad@", "Acompañad@", "Viud@", "Divorciad@", "Ignorad@"})
        Me.CboEstadoCivil.Location = New System.Drawing.Point(285, 168)
        Me.CboEstadoCivil.Name = "CboEstadoCivil"
        Me.CboEstadoCivil.Size = New System.Drawing.Size(73, 21)
        Me.CboEstadoCivil.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(215, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "Estado Civil:"
        '
        'CboSexo
        '
        Me.CboSexo.FormattingEnabled = True
        Me.CboSexo.Items.AddRange(New Object() {"Masculino", "Femenino"})
        Me.CboSexo.Location = New System.Drawing.Point(430, 143)
        Me.CboSexo.Name = "CboSexo"
        Me.CboSexo.Size = New System.Drawing.Size(73, 21)
        Me.CboSexo.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(395, 147)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 208
        Me.Label10.Text = "Sexo:"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(285, 241)
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDireccion.Size = New System.Drawing.Size(218, 62)
        Me.TxtDireccion.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(224, 240)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "Direccion;"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(285, 218)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(168, 20)
        Me.TxtTelefono.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(227, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 204
        Me.Label8.Text = "Telefono;"
        '
        'TxtNombreMadre
        '
        Me.TxtNombreMadre.Location = New System.Drawing.Point(620, 96)
        Me.TxtNombreMadre.Name = "TxtNombreMadre"
        Me.TxtNombreMadre.Size = New System.Drawing.Size(168, 20)
        Me.TxtNombreMadre.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(533, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 202
        Me.Label7.Text = "Nombres Madre:"
        '
        'TxtNombrePadre
        '
        Me.TxtNombrePadre.Location = New System.Drawing.Point(620, 71)
        Me.TxtNombrePadre.Name = "TxtNombrePadre"
        Me.TxtNombrePadre.Size = New System.Drawing.Size(168, 20)
        Me.TxtNombrePadre.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(533, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 200
        Me.Label6.Text = "Nombres Padre:"
        '
        'TxtEdad
        '
        Me.TxtEdad.Location = New System.Drawing.Point(285, 145)
        Me.TxtEdad.Name = "TxtEdad"
        Me.TxtEdad.Size = New System.Drawing.Size(50, 20)
        Me.TxtEdad.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(244, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "Edad:"
        '
        'CmdQuitarFoto
        '
        Me.CmdQuitarFoto.Image = CType(resources.GetObject("CmdQuitarFoto.Image"), System.Drawing.Image)
        Me.CmdQuitarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdQuitarFoto.Location = New System.Drawing.Point(100, 203)
        Me.CmdQuitarFoto.Name = "CmdQuitarFoto"
        Me.CmdQuitarFoto.Size = New System.Drawing.Size(85, 39)
        Me.CmdQuitarFoto.TabIndex = 22
        Me.CmdQuitarFoto.Text = "       Quitar   Foto"
        Me.CmdQuitarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdQuitarFoto.UseVisualStyleBackColor = True
        '
        'CmdAgregarFoto
        '
        Me.CmdAgregarFoto.Image = CType(resources.GetObject("CmdAgregarFoto.Image"), System.Drawing.Image)
        Me.CmdAgregarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAgregarFoto.Location = New System.Drawing.Point(9, 203)
        Me.CmdAgregarFoto.Name = "CmdAgregarFoto"
        Me.CmdAgregarFoto.Size = New System.Drawing.Size(85, 37)
        Me.CmdAgregarFoto.TabIndex = 21
        Me.CmdAgregarFoto.Text = "      Agregar Foto"
        Me.CmdAgregarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAgregarFoto.UseVisualStyleBackColor = True
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Image = CType(resources.GetObject("BtnConsultar.Image"), System.Drawing.Image)
        Me.BtnConsultar.Location = New System.Drawing.Point(403, 14)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(29, 30)
        Me.BtnConsultar.TabIndex = 165
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(180, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero Expediente:"
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(285, 73)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(218, 20)
        Me.TxtApellidos.TabIndex = 4
        '
        'TxtLetra
        '
        Me.TxtLetra.Location = New System.Drawing.Point(285, 19)
        Me.TxtLetra.Name = "TxtLetra"
        Me.TxtLetra.Size = New System.Drawing.Size(40, 20)
        Me.TxtLetra.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Apellidos:"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(331, 19)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(69, 20)
        Me.TxtCodigo.TabIndex = 2
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(285, 48)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(218, 20)
        Me.TxtNombres.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(231, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombres:"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(884, 330)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Admision"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(660, 375)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 34)
        Me.Button6.TabIndex = 173
        Me.Button6.Text = "Imprimir"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'FrmExpediente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 421)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.CmdGuardar)
        Me.Controls.Add(Me.CmdEliminar)
        Me.Name = "FrmExpediente"
        Me.Text = "FrmExpediente"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TxtLetra As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnConsultar As System.Windows.Forms.Button
    Friend WithEvents CmdQuitarFoto As System.Windows.Forms.Button
    Friend WithEvents CmdAgregarFoto As System.Windows.Forms.Button
    Friend WithEvents TxtEdad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreMadre As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtNombrePadre As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CboSexo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CboEstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CboEscolaridad As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CboMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CboLocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CboOcupacion As System.Windows.Forms.ComboBox
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombreEmergencia As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefonoEmergencia As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccionEmergencia As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CboUnidadSalud As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DtpFechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CboComarca As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ImgFoto As System.Windows.Forms.PictureBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class
