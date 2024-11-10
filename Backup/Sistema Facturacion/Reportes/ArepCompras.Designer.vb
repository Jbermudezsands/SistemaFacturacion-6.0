<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepCompras
    Inherits DataDynamics.ActiveReports.ActiveReport3

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim SqlDBDataSource1 As DataDynamics.ActiveReports.DataSources.SqlDBDataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepCompras))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblOrderNum = New DataDynamics.ActiveReports.Label
        Me.lblOrderDate = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.LblOrden = New DataDynamics.ActiveReports.Label
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.LblTipoCompra = New DataDynamics.ActiveReports.Label
        Me.LblMoneda = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.lblProductName = New DataDynamics.ActiveReports.Label
        Me.lblQty = New DataDynamics.ActiveReports.Label
        Me.lblUnitPrice = New DataDynamics.ActiveReports.Label
        Me.lblDiscount = New DataDynamics.ActiveReports.Label
        Me.lblTotals = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.TxtMetodo = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.LblCodProveedor = New DataDynamics.ActiveReports.Label
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.LblApellidos = New DataDynamics.ActiveReports.Label
        Me.LblDireccionProveedor = New DataDynamics.ActiveReports.Label
        Me.LblTelefono = New DataDynamics.ActiveReports.Label
        Me.LblBodegas = New DataDynamics.ActiveReports.Label
        Me.LblFechaVence = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lneBillTo = New DataDynamics.ActiveReports.Line
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.LblReferencia = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.lblFreight = New DataDynamics.ActiveReports.Label
        Me.lblSubTotals = New DataDynamics.ActiveReports.Label
        Me.lblGrandTotal = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.LblSubTotal = New DataDynamics.ActiveReports.Label
        Me.LblIva = New DataDynamics.ActiveReports.Label
        Me.LblPagado = New DataDynamics.ActiveReports.Label
        Me.LblTotal = New DataDynamics.ActiveReports.Label
        Me.LblNotas = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.LblLetras = New DataDynamics.ActiveReports.Label
        Me.LblTelefonos = New DataDynamics.ActiveReports.Label
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCodProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccionProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaVence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFreight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPagado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblOrderNum, Me.lblOrderDate, Me.ImgLogo, Me.LblEncabezado, Me.LblDireccion, Me.LblRuc, Me.LblOrden, Me.LblFechaOrden, Me.LblTipoCompra, Me.LblMoneda, Me.Label13, Me.LblTelefonos})
        Me.PageHeader1.Height = 1.3125!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblOrderNum
        '
        Me.lblOrderNum.Border.BottomColor = System.Drawing.Color.Black
        Me.lblOrderNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderNum.Border.LeftColor = System.Drawing.Color.Black
        Me.lblOrderNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderNum.Border.RightColor = System.Drawing.Color.Black
        Me.lblOrderNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderNum.Border.TopColor = System.Drawing.Color.Black
        Me.lblOrderNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderNum.Height = 0.1875!
        Me.lblOrderNum.HyperLink = Nothing
        Me.lblOrderNum.Left = 5.125!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "text-align: right; font-weight: bold; "
        Me.lblOrderNum.Text = "Orden #:"
        Me.lblOrderNum.Top = 0.625!
        Me.lblOrderNum.Width = 1.0!
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Border.BottomColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.LeftColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.RightColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.TopColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Height = 0.1875!
        Me.lblOrderDate.HyperLink = Nothing
        Me.lblOrderDate.Left = 5.125!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "text-align: right; font-weight: bold; "
        Me.lblOrderDate.Text = "Fecha Orden:"
        Me.lblOrderDate.Top = 0.8125!
        Me.lblOrderDate.Width = 1.0!
        '
        'ImgLogo
        '
        Me.ImgLogo.Border.BottomColor = System.Drawing.Color.Black
        Me.ImgLogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgLogo.Border.LeftColor = System.Drawing.Color.Black
        Me.ImgLogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgLogo.Border.RightColor = System.Drawing.Color.Black
        Me.ImgLogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgLogo.Border.TopColor = System.Drawing.Color.Black
        Me.ImgLogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgLogo.Height = 0.875!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.25!
        '
        'LblEncabezado
        '
        Me.LblEncabezado.Border.BottomColor = System.Drawing.Color.Black
        Me.LblEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado.Border.LeftColor = System.Drawing.Color.Black
        Me.LblEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado.Border.RightColor = System.Drawing.Color.Black
        Me.LblEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado.Border.TopColor = System.Drawing.Color.Black
        Me.LblEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado.Height = 0.5!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 1.25!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 15.75pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.0!
        Me.LblEncabezado.Width = 4.0625!
        '
        'LblDireccion
        '
        Me.LblDireccion.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDireccion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDireccion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion.Border.RightColor = System.Drawing.Color.Black
        Me.LblDireccion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion.Border.TopColor = System.Drawing.Color.Black
        Me.LblDireccion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion.Height = 0.1875!
        Me.LblDireccion.HyperLink = Nothing
        Me.LblDireccion.Left = 0.0625!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.875!
        Me.LblDireccion.Width = 5.0!
        '
        'LblRuc
        '
        Me.LblRuc.Border.BottomColor = System.Drawing.Color.Black
        Me.LblRuc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRuc.Border.LeftColor = System.Drawing.Color.Black
        Me.LblRuc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRuc.Border.RightColor = System.Drawing.Color.Black
        Me.LblRuc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRuc.Border.TopColor = System.Drawing.Color.Black
        Me.LblRuc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRuc.Height = 0.1875!
        Me.LblRuc.HyperLink = Nothing
        Me.LblRuc.Left = 0.0!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 1.0625!
        Me.LblRuc.Width = 2.25!
        '
        'LblOrden
        '
        Me.LblOrden.Border.BottomColor = System.Drawing.Color.Black
        Me.LblOrden.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrden.Border.LeftColor = System.Drawing.Color.Black
        Me.LblOrden.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrden.Border.RightColor = System.Drawing.Color.Black
        Me.LblOrden.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrden.Border.TopColor = System.Drawing.Color.Black
        Me.LblOrden.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrden.Height = 0.1875!
        Me.LblOrden.HyperLink = Nothing
        Me.LblOrden.Left = 6.1875!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = ""
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 0.625!
        Me.LblOrden.Width = 0.8125!
        '
        'LblFechaOrden
        '
        Me.LblFechaOrden.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.RightColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.TopColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Height = 0.1875!
        Me.LblFechaOrden.HyperLink = Nothing
        Me.LblFechaOrden.Left = 6.1875!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = ""
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 0.8125!
        Me.LblFechaOrden.Width = 0.8125!
        '
        'LblTipoCompra
        '
        Me.LblTipoCompra.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTipoCompra.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoCompra.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTipoCompra.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoCompra.Border.RightColor = System.Drawing.Color.Black
        Me.LblTipoCompra.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoCompra.Border.TopColor = System.Drawing.Color.Black
        Me.LblTipoCompra.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoCompra.Height = 0.5!
        Me.LblTipoCompra.HyperLink = Nothing
        Me.LblTipoCompra.Left = 5.3125!
        Me.LblTipoCompra.Name = "LblTipoCompra"
        Me.LblTipoCompra.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 14.25pt; "
        Me.LblTipoCompra.Text = "Devolucion de Compra"
        Me.LblTipoCompra.Top = 0.0!
        Me.LblTipoCompra.Width = 1.5625!
        '
        'LblMoneda
        '
        Me.LblMoneda.Border.BottomColor = System.Drawing.Color.Black
        Me.LblMoneda.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMoneda.Border.LeftColor = System.Drawing.Color.Black
        Me.LblMoneda.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMoneda.Border.RightColor = System.Drawing.Color.Black
        Me.LblMoneda.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMoneda.Border.TopColor = System.Drawing.Color.Black
        Me.LblMoneda.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMoneda.Height = 0.21!
        Me.LblMoneda.HyperLink = Nothing
        Me.LblMoneda.Left = 6.1875!
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Style = ""
        Me.LblMoneda.Text = "Cordobas"
        Me.LblMoneda.Top = 1.0!
        Me.LblMoneda.Width = 0.8125!
        '
        'Label13
        '
        Me.Label13.Border.BottomColor = System.Drawing.Color.Black
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.LeftColor = System.Drawing.Color.Black
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.RightColor = System.Drawing.Color.Black
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.TopColor = System.Drawing.Color.Black
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Height = 0.1875!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 5.125!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: right; font-weight: bold; "
        Me.Label13.Text = "Moneda"
        Me.Label13.Top = 1.0!
        Me.Label13.Width = 1.0!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8})
        Me.Detail1.Height = 0.21875!
        Me.Detail1.Name = "Detail1"
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.DataField = "Cod_Productos"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.75!
        '
        'TextBox2
        '
        Me.TextBox2.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.DataField = "Descripcion_Producto"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 0.75!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 2.625!
        '
        'TextBox3
        '
        Me.TextBox3.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox3.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox3.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox3.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox3.DataField = "Cantidad"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 3.8125!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.5!
        '
        'TextBox4
        '
        Me.TextBox4.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox4.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox4.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox4.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox4.DataField = "Precio_Unitario"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 4.3125!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.75!
        '
        'TextBox5
        '
        Me.TextBox5.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.DataField = "Descuento"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 5.0625!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.5625!
        '
        'TextBox6
        '
        Me.TextBox6.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox6.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox6.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox6.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox6.DataField = "Precio_Neto"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 5.625!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.75!
        '
        'TextBox7
        '
        Me.TextBox7.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.DataField = "Importe"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 6.375!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.75!
        '
        'TextBox8
        '
        Me.TextBox8.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.DataField = "Unidad_Medida"
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 3.375!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.4375!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblProductID, Me.lblProductName, Me.lblQty, Me.lblUnitPrice, Me.lblDiscount, Me.lblTotals, Me.Label2, Me.TxtMetodo, Me.Label4, Me.Line1, Me.Label5, Me.Line2, Me.Label6, Me.Line3, Me.LblCodProveedor, Me.LblNombres, Me.LblApellidos, Me.LblDireccionProveedor, Me.LblTelefono, Me.LblBodegas, Me.LblFechaVence, Me.Label1, Me.lneBillTo, Me.Label8, Me.Label12, Me.LblReferencia})
        Me.GroupHeader1.Height = 1.520833!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblProductID
        '
        Me.lblProductID.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Height = 0.1875!
        Me.lblProductID.HyperLink = Nothing
        Me.lblProductID.Left = 0.0!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblProductID.Text = "Codigo"
        Me.lblProductID.Top = 1.3125!
        Me.lblProductID.Width = 0.6875!
        '
        'lblProductName
        '
        Me.lblProductName.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductName.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductName.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductName.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductName.Height = 0.1875!
        Me.lblProductName.HyperLink = Nothing
        Me.lblProductName.Left = 0.6875!
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblProductName.Text = "Nombre Producto"
        Me.lblProductName.Top = 1.3125!
        Me.lblProductName.Width = 2.6875!
        '
        'lblQty
        '
        Me.lblQty.Border.BottomColor = System.Drawing.Color.Black
        Me.lblQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.LeftColor = System.Drawing.Color.Black
        Me.lblQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.RightColor = System.Drawing.Color.Black
        Me.lblQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.TopColor = System.Drawing.Color.Black
        Me.lblQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Height = 0.1875!
        Me.lblQty.HyperLink = Nothing
        Me.lblQty.Left = 3.8125!
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.lblQty.Text = "Qty"
        Me.lblQty.Top = 1.3125!
        Me.lblQty.Width = 0.5!
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Border.BottomColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblUnitPrice.Border.LeftColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblUnitPrice.Border.RightColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblUnitPrice.Border.TopColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblUnitPrice.Height = 0.1875!
        Me.lblUnitPrice.HyperLink = Nothing
        Me.lblUnitPrice.Left = 4.3125!
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblUnitPrice.Text = "Precio Unit"
        Me.lblUnitPrice.Top = 1.3125!
        Me.lblUnitPrice.Width = 0.75!
        '
        'lblDiscount
        '
        Me.lblDiscount.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDiscount.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDiscount.Border.RightColor = System.Drawing.Color.Black
        Me.lblDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDiscount.Border.TopColor = System.Drawing.Color.Black
        Me.lblDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDiscount.Height = 0.1875!
        Me.lblDiscount.HyperLink = Nothing
        Me.lblDiscount.Left = 5.0625!
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.lblDiscount.Text = "%Desc"
        Me.lblDiscount.Top = 1.3125!
        Me.lblDiscount.Width = 0.5!
        '
        'lblTotals
        '
        Me.lblTotals.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTotals.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotals.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTotals.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotals.Border.RightColor = System.Drawing.Color.Black
        Me.lblTotals.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotals.Border.TopColor = System.Drawing.Color.Black
        Me.lblTotals.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotals.Height = 0.1875!
        Me.lblTotals.HyperLink = Nothing
        Me.lblTotals.Left = 6.375!
        Me.lblTotals.Name = "lblTotals"
        Me.lblTotals.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblTotals.Text = "Total"
        Me.lblTotals.Top = 1.3125!
        Me.lblTotals.Width = 0.75!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 5.5625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label2.Text = "Precio Neto"
        Me.Label2.Top = 1.3125!
        Me.Label2.Width = 0.8125!
        '
        'TxtMetodo
        '
        Me.TxtMetodo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMetodo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMetodo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMetodo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMetodo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMetodo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMetodo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMetodo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMetodo.Height = 0.25!
        Me.TxtMetodo.Left = 3.5!
        Me.TxtMetodo.Name = "TxtMetodo"
        Me.TxtMetodo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TxtMetodo.Text = Nothing
        Me.TxtMetodo.Top = 0.25!
        Me.TxtMetodo.Width = 1.4375!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 3.5!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label4.Text = "Metodo de Pago"
        Me.Label4.Top = 0.0!
        Me.Label4.Width = 1.125!
        '
        'Line1
        '
        Me.Line1.Border.BottomColor = System.Drawing.Color.Black
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.LeftColor = System.Drawing.Color.Black
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.RightColor = System.Drawing.Color.Black
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.TopColor = System.Drawing.Color.Black
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 3.5!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.1875!
        Me.Line1.Width = 1.5!
        Me.Line1.X1 = 3.5!
        Me.Line1.X2 = 5.0!
        Me.Line1.Y1 = 0.1875!
        Me.Line1.Y2 = 0.1875!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 5.125!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label5.Text = "Bodegas"
        Me.Label5.Top = 0.0!
        Me.Label5.Width = 1.9375!
        '
        'Line2
        '
        Me.Line2.Border.BottomColor = System.Drawing.Color.Black
        Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.LeftColor = System.Drawing.Color.Black
        Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.RightColor = System.Drawing.Color.Black
        Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.TopColor = System.Drawing.Color.Black
        Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 5.125!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.1875!
        Me.Line2.Width = 1.875!
        Me.Line2.X1 = 5.125!
        Me.Line2.X2 = 7.0!
        Me.Line2.Y1 = 0.1875!
        Me.Line2.Y2 = 0.1875!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 5.125!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label6.Text = "Fecha Vencimiento"
        Me.Label6.Top = 0.5625!
        Me.Label6.Width = 1.875!
        '
        'Line3
        '
        Me.Line3.Border.BottomColor = System.Drawing.Color.Black
        Me.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.LeftColor = System.Drawing.Color.Black
        Me.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.RightColor = System.Drawing.Color.Black
        Me.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.TopColor = System.Drawing.Color.Black
        Me.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 5.125!
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.75!
        Me.Line3.Width = 1.875!
        Me.Line3.X1 = 5.125!
        Me.Line3.X2 = 7.0!
        Me.Line3.Y1 = 0.75!
        Me.Line3.Y2 = 0.75!
        '
        'LblCodProveedor
        '
        Me.LblCodProveedor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCodProveedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodProveedor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCodProveedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodProveedor.Border.RightColor = System.Drawing.Color.Black
        Me.LblCodProveedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodProveedor.Border.TopColor = System.Drawing.Color.Black
        Me.LblCodProveedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodProveedor.Height = 0.1875!
        Me.LblCodProveedor.HyperLink = Nothing
        Me.LblCodProveedor.Left = 0.0!
        Me.LblCodProveedor.MultiLine = False
        Me.LblCodProveedor.Name = "LblCodProveedor"
        Me.LblCodProveedor.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblCodProveedor.Text = ""
        Me.LblCodProveedor.Top = 0.25!
        Me.LblCodProveedor.Width = 3.0!
        '
        'LblNombres
        '
        Me.LblNombres.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNombres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNombres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.RightColor = System.Drawing.Color.Black
        Me.LblNombres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.TopColor = System.Drawing.Color.Black
        Me.LblNombres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Height = 0.1875!
        Me.LblNombres.HyperLink = Nothing
        Me.LblNombres.Left = 0.0!
        Me.LblNombres.MultiLine = False
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblNombres.Text = ""
        Me.LblNombres.Top = 0.4375!
        Me.LblNombres.Width = 3.0!
        '
        'LblApellidos
        '
        Me.LblApellidos.Border.BottomColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.LeftColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.RightColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.TopColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Height = 0.1875!
        Me.LblApellidos.HyperLink = Nothing
        Me.LblApellidos.Left = 0.0!
        Me.LblApellidos.MultiLine = False
        Me.LblApellidos.Name = "LblApellidos"
        Me.LblApellidos.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblApellidos.Text = ""
        Me.LblApellidos.Top = 0.625!
        Me.LblApellidos.Width = 3.0!
        '
        'LblDireccionProveedor
        '
        Me.LblDireccionProveedor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Border.RightColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Border.TopColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Height = 0.1875!
        Me.LblDireccionProveedor.HyperLink = Nothing
        Me.LblDireccionProveedor.Left = 0.0!
        Me.LblDireccionProveedor.MultiLine = False
        Me.LblDireccionProveedor.Name = "LblDireccionProveedor"
        Me.LblDireccionProveedor.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblDireccionProveedor.Text = ""
        Me.LblDireccionProveedor.Top = 0.8125!
        Me.LblDireccionProveedor.Width = 3.0!
        '
        'LblTelefono
        '
        Me.LblTelefono.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTelefono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefono.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTelefono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefono.Border.RightColor = System.Drawing.Color.Black
        Me.LblTelefono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefono.Border.TopColor = System.Drawing.Color.Black
        Me.LblTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefono.Height = 0.1875!
        Me.LblTelefono.HyperLink = Nothing
        Me.LblTelefono.Left = 0.0!
        Me.LblTelefono.MultiLine = False
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblTelefono.Text = ""
        Me.LblTelefono.Top = 1.0!
        Me.LblTelefono.Width = 3.0!
        '
        'LblBodegas
        '
        Me.LblBodegas.Border.BottomColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.LeftColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.RightColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.TopColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Height = 0.1875!
        Me.LblBodegas.HyperLink = Nothing
        Me.LblBodegas.Left = 5.125!
        Me.LblBodegas.Name = "LblBodegas"
        Me.LblBodegas.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblBodegas.Text = ""
        Me.LblBodegas.Top = 0.25!
        Me.LblBodegas.Width = 1.875!
        '
        'LblFechaVence
        '
        Me.LblFechaVence.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Border.RightColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Border.TopColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Height = 0.1875!
        Me.LblFechaVence.HyperLink = Nothing
        Me.LblFechaVence.Left = 5.125!
        Me.LblFechaVence.Name = "LblFechaVence"
        Me.LblFechaVence.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblFechaVence.Text = ""
        Me.LblFechaVence.Top = 0.8125!
        Me.LblFechaVence.Width = 1.875!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.Black
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.LeftColor = System.Drawing.Color.Black
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.RightColor = System.Drawing.Color.Black
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.TopColor = System.Drawing.Color.Black
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Height = 0.1979167!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label1.Text = "Proveedor"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.0!
        '
        'lneBillTo
        '
        Me.lneBillTo.Border.BottomColor = System.Drawing.Color.Black
        Me.lneBillTo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lneBillTo.Border.LeftColor = System.Drawing.Color.Black
        Me.lneBillTo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lneBillTo.Border.RightColor = System.Drawing.Color.Black
        Me.lneBillTo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lneBillTo.Border.TopColor = System.Drawing.Color.Black
        Me.lneBillTo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lneBillTo.Height = 0.0!
        Me.lneBillTo.Left = 0.0!
        Me.lneBillTo.LineWeight = 2.0!
        Me.lneBillTo.Name = "lneBillTo"
        Me.lneBillTo.Top = 0.1875!
        Me.lneBillTo.Width = 3.0!
        Me.lneBillTo.X1 = 0.0!
        Me.lneBillTo.X2 = 3.0!
        Me.lneBillTo.Y1 = 0.1875!
        Me.lneBillTo.Y2 = 0.1875!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 3.375!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label8.Text = "UM"
        Me.Label8.Top = 1.3125!
        Me.Label8.Width = 0.4375!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 3.1875!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label12.Text = "Referencia"
        Me.Label12.Top = 0.5625!
        Me.Label12.Width = 1.875!
        '
        'LblReferencia
        '
        Me.LblReferencia.Border.BottomColor = System.Drawing.Color.Black
        Me.LblReferencia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblReferencia.Border.LeftColor = System.Drawing.Color.Black
        Me.LblReferencia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblReferencia.Border.RightColor = System.Drawing.Color.Black
        Me.LblReferencia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblReferencia.Border.TopColor = System.Drawing.Color.Black
        Me.LblReferencia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblReferencia.Height = 0.1875!
        Me.LblReferencia.HyperLink = Nothing
        Me.LblReferencia.Left = 3.1875!
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblReferencia.Text = ""
        Me.LblReferencia.Top = 0.8125!
        Me.LblReferencia.Width = 1.875!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFreight, Me.lblSubTotals, Me.lblGrandTotal, Me.Label3, Me.LblSubTotal, Me.LblIva, Me.LblPagado, Me.LblTotal, Me.LblNotas, Me.Label7, Me.Label9, Me.Label10, Me.Label11, Me.LblLetras})
        Me.GroupFooter1.Height = 2.447917!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'lblFreight
        '
        Me.lblFreight.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFreight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFreight.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFreight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFreight.Border.RightColor = System.Drawing.Color.Black
        Me.lblFreight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFreight.Border.TopColor = System.Drawing.Color.Black
        Me.lblFreight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFreight.Height = 0.1875!
        Me.lblFreight.HyperLink = Nothing
        Me.lblFreight.Left = 4.947368!
        Me.lblFreight.Name = "lblFreight"
        Me.lblFreight.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblFreight.Text = "Iva"
        Me.lblFreight.Top = 0.2105263!
        Me.lblFreight.Width = 1.125!
        '
        'lblSubTotals
        '
        Me.lblSubTotals.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.RightColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.TopColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Height = 0.1875!
        Me.lblSubTotals.HyperLink = Nothing
        Me.lblSubTotals.Left = 4.947368!
        Me.lblSubTotals.Name = "lblSubTotals"
        Me.lblSubTotals.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblSubTotals.Text = "Sub Total "
        Me.lblSubTotals.Top = 0.0!
        Me.lblSubTotals.Width = 1.125!
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrandTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrandTotal.Border.RightColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrandTotal.Border.TopColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrandTotal.Height = 0.1875!
        Me.lblGrandTotal.HyperLink = Nothing
        Me.lblGrandTotal.Left = 4.947368!
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblGrandTotal.Text = "Total"
        Me.lblGrandTotal.Top = 0.5789474!
        Me.lblGrandTotal.Width = 1.125!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 4.947368!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label3.Text = "Pagado"
        Me.Label3.Top = 0.368421!
        Me.Label3.Width = 1.125!
        '
        'LblSubTotal
        '
        Me.LblSubTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal.Border.RightColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal.Border.TopColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal.Height = 0.1875!
        Me.LblSubTotal.HyperLink = Nothing
        Me.LblSubTotal.Left = 6.25!
        Me.LblSubTotal.Name = "LblSubTotal"
        Me.LblSubTotal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.LblSubTotal.Text = ""
        Me.LblSubTotal.Top = 0.0!
        Me.LblSubTotal.Width = 0.875!
        '
        'LblIva
        '
        Me.LblIva.Border.BottomColor = System.Drawing.Color.Black
        Me.LblIva.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIva.Border.LeftColor = System.Drawing.Color.Black
        Me.LblIva.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIva.Border.RightColor = System.Drawing.Color.Black
        Me.LblIva.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIva.Border.TopColor = System.Drawing.Color.Black
        Me.LblIva.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIva.Height = 0.1875!
        Me.LblIva.HyperLink = Nothing
        Me.LblIva.Left = 6.25!
        Me.LblIva.Name = "LblIva"
        Me.LblIva.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.LblIva.Text = ""
        Me.LblIva.Top = 0.1875!
        Me.LblIva.Width = 0.875!
        '
        'LblPagado
        '
        Me.LblPagado.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPagado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagado.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPagado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagado.Border.RightColor = System.Drawing.Color.Black
        Me.LblPagado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagado.Border.TopColor = System.Drawing.Color.Black
        Me.LblPagado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagado.Height = 0.1875!
        Me.LblPagado.HyperLink = Nothing
        Me.LblPagado.Left = 6.25!
        Me.LblPagado.Name = "LblPagado"
        Me.LblPagado.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.LblPagado.Text = ""
        Me.LblPagado.Top = 0.375!
        Me.LblPagado.Width = 0.875!
        '
        'LblTotal
        '
        Me.LblTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Height = 0.19!
        Me.LblTotal.HyperLink = Nothing
        Me.LblTotal.Left = 6.25!
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.LblTotal.Text = ""
        Me.LblTotal.Top = 0.5625!
        Me.LblTotal.Width = 0.875!
        '
        'LblNotas
        '
        Me.LblNotas.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNotas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNotas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Border.RightColor = System.Drawing.Color.Black
        Me.LblNotas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Border.TopColor = System.Drawing.Color.Black
        Me.LblNotas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Height = 0.6875!
        Me.LblNotas.HyperLink = Nothing
        Me.LblNotas.Left = 1.625!
        Me.LblNotas.Name = "LblNotas"
        Me.LblNotas.Style = ""
        Me.LblNotas.Text = ""
        Me.LblNotas.Top = 0.0625!
        Me.LblNotas.Width = 3.125!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Height = 0.2105263!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.1052632!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label7.Text = "Observaciones"
        Me.Label7.Top = 0.1052632!
        Me.Label7.Width = 1.526316!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.2105263!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.375!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; "
        Me.Label9.Text = "Autorizado Por:"
        Me.Label9.Top = 2.125!
        Me.Label9.Width = 1.210526!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.2105263!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 3.0!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; "
        Me.Label10.Text = "Recibido Por"
        Me.Label10.Top = 2.125!
        Me.Label10.Visible = False
        Me.Label10.Width = 1.210526!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.2105263!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 5.4375!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; "
        Me.Label11.Text = "Entregado Por"
        Me.Label11.Top = 2.125!
        Me.Label11.Visible = False
        Me.Label11.Width = 1.210526!
        '
        'LblLetras
        '
        Me.LblLetras.Border.BottomColor = System.Drawing.Color.Black
        Me.LblLetras.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLetras.Border.LeftColor = System.Drawing.Color.Black
        Me.LblLetras.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLetras.Border.RightColor = System.Drawing.Color.Black
        Me.LblLetras.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLetras.Border.TopColor = System.Drawing.Color.Black
        Me.LblLetras.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLetras.Height = 0.1875!
        Me.LblLetras.HyperLink = Nothing
        Me.LblLetras.Left = 0.1875!
        Me.LblLetras.Name = "LblLetras"
        Me.LblLetras.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblLetras.Text = ""
        Me.LblLetras.Top = 0.875!
        Me.LblLetras.Width = 5.875!
        '
        'LblTelefonos
        '
        Me.LblTelefonos.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTelefonos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonos.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTelefonos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonos.Border.RightColor = System.Drawing.Color.Black
        Me.LblTelefonos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonos.Border.TopColor = System.Drawing.Color.Black
        Me.LblTelefonos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonos.Height = 0.1875!
        Me.LblTelefonos.HyperLink = Nothing
        Me.LblTelefonos.Left = 2.25!
        Me.LblTelefonos.Name = "LblTelefonos"
        Me.LblTelefonos.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblTelefonos.Text = ""
        Me.LblTelefonos.Top = 1.0625!
        Me.LblTelefonos.Width = 2.8125!
        '
        'ArepCompras
        '
        Me.MasterReport = False
        SqlDBDataSource1.ConnectionString = "data source=JUAN\SQL2005;initial catalog=SistemaFacturacion;integrated security=S" & _
            "SPI;persist security info=False"
        SqlDBDataSource1.SQL = resources.GetString("SqlDBDataSource1.SQL")
        Me.DataSource = SqlDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.4!
        Me.PageSettings.Margins.Left = 0.7!
        Me.PageSettings.Margins.Right = 0.2!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.177083!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCodProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccionProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaVence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFreight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPagado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents lneBillTo As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductName As DataDynamics.ActiveReports.Label
    Private WithEvents lblQty As DataDynamics.ActiveReports.Label
    Private WithEvents lblUnitPrice As DataDynamics.ActiveReports.Label
    Private WithEvents lblDiscount As DataDynamics.ActiveReports.Label
    Private WithEvents lblTotals As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents lblFreight As DataDynamics.ActiveReports.Label
    Private WithEvents lblSubTotals As DataDynamics.ActiveReports.Label
    Private WithEvents lblGrandTotal As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtMetodo As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCodProveedor As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents LblApellidos As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccionProveedor As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents LblBodegas As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaVence As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSubTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents LblIva As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPagado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoCompra As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblNotas As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblReferencia As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLetras As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMoneda As DataDynamics.ActiveReports.Label
    Private WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefonos As DataDynamics.ActiveReports.Label
End Class
