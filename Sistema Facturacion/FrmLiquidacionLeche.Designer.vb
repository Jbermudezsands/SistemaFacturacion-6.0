<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLiquidacionLeche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLiquidacionLeche))
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.LblProcesando = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.CmdCerrar = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdNomina = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Ingresos = New System.Windows.Forms.TabPage
        Me.TDGridIngresos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Deducciones = New System.Windows.Forms.TabPage
        Me.TDGridDeducciones = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Configuracion = New System.Windows.Forms.TabPage
        Me.Button1 = New System.Windows.Forms.Button
        Me.TDGridDeducciones2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtBolsa = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtPrecioUnitario = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtDeduccionPolicia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtIR = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmdCalcular = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.CmdBorraLinea = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtNumNomina = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblTotalPlanilla = New System.Windows.Forms.Label
        Me.DTPFechaIni = New System.Windows.Forms.DateTimePicker
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.Ingresos.SuspendLayout()
        CType(Me.TDGridIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Deducciones.SuspendLayout()
        CType(Me.TDGridDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Configuracion.SuspendLayout()
        CType(Me.TDGridDeducciones2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(763, 419)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(133, 23)
        Me.ProgressBar2.TabIndex = 196
        Me.ProgressBar2.Visible = False
        '
        'LblProcesando
        '
        Me.LblProcesando.AutoSize = True
        Me.LblProcesando.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProcesando.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblProcesando.Location = New System.Drawing.Point(434, 419)
        Me.LblProcesando.Name = "LblProcesando"
        Me.LblProcesando.Size = New System.Drawing.Size(323, 16)
        Me.LblProcesando.TabIndex = 195
        Me.LblProcesando.Text = "Calculando  00001 JUAN BERMUDEZ HERNANDEZ"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(421, 390)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(475, 26)
        Me.ProgressBar.TabIndex = 194
        Me.ProgressBar.Visible = False
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Enabled = False
        Me.CmdCerrar.Image = CType(resources.GetObject("CmdCerrar.Image"), System.Drawing.Image)
        Me.CmdCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCerrar.Location = New System.Drawing.Point(332, 390)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(75, 75)
        Me.CmdCerrar.TabIndex = 193
        Me.CmdCerrar.Text = "Procesar"
        Me.CmdCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = CType(resources.GetObject("CmdSalir.Image"), System.Drawing.Image)
        Me.CmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdSalir.Location = New System.Drawing.Point(917, 390)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(75, 67)
        Me.CmdSalir.TabIndex = 192
        Me.CmdSalir.Text = "Salir"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdNomina
        '
        Me.CmdNomina.Enabled = False
        Me.CmdNomina.Image = CType(resources.GetObject("CmdNomina.Image"), System.Drawing.Image)
        Me.CmdNomina.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNomina.Location = New System.Drawing.Point(89, 390)
        Me.CmdNomina.Name = "CmdNomina"
        Me.CmdNomina.Size = New System.Drawing.Size(75, 75)
        Me.CmdNomina.TabIndex = 190
        Me.CmdNomina.Text = "Imprimir"
        Me.CmdNomina.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNomina.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Ingresos)
        Me.TabControl1.Controls.Add(Me.Deducciones)
        Me.TabControl1.Controls.Add(Me.Configuracion)
        Me.TabControl1.Location = New System.Drawing.Point(8, 148)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1014, 236)
        Me.TabControl1.TabIndex = 189
        '
        'Ingresos
        '
        Me.Ingresos.Controls.Add(Me.TDGridIngresos)
        Me.Ingresos.Location = New System.Drawing.Point(4, 22)
        Me.Ingresos.Name = "Ingresos"
        Me.Ingresos.Padding = New System.Windows.Forms.Padding(3)
        Me.Ingresos.Size = New System.Drawing.Size(1006, 210)
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
        Me.TDGridIngresos.Location = New System.Drawing.Point(7, 10)
        Me.TDGridIngresos.Name = "TDGridIngresos"
        Me.TDGridIngresos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridIngresos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridIngresos.PreviewInfo.ZoomFactor = 75
        Me.TDGridIngresos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridIngresos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridIngresos.Size = New System.Drawing.Size(983, 186)
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
        Me.Deducciones.Size = New System.Drawing.Size(1006, 240)
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
        Me.TDGridDeducciones.PreviewInfo.ZoomFactor = 75
        Me.TDGridDeducciones.PrintInfo.PageSettings = CType(resources.GetObject("TDGridDeducciones.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridDeducciones.Size = New System.Drawing.Size(994, 229)
        Me.TDGridDeducciones.TabIndex = 171
        Me.TDGridDeducciones.Text = "C1TrueDBGrid1"
        Me.TDGridDeducciones.PropBag = resources.GetString("TDGridDeducciones.PropBag")
        '
        'Configuracion
        '
        Me.Configuracion.Controls.Add(Me.Button1)
        Me.Configuracion.Controls.Add(Me.TDGridDeducciones2)
        Me.Configuracion.Controls.Add(Me.GroupBox2)
        Me.Configuracion.Location = New System.Drawing.Point(4, 22)
        Me.Configuracion.Name = "Configuracion"
        Me.Configuracion.Size = New System.Drawing.Size(1006, 240)
        Me.Configuracion.TabIndex = 2
        Me.Configuracion.Text = "Configuracion"
        Me.Configuracion.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(845, 212)
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
        Me.TDGridDeducciones2.PreviewInfo.ZoomFactor = 75
        Me.TDGridDeducciones2.PrintInfo.PageSettings = CType(resources.GetObject("TDGridDeducciones2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridDeducciones2.Size = New System.Drawing.Size(838, 187)
        Me.TDGridDeducciones2.TabIndex = 171
        Me.TDGridDeducciones2.Text = "C1TrueDBGrid1"
        Me.TDGridDeducciones2.PropBag = resources.GetString("TDGridDeducciones2.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtBolsa)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TxtPrecioUnitario)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TxtDeduccionPolicia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtIR)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(145, 222)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuracion Planilla"
        '
        'TxtBolsa
        '
        Me.TxtBolsa.Location = New System.Drawing.Point(93, 58)
        Me.TxtBolsa.Name = "TxtBolsa"
        Me.TxtBolsa.Size = New System.Drawing.Size(43, 20)
        Me.TxtBolsa.TabIndex = 7
        Me.TxtBolsa.Text = "0.50"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "% Bolsa"
        '
        'TxtPrecioUnitario
        '
        Me.TxtPrecioUnitario.Location = New System.Drawing.Point(93, 113)
        Me.TxtPrecioUnitario.Name = "TxtPrecioUnitario"
        Me.TxtPrecioUnitario.Size = New System.Drawing.Size(43, 20)
        Me.TxtPrecioUnitario.TabIndex = 5
        Me.TxtPrecioUnitario.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Precio Unitario"
        '
        'TxtDeduccionPolicia
        '
        Me.TxtDeduccionPolicia.Location = New System.Drawing.Point(93, 84)
        Me.TxtDeduccionPolicia.Name = "TxtDeduccionPolicia"
        Me.TxtDeduccionPolicia.Size = New System.Drawing.Size(43, 20)
        Me.TxtDeduccionPolicia.TabIndex = 3
        Me.TxtDeduccionPolicia.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "% Policia"
        '
        'TxtIR
        '
        Me.TxtIR.Location = New System.Drawing.Point(95, 29)
        Me.TxtIR.Name = "TxtIR"
        Me.TxtIR.Size = New System.Drawing.Size(43, 20)
        Me.TxtIR.TabIndex = 1
        Me.TxtIR.Text = "3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "% IR"
        '
        'CmdCalcular
        '
        Me.CmdCalcular.Enabled = False
        Me.CmdCalcular.Image = CType(resources.GetObject("CmdCalcular.Image"), System.Drawing.Image)
        Me.CmdCalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdCalcular.Location = New System.Drawing.Point(8, 390)
        Me.CmdCalcular.Name = "CmdCalcular"
        Me.CmdCalcular.Size = New System.Drawing.Size(75, 75)
        Me.CmdCalcular.TabIndex = 188
        Me.CmdCalcular.Text = "Calcular"
        Me.CmdCalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdCalcular.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(408, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(198, 13)
        Me.Label9.TabIndex = 187
        Me.Label9.Text = "LIQUIDACION POR PROVEEDOR"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(19, -5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 186
        Me.PictureBox2.TabStop = False
        '
        'CmdBorraLinea
        '
        Me.CmdBorraLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.CmdBorraLinea.Location = New System.Drawing.Point(-4, -5)
        Me.CmdBorraLinea.Name = "CmdBorraLinea"
        Me.CmdBorraLinea.Size = New System.Drawing.Size(1041, 60)
        Me.CmdBorraLinea.TabIndex = 185
        Me.CmdBorraLinea.TabStop = False
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(980, 51)
        Me.GroupBox1.TabIndex = 184
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
        Me.Label7.Size = New System.Drawing.Size(89, 16)
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
        Me.DTPFechaIni.Location = New System.Drawing.Point(96, 18)
        Me.DTPFechaIni.Name = "DTPFechaIni"
        Me.DTPFechaIni.Size = New System.Drawing.Size(117, 20)
        Me.DTPFechaIni.TabIndex = 179
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.Enabled = False
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(304, 19)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(117, 20)
        Me.DTPFechaFin.TabIndex = 178
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(226, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 177
        Me.Label3.Text = "Inicio Periodo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Inicio Periodo"
        '
        'FrmLiquidacionLeche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 470)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.LblProcesando)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.CmdNomina)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdCalcular)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CmdBorraLinea)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmLiquidacionLeche"
        Me.Text = "FrmLiquidacionLeche"
        Me.TabControl1.ResumeLayout(False)
        Me.Ingresos.ResumeLayout(False)
        CType(Me.TDGridIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Deducciones.ResumeLayout(False)
        CType(Me.TDGridDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Configuracion.ResumeLayout(False)
        CType(Me.TDGridDeducciones2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdBorraLinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents LblProcesando As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdNomina As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Ingresos As System.Windows.Forms.TabPage
    Friend WithEvents TDGridIngresos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Deducciones As System.Windows.Forms.TabPage
    Friend WithEvents TDGridDeducciones As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Configuracion As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TDGridDeducciones2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBolsa As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDeduccionPolicia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtIR As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdCalcular As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdBorraLinea As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumNomina As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblTotalPlanilla As System.Windows.Forms.Label
    Friend WithEvents DTPFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
