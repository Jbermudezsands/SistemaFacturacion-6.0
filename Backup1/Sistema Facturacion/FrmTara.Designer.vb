<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTara
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTara))
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.TxtTara = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button7 = New System.Windows.Forms.Button
        Me.sp = New System.IO.Ports.SerialPort(Me.components)
        Me.LblEstado = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(335, 74)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(114, 56)
        Me.Button10.TabIndex = 217
        Me.Button10.Text = "Des-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Conectar"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.Location = New System.Drawing.Point(335, 12)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(114, 56)
        Me.Button11.TabIndex = 216
        Me.Button11.Text = "Conectar"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.UseVisualStyleBackColor = True
        '
        'TxtTara
        '
        Me.TxtTara.Location = New System.Drawing.Point(83, 32)
        Me.TxtTara.Name = "TxtTara"
        Me.TxtTara.Size = New System.Drawing.Size(100, 20)
        Me.TxtTara.TabIndex = 218
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 219
        Me.Label1.Text = "Tara"
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(215, 14)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(114, 56)
        Me.Button7.TabIndex = 220
        Me.Button7.Text = "Grabar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'sp
        '
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstado.ForeColor = System.Drawing.Color.SaddleBrown
        Me.LblEstado.Location = New System.Drawing.Point(22, 89)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(137, 24)
        Me.LblEstado.TabIndex = 239
        Me.LblEstado.Text = "DESCONECT"
        '
        'FrmTara
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 140)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtTara)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button11)
        Me.Name = "FrmTara"
        Me.Text = "FrmTara"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents TxtTara As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents sp As System.IO.Ports.SerialPort
    Friend WithEvents LblEstado As System.Windows.Forms.Label
End Class
