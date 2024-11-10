<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepKardex 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepKardex))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TxtCodProducto = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtEntrada = New DataDynamics.ActiveReports.TextBox
        Me.TxtInicial = New DataDynamics.ActiveReports.TextBox
        Me.TxtCostoPromedio = New DataDynamics.ActiveReports.TextBox
        Me.TxtCostoPromedio2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtSalida = New DataDynamics.ActiveReports.TextBox
        Me.TxtSaldo = New DataDynamics.ActiveReports.TextBox
        Me.TxtInicialM = New DataDynamics.ActiveReports.TextBox
        Me.TxtEntradaM = New DataDynamics.ActiveReports.TextBox
        Me.TxtSalidaM = New DataDynamics.ActiveReports.TextBox
        Me.TxtSaldoM = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.LblRango = New DataDynamics.ActiveReports.TextBox
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCostoPromedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCostoPromedio2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInicialM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEntradaM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSalidaM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSaldoM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRango, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1, Me.Label2, Me.Line1, Me.Label4, Me.Label6, Me.Label7, Me.Label8, Me.Line2, Me.Label5, Me.Label9, Me.Label14, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label15, Me.LblRango})
        Me.PageHeader1.Height = 1.65625!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.ImgLogo.Height = 1.0!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.25!
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
        Me.LblTitulo.Left = 0.0!
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.LblTitulo.Text = "S&S"
        Me.LblTitulo.Top = 0.0625!
        Me.LblTitulo.Width = 10.5625!
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
        Me.LblDireccion.Style = "text-align: center; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.3125!
        Me.LblDireccion.Width = 10.5625!
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
        Me.LblRuc.Style = "text-align: center; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 0.5!
        Me.LblRuc.Width = 10.5625!
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
        Me.TextBox1.Left = 10.125!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = ""
        Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.875!
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
        Me.Label3.Left = 9.8125!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "Pag."
        Me.Label3.Top = 0.875!
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
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.Label1.Text = "Tarjeta de Control Kardex"
        Me.Label1.Top = 0.6875!
        Me.Label1.Width = 10.5625!
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
        Me.Label2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label2.Text = "Cod Producto"
        Me.Label2.Top = 1.1875!
        Me.Label2.Width = 0.9375!
        '
        'Line1
        '
        Me.Line1.Border.BottomColor = System.Drawing.Color.Black
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line1.Border.LeftColor = System.Drawing.Color.Black
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.RightColor = System.Drawing.Color.Black
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.TopColor = System.Drawing.Color.Black
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0625!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.125!
        Me.Line1.Width = 10.625!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 10.6875!
        Me.Line1.Y1 = 1.125!
        Me.Line1.Y2 = 1.125!
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
        Me.Label4.Left = 1.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label4.Text = "Descripcion"
        Me.Label4.Top = 1.1875!
        Me.Label4.Width = 3.5625!
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
        Me.Label6.Left = 5.6875!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label6.Text = "Salida"
        Me.Label6.Top = 1.375!
        Me.Label6.Width = 0.5625!
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
        Me.Label7.Left = 6.25!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label7.Text = "Saldo"
        Me.Label7.Top = 1.375!
        Me.Label7.Width = 0.5625!
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
        Me.Label8.Left = 4.5625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label8.Text = "Existencia Fisica"
        Me.Label8.Top = 1.1875!
        Me.Label8.Width = 2.25!
        '
        'Line2
        '
        Me.Line2.Border.BottomColor = System.Drawing.Color.Black
        Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Line2.Border.LeftColor = System.Drawing.Color.Black
        Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.RightColor = System.Drawing.Color.Black
        Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.TopColor = System.Drawing.Color.Black
        Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.625!
        Me.Line2.Width = 10.625!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 10.6875!
        Me.Line2.Y1 = 1.625!
        Me.Line2.Y2 = 1.625!
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
        Me.Label5.Left = 4.5625!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label5.Text = "Inicial"
        Me.Label5.Top = 1.375!
        Me.Label5.Width = 0.5625!
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
        Me.Label9.Height = 0.375!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 6.8125!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label9.Text = "Costo de Venta"
        Me.Label9.Top = 1.1875!
        Me.Label9.Width = 0.8125!
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
        Me.Label14.Height = 0.1875!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 5.125!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label14.Text = "Entrada"
        Me.Label14.Top = 1.375!
        Me.Label14.Width = 0.5625!
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
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 9.125!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label10.Text = "Salida"
        Me.Label10.Top = 1.375!
        Me.Label10.Width = 0.75!
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
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 9.875!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label11.Text = "Saldo"
        Me.Label11.Top = 1.375!
        Me.Label11.Width = 0.75!
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
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 7.625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label12.Text = "Movimiento Monetario"
        Me.Label12.Top = 1.1875!
        Me.Label12.Width = 3.0!
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
        Me.Label13.Left = 7.625!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label13.Text = "Inicial"
        Me.Label13.Top = 1.375!
        Me.Label13.Width = 0.75!
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
        Me.Label15.Height = 0.1875!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 8.375!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label15.Text = "Entrada"
        Me.Label15.Top = 1.375!
        Me.Label15.Width = 0.75!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtCodProducto, Me.TextBox3, Me.TxtEntrada, Me.TxtInicial, Me.TxtCostoPromedio, Me.TxtCostoPromedio2, Me.TxtSalida, Me.TxtSaldo, Me.TxtInicialM, Me.TxtEntradaM, Me.TxtSalidaM, Me.TxtSaldoM})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
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
        Me.TxtCodProducto.Left = 0.0!
        Me.TxtCodProducto.Name = "TxtCodProducto"
        Me.TxtCodProducto.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtCodProducto.Text = Nothing
        Me.TxtCodProducto.Top = 0.0!
        Me.TxtCodProducto.Width = 1.0!
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
        Me.TextBox3.DataField = "Descripcion_Producto"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 1.0!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 3.5625!
        '
        'TxtEntrada
        '
        Me.TxtEntrada.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtEntrada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEntrada.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtEntrada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEntrada.Border.RightColor = System.Drawing.Color.Black
        Me.TxtEntrada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEntrada.Border.TopColor = System.Drawing.Color.Black
        Me.TxtEntrada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEntrada.DataField = "Entrada"
        Me.TxtEntrada.Height = 0.1875!
        Me.TxtEntrada.Left = 5.125!
        Me.TxtEntrada.Name = "TxtEntrada"
        Me.TxtEntrada.OutputFormat = resources.GetString("TxtEntrada.OutputFormat")
        Me.TxtEntrada.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtEntrada.Text = Nothing
        Me.TxtEntrada.Top = 0.0!
        Me.TxtEntrada.Width = 0.5625!
        '
        'TxtInicial
        '
        Me.TxtInicial.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtInicial.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInicial.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtInicial.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInicial.Border.RightColor = System.Drawing.Color.Black
        Me.TxtInicial.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInicial.Border.TopColor = System.Drawing.Color.Black
        Me.TxtInicial.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInicial.DataField = "Inicial"
        Me.TxtInicial.Height = 0.1875!
        Me.TxtInicial.Left = 4.5625!
        Me.TxtInicial.Name = "TxtInicial"
        Me.TxtInicial.OutputFormat = resources.GetString("TxtInicial.OutputFormat")
        Me.TxtInicial.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtInicial.Text = Nothing
        Me.TxtInicial.Top = 0.0!
        Me.TxtInicial.Width = 0.5625!
        '
        'TxtCostoPromedio
        '
        Me.TxtCostoPromedio.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCostoPromedio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCostoPromedio.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCostoPromedio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCostoPromedio.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCostoPromedio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCostoPromedio.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCostoPromedio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCostoPromedio.DataField = "Costo_Promedio"
        Me.TxtCostoPromedio.Height = 0.1875!
        Me.TxtCostoPromedio.Left = 5.5!
        Me.TxtCostoPromedio.Name = "TxtCostoPromedio"
        Me.TxtCostoPromedio.OutputFormat = resources.GetString("TxtCostoPromedio.OutputFormat")
        Me.TxtCostoPromedio.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCostoPromedio.Text = Nothing
        Me.TxtCostoPromedio.Top = 0.875!
        Me.TxtCostoPromedio.Visible = False
        Me.TxtCostoPromedio.Width = 0.5625!
        '
        'TxtCostoPromedio2
        '
        Me.TxtCostoPromedio2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCostoPromedio2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCostoPromedio2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCostoPromedio2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCostoPromedio2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCostoPromedio2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCostoPromedio2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCostoPromedio2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCostoPromedio2.DataField = "CostoVenta"
        Me.TxtCostoPromedio2.Height = 0.1875!
        Me.TxtCostoPromedio2.Left = 6.8125!
        Me.TxtCostoPromedio2.Name = "TxtCostoPromedio2"
        Me.TxtCostoPromedio2.OutputFormat = resources.GetString("TxtCostoPromedio2.OutputFormat")
        Me.TxtCostoPromedio2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCostoPromedio2.Text = Nothing
        Me.TxtCostoPromedio2.Top = 0.0!
        Me.TxtCostoPromedio2.Width = 0.8125!
        '
        'TxtSalida
        '
        Me.TxtSalida.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtSalida.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSalida.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtSalida.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSalida.Border.RightColor = System.Drawing.Color.Black
        Me.TxtSalida.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSalida.Border.TopColor = System.Drawing.Color.Black
        Me.TxtSalida.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSalida.DataField = "Salida"
        Me.TxtSalida.Height = 0.1875!
        Me.TxtSalida.Left = 5.6875!
        Me.TxtSalida.Name = "TxtSalida"
        Me.TxtSalida.OutputFormat = resources.GetString("TxtSalida.OutputFormat")
        Me.TxtSalida.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtSalida.Text = Nothing
        Me.TxtSalida.Top = 0.0!
        Me.TxtSalida.Width = 0.5625!
        '
        'TxtSaldo
        '
        Me.TxtSaldo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtSaldo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtSaldo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtSaldo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtSaldo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldo.DataField = "Saldo"
        Me.TxtSaldo.Height = 0.1875!
        Me.TxtSaldo.Left = 6.25!
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.OutputFormat = resources.GetString("TxtSaldo.OutputFormat")
        Me.TxtSaldo.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtSaldo.Text = Nothing
        Me.TxtSaldo.Top = 0.0!
        Me.TxtSaldo.Width = 0.5625!
        '
        'TxtInicialM
        '
        Me.TxtInicialM.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtInicialM.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInicialM.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtInicialM.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInicialM.Border.RightColor = System.Drawing.Color.Black
        Me.TxtInicialM.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInicialM.Border.TopColor = System.Drawing.Color.Black
        Me.TxtInicialM.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInicialM.DataField = "InicialD"
        Me.TxtInicialM.Height = 0.1875!
        Me.TxtInicialM.Left = 7.625!
        Me.TxtInicialM.Name = "TxtInicialM"
        Me.TxtInicialM.OutputFormat = resources.GetString("TxtInicialM.OutputFormat")
        Me.TxtInicialM.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtInicialM.Text = Nothing
        Me.TxtInicialM.Top = 0.0!
        Me.TxtInicialM.Width = 0.75!
        '
        'TxtEntradaM
        '
        Me.TxtEntradaM.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtEntradaM.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEntradaM.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtEntradaM.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEntradaM.Border.RightColor = System.Drawing.Color.Black
        Me.TxtEntradaM.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEntradaM.Border.TopColor = System.Drawing.Color.Black
        Me.TxtEntradaM.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEntradaM.DataField = "EntradaD"
        Me.TxtEntradaM.Height = 0.1875!
        Me.TxtEntradaM.Left = 8.375!
        Me.TxtEntradaM.Name = "TxtEntradaM"
        Me.TxtEntradaM.OutputFormat = resources.GetString("TxtEntradaM.OutputFormat")
        Me.TxtEntradaM.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtEntradaM.Text = Nothing
        Me.TxtEntradaM.Top = 0.0!
        Me.TxtEntradaM.Width = 0.75!
        '
        'TxtSalidaM
        '
        Me.TxtSalidaM.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtSalidaM.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSalidaM.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtSalidaM.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSalidaM.Border.RightColor = System.Drawing.Color.Black
        Me.TxtSalidaM.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSalidaM.Border.TopColor = System.Drawing.Color.Black
        Me.TxtSalidaM.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSalidaM.DataField = "SalidaD"
        Me.TxtSalidaM.Height = 0.1875!
        Me.TxtSalidaM.Left = 9.125!
        Me.TxtSalidaM.Name = "TxtSalidaM"
        Me.TxtSalidaM.OutputFormat = resources.GetString("TxtSalidaM.OutputFormat")
        Me.TxtSalidaM.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtSalidaM.Text = Nothing
        Me.TxtSalidaM.Top = 0.0!
        Me.TxtSalidaM.Width = 0.75!
        '
        'TxtSaldoM
        '
        Me.TxtSaldoM.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtSaldoM.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldoM.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtSaldoM.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldoM.Border.RightColor = System.Drawing.Color.Black
        Me.TxtSaldoM.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldoM.Border.TopColor = System.Drawing.Color.Black
        Me.TxtSaldoM.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtSaldoM.DataField = "SaldoD"
        Me.TxtSaldoM.Height = 0.1875!
        Me.TxtSaldoM.Left = 9.875!
        Me.TxtSaldoM.Name = "TxtSaldoM"
        Me.TxtSaldoM.OutputFormat = resources.GetString("TxtSaldoM.OutputFormat")
        Me.TxtSaldoM.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtSaldoM.Text = Nothing
        Me.TxtSaldoM.Top = 0.0!
        Me.TxtSaldoM.Width = 0.75!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.DataField = "Cod_Bodega"
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.Label18, Me.Label16})
        Me.GroupFooter1.Height = 0.25!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.TextBox2.DataField = "SaldoD"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 9.875!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox2.SummaryGroup = "GroupHeader1"
        Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.75!
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
        Me.TextBox4.DataField = "EntradaD"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 8.375!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox4.SummaryGroup = "GroupHeader1"
        Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
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
        Me.TextBox5.DataField = "SalidaD"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 9.125!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox5.SummaryGroup = "GroupHeader1"
        Me.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.75!
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
        Me.TextBox6.DataField = "InicialD"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 7.625!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox6.SummaryGroup = "GroupHeader1"
        Me.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
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
        Me.TextBox7.DataField = "Cod_Productos"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 4.125!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox7.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.TextBox7.SummaryGroup = "GroupHeader1"
        Me.TextBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.4375!
        '
        'Label18
        '
        Me.Label18.Border.BottomColor = System.Drawing.Color.Black
        Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.LeftColor = System.Drawing.Color.Black
        Me.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.RightColor = System.Drawing.Color.Black
        Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.TopColor = System.Drawing.Color.Black
        Me.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Height = 0.1875!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 3.75!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = ""
        Me.Label18.Text = "Items"
        Me.Label18.Top = 0.0!
        Me.Label18.Width = 0.375!
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
        Me.Label16.Left = 0.875!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Label16.Text = "Total"
        Me.Label16.Top = 0.0!
        Me.Label16.Width = 2.8125!
        '
        'LblRango
        '
        Me.LblRango.Border.BottomColor = System.Drawing.Color.Black
        Me.LblRango.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRango.Border.LeftColor = System.Drawing.Color.Black
        Me.LblRango.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRango.Border.RightColor = System.Drawing.Color.Black
        Me.LblRango.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRango.Border.TopColor = System.Drawing.Color.Black
        Me.LblRango.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRango.Height = 0.1875!
        Me.LblRango.Left = 0.0!
        Me.LblRango.Name = "LblRango"
        Me.LblRango.Style = "text-align: center; "
        Me.LblRango.Text = Nothing
        Me.LblRango.Top = 0.875!
        Me.LblRango.Width = 10.5625!
        '
        'ArepKardex
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=SistemaFacturacionRevetsa;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.2!
        Me.PageSettings.Margins.Right = 0.1!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.79167!
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
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCostoPromedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCostoPromedio2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInicialM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEntradaM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSalidaM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSaldoM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRango, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCodProducto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtEntrada As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtInicial As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCostoPromedio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCostoPromedio2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtSalida As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtSaldo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtInicialM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtEntradaM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtSalidaM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtSaldoM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRango As DataDynamics.ActiveReports.TextBox
End Class
