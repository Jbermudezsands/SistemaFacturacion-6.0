<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCuentasXCobrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentasXCobrar))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblNombres = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.OptDolares = New System.Windows.Forms.RadioButton()
        Me.OptCordobas = New System.Windows.Forms.RadioButton()
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CboCodigoCliente = New C1.Win.C1List.C1Combo()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.DTPFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.TDGridImpuestos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStripGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AsignarFacturaAlReciboToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularNotasDeDebitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularNotasDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjustarDiferencialCambiarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtNB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtMora = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtSaldoFinal = New System.Windows.Forms.TextBox()
        Me.TxtAbonos = New System.Windows.Forms.TextBox()
        Me.TxtCargos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdAjustes = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripGrid.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblNombres)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CboCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.LblCodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.CmdGrabar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 131)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LblNombres
        '
        Me.LblNombres.AutoSize = True
        Me.LblNombres.Location = New System.Drawing.Point(23, 49)
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Size = New System.Drawing.Size(0, 13)
        Me.LblNombres.TabIndex = 202
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptDolares)
        Me.GroupBox2.Controls.Add(Me.OptCordobas)
        Me.GroupBox2.Location = New System.Drawing.Point(109, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(171, 32)
        Me.GroupBox2.TabIndex = 201
        Me.GroupBox2.TabStop = False
        '
        'OptDolares
        '
        Me.OptDolares.AutoSize = True
        Me.OptDolares.Location = New System.Drawing.Point(95, 8)
        Me.OptDolares.Name = "OptDolares"
        Me.OptDolares.Size = New System.Drawing.Size(61, 17)
        Me.OptDolares.TabIndex = 1
        Me.OptDolares.Text = "Dolares"
        Me.OptDolares.UseVisualStyleBackColor = True
        '
        'OptCordobas
        '
        Me.OptCordobas.AutoSize = True
        Me.OptCordobas.Checked = True
        Me.OptCordobas.Location = New System.Drawing.Point(15, 9)
        Me.OptCordobas.Name = "OptCordobas"
        Me.OptCordobas.Size = New System.Drawing.Size(70, 17)
        Me.OptCordobas.TabIndex = 0
        Me.OptCordobas.TabStop = True
        Me.OptCordobas.Text = "Cordobas"
        Me.OptCordobas.UseVisualStyleBackColor = True
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.CustomFormat = ""
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(175, 70)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaFin.TabIndex = 186
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(105, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 185
        Me.Label6.Text = "Fecha Fin"
        '
        'CboCodigoCliente
        '
        Me.CboCodigoCliente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoCliente.Caption = ""
        Me.CboCodigoCliente.CaptionHeight = 17
        Me.CboCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoCliente.ColumnCaptionHeight = 17
        Me.CboCodigoCliente.ColumnFooterHeight = 17
        Me.CboCodigoCliente.ContentHeight = 15
        Me.CboCodigoCliente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoCliente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoCliente.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoCliente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoCliente.EditorHeight = 15
        Me.CboCodigoCliente.Images.Add(CType(resources.GetObject("CboCodigoCliente.Images"), System.Drawing.Image))
        Me.CboCodigoCliente.ItemHeight = 15
        Me.CboCodigoCliente.Location = New System.Drawing.Point(108, 23)
        Me.CboCodigoCliente.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoCliente.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoCliente.MaxLength = 32767
        Me.CboCodigoCliente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoCliente.Name = "CboCodigoCliente"
        Me.CboCodigoCliente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoCliente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.Size = New System.Drawing.Size(304, 21)
        Me.CboCodigoCliente.TabIndex = 182
        Me.CboCodigoCliente.PropBag = resources.GetString("CboCodigoCliente.PropBag")
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(23, 23)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(80, 13)
        Me.LblCodigo.TabIndex = 183
        Me.LblCodigo.Text = "Codigo Clientes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(252, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Fecha Inicio"
        Me.Label2.Visible = False
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(418, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 30)
        Me.Button2.TabIndex = 172
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(369, 53)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 184
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Consultar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'DTPFechaIni
        '
        Me.DTPFechaIni.CustomFormat = ""
        Me.DTPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaIni.Location = New System.Drawing.Point(334, 190)
        Me.DTPFechaIni.Name = "DTPFechaIni"
        Me.DTPFechaIni.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaIni.TabIndex = 132
        Me.DTPFechaIni.Visible = False
        '
        'TDGridImpuestos
        '
        Me.TDGridImpuestos.AllowUpdate = False
        Me.TDGridImpuestos.AlternatingRows = True
        Me.TDGridImpuestos.Caption = "Listado de Impuestos para Liquidacion de Productos"
        Me.TDGridImpuestos.ContextMenuStrip = Me.ContextMenuStripGrid
        Me.TDGridImpuestos.FilterBar = True
        Me.TDGridImpuestos.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridImpuestos.Images.Add(CType(resources.GetObject("TDGridImpuestos.Images"), System.Drawing.Image))
        Me.TDGridImpuestos.Location = New System.Drawing.Point(12, 200)
        Me.TDGridImpuestos.Name = "TDGridImpuestos"
        Me.TDGridImpuestos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridImpuestos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridImpuestos.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridImpuestos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridImpuestos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridImpuestos.Size = New System.Drawing.Size(902, 208)
        Me.TDGridImpuestos.TabIndex = 130
        Me.TDGridImpuestos.Text = "C1TrueDBGrid1"
        Me.TDGridImpuestos.PropBag = resources.GetString("TDGridImpuestos.PropBag")
        '
        'ContextMenuStripGrid
        '
        Me.ContextMenuStripGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsignarFacturaAlReciboToolStripMenuItem, Me.AnularNotasDeDebitoToolStripMenuItem, Me.AnularNotasDeCreditoToolStripMenuItem, Me.AjustarDiferencialCambiarioToolStripMenuItem, Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem})
        Me.ContextMenuStripGrid.Name = "ContextMenuStripGrid"
        Me.ContextMenuStripGrid.Size = New System.Drawing.Size(249, 114)
        '
        'AsignarFacturaAlReciboToolStripMenuItem
        '
        Me.AsignarFacturaAlReciboToolStripMenuItem.Name = "AsignarFacturaAlReciboToolStripMenuItem"
        Me.AsignarFacturaAlReciboToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AsignarFacturaAlReciboToolStripMenuItem.Text = "Asignar Factura al Recibo"
        '
        'AnularNotasDeDebitoToolStripMenuItem
        '
        Me.AnularNotasDeDebitoToolStripMenuItem.Name = "AnularNotasDeDebitoToolStripMenuItem"
        Me.AnularNotasDeDebitoToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AnularNotasDeDebitoToolStripMenuItem.Text = "Crear Recibo"
        '
        'AnularNotasDeCreditoToolStripMenuItem
        '
        Me.AnularNotasDeCreditoToolStripMenuItem.Name = "AnularNotasDeCreditoToolStripMenuItem"
        Me.AnularNotasDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AnularNotasDeCreditoToolStripMenuItem.Text = "Anular Notas de Credito"
        '
        'AjustarDiferencialCambiarioToolStripMenuItem
        '
        Me.AjustarDiferencialCambiarioToolStripMenuItem.Name = "AjustarDiferencialCambiarioToolStripMenuItem"
        Me.AjustarDiferencialCambiarioToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AjustarDiferencialCambiarioToolStripMenuItem.Text = "Ajustar Diferencial Cambiario"
        '
        'AsignarFacturaALaNotaDeCreditoToolStripMenuItem
        '
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Name = "AsignarFacturaALaNotaDeCreditoToolStripMenuItem"
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Text = "Asignar Factura a la Nota Credito"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(228, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(433, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 132
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-5, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(937, 60)
        Me.PictureBox1.TabIndex = 133
        Me.PictureBox1.TabStop = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 414)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(902, 26)
        Me.ProgressBar.TabIndex = 134
        Me.ProgressBar.Visible = False
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(754, 69)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 34)
        Me.Button6.TabIndex = 171
        Me.Button6.Tag = "27"
        Me.Button6.Text = "Imprimir"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(673, 69)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 34)
        Me.Button5.TabIndex = 170
        Me.Button5.Tag = "25"
        Me.Button5.Text = "Debito"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(754, 108)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 176
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(673, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 34)
        Me.Button1.TabIndex = 177
        Me.Button1.Tag = "26"
        Me.Button1.Text = "Credito"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(673, 148)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 34)
        Me.Button3.TabIndex = 178
        Me.Button3.Tag = "28"
        Me.Button3.Text = "Recibos"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtNB)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TxtMora)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.TxtSaldoFinal)
        Me.GroupBox3.Controls.Add(Me.TxtAbonos)
        Me.GroupBox3.Controls.Add(Me.TxtCargos)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(480, 63)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(187, 128)
        Me.GroupBox3.TabIndex = 185
        Me.GroupBox3.TabStop = False
        '
        'TxtNB
        '
        Me.TxtNB.Location = New System.Drawing.Point(76, 57)
        Me.TxtNB.Name = "TxtNB"
        Me.TxtNB.Size = New System.Drawing.Size(100, 20)
        Me.TxtNB.TabIndex = 216
        Me.TxtNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 215
        Me.Label7.Text = "NB/NC"
        '
        'TxtMora
        '
        Me.TxtMora.Location = New System.Drawing.Point(76, 81)
        Me.TxtMora.Name = "TxtMora"
        Me.TxtMora.Size = New System.Drawing.Size(100, 20)
        Me.TxtMora.TabIndex = 214
        Me.TxtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 213
        Me.Label1.Text = "Mora"
        '
        'TxtSaldoFinal
        '
        Me.TxtSaldoFinal.Location = New System.Drawing.Point(76, 104)
        Me.TxtSaldoFinal.Name = "TxtSaldoFinal"
        Me.TxtSaldoFinal.Size = New System.Drawing.Size(100, 20)
        Me.TxtSaldoFinal.TabIndex = 212
        Me.TxtSaldoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAbonos
        '
        Me.TxtAbonos.Location = New System.Drawing.Point(76, 35)
        Me.TxtAbonos.Name = "TxtAbonos"
        Me.TxtAbonos.Size = New System.Drawing.Size(100, 20)
        Me.TxtAbonos.TabIndex = 211
        Me.TxtAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCargos
        '
        Me.TxtCargos.Location = New System.Drawing.Point(76, 12)
        Me.TxtCargos.Name = "TxtCargos"
        Me.TxtCargos.Size = New System.Drawing.Size(100, 20)
        Me.TxtCargos.TabIndex = 210
        Me.TxtCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 209
        Me.Label5.Text = "Saldo Final"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 208
        Me.Label4.Text = "Abonos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "Cargos"
        '
        'CmdAjustes
        '
        Me.CmdAjustes.Enabled = False
        Me.CmdAjustes.Image = CType(resources.GetObject("CmdAjustes.Image"), System.Drawing.Image)
        Me.CmdAjustes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAjustes.Location = New System.Drawing.Point(754, 148)
        Me.CmdAjustes.Name = "CmdAjustes"
        Me.CmdAjustes.Size = New System.Drawing.Size(75, 34)
        Me.CmdAjustes.TabIndex = 186
        Me.CmdAjustes.Tag = "28"
        Me.CmdAjustes.Text = "Ajustes"
        Me.CmdAjustes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAjustes.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(838, 69)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 34)
        Me.Button4.TabIndex = 187
        Me.Button4.Tag = "28"
        Me.Button4.Text = "Ajustes Total"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'FrmCuentasXCobrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 452)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.CmdAjustes)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TDGridImpuestos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DTPFechaIni)
        Me.Name = "FrmCuentasXCobrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas x Cobrar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripGrid.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TDGridImpuestos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CboCodigoCliente As C1.Win.C1List.C1Combo
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptDolares As System.Windows.Forms.RadioButton
    Friend WithEvents OptCordobas As System.Windows.Forms.RadioButton
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents LblNombres As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AsignarFacturaAlReciboToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularNotasDeDebitoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularNotasDeCreditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNB As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMora As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSaldoFinal As System.Windows.Forms.TextBox
    Friend WithEvents TxtAbonos As System.Windows.Forms.TextBox
    Friend WithEvents TxtCargos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AjustarDiferencialCambiarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdAjustes As System.Windows.Forms.Button
    Friend WithEvents AsignarFacturaALaNotaDeCreditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button4 As Button
End Class
