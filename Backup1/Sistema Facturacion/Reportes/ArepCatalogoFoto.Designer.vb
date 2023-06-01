<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepCatalogoFoto 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepCatalogoFoto))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.ImgProducto = New DataDynamics.ActiveReports.Picture
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.TxtCodigoProducto = New DataDynamics.ActiveReports.TextBox
        Me.lblProductName = New DataDynamics.ActiveReports.Label
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.lblQty = New DataDynamics.ActiveReports.Label
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigoProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1})
        Me.PageHeader1.Height = 1.145833!
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
        Me.LblTitulo.Text = "SOLINFO"
        Me.LblTitulo.Top = 0.0625!
        Me.LblTitulo.Width = 6.6875!
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
        Me.LblDireccion.Width = 6.6875!
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
        Me.LblRuc.Width = 6.6875!
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
        Me.TextBox1.Left = 6.1875!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = ""
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
        Me.Label3.Left = 5.875!
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
        Me.Label1.Text = "Catalogo de Productos x Fotos"
        Me.Label1.Top = 0.6875!
        Me.Label1.Width = 6.6875!
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgProducto, Me.lblProductID, Me.TxtCodigoProducto, Me.lblProductName, Me.TextBox3, Me.Label2, Me.TextBox5, Me.lblQty, Me.TextBox4, Me.Label4, Me.TextBox6, Me.Label5, Me.TextBox7, Me.Line1, Me.Line2})
        Me.Detail1.Height = 1.145833!
        Me.Detail1.KeepTogether = True
        Me.Detail1.Name = "Detail1"
        '
        'ImgProducto
        '
        Me.ImgProducto.Border.BottomColor = System.Drawing.Color.Black
        Me.ImgProducto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgProducto.Border.LeftColor = System.Drawing.Color.Black
        Me.ImgProducto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgProducto.Border.RightColor = System.Drawing.Color.Black
        Me.ImgProducto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgProducto.Border.TopColor = System.Drawing.Color.Black
        Me.ImgProducto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgProducto.Height = 1.0!
        Me.ImgProducto.Image = CType(resources.GetObject("ImgProducto.Image"), System.Drawing.Image)
        Me.ImgProducto.ImageData = CType(resources.GetObject("ImgProducto.ImageData"), System.IO.Stream)
        Me.ImgProducto.Left = 0.125!
        Me.ImgProducto.LineWeight = 0.0!
        Me.ImgProducto.Name = "ImgProducto"
        Me.ImgProducto.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgProducto.Top = 0.0625!
        Me.ImgProducto.Width = 1.25!
        '
        'lblProductID
        '
        Me.lblProductID.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductID.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductID.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductID.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductID.Height = 0.1875!
        Me.lblProductID.HyperLink = Nothing
        Me.lblProductID.Left = 1.4375!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: rgb(255,255,255); text-align: center; font-weight: bold; background-color:" & _
            " #8080FF; font-size: 8.5pt; "
        Me.lblProductID.Text = "Product ID"
        Me.lblProductID.Top = 0.0625!
        Me.lblProductID.Width = 0.8125!
        '
        'TxtCodigoProducto
        '
        Me.TxtCodigoProducto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCodigoProducto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigoProducto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCodigoProducto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigoProducto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCodigoProducto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigoProducto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCodigoProducto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigoProducto.DataField = "Cod_Productos"
        Me.TxtCodigoProducto.Height = 0.1875!
        Me.TxtCodigoProducto.Left = 2.3125!
        Me.TxtCodigoProducto.Name = "TxtCodigoProducto"
        Me.TxtCodigoProducto.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtCodigoProducto.Text = Nothing
        Me.TxtCodigoProducto.Top = 0.0625!
        Me.TxtCodigoProducto.Width = 0.8125!
        '
        'lblProductName
        '
        Me.lblProductName.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductName.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductName.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductName.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductName.Height = 0.1875!
        Me.lblProductName.HyperLink = Nothing
        Me.lblProductName.Left = 1.4375!
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Style = "color: rgb(255,255,255); text-align: center; font-weight: bold; background-color:" & _
            " #8080FF; font-size: 8.5pt; "
        Me.lblProductName.Text = "Nombre Producto"
        Me.lblProductName.Top = 0.3125!
        Me.lblProductName.Width = 1.125!
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
        Me.TextBox3.Left = 2.625!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.3125!
        Me.TextBox3.Width = 4.0!
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
        Me.Label2.Left = 3.5!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: rgb(255,255,255); ddo-char-set: 0; text-align: center; font-weight: bold; " & _
            "background-color: #8080FF; font-size: 8.25pt; "
        Me.Label2.Text = "Precio Venta"
        Me.Label2.Top = 0.0625!
        Me.Label2.Width = 0.875!
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
        Me.TextBox5.DataField = "Precio_Venta"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 4.4375!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0625!
        Me.TextBox5.Width = 0.9375!
        '
        'lblQty
        '
        Me.lblQty.Border.BottomColor = System.Drawing.Color.Black
        Me.lblQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblQty.Border.LeftColor = System.Drawing.Color.Black
        Me.lblQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblQty.Border.RightColor = System.Drawing.Color.Black
        Me.lblQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblQty.Border.TopColor = System.Drawing.Color.Black
        Me.lblQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblQty.Height = 0.1875!
        Me.lblQty.HyperLink = Nothing
        Me.lblQty.Left = 1.4375!
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Style = "color: rgb(255,255,255); ddo-char-set: 0; text-align: center; font-weight: bold; " & _
            "background-color: #8080FF; font-size: 8.25pt; "
        Me.lblQty.Text = "Existencia"
        Me.lblQty.Top = 0.5625!
        Me.lblQty.Width = 0.75!
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
        Me.TextBox4.DataField = "Existencia_Unidades"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 2.25!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.5625!
        Me.TextBox4.Width = 0.625!
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
        Me.Label4.Style = "color: rgb(255,255,255); ddo-char-set: 0; text-align: center; font-weight: bold; " & _
            "background-color: #8080FF; font-size: 8.25pt; "
        Me.Label4.Text = "Activo"
        Me.Label4.Top = 0.5625!
        Me.Label4.Width = 0.5625!
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
        Me.TextBox6.DataField = "Activo"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 4.125!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.5625!
        Me.TextBox6.Width = 0.75!
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
        Me.Label5.Left = 1.4375!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: rgb(255,255,255); ddo-char-set: 0; text-align: center; font-weight: bold; " & _
            "background-color: #8080FF; font-size: 8.25pt; "
        Me.Label5.Text = "Ubicacion"
        Me.Label5.Top = 0.8125!
        Me.Label5.Width = 0.9375!
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
        Me.TextBox7.DataField = "Ubicacion"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 2.4375!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.8125!
        Me.TextBox7.Width = 2.9375!
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
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 6.5!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 6.5625!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.0!
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
        Me.Line2.Top = 1.125!
        Me.Line2.Width = 6.5!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 6.5625!
        Me.Line2.Y1 = 1.125!
        Me.Line2.Y2 = 1.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ArepCatalogoFoto
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB;Integrated Security=SSPI;Persist Security Info=False;Initial Ca" & _
            "talog=SistemaFacturacion;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = "SELECT     *" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         Productos"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.75!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
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
        CType(Me.ImgProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigoProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgProducto As DataDynamics.ActiveReports.Picture
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCodigoProducto As DataDynamics.ActiveReports.TextBox
    Private WithEvents lblProductName As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Private WithEvents lblQty As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
End Class 
