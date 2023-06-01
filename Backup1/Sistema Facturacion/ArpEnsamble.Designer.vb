<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArpEnsamble
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ArpEnsamble))
        Dim SqlDBDataSource1 As DataDynamics.ActiveReports.DataSources.SqlDBDataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.LblEncabezado1 = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblDireccion1 = New DataDynamics.ActiveReports.Label
        Me.LblDireccion2 = New DataDynamics.ActiveReports.Label
        Me.LblTipoEnsamble = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.LblCodProducto = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.TxtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.TxtDescripcion = New DataDynamics.ActiveReports.TextBox
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.TxtCantidad = New DataDynamics.ActiveReports.TextBox
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.TxtTipoEnsamble = New DataDynamics.ActiveReports.TextBox
        Me.TxtFecha = New DataDynamics.ActiveReports.TextBox
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.TxtNumero = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.TxtBodegaOrigen = New DataDynamics.ActiveReports.TextBox
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.TxtBodegaDestino = New DataDynamics.ActiveReports.TextBox
        CType(Me.LblEncabezado1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDireccion2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoEnsamble, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTipoEnsamble, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBodegaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBodegaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblEncabezado1, Me.ImgLogo, Me.LblDireccion1, Me.LblDireccion2, Me.LblTipoEnsamble, Me.Label3, Me.Label1, Me.Label2, Me.LblCodProducto, Me.Label4, Me.Label5, Me.TxtCodigo, Me.Label6, Me.TxtDescripcion, Me.Label7, Me.TxtCantidad, Me.Label8, Me.TxtTipoEnsamble, Me.TxtFecha, Me.Label9, Me.TxtNumero, Me.Label10, Me.Label11, Me.TxtBodegaOrigen, Me.Label12, Me.TxtBodegaDestino})
        Me.PageHeader1.Height = 2.6875!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'LblEncabezado1
        '
        Me.LblEncabezado1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblEncabezado1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblEncabezado1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado1.Border.RightColor = System.Drawing.Color.Black
        Me.LblEncabezado1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado1.Border.TopColor = System.Drawing.Color.Black
        Me.LblEncabezado1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado1.Height = 0.3125!
        Me.LblEncabezado1.HyperLink = Nothing
        Me.LblEncabezado1.Left = 0.0625!
        Me.LblEncabezado1.Name = "LblEncabezado1"
        Me.LblEncabezado1.Style = "ddo-char-set: 0; text-align: center; font-style: italic; font-size: 15.75pt; "
        Me.LblEncabezado1.Text = "Soluciones Informaticas"
        Me.LblEncabezado1.Top = 0.0!
        Me.LblEncabezado1.Width = 6.6875!
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
        Me.ImgLogo.Left = 0.0625!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.1875!
        '
        'LblDireccion1
        '
        Me.LblDireccion1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDireccion1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDireccion1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion1.Border.RightColor = System.Drawing.Color.Black
        Me.LblDireccion1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion1.Border.TopColor = System.Drawing.Color.Black
        Me.LblDireccion1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion1.Height = 0.1875!
        Me.LblDireccion1.HyperLink = Nothing
        Me.LblDireccion1.Left = 0.0625!
        Me.LblDireccion1.Name = "LblDireccion1"
        Me.LblDireccion1.Style = "ddo-char-set: 0; text-align: center; font-style: italic; font-size: 9.75pt; "
        Me.LblDireccion1.Text = "Praderas del Doral Alameda 12 Casa #908"
        Me.LblDireccion1.Top = 0.3125!
        Me.LblDireccion1.Width = 6.6875!
        '
        'LblDireccion2
        '
        Me.LblDireccion2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDireccion2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDireccion2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion2.Border.RightColor = System.Drawing.Color.Black
        Me.LblDireccion2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion2.Border.TopColor = System.Drawing.Color.Black
        Me.LblDireccion2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion2.Height = 0.1875!
        Me.LblDireccion2.HyperLink = Nothing
        Me.LblDireccion2.Left = 0.0625!
        Me.LblDireccion2.Name = "LblDireccion2"
        Me.LblDireccion2.Style = "ddo-char-set: 0; text-align: center; font-style: italic; font-size: 9.75pt; "
        Me.LblDireccion2.Text = "Praderas del Doral Alameda 12 Casa #908"
        Me.LblDireccion2.Top = 0.5!
        Me.LblDireccion2.Width = 6.6875!
        '
        'LblTipoEnsamble
        '
        Me.LblTipoEnsamble.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTipoEnsamble.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoEnsamble.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTipoEnsamble.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoEnsamble.Border.RightColor = System.Drawing.Color.Black
        Me.LblTipoEnsamble.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoEnsamble.Border.TopColor = System.Drawing.Color.Black
        Me.LblTipoEnsamble.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoEnsamble.Height = 0.3125!
        Me.LblTipoEnsamble.HyperLink = Nothing
        Me.LblTipoEnsamble.Left = 0.0625!
        Me.LblTipoEnsamble.Name = "LblTipoEnsamble"
        Me.LblTipoEnsamble.Style = "color: #0000C0; ddo-char-set: 0; text-align: center; font-weight: bold; font-styl" & _
            "e: normal; font-size: 12pt; "
        Me.LblTipoEnsamble.Text = "ENSAMBLE DE PRODUCTOS"
        Me.LblTipoEnsamble.Top = 0.8125!
        Me.LblTipoEnsamble.Width = 6.6875!
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
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 5.75!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; background-color: #C0C0FF" & _
            "; font-size: 9pt; "
        Me.Label3.Text = "Desecho"
        Me.Label3.Top = 2.5!
        Me.Label3.Width = 1.0!
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
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-weight: bold; background-color: #C0C0FF; font-size: 9pt; "
        Me.Label1.Text = "Descripcion"
        Me.Label1.Top = 2.5!
        Me.Label1.Width = 3.6875!
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
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 4.75!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; background-color: #C0C0FF" & _
            "; font-size: 9pt; "
        Me.Label2.Text = "Requerido"
        Me.Label2.Top = 2.5!
        Me.Label2.Width = 1.0!
        '
        'LblCodProducto
        '
        Me.LblCodProducto.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCodProducto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCodProducto.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCodProducto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCodProducto.Border.RightColor = System.Drawing.Color.Black
        Me.LblCodProducto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCodProducto.Border.TopColor = System.Drawing.Color.Black
        Me.LblCodProducto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCodProducto.Height = 0.1875!
        Me.LblCodProducto.HyperLink = Nothing
        Me.LblCodProducto.Left = 0.0625!
        Me.LblCodProducto.Name = "LblCodProducto"
        Me.LblCodProducto.Style = "ddo-char-set: 0; font-weight: bold; background-color: #C0C0FF; font-size: 9pt; "
        Me.LblCodProducto.Text = "Componente"
        Me.LblCodProducto.Top = 2.5!
        Me.LblCodProducto.Width = 1.0!
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
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0625!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: center; background-color: #C0C0FF; "
        Me.Label4.Text = "Lista de Componentes para Ensamble"
        Me.Label4.Top = 2.3125!
        Me.Label4.Width = 6.6875!
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
        Me.Label5.Left = 0.0625!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label5.Text = "Codigo"
        Me.Label5.Top = 1.625!
        Me.Label5.Width = 0.625!
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCodigo.Height = 0.1875!
        Me.TxtCodigo.Left = 0.75!
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Style = ""
        Me.TxtCodigo.Text = Nothing
        Me.TxtCodigo.Top = 1.625!
        Me.TxtCodigo.Width = 0.6875!
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
        Me.Label6.Left = 1.625!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label6.Text = "Descripcion"
        Me.Label6.Top = 1.625!
        Me.Label6.Width = 0.8125!
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDescripcion.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDescripcion.Border.RightColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDescripcion.Border.TopColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDescripcion.Height = 0.1875!
        Me.TxtDescripcion.Left = 2.5625!
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Style = ""
        Me.TxtDescripcion.Text = Nothing
        Me.TxtDescripcion.Top = 1.625!
        Me.TxtDescripcion.Width = 2.75!
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
        Me.Label7.Left = 5.4375!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label7.Text = "Cantidad"
        Me.Label7.Top = 1.625!
        Me.Label7.Width = 0.625!
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantidad.Height = 0.1875!
        Me.TxtCantidad.Left = 6.125!
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Style = ""
        Me.TxtCantidad.Text = Nothing
        Me.TxtCantidad.Top = 1.625!
        Me.TxtCantidad.Width = 0.625!
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
        Me.Label8.Left = 0.0625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label8.Text = "Tipo Ensamble"
        Me.Label8.Top = 1.3125!
        Me.Label8.Width = 1.0625!
        '
        'TxtTipoEnsamble
        '
        Me.TxtTipoEnsamble.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTipoEnsamble.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipoEnsamble.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTipoEnsamble.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipoEnsamble.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTipoEnsamble.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipoEnsamble.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTipoEnsamble.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipoEnsamble.Height = 0.1875!
        Me.TxtTipoEnsamble.Left = 1.1875!
        Me.TxtTipoEnsamble.Name = "TxtTipoEnsamble"
        Me.TxtTipoEnsamble.Style = ""
        Me.TxtTipoEnsamble.Text = Nothing
        Me.TxtTipoEnsamble.Top = 1.3125!
        Me.TxtTipoEnsamble.Width = 1.6875!
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
        Me.TxtFecha.Height = 0.1875!
        Me.TxtFecha.Left = 3.625!
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.Style = ""
        Me.TxtFecha.Text = Nothing
        Me.TxtFecha.Top = 1.3125!
        Me.TxtFecha.Width = 0.8125!
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
        Me.Label9.Left = 3.0625!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label9.Text = "Fecha"
        Me.Label9.Top = 1.3125!
        Me.Label9.Width = 0.5!
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
        Me.TxtNumero.Height = 0.1875!
        Me.TxtNumero.Left = 6.0!
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Style = ""
        Me.TxtNumero.Text = Nothing
        Me.TxtNumero.Top = 1.3125!
        Me.TxtNumero.Width = 0.75!
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
        Me.Label10.Left = 4.6875!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label10.Text = "Numero Ensamble"
        Me.Label10.Top = 1.3125!
        Me.Label10.Width = 1.25!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4})
        Me.Detail1.Height = 0.25!
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
        Me.TextBox1.DataField = "CodProducto"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0625!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.0!
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
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 1.0625!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = ""
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 3.6875!
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
        Me.TextBox3.DataField = "Cantidad_Ensamble"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 4.75!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 1.0!
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
        Me.TextBox4.DataField = "Desecho"
        Me.TextBox4.Height = 0.1875!
        Me.TextBox4.Left = 5.75!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 1.0!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.15625!
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
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.375!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label11.Text = "Bodega Origen:"
        Me.Label11.Top = 2.0!
        Me.Label11.Width = 1.0625!
        '
        'TxtBodegaOrigen
        '
        Me.TxtBodegaOrigen.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtBodegaOrigen.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBodegaOrigen.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtBodegaOrigen.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBodegaOrigen.Border.RightColor = System.Drawing.Color.Black
        Me.TxtBodegaOrigen.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBodegaOrigen.Border.TopColor = System.Drawing.Color.Black
        Me.TxtBodegaOrigen.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBodegaOrigen.Height = 0.1875!
        Me.TxtBodegaOrigen.Left = 1.4375!
        Me.TxtBodegaOrigen.Name = "TxtBodegaOrigen"
        Me.TxtBodegaOrigen.Style = ""
        Me.TxtBodegaOrigen.Text = Nothing
        Me.TxtBodegaOrigen.Top = 2.0!
        Me.TxtBodegaOrigen.Width = 1.25!
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
        Me.Label12.Left = 3.25!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; "
        Me.Label12.Text = "Bodega Destino:"
        Me.Label12.Top = 2.0!
        Me.Label12.Width = 1.1875!
        '
        'TxtBodegaDestino
        '
        Me.TxtBodegaDestino.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtBodegaDestino.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBodegaDestino.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtBodegaDestino.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBodegaDestino.Border.RightColor = System.Drawing.Color.Black
        Me.TxtBodegaDestino.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBodegaDestino.Border.TopColor = System.Drawing.Color.Black
        Me.TxtBodegaDestino.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtBodegaDestino.Height = 0.1875!
        Me.TxtBodegaDestino.Left = 4.4375!
        Me.TxtBodegaDestino.Name = "TxtBodegaDestino"
        Me.TxtBodegaDestino.Style = ""
        Me.TxtBodegaDestino.Text = Nothing
        Me.TxtBodegaDestino.Top = 2.0!
        Me.TxtBodegaDestino.Width = 1.25!
        '
        'ArpEnsamble
        '
        Me.MasterReport = False
        SqlDBDataSource1.ConnectionString = "data source=JUAN\SQL2005;initial catalog=SistemaFacturacion;integrated security=S" & _
            "SPI;persist security info=False"
        SqlDBDataSource1.SQL = "SELECT     *" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         Detalle_Ensamble INNER JOIN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "                      Pro" & _
            "ductos ON Detalle_Ensamble.CodProducto = Productos.Cod_Productos"
        Me.DataSource = SqlDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.7!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.3!
        Me.PageSettings.Margins.Top = 0.7!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.84375!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        Me.WatermarkSizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        CType(Me.LblEncabezado1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDireccion2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoEnsamble, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTipoEnsamble, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBodegaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBodegaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents LblEncabezado1 As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblDireccion1 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDireccion2 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblCodProducto As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblTipoEnsamble As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtDescripcion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCantidad As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtTipoEnsamble As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtNumero As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtBodegaOrigen As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtBodegaDestino As DataDynamics.ActiveReports.TextBox
End Class
