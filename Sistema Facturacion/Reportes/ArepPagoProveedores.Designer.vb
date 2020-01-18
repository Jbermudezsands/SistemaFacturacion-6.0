<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepPagoProveedores 
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
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepPagoProveedores))
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
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lneBillTo = New DataDynamics.ActiveReports.Line
        Me.LblCodProveedor = New DataDynamics.ActiveReports.Label
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.LblApellidos = New DataDynamics.ActiveReports.Label
        Me.LblDireccionProveedor = New DataDynamics.ActiveReports.Label
        Me.LblTelefono = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.TxtMetodo = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.ChkRetencion3 = New DataDynamics.ActiveReports.CheckBox
        Me.ChkRetencion4 = New DataDynamics.ActiveReports.CheckBox
        Me.ChkRetencion1 = New DataDynamics.ActiveReports.CheckBox
        Me.ChkRetencion2 = New DataDynamics.ActiveReports.CheckBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.lblFreight = New DataDynamics.ActiveReports.Label
        Me.lblSubTotals = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.LblSubTotal = New DataDynamics.ActiveReports.Label
        Me.LblDescuento = New DataDynamics.ActiveReports.Label
        Me.LblPagado = New DataDynamics.ActiveReports.Label
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCodProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccionProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkRetencion3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkRetencion4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkRetencion1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkRetencion2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFreight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPagado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblOrderNum, Me.lblOrderDate, Me.ImgLogo, Me.LblEncabezado, Me.LblDireccion, Me.LblRuc, Me.LblOrden, Me.LblFechaOrden, Me.LblTipoCompra})
        Me.PageHeader1.Height = 1.177083!
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
        Me.lblOrderNum.Left = 4.5!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "text-align: right; font-weight: bold; "
        Me.lblOrderNum.Text = "Solicitud Pago #:"
        Me.lblOrderNum.Top = 0.625!
        Me.lblOrderNum.Width = 1.25!
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
        Me.lblOrderDate.Left = 4.5!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "text-align: right; font-weight: bold; "
        Me.lblOrderDate.Text = "Fecha Solicitud:"
        Me.lblOrderDate.Top = 0.8125!
        Me.lblOrderDate.Width = 1.25!
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
        Me.ImgLogo.Height = 0.75!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 0.9375!
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
        Me.LblEncabezado.Height = 0.375!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 0.9375!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 12pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.0!
        Me.LblEncabezado.Width = 3.8125!
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
        Me.LblDireccion.Left = 0.0!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.75!
        Me.LblDireccion.Width = 4.0!
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
        Me.LblRuc.Top = 0.9375!
        Me.LblRuc.Width = 2.0!
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
        Me.LblOrden.Left = 5.8125!
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
        Me.LblFechaOrden.Left = 5.8125!
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
        Me.LblTipoCompra.Left = 5.0625!
        Me.LblTipoCompra.Name = "LblTipoCompra"
        Me.LblTipoCompra.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: #C0C0FF; font-size: 14.25pt; "
        Me.LblTipoCompra.Text = "Solicitud de Pagos"
        Me.LblTipoCompra.Top = 0.0!
        Me.LblTipoCompra.Width = 1.5625!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5})
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
        Me.TextBox1.DataField = "Numero_Compra"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0625!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.3125!
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
        Me.TextBox2.DataField = "Fecha_Compra"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 1.375!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = "TextBox2"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 1.3125!
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
        Me.TextBox3.DataField = "MontoCredito"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 2.6875!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox3.Text = "TextBox3"
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 1.25!
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
        Me.TextBox4.DataField = "MontoPagado"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 3.9375!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox4.Text = "TextBox4"
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 1.3125!
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
        Me.TextBox5.DataField = "Saldo"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 5.25!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox5.Text = "TextBox5"
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 1.375!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lneBillTo, Me.LblCodProveedor, Me.LblNombres, Me.LblApellidos, Me.LblDireccionProveedor, Me.LblTelefono, Me.Label1, Me.TxtMetodo, Me.Label4, Me.Line1, Me.Label2, Me.Label3, Me.Label5, Me.Label6, Me.Label7, Me.ChkRetencion3, Me.ChkRetencion4, Me.ChkRetencion1, Me.ChkRetencion2})
        Me.GroupHeader1.Height = 1.635417!
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblTelefono.Text = ""
        Me.LblTelefono.Top = 1.0!
        Me.LblTelefono.Width = 3.0!
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
        Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
            "8.25pt; "
        Me.Label1.Text = "Proveedor"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.0!
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
        Me.TxtMetodo.Height = 0.5!
        Me.TxtMetodo.Left = 3.4375!
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
        Me.Label4.Left = 3.4375!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Black; text-align: center; font-weight: bold; font-size: 8.5pt; "
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
        Me.Line1.Left = 3.4375!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.1875!
        Me.Line1.Width = 1.5!
        Me.Line1.X1 = 3.4375!
        Me.Line1.X2 = 4.9375!
        Me.Line1.Y1 = 0.1875!
        Me.Line1.Y2 = 0.1875!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; background-color: #8080FF; font-size: 8.25pt; "
        Me.Label2.Text = "Numero Compra"
        Me.Label2.Top = 1.4375!
        Me.Label2.Width = 1.3125!
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
        Me.Label3.Left = 1.375!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; background-color: #8080FF; font-size: 8.25pt; "
        Me.Label3.Text = "Fecha Compra"
        Me.Label3.Top = 1.4375!
        Me.Label3.Width = 1.3125!
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
        Me.Label5.Left = 2.6875!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: right; background-color: #8080FF; font-size: 8.25pt;" & _
            " "
        Me.Label5.Text = "Monto Credito"
        Me.Label5.Top = 1.4375!
        Me.Label5.Width = 1.25!
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
        Me.Label6.Left = 3.9375!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: right; background-color: #8080FF; font-size: 8.25pt;" & _
            " "
        Me.Label6.Text = "Monto Pago"
        Me.Label6.Top = 1.4375!
        Me.Label6.Width = 1.3125!
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
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 5.25!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: right; background-color: #8080FF; font-size: 8.25pt;" & _
            " "
        Me.Label7.Text = "Saldo"
        Me.Label7.Top = 1.4375!
        Me.Label7.Width = 1.375!
        '
        'ChkRetencion3
        '
        Me.ChkRetencion3.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkRetencion3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion3.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkRetencion3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion3.Border.RightColor = System.Drawing.Color.Black
        Me.ChkRetencion3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion3.Border.TopColor = System.Drawing.Color.Black
        Me.ChkRetencion3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion3.Height = 0.1979167!
        Me.ChkRetencion3.Left = 3.395833!
        Me.ChkRetencion3.Name = "ChkRetencion3"
        Me.ChkRetencion3.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ChkRetencion3.Text = "Retencion 7%"
        Me.ChkRetencion3.Top = 0.8541667!
        Me.ChkRetencion3.Width = 1.0!
        '
        'ChkRetencion4
        '
        Me.ChkRetencion4.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkRetencion4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion4.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkRetencion4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion4.Border.RightColor = System.Drawing.Color.Black
        Me.ChkRetencion4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion4.Border.TopColor = System.Drawing.Color.Black
        Me.ChkRetencion4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion4.Height = 0.1979167!
        Me.ChkRetencion4.Left = 4.625!
        Me.ChkRetencion4.Name = "ChkRetencion4"
        Me.ChkRetencion4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ChkRetencion4.Text = "Retencion 10%"
        Me.ChkRetencion4.Top = 0.8500001!
        Me.ChkRetencion4.Width = 1.0!
        '
        'ChkRetencion1
        '
        Me.ChkRetencion1.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkRetencion1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion1.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkRetencion1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion1.Border.RightColor = System.Drawing.Color.Black
        Me.ChkRetencion1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion1.Border.TopColor = System.Drawing.Color.Black
        Me.ChkRetencion1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion1.Height = 0.1979167!
        Me.ChkRetencion1.Left = 3.375!
        Me.ChkRetencion1.Name = "ChkRetencion1"
        Me.ChkRetencion1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ChkRetencion1.Text = "Retencion 1%"
        Me.ChkRetencion1.Top = 1.125!
        Me.ChkRetencion1.Width = 1.0!
        '
        'ChkRetencion2
        '
        Me.ChkRetencion2.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkRetencion2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion2.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkRetencion2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion2.Border.RightColor = System.Drawing.Color.Black
        Me.ChkRetencion2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion2.Border.TopColor = System.Drawing.Color.Black
        Me.ChkRetencion2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRetencion2.Height = 0.1979167!
        Me.ChkRetencion2.Left = 4.625!
        Me.ChkRetencion2.Name = "ChkRetencion2"
        Me.ChkRetencion2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ChkRetencion2.Text = "Retencion 2%"
        Me.ChkRetencion2.Top = 1.125!
        Me.ChkRetencion2.Width = 1.0!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFreight, Me.lblSubTotals, Me.Label8, Me.LblSubTotal, Me.LblDescuento, Me.LblPagado})
        Me.GroupFooter1.Height = 0.5625!
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
        Me.lblFreight.Left = 4.625!
        Me.lblFreight.Name = "lblFreight"
        Me.lblFreight.Style = "color: Black; text-align: right; font-weight: bold; font-size: 8.5pt; "
        Me.lblFreight.Text = "Retencion"
        Me.lblFreight.Top = 0.1875!
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
        Me.lblSubTotals.Left = 4.625!
        Me.lblSubTotals.Name = "lblSubTotals"
        Me.lblSubTotals.Style = "color: Black; text-align: right; font-weight: bold; font-size: 8.5pt; "
        Me.lblSubTotals.Text = "Sub Total "
        Me.lblSubTotals.Top = 0.0!
        Me.lblSubTotals.Width = 1.125!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 4.625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: Black; text-align: right; font-weight: bold; font-size: 8.5pt; "
        Me.Label8.Text = "Total a Pagar"
        Me.Label8.Top = 0.375!
        Me.Label8.Width = 1.125!
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
        Me.LblSubTotal.Left = 5.75!
        Me.LblSubTotal.Name = "LblSubTotal"
        Me.LblSubTotal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblSubTotal.Text = ""
        Me.LblSubTotal.Top = 0.0!
        Me.LblSubTotal.Width = 0.875!
        '
        'LblDescuento
        '
        Me.LblDescuento.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDescuento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDescuento.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDescuento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDescuento.Border.RightColor = System.Drawing.Color.Black
        Me.LblDescuento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDescuento.Border.TopColor = System.Drawing.Color.Black
        Me.LblDescuento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDescuento.Height = 0.1875!
        Me.LblDescuento.HyperLink = Nothing
        Me.LblDescuento.Left = 5.75!
        Me.LblDescuento.Name = "LblDescuento"
        Me.LblDescuento.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblDescuento.Text = ""
        Me.LblDescuento.Top = 0.1875!
        Me.LblDescuento.Width = 0.875!
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
        Me.LblPagado.Left = 5.75!
        Me.LblPagado.Name = "LblPagado"
        Me.LblPagado.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblPagado.Text = ""
        Me.LblPagado.Top = 0.375!
        Me.LblPagado.Width = 0.875!
        '
        'ArepPagoProveedores
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaFacturacion;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.697917!
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
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCodProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccionProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkRetencion3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkRetencion4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkRetencion1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkRetencion2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFreight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPagado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoCompra As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents lneBillTo As DataDynamics.ActiveReports.Line
    Friend WithEvents LblCodProveedor As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents LblApellidos As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccionProveedor As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtMetodo As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Private WithEvents lblFreight As DataDynamics.ActiveReports.Label
    Private WithEvents lblSubTotals As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSubTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDescuento As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPagado As DataDynamics.ActiveReports.Label
    Friend WithEvents ChkRetencion3 As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents ChkRetencion4 As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents ChkRetencion1 As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents ChkRetencion2 As DataDynamics.ActiveReports.CheckBox
End Class 
