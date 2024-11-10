<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SubReporteCompras 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SubReporteCompras))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TxtTipo = New DataDynamics.ActiveReports.TextBox
        Me.TxtFecha = New DataDynamics.ActiveReports.TextBox
        Me.TxtNumero = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantidad1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtImporte1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantidad2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtImporte2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantidad1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtImporte1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantidad2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtImporte2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label12, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label2, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label1})
        Me.PageHeader1.Height = 0.3958333!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.Label12.Left = 4.25!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label12.Text = "Importe"
        Me.Label12.Top = 0.1875!
        Me.Label12.Width = 0.6875!
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
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label4.Text = "Tipo"
        Me.Label4.Top = 0.1875!
        Me.Label4.Width = 1.25!
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
        Me.Label5.Left = 1.25!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label5.Text = "Descripcion"
        Me.Label5.Top = 0.0!
        Me.Label5.Width = 2.3125!
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
        Me.Label6.Left = 1.9375!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label6.Text = "Fecha"
        Me.Label6.Top = 0.1875!
        Me.Label6.Width = 0.8125!
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
        Me.Label7.Left = 2.75!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label7.Text = "Numero"
        Me.Label7.Top = 0.1875!
        Me.Label7.Width = 0.8125!
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
        Me.Label8.Left = 3.5625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.Label8.Text = "---------ENTRADAS---------"
        Me.Label8.Top = 0.0!
        Me.Label8.Width = 1.375!
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
        Me.Label9.Left = 4.9375!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label9.Text = "----------SALIDAS----------"
        Me.Label9.Top = 0.0!
        Me.Label9.Width = 1.375!
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
        Me.Label10.Left = 6.3125!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label10.Text = "----MOVIMIENTO NETO----"
        Me.Label10.Top = 0.0!
        Me.Label10.Width = 1.5!
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
        Me.Label11.Left = 3.5625!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label11.Text = "Cantidad"
        Me.Label11.Top = 0.1875!
        Me.Label11.Width = 0.6875!
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
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label2.Text = "Cod Producto"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 1.25!
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
        Me.Label13.Left = 4.9375!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label13.Text = "Cantidad"
        Me.Label13.Top = 0.1875!
        Me.Label13.Width = 0.6875!
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
        Me.Label14.Height = 0.1875!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 5.625!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label14.Text = "Importe"
        Me.Label14.Top = 0.1875!
        Me.Label14.Width = 0.6875!
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
        Me.Label15.Height = 0.1875!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 6.3125!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label15.Text = "Cantidad"
        Me.Label15.Top = 0.1875!
        Me.Label15.Width = 0.75!
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
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 7.0625!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label16.Text = "Importe"
        Me.Label16.Top = 0.1875!
        Me.Label16.Width = 0.75!
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
        Me.Label1.Left = 1.25!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label1.Text = "Bodega"
        Me.Label1.Top = 0.1875!
        Me.Label1.Width = 0.6875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtTipo, Me.TxtFecha, Me.TxtNumero, Me.TxtCantidad1, Me.TxtImporte1, Me.TxtCantidad2, Me.TxtImporte2, Me.TextBox1})
        Me.Detail1.Height = 0.21875!
        Me.Detail1.Name = "Detail1"
        '
        'TxtTipo
        '
        Me.TxtTipo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.DataField = "Tipo_Compra"
        Me.TxtTipo.Height = 0.1875!
        Me.TxtTipo.Left = 0.0!
        Me.TxtTipo.Name = "TxtTipo"
        Me.TxtTipo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtTipo.Text = Nothing
        Me.TxtTipo.Top = 0.0!
        Me.TxtTipo.Width = 1.25!
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
        Me.TxtFecha.DataField = "Fecha_Compra"
        Me.TxtFecha.Height = 0.1875!
        Me.TxtFecha.Left = 1.9375!
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.OutputFormat = resources.GetString("TxtFecha.OutputFormat")
        Me.TxtFecha.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TxtFecha.Text = Nothing
        Me.TxtFecha.Top = 0.0!
        Me.TxtFecha.Width = 0.8125!
        '
        'TxtNumero
        '
        Me.TxtNumero.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtNumero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumero.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtNumero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumero.Border.RightColor = System.Drawing.Color.Black
        Me.TxtNumero.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumero.Border.TopColor = System.Drawing.Color.Black
        Me.TxtNumero.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumero.DataField = "Numero_Compra"
        Me.TxtNumero.Height = 0.1875!
        Me.TxtNumero.Left = 2.75!
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TxtNumero.Text = Nothing
        Me.TxtNumero.Top = 0.0!
        Me.TxtNumero.Width = 0.8125!
        '
        'TxtCantidad1
        '
        Me.TxtCantidad1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantidad1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantidad1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantidad1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantidad1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad1.DataField = "Cantidad"
        Me.TxtCantidad1.Height = 0.1875!
        Me.TxtCantidad1.Left = 3.5625!
        Me.TxtCantidad1.Name = "TxtCantidad1"
        Me.TxtCantidad1.OutputFormat = resources.GetString("TxtCantidad1.OutputFormat")
        Me.TxtCantidad1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCantidad1.Text = Nothing
        Me.TxtCantidad1.Top = 0.0!
        Me.TxtCantidad1.Width = 0.6875!
        '
        'TxtImporte1
        '
        Me.TxtImporte1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtImporte1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtImporte1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtImporte1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtImporte1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte1.DataField = "Importe"
        Me.TxtImporte1.Height = 0.1875!
        Me.TxtImporte1.Left = 4.25!
        Me.TxtImporte1.Name = "TxtImporte1"
        Me.TxtImporte1.OutputFormat = resources.GetString("TxtImporte1.OutputFormat")
        Me.TxtImporte1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtImporte1.Text = Nothing
        Me.TxtImporte1.Top = 0.0!
        Me.TxtImporte1.Width = 0.6875!
        '
        'TxtCantidad2
        '
        Me.TxtCantidad2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantidad2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantidad2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantidad2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantidad2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad2.DataField = "Cantidad"
        Me.TxtCantidad2.Height = 0.1875!
        Me.TxtCantidad2.Left = 4.9375!
        Me.TxtCantidad2.Name = "TxtCantidad2"
        Me.TxtCantidad2.OutputFormat = resources.GetString("TxtCantidad2.OutputFormat")
        Me.TxtCantidad2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtCantidad2.Text = Nothing
        Me.TxtCantidad2.Top = 0.0!
        Me.TxtCantidad2.Width = 0.6875!
        '
        'TxtImporte2
        '
        Me.TxtImporte2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtImporte2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtImporte2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtImporte2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtImporte2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImporte2.DataField = "Importe"
        Me.TxtImporte2.Height = 0.1875!
        Me.TxtImporte2.Left = 5.625!
        Me.TxtImporte2.Name = "TxtImporte2"
        Me.TxtImporte2.OutputFormat = resources.GetString("TxtImporte2.OutputFormat")
        Me.TxtImporte2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtImporte2.Text = Nothing
        Me.TxtImporte2.Top = 0.0!
        Me.TxtImporte2.Width = 0.6875!
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
        Me.TextBox1.DataField = "Cod_Bodega"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 1.25!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.6875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'SubReporteCompras
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=SistemaFacturacionRevetsa;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.875!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantidad1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtImporte1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantidad2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtImporte2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents TxtTipo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtNumero As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantidad1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtImporte1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantidad2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtImporte2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
End Class
