<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepRecepcion 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepRecepcion))
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
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.LblLote = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.LblApellidos = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lneBillTo = New DataDynamics.ActiveReports.Line
        Me.lblProductName = New DataDynamics.ActiveReports.Label
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.lblQty = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.LblBodegas = New DataDynamics.ActiveReports.Label
        Me.LblBarco = New DataDynamics.ActiveReports.Label
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.LblConductor = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.LblOrigen = New DataDynamics.ActiveReports.Label
        Me.LblCedula = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.LblPila = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.LblPlaca = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.lblSubTotals = New DataDynamics.ActiveReports.Label
        Me.LblNotas = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblBarco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPila, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblOrderNum, Me.lblOrderDate, Me.ImgLogo, Me.LblEncabezado, Me.LblDireccion, Me.LblRuc, Me.LblOrden, Me.LblFechaOrden, Me.LblTipoCompra, Me.Label11, Me.LblLote})
        Me.PageHeader1.Height = 1.25!
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
        Me.lblOrderNum.Left = 3.875!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "text-align: left; font-weight: bold; "
        Me.lblOrderNum.Text = "Recepción #:"
        Me.lblOrderNum.Top = 0.625!
        Me.lblOrderNum.Width = 1.0!
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
        Me.lblOrderDate.Left = 3.875!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "text-align: left; font-weight: bold; "
        Me.lblOrderDate.Text = "Fecha Orden:"
        Me.lblOrderDate.Top = 0.8125!
        Me.lblOrderDate.Width = 1.0!
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
        Me.ImgLogo.Height = 0.7368421!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.157895!
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
        Me.LblEncabezado.Height = 0.368421!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 1.578947!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 15.75pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.05263158!
        Me.LblEncabezado.Width = 2.947368!
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
        Me.LblDireccion.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.75!
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
        Me.LblRuc.Left = 0.0!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 0.9473684!
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
        Me.LblOrden.Left = 4.9375!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = ""
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 0.625!
        Me.LblOrden.Width = 0.8125!
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
        Me.LblFechaOrden.Left = 4.9375!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = ""
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 0.8125!
        Me.LblFechaOrden.Width = 0.8125!
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
        Me.LblTipoCompra.Left = 4.9375!
        Me.LblTipoCompra.Name = "LblTipoCompra"
        Me.LblTipoCompra.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 14.25pt; "
        Me.LblTipoCompra.Text = "Recepción"
        Me.LblTipoCompra.Top = 0.0!
        Me.LblTipoCompra.Width = 1.5625!
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
        Me.Label11.Left = 3.875!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: left; font-weight: bold; "
        Me.Label11.Text = "Lote No."
        Me.Label11.Top = 1.0!
        Me.Label11.Width = 1.0!
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
        Me.LblLote.Left = 4.9375!
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Style = "ddo-char-set: 0; font-size: 9.75pt; "
        Me.LblLote.Text = ""
        Me.LblLote.Top = 1.0!
        Me.LblLote.Width = 1.5625!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox7})
        Me.Detail1.Height = 0.5208333!
        Me.Detail1.Name = "Detail1"
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
        Me.TextBox2.DataField = "Cantidad"
        Me.TextBox2.Height = 0.2105263!
        Me.TextBox2.Left = 5.2!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.5789472!
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
        Me.TextBox3.Height = 0.2105263!
        Me.TextBox3.Left = 0.6842105!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 4.526316!
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
        Me.TextBox4.Left = 0.0!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.6842105!
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
        Me.TextBox5.DataField = "Unidad_Medida"
        Me.TextBox5.Height = 0.2105263!
        Me.TextBox5.Left = 0.6842105!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.2105263!
        Me.TextBox5.Width = 4.526316!
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
        Me.TextBox7.DataField = "PesoKg"
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 5.75!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.5000002!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.02083333!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.25!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblApellidos, Me.Label1, Me.lneBillTo, Me.lblProductName, Me.lblProductID, Me.lblQty, Me.Label3, Me.Label5, Me.Line2, Me.LblBodegas, Me.LblBarco, Me.LblNombres, Me.LblConductor, Me.Label2, Me.Label4, Me.Label6, Me.LblOrigen, Me.LblCedula, Me.Label8, Me.Label9, Me.LblPila, Me.Label10, Me.LblPlaca})
        Me.GroupHeader1.DataField = "NumeroRecepcion"
        Me.GroupHeader1.Height = 1.34375!
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.LblApellidos.Left = 5.9375!
        Me.LblApellidos.Name = "LblApellidos"
        Me.LblApellidos.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblApellidos.Text = ""
        Me.LblApellidos.Top = 0.25!
        Me.LblApellidos.Visible = False
        Me.LblApellidos.Width = 1.526316!
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
        Me.Label1.Height = 0.1979167!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label1.Text = "Proveedor"
        Me.Label1.Top = 0.0625!
        Me.Label1.Width = 1.0!
        '
        'lneBillTo
        '
        Me.lneBillTo.Border.BottomColor = System.Drawing.Color.Black
        Me.lneBillTo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lneBillTo.Border.LeftColor = System.Drawing.Color.Black
        Me.lneBillTo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lneBillTo.Border.RightColor = System.Drawing.Color.Black
        Me.lneBillTo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lneBillTo.Border.TopColor = System.Drawing.Color.Black
        Me.lneBillTo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lneBillTo.Height = 0.0!
        Me.lneBillTo.Left = 0.0!
        Me.lneBillTo.LineWeight = 2.0!
        Me.lneBillTo.Name = "lneBillTo"
        Me.lneBillTo.Top = 0.25!
        Me.lneBillTo.Width = 3.0!
        Me.lneBillTo.X1 = 0.0!
        Me.lneBillTo.X2 = 3.0!
        Me.lneBillTo.Y1 = 0.25!
        Me.lneBillTo.Y2 = 0.25!
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
        Me.lblProductName.Height = 0.2105264!
        Me.lblProductName.HyperLink = Nothing
        Me.lblProductName.Left = 0.6875!
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblProductName.Text = "Nombre Producto"
        Me.lblProductName.Top = 1.125!
        Me.lblProductName.Width = 4.526316!
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
        Me.lblProductID.Left = 0.0!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblProductID.Text = "Product ID"
        Me.lblProductID.Top = 1.125!
        Me.lblProductID.Width = 0.6842105!
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
        Me.lblQty.Height = 0.2105264!
        Me.lblQty.HyperLink = Nothing
        Me.lblQty.Left = 5.2!
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.lblQty.Text = "Qty"
        Me.lblQty.Top = 1.125!
        Me.lblQty.Width = 0.5789472!
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
        Me.Label3.Height = 0.2105263!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 5.775!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label3.Text = "Kg"
        Me.Label3.Top = 1.125!
        Me.Label3.Width = 0.4736845!
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
        Me.Label5.Left = 4.25!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: #000040; text-align: left; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label5.Text = "Bodega"
        Me.Label5.Top = 0.0625!
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
        Me.Line2.Left = 4.157895!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.2631579!
        Me.Line2.Width = 1.578947!
        Me.Line2.X1 = 4.157895!
        Me.Line2.X2 = 5.736842!
        Me.Line2.Y1 = 0.2631579!
        Me.Line2.Y2 = 0.2631579!
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
        Me.LblBodegas.Left = 4.9375!
        Me.LblBodegas.Name = "LblBodegas"
        Me.LblBodegas.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblBodegas.Text = ""
        Me.LblBodegas.Top = 0.0625!
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
        Me.LblBarco.Left = 5.9375!
        Me.LblBarco.Name = "LblBarco"
        Me.LblBarco.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblBarco.Text = ""
        Me.LblBarco.Top = 0.0625!
        Me.LblBarco.Visible = False
        Me.LblBarco.Width = 1.526316!
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
        Me.LblNombres.Height = 0.3333333!
        Me.LblNombres.HyperLink = Nothing
        Me.LblNombres.Left = 0.8333333!
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblNombres.Text = ""
        Me.LblNombres.Top = 0.3333333!
        Me.LblNombres.Width = 2.722222!
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
        Me.LblConductor.Height = 0.1666667!
        Me.LblConductor.HyperLink = Nothing
        Me.LblConductor.Left = 4.611111!
        Me.LblConductor.Name = "LblConductor"
        Me.LblConductor.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblConductor.Text = ""
        Me.LblConductor.Top = 0.3333333!
        Me.LblConductor.Width = 1.888889!
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
        Me.Label2.Height = 0.2105263!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label2.Text = "Nombre"
        Me.Label2.Top = 0.3125!
        Me.Label2.Width = 0.7368421!
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
        Me.Label4.Height = 0.2105263!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label4.Text = "Origen"
        Me.Label4.Top = 0.5625!
        Me.Label4.Visible = False
        Me.Label4.Width = 0.7368421!
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
        Me.Label6.Left = 3.888889!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label6.Text = "Conductor"
        Me.Label6.Top = 0.3333333!
        Me.Label6.Width = 0.6875!
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
        Me.LblOrigen.Height = 0.1666667!
        Me.LblOrigen.HyperLink = Nothing
        Me.LblOrigen.Left = 0.8333333!
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblOrigen.Text = ""
        Me.LblOrigen.Top = 0.6111111!
        Me.LblOrigen.Visible = False
        Me.LblOrigen.Width = 2.722222!
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
        Me.LblCedula.Height = 0.1666667!
        Me.LblCedula.HyperLink = Nothing
        Me.LblCedula.Left = 4.611111!
        Me.LblCedula.Name = "LblCedula"
        Me.LblCedula.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblCedula.Text = ""
        Me.LblCedula.Top = 0.5555556!
        Me.LblCedula.Width = 1.888889!
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
        Me.Label8.Left = 3.888889!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label8.Text = "Cedula"
        Me.Label8.Top = 0.5555556!
        Me.Label8.Width = 0.6875!
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
        Me.Label9.Height = 0.2105263!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label9.Text = "Pila"
        Me.Label9.Top = 0.8125!
        Me.Label9.Visible = False
        Me.Label9.Width = 0.7368421!
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
        Me.LblPila.Left = 0.8125!
        Me.LblPila.Name = "LblPila"
        Me.LblPila.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblPila.Text = ""
        Me.LblPila.Top = 0.8125!
        Me.LblPila.Visible = False
        Me.LblPila.Width = 2.736842!
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
        Me.Label10.Left = 3.888889!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label10.Text = "Placa"
        Me.Label10.Top = 0.8333333!
        Me.Label10.Width = 0.6875!
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
        Me.LblPlaca.Height = 0.1666667!
        Me.LblPlaca.HyperLink = Nothing
        Me.LblPlaca.Left = 4.611111!
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblPlaca.Text = ""
        Me.LblPlaca.Top = 0.8333333!
        Me.LblPlaca.Width = 1.888889!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblSubTotals, Me.LblNotas, Me.Label7, Me.TextBox6})
        Me.GroupFooter1.Height = 0.5416667!
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
        Me.lblSubTotals.Height = 0.2105263!
        Me.lblSubTotals.HyperLink = Nothing
        Me.lblSubTotals.Left = 4.421052!
        Me.lblSubTotals.Name = "lblSubTotals"
        Me.lblSubTotals.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblSubTotals.Text = "Sub Total "
        Me.lblSubTotals.Top = 0.0!
        Me.lblSubTotals.Width = 0.7894735!
        '
        'LblNotas
        '
        Me.LblNotas.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNotas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNotas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Border.RightColor = System.Drawing.Color.Black
        Me.LblNotas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Border.TopColor = System.Drawing.Color.Black
        Me.LblNotas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNotas.Height = 0.368421!
        Me.LblNotas.HyperLink = Nothing
        Me.LblNotas.Left = 1.157895!
        Me.LblNotas.Name = "LblNotas"
        Me.LblNotas.Style = ""
        Me.LblNotas.Text = ""
        Me.LblNotas.Top = 0.05263158!
        Me.LblNotas.Width = 3.105263!
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
        Me.Label7.Left = 0.0!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label7.Text = "Observaciones"
        Me.Label7.Top = 0.05263158!
        Me.Label7.Width = 1.125!
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
        Me.TextBox6.Height = 0.2105263!
        Me.TextBox6.Left = 5.263157!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 13pt; font-fam" & _
            "ily: Arial Black; "
        Me.TextBox6.SummaryGroup = "GroupHeader1"
        Me.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 1.052632!
        '
        'ArepRecepcion
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=FacturacionEMTRIDES;Data Source=JUANBERMUDEZ-PC\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.622807!
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
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblBarco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPila, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoCompra As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents LblApellidos As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents lneBillTo As DataDynamics.ActiveReports.Line
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductName As DataDynamics.ActiveReports.Label
    Private WithEvents lblQty As DataDynamics.ActiveReports.Label
    Private WithEvents lblSubTotals As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNotas As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents LblBodegas As DataDynamics.ActiveReports.Label
    Friend WithEvents LblBarco As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents LblConductor As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrigen As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCedula As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPila As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPlaca As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLote As DataDynamics.ActiveReports.Label
End Class
