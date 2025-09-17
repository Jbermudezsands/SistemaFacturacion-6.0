<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpuestos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpuestos))
        Me.CboCodigoImpuesto = New C1.Win.C1List.C1Combo()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.CmdNuevo = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblImpuestos = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TxtValor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtImpuestoxPagar = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtImpuestoxCobrar = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OptRetencion = New System.Windows.Forms.RadioButton()
        Me.OptIVA = New System.Windows.Forms.RadioButton()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        CType(Me.CboCodigoImpuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CboCodigoImpuesto
        '
        Me.CboCodigoImpuesto.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoImpuesto.Caption = ""
        Me.CboCodigoImpuesto.CaptionHeight = 17
        Me.CboCodigoImpuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoImpuesto.ColumnCaptionHeight = 17
        Me.CboCodigoImpuesto.ColumnFooterHeight = 17
        Me.CboCodigoImpuesto.ContentHeight = 15
        Me.CboCodigoImpuesto.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoImpuesto.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoImpuesto.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoImpuesto.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoImpuesto.EditorHeight = 15
        Me.CboCodigoImpuesto.Images.Add(CType(resources.GetObject("CboCodigoImpuesto.Images"), System.Drawing.Image))
        Me.CboCodigoImpuesto.ItemHeight = 15
        Me.CboCodigoImpuesto.Location = New System.Drawing.Point(111, 78)
        Me.CboCodigoImpuesto.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoImpuesto.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoImpuesto.MaxLength = 32767
        Me.CboCodigoImpuesto.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoImpuesto.Name = "CboCodigoImpuesto"
        Me.CboCodigoImpuesto.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoImpuesto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoImpuesto.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoImpuesto.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoImpuesto.TabIndex = 87
        Me.CboCodigoImpuesto.PropBag = resources.GetString("CboCodigoImpuesto.PropBag")
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(92, 239)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 91
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(176, 241)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 92
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(11, 241)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 90
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(288, 241)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 93
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(111, 107)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(252, 20)
        Me.TxtNombre.TabIndex = 88
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Nombre Impuesto"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(326, 65)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 38)
        Me.Button6.TabIndex = 89
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Codigo Impuesto"
        '
        'LblImpuestos
        '
        Me.LblImpuestos.AutoSize = True
        Me.LblImpuestos.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblImpuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblImpuestos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblImpuestos.Location = New System.Drawing.Point(108, 22)
        Me.LblImpuestos.Name = "LblImpuestos"
        Me.LblImpuestos.Size = New System.Drawing.Size(143, 13)
        Me.LblImpuestos.TabIndex = 96
        Me.LblImpuestos.Text = "TABLA DE IMPUESTOS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 95
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(418, 60)
        Me.PictureBox1.TabIndex = 94
        Me.PictureBox1.TabStop = False
        '
        'TxtValor
        '
        Me.TxtValor.AcceptsReturn = True
        Me.TxtValor.Location = New System.Drawing.Point(111, 133)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(69, 20)
        Me.TxtValor.TabIndex = 99
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Valor"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(229, 188)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 28)
        Me.Button2.TabIndex = 137
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 191)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 136
        Me.Label15.Text = "Impuesto x Pagar"
        '
        'TxtImpuestoxPagar
        '
        Me.TxtImpuestoxPagar.Location = New System.Drawing.Point(111, 191)
        Me.TxtImpuestoxPagar.Name = "TxtImpuestoxPagar"
        Me.TxtImpuestoxPagar.Size = New System.Drawing.Size(115, 20)
        Me.TxtImpuestoxPagar.TabIndex = 135
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(229, 156)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 28)
        Me.Button1.TabIndex = 134
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 159)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 13)
        Me.Label14.TabIndex = 133
        Me.Label14.Text = "Impuesto x Cobrar"
        '
        'TxtImpuestoxCobrar
        '
        Me.TxtImpuestoxCobrar.Location = New System.Drawing.Point(111, 159)
        Me.TxtImpuestoxCobrar.Name = "TxtImpuestoxCobrar"
        Me.TxtImpuestoxCobrar.Size = New System.Drawing.Size(115, 20)
        Me.TxtImpuestoxCobrar.TabIndex = 132
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptRetencion)
        Me.GroupBox1.Controls.Add(Me.OptIVA)
        Me.GroupBox1.Location = New System.Drawing.Point(273, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(107, 66)
        Me.GroupBox1.TabIndex = 138
        Me.GroupBox1.TabStop = False
        '
        'OptRetencion
        '
        Me.OptRetencion.AutoSize = True
        Me.OptRetencion.Location = New System.Drawing.Point(7, 39)
        Me.OptRetencion.Name = "OptRetencion"
        Me.OptRetencion.Size = New System.Drawing.Size(75, 17)
        Me.OptRetencion.TabIndex = 1
        Me.OptRetencion.TabStop = True
        Me.OptRetencion.Text = "Causa Ret"
        Me.OptRetencion.UseVisualStyleBackColor = True
        '
        'OptIVA
        '
        Me.OptIVA.AutoSize = True
        Me.OptIVA.Location = New System.Drawing.Point(7, 16)
        Me.OptIVA.Name = "OptIVA"
        Me.OptIVA.Size = New System.Drawing.Size(75, 17)
        Me.OptIVA.TabIndex = 0
        Me.OptIVA.TabStop = True
        Me.OptIVA.Text = "Causa IVA"
        Me.OptIVA.UseVisualStyleBackColor = True
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Location = New System.Drawing.Point(280, 211)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 139
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'FrmImpuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 317)
        Me.Controls.Add(Me.ChkActivo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtImpuestoxPagar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtImpuestoxCobrar)
        Me.Controls.Add(Me.TxtValor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboCodigoImpuesto)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblImpuestos)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmImpuestos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPUESTOS"
        CType(Me.CboCodigoImpuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboCodigoImpuesto As C1.Win.C1List.C1Combo
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblImpuestos As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtImpuestoxPagar As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtImpuestoxCobrar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptRetencion As System.Windows.Forms.RadioButton
    Friend WithEvents OptIVA As System.Windows.Forms.RadioButton
    Friend WithEvents ChkActivo As System.Windows.Forms.CheckBox
End Class
