<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepVentasVendedor
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
        Dim ChartArea1 As DataDynamics.ActiveReports.Chart.ChartArea = New DataDynamics.ActiveReports.Chart.ChartArea
        Dim Axis1 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Axis2 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Axis3 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Axis4 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim Axis5 As DataDynamics.ActiveReports.Chart.Axis = New DataDynamics.ActiveReports.Chart.Axis
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepVentasVendedor))
        Dim Legend1 As DataDynamics.ActiveReports.Chart.Legend = New DataDynamics.ActiveReports.Chart.Legend
        Dim Title1 As DataDynamics.ActiveReports.Chart.Title = New DataDynamics.ActiveReports.Chart.Title
        Dim Title2 As DataDynamics.ActiveReports.Chart.Title = New DataDynamics.ActiveReports.Chart.Title
        Dim Series1 As DataDynamics.ActiveReports.Chart.Series = New DataDynamics.ActiveReports.Chart.Series
        Dim Series2 As DataDynamics.ActiveReports.Chart.Series = New DataDynamics.ActiveReports.Chart.Series
        Dim Series3 As DataDynamics.ActiveReports.Chart.Series = New DataDynamics.ActiveReports.Chart.Series
        Dim Title3 As DataDynamics.ActiveReports.Chart.Title = New DataDynamics.ActiveReports.Chart.Title
        Dim Title4 As DataDynamics.ActiveReports.Chart.Title = New DataDynamics.ActiveReports.Chart.Title
        Dim OleDBDataSource2 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.ChartControl = New DataDynamics.ActiveReports.ChartControl
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.lblQty = New DataDynamics.ActiveReports.Label
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox
        Me.LblRango = New DataDynamics.ActiveReports.Label
        Me.LblMoneda = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtVentas = New DataDynamics.ActiveReports.TextBox
        Me.LblPorciento = New DataDynamics.ActiveReports.Label
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRango, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPorciento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblTitulo, Me.LblDireccion, Me.LblRuc, Me.Label1, Me.ChartControl, Me.Label4, Me.lblQty, Me.lblProductID, Me.Label5, Me.Label9, Me.TextBox14, Me.LblRango, Me.LblMoneda})
        Me.PageHeader1.Height = 5.4375!
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
        Me.LblTitulo.Left = 0.0!
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.LblTitulo.Text = "S&S"
        Me.LblTitulo.Top = 0.0625!
        Me.LblTitulo.Width = 7.875!
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
        Me.LblDireccion.Width = 7.875!
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
        Me.LblRuc.Width = 7.875!
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
        Me.Label1.Text = "Reporte de Ventas por Vendedor"
        Me.Label1.Top = 0.6875!
        Me.Label1.Width = 7.875!
        '
        'ChartControl
        '
        Me.ChartControl.AutoRefresh = True
        Me.ChartControl.Backdrop = New DataDynamics.ActiveReports.Chart.BackdropItem(DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Color.White, System.Drawing.Color.SteelBlue)
        Me.ChartControl.Border.BottomColor = System.Drawing.Color.Black
        Me.ChartControl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChartControl.Border.LeftColor = System.Drawing.Color.Black
        Me.ChartControl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChartControl.Border.RightColor = System.Drawing.Color.Black
        Me.ChartControl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChartControl.Border.TopColor = System.Drawing.Color.Black
        Me.ChartControl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        ChartArea1.AntiAliasMode = DataDynamics.ActiveReports.Chart.Graphics.AntiAliasMode.Graphics
        Axis1.AxisType = DataDynamics.ActiveReports.Chart.AxisType.Categorical
        Axis1.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis1.LabelFormat = "{0:#.00}"
        Axis1.LabelsInside = True
        Axis1.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line, New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Black, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.Dot), 1, 5.0!, True)
        Axis1.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis1.Title = "Axis X"
        Axis1.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis2.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis2.LabelsGap = 0
        Axis2.LabelsVisible = False
        Axis2.Line = New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None)
        Axis2.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis2.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis2.Position = 0
        Axis2.TickOffset = 0
        Axis2.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis2.Visible = False
        Axis3.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis3.LabelFormat = "{0:#.00}"
        Axis3.LabelsVisible = False
        Axis3.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 1, 0.0!, True)
        Axis3.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis3.Position = 0
        Axis3.Title = "Axis Y"
        Axis3.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!), -90.0!)
        Axis4.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis4.LabelsVisible = False
        Axis4.Line = New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None)
        Axis4.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis4.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis4.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis4.Visible = False
        Axis5.LabelFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis5.LabelsGap = 0
        Axis5.LabelsVisible = False
        Axis5.Line = New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None)
        Axis5.MajorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis5.MinorTick = New DataDynamics.ActiveReports.Chart.Tick(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, 0.0!, False)
        Axis5.Position = 0
        Axis5.TickOffset = 0
        Axis5.TitleFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Axis5.Visible = False
        ChartArea1.Axes.AddRange(New DataDynamics.ActiveReports.Chart.AxisBase() {Axis1, Axis2, Axis3, Axis4, Axis5})
        ChartArea1.Backdrop = New DataDynamics.ActiveReports.Chart.BackdropItem(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, Nothing, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched)
        ChartArea1.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        ChartArea1.Light = New DataDynamics.ActiveReports.Chart.Light(New DataDynamics.ActiveReports.Chart.Graphics.Point3d(10.0!, 40.0!, 20.0!), DataDynamics.ActiveReports.Chart.LightType.InfiniteDirectional, 0.3!)
        ChartArea1.Name = "defaultArea"
        ChartArea1.Projection = New DataDynamics.ActiveReports.Chart.Projection(DataDynamics.ActiveReports.Chart.Graphics.ProjectionType.Orthogonal, 0.1!, 0.1!, 19.0!, 22.0!)
        ChartArea1.SwapAxesDirection = True
        Me.ChartControl.ChartAreas.AddRange(New DataDynamics.ActiveReports.Chart.ChartArea() {ChartArea1})
        Me.ChartControl.ChartBorder = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaFacturacionBuiler;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.ChartControl.DataSource = OleDBDataSource1
        Me.ChartControl.Height = 3.736842!
        Me.ChartControl.Left = 0.0!
        Legend1.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Right
        Legend1.Backdrop = New DataDynamics.ActiveReports.Chart.BackdropItem(System.Drawing.Color.White, CType(128, Byte))
        Legend1.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line, 0, System.Drawing.Color.Black)
        Legend1.DockArea = ChartArea1
        Title1.Backdrop = New DataDynamics.ActiveReports.Chart.Graphics.Backdrop(DataDynamics.ActiveReports.Chart.Graphics.BackdropStyle.Transparent, System.Drawing.Color.White, System.Drawing.Color.White, DataDynamics.ActiveReports.Chart.Graphics.GradientType.Vertical, System.Drawing.Drawing2D.HatchStyle.DottedGrid, Nothing, DataDynamics.ActiveReports.Chart.Graphics.PicturePutStyle.Stretched)
        Title1.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        Title1.DockArea = Nothing
        Title1.Font = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Title1.Name = ""
        Title1.Text = ""
        Title1.Visible = False
        Legend1.Footer = Title1
        Legend1.GridLayout = New DataDynamics.ActiveReports.Chart.GridLayout(0, 1)
        Title2.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.White, 2), 0, System.Drawing.Color.Black)
        Title2.DockArea = Nothing
        Title2.Font = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Title2.Name = ""
        Title2.Text = "Monto Ventas"
        Legend1.Header = Title2
        Legend1.LabelsFont = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Legend1.MarginX = 20
        Legend1.MarginY = 20
        Legend1.Name = "defaultLegend"
        Me.ChartControl.Legends.AddRange(New DataDynamics.ActiveReports.Chart.Legend() {Legend1})
        Me.ChartControl.Name = "ChartControl"
        Series1.AxisX = Axis1
        Series1.AxisY = Axis3
        Series1.ChartArea = ChartArea1
        Series1.ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.[Default]
        Series1.Legend = Legend1
        Series1.LegendText = ""
        Series1.Name = "Series1"
        Series1.Properties = New DataDynamics.ActiveReports.Chart.CustomProperties(New DataDynamics.ActiveReports.Chart.KeyValuePair() {New DataDynamics.ActiveReports.Chart.KeyValuePair("HoleSize", 0.0!)})
        Series1.Type = DataDynamics.ActiveReports.Chart.ChartType.Doughnut3D
        Series1.ValueMembersY = "MontoVendido"
        Series1.ValueMemberX = "Cod_Vendedor"
        Series2.AxisX = Axis1
        Series2.AxisY = Axis3
        Series2.ChartArea = ChartArea1
        Series2.ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.[Default]
        Series2.Legend = Legend1
        Series2.LegendText = ""
        Series2.Name = "Series2"
        Series2.Properties = New DataDynamics.ActiveReports.Chart.CustomProperties(New DataDynamics.ActiveReports.Chart.KeyValuePair() {New DataDynamics.ActiveReports.Chart.KeyValuePair("HoleSize", 0.0!)})
        Series2.Type = DataDynamics.ActiveReports.Chart.ChartType.Doughnut3D
        Series2.ValueMembersY = "MontoVendido"
        Series2.ValueMemberX = "NombreVendedor"
        Series3.AxisX = Axis1
        Series3.AxisY = Axis3
        Series3.ChartArea = ChartArea1
        Series3.ColorPalette = DataDynamics.ActiveReports.Chart.ColorPalette.[Default]
        Series3.Legend = Legend1
        Series3.LegendText = ""
        Series3.Name = "Series3"
        Series3.Properties = New DataDynamics.ActiveReports.Chart.CustomProperties(New DataDynamics.ActiveReports.Chart.KeyValuePair() {New DataDynamics.ActiveReports.Chart.KeyValuePair("HoleSize", 0.0!)})
        Series3.Type = DataDynamics.ActiveReports.Chart.ChartType.Doughnut3D
        Series3.ValueMembersY = "MontoVendido"
        Series3.ValueMemberX = "NombreVendedor"
        Me.ChartControl.Series.AddRange(New DataDynamics.ActiveReports.Chart.Series() {Series1, Series2, Series3})
        Title3.Alignment = DataDynamics.ActiveReports.Chart.Alignment.Center
        Title3.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        Title3.DockArea = Nothing
        Title3.Font = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Title3.Name = "header"
        Title3.Text = ""
        Title4.Border = New DataDynamics.ActiveReports.Chart.Border(New DataDynamics.ActiveReports.Chart.Graphics.Line(System.Drawing.Color.Transparent, 0, DataDynamics.ActiveReports.Chart.Graphics.LineStyle.None), 0, System.Drawing.Color.Black)
        Title4.DockArea = Nothing
        Title4.Docking = DataDynamics.ActiveReports.Chart.DockType.Bottom
        Title4.Font = New DataDynamics.ActiveReports.Chart.FontInfo(System.Drawing.Color.Black, New System.Drawing.Font("Microsoft Sans Serif", 8.0!))
        Title4.Name = "footer"
        Title4.Text = "Graficos"
        Me.ChartControl.Titles.AddRange(New DataDynamics.ActiveReports.Chart.Title() {Title3, Title4})
        Me.ChartControl.Top = 1.368421!
        Me.ChartControl.UIOptions = DataDynamics.ActiveReports.Chart.UIOptions.ForceHitTesting
        Me.ChartControl.Width = 7.789473!
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
        Me.Label4.Height = 0.2999999!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 4.8!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: rgb(255,255,255); ddo-char-set: 0; text-align: center; font-weight: bold; " & _
            "background-color: #8080FF; font-size: 8.25pt; "
        Me.Label4.Text = "Monto de Ventas"
        Me.Label4.Top = 5.125!
        Me.Label4.Width = 0.9!
        '
        'lblQty
        '
        Me.lblQty.Border.BottomColor = System.Drawing.Color.Black
        Me.lblQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblQty.Border.LeftColor = System.Drawing.Color.Black
        Me.lblQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblQty.Border.RightColor = System.Drawing.Color.Black
        Me.lblQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblQty.Border.TopColor = System.Drawing.Color.Black
        Me.lblQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblQty.Height = 0.3125!
        Me.lblQty.HyperLink = Nothing
        Me.lblQty.Left = 2.25!
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Style = "color: rgb(255,255,255); ddo-char-set: 0; text-align: center; font-weight: bold; " & _
            "background-color: #8080FF; font-size: 8.25pt; "
        Me.lblQty.Text = "Nombre Vendedor"
        Me.lblQty.Top = 5.125!
        Me.lblQty.Width = 2.5625!
        '
        'lblProductID
        '
        Me.lblProductID.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductID.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductID.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductID.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductID.Height = 0.3125!
        Me.lblProductID.HyperLink = Nothing
        Me.lblProductID.Left = 1.5!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: rgb(255,255,255); text-align: center; font-weight: bold; background-color:" & _
            " #8080FF; font-size: 8.5pt; "
        Me.lblProductID.Text = "Codigo Vendedor"
        Me.lblProductID.Top = 5.125!
        Me.lblProductID.Width = 0.75!
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
        Me.Label5.Height = 0.3125!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 5.7!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: rgb(255,255,255); ddo-char-set: 0; text-align: center; font-weight: bold; " & _
            "background-color: #8080FF; font-size: 8.25pt; "
        Me.Label5.Text = "Porciento Vendido"
        Me.Label5.Top = 5.125!
        Me.Label5.Width = 0.625!
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
        Me.Label9.Left = 7.125!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = ""
        Me.Label9.Text = "Pag."
        Me.Label9.Top = 0.875!
        Me.Label9.Width = 0.3125!
        '
        'TextBox14
        '
        Me.TextBox14.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Height = 0.1875!
        Me.TextBox14.Left = 7.4375!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = ""
        Me.TextBox14.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.TextBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = 0.875!
        Me.TextBox14.Width = 0.4375!
        '
        'LblRango
        '
        Me.LblRango.Border.BottomColor = System.Drawing.Color.Black
        Me.LblRango.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRango.Border.LeftColor = System.Drawing.Color.Black
        Me.LblRango.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRango.Border.RightColor = System.Drawing.Color.Black
        Me.LblRango.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRango.Border.TopColor = System.Drawing.Color.Black
        Me.LblRango.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRango.Height = 0.1875!
        Me.LblRango.HyperLink = Nothing
        Me.LblRango.Left = 0.0625!
        Me.LblRango.Name = "LblRango"
        Me.LblRango.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblRango.Text = ""
        Me.LblRango.Top = 1.125!
        Me.LblRango.Width = 5.4375!
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
        Me.LblMoneda.Height = 0.1875!
        Me.LblMoneda.HyperLink = Nothing
        Me.LblMoneda.Left = 0.0!
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.LblMoneda.Text = "Expresado en Cordobas"
        Me.LblMoneda.Top = 0.8947368!
        Me.LblMoneda.Width = 7.875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TxtVentas, Me.LblPorciento})
        Me.Detail1.Height = 0.1979167!
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
        Me.TextBox1.DataField = "Cod_Vendedor"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 1.5!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox1.Text = "Cod_Vendedor"
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
        Me.TextBox2.DataField = "NombreVendedor"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 2.25!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = ""
        Me.TextBox2.Text = "NombreVendedor"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 2.5625!
        '
        'TxtVentas
        '
        Me.TxtVentas.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtVentas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtVentas.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtVentas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtVentas.Border.RightColor = System.Drawing.Color.Black
        Me.TxtVentas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtVentas.Border.TopColor = System.Drawing.Color.Black
        Me.TxtVentas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtVentas.DataField = "MontoVendido"
        Me.TxtVentas.Height = 0.175!
        Me.TxtVentas.Left = 4.8!
        Me.TxtVentas.Name = "TxtVentas"
        Me.TxtVentas.OutputFormat = resources.GetString("TxtVentas.OutputFormat")
        Me.TxtVentas.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtVentas.Text = "MontoVendido"
        Me.TxtVentas.Top = 0.0!
        Me.TxtVentas.Width = 0.95!
        '
        'LblPorciento
        '
        Me.LblPorciento.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPorciento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPorciento.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPorciento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPorciento.Border.RightColor = System.Drawing.Color.Black
        Me.LblPorciento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPorciento.Border.TopColor = System.Drawing.Color.Black
        Me.LblPorciento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPorciento.Height = 0.1875!
        Me.LblPorciento.HyperLink = Nothing
        Me.LblPorciento.Left = 5.725!
        Me.LblPorciento.Name = "LblPorciento"
        Me.LblPorciento.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.LblPorciento.Text = "%"
        Me.LblPorciento.Top = 0.0!
        Me.LblPorciento.Width = 0.625!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox3, Me.Label2})
        Me.GroupFooter1.Height = 0.25!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.TextBox3.DataField = "MontoVendido"
        Me.TextBox3.Height = 0.175!
        Me.TextBox3.Left = 4.775!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox3.SummaryGroup = "GroupHeader1"
        Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox3.Text = "MontoVendido"
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.925!
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
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 5.725!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.Label2.Text = "%"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 0.625!
        '
        'ArepVentasVendedor
        '
        Me.MasterReport = False
        OleDBDataSource2.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaFacturacionBuiler;Data Source=JUAN\SQL2005"
        OleDBDataSource2.SQL = resources.GetString("OleDBDataSource2.SQL")
        Me.DataSource = OleDBDataSource2
        Me.PageSettings.Margins.Left = 0.35!
        Me.PageSettings.Margins.Right = 0.2!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.916667!
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
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRango, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPorciento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents ChartControl As DataDynamics.ActiveReports.ChartControl
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents lblQty As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtVentas As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblPorciento As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRango As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMoneda As DataDynamics.ActiveReports.Label
End Class
