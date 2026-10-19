Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class FacturasCreditoService

    Public Function ObtenerFacturasPendientes(
        ByVal CodigoCliente As String,
        ByVal FechaCorte As Date,
        ByVal Moneda As String) _
        As List(Of FacturaCredito)

        Dim facturas As New List(Of FacturaCredito)

        Dim conexionBD As New SqlClient.SqlConnection(Conexion)

        Try

            conexionBD.Open()

            '==========================================================
            ' 1. CARGAR FACTURAS
            '==========================================================

            Dim sql As String =
                "SELECT Numero_Factura, " &
                "       Fecha_Factura, " &
                "       SubTotal, " &
                "       IVA, " &
                "       MontoCredito, " &
                "       MonedaFactura, " &
                "       Fecha_Vencimiento " &
                "FROM Facturas " &
                "WHERE MetodoPago = @MetodoPago " &
                "  AND Tipo_Factura = @TipoFactura " &
                "  AND Cod_Cliente = @CodigoCliente " &
                "  AND Nombre_Cliente <> N'******CANCELADO' " &
                "  AND Fecha_Factura <= @FechaCorte " &
                "ORDER BY Fecha_Factura, Numero_Factura"

            Dim comando As New SqlClient.SqlCommand(sql, conexionBD)

            Try

                comando.Parameters.AddWithValue("@MetodoPago", "Credito")
                comando.Parameters.AddWithValue("@TipoFactura", "Factura")
                comando.Parameters.AddWithValue("@CodigoCliente", CodigoCliente)
                comando.Parameters.AddWithValue("@FechaCorte", FechaCorte)

                Dim lector As SqlClient.SqlDataReader = comando.ExecuteReader()

                Try

                    While lector.Read()

                        Dim factura As New FacturaCredito

                        factura.NumeroFactura =
                            Convert.ToString(lector("Numero_Factura"))

                        factura.FechaFactura =
                            Convert.ToDateTime(lector("Fecha_Factura"))

                        '==================================================
                        ' MontoFactura = TOTAL ORIGINAL DE LA FACTURA
                        '
                        ' NO utilizar MontoCredito.
                        ' MontoCredito ya contiene el saldo almacenado.
                        '==================================================

                        Dim subtotal As Double = 0
                        Dim iva As Double = 0

                        If Not IsDBNull(lector("SubTotal")) Then
                            subtotal = Convert.ToDouble(lector("SubTotal"))
                        End If

                        If Not IsDBNull(lector("IVA")) Then
                            iva = Convert.ToDouble(lector("IVA"))
                        End If

                        factura.MontoFactura = subtotal + iva

                        factura.MontoPagado = 0
                        factura.MontoNotaDebito = 0
                        factura.MontoNotaCredito = 0

                        factura.MonedaFactura =
                            Convert.ToString(lector("MonedaFactura"))

                        If Not IsDBNull(lector("Fecha_Vencimiento")) Then
                            factura.FechaVencimiento =
                                Convert.ToDateTime(lector("Fecha_Vencimiento"))
                        End If

                        factura.Saldo = factura.MontoFactura

                        facturas.Add(factura)

                    End While

                Finally

                    lector.Close()

                End Try

            Finally

                comando.Dispose()

            End Try


            '==========================================================
            ' 2. CARGAR RECIBOS
            '==========================================================

            CargarRecibos(
    conexionBD,
    facturas,
    Moneda)


            '==========================================================
            ' 3. CARGAR TASAS DE CAMBIO
            '
            ' Se cargan antes de las notas porque las notas
            ' utilizan la tasa de su fecha.
            '==========================================================

            Dim tasas As System.Collections.Generic.Dictionary(Of Date, Double)

            tasas = CargarTasasCambio(
    conexionBD,
    facturas,
    FechaCorte)


            '==========================================================
            ' 4. CARGAR NOTAS DEBITO
            '==========================================================

            CargarNotasDebito(
    conexionBD,
    facturas,
    FechaCorte,
    Moneda,
    tasas)


            '==========================================================
            ' 5. CARGAR NOTAS CREDITO
            '==========================================================

            CargarNotasCredito(
    conexionBD,
    facturas,
    FechaCorte,
    Moneda,
    tasas)


            '==========================================================
            ' 6. CONVERTIR MONEDA DE LAS FACTURAS
            '==========================================================

            AplicarConversionMoneda(
                facturas,
                Moneda,
                tasas)


            '==========================================================
            ' 7. CALCULAR SALDO FINAL
            '==========================================================

            Dim facturaActual As FacturaCredito

            For Each facturaActual In facturas

                facturaActual.Saldo =
                    facturaActual.MontoFactura _
                    - facturaActual.MontoPagado _
                    + facturaActual.MontoNotaDebito _
                    - facturaActual.MontoNotaCredito

                'Eliminar residuos de FLOAT
                If Math.Abs(facturaActual.Saldo) < 0.005 Then
                    facturaActual.Saldo = 0
                End If

            Next

        Finally

            conexionBD.Close()
            conexionBD.Dispose()

        End Try

        Return facturas

    End Function


    '==================================================================
    ' CARGAR RECIBOS
    '==================================================================

    Private Sub CargarRecibos(
        ByVal conexionBD As SqlClient.SqlConnection,
        ByVal facturas As List(Of FacturaCredito),
        ByVal Moneda As String)

        If facturas.Count = 0 Then
            Return
        End If

        Dim parametros As New List(Of String)

        Dim i As Integer

        For i = 0 To facturas.Count - 1

            parametros.Add("@Factura" & i.ToString())

        Next

        Dim sql As String =
            "SELECT " &
            "    DetalleRecibo.Numero_Factura, " &
            "    SUM(CASE " &
            "        WHEN Recibo.MonedaRecibo = 'Dolares' " &
            "        THEN DetalleRecibo.MontoPagado " &
            "        ELSE DetalleRecibo.MontoPagado / " &
            "             ISNULL(TasaCambio.MontoTasa, 1) " &
            "    END) AS MontoDolar, " &
            "    SUM(CASE " &
            "        WHEN Recibo.MonedaRecibo = 'Cordobas' " &
            "        THEN DetalleRecibo.MontoPagado " &
            "        ELSE DetalleRecibo.MontoPagado * " &
            "             ISNULL(TasaCambio.MontoTasa, 1) " &
            "    END) AS MontoCordobas " &
            "FROM DetalleRecibo " &
            "INNER JOIN Recibo " &
            "    ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago " &
            "   AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo " &
            "INNER JOIN TasaCambio " &
            "    ON DetalleRecibo.Fecha_Recibo = TasaCambio.FechaTasa " &
            "WHERE DetalleRecibo.Numero_Factura IN (" &
            String.Join(",", parametros.ToArray()) &
            ") " &
            "GROUP BY DetalleRecibo.Numero_Factura"

        Dim comando As New SqlClient.SqlCommand(sql, conexionBD)

        Try

            For i = 0 To facturas.Count - 1

                comando.Parameters.AddWithValue(
                    "@Factura" & i.ToString(),
                    facturas(i).NumeroFactura)

            Next

            Dim lector As SqlClient.SqlDataReader =
                comando.ExecuteReader()

            Try

                While lector.Read()

                    Dim numeroFactura As String =
                        Convert.ToString(lector("Numero_Factura"))

                    Dim monto As Double = 0

                    If Moneda = "Cordobas" Then

                        If Not IsDBNull(lector("MontoCordobas")) Then

                            monto =
                                Convert.ToDouble(lector("MontoCordobas"))

                        End If

                    Else

                        If Not IsDBNull(lector("MontoDolar")) Then

                            monto =
                                Convert.ToDouble(lector("MontoDolar"))

                        End If

                    End If

                    Dim factura As FacturaCredito =
                        BuscarFactura(facturas, numeroFactura)

                    If Not factura Is Nothing Then

                        factura.MontoPagado = monto

                    End If

                End While

            Finally

                lector.Close()

            End Try

        Finally

            comando.Dispose()

        End Try

    End Sub


    '==================================================================
    ' CARGAR NOTAS DEBITO
    '==================================================================

    Private Sub CargarNotasDebito(
    ByVal conexionBD As SqlClient.SqlConnection,
    ByVal facturas As List(Of FacturaCredito),
    ByVal FechaCorte As Date,
    ByVal Moneda As String,
    ByVal tasas As System.Collections.Generic.Dictionary(Of Date, Double))

        If facturas.Count = 0 Then
            Return
        End If

        Dim parametros As New List(Of String)

        Dim i As Integer

        For i = 0 To facturas.Count - 1

            parametros.Add("@Factura" & i.ToString())

        Next

        Dim sql As String =
        "SELECT " &
        "    Detalle_Nota.Numero_Factura, " &
        "    Detalle_Nota.Fecha_Nota, " &
        "    Detalle_Nota.Monto, " &
        "    NotaDebito.Tipo, " &
        "    IndiceNota.MonedaNota " &
        "FROM Detalle_Nota " &
        "INNER JOIN NotaDebito " &
        "    ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB " &
        "INNER JOIN IndiceNota " &
        "    ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota " &
        "   AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota " &
        "   AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota " &
        "WHERE Detalle_Nota.Fecha_Nota <= @FechaCorte " &
        "  AND NotaDebito.Tipo LIKE '%Debito Clientes%' " &
        "  AND Detalle_Nota.Numero_Factura IN (" &
        String.Join(",", parametros.ToArray()) &
        ")"

        Dim comando As New SqlClient.SqlCommand(sql, conexionBD)

        Try

            comando.Parameters.AddWithValue(
            "@FechaCorte",
            FechaCorte)

            For i = 0 To facturas.Count - 1

                comando.Parameters.AddWithValue(
                "@Factura" & i.ToString(),
                facturas(i).NumeroFactura)

            Next

            Dim lector As SqlClient.SqlDataReader =
            comando.ExecuteReader()

            Try

                While lector.Read()

                    Dim numeroFactura As String =
                    Convert.ToString(
                        lector("Numero_Factura"))

                    Dim montoNota As Double = 0

                    If Not IsDBNull(lector("Monto")) Then

                        montoNota =
                        Convert.ToDouble(
                            lector("Monto"))

                    End If

                    Dim tipoNota As String =
                    Convert.ToString(
                        lector("Tipo"))

                    Dim monedaNota As String =
                    Convert.ToString(
                        lector("MonedaNota"))

                    Dim fechaNota As Date =
                    Convert.ToDateTime(
                        lector("Fecha_Nota"))

                    Dim factura As FacturaCredito =
                    BuscarFactura(
                        facturas,
                        numeroFactura)

                    If Not factura Is Nothing Then

                        Dim tasa As Double = 0

                        If tasas.ContainsKey(fechaNota.Date) Then

                            tasa = tasas(fechaNota.Date)

                        End If

                        Dim factor As Double =
                        ObtenerFactorNota(
                            monedaNota,
                            tipoNota,
                            Moneda,
                            tasa)

                        factura.MontoNotaDebito +=
                        montoNota * factor

                    End If

                End While

            Finally

                lector.Close()

            End Try

        Finally

            comando.Dispose()

        End Try

    End Sub

    '==================================================================
    ' CARGAR NOTAS CREDITO
    '==================================================================

    Private Sub CargarNotasCredito(
    ByVal conexionBD As SqlClient.SqlConnection,
    ByVal facturas As List(Of FacturaCredito),
    ByVal FechaCorte As Date,
    ByVal Moneda As String,
    ByVal tasas As System.Collections.Generic.Dictionary(Of Date, Double))

        If facturas.Count = 0 Then
            Return
        End If

        Dim parametros As New List(Of String)

        Dim i As Integer

        For i = 0 To facturas.Count - 1

            parametros.Add("@Factura" & i.ToString())

        Next

        Dim sql As String =
        "SELECT " &
        "    Detalle_Nota.Numero_Factura, " &
        "    Detalle_Nota.Fecha_Nota, " &
        "    Detalle_Nota.Monto, " &
        "    NotaDebito.Tipo, " &
        "    IndiceNota.MonedaNota " &
        "FROM Detalle_Nota " &
        "INNER JOIN NotaDebito " &
        "    ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB " &
        "INNER JOIN IndiceNota " &
        "    ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota " &
        "   AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota " &
        "   AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota " &
        "WHERE NotaDebito.Tipo = 'Credito Clientes' " &
        "  AND Detalle_Nota.Numero_Factura IN (" &
        String.Join(",", parametros.ToArray()) &
        ")"

        Dim comando As New SqlClient.SqlCommand(sql, conexionBD)

        Try

            For i = 0 To facturas.Count - 1

                comando.Parameters.AddWithValue(
                "@Factura" & i.ToString(),
                facturas(i).NumeroFactura)

            Next

            Dim lector As SqlClient.SqlDataReader =
            comando.ExecuteReader()

            Try

                While lector.Read()

                    Dim numeroFactura As String =
                    Convert.ToString(
                        lector("Numero_Factura"))

                    Dim montoNota As Double = 0

                    If Not IsDBNull(lector("Monto")) Then

                        montoNota =
                        Convert.ToDouble(
                            lector("Monto"))

                    End If

                    Dim monedaNota As String =
                    Convert.ToString(
                        lector("MonedaNota"))

                    Dim fechaNota As Date =
                    Convert.ToDateTime(
                        lector("Fecha_Nota"))

                    Dim factura As FacturaCredito =
                    BuscarFactura(
                        facturas,
                        numeroFactura)

                    If Not factura Is Nothing Then

                        Dim tasa As Double = 0

                        If tasas.ContainsKey(fechaNota.Date) Then

                            tasa = tasas(fechaNota.Date)

                        End If

                        Dim factor As Double =
                        ObtenerFactorNota(
                            monedaNota,
                            "",
                            Moneda,
                            tasa)

                        factura.MontoNotaCredito +=
                        montoNota * factor

                    End If

                End While

            Finally

                lector.Close()

            End Try

        Finally

            comando.Dispose()

        End Try

    End Sub

    '==================================================================
    ' CARGAR TASAS DE CAMBIO
    '==================================================================
    Private Function CargarTasasCambio(
    ByVal conexionBD As SqlClient.SqlConnection,
    ByVal facturas As List(Of FacturaCredito),
    ByVal FechaCorte As Date) _
    As System.Collections.Generic.Dictionary(Of Date, Double)

        Dim tasas As New System.Collections.Generic.Dictionary(Of Date, Double)

        If facturas.Count = 0 Then
            Return tasas
        End If

        Dim fechaInicio As Date =
        facturas(0).FechaFactura.Date

        Dim factura As FacturaCredito

        For Each factura In facturas

            If factura.FechaFactura.Date < fechaInicio Then

                fechaInicio = factura.FechaFactura.Date

            End If

        Next

        Dim fechaFin As Date = FechaCorte.Date

        Dim sql As String =
        "SELECT FechaTasa, MontoTasa " &
        "FROM TasaCambio " &
        "WHERE FechaTasa >= @FechaInicio " &
        "  AND FechaTasa < DATEADD(day, 1, @FechaFin)"

        Dim comando As New SqlClient.SqlCommand(sql, conexionBD)

        Try

            comando.Parameters.AddWithValue(
            "@FechaInicio",
            fechaInicio)

            comando.Parameters.AddWithValue(
            "@FechaFin",
            fechaFin)

            Dim lector As SqlClient.SqlDataReader =
            comando.ExecuteReader()

            Try

                While lector.Read()

                    Dim fecha As Date =
                    Convert.ToDateTime(
                        lector("FechaTasa")).Date

                    Dim tasa As Double = 0

                    If Not IsDBNull(lector("MontoTasa")) Then

                        tasa =
                        Convert.ToDouble(
                            lector("MontoTasa"))

                    End If

                    If Not tasas.ContainsKey(fecha) Then

                        tasas.Add(fecha, tasa)

                    End If

                End While

            Finally

                lector.Close()

            End Try

        Finally

            comando.Dispose()

        End Try

        Return tasas

    End Function

    '==================================================================
    ' CONVERSION DE MONEDA
    '==================================================================

    Private Sub AplicarConversionMoneda(
        ByVal facturas As List(Of FacturaCredito),
        ByVal Moneda As String,
        ByVal tasas As System.Collections.Generic.Dictionary(Of Date, Double))

        Dim factura As FacturaCredito

        For Each factura In facturas

            Dim tasa As Double = 0

            Dim fecha As Date =
                factura.FechaFactura.Date

            If Moneda = "Cordobas" Then

                If factura.MonedaFactura = "Cordobas" Then

                    tasa = 1

                Else

                    If tasas.ContainsKey(fecha) Then

                        tasa = tasas(fecha)

                    End If

                End If

            Else

                If factura.MonedaFactura = "Dolares" Then

                    tasa = 1

                Else

                    If tasas.ContainsKey(fecha) Then

                        If tasas(fecha) <> 0 Then

                            tasa = 1 / tasas(fecha)

                        End If

                    End If

                End If

            End If

            factura.MontoFactura =
                factura.MontoFactura * tasa

        Next

    End Sub


    '==================================================================
    ' BUSCAR FACTURA EN MEMORIA
    '==================================================================

    Private Function BuscarFactura(
        ByVal facturas As List(Of FacturaCredito),
        ByVal numeroFactura As String) _
        As FacturaCredito

        Dim factura As FacturaCredito

        For Each factura In facturas

            If factura.NumeroFactura = numeroFactura Then

                Return factura

            End If

        Next

        Return Nothing

    End Function


    '==================================================================
    ' FACTOR DE CONVERSION DE NOTAS
    '==================================================================

    Private Function ObtenerFactorNota(
        ByVal monedaNota As String,
        ByVal tipoNota As String,
        ByVal monedaDestino As String,
        ByVal tasa As Double) As Double

        If monedaDestino = "Cordobas" Then

            If tipoNota = "Debito Clientes Dif $" Then

                Return 0

            End If

            If monedaNota = "Cordobas" Then

                Return 1

            End If

            If tasa <> 0 Then

                Return 1 / tasa

            End If

            Return 0

        Else

            If tipoNota = "Debito Clientes Dif C$" Then

                Return 0

            End If

            If monedaNota = "Dolares" Then

                Return 1

            End If

            If tasa <> 0 Then

                Return 1 / tasa

            End If

            Return 0

        End If

    End Function

End Class