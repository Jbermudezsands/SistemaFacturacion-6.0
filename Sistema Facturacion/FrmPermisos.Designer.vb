<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPermisos))
        Me.CboUsuario = New C1.Win.C1List.C1Combo()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdEntrar = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.CboUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CboUsuario
        '
        Me.CboUsuario.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboUsuario.Caption = ""
        Me.CboUsuario.CaptionHeight = 17
        Me.CboUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboUsuario.ColumnCaptionHeight = 17
        Me.CboUsuario.ColumnFooterHeight = 17
        Me.CboUsuario.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboUsuario.ContentHeight = 15
        Me.CboUsuario.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboUsuario.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboUsuario.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboUsuario.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboUsuario.EditorHeight = 15
        Me.CboUsuario.Images.Add(CType(resources.GetObject("CboUsuario.Images"), System.Drawing.Image))
        Me.CboUsuario.ItemHeight = 15
        Me.CboUsuario.Location = New System.Drawing.Point(85, 64)
        Me.CboUsuario.MatchEntryTimeout = CType(2000, Long)
        Me.CboUsuario.MaxDropDownItems = CType(5, Short)
        Me.CboUsuario.MaxLength = 32767
        Me.CboUsuario.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboUsuario.Name = "CboUsuario"
        Me.CboUsuario.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboUsuario.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboUsuario.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboUsuario.Size = New System.Drawing.Size(142, 21)
        Me.CboUsuario.TabIndex = 30
        Me.CboUsuario.PropBag = resources.GetString("CboUsuario.PropBag")
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(57, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(63, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(151, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "PERMISO DESBLOQUEO"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(2, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(249, 60)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(146, 127)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 66)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdEntrar
        '
        Me.cmdEntrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEntrar.ForeColor = System.Drawing.Color.Black
        Me.cmdEntrar.Image = CType(resources.GetObject("cmdEntrar.Image"), System.Drawing.Image)
        Me.cmdEntrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdEntrar.Location = New System.Drawing.Point(9, 127)
        Me.cmdEntrar.Name = "cmdEntrar"
        Me.cmdEntrar.Size = New System.Drawing.Size(75, 66)
        Me.cmdEntrar.TabIndex = 25
        Me.cmdEntrar.Text = "Aceptar"
        Me.cmdEntrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEntrar.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(85, 91)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(142, 20)
        Me.txtPassword.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Contraseña"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Usuario"
        '
        'FrmPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(237, 206)
        Me.Controls.Add(Me.CboUsuario)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cmdEntrar)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPermisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuario Desbloqueo"
        CType(Me.CboUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboUsuario As C1.Win.C1List.C1Combo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdEntrar As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
