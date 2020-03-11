<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepReciboCajaTira 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepReciboCajaTira))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.LblReciboNo = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.LblTelefono = New DataDynamics.ActiveReports.Label
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.TxtVendedor = New DataDynamics.ActiveReports.TextBox
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.TxtRuc = New DataDynamics.ActiveReports.TextBox
        Me.TxtDireccion = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.LblPagadoRecibo = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.LblMontoTexto = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.LblObservaciones = New DataDynamics.ActiveReports.Label
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblReciboNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPagadoRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMontoTexto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label6, Me.LblReciboNo, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label22, Me.Label7, Me.Label8, Me.ImgLogo, Me.LblDireccion, Me.LblRuc, Me.LblEncabezado, Me.LblTelefono, Me.LblFechaOrden, Me.TxtVendedor, Me.LblNombres, Me.TxtRuc, Me.TxtDireccion})
        Me.PageHeader1.Height = 4.46875!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.Label6.Height = 0.2222222!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 12pt; font-f" & _
            "amily: Elephant; "
        Me.Label6.Text = "RECIBIDO"
        Me.Label6.Top = 0.7777779!
        Me.Label6.Width = 2.666667!
        '
        'LblReciboNo
        '
        Me.LblReciboNo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblReciboNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblReciboNo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblReciboNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblReciboNo.Border.RightColor = System.Drawing.Color.Black
        Me.LblReciboNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblReciboNo.Border.TopColor = System.Drawing.Color.Black
        Me.LblReciboNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblReciboNo.Height = 0.2222223!
        Me.LblReciboNo.HyperLink = Nothing
        Me.LblReciboNo.Left = 0.0!
        Me.LblReciboNo.Name = "LblReciboNo"
        Me.LblReciboNo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; "
        Me.LblReciboNo.Text = "Recibo Oficial No: 12344555"
        Me.LblReciboNo.Top = 2.333333!
        Me.LblReciboNo.Width = 2.666667!
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
        Me.Label1.Height = 0.2222223!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.3333333!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label1.Text = "Cajero:"
        Me.Label1.Top = 2.666667!
        Me.Label1.Width = 0.5!
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
        Me.Label2.Height = 0.2222222!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.3333333!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label2.Text = "Fecha:"
        Me.Label2.Top = 2.888889!
        Me.Label2.Width = 0.5!
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
        Me.Label3.Height = 0.2222221!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.3333333!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label3.Text = "Ced/Ruc:"
        Me.Label3.Top = 3.111111!
        Me.Label3.Width = 0.5!
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
        Me.Label4.Height = 0.2222223!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.3333333!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label4.Text = "Cliente:"
        Me.Label4.Top = 3.333333!
        Me.Label4.Width = 0.5!
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
        Me.Label5.Height = 0.2777778!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.3333333!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label5.Text = "Direccion"
        Me.Label5.Top = 3.666667!
        Me.Label5.Width = 0.5555556!
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
        Me.Label22.Height = 0.2777779!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.3888889!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label22.Text = "Concepto"
        Me.Label22.Top = 4.166667!
        Me.Label22.Width = 1.166667!
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
        Me.Label7.Height = 0.2777779!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 1.555556!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label7.Text = "No Factura"
        Me.Label7.Top = 4.166667!
        Me.Label7.Width = 0.5555555!
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
        Me.Label8.Height = 0.2777779!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 2.111111!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label8.Text = "Monto"
        Me.Label8.Top = 4.166667!
        Me.Label8.Width = 0.6111111!
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
        Me.ImgLogo.Left = 0.6111111!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.05555556!
        Me.ImgLogo.Visible = False
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
        Me.LblDireccion.Height = 0.4444445!
        Me.LblDireccion.HyperLink = Nothing
        Me.LblDireccion.Left = 0.0!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "ddo-char-set: 0; text-align: center; font-style: normal; font-size: 9pt; font-fam" & _
            "ily: Microsoft Sans Serif; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 1.333333!
        Me.LblDireccion.Width = 2.666667!
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
        Me.LblRuc.Height = 0.2222222!
        Me.LblRuc.HyperLink = Nothing
        Me.LblRuc.Left = 0.0!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "ddo-char-set: 0; text-align: center; font-style: normal; font-size: 9pt; font-fam" & _
            "ily: Cambria; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 1.777778!
        Me.LblRuc.Width = 2.666667!
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
        Me.LblEncabezado.Height = 0.2222222!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 0.0!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: normal; font-si" & _
            "ze: 9.75pt; font-family: Microsoft Sans Serif; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 1.111111!
        Me.LblEncabezado.Width = 2.666667!
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
        Me.LblTelefono.Height = 0.2222223!
        Me.LblTelefono.HyperLink = Nothing
        Me.LblTelefono.Left = 0.0!
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "ddo-char-set: 0; text-align: center; font-style: normal; font-size: 9pt; font-fam" & _
            "ily: Cambria; "
        Me.LblTelefono.Text = ""
        Me.LblTelefono.Top = 2.0!
        Me.LblTelefono.Width = 2.666667!
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
        Me.LblFechaOrden.Height = 0.2222222!
        Me.LblFechaOrden.HyperLink = Nothing
        Me.LblFechaOrden.Left = 0.8888889!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 2.888889!
        Me.LblFechaOrden.Width = 0.7222223!
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
        Me.TxtVendedor.Height = 0.2222223!
        Me.TxtVendedor.Left = 0.8888889!
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.TxtVendedor.Text = Nothing
        Me.TxtVendedor.Top = 2.666667!
        Me.TxtVendedor.Width = 1.833333!
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
        Me.LblNombres.Height = 0.2777779!
        Me.LblNombres.HyperLink = Nothing
        Me.LblNombres.Left = 0.8888889!
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.LblNombres.Text = ""
        Me.LblNombres.Top = 3.333333!
        Me.LblNombres.Width = 1.833333!
        '
        'TxtRuc
        '
        Me.TxtRuc.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtRuc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtRuc.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtRuc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtRuc.Border.RightColor = System.Drawing.Color.Black
        Me.TxtRuc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtRuc.Border.TopColor = System.Drawing.Color.Black
        Me.TxtRuc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtRuc.Height = 0.2222221!
        Me.TxtRuc.Left = 0.8888889!
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.TxtRuc.Text = Nothing
        Me.TxtRuc.Top = 3.111111!
        Me.TxtRuc.Width = 1.833333!
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtDireccion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDireccion.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtDireccion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDireccion.Border.RightColor = System.Drawing.Color.Black
        Me.TxtDireccion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDireccion.Border.TopColor = System.Drawing.Color.Black
        Me.TxtDireccion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDireccion.Height = 0.4444444!
        Me.TxtDireccion.Left = 0.8888889!
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.TxtDireccion.Text = Nothing
        Me.TxtDireccion.Top = 3.666667!
        Me.TxtDireccion.Width = 1.833333!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox4, Me.TextBox2, Me.TextBox1})
        Me.Detail1.Height = 0.2708333!
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
        Me.TextBox4.DataField = "MontoPagado"
        Me.TextBox4.Height = 0.2222222!
        Me.TextBox4.Left = 2.111111!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.6111111!
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
        Me.TextBox2.DataField = "Numero_Factura"
        Me.TextBox2.Height = 0.2222222!
        Me.TextBox2.Left = 1.555556!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; text-align: center; font-size: 6.75pt; font-family: Arial; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.5555555!
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
        Me.TextBox1.DataField = "Descripcion"
        Me.TextBox1.Height = 0.2222222!
        Me.TextBox1.Left = 0.4444444!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.111111!
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
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblPagadoRecibo, Me.Label10, Me.LblMontoTexto, Me.Label11, Me.LblObservaciones})
        Me.ReportFooter1.Height = 2.0625!
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
        Me.LblPagadoRecibo.Left = 1.833333!
        Me.LblPagadoRecibo.Name = "LblPagadoRecibo"
        Me.LblPagadoRecibo.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblPagadoRecibo.Text = ""
        Me.LblPagadoRecibo.Top = 0.0!
        Me.LblPagadoRecibo.Width = 0.875!
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
        Me.Label10.Left = 0.6666667!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "color: Black; ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8" & _
            ".25pt; "
        Me.Label10.Text = "Total Recibido"
        Me.Label10.Top = 0.0!
        Me.Label10.Width = 1.125!
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
        Me.LblMontoTexto.Height = 0.3333333!
        Me.LblMontoTexto.HyperLink = Nothing
        Me.LblMontoTexto.Left = 0.3888889!
        Me.LblMontoTexto.Name = "LblMontoTexto"
        Me.LblMontoTexto.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.LblMontoTexto.Text = ""
        Me.LblMontoTexto.Top = 0.2777778!
        Me.LblMontoTexto.Width = 2.333333!
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
        Me.Label11.Height = 0.2222222!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.2777778!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label11.Text = "Recibo necesita sello y Firma del Cajero"
        Me.Label11.Top = 1.722222!
        Me.Label11.Width = 2.388889!
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
        Me.LblObservaciones.Height = 0.5000001!
        Me.LblObservaciones.HyperLink = Nothing
        Me.LblObservaciones.Left = 0.3888889!
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.LblObservaciones.Text = ""
        Me.LblObservaciones.Top = 0.6666667!
        Me.LblObservaciones.Width = 2.333333!
        '
        'ArepReciboCajaTira
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=FacturacionEMTRIDES;Data Source=JUANBERMUDEZ-PC\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.01!
        Me.PageSettings.Margins.Right = 0.01!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.770834!
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
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblReciboNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPagadoRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMontoTexto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblReciboNo As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtVendedor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtRuc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtDireccion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents LblPagadoRecibo As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMontoTexto As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblObservaciones As DataDynamics.ActiveReports.Label
End Class 
