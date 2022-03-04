<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpresoras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpresoras))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbImpresorasRecibo = New System.Windows.Forms.ComboBox
        Me.CmbImpresorasRemision = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.BtnGuardarRem = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbImpresorasRecibo)
        Me.GroupBox1.Controls.Add(Me.CmbImpresorasRemision)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 160)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Listado de Impresoras"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Impresora Recibo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Impresora Factura"
        '
        'CmbImpresorasRecibo
        '
        Me.CmbImpresorasRecibo.FormattingEnabled = True
        Me.CmbImpresorasRecibo.Location = New System.Drawing.Point(10, 96)
        Me.CmbImpresorasRecibo.Name = "CmbImpresorasRecibo"
        Me.CmbImpresorasRecibo.Size = New System.Drawing.Size(351, 21)
        Me.CmbImpresorasRecibo.TabIndex = 2
        '
        'CmbImpresorasRemision
        '
        Me.CmbImpresorasRemision.FormattingEnabled = True
        Me.CmbImpresorasRemision.Location = New System.Drawing.Point(10, 45)
        Me.CmbImpresorasRemision.Name = "CmbImpresorasRemision"
        Me.CmbImpresorasRemision.Size = New System.Drawing.Size(351, 21)
        Me.CmbImpresorasRemision.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(21, 255)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(469, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Selecciona la Impresora y establecer como Predeterminada"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.BtnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnSalir.Location = New System.Drawing.Point(290, 178)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(114, 58)
        Me.BtnSalir.TabIndex = 232
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnGuardarRem
        '
        Me.BtnGuardarRem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.BtnGuardarRem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnGuardarRem.Image = CType(resources.GetObject("BtnGuardarRem.Image"), System.Drawing.Image)
        Me.BtnGuardarRem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardarRem.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnGuardarRem.Location = New System.Drawing.Point(-343, 132)
        Me.BtnGuardarRem.Name = "BtnGuardarRem"
        Me.BtnGuardarRem.Size = New System.Drawing.Size(114, 58)
        Me.BtnGuardarRem.TabIndex = 231
        Me.BtnGuardarRem.Text = "Guardar"
        Me.BtnGuardarRem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardarRem.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnGuardar.Location = New System.Drawing.Point(21, 178)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(114, 58)
        Me.BtnGuardar.TabIndex = 233
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'FrmImpresoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 243)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BtnGuardarRem)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmImpresoras"
        Me.Text = "FrmImpresoras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents CmbImpresorasRemision As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardarRem As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbImpresorasRecibo As System.Windows.Forms.ComboBox
End Class
