<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepCuotas 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ArepCuotas))
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.lblInvoice = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.TxtBeneficiario = New DataDynamics.ActiveReports.TextBox
        Me.TxtModalidad = New DataDynamics.ActiveReports.TextBox
        Me.TxtInteres = New DataDynamics.ActiveReports.TextBox
        Me.TxtMonto = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaInicial = New DataDynamics.ActiveReports.TextBox
        Me.TxtCreditoNo = New DataDynamics.ActiveReports.TextBox
        Me.Barcode = New DataDynamics.ActiveReports.Barcode
        Me.TxtTitutlo = New DataDynamics.ActiveReports.TextBox
        Me.TxtDireccion = New DataDynamics.ActiveReports.TextBox
        Me.TxtRuc = New DataDynamics.ActiveReports.TextBox
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBeneficiario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtModalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCreditoNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTitutlo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.Label3, Me.lblInvoice, Me.Label1, Me.Label2, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Shape1, Me.Shape2, Me.TxtBeneficiario, Me.TxtModalidad, Me.TxtInteres, Me.TxtMonto, Me.TxtFechaInicial, Me.TxtCreditoNo, Me.Barcode, Me.TxtTitutlo, Me.TxtDireccion, Me.TxtRuc, Me.ImgLogo})
        Me.PageHeader1.Height = 2.895833!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.TextBox1.Left = 7.125!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = ""
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 1.25!
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
        Me.Label3.Left = 6.8125!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "Pag."
        Me.Label3.Top = 1.25!
        Me.Label3.Width = 0.3125!
        '
        'lblInvoice
        '
        Me.lblInvoice.Border.BottomColor = System.Drawing.Color.Black
        Me.lblInvoice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInvoice.Border.LeftColor = System.Drawing.Color.Black
        Me.lblInvoice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInvoice.Border.RightColor = System.Drawing.Color.Black
        Me.lblInvoice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInvoice.Border.TopColor = System.Drawing.Color.Black
        Me.lblInvoice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInvoice.Height = 0.375!
        Me.lblInvoice.HyperLink = Nothing
        Me.lblInvoice.Left = 6.0!
        Me.lblInvoice.Name = "lblInvoice"
        Me.lblInvoice.Style = "color: rgb(255,255,255); text-align: center; font-weight: bold; background-color:" & _
            " Navy; font-size: 20.5pt; "
        Me.lblInvoice.Text = "Credito No"
        Me.lblInvoice.Top = 0.0625!
        Me.lblInvoice.Width = 1.875!
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
        Me.Label1.Left = 0.75!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
            "15.75pt; font-family: Cambria; "
        Me.Label1.Text = "Calendario de Pagos"
        Me.Label1.Top = 2.3125!
        Me.Label1.Width = 6.5!
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
        Me.Label2.Height = 0.25!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.75!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
            "11.25pt; font-family: Cambria; "
        Me.Label2.Text = "No Cuotas"
        Me.Label2.Top = 2.625!
        Me.Label2.Width = 0.875!
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
        Me.Label4.Height = 0.25!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 1.625!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
            "11.25pt; font-family: Cambria; "
        Me.Label4.Text = "Cuota"
        Me.Label4.Top = 2.625!
        Me.Label4.Width = 1.125!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Height = 0.25!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 2.75!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
            "11.25pt; font-family: Cambria; "
        Me.Label5.Text = "Interes"
        Me.Label5.Top = 2.625!
        Me.Label5.Width = 1.125!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.25!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 3.875!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
            "11.25pt; font-family: Cambria; "
        Me.Label6.Text = "Manto Valor"
        Me.Label6.Top = 2.625!
        Me.Label6.Width = 1.125!
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
        Me.Label7.Height = 0.25!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 5.0!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
            "11.25pt; font-family: Cambria; "
        Me.Label7.Text = "Pago"
        Me.Label7.Top = 2.625!
        Me.Label7.Width = 1.125!
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
        Me.Label8.Height = 0.25!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 6.125!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
            "11.25pt; font-family: Cambria; "
        Me.Label8.Text = "Fecha"
        Me.Label8.Top = 2.625!
        Me.Label8.Width = 1.125!
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
        Me.Label9.Left = 0.375!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9." & _
            "75pt; font-family: Cambria; "
        Me.Label9.Text = "Modalidad"
        Me.Label9.Top = 1.6875!
        Me.Label9.Width = 0.9375!
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
        Me.Label10.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9." & _
            "75pt; font-family: Cambria; "
        Me.Label10.Text = "Interes Diario"
        Me.Label10.Top = 1.9375!
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
        Me.Label11.Left = 0.3125!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9." & _
            "75pt; font-family: Cambria; "
        Me.Label11.Text = "Beneficiario"
        Me.Label11.Top = 1.25!
        Me.Label11.Width = 0.9375!
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
        Me.Label12.Left = 4.0625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9." & _
            "75pt; font-family: Cambria; "
        Me.Label12.Text = "Monto"
        Me.Label12.Top = 1.6875!
        Me.Label12.Width = 0.875!
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
        Me.Label13.Left = 4.0625!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9." & _
            "75pt; font-family: Cambria; "
        Me.Label13.Text = "Fecha Inicial"
        Me.Label13.Top = 1.9375!
        Me.Label13.Width = 0.875!
        '
        'Shape1
        '
        Me.Shape1.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.RightColor = System.Drawing.Color.Black
        Me.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.TopColor = System.Drawing.Color.Black
        Me.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Height = 0.625!
        Me.Shape1.Left = 0.3125!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 1.625!
        Me.Shape1.Width = 3.625!
        '
        'Shape2
        '
        Me.Shape2.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.RightColor = System.Drawing.Color.Black
        Me.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.TopColor = System.Drawing.Color.Black
        Me.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Height = 0.625!
        Me.Shape2.Left = 3.9375!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 1.625!
        Me.Shape2.Width = 3.625!
        '
        'TxtBeneficiario
        '
        Me.TxtBeneficiario.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtBeneficiario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBeneficiario.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtBeneficiario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBeneficiario.Border.RightColor = System.Drawing.Color.Black
        Me.TxtBeneficiario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBeneficiario.Border.TopColor = System.Drawing.Color.Black
        Me.TxtBeneficiario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBeneficiario.Height = 0.1875!
        Me.TxtBeneficiario.Left = 1.25!
        Me.TxtBeneficiario.Name = "TxtBeneficiario"
        Me.TxtBeneficiario.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Cambria; "
        Me.TxtBeneficiario.Text = Nothing
        Me.TxtBeneficiario.Top = 1.25!
        Me.TxtBeneficiario.Width = 4.75!
        '
        'TxtModalidad
        '
        Me.TxtModalidad.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtModalidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtModalidad.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtModalidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtModalidad.Border.RightColor = System.Drawing.Color.Black
        Me.TxtModalidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtModalidad.Border.TopColor = System.Drawing.Color.Black
        Me.TxtModalidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtModalidad.Height = 0.1875!
        Me.TxtModalidad.Left = 1.3125!
        Me.TxtModalidad.Name = "TxtModalidad"
        Me.TxtModalidad.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Cambria; "
        Me.TxtModalidad.Text = Nothing
        Me.TxtModalidad.Top = 1.6875!
        Me.TxtModalidad.Width = 2.4375!
        '
        'TxtInteres
        '
        Me.TxtInteres.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtInteres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInteres.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtInteres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInteres.Border.RightColor = System.Drawing.Color.Black
        Me.TxtInteres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInteres.Border.TopColor = System.Drawing.Color.Black
        Me.TxtInteres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtInteres.Height = 0.1875!
        Me.TxtInteres.Left = 1.3125!
        Me.TxtInteres.Name = "TxtInteres"
        Me.TxtInteres.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Cambria; "
        Me.TxtInteres.Text = Nothing
        Me.TxtInteres.Top = 1.9375!
        Me.TxtInteres.Width = 2.4375!
        '
        'TxtMonto
        '
        Me.TxtMonto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMonto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMonto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMonto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMonto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMonto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMonto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMonto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMonto.Height = 0.1875!
        Me.TxtMonto.Left = 4.9375!
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Cambria; "
        Me.TxtMonto.Text = Nothing
        Me.TxtMonto.Top = 1.6875!
        Me.TxtMonto.Width = 2.4375!
        '
        'TxtFechaInicial
        '
        Me.TxtFechaInicial.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaInicial.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaInicial.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaInicial.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaInicial.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaInicial.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaInicial.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaInicial.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaInicial.Height = 0.1875!
        Me.TxtFechaInicial.Left = 4.9375!
        Me.TxtFechaInicial.Name = "TxtFechaInicial"
        Me.TxtFechaInicial.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Cambria; "
        Me.TxtFechaInicial.Text = Nothing
        Me.TxtFechaInicial.Top = 1.9375!
        Me.TxtFechaInicial.Width = 2.4375!
        '
        'TxtCreditoNo
        '
        Me.TxtCreditoNo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCreditoNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCreditoNo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCreditoNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCreditoNo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCreditoNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCreditoNo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCreditoNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCreditoNo.Height = 0.1875!
        Me.TxtCreditoNo.Left = 6.0!
        Me.TxtCreditoNo.Name = "TxtCreditoNo"
        Me.TxtCreditoNo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 15.75pt; font-" & _
            "family: Cambria; "
        Me.TxtCreditoNo.Text = Nothing
        Me.TxtCreditoNo.Top = 0.875!
        Me.TxtCreditoNo.Width = 1.875!
        '
        'Barcode
        '
        Me.Barcode.Border.BottomColor = System.Drawing.Color.Black
        Me.Barcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Barcode.Border.LeftColor = System.Drawing.Color.Black
        Me.Barcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Barcode.Border.RightColor = System.Drawing.Color.Black
        Me.Barcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Barcode.Border.TopColor = System.Drawing.Color.Black
        Me.Barcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Barcode.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Barcode.Height = 0.375!
        Me.Barcode.Left = 6.0!
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Text = "Barcode1"
        Me.Barcode.Top = 0.4375!
        Me.Barcode.Width = 1.875!
        '
        'TxtTitutlo
        '
        Me.TxtTitutlo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTitutlo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTitutlo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTitutlo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTitutlo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTitutlo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTitutlo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTitutlo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTitutlo.Height = 0.25!
        Me.TxtTitutlo.Left = 1.625!
        Me.TxtTitutlo.Name = "TxtTitutlo"
        Me.TxtTitutlo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.TxtTitutlo.Text = "Systems And Solutions"
        Me.TxtTitutlo.Top = 0.0625!
        Me.TxtTitutlo.Width = 4.3125!
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
        Me.TxtDireccion.Height = 0.375!
        Me.TxtDireccion.Left = 1.625!
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 12pt; font-fam" & _
            "ily: Cambria; "
        Me.TxtDireccion.Text = Nothing
        Me.TxtDireccion.Top = 0.3125!
        Me.TxtDireccion.Width = 4.3125!
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
        Me.TxtRuc.Height = 0.1875!
        Me.TxtRuc.Left = 1.625!
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 11.25pt; font-" & _
            "family: Cambria; "
        Me.TxtRuc.Text = Nothing
        Me.TxtRuc.Top = 0.6875!
        Me.TxtRuc.Width = 4.3125!
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
        Me.ImgLogo.Height = 1.0625!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0625!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0625!
        Me.ImgLogo.Width = 1.5!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8})
        Me.Detail1.Height = 0.21875!
        Me.Detail1.Name = "Detail1"
        '
        'TextBox3
        '
        Me.TextBox3.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.DataField = "NumCuota"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 0.75!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Cambria; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.875!
        '
        'TextBox4
        '
        Me.TextBox4.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.DataField = "Cuota"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 1.625!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; font-family: Cambria; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 1.125!
        '
        'TextBox5
        '
        Me.TextBox5.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.DataField = "Interes"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 2.75!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; font-family: Cambria; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 1.125!
        '
        'TextBox6
        '
        Me.TextBox6.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.DataField = "MantoValor"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 3.875!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; font-family: Cambria; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 1.125!
        '
        'TextBox7
        '
        Me.TextBox7.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox7.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox7.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox7.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox7.DataField = "Pago"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 5.0!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; font-family: Cambria; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 1.125!
        '
        'TextBox8
        '
        Me.TextBox8.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.DataField = "FechaPago"
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 6.125!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; font-family: Cambria; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 1.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ArepCuotas
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaCreditoSelf;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = "SELECT NumCuota, Cuota, InteresDevengado AS Interes, MantoValor, Pago, FechaPago " & _
            "FROM DetalleCredito WHERE (NumeroCredito = '-1')"
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.5!
        Me.PageSettings.Margins.Left = 0.1!
        Me.PageSettings.Margins.Right = 0.1!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.927083!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBeneficiario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtModalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCreditoNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTitutlo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents lblInvoice As DataDynamics.ActiveReports.Label
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Private WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents TxtBeneficiario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtModalidad As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtInteres As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMonto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaInicial As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCreditoNo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Barcode As DataDynamics.ActiveReports.Barcode
    Friend WithEvents TxtTitutlo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtDireccion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtRuc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
End Class
