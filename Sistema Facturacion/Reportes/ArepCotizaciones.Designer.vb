<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepCotizaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepCotizaciones))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblTipoCompra = New DataDynamics.ActiveReports.Label
        Me.LblOrden = New DataDynamics.ActiveReports.Label
        Me.lblOrderNum = New DataDynamics.ActiveReports.Label
        Me.LblDireccionProveedor = New DataDynamics.ActiveReports.Label
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.lblOrderDate = New DataDynamics.ActiveReports.Label
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.LblTelefono = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.LblMoneda = New DataDynamics.ActiveReports.Label
        Me.LblTelefonos = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.LblTotal = New DataDynamics.ActiveReports.Label
        Me.LblSubTotal = New DataDynamics.ActiveReports.Label
        Me.lblFreight = New DataDynamics.ActiveReports.Label
        Me.LblIva = New DataDynamics.ActiveReports.Label
        Me.lblGrandTotal = New DataDynamics.ActiveReports.Label
        Me.lblSubTotals = New DataDynamics.ActiveReports.Label
        Me.LblNotas = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.LblVendedor = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.LblFechaVence = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.LblCorreo = New DataDynamics.ActiveReports.Label
        Me.LblLetras = New DataDynamics.ActiveReports.Label
        Me.LblTelefonoVendedor = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccionProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFreight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaVence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCorreo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefonoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblEncabezado, Me.LblDireccion, Me.LblTipoCompra, Me.LblOrden, Me.lblOrderNum, Me.LblDireccionProveedor, Me.LblNombres, Me.lblOrderDate, Me.LblFechaOrden, Me.Label18, Me.Label22, Me.Label23, Me.Label15, Me.Label21, Me.Shape2, Me.LblTelefono, Me.ImgLogo, Me.Label10, Me.Label11, Me.Label12, Me.Label1, Me.LblRuc, Me.Label3, Me.LblMoneda, Me.LblTelefonos})
        Me.PageHeader1.Height = 2.9375!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.LblEncabezado.Left = 1.4375!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 15.75pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.0!
        Me.LblEncabezado.Width = 6.5625!
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
        Me.LblDireccion.Left = 1.5!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "ddo-char-set: 0; text-align: center; font-style: italic; font-size: 8.25pt; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.375!
        Me.LblDireccion.Width = 6.5!
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
        Me.LblTipoCompra.Height = 0.368421!
        Me.LblTipoCompra.HyperLink = Nothing
        Me.LblTipoCompra.Left = 0.125!
        Me.LblTipoCompra.Name = "LblTipoCompra"
        Me.LblTipoCompra.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 20.25pt; font-family: Arial Black; "
        Me.LblTipoCompra.Text = "P R O F O R M A"
        Me.LblTipoCompra.Top = 1.375!
        Me.LblTipoCompra.Width = 2.947368!
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
        Me.LblOrden.Left = 6.75!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = "ddo-char-set: 0; font-weight: bold; font-size: 12pt; "
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 1.5625!
        Me.LblOrden.Width = 0.8125!
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
        Me.lblOrderNum.Height = 0.2105263!
        Me.lblOrderNum.HyperLink = Nothing
        Me.lblOrderNum.Left = 6.1875!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 12pt; "
        Me.lblOrderNum.Text = "No."
        Me.lblOrderNum.Top = 1.5625!
        Me.lblOrderNum.Width = 0.5789474!
        '
        'LblDireccionProveedor
        '
        Me.LblDireccionProveedor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblDireccionProveedor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Border.RightColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Border.TopColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Height = 0.21!
        Me.LblDireccionProveedor.HyperLink = Nothing
        Me.LblDireccionProveedor.Left = 0.8125!
        Me.LblDireccionProveedor.Name = "LblDireccionProveedor"
        Me.LblDireccionProveedor.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblDireccionProveedor.Text = ""
        Me.LblDireccionProveedor.Top = 2.125!
        Me.LblDireccionProveedor.Width = 5.0!
        '
        'LblNombres
        '
        Me.LblNombres.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNombres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblNombres.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNombres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.RightColor = System.Drawing.Color.Black
        Me.LblNombres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.TopColor = System.Drawing.Color.Black
        Me.LblNombres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Height = 0.21!
        Me.LblNombres.HyperLink = Nothing
        Me.LblNombres.Left = 0.8125!
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblNombres.Text = ""
        Me.LblNombres.Top = 1.875!
        Me.LblNombres.Width = 5.625!
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Border.BottomColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblOrderDate.Border.LeftColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.RightColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.TopColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblOrderDate.Height = 0.2105263!
        Me.lblOrderDate.HyperLink = Nothing
        Me.lblOrderDate.Left = 5.9375!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "text-align: left; font-weight: bold; "
        Me.lblOrderDate.Text = "Fecha"
        Me.lblOrderDate.Top = 2.125!
        Me.lblOrderDate.Width = 0.5263157!
        '
        'LblFechaOrden
        '
        Me.LblFechaOrden.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblFechaOrden.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.RightColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.TopColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblFechaOrden.Height = 0.2105263!
        Me.LblFechaOrden.HyperLink = Nothing
        Me.LblFechaOrden.Left = 6.4375!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = ""
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 2.125!
        Me.LblFechaOrden.Width = 1.526316!
        '
        'Label18
        '
        Me.Label18.Border.BottomColor = System.Drawing.Color.Black
        Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.LeftColor = System.Drawing.Color.Black
        Me.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.RightColor = System.Drawing.Color.Black
        Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.TopColor = System.Drawing.Color.Black
        Me.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Height = 0.2105262!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 7.0625!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label18.Text = "Total"
        Me.Label18.Top = 2.6875!
        Me.Label18.Width = 0.9473686!
        '
        'Label22
        '
        Me.Label22.Border.BottomColor = System.Drawing.Color.Black
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.LeftColor = System.Drawing.Color.Black
        Me.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.RightColor = System.Drawing.Color.Black
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.TopColor = System.Drawing.Color.Black
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Height = 0.21!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 1.1875!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label22.Text = "DESCRIPCION"
        Me.Label22.Top = 2.6875!
        Me.Label22.Width = 4.375!
        '
        'Label23
        '
        Me.Label23.Border.BottomColor = System.Drawing.Color.Black
        Me.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.LeftColor = System.Drawing.Color.Black
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.RightColor = System.Drawing.Color.Black
        Me.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.TopColor = System.Drawing.Color.Black
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Height = 0.2105262!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 5.5625!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label23.Text = "CANT"
        Me.Label23.Top = 2.6875!
        Me.Label23.Width = 0.6315788!
        '
        'Label15
        '
        Me.Label15.Border.BottomColor = System.Drawing.Color.Black
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.LeftColor = System.Drawing.Color.Black
        Me.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.RightColor = System.Drawing.Color.Black
        Me.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.TopColor = System.Drawing.Color.Black
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Height = 0.2105262!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 6.1875!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label15.Text = "Precio Unit"
        Me.Label15.Top = 2.6875!
        Me.Label15.Width = 0.8421051!
        '
        'Label21
        '
        Me.Label21.Border.BottomColor = System.Drawing.Color.Black
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.LeftColor = System.Drawing.Color.Black
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.RightColor = System.Drawing.Color.Black
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.TopColor = System.Drawing.Color.Black
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Height = 0.21!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0.125!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label21.Text = "Codigo"
        Me.Label21.Top = 2.6875!
        Me.Label21.Width = 1.0625!
        '
        'Shape2
        '
        Me.Shape2.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.RightColor = System.Drawing.Color.Black
        Me.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.TopColor = System.Drawing.Color.Black
        Me.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Height = 0.8125!
        Me.Shape2.Left = 0.0625!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape2.Top = 1.8125!
        Me.Shape2.Width = 7.9375!
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
        Me.LblTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTelefono.Height = 0.2105263!
        Me.LblTelefono.HyperLink = Nothing
        Me.LblTelefono.Left = 0.8125!
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblTelefono.Text = ""
        Me.LblTelefono.Top = 2.375!
        Me.LblTelefono.Width = 7.157894!
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
        Me.ImgLogo.Height = 1.0625!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.5!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Height = 0.2105263!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.125!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; "
        Me.Label10.Text = "Cliente:"
        Me.Label10.Top = 1.875!
        Me.Label10.Width = 0.6842105!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.2105263!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.125!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; "
        Me.Label11.Text = "Direccion:"
        Me.Label11.Top = 2.125!
        Me.Label11.Width = 0.6842105!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.2105263!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.125!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: center; "
        Me.Label12.Text = "Telefono:"
        Me.Label12.Top = 2.375!
        Me.Label12.Width = 0.6842105!
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
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Height = 0.125!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 15.75pt; "
        Me.Label1.Text = ""
        Me.Label1.Top = 1.1875!
        Me.Label1.Width = 8.0!
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
        Me.LblRuc.Left = 1.5!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "ddo-char-set: 0; text-align: center; font-style: italic; font-size: 8.25pt; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 0.5625!
        Me.LblRuc.Width = 6.5!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.21!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 6.5!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: left; font-weight: bold; "
        Me.Label3.Text = "Moneda"
        Me.Label3.Top = 1.875!
        Me.Label3.Width = 0.625!
        '
        'LblMoneda
        '
        Me.LblMoneda.Border.BottomColor = System.Drawing.Color.Black
        Me.LblMoneda.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblMoneda.Border.LeftColor = System.Drawing.Color.Black
        Me.LblMoneda.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMoneda.Border.RightColor = System.Drawing.Color.Black
        Me.LblMoneda.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMoneda.Border.TopColor = System.Drawing.Color.Black
        Me.LblMoneda.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMoneda.Height = 0.21!
        Me.LblMoneda.HyperLink = Nothing
        Me.LblMoneda.Left = 7.125!
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Style = ""
        Me.LblMoneda.Text = "Cordobas"
        Me.LblMoneda.Top = 1.875!
        Me.LblMoneda.Width = 0.8125!
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
        Me.LblTelefonos.Left = 1.5!
        Me.LblTelefonos.Name = "LblTelefonos"
        Me.LblTelefonos.Style = "ddo-char-set: 0; text-align: center; font-style: italic; font-size: 8.25pt; "
        Me.LblTelefonos.Text = ""
        Me.LblTelefonos.Top = 0.75!
        Me.LblTelefonos.Width = 6.5!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox7})
        Me.Detail1.Height = 0.2291667!
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
        Me.TextBox1.Left = 0.125!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.0625!
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
        Me.TextBox2.Left = 1.1875!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 4.4375!
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
        Me.TextBox3.Height = 0.2105263!
        Me.TextBox3.Left = 5.631578!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.6315789!
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
        Me.TextBox4.Height = 0.2105263!
        Me.TextBox4.Left = 6.263157!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.8421053!
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
        Me.TextBox7.Height = 0.2105263!
        Me.TextBox7.Left = 7.105263!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.9473686!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblTotal, Me.LblSubTotal, Me.lblFreight, Me.LblIva, Me.lblGrandTotal, Me.lblSubTotals, Me.LblNotas, Me.Label7, Me.Shape1, Me.LblVendedor, Me.Label4, Me.LblFechaVence, Me.Label5, Me.Label6, Me.Label8, Me.Label9, Me.Label2, Me.LblCorreo, Me.LblLetras, Me.LblTelefonoVendedor, Me.Label14})
        Me.ReportFooter1.Height = 3.8125!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'LblTotal
        '
        Me.LblTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTotal.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTotal.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTotal.Height = 0.1875!
        Me.LblTotal.HyperLink = Nothing
        Me.LblTotal.Left = 7.157894!
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotal.Text = ""
        Me.LblTotal.Top = 0.4210526!
        Me.LblTotal.Width = 0.875!
        '
        'LblSubTotal
        '
        Me.LblSubTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblSubTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblSubTotal.Border.RightColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblSubTotal.Border.TopColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblSubTotal.Height = 0.1875!
        Me.LblSubTotal.HyperLink = Nothing
        Me.LblSubTotal.Left = 7.157894!
        Me.LblSubTotal.Name = "LblSubTotal"
        Me.LblSubTotal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblSubTotal.Text = ""
        Me.LblSubTotal.Top = 0.0!
        Me.LblSubTotal.Width = 0.875!
        '
        'lblFreight
        '
        Me.lblFreight.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFreight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFreight.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFreight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFreight.Border.RightColor = System.Drawing.Color.Black
        Me.lblFreight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFreight.Border.TopColor = System.Drawing.Color.Black
        Me.lblFreight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFreight.Height = 0.1875!
        Me.lblFreight.HyperLink = Nothing
        Me.lblFreight.Left = 6.052631!
        Me.lblFreight.Name = "lblFreight"
        Me.lblFreight.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblFreight.Text = "IVA"
        Me.lblFreight.Top = 0.2105263!
        Me.lblFreight.Width = 1.125!
        '
        'LblIva
        '
        Me.LblIva.Border.BottomColor = System.Drawing.Color.Black
        Me.LblIva.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblIva.Border.LeftColor = System.Drawing.Color.Black
        Me.LblIva.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblIva.Border.RightColor = System.Drawing.Color.Black
        Me.LblIva.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblIva.Border.TopColor = System.Drawing.Color.Black
        Me.LblIva.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblIva.Height = 0.1875!
        Me.LblIva.HyperLink = Nothing
        Me.LblIva.Left = 7.157894!
        Me.LblIva.Name = "LblIva"
        Me.LblIva.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblIva.Text = ""
        Me.LblIva.Top = 0.2105263!
        Me.LblIva.Width = 0.875!
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGrandTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGrandTotal.Border.RightColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGrandTotal.Border.TopColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGrandTotal.Height = 0.1875!
        Me.lblGrandTotal.HyperLink = Nothing
        Me.lblGrandTotal.Left = 6.052631!
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblGrandTotal.Text = "Total"
        Me.lblGrandTotal.Top = 0.4210526!
        Me.lblGrandTotal.Width = 1.125!
        '
        'lblSubTotals
        '
        Me.lblSubTotals.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSubTotals.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSubTotals.Border.RightColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSubTotals.Border.TopColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSubTotals.Height = 0.1875!
        Me.lblSubTotals.HyperLink = Nothing
        Me.lblSubTotals.Left = 6.052631!
        Me.lblSubTotals.Name = "lblSubTotals"
        Me.lblSubTotals.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblSubTotals.Text = "Sub Total "
        Me.lblSubTotals.Top = 0.0!
        Me.lblSubTotals.Width = 1.125!
        '
        'LblNotas
        '
        Me.LblNotas.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNotas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNotas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Border.RightColor = System.Drawing.Color.Black
        Me.LblNotas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblNotas.Border.TopColor = System.Drawing.Color.Black
        Me.LblNotas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Height = 1.25!
        Me.LblNotas.HyperLink = Nothing
        Me.LblNotas.Left = 0.1875!
        Me.LblNotas.Name = "LblNotas"
        Me.LblNotas.Style = "ddo-char-set: 0; font-size: 6pt; "
        Me.LblNotas.Text = ""
        Me.LblNotas.Top = 1.0!
        Me.LblNotas.Width = 5.1875!
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
        Me.Label7.Left = 0.125!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label7.Text = "OBSERVACIONES"
        Me.Label7.Top = 0.75!
        Me.Label7.Width = 1.125!
        '
        'Shape1
        '
        Me.Shape1.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.RightColor = System.Drawing.Color.Black
        Me.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.TopColor = System.Drawing.Color.Black
        Me.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Height = 1.375!
        Me.Shape1.Left = 0.125!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape1.Top = 0.9375!
        Me.Shape1.Width = 7.9375!
        '
        'LblVendedor
        '
        Me.LblVendedor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.LblVendedor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblVendedor.Border.RightColor = System.Drawing.Color.Black
        Me.LblVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblVendedor.Border.TopColor = System.Drawing.Color.Black
        Me.LblVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblVendedor.Height = 0.1875!
        Me.LblVendedor.HyperLink = Nothing
        Me.LblVendedor.Left = 5.9375!
        Me.LblVendedor.Name = "LblVendedor"
        Me.LblVendedor.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblVendedor.Text = ""
        Me.LblVendedor.Top = 1.0!
        Me.LblVendedor.Width = 2.0625!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 5.4375!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = ""
        Me.Label4.Text = "Vendedor"
        Me.Label4.Top = 1.0!
        Me.Label4.Width = 0.6875!
        '
        'LblFechaVence
        '
        Me.LblFechaVence.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.LblFechaVence.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Border.RightColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Border.TopColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Height = 0.1875!
        Me.LblFechaVence.HyperLink = Nothing
        Me.LblFechaVence.Left = 5.9375!
        Me.LblFechaVence.Name = "LblFechaVence"
        Me.LblFechaVence.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblFechaVence.Text = ""
        Me.LblFechaVence.Top = 1.4375!
        Me.LblFechaVence.Width = 2.0625!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 5.4375!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = ""
        Me.Label5.Text = "Validez"
        Me.Label5.Top = 1.4375!
        Me.Label5.Width = 0.6875!
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
        Me.Label6.Height = 0.2105264!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.0625!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = ""
        Me.Label6.Text = "Esperando que la presente Proforma sea de su agrado, aprovechamos la Ocasión para" & _
            " saludarle y agradecer su preferencia."
        Me.Label6.Top = 2.375!
        Me.Label6.Width = 7.842105!
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
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.2105264!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 5.125!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; "
        Me.Label8.Text = "Recibí Conforme  ( Cliente )"
        Me.Label8.Top = 3.0625!
        Me.Label8.Width = 2.789474!
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
        Me.Label9.Left = 0.1875!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; "
        Me.Label9.Text = "Elaborada Por:"
        Me.Label9.Top = 3.0625!
        Me.Label9.Width = 2.789474!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 5.4375!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "Correo"
        Me.Label2.Top = 1.1875!
        Me.Label2.Width = 0.6875!
        '
        'LblCorreo
        '
        Me.LblCorreo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCorreo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.LblCorreo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCorreo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCorreo.Border.RightColor = System.Drawing.Color.Black
        Me.LblCorreo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCorreo.Border.TopColor = System.Drawing.Color.Black
        Me.LblCorreo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCorreo.Height = 0.1875!
        Me.LblCorreo.HyperLink = Nothing
        Me.LblCorreo.Left = 5.9375!
        Me.LblCorreo.Name = "LblCorreo"
        Me.LblCorreo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblCorreo.Text = ""
        Me.LblCorreo.Top = 1.1875!
        Me.LblCorreo.Width = 2.0625!
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
        Me.LblLetras.Left = 0.0625!
        Me.LblLetras.Name = "LblLetras"
        Me.LblLetras.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblLetras.Text = ""
        Me.LblLetras.Top = 0.4375!
        Me.LblLetras.Width = 5.875!
        '
        'LblTelefonoVendedor
        '
        Me.LblTelefonoVendedor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTelefonoVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.LblTelefonoVendedor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTelefonoVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonoVendedor.Border.RightColor = System.Drawing.Color.Black
        Me.LblTelefonoVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonoVendedor.Border.TopColor = System.Drawing.Color.Black
        Me.LblTelefonoVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonoVendedor.Height = 0.1875!
        Me.LblTelefonoVendedor.HyperLink = Nothing
        Me.LblTelefonoVendedor.Left = 5.9375!
        Me.LblTelefonoVendedor.Name = "LblTelefonoVendedor"
        Me.LblTelefonoVendedor.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblTelefonoVendedor.Text = ""
        Me.LblTelefonoVendedor.Top = 1.6875!
        Me.LblTelefonoVendedor.Width = 2.0625!
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Height = 0.1875!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 5.4375!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = ""
        Me.Label14.Text = "Telefono:"
        Me.Label14.Top = 1.6875!
        Me.Label14.Width = 0.6875!
        '
        'ArepCotizaciones
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=sa;Persist Security Info=True;User ID=sa;Initial Cat" & _
            "alog=SistemaFacturacionRevetsa;Data Source=JUAN\SQL2012"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.2!
        Me.PageSettings.Margins.Left = 0.1!
        Me.PageSettings.Margins.Right = 0.05!
        Me.PageSettings.Margins.Top = 0.2!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 8.135417!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccionProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFreight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaVence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCorreo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefonoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoCompra As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccionProveedor As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents LblTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSubTotal As DataDynamics.ActiveReports.Label
    Private WithEvents lblFreight As DataDynamics.ActiveReports.Label
    Friend WithEvents LblIva As DataDynamics.ActiveReports.Label
    Private WithEvents lblGrandTotal As DataDynamics.ActiveReports.Label
    Private WithEvents lblSubTotals As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNotas As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents LblVendedor As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaVence As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCorreo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMoneda As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLetras As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefonos As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefonoVendedor As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
End Class
