<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPlanPagoRecibos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlanPagoRecibos))
        Me.pnlMetodosPago = New System.Windows.Forms.Panel()
        Me.btnQuitarMetodo = New System.Windows.Forms.Button()
        Me.lblTituloMetodos = New System.Windows.Forms.Label()
        Me.btnAgregarMetodo = New System.Windows.Forms.Button()
        Me.TrueDBGridMetodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlFacturas = New System.Windows.Forms.Panel()
        Me.lblTituloFacturas = New System.Windows.Forms.Label()
        Me.TDGridFacturas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlDetallePlan = New System.Windows.Forms.Panel()
        Me.TDGridDetallePlan = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlSepDetalle = New System.Windows.Forms.Panel()
        Me.lblTituloDetalle = New System.Windows.Forms.Label()
        Me.cardPorAplicar = New System.Windows.Forms.Panel()
        Me.franjaPorAplicar = New System.Windows.Forms.Panel()
        Me.lblTituloPorAplicar = New System.Windows.Forms.Label()
        Me.TxtPorAplicar = New System.Windows.Forms.TextBox()
        Me.cardAplicado = New System.Windows.Forms.Panel()
        Me.franjaAplicado = New System.Windows.Forms.Panel()
        Me.lblTituloAplicado = New System.Windows.Forms.Label()
        Me.TxtImporteAplicado = New System.Windows.Forms.TextBox()
        Me.cardRecibido = New System.Windows.Forms.Panel()
        Me.franjaRecibido = New System.Windows.Forms.Panel()
        Me.lblTituloRecibido = New System.Windows.Forms.Label()
        Me.TxtImporteRecibido = New System.Windows.Forms.TextBox()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.pnlMetodosPago.SuspendLayout()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFacturas.SuspendLayout()
        CType(Me.TDGridFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetallePlan.SuspendLayout()
        CType(Me.TDGridDetallePlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardPorAplicar.SuspendLayout()
        Me.cardAplicado.SuspendLayout()
        Me.cardRecibido.SuspendLayout()
        Me.pnlInferior.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMetodosPago
        '
        Me.pnlMetodosPago.BackColor = System.Drawing.Color.White
        Me.pnlMetodosPago.Controls.Add(Me.btnQuitarMetodo)
        Me.pnlMetodosPago.Controls.Add(Me.lblTituloMetodos)
        Me.pnlMetodosPago.Controls.Add(Me.btnAgregarMetodo)
        Me.pnlMetodosPago.Controls.Add(Me.TrueDBGridMetodo)
        Me.pnlMetodosPago.Location = New System.Drawing.Point(599, 4)
        Me.pnlMetodosPago.Name = "pnlMetodosPago"
        Me.pnlMetodosPago.Size = New System.Drawing.Size(558, 210)
        Me.pnlMetodosPago.TabIndex = 224
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
        Me.lblTituloMetodos.Location = New System.Drawing.Point(8, 4)
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
        Me.TrueDBGridMetodo.Size = New System.Drawing.Size(407, 160)
        Me.TrueDBGridMetodo.TabIndex = 206
        Me.TrueDBGridMetodo.Text = "C1TrueDBGrid1"
        Me.TrueDBGridMetodo.PropBag = resources.GetString("TrueDBGridMetodo.PropBag")
        '
        'pnlFacturas
        '
        Me.pnlFacturas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlFacturas.BackColor = System.Drawing.Color.White
        Me.pnlFacturas.Controls.Add(Me.lblTituloFacturas)
        Me.pnlFacturas.Controls.Add(Me.TDGridFacturas)
        Me.pnlFacturas.Location = New System.Drawing.Point(3, 4)
        Me.pnlFacturas.Name = "pnlFacturas"
        Me.pnlFacturas.Size = New System.Drawing.Size(590, 210)
        Me.pnlFacturas.TabIndex = 228
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
        'TDGridFacturas
        '
        Me.TDGridFacturas.AlternatingRows = True
        Me.TDGridFacturas.FilterBar = True
        Me.TDGridFacturas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridFacturas.Images.Add(CType(resources.GetObject("TDGridFacturas.Images"), System.Drawing.Image))
        Me.TDGridFacturas.Location = New System.Drawing.Point(10, 30)
        Me.TDGridFacturas.Name = "TDGridFacturas"
        Me.TDGridFacturas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridFacturas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridFacturas.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridFacturas.PrintInfo.PageSettings = CType(resources.GetObject("TDGridFacturas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridFacturas.Size = New System.Drawing.Size(562, 161)
        Me.TDGridFacturas.TabIndex = 218
        Me.TDGridFacturas.Text = "C1TrueDBGrid1"
        Me.TDGridFacturas.PropBag = resources.GetString("TDGridFacturas.PropBag")
        '
        'pnlDetallePlan
        '
        Me.pnlDetallePlan.BackColor = System.Drawing.Color.White
        Me.pnlDetallePlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetallePlan.Controls.Add(Me.TDGridDetallePlan)
        Me.pnlDetallePlan.Controls.Add(Me.pnlSepDetalle)
        Me.pnlDetallePlan.Controls.Add(Me.lblTituloDetalle)
        Me.pnlDetallePlan.Location = New System.Drawing.Point(5, 220)
        Me.pnlDetallePlan.Name = "pnlDetallePlan"
        Me.pnlDetallePlan.Size = New System.Drawing.Size(787, 215)
        Me.pnlDetallePlan.TabIndex = 229
        '
        'TDGridDetallePlan
        '
        Me.TDGridDetallePlan.AllowUpdate = False
        Me.TDGridDetallePlan.AlternatingRows = True
        Me.TDGridDetallePlan.CaptionHeight = 17
        Me.TDGridDetallePlan.FilterBar = True
        Me.TDGridDetallePlan.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridDetallePlan.Images.Add(CType(resources.GetObject("TDGridDetallePlan.Images"), System.Drawing.Image))
        Me.TDGridDetallePlan.Location = New System.Drawing.Point(10, 33)
        Me.TDGridDetallePlan.Name = "TDGridDetallePlan"
        Me.TDGridDetallePlan.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridDetallePlan.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridDetallePlan.PreviewInfo.ZoomFactor = 75.0R
        Me.TDGridDetallePlan.PrintInfo.PageSettings = CType(resources.GetObject("TDGridDetallePlan.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridDetallePlan.RowHeight = 15
        Me.TDGridDetallePlan.Size = New System.Drawing.Size(768, 168)
        Me.TDGridDetallePlan.TabIndex = 130
        Me.TDGridDetallePlan.Text = "C1TrueDBGrid1"
        Me.TDGridDetallePlan.PropBag = resources.GetString("TDGridDetallePlan.PropBag")
        '
        'pnlSepDetalle
        '
        Me.pnlSepDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.pnlSepDetalle.Location = New System.Drawing.Point(20, 26)
        Me.pnlSepDetalle.Name = "pnlSepDetalle"
        Me.pnlSepDetalle.Size = New System.Drawing.Size(620, 1)
        Me.pnlSepDetalle.TabIndex = 1
        '
        'lblTituloDetalle
        '
        Me.lblTituloDetalle.AutoSize = True
        Me.lblTituloDetalle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.lblTituloDetalle.Location = New System.Drawing.Point(20, 4)
        Me.lblTituloDetalle.Name = "lblTituloDetalle"
        Me.lblTituloDetalle.Size = New System.Drawing.Size(146, 20)
        Me.lblTituloDetalle.TabIndex = 2
        Me.lblTituloDetalle.Text = "DETALLE DEL PLAN"
        '
        'cardPorAplicar
        '
        Me.cardPorAplicar.BackColor = System.Drawing.Color.White
        Me.cardPorAplicar.Controls.Add(Me.franjaPorAplicar)
        Me.cardPorAplicar.Controls.Add(Me.lblTituloPorAplicar)
        Me.cardPorAplicar.Controls.Add(Me.TxtPorAplicar)
        Me.cardPorAplicar.Location = New System.Drawing.Point(798, 363)
        Me.cardPorAplicar.Name = "cardPorAplicar"
        Me.cardPorAplicar.Size = New System.Drawing.Size(360, 64)
        Me.cardPorAplicar.TabIndex = 232
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
        'cardAplicado
        '
        Me.cardAplicado.BackColor = System.Drawing.Color.White
        Me.cardAplicado.Controls.Add(Me.franjaAplicado)
        Me.cardAplicado.Controls.Add(Me.lblTituloAplicado)
        Me.cardAplicado.Controls.Add(Me.TxtImporteAplicado)
        Me.cardAplicado.Location = New System.Drawing.Point(798, 293)
        Me.cardAplicado.Name = "cardAplicado"
        Me.cardAplicado.Size = New System.Drawing.Size(360, 64)
        Me.cardAplicado.TabIndex = 231
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
        'cardRecibido
        '
        Me.cardRecibido.BackColor = System.Drawing.Color.White
        Me.cardRecibido.Controls.Add(Me.franjaRecibido)
        Me.cardRecibido.Controls.Add(Me.lblTituloRecibido)
        Me.cardRecibido.Controls.Add(Me.TxtImporteRecibido)
        Me.cardRecibido.Location = New System.Drawing.Point(798, 225)
        Me.cardRecibido.Name = "cardRecibido"
        Me.cardRecibido.Size = New System.Drawing.Size(360, 64)
        Me.cardRecibido.TabIndex = 230
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
        'pnlInferior
        '
        Me.pnlInferior.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlInferior.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.pnlInferior.Controls.Add(Me.btnProcesar)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.ProgressBar)
        Me.pnlInferior.Location = New System.Drawing.Point(5, 441)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1152, 42)
        Me.pnlInferior.TabIndex = 229
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
        Me.btnProcesar.Location = New System.Drawing.Point(917, 5)
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
        Me.btnSalir.Location = New System.Drawing.Point(1033, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(110, 34)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 7)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(883, 26)
        Me.ProgressBar.TabIndex = 222
        Me.ProgressBar.Visible = False
        '
        'FrmPlanPagoRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1169, 488)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.cardPorAplicar)
        Me.Controls.Add(Me.cardAplicado)
        Me.Controls.Add(Me.cardRecibido)
        Me.Controls.Add(Me.pnlDetallePlan)
        Me.Controls.Add(Me.pnlFacturas)
        Me.Controls.Add(Me.pnlMetodosPago)
        Me.Name = "FrmPlanPagoRecibos"
        Me.Text = "Recibo de plan de pagos"
        Me.pnlMetodosPago.ResumeLayout(False)
        Me.pnlMetodosPago.PerformLayout()
        CType(Me.TrueDBGridMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFacturas.ResumeLayout(False)
        Me.pnlFacturas.PerformLayout()
        CType(Me.TDGridFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetallePlan.ResumeLayout(False)
        Me.pnlDetallePlan.PerformLayout()
        CType(Me.TDGridDetallePlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardPorAplicar.ResumeLayout(False)
        Me.cardPorAplicar.PerformLayout()
        Me.cardAplicado.ResumeLayout(False)
        Me.cardAplicado.PerformLayout()
        Me.cardRecibido.ResumeLayout(False)
        Me.cardRecibido.PerformLayout()
        Me.pnlInferior.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMetodosPago As Panel
    Friend WithEvents btnQuitarMetodo As Button
    Friend WithEvents lblTituloMetodos As Label
    Friend WithEvents btnAgregarMetodo As Button
    Friend WithEvents TrueDBGridMetodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlFacturas As Panel
    Friend WithEvents lblTituloFacturas As Label
    Friend WithEvents TDGridFacturas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlDetallePlan As Panel
    Friend WithEvents TDGridDetallePlan As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlSepDetalle As Panel
    Friend WithEvents lblTituloDetalle As Label
    Friend WithEvents cardPorAplicar As Panel
    Friend WithEvents franjaPorAplicar As Panel
    Friend WithEvents lblTituloPorAplicar As Label
    Friend WithEvents TxtPorAplicar As TextBox
    Friend WithEvents cardAplicado As Panel
    Friend WithEvents franjaAplicado As Panel
    Friend WithEvents lblTituloAplicado As Label
    Friend WithEvents TxtImporteAplicado As TextBox
    Friend WithEvents cardRecibido As Panel
    Friend WithEvents franjaRecibido As Panel
    Friend WithEvents lblTituloRecibido As Label
    Friend WithEvents TxtImporteRecibido As TextBox
    Friend WithEvents pnlInferior As Panel
    Friend WithEvents btnProcesar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents ProgressBar As ProgressBar
End Class
