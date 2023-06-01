<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjustarTodos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjustarTodos))
        Me.ChkSseries = New System.Windows.Forms.CheckBox()
        Me.CmbSerie = New C1.Win.C1List.C1Combo()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.OptDolares = New System.Windows.Forms.RadioButton()
        Me.OptCordobas = New System.Windows.Forms.RadioButton()
        Me.TxtMonto = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CboCodigoDesde = New C1.Win.C1List.C1Combo()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.FrmAjusteRango = New System.Windows.Forms.Button()
        Me.CboCodigoHasta = New C1.Win.C1List.C1Combo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChkSseries
        '
        Me.ChkSseries.AutoSize = True
        Me.ChkSseries.Checked = True
        Me.ChkSseries.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSseries.Location = New System.Drawing.Point(295, 104)
        Me.ChkSseries.Name = "ChkSseries"
        Me.ChkSseries.Size = New System.Drawing.Size(135, 17)
        Me.ChkSseries.TabIndex = 234
        Me.ChkSseries.Text = "Consecutivo Sin Series"
        Me.ChkSseries.UseVisualStyleBackColor = True
        '
        'CmbSerie
        '
        Me.CmbSerie.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbSerie.Caption = ""
        Me.CmbSerie.CaptionHeight = 17
        Me.CmbSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbSerie.ColumnCaptionHeight = 17
        Me.CmbSerie.ColumnFooterHeight = 17
        Me.CmbSerie.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CmbSerie.ContentHeight = 15
        Me.CmbSerie.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbSerie.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbSerie.DropDownWidth = 100
        Me.CmbSerie.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbSerie.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSerie.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbSerie.EditorHeight = 15
        Me.CmbSerie.Images.Add(CType(resources.GetObject("CmbSerie.Images"), System.Drawing.Image))
        Me.CmbSerie.ItemHeight = 15
        Me.CmbSerie.Location = New System.Drawing.Point(226, 100)
        Me.CmbSerie.MatchEntryTimeout = CType(2000, Long)
        Me.CmbSerie.MaxDropDownItems = CType(5, Short)
        Me.CmbSerie.MaxLength = 32767
        Me.CmbSerie.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbSerie.Name = "CmbSerie"
        Me.CmbSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbSerie.Size = New System.Drawing.Size(43, 21)
        Me.CmbSerie.TabIndex = 233
        Me.CmbSerie.Visible = False
        Me.CmbSerie.PropBag = resources.GetString("CmbSerie.PropBag")
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(89, 160)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(260, 14)
        Me.ProgressBar.TabIndex = 232
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(8, 156)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 34)
        Me.Button4.TabIndex = 231
        Me.Button4.Tag = "28"
        Me.Button4.Text = "Ajustes"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(355, 156)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 230
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptDolares)
        Me.GroupBox2.Controls.Add(Me.OptCordobas)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(226, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(171, 32)
        Me.GroupBox2.TabIndex = 229
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
        'TxtMonto
        '
        Me.TxtMonto.Location = New System.Drawing.Point(102, 87)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(104, 20)
        Me.TxtMonto.TabIndex = 228
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "Saldo Menor"
        '
        'DTPFechaFin
        '
        Me.DTPFechaFin.CustomFormat = ""
        Me.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFin.Location = New System.Drawing.Point(102, 61)
        Me.DTPFechaFin.Name = "DTPFechaFin"
        Me.DTPFechaFin.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaFin.TabIndex = 226
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 225
        Me.Label1.Text = "Fecha Fin"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(185, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 30)
        Me.Button2.TabIndex = 220
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CboCodigoDesde
        '
        Me.CboCodigoDesde.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoDesde.Caption = ""
        Me.CboCodigoDesde.CaptionHeight = 17
        Me.CboCodigoDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoDesde.ColumnCaptionHeight = 17
        Me.CboCodigoDesde.ColumnFooterHeight = 17
        Me.CboCodigoDesde.ContentHeight = 15
        Me.CboCodigoDesde.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoDesde.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoDesde.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoDesde.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoDesde.EditorHeight = 15
        Me.CboCodigoDesde.Images.Add(CType(resources.GetObject("CboCodigoDesde.Images"), System.Drawing.Image))
        Me.CboCodigoDesde.ItemHeight = 15
        Me.CboCodigoDesde.Location = New System.Drawing.Point(102, 9)
        Me.CboCodigoDesde.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoDesde.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoDesde.MaxLength = 32767
        Me.CboCodigoDesde.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoDesde.Name = "CboCodigoDesde"
        Me.CboCodigoDesde.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoDesde.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoDesde.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoDesde.Size = New System.Drawing.Size(77, 21)
        Me.CboCodigoDesde.TabIndex = 218
        Me.CboCodigoDesde.PropBag = resources.GetString("CboCodigoDesde.PropBag")
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(19, 14)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(77, 13)
        Me.LblCodigo.TabIndex = 219
        Me.LblCodigo.Text = "Codigo Desde:"
        '
        'FrmAjusteRango
        '
        Me.FrmAjusteRango.Image = CType(resources.GetObject("FrmAjusteRango.Image"), System.Drawing.Image)
        Me.FrmAjusteRango.Location = New System.Drawing.Point(403, 5)
        Me.FrmAjusteRango.Name = "FrmAjusteRango"
        Me.FrmAjusteRango.Size = New System.Drawing.Size(29, 30)
        Me.FrmAjusteRango.TabIndex = 237
        Me.FrmAjusteRango.UseVisualStyleBackColor = True
        '
        'CboCodigoHasta
        '
        Me.CboCodigoHasta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoHasta.Caption = ""
        Me.CboCodigoHasta.CaptionHeight = 17
        Me.CboCodigoHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoHasta.ColumnCaptionHeight = 17
        Me.CboCodigoHasta.ColumnFooterHeight = 17
        Me.CboCodigoHasta.ContentHeight = 15
        Me.CboCodigoHasta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoHasta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoHasta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoHasta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoHasta.EditorHeight = 15
        Me.CboCodigoHasta.Images.Add(CType(resources.GetObject("CboCodigoHasta.Images"), System.Drawing.Image))
        Me.CboCodigoHasta.ItemHeight = 15
        Me.CboCodigoHasta.Location = New System.Drawing.Point(320, 12)
        Me.CboCodigoHasta.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoHasta.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoHasta.MaxLength = 32767
        Me.CboCodigoHasta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoHasta.Name = "CboCodigoHasta"
        Me.CboCodigoHasta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoHasta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoHasta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoHasta.Size = New System.Drawing.Size(77, 21)
        Me.CboCodigoHasta.TabIndex = 235
        Me.CboCodigoHasta.PropBag = resources.GetString("CboCodigoHasta.PropBag")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(240, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 236
        Me.Label3.Text = "Codigo Hasta:"
        '
        'DTPFechaInicio
        '
        Me.DTPFechaInicio.CustomFormat = ""
        Me.DTPFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicio.Location = New System.Drawing.Point(102, 38)
        Me.DTPFechaInicio.Name = "DTPFechaInicio"
        Me.DTPFechaInicio.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaInicio.TabIndex = 239
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 238
        Me.Label4.Text = "Fecha Inicio"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 131)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(418, 23)
        Me.ProgressBar1.TabIndex = 240
        '
        'FrmAjustarTodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 195)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.DTPFechaInicio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FrmAjusteRango)
        Me.Controls.Add(Me.CboCodigoHasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ChkSseries)
        Me.Controls.Add(Me.CmbSerie)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtMonto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPFechaFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CboCodigoDesde)
        Me.Controls.Add(Me.LblCodigo)
        Me.Name = "FrmAjustarTodos"
        Me.Text = "Ajustar Todos"
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoHasta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChkSseries As CheckBox
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Button4 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents OptDolares As RadioButton
    Friend WithEvents OptCordobas As RadioButton
    Friend WithEvents TxtMonto As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents DTPFechaFin As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents CboCodigoDesde As C1.Win.C1List.C1Combo
    Friend WithEvents LblCodigo As Label
    Friend WithEvents FrmAjusteRango As Button
    Friend WithEvents CboCodigoHasta As C1.Win.C1List.C1Combo
    Friend WithEvents Label3 As Label
    Friend WithEvents DTPFechaInicio As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
