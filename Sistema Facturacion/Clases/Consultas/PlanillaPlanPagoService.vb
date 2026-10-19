Imports System.Data.SqlClient

Public Class PlanillaPlanPagoService

    Private ReadOnly _Conexion As String

    Public Sub New(ByVal Conexion As String)
        _Conexion = Conexion
    End Sub

    Public Function ObtenerCuotasPlanillaPlanPago(
    NumNomina As String) As List(Of PlanillaPlanPagoItem)

        Dim Lista As New List(Of PlanillaPlanPagoItem)

        Dim SQL As String = ""

        SQL &= ";WITH Abonos AS "
        SQL &= "("

        SQL &= " SELECT "
        SQL &= "     APP.idDetallePago, "
        SQL &= "     SUM(APP.MontoAplicado) AS MontoAbonado "

        SQL &= " FROM dbo.AplicacionPagoPlan APP "

        SQL &= " WHERE APP.Anulado = 0 "

        SQL &= " GROUP BY APP.idDetallePago "

        SQL &= "), "

        SQL &= "CuotasPendientes AS "
        SQL &= "("

        SQL &= " SELECT "
        SQL &= "     N.NumPlanilla, "
        SQL &= "     N.FechaInicial, "
        SQL &= "     N.FechaFinal, "

        SQL &= "     F.Cod_Cliente AS CodProductor, "
        SQL &= "     DN.TipoProductor, "

        SQL &= "     PP.NumeroCredito, "
        SQL &= "     PP.NumeroFactura, "
        SQL &= "     PP.FechaFactura, "

        SQL &= "     DP.idDetallePago, "
        SQL &= "     DP.NumeroCuota, "
        SQL &= "     DP.FechaVencimiento, "

        SQL &= "     ( "
        SQL &= "         DP.MontoAbono "
        SQL &= "         + DP.MontoInteres "
        SQL &= "         + DP.MontoMora "
        SQL &= "         + DP.MontoMtoValor "
        SQL &= "     ) AS MontoCuota, "

        SQL &= "     ISNULL(A.MontoAbonado, 0) AS MontoAbonadoAnterior, "

        SQL &= "     ( "
        SQL &= "         DP.MontoAbono "
        SQL &= "         + DP.MontoInteres "
        SQL &= "         + DP.MontoMora "
        SQL &= "         + DP.MontoMtoValor "
        SQL &= "         - ISNULL(A.MontoAbonado, 0) "
        SQL &= "     ) AS SaldoAntesPlanilla, "

        SQL &= "     ISNULL(DN.TotalIngresos, 0) AS TotalIngresos, "

        SQL &= "     PPP.MontoCobrado AS MontoCobradoPlanilla "

        SQL &= " FROM dbo.Nomina N "

        SQL &= " INNER JOIN dbo.Detalle_Nomina DN "
        SQL &= "     ON DN.NumNomina = N.NumPlanilla "

        SQL &= " INNER JOIN dbo.Facturas F "
        SQL &= "     ON F.Cod_Cliente = DN.CodProductor "
        SQL &= "     AND F.Tipo_Factura = 'Factura' "

        SQL &= " INNER JOIN dbo.PlanPagos PP "
        SQL &= "     ON PP.NumeroFactura = F.Numero_Factura "
        SQL &= "     AND PP.FechaFactura = F.Fecha_Factura "
        SQL &= "     AND PP.TipoFactura = F.Tipo_Factura "

        SQL &= " INNER JOIN dbo.DetallePagos DP "
        SQL &= "     ON DP.NumeroCredito = PP.NumeroCredito "

        SQL &= " LEFT JOIN Abonos A "
        SQL &= "     ON A.idDetallePago = DP.idDetallePago "

        SQL &= " LEFT JOIN dbo.PlanillaPlanPago PPP "
        SQL &= "     ON PPP.NumNomina = N.NumPlanilla "
        SQL &= "     AND PPP.CodProductor = DN.CodProductor "
        SQL &= "     AND PPP.TipoProductor = DN.TipoProductor "
        SQL &= "     AND PPP.idDetallePago = DP.idDetallePago "

        SQL &= " WHERE N.NumPlanilla = @NumNomina "

        SQL &= " AND PP.Anulado = 0 "
        SQL &= " AND DP.Anulado = 0 "

        SQL &= " AND DP.FechaVencimiento "
        SQL &= "     BETWEEN N.FechaInicial AND N.FechaFinal "

        SQL &= " AND ( "
        SQL &= "     DP.MontoAbono "
        SQL &= "     + DP.MontoInteres "
        SQL &= "     + DP.MontoMora "
        SQL &= "     + DP.MontoMtoValor "
        SQL &= "     - ISNULL(A.MontoAbonado, 0) "
        SQL &= " ) > 0 "

        SQL &= "), "

        SQL &= "CuotasOrdenadas AS "
        SQL &= "("

        SQL &= " SELECT "
        SQL &= "     CP.*, "

        SQL &= "     ISNULL( "
        SQL &= "         SUM(CP.SaldoAntesPlanilla) OVER "
        SQL &= "         ( "
        SQL &= "             PARTITION BY CP.CodProductor "
        SQL &= "             ORDER BY "
        SQL &= "                 CP.FechaVencimiento, "
        SQL &= "                 CP.NumeroCredito, "
        SQL &= "                 CP.NumeroCuota "
        SQL &= "             ROWS BETWEEN UNBOUNDED PRECEDING "
        SQL &= "                  AND 1 PRECEDING "
        SQL &= "         ), "
        SQL &= "         0 "
        SQL &= "     ) AS SaldoAnteriorAcumulado "

        SQL &= " FROM CuotasPendientes CP "

        SQL &= ") "

        SQL &= " SELECT "

        SQL &= "     NumPlanilla, "
        SQL &= "     FechaInicial, "
        SQL &= "     FechaFinal, "

        SQL &= "     CodProductor, "
        SQL &= "     TipoProductor, "

        SQL &= "     NumeroCredito, "
        SQL &= "     NumeroFactura, "
        SQL &= "     FechaFactura, "

        SQL &= "     idDetallePago, "
        SQL &= "     NumeroCuota, "
        SQL &= "     FechaVencimiento, "

        SQL &= "     MontoCuota, "
        SQL &= "     MontoAbonadoAnterior, "
        SQL &= "     SaldoAntesPlanilla, "

        SQL &= "     TotalIngresos, "

        SQL &= "     SaldoAnteriorAcumulado, "

        '-------------------------------------------------------------
        ' MontoPropuesto
        '-------------------------------------------------------------

        SQL &= "     CASE "

        SQL &= "         WHEN TotalIngresos - SaldoAnteriorAcumulado <= 0 "
        SQL &= "             THEN 0 "

        SQL &= "         WHEN SaldoAntesPlanilla <= "
        SQL &= "              TotalIngresos - SaldoAnteriorAcumulado "
        SQL &= "             THEN SaldoAntesPlanilla "

        SQL &= "         ELSE "
        SQL &= "             TotalIngresos - SaldoAnteriorAcumulado "

        SQL &= "     END AS MontoPropuesto, "

        '-------------------------------------------------------------
        ' MontoCobrado
        '
        ' Si ya existe registro en PlanillaPlanPago:
        '     utiliza MontoCobrado guardado.
        '
        ' Si todavía no existe:
        '     utiliza MontoPropuesto.
        '-------------------------------------------------------------

        SQL &= "     ISNULL( "
        SQL &= "         MontoCobradoPlanilla, "

        SQL &= "         CASE "

        SQL &= "             WHEN TotalIngresos - SaldoAnteriorAcumulado <= 0 "
        SQL &= "                 THEN 0 "

        SQL &= "             WHEN SaldoAntesPlanilla <= "
        SQL &= "                  TotalIngresos - SaldoAnteriorAcumulado "
        SQL &= "                 THEN SaldoAntesPlanilla "

        SQL &= "             ELSE "
        SQL &= "                 TotalIngresos - SaldoAnteriorAcumulado "

        SQL &= "         END "

        SQL &= "     ) AS MontoCobrado "

        SQL &= " FROM CuotasOrdenadas "

        SQL &= " ORDER BY "
        SQL &= "     CodProductor, "
        SQL &= "     FechaVencimiento, "
        SQL &= "     NumeroCredito, "
        SQL &= "     NumeroCuota "

        Using cn As New SqlConnection(_Conexion)

            Using cmd As New SqlCommand(SQL, cn)

                cmd.Parameters.Add(
                "@NumNomina",
                SqlDbType.NVarChar,
                50).Value = NumNomina

                cn.Open()

                Using Reader As SqlDataReader = cmd.ExecuteReader()

                    While Reader.Read()

                        Dim Item As New PlanillaPlanPagoItem()

                        Item.NumPlanilla =
                        Reader("NumPlanilla").ToString()

                        Item.FechaInicial =
                        Convert.ToDateTime(
                            Reader("FechaInicial"))

                        Item.FechaFinal =
                        Convert.ToDateTime(
                            Reader("FechaFinal"))

                        Item.CodProductor =
                        Reader("CodProductor").ToString()

                        Item.TipoProductor =
                        Reader("TipoProductor").ToString()

                        Item.NumeroCredito =
                        Convert.ToInt32(
                            Reader("NumeroCredito"))

                        Item.NumeroFactura =
                        Reader("NumeroFactura").ToString()

                        Item.FechaFactura =
                        Convert.ToDateTime(
                            Reader("FechaFactura"))

                        Item.idDetallePago =
                        Convert.ToInt32(
                            Reader("idDetallePago"))

                        Item.NumeroCuota =
                        Convert.ToInt32(
                            Reader("NumeroCuota"))

                        Item.FechaVencimiento =
                        Convert.ToDateTime(
                            Reader("FechaVencimiento"))

                        Item.MontoCuota =
                        Convert.ToDecimal(
                            Reader("MontoCuota"))

                        Item.MontoAbonadoAnterior =
                        Convert.ToDecimal(
                            Reader("MontoAbonadoAnterior"))

                        Item.SaldoAntesPlanilla =
                        Convert.ToDecimal(
                            Reader("SaldoAntesPlanilla"))

                        Item.TotalIngresos =
                        Convert.ToDecimal(
                            Reader("TotalIngresos"))

                        Item.SaldoAnteriorAcumulado =
                        Convert.ToDecimal(
                            Reader("SaldoAnteriorAcumulado"))

                        Item.MontoPropuesto =
                        Convert.ToDecimal(
                            Reader("MontoPropuesto"))

                        Item.MontoCobrado =
                        Convert.ToDecimal(
                            Reader("MontoCobrado"))

                        Lista.Add(Item)

                    End While

                End Using

            End Using

        End Using

        Return Lista

    End Function
    Public Sub GuardarPropuestasPlanillaPlanPago(
    Items As List(Of PlanillaPlanPagoItem),
    Usuario As String)

        If Items Is Nothing OrElse Items.Count = 0 Then
            Exit Sub
        End If

        Using cn As New SqlConnection(_Conexion)

            cn.Open()

            Using trans As SqlTransaction = cn.BeginTransaction()

                Try

                    For Each Item As PlanillaPlanPagoItem In Items

                        Dim SQL As String = ""

                        SQL &= "IF NOT EXISTS ("
                        SQL &= "    SELECT 1 "
                        SQL &= "    FROM PlanillaPlanPago "
                        SQL &= "    WHERE NumNomina = @NumNomina "
                        SQL &= "      AND CodProductor = @CodProductor "
                        SQL &= "      AND TipoProductor = @TipoProductor "
                        SQL &= "      AND idDetallePago = @idDetallePago"
                        SQL &= ") "
                        SQL &= "BEGIN "

                        SQL &= "    INSERT INTO PlanillaPlanPago "
                        SQL &= "    ("
                        SQL &= "        NumNomina, "
                        SQL &= "        CodProductor, "
                        SQL &= "        TipoProductor, "
                        SQL &= "        idDetallePago, "
                        SQL &= "        MontoCuota, "
                        SQL &= "        MontoAbonadoAnterior, "
                        SQL &= "        SaldoAntesPlanilla, "
                        SQL &= "        MontoPropuesto, "
                        SQL &= "        MontoCobrado, "
                        SQL &= "        Estado, "
                        SQL &= "        Motivo, "
                        SQL &= "        UsuarioRegistro, "
                        SQL &= "        FechaRegistro"
                        SQL &= "    ) "
                        SQL &= "    VALUES "
                        SQL &= "    ("
                        SQL &= "        @NumNomina, "
                        SQL &= "        @CodProductor, "
                        SQL &= "        @TipoProductor, "
                        SQL &= "        @idDetallePago, "
                        SQL &= "        @MontoCuota, "
                        SQL &= "        @MontoAbonadoAnterior, "
                        SQL &= "        @SaldoAntesPlanilla, "
                        SQL &= "        @MontoPropuesto, "
                        SQL &= "        @MontoCobrado, "
                        SQL &= "        @Estado, "
                        SQL &= "        @Motivo, "
                        SQL &= "        @UsuarioRegistro, "
                        SQL &= "        SYSDATETIME()"
                        SQL &= "    ) "

                        SQL &= "END"

                        Using cmd As New SqlCommand(SQL, cn, trans)

                            cmd.Parameters.Add(
                                "@NumNomina",
                                SqlDbType.NVarChar,
                                50).Value =
                                    Item.NumPlanilla

                            cmd.Parameters.Add(
                                "@CodProductor",
                                SqlDbType.NVarChar,
                                50).Value =
                                    Item.CodProductor

                            cmd.Parameters.Add(
                                "@TipoProductor",
                                SqlDbType.NVarChar,
                                50).Value =
                                    Item.TipoProductor

                            cmd.Parameters.Add(
                                "@idDetallePago",
                                SqlDbType.Int).Value =
                                    Item.idDetallePago

                            cmd.Parameters.Add(
                                "@MontoCuota",
                                SqlDbType.Decimal).Value =
                                    Item.MontoCuota

                            cmd.Parameters.Add(
                                "@MontoAbonadoAnterior",
                                SqlDbType.Decimal).Value =
                                    Item.MontoAbonadoAnterior

                            cmd.Parameters.Add(
                                "@SaldoAntesPlanilla",
                                SqlDbType.Decimal).Value =
                                    Item.SaldoAntesPlanilla

                            cmd.Parameters.Add(
                                "@MontoPropuesto",
                                SqlDbType.Decimal).Value =
                                    Item.MontoPropuesto

                            cmd.Parameters.Add(
                                "@MontoCobrado",
                                SqlDbType.Decimal).Value =
                                    Item.MontoPropuesto

                            cmd.Parameters.Add(
                                "@Estado",
                                SqlDbType.NVarChar,
                                20).Value =
                                    "Propuesto"

                            cmd.Parameters.Add(
                                "@Motivo",
                                SqlDbType.NVarChar,
                                250).Value =
                                    DBNull.Value

                            If String.IsNullOrWhiteSpace(Usuario) Then

                                cmd.Parameters.Add(
                                    "@UsuarioRegistro",
                                    SqlDbType.NVarChar,
                                    50).Value =
                                        DBNull.Value

                            Else

                                cmd.Parameters.Add(
                                    "@UsuarioRegistro",
                                    SqlDbType.NVarChar,
                                    50).Value =
                                        Usuario

                            End If

                            cmd.ExecuteNonQuery()

                        End Using

                    Next

                    trans.Commit()

                Catch

                    Try
                        trans.Rollback()
                    Catch
                    End Try

                    Throw

                End Try

            End Using

        End Using

    End Sub

End Class
