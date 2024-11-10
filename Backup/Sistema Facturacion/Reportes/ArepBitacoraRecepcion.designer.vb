<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepBitacoraRecepcion 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepBitacoraRecepcion))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblOrderNum = New DataDynamics.ActiveReports.Label
        Me.lblOrderDate = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.LblOrden = New DataDynamics.ActiveReports.Label
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.LblTipoCompra = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.LblLote = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.LblCosecha = New DataDynamics.ActiveReports.Label
        Me.LblLocalidad = New DataDynamics.ActiveReports.Label
        Me.LblHora = New DataDynamics.ActiveReports.Label
        Me.Label39 = New DataDynamics.ActiveReports.Label
        Me.Label40 = New DataDynamics.ActiveReports.Label
        Me.Label41 = New DataDynamics.ActiveReports.Label
        Me.LblCodRecolector = New DataDynamics.ActiveReports.Label
        Me.LblNombreRecolector = New DataDynamics.ActiveReports.Label
        Me.LblCedulaRecolector = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.LblApellidos = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.LblBodegas = New DataDynamics.ActiveReports.Label
        Me.LblBarco = New DataDynamics.ActiveReports.Label
        Me.LblConductor = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.LblOrigen = New DataDynamics.ActiveReports.Label
        Me.LblCedula = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.LblPila = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.LblPlaca = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label19 = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.Label25 = New DataDynamics.ActiveReports.Label
        Me.Label26 = New DataDynamics.ActiveReports.Label
        Me.Label27 = New DataDynamics.ActiveReports.Label
        Me.Label28 = New DataDynamics.ActiveReports.Label
        Me.Label29 = New DataDynamics.ActiveReports.Label
        Me.Label30 = New DataDynamics.ActiveReports.Label
        Me.Label31 = New DataDynamics.ActiveReports.Label
        Me.Label32 = New DataDynamics.ActiveReports.Label
        Me.Label33 = New DataDynamics.ActiveReports.Label
        Me.Label34 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label37 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.lblSubTotals = New DataDynamics.ActiveReports.Label
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.Label36 = New DataDynamics.ActiveReports.Label
        Me.Label38 = New DataDynamics.ActiveReports.Label
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox
        Me.Label35 = New DataDynamics.ActiveReports.Label
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.Label42 = New DataDynamics.ActiveReports.Label
        Me.Label43 = New DataDynamics.ActiveReports.Label
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.Label44 = New DataDynamics.ActiveReports.Label
        Me.Label45 = New DataDynamics.ActiveReports.Label
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox
        Me.Label46 = New DataDynamics.ActiveReports.Label
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCodRecolector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombreRecolector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCedulaRecolector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblBarco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPila, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblOrderNum, Me.lblOrderDate, Me.ImgLogo, Me.LblEncabezado, Me.LblDireccion, Me.LblRuc, Me.LblOrden, Me.LblFechaOrden, Me.LblTipoCompra, Me.Label13, Me.LblLote, Me.Label6, Me.LblNombres, Me.LblCosecha, Me.LblLocalidad, Me.LblHora, Me.Label39, Me.Label40, Me.Label41, Me.LblCodRecolector, Me.LblNombreRecolector, Me.LblCedulaRecolector})
        Me.PageHeader1.Height = 4.0!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.lblOrderNum.Height = 0.1875!
        Me.lblOrderNum.HyperLink = Nothing
        Me.lblOrderNum.Left = 0.0625!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.lblOrderNum.Text = "Recepción #:"
        Me.lblOrderNum.Top = 2.375!
        Me.lblOrderNum.Width = 0.8125!
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Border.BottomColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.LeftColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.RightColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.TopColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Height = 0.1875!
        Me.lblOrderDate.HyperLink = Nothing
        Me.lblOrderDate.Left = 0.0625!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.lblOrderDate.Text = "Fecha Orden:"
        Me.lblOrderDate.Top = 2.125!
        Me.lblOrderDate.Width = 0.8125!
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
        Me.ImgLogo.Height = 0.75!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.625!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.3125!
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
        Me.LblEncabezado.Height = 0.4375!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 0.0!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 12pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.8125!
        Me.LblEncabezado.Width = 2.5625!
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
        Me.LblDireccion.Left = 8.6875!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 1.625!
        Me.LblDireccion.Visible = False
        Me.LblDireccion.Width = 3.6875!
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
        Me.LblRuc.Left = 8.6875!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 1.8125!
        Me.LblRuc.Visible = False
        Me.LblRuc.Width = 2.0!
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
        Me.LblOrden.Left = 0.9375!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = ""
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 2.375!
        Me.LblOrden.Width = 1.0625!
        '
        'LblFechaOrden
        '
        Me.LblFechaOrden.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.RightColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.TopColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Height = 0.1875!
        Me.LblFechaOrden.HyperLink = Nothing
        Me.LblFechaOrden.Left = 0.9375!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = ""
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 2.125!
        Me.LblFechaOrden.Width = 1.0625!
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
        Me.LblTipoCompra.Height = 0.25!
        Me.LblTipoCompra.HyperLink = Nothing
        Me.LblTipoCompra.Left = 0.0!
        Me.LblTipoCompra.Name = "LblTipoCompra"
        Me.LblTipoCompra.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 12pt; "
        Me.LblTipoCompra.Text = "Recepción"
        Me.LblTipoCompra.Top = 1.375!
        Me.LblTipoCompra.Width = 2.5625!
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
        Me.Label13.Left = 8.5625!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: left; font-weight: bold; "
        Me.Label13.Text = "Lote No."
        Me.Label13.Top = 1.125!
        Me.Label13.Visible = False
        Me.Label13.Width = 1.0!
        '
        'LblLote
        '
        Me.LblLote.Border.BottomColor = System.Drawing.Color.Black
        Me.LblLote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLote.Border.LeftColor = System.Drawing.Color.Black
        Me.LblLote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLote.Border.RightColor = System.Drawing.Color.Black
        Me.LblLote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLote.Border.TopColor = System.Drawing.Color.Black
        Me.LblLote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLote.Height = 0.1875!
        Me.LblLote.HyperLink = Nothing
        Me.LblLote.Left = 9.625!
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Style = "ddo-char-set: 0; font-size: 9.75pt; "
        Me.LblLote.Text = ""
        Me.LblLote.Top = 1.125!
        Me.LblLote.Visible = False
        Me.LblLote.Width = 1.5625!
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
        Me.Label6.Height = 0.2105263!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.0625!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label6.Text = "Proveedor"
        Me.Label6.Top = 2.625!
        Me.Label6.Width = 0.7368421!
        '
        'LblNombres
        '
        Me.LblNombres.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNombres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNombres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.RightColor = System.Drawing.Color.Black
        Me.LblNombres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.TopColor = System.Drawing.Color.Black
        Me.LblNombres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Height = 0.4375!
        Me.LblNombres.HyperLink = Nothing
        Me.LblNombres.Left = 0.9375!
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblNombres.Text = ""
        Me.LblNombres.Top = 2.625!
        Me.LblNombres.Width = 1.6875!
        '
        'LblCosecha
        '
        Me.LblCosecha.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCosecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCosecha.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCosecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCosecha.Border.RightColor = System.Drawing.Color.Black
        Me.LblCosecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCosecha.Border.TopColor = System.Drawing.Color.Black
        Me.LblCosecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCosecha.Height = 0.1875!
        Me.LblCosecha.HyperLink = Nothing
        Me.LblCosecha.Left = 0.0!
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Style = "text-align: center; "
        Me.LblCosecha.Text = ""
        Me.LblCosecha.Top = 1.625!
        Me.LblCosecha.Width = 2.5625!
        '
        'LblLocalidad
        '
        Me.LblLocalidad.Border.BottomColor = System.Drawing.Color.Black
        Me.LblLocalidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLocalidad.Border.LeftColor = System.Drawing.Color.Black
        Me.LblLocalidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLocalidad.Border.RightColor = System.Drawing.Color.Black
        Me.LblLocalidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLocalidad.Border.TopColor = System.Drawing.Color.Black
        Me.LblLocalidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLocalidad.Height = 0.1875!
        Me.LblLocalidad.HyperLink = Nothing
        Me.LblLocalidad.Left = 0.0!
        Me.LblLocalidad.Name = "LblLocalidad"
        Me.LblLocalidad.Style = "text-align: center; "
        Me.LblLocalidad.Text = ""
        Me.LblLocalidad.Top = 1.8125!
        Me.LblLocalidad.Width = 2.5625!
        '
        'LblHora
        '
        Me.LblHora.Border.BottomColor = System.Drawing.Color.Black
        Me.LblHora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHora.Border.LeftColor = System.Drawing.Color.Black
        Me.LblHora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHora.Border.RightColor = System.Drawing.Color.Black
        Me.LblHora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHora.Border.TopColor = System.Drawing.Color.Black
        Me.LblHora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHora.Height = 0.1875!
        Me.LblHora.HyperLink = Nothing
        Me.LblHora.Left = 0.175!
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Style = "text-align: center; "
        Me.LblHora.Text = ""
        Me.LblHora.Top = 3.775!
        Me.LblHora.Width = 2.4375!
        '
        'Label39
        '
        Me.Label39.Border.BottomColor = System.Drawing.Color.Black
        Me.Label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Border.LeftColor = System.Drawing.Color.Black
        Me.Label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Border.RightColor = System.Drawing.Color.Black
        Me.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Border.TopColor = System.Drawing.Color.Black
        Me.Label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Height = 0.2!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 0.05!
        Me.Label39.Name = "Label39"
        Me.Label39.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label39.Text = "Cod Recolector"
        Me.Label39.Top = 3.15!
        Me.Label39.Width = 0.9!
        '
        'Label40
        '
        Me.Label40.Border.BottomColor = System.Drawing.Color.Black
        Me.Label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.LeftColor = System.Drawing.Color.Black
        Me.Label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.RightColor = System.Drawing.Color.Black
        Me.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.TopColor = System.Drawing.Color.Black
        Me.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Height = 0.1750001!
        Me.Label40.HyperLink = Nothing
        Me.Label40.Left = 0.05!
        Me.Label40.Name = "Label40"
        Me.Label40.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label40.Text = "Nombre Recol"
        Me.Label40.Top = 3.35!
        Me.Label40.Width = 0.925!
        '
        'Label41
        '
        Me.Label41.Border.BottomColor = System.Drawing.Color.Black
        Me.Label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label41.Border.LeftColor = System.Drawing.Color.Black
        Me.Label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label41.Border.RightColor = System.Drawing.Color.Black
        Me.Label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label41.Border.TopColor = System.Drawing.Color.Black
        Me.Label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label41.Height = 0.1750001!
        Me.Label41.HyperLink = Nothing
        Me.Label41.Left = 0.05!
        Me.Label41.Name = "Label41"
        Me.Label41.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label41.Text = "Cedula"
        Me.Label41.Top = 3.575!
        Me.Label41.Width = 0.925!
        '
        'LblCodRecolector
        '
        Me.LblCodRecolector.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCodRecolector.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodRecolector.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCodRecolector.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodRecolector.Border.RightColor = System.Drawing.Color.Black
        Me.LblCodRecolector.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodRecolector.Border.TopColor = System.Drawing.Color.Black
        Me.LblCodRecolector.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodRecolector.Height = 0.2!
        Me.LblCodRecolector.HyperLink = Nothing
        Me.LblCodRecolector.Left = 0.9750001!
        Me.LblCodRecolector.Name = "LblCodRecolector"
        Me.LblCodRecolector.Style = "text-align: center; "
        Me.LblCodRecolector.Text = ""
        Me.LblCodRecolector.Top = 3.15!
        Me.LblCodRecolector.Width = 1.525!
        '
        'LblNombreRecolector
        '
        Me.LblNombreRecolector.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNombreRecolector.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombreRecolector.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNombreRecolector.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombreRecolector.Border.RightColor = System.Drawing.Color.Black
        Me.LblNombreRecolector.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombreRecolector.Border.TopColor = System.Drawing.Color.Black
        Me.LblNombreRecolector.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombreRecolector.Height = 0.2!
        Me.LblNombreRecolector.HyperLink = Nothing
        Me.LblNombreRecolector.Left = 0.9750001!
        Me.LblNombreRecolector.Name = "LblNombreRecolector"
        Me.LblNombreRecolector.Style = ""
        Me.LblNombreRecolector.Text = ""
        Me.LblNombreRecolector.Top = 3.35!
        Me.LblNombreRecolector.Width = 1.525!
        '
        'LblCedulaRecolector
        '
        Me.LblCedulaRecolector.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCedulaRecolector.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedulaRecolector.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCedulaRecolector.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedulaRecolector.Border.RightColor = System.Drawing.Color.Black
        Me.LblCedulaRecolector.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedulaRecolector.Border.TopColor = System.Drawing.Color.Black
        Me.LblCedulaRecolector.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedulaRecolector.Height = 0.2!
        Me.LblCedulaRecolector.HyperLink = Nothing
        Me.LblCedulaRecolector.Left = 0.9750001!
        Me.LblCedulaRecolector.Name = "LblCedulaRecolector"
        Me.LblCedulaRecolector.Style = ""
        Me.LblCedulaRecolector.Text = ""
        Me.LblCedulaRecolector.Top = 3.55!
        Me.LblCedulaRecolector.Width = 1.525!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox5, Me.TextBox1, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.TextBox10})
        Me.Detail1.Height = 0.21875!
        Me.Detail1.Name = "Detail1"
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
        Me.TextBox5.DataField = "id_Eventos"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 0.0625!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.25!
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
        Me.TextBox1.DataField = "PesoNetoKg"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.325!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.4375!
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
        Me.TextBox7.DataField = "Descripcion_Producto"
        Me.TextBox7.Height = 0.175!
        Me.TextBox7.Left = 0.775!
        Me.TextBox7.MultiLine = False
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.925!
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
        Me.TextBox8.DataField = "TotalPagar"
        Me.TextBox8.Height = 0.175!
        Me.TextBox8.Left = 2.125!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.4749999!
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
        Me.TextBox9.DataField = "Precio"
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 2.875!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Visible = False
        Me.TextBox9.Width = 0.5625!
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
        Me.TextBox10.DataField = "Precio"
        Me.TextBox10.Height = 0.175!
        Me.TextBox10.Left = 1.675!
        Me.TextBox10.MultiLine = False
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.45!
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
        Me.TextBox4.DataField = "Cod_Productos"
        Me.TextBox4.Height = 0.2105263!
        Me.TextBox4.Left = 7.0!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.5!
        Me.TextBox4.Visible = False
        Me.TextBox4.Width = 0.6842105!
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
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox11})
        Me.ReportFooter1.Height = 0.9375!
        Me.ReportFooter1.Name = "ReportFooter1"
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
        Me.TextBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox11.Height = 0.2!
        Me.TextBox11.Left = 0.3!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "text-align: center; "
        Me.TextBox11.Text = "Recibi Conforme"
        Me.TextBox11.Top = 0.7!
        Me.TextBox11.Width = 2.25!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblProductID, Me.Label2, Me.LblApellidos, Me.Label5, Me.Line2, Me.LblBodegas, Me.LblBarco, Me.LblConductor, Me.Label8, Me.Label9, Me.LblOrigen, Me.LblCedula, Me.Label10, Me.Label11, Me.LblPila, Me.Label12, Me.LblPlaca, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.Label23, Me.Label24, Me.Label25, Me.Label26, Me.Label27, Me.Label28, Me.Label29, Me.Label30, Me.Label31, Me.Label32, Me.Label33, Me.Label34, Me.TextBox4, Me.Label1, Me.Label3, Me.Label4, Me.Label7, Me.Label37})
        Me.GroupHeader1.DataField = "NumeroRecepcion"
        Me.GroupHeader1.Height = 0.3541667!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblProductID
        '
        Me.lblProductID.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Height = 0.2105263!
        Me.lblProductID.HyperLink = Nothing
        Me.lblProductID.Left = 6.9375!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblProductID.Text = "Product ID"
        Me.lblProductID.Top = 0.1875!
        Me.lblProductID.Visible = False
        Me.lblProductID.Width = 0.6842105!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Height = 0.3125!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label2.Text = "Pd"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 0.25!
        '
        'LblApellidos
        '
        Me.LblApellidos.Border.BottomColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.LeftColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.RightColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.TopColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Height = 0.2105263!
        Me.LblApellidos.HyperLink = Nothing
        Me.LblApellidos.Left = 9.125!
        Me.LblApellidos.Name = "LblApellidos"
        Me.LblApellidos.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblApellidos.Text = ""
        Me.LblApellidos.Top = 0.25!
        Me.LblApellidos.Visible = False
        Me.LblApellidos.Width = 1.526316!
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
        Me.Label5.Left = 8.0!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: #000040; text-align: left; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label5.Text = "Bodega"
        Me.Label5.Top = 0.8125!
        Me.Label5.Visible = False
        Me.Label5.Width = 0.6875!
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
        Me.Line2.Left = 7.875!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.0!
        Me.Line2.Visible = False
        Me.Line2.Width = 1.5625!
        Me.Line2.X1 = 7.875!
        Me.Line2.X2 = 9.4375!
        Me.Line2.Y1 = 1.0!
        Me.Line2.Y2 = 1.0!
        '
        'LblBodegas
        '
        Me.LblBodegas.Border.BottomColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.LeftColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.RightColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.TopColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Height = 0.1875!
        Me.LblBodegas.HyperLink = Nothing
        Me.LblBodegas.Left = 8.6875!
        Me.LblBodegas.Name = "LblBodegas"
        Me.LblBodegas.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblBodegas.Text = ""
        Me.LblBodegas.Top = 0.8125!
        Me.LblBodegas.Visible = False
        Me.LblBodegas.Width = 1.25!
        '
        'LblBarco
        '
        Me.LblBarco.Border.BottomColor = System.Drawing.Color.Black
        Me.LblBarco.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBarco.Border.LeftColor = System.Drawing.Color.Black
        Me.LblBarco.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBarco.Border.RightColor = System.Drawing.Color.Black
        Me.LblBarco.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBarco.Border.TopColor = System.Drawing.Color.Black
        Me.LblBarco.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBarco.Height = 0.2105263!
        Me.LblBarco.HyperLink = Nothing
        Me.LblBarco.Left = 9.125!
        Me.LblBarco.Name = "LblBarco"
        Me.LblBarco.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblBarco.Text = ""
        Me.LblBarco.Top = 0.0625!
        Me.LblBarco.Visible = False
        Me.LblBarco.Width = 1.526316!
        '
        'LblConductor
        '
        Me.LblConductor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblConductor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblConductor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblConductor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblConductor.Border.RightColor = System.Drawing.Color.Black
        Me.LblConductor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblConductor.Border.TopColor = System.Drawing.Color.Black
        Me.LblConductor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblConductor.Height = 0.1875!
        Me.LblConductor.HyperLink = Nothing
        Me.LblConductor.Left = 8.6875!
        Me.LblConductor.Name = "LblConductor"
        Me.LblConductor.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblConductor.Text = ""
        Me.LblConductor.Top = 1.0625!
        Me.LblConductor.Visible = False
        Me.LblConductor.Width = 1.4375!
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
        Me.Label8.Left = 7.25!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label8.Text = "Origen"
        Me.Label8.Top = 1.5!
        Me.Label8.Visible = False
        Me.Label8.Width = 0.7368421!
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
        Me.Label9.Left = 7.9375!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label9.Text = "Conductor"
        Me.Label9.Top = 1.0625!
        Me.Label9.Visible = False
        Me.Label9.Width = 0.6875!
        '
        'LblOrigen
        '
        Me.LblOrigen.Border.BottomColor = System.Drawing.Color.Black
        Me.LblOrigen.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrigen.Border.LeftColor = System.Drawing.Color.Black
        Me.LblOrigen.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrigen.Border.RightColor = System.Drawing.Color.Black
        Me.LblOrigen.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrigen.Border.TopColor = System.Drawing.Color.Black
        Me.LblOrigen.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrigen.Height = 0.2105264!
        Me.LblOrigen.HyperLink = Nothing
        Me.LblOrigen.Left = 9.625!
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblOrigen.Text = ""
        Me.LblOrigen.Top = 0.625!
        Me.LblOrigen.Visible = False
        Me.LblOrigen.Width = 2.736842!
        '
        'LblCedula
        '
        Me.LblCedula.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCedula.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedula.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCedula.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedula.Border.RightColor = System.Drawing.Color.Black
        Me.LblCedula.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedula.Border.TopColor = System.Drawing.Color.Black
        Me.LblCedula.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedula.Height = 0.1875!
        Me.LblCedula.HyperLink = Nothing
        Me.LblCedula.Left = 8.6875!
        Me.LblCedula.Name = "LblCedula"
        Me.LblCedula.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblCedula.Text = ""
        Me.LblCedula.Top = 1.3125!
        Me.LblCedula.Visible = False
        Me.LblCedula.Width = 1.4375!
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
        Me.Label10.Left = 7.9375!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label10.Text = "Cedula"
        Me.Label10.Top = 1.3125!
        Me.Label10.Visible = False
        Me.Label10.Width = 0.6875!
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
        Me.Label11.Height = 0.2105263!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 7.25!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label11.Text = "Pila"
        Me.Label11.Top = 1.75!
        Me.Label11.Visible = False
        Me.Label11.Width = 0.7368421!
        '
        'LblPila
        '
        Me.LblPila.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPila.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPila.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPila.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPila.Border.RightColor = System.Drawing.Color.Black
        Me.LblPila.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPila.Border.TopColor = System.Drawing.Color.Black
        Me.LblPila.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPila.Height = 0.2105262!
        Me.LblPila.HyperLink = Nothing
        Me.LblPila.Left = 9.75!
        Me.LblPila.Name = "LblPila"
        Me.LblPila.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblPila.Text = ""
        Me.LblPila.Top = 1.1875!
        Me.LblPila.Visible = False
        Me.LblPila.Width = 2.736842!
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
        Me.Label12.Left = 7.9375!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label12.Text = "Placa"
        Me.Label12.Top = 1.5625!
        Me.Label12.Visible = False
        Me.Label12.Width = 0.6875!
        '
        'LblPlaca
        '
        Me.LblPlaca.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPlaca.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPlaca.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPlaca.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPlaca.Border.RightColor = System.Drawing.Color.Black
        Me.LblPlaca.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPlaca.Border.TopColor = System.Drawing.Color.Black
        Me.LblPlaca.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPlaca.Height = 0.1875!
        Me.LblPlaca.HyperLink = Nothing
        Me.LblPlaca.Left = 8.6875!
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblPlaca.Text = ""
        Me.LblPlaca.Top = 1.5625!
        Me.LblPlaca.Visible = False
        Me.LblPlaca.Width = 1.4375!
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
        Me.Label14.Left = 7.25!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label14.Text = "Origen"
        Me.Label14.Top = 1.5!
        Me.Label14.Visible = False
        Me.Label14.Width = 0.7368421!
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
        Me.Label15.Height = 0.2105263!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 7.9375!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label15.Text = "Pila"
        Me.Label15.Top = 0.5625!
        Me.Label15.Visible = False
        Me.Label15.Width = 0.7368421!
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
        Me.Label16.Height = 0.2105264!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 8.6875!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label16.Text = ""
        Me.Label16.Top = 0.5!
        Me.Label16.Visible = False
        Me.Label16.Width = 2.736842!
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
        Me.Label17.Height = 0.2105262!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 9.0!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label17.Text = ""
        Me.Label17.Top = 0.875!
        Me.Label17.Visible = False
        Me.Label17.Width = 2.736842!
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
        Me.Label18.Left = 7.9375!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label18.Text = "Conductor"
        Me.Label18.Top = 1.0625!
        Me.Label18.Visible = False
        Me.Label18.Width = 0.6875!
        '
        'Label19
        '
        Me.Label19.Border.BottomColor = System.Drawing.Color.Black
        Me.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Border.LeftColor = System.Drawing.Color.Black
        Me.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Border.RightColor = System.Drawing.Color.Black
        Me.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Border.TopColor = System.Drawing.Color.Black
        Me.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Height = 0.1875!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 8.6875!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label19.Text = ""
        Me.Label19.Top = 1.0625!
        Me.Label19.Visible = False
        Me.Label19.Width = 1.4375!
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
        Me.Label20.Left = 8.6875!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label20.Text = ""
        Me.Label20.Top = 1.3125!
        Me.Label20.Visible = False
        Me.Label20.Width = 1.4375!
        '
        'Label21
        '
        Me.Label21.Border.BottomColor = System.Drawing.Color.Black
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.LeftColor = System.Drawing.Color.Black
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.RightColor = System.Drawing.Color.Black
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.TopColor = System.Drawing.Color.Black
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Height = 0.1875!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 7.9375!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label21.Text = "Cedula"
        Me.Label21.Top = 1.3125!
        Me.Label21.Visible = False
        Me.Label21.Width = 0.6875!
        '
        'Label22
        '
        Me.Label22.Border.BottomColor = System.Drawing.Color.Black
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Border.LeftColor = System.Drawing.Color.Black
        Me.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Border.RightColor = System.Drawing.Color.Black
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Border.TopColor = System.Drawing.Color.Black
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Height = 0.1875!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 7.9375!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label22.Text = "Placa"
        Me.Label22.Top = 1.5625!
        Me.Label22.Visible = False
        Me.Label22.Width = 0.6875!
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
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Height = 0.2105263!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 8.5!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label23.Text = "Origen"
        Me.Label23.Top = 1.625!
        Me.Label23.Visible = False
        Me.Label23.Width = 0.7368421!
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
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Height = 0.2105263!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 8.5!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label24.Text = "Pila"
        Me.Label24.Top = 1.875!
        Me.Label24.Visible = False
        Me.Label24.Width = 0.7368421!
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
        Me.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Height = 0.2105264!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 9.3125!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label25.Text = ""
        Me.Label25.Top = 1.625!
        Me.Label25.Visible = False
        Me.Label25.Width = 2.736842!
        '
        'Label26
        '
        Me.Label26.Border.BottomColor = System.Drawing.Color.Black
        Me.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label26.Border.LeftColor = System.Drawing.Color.Black
        Me.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label26.Border.RightColor = System.Drawing.Color.Black
        Me.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label26.Border.TopColor = System.Drawing.Color.Black
        Me.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label26.Height = 0.2105262!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 9.3125!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label26.Text = ""
        Me.Label26.Top = 1.875!
        Me.Label26.Visible = False
        Me.Label26.Width = 2.736842!
        '
        'Label27
        '
        Me.Label27.Border.BottomColor = System.Drawing.Color.Black
        Me.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label27.Border.LeftColor = System.Drawing.Color.Black
        Me.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label27.Border.RightColor = System.Drawing.Color.Black
        Me.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label27.Border.TopColor = System.Drawing.Color.Black
        Me.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label27.Height = 0.1875!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 7.9375!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label27.Text = "Conductor"
        Me.Label27.Top = 1.0625!
        Me.Label27.Visible = False
        Me.Label27.Width = 0.6875!
        '
        'Label28
        '
        Me.Label28.Border.BottomColor = System.Drawing.Color.Black
        Me.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label28.Border.LeftColor = System.Drawing.Color.Black
        Me.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label28.Border.RightColor = System.Drawing.Color.Black
        Me.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label28.Border.TopColor = System.Drawing.Color.Black
        Me.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label28.Height = 0.1875!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 8.6875!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label28.Text = ""
        Me.Label28.Top = 1.0625!
        Me.Label28.Visible = False
        Me.Label28.Width = 1.4375!
        '
        'Label29
        '
        Me.Label29.Border.BottomColor = System.Drawing.Color.Black
        Me.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label29.Border.LeftColor = System.Drawing.Color.Black
        Me.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label29.Border.RightColor = System.Drawing.Color.Black
        Me.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label29.Border.TopColor = System.Drawing.Color.Black
        Me.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label29.Height = 0.1875!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 8.6875!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label29.Text = ""
        Me.Label29.Top = 1.3125!
        Me.Label29.Visible = False
        Me.Label29.Width = 1.4375!
        '
        'Label30
        '
        Me.Label30.Border.BottomColor = System.Drawing.Color.Black
        Me.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label30.Border.LeftColor = System.Drawing.Color.Black
        Me.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label30.Border.RightColor = System.Drawing.Color.Black
        Me.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label30.Border.TopColor = System.Drawing.Color.Black
        Me.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label30.Height = 0.1875!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 7.9375!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label30.Text = "Cedula"
        Me.Label30.Top = 1.3125!
        Me.Label30.Visible = False
        Me.Label30.Width = 0.6875!
        '
        'Label31
        '
        Me.Label31.Border.BottomColor = System.Drawing.Color.Black
        Me.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.LeftColor = System.Drawing.Color.Black
        Me.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.RightColor = System.Drawing.Color.Black
        Me.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.TopColor = System.Drawing.Color.Black
        Me.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Height = 0.1875!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 7.9375!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label31.Text = "Placa"
        Me.Label31.Top = 1.5625!
        Me.Label31.Visible = False
        Me.Label31.Width = 0.6875!
        '
        'Label32
        '
        Me.Label32.Border.BottomColor = System.Drawing.Color.Black
        Me.Label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label32.Border.LeftColor = System.Drawing.Color.Black
        Me.Label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label32.Border.RightColor = System.Drawing.Color.Black
        Me.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label32.Border.TopColor = System.Drawing.Color.Black
        Me.Label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label32.Height = 0.1875!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 8.6875!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label32.Text = ""
        Me.Label32.Top = 1.5625!
        Me.Label32.Visible = False
        Me.Label32.Width = 1.4375!
        '
        'Label33
        '
        Me.Label33.Border.BottomColor = System.Drawing.Color.Black
        Me.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label33.Border.LeftColor = System.Drawing.Color.Black
        Me.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label33.Border.RightColor = System.Drawing.Color.Black
        Me.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label33.Border.TopColor = System.Drawing.Color.Black
        Me.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label33.Height = 0.2105263!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 8.0625!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label33.Text = "Origen"
        Me.Label33.Top = 0.125!
        Me.Label33.Visible = False
        Me.Label33.Width = 0.7368421!
        '
        'Label34
        '
        Me.Label34.Border.BottomColor = System.Drawing.Color.Black
        Me.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label34.Border.LeftColor = System.Drawing.Color.Black
        Me.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label34.Border.RightColor = System.Drawing.Color.Black
        Me.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label34.Border.TopColor = System.Drawing.Color.Black
        Me.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label34.Height = 0.2105264!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 7.9375!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label34.Text = ""
        Me.Label34.Top = 0.875!
        Me.Label34.Visible = False
        Me.Label34.Width = 2.736842!
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
        Me.Label1.Height = 0.3125!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.325!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label1.Text = "Peso KG"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 0.4375!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.875!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label3.Text = "Precio"
        Me.Label3.Top = 0.0!
        Me.Label3.Visible = False
        Me.Label3.Width = 0.5625!
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
        Me.Label4.Height = 0.3125!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 1.675!
        Me.Label4.MultiLine = False
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label4.Text = "Precio"
        Me.Label4.Top = 0.0!
        Me.Label4.Width = 0.4375!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.31!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 2.125!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: #000040; ddo-char-set: 0; text-align: left; font-weight: bold; background-" & _
            "color: White; font-size: 8.25pt; "
        Me.Label7.Text = "Total"
        Me.Label7.Top = 0.0!
        Me.Label7.Width = 0.44!
        '
        'Label37
        '
        Me.Label37.Border.BottomColor = System.Drawing.Color.Black
        Me.Label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.LeftColor = System.Drawing.Color.Black
        Me.Label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.RightColor = System.Drawing.Color.Black
        Me.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.TopColor = System.Drawing.Color.Black
        Me.Label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Height = 0.313!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 0.775!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label37.Text = "Descripcion"
        Me.Label37.Top = 0.0!
        Me.Label37.Width = 0.9!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblSubTotals, Me.TextBox6, Me.Label36, Me.Label38, Me.TextBox12, Me.Label35, Me.TextBox2, Me.Label42, Me.Label43, Me.TextBox3, Me.Label44, Me.Label45, Me.TextBox13, Me.Label46})
        Me.GroupFooter1.Height = 1.166667!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'lblSubTotals
        '
        Me.lblSubTotals.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.RightColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.TopColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Height = 0.1875!
        Me.lblSubTotals.HyperLink = Nothing
        Me.lblSubTotals.Left = 0.5!
        Me.lblSubTotals.Name = "lblSubTotals"
        Me.lblSubTotals.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblSubTotals.Text = "Peso  Bruto:"
        Me.lblSubTotals.Top = 0.0!
        Me.lblSubTotals.Width = 0.8125!
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
        Me.TextBox6.DataField = "PesoKg"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 1.3125!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; font-famil" & _
            "y: Arial; "
        Me.TextBox6.SummaryGroup = "GroupHeader1"
        Me.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.75!
        '
        'Label36
        '
        Me.Label36.Border.BottomColor = System.Drawing.Color.Black
        Me.Label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label36.Border.LeftColor = System.Drawing.Color.Black
        Me.Label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label36.Border.RightColor = System.Drawing.Color.Black
        Me.Label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label36.Border.TopColor = System.Drawing.Color.Black
        Me.Label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label36.Height = 0.1875!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 2.125!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label36.Text = "Kg"
        Me.Label36.Top = 0.0!
        Me.Label36.Width = 0.3125!
        '
        'Label38
        '
        Me.Label38.Border.BottomColor = System.Drawing.Color.Black
        Me.Label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.LeftColor = System.Drawing.Color.Black
        Me.Label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.RightColor = System.Drawing.Color.Black
        Me.Label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.TopColor = System.Drawing.Color.Black
        Me.Label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Height = 0.1875!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.5!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label38.Text = "Total Pagar"
        Me.Label38.Top = 0.9375!
        Me.Label38.Width = 0.8125!
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
        Me.TextBox12.DataField = "TotalPagar"
        Me.TextBox12.Height = 0.1875!
        Me.TextBox12.Left = 1.3125!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; font-famil" & _
            "y: Arial; "
        Me.TextBox12.SummaryGroup = "GroupHeader1"
        Me.TextBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0.9375!
        Me.TextBox12.Width = 0.75!
        '
        'Label35
        '
        Me.Label35.Border.BottomColor = System.Drawing.Color.Black
        Me.Label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.LeftColor = System.Drawing.Color.Black
        Me.Label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.RightColor = System.Drawing.Color.Black
        Me.Label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.TopColor = System.Drawing.Color.Black
        Me.Label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Height = 0.1875!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 0.5!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label35.Text = "Merma:"
        Me.Label35.Top = 0.375!
        Me.Label35.Visible = False
        Me.Label35.Width = 0.8125!
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
        Me.TextBox2.DataField = "Merma"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 1.3125!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; font-famil" & _
            "y: Arial; "
        Me.TextBox2.SummaryGroup = "GroupHeader1"
        Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.375!
        Me.TextBox2.Visible = False
        Me.TextBox2.Width = 0.75!
        '
        'Label42
        '
        Me.Label42.Border.BottomColor = System.Drawing.Color.Black
        Me.Label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label42.Border.LeftColor = System.Drawing.Color.Black
        Me.Label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label42.Border.RightColor = System.Drawing.Color.Black
        Me.Label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label42.Border.TopColor = System.Drawing.Color.Black
        Me.Label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label42.Height = 0.1875!
        Me.Label42.HyperLink = Nothing
        Me.Label42.Left = 2.125!
        Me.Label42.Name = "Label42"
        Me.Label42.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label42.Text = "Kg"
        Me.Label42.Top = 0.375!
        Me.Label42.Visible = False
        Me.Label42.Width = 0.3125!
        '
        'Label43
        '
        Me.Label43.Border.BottomColor = System.Drawing.Color.Black
        Me.Label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Border.LeftColor = System.Drawing.Color.Black
        Me.Label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Border.RightColor = System.Drawing.Color.Black
        Me.Label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Border.TopColor = System.Drawing.Color.Black
        Me.Label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Height = 0.1875!
        Me.Label43.HyperLink = Nothing
        Me.Label43.Left = 0.5!
        Me.Label43.Name = "Label43"
        Me.Label43.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label43.Text = "Neto:"
        Me.Label43.Top = 0.5625!
        Me.Label43.Width = 0.8125!
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
        Me.TextBox3.DataField = "PesoNetoKg"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 1.3125!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; font-famil" & _
            "y: Arial; "
        Me.TextBox3.SummaryGroup = "GroupHeader1"
        Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.5625!
        Me.TextBox3.Width = 0.75!
        '
        'Label44
        '
        Me.Label44.Border.BottomColor = System.Drawing.Color.Black
        Me.Label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label44.Border.LeftColor = System.Drawing.Color.Black
        Me.Label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label44.Border.RightColor = System.Drawing.Color.Black
        Me.Label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label44.Border.TopColor = System.Drawing.Color.Black
        Me.Label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label44.Height = 0.1875!
        Me.Label44.HyperLink = Nothing
        Me.Label44.Left = 2.125!
        Me.Label44.Name = "Label44"
        Me.Label44.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label44.Text = "Kg"
        Me.Label44.Top = 0.5625!
        Me.Label44.Width = 0.3125!
        '
        'Label45
        '
        Me.Label45.Border.BottomColor = System.Drawing.Color.Black
        Me.Label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Border.LeftColor = System.Drawing.Color.Black
        Me.Label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Border.RightColor = System.Drawing.Color.Black
        Me.Label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Border.TopColor = System.Drawing.Color.Black
        Me.Label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Height = 0.1875!
        Me.Label45.HyperLink = Nothing
        Me.Label45.Left = 0.5!
        Me.Label45.Name = "Label45"
        Me.Label45.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label45.Text = "Tara:"
        Me.Label45.Top = 0.1875!
        Me.Label45.Width = 0.8125!
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
        Me.TextBox13.DataField = "Tara"
        Me.TextBox13.Height = 0.1875!
        Me.TextBox13.Left = 1.3125!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; font-famil" & _
            "y: Arial; "
        Me.TextBox13.SummaryGroup = "GroupHeader1"
        Me.TextBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0.1875!
        Me.TextBox13.Width = 0.75!
        '
        'Label46
        '
        Me.Label46.Border.BottomColor = System.Drawing.Color.Black
        Me.Label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label46.Border.LeftColor = System.Drawing.Color.Black
        Me.Label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label46.Border.RightColor = System.Drawing.Color.Black
        Me.Label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label46.Border.TopColor = System.Drawing.Color.Black
        Me.Label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label46.Height = 0.1875!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 2.125!
        Me.Label46.Name = "Label46"
        Me.Label46.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label46.Text = "Kg"
        Me.Label46.Top = 0.1875!
        Me.Label46.Width = 0.3125!
        '
        'ArepBitacoraRecepcion
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=FacturacionEMTRIDES;Data Source=JUANBERMUDEZ-PC\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.01!
        Me.PageSettings.Margins.Left = 0.23!
        Me.PageSettings.Margins.Right = 0.01!
        Me.PageSettings.Margins.Top = 0.1!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.677083!
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
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCodRecolector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombreRecolector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCedulaRecolector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblBarco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPila, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Private WithEvents lblSubTotals As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoCompra As DataDynamics.ActiveReports.Label
    Private WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLote As DataDynamics.ActiveReports.Label
    Friend WithEvents LblApellidos As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents LblBodegas As DataDynamics.ActiveReports.Label
    Friend WithEvents LblBarco As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents LblConductor As DataDynamics.ActiveReports.Label
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrigen As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCedula As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPila As DataDynamics.ActiveReports.Label
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPlaca As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label19 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label26 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label27 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label28 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label29 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label30 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label31 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label32 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label34 As DataDynamics.ActiveReports.Label
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblCosecha As DataDynamics.ActiveReports.Label
    Friend WithEvents Label36 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLocalidad As DataDynamics.ActiveReports.Label
    Friend WithEvents LblHora As DataDynamics.ActiveReports.Label
    Private WithEvents Label37 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label38 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label39 As DataDynamics.ActiveReports.Label
    Private WithEvents Label40 As DataDynamics.ActiveReports.Label
    Private WithEvents Label41 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCodRecolector As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombreRecolector As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCedulaRecolector As DataDynamics.ActiveReports.Label
    Private WithEvents Label35 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label42 As DataDynamics.ActiveReports.Label
    Private WithEvents Label43 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label44 As DataDynamics.ActiveReports.Label
    Private WithEvents Label45 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label46 As DataDynamics.ActiveReports.Label
End Class
