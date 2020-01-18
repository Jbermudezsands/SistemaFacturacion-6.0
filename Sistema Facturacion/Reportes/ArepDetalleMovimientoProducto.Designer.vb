<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepDetalleMovimientoProducto 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepDetalleMovimientoProducto))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TxtTipo = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFecha = New DataDynamics.ActiveReports.TextBox
        Me.TxtNumero = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantidad1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtImporte1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantidad2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtImporte2 = New DataDynamics.ActiveReports.TextBox
        Me.LblCantidadSaldo = New DataDynamics.ActiveReports.Label
        Me.LblImporteSaldo = New DataDynamics.ActiveReports.Label
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.TxtCodProducto = New DataDynamics.ActiveReports.TextBox
        Me.TxtCodProductos = New DataDynamics.ActiveReports.TextBox
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.TxtSaldoInicial = New DataDynamics.ActiveReports.TextBox
        Me.TxtImporteInicial = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TxtImporteSalida = New DataDynamics.ActiveReports.TextBox
        Me.TxtImporteEntrada = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantidadSalida = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantidadEntrada = New DataDynamics.ActiveReports.TextBox
        Me.LblTotalCantidad3 = New DataDynamics.ActiveReports.Label
        Me.LblTotalImporte3 = New DataDynamics.ActiveReports.Label
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantidad1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtImporte1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantidad2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtImporte2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCantidadSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblImporteSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSaldoInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtImporteInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtImporteSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtImporteEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantidadSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantidadEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalCantidad3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalImporte3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1, Me.Line1, Me.Line2, Me.Label12, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label2, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.ImgLogo})
        Me.PageHeader1.Height = 1.756944!
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
        Me.LblTitulo.Left = 0.1875!
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.LblTitulo.Text = "SYSTEMS AND SOLUTIONS"
        Me.LblTitulo.Top = 0.0!
        Me.LblTitulo.Width = 7.5!
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
        Me.LblDireccion.Left = 0.1875!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "text-align: center; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.25!
        Me.LblDireccion.Width = 7.5!
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
        Me.LblRuc.Left = 0.1875!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "text-align: center; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 0.4375!
        Me.LblRuc.Width = 7.5!
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
        Me.TextBox1.Left = 6.5!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = ""
        Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.9375!
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
        Me.Label3.Left = 6.1875!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "Pag."
        Me.Label3.Top = 0.9375!
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
        Me.Label1.Left = 0.1875!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.Label1.Text = "Movimiento de Productos"
        Me.Label1.Top = 0.625!
        Me.Label1.Width = 7.5!
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
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.25!
        Me.Line1.Width = 7.875!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 7.875!
        Me.Line1.Y1 = 1.25!
        Me.Line1.Y2 = 1.25!
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
        Me.Line2.Left = 0.0!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.75!
        Me.Line2.Width = 7.875!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 7.875!
        Me.Line2.Y1 = 1.75!
        Me.Line2.Y2 = 1.75!
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
        Me.Label12.Left = 4.3125!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label12.Text = "Importe"
        Me.Label12.Top = 1.5!
        Me.Label12.Width = 0.6875!
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
        Me.Label4.Left = 0.0625!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label4.Text = "Tipo"
        Me.Label4.Top = 1.5!
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
        Me.Label5.Left = 1.3125!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label5.Text = "Descripcion"
        Me.Label5.Top = 1.3125!
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
        Me.Label6.Left = 2.0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label6.Text = "Fecha"
        Me.Label6.Top = 1.5!
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
        Me.Label7.Left = 2.8125!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label7.Text = "Numero"
        Me.Label7.Top = 1.5!
        Me.Label7.Width = 0.8125!
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
        Me.Label8.Left = 3.625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Label8.Text = "---------ENTRADAS---------"
        Me.Label8.Top = 1.3125!
        Me.Label8.Width = 1.375!
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
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 5.0!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label9.Text = "----------SALIDAS----------"
        Me.Label9.Top = 1.3125!
        Me.Label9.Width = 1.375!
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
        Me.Label10.Left = 6.375!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label10.Text = "----MOVIMIENTO NETO----"
        Me.Label10.Top = 1.3125!
        Me.Label10.Width = 1.5!
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
        Me.Label11.Left = 3.625!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label11.Text = "Cantidad"
        Me.Label11.Top = 1.5!
        Me.Label11.Width = 0.6875!
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
        Me.Label2.Top = 1.3125!
        Me.Label2.Width = 1.25!
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
        Me.Label13.Left = 5.0!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label13.Text = "Cantidad"
        Me.Label13.Top = 1.5!
        Me.Label13.Width = 0.6875!
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
        Me.Label14.Left = 5.6875!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label14.Text = "Importe"
        Me.Label14.Top = 1.5!
        Me.Label14.Width = 0.6875!
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
        Me.Label15.Left = 6.375!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label15.Text = "Cantidad"
        Me.Label15.Top = 1.5!
        Me.Label15.Width = 0.75!
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
        Me.Label16.Left = 7.125!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label16.Text = "Importe"
        Me.Label16.Top = 1.5!
        Me.Label16.Width = 0.75!
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
        Me.Label17.Left = 1.3125!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label17.Text = "Bodega"
        Me.Label17.Top = 1.5!
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
        Me.ImgLogo.Left = 0.0625!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.6875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtTipo, Me.TextBox2, Me.TxtFecha, Me.TxtNumero, Me.TxtCantidad1, Me.TxtImporte1, Me.TxtCantidad2, Me.TxtImporte2, Me.LblCantidadSaldo, Me.LblImporteSaldo})
        Me.Detail1.Height = 0.2395833!
        Me.Detail1.Name = "Detail1"
        '
        'TxtTipo
        '
        Me.TxtTipo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.DataField = "Tipo_Factura"
        Me.TxtTipo.Height = 0.1875!
        Me.TxtTipo.Left = 0.0625!
        Me.TxtTipo.Name = "TxtTipo"
        Me.TxtTipo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtTipo.Text = Nothing
        Me.TxtTipo.Top = 0.0!
        Me.TxtTipo.Width = 1.25!
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
        Me.TextBox2.DataField = "Cod_Bodega"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 1.3125!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.6875!
        '
        'TxtFecha
        '
        Me.TxtFecha.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFecha.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFecha.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFecha.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFecha.DataField = "Fecha_Factura"
        Me.TxtFecha.Height = 0.1875!
        Me.TxtFecha.Left = 2.0!
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.OutputFormat = resources.GetString("TxtFecha.OutputFormat")
        Me.TxtFecha.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TxtFecha.Text = Nothing
        Me.TxtFecha.Top = 0.0!
        Me.TxtFecha.Width = 0.8125!
        '
        'TxtNumero
        '
        Me.TxtNumero.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtNumero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumero.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtNumero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumero.Border.RightColor = System.Drawing.Color.Black
        Me.TxtNumero.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumero.Border.TopColor = System.Drawing.Color.Black
        Me.TxtNumero.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumero.DataField = "Numero_Factura"
        Me.TxtNumero.Height = 0.1875!
        Me.TxtNumero.Left = 2.8125!
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TxtNumero.Text = Nothing
        Me.TxtNumero.Top = 0.0!
        Me.TxtNumero.Width = 0.8125!
        '
        'TxtCantidad1
        '
        Me.TxtCantidad1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantidad1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantidad1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantidad1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantidad1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad1.DataField = "CantidadCompra"
        Me.TxtCantidad1.Height = 0.1875!
        Me.TxtCantidad1.Left = 3.625!
        Me.TxtCantidad1.Name = "TxtCantidad1"
        Me.TxtCantidad1.OutputFormat = resources.GetString("TxtCantidad1.OutputFormat")
        Me.TxtCantidad1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCantidad1.Text = Nothing
        Me.TxtCantidad1.Top = 0.0!
        Me.TxtCantidad1.Width = 0.6875!
        '
        'TxtImporte1
        '
        Me.TxtImporte1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtImporte1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtImporte1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtImporte1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtImporte1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte1.DataField = "ImporteCompra"
        Me.TxtImporte1.Height = 0.1875!
        Me.TxtImporte1.Left = 4.3125!
        Me.TxtImporte1.Name = "TxtImporte1"
        Me.TxtImporte1.OutputFormat = resources.GetString("TxtImporte1.OutputFormat")
        Me.TxtImporte1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtImporte1.Text = Nothing
        Me.TxtImporte1.Top = 0.0!
        Me.TxtImporte1.Width = 0.6875!
        '
        'TxtCantidad2
        '
        Me.TxtCantidad2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantidad2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantidad2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantidad2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantidad2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad2.DataField = "Cantidad"
        Me.TxtCantidad2.Height = 0.1875!
        Me.TxtCantidad2.Left = 5.0!
        Me.TxtCantidad2.Name = "TxtCantidad2"
        Me.TxtCantidad2.OutputFormat = resources.GetString("TxtCantidad2.OutputFormat")
        Me.TxtCantidad2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCantidad2.Text = Nothing
        Me.TxtCantidad2.Top = 0.0!
        Me.TxtCantidad2.Width = 0.6875!
        '
        'TxtImporte2
        '
        Me.TxtImporte2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtImporte2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtImporte2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtImporte2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtImporte2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte2.DataField = "Importe"
        Me.TxtImporte2.Height = 0.1875!
        Me.TxtImporte2.Left = 5.6875!
        Me.TxtImporte2.Name = "TxtImporte2"
        Me.TxtImporte2.OutputFormat = resources.GetString("TxtImporte2.OutputFormat")
        Me.TxtImporte2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtImporte2.Text = Nothing
        Me.TxtImporte2.Top = 0.0!
        Me.TxtImporte2.Width = 0.6875!
        '
        'LblCantidadSaldo
        '
        Me.LblCantidadSaldo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCantidadSaldo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCantidadSaldo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCantidadSaldo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCantidadSaldo.Border.RightColor = System.Drawing.Color.Black
        Me.LblCantidadSaldo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCantidadSaldo.Border.TopColor = System.Drawing.Color.Black
        Me.LblCantidadSaldo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCantidadSaldo.Height = 0.1875!
        Me.LblCantidadSaldo.HyperLink = Nothing
        Me.LblCantidadSaldo.Left = 6.375!
        Me.LblCantidadSaldo.Name = "LblCantidadSaldo"
        Me.LblCantidadSaldo.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; "
        Me.LblCantidadSaldo.Text = ""
        Me.LblCantidadSaldo.Top = 0.0!
        Me.LblCantidadSaldo.Width = 0.75!
        '
        'LblImporteSaldo
        '
        Me.LblImporteSaldo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblImporteSaldo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImporteSaldo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblImporteSaldo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImporteSaldo.Border.RightColor = System.Drawing.Color.Black
        Me.LblImporteSaldo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImporteSaldo.Border.TopColor = System.Drawing.Color.Black
        Me.LblImporteSaldo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImporteSaldo.Height = 0.1875!
        Me.LblImporteSaldo.HyperLink = Nothing
        Me.LblImporteSaldo.Left = 7.125!
        Me.LblImporteSaldo.Name = "LblImporteSaldo"
        Me.LblImporteSaldo.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; "
        Me.LblImporteSaldo.Text = ""
        Me.LblImporteSaldo.Top = 0.0!
        Me.LblImporteSaldo.Width = 0.75!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtCodProducto, Me.TxtCodProductos, Me.Label18, Me.TxtSaldoInicial, Me.TxtImporteInicial})
        Me.GroupHeader1.DataField = "Cod_Producto"
        Me.GroupHeader1.Height = 0.3125!
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
        Me.TxtCodProducto.DataField = "Cod_Producto"
        Me.TxtCodProducto.Height = 0.1875!
        Me.TxtCodProducto.Left = 0.0!
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
        Me.TxtCodProductos.Left = 1.125!
        Me.TxtCodProductos.Name = "TxtCodProductos"
        Me.TxtCodProductos.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.TxtCodProductos.Text = Nothing
        Me.TxtCodProductos.Top = 0.0!
        Me.TxtCodProductos.Width = 3.9375!
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
        Me.Label18.Left = 5.3125!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label18.Text = "Saldo Inicial"
        Me.Label18.Top = 0.0!
        Me.Label18.Width = 1.0625!
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
        Me.TxtSaldoInicial.Height = 0.1875!
        Me.TxtSaldoInicial.Left = 6.375!
        Me.TxtSaldoInicial.Name = "TxtSaldoInicial"
        Me.TxtSaldoInicial.OutputFormat = resources.GetString("TxtSaldoInicial.OutputFormat")
        Me.TxtSaldoInicial.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtSaldoInicial.Text = Nothing
        Me.TxtSaldoInicial.Top = 0.0!
        Me.TxtSaldoInicial.Width = 0.75!
        '
        'TxtImporteInicial
        '
        Me.TxtImporteInicial.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtImporteInicial.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteInicial.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtImporteInicial.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteInicial.Border.RightColor = System.Drawing.Color.Black
        Me.TxtImporteInicial.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteInicial.Border.TopColor = System.Drawing.Color.Black
        Me.TxtImporteInicial.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteInicial.Height = 0.1875!
        Me.TxtImporteInicial.Left = 7.125!
        Me.TxtImporteInicial.Name = "TxtImporteInicial"
        Me.TxtImporteInicial.OutputFormat = resources.GetString("TxtImporteInicial.OutputFormat")
        Me.TxtImporteInicial.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtImporteInicial.Text = Nothing
        Me.TxtImporteInicial.Top = 0.0!
        Me.TxtImporteInicial.Width = 0.75!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtImporteSalida, Me.TxtImporteEntrada, Me.TxtCantidadSalida, Me.TxtCantidadEntrada, Me.LblTotalCantidad3, Me.LblTotalImporte3})
        Me.GroupFooter1.Height = 0.25!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TxtImporteSalida
        '
        Me.TxtImporteSalida.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtImporteSalida.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteSalida.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtImporteSalida.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteSalida.Border.RightColor = System.Drawing.Color.Black
        Me.TxtImporteSalida.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteSalida.Border.TopColor = System.Drawing.Color.Black
        Me.TxtImporteSalida.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteSalida.DataField = "Importe"
        Me.TxtImporteSalida.Height = 0.1875!
        Me.TxtImporteSalida.Left = 5.6875!
        Me.TxtImporteSalida.Name = "TxtImporteSalida"
        Me.TxtImporteSalida.OutputFormat = resources.GetString("TxtImporteSalida.OutputFormat")
        Me.TxtImporteSalida.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtImporteSalida.SummaryGroup = "GroupHeader1"
        Me.TxtImporteSalida.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtImporteSalida.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtImporteSalida.Text = Nothing
        Me.TxtImporteSalida.Top = 0.0!
        Me.TxtImporteSalida.Width = 0.6875!
        '
        'TxtImporteEntrada
        '
        Me.TxtImporteEntrada.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtImporteEntrada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteEntrada.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtImporteEntrada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteEntrada.Border.RightColor = System.Drawing.Color.Black
        Me.TxtImporteEntrada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteEntrada.Border.TopColor = System.Drawing.Color.Black
        Me.TxtImporteEntrada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporteEntrada.DataField = "ImporteCompra"
        Me.TxtImporteEntrada.Height = 0.1875!
        Me.TxtImporteEntrada.Left = 4.3125!
        Me.TxtImporteEntrada.Name = "TxtImporteEntrada"
        Me.TxtImporteEntrada.OutputFormat = resources.GetString("TxtImporteEntrada.OutputFormat")
        Me.TxtImporteEntrada.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtImporteEntrada.SummaryGroup = "GroupHeader1"
        Me.TxtImporteEntrada.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtImporteEntrada.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtImporteEntrada.Text = Nothing
        Me.TxtImporteEntrada.Top = 0.0!
        Me.TxtImporteEntrada.Width = 0.6875!
        '
        'TxtCantidadSalida
        '
        Me.TxtCantidadSalida.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantidadSalida.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidadSalida.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantidadSalida.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidadSalida.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantidadSalida.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidadSalida.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantidadSalida.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidadSalida.DataField = "Cantidad"
        Me.TxtCantidadSalida.Height = 0.1875!
        Me.TxtCantidadSalida.Left = 5.0!
        Me.TxtCantidadSalida.Name = "TxtCantidadSalida"
        Me.TxtCantidadSalida.OutputFormat = resources.GetString("TxtCantidadSalida.OutputFormat")
        Me.TxtCantidadSalida.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCantidadSalida.SummaryGroup = "GroupHeader1"
        Me.TxtCantidadSalida.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtCantidadSalida.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtCantidadSalida.Text = Nothing
        Me.TxtCantidadSalida.Top = 0.0!
        Me.TxtCantidadSalida.Width = 0.6875!
        '
        'TxtCantidadEntrada
        '
        Me.TxtCantidadEntrada.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantidadEntrada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidadEntrada.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantidadEntrada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidadEntrada.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantidadEntrada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidadEntrada.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantidadEntrada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidadEntrada.DataField = "CantidadCompra"
        Me.TxtCantidadEntrada.Height = 0.1875!
        Me.TxtCantidadEntrada.Left = 3.625!
        Me.TxtCantidadEntrada.Name = "TxtCantidadEntrada"
        Me.TxtCantidadEntrada.OutputFormat = resources.GetString("TxtCantidadEntrada.OutputFormat")
        Me.TxtCantidadEntrada.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCantidadEntrada.SummaryGroup = "GroupHeader1"
        Me.TxtCantidadEntrada.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtCantidadEntrada.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtCantidadEntrada.Text = Nothing
        Me.TxtCantidadEntrada.Top = 0.0!
        Me.TxtCantidadEntrada.Width = 0.6875!
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
        Me.LblTotalCantidad3.Left = 6.375!
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
        Me.LblTotalImporte3.Left = 7.125!
        Me.LblTotalImporte3.Name = "LblTotalImporte3"
        Me.LblTotalImporte3.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalImporte3.Text = ""
        Me.LblTotalImporte3.Top = 0.0!
        Me.LblTotalImporte3.Width = 0.75!
        '
        'ArepDetalleMovimientoProducto
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=SistemaFacturacionRevetsa;Data Source=JUANBERMUDEZ\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.3!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.3!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.9375!
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
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantidad1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtImporte1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantidad2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtImporte2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCantidadSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblImporteSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSaldoInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtImporteInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtImporteSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtImporteEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantidadSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantidadEntrada, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TxtCodProducto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCodProductos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtSaldoInicial As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtImporteInicial As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTipo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtNumero As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantidad1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtImporte1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantidad2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtImporte2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtImporteSalida As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtImporteEntrada As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantidadSalida As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantidadEntrada As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblTotalCantidad3 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotalImporte3 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCantidadSaldo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblImporteSaldo As DataDynamics.ActiveReports.Label
End Class 
