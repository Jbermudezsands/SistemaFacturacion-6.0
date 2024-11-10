<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepRecibo2 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ArepRecibo2))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.TxtRecibimosDe = New DataDynamics.ActiveReports.TextBox
        Me.TxtLaSumaDe = New DataDynamics.ActiveReports.TextBox
        Me.TxtConcepto = New DataDynamics.ActiveReports.TextBox
        Me.TxtFecha = New DataDynamics.ActiveReports.TextBox
        Me.TxtNoRecibo = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.TxtMonto = New DataDynamics.ActiveReports.TextBox
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.TxtObservaciones = New DataDynamics.ActiveReports.TextBox
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRecibimosDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtLaSumaDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNoRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.TxtRecibimosDe, Me.TxtLaSumaDe, Me.TxtConcepto, Me.TxtFecha, Me.TxtNoRecibo, Me.Label10, Me.TxtMonto, Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.Label9, Me.Label11, Me.TxtObservaciones})
        Me.Detail1.Height = 4.21875!
        Me.Detail1.Name = "Detail1"
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
        Me.Label1.Left = 0.2631579!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label1.Text = "Recibimos De:"
        Me.Label1.Top = 1.842105!
        Me.Label1.Width = 1.0!
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
        Me.Label2.Left = 0.2631579!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label2.Text = "La Suma de:"
        Me.Label2.Top = 2.157895!
        Me.Label2.Width = 1.0!
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
        Me.Label3.Height = 0.1979167!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.2631579!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label3.Text = "En Concepto de:"
        Me.Label3.Top = 2.473684!
        Me.Label3.Width = 1.0!
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
        Me.Label4.Height = 0.2631578!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.1052632!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.Label4.Text = "RECIBO OFICIAL DE CAJA"
        Me.Label4.Top = 0.7894737!
        Me.Label4.Width = 7.052631!
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
        Me.Label5.Left = 4.68421!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label5.Text = "Fecha:"
        Me.Label5.Top = 1.157895!
        Me.Label5.Width = 0.7894736!
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
        Me.Label6.Left = 4.68421!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label6.Text = "Recibo No."
        Me.Label6.Top = 1.421053!
        Me.Label6.Width = 0.7894736!
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
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.2105263!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.5!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; "
        Me.Label7.Text = "Vo.Bo"
        Me.Label7.Top = 3.75!
        Me.Label7.Width = 2.105263!
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
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.2105263!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 5.0!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; "
        Me.Label8.Text = "Cajero"
        Me.Label8.Top = 3.6875!
        Me.Label8.Width = 2.105263!
        '
        'TxtRecibimosDe
        '
        Me.TxtRecibimosDe.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtRecibimosDe.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtRecibimosDe.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtRecibimosDe.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtRecibimosDe.Border.RightColor = System.Drawing.Color.Black
        Me.TxtRecibimosDe.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtRecibimosDe.Border.TopColor = System.Drawing.Color.Black
        Me.TxtRecibimosDe.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtRecibimosDe.Height = 0.2105263!
        Me.TxtRecibimosDe.Left = 1.263158!
        Me.TxtRecibimosDe.Name = "TxtRecibimosDe"
        Me.TxtRecibimosDe.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TxtRecibimosDe.Text = Nothing
        Me.TxtRecibimosDe.Top = 1.842105!
        Me.TxtRecibimosDe.Width = 3.368421!
        '
        'TxtLaSumaDe
        '
        Me.TxtLaSumaDe.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtLaSumaDe.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtLaSumaDe.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtLaSumaDe.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtLaSumaDe.Border.RightColor = System.Drawing.Color.Black
        Me.TxtLaSumaDe.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtLaSumaDe.Border.TopColor = System.Drawing.Color.Black
        Me.TxtLaSumaDe.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtLaSumaDe.Height = 0.2105264!
        Me.TxtLaSumaDe.Left = 1.263158!
        Me.TxtLaSumaDe.Name = "TxtLaSumaDe"
        Me.TxtLaSumaDe.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TxtLaSumaDe.Text = Nothing
        Me.TxtLaSumaDe.Top = 2.157895!
        Me.TxtLaSumaDe.Width = 5.894737!
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtConcepto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConcepto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtConcepto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConcepto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtConcepto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConcepto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtConcepto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConcepto.Height = 0.4210526!
        Me.TxtConcepto.Left = 1.263158!
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TxtConcepto.Text = Nothing
        Me.TxtConcepto.Top = 2.473684!
        Me.TxtConcepto.Width = 5.894737!
        '
        'TxtFecha
        '
        Me.TxtFecha.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFecha.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFecha.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFecha.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFecha.Height = 0.2105263!
        Me.TxtFecha.Left = 5.473684!
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TxtFecha.Text = Nothing
        Me.TxtFecha.Top = 1.157895!
        Me.TxtFecha.Width = 1.631579!
        '
        'TxtNoRecibo
        '
        Me.TxtNoRecibo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtNoRecibo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNoRecibo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtNoRecibo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNoRecibo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtNoRecibo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNoRecibo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtNoRecibo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNoRecibo.Height = 0.2105263!
        Me.TxtNoRecibo.Left = 5.473684!
        Me.TxtNoRecibo.Name = "TxtNoRecibo"
        Me.TxtNoRecibo.Style = "ddo-char-set: 0; font-size: 12pt; "
        Me.TxtNoRecibo.Text = Nothing
        Me.TxtNoRecibo.Top = 1.421053!
        Me.TxtNoRecibo.Width = 1.631579!
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
        Me.Label10.Height = 0.2105263!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 5.105263!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label10.Text = "Monto"
        Me.Label10.Top = 1.842105!
        Me.Label10.Width = 0.4736843!
        '
        'TxtMonto
        '
        Me.TxtMonto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMonto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TxtMonto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMonto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMonto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMonto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMonto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMonto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMonto.Height = 0.2105263!
        Me.TxtMonto.Left = 5.578947!
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 12pt; "
        Me.TxtMonto.Text = Nothing
        Me.TxtMonto.Top = 1.842105!
        Me.TxtMonto.Width = 1.526316!
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
        Me.ImgLogo.Left = 0.05263158!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.368421!
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
        Me.LblTitulo.Height = 0.2631579!
        Me.LblTitulo.HyperLink = Nothing
        Me.LblTitulo.Left = 0.05263158!
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.LblTitulo.Text = "S&S"
        Me.LblTitulo.Top = 0.05263158!
        Me.LblTitulo.Width = 7.105263!
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
        Me.LblDireccion.Left = 0.05263158!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "text-align: center; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 0.3157895!
        Me.LblDireccion.Width = 7.105263!
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
        Me.LblRuc.Height = 0.1578947!
        Me.LblRuc.HyperLink = Nothing
        Me.LblRuc.Left = 0.05263158!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "text-align: center; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 0.5263157!
        Me.LblRuc.Width = 7.105263!
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
        Me.Label9.Height = 0.2105264!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.3125!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label9.Text = "Impreso Zeus Facturacion"
        Me.Label9.Top = 4.0!
        Me.Label9.Width = 3.157895!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
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
        Me.Label11.Height = 0.1979167!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.25!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label11.Text = "Observaciones:"
        Me.Label11.Top = 3.0!
        Me.Label11.Width = 1.0!
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtObservaciones.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtObservaciones.Border.RightColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtObservaciones.Border.TopColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtObservaciones.Height = 0.4210526!
        Me.TxtObservaciones.Left = 1.25!
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TxtObservaciones.Text = Nothing
        Me.TxtObservaciones.Top = 3.0!
        Me.TxtObservaciones.Width = 5.894737!
        '
        'ArepRecibo2
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.49!
        Me.PageSettings.Margins.Left = 0.42!
        Me.PageSettings.Margins.Right = 0.42!
        Me.PageSettings.Margins.Top = 0.2!
        Me.PageSettings.PaperHeight = 6.0!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperName = "Custom paper"
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
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRecibimosDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtLaSumaDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNoRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtRecibimosDe As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtLaSumaDe As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtConcepto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtNoRecibo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtMonto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtObservaciones As DataDynamics.ActiveReports.TextBox
End Class
