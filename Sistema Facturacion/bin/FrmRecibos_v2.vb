Public Class FrmRecibosCaja
    Inherits Form

    ' ===== Paleta de colores (estilo plano moderno) =====
    Private ReadOnly clrFondo As Color = Color.FromArgb(243, 244, 246)
    Private ReadOnly clrTarjeta As Color = Color.White
    Private ReadOnly clrBorde As Color = Color.FromArgb(226, 229, 233)
    Private ReadOnly clrTextoPrimario As Color = Color.FromArgb(31, 41, 55)
    Private ReadOnly clrTextoSecundario As Color = Color.FromArgb(107, 114, 128)
    Private ReadOnly clrAcento As Color = Color.FromArgb(37, 99, 235)
    Private ReadOnly clrAcentoFondo As Color = Color.FromArgb(239, 246, 255)
    Private ReadOnly clrPeligro As Color = Color.FromArgb(220, 38, 38)

    ' ===== Controles principales =====
    Private pnlHeader As Panel
    Private lblTitulo As Label
    Private btnNuevo As Button
    Private btnImprimir As Button
    Private btnEliminar As Button

    Private pnlDatosGenerales As Panel
    Private lblFecha As Label
    Private dtpFecha As DateTimePicker
    Private lblNumero As Label
    Private cboTipoRecibo As ComboBox
    Private txtNumero As TextBox
    Private lblMoneda As Label
    Private cboMoneda As ComboBox

    Private pnlCliente As Panel
    Private lblSeccionCliente As Label
    Private btnAbono As Button
    Private btnPlanPago As Button
    Private txtBuscarCliente As TextBox
    Private btnBuscarCliente As Button
    Private txtDireccion As TextBox
    Private txtRucCedula As TextBox
    Private chkRetener1 As CheckBox
    Private chkRetener2 As CheckBox
    Private lblCajero As Label

    Private pnlDetalle As Panel
    Private lblSeccionDetalle As Label
    Private btnAgregarFila As Button
    Private dgvDetalle As DataGridView

    Private pnlTotales As TableLayoutPanel
    Private tarjetaSubTotal As Panel
    Private tarjetaDescuento As Panel
    Private tarjetaTotalRecibido As Panel
    Private tarjetaPorAplicar As Panel
    Private lblSubTotal As Label
    Private lblValorSubTotal As Label
    Private lblDescuento As Label
    Private lblValorDescuento As Label
    Private lblTotalRecibido As Label
    Private lblValorTotalRecibido As Label
    Private lblPorAplicar As Label
    Private lblValorPorAplicar As Label

    Private lblObservaciones As Label
    Private txtObservaciones As TextBox

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()

        Me.SuspendLayout()

        ' ===== Formulario =====
        Me.Text = "Recibos de Caja"
        Me.ClientSize = New Size(950, 760)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = clrFondo
        Me.Font = New Font("Segoe UI", 9.0!)
        Me.MinimumSize = New Size(900, 700)

        ' ===== Header con titulo y acciones principales =====
        pnlHeader = New Panel()
        pnlHeader.BackColor = clrTarjeta
        pnlHeader.Location = New Point(20, 20)
        pnlHeader.Size = New Size(910, 56)
        pnlHeader.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        lblTitulo = New Label()
        lblTitulo.Text = "Recibos de caja"
        lblTitulo.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblTitulo.ForeColor = clrTextoPrimario
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(16, 16)

        btnEliminar = CrearBotonEstandar("Eliminar", 90)
        btnEliminar.ForeColor = clrPeligro
        btnEliminar.Location = New Point(910 - 16 - 90, 12)
        btnEliminar.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        btnImprimir = CrearBotonEstandar("Imprimir", 90)
        btnImprimir.Location = New Point(btnEliminar.Left - 8 - 90, 12)
        btnImprimir.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        btnNuevo = CrearBotonEstandar("Nuevo", 90)
        btnNuevo.Location = New Point(btnImprimir.Left - 8 - 90, 12)
        btnNuevo.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        pnlHeader.Controls.AddRange({lblTitulo, btnNuevo, btnImprimir, btnEliminar})

        ' ===== Datos generales: Fecha / Numero / Moneda =====
        pnlDatosGenerales = New Panel()
        pnlDatosGenerales.Location = New Point(20, 88)
        pnlDatosGenerales.Size = New Size(910, 50)
        pnlDatosGenerales.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        lblFecha = CrearEtiquetaSecundaria("Fecha", New Point(0, 0))
        dtpFecha = New DateTimePicker()
        dtpFecha.Location = New Point(0, 20)
        dtpFecha.Size = New Size(140, 24)
        dtpFecha.Format = DateTimePickerFormat.Short

        lblNumero = CrearEtiquetaSecundaria("Numero", New Point(320, 0))
        cboTipoRecibo = New ComboBox()
        cboTipoRecibo.Location = New Point(320, 20)
        cboTipoRecibo.Size = New Size(55, 24)
        cboTipoRecibo.DropDownStyle = ComboBoxStyle.DropDownList
        cboTipoRecibo.Items.Add("B")
        cboTipoRecibo.SelectedIndex = 0

        txtNumero = New TextBox()
        txtNumero.Location = New Point(380, 20)
        txtNumero.Size = New Size(150, 24)
        txtNumero.Text = "0"

        lblMoneda = CrearEtiquetaSecundaria("Moneda", New Point(650, 0))
        cboMoneda = New ComboBox()
        cboMoneda.Location = New Point(650, 20)
        cboMoneda.Size = New Size(150, 24)
        cboMoneda.DropDownStyle = ComboBoxStyle.DropDownList
        cboMoneda.Items.Add("Cordobas")
        cboMoneda.Items.Add("Dolares")
        cboMoneda.SelectedIndex = 0

        pnlDatosGenerales.Controls.AddRange({lblFecha, dtpFecha, lblNumero, cboTipoRecibo, txtNumero, lblMoneda, cboMoneda})

        ' ===== Tarjeta: Informacion del cliente =====
        pnlCliente = New Panel()
        pnlCliente.BackColor = clrTarjeta
        pnlCliente.Location = New Point(20, 150)
        pnlCliente.Size = New Size(910, 160)
        pnlCliente.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        lblSeccionCliente = New Label()
        lblSeccionCliente.Text = "Informacion del cliente"
        lblSeccionCliente.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        lblSeccionCliente.ForeColor = clrTextoSecundario
        lblSeccionCliente.AutoSize = True
        lblSeccionCliente.Location = New Point(16, 12)

        btnPlanPago = CrearBotonEstandar("Plan de pago", 120)
        btnPlanPago.Location = New Point(910 - 16 - 120, 8)
        btnPlanPago.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        btnAbono = CrearBotonEstandar("Abono", 100)
        btnAbono.Location = New Point(btnPlanPago.Left - 8 - 100, 8)
        btnAbono.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAbono.ForeColor = clrAcento
        btnAbono.FlatAppearance.BorderColor = clrAcento
        btnAbono.FlatAppearance.BorderSize = 2

        txtBuscarCliente = New TextBox()
        txtBuscarCliente.Location = New Point(16, 44)
        txtBuscarCliente.Size = New Size(830, 24)
        txtBuscarCliente.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        btnBuscarCliente = New Button()
        btnBuscarCliente.Text = "..."
        btnBuscarCliente.Size = New Size(36, 24)
        btnBuscarCliente.Location = New Point(858, 44)
        btnBuscarCliente.FlatStyle = FlatStyle.Flat
        btnBuscarCliente.FlatAppearance.BorderColor = clrBorde
        btnBuscarCliente.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        txtDireccion = New TextBox()
        txtDireccion.Location = New Point(16, 78)
        txtDireccion.Size = New Size(437, 24)
        txtDireccion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        txtRucCedula = New TextBox()
        txtRucCedula.Location = New Point(465, 78)
        txtRucCedula.Size = New Size(429, 24)
        txtRucCedula.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        chkRetener1 = New CheckBox()
        chkRetener1.Text = "Retener 1%"
        chkRetener1.AutoSize = True
        chkRetener1.Location = New Point(16, 116)

        chkRetener2 = New CheckBox()
        chkRetener2.Text = "Retener 2%"
        chkRetener2.AutoSize = True
        chkRetener2.Location = New Point(120, 116)

        lblCajero = New Label()
        lblCajero.Text = "Cajero: 001"
        lblCajero.ForeColor = clrTextoSecundario
        lblCajero.AutoSize = True
        lblCajero.Location = New Point(800, 118)
        lblCajero.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        pnlCliente.Controls.AddRange({lblSeccionCliente, btnAbono, btnPlanPago, txtBuscarCliente,
                                       btnBuscarCliente, txtDireccion, txtRucCedula, chkRetener1,
                                       chkRetener2, lblCajero})

        ' ===== Tarjeta: Detalle de recibos =====
        pnlDetalle = New Panel()
        pnlDetalle.BackColor = clrTarjeta
        pnlDetalle.Location = New Point(20, 322)
        pnlDetalle.Size = New Size(910, 260)
        pnlDetalle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        lblSeccionDetalle = New Label()
        lblSeccionDetalle.Text = "Detalle de recibos"
        lblSeccionDetalle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        lblSeccionDetalle.ForeColor = clrTextoSecundario
        lblSeccionDetalle.AutoSize = True
        lblSeccionDetalle.Location = New Point(16, 12)

        btnAgregarFila = New Button()
        btnAgregarFila.Text = "+"
        btnAgregarFila.Size = New Size(30, 24)
        btnAgregarFila.Location = New Point(910 - 16 - 30, 8)
        btnAgregarFila.FlatStyle = FlatStyle.Flat
        btnAgregarFila.FlatAppearance.BorderColor = clrBorde
        btnAgregarFila.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        dgvDetalle = New DataGridView()
        dgvDetalle.Location = New Point(16, 44)
        dgvDetalle.Size = New Size(878, 200)
        dgvDetalle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        dgvDetalle.BackgroundColor = clrTarjeta
        dgvDetalle.BorderStyle = BorderStyle.None
        dgvDetalle.GridColor = clrBorde
        dgvDetalle.RowHeadersVisible = False
        dgvDetalle.AllowUserToAddRows = True
        dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvDetalle.ColumnHeadersHeight = 32
        dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = clrTarjeta
        dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = clrTextoSecundario
        dgvDetalle.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
        dgvDetalle.EnableHeadersVisualStyles = False
        dgvDetalle.DefaultCellStyle.SelectionBackColor = clrAcentoFondo
        dgvDetalle.DefaultCellStyle.SelectionForeColor = clrTextoPrimario
        dgvDetalle.Columns.Add("NombrePago", "Nombre pago")
        dgvDetalle.Columns.Add("Descripcion", "Descripcion")
        dgvDetalle.Columns.Add("NumeroFactura", "No. factura")
        dgvDetalle.Columns.Add("MontoPagado", "Monto")
        dgvDetalle.Columns("MontoPagado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalle.Columns("NombrePago").FillWeight = 25
        dgvDetalle.Columns("Descripcion").FillWeight = 35
        dgvDetalle.Columns("NumeroFactura").FillWeight = 20
        dgvDetalle.Columns("MontoPagado").FillWeight = 20
        dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        pnlDetalle.Controls.AddRange({lblSeccionDetalle, btnAgregarFila, dgvDetalle})

        ' ===== Tarjetas de totales =====
        pnlTotales = New TableLayoutPanel()
        pnlTotales.Location = New Point(20, 594)
        pnlTotales.Size = New Size(910, 66)
        pnlTotales.ColumnCount = 4
        pnlTotales.RowCount = 1
        pnlTotales.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        For i As Integer = 0 To 3
            pnlTotales.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25))
        Next

        tarjetaSubTotal = CrearTarjetaTotal("Sub total", "C$ 0.00", clrTarjeta, clrTextoPrimario, lblSubTotal, lblValorSubTotal)
        tarjetaDescuento = CrearTarjetaTotal("Descuento", "C$ 0.00", clrTarjeta, clrTextoPrimario, lblDescuento, lblValorDescuento)
        tarjetaTotalRecibido = CrearTarjetaTotal("Total recibido", "C$ 0.00", clrTarjeta, clrTextoPrimario, lblTotalRecibido, lblValorTotalRecibido)
        tarjetaPorAplicar = CrearTarjetaTotal("Por aplicar", "C$ 0.00", clrAcentoFondo, clrAcento, lblPorAplicar, lblValorPorAplicar)

        pnlTotales.Controls.Add(tarjetaSubTotal, 0, 0)
        pnlTotales.Controls.Add(tarjetaDescuento, 1, 0)
        pnlTotales.Controls.Add(tarjetaTotalRecibido, 2, 0)
        pnlTotales.Controls.Add(tarjetaPorAplicar, 3, 0)

        ' ===== Observaciones =====
        lblObservaciones = New Label()
        lblObservaciones.Text = "Observaciones"
        lblObservaciones.ForeColor = clrTextoSecundario
        lblObservaciones.AutoSize = True
        lblObservaciones.Location = New Point(20, 672)

        txtObservaciones = New TextBox()
        txtObservaciones.Location = New Point(20, 692)
        txtObservaciones.Size = New Size(910, 48)
        txtObservaciones.Multiline = True
        txtObservaciones.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom

        ' ===== Ensamblar formulario =====
        Me.Controls.AddRange({pnlHeader, pnlDatosGenerales, pnlCliente, pnlDetalle,
                               pnlTotales, lblObservaciones, txtObservaciones})

        Me.ResumeLayout(False)

    End Sub

    ' ===== Utilidades de creacion de controles =====

    Private Function CrearBotonEstandar(texto As String, ancho As Integer) As Button
        Dim boton As New Button()
        boton.Text = texto
        boton.Size = New Size(ancho, 32)
        boton.FlatStyle = FlatStyle.Flat
        boton.FlatAppearance.BorderColor = clrBorde
        boton.BackColor = clrTarjeta
        boton.ForeColor = clrTextoPrimario
        boton.Font = New Font("Segoe UI", 9.0!)
        Return boton
    End Function

    Private Function CrearEtiquetaSecundaria(texto As String, ubicacion As Point) As Label
        Dim etiqueta As New Label()
        etiqueta.Text = texto
        etiqueta.ForeColor = clrTextoSecundario
        etiqueta.AutoSize = True
        etiqueta.Location = ubicacion
        Return etiqueta
    End Function

    Private Function CrearTarjetaTotal(titulo As String, valor As String, colorFondo As Color,
                                        colorTexto As Color, ByRef lblTituloRef As Label,
                                        ByRef lblValorRef As Label) As Panel
        Dim tarjeta As New Panel()
        tarjeta.BackColor = colorFondo
        tarjeta.Margin = New Padding(0, 0, 8, 0)
        tarjeta.Dock = DockStyle.Fill

        lblTituloRef = New Label()
        lblTituloRef.Text = titulo
        lblTituloRef.ForeColor = If(colorFondo = clrTarjeta, clrTextoSecundario, colorTexto)
        lblTituloRef.Font = New Font("Segoe UI", 8.5!)
        lblTituloRef.AutoSize = True
        lblTituloRef.Location = New Point(12, 8)

        lblValorRef = New Label()
        lblValorRef.Text = valor
        lblValorRef.ForeColor = colorTexto
        lblValorRef.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblValorRef.AutoSize = True
        lblValorRef.Location = New Point(12, 28)

        tarjeta.Controls.AddRange({lblTituloRef, lblValorRef})
        Return tarjeta
    End Function

End Class
