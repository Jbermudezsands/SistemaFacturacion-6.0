Imports System.Data
Imports System.Data.SqlClient
Public Class FrmPlanPago

    Private _NumeroFactura As String = ""
    Private _FechaFactura As Date
    Private _FechaVencimiento As Date
    Private _MontoCredito As Decimal
    Private _MonedaFactura As String = ""

    Private _TablaDetalle As DataTable
    Private _ActualizarVencimiento As Boolean = False
    Private _NumeroCredito As Integer = 0
    Private Function ExistePlanPagoActivo() As Boolean

        Using MiConexion As New SqlClient.SqlConnection(Conexion)

            MiConexion.Open()

            Dim Sql As String =
            "SELECT COUNT(*) " &
            "FROM PlanPagos " &
            "WHERE NumeroFactura = @NumeroFactura " &
            "AND FechaFactura = @FechaFactura " &
            "AND TipoFactura = @TipoFactura " &
            "AND Anulado = 0"

            Using Cmd As New SqlClient.SqlCommand(Sql, MiConexion)

                Cmd.Parameters.Add("@NumeroFactura",
                               SqlDbType.NVarChar, 50).Value =
                               _NumeroFactura

                Cmd.Parameters.Add("@FechaFactura",
                               SqlDbType.SmallDateTime).Value =
                               _FechaFactura

                Cmd.Parameters.Add("@TipoFactura",
                               SqlDbType.NVarChar, 50).Value =
                               "Factura"

                Return Convert.ToInt32(Cmd.ExecuteScalar()) > 0

            End Using

        End Using

    End Function
    Private Sub CargarPlanExistente(ByVal NumeroCredito As Integer)

        Try

            Using MiConexion As New SqlClient.SqlConnection(Conexion)

                MiConexion.Open()

                '---------------------------------------------------------
                ' CARGAR CABECERA DEL PLAN
                '---------------------------------------------------------

                Dim SqlPlan As String =
                "SELECT " &
                "NumeroCredito, " &
                "MontoCredito, " &
                "Cuotas, " &
                "FrecuenciaPago, " &
                "PorcentajeInteres, " &
                "PorcentajeMora, " &
                "PorcentajeMantenimientoValor, " &
                "MonedaFactura " &
                "FROM PlanPagos " &
                "WHERE NumeroCredito = @NumeroCredito"

                Using Cmd As New SqlClient.SqlCommand(SqlPlan, MiConexion)

                    Cmd.Parameters.Add("@NumeroCredito",
                                   SqlDbType.Int).Value =
                                   NumeroCredito

                    Using Reader As SqlClient.SqlDataReader =
                    Cmd.ExecuteReader()

                        If Reader.Read() Then

                            txtMontoCredito.Text =
                            Convert.ToDecimal(
                                Reader("MontoCredito")
                            ).ToString("N2")

                            nudCuotas.Value =
                            Convert.ToDecimal(
                                Reader("Cuotas")
                            )

                            cboFrecuencia.Text =
                            Reader("FrecuenciaPago").ToString()

                            nudInteres.Value =
                            Convert.ToDecimal(
                                Reader("PorcentajeInteres")
                            )

                            nudMora.Value =
                            Convert.ToDecimal(
                                Reader("PorcentajeMora")
                            )

                            nudMantenimiento.Value =
                            Convert.ToDecimal(
                                Reader("PorcentajeMantenimientoValor")
                            )

                            If Not IsDBNull(Reader("MonedaFactura")) Then
                                TxtMonedaFactura.Text =
                                Reader("MonedaFactura").ToString()
                            End If

                        End If

                    End Using

                End Using


                '---------------------------------------------------------
                ' CARGAR DETALLE
                '---------------------------------------------------------

                _TablaDetalle.Rows.Clear()

                Dim SqlDetalle As String =
                "SELECT " &
                "NumeroCuota, " &
                "FechaVencimiento, " &
                "MontoAbono, " &
                "MontoInteres, " &
                "MontoMora, " &
                "MontoMtoValor, " &
                "Pagado " &
                "FROM DetallePagos " &
                "WHERE NumeroCredito = @NumeroCredito " &
                "ORDER BY NumeroCuota"

                Using Cmd As New SqlClient.SqlCommand(SqlDetalle, MiConexion)

                    Cmd.Parameters.Add("@NumeroCredito",
                                   SqlDbType.Int).Value =
                                   NumeroCredito

                    Using Reader As SqlClient.SqlDataReader =
                    Cmd.ExecuteReader()

                        While Reader.Read()

                            Dim Fila As DataRow =
                            _TablaDetalle.NewRow()

                            Dim MontoAbono As Decimal =
                            Convert.ToDecimal(
                                Reader("MontoAbono")
                            )

                            Dim MontoInteres As Decimal =
                            Convert.ToDecimal(
                                Reader("MontoInteres")
                            )

                            Dim MontoMantenimiento As Decimal =
                            Convert.ToDecimal(
                                Reader("MontoMtoValor")
                            )

                            Dim MontoMora As Decimal =
                            Convert.ToDecimal(
                                Reader("MontoMora")
                            )

                            Dim TotalCuota As Decimal =
                            Math.Round(
                                MontoAbono +
                                MontoInteres +
                                MontoMantenimiento +
                                MontoMora,
                                2,
                                MidpointRounding.AwayFromZero
                            )

                            Fila("NumeroCuota") =
                            Convert.ToInt32(
                                Reader("NumeroCuota")
                            )

                            Fila("FechaVencimiento") =
                            Convert.ToDateTime(
                                Reader("FechaVencimiento")
                            )

                            Fila("MontoAbono") =
                            MontoAbono

                            Fila("MontoInteres") =
                            MontoInteres

                            Fila("MontoMtoValor") =
                            MontoMantenimiento

                            Fila("MontoMora") =
                            MontoMora

                            Fila("TotalCuota") =
                            TotalCuota

                            Fila("Saldo") =
                            TotalCuota

                            Fila("Pagado") =
                            Convert.ToBoolean(
                                Reader("Pagado")
                            )

                            _TablaDetalle.Rows.Add(Fila)

                        End While

                    End Using

                End Using

            End Using

            TrueDBGridDetallePlan.DataSource = _TablaDetalle
            _NumeroCredito = NumeroCredito
            ConfigurarGrid()

        Catch ex As Exception

            MessageBox.Show(
            "No fue posible cargar el plan de pago." &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "Plan de Pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub
    Private Function ObtenerNumeroCreditoExistente() As Integer

        Dim NumeroCredito As Integer = 0

        Using MiConexion As New SqlClient.SqlConnection(Conexion)

            MiConexion.Open()

            Dim Sql As String =
            "SELECT TOP 1 NumeroCredito " &
            "FROM PlanPagos " &
            "WHERE NumeroFactura = @NumeroFactura " &
            "AND FechaFactura = @FechaFactura " &
            "AND TipoFactura = @TipoFactura " &
            "AND Anulado = 0 " &
            "ORDER BY NumeroCredito DESC"

            Using Cmd As New SqlClient.SqlCommand(Sql, MiConexion)

                Cmd.Parameters.Add("@NumeroFactura",
                               SqlDbType.NVarChar, 50).Value =
                               _NumeroFactura

                Cmd.Parameters.Add("@FechaFactura",
                               SqlDbType.SmallDateTime).Value =
                               _FechaFactura

                Cmd.Parameters.Add("@TipoFactura",
                               SqlDbType.NVarChar, 50).Value =
                               "Factura"

                Dim Resultado = Cmd.ExecuteScalar()

                If Resultado IsNot Nothing AndAlso
               Not IsDBNull(Resultado) Then

                    NumeroCredito = Convert.ToInt32(Resultado)

                End If

            End Using

        End Using

        Return NumeroCredito

    End Function
    Private Function ObtenerDiasFrecuencia() As Integer

        Select Case cboFrecuencia.Text.Trim().ToUpper()

            Case "SEMANAL"
                Return 7

            Case "QUINCENAL"
                Return 15

            Case "MENSUAL"
                Return 30

            Case Else
                Return 0

        End Select

    End Function
    Private Function ObtenerPorcentaje(ByVal valor As Decimal) As Decimal

        If valor < 0D Then
            Return 0D
        End If

        Return valor

    End Function

    Public Sub New(ByVal NumeroFactura As String,
                   ByVal FechaFactura As Date,
                   ByVal FechaVencimiento As Date,
                   ByVal MontoCredito As Decimal,
                   ByVal MonedaFactura As String)

        InitializeComponent()

        _NumeroFactura = NumeroFactura
        _FechaFactura = FechaFactura
        _FechaVencimiento = FechaVencimiento
        _MontoCredito = MontoCredito
        _MonedaFactura = MonedaFactura


    End Sub

    Private Sub FrmPlanPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNumeroFactura.Text = _NumeroFactura
        dtpFechaFactura.Value = _FechaFactura
        dtpVencimientoActual.Value = _FechaVencimiento
        txtMontoCredito.Text = _MontoCredito.ToString("N2")
        TxtMonedaFactura.Text = _MonedaFactura


        PrepararTablaDetalle()
        ConfigurarGrid()

        If ExistePlanPagoActivo() Then
            btnCrear.Enabled = False
        Else
            btnCrear.Enabled = True
        End If


        Dim NumeroCredito As Integer = ObtenerNumeroCreditoExistente()

        If NumeroCredito > 0 Then

            CargarPlanExistente(NumeroCredito)

            btnCrear.Enabled = False
            btnAnular.Enabled = True

        Else

            _NumeroCredito = 0

            btnCrear.Enabled = True
            btnAnular.Enabled = False

        End If

    End Sub

    Private Sub PrepararTablaDetalle()

        _TablaDetalle = New DataTable("DetallePlanPago")

        _TablaDetalle.Columns.Add("NumeroCuota", GetType(Integer))
        _TablaDetalle.Columns.Add("FechaVencimiento", GetType(Date))
        _TablaDetalle.Columns.Add("MontoAbono", GetType(Decimal))
        _TablaDetalle.Columns.Add("MontoInteres", GetType(Decimal))
        _TablaDetalle.Columns.Add("MontoMtoValor", GetType(Decimal))
        _TablaDetalle.Columns.Add("MontoMora", GetType(Decimal))
        _TablaDetalle.Columns.Add("TotalCuota", GetType(Decimal))
        _TablaDetalle.Columns.Add("Saldo", GetType(Decimal))
        _TablaDetalle.Columns.Add("Pagado", GetType(Boolean))

        TrueDBGridDetallePlan.DataSource = _TablaDetalle

    End Sub

    Private Sub ConfigurarGrid()

        With TrueDBGridDetallePlan

            .AllowUpdate = False
            .AllowAddNew = False
            .AllowDelete = False

            .Columns("NumeroCuota").Caption = "Cuota"
            .Columns("FechaVencimiento").Caption = "Vencimiento"
            .Columns("MontoAbono").Caption = "Abono"
            .Columns("MontoInteres").Caption = "Interés"
            .Columns("MontoMtoValor").Caption = "Mant. Valor"
            .Columns("MontoMora").Caption = "Mora"
            .Columns("TotalCuota").Caption = "Total"
            .Columns("Saldo").Caption = "Saldo"
            .Columns("Pagado").Caption = "Pagado"

            .Columns("FechaVencimiento").NumberFormat = "dd/MM/yyyy"

            .Columns("MontoAbono").NumberFormat = "N2"
            .Columns("MontoInteres").NumberFormat = "N2"
            .Columns("MontoMtoValor").NumberFormat = "N2"
            .Columns("MontoMora").NumberFormat = "N2"
            .Columns("TotalCuota").NumberFormat = "N2"
            .Columns("Saldo").NumberFormat = "N2"

            'Campo interno; el usuario no lo modifica

            .Splits.Item(0).DisplayColumns(8).Visible = False

            With .Splits.Item(0).DisplayColumns

                .Item(0).Width = 50      'Cuota
                .Item(1).Width = 80     'Vencimiento
                .Item(2).Width = 80     'Abono
                .Item(3).Width = 80     'Interés
                .Item(4).Width = 80     'Mant. Valor
                .Item(5).Width = 80    'Mora
                .Item(6).Width = 100     'Total
                .Item(7).Width = 100    'Saldo
                .Item(8).Width = 80      'Pagado

            End With


        End With



    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub pnlContenedor_Paint(sender As Object, e As PaintEventArgs) Handles pnlContenedor.Paint

    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        Try

            '---------------------------------------------------------
            ' VALIDACIONES
            '---------------------------------------------------------

            If _MontoCredito <= 0D Then
                MessageBox.Show("El monto del crédito debe ser mayor que cero.",
                            "Plan de Pago",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            If nudCuotas.Value <= 0 Then
                MessageBox.Show("Debe indicar el número de cuotas.",
                            "Plan de Pago",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim DiasFrecuencia As Integer = ObtenerDiasFrecuencia()

            If DiasFrecuencia <= 0 Then
                MessageBox.Show("Debe seleccionar una frecuencia de pago.",
                            "Plan de Pago",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If


            '---------------------------------------------------------
            ' DATOS DEL PLAN
            '---------------------------------------------------------

            Dim NumeroCuotas As Integer = CInt(nudCuotas.Value)

            Dim PorcentajeInteres As Decimal =
            ObtenerPorcentaje(nudInteres.Value)

            Dim PorcentajeMantenimiento As Decimal =
            ObtenerPorcentaje(nudMantenimiento.Value)


            '---------------------------------------------------------
            ' CALCULO DEL INTERES LINEAL
            '---------------------------------------------------------

            Dim InteresTotal As Decimal =
            Math.Round(
                _MontoCredito * (PorcentajeInteres / 100D),
                2,
                MidpointRounding.AwayFromZero
            )


            '---------------------------------------------------------
            ' CALCULO DEL MANTENIMIENTO LINEAL
            '---------------------------------------------------------

            Dim MantenimientoTotal As Decimal =
            Math.Round(
                _MontoCredito * (PorcentajeMantenimiento / 100D),
                2,
                MidpointRounding.AwayFromZero
            )


            '---------------------------------------------------------
            ' VALOR POR CUOTA
            '---------------------------------------------------------

            Dim AbonoCuota As Decimal =
            Math.Round(
                _MontoCredito / NumeroCuotas,
                2,
                MidpointRounding.AwayFromZero
            )

            Dim InteresCuota As Decimal =
            Math.Round(
                InteresTotal / NumeroCuotas,
                2,
                MidpointRounding.AwayFromZero
            )

            Dim MantenimientoCuota As Decimal =
            Math.Round(
                MantenimientoTotal / NumeroCuotas,
                2,
                MidpointRounding.AwayFromZero
            )


            '---------------------------------------------------------
            ' LIMPIAR EL GRID
            '---------------------------------------------------------

            If _TablaDetalle Is Nothing Then
                PrepararTablaDetalle()
            Else
                _TablaDetalle.Rows.Clear()
            End If


            '---------------------------------------------------------
            ' VARIABLES PARA CONTROLAR REDONDEOS
            '---------------------------------------------------------

            Dim TotalAbonoGenerado As Decimal = 0D
            Dim TotalInteresGenerado As Decimal = 0D
            Dim TotalMantenimientoGenerado As Decimal = 0D


            '---------------------------------------------------------
            ' GENERAR LAS CUOTAS
            '---------------------------------------------------------

            For i As Integer = 1 To NumeroCuotas

                Dim Abono As Decimal
                Dim Interes As Decimal
                Dim Mantenimiento As Decimal


                '-----------------------------------------------------
                ' ULTIMA CUOTA
                ' Ajustamos el redondeo para que el total coincida
                ' exactamente con el crédito.
                '-----------------------------------------------------

                If i = NumeroCuotas Then

                    Abono = _MontoCredito - TotalAbonoGenerado

                    Interes = InteresTotal - TotalInteresGenerado

                    Mantenimiento =
                    MantenimientoTotal -
                    TotalMantenimientoGenerado

                Else

                    Abono = AbonoCuota
                    Interes = InteresCuota
                    Mantenimiento = MantenimientoCuota

                End If


                Abono = Math.Round(
                Abono,
                2,
                MidpointRounding.AwayFromZero
            )

                Interes = Math.Round(
                Interes,
                2,
                MidpointRounding.AwayFromZero
            )

                Mantenimiento = Math.Round(
                Mantenimiento,
                2,
                MidpointRounding.AwayFromZero
            )


                '-----------------------------------------------------
                ' FECHA DE VENCIMIENTO
                '-----------------------------------------------------

                Dim FechaVencimiento As Date =
                _FechaFactura.AddDays(
                    DiasFrecuencia * i
                )


                '-----------------------------------------------------
                ' MORA
                ' La mora no se genera al crear el plan.
                ' Se calculará posteriormente si existe atraso.
                '-----------------------------------------------------

                Dim Mora As Decimal = 0D


                '-----------------------------------------------------
                ' TOTAL DE LA CUOTA
                '-----------------------------------------------------

                Dim TotalCuota As Decimal =
                Math.Round(
                    Abono +
                    Interes +
                    Mantenimiento +
                    Mora,
                    2,
                    MidpointRounding.AwayFromZero
                )


                '-----------------------------------------------------
                ' SALDO INICIAL
                ' Todavía no existen pagos.
                '-----------------------------------------------------

                Dim Saldo As Decimal = TotalCuota


                '-----------------------------------------------------
                ' AGREGAR AL DATATABLE
                '-----------------------------------------------------

                Dim Fila As DataRow =
                                   _TablaDetalle.NewRow()

                Fila("NumeroCuota") = i
                Fila("FechaVencimiento") = FechaVencimiento
                Fila("MontoAbono") = Abono
                Fila("MontoInteres") = Interes
                Fila("MontoMtoValor") = Mantenimiento
                Fila("MontoMora") = Mora
                Fila("TotalCuota") = TotalCuota
                Fila("Saldo") = Saldo
                Fila("Pagado") = False

                _TablaDetalle.Rows.Add(Fila)


                '-----------------------------------------------------
                ' ACUMULAR
                '-----------------------------------------------------

                TotalAbonoGenerado += Abono
                TotalInteresGenerado += Interes
                TotalMantenimientoGenerado += Mantenimiento

            Next


            '---------------------------------------------------------
            ' ACTUALIZAR GRID
            '---------------------------------------------------------

            TrueDBGridDetallePlan.DataSource = _TablaDetalle


            '---------------------------------------------------------
            ' CONFIGURAR GRID NUEVAMENTE
            '---------------------------------------------------------

            ConfigurarGrid()


            '---------------------------------------------------------
            ' VALIDAR FECHA FINAL CONTRA VENCIMIENTO DE FACTURA
            '---------------------------------------------------------

            If _TablaDetalle.Rows.Count > 0 Then

                Dim UltimaFecha As Date =
                CDate(
                    _TablaDetalle.Rows(
                        _TablaDetalle.Rows.Count - 1
                    )("FechaVencimiento")
                )

                If UltimaFecha > _FechaVencimiento Then

                    MessageBox.Show(
                    "El plan de pago supera la fecha de vencimiento actual de la factura." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "Vencimiento actual: " &
                    _FechaVencimiento.ToString("dd/MM/yyyy") &
                    Environment.NewLine &
                    "Última cuota: " &
                    UltimaFecha.ToString("dd/MM/yyyy") &
                    Environment.NewLine &
                    Environment.NewLine &
                    "Al guardar el plan podrá actualizarse el vencimiento de la factura.",
                    "Plan de Pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

                End If

            End If


        Catch ex As Exception

            MessageBox.Show(
            "Error al generar el plan de pago:" &
            Environment.NewLine &
            ex.Message,
            "Plan de Pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim MiConexion As SqlClient.SqlConnection = Nothing
        Dim Transaccion As SqlClient.SqlTransaction = Nothing

        Try

            '=========================================================
            ' VALIDACIONES
            '=========================================================

            If _TablaDetalle Is Nothing OrElse _TablaDetalle.Rows.Count = 0 Then

                MessageBox.Show(
                "Debe generar el plan de pago antes de guardar.",
                "Plan de Pago",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If


            If String.IsNullOrWhiteSpace(_NumeroFactura) Then

                MessageBox.Show(
                "No se ha definido el número de factura.",
                "Plan de Pago",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If


            If String.IsNullOrWhiteSpace(_MonedaFactura) Then

                MessageBox.Show(
                "La factura no tiene definida la moneda.",
                "Plan de Pago",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

                Exit Sub

            End If


            '=========================================================
            ' DETERMINAR SI EL VENCIMIENTO DEBE ACTUALIZARSE
            '=========================================================

            Dim UltimaFecha As Date =
            CDate(
                _TablaDetalle.Rows(
                    _TablaDetalle.Rows.Count - 1
                )("FechaVencimiento")
            )

            Dim ActualizarVencimiento As Boolean = False


            If UltimaFecha > _FechaVencimiento Then

                Dim Respuesta As DialogResult =
                MessageBox.Show(
                    "La última cuota del plan vence el " &
                    UltimaFecha.ToString("dd/MM/yyyy") &
                    "." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "El vencimiento actual de la factura es " &
                    _FechaVencimiento.ToString("dd/MM/yyyy") &
                    "." &
                    Environment.NewLine &
                    Environment.NewLine &
                    "¿Desea actualizar el vencimiento de la factura " &
                    "a la fecha de la última cuota?",
                    "Actualizar vencimiento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)

                If Respuesta = DialogResult.Yes Then
                    ActualizarVencimiento = True
                End If

            End If


            '=========================================================
            ' CONEXION
            '=========================================================

            MiConexion = New SqlClient.SqlConnection(Conexion)

            MiConexion.Open()

            Transaccion = MiConexion.BeginTransaction()


            '=========================================================
            ' VERIFICAR QUE LA FACTURA EXISTA
            '=========================================================

            Dim SqlExisteFactura As String =
            "SELECT COUNT(*) " &
            "FROM Facturas " &
            "WHERE Numero_Factura = @NumeroFactura " &
            "AND Fecha_Factura = @FechaFactura " &
            "AND Tipo_Factura = @TipoFactura"


            Using Cmd As New SqlClient.SqlCommand(
            SqlExisteFactura,
            MiConexion,
            Transaccion)

                Cmd.Parameters.Add("@NumeroFactura",
                               SqlDbType.NVarChar, 50).Value =
                               _NumeroFactura

                Cmd.Parameters.Add("@FechaFactura",
                               SqlDbType.SmallDateTime).Value =
                               _FechaFactura

                Cmd.Parameters.Add("@TipoFactura",
                               SqlDbType.NVarChar, 50).Value =
                               "Factura"

                Dim Existe As Integer =
                Convert.ToInt32(Cmd.ExecuteScalar())

                If Existe = 0 Then

                    Throw New Exception(
                    "La factura ya no existe en la base de datos.")

                End If

            End Using


            '=========================================================
            ' VERIFICAR PLAN ACTIVO EXISTENTE
            '=========================================================

            Dim SqlPlanExistente As String =
            "SELECT COUNT(*) " &
            "FROM PlanPagos " &
            "WHERE NumeroFactura = @NumeroFactura " &
            "AND FechaFactura = @FechaFactura " &
            "AND TipoFactura = @TipoFactura " &
            "AND Anulado = 0"


            Using Cmd As New SqlClient.SqlCommand(
            SqlPlanExistente,
            MiConexion,
            Transaccion)

                Cmd.Parameters.Add("@NumeroFactura",
                               SqlDbType.NVarChar, 50).Value =
                               _NumeroFactura

                Cmd.Parameters.Add("@FechaFactura",
                               SqlDbType.SmallDateTime).Value =
                               _FechaFactura

                Cmd.Parameters.Add("@TipoFactura",
                               SqlDbType.NVarChar, 50).Value =
                               "Factura"

                Dim ExistePlan As Integer =
                Convert.ToInt32(Cmd.ExecuteScalar())

                If ExistePlan > 0 Then

                    Throw New Exception(
                    "La factura ya tiene un plan de pago activo.")

                End If

            End Using


            '=========================================================
            ' OBTENER NUMERO DE CREDITO
            '=========================================================

            'IMPORTANTE:
            'BuscaConsecutivo utiliza su propia conexión.
            'Por eso lo obtenemos antes de comenzar a insertar.

            Dim NumeroCredito As Integer

            NumeroCredito =
            CInt(BuscaConsecutivo("NumeroCredito"))


            If NumeroCredito <= 0 Then

                Throw New Exception(
                "No fue posible obtener el número de crédito.")

            End If


            '=========================================================
            ' INSERTAR PLANPAGOS
            '=========================================================

            Dim SqlPlan As String =
            "INSERT INTO PlanPagos " &
            "(NumeroCredito, " &
            " NumeroFactura, " &
            " FechaFactura, " &
            " TipoFactura, " &
            " FechaCredito, " &
            " MontoCredito, " &
            " Cuotas, " &
            " FrecuenciaPago, " &
            " DiasFrecuencia, " &
            " PorcentajeInteres, " &
            " PorcentajeMora, " &
            " PorcentajeMantenimientoValor, " &
            " MonedaFactura, " &
            " Anulado) " &
            "VALUES " &
            "(@NumeroCredito, " &
            " @NumeroFactura, " &
            " @FechaFactura, " &
            " @TipoFactura, " &
            " @FechaCredito, " &
            " @MontoCredito, " &
            " @Cuotas, " &
            " @FrecuenciaPago, " &
            " @DiasFrecuencia, " &
            " @PorcentajeInteres, " &
            " @PorcentajeMora, " &
            " @PorcentajeMantenimientoValor, " &
            " @MonedaFactura, " &
            " 0)"


            Using Cmd As New SqlClient.SqlCommand(
            SqlPlan,
            MiConexion,
            Transaccion)

                Cmd.Parameters.Add("@NumeroCredito",
                               SqlDbType.Int).Value =
                               NumeroCredito

                Cmd.Parameters.Add("@NumeroFactura",
                               SqlDbType.NVarChar, 50).Value =
                               _NumeroFactura

                Cmd.Parameters.Add("@FechaFactura",
                               SqlDbType.SmallDateTime).Value =
                               _FechaFactura

                Cmd.Parameters.Add("@TipoFactura",
                               SqlDbType.NVarChar, 50).Value =
                               "Factura"

                Cmd.Parameters.Add("@FechaCredito",
                               SqlDbType.SmallDateTime).Value =
                               Date.Now

                Cmd.Parameters.Add("@MontoCredito",
                               SqlDbType.Decimal).Value =
                               _MontoCredito

                Cmd.Parameters("@MontoCredito").Precision = 18
                Cmd.Parameters("@MontoCredito").Scale = 2

                Cmd.Parameters.Add("@Cuotas",
                               SqlDbType.Int).Value =
                               CInt(nudCuotas.Value)

                Cmd.Parameters.Add("@FrecuenciaPago",
                               SqlDbType.NVarChar, 20).Value =
                               cboFrecuencia.Text.Trim()

                Cmd.Parameters.Add("@DiasFrecuencia",
                               SqlDbType.Int).Value =
                               ObtenerDiasFrecuencia()

                Cmd.Parameters.Add("@PorcentajeInteres",
                               SqlDbType.Decimal).Value =
                               nudInteres.Value

                Cmd.Parameters("@PorcentajeInteres").Precision = 9
                Cmd.Parameters("@PorcentajeInteres").Scale = 4

                Cmd.Parameters.Add("@PorcentajeMora",
                               SqlDbType.Decimal).Value =
                               nudMora.Value

                Cmd.Parameters("@PorcentajeMora").Precision = 9
                Cmd.Parameters("@PorcentajeMora").Scale = 4

                Cmd.Parameters.Add("@PorcentajeMantenimientoValor",
                               SqlDbType.Decimal).Value =
                               nudMantenimiento.Value

                Cmd.Parameters("@PorcentajeMantenimientoValor").Precision = 9
                Cmd.Parameters("@PorcentajeMantenimientoValor").Scale = 4

                Cmd.Parameters.Add("@MonedaFactura",
                               SqlDbType.NVarChar, 50).Value =
                               _MonedaFactura

                Cmd.ExecuteNonQuery()

            End Using


            '=========================================================
            ' INSERTAR DETALLEPAGOS
            '=========================================================

            Dim SqlDetalle As String =
            "INSERT INTO DetallePagos " &
            "(NumeroCredito, " &
            " NumeroCuota, " &
            " FechaVencimiento, " &
            " MontoAbono, " &
            " MontoInteres, " &
            " MontoMora, " &
            " MontoMtoValor, " &
            " Pagado) " &
            "VALUES " &
            "(@NumeroCredito, " &
            " @NumeroCuota, " &
            " @FechaVencimiento, " &
            " @MontoAbono, " &
            " @MontoInteres, " &
            " @MontoMora, " &
            " @MontoMtoValor, " &
            " 0)"


            For Each Fila As DataRow In _TablaDetalle.Rows

                Using Cmd As New SqlClient.SqlCommand(
                SqlDetalle,
                MiConexion,
                Transaccion)

                    Cmd.Parameters.Add("@NumeroCredito",
                                   SqlDbType.Int).Value =
                                   NumeroCredito

                    Cmd.Parameters.Add("@NumeroCuota",
                                   SqlDbType.Int).Value =
                                   CInt(Fila("NumeroCuota"))

                    Cmd.Parameters.Add("@FechaVencimiento",
                                   SqlDbType.SmallDateTime).Value =
                                   CDate(Fila("FechaVencimiento"))

                    Cmd.Parameters.Add("@MontoAbono",
                                   SqlDbType.Decimal).Value =
                                   CDec(Fila("MontoAbono"))

                    Cmd.Parameters("@MontoAbono").Precision = 18
                    Cmd.Parameters("@MontoAbono").Scale = 2

                    Cmd.Parameters.Add("@MontoInteres",
                                   SqlDbType.Decimal).Value =
                                   CDec(Fila("MontoInteres"))

                    Cmd.Parameters("@MontoInteres").Precision = 18
                    Cmd.Parameters("@MontoInteres").Scale = 2

                    Cmd.Parameters.Add("@MontoMora",
                                   SqlDbType.Decimal).Value =
                                   CDec(Fila("MontoMora"))

                    Cmd.Parameters("@MontoMora").Precision = 18
                    Cmd.Parameters("@MontoMora").Scale = 2

                    Cmd.Parameters.Add("@MontoMtoValor",
                                   SqlDbType.Decimal).Value =
                                   CDec(Fila("MontoMtoValor"))

                    Cmd.Parameters("@MontoMtoValor").Precision = 18
                    Cmd.Parameters("@MontoMtoValor").Scale = 2

                    Cmd.ExecuteNonQuery()

                End Using

            Next


            '=========================================================
            ' ACTUALIZAR FACTURA
            '=========================================================

            Dim SqlFactura As String =
            "UPDATE Facturas " &
            "SET AplicarCtasXCobrar = 1"


            If ActualizarVencimiento Then

                SqlFactura &= ", Fecha_Vencimiento = @NuevaFechaVencimiento"

            End If


            SqlFactura &=
            " WHERE Numero_Factura = @NumeroFactura " &
            "AND Fecha_Factura = @FechaFactura " &
            "AND Tipo_Factura = @TipoFactura"


            Using Cmd As New SqlClient.SqlCommand(
            SqlFactura,
            MiConexion,
            Transaccion)

                Cmd.Parameters.Add("@NumeroFactura",
                               SqlDbType.NVarChar, 50).Value =
                               _NumeroFactura

                Cmd.Parameters.Add("@FechaFactura",
                               SqlDbType.SmallDateTime).Value =
                               _FechaFactura

                Cmd.Parameters.Add("@TipoFactura",
                               SqlDbType.NVarChar, 50).Value =
                               "Factura"

                If ActualizarVencimiento Then

                    Cmd.Parameters.Add("@NuevaFechaVencimiento",
                                   SqlDbType.SmallDateTime).Value =
                                   UltimaFecha

                End If

                Cmd.ExecuteNonQuery()

            End Using


            '=========================================================
            ' CONFIRMAR TRANSACCION
            '=========================================================

            Transaccion.Commit()
            Transaccion = Nothing


            MessageBox.Show(
            "Plan de pago creado correctamente." &
            Environment.NewLine &
            Environment.NewLine &
            "Número de crédito: " &
            NumeroCredito.ToString(),
            "Plan de Pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)


            Me.DialogResult = DialogResult.OK
            Me.Close()


        Catch ex As Exception

            '=========================================================
            ' DESHACER TRANSACCION
            '=========================================================

            If Transaccion IsNot Nothing Then

                Try
                    Transaccion.Rollback()
                Catch
                End Try

            End If


            MessageBox.Show(
            "No fue posible guardar el plan de pago." &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "Plan de Pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)


        Finally

            If MiConexion IsNot Nothing Then

                If MiConexion.State <> ConnectionState.Closed Then
                    MiConexion.Close()
                End If

                MiConexion.Dispose()

            End If

        End Try

    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click

        Dim MiConexion As SqlClient.SqlConnection = Nothing
        Dim Transaccion As SqlClient.SqlTransaction = Nothing

        Try

            '=========================================================
            ' VALIDAR QUE EXISTA UN PLAN
            '=========================================================

            If _NumeroCredito <= 0 Then

                MessageBox.Show(
                "No existe un plan de pago para anular.",
                "Plan de Pago",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

                Exit Sub

            End If


            '=========================================================
            ' CONFIRMACION
            '=========================================================

            Dim Respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro que desea anular este plan de pago?" &
                Environment.NewLine &
                Environment.NewLine &
                "Número de crédito: " &
                _NumeroCredito.ToString() &
                Environment.NewLine &
                Environment.NewLine &
                "Las cuotas que ya fueron pagadas se conservarán." &
                Environment.NewLine &
                "Las cuotas pendientes serán anuladas." &
                Environment.NewLine &
                Environment.NewLine &
                "Esta operación no elimina el historial.",
                "Anular Plan de Pago",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)

            If Respuesta <> DialogResult.Yes Then
                Exit Sub
            End If


            '=========================================================
            ' CONEXION Y TRANSACCION
            '=========================================================

            MiConexion = New SqlClient.SqlConnection(Conexion)

            MiConexion.Open()

            Transaccion = MiConexion.BeginTransaction()


            '=========================================================
            ' VERIFICAR QUE EL PLAN SIGA ACTIVO
            '=========================================================

            Dim SqlVerificar As String =
            "SELECT COUNT(*) " &
            "FROM PlanPagos " &
            "WHERE NumeroCredito = @NumeroCredito " &
            "AND Anulado = 0"

            Using Cmd As New SqlClient.SqlCommand(
            SqlVerificar,
            MiConexion,
            Transaccion)

                Cmd.Parameters.Add("@NumeroCredito",
                               SqlDbType.Int).Value =
                               _NumeroCredito

                Dim Existe As Integer =
                Convert.ToInt32(Cmd.ExecuteScalar())

                If Existe = 0 Then

                    Throw New Exception(
                    "El plan ya se encuentra anulado.")

                End If

            End Using


            '=========================================================
            ' ANULAR PLAN
            '=========================================================

            Dim SqlPlan As String =
            "UPDATE PlanPagos " &
            "SET Anulado = 1 " &
            "WHERE NumeroCredito = @NumeroCredito " &
            "AND Anulado = 0"

            Using Cmd As New SqlClient.SqlCommand(
            SqlPlan,
            MiConexion,
            Transaccion)

                Cmd.Parameters.Add("@NumeroCredito",
                               SqlDbType.Int).Value =
                               _NumeroCredito

                Cmd.ExecuteNonQuery()

            End Using


            '=========================================================
            ' ANULAR SOLAMENTE CUOTAS PENDIENTES
            '=========================================================

            Dim SqlDetalle As String =
            "UPDATE DetallePagos " &
            "SET Anulado = 1 " &
            "WHERE NumeroCredito = @NumeroCredito " &
            "AND Pagado = 0 " &
            "AND Anulado = 0"

            Using Cmd As New SqlClient.SqlCommand(
            SqlDetalle,
            MiConexion,
            Transaccion)

                Cmd.Parameters.Add("@NumeroCredito",
                               SqlDbType.Int).Value =
                               _NumeroCredito

                Cmd.ExecuteNonQuery()

            End Using


            '=========================================================
            ' ACTUALIZAR FACTURA
            ' YA NO TIENE PLAN ACTIVO
            '=========================================================

            Dim SqlFactura As String =
            "UPDATE Facturas " &
            "SET AplicarCtasXCobrar = 0 " &
            "WHERE Numero_Factura = @NumeroFactura " &
            "AND Fecha_Factura = @FechaFactura " &
            "AND Tipo_Factura = @TipoFactura"

            Using Cmd As New SqlClient.SqlCommand(
            SqlFactura,
            MiConexion,
            Transaccion)

                Cmd.Parameters.Add("@NumeroFactura",
                               SqlDbType.NVarChar, 50).Value =
                               _NumeroFactura

                Cmd.Parameters.Add("@FechaFactura",
                               SqlDbType.SmallDateTime).Value =
                               _FechaFactura

                Cmd.Parameters.Add("@TipoFactura",
                               SqlDbType.NVarChar, 50).Value =
                               "Factura"

                Cmd.ExecuteNonQuery()

            End Using


            '=========================================================
            ' CONFIRMAR
            '=========================================================

            Transaccion.Commit()
            Transaccion = Nothing


            MessageBox.Show(
            "El plan de pago fue anulado correctamente." &
            Environment.NewLine &
            Environment.NewLine &
            "Número de crédito: " &
            _NumeroCredito.ToString(),
            "Plan de Pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)


            Me.DialogResult = DialogResult.OK
            Me.Close()


        Catch ex As Exception

            If Transaccion IsNot Nothing Then

                Try
                    Transaccion.Rollback()
                Catch
                End Try

            End If


            MessageBox.Show(
            "No fue posible anular el plan de pago." &
            Environment.NewLine &
            Environment.NewLine &
            ex.Message,
            "Anular Plan de Pago",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)


        Finally

            If MiConexion IsNot Nothing Then

                If MiConexion.State <> ConnectionState.Closed Then
                    MiConexion.Close()
                End If

                MiConexion.Dispose()

            End If

        End Try

    End Sub
End Class