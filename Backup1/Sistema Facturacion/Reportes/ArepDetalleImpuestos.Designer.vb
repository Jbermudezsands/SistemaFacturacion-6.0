<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepDetalleImpuestos 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepDetalleImpuestos))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.lblQty = New DataDynamics.ActiveReports.Label
        Me.TxtImpuesto = New DataDynamics.ActiveReports.TextBox
        Me.TxtMonto = New DataDynamics.ActiveReports.TextBox
        Me.TxtTotal = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtImpuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblProductID, Me.lblQty})
        Me.PageHeader1.Height = 0.1666667!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtImpuesto, Me.TxtMonto})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtTotal})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
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
        Me.lblProductID.Height = 0.1875!
        Me.lblProductID.HyperLink = Nothing
        Me.lblProductID.Left = 0.0!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: rgb(255,255,255); text-align: center; font-weight: bold; background-color:" & _
            " #8080FF; font-size: 8.5pt; "
        Me.lblProductID.Text = "Impuesto"
        Me.lblProductID.Top = 0.0!
        Me.lblProductID.Width = 0.875!
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
        Me.lblQty.Height = 0.1875!
        Me.lblQty.HyperLink = Nothing
        Me.lblQty.Left = 0.875!
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Style = "color: rgb(255,255,255); ddo-char-set: 0; text-align: center; font-weight: bold; " & _
            "background-color: #8080FF; font-size: 8.25pt; "
        Me.lblQty.Text = "Monto"
        Me.lblQty.Top = 0.0!
        Me.lblQty.Width = 0.6875!
        '
        'TxtImpuesto
        '
        Me.TxtImpuesto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtImpuesto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImpuesto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtImpuesto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImpuesto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtImpuesto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImpuesto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtImpuesto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtImpuesto.DataField = "Cod_Iva"
        Me.TxtImpuesto.Height = 0.1875!
        Me.TxtImpuesto.Left = 0.0!
        Me.TxtImpuesto.Name = "TxtImpuesto"
        Me.TxtImpuesto.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtImpuesto.Top = 0.0!
        Me.TxtImpuesto.Width = 0.875!
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
        Me.TxtMonto.DataField = "Monto"
        Me.TxtMonto.Height = 0.1875!
        Me.TxtMonto.Left = 0.875!
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.OutputFormat = resources.GetString("TxtMonto.OutputFormat")
        Me.TxtMonto.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtMonto.Top = 0.0!
        Me.TxtMonto.Width = 0.6875!
        '
        'TxtTotal
        '
        Me.TxtTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotal.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotal.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotal.DataField = "Monto"
        Me.TxtTotal.Height = 0.1875!
        Me.TxtTotal.Left = 0.875!
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.OutputFormat = resources.GetString("TxtTotal.OutputFormat")
        Me.TxtTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtTotal.SummaryGroup = "GroupHeader1"
        Me.TxtTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtTotal.Top = 0.0!
        Me.TxtTotal.Width = 0.6875!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.DataField = "Numero_Liquidacion"
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.01041667!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'ArepDetalleImpuestos
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=SistemaFacturacionImportadora;Data Source=JUAN\SQL2005"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 1.59375!
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
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtImpuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Private WithEvents lblQty As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtImpuesto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMonto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
End Class 
