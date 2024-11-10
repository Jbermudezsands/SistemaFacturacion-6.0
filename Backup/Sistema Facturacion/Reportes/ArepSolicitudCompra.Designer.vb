<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepSolicitudCompra 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepSolicitudCompra))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblOrderNum = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.LblOrden = New DataDynamics.ActiveReports.Label
        Me.LblTipoCompra = New DataDynamics.ActiveReports.Label
        Me.LblTelefonos = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.lblProductName = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.lblQty = New DataDynamics.ActiveReports.Label
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.TxtProyecto = New DataDynamics.ActiveReports.TextBox
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.LblImpreso = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.CheckBox1 = New DataDynamics.ActiveReports.CheckBox
        Me.CheckBox2 = New DataDynamics.ActiveReports.CheckBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.ChkSolicitudCta = New DataDynamics.ActiveReports.CheckBox
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblImpreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkSolicitudCta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblOrderNum, Me.ImgLogo, Me.LblEncabezado, Me.LblDireccion, Me.LblRuc, Me.LblOrden, Me.LblTipoCompra, Me.LblTelefonos, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.lblProductName, Me.Label8, Me.lblQty, Me.lblProductID, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.Label15, Me.TextBox9, Me.Label16, Me.TxtProyecto, Me.TextBox11, Me.Label17, Me.Label18, Me.LblImpreso, Me.ChkSolicitudCta})
        Me.PageHeader1.Height = 3.135417!
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
        Me.lblOrderNum.Left = 5.125!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "text-align: right; font-weight: bold; "
        Me.lblOrderNum.Text = "Solicitud #:"
        Me.lblOrderNum.Top = 0.625!
        Me.lblOrderNum.Width = 1.0!
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
        Me.ImgLogo.Height = 0.875!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.25!
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
        Me.LblEncabezado.Height = 0.5!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 1.25!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 15.75pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.0!
        Me.LblEncabezado.Width = 4.0625!
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
        Me.LblDireccion.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.875!
        Me.LblDireccion.Width = 5.0!
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
        Me.LblRuc.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 1.0625!
        Me.LblRuc.Width = 2.25!
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
        Me.LblOrden.DataField = "Numero_Solicitud"
        Me.LblOrden.Height = 0.1875!
        Me.LblOrden.HyperLink = Nothing
        Me.LblOrden.Left = 6.1875!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = ""
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 0.625!
        Me.LblOrden.Width = 0.8125!
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
        Me.LblTipoCompra.Height = 0.5!
        Me.LblTipoCompra.HyperLink = Nothing
        Me.LblTipoCompra.Left = 5.3125!
        Me.LblTipoCompra.Name = "LblTipoCompra"
        Me.LblTipoCompra.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 14.25pt; "
        Me.LblTipoCompra.Text = "SOLICITUD DE COMPRA"
        Me.LblTipoCompra.Top = 0.0!
        Me.LblTipoCompra.Width = 1.5625!
        '
        'LblTelefonos
        '
        Me.LblTelefonos.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTelefonos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonos.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTelefonos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonos.Border.RightColor = System.Drawing.Color.Black
        Me.LblTelefonos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonos.Border.TopColor = System.Drawing.Color.Black
        Me.LblTelefonos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefonos.Height = 0.1875!
        Me.LblTelefonos.HyperLink = Nothing
        Me.LblTelefonos.Left = 2.25!
        Me.LblTelefonos.Name = "LblTelefonos"
        Me.LblTelefonos.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblTelefonos.Text = ""
        Me.LblTelefonos.Top = 1.0625!
        Me.LblTelefonos.Width = 2.8125!
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
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.05!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; "
        Me.Label1.Text = "Gerencia Solicitante:"
        Me.Label1.Top = 1.625!
        Me.Label1.Width = 1.45!
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
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.025!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; "
        Me.Label2.Text = "Departamento:"
        Me.Label2.Top = 1.8!
        Me.Label2.Width = 1.45!
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
        Me.Label3.Height = 0.1999999!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.125!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; "
        Me.Label3.Text = "Fecha Pedido"
        Me.Label3.Top = 2.025!
        Me.Label3.Width = 1.35!
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
        Me.Label4.Height = 0.1999999!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 2.5!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; "
        Me.Label4.Text = "Fecha Requerido"
        Me.Label4.Top = 2.025!
        Me.Label4.Width = 1.35!
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
        Me.Label5.Height = 0.45!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.15!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; "
        Me.Label5.Text = "Descripcion del Pedido"
        Me.Label5.Top = 2.3!
        Me.Label5.Width = 1.35!
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
        Me.lblProductName.Height = 0.2!
        Me.lblProductName.HyperLink = Nothing
        Me.lblProductName.Left = 0.425!
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblProductName.Text = "Nombre Producto"
        Me.lblProductName.Top = 2.875!
        Me.lblProductName.Width = 4.075!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 4.5!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label8.Text = "UM"
        Me.Label8.Top = 2.875!
        Me.Label8.Width = 0.6250001!
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
        Me.lblQty.Height = 0.2!
        Me.lblQty.HyperLink = Nothing
        Me.lblQty.Left = 5.125!
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.lblQty.Text = "Qty"
        Me.lblQty.Top = 2.875!
        Me.lblQty.Width = 0.5!
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
        Me.lblProductID.Height = 0.1875!
        Me.lblProductID.HyperLink = Nothing
        Me.lblProductID.Left = 0.0!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblProductID.Text = "Codigo"
        Me.lblProductID.Top = 2.875!
        Me.lblProductID.Width = 0.6875!
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
        Me.TextBox4.DataField = "Gerencia_Solicitante"
        Me.TextBox4.Height = 0.2!
        Me.TextBox4.Left = 1.575!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 1.65!
        Me.TextBox4.Width = 3.325!
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
        Me.TextBox5.DataField = "Departamento_Solicitante"
        Me.TextBox5.Height = 0.1999999!
        Me.TextBox5.Left = 1.55!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 1.825!
        Me.TextBox5.Width = 3.35!
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
        Me.TextBox6.DataField = "Fecha_Solicitud"
        Me.TextBox6.Height = 0.2!
        Me.TextBox6.Left = 1.55!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 2.025!
        Me.TextBox6.Width = 0.9000001!
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
        Me.TextBox7.DataField = "Fecha_Requerido"
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 3.85!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 2.025!
        Me.TextBox7.Width = 0.9500001!
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
        Me.Label15.Height = 0.2!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 4.925!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; "
        Me.Label15.Text = "Bodega:"
        Me.Label15.Top = 2.05!
        Me.Label15.Width = 0.7250001!
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
        Me.TextBox9.DataField = "Cod_Bodega"
        Me.TextBox9.Height = 0.2!
        Me.TextBox9.Left = 5.7!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 2.05!
        Me.TextBox9.Width = 1.4!
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
        Me.Label16.Height = 0.1999999!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 4.95!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; "
        Me.Label16.Text = "Proyecto"
        Me.Label16.Top = 1.825!
        Me.Label16.Width = 0.7!
        '
        'TxtProyecto
        '
        Me.TxtProyecto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtProyecto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtProyecto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtProyecto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtProyecto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtProyecto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtProyecto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtProyecto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtProyecto.Height = 0.1999999!
        Me.TxtProyecto.Left = 5.7!
        Me.TxtProyecto.Name = "TxtProyecto"
        Me.TxtProyecto.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TxtProyecto.Text = Nothing
        Me.TxtProyecto.Top = 1.825!
        Me.TxtProyecto.Width = 1.4!
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
        Me.TextBox11.DataField = "Concepto"
        Me.TextBox11.Height = 0.4375!
        Me.TextBox11.Left = 1.5625!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 2.3125!
        Me.TextBox11.Width = 5.5!
        '
        'Label17
        '
        Me.Label17.Border.BottomColor = System.Drawing.Color.Black
        Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.LeftColor = System.Drawing.Color.Black
        Me.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.RightColor = System.Drawing.Color.Black
        Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.TopColor = System.Drawing.Color.Black
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 5.625!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label17.Text = "Autorizado"
        Me.Label17.Top = 2.875!
        Me.Label17.Width = 0.6500003!
        '
        'Label18
        '
        Me.Label18.Border.BottomColor = System.Drawing.Color.Black
        Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.LeftColor = System.Drawing.Color.Black
        Me.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.RightColor = System.Drawing.Color.Black
        Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.TopColor = System.Drawing.Color.Black
        Me.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 6.25!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label18.Text = "Comprado"
        Me.Label18.Top = 2.875!
        Me.Label18.Width = 0.6500003!
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
        Me.LblImpreso.Height = 0.2!
        Me.LblImpreso.HyperLink = Nothing
        Me.LblImpreso.Left = 0.075!
        Me.LblImpreso.Name = "LblImpreso"
        Me.LblImpreso.Style = "ddo-char-set: 0; font-style: normal; font-size: 8.25pt; "
        Me.LblImpreso.Text = "Impreso:"
        Me.LblImpreso.Top = 1.225!
        Me.LblImpreso.Width = 4.875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox8, Me.TextBox3, Me.CheckBox1, Me.CheckBox2})
        Me.Detail1.Height = 0.2395833!
        Me.Detail1.Name = "Detail1"
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
        Me.TextBox1.DataField = "Cod_Producto"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.75!
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
        Me.TextBox2.DataField = "Descripcion_Producto"
        Me.TextBox2.Height = 0.175!
        Me.TextBox2.Left = 0.75!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 3.775!
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
        Me.TextBox8.DataField = "Unidad_Medida"
        Me.TextBox8.Height = 0.175!
        Me.TextBox8.Left = 4.525!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.6000001!
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
        Me.TextBox3.Left = 5.15!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.5!
        '
        'CheckBox1
        '
        Me.CheckBox1.Border.BottomColor = System.Drawing.Color.Black
        Me.CheckBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheckBox1.Border.LeftColor = System.Drawing.Color.Black
        Me.CheckBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheckBox1.Border.RightColor = System.Drawing.Color.Black
        Me.CheckBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheckBox1.Border.TopColor = System.Drawing.Color.Black
        Me.CheckBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheckBox1.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.DataField = "Autorizado"
        Me.CheckBox1.Height = 0.2!
        Me.CheckBox1.Left = 5.625!
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Style = ""
        Me.CheckBox1.Text = ""
        Me.CheckBox1.Top = 0.0!
        Me.CheckBox1.Width = 0.6000003!
        '
        'CheckBox2
        '
        Me.CheckBox2.Border.BottomColor = System.Drawing.Color.Black
        Me.CheckBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheckBox2.Border.LeftColor = System.Drawing.Color.Black
        Me.CheckBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheckBox2.Border.RightColor = System.Drawing.Color.Black
        Me.CheckBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheckBox2.Border.TopColor = System.Drawing.Color.Black
        Me.CheckBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheckBox2.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.DataField = "Comprado"
        Me.CheckBox2.Height = 0.2!
        Me.CheckBox2.Left = 6.275!
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Style = ""
        Me.CheckBox2.Text = ""
        Me.CheckBox2.Top = 0.0!
        Me.CheckBox2.Width = 0.6000003!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label6, Me.Label7, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14})
        Me.PageFooter1.Height = 1.177083!
        Me.PageFooter1.Name = "PageFooter1"
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
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.025!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label6.Text = "Elaborador Por"
        Me.Label6.Top = 0.525!
        Me.Label6.Width = 1.125!
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
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 1.7!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label7.Text = "Adquisiciones"
        Me.Label7.Top = 0.7250001!
        Me.Label7.Width = 1.125!
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
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 1.7!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label9.Text = "Recibido Por"
        Me.Label9.Top = 0.525!
        Me.Label9.Width = 1.125!
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
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.0!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label10.Text = "Gerente Solicitante"
        Me.Label10.Top = 0.7250001!
        Me.Label10.Width = 1.125!
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
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 3.45!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label11.Text = "Revicion Presupuesto"
        Me.Label11.Top = 0.525!
        Me.Label11.Width = 1.5!
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
        Me.Label12.Height = 0.2!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 3.45!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label12.Text = "Gerente Administrativo"
        Me.Label12.Top = 0.7250001!
        Me.Label12.Width = 1.5!
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
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.2!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 5.725!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label13.Text = "Autorizado"
        Me.Label13.Top = 0.5!
        Me.Label13.Width = 1.125!
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
        Me.Label14.Height = 0.2!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 5.725!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label14.Text = "Gerente General"
        Me.Label14.Top = 0.7!
        Me.Label14.Width = 1.125!
        '
        'ChkSolicitudCta
        '
        Me.ChkSolicitudCta.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkSolicitudCta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkSolicitudCta.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkSolicitudCta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkSolicitudCta.Border.RightColor = System.Drawing.Color.Black
        Me.ChkSolicitudCta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkSolicitudCta.Border.TopColor = System.Drawing.Color.Black
        Me.ChkSolicitudCta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkSolicitudCta.DataField = "Solcitud_Cta_Contable"
        Me.ChkSolicitudCta.Height = 0.1875!
        Me.ChkSolicitudCta.Left = 5.0!
        Me.ChkSolicitudCta.Name = "ChkSolicitudCta"
        Me.ChkSolicitudCta.Style = ""
        Me.ChkSolicitudCta.Text = "Solicitud Cta Contable"
        Me.ChkSolicitudCta.Top = 1.625!
        Me.ChkSolicitudCta.Width = 1.8125!
        '
        'ArepSolicitudCompra
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=SistemaFacturacionEmtrides;Data Source=JUANBERMUDEZ"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.21875!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblImpreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkSolicitudCta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoCompra As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefonos As DataDynamics.ActiveReports.Label
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductName As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents lblQty As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Private WithEvents Label13 As DataDynamics.ActiveReports.Label
    Private WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtProyecto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label17 As DataDynamics.ActiveReports.Label
    Private WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents CheckBox1 As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents CheckBox2 As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents LblImpreso As DataDynamics.ActiveReports.Label
    Friend WithEvents ChkSolicitudCta As DataDynamics.ActiveReports.CheckBox
End Class
