Imports System.Data.SqlClient


Public Class FrmPlanPagoRecibos

    Private _DatosRecibo As DatosReciboPlanPago
    Private _Servicio As New PlanPagoReciboService()
    Private _Facturas As List(Of FacturaPlanPagoRecibo)
    Private _MetodosPago As List(Of MetodoPagoRecibo)
    Private _TablaFacturas As DataTable
    Private _MetodosDisponibles As New List(Of String)
    Private _AplicacionesPendientes As New List(Of AplicacionPlanPendiente)
    Private _NumeroCreditoActual As Integer

    Public ReadOnly Property AplicacionesPendientes As List(Of AplicacionPlanPendiente)
        Get
            Return _AplicacionesPendientes
        End Get
    End Property

    Private Sub FrmPlanPagoRecibos_Load(
    ByVal sender As Object,
    ByVal e As System.EventArgs
) Handles MyBase.Load

        Try

            CargarFacturas()

            CargarMetodoPagoDefecto()

            CargarMetodosDisponibles()

        Catch ex As Exception

            MessageBox.Show(
            "Error al cargar el recibo de plan de pago." &
            vbCrLf & vbCrLf &
            ex.Message,
            "Plan de pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub CargarMetodosDisponibles()

        _MetodosDisponibles.Clear()

        If _DatosRecibo Is Nothing Then
            Exit Sub
        End If

        Dim SQL As String =
        "SELECT DISTINCT NombrePago " &
        "FROM MetodoPago " &
        "WHERE Moneda = @Moneda " &
        "ORDER BY NombrePago"

        Using CN As New SqlConnection(Conexion)

            Using CMD As New SqlCommand(SQL, CN)

                CMD.Parameters.Add(
                "@Moneda",
                SqlDbType.NVarChar,
                50).Value =
                _DatosRecibo.MonedaRecibo

                CN.Open()

                Using DR As SqlDataReader =
                CMD.ExecuteReader()

                    While DR.Read()

                        If Not IsDBNull(DR("NombrePago")) Then

                            Dim Nombre As String =
                            Convert.ToString(DR("NombrePago"))

                            If Nombre <> "" Then
                                _MetodosDisponibles.Add(Nombre)
                            End If

                        End If

                    End While

                End Using

            End Using

        End Using

    End Sub
    Private Sub CargarMetodoPagoDefecto()

        _MetodosPago = New List(Of MetodoPagoRecibo)()

        If _DatosRecibo Is Nothing Then
            Exit Sub
        End If


        '==============================================================
        ' OBTENER METODO DE PAGO POR DEFECTO
        '==============================================================

        Dim MetodoPagoDefecto As String = ""

        Dim SQL As String =
        "SELECT MetodoPagoDefecto " &
        "FROM DatosEmpresa"

        Using CN As New SqlConnection(Conexion)

            Using CMD As New SqlCommand(SQL, CN)

                CN.Open()

                Dim Resultado As Object =
                CMD.ExecuteScalar()

                If Resultado IsNot Nothing AndAlso
               Not IsDBNull(Resultado) Then

                    MetodoPagoDefecto =
                    Convert.ToString(Resultado)

                End If

            End Using

        End Using


        '==============================================================
        ' SI EL METODO POR DEFECTO ES EFECTIVO
        '==============================================================

        If MetodoPagoDefecto = "Efectivo" Then

            Dim NombrePagoEfectivo As String = ""

            SQL =
            "SELECT TOP 1 NombrePago " &
            "FROM MetodoPago " &
            "WHERE TipoPago = @TipoPago " &
            "AND Moneda = @Moneda"

            Using CN As New SqlConnection(Conexion)

                Using CMD As New SqlCommand(SQL, CN)

                    CMD.Parameters.Add(
                    "@TipoPago",
                    SqlDbType.NVarChar,
                    50).Value = "Efectivo"

                    CMD.Parameters.Add(
                    "@Moneda",
                    SqlDbType.NVarChar,
                    50).Value =
                    _DatosRecibo.MonedaRecibo

                    CN.Open()

                    Dim Resultado As Object =
                    CMD.ExecuteScalar()

                    If Resultado IsNot Nothing AndAlso
                   Not IsDBNull(Resultado) Then

                        NombrePagoEfectivo =
                        Convert.ToString(Resultado)

                    End If

                End Using

            End Using


            '==========================================================
            ' AGREGAR METODO EFECTIVO
            '==========================================================

            If NombrePagoEfectivo <> "" Then

                Dim Metodo As New MetodoPagoRecibo()

                Metodo.NombrePago =
                NombrePagoEfectivo

                Metodo.Monto = 0D

                Metodo.NumeroTarjeta = ""

                Metodo.FechaVence = Now.Date

                _MetodosPago.Add(Metodo)

            End If

        End If


        '==============================================================
        ' ENLAZAR GRID
        '==============================================================

        Me.TrueDBGridMetodo.DataSource =
        _MetodosPago

        '==============================================================
        ' CONFIGURAR GRID DE METODOS DE PAGO
        '==============================================================

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Width = 150

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 80

        Me.TrueDBGridMetodo.Columns(1).NumberFormat =
            "##,##0.00"

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False

    End Sub
    Public Property DatosRecibo As DatosReciboPlanPago
        Get
            Return _DatosRecibo
        End Get
        Set(ByVal value As DatosReciboPlanPago)
            _DatosRecibo = value
        End Set
    End Property
    Private Sub PrepararTablaFacturas()

        _TablaFacturas = New DataTable()

        _TablaFacturas.Columns.Add("NumeroFactura", GetType(String))
        _TablaFacturas.Columns.Add("FechaFactura", GetType(Date))
        _TablaFacturas.Columns.Add("TipoFactura", GetType(String))
        _TablaFacturas.Columns.Add("MontoCredito", GetType(Decimal))
        _TablaFacturas.Columns.Add("TotalAplicado", GetType(Decimal))
        _TablaFacturas.Columns.Add("Saldo", GetType(Decimal))
        _TablaFacturas.Columns.Add("NumeroCredito", GetType(Integer))

    End Sub

    Private Sub CargarFacturas()

        If _DatosRecibo Is Nothing Then
            Exit Sub
        End If

        _Facturas = _Servicio.ObtenerFacturasConPlanPago(
        _DatosRecibo.CodigoCliente,
        _DatosRecibo.MonedaRecibo)

        TDGridFacturas.DataSource = Nothing
        TDGridFacturas.DataSource = _Facturas

    End Sub

    Private Function PrepararAplicaciones() As Boolean

        _AplicacionesPendientes.Clear()

        Dim ImporteRecibido As Decimal = 0D

        If _MetodosPago IsNot Nothing Then

            For Each Metodo As MetodoPagoRecibo In _MetodosPago

                If Metodo IsNot Nothing Then
                    ImporteRecibido += Metodo.Monto
                End If

            Next

        End If


        If ImporteRecibido <= 0D Then

            MessageBox.Show(
            "El importe recibido debe ser mayor que cero.",
            "Recibo de plan de pagos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return False

        End If


        Dim Detalles As List(Of DetallePlanPagoRecibo) =
        TryCast(
            TDGridDetallePlan.DataSource,
            List(Of DetallePlanPagoRecibo))


        If Detalles Is Nothing Then

            MessageBox.Show(
            "No hay cuotas disponibles para aplicar.",
            "Recibo de plan de pagos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return False

        End If


        Dim ImporteAplicado As Decimal = 0D

        For Each Detalle As DetallePlanPagoRecibo In Detalles

            If Detalle Is Nothing Then Continue For

            If Not Detalle.Aplicar Then Continue For

            If Detalle.MontoAAplicar > 0D Then
                ImporteAplicado += Detalle.MontoAAplicar
            End If

        Next


        Dim PorAplicar As Decimal =
        ImporteRecibido - ImporteAplicado


        If PorAplicar > 0.01D Then

            MessageBox.Show(
            "Existe un importe recibido que todavía no ha sido aplicado." &
            vbCrLf & vbCrLf &
            "Importe recibido: " &
            ImporteRecibido.ToString("N2") &
            vbCrLf &
            "Importe aplicado: " &
            ImporteAplicado.ToString("N2") &
            vbCrLf &
            "Por aplicar: " &
            PorAplicar.ToString("N2"),
            "Recibo de plan de pagos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return False

        End If


        Dim FacturaActual As FacturaPlanPagoRecibo = Nothing

        If _Facturas IsNot Nothing Then

            For Each Factura As FacturaPlanPagoRecibo In _Facturas

                If Factura IsNot Nothing AndAlso
               Factura.NumeroCredito = _NumeroCreditoActual Then

                    FacturaActual = Factura

                    Exit For

                End If

            Next

        End If


        If FacturaActual Is Nothing Then

            MessageBox.Show(
            "No se pudo determinar la factura correspondiente a las cuotas seleccionadas.",
            "Recibo de plan de pagos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return False

        End If


        '==========================================================
        ' COPIA TEMPORAL DE LOS SALDOS DE LOS METODOS
        ' NO MODIFICA LOS IMPORTES ORIGINALES
        '==========================================================

        Dim SaldosMetodos As New List(Of Decimal)


        If _MetodosPago IsNot Nothing Then

            For Each Metodo As MetodoPagoRecibo In _MetodosPago

                If Metodo Is Nothing Then
                    SaldosMetodos.Add(0D)
                Else
                    SaldosMetodos.Add(Metodo.Monto)
                End If

            Next

        End If


        Dim IndiceMetodo As Integer = 0


        While IndiceMetodo < SaldosMetodos.Count AndAlso
          SaldosMetodos(IndiceMetodo) <= 0.01D

            IndiceMetodo += 1

        End While


        If IndiceMetodo >= SaldosMetodos.Count Then

            MessageBox.Show(
            "No existen importes disponibles en los métodos de pago.",
            "Recibo de plan de pagos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return False

        End If


        '==========================================================
        ' RECORRER CUOTAS EN ORDEN
        '==========================================================

        For Each Detalle As DetallePlanPagoRecibo In Detalles

            If Detalle Is Nothing Then Continue For

            If Not Detalle.Aplicar Then Continue For

            If Detalle.MontoAAplicar <= 0D Then Continue For


            Dim PendienteCuota As Decimal =
            Detalle.MontoAAplicar


            '======================================================
            ' DISTRIBUIR LA CUOTA ENTRE LOS METODOS
            '======================================================

            While PendienteCuota > 0.01D


                While IndiceMetodo < SaldosMetodos.Count AndAlso
                  SaldosMetodos(IndiceMetodo) <= 0.01D

                    IndiceMetodo += 1

                End While


                If IndiceMetodo >= SaldosMetodos.Count Then

                    MessageBox.Show(
                    "No hay suficiente importe disponible en los métodos de pago para completar la distribución.",
                    "Recibo de plan de pagos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                    Return False

                End If


                Dim Metodo As MetodoPagoRecibo =
                _MetodosPago(IndiceMetodo)


                If Metodo Is Nothing Then

                    IndiceMetodo += 1

                    Continue While

                End If


                Dim SaldoMetodo As Decimal =
                SaldosMetodos(IndiceMetodo)


                Dim MontoAplicacion As Decimal =
                Math.Min(
                    PendienteCuota,
                    SaldoMetodo)


                If MontoAplicacion <= 0D Then

                    IndiceMetodo += 1

                    Continue While

                End If


                '==================================================
                ' CREAR APLICACION PENDIENTE
                '==================================================

                Dim Aplicacion As New AplicacionPlanPendiente()


                Aplicacion.IdDetallePago =
                Detalle.IdDetallePago


                Aplicacion.NumeroCuota =
                Detalle.NumeroCuota


                Aplicacion.NumeroFactura =
                FacturaActual.NumeroFactura


                Aplicacion.FechaFactura =
                FacturaActual.FechaFactura


                Aplicacion.TipoFactura =
                FacturaActual.TipoFactura


                Aplicacion.MontoAplicado =
                MontoAplicacion


                Aplicacion.NombrePago =
                Metodo.NombrePago


                Aplicacion.NumeroTarjeta =
                Metodo.NumeroTarjeta


                Aplicacion.FechaVence =
                Metodo.FechaVence


                _AplicacionesPendientes.Add(
                Aplicacion)


                '==================================================
                ' ACTUALIZAR SOLO EL SALDO TEMPORAL
                '==================================================

                SaldosMetodos(IndiceMetodo) =
                SaldosMetodos(IndiceMetodo) -
                MontoAplicacion


                PendienteCuota =
                PendienteCuota -
                MontoAplicacion


                If SaldosMetodos(IndiceMetodo) <= 0.01D Then

                    SaldosMetodos(IndiceMetodo) = 0D

                    IndiceMetodo += 1

                End If

            End While

        Next


        If _AplicacionesPendientes.Count = 0 Then

            MessageBox.Show(
            "No se generaron aplicaciones para las cuotas seleccionadas.",
            "Recibo de plan de pagos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return False

        End If


        '==========================================================
        ' VALIDACION FINAL
        '==========================================================

        Dim TotalGenerado As Decimal = 0D


        For Each Aplicacion As AplicacionPlanPendiente In
        _AplicacionesPendientes

            If Aplicacion IsNot Nothing Then

                TotalGenerado +=
                Aplicacion.MontoAplicado

            End If

        Next


        If Math.Abs(
        TotalGenerado - ImporteRecibido) > 0.01D Then

            MessageBox.Show(
            "El total de las aplicaciones no coincide con el importe recibido." &
            vbCrLf & vbCrLf &
            "Importe recibido: " &
            ImporteRecibido.ToString("N2") &
            vbCrLf &
            "Total generado: " &
            TotalGenerado.ToString("N2"),
            "Recibo de plan de pagos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            _AplicacionesPendientes.Clear()

            Return False

        End If


        Return True

    End Function


    Private Sub TDGridFacturas_RowColChange(
    ByVal sender As Object,
    ByVal e As System.EventArgs
) Handles TDGridFacturas.RowColChange

        Try

            If TDGridFacturas.Row < 0 Then
                Exit Sub
            End If

            If _Facturas Is Nothing Then
                Exit Sub
            End If

            If TDGridFacturas.Row >= _Facturas.Count Then
                Exit Sub
            End If

            Dim Factura As FacturaPlanPagoRecibo =
                _Facturas(TDGridFacturas.Row)

            If Factura Is Nothing Then
                Exit Sub
            End If

            CargarDetallePlanPago(Factura.NumeroCredito)

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar el detalle del plan de pago." &
                vbCrLf & vbCrLf &
                ex.Message,
                "Plan de pago",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub CargarDetallePlanPago(
    ByVal NumeroCredito As Integer
)

        Dim Detalles As List(Of DetallePlanPagoRecibo)

        _NumeroCreditoActual = NumeroCredito

        Detalles = _Servicio.ObtenerDetallePlanPago(NumeroCredito)

        TDGridDetallePlan.DataSource = Nothing
        TDGridDetallePlan.DataSource = Detalles

        '==============================================================
        ' CONFIGURAR GRID DETALLE DEL PLAN
        '==============================================================

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(3).Visible = False
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(5).Visible = False
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(6).Visible = False

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(12).Visible = False
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(13).Visible = False

        '==============================================================
        ' TITULOS DE LAS COLUMNAS
        '==============================================================

        Me.TDGridDetallePlan.Columns(1).Caption =
            "Cuota"

        Me.TDGridDetallePlan.Columns(2).Caption =
            "Vencimiento"

        Me.TDGridDetallePlan.Columns(7).Caption =
            "Total Cuota"

        Me.TDGridDetallePlan.Columns(8).Caption =
            "Aplicado"

        Me.TDGridDetallePlan.Columns(9).Caption =
            "Saldo"

        Me.TDGridDetallePlan.Columns(10).Caption =
            "Monto a Aplicar"

        Me.TDGridDetallePlan.Columns(11).Caption =
            "Aplicar"

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(1).Width = 60

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(2).Width = 90

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(7).Width = 90

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(8).Width = 90

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(9).Width = 90

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(10).Width = 100

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(11).Width = 60

        '==============================================================
        ' PERMITIR EDICION DEL GRID
        '==============================================================

        Me.TDGridDetallePlan.AllowUpdate = True


        '==============================================================
        ' BLOQUEAR TODAS LAS COLUMNAS
        '==============================================================

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(10).Locked = False


        '==============================================================
        ' COLUMNA APLICAR
        ' ES LA UNICA EDITABLE
        '==============================================================

        Me.TDGridDetallePlan.Splits.Item(0).DisplayColumns(11).Locked = False

    End Sub

    Private Sub btnAgregarMetodo_Click(
    ByVal sender As Object,
    ByVal e As System.EventArgs
) Handles btnAgregarMetodo.Click

        If _MetodosDisponibles Is Nothing OrElse
       _MetodosDisponibles.Count = 0 Then

            MessageBox.Show(
            "No existen métodos de pago configurados para la moneda del recibo.",
            "Métodos de pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

            Exit Sub

        End If


        '==============================================================
        ' MOSTRAR METODOS DISPONIBLES
        '==============================================================

        Dim TextoOpciones As String = ""

        For I As Integer = 0 To _MetodosDisponibles.Count - 1

            TextoOpciones &=
            (I + 1).ToString() & ". " &
            _MetodosDisponibles(I) & vbCrLf

        Next


        Dim Respuesta As String =
        Microsoft.VisualBasic.Interaction.InputBox(
            "Seleccione el número del método de pago:" &
            vbCrLf & vbCrLf &
            TextoOpciones,
            "Agregar método de pago",
            "1")


        If String.IsNullOrEmpty(Respuesta) Then
            Exit Sub
        End If


        '==============================================================
        ' VALIDAR OPCION
        '==============================================================

        Dim Indice As Integer

        If Not Integer.TryParse(Respuesta, Indice) Then

            MessageBox.Show(
            "Debe seleccionar un número válido.",
            "Métodos de pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Exit Sub

        End If

        Indice -= 1


        If Indice < 0 OrElse
       Indice >= _MetodosDisponibles.Count Then

            MessageBox.Show(
            "El método seleccionado no es válido.",
            "Métodos de pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Exit Sub

        End If


        '==============================================================
        ' AGREGAR METODO
        '==============================================================

        Dim Metodo As New MetodoPagoRecibo()

        Metodo.NombrePago =
        _MetodosDisponibles(Indice)

        Metodo.Monto = 0D

        Metodo.NumeroTarjeta = ""

        Metodo.FechaVence = Now.Date

        _MetodosPago.Add(Metodo)


        '==============================================================
        ' ACTUALIZAR GRID
        '==============================================================

        Me.TrueDBGridMetodo.DataSource = Nothing

        Me.TrueDBGridMetodo.DataSource =
        _MetodosPago


        '==============================================================
        ' CONFIGURAR COLUMNAS NUEVAMENTE
        '==============================================================

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Width = 150

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 80

        Me.TrueDBGridMetodo.Columns(1).NumberFormat =
        "##,##0.00"

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False

    End Sub

    Private Sub btnQuitarMetodo_Click(
    ByVal sender As Object,
    ByVal e As System.EventArgs
) Handles btnQuitarMetodo.Click

        If _MetodosPago Is Nothing OrElse
       _MetodosPago.Count = 0 Then

            Exit Sub

        End If


        '==============================================================
        ' OBTENER FILA SELECCIONADA
        '==============================================================

        Dim Indice As Integer =
        Me.TrueDBGridMetodo.Row


        If Indice < 0 OrElse
       Indice >= _MetodosPago.Count Then

            Exit Sub

        End If


        '==============================================================
        ' ELIMINAR METODO
        '==============================================================

        _MetodosPago.RemoveAt(Indice)


        '==============================================================
        ' ACTUALIZAR GRID
        '==============================================================

        Me.TrueDBGridMetodo.DataSource = Nothing

        Me.TrueDBGridMetodo.DataSource =
        _MetodosPago


        '==============================================================
        ' CONFIGURAR COLUMNAS
        '==============================================================

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(0).Width = 150

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(1).Width = 80

        Me.TrueDBGridMetodo.Columns(1).NumberFormat =
        "##,##0.00"

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(2).Visible = False

        Me.TrueDBGridMetodo.Splits.Item(0).DisplayColumns(3).Visible = False

    End Sub

    Private Sub TrueDBGridMetodo_AfterColUpdate(
    ByVal sender As Object,
    ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs
) Handles TrueDBGridMetodo.AfterColUpdate

        If e.ColIndex = 1 Then

            CalcularImporteRecibido()

        End If

    End Sub

    Private Sub CalcularImporteRecibido()

        Dim Total As Decimal = 0D

        If _MetodosPago Is Nothing Then
            Me.TxtImporteRecibido.Text = "0.00"
            Exit Sub
        End If


        For Each Metodo As MetodoPagoRecibo In _MetodosPago

            If Metodo IsNot Nothing Then

                If Metodo.Monto > 0D Then

                    Total += Metodo.Monto

                End If

            End If

        Next


        Me.TxtImporteRecibido.Text =
            Total.ToString("N2")

    End Sub

    Private Sub TrueDBGridMetodo_Click(sender As Object, e As EventArgs) Handles TrueDBGridMetodo.Click

    End Sub

    Private Sub TDGridDetallePlan_AfterColUpdate(
    ByVal sender As Object,
    ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs
) Handles TDGridDetallePlan.AfterColUpdate

        '==============================================================
        ' COLUMNA APLICAR
        '==============================================================

        If e.ColIndex = 11 Then

            If TDGridDetallePlan.Row < 0 Then
                Exit Sub
            End If


            Dim Detalles As List(Of DetallePlanPagoRecibo) =
            TryCast(
                TDGridDetallePlan.DataSource,
                List(Of DetallePlanPagoRecibo))


            If Detalles Is Nothing Then
                Exit Sub
            End If


            Dim IndiceActual As Integer =
            TDGridDetallePlan.Row


            If IndiceActual < 0 OrElse
           IndiceActual >= Detalles.Count Then

                Exit Sub

            End If


            Dim Detalle As DetallePlanPagoRecibo =
            Detalles(IndiceActual)


            '==========================================================
            ' SI SE ESTA MARCANDO LA CUOTA
            '==========================================================

            If Detalle.Aplicar Then

                '==========================================================
                ' VERIFICAR CUOTAS ANTERIORES
                '==========================================================

                For I As Integer = 0 To IndiceActual - 1

                    Dim CuotaAnterior As DetallePlanPagoRecibo =
            Detalles(I)

                    If CuotaAnterior.Saldo > 0D Then

                        If Not CuotaAnterior.Aplicar OrElse
               CuotaAnterior.MontoAAplicar <= 0D Then

                            MessageBox.Show(
                    "No puede aplicar la cuota " &
                    Detalle.NumeroCuota.ToString() &
                    " porque la cuota " &
                    CuotaAnterior.NumeroCuota.ToString() &
                    " todavía está pendiente.",
                    "Orden de cuotas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                            Detalle.Aplicar = False
                            Detalle.MontoAAplicar = 0D

                            TDGridDetallePlan.Refresh()

                            Exit Sub

                        End If

                    End If

                Next


                '==========================================================
                ' CALCULAR IMPORTE RECIBIDO
                '==========================================================

                Dim ImporteRecibido As Decimal = 0D

                If _MetodosPago IsNot Nothing Then

                    For Each Metodo As MetodoPagoRecibo In _MetodosPago

                        If Metodo IsNot Nothing Then
                            ImporteRecibido += Metodo.Monto
                        End If

                    Next

                End If


                '==========================================================
                ' CALCULAR LO YA APLICADO
                '==========================================================

                Dim ImporteAplicado As Decimal = 0D

                For Each D As DetallePlanPagoRecibo In Detalles

                    If D IsNot Nothing AndAlso
           D.Aplicar Then

                        ImporteAplicado += D.MontoAAplicar

                    End If

                Next


                ImporteAplicado -= Detalle.MontoAAplicar


                '==========================================================
                ' DINERO DISPONIBLE
                '==========================================================

                Dim Disponible As Decimal =
        ImporteRecibido - ImporteAplicado

                If Disponible < 0D Then
                    Disponible = 0D
                End If


                '==========================================================
                ' SUGERIR MONTO
                '==========================================================

                If Detalle.Saldo < Disponible Then

                    Detalle.MontoAAplicar =
            Detalle.Saldo

                Else

                    Detalle.MontoAAplicar =
            Disponible

                End If


            Else

                '==========================================================
                ' SE ESTA DESMARCANDO
                '==========================================================

                '----------------------------------------------------------
                ' VERIFICAR SI EXISTEN CUOTAS POSTERIORES APLICADAS
                '----------------------------------------------------------

                For I As Integer = IndiceActual + 1 To Detalles.Count - 1

                    Dim CuotaPosterior As DetallePlanPagoRecibo =
            Detalles(I)

                    If CuotaPosterior.Aplicar AndAlso
           CuotaPosterior.MontoAAplicar > 0D Then

                        MessageBox.Show(
                "No puede desmarcar la cuota " &
                Detalle.NumeroCuota.ToString() &
                " porque existe una aplicación en la cuota " &
                CuotaPosterior.NumeroCuota.ToString() &
                "." & vbCrLf & vbCrLf &
                "Primero debe desmarcar las cuotas posteriores.",
                "Orden de cuotas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                        '--------------------------------------------------
                        ' RESTAURAR LA CUOTA
                        '--------------------------------------------------

                        Detalle.Aplicar = True

                        TDGridDetallePlan.Refresh()

                        Exit Sub

                    End If

                Next


                '----------------------------------------------------------
                ' NO HAY CUOTAS POSTERIORES APLICADAS
                '----------------------------------------------------------

                Detalle.MontoAAplicar = 0D

            End If

            '==========================================================
            ' ACTUALIZAR GRID
            '==========================================================

            TDGridDetallePlan.Refresh()


            '==========================================================
            ' ACTUALIZAR IMPORTES
            '==========================================================

            CalcularImportesPlan()

        End If


        '==============================================================
        ' COLUMNA MONTO A APLICAR
        '==============================================================

        '==============================================================
        ' COLUMNA MONTO A APLICAR
        '==============================================================

        If e.ColIndex = 10 Then

            If TDGridDetallePlan.Row < 0 Then
                Exit Sub
            End If


            Dim DetalleMonto As DetallePlanPagoRecibo =
                TryCast(
                    TDGridDetallePlan.DataSource(TDGridDetallePlan.Row),
                    DetallePlanPagoRecibo)


            If DetalleMonto Is Nothing Then
                Exit Sub
            End If


            '==========================================================
            ' SI LA CUOTA NO ESTA MARCADA
            '==========================================================

            If Not DetalleMonto.Aplicar Then

                DetalleMonto.MontoAAplicar = 0D

                TDGridDetallePlan.Refresh()

                CalcularImportesPlan()

                Exit Sub

            End If


            '==========================================================
            ' NO PERMITIR MONTO NEGATIVO
            '==========================================================

            If DetalleMonto.MontoAAplicar < 0D Then

                MessageBox.Show(
                    "El monto a aplicar no puede ser negativo.",
                    "Monto a aplicar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                DetalleMonto.MontoAAplicar = 0D

                TDGridDetallePlan.Refresh()

                CalcularImportesPlan()

                Exit Sub

            End If


            '==========================================================
            ' CALCULAR IMPORTE RECIBIDO
            '==========================================================

            Dim ImporteRecibido As Decimal = 0D

            If _MetodosPago IsNot Nothing Then

                For Each Metodo As MetodoPagoRecibo In _MetodosPago

                    If Metodo IsNot Nothing Then

                        ImporteRecibido += Metodo.Monto

                    End If

                Next

            End If


            '==========================================================
            ' CALCULAR LO APLICADO POR LAS OTRAS CUOTAS
            '==========================================================

            Dim ImporteAplicadoOtros As Decimal = 0D

            Dim Detalles As List(Of DetallePlanPagoRecibo) =
                TryCast(
                    TDGridDetallePlan.DataSource,
                    List(Of DetallePlanPagoRecibo))


            If Detalles IsNot Nothing Then

                For Each D As DetallePlanPagoRecibo In Detalles

                    If D IsNot Nothing AndAlso
                       D.Aplicar Then

                        If D IsNot DetalleMonto Then

                            ImporteAplicadoOtros +=
                                D.MontoAAplicar

                        End If

                    End If

                Next

            End If


            '==========================================================
            ' CALCULAR DINERO DISPONIBLE PARA ESTA CUOTA
            '==========================================================

            Dim Disponible As Decimal =
                ImporteRecibido - ImporteAplicadoOtros


            If Disponible < 0D Then
                Disponible = 0D
            End If


            '==========================================================
            ' NO SUPERAR EL SALDO DE LA CUOTA
            '==========================================================

            If DetalleMonto.MontoAAplicar >
               DetalleMonto.Saldo Then

                DetalleMonto.MontoAAplicar =
                    DetalleMonto.Saldo

            End If


            '==========================================================
            ' NO SUPERAR EL DINERO DISPONIBLE
            '==========================================================

            If DetalleMonto.MontoAAplicar >
               Disponible Then

                DetalleMonto.MontoAAplicar =
                    Disponible

            End If


            '==========================================================
            ' ACTUALIZAR GRID
            '==========================================================

            TDGridDetallePlan.Refresh()


            '==========================================================
            ' ACTUALIZAR IMPORTES
            '==========================================================

            CalcularImportesPlan()

        End If

    End Sub

    Private Sub CalcularImportesPlan()

        Dim ImporteRecibido As Decimal = 0D
        Dim ImporteAplicado As Decimal = 0D

        '==========================================================
        ' IMPORTE RECIBIDO
        ' Es el TOTAL del recibo:
        ' suma de todos los métodos de pago.
        '==========================================================
        If _MetodosPago IsNot Nothing Then

            For Each Metodo As MetodoPagoRecibo In _MetodosPago

                If Metodo IsNot Nothing Then
                    ImporteRecibido += Metodo.Monto
                End If

            Next

        End If

        '==========================================================
        ' IMPORTE APLICADO
        ' Es la suma de lo que se está distribuyendo
        ' entre las cuotas seleccionadas.
        '==========================================================
        If TDGridDetallePlan.DataSource IsNot Nothing Then

            Dim Detalles As List(Of DetallePlanPagoRecibo) =
                TryCast(TDGridDetallePlan.DataSource,
                        List(Of DetallePlanPagoRecibo))

            If Detalles IsNot Nothing Then

                For Each Detalle As DetallePlanPagoRecibo In Detalles

                    If Detalle IsNot Nothing AndAlso Detalle.Aplicar Then

                        ImporteAplicado += Detalle.MontoAAplicar

                    End If

                Next

            End If

        End If

        '==========================================================
        ' MOSTRAR TOTALES
        '==========================================================
        Me.TxtImporteRecibido.Text =
            ImporteRecibido.ToString("N2")

        Me.TxtImporteAplicado.Text =
            ImporteAplicado.ToString("N2")

        Me.TxtPorAplicar.Text =
            (ImporteRecibido - ImporteAplicado).ToString("N2")

    End Sub

    Private Sub btnProcesar_Click(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs
) Handles btnProcesar.Click

        If Not PrepararAplicaciones() Then
            Exit Sub
        End If

        Me.DialogResult = DialogResult.OK

        Me.Close()

    End Sub
End Class