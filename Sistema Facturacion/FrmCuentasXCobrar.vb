Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Linq

'=====================================================================================================
'  CUENTAS X COBRAR
'  El cálculo vive en CxCServicio (CxC_*.vb). Este formulario solo pide, muestra y abre las pantallas
'  de notas, recibos y ajustes. La consulta corre en segundo plano y la pantalla no se congela.
'=====================================================================================================
Public Class FrmCuentasXCobrar

    '---- Miembros públicos que otros formularios ya usaban (se conservan) ----
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NombreEmpresa As String, DireccionEmpresa As String, Ruc As String, RutaLogo As String, MostrarImagen As Boolean = False
    Public DatasetReporte As New DataSet, ds As New DataSet
    Public TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0, TotalMora As Double, TotalMontoNotaDB As Double, TotalMontoNotaCR As Double
    Public dv As New DataView

    '---- Estado interno ----
    Private _servicio As CxCServicio
    Private _resultado As CxCResultado
    Private ReadOnly _nombresClientes As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    Private _consultando As Boolean
    Private _iniciando As Boolean = True
    Private _datosEmpresaCargados As Boolean

    Private Shared ReadOnly ColorVencido As Color = Color.FromArgb(185, 28, 28)
    Private Shared ReadOnly ColorFavor As Color = Color.FromArgb(21, 128, 61)
    Private Shared ReadOnly ColorAdvertencia As Color = Color.FromArgb(180, 83, 9)
    Private Shared ReadOnly ColorTexto As Color = Color.FromArgb(71, 85, 105)

    '=================================================================================================
    ' CARGA
    '=================================================================================================
    Private Sub FrmCuentasXCobrar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Bloqueo(Me, Acceso, "Ctas x Cobrar")
    End Sub

    Private Sub FrmCuentasXCobrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _servicio = CrearServicioCxC()

        Try
            Dim clientes = _servicio.ListarClientes()
            For Each fila As DataRow In clientes.Rows
                _nombresClientes(CStr(fila("Codigo")).Trim()) = If(IsDBNull(fila("Nombres")), "", CStr(fila("Nombres")))
            Next
            If clientes.Rows.Count > 0 Then Me.CboCodigoCliente.DataSource = clientes
        Catch ex As Exception
            MsgBox("No se pudo cargar la lista de clientes: " & ex.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
        End Try

        Me.DTPFechaIni.Value = Now
        Me.DTPFechaFin.Value = Today

        AplicarEstiloGrid()
        Me.TDGridImpuestos.DataSource = CxCResultado.CrearTablaSaldos()
        ConfigurarColumnasGrid()
        LimpiarResumen()
        HabilitarAcciones(False)

        Me.ToolTipCxC.SetToolTip(Me.CmdGrabar, "Calcular saldos (F5)")
        Me.ToolTipCxC.SetToolTip(Me.Button2, "Buscar cliente")
        Me.ToolTipCxC.SetToolTip(Me.Button5, "Registrar nota de débito")
        Me.ToolTipCxC.SetToolTip(Me.Button1, "Registrar nota de crédito a la factura seleccionada")
        Me.ToolTipCxC.SetToolTip(Me.Button3, "Registrar recibo de caja")
        Me.ToolTipCxC.SetToolTip(Me.CmdAjustes, "Ajustes de la fecha de la factura seleccionada")
        Me.ToolTipCxC.SetToolTip(Me.Button6, "Imprimir estado de cuenta")


        AplicarDisenoCompacto()
        _iniciando = False
    End Sub

    Private Sub FrmCuentasXCobrar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            e.Handled = True
            CmdGrabar.PerformClick()
        End If
    End Sub

    '=================================================================================================
    ' CONSULTA
    '=================================================================================================
    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Consultar()
    End Sub

    Private ReadOnly Property MonedaSeleccionada As MonedaCxC
        Get
            Return If(Me.OptDolares.Checked, MonedaCxC.Dolares, MonedaCxC.Cordobas)
        End Get
    End Property

    Private ReadOnly Property MonedaTexto As String
        Get
            Return DineroCxC.MonedaTexto(MonedaSeleccionada)
        End Get
    End Property

    ''' <summary>
    ''' Calcula en segundo plano (BackgroundWorker, compatible con .NET Framework 4) y muestra el resultado.
    ''' "despues" se ejecuta al terminar, solo si el cálculo fue exitoso.
    ''' </summary>
    Private Sub Consultar(Optional despues As Action = Nothing)
        Dim codigo = Me.CboCodigoCliente.Text.Trim()
        If codigo = "" OrElse _consultando Then Exit Sub

        _consultando = True
        Dim filtro = CxCFiltro.PorCliente(codigo, Me.DTPFechaFin.Value.Date, MonedaSeleccionada)
        Dim servicio = _servicio
        MostrarProgreso(True, "Calculando saldos del cliente " & codigo & "...")

        Dim trabajador As New BackgroundWorker()
        AddHandler trabajador.DoWork,
            Sub(s As Object, ev As DoWorkEventArgs)
                ev.Result = servicio.CalcularSaldos(filtro)
            End Sub
        AddHandler trabajador.RunWorkerCompleted,
            Sub(s As Object, ev As RunWorkerCompletedEventArgs)
                Dim exito = False
                Try
                    If ev.Error IsNot Nothing Then
                        MostrarEstado("No se pudo calcular: " & ev.Error.Message, ColorVencido)
                        MsgBox("No se pudo calcular el estado de cuenta." & vbCrLf & ev.Error.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
                    Else
                        MostrarResultado(DirectCast(ev.Result, CxCResultado))
                        exito = True
                    End If
                Finally
                    MostrarProgreso(False, Nothing)
                    _consultando = False
                    trabajador.Dispose()
                End Try
                If exito AndAlso despues IsNot Nothing Then despues()
            End Sub
        trabajador.RunWorkerAsync()
    End Sub

    Private Sub MostrarResultado(resultado As CxCResultado)
        _resultado = resultado
        AsignarTotales(resultado)

        DatasetReporte = resultado.ToDataSet()
        RefrescarVista()

        Me.TxtCargos.Text = DineroCxC.Formatear(resultado.TotalCargos)
        Me.TxtAbonos.Text = DineroCxC.Formatear(resultado.TotalAbonos)
        Me.TxtNB.Text = DineroCxC.Formatear(resultado.TotalNotasNeto)
        Me.TxtMora.Text = DineroCxC.Formatear(resultado.TotalMora)
        Me.TxtSaldoFinal.Text = DineroCxC.Formatear(resultado.SaldoFinal)
        Me.TxtMora.ForeColor = If(resultado.TotalMora > 0D, ColorAdvertencia, Color.FromArgb(31, 41, 55))

        HabilitarAcciones(True)

        Dim simbolo = If(MonedaSeleccionada = MonedaCxC.Dolares, "US$", "C$")
        Dim resumen = String.Format("{0} documento(s) · {1} · corte al {2:dd/MM/yyyy}",
                                    resultado.Lineas.Count, simbolo, resultado.Filtro.FechaFin)
        If resultado.Advertencias.Count > 0 Then
            MostrarEstado(String.Format("⚠ {0} advertencia(s), clic aquí para verlas · {1}", resultado.Advertencias.Count, resumen), ColorAdvertencia)
            Me.LblEstado.Cursor = Cursors.Hand
        Else
            MostrarEstado(resumen, ColorTexto)
            Me.LblEstado.Cursor = Cursors.Default
        End If
    End Sub

    ''' <summary>Totales públicos que antes llenaba FillDataSetCtaxCobrar (se conservan por compatibilidad).</summary>
    Public Sub AsignarTotales(resultado As CxCResultado)
        TotalCargos = CDbl(resultado.TotalCargos)
        TotalAbonos = CDbl(resultado.TotalAbonos)
        TotalMora = CDbl(resultado.TotalMora)
        TotalMontoNotaDB = CDbl(resultado.TotalNotasDebito)
        TotalMontoNotaCR = CDbl(resultado.TotalNotasCredito)
        TotalFactura = CDbl(resultado.SaldoFinal)
    End Sub

    ''' <summary>Vuelve a armar la vista del grid (sin ir a la base de datos).</summary>
    Private Sub RefrescarVista()
        If _resultado Is Nothing Then Exit Sub
        dv = _resultado.ToDataView(Me.ChkRegistrosCero.Checked, ordenarPorCliente:=True)
        Me.TDGridImpuestos.DataSource = dv
        ConfigurarColumnasGrid()
    End Sub

    Private Sub ChkRegistrosCero_CheckedChanged(sender As Object, e As EventArgs) Handles ChkRegistrosCero.CheckedChanged
        If Not _iniciando Then RefrescarVista()
    End Sub

    Private Sub OptMoneda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptCordobas.CheckedChanged, OptDolares.CheckedChanged
        ' Al cambiar de moneda se disparan los dos eventos; solo se recalcula una vez
        If _iniciando OrElse Not DirectCast(sender, RadioButton).Checked Then Exit Sub
        Consultar()
    End Sub

    Private Sub CboCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoCliente.TextChanged
        ' Se busca en la lista ya cargada: ya no hay una consulta a la base por cada tecla
        Dim nombre As String = Nothing
        If _nombresClientes.TryGetValue(Me.CboCodigoCliente.Text.Trim(), nombre) Then
            Me.LblNombres.Text = nombre
        Else
            Me.LblNombres.Text = ""
        End If

        If _resultado IsNot Nothing AndAlso Not _resultado.Filtro.ClienteDesde.Equals(Me.CboCodigoCliente.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
            HabilitarAcciones(False)
            MostrarEstado("Cliente cambiado: presione Consultar (F5).", ColorTexto)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoCliente.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    '=================================================================================================
    ' PRESENTACIÓN
    '=================================================================================================
    Private Sub MostrarProgreso(activo As Boolean, mensaje As String)
        Me.ProgressBar.Visible = activo
        Me.LblLeyendaVencido.Visible = Not activo
        Me.LblLeyendaFavor.Visible = Not activo
        Me.CmdGrabar.Enabled = Not activo
        Me.Cursor = If(activo, Cursors.AppStarting, Cursors.Default)
        If activo Then
            HabilitarAcciones(False)
            MostrarEstado(mensaje, ColorTexto)
        End If
    End Sub

    Private Sub MostrarEstado(texto As String, color As Color)
        Me.LblEstado.Text = texto
        Me.LblEstado.ForeColor = color
    End Sub

    Private Sub HabilitarAcciones(habilitar As Boolean)
        Me.Button1.Enabled = habilitar
        Me.Button3.Enabled = habilitar
        Me.Button5.Enabled = habilitar
        Me.CmdAjustes.Enabled = habilitar
        ' Se vuelven a aplicar los permisos del usuario sobre los botones
        If habilitar Then Bloqueo(Me, Acceso, "Ctas x Cobrar")
    End Sub

    Private Sub LimpiarResumen()
        For Each txt As TextBox In New TextBox() {TxtCargos, TxtAbonos, TxtNB, TxtMora, TxtSaldoFinal}
            txt.Text = "0.00"
        Next
    End Sub

    Private Sub LblEstado_Click(sender As Object, e As EventArgs) Handles LblEstado.Click
        If _resultado Is Nothing OrElse _resultado.Advertencias.Count = 0 Then Exit Sub
        MsgBox(String.Join(vbCrLf & vbCrLf, _resultado.Advertencias), MsgBoxStyle.Exclamation, "Zeus Facturacion - Advertencias del cálculo")
    End Sub

    Private Sub AplicarEstiloGrid()
        Try
            With Me.TDGridImpuestos
                .Caption = ""
                .Font = New Font("Segoe UI", 9.0!)
                .RowHeight = 24
                .FetchRowStyles = True
                .Styles("Normal").Font = New Font("Segoe UI", 9.0!)
                .Styles("Heading").BackColor = Color.FromArgb(232, 237, 243)
                .Styles("Heading").ForeColor = Color.FromArgb(45, 55, 72)
                .Styles("Heading").Font = New Font("Segoe UI Semibold", 9.0!)
                .Styles("EvenRow").BackColor = Color.FromArgb(248, 250, 252)
                .Styles("OddRow").BackColor = Color.White
                .Styles("FilterBar").BackColor = Color.FromArgb(255, 251, 235)
                .Styles("HighlightRow").BackColor = Color.FromArgb(219, 234, 254)
                .Styles("HighlightRow").ForeColor = Color.FromArgb(30, 58, 138)
                .Styles("Selected").BackColor = Color.FromArgb(219, 234, 254)
                .Styles("Selected").ForeColor = Color.FromArgb(30, 58, 138)
            End With
        Catch
            ' Si la versión de ComponentOne no tiene alguno de estos estilos, se deja el aspecto por defecto
        End Try
    End Sub

    Private Sub ConfigurarColumnasGrid()
        Try
            ConfigurarColumna("Fecha_Factura", "Fecha", 80, "dd/MM/yyyy", False)
            ConfigurarColumna("Numero_Factura", "Factura No", 80, Nothing, False)
            ConfigurarColumna("Numero_Recibo", "Recibo No", 95, Nothing, False)
            ConfigurarColumna("NotaDebito", "NB / NC No", 105, Nothing, False)
            ConfigurarColumna("MontoNota", "Monto NB/NC", 90, DineroCxC.FormatoMonto, True)
            ConfigurarColumna("Monto", "Cargo", 95, DineroCxC.FormatoMonto, True)
            ConfigurarColumna("FechaVence", "Vence", 80, "dd/MM/yyyy", False)
            ConfigurarColumna("Abono", "Abono", 95, DineroCxC.FormatoMonto, True)
            ConfigurarColumna("Saldo", "Saldo", 95, DineroCxC.FormatoMonto, True)
            ConfigurarColumna("Moratorio", "Moratorio", 85, DineroCxC.FormatoMonto, True)
            ConfigurarColumna("Dias", "Días", 50, Nothing, True)
            ConfigurarColumna("Total", "Total", 100, DineroCxC.FormatoMonto, True)
            Me.TDGridImpuestos.Splits(0).DisplayColumns("Cod_Cliente").Visible = False
            Me.TDGridImpuestos.Splits(0).DisplayColumns("Nombre_Cliente").Visible = False
        Catch
        End Try
    End Sub

    Private Sub ConfigurarColumna(campo As String, titulo As String, ancho As Integer, formato As String, alinearDerecha As Boolean)
        Dim col = Me.TDGridImpuestos.Columns(campo)
        col.Caption = titulo
        If formato IsNot Nothing Then col.NumberFormat = formato
        Dim display = Me.TDGridImpuestos.Splits(0).DisplayColumns(campo)
        display.Width = ancho
        If alinearDerecha Then display.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
    End Sub

    ''' <summary>Rojo: factura vencida con saldo. Verde: saldo a favor del cliente.</summary>
    Private Sub TDGridImpuestos_FetchRowStyle(sender As Object, e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles TDGridImpuestos.FetchRowStyle
        Try
            Dim saldo = Me.TDGridImpuestos.Columns("Saldo").CellValue(e.Row)
            Dim dias = Me.TDGridImpuestos.Columns("Dias").CellValue(e.Row)
            If saldo Is Nothing OrElse IsDBNull(saldo) Then Exit Sub
            If CDec(saldo) < 0D Then
                e.CellStyle.ForeColor = ColorFavor
            ElseIf CDec(saldo) > 0D AndAlso dias IsNot Nothing AndAlso Not IsDBNull(dias) AndAlso CInt(dias) > 0 Then
                e.CellStyle.ForeColor = ColorVencido
            End If
        Catch
        End Try
    End Sub

    '=================================================================================================
    ' FILA SELECCIONADA (se leen los valores reales, no el texto formateado del grid)
    '=================================================================================================
    Private Function HayFila() As Boolean
        Return dv IsNot Nothing AndAlso dv.Count > 0
    End Function

    Private Function ValorFila(campo As String) As Object
        If Not HayFila() Then Return Nothing
        Try
            Dim valor = Me.TDGridImpuestos.Columns(campo).Value
            If valor Is Nothing OrElse IsDBNull(valor) Then Return Nothing
            Return valor
        Catch
            Return Nothing
        End Try
    End Function

    Private Function FilaTexto(campo As String) As String
        Dim v = ValorFila(campo)
        Return If(v Is Nothing, "", CStr(v).Trim())
    End Function

    Private Function FilaDecimal(campo As String) As Decimal
        Dim v = ValorFila(campo)
        Return If(v Is Nothing, 0D, CDec(v))
    End Function

    Private Function FilaFecha(campo As String, valorSiVacio As Date) As Date
        Dim v = ValorFila(campo)
        Return If(v Is Nothing, valorSiVacio, CDate(v).Date)
    End Function

    Private Function NombreCorto() As String
        Return If(Len(Me.LblNombres.Text) > 29, Mid(Me.LblNombres.Text, 1, 29), Me.LblNombres.Text)
    End Function

    '=================================================================================================
    ' ACCIONES
    '=================================================================================================
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If _resultado Is Nothing Then
            Consultar(AddressOf ImprimirEstadoCuenta)     ' imprime cuando termine el cálculo
        Else
            ImprimirEstadoCuenta()
        End If
    End Sub

    Private Sub ImprimirEstadoCuenta()
        CargarDatosEmpresa()
        Dim ArepEstadoCuentas As New ArepEstadoCuentas

        If RutaLogo <> "" AndAlso Dir(RutaLogo) <> "" Then
            ArepEstadoCuentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
        End If

        ArepEstadoCuentas.LblTitulo.Text = NombreEmpresa
        ArepEstadoCuentas.LblDireccion.Text = DireccionEmpresa
        ArepEstadoCuentas.LblRuc.Text = Ruc
        ArepEstadoCuentas.LblCodCliente.Text = Me.CboCodigoCliente.Text
        ArepEstadoCuentas.LblNombreCliente.Text = Me.LblNombres.Text
        ArepEstadoCuentas.LblMoneda.Text = MonedaTexto
        ArepEstadoCuentas.LblFecha.Text = Format(Me.DTPFechaFin.Value, "dd/MM/yyyy")
        ArepEstadoCuentas.LblCargo.Text = Me.TxtCargos.Text
        ArepEstadoCuentas.LblAbono.Text = Me.TxtAbonos.Text
        ArepEstadoCuentas.LblMora.Text = Me.TxtMora.Text
        ArepEstadoCuentas.LblSaldoFinal.Text = Me.TxtSaldoFinal.Text

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepEstadoCuentas.Document
        ArepEstadoCuentas.DataSource = dv
        ArepEstadoCuentas.Run(False)
        ViewerForm.Show()
    End Sub

    Private Sub CargarDatosEmpresa()
        If _datosEmpresaCargados Then Exit Sub
        Dim tabla As New DataTable
        Using da As New SqlClient.SqlDataAdapter("SELECT TOP (1) * FROM DatosEmpresa", Conexion)
            da.Fill(tabla)
        End Using
        If tabla.Rows.Count > 0 Then
            Dim fila = tabla.Rows(0)
            NombreEmpresa = If(IsDBNull(fila("Nombre_Empresa")), "", CStr(fila("Nombre_Empresa")))
            DireccionEmpresa = If(IsDBNull(fila("Direccion_Empresa")), "", CStr(fila("Direccion_Empresa")))
            Ruc = If(IsDBNull(fila("Numero_Ruc")), "", "Numero RUC " & CStr(fila("Numero_Ruc")))
            RutaLogo = If(IsDBNull(fila("Ruta_Logo")), "", CStr(fila("Ruta_Logo")))
        End If
        _datosEmpresaCargados = True
    End Sub

    ' Nota de débito
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        With My.Forms.FrmRegistroDebito
            .LblNombre.Text = NombreCorto()
            .LblMoneda.Text = MonedaTexto
            .TipoNota = "Debito Clientes"
            .TxtNumeroEnsamble.Text = "-----0-----"
            .LblFactura.Text = FilaTexto("Numero_Factura")
            .DTPFecha.Value = FilaFecha("Fecha_Factura", Today)
            .TxtCodCliente.Text = Me.CboCodigoCliente.Text
            .Label1.Text = "NOTAS DE DEBITO"
            .ShowDialog()
        End With
        Consultar()
    End Sub



    ' Nota de crédito
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With My.Forms.FrmRegistroDebito
            .LblNombre.Text = NombreCorto()
            .LblMoneda.Text = MonedaTexto
            .TipoNota = "Credito Clientes"
            .TxtNumeroEnsamble.Text = "-----0-----"
            .LblFactura.Text = FilaTexto("Numero_Factura")
            .NumeroFactura = FilaTexto("Numero_Factura")
            .DTPFecha.Value = FilaFecha("Fecha_Factura", Today)
            .TxtCodCliente.Text = Me.CboCodigoCliente.Text
            .Label1.Text = "NOTAS DE CREDITO"
            .ShowDialog()
        End With
        Consultar()
    End Sub

    ' Recibos
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Forms.FrmRecibos.TxtCodigoClientes.Text = Me.CboCodigoCliente.Text
        My.Forms.FrmRecibos.DTPFecha.Value = FilaFecha("Fecha_Factura", Today)
        My.Forms.FrmRecibos.ShowDialog()
        Consultar()
    End Sub

    Private Sub PnlGrid_Paint(sender As Object, e As PaintEventArgs) Handles PnlGrid.Paint

    End Sub

    ' Ajustes de la fecha de la factura seleccionada
    Private Sub CmdAjustes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAjustes.Click
        Dim fecha = FilaFecha("Fecha_Factura", Today)

        If Me.OptCordobas.Checked Then
            FrmAjustes.OptCordobas.Checked = True
        Else
            FrmAjustes.OptDolares.Checked = True
        End If

        FrmAjustes.CboCodigoCliente.Text = Me.CboCodigoCliente.Text
        FrmAjustes.TxtNombre.Text = Me.LblNombres.Text
        FrmAjustes.DTPFechaIni.Value = fecha
        FrmAjustes.DTPFechaFin.Value = fecha
        FrmAjustes.ShowDialog()
        Consultar()
    End Sub

    ' Ajustes total (botón oculto, igual que antes)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Me.OptCordobas.Checked Then
            FrmAjustarTodos.OptCordobas.Checked = True
        Else
            FrmAjustarTodos.OptDolares.Checked = True
        End If
        FrmAjustarTodos.DTPFechaFin.Value = Today
        FrmAjustarTodos.ShowDialog()
    End Sub

    '=================================================================================================
    ' MENÚ CONTEXTUAL DEL GRID
    '=================================================================================================
    Private Sub TDGridImpuestos_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TDGridImpuestos.MouseDown
        If e.Button <> MouseButtons.Right Then Exit Sub

        ' Selecciona la celda donde se hizo clic derecho
        Try
            Dim fila = Me.TDGridImpuestos.RowContaining(e.Y)
            Dim columna = Me.TDGridImpuestos.ColContaining(e.X)
            If fila >= 0 Then Me.TDGridImpuestos.Row = fila
            If columna >= 0 Then Me.TDGridImpuestos.Col = columna
        Catch
        End Try

        Dim campo = ""
        Try
            campo = Me.TDGridImpuestos.Columns(Me.TDGridImpuestos.Col).DataField
        Catch
        End Try

        Dim menuRecibo = (campo = "Numero_Recibo")
        Dim menuNota = (campo = "NotaDebito")

        Me.AsignarFacturaAlReciboToolStripMenuItem.Visible = menuRecibo AndAlso FilaTexto("Numero_Recibo") <> ""
        Me.AnularNotasDeDebitoToolStripMenuItem.Visible = menuRecibo
        Me.AnularNotasDeCreditoToolStripMenuItem.Visible = menuNota
        Me.AjustarDiferencialCambiarioToolStripMenuItem.Visible = menuNota
        Me.AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Visible = menuNota
    End Sub

    Private Sub ContextMenuStripGrid_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripGrid.Opening
        Dim algunoVisible = False
        For Each item As ToolStripItem In Me.ContextMenuStripGrid.Items
            If item.Available Then algunoVisible = True
        Next
        e.Cancel = Not algunoVisible OrElse Not HayFila()
    End Sub

    ' "Crear Recibo"
    Private Sub AnularNotasDeDebitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularNotasDeDebitoToolStripMenuItem.Click
        Dim total = FilaDecimal("Total")
        My.Forms.FrmAgregarRecibo.LblNombreCliente.Text = Me.LblNombres.Text
        My.Forms.FrmAgregarRecibo.LblNumeroFactura.Text = FilaTexto("Numero_Factura")
        My.Forms.FrmAgregarRecibo.TxtMontoRecibo.Text = DineroCxC.Formatear(total)
        My.Forms.FrmAgregarRecibo.LblMontoFactura.Text = DineroCxC.Formatear(total)
        My.Forms.FrmAgregarRecibo.DTPFecha.Value = Now
        My.Forms.FrmAgregarRecibo.MonedaRecibo = MonedaTexto
        My.Forms.FrmAgregarRecibo.ShowDialog()
        Consultar()
    End Sub

    Private Sub AsignarFacturaAlReciboToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarFacturaAlReciboToolStripMenuItem.Click
        ' Sin implementación (igual que en la versión anterior)
    End Sub

    Private Sub AjustarDiferencialCambiarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjustarDiferencialCambiarioToolStripMenuItem.Click
        ' Se toma el valor exacto de la fila (antes se leía el texto formateado del grid)
        Dim monto = FilaDecimal("Total")
        If monto = 0D Then Exit Sub

        Dim esCredito = monto > 0D
        Dim simbolo = If(MonedaSeleccionada = MonedaCxC.Cordobas, "C$", "$")
        Dim tipoDiferencial = If(esCredito, "Credito Clientes Dif ", "Debito Clientes Dif ") & simbolo

        Dim codigoNota As String
        Try
            codigoNota = _servicio.Repositorio.BuscarNotaPorTipo(tipoDiferencial)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End Try
        If codigoNota Is Nothing Then
            MsgBox("No Existe Nota de Diferencial " & simbolo, MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        Quien = "CtasXcob"
        With My.Forms.FrmRegistroDebito
            .LblNombre.Text = NombreCorto()
            .LblMoneda.Text = MonedaTexto
            .TxtNumeroEnsamble.Text = "-----0-----"
            .LblFactura.Text = FilaTexto("Numero_Factura")
            .DTPFecha.Value = FilaFecha("Fecha_Factura", Today)
            .TxtCodCliente.Text = Me.CboCodigoCliente.Text
            .Codigo = codigoNota
            .Monto = CDbl(Math.Abs(monto))
            .TxtObservaciones.Text = "Proceso AJUSTES AUTOMATICOS ZEUS"
            If esCredito Then
                .TipoNota = "Credito Clientes"
                .NumeroFactura = FilaTexto("Numero_Factura")
                .Label1.Text = "NOTAS DE CREDITO"
            Else
                .TipoNota = "Debito Clientes"
                .Label1.Text = "NOTAS DE DEBITO"
            End If
            .ShowDialog()
        End With
        Consultar()
    End Sub

    Private Sub AsignarFacturaALaNotaDeCreditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarFacturaALaNotaDeCreditoToolStripMenuItem.Click
        Dim saldo = FilaDecimal("Saldo")
        If saldo <= 0D Then
            MsgBox("La Factura no tiene Saldo Pendiente", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        End If

        FrmAgregarNotaCredito.ds.Reset()
        FrmAgregarNotaCredito.ds = DatasetReporte.Copy
        FrmAgregarNotaCredito.Numero_Factura = FilaTexto("Numero_Factura")
        FrmAgregarNotaCredito.Fecha_Factura = FilaFecha("Fecha_Factura", Today)
        FrmAgregarNotaCredito.MontoFactura = CDbl(saldo)
        FrmAgregarNotaCredito.TxtMontoRecibo.Text = DineroCxC.Formatear(saldo)
        FrmAgregarNotaCredito.MonedaEstado = MonedaTexto
        FrmAgregarNotaCredito.ShowDialog()

        Consultar()
    End Sub


    '-------------------------------------------------------------------------------------------------
    ' Ventana hija MDI: el formulario principal tapa el borde inferior (barra de estado).
    ' Se mide cuánto queda tapado y se deja ese espacio libre abajo, para que el grid no se corte.
    '-------------------------------------------------------------------------------------------------
    Private Sub FrmCuentasXCobrar_AjustarAreaVisible(sender As Object, e As EventArgs) Handles Me.Shown, Me.Resize, Me.Activated
        Dim tapado = 0
        Try
            Dim principal = Me.MdiParent
            Dim areaHijas = Me.Parent      ' MdiClient
            If principal IsNot Nothing AndAlso areaHijas IsNot Nothing AndAlso Me.WindowState = FormWindowState.Maximized Then
                ' Rectángulo del área de ventanas hijas, en coordenadas del formulario principal
                Dim area = principal.RectangleToClient(areaHijas.RectangleToScreen(areaHijas.ClientRectangle))
                Dim limiteVisible = Math.Min(area.Bottom, principal.ClientSize.Height)

                ' Cualquier control del principal que se monte sobre la parte de abajo del área
                For Each c As Control In principal.Controls
                    If c Is areaHijas OrElse Not c.Visible Then Continue For
                    Dim cruce = Rectangle.Intersect(c.Bounds, area)
                    If cruce.Width > 0 AndAlso cruce.Height > 0 AndAlso cruce.Top > area.Top + area.Height \ 2 Then
                        limiteVisible = Math.Min(limiteVisible, cruce.Top)
                    End If
                Next
                tapado = Math.Max(0, area.Bottom - limiteVisible)
            End If
        Catch
            tapado = 0
        End Try

        If Me.Padding.Bottom <> tapado Then Me.Padding = New Padding(0, 0, 0, tapado)
    End Sub


    '-------------------------------------------------------------------------------------------------
    ' Diseño compacto: reduce encabezado, filtros, botones, tarjetas y mensajes (~80 px más para el grid)
    ' y ajusta la ventana al área disponible dentro del formulario principal.
    ' Se llama una vez al final del Load. No cambia el diseñador (conserva controles agregados, ej. RUC).
    '-------------------------------------------------------------------------------------------------
    Private Sub AplicarDisenoCompacto()
        Me.SuspendLayout()

        ' Encabezado: 60 -> 42, título y subtítulo en una sola línea
        Me.PnlHeader.Height = 42
        Me.LblTitulo.Font = New Font("Segoe UI Semibold", 13.0!)
        Me.LblTitulo.Location = New Point(16, 8)
        Me.LblSubtitulo.Location = New Point(Me.LblTitulo.Right + 14, 15)
        For Each imagen As PictureBox In Me.PnlHeader.Controls.OfType(Of PictureBox)()
            imagen.Size = New Size(120, 34)
            imagen.Location = New Point(Me.PnlHeader.Width - imagen.Width - 10, 4)
        Next

        ' Filtros: 96 -> 72 (todos los controles de la fila de arriba suben 5 px, los de abajo 13 px)
        Me.PnlFiltros.Height = 72
        For Each c As Control In Me.PnlFiltros.Controls
            If c Is Me.CmdGrabar OrElse c Is Me.PnlLineaFiltros Then Continue For
            c.Top -= If(c.Top < 40, 5, 13)
        Next
        Me.CmdGrabar.Size = New Size(140, 40)
        Me.CmdGrabar.Top = (Me.PnlFiltros.Height - Me.CmdGrabar.Height) \ 2

        ' Barra de botones: 52 -> 42
        Me.PnlAcciones.Height = 42
        Dim topBotones = Me.PnlHeader.Height + Me.PnlFiltros.Height + 5
        For Each b As Button In New Button() {Button5, Button1, Button3, CmdAjustes, Button4, Button6, Button8}
            b.Height = 32
            b.Top = topBotones
        Next

        ' Tarjetas de totales: 88 -> 64
        Me.TlpResumen.Height = 64
        Me.TlpResumen.Padding = New Padding(12, 0, 12, 6)
        For Each tarjeta As Panel In New Panel() {PnlCargos, PnlAbonos, PnlNotas, PnlMora, PnlSaldo}
            For Each c As Control In tarjeta.Controls
                If TypeOf c Is Label Then
                    c.Top = 6
                Else
                    c.Font = New Font("Segoe UI Semibold", 14.25!)
                    c.Top = 24
                End If
            Next
        Next

        ' Mensajes: 30 -> 24
        ' Mensajes: alto según la fuente (funciona con escala de Windows 100%, 125%, 150%)
        Me.LblEstado.AutoEllipsis = False
        Me.LblEstado.AutoSize = False
        Me.LblEstado.Dock = DockStyle.Fill
        Me.LblEstado.Visible = True
        Me.LblEstado.BringToFront()          ' el control con Dock=Fill debe acomodarse de último
        Me.PnlEstado.Padding = New Padding(16, 0, 16, 0)
        Me.PnlEstado.Height = Me.LblEstado.Font.Height + 10

        ' Ventana: que quepa en el área del formulario principal cuando no está maximizada
        Me.MinimumSize = New Size(900, 460)
        If Me.MdiParent IsNot Nothing AndAlso Me.Parent IsNot Nothing Then
            Dim area = Me.Parent.ClientSize
            Me.Size = New Size(Math.Min(Me.Width, area.Width), Math.Min(Me.Height, area.Height))
            Me.Location = New Point(0, 0)
        End If

        Me.ResumeLayout(True)
    End Sub
End Class
