<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransformacionNueva
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransformacionNueva))
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtObservaciones = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TrueDBGridOrigen = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboCodigoBodega2 = New C1.Win.C1List.C1Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.Label11 = New System.Windows.Forms.Label
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.TrueDBGridDestino = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BtnBorrarLineaDestino = New System.Windows.Forms.Button
        Me.BindingDetalleOrigen = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingDetalleDestino = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox4.SuspendLayout()
        CType(Me.TrueDBGridOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboCodigoBodega2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalleDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button4.Location = New System.Drawing.Point(4, 386)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(94, 23)
        Me.Button4.TabIndex = 228
        Me.Button4.Text = "Borrar Linea"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtObservaciones)
        Me.GroupBox4.Location = New System.Drawing.Point(672, 417)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(466, 83)
        Me.GroupBox4.TabIndex = 225
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Observaciones"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(6, 13)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservaciones.Size = New System.Drawing.Size(460, 64)
        Me.TxtObservaciones.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(94, 425)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 67)
        Me.Button1.TabIndex = 224
        Me.Button1.Tag = "27"
        Me.Button1.Text = "Imprimir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TrueDBGridOrigen
        '
        Me.TrueDBGridOrigen.AllowAddNew = True
        Me.TrueDBGridOrigen.AllowDelete = True
        Me.TrueDBGridOrigen.AlternatingRows = True
        Me.TrueDBGridOrigen.Caption = "Listado de Productos Origen"
        Me.TrueDBGridOrigen.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridOrigen.Images.Add(CType(resources.GetObject("TrueDBGridOrigen.Images"), System.Drawing.Image))
        Me.TrueDBGridOrigen.Location = New System.Drawing.Point(4, 187)
        Me.TrueDBGridOrigen.Name = "TrueDBGridOrigen"
        Me.TrueDBGridOrigen.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridOrigen.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridOrigen.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridOrigen.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridOrigen.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridOrigen.Size = New System.Drawing.Size(572, 193)
        Me.TrueDBGridOrigen.TabIndex = 223
        Me.TrueDBGridOrigen.Text = "C1TrueDBGrid1"
        Me.TrueDBGridOrigen.PropBag = resources.GetString("TrueDBGridOrigen.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DTPFecha)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1240, 48)
        Me.GroupBox2.TabIndex = 222
        Me.GroupBox2.TabStop = False
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(51, 17)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(76, 20)
        Me.TxtNumeroEnsamble.TabIndex = 122
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(227, 14)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboCodigoBodega2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CboCodigoBodega)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1240, 52)
        Me.GroupBox1.TabIndex = 221
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bodegas de Transferencias"
        '
        'CboCodigoBodega2
        '
        Me.CboCodigoBodega2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega2.Caption = ""
        Me.CboCodigoBodega2.CaptionHeight = 17
        Me.CboCodigoBodega2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega2.ColumnCaptionHeight = 17
        Me.CboCodigoBodega2.ColumnFooterHeight = 17
        Me.CboCodigoBodega2.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCodigoBodega2.ContentHeight = 15
        Me.CboCodigoBodega2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega2.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoBodega2.DropDownWidth = 300
        Me.CboCodigoBodega2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega2.EditorHeight = 15
        Me.CboCodigoBodega2.Images.Add(CType(resources.GetObject("CboCodigoBodega2.Images"), System.Drawing.Image))
        Me.CboCodigoBodega2.ItemHeight = 15
        Me.CboCodigoBodega2.Location = New System.Drawing.Point(768, 19)
        Me.CboCodigoBodega2.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega2.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega2.MaxLength = 32767
        Me.CboCodigoBodega2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega2.Name = "CboCodigoBodega2"
        Me.CboCodigoBodega2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega2.Size = New System.Drawing.Size(121, 21)
        Me.CboCodigoBodega2.TabIndex = 185
        Me.CboCodigoBodega2.PropBag = resources.GetString("CboCodigoBodega2.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(684, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Bodega Detino"
        '
        'CboCodigoBodega
        '
        Me.CboCodigoBodega.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega.Caption = ""
        Me.CboCodigoBodega.CaptionHeight = 17
        Me.CboCodigoBodega.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega.ColumnCaptionHeight = 17
        Me.CboCodigoBodega.ColumnFooterHeight = 17
        Me.CboCodigoBodega.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCodigoBodega.ContentHeight = 15
        Me.CboCodigoBodega.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoBodega.DropDownWidth = 300
        Me.CboCodigoBodega.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega.EditorHeight = 15
        Me.CboCodigoBodega.Images.Add(CType(resources.GetObject("CboCodigoBodega.Images"), System.Drawing.Image))
        Me.CboCodigoBodega.ItemHeight = 15
        Me.CboCodigoBodega.Location = New System.Drawing.Point(90, 21)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(121, 21)
        Me.CboCodigoBodega.TabIndex = 183
        Me.CboCodigoBodega.Tag = "30"
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 182
        Me.Label11.Text = "Bodega Origen"
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(10, 425)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 215
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(1167, 425)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 217
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(503, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(224, 13)
        Me.Label9.TabIndex = 220
        Me.Label9.Text = "TRANSFORMACION DE PRODUCTOS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(11, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(89, 74)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 219
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1272, 74)
        Me.PictureBox1.TabIndex = 218
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(582, 247)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(81, 71)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 229
        Me.PictureBox3.TabStop = False
        '
        'TrueDBGridDestino
        '
        Me.TrueDBGridDestino.AllowAddNew = True
        Me.TrueDBGridDestino.AllowDelete = True
        Me.TrueDBGridDestino.AlternatingRows = True
        Me.TrueDBGridDestino.Caption = "Listado de Productos Transformados"
        Me.TrueDBGridDestino.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridDestino.Images.Add(CType(resources.GetObject("TrueDBGridDestino.Images"), System.Drawing.Image))
        Me.TrueDBGridDestino.Location = New System.Drawing.Point(672, 187)
        Me.TrueDBGridDestino.Name = "TrueDBGridDestino"
        Me.TrueDBGridDestino.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridDestino.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridDestino.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridDestino.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridDestino.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridDestino.Size = New System.Drawing.Size(572, 193)
        Me.TrueDBGridDestino.TabIndex = 230
        Me.TrueDBGridDestino.Text = "C1TrueDBGrid1"
        Me.TrueDBGridDestino.PropBag = resources.GetString("TrueDBGridDestino.PropBag")
        '
        'BtnBorrarLineaDestino
        '
        Me.BtnBorrarLineaDestino.Image = CType(resources.GetObject("BtnBorrarLineaDestino.Image"), System.Drawing.Image)
        Me.BtnBorrarLineaDestino.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.BtnBorrarLineaDestino.Location = New System.Drawing.Point(672, 386)
        Me.BtnBorrarLineaDestino.Name = "BtnBorrarLineaDestino"
        Me.BtnBorrarLineaDestino.Size = New System.Drawing.Size(94, 23)
        Me.BtnBorrarLineaDestino.TabIndex = 231
        Me.BtnBorrarLineaDestino.Text = "Borrar Linea"
        Me.BtnBorrarLineaDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBorrarLineaDestino.UseVisualStyleBackColor = True
        '
        'TransformacionNueva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1252, 520)
        Me.Controls.Add(Me.BtnBorrarLineaDestino)
        Me.Controls.Add(Me.TrueDBGridDestino)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TrueDBGridOrigen)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "TransformacionNueva"
        Me.Text = "TransformacionNueva"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TrueDBGridOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboCodigoBodega2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalleDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridOrigen As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CboCodigoBodega2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TrueDBGridDestino As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnBorrarLineaDestino As System.Windows.Forms.Button
    Friend WithEvents BindingDetalleOrigen As System.Windows.Forms.BindingSource
    Friend WithEvents BindingDetalleDestino As System.Windows.Forms.BindingSource
End Class
