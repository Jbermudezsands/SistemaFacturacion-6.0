<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvacuaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEvacuaciones))
        Me.TDGridSolicitud = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.DTPFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ProgressBarMini = New System.Windows.Forms.ProgressBar
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.CmbContrato1 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.CmdBorraLinea = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.BtnActualizar = New System.Windows.Forms.Button
        Me.BtnVer = New System.Windows.Forms.Button
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Button4 = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Button5 = New System.Windows.Forms.Button
        Me.BtnProcesar = New System.Windows.Forms.Button
        Me.BtnSalirFacturacion = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ProgressBarSy = New System.Windows.Forms.ProgressBar
        Me.ProgressBarFact = New System.Windows.Forms.ProgressBar
        Me.CmbContrato2 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.DtpFechaFinFact = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtpFechaIniFact = New System.Windows.Forms.DateTimePicker
        Me.TDGridFacturacion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        CType(Me.TDGridSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TDGridFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TDGridSolicitud
        '
        Me.TDGridSolicitud.AllowUpdate = False
        Me.TDGridSolicitud.AlternatingRows = True
        Me.TDGridSolicitud.Caption = "Listado de Clientes x Dias"
        Me.TDGridSolicitud.FilterBar = True
        Me.TDGridSolicitud.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridSolicitud.Images.Add(CType(resources.GetObject("TDGridSolicitud.Images"), System.Drawing.Image))
        Me.TDGridSolicitud.Location = New System.Drawing.Point(6, 104)
        Me.TDGridSolicitud.Name = "TDGridSolicitud"
        Me.TDGridSolicitud.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridSolicitud.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridSolicitud.PreviewInfo.ZoomFactor = 75
        Me.TDGridSolicitud.PrintInfo.PageSettings = CType(resources.GetObject("TDGridSolicitud.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridSolicitud.Size = New System.Drawing.Size(1112, 303)
        Me.TDGridSolicitud.TabIndex = 251
        Me.TDGridSolicitud.Text = "C1TrueDBGrid1"
        Me.TDGridSolicitud.PropBag = resources.GetString("TDGridSolicitud.PropBag")
        '
        'DTPFechaInicio
        '
        Me.DTPFechaInicio.CustomFormat = ""
        Me.DTPFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicio.Location = New System.Drawing.Point(83, 9)
        Me.DTPFechaInicio.Name = "DTPFechaInicio"
        Me.DTPFechaInicio.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaInicio.TabIndex = 254
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 253
        Me.Label2.Text = "Fecha Inicio"
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.CustomFormat = ""
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(269, 10)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaFin.TabIndex = 256
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(209, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 255
        Me.Label3.Text = "Fecha Fin"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBarMini)
        Me.GroupBox1.Controls.Add(Me.ProgressBar)
        Me.GroupBox1.Controls.Add(Me.CmbContrato1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPFechaInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1226, 86)
        Me.GroupBox1.TabIndex = 257
        Me.GroupBox1.TabStop = False
        '
        'ProgressBarMini
        '
        Me.ProgressBarMini.Location = New System.Drawing.Point(269, 67)
        Me.ProgressBarMini.Name = "ProgressBarMini"
        Me.ProgressBarMini.Size = New System.Drawing.Size(372, 10)
        Me.ProgressBarMini.TabIndex = 264
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(269, 34)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(629, 23)
        Me.ProgressBar.TabIndex = 263
        '
        'CmbContrato1
        '
        Me.CmbContrato1.DisplayMember = "TipoContrato"
        Me.CmbContrato1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbContrato1.FormattingEnabled = True
        Me.CmbContrato1.Location = New System.Drawing.Point(84, 51)
        Me.CmbContrato1.Name = "CmbContrato1"
        Me.CmbContrato1.Size = New System.Drawing.Size(121, 21)
        Me.CmbContrato1.TabIndex = 261
        Me.CmbContrato1.ValueMember = "TipoContrato"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Tipo Servicio"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(916, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 68)
        Me.Button1.TabIndex = 257
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(19, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(104, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 259
        Me.PictureBox2.TabStop = False
        '
        'CmdBorraLinea
        '
        Me.CmdBorraLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CmdBorraLinea.Location = New System.Drawing.Point(-4, -1)
        Me.CmdBorraLinea.Name = "CmdBorraLinea"
        Me.CmdBorraLinea.Size = New System.Drawing.Size(1328, 60)
        Me.CmdBorraLinea.TabIndex = 258
        Me.CmdBorraLinea.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(435, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(290, 13)
        Me.Label9.TabIndex = 260
        Me.Label9.Text = "REGISTRO DE VIAJES CONTRATOS VARIABLES"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(1124, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 56)
        Me.Button2.TabIndex = 265
        Me.Button2.Text = "Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActualizar.Location = New System.Drawing.Point(1124, 228)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(108, 56)
        Me.BtnActualizar.TabIndex = 263
        Me.BtnActualizar.Text = "Actualiza"
        Me.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnActualizar.UseVisualStyleBackColor = True
        '
        'BtnVer
        '
        Me.BtnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVer.Image = CType(resources.GetObject("BtnVer.Image"), System.Drawing.Image)
        Me.BtnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVer.Location = New System.Drawing.Point(1124, 167)
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(108, 56)
        Me.BtnVer.TabIndex = 262
        Me.BtnVer.Text = "Ver"
        Me.BtnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVer.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.Location = New System.Drawing.Point(1124, 351)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(108, 56)
        Me.BtnSalir.TabIndex = 261
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(10, 65)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1255, 439)
        Me.TabControl1.TabIndex = 266
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.TDGridSolicitud)
        Me.TabPage1.Controls.Add(Me.BtnSalir)
        Me.TabPage1.Controls.Add(Me.BtnActualizar)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.BtnVer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1247, 413)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Evacuaciones"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(1124, 289)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(108, 56)
        Me.Button4.TabIndex = 266
        Me.Button4.Text = "Excel"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.BtnProcesar)
        Me.TabPage2.Controls.Add(Me.BtnSalirFacturacion)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.TDGridFacturacion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1247, 413)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Facturacion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(1124, 166)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(108, 56)
        Me.Button5.TabIndex = 268
        Me.Button5.Text = "Excel"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'BtnProcesar
        '
        Me.BtnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProcesar.Location = New System.Drawing.Point(1124, 104)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Size = New System.Drawing.Size(108, 56)
        Me.BtnProcesar.TabIndex = 267
        Me.BtnProcesar.Text = "Facturar"
        Me.BtnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnProcesar.UseVisualStyleBackColor = True
        '
        'BtnSalirFacturacion
        '
        Me.BtnSalirFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalirFacturacion.Image = CType(resources.GetObject("BtnSalirFacturacion.Image"), System.Drawing.Image)
        Me.BtnSalirFacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalirFacturacion.Location = New System.Drawing.Point(1124, 351)
        Me.BtnSalirFacturacion.Name = "BtnSalirFacturacion"
        Me.BtnSalirFacturacion.Size = New System.Drawing.Size(108, 56)
        Me.BtnSalirFacturacion.TabIndex = 262
        Me.BtnSalirFacturacion.Text = "Salir"
        Me.BtnSalirFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalirFacturacion.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ProgressBarSy)
        Me.GroupBox2.Controls.Add(Me.ProgressBarFact)
        Me.GroupBox2.Controls.Add(Me.CmbContrato2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.DtpFechaFinFact)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.DtpFechaIniFact)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1226, 86)
        Me.GroupBox2.TabIndex = 258
        Me.GroupBox2.TabStop = False
        '
        'ProgressBarSy
        '
        Me.ProgressBarSy.Location = New System.Drawing.Point(526, 65)
        Me.ProgressBarSy.Name = "ProgressBarSy"
        Me.ProgressBarSy.Size = New System.Drawing.Size(372, 10)
        Me.ProgressBarSy.TabIndex = 263
        '
        'ProgressBarFact
        '
        Me.ProgressBarFact.Location = New System.Drawing.Point(269, 36)
        Me.ProgressBarFact.Name = "ProgressBarFact"
        Me.ProgressBarFact.Size = New System.Drawing.Size(629, 23)
        Me.ProgressBarFact.TabIndex = 262
        '
        'CmbContrato2
        '
        Me.CmbContrato2.DisplayMember = "TipoContrato"
        Me.CmbContrato2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbContrato2.FormattingEnabled = True
        Me.CmbContrato2.Location = New System.Drawing.Point(84, 51)
        Me.CmbContrato2.Name = "CmbContrato2"
        Me.CmbContrato2.Size = New System.Drawing.Size(121, 21)
        Me.CmbContrato2.TabIndex = 261
        Me.CmbContrato2.ValueMember = "TipoContrato"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Tipo Servicio"
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(916, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(196, 68)
        Me.Button3.TabIndex = 257
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DtpFechaFinFact
        '
        Me.DtpFechaFinFact.CustomFormat = ""
        Me.DtpFechaFinFact.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaFinFact.Location = New System.Drawing.Point(269, 12)
        Me.DtpFechaFinFact.Name = "DtpFechaFinFact"
        Me.DtpFechaFinFact.Size = New System.Drawing.Size(104, 20)
        Me.DtpFechaFinFact.TabIndex = 256
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 253
        Me.Label4.Text = "Fecha Inicio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(209, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 255
        Me.Label6.Text = "Fecha Fin"
        '
        'DtpFechaIniFact
        '
        Me.DtpFechaIniFact.CustomFormat = ""
        Me.DtpFechaIniFact.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaIniFact.Location = New System.Drawing.Point(83, 11)
        Me.DtpFechaIniFact.Name = "DtpFechaIniFact"
        Me.DtpFechaIniFact.Size = New System.Drawing.Size(104, 20)
        Me.DtpFechaIniFact.TabIndex = 254
        '
        'TDGridFacturacion
        '
        Me.TDGridFacturacion.AlternatingRows = True
        Me.TDGridFacturacion.Caption = "Listado de Clientes x Dias"
        Me.TDGridFacturacion.FilterBar = True
        Me.TDGridFacturacion.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridFacturacion.Images.Add(CType(resources.GetObject("TDGridFacturacion.Images"), System.Drawing.Image))
        Me.TDGridFacturacion.Location = New System.Drawing.Point(6, 104)
        Me.TDGridFacturacion.Name = "TDGridFacturacion"
        Me.TDGridFacturacion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridFacturacion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridFacturacion.PreviewInfo.ZoomFactor = 75
        Me.TDGridFacturacion.PrintInfo.PageSettings = CType(resources.GetObject("TDGridFacturacion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridFacturacion.Size = New System.Drawing.Size(1112, 303)
        Me.TDGridFacturacion.TabIndex = 252
        Me.TDGridFacturacion.Text = "C1TrueDBGrid1"
        Me.TDGridFacturacion.PropBag = resources.GetString("TDGridFacturacion.PropBag")
        '
        'FrmEvacuaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1277, 506)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CmdBorraLinea)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvacuaciones"
        Me.Text = "FrmEvacuaciones"
        CType(Me.TDGridSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TDGridFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TDGridSolicitud As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DTPFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdBorraLinea As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents BtnVer As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents CmbContrato1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TDGridFacturacion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnSalirFacturacion As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbContrato2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DtpFechaFinFact As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaIniFact As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents BtnProcesar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBarFact As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBarSy As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBarMini As System.Windows.Forms.ProgressBar
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
