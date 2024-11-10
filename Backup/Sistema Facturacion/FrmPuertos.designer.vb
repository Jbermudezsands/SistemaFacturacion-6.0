<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPuertos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPuertos))
        Me.lista = New System.Windows.Forms.ListBox
        Me.consola = New System.Windows.Forms.TextBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lista
        '
        Me.lista.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lista.FormattingEnabled = True
        Me.lista.ItemHeight = 55
        Me.lista.Location = New System.Drawing.Point(3, 2)
        Me.lista.Name = "lista"
        Me.lista.Size = New System.Drawing.Size(198, 114)
        Me.lista.TabIndex = 1
        '
        'consola
        '
        Me.consola.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.consola.ForeColor = System.Drawing.SystemColors.Window
        Me.consola.Location = New System.Drawing.Point(207, 2)
        Me.consola.Multiline = True
        Me.consola.Name = "consola"
        Me.consola.Size = New System.Drawing.Size(239, 114)
        Me.consola.TabIndex = 3
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(310, 138)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(136, 64)
        Me.Button9.TabIndex = 185
        Me.Button9.Text = "Salir"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'FrmPuertos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(454, 215)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.consola)
        Me.Controls.Add(Me.lista)
        Me.Name = "FrmPuertos"
        Me.Text = "FrmPuertos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lista As System.Windows.Forms.ListBox
    Friend WithEvents consola As System.Windows.Forms.TextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
End Class
