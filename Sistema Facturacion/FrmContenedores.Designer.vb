<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContenedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContenedores))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.CmdPrecios = New System.Windows.Forms.Button()
        Me.CboCodigoContenedor = New C1.Win.C1List.C1Combo()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CmdGrabar = New System.Windows.Forms.Button()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CboCodigoContenedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(174, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "CONTENEDORES"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(-1, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(89, 74)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 103
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(699, 74)
        Me.PictureBox1.TabIndex = 102
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 78)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(423, 136)
        Me.TabControl1.TabIndex = 129
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ChkActivo)
        Me.TabPage1.Controls.Add(Me.CmdPrecios)
        Me.TabPage1.Controls.Add(Me.CboCodigoContenedor)
        Me.TabPage1.Controls.Add(Me.TxtNombre)
        Me.TabPage1.Controls.Add(Me.LblNombre)
        Me.TabPage1.Controls.Add(Me.LblCodigo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(415, 110)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro Contenedores"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Location = New System.Drawing.Point(122, 81)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(56, 17)
        Me.ChkActivo.TabIndex = 172
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'CmdPrecios
        '
        Me.CmdPrecios.Image = CType(resources.GetObject("CmdPrecios.Image"), System.Drawing.Image)
        Me.CmdPrecios.Location = New System.Drawing.Point(337, 18)
        Me.CmdPrecios.Name = "CmdPrecios"
        Me.CmdPrecios.Size = New System.Drawing.Size(29, 30)
        Me.CmdPrecios.TabIndex = 171
        Me.CmdPrecios.UseVisualStyleBackColor = True
        '
        'CboCodigoContenedor
        '
        Me.CboCodigoContenedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoContenedor.Caption = ""
        Me.CboCodigoContenedor.CaptionHeight = 17
        Me.CboCodigoContenedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoContenedor.ColumnCaptionHeight = 17
        Me.CboCodigoContenedor.ColumnFooterHeight = 17
        Me.CboCodigoContenedor.ContentHeight = 15
        Me.CboCodigoContenedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoContenedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoContenedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoContenedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoContenedor.EditorHeight = 15
        Me.CboCodigoContenedor.Images.Add(CType(resources.GetObject("CboCodigoContenedor.Images"), System.Drawing.Image))
        Me.CboCodigoContenedor.ItemHeight = 15
        Me.CboCodigoContenedor.Location = New System.Drawing.Point(122, 25)
        Me.CboCodigoContenedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoContenedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoContenedor.MaxLength = 32767
        Me.CboCodigoContenedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoContenedor.Name = "CboCodigoContenedor"
        Me.CboCodigoContenedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoContenedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoContenedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoContenedor.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoContenedor.TabIndex = 120
        Me.CboCodigoContenedor.PropBag = resources.GetString("CboCodigoContenedor.PropBag")
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
        Me.LblNombre.Size = New System.Drawing.Size(102, 13)
        Me.LblNombre.TabIndex = 129
        Me.LblNombre.Text = "Nombre Contenedor"
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(16, 25)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(92, 13)
        Me.LblCodigo.TabIndex = 128
        Me.LblCodigo.Text = "Codigo Contendor"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(13, 216)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 67)
        Me.Button2.TabIndex = 133
        Me.Button2.Text = "Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(91, 216)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 130
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(175, 216)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 131
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
        Me.Button8.Location = New System.Drawing.Point(358, 216)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 132
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'FrmContenedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 289)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmContenedores"
        Me.Text = "FrmContenedores"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.CboCodigoContenedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents CboCodigoContenedor As C1.Win.C1List.C1Combo
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents LblNombre As Label
    Friend WithEvents LblCodigo As Label
    Friend WithEvents CmdPrecios As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents CmdGrabar As Button
    Friend WithEvents ButtonBorrar As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents ChkActivo As CheckBox
End Class
