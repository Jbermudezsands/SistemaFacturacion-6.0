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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecibosFacturas))
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TxtImporteAplicado = New System.Windows.Forms.TextBox()
        Me.TxtPorAplicar = New System.Windows.Forms.TextBox()
        Me.TxtImporteRecibido = New System.Windows.Forms.TextBox()
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BindingFacturas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingMetodo = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.pnlMetodosPago = New System.Windows.Forms.Panel()
        Me.btnQuitarMetodo = New System.Windows.Forms.Button()
        Me.lblTituloMetodos = New System.Windows.Forms.Label()
        Me.btnAgregarMetodo = New System.Windows.Forms.Button()
        Me.cardRecibido = New System.Windows.Forms.Panel()
        Me.franjaRecibido = New System.Windows.Forms.Panel()
        Me.lblTituloRecibido = New System.Windows.Forms.Label()
        Me.cardAplicado = New System.Windows.Forms.Panel()
        Me.franjaAplicado = New System.Windows.Forms.Panel()
        Me.lblTituloAplicado = New System.Windows.Forms.Label()
        Me.cardPorAplicar = New System.Windows.Forms.Panel()
        Me.franjaPorAplicar = New System.Windows.Forms.Panel()
        Me.lblTituloPorAplicar = New System.Windows.Forms.Label()
        Me.pnlFacturas = New System.Windows.Forms.Panel()
        Me.lblTituloFacturas = New System.Windows.Forms.Label()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMetodosPago.SuspendLayout()
        Me.cardRecibido.SuspendLayout()
        Me.cardAplicado.SuspendLayout()
        Me.cardPorAplicar.SuspendLayout()
        Me.pnlFacturas.SuspendLayout()
        Me.pnlInferior.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGridMetodo
        '
        Me.TrueDBGridMetodo.AllowAddNew = True
        Me.TrueDBGridMetodo.AllowDelete = True
        Me.TrueDBGridMetodo.AlternatingRows = True
        Me.TrueDBGridMetodo.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridMetodo.Images.Add(CType(resources.GetObject("TrueDBGridMetodo.Images"), System.Drawing.Image))
        Me.TrueDBGridMetodo.Location = New System.Drawing.Point(12, 31)
        Me.TrueDBGridMetodo.Name = "TrueDBGridMetodo"
        Me.TrueDBGridMetodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridMetodo.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridMetodo.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridMetodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(407, 146)
        Me.TrueDBGridMetodo.TabIndex = 206
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'TxtImporteAplicado
        '
        Me.TxtImporteAplicado.BackColor = System.Drawing.Color.White
        Me.TxtImporteAplicado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtImporteAplicado.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.TxtImporteAplicado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TxtImporteAplicado.Location = New System.Drawing.Point(32, 29)
        Me.TxtImporteAplicado.Name = "TxtImporteAplicado"
        Me.TxtImporteAplicado.ReadOnly = True
        Me.TxtImporteAplicado.Size = New System.Drawing.Size(307, 29)
        Me.TxtImporteAplicado.TabIndex = 217
        Me.TxtImporteAplicado.Text = "0.00"
        Me.TxtImporteAplicado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPorAplicar
        '
        Me.TxtPorAplicar.BackColor = System.Drawing.Color.White
        Me.TxtPorAplicar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPorAplicar.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.TxtPorAplicar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.TxtPorAplicar.Location = New System.Drawing.Point(23, 26)
        Me.TxtPorAplicar.Name = "TxtPorAplicar"
        Me.TxtPorAplicar.ReadOnly = True
        Me.TxtPorAplicar.Size = New System.Drawing.Size(316, 29)
        Me.TxtPorAplicar.TabIndex = 215
        Me.TxtPorAplicar.Text = "0.00"
        Me.TxtPorAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtImporteRecibido
        '
        Me.TxtImporteRecibido.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TxtImporteRecibido.BackColor = System.Drawing.Color.White
        Me.TxtImporteRecibido.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtImporteRecibido.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.TxtImporteRecibido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtImporteRecibido.Location = New System.Drawing.Point(23, 28)
        Me.TxtImporteRecibido.Name = "TxtImporteRecibido"
        Me.TxtImporteRecibido.ReadOnly = True
        Me.TxtImporteRecibido.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtImporteRecibido.Size = New System.Drawing.Size(316, 29)
        Me.TxtImporteRecibido.TabIndex = 213
        Me.TxtImporteRecibido.Text = "0.00"
        Me.TxtImporteRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Enabled = False
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(10, 30)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75.0R
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(887, 266)
        Me.TrueDBGridComponentes.TabIndex = 218
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(936, 55)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 77)
        Me.PictureBox1.TabIndex = 221
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 7)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(667, 26)
        Me.ProgressBar.TabIndex = 222
        Me.ProgressBar.Visible = False
        '
        'pnlMetodosPago
        '
        Me.pnlMetodosPago.BackColor = System.Drawing.Color.White
        Me.pnlMetodosPago.Controls.Add(Me.btnQuitarMetodo)
        Me.pnlMetodosPago.Controls.Add(Me.lblTituloMetodos)
        Me.pnlMetodosPago.Controls.Add(Me.btnAgregarMetodo)
        Me.pnlMetodosPago.Controls.Add(Me.TrueDBGridMetodo)
        Me.pnlMetodosPago.Location = New System.Drawing.Point(2, 3)
        Me.pnlMetodosPago.Name = "pnlMetodosPago"
        Me.pnlMetodosPago.Size = New System.Drawing.Size(560, 210)
        Me.pnlMetodosPago.TabIndex = 223
        '
        'btnQuitarMetodo
        '
        Me.btnQuitarMetodo.BackColor = System.Drawing.Color.White
        Me.btnQuitarMetodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuitarMetodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnQuitarMetodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitarMetodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnQuitarMetodo.Location = New System.Drawing.Point(425, 69)
        Me.btnQuitarMetodo.Name = "btnQuitarMetodo"
        Me.btnQuitarMetodo.Size = New System.Drawing.Size(96, 30)
        Me.btnQuitarMetodo.TabIndex = 207
        Me.btnQuitarMetodo.Text = "- Quitar"
        Me.btnQuitarMetodo.UseVisualStyleBackColor = False
        '
        'lblTituloMetodos
        '
        Me.lblTituloMetodos.AutoSize = True
        Me.lblTituloMetodos.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloMetodos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblTituloMetodos.Location = New System.Drawing.Point(8, 9)
        Me.lblTituloMetodos.Name = "lblTituloMetodos"
        Me.lblTituloMetodos.Size = New System.Drawing.Size(138, 19)
        Me.lblTituloMetodos.TabIndex = 0
        Me.lblTituloMetodos.Text = "MÉTODOS DE PAGO"
        '
        'btnAgregarMetodo
        '
        Me.btnAgregarMetodo.BackColor = System.Drawing.Color.White
        Me.btnAgregarMetodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarMetodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAgregarMetodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarMetodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAgregarMetodo.Location = New System.Drawing.Point(425, 33)
        Me.btnAgregarMetodo.Name = "btnAgregarMetodo"
        Me.btnAgregarMetodo.Size = New System.Drawing.Size(96, 30)
        Me.btnAgregarMetodo.TabIndex = 2
        Me.btnAgregarMetodo.Text = "+ Agregar"
        Me.btnAgregarMetodo.UseVisualStyleBackColor = False
        '
        'cardRecibido
        '
        Me.cardRecibido.BackColor = System.Drawing.Color.White
        Me.cardRecibido.Controls.Add(Me.franjaRecibido)
        Me.cardRecibido.Controls.Add(Me.lblTituloRecibido)
        Me.cardRecibido.Controls.Add(Me.TxtImporteRecibido)
        Me.cardRecibido.Location = New System.Drawing.Point(570, 6)
        Me.cardRecibido.Name = "cardRecibido"
        Me.cardRecibido.Size = New System.Drawing.Size(360, 64)
        Me.cardRecibido.TabIndex = 224
        '
        'franjaRecibido
        '
        Me.franjaRecibido.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.franjaRecibido.Location = New System.Drawing.Point(0, 0)
        Me.franjaRecibido.Name = "franjaRecibido"
        Me.franjaRecibido.Size = New System.Drawing.Size(6, 64)
        Me.franjaRecibido.TabIndex = 0
        '
        'lblTituloRecibido
        '
        Me.lblTituloRecibido.AutoSize = True
        Me.lblTituloRecibido.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblTituloRecibido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.lblTituloRecibido.Location = New System.Drawing.Point(20, 12)
        Me.lblTituloRecibido.Name = "lblTituloRecibido"
        Me.lblTituloRecibido.Size = New System.Drawing.Size(117, 15)
        Me.lblTituloRecibido.TabIndex = 1
        Me.lblTituloRecibido.Text = "IMPORTE RECIBIDO"
        '
        'cardAplicado
        '
        Me.cardAplicado.BackColor = System.Drawing.Color.White
        Me.cardAplicado.Controls.Add(Me.franjaAplicado)
        Me.cardAplicado.Controls.Add(Me.lblTituloAplicado)
        Me.cardAplicado.Controls.Add(Me.TxtImporteAplicado)
        Me.cardAplicado.Location = New System.Drawing.Point(570, 74)
        Me.cardAplicado.Name = "cardAplicado"
        Me.cardAplicado.Size = New System.Drawing.Size(360, 64)
        Me.cardAplicado.TabIndex = 225
        '
        'franjaAplicado
        '
        Me.franjaAplicado.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.franjaAplicado.Location = New System.Drawing.Point(0, 0)
        Me.franjaAplicado.Name = "franjaAplicado"
        Me.franjaAplicado.Size = New System.Drawing.Size(6, 64)
        Me.franjaAplicado.TabIndex = 0
        '
        'lblTituloAplicado
        '
        Me.lblTituloAplicado.AutoSize = True
        Me.lblTituloAplicado.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblTituloAplicado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.lblTituloAplicado.Location = New System.Drawing.Point(20, 12)
        Me.lblTituloAplicado.Name = "lblTituloAplicado"
        Me.lblTituloAplicado.Size = New System.Drawing.Size(120, 15)
        Me.lblTituloAplicado.TabIndex = 1
        Me.lblTituloAplicado.Text = "IMPORTE APLICADO"
        '
        'cardPorAplicar
        '
        Me.cardPorAplicar.BackColor = System.Drawing.Color.White
        Me.cardPorAplicar.Controls.Add(Me.franjaPorAplicar)
        Me.cardPorAplicar.Controls.Add(Me.lblTituloPorAplicar)
        Me.cardPorAplicar.Controls.Add(Me.TxtPorAplicar)
        Me.cardPorAplicar.Location = New System.Drawing.Point(570, 144)
        Me.cardPorAplicar.Name = "cardPorAplicar"
        Me.cardPorAplicar.Size = New System.Drawing.Size(360, 64)
        Me.cardPorAplicar.TabIndex = 226
        '
        'franjaPorAplicar
        '
        Me.franjaPorAplicar.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.franjaPorAplicar.Location = New System.Drawing.Point(0, 0)
        Me.franjaPorAplicar.Name = "franjaPorAplicar"
        Me.franjaPorAplicar.Size = New System.Drawing.Size(6, 64)
        Me.franjaPorAplicar.TabIndex = 0
        '
        'lblTituloPorAplicar
        '
        Me.lblTituloPorAplicar.AutoSize = True
        Me.lblTituloPorAplicar.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblTituloPorAplicar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.lblTituloPorAplicar.Location = New System.Drawing.Point(20, 12)
        Me.lblTituloPorAplicar.Name = "lblTituloPorAplicar"
        Me.lblTituloPorAplicar.Size = New System.Drawing.Size(82, 15)
        Me.lblTituloPorAplicar.TabIndex = 1
        Me.lblTituloPorAplicar.Text = "POR APLICAR"
        '
        'pnlFacturas
        '
        Me.pnlFacturas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFacturas.BackColor = System.Drawing.Color.White
        Me.pnlFacturas.Controls.Add(Me.lblTituloFacturas)
        Me.pnlFacturas.Controls.Add(Me.TrueDBGridComponentes)
        Me.pnlFacturas.Location = New System.Drawing.Point(4, 219)
        Me.pnlFacturas.Name = "pnlFacturas"
        Me.pnlFacturas.Size = New System.Drawing.Size(928, 303)
        Me.pnlFacturas.TabIndex = 227
        '
        'lblTituloFacturas
        '
        Me.lblTituloFacturas.AutoSize = True
        Me.lblTituloFacturas.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloFacturas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblTituloFacturas.Location = New System.Drawing.Point(16, 8)
        Me.lblTituloFacturas.Name = "lblTituloFacturas"
        Me.lblTituloFacturas.Size = New System.Drawing.Size(158, 19)
        Me.lblTituloFacturas.TabIndex = 0
        Me.lblTituloFacturas.Text = "LISTADO DE FACTURAS"
        '
        'pnlInferior
        '
        Me.pnlInferior.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlInferior.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlInferior.Controls.Add(Me.btnProcesar)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.ProgressBar)
        Me.pnlInferior.Location = New System.Drawing.Point(4, 524)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(928, 42)
        Me.pnlInferior.TabIndex = 228
        '
        'btnProcesar
        '
        Me.btnProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcesar.FlatAppearance.BorderSize = 0
        Me.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcesar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnProcesar.ForeColor = System.Drawing.Color.White
        Me.btnProcesar.Location = New System.Drawing.Point(693, 5)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(110, 34)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.btnSalir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnSalir.Location = New System.Drawing.Point(809, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(110, 34)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'FrmRecibosFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(937, 564)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlFacturas)
        Me.Controls.Add(Me.cardPorAplicar)
        Me.Controls.Add(Me.cardAplicado)
        Me.Controls.Add(Me.cardRecibido)
        Me.Controls.Add(Me.pnlMetodosPago)
        Me.Controls.Add(Me.PictureBox1)
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
        Me.pnlMetodosPago.ResumeLayout(False)
        Me.pnlMetodosPago.PerformLayout()
        Me.cardRecibido.ResumeLayout(False)
        Me.cardRecibido.PerformLayout()
        Me.cardAplicado.ResumeLayout(False)
        Me.cardAplicado.PerformLayout()
        Me.cardPorAplicar.ResumeLayout(False)
        Me.cardPorAplicar.PerformLayout()
        Me.pnlFacturas.ResumeLayout(False)
        Me.pnlFacturas.PerformLayout()
        Me.pnlInferior.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtImporteAplicado As System.Windows.Forms.TextBox
    Friend WithEvents TxtPorAplicar As System.Windows.Forms.TextBox
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BindingFacturas As System.Windows.Forms.BindingSource
    Friend WithEvents BindingMetodo As System.Windows.Forms.BindingSource
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents pnlMetodosPago As Panel
    Friend WithEvents btnQuitarMetodo As Button
    Friend WithEvents lblTituloMetodos As Label
    Friend WithEvents btnAgregarMetodo As Button
    Friend WithEvents cardRecibido As Panel
    Friend WithEvents franjaRecibido As Panel
    Friend WithEvents lblTituloRecibido As Label
    Friend WithEvents cardAplicado As Panel
    Friend WithEvents franjaAplicado As Panel
    Friend WithEvents lblTituloAplicado As Label
    Friend WithEvents cardPorAplicar As Panel
    Friend WithEvents franjaPorAplicar As Panel
    Friend WithEvents lblTituloPorAplicar As Label
    Friend WithEvents TxtImporteRecibido As TextBox
    Friend WithEvents pnlFacturas As Panel
    Friend WithEvents lblTituloFacturas As Label
    Friend WithEvents pnlInferior As Panel
    Friend WithEvents btnProcesar As Button
    Friend WithEvents btnSalir As Button
End Class
