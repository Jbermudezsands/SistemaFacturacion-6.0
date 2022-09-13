<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreciosFacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPreciosFacturacion))
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CmdPegar = New System.Windows.Forms.Button
        Me.LblProducto = New System.Windows.Forms.Label
        Me.Button8 = New System.Windows.Forms.Button
        Me.tdbGridUnidadMedida = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tdbGridUndMedidaVrsPrecio = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.LblUnidad = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCantidad = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbGridUnidadMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbGridUndMedidaVrsPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(179, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 13)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "PRECIOS FACTURACION"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(533, 60)
        Me.PictureBox1.TabIndex = 167
        Me.PictureBox1.TabStop = False
        '
        'CmdPegar
        '
        Me.CmdPegar.Image = CType(resources.GetObject("CmdPegar.Image"), System.Drawing.Image)
        Me.CmdPegar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdPegar.Location = New System.Drawing.Point(12, 347)
        Me.CmdPegar.Name = "CmdPegar"
        Me.CmdPegar.Size = New System.Drawing.Size(75, 67)
        Me.CmdPegar.TabIndex = 172
        Me.CmdPegar.Text = "Pegar"
        Me.CmdPegar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdPegar.UseVisualStyleBackColor = True
        '
        'LblProducto
        '
        Me.LblProducto.AutoSize = True
        Me.LblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProducto.Location = New System.Drawing.Point(16, 63)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(193, 13)
        Me.LblProducto.TabIndex = 171
        Me.LblProducto.Text = "0001 NOMBRE DEL PRODUCTO"
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(432, 348)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(86, 66)
        Me.Button8.TabIndex = 170
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'tdbGridUnidadMedida
        '
        Me.tdbGridUnidadMedida.AllowUpdate = False
        Me.tdbGridUnidadMedida.AlternatingRows = True
        Me.tdbGridUnidadMedida.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tdbGridUnidadMedida.Caption = "Unidades de Medida"
        Me.tdbGridUnidadMedida.ChildGrid = Me.tdbGridUndMedidaVrsPrecio
        Me.tdbGridUnidadMedida.FilterBar = True
        Me.tdbGridUnidadMedida.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbGridUnidadMedida.Images.Add(CType(resources.GetObject("tdbGridUnidadMedida.Images"), System.Drawing.Image))
        Me.tdbGridUnidadMedida.Location = New System.Drawing.Point(12, 89)
        Me.tdbGridUnidadMedida.Name = "tdbGridUnidadMedida"
        Me.tdbGridUnidadMedida.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbGridUnidadMedida.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbGridUnidadMedida.PreviewInfo.ZoomFactor = 75
        Me.tdbGridUnidadMedida.PrintInfo.PageSettings = CType(resources.GetObject("tdbGridUnidadMedida.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbGridUnidadMedida.Size = New System.Drawing.Size(506, 238)
        Me.tdbGridUnidadMedida.TabIndex = 173
        Me.tdbGridUnidadMedida.Text = "C1TrueDBGrid1"
        Me.tdbGridUnidadMedida.PropBag = resources.GetString("tdbGridUnidadMedida.PropBag")
        '
        'tdbGridUndMedidaVrsPrecio
        '
        Me.tdbGridUndMedidaVrsPrecio.AllowUpdate = False
        Me.tdbGridUndMedidaVrsPrecio.AlternatingRows = True
        Me.tdbGridUndMedidaVrsPrecio.Caption = "Unidad Medida Vrs Lista Precio"
        Me.tdbGridUndMedidaVrsPrecio.FilterBar = True
        Me.tdbGridUndMedidaVrsPrecio.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbGridUndMedidaVrsPrecio.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbGridUndMedidaVrsPrecio.Images.Add(CType(resources.GetObject("tdbGridUndMedidaVrsPrecio.Images"), System.Drawing.Image))
        Me.tdbGridUndMedidaVrsPrecio.Location = New System.Drawing.Point(52, 197)
        Me.tdbGridUndMedidaVrsPrecio.Name = "tdbGridUndMedidaVrsPrecio"
        Me.tdbGridUndMedidaVrsPrecio.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbGridUndMedidaVrsPrecio.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbGridUndMedidaVrsPrecio.PreviewInfo.ZoomFactor = 75
        Me.tdbGridUndMedidaVrsPrecio.PrintInfo.PageSettings = CType(resources.GetObject("tdbGridUndMedidaVrsPrecio.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbGridUndMedidaVrsPrecio.Size = New System.Drawing.Size(449, 118)
        Me.tdbGridUndMedidaVrsPrecio.TabIndex = 174
        Me.tdbGridUndMedidaVrsPrecio.TabStop = False
        Me.tdbGridUndMedidaVrsPrecio.Text = "C1TrueDBGrid1"
        Me.tdbGridUndMedidaVrsPrecio.PropBag = resources.GetString("tdbGridUndMedidaVrsPrecio.PropBag")
        '
        'LblUnidad
        '
        Me.LblUnidad.AutoSize = True
        Me.LblUnidad.Location = New System.Drawing.Point(270, 370)
        Me.LblUnidad.Name = "LblUnidad"
        Me.LblUnidad.Size = New System.Drawing.Size(39, 13)
        Me.LblUnidad.TabIndex = 175
        Me.LblUnidad.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 348)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Cantidad"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(271, 347)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.TxtCantidad.TabIndex = 177
        Me.TxtCantidad.Text = "1"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(93, 347)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 67)
        Me.Button1.TabIndex = 178
        Me.Button1.Text = "Act Precios"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmPreciosFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 426)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblUnidad)
        Me.Controls.Add(Me.tdbGridUndMedidaVrsPrecio)
        Me.Controls.Add(Me.tdbGridUnidadMedida)
        Me.Controls.Add(Me.CmdPegar)
        Me.Controls.Add(Me.LblProducto)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPreciosFacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Precios x Unidad Medida"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbGridUnidadMedida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbGridUndMedidaVrsPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdPegar As System.Windows.Forms.Button
    Friend WithEvents LblProducto As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents tdbGridUnidadMedida As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tdbGridUndMedidaVrsPrecio As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents LblUnidad As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
