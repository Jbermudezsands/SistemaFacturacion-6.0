<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRevalorizar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRevalorizar))
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.Button21 = New System.Windows.Forms.Button
        Me.Button22 = New System.Windows.Forms.Button
        Me.TxtRebalorizarHasta = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtRebalorizaDesde = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.OptCuentasPagarRe = New System.Windows.Forms.RadioButton
        Me.OptCuentasCobrarRe = New System.Windows.Forms.RadioButton
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.BtnRebalorizar = New System.Windows.Forms.Button
        Me.ChkMoneda = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.BtnCalcular = New System.Windows.Forms.Button
        Me.BtnVer = New System.Windows.Forms.Button
        Me.TDGridIngresos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.TDGridIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Button21)
        Me.GroupBox11.Controls.Add(Me.Button22)
        Me.GroupBox11.Controls.Add(Me.TxtRebalorizarHasta)
        Me.GroupBox11.Controls.Add(Me.Label23)
        Me.GroupBox11.Controls.Add(Me.TxtRebalorizaDesde)
        Me.GroupBox11.Controls.Add(Me.Label24)
        Me.GroupBox11.Location = New System.Drawing.Point(9, 56)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(467, 54)
        Me.GroupBox11.TabIndex = 9
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Rango de Cuentas a Filtrar"
        '
        'Button21
        '
        Me.Button21.Image = CType(resources.GetObject("Button21.Image"), System.Drawing.Image)
        Me.Button21.Location = New System.Drawing.Point(403, 10)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(37, 38)
        Me.Button21.TabIndex = 129
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.Image = CType(resources.GetObject("Button22.Image"), System.Drawing.Image)
        Me.Button22.Location = New System.Drawing.Point(172, 10)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(37, 38)
        Me.Button22.TabIndex = 128
        Me.Button22.UseVisualStyleBackColor = True
        '
        'TxtRebalorizarHasta
        '
        Me.TxtRebalorizarHasta.Location = New System.Drawing.Point(297, 22)
        Me.TxtRebalorizarHasta.Name = "TxtRebalorizarHasta"
        Me.TxtRebalorizarHasta.Size = New System.Drawing.Size(100, 20)
        Me.TxtRebalorizarHasta.TabIndex = 9
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(253, 25)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(35, 13)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "Hasta"
        '
        'TxtRebalorizaDesde
        '
        Me.TxtRebalorizaDesde.Location = New System.Drawing.Point(66, 22)
        Me.TxtRebalorizaDesde.Name = "TxtRebalorizaDesde"
        Me.TxtRebalorizaDesde.Size = New System.Drawing.Size(100, 20)
        Me.TxtRebalorizaDesde.TabIndex = 7
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(22, 25)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(38, 13)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Desde"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.OptCuentasPagarRe)
        Me.GroupBox10.Controls.Add(Me.OptCuentasCobrarRe)
        Me.GroupBox10.Location = New System.Drawing.Point(9, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(467, 44)
        Me.GroupBox10.TabIndex = 8
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Tipo de Cuentas"
        '
        'OptCuentasPagarRe
        '
        Me.OptCuentasPagarRe.AutoSize = True
        Me.OptCuentasPagarRe.Location = New System.Drawing.Point(185, 19)
        Me.OptCuentasPagarRe.Name = "OptCuentasPagarRe"
        Me.OptCuentasPagarRe.Size = New System.Drawing.Size(103, 17)
        Me.OptCuentasPagarRe.TabIndex = 1
        Me.OptCuentasPagarRe.TabStop = True
        Me.OptCuentasPagarRe.Text = "Cuentas x Pagar"
        Me.OptCuentasPagarRe.UseVisualStyleBackColor = True
        '
        'OptCuentasCobrarRe
        '
        Me.OptCuentasCobrarRe.AutoSize = True
        Me.OptCuentasCobrarRe.Checked = True
        Me.OptCuentasCobrarRe.Location = New System.Drawing.Point(20, 19)
        Me.OptCuentasCobrarRe.Name = "OptCuentasCobrarRe"
        Me.OptCuentasCobrarRe.Size = New System.Drawing.Size(106, 17)
        Me.OptCuentasCobrarRe.TabIndex = 0
        Me.OptCuentasCobrarRe.TabStop = True
        Me.OptCuentasCobrarRe.Text = "Cuentas x Cobrar"
        Me.OptCuentasCobrarRe.UseVisualStyleBackColor = True
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.CustomFormat = ""
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(102, 116)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaFin.TabIndex = 191
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 118)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(87, 13)
        Me.Label25.TabIndex = 190
        Me.Label25.Text = "Fecha Ejecucion"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 142)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(639, 23)
        Me.ProgressBar.TabIndex = 189
        '
        'BtnRebalorizar
        '
        Me.BtnRebalorizar.Image = CType(resources.GetObject("BtnRebalorizar.Image"), System.Drawing.Image)
        Me.BtnRebalorizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnRebalorizar.Location = New System.Drawing.Point(583, 21)
        Me.BtnRebalorizar.Name = "BtnRebalorizar"
        Me.BtnRebalorizar.Size = New System.Drawing.Size(74, 73)
        Me.BtnRebalorizar.TabIndex = 192
        Me.BtnRebalorizar.Tag = "25"
        Me.BtnRebalorizar.Text = "Ejecutar"
        Me.BtnRebalorizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnRebalorizar.UseVisualStyleBackColor = True
        '
        'ChkMoneda
        '
        Me.ChkMoneda.AutoSize = True
        Me.ChkMoneda.Checked = True
        Me.ChkMoneda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMoneda.Enabled = False
        Me.ChkMoneda.Location = New System.Drawing.Point(255, 116)
        Me.ChkMoneda.Name = "ChkMoneda"
        Me.ChkMoneda.Size = New System.Drawing.Size(121, 17)
        Me.ChkMoneda.TabIndex = 193
        Me.ChkMoneda.Text = "Facturas en Dolares"
        Me.ChkMoneda.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(759, 458)
        Me.TabControl1.TabIndex = 194
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ProgressBar2)
        Me.TabPage1.Controls.Add(Me.BtnSalir)
        Me.TabPage1.Controls.Add(Me.BtnCalcular)
        Me.TabPage1.Controls.Add(Me.BtnVer)
        Me.TabPage1.Controls.Add(Me.TDGridIngresos)
        Me.TabPage1.Controls.Add(Me.GroupBox10)
        Me.TabPage1.Controls.Add(Me.ProgressBar)
        Me.TabPage1.Controls.Add(Me.ChkMoneda)
        Me.TabPage1.Controls.Add(Me.DTPFechaFin)
        Me.TabPage1.Controls.Add(Me.GroupBox11)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.BtnRebalorizar)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(751, 432)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.AccessibleName = "Bt"
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(670, 21)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(74, 73)
        Me.BtnSalir.TabIndex = 198
        Me.BtnSalir.Tag = "25"
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnCalcular
        '
        Me.BtnCalcular.Image = CType(resources.GetObject("BtnCalcular.Image"), System.Drawing.Image)
        Me.BtnCalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCalcular.Location = New System.Drawing.Point(503, 21)
        Me.BtnCalcular.Name = "BtnCalcular"
        Me.BtnCalcular.Size = New System.Drawing.Size(74, 73)
        Me.BtnCalcular.TabIndex = 196
        Me.BtnCalcular.Tag = "25"
        Me.BtnCalcular.Text = "Calcular"
        Me.BtnCalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCalcular.UseVisualStyleBackColor = True
        '
        'BtnVer
        '
        Me.BtnVer.Image = CType(resources.GetObject("BtnVer.Image"), System.Drawing.Image)
        Me.BtnVer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnVer.Location = New System.Drawing.Point(678, 179)
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(66, 43)
        Me.BtnVer.TabIndex = 195
        Me.BtnVer.Tag = "25"
        Me.BtnVer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnVer.UseVisualStyleBackColor = True
        '
        'TDGridIngresos
        '
        Me.TDGridIngresos.AlternatingRows = True
        Me.TDGridIngresos.Caption = "Listado de Nominas"
        Me.TDGridIngresos.FilterBar = True
        Me.TDGridIngresos.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridIngresos.Images.Add(CType(resources.GetObject("TDGridIngresos.Images"), System.Drawing.Image))
        Me.TDGridIngresos.Location = New System.Drawing.Point(6, 202)
        Me.TDGridIngresos.Name = "TDGridIngresos"
        Me.TDGridIngresos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridIngresos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridIngresos.PreviewInfo.ZoomFactor = 75
        Me.TDGridIngresos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridIngresos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridIngresos.Size = New System.Drawing.Size(663, 224)
        Me.TDGridIngresos.TabIndex = 194
        Me.TDGridIngresos.Text = "C1TrueDBGrid1"
        Me.TDGridIngresos.PropBag = resources.GetString("TDGridIngresos.PropBag")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.C1TrueDBGrid1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(751, 411)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle Facturas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.AlternatingRows = True
        Me.C1TrueDBGrid1.Caption = "Listado de Nominas"
        Me.C1TrueDBGrid1.FilterBar = True
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(15, 22)
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(717, 326)
        Me.C1TrueDBGrid1.TabIndex = 195
        Me.C1TrueDBGrid1.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Check3.png")
        Me.ImageList.Images.SetKeyName(1, "Uncheked3.png")
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(12, 171)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(320, 23)
        Me.ProgressBar2.TabIndex = 199
        '
        'FrmRevalorizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 466)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmRevalorizar"
        Me.Text = "FrmRevalorizar"
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.TDGridIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents TxtRebalorizarHasta As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtRebalorizaDesde As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents OptCuentasPagarRe As System.Windows.Forms.RadioButton
    Friend WithEvents OptCuentasCobrarRe As System.Windows.Forms.RadioButton
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnRebalorizar As System.Windows.Forms.Button
    Friend WithEvents ChkMoneda As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TDGridIngresos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents BtnVer As System.Windows.Forms.Button
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnCalcular As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
End Class
