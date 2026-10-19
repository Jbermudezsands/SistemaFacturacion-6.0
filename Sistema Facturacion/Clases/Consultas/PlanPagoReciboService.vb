Imports System.Data.SqlClient

Public Class PlanPagoReciboService

    Public Function ObtenerFacturasConPlanPago(
        ByVal CodigoCliente As String,
        ByVal Moneda As String
    ) As List(Of FacturaPlanPagoRecibo)

        Dim Resultado As New List(Of FacturaPlanPagoRecibo)

        Dim SQL As String = ""

        SQL &= "SELECT " & vbCrLf
        SQL &= "    F.Numero_Factura, " & vbCrLf
        SQL &= "    F.Fecha_Factura, " & vbCrLf
        SQL &= "    F.Tipo_Factura, " & vbCrLf
        SQL &= "    F.MonedaFactura, " & vbCrLf
        SQL &= "    P.NumeroCredito, " & vbCrLf
        SQL &= "    P.MontoCredito, " & vbCrLf
        SQL &= "    ISNULL(A.TotalAplicado, 0) AS TotalAplicado, " & vbCrLf
        SQL &= "    P.MontoCredito - ISNULL(A.TotalAplicado, 0) AS Saldo " & vbCrLf
        SQL &= "FROM Facturas F " & vbCrLf
        SQL &= "INNER JOIN PlanPagos P " & vbCrLf
        SQL &= "    ON P.NumeroFactura = F.Numero_Factura " & vbCrLf
        SQL &= "    AND P.FechaFactura = F.Fecha_Factura " & vbCrLf
        SQL &= "    AND P.TipoFactura = F.Tipo_Factura " & vbCrLf
        SQL &= "LEFT JOIN ( " & vbCrLf
        SQL &= "    SELECT " & vbCrLf
        SQL &= "        DP.NumeroCredito, " & vbCrLf
        SQL &= "        SUM(ISNULL(AP.TotalAplicado, 0)) AS TotalAplicado " & vbCrLf
        SQL &= "    FROM DetallePagos DP " & vbCrLf
        SQL &= "    LEFT JOIN ( " & vbCrLf
        SQL &= "        SELECT " & vbCrLf
        SQL &= "            idDetallePago, " & vbCrLf
        SQL &= "            SUM(MontoAplicado) AS TotalAplicado " & vbCrLf
        SQL &= "        FROM AplicacionPagoPlan " & vbCrLf
        SQL &= "        WHERE Anulado = 0 " & vbCrLf
        SQL &= "        GROUP BY idDetallePago " & vbCrLf
        SQL &= "    ) AP " & vbCrLf
        SQL &= "        ON AP.idDetallePago = DP.idDetallePago " & vbCrLf
        SQL &= "    WHERE DP.Anulado = 0 " & vbCrLf
        SQL &= "    GROUP BY DP.NumeroCredito " & vbCrLf
        SQL &= ") A " & vbCrLf
        SQL &= "    ON A.NumeroCredito = P.NumeroCredito " & vbCrLf
        SQL &= "WHERE F.Cod_Cliente = @CodigoCliente " & vbCrLf
        SQL &= "AND F.MonedaFactura = @Moneda " & vbCrLf
        SQL &= "AND P.Anulado = 0 " & vbCrLf
        SQL &= "AND P.MontoCredito - ISNULL(A.TotalAplicado, 0) > 0 " & vbCrLf
        SQL &= "ORDER BY F.Fecha_Factura, F.Numero_Factura"

        Using CN As New SqlConnection(Conexion)

            Using CMD As New SqlCommand(SQL, CN)

                CMD.Parameters.Add("@CodigoCliente", SqlDbType.NVarChar, 50).Value = CodigoCliente
                CMD.Parameters.Add("@Moneda", SqlDbType.NVarChar, 50).Value = Moneda

                CN.Open()

                Using DR As SqlDataReader = CMD.ExecuteReader()

                    While DR.Read()

                        Dim Factura As New FacturaPlanPagoRecibo()

                        Factura.NumeroFactura =
                            Convert.ToString(DR("Numero_Factura"))

                        Factura.FechaFactura =
                            Convert.ToDateTime(DR("Fecha_Factura"))

                        Factura.TipoFactura =
                            Convert.ToString(DR("Tipo_Factura"))

                        Factura.MonedaFactura =
                            Convert.ToString(DR("MonedaFactura"))

                        Factura.NumeroCredito =
                            Convert.ToInt32(DR("NumeroCredito"))

                        Factura.MontoCredito =
                            Convert.ToDecimal(DR("MontoCredito"))

                        Factura.TotalAplicado =
                            Convert.ToDecimal(DR("TotalAplicado"))

                        Factura.Saldo =
                            Convert.ToDecimal(DR("Saldo"))

                        Resultado.Add(Factura)

                    End While

                End Using

            End Using

        End Using

        Return Resultado

    End Function

    Public Function ObtenerDetallePlanPago(
    ByVal NumeroCredito As Integer
) As List(Of DetallePlanPagoRecibo)

        Dim Resultado As New List(Of DetallePlanPagoRecibo)

        Dim SQL As String = ""

        SQL &= "SELECT " & vbCrLf
        SQL &= "    D.idDetallePago, " & vbCrLf
        SQL &= "    D.NumeroCuota, " & vbCrLf
        SQL &= "    D.FechaVencimiento, " & vbCrLf
        SQL &= "    D.MontoAbono, " & vbCrLf
        SQL &= "    D.MontoInteres, " & vbCrLf
        SQL &= "    D.MontoMora, " & vbCrLf
        SQL &= "    D.MontoMtoValor, " & vbCrLf
        SQL &= "    D.Pagado, " & vbCrLf
        SQL &= "    D.Anulado, " & vbCrLf
        SQL &= "    ( " & vbCrLf
        SQL &= "        D.MontoAbono + " & vbCrLf
        SQL &= "        D.MontoInteres + " & vbCrLf
        SQL &= "        D.MontoMora + " & vbCrLf
        SQL &= "        D.MontoMtoValor " & vbCrLf
        SQL &= "    ) AS TotalCuota, " & vbCrLf
        SQL &= "    ISNULL(A.TotalAplicado, 0) AS MontoAplicadoAnterior " & vbCrLf
        SQL &= "FROM DetallePagos D " & vbCrLf
        SQL &= "LEFT JOIN ( " & vbCrLf
        SQL &= "    SELECT " & vbCrLf
        SQL &= "        idDetallePago, " & vbCrLf
        SQL &= "        SUM(MontoAplicado) AS TotalAplicado " & vbCrLf
        SQL &= "    FROM AplicacionPagoPlan " & vbCrLf
        SQL &= "    WHERE Anulado = 0 " & vbCrLf
        SQL &= "    GROUP BY idDetallePago " & vbCrLf
        SQL &= ") A " & vbCrLf
        SQL &= "    ON A.idDetallePago = D.idDetallePago " & vbCrLf
        SQL &= "WHERE D.NumeroCredito = @NumeroCredito " & vbCrLf
        SQL &= "ORDER BY D.NumeroCuota"

        Using CN As New SqlConnection(Conexion)

            Using CMD As New SqlCommand(SQL, CN)

                CMD.Parameters.Add("@NumeroCredito", SqlDbType.Int).Value = NumeroCredito

                CN.Open()

                Using DR As SqlDataReader = CMD.ExecuteReader()

                    While DR.Read()

                        Dim Detalle As New DetallePlanPagoRecibo()

                        Detalle.IdDetallePago =
                            Convert.ToInt32(DR("idDetallePago"))

                        Detalle.NumeroCuota =
                            Convert.ToInt32(DR("NumeroCuota"))

                        Detalle.FechaVencimiento =
                            Convert.ToDateTime(DR("FechaVencimiento"))

                        Detalle.MontoAbono =
                            Convert.ToDecimal(DR("MontoAbono"))

                        Detalle.MontoInteres =
                            Convert.ToDecimal(DR("MontoInteres"))

                        Detalle.MontoMora =
                            Convert.ToDecimal(DR("MontoMora"))

                        Detalle.MontoMtoValor =
                            Convert.ToDecimal(DR("MontoMtoValor"))

                        Detalle.TotalCuota =
                            Convert.ToDecimal(DR("TotalCuota"))

                        Detalle.MontoAplicadoAnterior =
                            Convert.ToDecimal(DR("MontoAplicadoAnterior"))

                        Detalle.Saldo =
                            Detalle.TotalCuota -
                            Detalle.MontoAplicadoAnterior

                        Detalle.Pagado =
                            Convert.ToBoolean(DR("Pagado"))

                        Detalle.Anulado =
                            Convert.ToBoolean(DR("Anulado"))

                        Detalle.Aplicar = False
                        Detalle.MontoAAplicar = 0D

                        Resultado.Add(Detalle)

                    End While

                End Using

            End Using

        End Using

        Return Resultado

    End Function


End Class
