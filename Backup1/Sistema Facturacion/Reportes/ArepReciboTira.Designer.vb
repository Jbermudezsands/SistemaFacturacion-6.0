<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepReciboTira 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepReciboTira))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.LblTipoCompra = New DataDynamics.ActiveReports.Label
        Me.LblOrden = New DataDynamics.ActiveReports.Label
        Me.lblOrderDate = New DataDynamics.ActiveReports.Label
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.LblTelefono = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.TxtVendedor = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.LblPagadoRecibo = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.LblMontoTexto = New DataDynamics.ActiveReports.Label
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPagadoRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMontoTexto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblDireccion, Me.LblRuc, Me.LblTipoCompra, Me.LblOrden, Me.lblOrderDate, Me.LblFechaOrden, Me.LblEncabezado, Me.Label18, Me.Label23, Me.Label15, Me.Label22, Me.Label1, Me.LblNombres, Me.LblTelefono, Me.Label5, Me.TxtVendedor, Me.Label6})
        Me.PageHeader1.Height = 3.114583!
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
        Me.ImgLogo.Height = 0.6315789!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.6842105!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.526316!
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
        Me.LblDireccion.Height = 0.2105263!
        Me.LblDireccion.HyperLink = Nothing
        Me.LblDireccion.Left = 0.0!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "ddo-char-set: 0; text-align: center; font-style: normal; font-size: 9pt; font-fam" & _
            "ily: Microsoft Sans Serif; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.8947368!
        Me.LblDireccion.Width = 2.789474!
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
        Me.LblRuc.Height = 0.2105263!
        Me.LblRuc.HyperLink = Nothing
        Me.LblRuc.Left = 0.0!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "ddo-char-set: 0; text-align: center; font-style: normal; font-size: 9pt; font-fam" & _
            "ily: Cambria; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 1.105263!
        Me.LblRuc.Width = 2.789474!
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
        Me.LblTipoCompra.Height = 0.2105264!
        Me.LblTipoCompra.HyperLink = Nothing
        Me.LblTipoCompra.Left = 0.2105263!
        Me.LblTipoCompra.Name = "LblTipoCompra"
        Me.LblTipoCompra.Style = "color: #404040; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: " & _
            "8.25pt; "
        Me.LblTipoCompra.Text = "Recibo"
        Me.LblTipoCompra.Top = 2.0!
        Me.LblTipoCompra.Width = 0.5263157!
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
        Me.LblOrden.Height = 0.2105264!
        Me.LblOrden.HyperLink = Nothing
        Me.LblOrden.Left = 0.7368422!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 2.0!
        Me.LblOrden.Width = 0.6842105!
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
        Me.lblOrderDate.Height = 0.2105263!
        Me.lblOrderDate.HyperLink = Nothing
        Me.lblOrderDate.Left = 1.421052!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.lblOrderDate.Text = "Fecha:"
        Me.lblOrderDate.Top = 2.0!
        Me.lblOrderDate.Width = 0.4736841!
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
        Me.LblFechaOrden.Height = 0.2105264!
        Me.LblFechaOrden.HyperLink = Nothing
        Me.LblFechaOrden.Left = 1.894736!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 2.0!
        Me.LblFechaOrden.Width = 0.7894736!
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
        Me.LblEncabezado.Height = 0.2105263!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 0.0!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: normal; font-si" & _
            "ze: 9pt; font-family: Microsoft Sans Serif; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.6842105!
        Me.LblEncabezado.Width = 2.789474!
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
        Me.Label18.Height = 0.3157895!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 2.052632!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label18.Text = "Saldo"
        Me.Label18.Top = 2.789474!
        Me.Label18.Width = 0.6315789!
        '
        'Label23
        '
        Me.Label23.Border.BottomColor = System.Drawing.Color.Black
        Me.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.LeftColor = System.Drawing.Color.Black
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.RightColor = System.Drawing.Color.Black
        Me.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.TopColor = System.Drawing.Color.Black
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Height = 0.3157895!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.8421052!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label23.Text = "Monto Credito"
        Me.Label23.Top = 2.789474!
        Me.Label23.Width = 0.6315789!
        '
        'Label15
        '
        Me.Label15.Border.BottomColor = System.Drawing.Color.Black
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.LeftColor = System.Drawing.Color.Black
        Me.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.RightColor = System.Drawing.Color.Black
        Me.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.TopColor = System.Drawing.Color.Black
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Height = 0.3157895!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 1.473684!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label15.Text = "Monto Pago"
        Me.Label15.Top = 2.789474!
        Me.Label15.Width = 0.5789473!
        '
        'Label22
        '
        Me.Label22.Border.BottomColor = System.Drawing.Color.Black
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.LeftColor = System.Drawing.Color.Black
        Me.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.RightColor = System.Drawing.Color.Black
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.TopColor = System.Drawing.Color.Black
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Height = 0.3157895!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.2631579!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label22.Text = "No Factura"
        Me.Label22.Top = 2.789474!
        Me.Label22.Width = 0.5789474!
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
        Me.Label1.Height = 0.2105262!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.2105263!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: #404040; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: " & _
            "8.25pt; "
        Me.Label1.Text = "Cliente"
        Me.Label1.Top = 2.210526!
        Me.Label1.Width = 0.5263157!
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
        Me.LblNombres.Height = 0.3157894!
        Me.LblNombres.HyperLink = Nothing
        Me.LblNombres.Left = 0.7368422!
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Cambria; "
        Me.LblNombres.Text = ""
        Me.LblNombres.Top = 2.210526!
        Me.LblNombres.Width = 1.947368!
        '
        'LblTelefono
        '
        Me.LblTelefono.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTelefono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefono.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTelefono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefono.Border.RightColor = System.Drawing.Color.Black
        Me.LblTelefono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefono.Border.TopColor = System.Drawing.Color.Black
        Me.LblTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTelefono.Height = 0.2105263!
        Me.LblTelefono.HyperLink = Nothing
        Me.LblTelefono.Left = 0.0!
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "ddo-char-set: 0; text-align: center; font-style: normal; font-size: 9pt; font-fam" & _
            "ily: Cambria; "
        Me.LblTelefono.Text = ""
        Me.LblTelefono.Top = 1.315789!
        Me.LblTelefono.Width = 2.789474!
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
        Me.Label5.Height = 0.2105263!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.2105263!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: #404040; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: " & _
            "8.25pt; "
        Me.Label5.Text = "Cajero"
        Me.Label5.Top = 2.526316!
        Me.Label5.Width = 0.6315789!
        '
        'TxtVendedor
        '
        Me.TxtVendedor.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtVendedor.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtVendedor.Border.RightColor = System.Drawing.Color.Black
        Me.TxtVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtVendedor.Border.TopColor = System.Drawing.Color.Black
        Me.TxtVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtVendedor.Height = 0.2105263!
        Me.TxtVendedor.Left = 0.8421053!
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Cambria; "
        Me.TxtVendedor.Text = Nothing
        Me.TxtVendedor.Top = 2.526316!
        Me.TxtVendedor.Width = 1.842105!
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
        Me.Label6.Left = 0.6315789!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-weight: normal; font-size: 11.25pt; font-family: Elephant; " & _
            ""
        Me.Label6.Text = "RECIBO DE CAJA"
        Me.Label6.Top = 1.631579!
        Me.Label6.Width = 1.736842!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox5, Me.TextBox3, Me.TextBox4, Me.TextBox1})
        Me.Detail1.Height = 0.2291667!
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
        Me.TextBox5.DataField = "Saldo"
        Me.TextBox5.Height = 0.2105263!
        Me.TextBox5.Left = 2.052632!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Cambria; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.6315789!
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
        Me.TextBox3.DataField = "MontoCredito"
        Me.TextBox3.Height = 0.2105263!
        Me.TextBox3.Left = 0.8421052!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Cambria; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.6315789!
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
        Me.TextBox4.DataField = "MontoPagado"
        Me.TextBox4.Height = 0.2105263!
        Me.TextBox4.Left = 1.473684!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Cambria; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.5789473!
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
        Me.TextBox1.DataField = "Numero_Factura"
        Me.TextBox1.Height = 0.2105263!
        Me.TextBox1.Left = 0.2631579!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Cambria; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.5789474!
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
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblPagadoRecibo, Me.Label8, Me.Label2, Me.LblMontoTexto})
        Me.ReportFooter1.Height = 2.09375!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'LblPagadoRecibo
        '
        Me.LblPagadoRecibo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPagadoRecibo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagadoRecibo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPagadoRecibo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagadoRecibo.Border.RightColor = System.Drawing.Color.Black
        Me.LblPagadoRecibo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagadoRecibo.Border.TopColor = System.Drawing.Color.Black
        Me.LblPagadoRecibo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagadoRecibo.Height = 0.1875!
        Me.LblPagadoRecibo.HyperLink = Nothing
        Me.LblPagadoRecibo.Left = 1.789474!
        Me.LblPagadoRecibo.Name = "LblPagadoRecibo"
        Me.LblPagadoRecibo.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblPagadoRecibo.Text = ""
        Me.LblPagadoRecibo.Top = 0.0!
        Me.LblPagadoRecibo.Width = 0.875!
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
        Me.Label8.Left = 0.6842105!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: Black; ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8" & _
            ".25pt; "
        Me.Label8.Text = "Total Recibido"
        Me.Label8.Top = 0.0!
        Me.Label8.Width = 1.125!
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
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Height = 0.2105263!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.5263157!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: center; "
        Me.Label2.Text = "Recibi Conforme"
        Me.Label2.Top = 1.368421!
        Me.Label2.Width = 1.578947!
        '
        'LblMontoTexto
        '
        Me.LblMontoTexto.Border.BottomColor = System.Drawing.Color.Black
        Me.LblMontoTexto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMontoTexto.Border.LeftColor = System.Drawing.Color.Black
        Me.LblMontoTexto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMontoTexto.Border.RightColor = System.Drawing.Color.Black
        Me.LblMontoTexto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMontoTexto.Border.TopColor = System.Drawing.Color.Black
        Me.LblMontoTexto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMontoTexto.Height = 0.3157895!
        Me.LblMontoTexto.HyperLink = Nothing
        Me.LblMontoTexto.Left = 0.3157895!
        Me.LblMontoTexto.Name = "LblMontoTexto"
        Me.LblMontoTexto.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Cambria; "
        Me.LblMontoTexto.Text = ""
        Me.LblMontoTexto.Top = 0.3157895!
        Me.LblMontoTexto.Width = 2.368421!
        '
        'ArepReciboTira
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaFacturacionSystemsAndSolutions;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.1!
        Me.PageSettings.Margins.Left = 0.02!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.1!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.864583!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPagadoRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMontoTexto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoCompra As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtVendedor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblPagadoRecibo As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMontoTexto As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
End Class
