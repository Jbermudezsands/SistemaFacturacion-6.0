<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepEstadoCuentas2 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepEstadoCuentas2))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.LblCodCliente = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.LblNombreCliente = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.LblMoneda = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.LblFecha = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.LblCargo = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.LblAbono = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.LblMora = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.LblSaldoFinal = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.Label25 = New DataDynamics.ActiveReports.Label
        Me.Label26 = New DataDynamics.ActiveReports.Label
        Me.Label27 = New DataDynamics.ActiveReports.Label
        Me.Label28 = New DataDynamics.ActiveReports.Label
        Me.TxtTotalCargo = New DataDynamics.ActiveReports.TextBox
        Me.TxtTotalAbono = New DataDynamics.ActiveReports.TextBox
        Me.TxtTotalSaldo = New DataDynamics.ActiveReports.TextBox
        Me.TxtTotalMora = New DataDynamics.ActiveReports.TextBox
        Me.TxtTotalSaldoFinal = New DataDynamics.ActiveReports.TextBox
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCodCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombreCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSaldoFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalMora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalSaldoFinal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.TextBox10, Me.TextBox11})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
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
        Me.TextBox2.DataField = "Fecha_Factura"
        Me.TextBox2.Height = 0.2105263!
        Me.TextBox2.Left = 0.0625!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.6842105!
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
        Me.TextBox3.DataField = "Numero_Factura"
        Me.TextBox3.Height = 0.2105263!
        Me.TextBox3.Left = 0.75!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.7894737!
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
        Me.TextBox4.DataField = "Numero_Recibo"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 1.5625!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.75!
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
        Me.TextBox5.Left = 2.3125!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.8125!
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
        Me.TextBox6.DataField = "FechaVence"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 3.125!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.75!
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
        Me.TextBox7.DataField = "Abono"
        Me.TextBox7.Height = 0.2105263!
        Me.TextBox7.Left = 3.875!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.7894737!
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
        Me.TextBox8.DataField = "Saldo"
        Me.TextBox8.Height = 0.2105263!
        Me.TextBox8.Left = 4.6875!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.7894737!
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
        Me.TextBox9.DataField = "Moratorio"
        Me.TextBox9.Height = 0.2105263!
        Me.TextBox9.Left = 5.5!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 0.7894737!
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
        Me.TextBox10.DataField = "Dias"
        Me.TextBox10.Height = 0.2105263!
        Me.TextBox10.Left = 6.25!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.4736843!
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
        Me.TextBox11.DataField = "Total"
        Me.TextBox11.Height = 0.2105263!
        Me.TextBox11.Left = 6.75!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.7894737!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.TextBox1, Me.Label3, Me.Label1, Me.lblProductID, Me.Label7, Me.Label8, Me.LblCodCliente, Me.Label10, Me.LblNombreCliente, Me.Label12, Me.LblMoneda, Me.Label14, Me.LblFecha, Me.Label16, Me.LblCargo, Me.Label18, Me.LblAbono, Me.Label20, Me.LblMora, Me.Label22, Me.LblSaldoFinal, Me.Label2, Me.Label4, Me.Label5, Me.Label6, Me.Label24, Me.Label25, Me.Label26, Me.Label27, Me.Label28})
        Me.GroupHeader1.DataField = "Cod_Cliente"
        Me.GroupHeader1.Height = 2.578947!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtTotalCargo, Me.TxtTotalAbono, Me.TxtTotalSaldo, Me.TxtTotalMora, Me.TxtTotalSaldoFinal})
        Me.GroupFooter1.Height = 0.25!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 1.052631!
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
        Me.Label3.Left = 6.68421!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "Pag."
        Me.Label3.Top = 1.052631!
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
        Me.Label1.Text = "Movimientos de Saldos"
        Me.Label1.Top = 0.6875!
        Me.Label1.Width = 7.4375!
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
        Me.lblProductID.Left = 0.05263158!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.lblProductID.Text = "Fecha"
        Me.lblProductID.Top = 2.368421!
        Me.lblProductID.Width = 0.6842105!
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
        Me.Label7.Left = 0.1052632!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label7.Text = "Impreso:"
        Me.Label7.Top = 1.052631!
        Me.Label7.Width = 1.5625!
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
        Me.Label8.Height = 0.1979167!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.2631579!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label8.Text = "Codigo Cliente"
        Me.Label8.Top = 1.421053!
        Me.Label8.Width = 1.0!
        '
        'LblCodCliente
        '
        Me.LblCodCliente.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCodCliente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodCliente.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCodCliente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodCliente.Border.RightColor = System.Drawing.Color.Black
        Me.LblCodCliente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodCliente.Border.TopColor = System.Drawing.Color.Black
        Me.LblCodCliente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodCliente.DataField = "Cod_Cliente"
        Me.LblCodCliente.Height = 0.1979167!
        Me.LblCodCliente.HyperLink = Nothing
        Me.LblCodCliente.Left = 1.263158!
        Me.LblCodCliente.Name = "LblCodCliente"
        Me.LblCodCliente.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblCodCliente.Text = ""
        Me.LblCodCliente.Top = 1.421053!
        Me.LblCodCliente.Width = 1.0!
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
        Me.Label10.Height = 0.1979167!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.2631579!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label10.Text = "Nombre Cliente"
        Me.Label10.Top = 1.631579!
        Me.Label10.Width = 1.0!
        '
        'LblNombreCliente
        '
        Me.LblNombreCliente.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNombreCliente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombreCliente.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNombreCliente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombreCliente.Border.RightColor = System.Drawing.Color.Black
        Me.LblNombreCliente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombreCliente.Border.TopColor = System.Drawing.Color.Black
        Me.LblNombreCliente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombreCliente.DataField = "Nombre_Cliente"
        Me.LblNombreCliente.Height = 0.1875!
        Me.LblNombreCliente.HyperLink = Nothing
        Me.LblNombreCliente.Left = 1.25!
        Me.LblNombreCliente.Name = "LblNombreCliente"
        Me.LblNombreCliente.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblNombreCliente.Text = ""
        Me.LblNombreCliente.Top = 1.625!
        Me.LblNombreCliente.Width = 6.1875!
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
        Me.Label12.Height = 0.1979167!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 2.526316!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label12.Text = "Moneda"
        Me.Label12.Top = 1.421053!
        Me.Label12.Width = 1.0!
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
        Me.LblMoneda.Height = 0.1979167!
        Me.LblMoneda.HyperLink = Nothing
        Me.LblMoneda.Left = 3.526316!
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblMoneda.Text = ""
        Me.LblMoneda.Top = 1.421053!
        Me.LblMoneda.Width = 1.0!
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
        Me.Label14.Height = 0.1979167!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 0.2631579!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label14.Text = "Saldo Al"
        Me.Label14.Top = 1.842105!
        Me.Label14.Width = 1.0!
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
        Me.LblFecha.Height = 0.1979167!
        Me.LblFecha.HyperLink = Nothing
        Me.LblFecha.Left = 1.263158!
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblFecha.Text = ""
        Me.LblFecha.Top = 1.842105!
        Me.LblFecha.Width = 1.0!
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
        Me.Label16.Height = 0.1979167!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 5.263157!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label16.Text = "Cargo"
        Me.Label16.Top = 1.421053!
        Me.Label16.Visible = False
        Me.Label16.Width = 1.0!
        '
        'LblCargo
        '
        Me.LblCargo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCargo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCargo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCargo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCargo.Border.RightColor = System.Drawing.Color.Black
        Me.LblCargo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCargo.Border.TopColor = System.Drawing.Color.Black
        Me.LblCargo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCargo.Height = 0.1979167!
        Me.LblCargo.HyperLink = Nothing
        Me.LblCargo.Left = 6.263157!
        Me.LblCargo.Name = "LblCargo"
        Me.LblCargo.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.LblCargo.Text = ""
        Me.LblCargo.Top = 1.421053!
        Me.LblCargo.Visible = False
        Me.LblCargo.Width = 1.0!
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
        Me.Label18.Height = 0.1979167!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 5.263157!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label18.Text = "Abonos"
        Me.Label18.Top = 1.631579!
        Me.Label18.Visible = False
        Me.Label18.Width = 1.0!
        '
        'LblAbono
        '
        Me.LblAbono.Border.BottomColor = System.Drawing.Color.Black
        Me.LblAbono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblAbono.Border.LeftColor = System.Drawing.Color.Black
        Me.LblAbono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblAbono.Border.RightColor = System.Drawing.Color.Black
        Me.LblAbono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblAbono.Border.TopColor = System.Drawing.Color.Black
        Me.LblAbono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblAbono.Height = 0.1979167!
        Me.LblAbono.HyperLink = Nothing
        Me.LblAbono.Left = 6.263157!
        Me.LblAbono.Name = "LblAbono"
        Me.LblAbono.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.LblAbono.Text = ""
        Me.LblAbono.Top = 1.631579!
        Me.LblAbono.Visible = False
        Me.LblAbono.Width = 1.0!
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
        Me.Label20.Height = 0.1979167!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 5.263157!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label20.Text = "Mora"
        Me.Label20.Top = 1.842105!
        Me.Label20.Visible = False
        Me.Label20.Width = 1.0!
        '
        'LblMora
        '
        Me.LblMora.Border.BottomColor = System.Drawing.Color.Black
        Me.LblMora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMora.Border.LeftColor = System.Drawing.Color.Black
        Me.LblMora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMora.Border.RightColor = System.Drawing.Color.Black
        Me.LblMora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMora.Border.TopColor = System.Drawing.Color.Black
        Me.LblMora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMora.Height = 0.1979167!
        Me.LblMora.HyperLink = Nothing
        Me.LblMora.Left = 6.263157!
        Me.LblMora.Name = "LblMora"
        Me.LblMora.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.LblMora.Text = ""
        Me.LblMora.Top = 1.842105!
        Me.LblMora.Visible = False
        Me.LblMora.Width = 1.0!
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
        Me.Label22.Height = 0.1979167!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 5.263157!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Label22.Text = "Saldo Final"
        Me.Label22.Top = 2.052632!
        Me.Label22.Visible = False
        Me.Label22.Width = 1.0!
        '
        'LblSaldoFinal
        '
        Me.LblSaldoFinal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSaldoFinal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSaldoFinal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSaldoFinal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSaldoFinal.Border.RightColor = System.Drawing.Color.Black
        Me.LblSaldoFinal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSaldoFinal.Border.TopColor = System.Drawing.Color.Black
        Me.LblSaldoFinal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSaldoFinal.Height = 0.1979167!
        Me.LblSaldoFinal.HyperLink = Nothing
        Me.LblSaldoFinal.Left = 6.263157!
        Me.LblSaldoFinal.Name = "LblSaldoFinal"
        Me.LblSaldoFinal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblSaldoFinal.Text = ""
        Me.LblSaldoFinal.Top = 2.052632!
        Me.LblSaldoFinal.Visible = False
        Me.LblSaldoFinal.Width = 1.0!
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
        Me.Label2.Height = 0.2105263!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.7368421!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label2.Text = "Factura No"
        Me.Label2.Top = 2.368421!
        Me.Label2.Width = 0.7894737!
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
        Me.Label4.Height = 0.2105263!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 1.526316!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label4.Text = "Recibo No"
        Me.Label4.Top = 2.368421!
        Me.Label4.Width = 0.7894737!
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
        Me.Label5.Height = 0.2105263!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 2.315789!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label5.Text = "Cargo"
        Me.Label5.Top = 2.368421!
        Me.Label5.Width = 0.7894737!
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
        Me.Label6.Height = 0.2105263!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 3.105263!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label6.Text = "Fecha Vence"
        Me.Label6.Top = 2.368421!
        Me.Label6.Width = 0.7894737!
        '
        'Label24
        '
        Me.Label24.Border.BottomColor = System.Drawing.Color.Black
        Me.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.LeftColor = System.Drawing.Color.Black
        Me.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.RightColor = System.Drawing.Color.Black
        Me.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.TopColor = System.Drawing.Color.Black
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Height = 0.2105263!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 3.894737!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label24.Text = "Abono"
        Me.Label24.Top = 2.368421!
        Me.Label24.Width = 0.7894737!
        '
        'Label25
        '
        Me.Label25.Border.BottomColor = System.Drawing.Color.Black
        Me.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.LeftColor = System.Drawing.Color.Black
        Me.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.RightColor = System.Drawing.Color.Black
        Me.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.TopColor = System.Drawing.Color.Black
        Me.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Height = 0.2105263!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 4.68421!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label25.Text = "Saldo"
        Me.Label25.Top = 2.368421!
        Me.Label25.Width = 0.7894737!
        '
        'Label26
        '
        Me.Label26.Border.BottomColor = System.Drawing.Color.Black
        Me.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.LeftColor = System.Drawing.Color.Black
        Me.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.RightColor = System.Drawing.Color.Black
        Me.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.TopColor = System.Drawing.Color.Black
        Me.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Height = 0.2105263!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 5.473684!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label26.Text = "Mora"
        Me.Label26.Top = 2.368421!
        Me.Label26.Width = 0.7894737!
        '
        'Label27
        '
        Me.Label27.Border.BottomColor = System.Drawing.Color.Black
        Me.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.LeftColor = System.Drawing.Color.Black
        Me.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.RightColor = System.Drawing.Color.Black
        Me.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.TopColor = System.Drawing.Color.Black
        Me.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Height = 0.2105263!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 6.263157!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label27.Text = "Dias"
        Me.Label27.Top = 2.368421!
        Me.Label27.Width = 0.4736843!
        '
        'Label28
        '
        Me.Label28.Border.BottomColor = System.Drawing.Color.Black
        Me.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.LeftColor = System.Drawing.Color.Black
        Me.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.RightColor = System.Drawing.Color.Black
        Me.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.TopColor = System.Drawing.Color.Black
        Me.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Height = 0.2105263!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 6.736842!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label28.Text = "Total Saldo"
        Me.Label28.Top = 2.368421!
        Me.Label28.Width = 0.7894737!
        '
        'TxtTotalCargo
        '
        Me.TxtTotalCargo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotalCargo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalCargo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotalCargo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalCargo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotalCargo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalCargo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotalCargo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalCargo.DataField = "Monto"
        Me.TxtTotalCargo.Height = 0.1875!
        Me.TxtTotalCargo.Left = 2.3125!
        Me.TxtTotalCargo.Name = "TxtTotalCargo"
        Me.TxtTotalCargo.OutputFormat = resources.GetString("TxtTotalCargo.OutputFormat")
        Me.TxtTotalCargo.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtTotalCargo.SummaryGroup = "GroupHeader1"
        Me.TxtTotalCargo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotalCargo.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtTotalCargo.Text = Nothing
        Me.TxtTotalCargo.Top = 0.0!
        Me.TxtTotalCargo.Width = 0.8125!
        '
        'TxtTotalAbono
        '
        Me.TxtTotalAbono.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotalAbono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalAbono.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotalAbono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalAbono.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotalAbono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalAbono.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotalAbono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalAbono.DataField = "Abono"
        Me.TxtTotalAbono.Height = 0.2105263!
        Me.TxtTotalAbono.Left = 3.875!
        Me.TxtTotalAbono.Name = "TxtTotalAbono"
        Me.TxtTotalAbono.OutputFormat = resources.GetString("TxtTotalAbono.OutputFormat")
        Me.TxtTotalAbono.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtTotalAbono.SummaryGroup = "GroupHeader1"
        Me.TxtTotalAbono.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotalAbono.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtTotalAbono.Text = Nothing
        Me.TxtTotalAbono.Top = 0.0!
        Me.TxtTotalAbono.Width = 0.7894737!
        '
        'TxtTotalSaldo
        '
        Me.TxtTotalSaldo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotalSaldo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalSaldo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotalSaldo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalSaldo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotalSaldo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalSaldo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotalSaldo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalSaldo.DataField = "Saldo"
        Me.TxtTotalSaldo.Height = 0.2105263!
        Me.TxtTotalSaldo.Left = 4.6875!
        Me.TxtTotalSaldo.Name = "TxtTotalSaldo"
        Me.TxtTotalSaldo.OutputFormat = resources.GetString("TxtTotalSaldo.OutputFormat")
        Me.TxtTotalSaldo.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtTotalSaldo.SummaryGroup = "GroupHeader1"
        Me.TxtTotalSaldo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotalSaldo.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtTotalSaldo.Text = Nothing
        Me.TxtTotalSaldo.Top = 0.0!
        Me.TxtTotalSaldo.Width = 0.7894737!
        '
        'TxtTotalMora
        '
        Me.TxtTotalMora.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotalMora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMora.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotalMora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMora.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotalMora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMora.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotalMora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMora.DataField = "Moratorio"
        Me.TxtTotalMora.Height = 0.2105263!
        Me.TxtTotalMora.Left = 5.5!
        Me.TxtTotalMora.Name = "TxtTotalMora"
        Me.TxtTotalMora.OutputFormat = resources.GetString("TxtTotalMora.OutputFormat")
        Me.TxtTotalMora.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtTotalMora.SummaryGroup = "GroupHeader1"
        Me.TxtTotalMora.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotalMora.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtTotalMora.Text = Nothing
        Me.TxtTotalMora.Top = 0.0!
        Me.TxtTotalMora.Width = 0.7894737!
        '
        'TxtTotalSaldoFinal
        '
        Me.TxtTotalSaldoFinal.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotalSaldoFinal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalSaldoFinal.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotalSaldoFinal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalSaldoFinal.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotalSaldoFinal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalSaldoFinal.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotalSaldoFinal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalSaldoFinal.CanGrow = False
        Me.TxtTotalSaldoFinal.DataField = "Total"
        Me.TxtTotalSaldoFinal.Height = 0.2105263!
        Me.TxtTotalSaldoFinal.Left = 6.75!
        Me.TxtTotalSaldoFinal.Name = "TxtTotalSaldoFinal"
        Me.TxtTotalSaldoFinal.OutputFormat = resources.GetString("TxtTotalSaldoFinal.OutputFormat")
        Me.TxtTotalSaldoFinal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtTotalSaldoFinal.SummaryGroup = "GroupHeader1"
        Me.TxtTotalSaldoFinal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotalSaldoFinal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtTotalSaldoFinal.Text = Nothing
        Me.TxtTotalSaldoFinal.Top = 0.0!
        Me.TxtTotalSaldoFinal.Width = 0.7894737!
        '
        'ArepEstadoCuentas2
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=SistemaFacturacionRevetsa;Data Source=JUANBERMUDEZ\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.3!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.3!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.635417!
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
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCodCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombreCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSaldoFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalMora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalSaldoFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCodCliente As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombreCliente As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMoneda As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCargo As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblAbono As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMora As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSaldoFinal As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Label24 As DataDynamics.ActiveReports.Label
    Private WithEvents Label25 As DataDynamics.ActiveReports.Label
    Private WithEvents Label26 As DataDynamics.ActiveReports.Label
    Private WithEvents Label27 As DataDynamics.ActiveReports.Label
    Private WithEvents Label28 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TxtTotalCargo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTotalAbono As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTotalSaldo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTotalMora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTotalSaldoFinal As DataDynamics.ActiveReports.TextBox
End Class 
