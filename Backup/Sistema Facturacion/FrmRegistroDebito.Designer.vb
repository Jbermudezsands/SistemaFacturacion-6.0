<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroDebito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroDebito))
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblNumero = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.LblMoneda = New System.Windows.Forms.Label
        Me.CmbCodigo = New C1.Win.C1List.C1Combo
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtMonto = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtObservaciones = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.LblFactura = New System.Windows.Forms.Label
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TxtCodCliente = New System.Windows.Forms.TextBox
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.CmbSerie = New C1.Win.C1List.C1Combo
        Me.ChkFactura = New System.Windows.Forms.CheckBox
        Me.ChkSseries = New System.Windows.Forms.CheckBox
        Me.PrintNota = New System.Drawing.Printing.PrintDocument
        Me.ChkTipoCuenta = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(188, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 18)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "NOTAS DE DEBITO"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(12, -4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 132
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox4.Location = New System.Drawing.Point(-5, -4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(597, 60)
        Me.PictureBox4.TabIndex = 131
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(275, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Fecha"
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.ForeColor = System.Drawing.Color.Navy
        Me.LblNombre.Location = New System.Drawing.Point(61, 70)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(176, 13)
        Me.LblNombre.TabIndex = 136
        Me.LblNombre.Text = "JUAN BERMUDEZ  HERNANDEZ "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(330, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 16)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "NO."
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumero.ForeColor = System.Drawing.Color.Maroon
        Me.LblNumero.Location = New System.Drawing.Point(89, 9)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(65, 24)
        Me.LblNumero.TabIndex = 138
        Me.LblNumero.Text = "10000"
        Me.LblNumero.Visible = False
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(318, 67)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 139
        '
        'LblMoneda
        '
        Me.LblMoneda.AutoSize = True
        Me.LblMoneda.ForeColor = System.Drawing.Color.Navy
        Me.LblMoneda.Location = New System.Drawing.Point(466, 70)
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Size = New System.Drawing.Size(52, 13)
        Me.LblMoneda.TabIndex = 140
        Me.LblMoneda.Text = "Cordobas"
        '
        'CmbCodigo
        '
        Me.CmbCodigo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbCodigo.Caption = ""
        Me.CmbCodigo.CaptionHeight = 17
        Me.CmbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbCodigo.ColumnCaptionHeight = 17
        Me.CmbCodigo.ColumnFooterHeight = 17
        Me.CmbCodigo.ContentHeight = 15
        Me.CmbCodigo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbCodigo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbCodigo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCodigo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbCodigo.EditorHeight = 15
        Me.CmbCodigo.Images.Add(CType(resources.GetObject("CmbCodigo.Images"), System.Drawing.Image))
        Me.CmbCodigo.ItemHeight = 15
        Me.CmbCodigo.Location = New System.Drawing.Point(57, 96)
        Me.CmbCodigo.MatchEntryTimeout = CType(2000, Long)
        Me.CmbCodigo.MaxDropDownItems = CType(5, Short)
        Me.CmbCodigo.MaxLength = 32767
        Me.CmbCodigo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbCodigo.Name = "CmbCodigo"
        Me.CmbCodigo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbCodigo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbCodigo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbCodigo.Size = New System.Drawing.Size(96, 21)
        Me.CmbCodigo.TabIndex = 141
        Me.CmbCodigo.PropBag = resources.GetString("CmbCodigo.PropBag")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 142
        Me.Label16.Text = "Codigo"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(159, 97)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(243, 20)
        Me.TxtDescripcion.TabIndex = 143
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(408, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "Monto"
        '
        'TxtMonto
        '
        Me.TxtMonto.Location = New System.Drawing.Point(451, 96)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(78, 20)
        Me.TxtMonto.TabIndex = 145
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "Observaciones"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(93, 131)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(238, 34)
        Me.TxtObservaciones.TabIndex = 147
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(355, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "Factura No."
        '
        'LblFactura
        '
        Me.LblFactura.AutoSize = True
        Me.LblFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFactura.ForeColor = System.Drawing.Color.Maroon
        Me.LblFactura.Location = New System.Drawing.Point(424, 131)
        Me.LblFactura.Name = "LblFactura"
        Me.LblFactura.Size = New System.Drawing.Size(60, 24)
        Me.LblFactura.TabIndex = 149
        Me.LblFactura.Text = "00023"
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(463, 173)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 177
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(12, 175)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 34)
        Me.Button1.TabIndex = 178
        Me.Button1.Text = "Grabar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(174, 175)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 34)
        Me.Button2.TabIndex = 179
        Me.Button2.Text = "Anular"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtCodCliente
        '
        Me.TxtCodCliente.Location = New System.Drawing.Point(211, 333)
        Me.TxtCodCliente.Name = "TxtCodCliente"
        Me.TxtCodCliente.Size = New System.Drawing.Size(100, 20)
        Me.TxtCodCliente.TabIndex = 180
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(418, 20)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(76, 20)
        Me.TxtNumeroEnsamble.TabIndex = 181
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(500, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 30)
        Me.Button3.TabIndex = 182
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(92, 174)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 34)
        Me.Button4.TabIndex = 183
        Me.Button4.Text = "Imprimir"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
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
        Me.CmbSerie.Location = New System.Drawing.Point(369, 20)
        Me.CmbSerie.MatchEntryTimeout = CType(2000, Long)
        Me.CmbSerie.MaxDropDownItems = CType(5, Short)
        Me.CmbSerie.MaxLength = 32767
        Me.CmbSerie.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbSerie.Name = "CmbSerie"
        Me.CmbSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbSerie.Size = New System.Drawing.Size(43, 21)
        Me.CmbSerie.TabIndex = 213
        Me.CmbSerie.Visible = False
        Me.CmbSerie.PropBag = resources.GetString("CmbSerie.PropBag")
        '
        'ChkFactura
        '
        Me.ChkFactura.AutoSize = True
        Me.ChkFactura.Location = New System.Drawing.Point(292, 175)
        Me.ChkFactura.Name = "ChkFactura"
        Me.ChkFactura.Size = New System.Drawing.Size(96, 17)
        Me.ChkFactura.TabIndex = 214
        Me.ChkFactura.Text = "Quitar  Factura"
        Me.ChkFactura.UseVisualStyleBackColor = True
        '
        'ChkSseries
        '
        Me.ChkSseries.AutoSize = True
        Me.ChkSseries.Location = New System.Drawing.Point(292, 194)
        Me.ChkSseries.Name = "ChkSseries"
        Me.ChkSseries.Size = New System.Drawing.Size(135, 17)
        Me.ChkSseries.TabIndex = 215
        Me.ChkSseries.Text = "Consecutivo Sin Series"
        Me.ChkSseries.UseVisualStyleBackColor = True
        '
        'PrintNota
        '
        '
        'ChkTipoCuenta
        '
        Me.ChkTipoCuenta.AutoSize = True
        Me.ChkTipoCuenta.Location = New System.Drawing.Point(292, 213)
        Me.ChkTipoCuenta.Name = "ChkTipoCuenta"
        Me.ChkTipoCuenta.Size = New System.Drawing.Size(84, 17)
        Me.ChkTipoCuenta.TabIndex = 216
        Me.ChkTipoCuenta.Text = "Tipo Cuenta"
        Me.ChkTipoCuenta.UseVisualStyleBackColor = True
        '
        'FrmRegistroDebito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 234)
        Me.Controls.Add(Me.ChkTipoCuenta)
        Me.Controls.Add(Me.ChkSseries)
        Me.Controls.Add(Me.ChkFactura)
        Me.Controls.Add(Me.CmbSerie)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TxtNumeroEnsamble)
        Me.Controls.Add(Me.TxtCodCliente)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblFactura)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtObservaciones)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtMonto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.CmbCodigo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LblMoneda)
        Me.Controls.Add(Me.DTPFecha)
        Me.Controls.Add(Me.LblNumero)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistroDebito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notas de Debito y Creditos"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblMoneda As System.Windows.Forms.Label
    Friend WithEvents CmbCodigo As C1.Win.C1List.C1Combo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblFactura As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtCodCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents ChkFactura As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSseries As System.Windows.Forms.CheckBox
    Friend WithEvents PrintNota As System.Drawing.Printing.PrintDocument
    Friend WithEvents ChkTipoCuenta As System.Windows.Forms.CheckBox
End Class
