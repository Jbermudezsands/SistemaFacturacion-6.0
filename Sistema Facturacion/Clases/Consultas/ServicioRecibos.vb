Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text.RegularExpressions



Public Class ServicioRecibos

    Private ReadOnly _Conexion As String


    Public Sub New(ByVal cadenaConexion As String)
        _Conexion = cadenaConexion
    End Sub

    ''' <summary>
    ''' Graba un detalle de recibo generado automáticamente desde Planilla
    ''' y devuelve el idDetalleRecibo generado.
    ''' </summary>
    Public Function GrabarDetalleReciboPlanilla(
    ByVal NumeroRecibo As String,
    ByVal FechaRecibo As Date,
    ByVal NumeroFactura As String,
    ByVal MontoPagado As Decimal,
    ByVal NombrePago As String,
    ByVal Descripcion As String,
    ByVal NumeroTarjeta As String,
    ByVal FechaVence As Nullable(Of Date),
    ByVal MontoFactura As Decimal,
    ByVal AplicaFactura As Decimal,
    ByVal SaldoFactura As Decimal,
    ByVal Estado As Integer,
    ByVal NumeroNota As String
) As Decimal

        Dim IdDetalleRecibo As Decimal = 0D

        Try

            Using cn As New SqlClient.SqlConnection(Conexion)

                cn.Open()

                Dim Sql As String = ""

                Sql = "INSERT INTO DetalleRecibo " &
                  "(Numero_Recibo, Fecha_Recibo, Numero_Factura, MontoPagado, " &
                  " NombrePago, Descripcion, NumeroTarjeta, FechaVence, " &
                  " MontoFactura, AplicaFactura, SaldoFactura, Estado, NumeroNota) " &
                  "VALUES " &
                  "(@NumeroRecibo, @FechaRecibo, @NumeroFactura, @MontoPagado, " &
                  " @NombrePago, @Descripcion, @NumeroTarjeta, @FechaVence, " &
                  " @MontoFactura, @AplicaFactura, @SaldoFactura, @Estado, @NumeroNota); " &
                  "SELECT CAST(SCOPE_IDENTITY() AS NUMERIC(18,0));"

                Using cmd As New SqlClient.SqlCommand(Sql, cn)

                    cmd.Parameters.Add("@NumeroRecibo", SqlDbType.NVarChar, 50).Value =
                    If(NumeroRecibo, "")

                    cmd.Parameters.Add("@FechaRecibo", SqlDbType.SmallDateTime).Value =
                    FechaRecibo

                    cmd.Parameters.Add("@NumeroFactura", SqlDbType.NVarChar, 50).Value =
                    If(NumeroFactura, "")

                    cmd.Parameters.Add("@MontoPagado", SqlDbType.Decimal).Value =
                    MontoPagado

                    cmd.Parameters.Add("@NombrePago", SqlDbType.NVarChar, 100).Value =
                    If(NombrePago, "")

                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 250).Value =
                    If(Descripcion, "")

                    cmd.Parameters.Add("@NumeroTarjeta", SqlDbType.NVarChar, 50).Value =
                    If(NumeroTarjeta, "")

                    If FechaVence.HasValue Then
                        cmd.Parameters.Add("@FechaVence", SqlDbType.SmallDateTime).Value =
                        FechaVence.Value
                    Else
                        cmd.Parameters.Add("@FechaVence", SqlDbType.SmallDateTime).Value =
                        DBNull.Value
                    End If

                    Dim pMontoFactura = cmd.Parameters.Add("@MontoFactura", SqlDbType.Decimal)
                    pMontoFactura.Precision = 18
                    pMontoFactura.Scale = 2
                    pMontoFactura.Value = MontoFactura

                    Dim pAplicaFactura = cmd.Parameters.Add("@AplicaFactura", SqlDbType.Decimal)
                    pAplicaFactura.Precision = 18
                    pAplicaFactura.Scale = 2
                    pAplicaFactura.Value = AplicaFactura

                    Dim pSaldoFactura = cmd.Parameters.Add("@SaldoFactura", SqlDbType.Decimal)
                    pSaldoFactura.Precision = 18
                    pSaldoFactura.Scale = 2
                    pSaldoFactura.Value = SaldoFactura

                    cmd.Parameters.Add("@Estado", SqlDbType.Int).Value =
                    Estado

                    cmd.Parameters.Add("@NumeroNota", SqlDbType.NVarChar, 50).Value =
                    If(NumeroNota, "")

                    Dim Resultado As Object = cmd.ExecuteScalar()

                    If Resultado IsNot Nothing AndAlso Not IsDBNull(Resultado) Then
                        IdDetalleRecibo = Convert.ToDecimal(Resultado)
                    End If

                End Using

            End Using

        Catch ex As Exception

            Throw New Exception(
            "Error al grabar el detalle del recibo de Planilla: " &
            ex.Message, ex)

        End Try

        Return IdDetalleRecibo

    End Function

    Public Function ObtenerNumeroReciboPlanilla(
    ByVal serie As String) As String

        If String.IsNullOrWhiteSpace(serie) Then
            Return ""
        End If

        Dim consecutivo As Double

        consecutivo =
        BuscaConsecutivoSerie(
            "Recibo",
            serie)

        If consecutivo <= 0 Then
            Return ""
        End If

        Return serie.Trim() &
           Format(consecutivo, "0000#")

    End Function


    Public Function GrabarRecibo(
    ByVal numeroRecibo As String,
    ByVal fecha As Date,
    ByVal codigoCliente As String,
    ByVal codigoCajero As String,
    ByVal subtotal As Decimal,
    ByVal descuento As Decimal,
    ByVal total As Decimal,
    ByVal nombreCliente As String,
    ByVal apellidosCliente As String,
    ByVal direccionCliente As String,
    ByVal telefonoCliente As String,
    ByVal moneda As String,
    ByVal observaciones As String) As Boolean

        Dim estadoRecibo As String
        Dim fechaRecibo As Date = fecha.Date

        estadoRecibo = ExisteRecibo(fechaRecibo, numeroRecibo)

        'No permitimos grabar sobre un recibo que existe
        'con la misma numeración pero con otra fecha.
        If estadoRecibo = "ExisteReciboDifFecha" Then
            Return False
        End If

        Using MiConexion As New SqlClient.SqlConnection(_Conexion)

            MiConexion.Open()

            If estadoRecibo = "ExisteRecibo" Then

                '========================================================
                ' ACTUALIZAR RECIBO
                '========================================================

                Dim SqlUpdate As String =
                "UPDATE Recibo SET " &
                "Cod_Cliente = @Cod_Cliente, " &
                "Cod_Cajero = @Cod_Cajero, " &
                "Sub_Total = @Sub_Total, " &
                "Descuento = @Descuento, " &
                "Total = @Total, " &
                "NombreCliente = @NombreCliente, " &
                "ApellidosCliente = @ApellidosCliente, " &
                "DireccionCliente = @DireccionCliente, " &
                "TelefonoCliente = @TelefonoCliente, " &
                "MonedaRecibo = @MonedaRecibo, " &
                "Observaciones = @Observaciones " &
                "WHERE CodReciboPago = @CodReciboPago " &
                "AND Fecha_Recibo = @Fecha_Recibo"

                Using Comando As New SqlClient.SqlCommand(SqlUpdate, MiConexion)

                    Comando.Parameters.Add("@CodReciboPago", SqlDbType.NVarChar, 50).Value = numeroRecibo
                    Comando.Parameters.Add("@Fecha_Recibo", SqlDbType.SmallDateTime).Value = fechaRecibo
                    Comando.Parameters.Add("@Cod_Cliente", SqlDbType.NVarChar, 50).Value = codigoCliente
                    Comando.Parameters.Add("@Cod_Cajero", SqlDbType.NVarChar, 50).Value = codigoCajero
                    Comando.Parameters.Add("@Sub_Total", SqlDbType.Float).Value = Convert.ToDouble(subtotal)
                    Comando.Parameters.Add("@Descuento", SqlDbType.Float).Value = Convert.ToDouble(descuento)
                    Comando.Parameters.Add("@Total", SqlDbType.Float).Value = Convert.ToDouble(total)
                    Comando.Parameters.Add("@NombreCliente", SqlDbType.NVarChar, -1).Value = nombreCliente
                    Comando.Parameters.Add("@ApellidosCliente", SqlDbType.NVarChar, -1).Value = apellidosCliente
                    Comando.Parameters.Add("@DireccionCliente", SqlDbType.NVarChar, -1).Value = direccionCliente
                    Comando.Parameters.Add("@TelefonoCliente", SqlDbType.NVarChar, -1).Value = telefonoCliente
                    Comando.Parameters.Add("@MonedaRecibo", SqlDbType.NVarChar, 50).Value = moneda
                    Comando.Parameters.Add("@Observaciones", SqlDbType.NVarChar, -1).Value = observaciones

                    Comando.ExecuteNonQuery()

                End Using

            Else

                '========================================================
                ' INSERTAR RECIBO
                '========================================================

                'IMPORTANTE:
                'FechaRegistro NO se incluye.
                'SQL Server la genera mediante:
                'DEFAULT (sysdatetime())

                Dim SqlInsert As String =
                "INSERT INTO Recibo " &
                "(CodReciboPago, Fecha_Recibo, Cod_Cliente, Cod_Cajero, " &
                "Sub_Total, Descuento, Total, NombreCliente, ApellidosCliente, " &
                "DireccionCliente, TelefonoCliente, MonedaRecibo, Observaciones) " &
                "VALUES " &
                "(@CodReciboPago, @Fecha_Recibo, @Cod_Cliente, @Cod_Cajero, " &
                "@Sub_Total, @Descuento, @Total, @NombreCliente, @ApellidosCliente, " &
                "@DireccionCliente, @TelefonoCliente, @MonedaRecibo, @Observaciones)"

                Using Comando As New SqlClient.SqlCommand(SqlInsert, MiConexion)

                    Comando.Parameters.Add("@CodReciboPago", SqlDbType.NVarChar, 50).Value = numeroRecibo
                    Comando.Parameters.Add("@Fecha_Recibo", SqlDbType.SmallDateTime).Value = fechaRecibo
                    Comando.Parameters.Add("@Cod_Cliente", SqlDbType.NVarChar, 50).Value = codigoCliente
                    Comando.Parameters.Add("@Cod_Cajero", SqlDbType.NVarChar, 50).Value = codigoCajero
                    Comando.Parameters.Add("@Sub_Total", SqlDbType.Float).Value = Convert.ToDouble(subtotal)
                    Comando.Parameters.Add("@Descuento", SqlDbType.Float).Value = Convert.ToDouble(descuento)
                    Comando.Parameters.Add("@Total", SqlDbType.Float).Value = Convert.ToDouble(total)
                    Comando.Parameters.Add("@NombreCliente", SqlDbType.NVarChar, -1).Value = nombreCliente
                    Comando.Parameters.Add("@ApellidosCliente", SqlDbType.NVarChar, -1).Value = apellidosCliente
                    Comando.Parameters.Add("@DireccionCliente", SqlDbType.NVarChar, -1).Value = direccionCliente
                    Comando.Parameters.Add("@TelefonoCliente", SqlDbType.NVarChar, -1).Value = telefonoCliente
                    Comando.Parameters.Add("@MonedaRecibo", SqlDbType.NVarChar, 50).Value = moneda
                    Comando.Parameters.Add("@Observaciones", SqlDbType.NVarChar, -1).Value = observaciones

                    Comando.ExecuteNonQuery()

                End Using

            End If

        End Using

        Return True

    End Function
    '==========================================================
    ' OBTENER CONSECUTIVO DEL RECIBO
    '==========================================================
    Public Function ObtenerConsecutivoRecibo(
    ByVal fecha As Date,
    ByVal serie As String,
    ByVal esNuevo As Boolean,
    ByRef consecutivoPago As Double) As String

        Dim DataSet As New DataSet
        Dim DataAdapter As New SqlClient.SqlDataAdapter

        Dim SqlConsecutivo As String
        Dim ConsecutivoManual As Boolean = False

        consecutivoPago = 0


        '==========================================================
        ' SI NO ES UN RECIBO NUEVO
        '==========================================================
        If esNuevo = False Then
            Return ""
        End If


        '==========================================================
        ' OBTENER CONFIGURACION DEL CONSECUTIVO MANUAL
        '==========================================================
        SqlConsecutivo =
        "SELECT ConsecutivoReciboManual " &
        "FROM DatosEmpresa"

        DataAdapter =
        New SqlClient.SqlDataAdapter(
            SqlConsecutivo,
            _Conexion)

        DataAdapter.Fill(
        DataSet,
        "Configuracion")


        If DataSet.Tables("Configuracion").Rows.Count <> 0 Then

            If Not IsDBNull(
            DataSet.Tables("Configuracion").Rows(0)(
                "ConsecutivoReciboManual")) Then

                ConsecutivoManual =
                Convert.ToBoolean(
                    DataSet.Tables("Configuracion").Rows(0)(
                        "ConsecutivoReciboManual"))

            End If

        End If


        '==========================================================
        ' CONSECUTIVO AUTOMATICO
        '==========================================================
        If ConsecutivoManual = False Then

            If String.IsNullOrEmpty(serie) Then

                consecutivoPago =
                BuscaConsecutivo("Recibo_Caja")

            Else

                consecutivoPago =
                BuscaConsecutivoSerie(
                    "Recibo",
                    serie)

            End If

        End If


        Return ""

    End Function

    Public Function DeterminarNumeroRecibo(
        ByVal numeroExistente As String,
        ByVal consecutivoPago As Double,
        ByVal utilizaSerie As Boolean,
        ByVal serie As String) As String

        If numeroExistente = "-----0-----" Then

            If utilizaSerie = False Then
                Return Format(consecutivoPago, "0000#")
            Else
                Return serie & Format(consecutivoPago, "0000#")
            End If

        Else

            'IMPORTANTE:
            'En edición conservar exactamente el número existente.
            Return numeroExistente.Trim()

        End If

    End Function


    '==========================================================
    ' RECIBO
    '==========================================================

    '==========================================================
    ' VERIFICAR EXISTENCIA DEL RECIBO
    '==========================================================
    Public Function ExisteRecibo(
    ByVal fecha As Date,
    ByVal numeroRecibo As String) As String

        Dim SQL As String
        Dim DataSet As New DataSet
        Dim DataAdapter As SqlClient.SqlDataAdapter

        Dim FechaConsulta As String

        FechaConsulta = Format(fecha, "yyyy-MM-dd")


        '==========================================================
        ' BUSCAR EL RECIBO EN LA FECHA INDICADA
        '==========================================================
        SQL =
        "SELECT CodReciboPago, Fecha_Recibo " &
        "FROM Recibo " &
        "WHERE CodReciboPago = @CodReciboPago " &
        "AND Fecha_Recibo = @Fecha_Recibo"


        Using CN As New SqlClient.SqlConnection(_Conexion)

            Using CMD As New SqlClient.SqlCommand(SQL, CN)

                CMD.Parameters.Add(
                "@CodReciboPago",
                SqlDbType.NVarChar,
                50).Value = numeroRecibo

                CMD.Parameters.Add(
                "@Fecha_Recibo",
                SqlDbType.DateTime).Value =
                    Convert.ToDateTime(FechaConsulta)


                Using DA As New SqlClient.SqlDataAdapter(CMD)

                    DA.Fill(DataSet, "Recibo")

                End Using

            End Using

        End Using


        '==========================================================
        ' SI EXISTE EN LA FECHA INDICADA
        '==========================================================
        If DataSet.Tables("Recibo").Rows.Count > 0 Then

            Return "ExisteRecibo"

        End If


        '==========================================================
        ' BUSCAR SI EXISTE EL MISMO RECIBO EN OTRA FECHA
        '==========================================================
        DataSet.Reset()


        SQL =
        "SELECT CodReciboPago, Fecha_Recibo " &
        "FROM Recibo " &
        "WHERE CodReciboPago = @CodReciboPago"


        Using CN As New SqlClient.SqlConnection(_Conexion)

            Using CMD As New SqlClient.SqlCommand(SQL, CN)

                CMD.Parameters.Add(
                "@CodReciboPago",
                SqlDbType.NVarChar,
                50).Value = numeroRecibo


                Using DA As New SqlClient.SqlDataAdapter(CMD)

                    DA.Fill(DataSet, "Recibo")

                End Using

            End Using

        End Using


        '==========================================================
        ' EXISTE PERO EN OTRA FECHA
        '==========================================================
        If DataSet.Tables("Recibo").Rows.Count > 0 Then

            Return "ExisteReciboDifFecha"

        End If


        '==========================================================
        ' NO EXISTE
        '==========================================================
        Return "NoExisteRecibo"

    End Function

    '==========================================================
    ' GRABAR / ACTUALIZAR ENCABEZADO DEL RECIBO
    '==========================================================
    Public Function GrabarRecibo(
    ByVal numeroRecibo As String,
    ByVal fecha As Date,
    ByVal codigoCliente As String,
    ByVal nombreCliente As String,
    ByVal apellidosCliente As String,
    ByVal moneda As String,
    ByVal subtotal As Decimal,
    ByVal descuento As Decimal,
    ByVal total As Decimal,
    ByVal usuario As String) As Boolean

        Try

            Dim EstadoRecibo As String
            EstadoRecibo = ExisteRecibo(fecha, numeroRecibo)

            If EstadoRecibo = "ExisteReciboDifFecha" Then
                Return False
            End If

            Using CN As New SqlConnection(_Conexion)

                CN.Open()

                If EstadoRecibo = "ExisteRecibo" Then

                    Dim SQLUpdate As String

                    SQLUpdate =
                    "UPDATE Recibo SET " &
                    "Cod_Cliente = @Cod_Cliente, " &
                    "Cod_Cajero = @Cod_Cajero, " &
                    "Sub_Total = @Sub_Total, " &
                    "Descuento = @Descuento, " &
                    "Total = @Total, " &
                    "NombreCliente = @NombreCliente, " &
                    "ApellidosCliente = @ApellidosCliente, " &
                    "MonedaRecibo = @MonedaRecibo " &
                    "WHERE CodReciboPago = @CodReciboPago " &
                    "AND Fecha_Recibo = @Fecha_Recibo"

                    Using CMD As New SqlCommand(SQLUpdate, CN)

                        CMD.Parameters.Add("@CodReciboPago",
                                       SqlDbType.NVarChar, 50).Value =
                                       numeroRecibo

                        CMD.Parameters.Add("@Fecha_Recibo",
                                       SqlDbType.SmallDateTime).Value =
                                       fecha

                        CMD.Parameters.Add("@Cod_Cliente",
                                       SqlDbType.NVarChar, 50).Value =
                                       codigoCliente

                        CMD.Parameters.Add("@Cod_Cajero",
                                       SqlDbType.NVarChar, 50).Value =
                                       usuario

                        CMD.Parameters.Add("@Sub_Total",
                                       SqlDbType.Float).Value =
                                       Convert.ToDouble(subtotal)

                        CMD.Parameters.Add("@Descuento",
                                       SqlDbType.Float).Value =
                                       Convert.ToDouble(descuento)

                        CMD.Parameters.Add("@Total",
                                       SqlDbType.Float).Value =
                                       Convert.ToDouble(total)

                        CMD.Parameters.Add("@NombreCliente",
                                       SqlDbType.NVarChar, -1).Value =
                                       nombreCliente

                        CMD.Parameters.Add("@ApellidosCliente",
                                       SqlDbType.NVarChar, -1).Value =
                                       apellidosCliente

                        CMD.Parameters.Add("@MonedaRecibo",
                                       SqlDbType.NVarChar, 50).Value =
                                       moneda

                        CMD.ExecuteNonQuery()

                    End Using

                ElseIf EstadoRecibo = "NoExisteRecibo" Then

                    Dim SQLInsert As String

                    SQLInsert =
                    "INSERT INTO Recibo (" &
                    "CodReciboPago, " &
                    "Fecha_Recibo, " &
                    "Cod_Cliente, " &
                    "Cod_Cajero, " &
                    "Sub_Total, " &
                    "Descuento, " &
                    "Total, " &
                    "NombreCliente, " &
                    "ApellidosCliente, " &
                    "MonedaRecibo) " &
                    "VALUES (" &
                    "@CodReciboPago, " &
                    "@Fecha_Recibo, " &
                    "@Cod_Cliente, " &
                    "@Cod_Cajero, " &
                    "@Sub_Total, " &
                    "@Descuento, " &
                    "@Total, " &
                    "@NombreCliente, " &
                    "@ApellidosCliente, " &
                    "@MonedaRecibo)"

                    Using CMD As New SqlCommand(SQLInsert, CN)

                        CMD.Parameters.Add("@CodReciboPago",
                                       SqlDbType.NVarChar, 50).Value =
                                       numeroRecibo

                        CMD.Parameters.Add("@Fecha_Recibo",
                                       SqlDbType.SmallDateTime).Value =
                                       fecha

                        CMD.Parameters.Add("@Cod_Cliente",
                                       SqlDbType.NVarChar, 50).Value =
                                       codigoCliente

                        CMD.Parameters.Add("@Cod_Cajero",
                                       SqlDbType.NVarChar, 50).Value =
                                       usuario

                        CMD.Parameters.Add("@Sub_Total",
                                       SqlDbType.Float).Value =
                                       Convert.ToDouble(subtotal)

                        CMD.Parameters.Add("@Descuento",
                                       SqlDbType.Float).Value =
                                       Convert.ToDouble(descuento)

                        CMD.Parameters.Add("@Total",
                                       SqlDbType.Float).Value =
                                       Convert.ToDouble(total)

                        CMD.Parameters.Add("@NombreCliente",
                                       SqlDbType.NVarChar, -1).Value =
                                       nombreCliente

                        CMD.Parameters.Add("@ApellidosCliente",
                                       SqlDbType.NVarChar, -1).Value =
                                       apellidosCliente

                        CMD.Parameters.Add("@MonedaRecibo",
                                       SqlDbType.NVarChar, 50).Value =
                                       moneda

                        CMD.ExecuteNonQuery()

                    End Using

                Else

                    Return False

                End If

            End Using

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function
    Public Function GrabarReciboPlanilla(
    ByVal CN As SqlConnection,
    ByVal Trans As SqlTransaction,
    ByVal NumeroRecibo As String,
    ByVal FechaRecibo As Date,
    ByVal CodigoCliente As String,
    ByVal NombreCliente As String,
    ByVal Moneda As String,
    ByVal Aplicaciones As List(Of AplicacionPlanPendiente)
) As Boolean

        Try

            If Aplicaciones Is Nothing OrElse
           Aplicaciones.Count = 0 Then

                Return False

            End If


            '==========================================================
            ' TOTAL DEL RECIBO
            '==========================================================

            Dim TotalRecibo As Decimal = 0D

            For Each Aplicacion As AplicacionPlanPendiente In Aplicaciones

                If Aplicacion.MontoAplicado > 0D Then

                    TotalRecibo += Aplicacion.MontoAplicado

                End If

            Next


            If TotalRecibo <= 0D Then

                Throw New Exception(
                "El total del recibo debe ser mayor que cero.")

            End If


            '==========================================================
            ' 1. GRABAR CABECERA DEL RECIBO
            '==========================================================

            Dim SQLRecibo As String =
        "INSERT INTO Recibo " &
        "(CodReciboPago, Fecha_Recibo, Cod_Cliente, " &
        "Sub_Total, Descuento, Total, NombreCliente, " &
        "MonedaRecibo, Activo, Contabilizado, Marca, Observaciones) " &
        "VALUES " &
        "(@CodReciboPago, @Fecha_Recibo, @Cod_Cliente, " &
        "@Sub_Total, @Descuento, @Total, @NombreCliente, " &
        "@MonedaRecibo, 1, 0, 1, @Observaciones)"

            Using CMD As New SqlCommand(
            SQLRecibo,
            CN,
            Trans)

                CMD.Parameters.Add(
                "@CodReciboPago",
                SqlDbType.NVarChar,
                50).Value =
                NumeroRecibo

                CMD.Parameters.Add(
                "@Fecha_Recibo",
                SqlDbType.SmallDateTime).Value =
                FechaRecibo.Date

                CMD.Parameters.Add(
                "@Cod_Cliente",
                SqlDbType.NVarChar,
                50).Value =
                If(CodigoCliente, "")

                CMD.Parameters.Add(
                "@Sub_Total",
                SqlDbType.Float).Value =
                Convert.ToDouble(TotalRecibo)

                CMD.Parameters.Add(
                "@Descuento",
                SqlDbType.Float).Value =
                0D

                CMD.Parameters.Add(
                "@Total",
                SqlDbType.Float).Value =
                Convert.ToDouble(TotalRecibo)

                CMD.Parameters.Add(
                "@NombreCliente",
                SqlDbType.NVarChar,
                -1).Value =
                If(NombreCliente, "")

                CMD.Parameters.Add(
                "@MonedaRecibo",
                SqlDbType.NVarChar,
                50).Value =
                If(Moneda, "")

                CMD.Parameters.Add(
                "@Observaciones",
                SqlDbType.NVarChar,
                -1).Value =
                "Recibo generado automáticamente desde Planilla de Leche - Plan de Pagos"

                CMD.ExecuteNonQuery()

            End Using


            '==========================================================
            ' 2. GRABAR DETALLES DEL RECIBO
            '    Y APLICACIONES DEL PLAN DE PAGOS
            '==========================================================

            For Each Aplicacion As AplicacionPlanPendiente In Aplicaciones

                If Aplicacion.MontoAplicado <= 0D Then
                    Continue For
                End If


                Dim MontoAplicado As Decimal =
                Aplicacion.MontoAplicado


                '======================================================
                ' OBTENER MONTO Y SALDO ACTUAL DE LA FACTURA
                '======================================================

                Dim MontoFactura As Decimal = 0D
                Dim PagadoActual As Decimal = 0D
                Dim SaldoFactura As Decimal = 0D

                Dim SQLFactura As String =
            "SELECT " &
            "ISNULL(NetoPagar, 0) AS NetoPagar, " &
            "ISNULL(Pagado, 0) AS Pagado " &
            "FROM Facturas " &
            "WHERE Numero_Factura = @NumeroFactura " &
            "AND Fecha_Factura = @FechaFactura " &
            "AND Tipo_Factura = @TipoFactura"

                Using CMDFactura As New SqlCommand(
                SQLFactura,
                CN,
                Trans)

                    CMDFactura.Parameters.Add(
                    "@NumeroFactura",
                    SqlDbType.NVarChar,
                    50).Value =
                    If(Aplicacion.NumeroFactura, "")

                    CMDFactura.Parameters.Add(
                    "@FechaFactura",
                    SqlDbType.SmallDateTime).Value =
                    Aplicacion.FechaFactura.Date

                    CMDFactura.Parameters.Add(
                    "@TipoFactura",
                    SqlDbType.NVarChar,
                    50).Value =
                    If(Aplicacion.TipoFactura, "Factura")

                    Using DR As SqlDataReader =
                    CMDFactura.ExecuteReader()

                        If DR.Read() Then

                            MontoFactura =
                            Convert.ToDecimal(
                                DR("NetoPagar"))

                            PagadoActual =
                            Convert.ToDecimal(
                                DR("Pagado"))

                        End If

                    End Using

                End Using


                SaldoFactura =
                MontoFactura -
                PagadoActual -
                MontoAplicado

                If SaldoFactura < 0D Then
                    SaldoFactura = 0D
                End If


                '======================================================
                ' 2.1 GRABAR DETALLE DEL RECIBO
                '======================================================

                Dim IdDetalle As Decimal =
                GrabarDetalleReciboPlanilla(
                    CN,
                    Trans,
                    NumeroRecibo,
                    FechaRecibo,
                    Aplicacion.NumeroFactura,
                    MontoAplicado,
                    "Efectivo",
                    "Abono Plan de Pagos - Cuota " &
                    Aplicacion.NumeroCuota.ToString(),
                    "",
                    Aplicacion.FechaVence,
                    MontoFactura,
                    MontoAplicado,
                    SaldoFactura,
                    1D,
                    "")


                If IdDetalle <= 0D Then

                    Throw New Exception(
                    "No se pudo grabar el detalle del recibo. " &
                    "Factura: " &
                    Aplicacion.NumeroFactura)

                End If


                '======================================================
                ' 2.2 GRABAR APLICACION DEL PLAN DE PAGOS
                '======================================================

                Dim SQLAplicacion As String =
            "INSERT INTO AplicacionPagoPlan " &
            "(idDetallePago, idDetalleRecibo, MontoAplicado, " &
            "FechaAplicacion, Anulado, CodReciboPago, " &
            "Fecha_Recibo, Numero_Factura) " &
            "VALUES " &
            "(@idDetallePago, @idDetalleRecibo, @MontoAplicado, " &
            "SYSDATETIME(), 0, @CodReciboPago, " &
            "@Fecha_Recibo, @Numero_Factura)"

                Using CMDAplicacion As New SqlCommand(
                SQLAplicacion,
                CN,
                Trans)

                    CMDAplicacion.Parameters.Add(
                    "@idDetallePago",
                    SqlDbType.Int).Value =
                    Aplicacion.IdDetallePago

                    CMDAplicacion.Parameters.Add(
                    "@idDetalleRecibo",
                    SqlDbType.Decimal).Value =
                    IdDetalle

                    CMDAplicacion.Parameters.Add(
                    "@MontoAplicado",
                    SqlDbType.Decimal).Value =
                    MontoAplicado

                    CMDAplicacion.Parameters.Add(
                    "@CodReciboPago",
                    SqlDbType.NVarChar,
                    50).Value =
                    NumeroRecibo

                    CMDAplicacion.Parameters.Add(
                    "@Fecha_Recibo",
                    SqlDbType.SmallDateTime).Value =
                    FechaRecibo.Date

                    CMDAplicacion.Parameters.Add(
                    "@Numero_Factura",
                    SqlDbType.NVarChar,
                    50).Value =
                    Aplicacion.NumeroFactura

                    CMDAplicacion.ExecuteNonQuery()

                End Using


                '======================================================
                ' 2.3 ACTUALIZAR PAGADO DEL DETALLE DE PAGOS
                '
                ' Se calcula con todas las aplicaciones activas,
                ' no solamente con el abono actual.
                '======================================================

                Dim SQLPagado As String =
                    "UPDATE DP " &
                    "SET Pagado = " &
                    "CASE " &
                    "WHEN ISNULL((" &
                    "    SELECT SUM(APP.MontoAplicado) " &
                    "    FROM AplicacionPagoPlan APP " &
                    "    WHERE APP.idDetallePago = DP.idDetallePago " &
                    "    AND APP.Anulado = 0" &
                    "), 0) >= " &
                    "(DP.MontoAbono + " &
                    " DP.MontoInteres + " &
                    " DP.MontoMora + " &
                    " DP.MontoMtoValor) " &
                    "THEN 1 " &
                    "ELSE 0 " &
                    "END " &
                    "FROM DetallePagos DP " &
                    "WHERE DP.idDetallePago = @idDetallePago"

                Using CMDPagado As New SqlCommand(
                SQLPagado,
                CN,
                Trans)

                    CMDPagado.Parameters.Add(
                    "@idDetallePago",
                    SqlDbType.Int).Value =
                    Aplicacion.IdDetallePago

                    CMDPagado.ExecuteNonQuery()

                End Using

            Next


            '==========================================================
            ' 3. GRABAR MÉTODO DE PAGO
            '==========================================================

            If Not GrabarMetodoDetalleReciboPlanilla(
            CN,
            Trans,
            NumeroRecibo,
            FechaRecibo,
            "Efectivo",
            TotalRecibo,
            "",
            Nothing) Then

                Throw New Exception(
                "No se pudo grabar el método de pago del recibo " &
                NumeroRecibo)

            End If


            '==========================================================
            ' 4. TODO CORRECTO
            '==========================================================

            Return True


        Catch ex As Exception

            Throw New Exception(
            "Error al grabar el recibo de Planilla: " &
            ex.Message,
            ex)

        End Try

    End Function

    '==========================================================
    ' DETALLE DEL RECIBO
    '==========================================================

    '==========================================================
    ' GRABAR / ACTUALIZAR DETALLE DEL RECIBO
    '==========================================================
    Public Function GrabarDetalleRecibo(
    ByVal numeroRecibo As String,
    ByVal fecha As Date,
    ByVal numeroFactura As String,
    ByVal montoPagado As Decimal,
    ByVal nombrePago As String,
    ByVal descripcion As String,
    ByVal numeroTarjeta As String,
    ByVal fechaVence As Date,
    ByVal montoFactura As Decimal,
    ByVal aplicaFactura As Decimal,
    ByVal saldoFactura As Decimal,
    ByVal tasaCambio As Decimal,
    ByVal numeroNota As String,
    ByVal idDetalleRecibo As Decimal) As Boolean

        Dim fechaRecibo As Date = fecha.Date

        Using MiConexion As New SqlClient.SqlConnection(_Conexion)

            MiConexion.Open()

            If idDetalleRecibo > 0 Then

                '========================================================
                ' ACTUALIZAR DETALLE
                '========================================================

                Dim SqlUpdate As String =
                "UPDATE DetalleRecibo SET " &
                "CodReciboPago = @CodReciboPago, " &
                "Fecha_Recibo = @Fecha_Recibo, " &
                "Numero_Factura = @Numero_Factura, " &
                "MontoPagado = @MontoPagado, " &
                "NombrePago = @NombrePago, " &
                "Descripcion = @Descripcion, " &
                "NumeroTarjeta = @NumeroTarjeta, " &
                "FechaVence = @FechaVence, " &
                "MontoFactura = @MontoFactura, " &
                "AplicaFactura = @AplicaFactura, " &
                "SaldoFactura = @SaldoFactura, " &
                "TasaCambio = @TasaCambio, " &
                "Numero_Nota = @Numero_Nota " &
                "WHERE idDetalleRecibo = @idDetalleRecibo"

                Using Comando As New SqlClient.SqlCommand(SqlUpdate, MiConexion)

                    Comando.Parameters.Add("@idDetalleRecibo", SqlDbType.Decimal).Value = idDetalleRecibo
                    Comando.Parameters.Add("@CodReciboPago", SqlDbType.NVarChar, 50).Value = numeroRecibo
                    Comando.Parameters.Add("@Fecha_Recibo", SqlDbType.SmallDateTime).Value = fechaRecibo
                    Comando.Parameters.Add("@Numero_Factura", SqlDbType.NVarChar, 50).Value = numeroFactura
                    Comando.Parameters.Add("@MontoPagado", SqlDbType.Float).Value = Convert.ToDouble(montoPagado)
                    Comando.Parameters.Add("@NombrePago", SqlDbType.NVarChar, 50).Value = nombrePago
                    Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, -1).Value = descripcion
                    Comando.Parameters.Add("@NumeroTarjeta", SqlDbType.NVarChar, 50).Value = numeroTarjeta
                    Comando.Parameters.Add("@FechaVence", SqlDbType.SmallDateTime).Value = fechaVence
                    Comando.Parameters.Add("@MontoFactura", SqlDbType.Float).Value = Convert.ToDouble(montoFactura)
                    Comando.Parameters.Add("@AplicaFactura", SqlDbType.Float).Value = Convert.ToDouble(aplicaFactura)
                    Comando.Parameters.Add("@SaldoFactura", SqlDbType.Float).Value = Convert.ToDouble(saldoFactura)
                    Comando.Parameters.Add("@TasaCambio", SqlDbType.Float).Value = Convert.ToDouble(tasaCambio)
                    Comando.Parameters.Add("@Numero_Nota", SqlDbType.NVarChar, 50).Value = numeroNota

                    Comando.ExecuteNonQuery()

                End Using

            Else

                '========================================================
                ' INSERTAR DETALLE
                '========================================================

                Dim SqlInsert As String =
                "INSERT INTO DetalleRecibo " &
                "(CodReciboPago, Fecha_Recibo, Numero_Factura, MontoPagado, " &
                "NombrePago, Descripcion, NumeroTarjeta, FechaVence, " &
                "MontoFactura, AplicaFactura, SaldoFactura, TasaCambio, Numero_Nota) " &
                "VALUES " &
                "(@CodReciboPago, @Fecha_Recibo, @Numero_Factura, @MontoPagado, " &
                "@NombrePago, @Descripcion, @NumeroTarjeta, @FechaVence, " &
                "@MontoFactura, @AplicaFactura, @SaldoFactura, @TasaCambio, @Numero_Nota)"

                Using Comando As New SqlClient.SqlCommand(SqlInsert, MiConexion)

                    Comando.Parameters.Add("@CodReciboPago", SqlDbType.NVarChar, 50).Value = numeroRecibo
                    Comando.Parameters.Add("@Fecha_Recibo", SqlDbType.SmallDateTime).Value = fechaRecibo
                    Comando.Parameters.Add("@Numero_Factura", SqlDbType.NVarChar, 50).Value = numeroFactura
                    Comando.Parameters.Add("@MontoPagado", SqlDbType.Float).Value = Convert.ToDouble(montoPagado)
                    Comando.Parameters.Add("@NombrePago", SqlDbType.NVarChar, 50).Value = nombrePago
                    Comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, -1).Value = descripcion
                    Comando.Parameters.Add("@NumeroTarjeta", SqlDbType.NVarChar, 50).Value = numeroTarjeta
                    Comando.Parameters.Add("@FechaVence", SqlDbType.SmallDateTime).Value = fechaVence
                    Comando.Parameters.Add("@MontoFactura", SqlDbType.Float).Value = Convert.ToDouble(montoFactura)
                    Comando.Parameters.Add("@AplicaFactura", SqlDbType.Float).Value = Convert.ToDouble(aplicaFactura)
                    Comando.Parameters.Add("@SaldoFactura", SqlDbType.Float).Value = Convert.ToDouble(saldoFactura)
                    Comando.Parameters.Add("@TasaCambio", SqlDbType.Float).Value = Convert.ToDouble(tasaCambio)
                    Comando.Parameters.Add("@Numero_Nota", SqlDbType.NVarChar, 50).Value = numeroNota

                    Comando.ExecuteNonQuery()

                End Using

            End If

        End Using

        Return True

    End Function

    Public Function GrabarDetalleReciboPlanilla(
    ByVal CN As SqlConnection,
    ByVal Trans As SqlTransaction,
    ByVal NumeroRecibo As String,
    ByVal FechaRecibo As Date,
    ByVal NumeroFactura As String,
    ByVal MontoPagado As Decimal,
    ByVal NombrePago As String,
    ByVal Descripcion As String,
    ByVal NumeroTarjeta As String,
    ByVal FechaVence As Nullable(Of Date),
    ByVal MontoFactura As Decimal,
    ByVal AplicaFactura As Decimal,
    ByVal SaldoFactura As Decimal,
    ByVal TasaCambio As Decimal,
    ByVal NumeroNota As String
) As Decimal

        Dim IdDetalleRecibo As Decimal = 0D

        Dim SQL As String =
        "INSERT INTO DetalleRecibo " &
        "(CodReciboPago, Fecha_Recibo, Numero_Factura, MontoPagado, " &
        "NombrePago, Descripcion, NumeroTarjeta, FechaVence, " &
        "MontoFactura, AplicaFactura, SaldoFactura, TasaCambio, Numero_Nota) " &
        "VALUES " &
        "(@CodReciboPago, @Fecha_Recibo, @Numero_Factura, @MontoPagado, " &
        "@NombrePago, @Descripcion, @NumeroTarjeta, @FechaVence, " &
        "@MontoFactura, @AplicaFactura, @SaldoFactura, @TasaCambio, " &
        "@Numero_Nota); " &
        "SELECT CAST(SCOPE_IDENTITY() AS NUMERIC(18,0));"

        Using CMD As New SqlCommand(SQL, CN, Trans)

            CMD.Parameters.Add(
            "@CodReciboPago",
            SqlDbType.NVarChar,
            50).Value =
            If(NumeroRecibo, "")

            CMD.Parameters.Add(
            "@Fecha_Recibo",
            SqlDbType.SmallDateTime).Value =
            FechaRecibo.Date

            CMD.Parameters.Add(
            "@Numero_Factura",
            SqlDbType.NVarChar,
            50).Value =
            If(NumeroFactura, "")

            CMD.Parameters.Add(
            "@MontoPagado",
            SqlDbType.Float).Value =
            Convert.ToDouble(MontoPagado)

            CMD.Parameters.Add(
            "@NombrePago",
            SqlDbType.NVarChar,
            50).Value =
            If(NombrePago, "")

            CMD.Parameters.Add(
            "@Descripcion",
            SqlDbType.NVarChar,
            -1).Value =
            If(Descripcion, "")

            CMD.Parameters.Add(
            "@NumeroTarjeta",
            SqlDbType.NVarChar,
            50).Value =
            If(NumeroTarjeta, "")

            If FechaVence.HasValue Then

                CMD.Parameters.Add(
                "@FechaVence",
                SqlDbType.SmallDateTime).Value =
                FechaVence.Value

            Else

                CMD.Parameters.Add(
                "@FechaVence",
                SqlDbType.SmallDateTime).Value =
                DBNull.Value

            End If

            CMD.Parameters.Add(
            "@MontoFactura",
            SqlDbType.Float).Value =
            Convert.ToDouble(MontoFactura)

            CMD.Parameters.Add(
            "@AplicaFactura",
            SqlDbType.Float).Value =
            Convert.ToDouble(AplicaFactura)

            CMD.Parameters.Add(
            "@SaldoFactura",
            SqlDbType.Float).Value =
            Convert.ToDouble(SaldoFactura)

            CMD.Parameters.Add(
            "@TasaCambio",
            SqlDbType.Float).Value =
            Convert.ToDouble(TasaCambio)

            CMD.Parameters.Add(
            "@Numero_Nota",
            SqlDbType.NVarChar,
            50).Value =
            If(NumeroNota, "")

            Dim Resultado As Object =
            CMD.ExecuteScalar()

            If Resultado IsNot Nothing AndAlso
           Not IsDBNull(Resultado) Then

                IdDetalleRecibo =
                Convert.ToDecimal(Resultado)

            End If

        End Using

        Return IdDetalleRecibo

    End Function

    '==========================================================
    ' GRABAR / ACTUALIZAR METODO DE PAGO DEL RECIBO
    '==========================================================
    Public Function GrabarMetodoDetalleRecibo(
    ByVal numeroRecibo As String,
    ByVal fecha As Date,
    ByVal nombrePago As String,
    ByVal montoPagado As Decimal,
    ByVal numeroTarjeta As String,
    ByVal fechaVence As Date) As Boolean

        Try

            Using CN As New SqlConnection(_Conexion)

                CN.Open()

                '==========================================================
                ' Verificar si ya existe el método de pago para el recibo
                '==========================================================

                Dim SQLExiste As String

                SQLExiste =
                "SELECT COUNT(*) " &
                "FROM Detalle_MetodoRecibo " &
                "WHERE CodRecibo = @CodRecibo " &
                "AND Fecha_Recibo = @Fecha_Recibo " &
                "AND NombrePago = @NombrePago"

                Dim Existe As Integer

                Using CMD As New SqlCommand(SQLExiste, CN)

                    CMD.Parameters.Add("@CodRecibo",
                                   SqlDbType.NVarChar, 50).Value =
                                   numeroRecibo

                    CMD.Parameters.Add("@Fecha_Recibo",
                                   SqlDbType.SmallDateTime).Value =
                                   fecha

                    CMD.Parameters.Add("@NombrePago",
                                   SqlDbType.NVarChar, 50).Value =
                                   nombrePago

                    Existe = Convert.ToInt32(CMD.ExecuteScalar())

                End Using

                '==========================================================
                ' ACTUALIZAR MÉTODO EXISTENTE
                '==========================================================

                If Existe > 0 Then

                    Dim SQLUpdate As String

                    SQLUpdate =
                    "UPDATE Detalle_MetodoRecibo SET " &
                    "Monto = @Monto, " &
                    "NumeroTarjeta = @NumeroTarjeta, " &
                    "Fecha_Vence = @Fecha_Vence " &
                    "WHERE CodRecibo = @CodRecibo " &
                    "AND Fecha_Recibo = @Fecha_Recibo " &
                    "AND NombrePago = @NombrePago"

                    Using CMD As New SqlCommand(SQLUpdate, CN)

                        CMD.Parameters.Add("@Monto",
                                       SqlDbType.Float).Value =
                                       Convert.ToDouble(montoPagado)

                        CMD.Parameters.Add("@NumeroTarjeta",
                                       SqlDbType.NVarChar, 50).Value =
                                       numeroTarjeta

                        CMD.Parameters.Add("@Fecha_Vence",
                                       SqlDbType.SmallDateTime).Value =
                                       fechaVence

                        CMD.Parameters.Add("@CodRecibo",
                                       SqlDbType.NVarChar, 50).Value =
                                       numeroRecibo

                        CMD.Parameters.Add("@Fecha_Recibo",
                                       SqlDbType.SmallDateTime).Value =
                                       fecha

                        CMD.Parameters.Add("@NombrePago",
                                       SqlDbType.NVarChar, 50).Value =
                                       nombrePago

                        CMD.ExecuteNonQuery()

                    End Using

                Else

                    '======================================================
                    ' INSERTAR MÉTODO NUEVO
                    '
                    ' idDetalle_Recibo es IDENTITY.
                    ' SQL Server genera el valor automáticamente.
                    '======================================================

                    Dim SQLInsert As String

                    SQLInsert =
                    "INSERT INTO Detalle_MetodoRecibo (" &
                    "CodRecibo, " &
                    "Fecha_Recibo, " &
                    "NombrePago, " &
                    "Monto, " &
                    "NumeroTarjeta, " &
                    "Fecha_Vence) " &
                    "VALUES (" &
                    "@CodRecibo, " &
                    "@Fecha_Recibo, " &
                    "@NombrePago, " &
                    "@Monto, " &
                    "@NumeroTarjeta, " &
                    "@Fecha_Vence)"

                    Using CMD As New SqlCommand(SQLInsert, CN)

                        CMD.Parameters.Add("@CodRecibo",
                                       SqlDbType.NVarChar, 50).Value =
                                       numeroRecibo

                        CMD.Parameters.Add("@Fecha_Recibo",
                                       SqlDbType.SmallDateTime).Value =
                                       fecha

                        CMD.Parameters.Add("@NombrePago",
                                       SqlDbType.NVarChar, 50).Value =
                                       nombrePago

                        CMD.Parameters.Add("@Monto",
                                       SqlDbType.Float).Value =
                                       Convert.ToDouble(montoPagado)

                        CMD.Parameters.Add("@NumeroTarjeta",
                                       SqlDbType.NVarChar, 50).Value =
                                       numeroTarjeta

                        CMD.Parameters.Add("@Fecha_Vence",
                                       SqlDbType.SmallDateTime).Value =
                                       fechaVence

                        CMD.ExecuteNonQuery()

                    End Using

                End If

            End Using

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    Public Function GrabarMetodoDetalleReciboPlanilla(
    ByVal CN As SqlConnection,
    ByVal Trans As SqlTransaction,
    ByVal NumeroRecibo As String,
    ByVal FechaRecibo As Date,
    ByVal NombrePago As String,
    ByVal MontoPagado As Decimal,
    ByVal NumeroTarjeta As String,
    ByVal FechaVence As Nullable(Of Date)
) As Boolean

        Dim SQL As String =
        "INSERT INTO Detalle_MetodoRecibo " &
        "(CodRecibo, Fecha_Recibo, NombrePago, Monto, " &
        "NumeroTarjeta, Fecha_Vence) " &
        "VALUES " &
        "(@CodRecibo, @Fecha_Recibo, @NombrePago, @Monto, " &
        "@NumeroTarjeta, @Fecha_Vence)"

        Using CMD As New SqlCommand(SQL, CN, Trans)

            CMD.Parameters.Add(
            "@CodRecibo",
            SqlDbType.NVarChar,
            50).Value =
            If(NumeroRecibo, "")

            CMD.Parameters.Add(
            "@Fecha_Recibo",
            SqlDbType.SmallDateTime).Value =
            FechaRecibo.Date

            CMD.Parameters.Add(
            "@NombrePago",
            SqlDbType.NVarChar,
            50).Value =
            If(NombrePago, "")

            CMD.Parameters.Add(
            "@Monto",
            SqlDbType.Float).Value =
            Convert.ToDouble(MontoPagado)

            CMD.Parameters.Add(
            "@NumeroTarjeta",
            SqlDbType.NVarChar,
            50).Value =
            If(NumeroTarjeta, "")

            If FechaVence.HasValue Then

                CMD.Parameters.Add(
                "@Fecha_Vence",
                SqlDbType.SmallDateTime).Value =
                FechaVence.Value

            Else

                CMD.Parameters.Add(
                "@Fecha_Vence",
                SqlDbType.SmallDateTime).Value =
                DBNull.Value

            End If

            Return CMD.ExecuteNonQuery() = 1

        End Using

    End Function

    '==========================================================
    ' CONSULTA DE METODOS DE PAGO DEL RECIBO
    '==========================================================

    '==========================================================
    ' OBTENER METODOS DE PAGO DEL RECIBO
    '==========================================================
    Public Function ObtenerMetodosPagoRecibo(
    ByVal numeroRecibo As String,
    ByVal fecha As Date) As DataTable

        Dim Resultado As New DataTable
        Dim SQL As String

        SQL =
        "SELECT " &
        "NombrePago, " &
        "MAX(NumeroTarjeta) AS NumeroTarjeta, " &
        "MAX(FechaVence) AS FechaVence, " &
        "SUM(MontoPagado) AS MontoPagado " &
        "FROM DetalleRecibo " &
        "WHERE CodReciboPago = @CodReciboPago " &
        "AND Fecha_Recibo = @Fecha_Recibo " &
        "GROUP BY NombrePago"

        Try

            Using CN As New SqlConnection(_Conexion)

                Using CMD As New SqlCommand(SQL, CN)

                    CMD.Parameters.Add(
                    "@CodReciboPago",
                    SqlDbType.NVarChar,
                    50).Value = numeroRecibo

                    CMD.Parameters.Add(
                    "@Fecha_Recibo",
                    SqlDbType.SmallDateTime).Value = fecha

                    Using DA As New SqlDataAdapter(CMD)

                        DA.Fill(Resultado)

                    End Using

                End Using

            End Using

            Return Resultado

        Catch ex As Exception

            Return Resultado

        End Try

    End Function
    '==========================================================
    ' ACTUALIZAR MONTO CREDITO DE FACTURA
    '==========================================================
    Public Function ActualizarMontoCreditoFactura(
    ByVal numeroFactura As String,
    ByVal montoCredito As Decimal) As Boolean

        Try

            Dim SQL As String

            SQL =
            "UPDATE Facturas SET " &
            "MontoCredito = @MontoCredito " &
            "WHERE Numero_Factura = @Numero_Factura"

            Using CN As New SqlConnection(_Conexion)

                Using CMD As New SqlCommand(SQL, CN)

                    CMD.Parameters.Add(
                    "@MontoCredito",
                    SqlDbType.Float).Value =
                    Convert.ToDouble(montoCredito)

                    CMD.Parameters.Add(
                    "@Numero_Factura",
                    SqlDbType.NVarChar, 50).Value =
                    numeroFactura

                    CN.Open()

                    CMD.ExecuteNonQuery()

                End Using

            End Using

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    '==========================================================
    ' ACTUALIZAR ESTADO DE FACTURA
    '==========================================================
    Public Function ActualizarEstadoFactura(
    ByVal numeroFactura As String) As Boolean

        Try

            Dim SQL As String

            SQL =
            "UPDATE Facturas SET " &
            "Activo = 0 " &
            "WHERE Numero_Factura = @Numero_Factura " &
            "AND Tipo_Factura = @Tipo_Factura " &
            "AND MontoCredito = 0"

            Using CN As New SqlConnection(_Conexion)

                Using CMD As New SqlCommand(SQL, CN)

                    CMD.Parameters.Add(
                    "@Numero_Factura",
                    SqlDbType.NVarChar, 50).Value =
                    numeroFactura

                    CMD.Parameters.Add(
                    "@Tipo_Factura",
                    SqlDbType.NVarChar, 50).Value =
                    "Factura"

                    CN.Open()

                    CMD.ExecuteNonQuery()

                End Using

            End Using

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    '==========================================================
    ' OBTENER DATOS DE FACTURA
    '==========================================================
    Public Function ObtenerFactura(
    ByVal numeroFactura As String) As DataTable

        Dim Resultado As New DataTable

        Dim SQL As String

        SQL =
        "SELECT * " &
        "FROM Facturas " &
        "WHERE Numero_Factura = @Numero_Factura " &
        "AND Tipo_Factura = @Tipo_Factura " &
        "ORDER BY Fecha_Factura DESC"


        Using CN As New SqlConnection(_Conexion)

            Using CMD As New SqlCommand(SQL, CN)

                CMD.Parameters.Add(
                "@Numero_Factura",
                SqlDbType.NVarChar,
                50).Value = numeroFactura

                CMD.Parameters.Add(
                "@Tipo_Factura",
                SqlDbType.NVarChar,
                50).Value = "Factura"


                Using DA As New SqlDataAdapter(CMD)

                    DA.Fill(Resultado)

                End Using

            End Using

        End Using


        Return Resultado

    End Function


    '==========================================================
    ' ANULAR RECIBO
    '
    ' La anulación:
    '   1. Inactiva el Recibo.
    '   2. Marca el Recibo como contabilizado.
    '   3. Coloca MontoPagado = 0 en DetalleRecibo.
    '   4. Anula las aplicaciones activas de Plan de Pago.
    '   5. Conserva todo el historial.
    '
    ' Todo se ejecuta dentro de una sola transacción.
    '==========================================================
    Public Function AnularRecibo(
    ByVal numeroRecibo As String,
    ByVal fecha As Date,
    ByVal codigoCliente As String,
    ByVal usuario As String,
    ByVal motivo As String) As Boolean

        Using CN As New SqlConnection(_Conexion)

            CN.Open()

            Dim Transaccion As SqlTransaction =
            CN.BeginTransaction()

            Try

                '==========================================================
                ' 1. VERIFICAR QUE EL RECIBO ESTE ACTIVO
                '==========================================================

                Dim SQLExiste As String

                SQLExiste =
                "SELECT COUNT(*) " &
                "FROM Recibo " &
                "WHERE CodReciboPago = @CodReciboPago " &
                "AND Fecha_Recibo = @Fecha_Recibo " &
                "AND Cod_Cliente = @Cod_Cliente " &
                "AND Activo = 1"

                Using CMD As New SqlCommand(
                SQLExiste,
                CN,
                Transaccion)

                    CMD.Parameters.Add(
                    "@CodReciboPago",
                    SqlDbType.NVarChar,
                    50).Value =
                    numeroRecibo

                    CMD.Parameters.Add(
                    "@Fecha_Recibo",
                    SqlDbType.SmallDateTime).Value =
                    fecha

                    CMD.Parameters.Add(
                    "@Cod_Cliente",
                    SqlDbType.NVarChar,
                    50).Value =
                    codigoCliente

                    Dim Existe As Integer =
                    Convert.ToInt32(
                        CMD.ExecuteScalar())

                    If Existe = 0 Then

                        Transaccion.Rollback()

                        Return False

                    End If

                End Using


                '==========================================================
                ' 2. ANULAR ENCABEZADO DEL RECIBO
                '==========================================================

                Dim SQLRecibo As String

                SQLRecibo =
                "UPDATE Recibo SET " &
                "Contabilizado = 1, " &
                "Activo = 0, " &
                "NombreCliente = '******CANCELADO', " &
                "ApellidosCliente = '******' " &
                "WHERE CodReciboPago = @CodReciboPago " &
                "AND Fecha_Recibo = @Fecha_Recibo " &
                "AND Cod_Cliente = @Cod_Cliente " &
                "AND Activo = 1"

                Using CMD As New SqlCommand(
                SQLRecibo,
                CN,
                Transaccion)

                    CMD.Parameters.Add(
                    "@CodReciboPago",
                    SqlDbType.NVarChar,
                    50).Value =
                    numeroRecibo

                    CMD.Parameters.Add(
                    "@Fecha_Recibo",
                    SqlDbType.SmallDateTime).Value =
                    fecha

                    CMD.Parameters.Add(
                    "@Cod_Cliente",
                    SqlDbType.NVarChar,
                    50).Value =
                    codigoCliente

                    CMD.ExecuteNonQuery()

                End Using


                '==========================================================
                ' 3. ANULAR LOS MONTOS DEL DETALLE DEL RECIBO
                '==========================================================

                Dim SQLDetalle As String

                SQLDetalle =
                "UPDATE DetalleRecibo SET " &
                "MontoPagado = 0 " &
                "WHERE CodReciboPago = @CodReciboPago " &
                "AND Fecha_Recibo = @Fecha_Recibo"

                Using CMD As New SqlCommand(
                SQLDetalle,
                CN,
                Transaccion)

                    CMD.Parameters.Add(
                    "@CodReciboPago",
                    SqlDbType.NVarChar,
                    50).Value =
                    numeroRecibo

                    CMD.Parameters.Add(
                    "@Fecha_Recibo",
                    SqlDbType.SmallDateTime).Value =
                    fecha

                    CMD.ExecuteNonQuery()

                End Using


                '==========================================================
                ' 4. LIBERAR APLICACIONES DE PLAN PAGO
                '
                ' NO SE ELIMINAN.
                ' Se conservan como historial y se marcan como anuladas.
                '==========================================================

                Dim SQLAplicaciones As String

                SQLAplicaciones =
                "UPDATE A SET " &
                "A.Anulado = 1, " &
                "A.FechaAnulacion = GETDATE(), " &
                "A.UsuarioAnulacion = @UsuarioAnulacion, " &
                "A.MotivoAnulacion = @MotivoAnulacion " &
                "FROM AplicacionPagoPlan A " &
                "INNER JOIN DetalleRecibo D " &
                "    ON D.idDetalleRecibo = A.idDetalleRecibo " &
                "WHERE D.CodReciboPago = @CodReciboPago " &
                "AND D.Fecha_Recibo = @Fecha_Recibo " &
                "AND A.Anulado = 0"

                Using CMD As New SqlCommand(
                SQLAplicaciones,
                CN,
                Transaccion)

                    CMD.Parameters.Add(
                    "@CodReciboPago",
                    SqlDbType.NVarChar,
                    50).Value =
                    numeroRecibo

                    CMD.Parameters.Add(
                    "@Fecha_Recibo",
                    SqlDbType.SmallDateTime).Value =
                    fecha

                    CMD.Parameters.Add(
                    "@UsuarioAnulacion",
                    SqlDbType.NVarChar,
                    100).Value =
                    usuario

                    CMD.Parameters.Add(
                    "@MotivoAnulacion",
                    SqlDbType.NVarChar,
                    500).Value =
                    motivo

                    CMD.ExecuteNonQuery()

                End Using


                '==========================================================
                ' 5. CONFIRMAR TODA LA OPERACION
                '==========================================================

                Transaccion.Commit()

                Return True

            Catch ex As Exception

                Try

                    Transaccion.Rollback()

                Catch

                End Try

                Return False

            End Try

        End Using

    End Function
    '==========================================================
    ' VERIFICAR SI EL RECIBO TIENE APLICACIONES
    ' ACTIVAS DE PLAN DE PAGO
    '==========================================================
    Public Function TieneAplicacionesPlanPagoActivas(
    ByVal numeroRecibo As String,
    ByVal fecha As Date) As Boolean

        Dim SQL As String
        Dim Resultado As Integer = 0

        SQL =
        "SELECT COUNT(*) " &
        "FROM AplicacionPagoPlan A " &
        "INNER JOIN DetalleRecibo D " &
        "    ON D.idDetalleRecibo = A.idDetalleRecibo " &
        "WHERE D.CodReciboPago = @CodReciboPago " &
        "AND D.Fecha_Recibo = @Fecha_Recibo " &
        "AND A.Anulado = 0"


        Try

            Using CN As New SqlConnection(_Conexion)

                Using CMD As New SqlCommand(SQL, CN)

                    CMD.Parameters.Add(
                    "@CodReciboPago",
                    SqlDbType.NVarChar,
                    50).Value = numeroRecibo

                    CMD.Parameters.Add(
                    "@Fecha_Recibo",
                    SqlDbType.DateTime).Value = fecha

                    CN.Open()

                    Resultado =
                    Convert.ToInt32(
                        CMD.ExecuteScalar())

                End Using

            End Using


            Return Resultado > 0


        Catch ex As Exception

            Return False

        End Try

    End Function

    '==========================================================
    ' VALIDAR SI EL RECIBO PUEDE SER EDITADO
    '==========================================================
    Public Function PuedeEditarRecibo(
        ByVal numeroRecibo As String,
        ByVal fecha As Date) As Boolean

        Try

            If TieneAplicacionesPlanPagoActivas(
                numeroRecibo,
                fecha) Then

                Return False

            End If

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function


    Public Function EliminarDetalleRecibo(
        ByVal idDetalleRecibo As Decimal) As Boolean

        If idDetalleRecibo <= 0 Then
            Return False
        End If

        Using MiConexion As New SqlClient.SqlConnection(_Conexion)

            MiConexion.Open()

            Dim SqlDelete As String =
                "DELETE FROM DetalleRecibo " &
                "WHERE idDetalleRecibo = @idDetalleRecibo"

            Using Comando As New SqlClient.SqlCommand(SqlDelete, MiConexion)

                Comando.Parameters.Add(
                    "@idDetalleRecibo",
                    SqlDbType.Decimal).Value = idDetalleRecibo

                Dim filasAfectadas As Integer = Comando.ExecuteNonQuery()

                Return filasAfectadas > 0

            End Using

        End Using

    End Function

    Public Function ObtenerRecibosPlanilla(
    ByVal NumNomina As String) As List(Of AplicacionPlanPendiente)

        Dim Lista As New List(Of AplicacionPlanPendiente)

        If String.IsNullOrWhiteSpace(NumNomina) Then
            Return Lista
        End If

        Dim SQL As String =
        "SELECT " &
        "PPP.CodProductor, " &
        "PPP.idDetallePago, " &
        "DP.NumeroCuota, " &
        "DP.FechaVencimiento, " &
        "PP.NumeroCredito, " &
        "PP.NumeroFactura, " &
        "PP.FechaFactura, " &
        "PP.TipoFactura, " &
        "PPP.MontoCobrado, " &
        "ISNULL(C.Nombre_Cliente, '') AS NombreCliente, " &
        "ISNULL(C.Apellido_Cliente, '') AS ApellidosCliente, " &
        "ISNULL(PP.MonedaFactura, 'Cordobas') AS Moneda " &
        "FROM PlanillaPlanPago PPP " &
        "INNER JOIN DetallePagos DP " &
        "ON DP.idDetallePago = PPP.idDetallePago " &
        "INNER JOIN PlanPagos PP " &
        "ON PP.NumeroCredito = DP.NumeroCredito " &
        "INNER JOIN Clientes C " &
        "ON C.Cod_Cliente = PPP.CodProductor " &
        "WHERE PPP.NumNomina = @NumNomina " &
        "AND PPP.MontoCobrado > 0 " &
        "AND ISNULL(DP.Anulado, 0) = 0 " &
        "AND ISNULL(PP.Anulado, 0) = 0 " &
        "AND NOT EXISTS ( " &
        "    SELECT 1 " &
        "    FROM AplicacionPagoPlan APP " &
        "    WHERE APP.idDetallePago = PPP.idDetallePago " &
        "    AND ISNULL(APP.Anulado, 0) = 0 " &
        ") " &
        "ORDER BY PPP.CodProductor, " &
        "DP.NumeroCuota, " &
        "PPP.idDetallePago"

        Using CN As New SqlConnection(_Conexion)

            CN.Open()

            Using CMD As New SqlCommand(SQL, CN)

                CMD.Parameters.Add(
                "@NumNomina",
                SqlDbType.NVarChar,
                50).Value =
                NumNomina.Trim()

                Using DR As SqlDataReader = CMD.ExecuteReader()

                    While DR.Read()

                        Dim Item As New AplicacionPlanPendiente()

                        '==================================================
                        ' DATOS DEL PLAN DE PAGOS
                        '==================================================

                        Item.IdDetallePago =
                        If(IsDBNull(DR("idDetallePago")),
                           0,
                           Convert.ToInt32(DR("idDetallePago")))

                        Item.NumeroCuota =
                        If(IsDBNull(DR("NumeroCuota")),
                           0,
                           Convert.ToInt32(DR("NumeroCuota")))

                        Item.NumeroFactura =
                        If(IsDBNull(DR("NumeroFactura")),
                           "",
                           Convert.ToString(DR("NumeroFactura")))

                        Item.FechaFactura =
                        If(IsDBNull(DR("FechaFactura")),
                           Date.MinValue,
                           Convert.ToDateTime(DR("FechaFactura")))

                        Item.TipoFactura =
                        If(IsDBNull(DR("TipoFactura")),
                           "Factura",
                           Convert.ToString(DR("TipoFactura")))

                        Item.MontoAplicado =
                        If(IsDBNull(DR("MontoCobrado")),
                           0D,
                           Convert.ToDecimal(DR("MontoCobrado")))

                        Item.FechaVence =
                        If(IsDBNull(DR("FechaVencimiento")),
                           Date.MinValue,
                           Convert.ToDateTime(DR("FechaVencimiento")))

                        '==================================================
                        ' MÉTODO DE PAGO
                        '==================================================

                        Item.NombrePago = "Efectivo"
                        Item.NumeroTarjeta = ""

                        '==================================================
                        ' DATOS DEL CLIENTE / PRODUCTOR
                        '==================================================

                        Item.CodigoCliente =
                        If(IsDBNull(DR("CodProductor")),
                           "",
                           Convert.ToString(DR("CodProductor")))

                        Item.NombreCliente =
                        If(IsDBNull(DR("NombreCliente")),
                           "",
                           Convert.ToString(DR("NombreCliente")))

                        Item.ApellidosCliente =
                        If(IsDBNull(DR("ApellidosCliente")),
                           "",
                           Convert.ToString(DR("ApellidosCliente")))

                        Item.Moneda =
                        If(IsDBNull(DR("Moneda")),
                           "Cordobas",
                           Convert.ToString(DR("Moneda")))

                        Lista.Add(Item)

                    End While

                End Using

            End Using

        End Using

        Return Lista

    End Function

    Public Function GrabarReciboPlanillaPorProductor(
    ByVal NumeroRecibo As String,
    ByVal FechaRecibo As Date,
    ByVal CodigoCliente As String,
    ByVal NombreCliente As String,
    ByVal ApellidosCliente As String,
    ByVal Moneda As String,
    ByVal Usuario As String,
    ByVal Aplicaciones As List(Of AplicacionPlanPendiente)
) As Boolean

        '==========================================================
        ' VALIDACIONES
        '==========================================================

        If String.IsNullOrWhiteSpace(NumeroRecibo) Then
            Throw New Exception(
                "El número de recibo es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(CodigoCliente) Then
            Throw New Exception(
                "El código del cliente es obligatorio.")
        End If

        If Aplicaciones Is Nothing OrElse
           Aplicaciones.Count = 0 Then

            Throw New Exception(
                "El productor no tiene abonos de Plan de Pago.")
        End If


        '==========================================================
        ' CALCULAR TOTAL DEL RECIBO
        '==========================================================

        Dim TotalRecibo As Decimal = 0D

        For Each Aplicacion As AplicacionPlanPendiente In Aplicaciones

            If Aplicacion.MontoAplicado > 0D Then

                TotalRecibo +=
                    Aplicacion.MontoAplicado

            End If

        Next


        If TotalRecibo <= 0D Then

            Throw New Exception(
                "El monto total del recibo debe ser mayor que cero.")

        End If


        '==========================================================
        ' CONEXIÓN
        '==========================================================

        Using CN As New SqlConnection(_Conexion)

            CN.Open()

            Using Trans As SqlTransaction =
                CN.BeginTransaction()

                Try

                    '==================================================
                    ' 1. GRABAR ENCABEZADO DEL RECIBO
                    '==================================================

                    Dim SQLRecibo As String =
                    "INSERT INTO Recibo " &
                    "(CodReciboPago, Fecha_Recibo, Cod_Cliente, Cod_Cajero, " &
                    "Sub_Total, Descuento, Total, NombreCliente, " &
                    "ApellidosCliente, DireccionCliente, TelefonoCliente, " &
                    "MonedaRecibo, Observaciones) " &
                    "VALUES " &
                    "(@CodReciboPago, @Fecha_Recibo, @Cod_Cliente, @Cod_Cajero, " &
                    "@Sub_Total, @Descuento, @Total, @NombreCliente, " &
                    "@ApellidosCliente, @DireccionCliente, @TelefonoCliente, " &
                    "@MonedaRecibo, @Observaciones)"


                    Using CMD As New SqlCommand(
                        SQLRecibo,
                        CN,
                        Trans)

                        CMD.Parameters.Add(
                            "@CodReciboPago",
                            SqlDbType.NVarChar,
                            50).Value =
                            NumeroRecibo

                        CMD.Parameters.Add(
                            "@Fecha_Recibo",
                            SqlDbType.SmallDateTime).Value =
                            FechaRecibo.Date

                        CMD.Parameters.Add(
                            "@Cod_Cliente",
                            SqlDbType.NVarChar,
                            50).Value =
                            CodigoCliente

                        CMD.Parameters.Add(
                            "@Cod_Cajero",
                            SqlDbType.NVarChar,
                            50).Value =
                            If(Usuario, "")

                        CMD.Parameters.Add(
                            "@Sub_Total",
                            SqlDbType.Float).Value =
                            Convert.ToDouble(TotalRecibo)

                        CMD.Parameters.Add(
                            "@Descuento",
                            SqlDbType.Float).Value =
                            0D

                        CMD.Parameters.Add(
                            "@Total",
                            SqlDbType.Float).Value =
                            Convert.ToDouble(TotalRecibo)

                        CMD.Parameters.Add(
                            "@NombreCliente",
                            SqlDbType.NVarChar,
                            -1).Value =
                            If(NombreCliente, "")

                        CMD.Parameters.Add(
                            "@ApellidosCliente",
                            SqlDbType.NVarChar,
                            -1).Value =
                            If(ApellidosCliente, "")

                        CMD.Parameters.Add(
                            "@DireccionCliente",
                            SqlDbType.NVarChar,
                            -1).Value =
                            ""

                        CMD.Parameters.Add(
                            "@TelefonoCliente",
                            SqlDbType.NVarChar,
                            -1).Value =
                            ""

                        CMD.Parameters.Add(
                            "@MonedaRecibo",
                            SqlDbType.NVarChar,
                            50).Value =
                            If(Moneda, "")

                        CMD.Parameters.Add(
                            "@Observaciones",
                            SqlDbType.NVarChar,
                            -1).Value =
                            "Recibo generado desde Planilla de Leche."

                        CMD.ExecuteNonQuery()

                    End Using


                    '==================================================
                    ' 2. GRABAR CADA ABONO COMO DETALLE DEL RECIBO
                    '==================================================

                    Dim TotalMetodoPago As Decimal = 0D


                    For Each Aplicacion As AplicacionPlanPendiente In Aplicaciones

                        If Aplicacion.MontoAplicado <= 0D Then
                            Continue For
                        End If


                        '------------------------------------------------
                        ' Buscar datos de la factura
                        '------------------------------------------------

                        Dim MontoFactura As Decimal = 0D
                        Dim FechaVencimiento As Nullable(Of Date) = Nothing


                        Dim SQLFactura As String =
                        "SELECT " &
                        "MontoCredito, " &
                        "Fecha_Vencimiento " &
                        "FROM Facturas " &
                        "WHERE Numero_Factura = @NumeroFactura " &
                        "AND Tipo_Factura = 'Factura'"


                        Using CMD As New SqlCommand(
                            SQLFactura,
                            CN,
                            Trans)

                            CMD.Parameters.Add(
                                "@NumeroFactura",
                                SqlDbType.NVarChar,
                                50).Value =
                                Aplicacion.NumeroFactura


                            Using DR As SqlDataReader =
                                CMD.ExecuteReader()

                                If DR.Read() Then

                                    If Not IsDBNull(
                                        DR("MontoCredito")) Then

                                        MontoFactura =
                                            Convert.ToDecimal(
                                                DR("MontoCredito"))

                                    End If


                                    If Not IsDBNull(
                                        DR("Fecha_Vencimiento")) Then

                                        FechaVencimiento =
                                            Convert.ToDateTime(
                                                DR("Fecha_Vencimiento"))

                                    End If

                                End If

                            End Using

                        End Using


                        '------------------------------------------------
                        ' Grabar detalle
                        '------------------------------------------------

                        Dim IdDetalleRecibo As Decimal


                        IdDetalleRecibo =
                        GrabarDetalleReciboPlanilla(
                            CN,
                            Trans,
                            NumeroRecibo,
                            FechaRecibo,
                            Aplicacion.NumeroFactura,
                            Aplicacion.MontoAplicado,
                            "Efectivo",
                            "Abono Plan de Pago",
                            "",
                            FechaVencimiento,
                            MontoFactura,
                            Aplicacion.MontoAplicado,
                            MontoFactura -
                            Aplicacion.MontoAplicado,
                            1D,
                            "")


                        If IdDetalleRecibo <= 0D Then

                            Throw New Exception(
                                "No se pudo grabar el detalle del recibo " &
                                NumeroRecibo &
                                " para la factura " &
                                Aplicacion.NumeroFactura & ".")

                        End If


                        '------------------------------------------------
                        ' Registrar aplicación al Plan de Pago
                        '------------------------------------------------

                        Dim SQLAplicacion As String =
                        "INSERT INTO AplicacionPagoPlan " &
                        "(idDetallePago, idDetalleRecibo, MontoAplicado, " &
                        "FechaAplicacion, UsuarioAplicacion, Anulado, " &
                        "FechaRegistro, CodReciboPago, Fecha_Recibo, " &
                        "Numero_Factura) " &
                        "VALUES " &
                        "(@idDetallePago, @idDetalleRecibo, " &
                        "@MontoAplicado, @FechaAplicacion, " &
                        "@UsuarioAplicacion, 0, SYSDATETIME(), " &
                        "@CodReciboPago, @Fecha_Recibo, " &
                        "@Numero_Factura)"


                        Using CMD As New SqlCommand(
                            SQLAplicacion,
                            CN,
                            Trans)

                            CMD.Parameters.Add(
                                "@idDetallePago",
                                SqlDbType.Int).Value =
                                Aplicacion.IdDetallePago

                            CMD.Parameters.Add(
                                "@idDetalleRecibo",
                                SqlDbType.Decimal).Value =
                                IdDetalleRecibo

                            CMD.Parameters.Add(
                                "@MontoAplicado",
                                SqlDbType.Decimal).Value =
                                Aplicacion.MontoAplicado

                            CMD.Parameters.Add(
                                "@FechaAplicacion",
                                SqlDbType.DateTime2).Value =
                                DateTime.Now

                            CMD.Parameters.Add(
                                "@UsuarioAplicacion",
                                SqlDbType.NVarChar,
                                50).Value =
                                If(Usuario, "")

                            CMD.Parameters.Add(
                                "@CodReciboPago",
                                SqlDbType.NVarChar,
                                50).Value =
                                NumeroRecibo

                            CMD.Parameters.Add(
                                "@Fecha_Recibo",
                                SqlDbType.SmallDateTime).Value =
                                FechaRecibo.Date

                            CMD.Parameters.Add(
                                "@Numero_Factura",
                                SqlDbType.NVarChar,
                                50).Value =
                                Aplicacion.NumeroFactura

                            CMD.ExecuteNonQuery()

                        End Using


                        TotalMetodoPago +=
                            Aplicacion.MontoAplicado

                    Next


                    '==================================================
                    ' 3. GRABAR MÉTODO DE PAGO
                    '==================================================

                    If TotalMetodoPago <= 0D Then

                        Throw New Exception(
                            "No se pudo determinar el monto del método de pago.")

                    End If


                    If Not GrabarMetodoDetalleReciboPlanilla(
                        CN,
                        Trans,
                        NumeroRecibo,
                        FechaRecibo,
                        "Efectivo",
                        TotalMetodoPago,
                        "",
                        Nothing) Then

                        Throw New Exception(
                            "No se pudo registrar el método de pago " &
                            "Efectivo para el recibo " &
                            NumeroRecibo & ".")

                    End If


                    '==================================================
                    ' 4. CONFIRMAR
                    '==================================================

                    Trans.Commit()

                    Return True


                Catch

                    '==================================================
                    ' DESHACER TODO
                    '==================================================

                    Try
                        Trans.Rollback()
                    Catch
                        'Mantener error original
                    End Try

                    Throw

                End Try

            End Using

        End Using

    End Function

    Public Function GrabarReciboPlanillaPorProductor(
    ByVal CodigoProductor As String,
    ByVal TipoProductor As String,
    ByVal NombreProductor As String,
    ByVal FechaRecibo As Date,
    ByVal Serie As String,
    ByVal Aplicaciones As List(Of AplicacionPlanPendiente)
) As String

        '==========================================================
        ' VALIDACIONES
        '==========================================================

        If String.IsNullOrWhiteSpace(CodigoProductor) Then
            Throw New Exception(
                "No se puede generar el recibo: el código del productor está vacío.")
        End If

        If String.IsNullOrWhiteSpace(Serie) Then
            Throw New Exception(
                "No se puede generar el recibo: la serie está vacía.")
        End If

        If Aplicaciones Is Nothing OrElse Aplicaciones.Count = 0 Then
            Throw New Exception(
                "No existen abonos del Plan de Pago para generar el recibo.")
        End If


        '==========================================================
        ' VALIDAR QUE TODOS LOS ABONOS SEAN DEL MISMO PRODUCTOR
        '==========================================================
        '
        ' La clase AplicacionPlanPendiente no contiene CodProductor.
        ' Por eso esta validación se hace sobre la lista recibida
        ' únicamente para asegurar que existan aplicaciones.
        '
        ' El productor ya viene determinado por CodigoProductor.


        Using CN As New SqlConnection(_Conexion)

            CN.Open()

            Using Trans As SqlTransaction = CN.BeginTransaction()

                Try

                    '==================================================
                    ' 1. OBTENER NÚMERO DE RECIBO
                    '==================================================

                    Dim NumeroRecibo As String =
                        ObtenerNumeroReciboPlanilla(Serie)

                    If String.IsNullOrWhiteSpace(NumeroRecibo) Then

                        Throw New Exception(
                            "No fue posible obtener el número de recibo para la serie " &
                            Serie & ".")

                    End If


                    '==================================================
                    ' 2. OBTENER DATOS DEL CLIENTE
                    '==================================================

                    Dim NombreCliente As String = NombreProductor
                    Dim ApellidoCliente As String = ""
                    Dim DireccionCliente As String = ""
                    Dim TelefonoCliente As String = ""


                    Dim SQLCliente As String =
                        "SELECT " &
                        "Nombre_Cliente, " &
                        "Apellido_Cliente, " &
                        "Direccion_Cliente, " &
                        "Telefono " &
                        "FROM Clientes " &
                        "WHERE Cod_Cliente = @CodCliente"


                    Using CMDCliente As New SqlCommand(
                        SQLCliente,
                        CN,
                        Trans)

                        CMDCliente.Parameters.Add(
                            "@CodCliente",
                            SqlDbType.NVarChar,
                            50).Value =
                            CodigoProductor


                        Using DR As SqlDataReader =
                            CMDCliente.ExecuteReader()

                            If DR.Read() Then

                                If Not IsDBNull(DR("Nombre_Cliente")) Then
                                    NombreCliente =
                                        DR("Nombre_Cliente").ToString()
                                End If

                                If Not IsDBNull(DR("Apellido_Cliente")) Then
                                    ApellidoCliente =
                                        DR("Apellido_Cliente").ToString()
                                End If

                                If Not IsDBNull(DR("Direccion_Cliente")) Then
                                    DireccionCliente =
                                        DR("Direccion_Cliente").ToString()
                                End If

                                If Not IsDBNull(DR("Telefono")) Then
                                    TelefonoCliente =
                                        DR("Telefono").ToString()
                                End If

                            End If

                        End Using

                    End Using


                    '==================================================
                    ' 3. CALCULAR TOTAL DEL RECIBO
                    '==================================================

                    Dim TotalRecibo As Decimal = 0D

                    For Each Aplicacion As AplicacionPlanPendiente In Aplicaciones

                        If Aplicacion.MontoAplicado > 0D Then

                            TotalRecibo +=
                                Aplicacion.MontoAplicado

                        End If

                    Next


                    If TotalRecibo <= 0D Then

                        Throw New Exception(
                            "El total de los abonos del productor es cero.")

                    End If


                    '==================================================
                    ' 4. DETERMINAR MONEDA
                    '==================================================

                    Dim MonedaRecibo As String = "Cordobas"

                    ' Las aplicaciones actualmente no contienen
                    ' Moneda como propiedad.
                    '
                    ' Para Planilla se utiliza Cordobas como moneda
                    ' predeterminada.


                    '==================================================
                    ' 5. GRABAR CABECERA DEL RECIBO
                    '==================================================

                    Dim SQLRecibo As String =
                        "INSERT INTO Recibo " &
                        "(CodReciboPago, Fecha_Recibo, Cod_Cliente, " &
                        "Cod_Cajero, Sub_Total, Descuento, Total, " &
                        "NombreCliente, ApellidosCliente, " &
                        "DireccionCliente, TelefonoCliente, " &
                        "MonedaRecibo, Activo, Contabilizado, Marca, " &
                        "Observaciones) " &
                        "VALUES " &
                        "(@CodReciboPago, @FechaRecibo, @CodCliente, " &
                        "@CodCajero, @SubTotal, @Descuento, @Total, " &
                        "@NombreCliente, @ApellidosCliente, " &
                        "@DireccionCliente, @TelefonoCliente, " &
                        "@MonedaRecibo, 1, 0, 1, @Observaciones)"


                    Using CMDRecibo As New SqlCommand(
                        SQLRecibo,
                        CN,
                        Trans)

                        CMDRecibo.Parameters.Add(
                            "@CodReciboPago",
                            SqlDbType.NVarChar,
                            50).Value =
                            NumeroRecibo

                        CMDRecibo.Parameters.Add(
                            "@FechaRecibo",
                            SqlDbType.SmallDateTime).Value =
                            FechaRecibo.Date

                        CMDRecibo.Parameters.Add(
                            "@CodCliente",
                            SqlDbType.NVarChar,
                            50).Value =
                            CodigoProductor

                        CMDRecibo.Parameters.Add(
                            "@CodCajero",
                            SqlDbType.NVarChar,
                            50).Value =
                            ""

                        CMDRecibo.Parameters.Add(
                            "@SubTotal",
                            SqlDbType.Float).Value =
                            Convert.ToDouble(TotalRecibo)

                        CMDRecibo.Parameters.Add(
                            "@Descuento",
                            SqlDbType.Float).Value =
                            0D

                        CMDRecibo.Parameters.Add(
                            "@Total",
                            SqlDbType.Float).Value =
                            Convert.ToDouble(TotalRecibo)

                        CMDRecibo.Parameters.Add(
                            "@NombreCliente",
                            SqlDbType.NVarChar,
                            -1).Value =
                            NombreCliente

                        CMDRecibo.Parameters.Add(
                            "@ApellidosCliente",
                            SqlDbType.NVarChar,
                            -1).Value =
                            ApellidoCliente

                        CMDRecibo.Parameters.Add(
                            "@DireccionCliente",
                            SqlDbType.NVarChar,
                            -1).Value =
                            DireccionCliente

                        CMDRecibo.Parameters.Add(
                            "@TelefonoCliente",
                            SqlDbType.NVarChar,
                            -1).Value =
                            TelefonoCliente

                        CMDRecibo.Parameters.Add(
                            "@MonedaRecibo",
                            SqlDbType.NVarChar,
                            50).Value =
                            MonedaRecibo

                        CMDRecibo.Parameters.Add(
                            "@Observaciones",
                            SqlDbType.NVarChar,
                            -1).Value =
                            "Recibo generado automáticamente desde Planilla de Leche. " &
                            "Tipo Productor: " & TipoProductor

                        CMDRecibo.ExecuteNonQuery()

                    End Using


                    '==================================================
                    ' 6. GRABAR DETALLES DEL RECIBO
                    '==================================================

                    For Each Aplicacion As AplicacionPlanPendiente In Aplicaciones

                        If Aplicacion.MontoAplicado <= 0D Then
                            Continue For
                        End If


                        '----------------------------------------------
                        ' Monto de la factura
                        '----------------------------------------------

                        Dim MontoFactura As Decimal =
                            Aplicacion.MontoAplicado


                        '----------------------------------------------
                        ' Saldo después de aplicar
                        '
                        ' Como aquí estamos registrando el abono,
                        ' posteriormente la aplicación del Plan de
                        ' Pago es la que controla el saldo real.
                        '----------------------------------------------

                        Dim SaldoFactura As Decimal = 0D


                        Dim Descripcion As String =
                            "Abono Plan de Pago - Cuota " &
                            Aplicacion.NumeroCuota.ToString()


                        Dim IdDetalleRecibo As Decimal =
                            GrabarDetalleReciboPlanilla(
                                NumeroRecibo,
                                FechaRecibo,
                                Aplicacion.NumeroFactura,
                                Aplicacion.MontoAplicado,
                                "Efectivo",
                                Descripcion,
                                Aplicacion.NumeroTarjeta,
                                Aplicacion.FechaVence,
                                MontoFactura,
                                Aplicacion.MontoAplicado,
                                SaldoFactura,
                                1,
                                "")


                        If IdDetalleRecibo <= 0D Then

                            Throw New Exception(
                                "No fue posible grabar el detalle del recibo para la factura " &
                                Aplicacion.NumeroFactura & ".")

                        End If


                        '================================================
                        ' 7. REGISTRAR APLICACIÓN DEL PLAN
                        '================================================

                        Dim SQLAplicacion As String =
                            "INSERT INTO AplicacionPagoPlan " &
                            "(idDetallePago, idDetalleRecibo, " &
                            "MontoAplicado, FechaAplicacion) " &
                            "VALUES " &
                            "(@idDetallePago, @idDetalleRecibo, " &
                            "@MontoAplicado, @FechaAplicacion)"


                        Using CMDAplicacion As New SqlCommand(
                            SQLAplicacion,
                            CN,
                            Trans)

                            CMDAplicacion.Parameters.Add(
                                "@idDetallePago",
                                SqlDbType.Int).Value =
                                Aplicacion.IdDetallePago

                            CMDAplicacion.Parameters.Add(
                                "@idDetalleRecibo",
                                SqlDbType.Decimal).Value =
                                IdDetalleRecibo

                            CMDAplicacion.Parameters.Add(
                                "@MontoAplicado",
                                SqlDbType.Float).Value =
                                Convert.ToDouble(
                                    Aplicacion.MontoAplicado)

                            CMDAplicacion.Parameters.Add(
                                "@FechaAplicacion",
                                SqlDbType.SmallDateTime).Value =
                                FechaRecibo.Date

                            CMDAplicacion.ExecuteNonQuery()

                        End Using

                    Next


                    '==================================================
                    ' 8. GRABAR MÉTODO DE PAGO
                    '==================================================
                    '
                    ' UN SOLO MÉTODO PARA TODO EL RECIBO.
                    '==================================================

                    If Not GrabarMetodoDetalleReciboPlanilla(
                        CN,
                        Trans,
                        NumeroRecibo,
                        FechaRecibo,
                        "Efectivo",
                        TotalRecibo,
                        "",
                        Nothing) Then

                        Throw New Exception(
                            "No fue posible grabar el método de pago del recibo.")

                    End If


                    '==================================================
                    ' 9. CONFIRMAR TODO
                    '==================================================

                    Trans.Commit()


                    '==================================================
                    ' 10. DEVOLVER NÚMERO DE RECIBO
                    '==================================================

                    Return NumeroRecibo


                Catch ex As Exception

                    Try
                        Trans.Rollback()
                    Catch
                    End Try

                    Throw New Exception(
                        "Error al generar el recibo de Planilla para el productor " &
                        CodigoProductor &
                        ": " &
                        ex.Message,
                        ex)

                End Try

            End Using

        End Using

    End Function

    Public Function CrearReciboPlanillaPlanPago(
        ByVal NumNomina As String,
        ByVal CodProductor As String,
        ByVal TipoProductor As String,
        ByVal FechaRecibo As Date,
        ByVal Serie As String,
        ByVal CodigoCliente As String,
        ByVal NombreCliente As String,
        ByVal Moneda As String) As String

        Dim NumeroRecibo As String = ""

        Try

            Using CN As New SqlClient.SqlConnection(Conexion)

                CN.Open()

                Using Trans As SqlClient.SqlTransaction = CN.BeginTransaction()

                    Try

                        '==========================================================
                        ' 1. OBTENER LAS APLICACIONES DE LA PLANILLA
                        '==========================================================

                        Dim Aplicaciones As New List(Of AplicacionPlanPendiente)

                        Dim SQL As String =
                            "SELECT " &
                            "    PPP.idDetallePago, " &
                            "    PPP.MontoCobrado, " &
                            "    DP.NumeroCuota, " &
                            "    DP.FechaVencimiento, " &
                            "    PP.NumeroFactura, " &
                            "    PP.FechaFactura, " &
                            "    PP.TipoFactura " &
                            "FROM PlanillaPlanPago PPP " &
                            "INNER JOIN DetallePagos DP " &
                            "    ON PPP.idDetallePago = DP.idDetallePago " &
                            "INNER JOIN PlanPagos PP " &
                            "    ON DP.NumeroCredito = PP.NumeroCredito " &
                            "WHERE PPP.NumNomina = @NumNomina " &
                            "AND PPP.CodProductor = @CodProductor " &
                            "AND PPP.TipoProductor = @TipoProductor " &
                            "AND PPP.MontoCobrado > 0 " &
                            "AND DP.Anulado = 0 " &
                            "AND PP.Anulado = 0 " &
                            "ORDER BY PPP.idDetallePago"

                        Using CMD As New SqlClient.SqlCommand(
                            SQL,
                            CN,
                            Trans)

                            CMD.Parameters.Add(
                                "@NumNomina",
                                SqlDbType.NVarChar,
                                50).Value = NumNomina

                            CMD.Parameters.Add(
                                "@CodProductor",
                                SqlDbType.NVarChar,
                                50).Value = CodProductor

                            CMD.Parameters.Add(
                                "@TipoProductor",
                                SqlDbType.NVarChar,
                                50).Value = TipoProductor

                            Using DR As SqlClient.SqlDataReader =
                                CMD.ExecuteReader()

                                While DR.Read()

                                    Dim Aplicacion As New AplicacionPlanPendiente()

                                    Aplicacion.IdDetallePago =
                                        Convert.ToInt32(
                                            DR("idDetallePago"))

                                    Aplicacion.NumeroCuota =
                                        Convert.ToInt32(
                                            DR("NumeroCuota"))

                                    Aplicacion.NumeroFactura =
                                        DR("NumeroFactura").ToString()

                                    Aplicacion.FechaFactura =
                                        Convert.ToDateTime(
                                            DR("FechaFactura"))

                                    Aplicacion.TipoFactura =
                                        DR("TipoFactura").ToString()

                                    Aplicacion.MontoAplicado =
                                        Convert.ToDecimal(
                                            DR("MontoCobrado"))

                                    '==================================================
                                    ' EL RECIBO GENERADO DESDE PLANILLA SIEMPRE
                                    ' ES EFECTIVO
                                    '==================================================

                                    Aplicacion.NombrePago = "Efectivo"

                                    Aplicacion.NumeroTarjeta = ""

                                    Aplicacion.FechaVence =
                                        Convert.ToDateTime(
                                            DR("FechaVencimiento"))

                                    Aplicaciones.Add(Aplicacion)

                                End While

                            End Using

                        End Using


                        '==========================================================
                        ' 2. VALIDAR APLICACIONES
                        '==========================================================

                        If Aplicaciones.Count = 0 Then

                            Trans.Rollback()

                            Return ""

                        End If


                        '==========================================================
                        ' 3. OBTENER NUMERO DE RECIBO
                        '==========================================================

                        NumeroRecibo =
                            ObtenerNumeroReciboPlanilla(Serie)

                        If String.IsNullOrWhiteSpace(NumeroRecibo) Then

                            Throw New Exception(
                                "No fue posible obtener el consecutivo del recibo " &
                                "para la serie " & Serie & ".")

                        End If


                        '==========================================================
                        ' 4. GRABAR RECIBO
                        '
                        ' IMPORTANTE:
                        ' Se utiliza la firma REAL de GrabarReciboPlanilla.
                        '==========================================================

                        Dim Resultado As Boolean =
                            GrabarReciboPlanilla(
                                CN,
                                Trans,
                                NumeroRecibo,
                                FechaRecibo,
                                CodigoCliente,
                                NombreCliente,
                                Moneda,
                                Aplicaciones)

                        If Not Resultado Then

                            Throw New Exception(
                                "No fue posible grabar el recibo " &
                                NumeroRecibo & ".")

                        End If


                        '==========================================================
                        ' 5. CONFIRMAR TRANSACCION
                        '==========================================================

                        Trans.Commit()

                        Return NumeroRecibo


                    Catch

                        Try
                            Trans.Rollback()
                        Catch
                        End Try

                        Throw

                    End Try

                End Using

            End Using


        Catch ex As Exception

            Throw New Exception(
                "Error al crear el recibo de Planilla para el productor " &
                CodProductor & ": " &
                ex.Message,
                ex)

        End Try

    End Function

    Public Function ObtenerSerieTipoNomina(
    ByVal CodTipoNomina As String) As String

        If String.IsNullOrWhiteSpace(CodTipoNomina) Then
            Return ""
        End If

        Dim Serie As String = ""

        Dim SQL As String =
            "SELECT ISNULL(Serie, '') " &
            "FROM TipoNomina " &
            "WHERE CodTipoNomina = @CodTipoNomina"

        Using CN As New SqlConnection(_Conexion)

            CN.Open()

            Using CMD As New SqlCommand(SQL, CN)

                CMD.Parameters.Add(
                    "@CodTipoNomina",
                    SqlDbType.NVarChar,
                    50).Value =
                    CodTipoNomina.Trim()

                Dim Resultado As Object =
                    CMD.ExecuteScalar()

                If Resultado IsNot Nothing AndAlso
                   Not IsDBNull(Resultado) Then

                    Serie = Convert.ToString(Resultado).Trim()

                End If

            End Using

        End Using

        Return Serie

    End Function

End Class
