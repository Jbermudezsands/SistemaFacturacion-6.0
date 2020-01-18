<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCuentasXPagar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentasXPagar))
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TDGridImpuestos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtNB = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtMora = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblNombres = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OptDolares = New System.Windows.Forms.RadioButton
        Me.OptCordobas = New System.Windows.Forms.RadioButton
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.CboCodigoProveedor = New C1.Win.C1List.C1Combo
        Me.LblCodigo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSaldoFinal = New System.Windows.Forms.TextBox
        Me.TxtAbonos = New System.Windows.Forms.TextBox
        Me.TxtCargos = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.DTPFechaIni = New System.Windows.Forms.DateTimePicker
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(677, 150)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 34)
        Me.Button3.TabIndex = 189
        Me.Button3.Text = "Recibos"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(677, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 34)
        Me.Button1.TabIndex = 188
        Me.Button1.Text = "Credito"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(758, 110)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 187
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(758, 71)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 34)
        Me.Button6.TabIndex = 186
        Me.Button6.Text = "Imprimir"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(677, 71)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 34)
        Me.Button5.TabIndex = 185
        Me.Button5.Text = "Debito"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(16, 416)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(902, 26)
        Me.ProgressBar.TabIndex = 184
        Me.ProgressBar.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(258, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(389, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 181
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(937, 60)
        Me.PictureBox1.TabIndex = 183
        Me.PictureBox1.TabStop = False
        '
        'TDGridImpuestos
        '
        Me.TDGridImpuestos.AllowUpdate = False
        Me.TDGridImpuestos.AlternatingRows = True
        Me.TDGridImpuestos.Caption = "Listado de Impuestos para Liquidacion de Productos"
        Me.TDGridImpuestos.FilterBar = True
        Me.TDGridImpuestos.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridImpuestos.Images.Add(CType(resources.GetObject("TDGridImpuestos.Images"), System.Drawing.Image))
        Me.TDGridImpuestos.Location = New System.Drawing.Point(16, 202)
        Me.TDGridImpuestos.Name = "TDGridImpuestos"
        Me.TDGridImpuestos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridImpuestos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridImpuestos.PreviewInfo.ZoomFactor = 75
        Me.TDGridImpuestos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridImpuestos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridImpuestos.Size = New System.Drawing.Size(902, 208)
        Me.TDGridImpuestos.TabIndex = 180
        Me.TDGridImpuestos.Text = "C1TrueDBGrid1"
        Me.TDGridImpuestos.PropBag = resources.GetString("TDGridImpuestos.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtNB)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtMora)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblNombres)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.DTPFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CmdGrabar)
        Me.GroupBox1.Controls.Add(Me.CboCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.LblCodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtSaldoFinal)
        Me.GroupBox1.Controls.Add(Me.TxtAbonos)
        Me.GroupBox1.Controls.Add(Me.TxtCargos)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 131)
        Me.GroupBox1.TabIndex = 179
        Me.GroupBox1.TabStop = False
        '
        'TxtNB
        '
        Me.TxtNB.Location = New System.Drawing.Point(531, 58)
        Me.TxtNB.Name = "TxtNB"
        Me.TxtNB.Size = New System.Drawing.Size(100, 20)
        Me.TxtNB.TabIndex = 206
        Me.TxtNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(466, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "NB/NC"
        '
        'TxtMora
        '
        Me.TxtMora.Location = New System.Drawing.Point(531, 82)
        Me.TxtMora.Name = "TxtMora"
        Me.TxtMora.Size = New System.Drawing.Size(100, 20)
        Me.TxtMora.TabIndex = 204
        Me.TxtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(466, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = "Mora"
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
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(369, 54)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 184
        Me.CmdGrabar.Text = "Consultar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
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
        Me.CboCodigoProveedor.Location = New System.Drawing.Point(115, 23)
        Me.CboCodigoProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoProveedor.MaxLength = 32767
        Me.CboCodigoProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoProveedor.Name = "CboCodigoProveedor"
        Me.CboCodigoProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.Size = New System.Drawing.Size(297, 21)
        Me.CboCodigoProveedor.TabIndex = 182
        Me.CboCodigoProveedor.PropBag = resources.GetString("CboCodigoProveedor.PropBag")
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(6, 23)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(103, 13)
        Me.LblCodigo.TabIndex = 183
        Me.LblCodigo.Text = "Codigo Proveedores"
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
        'TxtSaldoFinal
        '
        Me.TxtSaldoFinal.Location = New System.Drawing.Point(531, 105)
        Me.TxtSaldoFinal.Name = "TxtSaldoFinal"
        Me.TxtSaldoFinal.Size = New System.Drawing.Size(100, 20)
        Me.TxtSaldoFinal.TabIndex = 180
        Me.TxtSaldoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtAbonos
        '
        Me.TxtAbonos.Location = New System.Drawing.Point(531, 36)
        Me.TxtAbonos.Name = "TxtAbonos"
        Me.TxtAbonos.Size = New System.Drawing.Size(100, 20)
        Me.TxtAbonos.TabIndex = 179
        Me.TxtAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCargos
        '
        Me.TxtCargos.Location = New System.Drawing.Point(531, 13)
        Me.TxtCargos.Name = "TxtCargos"
        Me.TxtCargos.Size = New System.Drawing.Size(100, 20)
        Me.TxtCargos.TabIndex = 178
        Me.TxtCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(466, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 176
        Me.Label5.Text = "Saldo Final"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(466, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Abonos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(466, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 174
        Me.Label3.Text = "Cargos"
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
        'DTPFechaIni
        '
        Me.DTPFechaIni.CustomFormat = ""
        Me.DTPFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaIni.Location = New System.Drawing.Point(338, 192)
        Me.DTPFechaIni.Name = "DTPFechaIni"
        Me.DTPFechaIni.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaIni.TabIndex = 182
        Me.DTPFechaIni.Visible = False
        '
        'FrmCuentasXPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 451)
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
        Me.Name = "FrmCuentasXPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas x Pagar"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TDGridImpuestos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNB As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMora As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblNombres As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptDolares As System.Windows.Forms.RadioButton
    Friend WithEvents OptCordobas As System.Windows.Forms.RadioButton
    Friend WithEvents DTPFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents CboCodigoProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSaldoFinal As System.Windows.Forms.TextBox
    Friend WithEvents TxtAbonos As System.Windows.Forms.TextBox
    Friend WithEvents TxtCargos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DTPFechaIni As System.Windows.Forms.DateTimePicker
End Class
