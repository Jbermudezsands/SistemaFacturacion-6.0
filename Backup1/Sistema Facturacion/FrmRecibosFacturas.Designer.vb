<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecibosFacturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecibosFacturas))
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.TxtImporteAplicado = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPorAplicar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtImporteRecibido = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdProcesar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BindingFacturas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGridMetodo
        '
        Me.TrueDBGridMetodo.AllowAddNew = True
        Me.TrueDBGridMetodo.AllowDelete = True
        Me.TrueDBGridMetodo.AlternatingRows = True
        Me.TrueDBGridMetodo.Caption = "Metodos de Pago"
        Me.TrueDBGridMetodo.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridMetodo.Images.Add(CType(resources.GetObject("TrueDBGridMetodo.Images"), System.Drawing.Image))
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(12, 21)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridMetodo.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridMetodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(249, 146)
        Me.TrueDBGridMetodo.TabIndex = 206
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'TxtImporteAplicado
        '
        Me.TxtImporteAplicado.Enabled = False
        Me.TxtImporteAplicado.Location = New System.Drawing.Point(404, 41)
        Me.TxtImporteAplicado.Name = "TxtImporteAplicado"
        Me.TxtImporteAplicado.Size = New System.Drawing.Size(87, 20)
        Me.TxtImporteAplicado.TabIndex = 217
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(307, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "Importe Aplicado "
        '
        'TxtPorAplicar
        '
        Me.TxtPorAplicar.Enabled = False
        Me.TxtPorAplicar.Location = New System.Drawing.Point(404, 64)
        Me.TxtPorAplicar.Name = "TxtPorAplicar"
        Me.TxtPorAplicar.Size = New System.Drawing.Size(87, 20)
        Me.TxtPorAplicar.TabIndex = 215
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(333, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 214
        Me.Label5.Text = "Por Aplicar"
        '
        'TxtImporteRecibido
        '
        Me.TxtImporteRecibido.Enabled = False
        Me.TxtImporteRecibido.Location = New System.Drawing.Point(403, 18)
        Me.TxtImporteRecibido.Name = "TxtImporteRecibido"
        Me.TxtImporteRecibido.Size = New System.Drawing.Size(88, 20)
        Me.TxtImporteRecibido.TabIndex = 213
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(301, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 212
        Me.Label7.Text = "Importe Recibido   "
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Facturas"
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(12, 173)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(486, 147)
        Me.TrueDBGridComponentes.TabIndex = 218
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'CmdSalir
        '
        Me.CmdSalir.Location = New System.Drawing.Point(403, 327)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(75, 23)
        Me.CmdSalir.TabIndex = 219
        Me.CmdSalir.Text = "Salir"
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdProcesar
        '
        Me.CmdProcesar.Location = New System.Drawing.Point(12, 327)
        Me.CmdProcesar.Name = "CmdProcesar"
        Me.CmdProcesar.Size = New System.Drawing.Size(75, 23)
        Me.CmdProcesar.TabIndex = 220
        Me.CmdProcesar.Text = "Procesar"
        Me.CmdProcesar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(366, 90)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 77)
        Me.PictureBox1.TabIndex = 221
        Me.PictureBox1.TabStop = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(93, 327)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(303, 26)
        Me.ProgressBar.TabIndex = 222
        Me.ProgressBar.Visible = False
        '
        'FrmRecibosFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 359)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmdProcesar)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.TxtImporteAplicado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPorAplicar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtImporteRecibido)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TrueDBGridMetodo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRecibosFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "      "
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtImporteAplicado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPorAplicar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteRecibido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdProcesar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BindingFacturas As System.Windows.Forms.BindingSource
    Friend WithEvents BindingMetodo As System.Windows.Forms.BindingSource
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
End Class
