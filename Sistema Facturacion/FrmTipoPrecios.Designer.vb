<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipoPrecios))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TxtCategoria = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblPorciento = New System.Windows.Forms.Label()
        Me.TxtPorciento = New System.Windows.Forms.TextBox()
        Me.OptQuitar = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OptAplicar = New System.Windows.Forms.RadioButton()
        Me.CmdPrecios = New System.Windows.Forms.Button()
        Me.CboCodigoCliente = New C1.Win.C1List.C1Combo()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Opt2 = New System.Windows.Forms.RadioButton()
        Me.Opt1 = New System.Windows.Forms.RadioButton()
        Me.LblProducto = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(10, 212)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 67)
        Me.Button2.TabIndex = 137
        Me.Button2.Text = "Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 138
        Me.PictureBox3.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(13, 66)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(484, 142)
        Me.TabControl1.TabIndex = 136
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TxtCategoria)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.CmdPrecios)
        Me.TabPage1.Controls.Add(Me.CboCodigoCliente)
        Me.TabPage1.Controls.Add(Me.TxtNombre)
        Me.TabPage1.Controls.Add(Me.LblNombre)
        Me.TabPage1.Controls.Add(Me.LblCodigo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(476, 116)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tipo de Precios"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TxtCategoria
        '
        Me.TxtCategoria.Location = New System.Drawing.Point(405, 54)
        Me.TxtCategoria.Name = "TxtCategoria"
        Me.TxtCategoria.Size = New System.Drawing.Size(37, 20)
        Me.TxtCategoria.TabIndex = 171
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblPorciento)
        Me.GroupBox2.Controls.Add(Me.TxtPorciento)
        Me.GroupBox2.Controls.Add(Me.OptQuitar)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.OptAplicar)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(459, 36)
        Me.GroupBox2.TabIndex = 139
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos Agregar"
        '
        'LblPorciento
        '
        Me.LblPorciento.AutoSize = True
        Me.LblPorciento.Location = New System.Drawing.Point(198, 16)
        Me.LblPorciento.Name = "LblPorciento"
        Me.LblPorciento.Size = New System.Drawing.Size(15, 13)
        Me.LblPorciento.TabIndex = 4
        Me.LblPorciento.Text = "%"
        '
        'TxtPorciento
        '
        Me.TxtPorciento.Location = New System.Drawing.Point(156, 11)
        Me.TxtPorciento.Name = "TxtPorciento"
        Me.TxtPorciento.Size = New System.Drawing.Size(39, 20)
        Me.TxtPorciento.TabIndex = 3
        '
        'OptQuitar
        '
        Me.OptQuitar.AutoSize = True
        Me.OptQuitar.Location = New System.Drawing.Point(227, 13)
        Me.OptQuitar.Name = "OptQuitar"
        Me.OptQuitar.Size = New System.Drawing.Size(144, 17)
        Me.OptQuitar.TabIndex = 2
        Me.OptQuitar.TabStop = True
        Me.OptQuitar.Text = "Quitar Precios por Costos"
        Me.OptQuitar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(378, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Tag = "26"
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OptAplicar
        '
        Me.OptAplicar.AutoSize = True
        Me.OptAplicar.Checked = True
        Me.OptAplicar.Location = New System.Drawing.Point(7, 13)
        Me.OptAplicar.Name = "OptAplicar"
        Me.OptAplicar.Size = New System.Drawing.Size(148, 17)
        Me.OptAplicar.TabIndex = 0
        Me.OptAplicar.TabStop = True
        Me.OptAplicar.Text = "Aplicar Precios por Costos"
        Me.OptAplicar.UseVisualStyleBackColor = True
        '
        'CmdPrecios
        '
        Me.CmdPrecios.Image = CType(resources.GetObject("CmdPrecios.Image"), System.Drawing.Image)
        Me.CmdPrecios.Location = New System.Drawing.Point(337, 16)
        Me.CmdPrecios.Name = "CmdPrecios"
        Me.CmdPrecios.Size = New System.Drawing.Size(35, 32)
        Me.CmdPrecios.TabIndex = 170
        Me.CmdPrecios.UseVisualStyleBackColor = True
        '
        'CboCodigoCliente
        '
        Me.CboCodigoCliente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoCliente.Caption = ""
        Me.CboCodigoCliente.CaptionHeight = 17
        Me.CboCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoCliente.ColumnCaptionHeight = 17
        Me.CboCodigoCliente.ColumnFooterHeight = 17
        Me.CboCodigoCliente.ContentHeight = 15
        Me.CboCodigoCliente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoCliente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoCliente.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoCliente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoCliente.EditorHeight = 15
        Me.CboCodigoCliente.Images.Add(CType(resources.GetObject("CboCodigoCliente.Images"), System.Drawing.Image))
        Me.CboCodigoCliente.ItemHeight = 15
        Me.CboCodigoCliente.Location = New System.Drawing.Point(122, 25)
        Me.CboCodigoCliente.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoCliente.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoCliente.MaxLength = 32767
        Me.CboCodigoCliente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoCliente.Name = "CboCodigoCliente"
        Me.CboCodigoCliente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoCliente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoCliente.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoCliente.TabIndex = 120
        Me.CboCodigoCliente.PropBag = resources.GetString("CboCodigoCliente.PropBag")
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(122, 54)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(275, 20)
        Me.TxtNombre.TabIndex = 121
        '
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Location = New System.Drawing.Point(16, 54)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(81, 13)
        Me.LblNombre.TabIndex = 129
        Me.LblNombre.Text = "Tipo de Precios"
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(16, 25)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(97, 13)
        Me.LblCodigo.TabIndex = 128
        Me.LblCodigo.Text = "Codigo Tipo Precio"
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(88, 212)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 131
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(172, 212)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 132
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(422, 212)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 133
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblTitulo.Location = New System.Drawing.Point(156, 23)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(115, 13)
        Me.LblTitulo.TabIndex = 135
        Me.LblTitulo.Text = "TIPO DE PRECIOS"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(527, 60)
        Me.PictureBox1.TabIndex = 134
        Me.PictureBox1.TabStop = False
        '
        'Opt2
        '
        Me.Opt2.AutoSize = True
        Me.Opt2.Location = New System.Drawing.Point(99, 13)
        Me.Opt2.Name = "Opt2"
        Me.Opt2.Size = New System.Drawing.Size(122, 17)
        Me.Opt2.TabIndex = 1
        Me.Opt2.Text = "Todos los Productos"
        Me.Opt2.UseVisualStyleBackColor = True
        '
        'Opt1
        '
        Me.Opt1.AutoSize = True
        Me.Opt1.Checked = True
        Me.Opt1.Location = New System.Drawing.Point(7, 13)
        Me.Opt1.Name = "Opt1"
        Me.Opt1.Size = New System.Drawing.Size(85, 17)
        Me.Opt1.TabIndex = 0
        Me.Opt1.TabStop = True
        Me.Opt1.Text = "Un Producto"
        Me.Opt1.UseVisualStyleBackColor = True
        '
        'LblProducto
        '
        Me.LblProducto.AutoSize = True
        Me.LblProducto.Location = New System.Drawing.Point(254, 247)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(94, 13)
        Me.LblProducto.TabIndex = 146
        Me.LblProducto.Text = "Procesado: 00001"
        Me.LblProducto.Visible = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(253, 214)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(148, 26)
        Me.ProgressBar.TabIndex = 145
        Me.ProgressBar.Visible = False
        '
        'FrmTipoPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 282)
        Me.Controls.Add(Me.LblProducto)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "FrmTipoPrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTipoPrecios"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CboCodigoCliente As C1.Win.C1List.C1Combo
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdPrecios As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OptAplicar As System.Windows.Forms.RadioButton
    Friend WithEvents Opt2 As System.Windows.Forms.RadioButton
    Friend WithEvents Opt1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LblProducto As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents OptQuitar As System.Windows.Forms.RadioButton
    Friend WithEvents LblPorciento As System.Windows.Forms.Label
    Friend WithEvents TxtPorciento As System.Windows.Forms.TextBox
    Friend WithEvents TxtCategoria As System.Windows.Forms.TextBox
End Class
