<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepFacturas2 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ArepFacturas2))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.lblProductName = New DataDynamics.ActiveReports.Label
        Me.lblUnitPrice = New DataDynamics.ActiveReports.Label
        Me.lblDiscount = New DataDynamics.ActiveReports.Label
        Me.TxtMetodo = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.LblCodProveedor = New DataDynamics.ActiveReports.Label
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.LblApellidos = New DataDynamics.ActiveReports.Label
        Me.LblDireccionProveedor = New DataDynamics.ActiveReports.Label
        Me.LblTelefono = New DataDynamics.ActiveReports.Label
        Me.LblBodegas = New DataDynamics.ActiveReports.Label
        Me.LblFechaVence = New DataDynamics.ActiveReports.Label
        Me.lneBillTo = New DataDynamics.ActiveReports.Line
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.LblVendedor = New DataDynamics.ActiveReports.Label
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label19 = New DataDynamics.ActiveReports.Label
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.lblFreight = New DataDynamics.ActiveReports.Label
        Me.lblSubTotals = New DataDynamics.ActiveReports.Label
        Me.lblGrandTotal = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.LblSubTotal = New DataDynamics.ActiveReports.Label
        Me.LblIva = New DataDynamics.ActiveReports.Label
        Me.LblPagado = New DataDynamics.ActiveReports.Label
        Me.LblTotal = New DataDynamics.ActiveReports.Label
        Me.LblNotas = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.LblDescuento = New DataDynamics.ActiveReports.Label
        Me.LblLetras = New DataDynamics.ActiveReports.Label
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMetodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCodProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccionProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaVence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFreight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPagado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.lblProductID, Me.lblProductName, Me.lblUnitPrice, Me.lblDiscount, Me.TxtMetodo, Me.Label4, Me.Line1, Me.Label5, Me.Label6, Me.Line3, Me.LblCodProveedor, Me.LblNombres, Me.LblApellidos, Me.LblDireccionProveedor, Me.LblTelefono, Me.LblBodegas, Me.LblFechaVence, Me.lneBillTo, Me.Label8, Me.LblVendedor, Me.Line4, Me.Label10, Me.Label11, Me.Label12, Me.Label15, Me.Label16, Me.Label18, Me.Label19, Me.Label21, Me.Label22, Me.Label23, Me.Line2, Me.LblFechaOrden, Me.Label17})
        Me.PageHeader1.Height = 2.760417!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.Label1.Left = 0.368421!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label1.Text = "Cliente"
        Me.Label1.Top = 1.210526!
        Me.Label1.Width = 1.0!
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
        Me.lblProductID.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.lblProductID.Text = "Product ID"
        Me.lblProductID.Top = 2.526316!
        Me.lblProductID.Width = 0.6875!
        '
        'lblProductName
        '
        Me.lblProductName.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductName.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductName.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductName.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblProductName.Height = 0.1875!
        Me.lblProductName.HyperLink = Nothing
        Me.lblProductName.Left = 0.6842105!
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.lblProductName.Text = "Nombre Producto"
        Me.lblProductName.Top = 2.526316!
        Me.lblProductName.Width = 2.6875!
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Border.BottomColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUnitPrice.Border.LeftColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUnitPrice.Border.RightColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUnitPrice.Border.TopColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUnitPrice.Height = 0.1875!
        Me.lblUnitPrice.HyperLink = Nothing
        Me.lblUnitPrice.Left = 4.421052!
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.lblUnitPrice.Text = "Precio Unit"
        Me.lblUnitPrice.Top = 2.526316!
        Me.lblUnitPrice.Width = 0.75!
        '
        'lblDiscount
        '
        Me.lblDiscount.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDiscount.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDiscount.Border.RightColor = System.Drawing.Color.Black
        Me.lblDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDiscount.Border.TopColor = System.Drawing.Color.Black
        Me.lblDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDiscount.Height = 0.1875!
        Me.lblDiscount.HyperLink = Nothing
        Me.lblDiscount.Left = 5.157895!
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: White; font-size: 8.25pt; "
        Me.lblDiscount.Text = "%Desc"
        Me.lblDiscount.Top = 2.526316!
        Me.lblDiscount.Width = 0.5!
        '
        'TxtMetodo
        '
        Me.TxtMetodo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMetodo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMetodo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMetodo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMetodo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMetodo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMetodo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMetodo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMetodo.Height = 0.2105263!
        Me.TxtMetodo.Left = 3.894737!
        Me.TxtMetodo.Name = "TxtMetodo"
        Me.TxtMetodo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TxtMetodo.Text = Nothing
        Me.TxtMetodo.Top = 1.473684!
        Me.TxtMetodo.Width = 1.421053!
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
        Me.Label4.Left = 3.894737!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label4.Text = "Forma de Pago"
        Me.Label4.Top = 1.210526!
        Me.Label4.Width = 1.125!
        '
        'Line1
        '
        Me.Line1.Border.BottomColor = System.Drawing.Color.Black
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.LeftColor = System.Drawing.Color.Black
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.RightColor = System.Drawing.Color.Black
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.TopColor = System.Drawing.Color.Black
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 3.894737!
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.421053!
        Me.Line1.Width = 1.473684!
        Me.Line1.X1 = 3.894737!
        Me.Line1.X2 = 5.368421!
        Me.Line1.Y1 = 1.421053!
        Me.Line1.Y2 = 1.421053!
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
        Me.Label5.Left = 5.473684!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: rgb(255,255,255); text-align: center; font-weight: bold; background-color:" & _
            " #8080FF; font-size: 8.5pt; "
        Me.Label5.Text = "Bodegas"
        Me.Label5.Top = 1.210526!
        Me.Label5.Width = 1.4375!
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
        Me.Label6.Left = 3.842105!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label6.Text = "Fecha Vencimiento"
        Me.Label6.Top = 1.894737!
        Me.Label6.Width = 1.4375!
        '
        'Line3
        '
        Me.Line3.Border.BottomColor = System.Drawing.Color.Black
        Me.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.LeftColor = System.Drawing.Color.Black
        Me.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.RightColor = System.Drawing.Color.Black
        Me.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.TopColor = System.Drawing.Color.Black
        Me.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 3.789474!
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 2.052632!
        Me.Line3.Width = 1.578947!
        Me.Line3.X1 = 3.789474!
        Me.Line3.X2 = 5.368421!
        Me.Line3.Y1 = 2.052632!
        Me.Line3.Y2 = 2.052632!
        '
        'LblCodProveedor
        '
        Me.LblCodProveedor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCodProveedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodProveedor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCodProveedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodProveedor.Border.RightColor = System.Drawing.Color.Black
        Me.LblCodProveedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodProveedor.Border.TopColor = System.Drawing.Color.Black
        Me.LblCodProveedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCodProveedor.Height = 0.1875!
        Me.LblCodProveedor.HyperLink = Nothing
        Me.LblCodProveedor.Left = 0.368421!
        Me.LblCodProveedor.Name = "LblCodProveedor"
        Me.LblCodProveedor.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblCodProveedor.Text = ""
        Me.LblCodProveedor.Top = 1.473684!
        Me.LblCodProveedor.Width = 3.0!
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
        Me.LblNombres.Height = 0.1875!
        Me.LblNombres.HyperLink = Nothing
        Me.LblNombres.Left = 0.368421!
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblNombres.Text = ""
        Me.LblNombres.Top = 1.631579!
        Me.LblNombres.Width = 3.0!
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
        Me.LblApellidos.Height = 0.1875!
        Me.LblApellidos.HyperLink = Nothing
        Me.LblApellidos.Left = 0.368421!
        Me.LblApellidos.Name = "LblApellidos"
        Me.LblApellidos.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblApellidos.Text = ""
        Me.LblApellidos.Top = 1.842105!
        Me.LblApellidos.Width = 3.0!
        '
        'LblDireccionProveedor
        '
        Me.LblDireccionProveedor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Border.RightColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Border.TopColor = System.Drawing.Color.Black
        Me.LblDireccionProveedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccionProveedor.Height = 0.1875!
        Me.LblDireccionProveedor.HyperLink = Nothing
        Me.LblDireccionProveedor.Left = 0.368421!
        Me.LblDireccionProveedor.Name = "LblDireccionProveedor"
        Me.LblDireccionProveedor.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblDireccionProveedor.Text = ""
        Me.LblDireccionProveedor.Top = 2.0!
        Me.LblDireccionProveedor.Width = 3.0!
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
        Me.LblTelefono.Height = 0.1875!
        Me.LblTelefono.HyperLink = Nothing
        Me.LblTelefono.Left = 0.368421!
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblTelefono.Text = ""
        Me.LblTelefono.Top = 2.210526!
        Me.LblTelefono.Width = 3.0!
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
        Me.LblBodegas.Left = 5.473684!
        Me.LblBodegas.Name = "LblBodegas"
        Me.LblBodegas.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblBodegas.Text = ""
        Me.LblBodegas.Top = 1.473684!
        Me.LblBodegas.Width = 1.5!
        '
        'LblFechaVence
        '
        Me.LblFechaVence.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Border.RightColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Border.TopColor = System.Drawing.Color.Black
        Me.LblFechaVence.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaVence.Height = 0.1875!
        Me.LblFechaVence.HyperLink = Nothing
        Me.LblFechaVence.Left = 5.526316!
        Me.LblFechaVence.Name = "LblFechaVence"
        Me.LblFechaVence.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblFechaVence.Text = ""
        Me.LblFechaVence.Top = 2.263158!
        Me.LblFechaVence.Visible = False
        Me.LblFechaVence.Width = 1.5!
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
        Me.lneBillTo.Left = 0.368421!
        Me.lneBillTo.LineWeight = 2.0!
        Me.lneBillTo.Name = "lneBillTo"
        Me.lneBillTo.Top = 1.421053!
        Me.lneBillTo.Width = 3.0!
        Me.lneBillTo.X1 = 0.368421!
        Me.lneBillTo.X2 = 3.368421!
        Me.lneBillTo.Y1 = 1.421053!
        Me.lneBillTo.Y2 = 1.421053!
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
        Me.Label8.Left = 5.578947!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label8.Text = "Representante"
        Me.Label8.Top = 1.842105!
        Me.Label8.Width = 1.0!
        '
        'LblVendedor
        '
        Me.LblVendedor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblVendedor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblVendedor.Border.RightColor = System.Drawing.Color.Black
        Me.LblVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblVendedor.Border.TopColor = System.Drawing.Color.Black
        Me.LblVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblVendedor.Height = 0.1875!
        Me.LblVendedor.HyperLink = Nothing
        Me.LblVendedor.Left = 5.578947!
        Me.LblVendedor.Name = "LblVendedor"
        Me.LblVendedor.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblVendedor.Text = ""
        Me.LblVendedor.Top = 2.105263!
        Me.LblVendedor.Width = 1.5!
        '
        'Line4
        '
        Me.Line4.Border.BottomColor = System.Drawing.Color.Black
        Me.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.LeftColor = System.Drawing.Color.Black
        Me.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.RightColor = System.Drawing.Color.Black
        Me.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.TopColor = System.Drawing.Color.Black
        Me.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 5.578947!
        Me.Line4.LineWeight = 2.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 2.052632!
        Me.Line4.Width = 1.578947!
        Me.Line4.X1 = 5.578947!
        Me.Line4.X2 = 7.157894!
        Me.Line4.Y1 = 2.052632!
        Me.Line4.Y2 = 2.052632!
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
        Me.Label10.Left = 5.473684!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label10.Text = "Bodegas"
        Me.Label10.Top = 1.210526!
        Me.Label10.Width = 1.4375!
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
        Me.Label11.Height = 0.0625!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 5.473684!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.Label11.Text = ""
        Me.Label11.Top = 1.578947!
        Me.Label11.Width = 1.5!
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
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.0!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label12.Text = "Product ID"
        Me.Label12.Top = 2.526316!
        Me.Label12.Width = 0.6875!
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
        Me.Label15.Height = 0.2105263!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 4.368421!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label15.Text = "Precio Unit"
        Me.Label15.Top = 2.526316!
        Me.Label15.Width = 0.7894736!
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
        Me.Label16.Height = 0.2105263!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 5.157895!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label16.Text = "%Desc"
        Me.Label16.Top = 2.526316!
        Me.Label16.Width = 0.5263159!
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
        Me.Label18.Height = 0.2105263!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 6.473684!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label18.Text = "Total"
        Me.Label18.Top = 2.526316!
        Me.Label18.Width = 0.8421054!
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
        Me.Label19.Height = 0.1875!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 0.0!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "color: Black; text-align: center; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label19.Text = "Product ID"
        Me.Label19.Top = 2.526316!
        Me.Label19.Width = 0.6875!
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
        Me.Label21.Height = 0.2105263!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0.0!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label21.Text = "Product ID"
        Me.Label21.Top = 2.526316!
        Me.Label21.Width = 0.6842105!
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
        Me.Label22.Height = 0.2105263!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.6842105!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label22.Text = "Nombre Producto"
        Me.Label22.Top = 2.526316!
        Me.Label22.Width = 3.157895!
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
        Me.Label23.Height = 0.2105263!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 3.842105!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label23.Text = "Cant"
        Me.Label23.Top = 2.526316!
        Me.Label23.Width = 0.5263156!
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
        Me.Line2.Left = 5.473684!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.421053!
        Me.Line2.Width = 1.578947!
        Me.Line2.X1 = 5.473684!
        Me.Line2.X2 = 7.052631!
        Me.Line2.Y1 = 1.421053!
        Me.Line2.Y2 = 1.421053!
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
        Me.LblFechaOrden.Height = 0.2105263!
        Me.LblFechaOrden.HyperLink = Nothing
        Me.LblFechaOrden.Left = 3.894737!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = ""
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 2.105263!
        Me.LblFechaOrden.Width = 1.368421!
        '
        'Label17
        '
        Me.Label17.Border.BottomColor = System.Drawing.Color.Black
        Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.LeftColor = System.Drawing.Color.Black
        Me.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.RightColor = System.Drawing.Color.Black
        Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.TopColor = System.Drawing.Color.Black
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Height = 0.2105263!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 5.68421!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label17.Text = "Precio Neto"
        Me.Label17.Top = 2.526316!
        Me.Label17.Width = 0.789474!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox6, Me.TextBox7, Me.TextBox5})
        Me.Detail1.Height = 0.1875!
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
        Me.TextBox1.DataField = "Cod_Productos"
        Me.TextBox1.Height = 0.1578947!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.7368421!
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
        Me.TextBox2.DataField = "Descripcion_Producto"
        Me.TextBox2.Height = 0.1578947!
        Me.TextBox2.Left = 0.7368421!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 3.105263!
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
        Me.TextBox3.DataField = "Cantidad"
        Me.TextBox3.Height = 0.1578947!
        Me.TextBox3.Left = 3.842105!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.5263156!
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
        Me.TextBox4.DataField = "Precio_Unitario"
        Me.TextBox4.Height = 0.1578947!
        Me.TextBox4.Left = 4.368421!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.7894736!
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
        Me.TextBox6.DataField = "Precio_Neto"
        Me.TextBox6.Height = 0.1578947!
        Me.TextBox6.Left = 5.68421!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.7894735!
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
        Me.TextBox7.DataField = "Importe"
        Me.TextBox7.Height = 0.1578947!
        Me.TextBox7.Left = 6.473684!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.8421056!
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
        Me.TextBox5.DataField = "Descuento"
        Me.TextBox5.Height = 0.1578947!
        Me.TextBox5.Left = 5.157895!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.5263159!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFreight, Me.lblSubTotals, Me.lblGrandTotal, Me.Label3, Me.LblSubTotal, Me.LblIva, Me.LblPagado, Me.LblTotal, Me.LblNotas, Me.Label7, Me.Label9, Me.LblDescuento, Me.LblLetras})
        Me.PageFooter1.Height = 0.9791667!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'lblFreight
        '
        Me.lblFreight.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFreight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFreight.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFreight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFreight.Border.RightColor = System.Drawing.Color.Black
        Me.lblFreight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFreight.Border.TopColor = System.Drawing.Color.Black
        Me.lblFreight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFreight.Height = 0.1875!
        Me.lblFreight.HyperLink = Nothing
        Me.lblFreight.Left = 5.315789!
        Me.lblFreight.Name = "lblFreight"
        Me.lblFreight.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblFreight.Text = "Iva"
        Me.lblFreight.Top = 0.2105263!
        Me.lblFreight.Width = 1.125!
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
        Me.lblSubTotals.Height = 0.1875!
        Me.lblSubTotals.HyperLink = Nothing
        Me.lblSubTotals.Left = 5.315789!
        Me.lblSubTotals.Name = "lblSubTotals"
        Me.lblSubTotals.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblSubTotals.Text = "Sub Total "
        Me.lblSubTotals.Top = 0.0!
        Me.lblSubTotals.Width = 1.125!
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrandTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrandTotal.Border.RightColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrandTotal.Border.TopColor = System.Drawing.Color.Black
        Me.lblGrandTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrandTotal.Height = 0.1875!
        Me.lblGrandTotal.HyperLink = Nothing
        Me.lblGrandTotal.Left = 5.315789!
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblGrandTotal.Text = "Total"
        Me.lblGrandTotal.Top = 0.4210526!
        Me.lblGrandTotal.Width = 1.125!
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
        Me.Label3.Left = 7.894737!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label3.Text = "Pagado"
        Me.Label3.Top = 0.2105263!
        Me.Label3.Visible = False
        Me.Label3.Width = 1.125!
        '
        'LblSubTotal
        '
        Me.LblSubTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal.Border.RightColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal.Border.TopColor = System.Drawing.Color.Black
        Me.LblSubTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSubTotal.Height = 0.1875!
        Me.LblSubTotal.HyperLink = Nothing
        Me.LblSubTotal.Left = 6.421052!
        Me.LblSubTotal.Name = "LblSubTotal"
        Me.LblSubTotal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblSubTotal.Text = ""
        Me.LblSubTotal.Top = 0.0!
        Me.LblSubTotal.Width = 0.875!
        '
        'LblIva
        '
        Me.LblIva.Border.BottomColor = System.Drawing.Color.Black
        Me.LblIva.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIva.Border.LeftColor = System.Drawing.Color.Black
        Me.LblIva.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIva.Border.RightColor = System.Drawing.Color.Black
        Me.LblIva.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIva.Border.TopColor = System.Drawing.Color.Black
        Me.LblIva.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIva.Height = 0.1875!
        Me.LblIva.HyperLink = Nothing
        Me.LblIva.Left = 6.421052!
        Me.LblIva.Name = "LblIva"
        Me.LblIva.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblIva.Text = ""
        Me.LblIva.Top = 0.2105263!
        Me.LblIva.Width = 0.875!
        '
        'LblPagado
        '
        Me.LblPagado.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPagado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagado.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPagado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagado.Border.RightColor = System.Drawing.Color.Black
        Me.LblPagado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagado.Border.TopColor = System.Drawing.Color.Black
        Me.LblPagado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPagado.Height = 0.1875!
        Me.LblPagado.HyperLink = Nothing
        Me.LblPagado.Left = 8.999999!
        Me.LblPagado.Name = "LblPagado"
        Me.LblPagado.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblPagado.Text = ""
        Me.LblPagado.Top = 0.2105263!
        Me.LblPagado.Visible = False
        Me.LblPagado.Width = 0.875!
        '
        'LblTotal
        '
        Me.LblTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Height = 0.1875!
        Me.LblTotal.HyperLink = Nothing
        Me.LblTotal.Left = 6.421052!
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblTotal.Text = ""
        Me.LblTotal.Top = 0.4210526!
        Me.LblTotal.Width = 0.875!
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
        Me.LblNotas.Height = 0.4210526!
        Me.LblNotas.HyperLink = Nothing
        Me.LblNotas.Left = 1.157895!
        Me.LblNotas.Name = "LblNotas"
        Me.LblNotas.Style = ""
        Me.LblNotas.Text = ""
        Me.LblNotas.Top = 0.05263158!
        Me.LblNotas.Width = 3.789474!
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
        Me.Label7.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.Label7.Text = "Observaciones"
        Me.Label7.Top = 0.05263158!
        Me.Label7.Width = 1.0625!
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
        Me.Label9.Left = 2.789474!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label9.Text = "Descuento"
        Me.Label9.Top = 0.0!
        Me.Label9.Visible = False
        Me.Label9.Width = 1.125!
        '
        'LblDescuento
        '
        Me.LblDescuento.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDescuento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDescuento.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDescuento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDescuento.Border.RightColor = System.Drawing.Color.Black
        Me.LblDescuento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDescuento.Border.TopColor = System.Drawing.Color.Black
        Me.LblDescuento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDescuento.Height = 0.1875!
        Me.LblDescuento.HyperLink = Nothing
        Me.LblDescuento.Left = 3.894737!
        Me.LblDescuento.Name = "LblDescuento"
        Me.LblDescuento.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.LblDescuento.Text = ""
        Me.LblDescuento.Top = 0.0!
        Me.LblDescuento.Visible = False
        Me.LblDescuento.Width = 0.875!
        '
        'LblLetras
        '
        Me.LblLetras.Border.BottomColor = System.Drawing.Color.Black
        Me.LblLetras.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLetras.Border.LeftColor = System.Drawing.Color.Black
        Me.LblLetras.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLetras.Border.RightColor = System.Drawing.Color.Black
        Me.LblLetras.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLetras.Border.TopColor = System.Drawing.Color.Black
        Me.LblLetras.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLetras.Height = 0.2083333!
        Me.LblLetras.HyperLink = Nothing
        Me.LblLetras.Left = 0.2631579!
        Me.LblLetras.Name = "LblLetras"
        Me.LblLetras.Style = ""
        Me.LblLetras.Text = ""
        Me.LblLetras.Top = 0.5263157!
        Me.LblLetras.Width = 4.677083!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'ArepFacturas2
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.49!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.42!
        Me.PageSettings.Margins.Top = 0.2!
        Me.PageSettings.PaperHeight = 5.5!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperName = "Custom paper"
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.354166!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMetodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCodProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccionProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaVence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFreight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPagado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Private WithEvents lblProductName As DataDynamics.ActiveReports.Label
    Private WithEvents lblUnitPrice As DataDynamics.ActiveReports.Label
    Private WithEvents lblDiscount As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtMetodo As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents LblCodProveedor As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents LblApellidos As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccionProveedor As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents LblBodegas As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaVence As DataDynamics.ActiveReports.Label
    Private WithEvents lneBillTo As DataDynamics.ActiveReports.Line
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblVendedor As DataDynamics.ActiveReports.Label
    Private WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label19 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Private WithEvents lblFreight As DataDynamics.ActiveReports.Label
    Private WithEvents lblSubTotals As DataDynamics.ActiveReports.Label
    Private WithEvents lblGrandTotal As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblSubTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents LblIva As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPagado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNotas As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDescuento As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLetras As DataDynamics.ActiveReports.Label
End Class 
