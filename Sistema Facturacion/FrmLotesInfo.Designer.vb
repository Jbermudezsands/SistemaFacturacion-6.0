<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLotesInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLotesInfo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DTPFechaLote = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblApellido = New System.Windows.Forms.Label()
        Me.CboLotes = New C1.Win.C1List.C1Combo()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.TDBGridLotes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TxtNumeroLote = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDBGridLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.ChkActivo)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.DTPFechaLote)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblApellido)
        Me.GroupBox1.Controls.Add(Me.CboLotes)
        Me.GroupBox1.Controls.Add(Me.TxtNombre)
        Me.GroupBox1.Controls.Add(Me.LblNombre)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(756, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(652, 17)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 175
        Me.PictureBox2.TabStop = False
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Checked = True
        Me.ChkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivo.Location = New System.Drawing.Point(268, 67)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 174
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(330, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 30)
        Me.Button2.TabIndex = 173
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DTPFechaLote
        '
        Me.DTPFechaLote.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaLote.Location = New System.Drawing.Point(114, 68)
        Me.DTPFechaLote.Name = "DTPFechaLote"
        Me.DTPFechaLote.Size = New System.Drawing.Size(104, 20)
        Me.DTPFechaLote.TabIndex = 140
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "Numero Lotes"
        '
        'LblApellido
        '
        Me.LblApellido.AutoSize = True
        Me.LblApellido.Location = New System.Drawing.Point(14, 67)
        Me.LblApellido.Name = "LblApellido"
        Me.LblApellido.Size = New System.Drawing.Size(98, 13)
        Me.LblApellido.TabIndex = 138
        Me.LblApellido.Text = "Fecha Vencimiento"
        '
        'CboLotes
        '
        Me.CboLotes.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboLotes.Caption = ""
        Me.CboLotes.CaptionHeight = 17
        Me.CboLotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboLotes.ColumnCaptionHeight = 17
        Me.CboLotes.ColumnFooterHeight = 17
        Me.CboLotes.ContentHeight = 15
        Me.CboLotes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboLotes.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboLotes.DropDownWidth = 300
        Me.CboLotes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboLotes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboLotes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboLotes.EditorHeight = 15
        Me.CboLotes.Images.Add(CType(resources.GetObject("CboLotes.Images"), System.Drawing.Image))
        Me.CboLotes.ItemHeight = 15
        Me.CboLotes.Location = New System.Drawing.Point(115, 17)
        Me.CboLotes.MatchEntryTimeout = CType(2000, Long)
        Me.CboLotes.MaxDropDownItems = CType(5, Short)
        Me.CboLotes.MaxLength = 32767
        Me.CboLotes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboLotes.Name = "CboLotes"
        Me.CboLotes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboLotes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboLotes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboLotes.Size = New System.Drawing.Size(209, 21)
        Me.CboLotes.TabIndex = 134
        Me.CboLotes.PropBag = resources.GetString("CboLotes.PropBag")
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(114, 43)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(422, 20)
        Me.TxtNombre.TabIndex = 135
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Location = New System.Drawing.Point(14, 43)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(68, 13)
        Me.LblNombre.TabIndex = 137
        Me.LblNombre.Text = "Nombre Lote"
        '
        'TDBGridLotes
        '
        Me.TDBGridLotes.AllowUpdate = False
        Me.TDBGridLotes.AlternatingRows = True
        Me.TDBGridLotes.Caption = "Detalle de Productos por Lotes"
        Me.TDBGridLotes.FilterBar = True
        Me.TDBGridLotes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDBGridLotes.Images.Add(CType(resources.GetObject("TDBGridLotes.Images"), System.Drawing.Image))
        Me.TDBGridLotes.Location = New System.Drawing.Point(5, 106)
        Me.TDBGridLotes.Name = "TDBGridLotes"
        Me.TDBGridLotes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDBGridLotes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDBGridLotes.PreviewInfo.ZoomFactor = 75.0R
        Me.TDBGridLotes.PrintInfo.PageSettings = CType(resources.GetObject("TDBGridLotes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDBGridLotes.Size = New System.Drawing.Size(756, 288)
        Me.TDBGridLotes.TabIndex = 212
        Me.TDBGridLotes.Text = "C1TrueDBGrid1"
        Me.TDBGridLotes.PropBag = resources.GetString("TDBGridLotes.PropBag")
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(773, 52)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 47)
        Me.Button1.TabIndex = 214
        Me.Button1.Text = "Editar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(777, 378)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(90, 47)
        Me.Button8.TabIndex = 213
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(773, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(94, 41)
        Me.Button3.TabIndex = 215
        Me.Button3.Text = "Nuevo"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(5, 400)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(756, 23)
        Me.ProgressBar1.TabIndex = 217
        '
        'TxtNumeroLote
        '
        Me.TxtNumeroLote.Location = New System.Drawing.Point(767, 171)
        Me.TxtNumeroLote.Name = "TxtNumeroLote"
        Me.TxtNumeroLote.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumeroLote.TabIndex = 218
        Me.TxtNumeroLote.Visible = False
        '
        'FrmLotesInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 434)
        Me.Controls.Add(Me.TxtNumeroLote)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TDBGridLotes)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLotesInfo"
        Me.Text = "FrmLotesInfo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDBGridLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblApellido As System.Windows.Forms.Label
    Friend WithEvents CboLotes As C1.Win.C1List.C1Combo
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents DTPFechaLote As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents TDBGridLotes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents TxtNumeroLote As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
