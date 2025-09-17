<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFechaxProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFechaxProveedor))
        Me.DTPFechaRequerido = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.BtnProcesar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DTPFechaRequerido
        '
        Me.DTPFechaRequerido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaRequerido.Location = New System.Drawing.Point(62, 17)
        Me.DTPFechaRequerido.Name = "DTPFechaRequerido"
        Me.DTPFechaRequerido.Size = New System.Drawing.Size(117, 20)
        Me.DTPFechaRequerido.TabIndex = 256
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Fecha"
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(52, 52)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(256, 20)
        Me.TxtNombres.TabIndex = 261
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.Location = New System.Drawing.Point(268, 19)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(37, 32)
        Me.BtnBuscar.TabIndex = 260
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(52, 26)
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(210, 20)
        Me.TxtCodigoProveedor.TabIndex = 259
        '
        'BtnProcesar
        '
        Me.BtnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProcesar.Image = CType(resources.GetObject("BtnProcesar.Image"), System.Drawing.Image)
        Me.BtnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnProcesar.Location = New System.Drawing.Point(22, 154)
        Me.BtnProcesar.Name = "BtnProcesar"
        Me.BtnProcesar.Size = New System.Drawing.Size(65, 66)
        Me.BtnProcesar.TabIndex = 262
        Me.BtnProcesar.Tag = "28"
        Me.BtnProcesar.Text = "Procesar"
        Me.BtnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnProcesar.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSalir.Location = New System.Drawing.Point(278, 154)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(65, 66)
        Me.BtnSalir.TabIndex = 263
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 264
        Me.Label2.Text = "Codigo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.TxtNombres)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 94)
        Me.GroupBox1.TabIndex = 265
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Proveedor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 265
        Me.Label3.Text = "Nombre"
        '
        'FrmFechaxProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 229)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BtnProcesar)
        Me.Controls.Add(Me.DTPFechaRequerido)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmFechaxProveedor"
        Me.Text = "FrmFechaxProveedor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DTPFechaRequerido As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtNombres As TextBox
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents TxtCodigoProveedor As TextBox
    Friend WithEvents BtnProcesar As Button
    Friend WithEvents BtnSalir As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
End Class
