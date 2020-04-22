<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepPlanilla 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepPlanilla))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblOrderNum = New DataDynamics.ActiveReports.Label
        Me.lblOrderDate = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblOrden = New DataDynamics.ActiveReports.Label
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label19 = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.LblPeriodo = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.Label25 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
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
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox19 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox20 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox21 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox24 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox25 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox83 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox86 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.TextBox23 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox39 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox44 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox45 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox47 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox49 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox50 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox51 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPrecio = New DataDynamics.ActiveReports.TextBox
        Me.TxtLunes = New DataDynamics.ActiveReports.TextBox
        Me.TxtMartes = New DataDynamics.ActiveReports.TextBox
        Me.TxtMiercoles = New DataDynamics.ActiveReports.TextBox
        Me.TxtJueves = New DataDynamics.ActiveReports.TextBox
        Me.TextBox58 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox59 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox60 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox61 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox62 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox53 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox64 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox65 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox66 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox67 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox68 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox69 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox70 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox71 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox72 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox73 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox74 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox75 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox76 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox77 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox78 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox79 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox80 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox81 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox63 = New DataDynamics.ActiveReports.TextBox
        Me.TxtMontoLunes = New DataDynamics.ActiveReports.TextBox
        Me.TextBox52 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox54 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox55 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox56 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox57 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox82 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox84 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox85 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox89 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox90 = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.TextBox22 = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TextBox26 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox27 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox28 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox29 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox30 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox31 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox32 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox33 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox34 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox35 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox36 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox37 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox38 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox40 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox41 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox42 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox43 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox46 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox48 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox87 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox88 = New DataDynamics.ActiveReports.TextBox
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox83, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox86, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtLunes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMartes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMiercoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtJueves, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox71, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox72, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox73, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox74, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox75, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox76, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox77, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox78, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox79, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox80, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox81, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMontoLunes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox84, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox85, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox89, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox90, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox87, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox88, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblOrderNum, Me.lblOrderDate, Me.ImgLogo, Me.LblEncabezado, Me.LblDireccion, Me.LblOrden, Me.LblFechaOrden, Me.Label1, Me.Label2, Me.Label5, Me.Label3, Me.Label4, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.LblRuc, Me.LblPeriodo, Me.Label22, Me.Label25})
        Me.PageHeader1.Height = 2.166667!
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
        Me.lblOrderNum.Left = 10.625!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "text-align: right; font-weight: bold; "
        Me.lblOrderNum.Text = "Planilla #:"
        Me.lblOrderNum.Top = 1.125!
        Me.lblOrderNum.Width = 1.25!
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
        Me.lblOrderDate.Left = 10.625!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "text-align: right; font-weight: bold; "
        Me.lblOrderDate.Text = "Fecha Planilla:"
        Me.lblOrderDate.Top = 1.3125!
        Me.lblOrderDate.Width = 1.25!
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
        Me.LblEncabezado.Height = 0.375!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 1.6875!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 15.75pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.0!
        Me.LblEncabezado.Width = 9.6875!
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
        Me.LblDireccion.Top = 1.25!
        Me.LblDireccion.Width = 4.0!
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
        Me.LblOrden.Left = 11.875!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = ""
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 1.125!
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
        Me.LblFechaOrden.Left = 11.875!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = ""
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 1.3125!
        Me.LblFechaOrden.Width = 0.8125!
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
        Me.Label1.Left = 0.03571429!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label1.Text = "Codigo Productor"
        Me.Label1.Top = 1.821429!
        Me.Label1.Width = 0.6875!
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
        Me.Label2.Left = 0.7142857!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label2.Text = "Nombre Productor"
        Me.Label2.Top = 1.821429!
        Me.Label2.Width = 1.25!
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
        Me.Label5.Height = 0.3125!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 3.464286!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label5.Text = "Miercoles"
        Me.Label5.Top = 1.821429!
        Me.Label5.Width = 0.54!
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
        Me.Label3.Height = 0.3125!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.464286!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label3.Text = "Lunes"
        Me.Label3.Top = 1.821429!
        Me.Label3.Width = 0.52!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Height = 0.31!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 2.964286!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label4.Text = "Martes"
        Me.Label4.Top = 1.821429!
        Me.Label4.Width = 0.4999999!
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
        Me.Label6.Height = 0.3125!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 4.0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label6.Text = "Jueves"
        Me.Label6.Top = 1.821429!
        Me.Label6.Width = 0.52!
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
        Me.Label7.Height = 0.3125!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 4.535715!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label7.Text = "Viernes"
        Me.Label7.Top = 1.821429!
        Me.Label7.Width = 0.52!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.3125!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 5.06!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label8.Text = "Sabado"
        Me.Label8.Top = 1.821429!
        Me.Label8.Width = 0.52!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.3125!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 1.964286!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label9.Text = "Domingo"
        Me.Label9.Top = 1.821429!
        Me.Label9.Width = 0.52!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.3125!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 5.571429!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label10.Text = "TOTAL LITROS"
        Me.Label10.Top = 1.821429!
        Me.Label10.Width = 0.625!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.3125!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 6.2!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label11.Text = "Precio Unitario"
        Me.Label11.Top = 1.821429!
        Me.Label11.Width = 0.5625!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.3125!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 7.464285!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label12.Text = "IR"
        Me.Label12.Top = 1.821429!
        Me.Label12.Width = 0.5!
        '
        'Label13
        '
        Me.Label13.Border.BottomColor = System.Drawing.Color.Black
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.LeftColor = System.Drawing.Color.Black
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.RightColor = System.Drawing.Color.Black
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.TopColor = System.Drawing.Color.Black
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.31!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 11.10714!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label13.Text = "Otras Deduccion"
        Me.Label13.Top = 1.821429!
        Me.Label13.Width = 0.59!
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Height = 0.3125!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 8.964286!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label14.Text = "Transp"
        Me.Label14.Top = 1.821429!
        Me.Label14.Width = 0.5!
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
        Me.Label15.Height = 0.3125!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 9.464286!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label15.Text = "Pulperia"
        Me.Label15.Top = 1.821429!
        Me.Label15.Width = 0.5!
        '
        'Label16
        '
        Me.Label16.Border.BottomColor = System.Drawing.Color.Black
        Me.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.LeftColor = System.Drawing.Color.Black
        Me.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.RightColor = System.Drawing.Color.Black
        Me.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.TopColor = System.Drawing.Color.Black
        Me.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Height = 0.31!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 9.964286!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label16.Text = "Insemina Artificial"
        Me.Label16.Top = 1.821429!
        Me.Label16.Width = 0.52!
        '
        'Label17
        '
        Me.Label17.Border.BottomColor = System.Drawing.Color.Black
        Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.LeftColor = System.Drawing.Color.Black
        Me.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Border.RightColor = System.Drawing.Color.Black
        Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Border.TopColor = System.Drawing.Color.Black
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Height = 0.3125!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 10.46429!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label17.Text = "Productos Veterinarios"
        Me.Label17.Top = 1.821429!
        Me.Label17.Width = 0.63!
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
        Me.Label18.Height = 0.31!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 11.7!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label18.Text = "TOTAL EGRESOS"
        Me.Label18.Top = 1.821429!
        Me.Label18.Width = 0.72!
        '
        'Label19
        '
        Me.Label19.Border.BottomColor = System.Drawing.Color.Black
        Me.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.LeftColor = System.Drawing.Color.Black
        Me.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.RightColor = System.Drawing.Color.Black
        Me.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.TopColor = System.Drawing.Color.Black
        Me.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Height = 0.31!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 6.75!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label19.Text = "INGRESOS BRUTOS"
        Me.Label19.Top = 1.821429!
        Me.Label19.Width = 0.7142856!
        '
        'Label20
        '
        Me.Label20.Border.BottomColor = System.Drawing.Color.Black
        Me.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.LeftColor = System.Drawing.Color.Black
        Me.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.RightColor = System.Drawing.Color.Black
        Me.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.TopColor = System.Drawing.Color.Black
        Me.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Height = 0.31!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 12.42857!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label20.Text = "NETO PAGAR"
        Me.Label20.Top = 1.821429!
        Me.Label20.Width = 0.8214291!
        '
        'Label21
        '
        Me.Label21.Border.BottomColor = System.Drawing.Color.Black
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.LeftColor = System.Drawing.Color.Black
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.RightColor = System.Drawing.Color.Black
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.TopColor = System.Drawing.Color.Black
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Height = 0.3125!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 8.464286!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label21.Text = "Anticipo"
        Me.Label21.Top = 1.821429!
        Me.Label21.Width = 0.5!
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
        Me.LblRuc.Left = 0.0625!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 1.0625!
        Me.LblRuc.Width = 2.0!
        '
        'LblPeriodo
        '
        Me.LblPeriodo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPeriodo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPeriodo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPeriodo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPeriodo.Border.RightColor = System.Drawing.Color.Black
        Me.LblPeriodo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPeriodo.Border.TopColor = System.Drawing.Color.Black
        Me.LblPeriodo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPeriodo.Height = 0.1875!
        Me.LblPeriodo.HyperLink = Nothing
        Me.LblPeriodo.Left = 0.0!
        Me.LblPeriodo.Name = "LblPeriodo"
        Me.LblPeriodo.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblPeriodo.Text = ""
        Me.LblPeriodo.Top = 1.5625!
        Me.LblPeriodo.Width = 10.5625!
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
        Me.Label22.Height = 0.375!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 1.666667!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 15.75pt; "
        Me.Label22.Text = "PLANILLA DE PAGO DE LECHE A SOCIOS Y CLIENTES"
        Me.Label22.Top = 0.3888889!
        Me.Label22.Width = 9.6875!
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
        Me.Label25.Height = 0.3125!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 7.964285!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label25.Text = "Bolsa"
        Me.Label25.Top = 1.821429!
        Me.Label25.Width = 0.5!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox13, Me.TextBox14, Me.TextBox15, Me.TextBox16, Me.TextBox17, Me.TextBox18, Me.TextBox19, Me.TextBox20, Me.TextBox21, Me.TextBox24, Me.TextBox25, Me.TextBox83, Me.TextBox86})
        Me.Detail1.Height = 0.1770833!
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
        Me.TextBox1.DataField = "CodProductor"
        Me.TextBox1.Height = 0.1785714!
        Me.TextBox1.Left = 0.07142857!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox1.Text = "CodProductor"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.6428571!
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
        Me.TextBox2.DataField = "Nombres"
        Me.TextBox2.Height = 0.1785714!
        Me.TextBox2.Left = 0.71!
        Me.TextBox2.MultiLine = False
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = "NombreProductor"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 1.23!
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
        Me.TextBox3.DataField = "Lunes"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 2.5!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox3.Text = "Lunes"
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.51!
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
        Me.TextBox4.DataField = "Martes"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 3.0!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox4.Text = "Martes"
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.52!
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
        Me.TextBox5.DataField = "Miercoles"
        Me.TextBox5.Height = 0.1785714!
        Me.TextBox5.Left = 3.535714!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox5.Text = "Miercoles"
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.46!
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
        Me.TextBox6.DataField = "Jueves"
        Me.TextBox6.Height = 0.1875!
        Me.TextBox6.Left = 4.0!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox6.Text = "Jueves"
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.52!
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
        Me.TextBox7.DataField = "Viernes"
        Me.TextBox7.Height = 0.1875!
        Me.TextBox7.Left = 4.535715!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox7.Text = "Viernes"
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.52!
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
        Me.TextBox8.DataField = "Sabado"
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 5.06!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox8.Text = "Sabado"
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.52!
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
        Me.TextBox9.DataField = "Domingo"
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 1.964286!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox9.Text = "Domingo"
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 0.52!
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
        Me.TextBox10.DataField = "Total"
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 5.571429!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox10.Text = "TotalLitros"
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.625!
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
        Me.TextBox11.DataField = "PrecioVenta"
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 6.214285!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox11.Text = "PrecioUnitario"
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.5625!
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
        Me.TextBox12.DataField = "TotalIngresos"
        Me.TextBox12.Height = 0.19!
        Me.TextBox12.Left = 6.785715!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
        Me.TextBox12.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox12.Text = "IngresosBrutos"
        Me.TextBox12.Top = 0.0!
        Me.TextBox12.Width = 0.74!
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
        Me.TextBox13.DataField = "IR"
        Me.TextBox13.Height = 0.1875!
        Me.TextBox13.Left = 7.535715!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat")
        Me.TextBox13.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox13.Text = "IR"
        Me.TextBox13.Top = 0.0!
        Me.TextBox13.Width = 0.5!
        '
        'TextBox14
        '
        Me.TextBox14.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox14.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox14.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox14.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox14.DataField = "DeduccionPolicia"
        Me.TextBox14.Height = 0.1875!
        Me.TextBox14.Left = 8.107142!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat")
        Me.TextBox14.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox14.Text = "Policia"
        Me.TextBox14.Top = 0.5714286!
        Me.TextBox14.Width = 0.5!
        '
        'TextBox15
        '
        Me.TextBox15.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.DataField = "DeduccionTransporte"
        Me.TextBox15.Height = 0.1875!
        Me.TextBox15.Left = 9.0!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat")
        Me.TextBox15.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox15.Text = "Transporte"
        Me.TextBox15.Top = 0.0!
        Me.TextBox15.Width = 0.5!
        '
        'TextBox16
        '
        Me.TextBox16.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox16.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox16.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox16.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox16.DataField = "Anticipo"
        Me.TextBox16.Height = 0.1785714!
        Me.TextBox16.Left = 8.535714!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat")
        Me.TextBox16.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox16.Text = "Anticipo"
        Me.TextBox16.Top = 0.0!
        Me.TextBox16.Width = 0.4642856!
        '
        'TextBox17
        '
        Me.TextBox17.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox17.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox17.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox17.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox17.DataField = "Pulperia"
        Me.TextBox17.Height = 0.1875!
        Me.TextBox17.Left = 9.5!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat")
        Me.TextBox17.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox17.Text = "Pulperia"
        Me.TextBox17.Top = 0.0!
        Me.TextBox17.Width = 0.5!
        '
        'TextBox18
        '
        Me.TextBox18.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox18.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox18.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox18.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox18.DataField = "Inseminacion"
        Me.TextBox18.Height = 0.1875!
        Me.TextBox18.Left = 10.0!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat")
        Me.TextBox18.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox18.Text = "Inseminacion"
        Me.TextBox18.Top = 0.0!
        Me.TextBox18.Width = 0.52!
        '
        'TextBox19
        '
        Me.TextBox19.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox19.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox19.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox19.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox19.DataField = "ProductosVeterinarios"
        Me.TextBox19.Height = 0.1785714!
        Me.TextBox19.Left = 10.53571!
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat")
        Me.TextBox19.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox19.Text = "ProductosVeterinarios"
        Me.TextBox19.Top = 0.0!
        Me.TextBox19.Width = 0.5714285!
        '
        'TextBox20
        '
        Me.TextBox20.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox20.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox20.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox20.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox20.DataField = "TotalEgresos"
        Me.TextBox20.Height = 0.1785714!
        Me.TextBox20.Left = 11.67857!
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat")
        Me.TextBox20.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox20.Text = "TotalEgresos"
        Me.TextBox20.Top = 0.0!
        Me.TextBox20.Width = 0.72!
        '
        'TextBox21
        '
        Me.TextBox21.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox21.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox21.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox21.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox21.DataField = "NetoPagar"
        Me.TextBox21.Height = 0.1875!
        Me.TextBox21.Left = 12.42857!
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat")
        Me.TextBox21.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox21.Text = "NetoPagar"
        Me.TextBox21.Top = 0.0!
        Me.TextBox21.Width = 0.82!
        '
        'TextBox24
        '
        Me.TextBox24.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox24.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox24.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox24.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox24.DataField = "Anticipo"
        Me.TextBox24.Height = 0.1875!
        Me.TextBox24.Left = 8.821429!
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox24.Text = "Anticipo"
        Me.TextBox24.Top = 0.5714286!
        Me.TextBox24.Visible = False
        Me.TextBox24.Width = 0.5625!
        '
        'TextBox25
        '
        Me.TextBox25.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox25.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox25.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox25.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox25.DataField = "DeduccionTransporte"
        Me.TextBox25.Height = 0.1875!
        Me.TextBox25.Left = 9.464286!
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox25.Text = "Transporte"
        Me.TextBox25.Top = 0.5714286!
        Me.TextBox25.Visible = False
        Me.TextBox25.Width = 0.5625!
        '
        'TextBox83
        '
        Me.TextBox83.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox83.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox83.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox83.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox83.DataField = "OtrasDeducciones"
        Me.TextBox83.Height = 0.19!
        Me.TextBox83.Left = 11.10714!
        Me.TextBox83.Name = "TextBox83"
        Me.TextBox83.OutputFormat = resources.GetString("TextBox83.OutputFormat")
        Me.TextBox83.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox83.Text = Nothing
        Me.TextBox83.Top = 0.0!
        Me.TextBox83.Width = 0.58!
        '
        'TextBox86
        '
        Me.TextBox86.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox86.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox86.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox86.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox86.DataField = "Bolsa"
        Me.TextBox86.Height = 0.1875!
        Me.TextBox86.Left = 8.035714!
        Me.TextBox86.Name = "TextBox86"
        Me.TextBox86.OutputFormat = resources.GetString("TextBox86.OutputFormat")
        Me.TextBox86.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox86.Text = "Bolsa"
        Me.TextBox86.Top = 0.0!
        Me.TextBox86.Width = 0.5!
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
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label23, Me.Label24, Me.TextBox23, Me.TextBox39, Me.TextBox44, Me.TextBox45, Me.TextBox47, Me.TextBox49, Me.TextBox50, Me.TextBox51, Me.TxtPrecio, Me.TxtLunes, Me.TxtMartes, Me.TxtMiercoles, Me.TxtJueves, Me.TextBox58, Me.TextBox59, Me.TextBox60, Me.TextBox61, Me.TextBox62, Me.TextBox53, Me.TextBox64, Me.TextBox65, Me.TextBox66, Me.TextBox67, Me.TextBox68, Me.TextBox69, Me.TextBox70, Me.TextBox71, Me.TextBox72, Me.TextBox73, Me.TextBox74, Me.TextBox75, Me.TextBox76, Me.TextBox77, Me.TextBox78, Me.TextBox79, Me.TextBox80, Me.TextBox81, Me.TextBox63, Me.TxtMontoLunes, Me.TextBox52, Me.TextBox54, Me.TextBox55, Me.TextBox56, Me.TextBox57, Me.TextBox82, Me.TextBox84, Me.TextBox85, Me.TextBox89, Me.TextBox90})
        Me.ReportFooter1.Height = 2.927083!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Label23
        '
        Me.Label23.Border.BottomColor = System.Drawing.Color.Black
        Me.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.LeftColor = System.Drawing.Color.Black
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Border.RightColor = System.Drawing.Color.Black
        Me.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Border.TopColor = System.Drawing.Color.Black
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Height = 0.1666667!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 2.222222!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label23.Text = "INGRESOS"
        Me.Label23.Top = 0.1666667!
        Me.Label23.Width = 3.611111!
        '
        'Label24
        '
        Me.Label24.Border.BottomColor = System.Drawing.Color.Black
        Me.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.LeftColor = System.Drawing.Color.Black
        Me.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.RightColor = System.Drawing.Color.Black
        Me.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.TopColor = System.Drawing.Color.Black
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Height = 0.1666666!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 6.333333!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label24.Text = "EGRESOS"
        Me.Label24.Top = 0.1666667!
        Me.Label24.Width = 3.611111!
        '
        'TextBox23
        '
        Me.TextBox23.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox23.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox23.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox23.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox23.Height = 0.1875!
        Me.TextBox23.Left = 2.392857!
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox23.Text = "Lunes"
        Me.TextBox23.Top = 0.6428571!
        Me.TextBox23.Width = 0.5625!
        '
        'TextBox39
        '
        Me.TextBox39.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox39.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox39.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox39.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox39.Height = 0.1875!
        Me.TextBox39.Left = 2.392857!
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox39.Text = "Martes"
        Me.TextBox39.Top = 0.8571429!
        Me.TextBox39.Width = 0.5625!
        '
        'TextBox44
        '
        Me.TextBox44.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox44.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox44.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox44.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox44.Height = 0.1875!
        Me.TextBox44.Left = 2.392857!
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox44.Text = "Miercoles"
        Me.TextBox44.Top = 1.035714!
        Me.TextBox44.Width = 0.5625!
        '
        'TextBox45
        '
        Me.TextBox45.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox45.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox45.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox45.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox45.Height = 0.1875!
        Me.TextBox45.Left = 2.392857!
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox45.Text = "Jueves"
        Me.TextBox45.Top = 1.25!
        Me.TextBox45.Width = 0.5625!
        '
        'TextBox47
        '
        Me.TextBox47.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox47.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox47.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox47.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox47.Height = 0.1875!
        Me.TextBox47.Left = 2.392857!
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox47.Text = "Viernes"
        Me.TextBox47.Top = 1.464286!
        Me.TextBox47.Width = 0.5625!
        '
        'TextBox49
        '
        Me.TextBox49.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox49.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox49.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox49.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox49.Height = 0.1875!
        Me.TextBox49.Left = 2.392857!
        Me.TextBox49.Name = "TextBox49"
        Me.TextBox49.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox49.Text = "Sabado"
        Me.TextBox49.Top = 1.678571!
        Me.TextBox49.Width = 0.5625!
        '
        'TextBox50
        '
        Me.TextBox50.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox50.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox50.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox50.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox50.Height = 0.1875!
        Me.TextBox50.Left = 2.392857!
        Me.TextBox50.Name = "TextBox50"
        Me.TextBox50.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox50.Text = "Domingo"
        Me.TextBox50.Top = 0.4285714!
        Me.TextBox50.Width = 0.5625!
        '
        'TextBox51
        '
        Me.TextBox51.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox51.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox51.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox51.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox51.Height = 0.1666667!
        Me.TextBox51.Left = 2.388889!
        Me.TextBox51.Name = "TextBox51"
        Me.TextBox51.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox51.Text = "Total Lts"
        Me.TextBox51.Top = 1.888889!
        Me.TextBox51.Width = 0.5555555!
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPrecio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPrecio.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPrecio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPrecio.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPrecio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPrecio.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPrecio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPrecio.DataField = "PrecioVenta"
        Me.TxtPrecio.Height = 0.1875!
        Me.TxtPrecio.Left = 5.111111!
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.OutputFormat = resources.GetString("TxtPrecio.OutputFormat")
        Me.TxtPrecio.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtPrecio.Text = "PrecioUnitario"
        Me.TxtPrecio.Top = 0.3888889!
        Me.TxtPrecio.Visible = False
        Me.TxtPrecio.Width = 0.5625!
        '
        'TxtLunes
        '
        Me.TxtLunes.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtLunes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtLunes.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtLunes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtLunes.Border.RightColor = System.Drawing.Color.Black
        Me.TxtLunes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtLunes.Border.TopColor = System.Drawing.Color.Black
        Me.TxtLunes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtLunes.DataField = "Lunes"
        Me.TxtLunes.Height = 0.1875!
        Me.TxtLunes.Left = 3.0!
        Me.TxtLunes.Name = "TxtLunes"
        Me.TxtLunes.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtLunes.SummaryGroup = "GroupHeader1"
        Me.TxtLunes.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtLunes.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtLunes.Text = "Lunes"
        Me.TxtLunes.Top = 0.6428571!
        Me.TxtLunes.Width = 0.5625!
        '
        'TxtMartes
        '
        Me.TxtMartes.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMartes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMartes.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMartes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMartes.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMartes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMartes.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMartes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMartes.DataField = "Martes"
        Me.TxtMartes.Height = 0.1875!
        Me.TxtMartes.Left = 3.0!
        Me.TxtMartes.Name = "TxtMartes"
        Me.TxtMartes.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtMartes.SummaryGroup = "GroupHeader1"
        Me.TxtMartes.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtMartes.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtMartes.Text = "Martes"
        Me.TxtMartes.Top = 0.8571429!
        Me.TxtMartes.Width = 0.5625!
        '
        'TxtMiercoles
        '
        Me.TxtMiercoles.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMiercoles.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMiercoles.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMiercoles.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMiercoles.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMiercoles.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMiercoles.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMiercoles.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMiercoles.DataField = "Miercoles"
        Me.TxtMiercoles.Height = 0.1875!
        Me.TxtMiercoles.Left = 3.0!
        Me.TxtMiercoles.Name = "TxtMiercoles"
        Me.TxtMiercoles.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtMiercoles.SummaryGroup = "GroupHeader1"
        Me.TxtMiercoles.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtMiercoles.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtMiercoles.Text = "Miercoles"
        Me.TxtMiercoles.Top = 1.035714!
        Me.TxtMiercoles.Width = 0.5625!
        '
        'TxtJueves
        '
        Me.TxtJueves.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtJueves.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtJueves.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtJueves.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtJueves.Border.RightColor = System.Drawing.Color.Black
        Me.TxtJueves.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtJueves.Border.TopColor = System.Drawing.Color.Black
        Me.TxtJueves.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtJueves.DataField = "Jueves"
        Me.TxtJueves.Height = 0.1875!
        Me.TxtJueves.Left = 3.0!
        Me.TxtJueves.Name = "TxtJueves"
        Me.TxtJueves.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtJueves.SummaryGroup = "GroupHeader1"
        Me.TxtJueves.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtJueves.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtJueves.Text = "Jueves"
        Me.TxtJueves.Top = 1.25!
        Me.TxtJueves.Width = 0.5625!
        '
        'TextBox58
        '
        Me.TextBox58.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox58.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox58.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox58.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox58.DataField = "Viernes"
        Me.TextBox58.Height = 0.1875!
        Me.TextBox58.Left = 3.0!
        Me.TextBox58.Name = "TextBox58"
        Me.TextBox58.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox58.SummaryGroup = "GroupHeader1"
        Me.TextBox58.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox58.Text = "Viernes"
        Me.TextBox58.Top = 1.464286!
        Me.TextBox58.Width = 0.5625!
        '
        'TextBox59
        '
        Me.TextBox59.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox59.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox59.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox59.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox59.DataField = "Sabado"
        Me.TextBox59.Height = 0.1875!
        Me.TextBox59.Left = 3.0!
        Me.TextBox59.Name = "TextBox59"
        Me.TextBox59.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox59.SummaryGroup = "GroupHeader1"
        Me.TextBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox59.Text = "Sabado"
        Me.TextBox59.Top = 1.678571!
        Me.TextBox59.Width = 0.5625!
        '
        'TextBox60
        '
        Me.TextBox60.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox60.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox60.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox60.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox60.DataField = "Domingo"
        Me.TextBox60.Height = 0.1875!
        Me.TextBox60.Left = 3.0!
        Me.TextBox60.Name = "TextBox60"
        Me.TextBox60.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox60.SummaryGroup = "GroupHeader1"
        Me.TextBox60.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox60.Text = "Domingo"
        Me.TextBox60.Top = 0.4285714!
        Me.TextBox60.Width = 0.5625!
        '
        'TextBox61
        '
        Me.TextBox61.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox61.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox61.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox61.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox61.DataField = "Total"
        Me.TextBox61.Height = 0.1666667!
        Me.TextBox61.Left = 3.0!
        Me.TextBox61.Name = "TextBox61"
        Me.TextBox61.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox61.SummaryGroup = "GroupHeader1"
        Me.TextBox61.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox61.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox61.Text = "TotalLitros"
        Me.TextBox61.Top = 1.888889!
        Me.TextBox61.Width = 0.5555556!
        '
        'TextBox62
        '
        Me.TextBox62.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox62.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox62.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox62.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox62.Height = 0.1875!
        Me.TextBox62.Left = 4.5!
        Me.TextBox62.Name = "TextBox62"
        Me.TextBox62.OutputFormat = resources.GetString("TextBox62.OutputFormat")
        Me.TextBox62.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox62.Text = "PrecioUnitario"
        Me.TextBox62.Top = 0.3888889!
        Me.TextBox62.Visible = False
        Me.TextBox62.Width = 0.5625!
        '
        'TextBox53
        '
        Me.TextBox53.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox53.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox53.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox53.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox53.Height = 0.1666667!
        Me.TextBox53.Left = 6.392857!
        Me.TextBox53.Name = "TextBox53"
        Me.TextBox53.OutputFormat = resources.GetString("TextBox53.OutputFormat")
        Me.TextBox53.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox53.Text = "IR"
        Me.TextBox53.Top = 0.3928572!
        Me.TextBox53.Width = 0.8333331!
        '
        'TextBox64
        '
        Me.TextBox64.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox64.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox64.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox64.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox64.Height = 0.1666667!
        Me.TextBox64.Left = 6.388889!
        Me.TextBox64.Name = "TextBox64"
        Me.TextBox64.OutputFormat = resources.GetString("TextBox64.OutputFormat")
        Me.TextBox64.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox64.Text = "Policia"
        Me.TextBox64.Top = 0.6111111!
        Me.TextBox64.Width = 0.8333331!
        '
        'TextBox65
        '
        Me.TextBox65.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox65.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox65.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox65.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox65.Height = 0.1666667!
        Me.TextBox65.Left = 6.388889!
        Me.TextBox65.Name = "TextBox65"
        Me.TextBox65.OutputFormat = resources.GetString("TextBox65.OutputFormat")
        Me.TextBox65.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox65.Text = "Anticipo"
        Me.TextBox65.Top = 0.8333333!
        Me.TextBox65.Width = 0.8333331!
        '
        'TextBox66
        '
        Me.TextBox66.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox66.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox66.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox66.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox66.Height = 0.1666667!
        Me.TextBox66.Left = 6.388889!
        Me.TextBox66.Name = "TextBox66"
        Me.TextBox66.OutputFormat = resources.GetString("TextBox66.OutputFormat")
        Me.TextBox66.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox66.Text = "Transporte"
        Me.TextBox66.Top = 1.055556!
        Me.TextBox66.Width = 0.8333331!
        '
        'TextBox67
        '
        Me.TextBox67.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox67.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox67.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox67.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox67.Height = 0.1666667!
        Me.TextBox67.Left = 6.388889!
        Me.TextBox67.Name = "TextBox67"
        Me.TextBox67.OutputFormat = resources.GetString("TextBox67.OutputFormat")
        Me.TextBox67.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox67.Text = "Pulperia"
        Me.TextBox67.Top = 1.277778!
        Me.TextBox67.Width = 0.8333331!
        '
        'TextBox68
        '
        Me.TextBox68.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox68.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox68.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox68.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox68.Height = 0.1666666!
        Me.TextBox68.Left = 6.388889!
        Me.TextBox68.Name = "TextBox68"
        Me.TextBox68.OutputFormat = resources.GetString("TextBox68.OutputFormat")
        Me.TextBox68.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox68.Text = "Inseminacion"
        Me.TextBox68.Top = 1.5!
        Me.TextBox68.Width = 0.8333331!
        '
        'TextBox69
        '
        Me.TextBox69.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox69.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox69.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox69.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox69.Height = 0.1666667!
        Me.TextBox69.Left = 6.388889!
        Me.TextBox69.Name = "TextBox69"
        Me.TextBox69.OutputFormat = resources.GetString("TextBox69.OutputFormat")
        Me.TextBox69.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox69.Text = "ProductosVet"
        Me.TextBox69.Top = 1.722222!
        Me.TextBox69.Width = 0.8333331!
        '
        'TextBox70
        '
        Me.TextBox70.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox70.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox70.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox70.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox70.Height = 0.1666667!
        Me.TextBox70.Left = 6.388889!
        Me.TextBox70.Name = "TextBox70"
        Me.TextBox70.OutputFormat = resources.GetString("TextBox70.OutputFormat")
        Me.TextBox70.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox70.Text = "TotalEgresos"
        Me.TextBox70.Top = 1.944445!
        Me.TextBox70.Width = 0.8333331!
        '
        'TextBox71
        '
        Me.TextBox71.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox71.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox71.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox71.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox71.Height = 0.2222223!
        Me.TextBox71.Left = 6.388889!
        Me.TextBox71.Name = "TextBox71"
        Me.TextBox71.OutputFormat = resources.GetString("TextBox71.OutputFormat")
        Me.TextBox71.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 12pt; "
        Me.TextBox71.Text = "NetoPagar"
        Me.TextBox71.Top = 2.277778!
        Me.TextBox71.Width = 1.055555!
        '
        'TextBox72
        '
        Me.TextBox72.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox72.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox72.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox72.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox72.Height = 0.2222223!
        Me.TextBox72.Left = 2.388889!
        Me.TextBox72.Name = "TextBox72"
        Me.TextBox72.OutputFormat = resources.GetString("TextBox72.OutputFormat")
        Me.TextBox72.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox72.Text = "TOTAL INGRESOS"
        Me.TextBox72.Top = 2.277778!
        Me.TextBox72.Width = 1.833333!
        '
        'TextBox73
        '
        Me.TextBox73.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox73.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox73.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox73.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox73.DataField = "IR"
        Me.TextBox73.Height = 0.1666667!
        Me.TextBox73.Left = 7.277778!
        Me.TextBox73.Name = "TextBox73"
        Me.TextBox73.OutputFormat = resources.GetString("TextBox73.OutputFormat")
        Me.TextBox73.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox73.SummaryGroup = "GroupHeader1"
        Me.TextBox73.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox73.Text = Nothing
        Me.TextBox73.Top = 0.3888889!
        Me.TextBox73.Width = 0.7222223!
        '
        'TextBox74
        '
        Me.TextBox74.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox74.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox74.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox74.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox74.DataField = "DeduccionPolicia"
        Me.TextBox74.Height = 0.1666667!
        Me.TextBox74.Left = 7.277778!
        Me.TextBox74.Name = "TextBox74"
        Me.TextBox74.OutputFormat = resources.GetString("TextBox74.OutputFormat")
        Me.TextBox74.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox74.SummaryGroup = "GroupHeader1"
        Me.TextBox74.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox74.Text = Nothing
        Me.TextBox74.Top = 0.6111111!
        Me.TextBox74.Width = 0.7222223!
        '
        'TextBox75
        '
        Me.TextBox75.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox75.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox75.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox75.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox75.DataField = "Anticipo"
        Me.TextBox75.Height = 0.1666667!
        Me.TextBox75.Left = 7.277778!
        Me.TextBox75.Name = "TextBox75"
        Me.TextBox75.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox75.SummaryGroup = "GroupHeader1"
        Me.TextBox75.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox75.Text = Nothing
        Me.TextBox75.Top = 0.8333333!
        Me.TextBox75.Width = 0.7222223!
        '
        'TextBox76
        '
        Me.TextBox76.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox76.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox76.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox76.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox76.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox76.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox76.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox76.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox76.DataField = "DeduccionTransporte"
        Me.TextBox76.Height = 0.1666667!
        Me.TextBox76.Left = 7.277778!
        Me.TextBox76.Name = "TextBox76"
        Me.TextBox76.OutputFormat = resources.GetString("TextBox76.OutputFormat")
        Me.TextBox76.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox76.SummaryGroup = "GroupHeader1"
        Me.TextBox76.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox76.Text = Nothing
        Me.TextBox76.Top = 1.055556!
        Me.TextBox76.Width = 0.7222223!
        '
        'TextBox77
        '
        Me.TextBox77.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox77.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox77.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox77.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox77.DataField = "Pulperia"
        Me.TextBox77.Height = 0.1666667!
        Me.TextBox77.Left = 7.277778!
        Me.TextBox77.Name = "TextBox77"
        Me.TextBox77.OutputFormat = resources.GetString("TextBox77.OutputFormat")
        Me.TextBox77.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox77.SummaryGroup = "GroupHeader1"
        Me.TextBox77.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox77.Text = Nothing
        Me.TextBox77.Top = 1.277778!
        Me.TextBox77.Width = 0.7222223!
        '
        'TextBox78
        '
        Me.TextBox78.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox78.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox78.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox78.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox78.DataField = "Inseminacion"
        Me.TextBox78.Height = 0.1666667!
        Me.TextBox78.Left = 7.277778!
        Me.TextBox78.Name = "TextBox78"
        Me.TextBox78.OutputFormat = resources.GetString("TextBox78.OutputFormat")
        Me.TextBox78.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox78.SummaryGroup = "GroupHeader1"
        Me.TextBox78.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox78.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox78.Text = Nothing
        Me.TextBox78.Top = 1.5!
        Me.TextBox78.Width = 0.7222223!
        '
        'TextBox79
        '
        Me.TextBox79.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox79.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox79.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox79.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox79.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox79.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox79.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox79.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox79.DataField = "ProductosVeterinarios"
        Me.TextBox79.Height = 0.1666667!
        Me.TextBox79.Left = 7.277778!
        Me.TextBox79.Name = "TextBox79"
        Me.TextBox79.OutputFormat = resources.GetString("TextBox79.OutputFormat")
        Me.TextBox79.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox79.SummaryGroup = "GroupHeader1"
        Me.TextBox79.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox79.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox79.Text = Nothing
        Me.TextBox79.Top = 1.722222!
        Me.TextBox79.Width = 0.7222223!
        '
        'TextBox80
        '
        Me.TextBox80.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox80.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox80.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox80.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox80.DataField = "TotalEgresos"
        Me.TextBox80.Height = 0.1666667!
        Me.TextBox80.Left = 7.277778!
        Me.TextBox80.Name = "TextBox80"
        Me.TextBox80.OutputFormat = resources.GetString("TextBox80.OutputFormat")
        Me.TextBox80.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox80.SummaryGroup = "GroupHeader1"
        Me.TextBox80.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox80.Text = Nothing
        Me.TextBox80.Top = 1.944445!
        Me.TextBox80.Width = 0.7222223!
        '
        'TextBox81
        '
        Me.TextBox81.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox81.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox81.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox81.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox81.DataField = "NetoPagar"
        Me.TextBox81.Height = 0.2222223!
        Me.TextBox81.Left = 8.944445!
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.OutputFormat = resources.GetString("TextBox81.OutputFormat")
        Me.TextBox81.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 12pt; "
        Me.TextBox81.SummaryGroup = "GroupHeader1"
        Me.TextBox81.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox81.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox81.Text = Nothing
        Me.TextBox81.Top = 2.277778!
        Me.TextBox81.Width = 0.9444445!
        '
        'TextBox63
        '
        Me.TextBox63.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox63.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox63.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox63.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox63.DataField = "TotalIngresos"
        Me.TextBox63.Height = 0.1875!
        Me.TextBox63.Left = 4.777778!
        Me.TextBox63.Name = "TextBox63"
        Me.TextBox63.OutputFormat = resources.GetString("TextBox63.OutputFormat")
        Me.TextBox63.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox63.SummaryGroup = "GroupHeader1"
        Me.TextBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox63.Text = "IngresosBrutos"
        Me.TextBox63.Top = 2.277778!
        Me.TextBox63.Width = 0.75!
        '
        'TxtMontoLunes
        '
        Me.TxtMontoLunes.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMontoLunes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMontoLunes.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMontoLunes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMontoLunes.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMontoLunes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMontoLunes.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMontoLunes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMontoLunes.DataField = "MontoLunes"
        Me.TxtMontoLunes.Height = 0.1666667!
        Me.TxtMontoLunes.Left = 3.607143!
        Me.TxtMontoLunes.Name = "TxtMontoLunes"
        Me.TxtMontoLunes.OutputFormat = resources.GetString("TxtMontoLunes.OutputFormat")
        Me.TxtMontoLunes.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtMontoLunes.SummaryGroup = "GroupHeader1"
        Me.TxtMontoLunes.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtMontoLunes.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtMontoLunes.Text = Nothing
        Me.TxtMontoLunes.Top = 0.6428571!
        Me.TxtMontoLunes.Width = 0.7777777!
        '
        'TextBox52
        '
        Me.TextBox52.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox52.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox52.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox52.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox52.DataField = "MontoMartes"
        Me.TextBox52.Height = 0.1666667!
        Me.TextBox52.Left = 3.607143!
        Me.TextBox52.Name = "TextBox52"
        Me.TextBox52.OutputFormat = resources.GetString("TextBox52.OutputFormat")
        Me.TextBox52.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox52.SummaryGroup = "GroupHeader1"
        Me.TextBox52.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox52.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox52.Text = Nothing
        Me.TextBox52.Top = 0.8571429!
        Me.TextBox52.Width = 0.7777777!
        '
        'TextBox54
        '
        Me.TextBox54.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox54.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox54.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox54.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox54.DataField = "MontoMiercoles"
        Me.TextBox54.Height = 0.1666667!
        Me.TextBox54.Left = 3.607143!
        Me.TextBox54.Name = "TextBox54"
        Me.TextBox54.OutputFormat = resources.GetString("TextBox54.OutputFormat")
        Me.TextBox54.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox54.SummaryGroup = "GroupHeader1"
        Me.TextBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox54.Text = Nothing
        Me.TextBox54.Top = 1.071429!
        Me.TextBox54.Width = 0.7777777!
        '
        'TextBox55
        '
        Me.TextBox55.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox55.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox55.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox55.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox55.DataField = "MontoJueves"
        Me.TextBox55.Height = 0.1666667!
        Me.TextBox55.Left = 3.607143!
        Me.TextBox55.Name = "TextBox55"
        Me.TextBox55.OutputFormat = resources.GetString("TextBox55.OutputFormat")
        Me.TextBox55.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox55.SummaryGroup = "GroupHeader1"
        Me.TextBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox55.Text = Nothing
        Me.TextBox55.Top = 1.285714!
        Me.TextBox55.Width = 0.7777777!
        '
        'TextBox56
        '
        Me.TextBox56.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox56.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox56.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox56.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox56.DataField = "MontoViernes"
        Me.TextBox56.Height = 0.1666667!
        Me.TextBox56.Left = 3.607143!
        Me.TextBox56.Name = "TextBox56"
        Me.TextBox56.OutputFormat = resources.GetString("TextBox56.OutputFormat")
        Me.TextBox56.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox56.SummaryGroup = "GroupHeader1"
        Me.TextBox56.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox56.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox56.Text = Nothing
        Me.TextBox56.Top = 1.535714!
        Me.TextBox56.Width = 0.7777777!
        '
        'TextBox57
        '
        Me.TextBox57.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox57.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox57.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox57.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox57.DataField = "MontoSabado"
        Me.TextBox57.Height = 0.1666667!
        Me.TextBox57.Left = 3.607143!
        Me.TextBox57.Name = "TextBox57"
        Me.TextBox57.OutputFormat = resources.GetString("TextBox57.OutputFormat")
        Me.TextBox57.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox57.SummaryGroup = "GroupHeader1"
        Me.TextBox57.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox57.Text = Nothing
        Me.TextBox57.Top = 1.75!
        Me.TextBox57.Width = 0.7777777!
        '
        'TextBox82
        '
        Me.TextBox82.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox82.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox82.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox82.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox82.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox82.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox82.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox82.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox82.DataField = "MontoDomingo"
        Me.TextBox82.Height = 0.1666667!
        Me.TextBox82.Left = 3.607143!
        Me.TextBox82.Name = "TextBox82"
        Me.TextBox82.OutputFormat = resources.GetString("TextBox82.OutputFormat")
        Me.TextBox82.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox82.SummaryGroup = "GroupHeader1"
        Me.TextBox82.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox82.Text = Nothing
        Me.TextBox82.Top = 0.4285714!
        Me.TextBox82.Width = 0.7777777!
        '
        'TextBox84
        '
        Me.TextBox84.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox84.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox84.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox84.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox84.Height = 0.1666667!
        Me.TextBox84.Left = 8.142858!
        Me.TextBox84.Name = "TextBox84"
        Me.TextBox84.OutputFormat = resources.GetString("TextBox84.OutputFormat")
        Me.TextBox84.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox84.Text = "Bolsa"
        Me.TextBox84.Top = 0.3928572!
        Me.TextBox84.Width = 0.8333331!
        '
        'TextBox85
        '
        Me.TextBox85.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox85.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox85.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox85.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox85.DataField = "Bolsa"
        Me.TextBox85.Height = 0.1666667!
        Me.TextBox85.Left = 9.035714!
        Me.TextBox85.Name = "TextBox85"
        Me.TextBox85.OutputFormat = resources.GetString("TextBox85.OutputFormat")
        Me.TextBox85.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox85.SummaryGroup = "GroupHeader1"
        Me.TextBox85.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox85.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox85.Text = Nothing
        Me.TextBox85.Top = 0.3928572!
        Me.TextBox85.Width = 0.7222223!
        '
        'TextBox89
        '
        Me.TextBox89.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox89.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox89.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox89.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox89.Height = 0.1666667!
        Me.TextBox89.Left = 8.150001!
        Me.TextBox89.Name = "TextBox89"
        Me.TextBox89.OutputFormat = resources.GetString("TextBox89.OutputFormat")
        Me.TextBox89.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox89.Text = "Otras"
        Me.TextBox89.Top = 0.6250001!
        Me.TextBox89.Width = 0.8333331!
        '
        'TextBox90
        '
        Me.TextBox90.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox90.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox90.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox90.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox90.DataField = "OtrasDeducciones"
        Me.TextBox90.Height = 0.1666667!
        Me.TextBox90.Left = 9.05!
        Me.TextBox90.Name = "TextBox90"
        Me.TextBox90.OutputFormat = resources.GetString("TextBox90.OutputFormat")
        Me.TextBox90.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox90.SummaryGroup = "GroupHeader1"
        Me.TextBox90.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox90.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox90.Text = Nothing
        Me.TextBox90.Top = 0.6250001!
        Me.TextBox90.Width = 0.7222223!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox22})
        Me.GroupHeader1.DataField = "CodRuta"
        Me.GroupHeader1.Height = 0.25!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'TextBox22
        '
        Me.TextBox22.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox22.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox22.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox22.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox22.DataField = "Nombre_Ruta"
        Me.TextBox22.Height = 0.1666667!
        Me.TextBox22.Left = 0.7222223!
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox22.Text = Nothing
        Me.TextBox22.Top = 0.0!
        Me.TextBox22.Width = 5.944445!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox26, Me.TextBox27, Me.TextBox28, Me.TextBox29, Me.TextBox30, Me.TextBox31, Me.TextBox32, Me.TextBox33, Me.TextBox34, Me.TextBox35, Me.TextBox36, Me.TextBox37, Me.TextBox38, Me.TextBox40, Me.TextBox41, Me.TextBox42, Me.TextBox43, Me.TextBox46, Me.TextBox48, Me.TextBox87, Me.TextBox88})
        Me.GroupFooter1.Height = 0.2083333!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox26
        '
        Me.TextBox26.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox26.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox26.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox26.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox26.DataField = "Lunes"
        Me.TextBox26.Height = 0.1875!
        Me.TextBox26.Left = 2.5!
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox26.SummaryGroup = "GroupHeader1"
        Me.TextBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox26.Text = "Lunes"
        Me.TextBox26.Top = 0.0!
        Me.TextBox26.Width = 0.52!
        '
        'TextBox27
        '
        Me.TextBox27.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox27.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox27.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox27.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox27.DataField = "Martes"
        Me.TextBox27.Height = 0.1875!
        Me.TextBox27.Left = 3.035714!
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox27.SummaryGroup = "GroupHeader1"
        Me.TextBox27.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox27.Text = "Martes"
        Me.TextBox27.Top = 0.0!
        Me.TextBox27.Width = 0.52!
        '
        'TextBox28
        '
        Me.TextBox28.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox28.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox28.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox28.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox28.DataField = "Miercoles"
        Me.TextBox28.Height = 0.1875!
        Me.TextBox28.Left = 3.56!
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox28.SummaryGroup = "GroupHeader1"
        Me.TextBox28.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox28.Text = "Miercoles"
        Me.TextBox28.Top = 0.0!
        Me.TextBox28.Width = 0.46!
        '
        'TextBox29
        '
        Me.TextBox29.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox29.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox29.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox29.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox29.DataField = "Jueves"
        Me.TextBox29.Height = 0.1875!
        Me.TextBox29.Left = 4.035715!
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox29.SummaryGroup = "GroupHeader1"
        Me.TextBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox29.Text = "Jueves"
        Me.TextBox29.Top = 0.0!
        Me.TextBox29.Width = 0.5!
        '
        'TextBox30
        '
        Me.TextBox30.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox30.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox30.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox30.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox30.DataField = "Viernes"
        Me.TextBox30.Height = 0.1875!
        Me.TextBox30.Left = 4.535715!
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox30.SummaryGroup = "GroupHeader1"
        Me.TextBox30.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox30.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox30.Text = "Viernes"
        Me.TextBox30.Top = 0.0!
        Me.TextBox30.Width = 0.52!
        '
        'TextBox31
        '
        Me.TextBox31.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox31.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox31.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox31.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox31.DataField = "Sabado"
        Me.TextBox31.Height = 0.1875!
        Me.TextBox31.Left = 5.071429!
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox31.SummaryGroup = "GroupHeader1"
        Me.TextBox31.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox31.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox31.Text = "Sabado"
        Me.TextBox31.Top = 0.0!
        Me.TextBox31.Width = 0.52!
        '
        'TextBox32
        '
        Me.TextBox32.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox32.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox32.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox32.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox32.DataField = "Domingo"
        Me.TextBox32.Height = 0.1875!
        Me.TextBox32.Left = 1.964!
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox32.SummaryGroup = "GroupHeader1"
        Me.TextBox32.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox32.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox32.Text = "Domingo"
        Me.TextBox32.Top = 0.0!
        Me.TextBox32.Width = 0.52!
        '
        'TextBox33
        '
        Me.TextBox33.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox33.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox33.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox33.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox33.DataField = "Total"
        Me.TextBox33.Height = 0.1875!
        Me.TextBox33.Left = 5.607143!
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox33.SummaryGroup = "GroupHeader1"
        Me.TextBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox33.Text = "TotalLitros"
        Me.TextBox33.Top = 0.0!
        Me.TextBox33.Width = 0.625!
        '
        'TextBox34
        '
        Me.TextBox34.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox34.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox34.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox34.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox34.DataField = "PrecioVenta"
        Me.TextBox34.Height = 0.1875!
        Me.TextBox34.Left = 6.214285!
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.OutputFormat = resources.GetString("TextBox34.OutputFormat")
        Me.TextBox34.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox34.SummaryGroup = "GroupHeader1"
        Me.TextBox34.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox34.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox34.Text = "PrecioUnitario"
        Me.TextBox34.Top = 0.0!
        Me.TextBox34.Visible = False
        Me.TextBox34.Width = 0.5625!
        '
        'TextBox35
        '
        Me.TextBox35.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox35.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox35.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox35.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox35.DataField = "TotalIngresos"
        Me.TextBox35.Height = 0.1875!
        Me.TextBox35.Left = 6.75!
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.OutputFormat = resources.GetString("TextBox35.OutputFormat")
        Me.TextBox35.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox35.SummaryGroup = "GroupHeader1"
        Me.TextBox35.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox35.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox35.Text = "IngresosBrutos"
        Me.TextBox35.Top = 0.0!
        Me.TextBox35.Width = 0.75!
        '
        'TextBox36
        '
        Me.TextBox36.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox36.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox36.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox36.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox36.DataField = "IR"
        Me.TextBox36.Height = 0.1875!
        Me.TextBox36.Left = 7.5!
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.OutputFormat = resources.GetString("TextBox36.OutputFormat")
        Me.TextBox36.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox36.SummaryGroup = "GroupHeader1"
        Me.TextBox36.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox36.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox36.Text = "IR"
        Me.TextBox36.Top = 0.0!
        Me.TextBox36.Width = 0.5!
        '
        'TextBox37
        '
        Me.TextBox37.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox37.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox37.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox37.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox37.DataField = "OtrasDeducciones"
        Me.TextBox37.Height = 0.1875!
        Me.TextBox37.Left = 7.607143!
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.OutputFormat = resources.GetString("TextBox37.OutputFormat")
        Me.TextBox37.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox37.SummaryGroup = "GroupHeader1"
        Me.TextBox37.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox37.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox37.Text = "Policia"
        Me.TextBox37.Top = 0.4642857!
        Me.TextBox37.Visible = False
        Me.TextBox37.Width = 0.5!
        '
        'TextBox38
        '
        Me.TextBox38.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox38.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox38.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox38.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox38.DataField = "DeduccionTransporte"
        Me.TextBox38.Height = 0.1875!
        Me.TextBox38.Left = 8.964286!
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.OutputFormat = resources.GetString("TextBox38.OutputFormat")
        Me.TextBox38.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox38.SummaryGroup = "GroupHeader1"
        Me.TextBox38.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox38.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox38.Text = "Transporte"
        Me.TextBox38.Top = 0.0!
        Me.TextBox38.Width = 0.5625!
        '
        'TextBox40
        '
        Me.TextBox40.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox40.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox40.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox40.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox40.DataField = "Pulperia"
        Me.TextBox40.Height = 0.1875!
        Me.TextBox40.Left = 9.535714!
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.OutputFormat = resources.GetString("TextBox40.OutputFormat")
        Me.TextBox40.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox40.SummaryGroup = "GroupHeader1"
        Me.TextBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox40.Text = "Pulperia"
        Me.TextBox40.Top = 0.0!
        Me.TextBox40.Width = 0.5!
        '
        'TextBox41
        '
        Me.TextBox41.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox41.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox41.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox41.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox41.DataField = "Inseminacion"
        Me.TextBox41.Height = 0.1785714!
        Me.TextBox41.Left = 10.03571!
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.OutputFormat = resources.GetString("TextBox41.OutputFormat")
        Me.TextBox41.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox41.SummaryGroup = "GroupHeader1"
        Me.TextBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox41.Text = "Inseminacion"
        Me.TextBox41.Top = 0.0!
        Me.TextBox41.Width = 0.4999999!
        '
        'TextBox42
        '
        Me.TextBox42.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox42.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox42.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox42.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox42.DataField = "ProductosVeterinarios"
        Me.TextBox42.Height = 0.1785714!
        Me.TextBox42.Left = 10.53571!
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.OutputFormat = resources.GetString("TextBox42.OutputFormat")
        Me.TextBox42.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox42.SummaryGroup = "GroupHeader1"
        Me.TextBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox42.Text = "ProductosVeterinarios"
        Me.TextBox42.Top = 0.0!
        Me.TextBox42.Width = 0.57!
        '
        'TextBox43
        '
        Me.TextBox43.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox43.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox43.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox43.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox43.DataField = "TotalEgresos"
        Me.TextBox43.Height = 0.1785714!
        Me.TextBox43.Left = 11.67857!
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.OutputFormat = resources.GetString("TextBox43.OutputFormat")
        Me.TextBox43.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox43.SummaryGroup = "GroupHeader1"
        Me.TextBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox43.Text = "TotalEgresos"
        Me.TextBox43.Top = 0.0!
        Me.TextBox43.Width = 0.7142861!
        '
        'TextBox46
        '
        Me.TextBox46.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox46.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox46.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox46.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox46.DataField = "Anticipo"
        Me.TextBox46.Height = 0.1785714!
        Me.TextBox46.Left = 8.5!
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox46.SummaryGroup = "GroupHeader1"
        Me.TextBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox46.Text = "Anticipo"
        Me.TextBox46.Top = 0.0!
        Me.TextBox46.Width = 0.46!
        '
        'TextBox48
        '
        Me.TextBox48.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox48.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox48.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox48.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox48.DataField = "NetoPagar"
        Me.TextBox48.Height = 0.1875!
        Me.TextBox48.Left = 12.42857!
        Me.TextBox48.Name = "TextBox48"
        Me.TextBox48.OutputFormat = resources.GetString("TextBox48.OutputFormat")
        Me.TextBox48.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox48.SummaryGroup = "GroupHeader1"
        Me.TextBox48.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox48.Text = "NetoPagar"
        Me.TextBox48.Top = 0.0!
        Me.TextBox48.Width = 0.82!
        '
        'TextBox87
        '
        Me.TextBox87.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox87.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox87.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox87.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox87.DataField = "Bolsa"
        Me.TextBox87.Height = 0.1785714!
        Me.TextBox87.Left = 8.0!
        Me.TextBox87.Name = "TextBox87"
        Me.TextBox87.OutputFormat = resources.GetString("TextBox87.OutputFormat")
        Me.TextBox87.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox87.SummaryGroup = "GroupHeader1"
        Me.TextBox87.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox87.Text = "Bolsa"
        Me.TextBox87.Top = 0.0!
        Me.TextBox87.Width = 0.5000001!
        '
        'TextBox88
        '
        Me.TextBox88.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox88.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox88.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox88.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox88.DataField = "OtrasDeducciones"
        Me.TextBox88.Height = 0.19!
        Me.TextBox88.Left = 11.10714!
        Me.TextBox88.Name = "TextBox88"
        Me.TextBox88.OutputFormat = resources.GetString("TextBox88.OutputFormat")
        Me.TextBox88.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox88.SummaryGroup = "GroupHeader1"
        Me.TextBox88.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox88.Text = Nothing
        Me.TextBox88.Top = 0.0!
        Me.TextBox88.Width = 0.58!
        '
        'ArepPlanilla
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB;Password=P@ssword;Persist Security Info=True;User ID=sa;Initial" & _
            " Catalog=SistemaFacturacionMulukuku;Data Source=JUANBERMUDEZ-PC\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.3!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.3!
        Me.PageSettings.Margins.Top = 0.33!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 14.0!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Legal
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 13.3125!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox83, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox86, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtLunes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMartes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMiercoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtJueves, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox71, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox72, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox73, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox74, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox75, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox76, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox77, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox78, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox79, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox80, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox81, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMontoLunes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox84, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox85, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox89, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox90, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox87, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox88, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label19 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
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
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox16 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox18 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox19 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox20 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox21 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPeriodo As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox24 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox25 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox23 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox39 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox44 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox45 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox47 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox49 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox50 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox51 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPrecio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtLunes As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMartes As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMiercoles As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtJueves As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox58 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox59 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox60 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox61 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox62 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox53 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox64 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox65 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox66 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox67 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox68 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox69 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox70 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox71 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox72 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox73 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox74 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox75 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox76 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox77 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox78 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox79 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox80 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox81 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox22 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox26 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox27 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox28 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox29 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox30 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox31 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox32 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox33 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox34 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox35 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox36 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox37 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox38 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox40 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox41 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox42 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox43 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox46 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox48 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox63 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMontoLunes As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox52 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox54 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox55 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox56 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox57 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox82 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox83 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox84 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox85 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox86 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox87 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox88 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox89 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox90 As DataDynamics.ActiveReports.TextBox
End Class
