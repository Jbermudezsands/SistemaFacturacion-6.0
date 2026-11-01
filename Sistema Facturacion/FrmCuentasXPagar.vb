Option Strict Off
Option Explicit On
Option Infer On

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

'=====================================================================================================
'  CUENTAS X PAGAR
'  El cálculo vive en CxPServicio (CxP_*.vb). Este formulario solo pide, muestra y abre las pantallas
'  de notas y pagos. La consulta corre en segundo plano y la pantalla no se congela.
'=====================================================================================================
Public Class FrmCuentasXPagar

    '---- Miembros públicos que se conservan ----
    Public NombreEmpresa As String, DireccionEmpresa As String, Ruc As String, RutaLogo As String, MostrarImagen As Boolean = False
    Public DatasetReporte As New DataSet
    Public TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0, TotalMora As Double

    '---- Estado interno ----
    Private _servicio As CxPServicio
    Private _resultado As CxPResultado
    Private _vista As DataView
    Private ReadOnly _nombresProveedores As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    Private _consultando As Boolean
    Private _iniciando As Boolean = True
    Private _empresa As CxPEmpresa
    Private _accionesHabilitadas As Boolean

    '=================================================================================================
    ' CARGA
    '=================================================================================================
    Private Sub FrmCuentasXPagar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Seguridad.Bloqueo(Me, Acceso, "Ctas x Pagar")
        ' Bloqueo habilita lo que el perfil permite; mientras no haya una consulta, las acciones siguen apagadas
        If Not _accionesHabilitadas Then HabilitarAcciones(False)
    End Sub

    Private Sub FrmCuentasXPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _servicio = New CxPServicio(Conexion)

        Try
            Dim proveedores = _servicio.ListarProveedores()
            For Each fila As DataRow In proveedores.Rows
                _nombresProveedores(CStr(fila("Cod_Proveedor")).Trim()) = If(IsDBNull(fila("Nombres")), "", CStr(fila("Nombres")))
            Next
            If proveedores.Rows.Count > 0 Then Me.CboCodigoProveedor.DataSource = proveedores
        Catch ex As Exception
            MsgBox("No se pudo cargar la lista de proveedores: " & ex.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
        End Try

        Me.DTPFechaFin.Value = Today

        CxPEstilos.AplicarEstiloGrid(Me.TDGridImpuestos)
        Me.TDGridImpuestos.DataSource = CxPResultado.CrearTablaSaldos()
        CxPEstilos.ConfigurarColumnas(Me.TDGridImpuestos)
        LimpiarResumen()
        HabilitarAcciones(False)

        Me.ToolTipCxP.SetToolTip(Me.CmdGrabar, "Calcular saldos (F5)")
        Me.ToolTipCxP.SetToolTip(Me.Button2, "Buscar proveedor")
        Me.ToolTipCxP.SetToolTip(Me.Button5, "Registrar nota de débito")
        Me.ToolTipCxP.SetToolTip(Me.Button1, "Registrar nota de crédito a la compra seleccionada")
        Me.ToolTipCxP.SetToolTip(Me.Button3, "Registrar pago a proveedor")
        Me.ToolTipCxP.SetToolTip(Me.Button6, "Imprimir estado de cuenta")

        Me.PnlEstado.Height = Me.LblEstado.Font.Height + 10
        _iniciando = False
    End Sub

    Private Sub FrmCuentasXPagar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            e.Handled = True
            CmdGrabar.PerformClick()
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------
    ' Ventana hija MDI: el formulario principal tapa el borde inferior; se deja ese espacio libre abajo.
    '-------------------------------------------------------------------------------------------------
    Private Sub FrmCuentasXPagar_AjustarAreaVisible(sender As Object, e As EventArgs) Handles Me.Shown, Me.Resize, Me.Activated
        Dim tapado = CxPAreaMdi.EspacioTapado(Me)
        If Me.Padding.Bottom <> tapado Then Me.Padding = New Padding(0, 0, 0, tapado)
    End Sub

    Private Sub FrmCuentasXPagar_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CxPAreaMdi.AjustarAlArea(Me)
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
        Dim codigo = Me.CboCodigoProveedor.Text.Trim()
        If codigo = "" OrElse _consultando Then Exit Sub

        _consultando = True
        Dim filtro = CxPFiltro.PorProveedor(codigo, Me.DTPFechaFin.Value.Date, MonedaSeleccionada)
        Dim servicio = _servicio
        MostrarProgreso(True, "Calculando saldos del proveedor " & codigo & "...")

        Dim trabajador As New BackgroundWorker()
        AddHandler trabajador.DoWork,
            Sub(s As Object, ev As DoWorkEventArgs)
                ev.Result = servicio.CalcularSaldos(filtro, actualizarMontoCredito:=True)
            End Sub
        AddHandler trabajador.RunWorkerCompleted,
            Sub(s As Object, ev As RunWorkerCompletedEventArgs)
                Dim exito = False
                Try
                    If ev.Error IsNot Nothing Then
                        MostrarEstado("No se pudo calcular: " & ev.Error.Message, CxPEstilos.ColorVencido)
                        MsgBox("No se pudo calcular el estado de cuenta." & vbCrLf & ev.Error.Message, MsgBoxStyle.Critical, "Zeus Facturacion")
                    Else
                        MostrarResultado(DirectCast(ev.Result, CxPResultado))
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

    Private Sub MostrarResultado(resultado As CxPResultado)
        _resultado = resultado
        AsignarTotales(resultado)

        DatasetReporte = resultado.ToDataSet()
        RefrescarVista()

        Me.TxtCargos.Text = DineroCxC.Formatear(resultado.TotalCargos)
        Me.TxtAbonos.Text = DineroCxC.Formatear(resultado.TotalAbonos)
        Me.TxtNB.Text = DineroCxC.Formatear(resultado.TotalNotasNeto)
        Me.TxtMora.Text = DineroCxC.Formatear(resultado.TotalMora)
        Me.TxtSaldoFinal.Text = DineroCxC.Formatear(resultado.SaldoFinal)
        Me.TxtMora.ForeColor = If(resultado.TotalMora > 0D, CxPEstilos.ColorAdvertencia, CxPEstilos.ColorValor)

        HabilitarAcciones(True)

        Dim simbolo = If(MonedaSeleccionada = MonedaCxC.Dolares, "US$", "C$")
        Dim resumen = String.Format("{0} documento(s) · {1} · corte al {2:dd/MM/yyyy}",
                                    resultado.Lineas.Count, simbolo, resultado.Filtro.FechaFin)
        If resultado.Advertencias.Count > 0 Then
            MostrarEstado(String.Format("⚠ {0} advertencia(s), clic aquí para verlas · {1}", resultado.Advertencias.Count, resumen), CxPEstilos.ColorAdvertencia)
            Me.LblEstado.Cursor = Cursors.Hand
        Else
            MostrarEstado(resumen, CxPEstilos.ColorTexto)
            Me.LblEstado.Cursor = Cursors.Default
        End If
    End Sub

    Public Sub AsignarTotales(resultado As CxPResultado)
        TotalCargos = CDbl(resultado.TotalCargos)
        TotalAbonos = CDbl(resultado.TotalAbonos)
        TotalMora = CDbl(resultado.TotalMora)
        TotalFactura = CDbl(resultado.SaldoFinal)
    End Sub

    ''' <summary>Vuelve a armar la vista del grid (sin ir a la base de datos).</summary>
    Private Sub RefrescarVista()
        If _resultado Is Nothing Then Exit Sub
        _vista = _resultado.ToDataView(Me.ChkRegistrosCero.Checked)
        Me.TDGridImpuestos.DataSource = _vista
        CxPEstilos.ConfigurarColumnas(Me.TDGridImpuestos)
    End Sub

    Private Sub ChkRegistrosCero_CheckedChanged(sender As Object, e As EventArgs) Handles ChkRegistrosCero.CheckedChanged
        If Not _iniciando Then RefrescarVista()
    End Sub

    Private Sub OptMoneda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptCordobas.CheckedChanged, OptDolares.CheckedChanged
        ' Al cambiar de moneda se disparan los dos eventos; solo se recalcula una vez
        If _iniciando OrElse Not DirectCast(sender, RadioButton).Checked Then Exit Sub
        Consultar()
    End Sub

    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        ' Se busca en la lista ya cargada: no hay una consulta a la base por cada tecla
        Dim nombre As String = Nothing
        If _nombresProveedores.TryGetValue(Me.CboCodigoProveedor.Text.Trim(), nombre) Then
            Me.LblNombres.Text = nombre
        Else
            Me.LblNombres.Text = ""
        End If

        If _resultado IsNot Nothing AndAlso Not _resultado.Filtro.CodProveedor.Equals(Me.CboCodigoProveedor.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
            HabilitarAcciones(False)
            MostrarEstado("Proveedor cambiado: presione Consultar (F5).", CxPEstilos.ColorTexto)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
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
            MostrarEstado(mensaje, CxPEstilos.ColorTexto)
        End If
    End Sub

    Private Sub MostrarEstado(texto As String, color As Color)
        Me.LblEstado.Text = texto
        Me.LblEstado.ForeColor = color
    End Sub

    Private Sub HabilitarAcciones(habilitar As Boolean)
        _accionesHabilitadas = habilitar
        Me.Button1.Enabled = habilitar
        Me.Button3.Enabled = habilitar
        Me.Button5.Enabled = habilitar
        ' Se vuelven a aplicar los permisos del usuario sobre los botones
        If habilitar Then Seguridad.Bloqueo(Me, Acceso, "Ctas x Pagar")
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

    Private Sub TDGridImpuestos_FetchRowStyle(sender As Object, e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles TDGridImpuestos.FetchRowStyle
        CxPEstilos.PintarFila(Me.TDGridImpuestos, e)
    End Sub

    '=================================================================================================
    ' FILA SELECCIONADA (se leen los valores reales, no el texto formateado del grid)
    '=================================================================================================
    Private Function HayFila() As Boolean
        Return _vista IsNot Nothing AndAlso _vista.Count > 0
    End Function

    Private Function FilaTexto(campo As String) As String
        If Not HayFila() Then Return ""
        Try
            Dim valor = Me.TDGridImpuestos.Columns(campo).Value
            If valor Is Nothing OrElse IsDBNull(valor) Then Return ""
            Return CStr(valor).Trim()
        Catch
            Return ""
        End Try
    End Function

    Private Function NombreCorto() As String
        Return If(Len(Me.LblNombres.Text) > 29, Mid(Me.LblNombres.Text, 1, 29), Me.LblNombres.Text)
    End Function

    '=================================================================================================
    ' ACCIONES
    '=================================================================================================
    ' Nota de débito
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        With My.Forms.FrmRegistroDebito
            .LblNombre.Text = NombreCorto()
            .LblMoneda.Text = MonedaTexto
            .TipoNota = "Debito Proveedores"
            .TxtNumeroEnsamble.Text = "-----0-----"
            .LblFactura.Text = FilaTexto("Numero_Compra")
            .TxtCodCliente.Text = Me.CboCodigoProveedor.Text
            .Label1.Text = "NOTAS DE DEBITO PROVEEDORES"
            .ShowDialog()
        End With
        Consultar()
    End Sub

    ' Nota de crédito
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With My.Forms.FrmRegistroDebito
            .LblNombre.Text = NombreCorto()
            .LblMoneda.Text = MonedaTexto
            .TipoNota = "Credito Proveedores"
            .TxtNumeroEnsamble.Text = "-----0-----"
            .LblFactura.Text = FilaTexto("Numero_Compra")
            .NumeroFactura = FilaTexto("Numero_Compra")
            .TxtCodCliente.Text = Me.CboCodigoProveedor.Text
            .Label1.Text = "NOTAS DE CREDITO PROVEEDOR"
            .ShowDialog()
        End With
        Consultar()
    End Sub

    ' Pagos
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Forms.FrmPagos.TxtCodigoProveedor.Text = Me.CboCodigoProveedor.Text
        My.Forms.FrmPagos.TxtMonedaFactura.Text = MonedaTexto
        My.Forms.FrmPagos.ShowDialog()
        Consultar()
    End Sub

    ' Imprimir estado de cuenta
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

        If RutaLogo <> "" AndAlso System.IO.File.Exists(RutaLogo) Then
            ArepEstadoCuentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
        End If

        ArepEstadoCuentas.LblTitulo.Text = NombreEmpresa
        ArepEstadoCuentas.LblDireccion.Text = DireccionEmpresa
        ArepEstadoCuentas.LblRuc.Text = Ruc
        ArepEstadoCuentas.LblCodCliente.Text = Me.CboCodigoProveedor.Text
        ArepEstadoCuentas.LblNombreCliente.Text = Me.LblNombres.Text
        ArepEstadoCuentas.LblMoneda.Text = MonedaTexto
        ArepEstadoCuentas.LblFecha.Text = Format(Me.DTPFechaFin.Value, "dd/MM/yyyy")
        ArepEstadoCuentas.LblCargo.Text = Me.TxtCargos.Text
        ArepEstadoCuentas.LblAbono.Text = Me.TxtAbonos.Text
        ArepEstadoCuentas.LblMora.Text = Me.TxtMora.Text
        ArepEstadoCuentas.LblSaldoFinal.Text = Me.TxtSaldoFinal.Text

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepEstadoCuentas.Document
        ArepEstadoCuentas.DataSource = _vista
        ArepEstadoCuentas.Run(False)
        ViewerForm.Show()
    End Sub

    Private Sub CargarDatosEmpresa()
        If _empresa Is Nothing Then _empresa = _servicio.ObtenerEmpresa()
        NombreEmpresa = _empresa.Nombre
        DireccionEmpresa = _empresa.Direccion
        Ruc = _empresa.Ruc
        RutaLogo = _empresa.RutaLogo
    End Sub
End Class
