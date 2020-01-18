<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProveedores))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ChkInventario = New System.Windows.Forms.CheckBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.TxtApellido = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CboCodigoProveedor = New C1.Win.C1List.C1Combo
        Me.TxtCtaxPagar = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtMerma = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtCtaxCobrar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmdConsulta = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TruDbGridHistoricosCompras = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BindingHistoricoCompras = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.TruDbGridHistoricosCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingHistoricoCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(417, 60)
        Me.PictureBox1.TabIndex = 68
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 69
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(97, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(193, 13)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "REGISTRO DE  PROVEEDORES"
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(178, 384)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 13
        Me.ButtonBorrar.Tag = "29"
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(13, 384)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 11
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(326, 380)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 14
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(94, 384)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 12
        Me.CmdGrabar.Tag = "25"
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 64)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(390, 310)
        Me.TabControl1.TabIndex = 94
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ChkInventario)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.TxtApellido)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.CboCodigoProveedor)
        Me.TabPage1.Controls.Add(Me.TxtCtaxPagar)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.TxtMerma)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.TxtCtaxCobrar)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.TxtTelefono)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TxtDireccion)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TxtNombre)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.CmdConsulta)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(382, 284)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro Proveedor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ChkInventario
        '
        Me.ChkInventario.AutoSize = True
        Me.ChkInventario.Location = New System.Drawing.Point(124, 251)
        Me.ChkInventario.Name = "ChkInventario"
        Me.ChkInventario.Size = New System.Drawing.Size(172, 17)
        Me.ChkInventario.TabIndex = 139
        Me.ChkInventario.Text = "Cuenta Ajuste Inventario Fisico"
        Me.ChkInventario.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(278, 200)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 38)
        Me.Button2.TabIndex = 104
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtApellido
        '
        Me.TxtApellido.Location = New System.Drawing.Point(123, 73)
        Me.TxtApellido.Name = "TxtApellido"
        Me.TxtApellido.Size = New System.Drawing.Size(252, 20)
        Me.TxtApellido.TabIndex = 96
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Apellido Proveedor"
        '
        'CboCodigoProveedor
        '
        Me.CboCodigoProveedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoProveedor.Caption = ""
        Me.CboCodigoProveedor.CaptionHeight = 17
        Me.CboCodigoProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoProveedor.ColumnCaptionHeight = 17
        Me.CboCodigoProveedor.ColumnFooterHeight = 17
        Me.CboCodigoProveedor.ContentHeight = 15
        Me.CboCodigoProveedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoProveedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoProveedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoProveedor.EditorHeight = 15
        Me.CboCodigoProveedor.Images.Add(CType(resources.GetObject("CboCodigoProveedor.Images"), System.Drawing.Image))
        Me.CboCodigoProveedor.ItemHeight = 15
        Me.CboCodigoProveedor.Location = New System.Drawing.Point(123, 20)
        Me.CboCodigoProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoProveedor.MaxLength = 32767
        Me.CboCodigoProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoProveedor.Name = "CboCodigoProveedor"
        Me.CboCodigoProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.Size = New System.Drawing.Size(209, 21)
        Me.CboCodigoProveedor.TabIndex = 94
        Me.CboCodigoProveedor.PropBag = resources.GetString("CboCodigoProveedor.PropBag")
        '
        'TxtCtaxPagar
        '
        Me.TxtCtaxPagar.Location = New System.Drawing.Point(124, 199)
        Me.TxtCtaxPagar.Name = "TxtCtaxPagar"
        Me.TxtCtaxPagar.Size = New System.Drawing.Size(148, 20)
        Me.TxtCtaxPagar.TabIndex = 101
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Cuenta x Pagar"
        '
        'TxtMerma
        '
        Me.TxtMerma.Location = New System.Drawing.Point(124, 225)
        Me.TxtMerma.Name = "TxtMerma"
        Me.TxtMerma.Size = New System.Drawing.Size(48, 20)
        Me.TxtMerma.TabIndex = 100
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "% Merma"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(278, 155)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 38)
        Me.Button1.TabIndex = 103
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtCtaxCobrar
        '
        Me.TxtCtaxCobrar.Location = New System.Drawing.Point(124, 173)
        Me.TxtCtaxCobrar.Name = "TxtCtaxCobrar"
        Me.TxtCtaxCobrar.Size = New System.Drawing.Size(148, 20)
        Me.TxtCtaxCobrar.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Cuenta  x Cobrar"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(124, 147)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(148, 20)
        Me.TxtTelefono.TabIndex = 98
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Telefono"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(124, 96)
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(252, 44)
        Me.TxtDireccion.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Direccion Proveedor"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(123, 49)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(252, 20)
        Me.TxtNombre.TabIndex = 95
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Nombre Proveedor"
        '
        'CmdConsulta
        '
        Me.CmdConsulta.Image = CType(resources.GetObject("CmdConsulta.Image"), System.Drawing.Image)
        Me.CmdConsulta.Location = New System.Drawing.Point(338, 7)
        Me.CmdConsulta.Name = "CmdConsulta"
        Me.CmdConsulta.Size = New System.Drawing.Size(37, 38)
        Me.CmdConsulta.TabIndex = 102
        Me.CmdConsulta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Codigo Proveedor"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TruDbGridHistoricosCompras)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(382, 284)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Historico"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TruDbGridHistoricosCompras
        '
        Me.TruDbGridHistoricosCompras.AllowUpdate = False
        Me.TruDbGridHistoricosCompras.AlternatingRows = True
        Me.TruDbGridHistoricosCompras.Caption = "Historico de Compras"
        Me.TruDbGridHistoricosCompras.FilterBar = True
        Me.TruDbGridHistoricosCompras.GroupByCaption = "Drag a column header here to group by that column"
        Me.TruDbGridHistoricosCompras.Images.Add(CType(resources.GetObject("TruDbGridHistoricosCompras.Images"), System.Drawing.Image))
        Me.TruDbGridHistoricosCompras.Location = New System.Drawing.Point(6, 6)
        Me.TruDbGridHistoricosCompras.Name = "TruDbGridHistoricosCompras"
        Me.TruDbGridHistoricosCompras.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TruDbGridHistoricosCompras.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TruDbGridHistoricosCompras.PreviewInfo.ZoomFactor = 75
        Me.TruDbGridHistoricosCompras.PrintInfo.PageSettings = CType(resources.GetObject("TruDbGridHistoricosCompras.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TruDbGridHistoricosCompras.Size = New System.Drawing.Size(370, 232)
        Me.TruDbGridHistoricosCompras.TabIndex = 130
        Me.TruDbGridHistoricosCompras.Text = "C1TrueDBGrid2"
        Me.TruDbGridHistoricosCompras.PropBag = resources.GetString("TruDbGridHistoricosCompras.PropBag")
        '
        'FrmProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 458)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proveedores"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.TruDbGridHistoricosCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingHistoricoCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents TxtCtaxPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMerma As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtCtaxCobrar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmdConsulta As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindingHistoricoCompras As System.Windows.Forms.BindingSource
    Friend WithEvents TruDbGridHistoricosCompras As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ChkInventario As System.Windows.Forms.CheckBox
End Class
