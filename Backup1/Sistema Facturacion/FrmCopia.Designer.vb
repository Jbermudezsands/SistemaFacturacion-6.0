<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCopia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCopia))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtConexion = New System.Windows.Forms.TextBox
        Me.CmdPrecios = New System.Windows.Forms.Button
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.TxtDestino = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdPrecios)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TxtConexion)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 82)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Origen"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtDestino)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(460, 69)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destino"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(-120, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 38)
        Me.Button1.TabIndex = 65
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtConexion
        '
        Me.TxtConexion.Location = New System.Drawing.Point(41, 19)
        Me.TxtConexion.Multiline = True
        Me.TxtConexion.Name = "TxtConexion"
        Me.TxtConexion.Size = New System.Drawing.Size(413, 47)
        Me.TxtConexion.TabIndex = 64
        '
        'CmdPrecios
        '
        Me.CmdPrecios.Image = CType(resources.GetObject("CmdPrecios.Image"), System.Drawing.Image)
        Me.CmdPrecios.Location = New System.Drawing.Point(6, 19)
        Me.CmdPrecios.Name = "CmdPrecios"
        Me.CmdPrecios.Size = New System.Drawing.Size(29, 30)
        Me.CmdPrecios.TabIndex = 170
        Me.CmdPrecios.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 175)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(457, 27)
        Me.ProgressBar.TabIndex = 227
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(397, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 67)
        Me.Button2.TabIndex = 226
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(12, 208)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 67)
        Me.Button3.TabIndex = 225
        Me.Button3.Text = "Procesar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxtDestino
        '
        Me.TxtDestino.Location = New System.Drawing.Point(7, 20)
        Me.TxtDestino.Multiline = True
        Me.TxtDestino.Name = "TxtDestino"
        Me.TxtDestino.Size = New System.Drawing.Size(447, 43)
        Me.TxtDestino.TabIndex = 0
        '
        'FrmCopia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 284)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmCopia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCopia"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtConexion As System.Windows.Forms.TextBox
    Friend WithEvents CmdPrecios As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TxtDestino As System.Windows.Forms.TextBox
End Class
