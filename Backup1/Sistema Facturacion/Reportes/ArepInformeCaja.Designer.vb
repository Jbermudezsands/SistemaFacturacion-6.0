<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepInformeCaja 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepInformeCaja))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.lblProductName = New DataDynamics.ActiveReports.Label
        Me.lblQty = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.LblFecha = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.Label25 = New DataDynamics.ActiveReports.Label
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.LblTotalGrupo = New DataDynamics.ActiveReports.Label
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotalGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.lblProductName, Me.lblQty, Me.Label1, Me.TextBox1, Me.Label3, Me.Label4, Me.Label12, Me.LblFecha})
        Me.PageHeader1.Height = 1.53125!
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
        Me.LblTitulo.Left = 0.5!
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
        Me.LblDireccion.Left = 0.5!
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
        Me.LblRuc.Left = 0.5!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "text-align: center; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 0.5!
        Me.LblRuc.Width = 6.625!
        '
        'lblProductName
        '
        Me.lblProductName.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductName.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductName.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductName.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductName.Height = 0.1875!
        Me.lblProductName.HyperLink = Nothing
        Me.lblProductName.Left = 0.0625!
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.lblProductName.Text = "Nombre de la Cuenta"
        Me.lblProductName.Top = 1.3125!
        Me.lblProductName.Width = 4.25!
        '
        'lblQty
        '
        Me.lblQty.Border.BottomColor = System.Drawing.Color.Black
        Me.lblQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.LeftColor = System.Drawing.Color.Black
        Me.lblQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.RightColor = System.Drawing.Color.Black
        Me.lblQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.TopColor = System.Drawing.Color.Black
        Me.lblQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Height = 0.1875!
        Me.lblQty.HyperLink = Nothing
        Me.lblQty.Left = 4.3125!
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: White; font-size: 8.25pt; "
        Me.lblQty.Text = "DEBE"
        Me.lblQty.Top = 1.3125!
        Me.lblQty.Width = 0.875!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.Black
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.LeftColor = System.Drawing.Color.Black
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.RightColor = System.Drawing.Color.Black
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopColor = System.Drawing.Color.Black
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 5.1875!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: White; font-size: 8.25pt; "
        Me.Label1.Text = "HABER"
        Me.Label1.Top = 1.3125!
        Me.Label1.Width = 0.9375!
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
        Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
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
        Me.Label3.Left = 5.875!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "Pag."
        Me.Label3.Top = 0.8125!
        Me.Label3.Width = 0.3125!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 6.125!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: White; font-size: 8.25pt; "
        Me.Label4.Text = "SALDO"
        Me.Label4.Top = 1.3125!
        Me.Label4.Width = 0.9375!
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
        Me.Label12.Left = 0.125!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.Label12.Text = "INFORME DE INGRESOS---CAJA GENERAL"
        Me.Label12.Top = 0.75!
        Me.Label12.Width = 7.0!
        '
        'LblFecha
        '
        Me.LblFecha.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFecha.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFecha.Border.RightColor = System.Drawing.Color.Black
        Me.LblFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFecha.Border.TopColor = System.Drawing.Color.Black
        Me.LblFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFecha.Height = 0.1875!
        Me.LblFecha.HyperLink = Nothing
        Me.LblFecha.Left = 0.125!
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Style = ""
        Me.LblFecha.Text = ""
        Me.LblFecha.Top = 1.0625!
        Me.LblFecha.Width = 3.375!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox3, Me.TextBox4})
        Me.Detail1.Height = 0.2291667!
        Me.Detail1.Name = "Detail1"
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
        Me.TextBox3.DataField = "Nombre_Rubro"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 0.0625!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 4.25!
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
        Me.TextBox4.DataField = "Monto"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 4.3125!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.01041667!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.DataField = "NombrePago"
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label23, Me.Label24, Me.Label25, Me.TextBox5, Me.LblTotalGrupo})
        Me.ReportFooter1.Height = 0.7083333!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Label23
        '
        Me.Label23.Border.BottomColor = System.Drawing.Color.Black
        Me.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Border.LeftColor = System.Drawing.Color.Black
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Border.RightColor = System.Drawing.Color.Black
        Me.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Border.TopColor = System.Drawing.Color.Black
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Height = 0.1875!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.5!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label23.Text = "CAJERO"
        Me.Label23.Top = 0.4375!
        Me.Label23.Width = 1.3125!
        '
        'Label24
        '
        Me.Label24.Border.BottomColor = System.Drawing.Color.Black
        Me.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.LeftColor = System.Drawing.Color.Black
        Me.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.RightColor = System.Drawing.Color.Black
        Me.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.TopColor = System.Drawing.Color.Black
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Height = 0.1875!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 2.6875!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label24.Text = "DIRECTOR GENERAL"
        Me.Label24.Top = 0.4375!
        Me.Label24.Width = 1.6875!
        '
        'Label25
        '
        Me.Label25.Border.BottomColor = System.Drawing.Color.Black
        Me.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Border.LeftColor = System.Drawing.Color.Black
        Me.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Border.RightColor = System.Drawing.Color.Black
        Me.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Border.TopColor = System.Drawing.Color.Black
        Me.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Height = 0.1875!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 5.0625!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label25.Text = "CONTADOR"
        Me.Label25.Top = 0.4375!
        Me.Label25.Width = 1.3125!
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
        Me.TextBox5.DataField = "Monto"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 4.25!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox5.SummaryGroup = "GroupHeader1"
        Me.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.875!
        '
        'LblTotalGrupo
        '
        Me.LblTotalGrupo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotalGrupo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalGrupo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotalGrupo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalGrupo.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotalGrupo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalGrupo.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotalGrupo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotalGrupo.Height = 0.1875!
        Me.LblTotalGrupo.HyperLink = Nothing
        Me.LblTotalGrupo.Left = 0.0!
        Me.LblTotalGrupo.Name = "LblTotalGrupo"
        Me.LblTotalGrupo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.LblTotalGrupo.Text = "TOTAL EFECTIVO"
        Me.LblTotalGrupo.Top = 0.0!
        Me.LblTotalGrupo.Width = 4.25!
        '
        'ArepInformeCaja
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaFacturacionInstituto;Data Source=CONSULTOR\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.3!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.3!
        Me.PageSettings.Margins.Top = 0.3!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.197917!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
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
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotalGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductName As DataDynamics.ActiveReports.Label
    Private WithEvents lblQty As DataDynamics.ActiveReports.Label
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblTotalGrupo As DataDynamics.ActiveReports.Label
End Class 
