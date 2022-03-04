<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVehiculo))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.LblApellido = New System.Windows.Forms.Label
        Me.TxtMarca = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblCodigo = New System.Windows.Forms.Label
        Me.C1Button2 = New C1.Win.C1Input.C1Button
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.CboActivo = New System.Windows.Forms.ComboBox
        Me.CboPlaca = New C1.Win.C1List.C1Combo
        Me.CboTipo = New C1.Win.C1List.C1Combo
        Me.ChkVehiculoEvacuaciones = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(4, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 112
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-7, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(515, 60)
        Me.PictureBox1.TabIndex = 111
        Me.PictureBox1.TabStop = False
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(124, 22)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(168, 13)
        Me.LblTitulo.TabIndex = 113
        Me.LblTitulo.Text = "CATALOGO DE VEHICULOS"
        '
        'LblApellido
        '
        Me.LblApellido.AutoSize = True
        Me.LblApellido.Location = New System.Drawing.Point(15, 119)
        Me.LblApellido.Name = "LblApellido"
        Me.LblApellido.Size = New System.Drawing.Size(72, 13)
        Me.LblApellido.TabIndex = 154
        Me.LblApellido.Text = "Tipo Vehiculo"
        '
        'TxtMarca
        '
        Me.TxtMarca.Location = New System.Drawing.Point(103, 93)
        Me.TxtMarca.Name = "TxtMarca"
        Me.TxtMarca.Size = New System.Drawing.Size(275, 20)
        Me.TxtMarca.TabIndex = 148
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Location = New System.Drawing.Point(48, 96)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(37, 13)
        Me.LblNombre.TabIndex = 152
        Me.LblNombre.Text = "Marca"
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(51, 66)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(34, 13)
        Me.LblCodigo.TabIndex = 151
        Me.LblCodigo.Text = "Placa"
        '
        'C1Button2
        '
        Me.C1Button2.Image = CType(resources.GetObject("C1Button2.Image"), System.Drawing.Image)
        Me.C1Button2.Location = New System.Drawing.Point(318, 66)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(39, 23)
        Me.C1Button2.TabIndex = 248
        Me.C1Button2.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(91, 206)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 250
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(175, 206)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 251
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(10, 206)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 249
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(303, 206)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 252
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CboActivo
        '
        Me.CboActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboActivo.FormattingEnabled = True
        Me.CboActivo.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.CboActivo.Location = New System.Drawing.Point(104, 145)
        Me.CboActivo.Name = "CboActivo"
        Me.CboActivo.Size = New System.Drawing.Size(121, 21)
        Me.CboActivo.TabIndex = 253
        '
        'CboPlaca
        '
        Me.CboPlaca.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboPlaca.Caption = ""
        Me.CboPlaca.CaptionHeight = 17
        Me.CboPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboPlaca.ColumnCaptionHeight = 17
        Me.CboPlaca.ColumnFooterHeight = 17
        Me.CboPlaca.ContentHeight = 15
        Me.CboPlaca.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboPlaca.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboPlaca.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPlaca.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboPlaca.EditorHeight = 15
        Me.CboPlaca.Images.Add(CType(resources.GetObject("CboPlaca.Images"), System.Drawing.Image))
        Me.CboPlaca.ItemHeight = 15
        Me.CboPlaca.Location = New System.Drawing.Point(103, 66)
        Me.CboPlaca.MatchEntryTimeout = CType(2000, Long)
        Me.CboPlaca.MaxDropDownItems = CType(5, Short)
        Me.CboPlaca.MaxLength = 32767
        Me.CboPlaca.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboPlaca.Name = "CboPlaca"
        Me.CboPlaca.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboPlaca.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboPlaca.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboPlaca.Size = New System.Drawing.Size(209, 21)
        Me.CboPlaca.TabIndex = 147
        Me.CboPlaca.PropBag = resources.GetString("CboPlaca.PropBag")
        '
        'CboTipo
        '
        Me.CboTipo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboTipo.Caption = ""
        Me.CboTipo.CaptionHeight = 17
        Me.CboTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboTipo.ColumnCaptionHeight = 17
        Me.CboTipo.ColumnFooterHeight = 17
        Me.CboTipo.ContentHeight = 15
        Me.CboTipo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboTipo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboTipo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboTipo.EditorHeight = 15
        Me.CboTipo.Images.Add(CType(resources.GetObject("CboTipo.Images"), System.Drawing.Image))
        Me.CboTipo.ItemHeight = 15
        Me.CboTipo.Location = New System.Drawing.Point(103, 119)
        Me.CboTipo.MatchEntryTimeout = CType(2000, Long)
        Me.CboTipo.MaxDropDownItems = CType(5, Short)
        Me.CboTipo.MaxLength = 32767
        Me.CboTipo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboTipo.Name = "CboTipo"
        Me.CboTipo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboTipo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboTipo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboTipo.Size = New System.Drawing.Size(209, 21)
        Me.CboTipo.TabIndex = 254
        Me.CboTipo.PropBag = resources.GetString("CboTipo.PropBag")
        '
        'ChkVehiculoEvacuaciones
        '
        Me.ChkVehiculoEvacuaciones.AutoSize = True
        Me.ChkVehiculoEvacuaciones.Location = New System.Drawing.Point(103, 179)
        Me.ChkVehiculoEvacuaciones.Name = "ChkVehiculoEvacuaciones"
        Me.ChkVehiculoEvacuaciones.Size = New System.Drawing.Size(138, 17)
        Me.ChkVehiculoEvacuaciones.TabIndex = 282
        Me.ChkVehiculoEvacuaciones.Text = "Vehiculo Evacuaciones"
        Me.ChkVehiculoEvacuaciones.UseVisualStyleBackColor = True
        '
        'FrmVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 281)
        Me.Controls.Add(Me.ChkVehiculoEvacuaciones)
        Me.Controls.Add(Me.CboTipo)
        Me.Controls.Add(Me.CboActivo)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.C1Button2)
        Me.Controls.Add(Me.LblApellido)
        Me.Controls.Add(Me.CboPlaca)
        Me.Controls.Add(Me.TxtMarca)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.LblCodigo)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVehiculo"
        Me.Text = "Vehiculo"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents LblApellido As System.Windows.Forms.Label
    Friend WithEvents TxtMarca As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CboActivo As System.Windows.Forms.ComboBox
    Friend WithEvents CboPlaca As C1.Win.C1List.C1Combo
    Friend WithEvents CboTipo As C1.Win.C1List.C1Combo
    Friend WithEvents ChkVehiculoEvacuaciones As System.Windows.Forms.CheckBox
End Class
