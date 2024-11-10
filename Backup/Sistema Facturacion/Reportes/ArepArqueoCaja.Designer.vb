<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepArqueoCaja 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ArepArqueoCaja))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.TxtCodCajero = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.TxtNombreCajero = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.TxtNumeroArqueo = New DataDynamics.ActiveReports.TextBox
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.TxtFechaArqueo = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.SubReportDenom1 = New DataDynamics.ActiveReports.SubReport
        Me.SubReportDenom2 = New DataDynamics.ActiveReports.SubReport
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.LblSubTotal2 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.LblSubTotal1 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.LblSumaFact1 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.LblSumaFact2 = New DataDynamics.ActiveReports.Label
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.LblTotalChequeCordobas = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.LblTotalChequeDolares = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.LbltotalCordobasDolares = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.LblMontoRecibidos = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.LblDiferencia = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.LblObservaciones = New DataDynamics.ActiveReports.Label
        Me.LblFirma = New DataDynamics.ActiveReports.Label
        Me.LblArqueadoPor = New DataDynamics.ActiveReports.Label
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNombreCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumeroArqueo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaArqueo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSubTotal2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSubTotal1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSumaFact1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSumaFact2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalChequeCordobas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalChequeDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LbltotalCordobasDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMontoRecibidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDiferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblArqueadoPor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1, Me.TxtCodCajero, Me.Label2, Me.TxtNombreCajero, Me.Label4, Me.TxtNumeroArqueo, Me.Label5, Me.TxtFechaArqueo})
        Me.PageHeader1.Height = 1.84375!
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
        Me.LblTitulo.Width = 6.625!
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
        Me.LblDireccion.Width = 6.625!
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
        Me.LblRuc.Width = 6.625!
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
        Me.TextBox1.Left = 5.4375!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = ""
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.8125!
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
        Me.Label3.Left = 5.125!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "Pag."
        Me.Label3.Top = 0.8125!
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
        Me.Label1.Style = ""
        Me.Label1.Text = "Cajero"
        Me.Label1.Top = 1.1875!
        Me.Label1.Width = 1.0!
        '
        'TxtCodCajero
        '
        Me.TxtCodCajero.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCodCajero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodCajero.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCodCajero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodCajero.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCodCajero.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodCajero.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCodCajero.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodCajero.Height = 0.1875!
        Me.TxtCodCajero.Left = 1.1875!
        Me.TxtCodCajero.Name = "TxtCodCajero"
        Me.TxtCodCajero.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtCodCajero.Text = Nothing
        Me.TxtCodCajero.Top = 1.1875!
        Me.TxtCodCajero.Width = 2.8125!
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
        Me.Label2.Height = 0.1979167!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.1875!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "Nombre Cajero"
        Me.Label2.Top = 1.4375!
        Me.Label2.Width = 1.0!
        '
        'TxtNombreCajero
        '
        Me.TxtNombreCajero.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtNombreCajero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNombreCajero.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtNombreCajero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNombreCajero.Border.RightColor = System.Drawing.Color.Black
        Me.TxtNombreCajero.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNombreCajero.Border.TopColor = System.Drawing.Color.Black
        Me.TxtNombreCajero.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNombreCajero.Height = 0.1875!
        Me.TxtNombreCajero.Left = 1.1875!
        Me.TxtNombreCajero.Name = "TxtNombreCajero"
        Me.TxtNombreCajero.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtNombreCajero.Text = Nothing
        Me.TxtNombreCajero.Top = 1.4375!
        Me.TxtNombreCajero.Width = 2.8125!
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
        Me.Label4.Left = 4.0625!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-weight: bold; background-color: #C0C0FF; font-size: 11.25pt" & _
            "; "
        Me.Label4.Text = "Numero Arqueo"
        Me.Label4.Top = 1.1875!
        Me.Label4.Width = 1.3125!
        '
        'TxtNumeroArqueo
        '
        Me.TxtNumeroArqueo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtNumeroArqueo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroArqueo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtNumeroArqueo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroArqueo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtNumeroArqueo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroArqueo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtNumeroArqueo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroArqueo.Height = 0.1875!
        Me.TxtNumeroArqueo.Left = 5.375!
        Me.TxtNumeroArqueo.Name = "TxtNumeroArqueo"
        Me.TxtNumeroArqueo.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; "
        Me.TxtNumeroArqueo.Text = Nothing
        Me.TxtNumeroArqueo.Top = 1.1875!
        Me.TxtNumeroArqueo.Width = 1.25!
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
        Me.Label5.Left = 4.0625!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label5.Text = "Fecha Arqueo"
        Me.Label5.Top = 1.4375!
        Me.Label5.Width = 1.3125!
        '
        'TxtFechaArqueo
        '
        Me.TxtFechaArqueo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaArqueo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaArqueo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaArqueo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaArqueo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaArqueo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaArqueo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaArqueo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaArqueo.Height = 0.1875!
        Me.TxtFechaArqueo.Left = 5.375!
        Me.TxtFechaArqueo.Name = "TxtFechaArqueo"
        Me.TxtFechaArqueo.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; "
        Me.TxtFechaArqueo.Text = Nothing
        Me.TxtFechaArqueo.Top = 1.4375!
        Me.TxtFechaArqueo.Width = 1.25!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReportDenom1, Me.SubReportDenom2, Me.Label6, Me.Label7, Me.LblSubTotal2, Me.Label8, Me.Label9, Me.LblSubTotal1, Me.Label10, Me.LblSumaFact1, Me.Label12, Me.LblSumaFact2, Me.Label11, Me.Label13, Me.SubReport1, Me.SubReport2, Me.Label14, Me.LblTotalChequeCordobas, Me.Label15, Me.LblTotalChequeDolares})
        Me.Detail1.Height = 1.40625!
        Me.Detail1.Name = "Detail1"
        '
        'SubReportDenom1
        '
        Me.SubReportDenom1.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportDenom1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDenom1.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportDenom1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDenom1.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportDenom1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDenom1.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportDenom1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDenom1.CloseBorder = False
        Me.SubReportDenom1.Height = 0.25!
        Me.SubReportDenom1.Left = 0.375!
        Me.SubReportDenom1.Name = "SubReportDenom1"
        Me.SubReportDenom1.Report = Nothing
        Me.SubReportDenom1.ReportName = ""
        Me.SubReportDenom1.Top = 0.1875!
        Me.SubReportDenom1.Width = 2.4375!
        '
        'SubReportDenom2
        '
        Me.SubReportDenom2.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportDenom2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDenom2.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportDenom2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDenom2.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportDenom2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDenom2.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportDenom2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDenom2.CloseBorder = False
        Me.SubReportDenom2.Height = 0.25!
        Me.SubReportDenom2.Left = 3.8125!
        Me.SubReportDenom2.Name = "SubReportDenom2"
        Me.SubReportDenom2.Report = Nothing
        Me.SubReportDenom2.ReportName = ""
        Me.SubReportDenom2.Top = 0.1875!
        Me.SubReportDenom2.Width = 2.4375!
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
        Me.Label6.Left = 1.75!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label6.Text = "Sub Total"
        Me.Label6.Top = 0.4375!
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
        Me.Label7.Left = 5.125!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label7.Text = "Sub Total"
        Me.Label7.Top = 0.4375!
        Me.Label7.Width = 0.5625!
        '
        'LblSubTotal2
        '
        Me.LblSubTotal2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSubTotal2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSubTotal2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal2.Border.RightColor = System.Drawing.Color.Black
        Me.LblSubTotal2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal2.Border.TopColor = System.Drawing.Color.Black
        Me.LblSubTotal2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal2.Height = 0.1875!
        Me.LblSubTotal2.HyperLink = Nothing
        Me.LblSubTotal2.Left = 5.6875!
        Me.LblSubTotal2.Name = "LblSubTotal2"
        Me.LblSubTotal2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblSubTotal2.Text = ""
        Me.LblSubTotal2.Top = 0.4375!
        Me.LblSubTotal2.Width = 0.5625!
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
        Me.Label8.Left = 0.375!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; background-color: #C0C0FF" & _
            "; font-size: 9.75pt; "
        Me.Label8.Text = "Denominacion Cordobas"
        Me.Label8.Top = 0.0!
        Me.Label8.Width = 2.4375!
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
        Me.Label9.Left = 3.8125!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; background-color: #C0C0FF" & _
            "; font-size: 9.75pt; "
        Me.Label9.Text = "Denominacion Dolares"
        Me.Label9.Top = 0.0!
        Me.Label9.Width = 2.4375!
        '
        'LblSubTotal1
        '
        Me.LblSubTotal1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSubTotal1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSubTotal1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal1.Border.RightColor = System.Drawing.Color.Black
        Me.LblSubTotal1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal1.Border.TopColor = System.Drawing.Color.Black
        Me.LblSubTotal1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal1.Height = 0.1875!
        Me.LblSubTotal1.HyperLink = Nothing
        Me.LblSubTotal1.Left = 2.3125!
        Me.LblSubTotal1.Name = "LblSubTotal1"
        Me.LblSubTotal1.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblSubTotal1.Text = ""
        Me.LblSubTotal1.Top = 0.4375!
        Me.LblSubTotal1.Width = 0.5!
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
        Me.Label10.Left = 0.375!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label10.Text = "Fac/Rec"
        Me.Label10.Top = 0.4375!
        Me.Label10.Width = 0.5!
        '
        'LblSumaFact1
        '
        Me.LblSumaFact1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSumaFact1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSumaFact1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSumaFact1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSumaFact1.Border.RightColor = System.Drawing.Color.Black
        Me.LblSumaFact1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSumaFact1.Border.TopColor = System.Drawing.Color.Black
        Me.LblSumaFact1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSumaFact1.Height = 0.1875!
        Me.LblSumaFact1.HyperLink = Nothing
        Me.LblSumaFact1.Left = 0.875!
        Me.LblSumaFact1.Name = "LblSumaFact1"
        Me.LblSumaFact1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.LblSumaFact1.Text = ""
        Me.LblSumaFact1.Top = 0.4375!
        Me.LblSumaFact1.Width = 0.5!
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
        Me.Label12.Left = 3.8125!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label12.Text = "Fac/Rec"
        Me.Label12.Top = 0.4375!
        Me.Label12.Width = 0.5!
        '
        'LblSumaFact2
        '
        Me.LblSumaFact2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSumaFact2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSumaFact2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSumaFact2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSumaFact2.Border.RightColor = System.Drawing.Color.Black
        Me.LblSumaFact2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSumaFact2.Border.TopColor = System.Drawing.Color.Black
        Me.LblSumaFact2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSumaFact2.Height = 0.1875!
        Me.LblSumaFact2.HyperLink = Nothing
        Me.LblSumaFact2.Left = 4.3125!
        Me.LblSumaFact2.Name = "LblSumaFact2"
        Me.LblSumaFact2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.LblSumaFact2.Text = ""
        Me.LblSumaFact2.Top = 0.4375!
        Me.LblSumaFact2.Width = 0.5!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label16, Me.LbltotalCordobasDolares, Me.Label18, Me.LblMontoRecibidos, Me.Label20, Me.LblDiferencia, Me.Label17, Me.LblObservaciones, Me.LblFirma, Me.LblArqueadoPor})
        Me.PageFooter1.Height = 1.3125!
        Me.PageFooter1.Name = "PageFooter1"
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
        Me.Label11.Left = 0.0625!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; background-color: #C0C0FF" & _
            "; font-size: 9.75pt; "
        Me.Label11.Text = "Detelle Cheque/Recibos Cordobas"
        Me.Label11.Top = 0.75!
        Me.Label11.Width = 3.25!
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
        Me.Label13.Left = 3.375!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; background-color: #C0C0FF" & _
            "; font-size: 9.75pt; "
        Me.Label13.Text = "Detelle Cheque/Recibos Dolares"
        Me.Label13.Top = 0.75!
        Me.Label13.Width = 3.25!
        '
        'SubReport1
        '
        Me.SubReport1.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.RightColor = System.Drawing.Color.Black
        Me.SubReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.TopColor = System.Drawing.Color.Black
        Me.SubReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.25!
        Me.SubReport1.Left = 0.0625!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = ""
        Me.SubReport1.Top = 0.9375!
        Me.SubReport1.Width = 3.25!
        '
        'SubReport2
        '
        Me.SubReport2.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReport2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReport2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.RightColor = System.Drawing.Color.Black
        Me.SubReport2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.TopColor = System.Drawing.Color.Black
        Me.SubReport2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.CloseBorder = False
        Me.SubReport2.Height = 0.25!
        Me.SubReport2.Left = 3.375!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.ReportName = ""
        Me.SubReport2.Top = 0.9375!
        Me.SubReport2.Width = 3.25!
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
        Me.Label14.Left = 0.5!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label14.Text = "Total Cheques mas Tarjetas Cordobas"
        Me.Label14.Top = 1.1875!
        Me.Label14.Width = 2.125!
        '
        'LblTotalChequeCordobas
        '
        Me.LblTotalChequeCordobas.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalChequeCordobas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalChequeCordobas.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalChequeCordobas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalChequeCordobas.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalChequeCordobas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalChequeCordobas.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalChequeCordobas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalChequeCordobas.Height = 0.1875!
        Me.LblTotalChequeCordobas.HyperLink = Nothing
        Me.LblTotalChequeCordobas.Left = 2.625!
        Me.LblTotalChequeCordobas.Name = "LblTotalChequeCordobas"
        Me.LblTotalChequeCordobas.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalChequeCordobas.Text = ""
        Me.LblTotalChequeCordobas.Top = 1.1875!
        Me.LblTotalChequeCordobas.Width = 0.6875!
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
        Me.Label15.Left = 4.0!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label15.Text = "Total Cheques mas Tarjetas Dolares"
        Me.Label15.Top = 1.1875!
        Me.Label15.Width = 1.9375!
        '
        'LblTotalChequeDolares
        '
        Me.LblTotalChequeDolares.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalChequeDolares.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalChequeDolares.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalChequeDolares.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalChequeDolares.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalChequeDolares.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalChequeDolares.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalChequeDolares.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalChequeDolares.Height = 0.1875!
        Me.LblTotalChequeDolares.HyperLink = Nothing
        Me.LblTotalChequeDolares.Left = 5.9375!
        Me.LblTotalChequeDolares.Name = "LblTotalChequeDolares"
        Me.LblTotalChequeDolares.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotalChequeDolares.Text = ""
        Me.LblTotalChequeDolares.Top = 1.1875!
        Me.LblTotalChequeDolares.Width = 0.6875!
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
        Me.Label16.Left = 4.1875!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label16.Text = "Total Cordobas mas Dolares"
        Me.Label16.Top = 0.0!
        Me.Label16.Width = 1.5!
        '
        'LbltotalCordobasDolares
        '
        Me.LbltotalCordobasDolares.Border.BottomColor = System.Drawing.Color.Black
        Me.LbltotalCordobasDolares.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LbltotalCordobasDolares.Border.LeftColor = System.Drawing.Color.Black
        Me.LbltotalCordobasDolares.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LbltotalCordobasDolares.Border.RightColor = System.Drawing.Color.Black
        Me.LbltotalCordobasDolares.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LbltotalCordobasDolares.Border.TopColor = System.Drawing.Color.Black
        Me.LbltotalCordobasDolares.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LbltotalCordobasDolares.Height = 0.1875!
        Me.LbltotalCordobasDolares.HyperLink = Nothing
        Me.LbltotalCordobasDolares.Left = 5.6875!
        Me.LbltotalCordobasDolares.Name = "LbltotalCordobasDolares"
        Me.LbltotalCordobasDolares.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LbltotalCordobasDolares.Text = ""
        Me.LbltotalCordobasDolares.Top = 0.0!
        Me.LbltotalCordobasDolares.Width = 0.9375!
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
        Me.Label18.Left = 4.1875!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label18.Text = "Montos Recibidos"
        Me.Label18.Top = 0.1875!
        Me.Label18.Width = 1.5!
        '
        'LblMontoRecibidos
        '
        Me.LblMontoRecibidos.Border.BottomColor = System.Drawing.Color.Black
        Me.LblMontoRecibidos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMontoRecibidos.Border.LeftColor = System.Drawing.Color.Black
        Me.LblMontoRecibidos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMontoRecibidos.Border.RightColor = System.Drawing.Color.Black
        Me.LblMontoRecibidos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMontoRecibidos.Border.TopColor = System.Drawing.Color.Black
        Me.LblMontoRecibidos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMontoRecibidos.Height = 0.1875!
        Me.LblMontoRecibidos.HyperLink = Nothing
        Me.LblMontoRecibidos.Left = 5.6875!
        Me.LblMontoRecibidos.Name = "LblMontoRecibidos"
        Me.LblMontoRecibidos.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblMontoRecibidos.Text = ""
        Me.LblMontoRecibidos.Top = 0.1875!
        Me.LblMontoRecibidos.Width = 0.9375!
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
        Me.Label20.Height = 0.1875!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 4.1875!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label20.Text = "Diferencia"
        Me.Label20.Top = 0.375!
        Me.Label20.Width = 1.5!
        '
        'LblDiferencia
        '
        Me.LblDiferencia.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDiferencia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDiferencia.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDiferencia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDiferencia.Border.RightColor = System.Drawing.Color.Black
        Me.LblDiferencia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDiferencia.Border.TopColor = System.Drawing.Color.Black
        Me.LblDiferencia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDiferencia.Height = 0.1875!
        Me.LblDiferencia.HyperLink = Nothing
        Me.LblDiferencia.Left = 5.6875!
        Me.LblDiferencia.Name = "LblDiferencia"
        Me.LblDiferencia.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblDiferencia.Text = ""
        Me.LblDiferencia.Top = 0.375!
        Me.LblDiferencia.Width = 0.9375!
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
        Me.Label17.Height = 0.1979167!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.125!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = ""
        Me.Label17.Text = "Observaciones"
        Me.Label17.Top = 0.0625!
        Me.Label17.Width = 1.0!
        '
        'LblObservaciones
        '
        Me.LblObservaciones.Border.BottomColor = System.Drawing.Color.Black
        Me.LblObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblObservaciones.Border.LeftColor = System.Drawing.Color.Black
        Me.LblObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblObservaciones.Border.RightColor = System.Drawing.Color.Black
        Me.LblObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblObservaciones.Border.TopColor = System.Drawing.Color.Black
        Me.LblObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblObservaciones.Height = 0.5!
        Me.LblObservaciones.HyperLink = Nothing
        Me.LblObservaciones.Left = 1.125!
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblObservaciones.Text = ""
        Me.LblObservaciones.Top = 0.0625!
        Me.LblObservaciones.Width = 1.9375!
        '
        'LblFirma
        '
        Me.LblFirma.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFirma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFirma.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFirma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFirma.Border.RightColor = System.Drawing.Color.Black
        Me.LblFirma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFirma.Border.TopColor = System.Drawing.Color.Black
        Me.LblFirma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblFirma.Height = 0.1875!
        Me.LblFirma.HyperLink = Nothing
        Me.LblFirma.Left = 0.4375!
        Me.LblFirma.Name = "LblFirma"
        Me.LblFirma.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblFirma.Text = "Firma Cajero"
        Me.LblFirma.Top = 1.0!
        Me.LblFirma.Width = 2.3125!
        '
        'LblArqueadoPor
        '
        Me.LblArqueadoPor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblArqueadoPor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblArqueadoPor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblArqueadoPor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblArqueadoPor.Border.RightColor = System.Drawing.Color.Black
        Me.LblArqueadoPor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblArqueadoPor.Border.TopColor = System.Drawing.Color.Black
        Me.LblArqueadoPor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblArqueadoPor.Height = 0.1875!
        Me.LblArqueadoPor.HyperLink = Nothing
        Me.LblArqueadoPor.Left = 3.625!
        Me.LblArqueadoPor.Name = "LblArqueadoPor"
        Me.LblArqueadoPor.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblArqueadoPor.Text = "Arqueado Por"
        Me.LblArqueadoPor.Top = 1.0!
        Me.LblArqueadoPor.Width = 2.5625!
        '
        'ArepArqueoCaja
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaFacturacion;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = "Select * from"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.6!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.6!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.697917!
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
        CType(Me.TxtCodCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNombreCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumeroArqueo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaArqueo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSubTotal2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSubTotal1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSumaFact1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSumaFact2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalChequeCordobas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalChequeDolares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LbltotalCordobasDolares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMontoRecibidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDiferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblArqueadoPor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCodCajero As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtNombreCajero As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtNumeroArqueo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtFechaArqueo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReportDenom1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents SubReportDenom2 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSubTotal1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSubTotal2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSumaFact1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSumaFact2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents SubReport2 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotalChequeCordobas As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotalChequeDolares As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents LbltotalCordobasDolares As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMontoRecibidos As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDiferencia As DataDynamics.ActiveReports.Label
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblObservaciones As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFirma As DataDynamics.ActiveReports.Label
    Friend WithEvents LblArqueadoPor As DataDynamics.ActiveReports.Label
End Class 
