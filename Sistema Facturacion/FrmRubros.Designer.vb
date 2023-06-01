<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRubros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRubros))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboCodigoCliente = New C1.Win.C1List.C1Combo()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.CmdNuevo = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(15, 63)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(423, 136)
        Me.TabControl1.TabIndex = 128
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CboCodigoCliente)
        Me.TabPage1.Controls.Add(Me.TxtNombre)
        Me.TabPage1.Controls.Add(Me.LblNombre)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.LblCodigo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(415, 110)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro de Rubros"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(122, 80)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(275, 20)
        Me.TextBox1.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Cta Referencia"
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
        Me.LblNombre.Size = New System.Drawing.Size(76, 13)
        Me.LblNombre.TabIndex = 129
        Me.LblNombre.Text = "Nombre Rubro"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(340, 8)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 38)
        Me.Button6.TabIndex = 126
        Me.Button6.UseVisualStyleBackColor = True
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(16, 25)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(72, 13)
        Me.LblCodigo.TabIndex = 128
        Me.LblCodigo.Text = "Codigo Rubro"
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(90, 209)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 122
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(174, 209)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 123
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(-89, 279)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 121
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(363, 205)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 124
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
        Me.LblTitulo.Location = New System.Drawing.Point(138, 20)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(148, 13)
        Me.LblTitulo.TabIndex = 127
        Me.LblTitulo.Text = "REGISTRO DE RUBROS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(-89, -81)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 126
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-2, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(492, 60)
        Me.PictureBox1.TabIndex = 125
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(12, 209)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 67)
        Me.Button2.TabIndex = 129
        Me.Button2.Text = "Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(3, -3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 130
        Me.PictureBox3.TabStop = False
        '
        'FrmRubros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 285)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRubros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRubros"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.CboCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CboCodigoCliente As C1.Win.C1List.C1Combo
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
