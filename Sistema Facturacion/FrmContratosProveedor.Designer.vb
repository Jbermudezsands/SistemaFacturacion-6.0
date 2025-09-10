<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmContratosProveedor
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContratosProveedor))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtComentarios = New System.Windows.Forms.TextBox()
        Me.CmbDiasResolucion = New System.Windows.Forms.ComboBox()
        Me.TxtDiasResolucion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbDiasRespuesta = New System.Windows.Forms.ComboBox()
        Me.TxtDiasRespuesta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.CmbTipoContrato = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbTipoServicio = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CmdEliminar = New System.Windows.Forms.Button()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TxtDomingoFin = New System.Windows.Forms.MaskedTextBox()
        Me.TxtDomingoInicio = New System.Windows.Forms.MaskedTextBox()
        Me.TxtSabadoFin = New System.Windows.Forms.MaskedTextBox()
        Me.TxtSabadoInicio = New System.Windows.Forms.MaskedTextBox()
        Me.TxtViernesFin = New System.Windows.Forms.MaskedTextBox()
        Me.TxtViernesInicio = New System.Windows.Forms.MaskedTextBox()
        Me.TxtJuevesFin = New System.Windows.Forms.MaskedTextBox()
        Me.TxtJuevesInicio = New System.Windows.Forms.MaskedTextBox()
        Me.TxtMiercolesFin = New System.Windows.Forms.MaskedTextBox()
        Me.TxtMiercolesInicio = New System.Windows.Forms.MaskedTextBox()
        Me.TxtMartesFin = New System.Windows.Forms.MaskedTextBox()
        Me.TxtMartesInicio = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtLunesFin = New System.Windows.Forms.MaskedTextBox()
        Me.TxtLunesInicio = New System.Windows.Forms.MaskedTextBox()
        Me.ChkDomingo = New System.Windows.Forms.CheckBox()
        Me.ChkSabado = New System.Windows.Forms.CheckBox()
        Me.ChkViernes = New System.Windows.Forms.CheckBox()
        Me.ChkJueves = New System.Windows.Forms.CheckBox()
        Me.ChkMiercoles = New System.Windows.Forms.CheckBox()
        Me.ChkMartes = New System.Windows.Forms.CheckBox()
        Me.ChkLunes = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DtpFinContrato = New System.Windows.Forms.DateTimePicker()
        Me.DtpInicioContrato = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CboCodigoProveedor = New C1.Win.C1List.C1Combo()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtContacto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNumeroContrato = New System.Windows.Forms.TextBox()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBoxImportar = New System.Windows.Forms.GroupBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.LblTotalRegistros = New System.Windows.Forms.Label()
        Me.TxtError = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnQuitar = New System.Windows.Forms.Button()
        Me.BtnCargar = New System.Windows.Forms.Button()
        Me.BtnAbrir = New System.Windows.Forms.Button()
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxImportar.SuspendLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 176)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 246)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.CmbEstado)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.TxtComentarios)
        Me.TabPage1.Controls.Add(Me.CmbDiasResolucion)
        Me.TabPage1.Controls.Add(Me.TxtDiasResolucion)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.CmbDiasRespuesta)
        Me.TabPage1.Controls.Add(Me.TxtDiasRespuesta)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtModelo)
        Me.TabPage1.Controls.Add(Me.CmbTipoContrato)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.CmbTipoServicio)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(768, 220)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dato Generales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(62, 151)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(43, 13)
        Me.Label20.TabIndex = 261
        Me.Label20.Text = "Estado:"
        '
        'CmbEstado
        '
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Items.AddRange(New Object() {"Autorizado", "Bloqueado", "Borrador", "Cancelado"})
        Me.CmbEstado.Location = New System.Drawing.Point(116, 147)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.CmbEstado.TabIndex = 260
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(329, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 259
        Me.Label14.Text = "Comentarios:"
        '
        'TxtComentarios
        '
        Me.TxtComentarios.Location = New System.Drawing.Point(319, 35)
        Me.TxtComentarios.Multiline = True
        Me.TxtComentarios.Name = "TxtComentarios"
        Me.TxtComentarios.Size = New System.Drawing.Size(416, 122)
        Me.TxtComentarios.TabIndex = 258
        '
        'CmbDiasResolucion
        '
        Me.CmbDiasResolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDiasResolucion.FormattingEnabled = True
        Me.CmbDiasResolucion.Items.AddRange(New Object() {"Dias", "Horas", "Minutos"})
        Me.CmbDiasResolucion.Location = New System.Drawing.Point(164, 120)
        Me.CmbDiasResolucion.Name = "CmbDiasResolucion"
        Me.CmbDiasResolucion.Size = New System.Drawing.Size(73, 21)
        Me.CmbDiasResolucion.TabIndex = 257
        '
        'TxtDiasResolucion
        '
        Me.TxtDiasResolucion.Location = New System.Drawing.Point(116, 121)
        Me.TxtDiasResolucion.Name = "TxtDiasResolucion"
        Me.TxtDiasResolucion.Size = New System.Drawing.Size(42, 20)
        Me.TxtDiasResolucion.TabIndex = 256
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 13)
        Me.Label12.TabIndex = 255
        Me.Label12.Text = "Tiempo Resolucion:"
        '
        'CmbDiasRespuesta
        '
        Me.CmbDiasRespuesta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDiasRespuesta.FormattingEnabled = True
        Me.CmbDiasRespuesta.Items.AddRange(New Object() {"Dias", "Horas", "Minutos"})
        Me.CmbDiasRespuesta.Location = New System.Drawing.Point(164, 94)
        Me.CmbDiasRespuesta.Name = "CmbDiasRespuesta"
        Me.CmbDiasRespuesta.Size = New System.Drawing.Size(73, 21)
        Me.CmbDiasRespuesta.TabIndex = 254
        '
        'TxtDiasRespuesta
        '
        Me.TxtDiasRespuesta.Location = New System.Drawing.Point(116, 95)
        Me.TxtDiasRespuesta.Name = "TxtDiasRespuesta"
        Me.TxtDiasRespuesta.Size = New System.Drawing.Size(42, 20)
        Me.TxtDiasRespuesta.TabIndex = 253
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 252
        Me.Label8.Text = "Tiempo Respuesta:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(60, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "Modelo:"
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(116, 70)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(123, 20)
        Me.txtModelo.TabIndex = 250
        '
        'CmbTipoContrato
        '
        Me.CmbTipoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoContrato.FormattingEnabled = True
        Me.CmbTipoContrato.Items.AddRange(New Object() {"Suministros", "Servicios", "Bienes"})
        Me.CmbTipoContrato.Location = New System.Drawing.Point(116, 44)
        Me.CmbTipoContrato.Name = "CmbTipoContrato"
        Me.CmbTipoContrato.Size = New System.Drawing.Size(121, 21)
        Me.CmbTipoContrato.TabIndex = 249
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 248
        Me.Label6.Text = "Tipo Contrato:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 247
        Me.Label5.Text = "Tipo de Servicio:"
        '
        'CmbTipoServicio
        '
        Me.CmbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoServicio.FormattingEnabled = True
        Me.CmbTipoServicio.Items.AddRange(New Object() {"Regular", "Garantia"})
        Me.CmbTipoServicio.Location = New System.Drawing.Point(116, 19)
        Me.CmbTipoServicio.Name = "CmbTipoServicio"
        Me.CmbTipoServicio.Size = New System.Drawing.Size(121, 21)
        Me.CmbTipoServicio.TabIndex = 246
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.CmdEliminar)
        Me.TabPage2.Controls.Add(Me.CmdGuardar)
        Me.TabPage2.Controls.Add(Me.TrueDBGridComponentes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(768, 220)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Articulos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(668, 51)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(82, 34)
        Me.Button4.TabIndex = 365
        Me.Button4.Text = "Importar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = CType(resources.GetObject("CmdEliminar.Image"), System.Drawing.Image)
        Me.CmdEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdEliminar.Location = New System.Drawing.Point(668, 167)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(82, 34)
        Me.CmdEliminar.TabIndex = 364
        Me.CmdEliminar.Text = "Quitar"
        Me.CmdEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Image = CType(resources.GetObject("CmdGuardar.Image"), System.Drawing.Image)
        Me.CmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdGuardar.Location = New System.Drawing.Point(668, 15)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(82, 34)
        Me.CmdGuardar.TabIndex = 363
        Me.CmdGuardar.Text = "Agregar"
        Me.CmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos y/o Servicios"
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(13, 15)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(583, 186)
        Me.TrueDBGridComponentes.TabIndex = 131
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TxtDomingoFin)
        Me.TabPage3.Controls.Add(Me.TxtDomingoInicio)
        Me.TabPage3.Controls.Add(Me.TxtSabadoFin)
        Me.TabPage3.Controls.Add(Me.TxtSabadoInicio)
        Me.TabPage3.Controls.Add(Me.TxtViernesFin)
        Me.TabPage3.Controls.Add(Me.TxtViernesInicio)
        Me.TabPage3.Controls.Add(Me.TxtJuevesFin)
        Me.TabPage3.Controls.Add(Me.TxtJuevesInicio)
        Me.TabPage3.Controls.Add(Me.TxtMiercolesFin)
        Me.TabPage3.Controls.Add(Me.TxtMiercolesInicio)
        Me.TabPage3.Controls.Add(Me.TxtMartesFin)
        Me.TabPage3.Controls.Add(Me.TxtMartesInicio)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.TxtLunesFin)
        Me.TabPage3.Controls.Add(Me.TxtLunesInicio)
        Me.TabPage3.Controls.Add(Me.ChkDomingo)
        Me.TabPage3.Controls.Add(Me.ChkSabado)
        Me.TabPage3.Controls.Add(Me.ChkViernes)
        Me.TabPage3.Controls.Add(Me.ChkJueves)
        Me.TabPage3.Controls.Add(Me.ChkMiercoles)
        Me.TabPage3.Controls.Add(Me.ChkMartes)
        Me.TabPage3.Controls.Add(Me.ChkLunes)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(768, 220)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cobertura"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TxtDomingoFin
        '
        Me.TxtDomingoFin.Location = New System.Drawing.Point(184, 169)
        Me.TxtDomingoFin.Mask = "00:00"
        Me.TxtDomingoFin.Name = "TxtDomingoFin"
        Me.TxtDomingoFin.Size = New System.Drawing.Size(50, 20)
        Me.TxtDomingoFin.TabIndex = 266
        Me.TxtDomingoFin.ValidatingType = GetType(Date)
        '
        'TxtDomingoInicio
        '
        Me.TxtDomingoInicio.Location = New System.Drawing.Point(116, 169)
        Me.TxtDomingoInicio.Mask = "00:00"
        Me.TxtDomingoInicio.Name = "TxtDomingoInicio"
        Me.TxtDomingoInicio.Size = New System.Drawing.Size(50, 20)
        Me.TxtDomingoInicio.TabIndex = 265
        Me.TxtDomingoInicio.ValidatingType = GetType(Date)
        '
        'TxtSabadoFin
        '
        Me.TxtSabadoFin.Location = New System.Drawing.Point(184, 146)
        Me.TxtSabadoFin.Mask = "00:00"
        Me.TxtSabadoFin.Name = "TxtSabadoFin"
        Me.TxtSabadoFin.Size = New System.Drawing.Size(50, 20)
        Me.TxtSabadoFin.TabIndex = 264
        Me.TxtSabadoFin.ValidatingType = GetType(Date)
        '
        'TxtSabadoInicio
        '
        Me.TxtSabadoInicio.Location = New System.Drawing.Point(116, 146)
        Me.TxtSabadoInicio.Mask = "00:00"
        Me.TxtSabadoInicio.Name = "TxtSabadoInicio"
        Me.TxtSabadoInicio.Size = New System.Drawing.Size(50, 20)
        Me.TxtSabadoInicio.TabIndex = 263
        Me.TxtSabadoInicio.ValidatingType = GetType(Date)
        '
        'TxtViernesFin
        '
        Me.TxtViernesFin.Location = New System.Drawing.Point(185, 123)
        Me.TxtViernesFin.Mask = "00:00"
        Me.TxtViernesFin.Name = "TxtViernesFin"
        Me.TxtViernesFin.Size = New System.Drawing.Size(50, 20)
        Me.TxtViernesFin.TabIndex = 262
        Me.TxtViernesFin.ValidatingType = GetType(Date)
        '
        'TxtViernesInicio
        '
        Me.TxtViernesInicio.Location = New System.Drawing.Point(117, 123)
        Me.TxtViernesInicio.Mask = "00:00"
        Me.TxtViernesInicio.Name = "TxtViernesInicio"
        Me.TxtViernesInicio.Size = New System.Drawing.Size(50, 20)
        Me.TxtViernesInicio.TabIndex = 261
        Me.TxtViernesInicio.ValidatingType = GetType(Date)
        '
        'TxtJuevesFin
        '
        Me.TxtJuevesFin.Location = New System.Drawing.Point(184, 100)
        Me.TxtJuevesFin.Mask = "00:00"
        Me.TxtJuevesFin.Name = "TxtJuevesFin"
        Me.TxtJuevesFin.Size = New System.Drawing.Size(50, 20)
        Me.TxtJuevesFin.TabIndex = 260
        Me.TxtJuevesFin.ValidatingType = GetType(Date)
        '
        'TxtJuevesInicio
        '
        Me.TxtJuevesInicio.Location = New System.Drawing.Point(116, 100)
        Me.TxtJuevesInicio.Mask = "00:00"
        Me.TxtJuevesInicio.Name = "TxtJuevesInicio"
        Me.TxtJuevesInicio.Size = New System.Drawing.Size(50, 20)
        Me.TxtJuevesInicio.TabIndex = 259
        Me.TxtJuevesInicio.ValidatingType = GetType(Date)
        '
        'TxtMiercolesFin
        '
        Me.TxtMiercolesFin.Location = New System.Drawing.Point(184, 77)
        Me.TxtMiercolesFin.Mask = "00:00"
        Me.TxtMiercolesFin.Name = "TxtMiercolesFin"
        Me.TxtMiercolesFin.Size = New System.Drawing.Size(50, 20)
        Me.TxtMiercolesFin.TabIndex = 258
        Me.TxtMiercolesFin.ValidatingType = GetType(Date)
        '
        'TxtMiercolesInicio
        '
        Me.TxtMiercolesInicio.Location = New System.Drawing.Point(116, 77)
        Me.TxtMiercolesInicio.Mask = "00:00"
        Me.TxtMiercolesInicio.Name = "TxtMiercolesInicio"
        Me.TxtMiercolesInicio.Size = New System.Drawing.Size(50, 20)
        Me.TxtMiercolesInicio.TabIndex = 257
        Me.TxtMiercolesInicio.ValidatingType = GetType(Date)
        '
        'TxtMartesFin
        '
        Me.TxtMartesFin.Location = New System.Drawing.Point(184, 52)
        Me.TxtMartesFin.Mask = "00:00"
        Me.TxtMartesFin.Name = "TxtMartesFin"
        Me.TxtMartesFin.Size = New System.Drawing.Size(50, 20)
        Me.TxtMartesFin.TabIndex = 256
        Me.TxtMartesFin.ValidatingType = GetType(Date)
        '
        'TxtMartesInicio
        '
        Me.TxtMartesInicio.Location = New System.Drawing.Point(116, 52)
        Me.TxtMartesInicio.Mask = "00:00"
        Me.TxtMartesInicio.Name = "TxtMartesInicio"
        Me.TxtMartesInicio.Size = New System.Drawing.Size(50, 20)
        Me.TxtMartesInicio.TabIndex = 255
        Me.TxtMartesInicio.ValidatingType = GetType(Date)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(187, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 254
        Me.Label10.Text = "Hora Fin"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(113, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 253
        Me.Label9.Text = "Hora Inicio"
        '
        'TxtLunesFin
        '
        Me.TxtLunesFin.Location = New System.Drawing.Point(185, 28)
        Me.TxtLunesFin.Mask = "00:00"
        Me.TxtLunesFin.Name = "TxtLunesFin"
        Me.TxtLunesFin.Size = New System.Drawing.Size(50, 20)
        Me.TxtLunesFin.TabIndex = 252
        Me.TxtLunesFin.ValidatingType = GetType(Date)
        '
        'TxtLunesInicio
        '
        Me.TxtLunesInicio.Location = New System.Drawing.Point(117, 28)
        Me.TxtLunesInicio.Mask = "00:00"
        Me.TxtLunesInicio.Name = "TxtLunesInicio"
        Me.TxtLunesInicio.Size = New System.Drawing.Size(50, 20)
        Me.TxtLunesInicio.TabIndex = 251
        Me.TxtLunesInicio.ValidatingType = GetType(Date)
        '
        'ChkDomingo
        '
        Me.ChkDomingo.AutoSize = True
        Me.ChkDomingo.Location = New System.Drawing.Point(33, 172)
        Me.ChkDomingo.Name = "ChkDomingo"
        Me.ChkDomingo.Size = New System.Drawing.Size(68, 17)
        Me.ChkDomingo.TabIndex = 250
        Me.ChkDomingo.Text = "Domingo"
        Me.ChkDomingo.UseVisualStyleBackColor = True
        '
        'ChkSabado
        '
        Me.ChkSabado.AutoSize = True
        Me.ChkSabado.Location = New System.Drawing.Point(33, 149)
        Me.ChkSabado.Name = "ChkSabado"
        Me.ChkSabado.Size = New System.Drawing.Size(63, 17)
        Me.ChkSabado.TabIndex = 249
        Me.ChkSabado.Text = "Sabado"
        Me.ChkSabado.UseVisualStyleBackColor = True
        '
        'ChkViernes
        '
        Me.ChkViernes.AutoSize = True
        Me.ChkViernes.Location = New System.Drawing.Point(33, 126)
        Me.ChkViernes.Name = "ChkViernes"
        Me.ChkViernes.Size = New System.Drawing.Size(61, 17)
        Me.ChkViernes.TabIndex = 248
        Me.ChkViernes.Text = "Viernes"
        Me.ChkViernes.UseVisualStyleBackColor = True
        '
        'ChkJueves
        '
        Me.ChkJueves.AutoSize = True
        Me.ChkJueves.Location = New System.Drawing.Point(33, 103)
        Me.ChkJueves.Name = "ChkJueves"
        Me.ChkJueves.Size = New System.Drawing.Size(60, 17)
        Me.ChkJueves.TabIndex = 247
        Me.ChkJueves.Text = "Jueves"
        Me.ChkJueves.UseVisualStyleBackColor = True
        '
        'ChkMiercoles
        '
        Me.ChkMiercoles.AutoSize = True
        Me.ChkMiercoles.Location = New System.Drawing.Point(33, 80)
        Me.ChkMiercoles.Name = "ChkMiercoles"
        Me.ChkMiercoles.Size = New System.Drawing.Size(71, 17)
        Me.ChkMiercoles.TabIndex = 246
        Me.ChkMiercoles.Text = "Miercoles"
        Me.ChkMiercoles.UseVisualStyleBackColor = True
        '
        'ChkMartes
        '
        Me.ChkMartes.AutoSize = True
        Me.ChkMartes.Location = New System.Drawing.Point(33, 57)
        Me.ChkMartes.Name = "ChkMartes"
        Me.ChkMartes.Size = New System.Drawing.Size(58, 17)
        Me.ChkMartes.TabIndex = 245
        Me.ChkMartes.Text = "Martes"
        Me.ChkMartes.UseVisualStyleBackColor = True
        '
        'ChkLunes
        '
        Me.ChkLunes.AutoSize = True
        Me.ChkLunes.Location = New System.Drawing.Point(33, 34)
        Me.ChkLunes.Name = "ChkLunes"
        Me.ChkLunes.Size = New System.Drawing.Size(55, 17)
        Me.ChkLunes.TabIndex = 244
        Me.ChkLunes.Text = "Lunes"
        Me.ChkLunes.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.DtpFinContrato)
        Me.GroupBox1.Controls.Add(Me.DtpInicioContrato)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.CboCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtTelefono)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtContacto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroContrato)
        Me.GroupBox1.Controls.Add(Me.TxtNombres)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(772, 152)
        Me.GroupBox1.TabIndex = 244
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Proveedor"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(447, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 340
        Me.Label19.Text = "Fecha Fin:"
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(323, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 30)
        Me.Button3.TabIndex = 339
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DtpFinContrato
        '
        Me.DtpFinContrato.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFinContrato.Location = New System.Drawing.Point(507, 71)
        Me.DtpFinContrato.Name = "DtpFinContrato"
        Me.DtpFinContrato.Size = New System.Drawing.Size(123, 20)
        Me.DtpFinContrato.TabIndex = 244
        Me.DtpFinContrato.Value = New Date(2021, 3, 6, 9, 40, 39, 0)
        '
        'DtpInicioContrato
        '
        Me.DtpInicioContrato.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpInicioContrato.Location = New System.Drawing.Point(507, 49)
        Me.DtpInicioContrato.Name = "DtpInicioContrato"
        Me.DtpInicioContrato.Size = New System.Drawing.Size(123, 20)
        Me.DtpInicioContrato.TabIndex = 243
        Me.DtpInicioContrato.Value = New Date(2021, 3, 6, 9, 40, 39, 0)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(436, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 13)
        Me.Label18.TabIndex = 242
        Me.Label18.Text = "Fecha Inicio:"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(111, 128)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(572, 20)
        Me.TxtDescripcion.TabIndex = 241
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(43, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 240
        Me.Label17.Text = "Descripcion:"
        '
        'CboCodigoProveedor
        '
        Me.CboCodigoProveedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoProveedor.Caption = ""
        Me.CboCodigoProveedor.CaptionHeight = 17
        Me.CboCodigoProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoProveedor.ColumnCaptionHeight = 17
        Me.CboCodigoProveedor.ColumnFooterHeight = 17
        Me.CboCodigoProveedor.ContentHeight = 15
        Me.CboCodigoProveedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoProveedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoProveedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoProveedor.EditorHeight = 15
        Me.CboCodigoProveedor.Images.Add(CType(resources.GetObject("CboCodigoProveedor.Images"), System.Drawing.Image))
        Me.CboCodigoProveedor.ItemHeight = 15
        Me.CboCodigoProveedor.Location = New System.Drawing.Point(111, 26)
        Me.CboCodigoProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoProveedor.MaxLength = 32767
        Me.CboCodigoProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoProveedor.Name = "CboCodigoProveedor"
        Me.CboCodigoProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoProveedor.TabIndex = 238
        Me.CboCodigoProveedor.PropBag = resources.GetString("CboCodigoProveedor.PropBag")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 13)
        Me.Label16.TabIndex = 237
        Me.Label16.Text = "Codigo Proveedor:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Telefono:"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(111, 102)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(209, 20)
        Me.TxtTelefono.TabIndex = 215
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 13)
        Me.Label11.TabIndex = 214
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(414, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Numero Contrato:"
        '
        'TxtContacto
        '
        Me.TxtContacto.Location = New System.Drawing.Point(111, 76)
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(209, 20)
        Me.TxtContacto.TabIndex = 171
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 172
        Me.Label3.Text = "Contacto:"
        '
        'TxtNumeroContrato
        '
        Me.TxtNumeroContrato.Enabled = False
        Me.TxtNumeroContrato.Location = New System.Drawing.Point(507, 26)
        Me.TxtNumeroContrato.Name = "TxtNumeroContrato"
        Me.TxtNumeroContrato.Size = New System.Drawing.Size(123, 20)
        Me.TxtNumeroContrato.TabIndex = 168
        Me.TxtNumeroContrato.Text = "-----0-----"
        '
        'TxtNombres
        '
        Me.TxtNombres.Enabled = False
        Me.TxtNombres.Location = New System.Drawing.Point(111, 52)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(209, 20)
        Me.TxtNombres.TabIndex = 169
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Nombres:"
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(807, 388)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(84, 34)
        Me.Button8.TabIndex = 262
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(807, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 34)
        Me.Button1.TabIndex = 263
        Me.Button1.Text = "Guardar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(807, 52)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 34)
        Me.Button2.TabIndex = 264
        Me.Button2.Text = "Eliminar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBoxImportar
        '
        Me.GroupBoxImportar.Controls.Add(Me.ProgressBar)
        Me.GroupBoxImportar.Controls.Add(Me.LblTotalRegistros)
        Me.GroupBoxImportar.Controls.Add(Me.TxtError)
        Me.GroupBoxImportar.Controls.Add(Me.BtnCancelar)
        Me.GroupBoxImportar.Controls.Add(Me.BtnQuitar)
        Me.GroupBoxImportar.Controls.Add(Me.BtnCargar)
        Me.GroupBoxImportar.Controls.Add(Me.BtnAbrir)
        Me.GroupBoxImportar.Controls.Add(Me.TrueDBGridConsultas)
        Me.GroupBoxImportar.Location = New System.Drawing.Point(961, 12)
        Me.GroupBoxImportar.Name = "GroupBoxImportar"
        Me.GroupBoxImportar.Size = New System.Drawing.Size(887, 429)
        Me.GroupBoxImportar.TabIndex = 365
        Me.GroupBoxImportar.TabStop = False
        Me.GroupBoxImportar.Text = "Importacion de Compras"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(8, 398)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(538, 20)
        Me.ProgressBar.TabIndex = 215
        Me.ProgressBar.Visible = False
        '
        'LblTotalRegistros
        '
        Me.LblTotalRegistros.AutoSize = True
        Me.LblTotalRegistros.Location = New System.Drawing.Point(552, 403)
        Me.LblTotalRegistros.Name = "LblTotalRegistros"
        Me.LblTotalRegistros.Size = New System.Drawing.Size(81, 13)
        Me.LblTotalRegistros.TabIndex = 214
        Me.LblTotalRegistros.Text = "Total Registros "
        '
        'TxtError
        '
        Me.TxtError.Location = New System.Drawing.Point(775, 234)
        Me.TxtError.Multiline = True
        Me.TxtError.Name = "TxtError"
        Me.TxtError.Size = New System.Drawing.Size(86, 88)
        Me.TxtError.TabIndex = 213
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCancelar.Location = New System.Drawing.Point(788, 336)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(72, 66)
        Me.BtnCancelar.TabIndex = 212
        Me.BtnCancelar.Tag = "27"
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnQuitar
        '
        Me.BtnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQuitar.Image = CType(resources.GetObject("BtnQuitar.Image"), System.Drawing.Image)
        Me.BtnQuitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnQuitar.Location = New System.Drawing.Point(790, 161)
        Me.BtnQuitar.Name = "BtnQuitar"
        Me.BtnQuitar.Size = New System.Drawing.Size(70, 66)
        Me.BtnQuitar.TabIndex = 211
        Me.BtnQuitar.Tag = "27"
        Me.BtnQuitar.Text = "Quitar"
        Me.BtnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnQuitar.UseVisualStyleBackColor = True
        '
        'BtnCargar
        '
        Me.BtnCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCargar.Image = CType(resources.GetObject("BtnCargar.Image"), System.Drawing.Image)
        Me.BtnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCargar.Location = New System.Drawing.Point(788, 87)
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(70, 66)
        Me.BtnCargar.TabIndex = 210
        Me.BtnCargar.Tag = "27"
        Me.BtnCargar.Text = "Cargar"
        Me.BtnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCargar.UseVisualStyleBackColor = True
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAbrir.Image = CType(resources.GetObject("BtnAbrir.Image"), System.Drawing.Image)
        Me.BtnAbrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAbrir.Location = New System.Drawing.Point(788, 19)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(70, 66)
        Me.BtnAbrir.TabIndex = 209
        Me.BtnAbrir.Tag = "27"
        Me.BtnAbrir.Text = "Abrir"
        Me.BtnAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAbrir.UseVisualStyleBackColor = True
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "Listado de Productos"
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(6, 25)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(763, 367)
        Me.TrueDBGridConsultas.TabIndex = 134
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'FrmContratosProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 450)
        Me.Controls.Add(Me.GroupBoxImportar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmContratosProveedor"
        Me.Text = "Contrato de Servicios Proveedor"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxImportar.ResumeLayout(False)
        Me.GroupBoxImportar.PerformLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtTelefono As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtContacto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNumeroContrato As TextBox
    Friend WithEvents TxtNombres As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label16 As Label
    Friend WithEvents CboCodigoProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents TxtDescripcion As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents DtpFinContrato As DateTimePicker
    Friend WithEvents DtpInicioContrato As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents CmbTipoServicio As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents CmbTipoContrato As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbDiasRespuesta As ComboBox
    Friend WithEvents TxtDiasRespuesta As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ChkSabado As CheckBox
    Friend WithEvents ChkViernes As CheckBox
    Friend WithEvents ChkJueves As CheckBox
    Friend WithEvents ChkMiercoles As CheckBox
    Friend WithEvents ChkMartes As CheckBox
    Friend WithEvents ChkLunes As CheckBox
    Friend WithEvents TxtDomingoFin As MaskedTextBox
    Friend WithEvents TxtDomingoInicio As MaskedTextBox
    Friend WithEvents TxtSabadoFin As MaskedTextBox
    Friend WithEvents TxtSabadoInicio As MaskedTextBox
    Friend WithEvents TxtViernesFin As MaskedTextBox
    Friend WithEvents TxtViernesInicio As MaskedTextBox
    Friend WithEvents TxtJuevesFin As MaskedTextBox
    Friend WithEvents TxtJuevesInicio As MaskedTextBox
    Friend WithEvents TxtMiercolesFin As MaskedTextBox
    Friend WithEvents TxtMiercolesInicio As MaskedTextBox
    Friend WithEvents TxtMartesFin As MaskedTextBox
    Friend WithEvents TxtMartesInicio As MaskedTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtLunesFin As MaskedTextBox
    Friend WithEvents TxtLunesInicio As MaskedTextBox
    Friend WithEvents ChkDomingo As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtComentarios As TextBox
    Friend WithEvents CmbDiasResolucion As ComboBox
    Friend WithEvents TxtDiasResolucion As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CmdGuardar As Button
    Friend WithEvents CmdEliminar As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txtModelo As TextBox
    Friend WithEvents GroupBoxImportar As GroupBox
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents LblTotalRegistros As Label
    Friend WithEvents TxtError As TextBox
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnQuitar As Button
    Friend WithEvents BtnCargar As Button
    Friend WithEvents BtnAbrir As Button
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button4 As Button
    Friend WithEvents OpenFileDialog As OpenFileDialog
End Class
