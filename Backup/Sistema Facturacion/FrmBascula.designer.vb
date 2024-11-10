<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBascula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBascula))
        Me.LblPeso = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtsubtotal = New System.Windows.Forms.TextBox
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Button6 = New System.Windows.Forms.Button
        Me.Eventos = New System.Windows.Forms.GroupBox
        Me.Button_Ticket = New System.Windows.Forms.Button
        Me.Button_Salir = New System.Windows.Forms.Button
        Me.Button_Reporte = New System.Windows.Forms.Button
        Me.Button_Desconectar = New System.Windows.Forms.Button
        Me.Button_Grabar = New System.Windows.Forms.Button
        Me.Button_Conectar = New System.Windows.Forms.Button
        Me.Button_Pesada = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.TxtTipoRemision = New System.Windows.Forms.TextBox
        Me.TxtNumeroRemision = New System.Windows.Forms.TextBox
        Me.lblbdega = New System.Windows.Forms.Label
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.sp = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.LblEstado = New System.Windows.Forms.Label
        Me.Grupo = New System.Windows.Forms.GroupBox
        Me.DtpHoraManual = New System.Windows.Forms.DateTimePicker
        Me.DTPFecha = New System.Windows.Forms.Label
        Me.LblHora = New System.Windows.Forms.Label
        Me.lbldatosre = New System.Windows.Forms.Label
        Me.CboIngresoBascula = New C1.Win.C1List.C1Combo
        Me.DTPRemFechCarga = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtTara = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtNeto = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.ChkTaraSaco = New System.Windows.Forms.CheckBox
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Eventos.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo.SuspendLayout()
        CType(Me.CboIngresoBascula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblPeso
        '
        Me.LblPeso.AutoSize = True
        Me.LblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeso.ForeColor = System.Drawing.Color.Maroon
        Me.LblPeso.Location = New System.Drawing.Point(952, 347)
        Me.LblPeso.Name = "LblPeso"
        Me.LblPeso.Size = New System.Drawing.Size(49, 24)
        Me.LblPeso.TabIndex = 237
        Me.LblPeso.Text = "0.00"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(386, 379)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 20)
        Me.Label1.TabIndex = 235
        Me.Label1.Text = "SubTotal"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.Enabled = False
        Me.txtsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.Location = New System.Drawing.Point(478, 375)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(105, 26)
        Me.txtsubtotal.TabIndex = 233
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AllowDelete = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos"
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(12, 168)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(988, 175)
        Me.TrueDBGridComponentes.TabIndex = 234
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(20, 350)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(171, 45)
        Me.Button6.TabIndex = 236
        Me.Button6.Text = "Borrar Linea"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Eventos
        '
        Me.Eventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Eventos.Controls.Add(Me.Button_Ticket)
        Me.Eventos.Controls.Add(Me.Button_Salir)
        Me.Eventos.Controls.Add(Me.Button_Reporte)
        Me.Eventos.Controls.Add(Me.Button_Desconectar)
        Me.Eventos.Controls.Add(Me.Button_Grabar)
        Me.Eventos.Controls.Add(Me.Button_Conectar)
        Me.Eventos.Location = New System.Drawing.Point(9, 435)
        Me.Eventos.Name = "Eventos"
        Me.Eventos.Size = New System.Drawing.Size(989, 80)
        Me.Eventos.TabIndex = 242
        Me.Eventos.TabStop = False
        '
        'Button_Ticket
        '
        Me.Button_Ticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Ticket.Image = CType(resources.GetObject("Button_Ticket.Image"), System.Drawing.Image)
        Me.Button_Ticket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Ticket.Location = New System.Drawing.Point(617, 15)
        Me.Button_Ticket.Name = "Button_Ticket"
        Me.Button_Ticket.Size = New System.Drawing.Size(114, 57)
        Me.Button_Ticket.TabIndex = 219
        Me.Button_Ticket.Text = "Ticket"
        Me.Button_Ticket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Ticket.UseVisualStyleBackColor = True
        Me.Button_Ticket.Visible = False
        '
        'Button_Salir
        '
        Me.Button_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Salir.Image = CType(resources.GetObject("Button_Salir.Image"), System.Drawing.Image)
        Me.Button_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Salir.Location = New System.Drawing.Point(856, 15)
        Me.Button_Salir.Name = "Button_Salir"
        Me.Button_Salir.Size = New System.Drawing.Size(114, 55)
        Me.Button_Salir.TabIndex = 218
        Me.Button_Salir.Text = "Salir"
        Me.Button_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Salir.UseVisualStyleBackColor = True
        '
        'Button_Reporte
        '
        Me.Button_Reporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Reporte.Image = CType(resources.GetObject("Button_Reporte.Image"), System.Drawing.Image)
        Me.Button_Reporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Reporte.Location = New System.Drawing.Point(736, 15)
        Me.Button_Reporte.Name = "Button_Reporte"
        Me.Button_Reporte.Size = New System.Drawing.Size(114, 55)
        Me.Button_Reporte.TabIndex = 217
        Me.Button_Reporte.Text = "Reporte"
        Me.Button_Reporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Reporte.UseVisualStyleBackColor = True
        Me.Button_Reporte.Visible = False
        '
        'Button_Desconectar
        '
        Me.Button_Desconectar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Desconectar.Image = CType(resources.GetObject("Button_Desconectar.Image"), System.Drawing.Image)
        Me.Button_Desconectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Desconectar.Location = New System.Drawing.Point(248, 14)
        Me.Button_Desconectar.Name = "Button_Desconectar"
        Me.Button_Desconectar.Size = New System.Drawing.Size(114, 56)
        Me.Button_Desconectar.TabIndex = 215
        Me.Button_Desconectar.Text = "Des-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Conectar"
        Me.Button_Desconectar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Desconectar.UseVisualStyleBackColor = True
        '
        'Button_Grabar
        '
        Me.Button_Grabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Grabar.Image = CType(resources.GetObject("Button_Grabar.Image"), System.Drawing.Image)
        Me.Button_Grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Grabar.Location = New System.Drawing.Point(12, 12)
        Me.Button_Grabar.Name = "Button_Grabar"
        Me.Button_Grabar.Size = New System.Drawing.Size(114, 56)
        Me.Button_Grabar.TabIndex = 179
        Me.Button_Grabar.Text = "Grabar"
        Me.Button_Grabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Grabar.UseVisualStyleBackColor = True
        '
        'Button_Conectar
        '
        Me.Button_Conectar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Conectar.Image = CType(resources.GetObject("Button_Conectar.Image"), System.Drawing.Image)
        Me.Button_Conectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Conectar.Location = New System.Drawing.Point(128, 12)
        Me.Button_Conectar.Name = "Button_Conectar"
        Me.Button_Conectar.Size = New System.Drawing.Size(114, 56)
        Me.Button_Conectar.TabIndex = 214
        Me.Button_Conectar.Text = "Conectar"
        Me.Button_Conectar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Conectar.UseVisualStyleBackColor = True
        '
        'Button_Pesada
        '
        Me.Button_Pesada.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Pesada.Image = CType(resources.GetObject("Button_Pesada.Image"), System.Drawing.Image)
        Me.Button_Pesada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Pesada.Location = New System.Drawing.Point(887, 68)
        Me.Button_Pesada.Name = "Button_Pesada"
        Me.Button_Pesada.Size = New System.Drawing.Size(114, 52)
        Me.Button_Pesada.TabIndex = 243
        Me.Button_Pesada.Text = "Pesada"
        Me.Button_Pesada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Pesada.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox7.Controls.Add(Me.TxtTipoRemision)
        Me.GroupBox7.Controls.Add(Me.TxtNumeroRemision)
        Me.GroupBox7.Controls.Add(Me.lblbdega)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(988, 42)
        Me.GroupBox7.TabIndex = 244
        Me.GroupBox7.TabStop = False
        '
        'TxtTipoRemision
        '
        Me.TxtTipoRemision.AutoCompleteCustomSource.AddRange(New String() {"Repesaje"})
        Me.TxtTipoRemision.Enabled = False
        Me.TxtTipoRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTipoRemision.Location = New System.Drawing.Point(11, 11)
        Me.TxtTipoRemision.Name = "TxtTipoRemision"
        Me.TxtTipoRemision.Size = New System.Drawing.Size(118, 26)
        Me.TxtTipoRemision.TabIndex = 237
        '
        'TxtNumeroRemision
        '
        Me.TxtNumeroRemision.Enabled = False
        Me.TxtNumeroRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroRemision.Location = New System.Drawing.Point(859, 10)
        Me.TxtNumeroRemision.Name = "TxtNumeroRemision"
        Me.TxtNumeroRemision.Size = New System.Drawing.Size(118, 26)
        Me.TxtNumeroRemision.TabIndex = 236
        '
        'lblbdega
        '
        Me.lblbdega.AutoSize = True
        Me.lblbdega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbdega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblbdega.Location = New System.Drawing.Point(748, 15)
        Me.lblbdega.Name = "lblbdega"
        Me.lblbdega.Size = New System.Drawing.Size(97, 16)
        Me.lblbdega.TabIndex = 12
        Me.lblbdega.Text = "No Remision"
        '
        'sp
        '
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ToolTip
        '
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstado.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.LblEstado.Location = New System.Drawing.Point(865, 411)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(137, 24)
        Me.LblEstado.TabIndex = 245
        Me.LblEstado.Text = "DESCONECT"
        '
        'Grupo
        '
        Me.Grupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Grupo.Controls.Add(Me.DtpHoraManual)
        Me.Grupo.Controls.Add(Me.DTPFecha)
        Me.Grupo.Controls.Add(Me.LblHora)
        Me.Grupo.Controls.Add(Me.lbldatosre)
        Me.Grupo.Location = New System.Drawing.Point(20, 55)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(436, 65)
        Me.Grupo.TabIndex = 246
        Me.Grupo.TabStop = False
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
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DTPFecha.Location = New System.Drawing.Point(18, 22)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(169, 33)
        Me.DTPFecha.TabIndex = 182
        Me.DTPFecha.Text = "20/10/2017"
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblHora.Location = New System.Drawing.Point(225, 21)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(205, 33)
        Me.LblHora.TabIndex = 181
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'lbldatosre
        '
        Me.lbldatosre.AutoSize = True
        Me.lbldatosre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatosre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lbldatosre.Location = New System.Drawing.Point(35, -2)
        Me.lbldatosre.Name = "lbldatosre"
        Me.lbldatosre.Size = New System.Drawing.Size(153, 20)
        Me.lbldatosre.TabIndex = 176
        Me.lbldatosre.Text = "DATOS REPESAJE"
        '
        'CboIngresoBascula
        '
        Me.CboIngresoBascula.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboIngresoBascula.AlternatingRows = True
        Me.CboIngresoBascula.Caption = ""
        Me.CboIngresoBascula.CaptionHeight = 17
        Me.CboIngresoBascula.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboIngresoBascula.ColumnCaptionHeight = 17
        Me.CboIngresoBascula.ColumnFooterHeight = 17
        Me.CboIngresoBascula.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboIngresoBascula.ContentHeight = 33
        Me.CboIngresoBascula.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboIngresoBascula.DisplayMember = "Descripcion_Producto"
        Me.CboIngresoBascula.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboIngresoBascula.DropDownWidth = 600
        Me.CboIngresoBascula.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboIngresoBascula.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboIngresoBascula.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboIngresoBascula.EditorHeight = 33
        Me.CboIngresoBascula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboIngresoBascula.Images.Add(CType(resources.GetObject("CboIngresoBascula.Images"), System.Drawing.Image))
        Me.CboIngresoBascula.ItemHeight = 35
        Me.CboIngresoBascula.Location = New System.Drawing.Point(122, 126)
        Me.CboIngresoBascula.MatchEntryTimeout = CType(2000, Long)
        Me.CboIngresoBascula.MaxDropDownItems = CType(6, Short)
        Me.CboIngresoBascula.MaxLength = 32767
        Me.CboIngresoBascula.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboIngresoBascula.Name = "CboIngresoBascula"
        Me.CboIngresoBascula.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboIngresoBascula.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboIngresoBascula.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboIngresoBascula.Size = New System.Drawing.Size(328, 39)
        Me.CboIngresoBascula.TabIndex = 247
        Me.CboIngresoBascula.Visible = False
        Me.CboIngresoBascula.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.CboIngresoBascula.PropBag = resources.GetString("CboIngresoBascula.PropBag")
        '
        'DTPRemFechCarga
        '
        Me.DTPRemFechCarga.CustomFormat = "dd/MM/yyyy HH:mm:s"
        Me.DTPRemFechCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPRemFechCarga.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPRemFechCarga.Location = New System.Drawing.Point(643, 68)
        Me.DTPRemFechCarga.Name = "DTPRemFechCarga"
        Me.DTPRemFechCarga.Size = New System.Drawing.Size(201, 29)
        Me.DTPRemFechCarga.TabIndex = 249
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(540, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 16)
        Me.Label10.TabIndex = 248
        Me.Label10.Text = "Fecha Carga"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(634, 379)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 20)
        Me.Label2.TabIndex = 251
        Me.Label2.Text = "Tara"
        '
        'TxtTara
        '
        Me.TxtTara.Enabled = False
        Me.TxtTara.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTara.Location = New System.Drawing.Point(685, 375)
        Me.TxtTara.Name = "TxtTara"
        Me.TxtTara.Size = New System.Drawing.Size(105, 26)
        Me.TxtTara.TabIndex = 250
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(844, 378)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 20)
        Me.Label3.TabIndex = 253
        Me.Label3.Text = "Neto"
        '
        'TxtNeto
        '
        Me.TxtNeto.Enabled = False
        Me.TxtNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNeto.Location = New System.Drawing.Point(897, 374)
        Me.TxtNeto.Name = "TxtNeto"
        Me.TxtNeto.Size = New System.Drawing.Size(105, 26)
        Me.TxtNeto.TabIndex = 252
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(456, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 23)
        Me.Button1.TabIndex = 254
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(17, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 20)
        Me.Label6.TabIndex = 255
        Me.Label6.Text = "PRODUCTO"
        '
        'ChkTaraSaco
        '
        Me.ChkTaraSaco.AutoSize = True
        Me.ChkTaraSaco.Checked = True
        Me.ChkTaraSaco.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTaraSaco.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkTaraSaco.ForeColor = System.Drawing.Color.White
        Me.ChkTaraSaco.Location = New System.Drawing.Point(495, 130)
        Me.ChkTaraSaco.Name = "ChkTaraSaco"
        Me.ChkTaraSaco.Size = New System.Drawing.Size(215, 29)
        Me.ChkTaraSaco.TabIndex = 256
        Me.ChkTaraSaco.Text = "Calcular Tara Saco"
        Me.ChkTaraSaco.UseVisualStyleBackColor = True
        '
        'FrmBascula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1018, 524)
        Me.Controls.Add(Me.ChkTaraSaco)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtNeto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTara)
        Me.Controls.Add(Me.DTPRemFechCarga)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CboIngresoBascula)
        Me.Controls.Add(Me.Grupo)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Button_Pesada)
        Me.Controls.Add(Me.Eventos)
        Me.Controls.Add(Me.LblPeso)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Name = "FrmBascula"
        Me.Text = "FrmBascula"
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Eventos.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo.ResumeLayout(False)
        Me.Grupo.PerformLayout()
        CType(Me.CboIngresoBascula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblPeso As System.Windows.Forms.Label
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Eventos As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Desconectar As System.Windows.Forms.Button
    Friend WithEvents Button_Grabar As System.Windows.Forms.Button
    Friend WithEvents Button_Conectar As System.Windows.Forms.Button
    Friend WithEvents Button_Ticket As System.Windows.Forms.Button
    Friend WithEvents Button_Salir As System.Windows.Forms.Button
    Friend WithEvents Button_Reporte As System.Windows.Forms.Button
    Friend WithEvents Button_Pesada As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumeroRemision As System.Windows.Forms.TextBox
    Friend WithEvents lblbdega As System.Windows.Forms.Label
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents sp As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents Grupo As System.Windows.Forms.GroupBox
    Friend WithEvents DtpHoraManual As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFecha As System.Windows.Forms.Label
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents lbldatosre As System.Windows.Forms.Label
    Friend WithEvents TxtTipoRemision As System.Windows.Forms.TextBox
    Friend WithEvents CboIngresoBascula As C1.Win.C1List.C1Combo
    Friend WithEvents DTPRemFechCarga As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTara As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNeto As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkTaraSaco As System.Windows.Forms.CheckBox
End Class
