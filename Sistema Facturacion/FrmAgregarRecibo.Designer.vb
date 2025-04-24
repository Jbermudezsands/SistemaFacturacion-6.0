<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAgregarRecibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAgregarRecibo))
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblNombreCliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkRet2Porciento = New System.Windows.Forms.CheckBox()
        Me.ChkRet1Porciento = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CboMetodoPago = New C1.Win.C1List.C1Combo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbSerie = New C1.Win.C1List.C1Combo()
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtMontoRecibo = New System.Windows.Forms.TextBox()
        Me.LblRetencion2 = New System.Windows.Forms.Label()
        Me.LblRetencion1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblMontoFactura = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblNumeroFactura = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CboMetodoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(17, -4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(61, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 197
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(722, 60)
        Me.PictureBox1.TabIndex = 196
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.LblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 92)
        Me.GroupBox1.TabIndex = 198
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales del Cliente"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(95, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(148, 23)
        Me.Label15.TabIndex = 3
        '
        'LblNombreCliente
        '
        Me.LblNombreCliente.Location = New System.Drawing.Point(95, 23)
        Me.LblNombreCliente.Name = "LblNombreCliente"
        Me.LblNombreCliente.Size = New System.Drawing.Size(148, 23)
        Me.LblNombreCliente.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "RUC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre Cliente"
        '
        'ChkRet2Porciento
        '
        Me.ChkRet2Porciento.AutoSize = True
        Me.ChkRet2Porciento.Location = New System.Drawing.Point(185, 68)
        Me.ChkRet2Porciento.Name = "ChkRet2Porciento"
        Me.ChkRet2Porciento.Size = New System.Drawing.Size(81, 17)
        Me.ChkRet2Porciento.TabIndex = 221
        Me.ChkRet2Porciento.Text = "Retener 2%"
        Me.ChkRet2Porciento.UseVisualStyleBackColor = True
        '
        'ChkRet1Porciento
        '
        Me.ChkRet1Porciento.AutoSize = True
        Me.ChkRet1Porciento.Location = New System.Drawing.Point(98, 68)
        Me.ChkRet1Porciento.Name = "ChkRet1Porciento"
        Me.ChkRet1Porciento.Size = New System.Drawing.Size(81, 17)
        Me.ChkRet1Porciento.TabIndex = 220
        Me.ChkRet1Porciento.Text = "Retener 1%"
        Me.ChkRet1Porciento.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CboMetodoPago)
        Me.GroupBox2.Controls.Add(Me.ChkRet2Porciento)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ChkRet1Porciento)
        Me.GroupBox2.Controls.Add(Me.CmbSerie)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox2.Controls.Add(Me.LblNumero)
        Me.GroupBox2.Controls.Add(Me.DTPFecha)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(281, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(366, 91)
        Me.GroupBox2.TabIndex = 222
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Recibo"
        '
        'CboMetodoPago
        '
        Me.CboMetodoPago.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboMetodoPago.Caption = ""
        Me.CboMetodoPago.CaptionHeight = 17
        Me.CboMetodoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboMetodoPago.ColumnCaptionHeight = 17
        Me.CboMetodoPago.ColumnFooterHeight = 17
        Me.CboMetodoPago.ContentHeight = 15
        Me.CboMetodoPago.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboMetodoPago.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboMetodoPago.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMetodoPago.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboMetodoPago.EditorHeight = 15
        Me.CboMetodoPago.Images.Add(CType(resources.GetObject("CboMetodoPago.Images"), System.Drawing.Image))
        Me.CboMetodoPago.ItemHeight = 15
        Me.CboMetodoPago.Location = New System.Drawing.Point(98, 41)
        Me.CboMetodoPago.MatchEntryTimeout = CType(2000, Long)
        Me.CboMetodoPago.MaxDropDownItems = CType(5, Short)
        Me.CboMetodoPago.MaxLength = 32767
        Me.CboMetodoPago.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboMetodoPago.Name = "CboMetodoPago"
        Me.CboMetodoPago.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboMetodoPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboMetodoPago.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboMetodoPago.Size = New System.Drawing.Size(168, 21)
        Me.CboMetodoPago.TabIndex = 226
        Me.CboMetodoPago.PropBag = resources.GetString("CboMetodoPago.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 225
        Me.Label4.Text = "Metodo Pago"
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
        Me.CmbSerie.Location = New System.Drawing.Point(223, 13)
        Me.CmbSerie.MatchEntryTimeout = CType(2000, Long)
        Me.CmbSerie.MaxDropDownItems = CType(5, Short)
        Me.CmbSerie.MaxLength = 32767
        Me.CmbSerie.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbSerie.Name = "CmbSerie"
        Me.CmbSerie.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbSerie.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbSerie.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbSerie.Size = New System.Drawing.Size(43, 21)
        Me.CmbSerie.TabIndex = 224
        Me.CmbSerie.Visible = False
        Me.CmbSerie.PropBag = resources.GetString("CmbSerie.PropBag")
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(272, 14)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(76, 20)
        Me.TxtNumeroEnsamble.TabIndex = 223
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.Location = New System.Drawing.Point(173, 20)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(44, 13)
        Me.LblNumero.TabIndex = 222
        Me.LblNumero.Text = "Numero"
        '
        'DTPFecha
        '
        Me.DTPFecha.CustomFormat = ""
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(57, 15)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(104, 20)
        Me.DTPFecha.TabIndex = 221
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 220
        Me.Label2.Text = "Fecha"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtMontoRecibo)
        Me.GroupBox3.Controls.Add(Me.LblRetencion2)
        Me.GroupBox3.Controls.Add(Me.LblRetencion1)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.LblMontoFactura)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.LblNumeroFactura)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(486, 100)
        Me.GroupBox3.TabIndex = 223
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle del Recibo"
        '
        'TxtMontoRecibo
        '
        Me.TxtMontoRecibo.Location = New System.Drawing.Point(382, 25)
        Me.TxtMontoRecibo.Name = "TxtMontoRecibo"
        Me.TxtMontoRecibo.Size = New System.Drawing.Size(98, 20)
        Me.TxtMontoRecibo.TabIndex = 234
        '
        'LblRetencion2
        '
        Me.LblRetencion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRetencion2.Location = New System.Drawing.Point(378, 73)
        Me.LblRetencion2.Name = "LblRetencion2"
        Me.LblRetencion2.Size = New System.Drawing.Size(102, 16)
        Me.LblRetencion2.TabIndex = 233
        Me.LblRetencion2.Text = "0.00"
        Me.LblRetencion2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblRetencion1
        '
        Me.LblRetencion1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRetencion1.Location = New System.Drawing.Point(379, 49)
        Me.LblRetencion1.Name = "LblRetencion1"
        Me.LblRetencion1.Size = New System.Drawing.Size(101, 16)
        Me.LblRetencion1.TabIndex = 231
        Me.LblRetencion1.Text = "0.00"
        Me.LblRetencion1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(265, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 16)
        Me.Label14.TabIndex = 232
        Me.Label14.Text = "Retencion 2%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(266, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 16)
        Me.Label12.TabIndex = 230
        Me.Label12.Text = "Retencion 1%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(266, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 16)
        Me.Label10.TabIndex = 228
        Me.Label10.Text = "Monto Recibo"
        '
        'LblMontoFactura
        '
        Me.LblMontoFactura.AutoSize = True
        Me.LblMontoFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoFactura.Location = New System.Drawing.Point(122, 66)
        Me.LblMontoFactura.Name = "LblMontoFactura"
        Me.LblMontoFactura.Size = New System.Drawing.Size(83, 16)
        Me.LblMontoFactura.TabIndex = 227
        Me.LblMontoFactura.Text = "5000000.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 16)
        Me.Label7.TabIndex = 226
        Me.Label7.Text = "Monto Factura"
        '
        'LblNumeroFactura
        '
        Me.LblNumeroFactura.AutoSize = True
        Me.LblNumeroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumeroFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblNumeroFactura.Location = New System.Drawing.Point(96, 23)
        Me.LblNumeroFactura.Name = "LblNumeroFactura"
        Me.LblNumeroFactura.Size = New System.Drawing.Size(103, 25)
        Me.LblNumeroFactura.TabIndex = 225
        Me.LblNumeroFactura.Text = "0000883"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 16)
        Me.Label5.TabIndex = 224
        Me.Label5.Text = "Factura No:"
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(572, 218)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 225
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(572, 177)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 34)
        Me.Button7.TabIndex = 224
        Me.Button7.Text = "Crear Recibo"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'FrmAgregarRecibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 287)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAgregarRecibo"
        Me.Text = "Crear Recibo de Caja"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CboMetodoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkRet2Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRet1Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CboMetodoPago As C1.Win.C1List.C1Combo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbSerie As C1.Win.C1List.C1Combo
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LblNumeroFactura As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblRetencion2 As System.Windows.Forms.Label
    Friend WithEvents LblRetencion1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblMontoFactura As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents LblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtMontoRecibo As System.Windows.Forms.TextBox
End Class
