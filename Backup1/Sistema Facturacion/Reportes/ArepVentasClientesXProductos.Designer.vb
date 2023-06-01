<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepVentasClientesXProductos 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepVentasClientesXProductos))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.LblMoneda = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.TxtCodBodega = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.TxtNombreBodega = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNombreBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1, Me.Label7, Me.Label2, Me.Line1, Me.Label4, Me.Line2, Me.Label14, Me.Label6, Me.Label8, Me.LblMoneda, Me.Label5, Me.Label9})
        Me.PageHeader1.Height = 1.701389!
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
        Me.LblTitulo.Text = "Systems And Solutions"
        Me.LblTitulo.Top = 0.0625!
        Me.LblTitulo.Width = 7.4375!
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
        Me.LblDireccion.Width = 7.4375!
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
        Me.LblRuc.Width = 7.4375!
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
        Me.TextBox1.Left = 7.0!
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
        Me.Label3.Left = 6.6875!
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
        Me.Label1.Text = "Ventas de Productos al Contado"
        Me.Label1.Top = 0.6875!
        Me.Label1.Width = 7.4375!
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
        Me.Label7.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label7.Text = "Impreso:"
        Me.Label7.Top = 1.125!
        Me.Label7.Width = 5.6875!
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
        Me.Label2.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label2.Text = "Cod Producto"
        Me.Label2.Top = 1.4375!
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
        Me.Line1.Left = 0.125!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.375!
        Me.Line1.Width = 7.375!
        Me.Line1.X1 = 0.125!
        Me.Line1.X2 = 7.5!
        Me.Line1.Y1 = 1.375!
        Me.Line1.Y2 = 1.375!
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
        Me.Label4.Left = 1.0625!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label4.Text = "Descripcion del Producto"
        Me.Label4.Top = 1.4375!
        Me.Label4.Width = 2.4375!
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
        Me.Line2.Left = 0.125!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.6875!
        Me.Line2.Width = 7.375!
        Me.Line2.X1 = 0.125!
        Me.Line2.X2 = 7.5!
        Me.Line2.Y1 = 1.6875!
        Me.Line2.Y2 = 1.6875!
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
        Me.Label14.Left = 5.0625!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label14.Text = "Valor"
        Me.Label14.Top = 1.4375!
        Me.Label14.Width = 0.9375!
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
        Me.Label6.Left = 6.0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label6.Text = "Utilidad"
        Me.Label6.Top = 1.4375!
        Me.Label6.Width = 0.9375!
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
        Me.Label8.Left = 6.9375!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial Black; "
        Me.Label8.Text = "%"
        Me.Label8.Top = 1.4375!
        Me.Label8.Width = 0.5625!
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
        Me.LblMoneda.Height = 0.2105263!
        Me.LblMoneda.HyperLink = Nothing
        Me.LblMoneda.Left = 0.0!
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.LblMoneda.Text = "Expresado en Cordobas"
        Me.LblMoneda.Top = 0.8947368!
        Me.LblMoneda.Width = 7.473684!
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
        Me.Label5.Left = 4.1875!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label5.Text = "Precio Unt"
        Me.Label5.Top = 1.4375!
        Me.Label5.Width = 0.875!
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
        Me.Label9.Left = 3.5!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label9.Text = "Cantidad"
        Me.Label9.Top = 1.4375!
        Me.Label9.Width = 0.6875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox4, Me.TextBox3, Me.TextBox2, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox9})
        Me.Detail1.Height = 0.21875!
        Me.Detail1.Name = "Detail1"
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
        Me.TextBox4.DataField = "Descripcion_Producto"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 1.0625!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 2.4375!
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
        Me.TextBox3.Left = 3.5!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.6875!
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
        Me.TextBox2.DataField = "Cod_Producto"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 0.1875!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.875!
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
        Me.TextBox5.DataField = "Importe"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 5.0625!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.9375!
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
        Me.TextBox6.DataField = "Costo"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 5.375!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.9375!
        Me.TextBox6.Visible = False
        Me.TextBox6.Width = 0.875!
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
        Me.TextBox7.DataField = "Utilidad"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 6.0!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.9375!
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
        Me.TextBox8.DataField = "Porciento"
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 6.9375!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.5625!
        '
        'TextBox10
        '
        Me.TextBox10.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.DataField = "Importe"
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 5.0625!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.9375!
        '
        'TextBox11
        '
        Me.TextBox11.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox11.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox11.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox11.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox11.DataField = "Costo"
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 4.0625!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 1.0625!
        Me.TextBox11.Visible = False
        Me.TextBox11.Width = 0.875!
        '
        'TextBox12
        '
        Me.TextBox12.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox12.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox12.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox12.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox12.DataField = "Utilidad"
        Me.TextBox12.Height = 0.1875!
        Me.TextBox12.Left = 6.0!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
        Me.TextBox12.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0.0!
        Me.TextBox12.Width = 0.9375!
        '
        'TextBox9
        '
        Me.TextBox9.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.DataField = "Precio_Unitario"
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 4.1875!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 0.875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtCodBodega, Me.Label10, Me.Label11, Me.TxtNombreBodega})
        Me.GroupHeader1.DataField = "Cod_Cliente"
        Me.GroupHeader1.Height = 0.25!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'TxtCodBodega
        '
        Me.TxtCodBodega.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCodBodega.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodBodega.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCodBodega.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodBodega.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCodBodega.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodBodega.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCodBodega.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodBodega.DataField = "Cod_Cliente"
        Me.TxtCodBodega.Height = 0.1875!
        Me.TxtCodBodega.Left = 1.25!
        Me.TxtCodBodega.Name = "TxtCodBodega"
        Me.TxtCodBodega.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtCodBodega.Text = Nothing
        Me.TxtCodBodega.Top = 0.0!
        Me.TxtCodBodega.Width = 0.875!
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
        Me.Label10.Left = 0.3125!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label10.Text = "Codigo Cliente"
        Me.Label10.Top = 0.0!
        Me.Label10.Width = 0.9375!
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
        Me.Label11.Left = 2.3125!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label11.Text = "Nombre Cliente"
        Me.Label11.Top = 0.0!
        Me.Label11.Width = 1.0!
        '
        'TxtNombreBodega
        '
        Me.TxtNombreBodega.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtNombreBodega.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNombreBodega.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtNombreBodega.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNombreBodega.Border.RightColor = System.Drawing.Color.Black
        Me.TxtNombreBodega.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNombreBodega.Border.TopColor = System.Drawing.Color.Black
        Me.TxtNombreBodega.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNombreBodega.DataField = "Nombre_Cliente"
        Me.TxtNombreBodega.Height = 0.1875!
        Me.TxtNombreBodega.Left = 3.3125!
        Me.TxtNombreBodega.Name = "TxtNombreBodega"
        Me.TxtNombreBodega.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtNombreBodega.Text = Nothing
        Me.TxtNombreBodega.Top = 0.0!
        Me.TxtNombreBodega.Width = 3.875!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label12, Me.TextBox13, Me.TextBox14, Me.TextBox15})
        Me.GroupFooter1.Height = 0.2916667!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.Label12.Left = 0.375!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label12.Text = "Total Cliente"
        Me.Label12.Top = 0.0!
        Me.Label12.Visible = False
        Me.Label12.Width = 0.8125!
        '
        'TextBox13
        '
        Me.TextBox13.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox13.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox13.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox13.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox13.DataField = "Nombre_Cliente"
        Me.TextBox13.Height = 0.1875!
        Me.TextBox13.Left = 1.25!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0.0!
        Me.TextBox13.Visible = False
        Me.TextBox13.Width = 2.25!
        '
        'TextBox14
        '
        Me.TextBox14.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.DataField = "Cantidad"
        Me.TextBox14.Height = 0.1875!
        Me.TextBox14.Left = 3.5!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat")
        Me.TextBox14.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox14.SummaryGroup = "GroupHeader1"
        Me.TextBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = 0.0!
        Me.TextBox14.Width = 0.6875!
        '
        'TextBox15
        '
        Me.TextBox15.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.DataField = "Importe"
        Me.TextBox15.Height = 0.1875!
        Me.TextBox15.Left = 5.0625!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat")
        Me.TextBox15.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox15.SummaryGroup = "GroupHeader1"
        Me.TextBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox15.Text = Nothing
        Me.TextBox15.Top = 0.0!
        Me.TextBox15.Width = 0.9375!
        '
        'ArepVentasClientesXProductos
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=sa;Persist Security Info=True;User ID=sa;Initial Cat" & _
            "alog=SistemaFacturacionRevetsa;Data Source=JUAN\SQL2012"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.3!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.3!
        Me.PageSettings.Margins.Top = 0.3!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.572917!
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
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNombreBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMoneda As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TxtCodBodega As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtNombreBodega As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
End Class 
