<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMetodosPagos
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtNumeroTarjeta = New System.Windows.Forms.MaskedTextBox
        Me.DtpFechavence = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtNumeroTarjeta)
        Me.GroupBox1.Controls.Add(Me.DtpFechavence)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(136, 127)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TxtNumeroTarjeta
        '
        Me.TxtNumeroTarjeta.Location = New System.Drawing.Point(11, 32)
        Me.TxtNumeroTarjeta.Mask = "####-####-####-####"
        Me.TxtNumeroTarjeta.Name = "TxtNumeroTarjeta"
        Me.TxtNumeroTarjeta.Size = New System.Drawing.Size(112, 20)
        Me.TxtNumeroTarjeta.TabIndex = 1
        '
        'DtpFechavence
        '
        Me.DtpFechavence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechavence.Location = New System.Drawing.Point(10, 81)
        Me.DtpFechavence.Name = "DtpFechavence"
        Me.DtpFechavence.Size = New System.Drawing.Size(113, 20)
        Me.DtpFechavence.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha de Vencimiento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero Tarjeta"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Location = New System.Drawing.Point(2, 136)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(57, 23)
        Me.CmdAceptar.TabIndex = 1
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(81, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmMetodosPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(144, 168)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMetodosPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Metodos "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpFechavence As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroTarjeta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
