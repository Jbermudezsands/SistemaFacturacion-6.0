<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAgregarNotaCredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAgregarNotaCredito))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxtMontoRecibo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblMontoFactura = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblNumeroFactura = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TDGridImpuestos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblNumeroNota = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblMontoNota = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtMontoRecibo)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.LblMontoFactura)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.LblNumeroFactura)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(503, 100)
        Me.GroupBox3.TabIndex = 224
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Destino Reasignacion"
        '
        'TxtMontoRecibo
        '
        Me.TxtMontoRecibo.Location = New System.Drawing.Point(382, 25)
        Me.TxtMontoRecibo.Name = "TxtMontoRecibo"
        Me.TxtMontoRecibo.Size = New System.Drawing.Size(98, 20)
        Me.TxtMontoRecibo.TabIndex = 234
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(266, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 16)
        Me.Label10.TabIndex = 228
        Me.Label10.Text = "Monto Asignar"
        '
        'LblMontoFactura
        '
        Me.LblMontoFactura.AutoSize = True
        Me.LblMontoFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoFactura.Location = New System.Drawing.Point(122, 66)
        Me.LblMontoFactura.Name = "LblMontoFactura"
        Me.LblMontoFactura.Size = New System.Drawing.Size(84, 16)
        Me.LblMontoFactura.TabIndex = 227
        Me.LblMontoFactura.Text = "5000000.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 16)
        Me.Label7.TabIndex = 226
        Me.Label7.Text = "Monto Factura"
        '
        'LblNumeroFactura
        '
        Me.LblNumeroFactura.AutoSize = True
        Me.LblNumeroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumeroFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblNumeroFactura.Location = New System.Drawing.Point(96, 23)
        Me.LblNumeroFactura.Name = "LblNumeroFactura"
        Me.LblNumeroFactura.Size = New System.Drawing.Size(103, 25)
        Me.LblNumeroFactura.TabIndex = 225
        Me.LblNumeroFactura.Text = "0000883"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 224
        Me.Label5.Text = "Factura No:"
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(515, 71)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 227
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(515, 12)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 34)
        Me.Button7.TabIndex = 226
        Me.Button7.Text = "        Insertar     Nota"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.Sistema_Facturacion.My.Resources.Resources.Unpinned
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(12, 111)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 27)
        Me.Button1.TabIndex = 228
        Me.Button1.Text = "Seleccionar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TDGridImpuestos
        '
        Me.TDGridImpuestos.AllowUpdate = False
        Me.TDGridImpuestos.AlternatingRows = True
        Me.TDGridImpuestos.Caption = "Listado de Impuestos para Liquidacion de Productos"
        Me.TDGridImpuestos.FilterBar = True
        Me.TDGridImpuestos.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridImpuestos.Images.Add(CType(resources.GetObject("TDGridImpuestos.Images"), System.Drawing.Image))
        Me.TDGridImpuestos.Location = New System.Drawing.Point(6, 159)
        Me.TDGridImpuestos.Name = "TDGridImpuestos"
        Me.TDGridImpuestos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridImpuestos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridImpuestos.PreviewInfo.ZoomFactor = 75
        Me.TDGridImpuestos.PrintInfo.PageSettings = CType(resources.GetObject("TDGridImpuestos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridImpuestos.Size = New System.Drawing.Size(902, 208)
        Me.TDGridImpuestos.TabIndex = 229
        Me.TDGridImpuestos.Text = "C1TrueDBGrid1"
        Me.TDGridImpuestos.Visible = False
        Me.TDGridImpuestos.PropBag = resources.GetString("TDGridImpuestos.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblMontoNota)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LblNumeroNota)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 145)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(596, 222)
        Me.GroupBox1.TabIndex = 230
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nota de Credito"
        '
        'LblNumeroNota
        '
        Me.LblNumeroNota.AutoSize = True
        Me.LblNumeroNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumeroNota.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblNumeroNota.Location = New System.Drawing.Point(124, 34)
        Me.LblNumeroNota.Name = "LblNumeroNota"
        Me.LblNumeroNota.Size = New System.Drawing.Size(103, 25)
        Me.LblNumeroNota.TabIndex = 227
        Me.LblNumeroNota.Text = "0000883"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "Numero Nota:"
        '
        'LblMontoNota
        '
        Me.LblMontoNota.AutoSize = True
        Me.LblMontoNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoNota.Location = New System.Drawing.Point(365, 41)
        Me.LblMontoNota.Name = "LblMontoNota"
        Me.LblMontoNota.Size = New System.Drawing.Size(36, 16)
        Me.LblMontoNota.TabIndex = 229
        Me.LblMontoNota.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(252, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Monto Factura"
        '
        'FrmAgregarNotaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 379)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TDGridImpuestos)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "FrmAgregarNotaCredito"
        Me.Text = "FrmAgregarNotaCredito"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TDGridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMontoRecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblMontoFactura As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblNumeroFactura As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TDGridImpuestos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblNumeroNota As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblMontoNota As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
