<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepExistenciaCostos 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepExistenciaCostos))
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
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.LblRango = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TxtCodProducto = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtSaldo = New DataDynamics.ActiveReports.TextBox
        Me.TxtCostoPromedio2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtSaldoM = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.LblCodigo = New DataDynamics.ActiveReports.Label
        Me.TxtCodLinea = New DataDynamics.ActiveReports.Label
        Me.LblNombre = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRango, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCostoPromedio2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSaldoM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1, Me.Label2, Me.Line1, Me.Label4, Me.Line2, Me.Label9, Me.Label11, Me.Label15, Me.LblRango})
        Me.PageHeader1.Height = 1.604167!
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
        Me.LblTitulo.Left = 0.0625!
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.LblTitulo.Text = "S&S"
        Me.LblTitulo.Top = 0.0625!
        Me.LblTitulo.Width = 7.625!
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
        Me.LblDireccion.Style = "text-align: center; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.3125!
        Me.LblDireccion.Width = 7.625!
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
        Me.LblRuc.Left = 0.0625!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "text-align: center; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 0.5!
        Me.LblRuc.Width = 7.625!
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
        Me.TextBox1.Left = 7.25!
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
        Me.Label3.Left = 6.9375!
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
        Me.Label1.Left = 0.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.Label1.Text = "Tarjeta de Control Kardex"
        Me.Label1.Top = 0.6875!
        Me.Label1.Width = 7.625!
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
        Me.Label2.Width = 1.125!
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
        Me.Line1.Width = 7.6875!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 7.75!
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
        Me.Label4.Left = 1.1875!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label4.Text = "Descripcion"
        Me.Label4.Top = 1.1875!
        Me.Label4.Width = 3.8125!
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
        Me.Line2.Top = 1.5625!
        Me.Line2.Width = 7.6875!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.75!
        Me.Line2.Y1 = 1.5625!
        Me.Line2.Y2 = 1.5625!
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
        Me.Label9.Left = 5.0!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label9.Text = "Costo de Venta"
        Me.Label9.Top = 1.1875!
        Me.Label9.Width = 0.8125!
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
        Me.Label11.Height = 0.375!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 6.6875!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label11.Text = "Costo Total Producto"
        Me.Label11.Top = 1.1875!
        Me.Label11.Width = 1.0!
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
        Me.Label15.Height = 0.375!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 5.8125!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label15.Text = "Existencia Unidades"
        Me.Label15.Top = 1.1875!
        Me.Label15.Width = 0.875!
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
        Me.LblRango.Left = 0.0625!
        Me.LblRango.Name = "LblRango"
        Me.LblRango.Style = "text-align: center; "
        Me.LblRango.Text = Nothing
        Me.LblRango.Top = 0.875!
        Me.LblRango.Width = 7.625!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtCodProducto, Me.TextBox3, Me.TxtSaldo, Me.TxtCostoPromedio2, Me.TxtSaldoM})
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
        Me.TxtCodProducto.Width = 1.1875!
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
        Me.TextBox3.Left = 1.1875!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 3.8125!
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
        Me.TxtSaldo.Left = 5.8125!
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.OutputFormat = resources.GetString("TxtSaldo.OutputFormat")
        Me.TxtSaldo.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtSaldo.Text = Nothing
        Me.TxtSaldo.Top = 0.0!
        Me.TxtSaldo.Width = 0.875!
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
        Me.TxtCostoPromedio2.Left = 5.0!
        Me.TxtCostoPromedio2.Name = "TxtCostoPromedio2"
        Me.TxtCostoPromedio2.OutputFormat = resources.GetString("TxtCostoPromedio2.OutputFormat")
        Me.TxtCostoPromedio2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCostoPromedio2.Text = Nothing
        Me.TxtCostoPromedio2.Top = 0.0!
        Me.TxtCostoPromedio2.Width = 0.8125!
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
        Me.TxtSaldoM.Left = 6.6875!
        Me.TxtSaldoM.Name = "TxtSaldoM"
        Me.TxtSaldoM.OutputFormat = resources.GetString("TxtSaldoM.OutputFormat")
        Me.TxtSaldoM.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtSaldoM.Text = Nothing
        Me.TxtSaldoM.Top = 0.0!
        Me.TxtSaldoM.Width = 1.0!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblCodigo, Me.TxtCodLinea, Me.LblNombre, Me.Label20})
        Me.GroupHeader1.DataField = "Cod_Bodega"
        Me.GroupHeader1.Height = 0.1979167!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'LblCodigo
        '
        Me.LblCodigo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodigo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodigo.Border.RightColor = System.Drawing.Color.Black
        Me.LblCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodigo.Border.TopColor = System.Drawing.Color.Black
        Me.LblCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodigo.Height = 0.1875!
        Me.LblCodigo.HyperLink = Nothing
        Me.LblCodigo.Left = 0.0!
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Style = "ddo-char-set: 0; background-color: White; font-size: 9pt; "
        Me.LblCodigo.Text = "Codigo Linea"
        Me.LblCodigo.Top = 0.0!
        Me.LblCodigo.Width = 0.9375!
        '
        'TxtCodLinea
        '
        Me.TxtCodLinea.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCodLinea.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodLinea.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCodLinea.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodLinea.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCodLinea.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodLinea.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCodLinea.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodLinea.DataField = "Cod_Bodega"
        Me.TxtCodLinea.Height = 0.1875!
        Me.TxtCodLinea.HyperLink = Nothing
        Me.TxtCodLinea.Left = 1.0!
        Me.TxtCodLinea.Name = "TxtCodLinea"
        Me.TxtCodLinea.Style = ""
        Me.TxtCodLinea.Text = ""
        Me.TxtCodLinea.Top = 0.0!
        Me.TxtCodLinea.Width = 0.875!
        '
        'LblNombre
        '
        Me.LblNombre.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNombre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombre.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNombre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombre.Border.RightColor = System.Drawing.Color.Black
        Me.LblNombre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombre.Border.TopColor = System.Drawing.Color.Black
        Me.LblNombre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombre.Height = 0.1875!
        Me.LblNombre.HyperLink = Nothing
        Me.LblNombre.Left = 2.0625!
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Style = "ddo-char-set: 0; background-color: White; font-size: 9pt; "
        Me.LblNombre.Text = "Nombre Linea"
        Me.LblNombre.Top = 0.0!
        Me.LblNombre.Width = 1.0625!
        '
        'Label20
        '
        Me.Label20.Border.BottomColor = System.Drawing.Color.Black
        Me.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.LeftColor = System.Drawing.Color.Black
        Me.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.RightColor = System.Drawing.Color.Black
        Me.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.TopColor = System.Drawing.Color.Black
        Me.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.DataField = "Nombre_Bodega"
        Me.Label20.Height = 0.1875!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 3.25!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = ""
        Me.Label20.Text = ""
        Me.Label20.Top = 0.0!
        Me.Label20.Width = 3.6875!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox7, Me.Label18, Me.Label16, Me.TextBox2})
        Me.GroupFooter1.Height = 0.25!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.TextBox7.Left = 3.25!
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
        Me.Label18.Left = 2.875!
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
        Me.Label16.Left = 0.0!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Label16.Text = "Total"
        Me.Label16.Top = 0.0!
        Me.Label16.Width = 2.8125!
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
        Me.TextBox2.Left = 6.6875!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox2.SummaryGroup = "GroupHeader1"
        Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 1.0!
        '
        'ArepExistenciaCostos
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=SistemaFacturacionRevetsa;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.802083!
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
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRango, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCostoPromedio2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSaldoM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCodProducto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtSaldo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCostoPromedio2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtSaldoM As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblRango As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblCodigo As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCodLinea As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombre As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
End Class 
