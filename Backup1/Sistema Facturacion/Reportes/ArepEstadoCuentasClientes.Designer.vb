<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepEstadoCuentasClientes 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepEstadoCuentasClientes))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.LblImpreso = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TxtDebito = New DataDynamics.ActiveReports.TextBox
        Me.TxtCredito = New DataDynamics.ActiveReports.TextBox
        Me.TxtBalance = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.LblNombre = New DataDynamics.ActiveReports.Label
        Me.LblCodigo = New DataDynamics.ActiveReports.Label
        Me.LblDesde = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.TxtCodigoCliente = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TxtSaldoInicial = New DataDynamics.ActiveReports.TextBox
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.LblMoneda = New DataDynamics.ActiveReports.Label
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblImpreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDebito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSaldoInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1, Me.LblImpreso, Me.LblMoneda})
        Me.PageHeader1.Height = 1.447917!
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
        Me.ImgLogo.Width = 1.5!
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
        Me.TextBox1.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 1.225!
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
        Me.Label3.Left = 6.675001!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "Pag."
        Me.Label3.Top = 1.225!
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
        Me.Label1.Text = "Estado de Cuenta x Cliente"
        Me.Label1.Top = 0.6875!
        Me.Label1.Width = 7.4375!
        '
        'LblImpreso
        '
        Me.LblImpreso.Border.BottomColor = System.Drawing.Color.Black
        Me.LblImpreso.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImpreso.Border.LeftColor = System.Drawing.Color.Black
        Me.LblImpreso.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImpreso.Border.RightColor = System.Drawing.Color.Black
        Me.LblImpreso.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImpreso.Border.TopColor = System.Drawing.Color.Black
        Me.LblImpreso.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImpreso.Height = 0.1875!
        Me.LblImpreso.HyperLink = Nothing
        Me.LblImpreso.Left = 0.0!
        Me.LblImpreso.Name = "LblImpreso"
        Me.LblImpreso.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.LblImpreso.Text = "Impreso:"
        Me.LblImpreso.Top = 1.225!
        Me.LblImpreso.Width = 5.4375!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtDebito, Me.TxtCredito, Me.TxtBalance, Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox13})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'TxtDebito
        '
        Me.TxtDebito.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtDebito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDebito.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtDebito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDebito.Border.RightColor = System.Drawing.Color.Black
        Me.TxtDebito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDebito.Border.TopColor = System.Drawing.Color.Black
        Me.TxtDebito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDebito.DataField = "Debito"
        Me.TxtDebito.Height = 0.1875!
        Me.TxtDebito.Left = 4.875!
        Me.TxtDebito.Name = "TxtDebito"
        Me.TxtDebito.OutputFormat = resources.GetString("TxtDebito.OutputFormat")
        Me.TxtDebito.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; "
        Me.TxtDebito.Text = Nothing
        Me.TxtDebito.Top = 0.0!
        Me.TxtDebito.Width = 0.875!
        '
        'TxtCredito
        '
        Me.TxtCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCredito.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCredito.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCredito.DataField = "Credito"
        Me.TxtCredito.Height = 0.1875!
        Me.TxtCredito.Left = 5.75!
        Me.TxtCredito.Name = "TxtCredito"
        Me.TxtCredito.OutputFormat = resources.GetString("TxtCredito.OutputFormat")
        Me.TxtCredito.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; "
        Me.TxtCredito.Text = Nothing
        Me.TxtCredito.Top = 0.0!
        Me.TxtCredito.Width = 0.875!
        '
        'TxtBalance
        '
        Me.TxtBalance.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBalance.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBalance.Border.RightColor = System.Drawing.Color.Black
        Me.TxtBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBalance.Border.TopColor = System.Drawing.Color.Black
        Me.TxtBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBalance.Height = 0.1875!
        Me.TxtBalance.Left = 6.625!
        Me.TxtBalance.Name = "TxtBalance"
        Me.TxtBalance.OutputFormat = resources.GetString("TxtBalance.OutputFormat")
        Me.TxtBalance.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; "
        Me.TxtBalance.Text = Nothing
        Me.TxtBalance.Top = 0.0!
        Me.TxtBalance.Width = 0.875!
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
        Me.TextBox10.DataField = "Concepto"
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 2.375!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 2.5!
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
        Me.TextBox11.DataField = "Fecha"
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 0.125!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.75!
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
        Me.TextBox12.DataField = "Numero"
        Me.TextBox12.Height = 0.1875!
        Me.TextBox12.Left = 0.875!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0.0!
        Me.TextBox12.Width = 0.75!
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
        Me.TextBox13.DataField = "TipoDocumento"
        Me.TextBox13.Height = 0.1875!
        Me.TextBox13.Left = 1.625!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0.0!
        Me.TextBox13.Width = 0.75!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblNombre, Me.LblCodigo, Me.LblDesde, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.TxtCodigoCliente, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TxtSaldoInicial, Me.Label13})
        Me.GroupHeader1.DataField = "Cod_Cliente"
        Me.GroupHeader1.Height = 1.333333!
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.LblNombre.Left = 0.125!
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.LblNombre.Text = "Nombre de Cliente:"
        Me.LblNombre.Top = 0.3125!
        Me.LblNombre.Width = 1.25!
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
        Me.LblCodigo.Left = 0.125!
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; "
        Me.LblCodigo.Text = "Codigo de Cliente:"
        Me.LblCodigo.Top = 0.0625!
        Me.LblCodigo.Width = 1.25!
        '
        'LblDesde
        '
        Me.LblDesde.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDesde.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDesde.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDesde.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDesde.Border.RightColor = System.Drawing.Color.Black
        Me.LblDesde.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDesde.Border.TopColor = System.Drawing.Color.Black
        Me.LblDesde.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDesde.Height = 0.1875!
        Me.LblDesde.HyperLink = Nothing
        Me.LblDesde.Left = 0.125!
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.LblDesde.Text = "Desde"
        Me.LblDesde.Top = 0.5625!
        Me.LblDesde.Width = 6.6875!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.125!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label6.Text = "FECHA"
        Me.Label6.Top = 0.875!
        Me.Label6.Width = 0.75!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.875!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label7.Text = "NUMERO"
        Me.Label7.Top = 0.875!
        Me.Label7.Width = 0.75!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 1.625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label8.Text = "T DOC"
        Me.Label8.Top = 0.875!
        Me.Label8.Width = 0.75!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 2.375!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label9.Text = "CONCEPTO"
        Me.Label9.Top = 0.875!
        Me.Label9.Width = 2.5!
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
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 4.875!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label10.Text = "DEBITO"
        Me.Label10.Top = 0.875!
        Me.Label10.Width = 0.875!
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
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 5.75!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label11.Text = "CREDITO"
        Me.Label11.Top = 0.875!
        Me.Label11.Width = 0.875!
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
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 6.625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label12.Text = "BALANCE"
        Me.Label12.Top = 0.875!
        Me.Label12.Width = 0.875!
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCodigoCliente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigoCliente.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCodigoCliente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigoCliente.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCodigoCliente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigoCliente.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCodigoCliente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigoCliente.DataField = "Cod_Cliente"
        Me.TxtCodigoCliente.Height = 0.1875!
        Me.TxtCodigoCliente.Left = 1.375!
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TxtCodigoCliente.Text = Nothing
        Me.TxtCodigoCliente.Top = 0.0625!
        Me.TxtCodigoCliente.Width = 4.5!
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
        Me.TextBox3.DataField = "Nombre_Cliente"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 1.375!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.3125!
        Me.TextBox3.Width = 4.5!
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
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 4.875!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 1.125!
        Me.TextBox4.Width = 0.875!
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
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 5.75!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 1.125!
        Me.TextBox5.Width = 0.875!
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
        Me.TxtSaldoInicial.Left = 6.625!
        Me.TxtSaldoInicial.Name = "TxtSaldoInicial"
        Me.TxtSaldoInicial.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; "
        Me.TxtSaldoInicial.Text = Nothing
        Me.TxtSaldoInicial.Top = 1.125!
        Me.TxtSaldoInicial.Width = 0.875!
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
        Me.Label13.Left = 3.9375!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label13.Text = "Saldo Inicial"
        Me.Label13.Top = 1.125!
        Me.Label13.Width = 0.9375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox6, Me.TextBox7})
        Me.GroupFooter1.Height = 0.2083333!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.TextBox6.DataField = "Debito"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 4.875!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.TextBox6.SummaryGroup = "GroupHeader1"
        Me.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
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
        Me.TextBox7.DataField = "Credito"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 5.75!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; "
        Me.TextBox7.SummaryGroup = "GroupHeader1"
        Me.TextBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.875!
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
        Me.LblMoneda.Height = 0.175!
        Me.LblMoneda.HyperLink = Nothing
        Me.LblMoneda.Left = 0.0!
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.LblMoneda.Text = ""
        Me.LblMoneda.Top = 0.9!
        Me.LblMoneda.Width = 7.475!
        '
        'ArepEstadoCuentasClientes
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=SistemaFacturacionRevetsa;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.2!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.53125!
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
        CType(Me.LblImpreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDebito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSaldoInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblImpreso As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents LblNombre As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCodigo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDesde As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCodigoCliente As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtSaldoInicial As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtDebito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCredito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtBalance As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblMoneda As DataDynamics.ActiveReports.Label
End Class
