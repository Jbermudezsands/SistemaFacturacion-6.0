<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepControlProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepControlProductos))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.SrpCompras = New DataDynamics.ActiveReports.SubReport
        Me.SrpFacturas = New DataDynamics.ActiveReports.SubReport
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.TxtCodProducto = New DataDynamics.ActiveReports.TextBox
        Me.TxtCodProductos = New DataDynamics.ActiveReports.TextBox
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.TxtSaldoInicial = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.LblTotalCantidad1 = New DataDynamics.ActiveReports.Label
        Me.LblTotalImporte1l = New DataDynamics.ActiveReports.Label
        Me.LblTotalCantidad2 = New DataDynamics.ActiveReports.Label
        Me.LblTotalImporte2 = New DataDynamics.ActiveReports.Label
        Me.LblTotalCantidad3 = New DataDynamics.ActiveReports.Label
        Me.LblTotalImporte3 = New DataDynamics.ActiveReports.Label
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSaldoInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalCantidad1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalImporte1l, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalCantidad2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalImporte2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalCantidad3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalImporte3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1, Me.Line1, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label2, Me.Label17, Me.ImgLogo, Me.Label10, Me.Label15, Me.Label9, Me.Label13, Me.Label8, Me.Label11, Me.Label12, Me.Line2, Me.Label16})
        Me.PageHeader1.Height = 1.854167!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'LblTitulo
        '
        Me.LblTitulo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTitulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTitulo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTitulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTitulo.Border.RightColor = System.Drawing.Color.Black
        Me.LblTitulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTitulo.Border.TopColor = System.Drawing.Color.Black
        Me.LblTitulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTitulo.Height = 0.25!
        Me.LblTitulo.HyperLink = Nothing
        Me.LblTitulo.Left = 0.25!
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.LblTitulo.Text = "SYSTEMS AND SOLUTIONS"
        Me.LblTitulo.Top = 0.0625!
        Me.LblTitulo.Width = 8.0!
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
        Me.LblDireccion.Left = 0.25!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "text-align: center; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.3125!
        Me.LblDireccion.Width = 8.0!
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
        Me.LblRuc.Left = 0.25!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "text-align: center; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 0.5!
        Me.LblRuc.Width = 8.0!
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
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 6.5625!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = ""
        Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 1.0!
        Me.TextBox1.Width = 0.4375!
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
        Me.Label3.Left = 6.25!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "Pag."
        Me.Label3.Top = 1.0!
        Me.Label3.Width = 0.3125!
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
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.25!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.Label1.Text = "Control de Entrada y Salida de Productos"
        Me.Label1.Top = 0.6875!
        Me.Label1.Width = 8.0!
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
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.3125!
        Me.Line1.Width = 8.25!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 8.3125!
        Me.Line1.Y1 = 1.3125!
        Me.Line1.Y2 = 1.3125!
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
        Me.Label4.Left = 0.125!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label4.Text = "Tipo"
        Me.Label4.Top = 1.5625!
        Me.Label4.Width = 1.25!
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
        Me.Label5.Left = 1.375!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label5.Text = "Descripcion"
        Me.Label5.Top = 1.375!
        Me.Label5.Width = 2.3125!
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
        Me.Label6.Left = 2.0625!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label6.Text = "Fecha"
        Me.Label6.Top = 1.5625!
        Me.Label6.Width = 0.8125!
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
        Me.Label7.Left = 2.875!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label7.Text = "Numero"
        Me.Label7.Top = 1.5625!
        Me.Label7.Width = 0.8125!
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
        Me.Label2.Left = 0.125!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label2.Text = "Cod Producto"
        Me.Label2.Top = 1.375!
        Me.Label2.Width = 1.25!
        '
        'Label17
        '
        Me.Label17.Border.BottomColor = System.Drawing.Color.Black
        Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Border.LeftColor = System.Drawing.Color.Black
        Me.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Border.RightColor = System.Drawing.Color.Black
        Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Border.TopColor = System.Drawing.Color.Black
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Height = 0.1875!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 1.375!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label17.Text = "Bodega"
        Me.Label17.Top = 1.5625!
        Me.Label17.Width = 0.6875!
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
        Me.ImgLogo.Left = 0.125!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0625!
        Me.ImgLogo.Width = 1.6875!
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
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Height = 0.2105263!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 5.9375!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label10.Text = "SALDO"
        Me.Label10.Top = 1.375!
        Me.Label10.Width = 0.7894735!
        '
        'Label15
        '
        Me.Label15.Border.BottomColor = System.Drawing.Color.Black
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.LeftColor = System.Drawing.Color.Black
        Me.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.RightColor = System.Drawing.Color.Black
        Me.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.TopColor = System.Drawing.Color.Black
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Height = 0.19!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 5.9375!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label15.Text = "Cantidad"
        Me.Label15.Top = 1.5625!
        Me.Label15.Width = 0.7894735!
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
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Height = 0.2105263!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 5.25!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label9.Text = "SALIDAS"
        Me.Label9.Top = 1.375!
        Me.Label9.Width = 0.6842104!
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
        Me.Label13.Left = 5.25!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label13.Text = "Cantidad"
        Me.Label13.Top = 1.5625!
        Me.Label13.Width = 0.6875!
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
        Me.Label8.Height = 0.2105263!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 4.5625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Label8.Text = "ENTRADAS"
        Me.Label8.Top = 1.375!
        Me.Label8.Width = 0.6842106!
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
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Height = 0.19!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 4.5625!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label11.Text = "Cantidad"
        Me.Label11.Top = 1.5625!
        Me.Label11.Width = 0.69!
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
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Height = 0.375!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 6.75!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label12.Text = "OBSERVACIONES"
        Me.Label12.Top = 1.375!
        Me.Label12.Width = 1.5!
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
        Me.Line2.Left = 0.0625!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.8125!
        Me.Line2.Width = 8.25!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 8.3125!
        Me.Line2.Y1 = 1.8125!
        Me.Line2.Y2 = 1.8125!
        '
        'Label16
        '
        Me.Label16.Border.BottomColor = System.Drawing.Color.Black
        Me.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.LeftColor = System.Drawing.Color.Black
        Me.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.RightColor = System.Drawing.Color.Black
        Me.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.TopColor = System.Drawing.Color.Black
        Me.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 3.6875!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label16.Text = "Prov/Cliente"
        Me.Label16.Top = 1.5625!
        Me.Label16.Width = 0.875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SrpCompras, Me.SrpFacturas})
        Me.Detail1.Height = 0.4791667!
        Me.Detail1.Name = "Detail1"
        '
        'SrpCompras
        '
        Me.SrpCompras.Border.BottomColor = System.Drawing.Color.Black
        Me.SrpCompras.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SrpCompras.Border.LeftColor = System.Drawing.Color.Black
        Me.SrpCompras.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SrpCompras.Border.RightColor = System.Drawing.Color.Black
        Me.SrpCompras.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SrpCompras.Border.TopColor = System.Drawing.Color.Black
        Me.SrpCompras.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SrpCompras.CloseBorder = False
        Me.SrpCompras.Height = 0.1875!
        Me.SrpCompras.Left = 0.0625!
        Me.SrpCompras.Name = "SrpCompras"
        Me.SrpCompras.Report = Nothing
        Me.SrpCompras.ReportName = "SrpCompras"
        Me.SrpCompras.Top = 0.0!
        Me.SrpCompras.Width = 8.25!
        '
        'SrpFacturas
        '
        Me.SrpFacturas.Border.BottomColor = System.Drawing.Color.Black
        Me.SrpFacturas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SrpFacturas.Border.LeftColor = System.Drawing.Color.Black
        Me.SrpFacturas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SrpFacturas.Border.RightColor = System.Drawing.Color.Black
        Me.SrpFacturas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SrpFacturas.Border.TopColor = System.Drawing.Color.Black
        Me.SrpFacturas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SrpFacturas.CloseBorder = False
        Me.SrpFacturas.Height = 0.25!
        Me.SrpFacturas.Left = 0.0625!
        Me.SrpFacturas.Name = "SrpFacturas"
        Me.SrpFacturas.Report = Nothing
        Me.SrpFacturas.ReportName = "SrpFacturas"
        Me.SrpFacturas.Top = 0.1875!
        Me.SrpFacturas.Width = 8.25!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtCodProducto, Me.TxtCodProductos, Me.Label14, Me.TxtSaldoInicial})
        Me.GroupHeader1.DataField = "Cod_Productos"
        Me.GroupHeader1.Height = 0.4270833!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'TxtCodProducto
        '
        Me.TxtCodProducto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCodProducto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodProducto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCodProducto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodProducto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCodProducto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodProducto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCodProducto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodProducto.DataField = "Cod_Productos"
        Me.TxtCodProducto.Height = 0.1875!
        Me.TxtCodProducto.Left = 0.0625!
        Me.TxtCodProducto.Name = "TxtCodProducto"
        Me.TxtCodProducto.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.TxtCodProducto.Text = Nothing
        Me.TxtCodProducto.Top = 0.0!
        Me.TxtCodProducto.Width = 1.125!
        '
        'TxtCodProductos
        '
        Me.TxtCodProductos.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCodProductos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodProductos.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCodProductos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodProductos.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCodProductos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodProductos.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCodProductos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodProductos.DataField = "Descripcion_Producto"
        Me.TxtCodProductos.Height = 0.1875!
        Me.TxtCodProductos.Left = 1.1875!
        Me.TxtCodProductos.Name = "TxtCodProductos"
        Me.TxtCodProductos.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.TxtCodProductos.Text = Nothing
        Me.TxtCodProductos.Top = 0.0!
        Me.TxtCodProductos.Width = 4.9375!
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Height = 0.2105263!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 2.684211!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label14.Text = "Saldo Inicial"
        Me.Label14.Top = 0.2105263!
        Me.Label14.Width = 0.9999999!
        '
        'TxtSaldoInicial
        '
        Me.TxtSaldoInicial.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtSaldoInicial.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldoInicial.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtSaldoInicial.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldoInicial.Border.RightColor = System.Drawing.Color.Black
        Me.TxtSaldoInicial.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldoInicial.Border.TopColor = System.Drawing.Color.Black
        Me.TxtSaldoInicial.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldoInicial.Height = 0.2105263!
        Me.TxtSaldoInicial.Left = 3.684211!
        Me.TxtSaldoInicial.Name = "TxtSaldoInicial"
        Me.TxtSaldoInicial.OutputFormat = resources.GetString("TxtSaldoInicial.OutputFormat")
        Me.TxtSaldoInicial.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtSaldoInicial.Text = Nothing
        Me.TxtSaldoInicial.Top = 0.2105263!
        Me.TxtSaldoInicial.Width = 0.6842105!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblTotalCantidad1, Me.LblTotalImporte1l, Me.LblTotalCantidad2, Me.LblTotalImporte2, Me.LblTotalCantidad3, Me.LblTotalImporte3})
        Me.GroupFooter1.Height = 0.2395833!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'LblTotalCantidad1
        '
        Me.LblTotalCantidad1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalCantidad1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalCantidad1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad1.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalCantidad1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad1.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalCantidad1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad1.Height = 0.1875!
        Me.LblTotalCantidad1.HyperLink = Nothing
        Me.LblTotalCantidad1.Left = 4.5625!
        Me.LblTotalCantidad1.Name = "LblTotalCantidad1"
        Me.LblTotalCantidad1.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalCantidad1.Text = ""
        Me.LblTotalCantidad1.Top = 0.0!
        Me.LblTotalCantidad1.Width = 0.6875!
        '
        'LblTotalImporte1l
        '
        Me.LblTotalImporte1l.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalImporte1l.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte1l.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalImporte1l.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte1l.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalImporte1l.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte1l.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalImporte1l.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte1l.Height = 0.1875!
        Me.LblTotalImporte1l.HyperLink = Nothing
        Me.LblTotalImporte1l.Left = 2.105263!
        Me.LblTotalImporte1l.Name = "LblTotalImporte1l"
        Me.LblTotalImporte1l.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalImporte1l.Text = ""
        Me.LblTotalImporte1l.Top = 0.9473684!
        Me.LblTotalImporte1l.Visible = False
        Me.LblTotalImporte1l.Width = 0.6875!
        '
        'LblTotalCantidad2
        '
        Me.LblTotalCantidad2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalCantidad2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalCantidad2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad2.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalCantidad2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad2.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalCantidad2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad2.Height = 0.1875!
        Me.LblTotalCantidad2.HyperLink = Nothing
        Me.LblTotalCantidad2.Left = 5.25!
        Me.LblTotalCantidad2.Name = "LblTotalCantidad2"
        Me.LblTotalCantidad2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalCantidad2.Text = ""
        Me.LblTotalCantidad2.Top = 0.0!
        Me.LblTotalCantidad2.Width = 0.6875!
        '
        'LblTotalImporte2
        '
        Me.LblTotalImporte2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalImporte2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalImporte2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte2.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalImporte2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte2.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalImporte2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte2.Height = 0.1875!
        Me.LblTotalImporte2.HyperLink = Nothing
        Me.LblTotalImporte2.Left = 3.473684!
        Me.LblTotalImporte2.Name = "LblTotalImporte2"
        Me.LblTotalImporte2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalImporte2.Text = ""
        Me.LblTotalImporte2.Top = 0.9473684!
        Me.LblTotalImporte2.Visible = False
        Me.LblTotalImporte2.Width = 0.6875!
        '
        'LblTotalCantidad3
        '
        Me.LblTotalCantidad3.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalCantidad3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad3.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalCantidad3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad3.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalCantidad3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad3.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalCantidad3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalCantidad3.Height = 0.1875!
        Me.LblTotalCantidad3.HyperLink = Nothing
        Me.LblTotalCantidad3.Left = 5.9375!
        Me.LblTotalCantidad3.Name = "LblTotalCantidad3"
        Me.LblTotalCantidad3.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalCantidad3.Text = ""
        Me.LblTotalCantidad3.Top = 0.0!
        Me.LblTotalCantidad3.Width = 0.75!
        '
        'LblTotalImporte3
        '
        Me.LblTotalImporte3.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalImporte3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte3.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalImporte3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte3.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalImporte3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte3.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalImporte3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalImporte3.Height = 0.1875!
        Me.LblTotalImporte3.HyperLink = Nothing
        Me.LblTotalImporte3.Left = 4.947368!
        Me.LblTotalImporte3.Name = "LblTotalImporte3"
        Me.LblTotalImporte3.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalImporte3.Text = ""
        Me.LblTotalImporte3.Top = 0.9473684!
        Me.LblTotalImporte3.Visible = False
        Me.LblTotalImporte3.Width = 0.75!
        '
        'ArepControlProductos
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaFacturacionImportadora;Data Source=CONSULTOR\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.1!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 8.375!
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
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSaldoInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalCantidad1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalImporte1l, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalCantidad2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalImporte2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalCantidad3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalImporte3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents SrpCompras As DataDynamics.ActiveReports.SubReport
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TxtCodProducto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCodProductos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SrpFacturas As DataDynamics.ActiveReports.SubReport
    Friend WithEvents LblTotalCantidad1 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotalCantidad2 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotalImporte2 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotalCantidad3 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotalImporte3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTotalImporte1l As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtSaldoInicial As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
End Class
