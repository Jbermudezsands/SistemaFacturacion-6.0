' =====================================================================================
' FrmAuditoriaFacturacion.vb
' Code-behind SIN lógica de negocio ni manejo de eventos.
' Solo el constructor mínimo requerido por el diseñador de Windows Forms.
' Aquí es donde después irías agregando los handlers (btnEjecutarAuditoria_Click,
' dgvControles_SelectionChanged, etc.) cuando decidas programar el comportamiento.
' =====================================================================================

Imports System.Collections.Generic
Imports System.ComponentModel

Public Class FrmAuditoriaFacturacion
    Private _WorkerAuditoria As BackgroundWorker
    Public WithEvents backgroundWorkerAuditoria As System.ComponentModel.BackgroundWorker

    Private _Auditor As Auditoria
    Private _Controles As List(Of Auditoria.ControlAuditoria)
    Private _ControlSeleccionado As Auditoria.ControlAuditoria
    Private _Hallazgos As List(Of Auditoria.HallazgoAuditoria)
    Private _ResultadoAuditoria As Auditoria.ResultadoAuditoria
    Private Sub backgroundWorkerAuditoria_DoWork(
    ByVal sender As Object,
    ByVal e As DoWorkEventArgs)

        Dim worker As BackgroundWorker =
        CType(sender, BackgroundWorker)

        If worker.CancellationPending Then

            e.Cancel = True
            Exit Sub

        End If

        Try

            _ResultadoAuditoria =
            _Auditor.Ejecutar()

            e.Result =
            _ResultadoAuditoria

        Catch ex As Exception

            e.Result = ex

        End Try

    End Sub
    Private Sub backgroundWorkerAuditoria_ProgressChanged(
    ByVal sender As Object,
    ByVal e As ProgressChangedEventArgs)

        Dim porcentaje As Integer =
        e.ProgressPercentage

        If porcentaje < 0 Then
            porcentaje = 0
        End If

        If porcentaje > 100 Then
            porcentaje = 100
        End If

        pbAuditoria.Value =
        porcentaje

        lblPorcentaje.Text =
        porcentaje.ToString() & "%"

        If e.UserState IsNot Nothing Then

            lblEstadoValor.Text =
            e.UserState.ToString()

        End If

    End Sub
    Private Sub backgroundWorkerAuditoria_RunWorkerCompleted(
    ByVal sender As Object,
    ByVal e As RunWorkerCompletedEventArgs)

        Try

            If e.Error IsNot Nothing Then

                MessageBox.Show(
                e.Error.Message,
                "Auditoría",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

                Return

            End If

            If e.Cancelled Then

                lblEstadoValor.Text =
                "Auditoría cancelada."

                Return

            End If

            If TypeOf e.Result Is Exception Then

                Dim ex As Exception =
                DirectCast(e.Result, Exception)

                MessageBox.Show(
                ex.Message,
                "Auditoría",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

                Return

            End If

            _ResultadoAuditoria =
            DirectCast(
                e.Result,
                Auditoria.ResultadoAuditoria)

            If _ResultadoAuditoria.TieneError Then

                MessageBox.Show(
                _ResultadoAuditoria.MensajeError,
                "Auditoría",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

                Return

            End If

            ' ====================================================
            ' ACTUALIZAR INDICADORES
            ' ====================================================

            lblControlesValor.Text =
            _ResultadoAuditoria.ControlesEjecutados.ToString()

            lblHallazgosValor.Text =
            _ResultadoAuditoria.TotalHallazgos.ToString()

            lblReparablesValor.Text =
            _ResultadoAuditoria.TotalReparables.ToString()

            If _ResultadoAuditoria.CostosConfiables Then

                lblCostosValor.Text = "CONFIABLES"

            Else

                lblCostosValor.Text = "NO CONFIABLES"

            End If

            ' ====================================================
            ' ACTUALIZAR GRID DE CONTROLES
            ' ====================================================

            _Controles =
            _ResultadoAuditoria.Controles

            dgvControles.DataSource = Nothing
            dgvControles.DataSource = _Controles

            ' ====================================================
            ' CARGAR HALLAZGOS
            ' ====================================================

            _Hallazgos =
            _ResultadoAuditoria.Hallazgos

            If _ControlSeleccionado IsNot Nothing Then

                CargarRegistrosControl()

            Else

                dgvRegistros.DataSource = Nothing

            End If

            ' ====================================================
            ' FINALIZAR
            ' ====================================================

            pbAuditoria.Value = 100
            lblPorcentaje.Text = "100%"

            lblEstadoValor.Text =
            "Auditoría finalizada."

        Catch ex As Exception

            MessageBox.Show(
            ex.Message,
            "Auditoría",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        Finally

            ' ====================================================
            ' DESCONECTAR EVENTO DE PROGRESO
            ' ====================================================

            RemoveHandler _Auditor.Progreso,
            AddressOf Auditor_Progreso

            btnEjecutar.Enabled = True
            btnDetener.Enabled = False

        End Try

    End Sub

    Public Sub New()

        InitializeComponent()

    End Sub

    ' ============================================================
    ' LOAD
    ' ============================================================

    Private Sub FrmAuditoriaFacturacion_Load(
    ByVal sender As Object,
    ByVal e As EventArgs) Handles MyBase.Load

        InicializarAuditoria()

    End Sub

    ' ============================================================
    ' INICIALIZAR AUDITORÍA
    ' ============================================================

    Private Sub InicializarAuditoria()

        _Auditor = New Auditoria()

        ConfigurarGridControles()

        CargarControlesAuditoria()

        InicializarEstadoFormulario()

    End Sub

    ' ============================================================
    ' CONFIGURAR GRID DE CONTROLES
    ' ============================================================

    Private Sub ConfigurarGridControles()

        With dgvControles

            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False

            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .RowHeadersVisible = False

            .Columns.Clear()

            Dim colCodigo As New DataGridViewTextBoxColumn()

            colCodigo.Name = "Codigo"
            colCodigo.HeaderText = "Código"
            colCodigo.DataPropertyName = "Codigo"
            colCodigo.Width = 90

            .Columns.Add(colCodigo)

            Dim colSeveridad As New DataGridViewTextBoxColumn()

            colSeveridad.Name = "Severidad"
            colSeveridad.HeaderText = "Severidad"
            colSeveridad.DataPropertyName = "Severidad"
            colSeveridad.Width = 90

            .Columns.Add(colSeveridad)

            Dim colDescripcion As New DataGridViewTextBoxColumn()

            colDescripcion.Name = "Descripcion"
            colDescripcion.HeaderText = "Descripción"
            colDescripcion.DataPropertyName = "Descripcion"
            colDescripcion.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill

            .Columns.Add(colDescripcion)

            Dim colCasos As New DataGridViewTextBoxColumn()

            colCasos.Name = "Casos"
            colCasos.HeaderText = "Casos"
            colCasos.DataPropertyName = "CantidadHallazgos"
            colCasos.Width = 80

            colCasos.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight

            .Columns.Add(colCasos)

            Dim colEstado As New DataGridViewTextBoxColumn()

            colEstado.Name = "Estado"
            colEstado.HeaderText = "Estado"
            colEstado.DataPropertyName = "Estado"
            colEstado.Width = 100

            .Columns.Add(colEstado)

        End With

    End Sub

    ' ============================================================
    ' CARGAR CATÁLOGO
    ' ============================================================

    Private Sub CargarControlesAuditoria()

        _Controles = _Auditor.ObtenerControles()

        dgvControles.DataSource = Nothing
        dgvControles.DataSource = _Controles

    End Sub

    ' ============================================================
    ' ESTADO INICIAL
    ' ============================================================

    Private Sub InicializarEstadoFormulario()

        pbAuditoria.Minimum = 0
        pbAuditoria.Maximum = 100
        pbAuditoria.Value = 0

        lblPorcentaje.Text = "0%"

        lblEstadoValor.Text = "Auditoría no ejecutada"

        lblControlesValor.Text = "0"
        lblHallazgosValor.Text = "0"
        lblReparablesValor.Text = "0"
        lblCostosValor.Text = "PENDIENTE"

        btnDetener.Enabled = False
        btnReparar.Enabled = False
        btnMarcarRevisado.Enabled = False

        LimpiarRegistros()
        LimpiarEvidencia()

    End Sub

    ' ============================================================
    ' LIMPIAR GRID DE REGISTROS
    ' ============================================================

    Private Sub LimpiarRegistros()

        dgvRegistros.DataSource = Nothing
        dgvRegistros.Rows.Clear()

    End Sub

    ' ============================================================
    ' LIMPIAR EVIDENCIA
    ' ============================================================

    Private Sub LimpiarEvidencia()

        lblDocumentoValor.Text = String.Empty
        lblFechaValor.Text = String.Empty
        lblTipoValor.Text = String.Empty
        lblProductoValor.Text = String.Empty
        lblCantidadValor.Text = String.Empty
        lblPrecioUnitarioValor.Text = String.Empty
        lblCostoUnitarioValor.Text = String.Empty

        txtMotivoValor.Text = String.Empty

        lblAccionValor.Text = String.Empty

    End Sub


    ' ============================================================
    ' SELECCIONAR CONTROL
    ' ============================================================

    Private Sub dgvControles_SelectionChanged(
ByVal sender As Object,
ByVal e As EventArgs) Handles dgvControles.SelectionChanged


        SeleccionarControl()


    End Sub

    ' ============================================================
    ' OBTENER CONTROL SELECCIONADO
    ' ============================================================

    Private Sub SeleccionarControl()


        _ControlSeleccionado = Nothing

        If dgvControles.CurrentRow Is Nothing Then

            LimpiarRegistros()
            LimpiarEvidencia()

            btnReparar.Enabled = False
            btnMarcarRevisado.Enabled = False

            Return

        End If

        If dgvControles.CurrentRow.Index < 0 Then

            Return

        End If

        Dim control As Auditoria.ControlAuditoria =
    TryCast(dgvControles.CurrentRow.DataBoundItem,
            Auditoria.ControlAuditoria)

        If control Is Nothing Then

            Return

        End If

        _ControlSeleccionado = control

        lblEstadoValor.Text =
    "Control seleccionado: " & control.Codigo

        ' --------------------------------------------------------
        ' POR AHORA NO CONSULTAMOS SQL.
        '
        ' Cuando el Auditor ejecute el control, aquí cargaremos
        ' los hallazgos correspondientes.
        ' --------------------------------------------------------

        CargarRegistrosControl()


    End Sub

    ' ============================================================
    ' CARGAR REGISTROS DEL CONTROL
    ' ============================================================
    Private Sub CargarRegistrosControl()

        dgvRegistros.DataSource = Nothing

        If _ControlSeleccionado Is Nothing Then

            LimpiarRegistros()
            ActualizarBotones()

            Return

        End If

        If _Hallazgos Is Nothing Then

            LimpiarRegistros()
            ActualizarBotones()

            Return

        End If

        ' ============================================================
        ' FILTRAR HALLAZGOS DEL CONTROL SELECCIONADO
        ' ============================================================

        Dim registros As New List(Of Auditoria.HallazgoAuditoria)

        For Each hallazgo As Auditoria.HallazgoAuditoria In _Hallazgos

            If String.Equals(
            hallazgo.Codigo,
            _ControlSeleccionado.Codigo,
            StringComparison.OrdinalIgnoreCase) Then

                registros.Add(hallazgo)

            End If

        Next

        ' ============================================================
        ' CONFIGURAR GRID
        ' ============================================================

        ConfigurarGridRegistros()

        ' ============================================================
        ' MOSTRAR REGISTROS FILTRADOS
        ' ============================================================

        dgvRegistros.DataSource = registros

        ' ============================================================
        ' ACTUALIZAR BOTONES
        ' ============================================================

        ActualizarBotones()

    End Sub


    ' ============================================================
    ' CONFIGURAR GRID DE REGISTROS
    ' ============================================================

    Private Sub ConfigurarGridRegistros()


        With dgvRegistros

            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False

            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode =
        DataGridViewSelectionMode.FullRowSelect

            .RowHeadersVisible = False

            .Columns.Clear()

            ' ----------------------------------------------------
            ' DOCUMENTO
            ' ----------------------------------------------------

            Dim colDocumento As New DataGridViewTextBoxColumn()

            colDocumento.Name = "Documento"
            colDocumento.HeaderText = "Documento"
            colDocumento.DataPropertyName = "Documento"
            colDocumento.Width = 90

            .Columns.Add(colDocumento)

            ' ----------------------------------------------------
            ' FECHA
            ' ----------------------------------------------------

            Dim colFecha As New DataGridViewTextBoxColumn()

            colFecha.Name = "Fecha"
            colFecha.HeaderText = "Fecha"
            colFecha.DataPropertyName = "Fecha"
            colFecha.Width = 90

            colFecha.DefaultCellStyle.Format = "dd/MM/yyyy"

            .Columns.Add(colFecha)

            ' ----------------------------------------------------
            ' TIPO
            ' ----------------------------------------------------

            Dim colTipo As New DataGridViewTextBoxColumn()

            colTipo.Name = "Tipo"
            colTipo.HeaderText = "Tipo"
            colTipo.DataPropertyName = "Tipo"
            colTipo.Width = 100

            .Columns.Add(colTipo)

            ' ----------------------------------------------------
            ' PRODUCTO
            ' ----------------------------------------------------

            Dim colProducto As New DataGridViewTextBoxColumn()

            colProducto.Name = "Producto"
            colProducto.HeaderText = "Producto"
            colProducto.DataPropertyName = "Producto"
            colProducto.Width = 100

            .Columns.Add(colProducto)

            ' ----------------------------------------------------
            ' CANTIDAD
            ' ----------------------------------------------------

            Dim colCantidad As New DataGridViewTextBoxColumn()

            colCantidad.Name = "Cantidad"
            colCantidad.HeaderText = "Cantidad"
            colCantidad.DataPropertyName = "Cantidad"
            colCantidad.Width = 80

            colCantidad.DefaultCellStyle.Format = "N2"

            colCantidad.DefaultCellStyle.Alignment =
        DataGridViewContentAlignment.MiddleRight

            .Columns.Add(colCantidad)

            ' ----------------------------------------------------
            ' COSTO
            ' ----------------------------------------------------

            Dim colCosto As New DataGridViewTextBoxColumn()

            colCosto.Name = "CostoUnitario"
            colCosto.HeaderText = "Costo"
            colCosto.DataPropertyName = "CostoUnitario"
            colCosto.Width = 90

            colCosto.DefaultCellStyle.Format = "N2"

            colCosto.DefaultCellStyle.Alignment =
        DataGridViewContentAlignment.MiddleRight

            .Columns.Add(colCosto)

            ' ----------------------------------------------------
            ' ESTADO
            ' ----------------------------------------------------

            Dim colEstado As New DataGridViewTextBoxColumn()

            colEstado.Name = "Estado"
            colEstado.HeaderText = "Estado"
            colEstado.DataPropertyName = "Estado"
            colEstado.Width = 100

            .Columns.Add(colEstado)

        End With


    End Sub

    ' ============================================================
    ' SELECCIONAR REGISTRO
    ' ============================================================

    Private Sub dgvRegistros_SelectionChanged(
ByVal sender As Object,
ByVal e As EventArgs) Handles dgvRegistros.SelectionChanged


        MostrarEvidencia()


    End Sub

    ' ============================================================
    ' MOSTRAR EVIDENCIA
    ' ============================================================

    Private Sub MostrarEvidencia()


        LimpiarEvidencia()

        If dgvRegistros.CurrentRow Is Nothing Then

            btnReparar.Enabled = False
            btnMarcarRevisado.Enabled = False

            Return

        End If

        Dim hallazgo As Auditoria.HallazgoAuditoria =
    TryCast(dgvRegistros.CurrentRow.DataBoundItem,
            Auditoria.HallazgoAuditoria)

        If hallazgo Is Nothing Then

            Return

        End If

        lblDocumentoValor.Text =
    hallazgo.Documento

        If hallazgo.Fecha <> DateTime.MinValue Then

            lblFechaValor.Text =
        hallazgo.Fecha.ToString("dd/MM/yyyy")

        End If

        lblTipoValor.Text =
    hallazgo.Tipo

        lblProductoValor.Text =
    hallazgo.Producto

        lblCantidadValor.Text =
    hallazgo.Cantidad.ToString("N2")

        lblPrecioUnitarioValor.Text =
    hallazgo.PrecioUnitario.ToString("N2")

        lblCostoUnitarioValor.Text =
    hallazgo.CostoUnitario.ToString("N2")

        txtMotivoValor.Text =
    hallazgo.Motivo

        lblAccionValor.Text =
    hallazgo.Accion

        ActualizarBotones()


    End Sub

    ' ============================================================
    ' ACTUALIZAR BOTONES
    ' ============================================================

    Private Sub ActualizarBotones()


        btnReparar.Enabled = False
        btnMarcarRevisado.Enabled = False

        If dgvRegistros.CurrentRow Is Nothing Then

            Return

        End If

        Dim hallazgo As Auditoria.HallazgoAuditoria =
    TryCast(dgvRegistros.CurrentRow.DataBoundItem,
            Auditoria.HallazgoAuditoria)

        If hallazgo Is Nothing Then

            Return

        End If

        ' --------------------------------------------------------
        ' REPARAR
        ' --------------------------------------------------------

        If hallazgo.Reparable AndAlso
   hallazgo.Estado =
   Auditoria.EstadoHallazgo.Reparable Then

            btnReparar.Enabled = True

        End If

        ' --------------------------------------------------------
        ' MARCAR REVISADO
        ' --------------------------------------------------------

        If hallazgo.Estado =
   Auditoria.EstadoHallazgo.Detectado Then

            btnMarcarRevisado.Enabled = True

        End If

    End Sub
    Private Sub EjecutarAuditoriaPrueba()

        My.Application.DoEvents()

        If _Auditor Is Nothing Then

            MessageBox.Show(
            "El Auditor no está inicializado.",
            "Auditoría",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

            Return

        End If

        _WorkerAuditoria =
        New BackgroundWorker()

        AddHandler _WorkerAuditoria.DoWork,
        AddressOf backgroundWorkerAuditoria_DoWork

        AddHandler _WorkerAuditoria.ProgressChanged,
        AddressOf backgroundWorkerAuditoria_ProgressChanged

        AddHandler _WorkerAuditoria.RunWorkerCompleted,
        AddressOf backgroundWorkerAuditoria_RunWorkerCompleted

        _WorkerAuditoria.WorkerReportsProgress = True
        _WorkerAuditoria.WorkerSupportsCancellation = True

        ' ====================================================
        ' CONECTAR PROGRESO DEL AUDITOR
        ' ====================================================

        AddHandler _Auditor.Progreso,
        AddressOf Auditor_Progreso

        ' ====================================================
        ' PREPARAR INTERFAZ
        ' ====================================================

        btnEjecutar.Enabled = False
        btnDetener.Enabled = True

        lblEstadoValor.Text =
        "Iniciando auditoría..."

        pbAuditoria.Value = 0
        lblPorcentaje.Text = "0%"

        ' ====================================================
        ' INICIAR BACKGROUNDWORKER
        ' ====================================================

        _WorkerAuditoria.RunWorkerAsync()

    End Sub

    Private Sub Auditor_Progreso(
    ByVal porcentaje As Integer,
    ByVal mensaje As String)

        If _WorkerAuditoria Is Nothing Then
            Return
        End If

        If Not _WorkerAuditoria.IsBusy Then
            Return
        End If

        _WorkerAuditoria.ReportProgress(
        porcentaje,
        mensaje)

    End Sub


    'Private Sub EjecutarAuditoriaPrueba()

    '    Try

    '        btnEjecutar.Enabled = False
    '        btnDetener.Enabled = False

    '        lblEstadoValor.Text =
    '            "Ejecutando COST-001..."

    '        _ResultadoAuditoria =
    '_Auditor.Ejecutar()

    '        If _ResultadoAuditoria.TieneError Then

    '            MessageBox.Show(
    '                _ResultadoAuditoria.MensajeError,
    '                "Auditoría",
    '                MessageBoxButtons.OK,
    '                MessageBoxIcon.Error)

    '            Return

    '        End If

    '        ' ====================================================
    '        ' ACTUALIZAR INDICADORES
    '        ' ====================================================

    '        lblControlesValor.Text =
    '            _ResultadoAuditoria.ControlesEjecutados.ToString()

    '        lblHallazgosValor.Text =
    '            _ResultadoAuditoria.TotalHallazgos.ToString()

    '        lblReparablesValor.Text =
    '            _ResultadoAuditoria.TotalReparables.ToString()

    '        If _ResultadoAuditoria.CostosConfiables Then

    '            lblCostosValor.Text = "CONFIABLES"

    '        Else

    '            lblCostosValor.Text = "NO CONFIABLES"

    '        End If

    '        ' ====================================================
    '        ' ACTUALIZAR GRID
    '        ' ====================================================

    '        _Controles = _ResultadoAuditoria.Controles

    '        dgvControles.DataSource = Nothing
    '        dgvControles.DataSource = _Controles

    '        ' ====================================================
    '        ' CARGAR HALLAZGOS
    '        ' ====================================================

    '        _Hallazgos =
    '            _ResultadoAuditoria.Hallazgos

    '        If _ControlSeleccionado IsNot Nothing Then

    '            CargarRegistrosControl()

    '        Else

    '            dgvRegistros.DataSource = Nothing

    '        End If

    '        lblEstadoValor.Text =
    '            "Auditoría finalizada."

    '        pbAuditoria.Value = 100
    '        lblPorcentaje.Text = "100%"

    '    Catch ex As Exception

    '        MessageBox.Show(
    '            ex.Message,
    '            "Auditoría",
    '            MessageBoxButtons.OK,
    '            MessageBoxIcon.Error)

    '    Finally

    '        btnEjecutar.Enabled = True
    '        btnDetener.Enabled = False

    '    End Try

    'End Sub

    Private Sub btnEjecutarAuditoria_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        EjecutarAuditoriaPrueba()
    End Sub

    Private Sub btnReparar_Click(
    ByVal sender As Object,
    ByVal e As EventArgs) Handles btnReparar.Click

        Try

            ' ============================================================
            ' VERIFICAR SELECCIÓN
            ' ============================================================

            If dgvRegistros.SelectedRows.Count = 0 Then

                MessageBox.Show(
                "Debe seleccionar un hallazgo para reparar.",
                "Auditoría",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

                Return

            End If

            ' ============================================================
            ' OBTENER HALLAZGO
            ' ============================================================

            Dim fila As DataGridViewRow =
            dgvRegistros.SelectedRows(0)

            Dim hallazgo As Auditoria.HallazgoAuditoria =
            TryCast(
                fila.DataBoundItem,
                Auditoria.HallazgoAuditoria)

            If hallazgo Is Nothing Then

                MessageBox.Show(
                "No fue posible obtener el hallazgo seleccionado.",
                "Auditoría",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Return

            End If

            ' ============================================================
            ' VERIFICAR QUE SEA REPARABLE
            ' ============================================================

            If Not hallazgo.Reparable Then

                MessageBox.Show(
                "El registro seleccionado no está disponible para reparación.",
                "Auditoría",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

                Return

            End If

            ' ============================================================
            ' DETERMINAR TIPO DE REPARACIÓN
            ' ============================================================

            Dim mensaje As String = ""

            Select Case hallazgo.Codigo

            ' ========================================================
            ' COSTOS
            ' ========================================================

                Case "COST-001",
                 "COST-002",
                 "COST-003",
                 "COST-004",
                 "COST-005"

                    mensaje =
                    "Se realizará la reparación del costo." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "Control: " &
                    hallazgo.Codigo &
                    Environment.NewLine &
                    "Documento: " &
                    hallazgo.Documento &
                    Environment.NewLine &
                    "Producto: " &
                    hallazgo.Producto &
                    Environment.NewLine &
                    "Costo actual: " &
                    hallazgo.CostoUnitario.ToString("N6") &
                    Environment.NewLine &
                    "Costo nuevo: " &
                    hallazgo.CostoPropuesto.ToString("N6") &
                    Environment.NewLine &
                    Environment.NewLine &
                    "¿Desea continuar?"

            ' ========================================================
            ' TRANSFERENCIA ENVIADA SIN RECIBIDA
            ' ========================================================

                Case "TRANS-001"

                    mensaje =
                    "Se creará el registro equivalente de la " &
                    "Transferencia Recibida." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "Control: TRANS-001" &
                    Environment.NewLine &
                    "Documento: " &
                    hallazgo.Documento &
                    Environment.NewLine &
                    "ID Detalle Factura: " &
                    hallazgo.IdDetalleFactura.ToString() &
                    Environment.NewLine &
                    "Producto: " &
                    hallazgo.Producto &
                    Environment.NewLine &
                    "Cantidad: " &
                    hallazgo.Cantidad.ToString("N6") &
                    Environment.NewLine &
                    Environment.NewLine &
                    "No se calculará ni modificará ningún costo." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "¿Desea continuar?"

            ' ========================================================
            ' TRANSFERENCIA RECIBIDA SIN ENVIADA
            ' ========================================================

                Case "TRANS-002"

                    mensaje =
                    "Se creará el registro equivalente de la " &
                    "Transferencia Enviada." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "Control: TRANS-002" &
                    Environment.NewLine &
                    "Documento: " &
                    hallazgo.Documento &
                    Environment.NewLine &
                    "ID Detalle Compra: " &
                    hallazgo.IdDetalleCompra.ToString() &
                    Environment.NewLine &
                    "Producto: " &
                    hallazgo.Producto &
                    Environment.NewLine &
                    "Cantidad: " &
                    hallazgo.Cantidad.ToString("N6") &
                    Environment.NewLine &
                    Environment.NewLine &
                    "No se calculará ni modificará ningún costo." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "¿Desea continuar?"

                Case Else

                    MessageBox.Show(
                    "El control " &
                    hallazgo.Codigo &
                    " no tiene una reparación definida.",
                    "Auditoría",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                    Return

            End Select

            ' ============================================================
            ' CONFIRMAR
            ' ============================================================

            Dim respuesta As DialogResult =
            MessageBox.Show(
                mensaje,
                "Confirmar reparación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If respuesta <> DialogResult.Yes Then
                Return
            End If

            ' ============================================================
            ' DESHABILITAR BOTÓN
            ' ============================================================

            btnReparar.Enabled = False

            lblEstadoValor.Text =
            "Reparando " & hallazgo.Codigo & "..."

            ' ============================================================
            ' EJECUTAR REPARACIÓN
            ' ============================================================

            Dim reparado As Boolean = False

            Select Case hallazgo.Codigo

            ' ========================================================
            ' COSTOS
            ' ========================================================

                Case "COST-001",
                 "COST-002",
                 "COST-003",
                 "COST-004",
                 "COST-005"

                    reparado =
                    _Auditor.RepararCosto(hallazgo)

            ' ========================================================
            ' TRANS-001
            ' ========================================================

                Case "TRANS-001"

                    reparado =
                    _Auditor.RepararTransferencia001(
                        hallazgo)

            ' ========================================================
            ' TRANS-002
            ' ========================================================

                Case "TRANS-002"

                    reparado =
                    _Auditor.RepararTransferencia002(
                        hallazgo)

            End Select

            ' ============================================================
            ' RESULTADO
            ' ============================================================

            If reparado Then

                ' ========================================================
                ' ACTUALIZAR CONTADOR
                ' ========================================================

                If _ResultadoAuditoria IsNot Nothing Then

                    If _ResultadoAuditoria.TotalReparables > 0 Then

                        _ResultadoAuditoria.TotalReparables -= 1

                    End If

                    lblReparablesValor.Text =
                    _ResultadoAuditoria.TotalReparables.ToString()

                End If

                ' ========================================================
                ' ACTUALIZAR EVIDENCIA
                ' ========================================================

                MostrarEvidencia()

                ' ========================================================
                ' ACTUALIZAR GRID
                ' ========================================================

                dgvRegistros.Refresh()

                ' ========================================================
                ' MENSAJE SEGÚN CONTROL
                ' ========================================================

                Select Case hallazgo.Codigo

                    Case "TRANS-001"

                        lblEstadoValor.Text =
                        "Transferencia reparada correctamente."

                        MessageBox.Show(
                        "La Transferencia Recibida fue creada correctamente." &
                        Environment.NewLine &
                        Environment.NewLine &
                        "Documento: " &
                        hallazgo.Documento &
                        Environment.NewLine &
                        "ID Detalle Factura origen: " &
                        hallazgo.IdDetalleFactura.ToString(),
                        "Auditoría",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

                    Case "TRANS-002"

                        lblEstadoValor.Text =
                        "Transferencia reparada correctamente."

                        MessageBox.Show(
                        "La Transferencia Enviada fue creada correctamente." &
                        Environment.NewLine &
                        Environment.NewLine &
                        "Documento: " &
                        hallazgo.Documento &
                        Environment.NewLine &
                        "ID Detalle Compra origen: " &
                        hallazgo.IdDetalleCompra.ToString(),
                        "Auditoría",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

                    Case Else

                        lblEstadoValor.Text =
                        "Costo reparado correctamente."

                        MessageBox.Show(
                        "El costo fue reparado correctamente." &
                        Environment.NewLine &
                        Environment.NewLine &
                        "Costo anterior: " &
                        hallazgo.Evidencia.CostoAnterior.ToString("N6") &
                        Environment.NewLine &
                        "Costo nuevo: " &
                        hallazgo.Evidencia.CostoNuevo.ToString("N6"),
                        "Auditoría",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

                End Select

            Else

                lblEstadoValor.Text =
                "No fue posible reparar " &
                hallazgo.Codigo & "."

                MessageBox.Show(
                "No fue posible realizar la reparación." &
                Environment.NewLine &
                Environment.NewLine &
                "El registro pudo haber sido modificado " &
                "por otro proceso o la contraparte ya puede existir.",
                "Auditoría",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            End If

        Catch ex As Exception

            MessageBox.Show(
            ex.Message,
            "Error al reparar",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        Finally

            ActualizarBotones()

        End Try

    End Sub
    Private Sub dgvControles_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvControles.CellContentClick

    End Sub
End Class
