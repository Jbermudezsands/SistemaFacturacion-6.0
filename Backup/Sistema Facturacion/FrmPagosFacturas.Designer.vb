<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagosFacturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagosFacturas))
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.CmdProcesar = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TxtImporteAplicado = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPorAplicar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtImporteRecibido = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtApellidos = New System.Windows.Forms.TextBox
        Me.TxtNombres = New System.Windows.Forms.TextBox
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox
        Me.BindingFacturas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.OptRet7Porciento = New System.Windows.Forms.CheckBox
        Me.OptRet10Porciento = New System.Windows.Forms.CheckBox
        Me.OptRet2Porciento = New System.Windows.Forms.CheckBox
        Me.OptRet1Porciento = New System.Windows.Forms.CheckBox
        Me.TxtRetencion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(95, 332)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(565, 26)
        Me.ProgressBar.TabIndex = 225
        Me.ProgressBar.Visible = False
        '
        'CmdProcesar
        '
        Me.CmdProcesar.Location = New System.Drawing.Point(14, 332)
        Me.CmdProcesar.Name = "CmdProcesar"
        Me.CmdProcesar.Size = New System.Drawing.Size(75, 23)
        Me.CmdProcesar.TabIndex = 224
        Me.CmdProcesar.Text = "Procesar"
        Me.CmdProcesar.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Location = New System.Drawing.Point(670, 335)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(75, 23)
        Me.CmdSalir.TabIndex = 223
        Me.CmdSalir.Text = "Salir"
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'TrueDBGridMetodo
        '
        Me.TrueDBGridMetodo.AllowAddNew = True
        Me.TrueDBGridMetodo.AllowDelete = True
        Me.TrueDBGridMetodo.AlternatingRows = True
        Me.TrueDBGridMetodo.Caption = "Metodos de Pago"
        Me.TrueDBGridMetodo.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridMetodo.Images.Add(CType(resources.GetObject("TrueDBGridMetodo.Images"), System.Drawing.Image))
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(429, 12)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridMetodo.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridMetodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(316, 119)
        Me.TrueDBGridMetodo.TabIndex = 226
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Facturas"
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(12, 179)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(733, 147)
        Me.TrueDBGridComponentes.TabIndex = 227
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'TxtImporteAplicado
        '
        Me.TxtImporteAplicado.Enabled = False
        Me.TxtImporteAplicado.Location = New System.Drawing.Point(313, 153)
        Me.TxtImporteAplicado.Name = "TxtImporteAplicado"
        Me.TxtImporteAplicado.Size = New System.Drawing.Size(87, 20)
        Me.TxtImporteAplicado.TabIndex = 233
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(227, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 232
        Me.Label1.Text = "Importe Aplicado "
        '
        'TxtPorAplicar
        '
        Me.TxtPorAplicar.Enabled = False
        Me.TxtPorAplicar.Location = New System.Drawing.Point(476, 153)
        Me.TxtPorAplicar.Name = "TxtPorAplicar"
        Me.TxtPorAplicar.Size = New System.Drawing.Size(87, 20)
        Me.TxtPorAplicar.TabIndex = 231
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(416, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 230
        Me.Label5.Text = "Por Aplicar"
        '
        'TxtImporteRecibido
        '
        Me.TxtImporteRecibido.Enabled = False
        Me.TxtImporteRecibido.Location = New System.Drawing.Point(119, 153)
        Me.TxtImporteRecibido.Name = "TxtImporteRecibido"
        Me.TxtImporteRecibido.Size = New System.Drawing.Size(88, 20)
        Me.TxtImporteRecibido.TabIndex = 229
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(28, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 228
        Me.Label7.Text = "Importe Recibido   "
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Enabled = False
        Me.TxtApellidos.Location = New System.Drawing.Point(14, 74)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(253, 20)
        Me.TxtApellidos.TabIndex = 236
        '
        'TxtNombres
        '
        Me.TxtNombres.Enabled = False
        Me.TxtNombres.Location = New System.Drawing.Point(14, 48)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(253, 20)
        Me.TxtNombres.TabIndex = 235
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Enabled = False
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(14, 22)
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(176, 20)
        Me.TxtCodigoProveedor.TabIndex = 234
        '
        'OptRet7Porciento
        '
        Me.OptRet7Porciento.AutoSize = True
        Me.OptRet7Porciento.Location = New System.Drawing.Point(107, 101)
        Me.OptRet7Porciento.Name = "OptRet7Porciento"
        Me.OptRet7Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet7Porciento.TabIndex = 240
        Me.OptRet7Porciento.Text = "Retener 7%"
        Me.OptRet7Porciento.UseVisualStyleBackColor = True
        '
        'OptRet10Porciento
        '
        Me.OptRet10Porciento.AutoSize = True
        Me.OptRet10Porciento.Location = New System.Drawing.Point(107, 119)
        Me.OptRet10Porciento.Name = "OptRet10Porciento"
        Me.OptRet10Porciento.Size = New System.Drawing.Size(87, 17)
        Me.OptRet10Porciento.TabIndex = 239
        Me.OptRet10Porciento.Text = "Retener 10%"
        Me.OptRet10Porciento.UseVisualStyleBackColor = True
        '
        'OptRet2Porciento
        '
        Me.OptRet2Porciento.AutoSize = True
        Me.OptRet2Porciento.Location = New System.Drawing.Point(14, 120)
        Me.OptRet2Porciento.Name = "OptRet2Porciento"
        Me.OptRet2Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet2Porciento.TabIndex = 238
        Me.OptRet2Porciento.Text = "Retener 2%"
        Me.OptRet2Porciento.UseVisualStyleBackColor = True
        '
        'OptRet1Porciento
        '
        Me.OptRet1Porciento.AutoSize = True
        Me.OptRet1Porciento.Location = New System.Drawing.Point(14, 100)
        Me.OptRet1Porciento.Name = "OptRet1Porciento"
        Me.OptRet1Porciento.Size = New System.Drawing.Size(81, 17)
        Me.OptRet1Porciento.TabIndex = 237
        Me.OptRet1Porciento.Text = "Retener 1%"
        Me.OptRet1Porciento.UseVisualStyleBackColor = True
        '
        'TxtRetencion
        '
        Me.TxtRetencion.Enabled = False
        Me.TxtRetencion.Location = New System.Drawing.Point(636, 154)
        Me.TxtRetencion.Name = "TxtRetencion"
        Me.TxtRetencion.Size = New System.Drawing.Size(87, 20)
        Me.TxtRetencion.TabIndex = 242
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(576, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 241
        Me.Label2.Text = "Retencion"
        '
        'FrmPagosFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 370)
        Me.Controls.Add(Me.TxtRetencion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.OptRet7Porciento)
        Me.Controls.Add(Me.OptRet10Porciento)
        Me.Controls.Add(Me.OptRet2Porciento)
        Me.Controls.Add(Me.OptRet1Porciento)
        Me.Controls.Add(Me.TxtApellidos)
        Me.Controls.Add(Me.TxtNombres)
        Me.Controls.Add(Me.TxtCodigoProveedor)
        Me.Controls.Add(Me.TxtImporteAplicado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPorAplicar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtImporteRecibido)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.TrueDBGridMetodo)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.CmdProcesar)
        Me.Controls.Add(Me.CmdSalir)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagosFacturas"
        Me.Text = "FrmPagosFacturas"
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents CmdProcesar As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtImporteAplicado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPorAplicar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteRecibido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents BindingFacturas As System.Windows.Forms.BindingSource
    Friend WithEvents BindingMetodo As System.Windows.Forms.BindingSource
    Friend WithEvents OptRet7Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents OptRet10Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents OptRet2Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents OptRet1Porciento As System.Windows.Forms.CheckBox
    Friend WithEvents TxtRetencion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
