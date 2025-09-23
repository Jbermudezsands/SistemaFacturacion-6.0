<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanilla
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlanilla))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtNumNomina = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblTotalPlanilla = New System.Windows.Forms.Label()
        Me.DTPFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboTipoPlanilla = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmdBorraLinea = New System.Windows.Forms.PictureBox()
        Me.CmdCalcular = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Ingresos = New System.Windows.Forms.TabPage()
        Me.TDGridIngresos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Deducciones = New System.Windows.Forms.TabPage()
        Me.TDGridDeducciones = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Configuracion = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TxtNuevoPrecio = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TDGridDeducciones2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtPrecioDomingo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtPrecioSabado = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtPrecioViernes = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtPrecioJueves = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtPrecioMiercoles = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtPrecioMartes = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtBolsa = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtPrecioLunes = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDeduccionPolicia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtIR = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmdNomina = New System.Windows.Forms.Button()
        Me.CmdColillas = New System.Windows.Forms.Button()
        Me.CmdSalir = New System.Windows.Forms.Button()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.LblProcesando = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BindingDeducciones2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBoxImportar = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LblTotalRegistros = New System.Windows.Forms.Label()
        Me.TxtError = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnQuitar = New System.Windows.Forms.Button()
        Me.BtnCargar = New System.Windows.Forms.Button()
        Me.BtnAbrir = New System.Windows.Forms.Button()
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboTipoPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Ingresos.SuspendLayout()
        CType(Me.TDGridIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Deducciones.SuspendLayout()
        CType(Me.TDGridDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Configuracion.SuspendLayout()
        CType(Me.TDGridDeducciones2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.BindingDeducciones2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxImportar.SuspendLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtNumNomina)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblTotalPlanilla)
        Me.GroupBox1.Controls.Add(Me.DTPFechaIni)
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CboTipoPlanilla)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(980, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TxtNumNomina
        '
        Me.TxtNumNomina.Enabled = False
        Me.TxtNumNomina.Location = New System.Drawing.Point(866, 22)
        Me.TxtNumNomina.Name = "TxtNumNomina"
        Me.TxtNumNomina.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumNomina.TabIndex = 183
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label7.Location = New System.Drawing.Point(771, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 182
        Me.Label7.Text = "No. Nomina"
        '
        'LblTotalPlanilla
        '
        Me.LblTotalPlanilla.AutoSize = True
        Me.LblTotalPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPlanilla.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblTotalPlanilla.Location = New System.Drawing.Point(545, 48)
        Me.LblTotalPlanilla.Name = "LblTotalPlanilla"
        Me.LblTotalPlanilla.Size = New System.Drawing.Size(25, 24)
        Me.LblTotalPlanilla.TabIndex = 181
        Me.LblTotalPlanilla.Text = "fff"
        '
        'DTPFechaIni
        '
        Me.DTPFechaIni.Enabled = False
        Me.DTPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaIni.Location = New System.Drawing.Point(431, 21)
        Me.DTPFechaIni.Name = "DTPFechaIni"
        Me.DTPFechaIni.Size = New System.Drawing.Size(117, 20)
        Me.DTPFechaIni.TabIndex = 179
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.Enabled = False
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(639, 22)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(117, 20)
        Me.DTPFechaFin.TabIndex = 178
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(561, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 177
        Me.Label3.Text = "Inicio Periodo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(354, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Inicio Periodo"
        '
        'CboTipoPlanilla
        '
        Me.CboTipoPlanilla.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTipoPlanilla.Caption = ""
        Me.CboTipoPlanilla.CaptionHeight = 17
        Me.CboTipoPlanilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipoPlanilla.ColumnCaptionHeight = 17
        Me.CboTipoPlanilla.ColumnFooterHeight = 17
        Me.CboTipoPlanilla.ContentHeight = 15
        Me.CboTipoPlanilla.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipoPlanilla.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipoPlanilla.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoPlanilla.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipoPlanilla.EditorHeight = 15
        Me.CboTipoPlanilla.Images.Add(CType(resources.GetObject("CboTipoPlanilla.Images"), System.Drawing.Image))
        Me.CboTipoPlanilla.ItemHeight = 15
        Me.CboTipoPlanilla.Location = New System.Drawing.Point(120, 19)
        Me.CboTipoPlanilla.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipoPlanilla.MaxDropDownItems = CType(5, Short)
        Me.CboTipoPlanilla.MaxLength = 32767
        Me.CboTipoPlanilla.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipoPlanilla.Name = "CboTipoPlanilla"
        Me.CboTipoPlanilla.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTipoPlanilla.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTipoPlanilla.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipoPlanilla.Size = New System.Drawing.Size(223, 21)
        Me.CboTipoPlanilla.TabIndex = 1
        Me.CboTipoPlanilla.PropBag = resources.GetString("CboTipoPlanilla.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione la Planilla"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(416, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(170, 13)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "REGISTROS DE PLANILLAS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(23, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 165
        Me.PictureBox2.TabStop = False
        '
        'CmdBorraLinea
        '
        Me.CmdBorraLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CmdBorraLinea.Location = New System.Drawing.Point(0, -3)
        Me.CmdBorraLinea.Name = "CmdBorraLinea"
        Me.CmdBorraLinea.Size = New System.Drawing.Size(1041, 60)
        Me.CmdBorraLinea.TabIndex = 164
        Me.CmdBorraLinea.TabStop = False
        '
        'CmdCalcular
        '
        Me.CmdCalcular.Enabled = False
        Me.CmdCalcular.Image = CType(resources.GetObject("CmdCalcular.Image"), System.Drawing.Image)
        Me.CmdCalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCalcular.Location = New System.Drawing.Point(12, 392)
        Me.CmdCalcular.Name = "CmdCalcular"
        Me.CmdCalcular.Size = New System.Drawing.Size(69, 67)
        Me.CmdCalcular.TabIndex = 173
        Me.CmdCalcular.Text = "Calcular"
        Me.CmdCalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdCalcular.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Ingresos)
        Me.TabControl1.Controls.Add(Me.Deducciones)
        Me.TabControl1.Controls.Add(Me.Configuracion)
        Me.TabControl1.Location = New System.Drawing.Point(12, 107)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1014, 283)
        Me.TabControl1.TabIndex = 174
        '
        'Ingresos
        '
        Me.Ingresos.Controls.Add(Me.TDGridIngresos)
        Me.Ingresos.Location = New System.Drawing.Point(4, 22)
        Me.Ingresos.Name = "Ingresos"
        Me.Ingresos.Padding = New System.Windows.Forms.Padding(3)
        Me.Ingresos.Size = New System.Drawing.Size(1006, 257)
        Me.Ingresos.TabIndex = 0
        Me.Ingresos.Text = "Ingresos"
        Me.Ingresos.UseVisualStyleBackColor = True
        '
        'TDGridIngresos
        '
        Me.TDGridIngresos.AlternatingRows = True
        Me.TDGridIngresos.Caption = "Listado de Nominas"
        Me.TDGridIngresos.FilterBar = True
        Me.TDGridIngresos.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridIngresos.Images.Add(CType(resources.GetObject("TDGridIngresos.Images"), System.Drawing.Image))
        Me.TDGridIngresos.Location = New System.Drawing.Point(6, 6)
        Me.TDGridIngresos.Name = "TDGridIngresos"
        Me.TDGridIngresos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridIngresos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridIngresos.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridIngresos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridIngresos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridIngresos.Size = New System.Drawing.Size(964, 229)
        Me.TDGridIngresos.TabIndex = 170
        Me.TDGridIngresos.Text = "C1TrueDBGrid1"
        Me.TDGridIngresos.PropBag = resources.GetString("TDGridIngresos.PropBag")
        '
        'Deducciones
        '
        Me.Deducciones.Controls.Add(Me.TDGridDeducciones)
        Me.Deducciones.Location = New System.Drawing.Point(4, 22)
        Me.Deducciones.Name = "Deducciones"
        Me.Deducciones.Padding = New System.Windows.Forms.Padding(3)
        Me.Deducciones.Size = New System.Drawing.Size(1006, 257)
        Me.Deducciones.TabIndex = 1
        Me.Deducciones.Text = "Deducciones"
        Me.Deducciones.UseVisualStyleBackColor = True
        '
        'TDGridDeducciones
        '
        Me.TDGridDeducciones.AlternatingRows = True
        Me.TDGridDeducciones.Caption = "Listado de Nominas"
        Me.TDGridDeducciones.FilterBar = True
        Me.TDGridDeducciones.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridDeducciones.Images.Add(CType(resources.GetObject("TDGridDeducciones.Images"), System.Drawing.Image))
        Me.TDGridDeducciones.Location = New System.Drawing.Point(6, 6)
        Me.TDGridDeducciones.Name = "TDGridDeducciones"
        Me.TDGridDeducciones.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridDeducciones.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridDeducciones.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridDeducciones.PrintInfo.PageSettings = CType(resources.GetObject("TDGridDeducciones.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridDeducciones.Size = New System.Drawing.Size(994, 229)
        Me.TDGridDeducciones.TabIndex = 171
        Me.TDGridDeducciones.Text = "C1TrueDBGrid1"
        Me.TDGridDeducciones.PropBag = resources.GetString("TDGridDeducciones.PropBag")
        '
        'Configuracion
        '
        Me.Configuracion.Controls.Add(Me.Button3)
        Me.Configuracion.Controls.Add(Me.TxtNuevoPrecio)
        Me.Configuracion.Controls.Add(Me.Label16)
        Me.Configuracion.Controls.Add(Me.Button1)
        Me.Configuracion.Controls.Add(Me.TDGridDeducciones2)
        Me.Configuracion.Controls.Add(Me.GroupBox2)
        Me.Configuracion.Location = New System.Drawing.Point(4, 22)
        Me.Configuracion.Name = "Configuracion"
        Me.Configuracion.Size = New System.Drawing.Size(1006, 257)
        Me.Configuracion.TabIndex = 2
        Me.Configuracion.Text = "Configuracion"
        Me.Configuracion.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button3.Location = New System.Drawing.Point(332, 212)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 23)
        Me.Button3.TabIndex = 206
        Me.Button3.Text = "Cambiar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxtNuevoPrecio
        '
        Me.TxtNuevoPrecio.Location = New System.Drawing.Point(283, 214)
        Me.TxtNuevoPrecio.Name = "TxtNuevoPrecio"
        Me.TxtNuevoPrecio.Size = New System.Drawing.Size(43, 20)
        Me.TxtNuevoPrecio.TabIndex = 174
        Me.TxtNuevoPrecio.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(169, 216)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 13)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "Nuevo Precio Planilla"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(905, 213)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 172
        Me.Button1.Text = "Borrar Linea"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TDGridDeducciones2
        '
        Me.TDGridDeducciones2.AllowAddNew = True
        Me.TDGridDeducciones2.AlternatingRows = True
        Me.TDGridDeducciones2.Caption = "Deducciones"
        Me.TDGridDeducciones2.Enabled = False
        Me.TDGridDeducciones2.FilterBar = True
        Me.TDGridDeducciones2.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridDeducciones2.Images.Add(CType(resources.GetObject("TDGridDeducciones2.Images"), System.Drawing.Image))
        Me.TDGridDeducciones2.Location = New System.Drawing.Point(158, 19)
        Me.TDGridDeducciones2.Name = "TDGridDeducciones2"
        Me.TDGridDeducciones2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridDeducciones2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridDeducciones2.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridDeducciones2.PrintInfo.PageSettings = CType(resources.GetObject("TDGridDeducciones2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridDeducciones2.Size = New System.Drawing.Size(838, 187)
        Me.TDGridDeducciones2.TabIndex = 171
        Me.TDGridDeducciones2.Text = "C1TrueDBGrid1"
        Me.TDGridDeducciones2.PropBag = resources.GetString("TDGridDeducciones2.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtPrecioDomingo)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioSabado)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioViernes)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioJueves)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioMiercoles)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioMartes)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TxtBolsa)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioLunes)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TxtDeduccionPolicia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtIR)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(145, 249)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuracion Planilla"
        '
        'TxtPrecioDomingo
        '
        Me.TxtPrecioDomingo.Location = New System.Drawing.Point(91, 223)
        Me.TxtPrecioDomingo.Name = "TxtPrecioDomingo"
        Me.TxtPrecioDomingo.Size = New System.Drawing.Size(43, 20)
        Me.TxtPrecioDomingo.TabIndex = 187
        Me.TxtPrecioDomingo.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 226)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 186
        Me.Label15.Text = "Precio Domingo"
        '
        'TxtPrecioSabado
        '
        Me.TxtPrecioSabado.Location = New System.Drawing.Point(92, 202)
        Me.TxtPrecioSabado.Name = "TxtPrecioSabado"
        Me.TxtPrecioSabado.Size = New System.Drawing.Size(43, 20)
        Me.TxtPrecioSabado.TabIndex = 185
        Me.TxtPrecioSabado.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 205)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 184
        Me.Label14.Text = "Precio Sabado"
        '
        'TxtPrecioViernes
        '
        Me.TxtPrecioViernes.Location = New System.Drawing.Point(92, 178)
        Me.TxtPrecioViernes.Name = "TxtPrecioViernes"
        Me.TxtPrecioViernes.Size = New System.Drawing.Size(43, 20)
        Me.TxtPrecioViernes.TabIndex = 15
        Me.TxtPrecioViernes.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Precio Viernes"
        '
        'TxtPrecioJueves
        '
        Me.TxtPrecioJueves.Location = New System.Drawing.Point(92, 154)
        Me.TxtPrecioJueves.Name = "TxtPrecioJueves"
        Me.TxtPrecioJueves.Size = New System.Drawing.Size(43, 20)
        Me.TxtPrecioJueves.TabIndex = 13
        Me.TxtPrecioJueves.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Precio Jueves"
        '
        'TxtPrecioMiercoles
        '
        Me.TxtPrecioMiercoles.Location = New System.Drawing.Point(92, 131)
        Me.TxtPrecioMiercoles.Name = "TxtPrecioMiercoles"
        Me.TxtPrecioMiercoles.Size = New System.Drawing.Size(43, 20)
        Me.TxtPrecioMiercoles.TabIndex = 11
        Me.TxtPrecioMiercoles.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 134)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Precio Miercoles"
        '
        'TxtPrecioMartes
        '
        Me.TxtPrecioMartes.Location = New System.Drawing.Point(92, 109)
        Me.TxtPrecioMartes.Name = "TxtPrecioMartes"
        Me.TxtPrecioMartes.Size = New System.Drawing.Size(43, 20)
        Me.TxtPrecioMartes.TabIndex = 9
        Me.TxtPrecioMartes.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Precio Martes"
        '
        'TxtBolsa
        '
        Me.TxtBolsa.Location = New System.Drawing.Point(93, 39)
        Me.TxtBolsa.Name = "TxtBolsa"
        Me.TxtBolsa.Size = New System.Drawing.Size(43, 20)
        Me.TxtBolsa.TabIndex = 7
        Me.TxtBolsa.Text = "0.20"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "% Bolsa"
        '
        'TxtPrecioLunes
        '
        Me.TxtPrecioLunes.Location = New System.Drawing.Point(93, 86)
        Me.TxtPrecioLunes.Name = "TxtPrecioLunes"
        Me.TxtPrecioLunes.Size = New System.Drawing.Size(43, 20)
        Me.TxtPrecioLunes.TabIndex = 5
        Me.TxtPrecioLunes.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Precio Lunes"
        '
        'TxtDeduccionPolicia
        '
        Me.TxtDeduccionPolicia.Location = New System.Drawing.Point(93, 62)
        Me.TxtDeduccionPolicia.Name = "TxtDeduccionPolicia"
        Me.TxtDeduccionPolicia.Size = New System.Drawing.Size(43, 20)
        Me.TxtDeduccionPolicia.TabIndex = 3
        Me.TxtDeduccionPolicia.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "% Otros"
        '
        'TxtIR
        '
        Me.TxtIR.Location = New System.Drawing.Point(95, 16)
        Me.TxtIR.Name = "TxtIR"
        Me.TxtIR.Size = New System.Drawing.Size(43, 20)
        Me.TxtIR.TabIndex = 1
        Me.TxtIR.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "% IR"
        '
        'CmdNomina
        '
        Me.CmdNomina.Enabled = False
        Me.CmdNomina.Image = CType(resources.GetObject("CmdNomina.Image"), System.Drawing.Image)
        Me.CmdNomina.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNomina.Location = New System.Drawing.Point(85, 392)
        Me.CmdNomina.Name = "CmdNomina"
        Me.CmdNomina.Size = New System.Drawing.Size(69, 67)
        Me.CmdNomina.TabIndex = 175
        Me.CmdNomina.Text = "Nomina"
        Me.CmdNomina.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNomina.UseVisualStyleBackColor = True
        '
        'CmdColillas
        '
        Me.CmdColillas.Enabled = False
        Me.CmdColillas.Image = CType(resources.GetObject("CmdColillas.Image"), System.Drawing.Image)
        Me.CmdColillas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdColillas.Location = New System.Drawing.Point(230, 392)
        Me.CmdColillas.Name = "CmdColillas"
        Me.CmdColillas.Size = New System.Drawing.Size(69, 67)
        Me.CmdColillas.TabIndex = 176
        Me.CmdColillas.Text = "Imp Recep"
        Me.CmdColillas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdColillas.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = CType(resources.GetObject("CmdSalir.Image"), System.Drawing.Image)
        Me.CmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdSalir.Location = New System.Drawing.Point(921, 392)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(75, 67)
        Me.CmdSalir.TabIndex = 177
        Me.CmdSalir.Text = "Salir"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Enabled = False
        Me.CmdCerrar.Image = CType(resources.GetObject("CmdCerrar.Image"), System.Drawing.Image)
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCerrar.Location = New System.Drawing.Point(386, 392)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(69, 67)
        Me.CmdCerrar.TabIndex = 178
        Me.CmdCerrar.Text = "Cerrar Nom"
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(463, 392)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(459, 26)
        Me.ProgressBar.TabIndex = 180
        Me.ProgressBar.Visible = False
        '
        'LblProcesando
        '
        Me.LblProcesando.AutoSize = True
        Me.LblProcesando.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProcesando.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblProcesando.Location = New System.Drawing.Point(460, 421)
        Me.LblProcesando.Name = "LblProcesando"
        Me.LblProcesando.Size = New System.Drawing.Size(322, 16)
        Me.LblProcesando.TabIndex = 181
        Me.LblProcesando.Text = "Calculando  00001 JUAN BERMUDEZ HERNANDEZ"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(789, 421)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(133, 23)
        Me.ProgressBar2.TabIndex = 182
        Me.ProgressBar2.Visible = False
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(302, 392)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 67)
        Me.Button2.TabIndex = 183
        Me.Button2.Text = "Imp Colillas"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(156, 392)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(70, 67)
        Me.Button4.TabIndex = 184
        Me.Button4.Text = "Importar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBoxImportar
        '
        Me.GroupBoxImportar.Controls.Add(Me.ProgressBar1)
        Me.GroupBoxImportar.Controls.Add(Me.LblTotalRegistros)
        Me.GroupBoxImportar.Controls.Add(Me.TxtError)
        Me.GroupBoxImportar.Controls.Add(Me.BtnCancelar)
        Me.GroupBoxImportar.Controls.Add(Me.BtnQuitar)
        Me.GroupBoxImportar.Controls.Add(Me.BtnCargar)
        Me.GroupBoxImportar.Controls.Add(Me.BtnAbrir)
        Me.GroupBoxImportar.Controls.Add(Me.TrueDBGridConsultas)
        Me.GroupBoxImportar.Location = New System.Drawing.Point(1073, 79)
        Me.GroupBoxImportar.Name = "GroupBoxImportar"
        Me.GroupBoxImportar.Size = New System.Drawing.Size(1021, 452)
        Me.GroupBoxImportar.TabIndex = 271
        Me.GroupBoxImportar.TabStop = False
        Me.GroupBoxImportar.Text = "Importacion de Compras"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 398)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(538, 20)
        Me.ProgressBar1.TabIndex = 215
        Me.ProgressBar1.Visible = False
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
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(8, 19)
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
        'FrmPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 527)
        Me.Controls.Add(Me.GroupBoxImportar)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.LblProcesando)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.CmdColillas)
        Me.Controls.Add(Me.CmdNomina)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdCalcular)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CmdBorraLinea)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPlanilla"
        Me.Text = "FrmPlanilla"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboTipoPlanilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Ingresos.ResumeLayout(False)
        CType(Me.TDGridIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Deducciones.ResumeLayout(False)
        CType(Me.TDGridDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Configuracion.ResumeLayout(False)
        Me.Configuracion.PerformLayout()
        CType(Me.TDGridDeducciones2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.BindingDeducciones2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxImportar.ResumeLayout(False)
        Me.GroupBoxImportar.PerformLayout()
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdBorraLinea As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboTipoPlanilla As C1.Win.C1List.C1Combo
    Friend WithEvents DTPFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmdCalcular As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Ingresos As System.Windows.Forms.TabPage
    Friend WithEvents Deducciones As System.Windows.Forms.TabPage
    Friend WithEvents TDGridIngresos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TDGridDeducciones As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Configuracion As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtIR As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDeduccionPolicia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmdNomina As System.Windows.Forms.Button
    Friend WithEvents CmdColillas As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents LblTotalPlanilla As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LblProcesando As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents TxtPrecioLunes As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TDGridDeducciones2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtNumNomina As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BindingDeducciones2 As System.Windows.Forms.BindingSource
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtBolsa As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioMiercoles As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioMartes As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioViernes As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioJueves As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioSabado As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioDomingo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtNuevoPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As Button
    Friend WithEvents GroupBoxImportar As GroupBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents LblTotalRegistros As Label
    Friend WithEvents TxtError As TextBox
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnQuitar As Button
    Friend WithEvents BtnCargar As Button
    Friend WithEvents BtnAbrir As Button
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
