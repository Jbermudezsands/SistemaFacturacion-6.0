<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLotes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLotes))
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.LblCantidad = New System.Windows.Forms.Label()
        Me.LblNumero = New System.Windows.Forms.Label()
        Me.LblProducto = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(312, 305)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(94, 34)
        Me.Button4.TabIndex = 208
        Me.Button4.Text = "Imprimir"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(212, 303)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 34)
        Me.Button2.TabIndex = 205
        Me.Button2.Text = "Borra Linea"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(412, 303)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 34)
        Me.Button1.TabIndex = 204
        Me.Button1.Text = "Grabar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(508, 305)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 34)
        Me.Button8.TabIndex = 203
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'LblCantidad
        '
        Me.LblCantidad.AutoSize = True
        Me.LblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad.ForeColor = System.Drawing.Color.Navy
        Me.LblCantidad.Location = New System.Drawing.Point(470, 69)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(21, 13)
        Me.LblCantidad.TabIndex = 193
        Me.LblCantidad.Text = "10"
        '
        'LblNumero
        '
        Me.LblNumero.AutoSize = True
        Me.LblNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.LblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumero.ForeColor = System.Drawing.Color.Maroon
        Me.LblNumero.Location = New System.Drawing.Point(93, 8)
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Size = New System.Drawing.Size(65, 24)
        Me.LblNumero.TabIndex = 191
        Me.LblNumero.Text = "10000"
        Me.LblNumero.Visible = False
        '
        'LblProducto
        '
        Me.LblProducto.AutoSize = True
        Me.LblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProducto.ForeColor = System.Drawing.Color.Navy
        Me.LblProducto.Location = New System.Drawing.Point(70, 69)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(201, 13)
        Me.LblProducto.TabIndex = 189
        Me.LblProducto.Text = "JUAN BERMUDEZ  HERNANDEZ "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 187
        Me.Label2.Text = "Producto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(209, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 18)
        Me.Label1.TabIndex = 186
        Me.Label1.Text = "DETALLE DE LOTES"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(16, -5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 185
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox4.Location = New System.Drawing.Point(-1, -5)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(597, 60)
        Me.PictureBox4.TabIndex = 184
        Me.PictureBox4.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(395, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "Cant Factura:"
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Detalle de Productos por Lotes"
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(17, 89)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(566, 208)
        Me.TrueDBGridComponentes.TabIndex = 210
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(312, 303)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(94, 34)
        Me.Button3.TabIndex = 211
        Me.Button3.Text = "Busca Lote"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(12, 305)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(94, 34)
        Me.Button5.TabIndex = 212
        Me.Button5.Text = "Pegar"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(112, 305)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(94, 34)
        Me.Button6.TabIndex = 215
        Me.Button6.Text = "Agregar"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'FrmLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 359)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LblCantidad)
        Me.Controls.Add(Me.LblNumero)
        Me.Controls.Add(Me.LblProducto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLotes"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents LblCantidad As System.Windows.Forms.Label
    Friend WithEvents LblNumero As System.Windows.Forms.Label
    Friend WithEvents LblProducto As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As Button
End Class
