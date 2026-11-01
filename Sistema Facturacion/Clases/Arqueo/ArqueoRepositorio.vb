Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

''' <summary>Acceso a datos del arqueo de caja. Todas las consultas son parametrizadas.</summary>
Public Class ArqueoRepositorio

    Private ReadOnly _conexion As String

    ' Efectivo de facturas / recibos pendiente de arquear (misma condición para sumar y para marcar)
    Private Const FromEfectivoFacturas As String =
        "FROM Detalle_MetodoFacturas DMF " &
        "INNER JOIN MetodoPago MP ON DMF.NombrePago = MP.NombrePago " &
        "INNER JOIN Facturas F ON DMF.Numero_Factura = F.Numero_Factura " &
        "AND DMF.Fecha_Factura = F.Fecha_Factura AND DMF.Tipo_Factura = F.Tipo_Factura " &
        "WHERE DMF.Arqueado = 0 AND DMF.Tipo_Factura = 'Factura' AND MP.TipoPago = 'Efectivo' " &
        "AND F.Cod_Cajero = @CodCajero " &
        "AND F.Fecha_Factura >= @Fecha AND F.Fecha_Factura < DATEADD(DAY, 1, @Fecha)"

    Private Const FromEfectivoRecibos As String =
        "FROM Detalle_MetodoRecibo DMR " &
        "INNER JOIN Recibo R ON DMR.CodRecibo = R.CodReciboPago AND DMR.Fecha_Recibo = R.Fecha_Recibo " &
        "INNER JOIN MetodoPago MP ON DMR.NombrePago = MP.NombrePago " &
        "WHERE DMR.Arqueado = 0 AND MP.TipoPago = 'Efectivo' " &
        "AND R.Cod_Cajero = @CodCajero " &
        "AND R.Fecha_Recibo >= @Fecha AND R.Fecha_Recibo < DATEADD(DAY, 1, @Fecha)"

    Public Sub New(ByVal conexion As String)
        If String.IsNullOrWhiteSpace(conexion) Then
            Throw New ArgumentException("La cadena de conexión es requerida.")
        End If
        _conexion = conexion
    End Sub

    '=================================================================================================
    ' CATÁLOGOS
    '=================================================================================================

    Public Function ObtenerCajeros() As DataTable
        Dim tabla As New DataTable("Cajeros")
        Using cn As New SqlConnection(_conexion)
            Using da As New SqlDataAdapter("SELECT Cod_Cajero, Nombre_Cajero + ' ' + Apellido_Cajero AS Nombres FROM Cajeros ORDER BY Nombre_Cajero", cn)
                da.Fill(tabla)
            End Using
        End Using
        Return tabla
    End Function

    Public Function ObtenerDenominaciones() As DataTable
        Dim tabla As New DataTable("Denominacion")
        Using cn As New SqlConnection(_conexion)
            Using da As New SqlDataAdapter("SELECT idDenominacion, Valor FROM Denominacion ORDER BY Valor DESC", cn)
                da.Fill(tabla)
            End Using
        End Using
        Return tabla
    End Function

    ''' <summary>Tasa de cambio oficial de la fecha; 0 si no está registrada.</summary>
    Public Function ObtenerTasaCambio(ByVal fecha As Date) As Decimal
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT TOP 1 MontoTasa FROM TasaCambio WHERE FechaTasa = @Fecha", cn)
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha.Date
                cn.Open()
                Dim valor As Object = cmd.ExecuteScalar()
                If valor Is Nothing OrElse IsDBNull(valor) Then Return 0D
                Return Convert.ToDecimal(valor)
            End Using
        End Using
    End Function

    Public Function ObtenerEmpresa() As ArqueoEmpresa
        Dim empresa As New ArqueoEmpresa() With {.Nombre = "", .Direccion = "", .Ruc = "", .RutaLogo = ""}
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT TOP 1 Nombre_Empresa, Direccion_Empresa, Numero_Ruc, Ruta_Logo FROM DatosEmpresa", cn)
                cn.Open()
                Using rd As SqlDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        empresa.Nombre = LeerTexto(rd, 0)
                        empresa.Direccion = LeerTexto(rd, 1)
                        empresa.Ruc = LeerTexto(rd, 2)
                        empresa.RutaLogo = LeerTexto(rd, 3)
                    End If
                End Using
            End Using
        End Using
        Return empresa
    End Function

    '=================================================================================================
    ' LECTURA DE UN ARQUEO
    '=================================================================================================

    Public Function ObtenerCabecera(ByVal codigo As String) As ArqueoCabecera
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT CodArqueo, FechaArqueo, Cod_Cajero, FondoApertura, Observaciones, PracticadoPor, TotalCordobasDolares, ValorFacturas, " &
                                        "EfectivoEsperadoCordobas, EfectivoEsperadoDolares, TasaCambio " &
                                        "FROM Arqueo WHERE CodArqueo = @CodArqueo", cn)
                cmd.Parameters.Add("@CodArqueo", SqlDbType.VarChar).Value = codigo
                cn.Open()
                Using rd As SqlDataReader = cmd.ExecuteReader()
                    If Not rd.Read() Then Return Nothing

                    Dim cab As New ArqueoCabecera()
                    cab.Codigo = LeerTexto(rd, 0)
                    cab.Fecha = Convert.ToDateTime(rd.GetValue(1)).Date
                    cab.CodCajero = LeerTexto(rd, 2)
                    cab.FondoApertura = LeerDecimal(rd, 3)
                    cab.Observaciones = LeerTexto(rd, 4)
                    cab.PracticadoPor = LeerTexto(rd, 5)
                    cab.TotalCordobasDolares = LeerDecimalNulo(rd, 6)
                    cab.ValorFacturas = LeerDecimalNulo(rd, 7)

                    If Not rd.IsDBNull(8) AndAlso Not rd.IsDBNull(9) Then
                        cab.EfectivoEsperado = New ArqueoEfectivoEsperado() With {
                            .EfectivoCordobas = LeerDecimal(rd, 8),
                            .EfectivoDolares = LeerDecimal(rd, 9),
                            .TasaCambio = LeerDecimal(rd, 10)}
                    End If

                    Return cab
                End Using
            End Using
        End Using
    End Function

    ''' <summary>Conteo por denominación guardado. Columnas: idDenominacion, Valor, Canitdad, Monto (nombre de columna heredado de la BD).</summary>
    Public Function ObtenerDetalleEfectivo(ByVal cab As ArqueoCabecera, ByVal moneda As String) As DataTable
        Dim tabla As New DataTable("DetalleEfectivo")
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT idDenominacion, Valor, Canitdad, Monto FROM Detalle_Arqueo " &
                                        "WHERE CodArqueo = @CodArqueo AND FechaArqueo = @Fecha AND Moneda = @Moneda " &
                                        "ORDER BY Valor DESC", cn)
                cmd.Parameters.Add("@CodArqueo", SqlDbType.VarChar).Value = cab.Codigo
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = cab.Fecha.Date
                cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = moneda
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function

    ''' <summary>Cheques/tarjetas guardados en el arqueo. Columnas: Factura#/Recibo#, NombrePago, Tarjeta#/Cheque#, Monto.</summary>
    Public Function ObtenerDetalleCheques(ByVal cab As ArqueoCabecera, ByVal moneda As String) As DataTable
        Dim tabla As New DataTable("DetalleCheques")
        Using cn As New SqlConnection(_conexion)
            Using cmd As New SqlCommand("SELECT NumeroFactura AS [Factura#/Recibo#], NombrePago, NumeroTarjeta AS [Tarjeta#/Cheque#], Monto " &
                                        "FROM Detalle_ArqueoCheque " &
                                        "WHERE CodArqueo = @CodArqueo AND FechaArqueo = @Fecha AND Modena = @Moneda " &
                                        "ORDER BY NumeroFactura", cn)
                cmd.Parameters.Add("@CodArqueo", SqlDbType.VarChar).Value = cab.Codigo
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = cab.Fecha.Date
                cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = moneda
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function

    '=================================================================================================
    ' PENDIENTES DE ARQUEAR
    '=================================================================================================

    ''' <summary>Efectivo de facturas del cajero en el día, aún no arqueado (consulta previa, sin marcar).</summary>
    Public Function SumarEfectivoFacturas(ByVal codCajero As String, ByVal fecha As Date, ByVal moneda As String) As Decimal
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Return SumarEfectivo(cn, Nothing, True, codCajero, fecha, moneda)
        End Using
    End Function

    ''' <summary>Efectivo de recibos del cajero en el día, aún no arqueado (consulta previa, sin marcar).</summary>
    Public Function SumarEfectivoRecibos(ByVal codCajero As String, ByVal fecha As Date, ByVal moneda As String) As Decimal
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Return SumarEfectivo(cn, Nothing, False, codCajero, fecha, moneda)
        End Using
    End Function

    ''' <summary>Pagos no efectivo (cheque, tarjeta...) de facturas y recibos pendientes hasta la fecha del arqueo, inclusive.</summary>
    Public Function ObtenerPagosDiferidosPendientes(ByVal codCajero As String, ByVal fecha As Date) As List(Of ArqueoPagoDiferido)
        Dim lista As New List(Of ArqueoPagoDiferido)()

        Const sqlFacturas As String =
            "SELECT DMF.Numero_Factura, DMF.Fecha_Factura, MP.Moneda, DMF.NombrePago, DMF.NumeroTarjeta, DMF.FechaVence, DMF.Monto " &
            "FROM Detalle_MetodoFacturas DMF " &
            "INNER JOIN MetodoPago MP ON DMF.NombrePago = MP.NombrePago " &
            "INNER JOIN Facturas F ON DMF.Numero_Factura = F.Numero_Factura " &
            "AND DMF.Fecha_Factura = F.Fecha_Factura AND DMF.Tipo_Factura = F.Tipo_Factura " &
            "WHERE DMF.Arqueado = 0 AND DMF.Tipo_Factura = 'Factura' AND MP.TipoPago <> 'Efectivo' " &
            "AND F.Cod_Cajero = @CodCajero AND DMF.Fecha_Factura < DATEADD(DAY, 1, @Fecha) " &
            "ORDER BY DMF.Numero_Factura"

        Const sqlRecibos As String =
            "SELECT DMR.CodRecibo, DMR.Fecha_Recibo, MP.Moneda, DMR.NombrePago, DMR.NumeroTarjeta, DMR.Fecha_Vence, DMR.Monto " &
            "FROM Detalle_MetodoRecibo DMR " &
            "INNER JOIN Recibo R ON DMR.CodRecibo = R.CodReciboPago AND DMR.Fecha_Recibo = R.Fecha_Recibo " &
            "INNER JOIN MetodoPago MP ON DMR.NombrePago = MP.NombrePago " &
            "WHERE DMR.Arqueado = 0 AND MP.TipoPago <> 'Efectivo' " &
            "AND R.Cod_Cajero = @CodCajero AND DMR.Fecha_Recibo < DATEADD(DAY, 1, @Fecha) " &
            "ORDER BY DMR.CodRecibo"

        Using cn As New SqlConnection(_conexion)
            cn.Open()
            LeerPagosDiferidos(cn, sqlFacturas, codCajero, fecha, ArqueoOrigenPago.Factura, lista)
            LeerPagosDiferidos(cn, sqlRecibos, codCajero, fecha, ArqueoOrigenPago.Recibo, lista)
        End Using

        Return lista
    End Function

    '=================================================================================================
    ' ESCRITURA
    '=================================================================================================

    ''' <summary>
    ''' Crea el arqueo completo en una sola transacción: captura y marca el efectivo esperado, encabezado,
    ''' renglones de denominaciones en cero, detalle de cheques/tarjetas y marca de "arqueado" en los pagos incluidos.
    ''' cab.EfectivoEsperado debe traer la tasa de cambio; los montos se calculan dentro de la transacción.
    ''' </summary>
    Public Sub CrearArqueo(ByVal cab As ArqueoCabecera,
                           ByVal denominaciones As IEnumerable(Of ArqueoDenominacion),
                           ByVal pagos As IEnumerable(Of ArqueoPagoDiferido))

        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Using tx As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
                Try
                    CapturarEfectivoEsperado(cn, tx, cab)
                    InsertarCabecera(cn, tx, cab)

                    For Each den As ArqueoDenominacion In denominaciones
                        InsertarDenominacion(cn, tx, cab, den)
                    Next

                    For Each pago As ArqueoPagoDiferido In pagos
                        InsertarPagoDiferido(cn, tx, cab, pago)
                        MarcarComoArqueado(cn, tx, pago)
                    Next

                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    ''' <summary>Graba el cierre del arqueo: conteo por denominación y totales del encabezado.</summary>
    Public Sub GuardarArqueo(ByVal cab As ArqueoCabecera, ByVal denominaciones As IEnumerable(Of ArqueoDenominacion))
        Using cn As New SqlConnection(_conexion)
            cn.Open()
            Using tx As SqlTransaction = cn.BeginTransaction()
                Try
                    For Each den As ArqueoDenominacion In denominaciones
                        ActualizarDenominacion(cn, tx, cab, den)
                    Next

                    ActualizarCabecera(cn, tx, cab)
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    '=================================================================================================
    ' PRIVADOS
    '=================================================================================================

    Private Shared Function SumarEfectivo(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal facturas As Boolean,
                                          ByVal codCajero As String, ByVal fecha As Date, ByVal moneda As String) As Decimal
        Dim sql As String
        If facturas Then
            sql = "SELECT ISNULL(SUM(DMF.Monto), 0) " & FromEfectivoFacturas & " AND MP.Moneda = @Moneda"
        Else
            sql = "SELECT ISNULL(SUM(DMR.Monto), 0) " & FromEfectivoRecibos & " AND MP.Moneda = @Moneda"
        End If

        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@CodCajero", SqlDbType.VarChar).Value = codCajero
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha.Date
            cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = moneda
            Dim valor As Object = cmd.ExecuteScalar()
            If valor Is Nothing OrElse IsDBNull(valor) Then Return 0D
            Return Convert.ToDecimal(valor)
        End Using
    End Function

    ''' <summary>
    ''' Suma el efectivo pendiente del cajero en el día y lo marca como arqueado, en la misma transacción,
    ''' para que otro arqueo del mismo cajero y día no lo cuente de nuevo.
    ''' </summary>
    Private Sub CapturarEfectivoEsperado(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal cab As ArqueoCabecera)
        If cab.EfectivoEsperado Is Nothing Then
            cab.EfectivoEsperado = New ArqueoEfectivoEsperado()
        End If

        cab.EfectivoEsperado.EfectivoCordobas =
            SumarEfectivo(cn, tx, True, cab.CodCajero, cab.Fecha, ArqueoMoneda.Cordobas) +
            SumarEfectivo(cn, tx, False, cab.CodCajero, cab.Fecha, ArqueoMoneda.Cordobas)

        cab.EfectivoEsperado.EfectivoDolares =
            SumarEfectivo(cn, tx, True, cab.CodCajero, cab.Fecha, ArqueoMoneda.Dolares) +
            SumarEfectivo(cn, tx, False, cab.CodCajero, cab.Fecha, ArqueoMoneda.Dolares)

        MarcarEfectivo(cn, tx, "UPDATE DMF SET DMF.Arqueado = 1 " & FromEfectivoFacturas, cab)
        MarcarEfectivo(cn, tx, "UPDATE DMR SET DMR.Arqueado = 1 " & FromEfectivoRecibos, cab)
    End Sub

    Private Shared Sub MarcarEfectivo(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal sql As String, ByVal cab As ArqueoCabecera)
        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@CodCajero", SqlDbType.VarChar).Value = cab.CodCajero
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = cab.Fecha.Date
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub LeerPagosDiferidos(ByVal cn As SqlConnection, ByVal sql As String, ByVal codCajero As String, ByVal fecha As Date,
                                   ByVal origen As ArqueoOrigenPago, ByVal destino As List(Of ArqueoPagoDiferido))
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@CodCajero", SqlDbType.VarChar).Value = codCajero
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha.Date
            Using rd As SqlDataReader = cmd.ExecuteReader()
                While rd.Read()
                    Dim pago As New ArqueoPagoDiferido()
                    pago.Origen = origen
                    pago.Numero = LeerTexto(rd, 0)
                    pago.FechaDocumento = Convert.ToDateTime(rd.GetValue(1))
                    pago.Moneda = LeerTexto(rd, 2)
                    pago.NombrePago = LeerTexto(rd, 3)
                    pago.NumeroTarjeta = LeerTexto(rd, 4)
                    If Not rd.IsDBNull(5) Then pago.FechaVence = Convert.ToDateTime(rd.GetValue(5))
                    pago.Monto = LeerDecimal(rd, 6)
                    destino.Add(pago)
                End While
            End Using
        End Using
    End Sub

    Private Sub InsertarCabecera(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal cab As ArqueoCabecera)
        Using cmd As New SqlCommand("INSERT INTO Arqueo (CodArqueo, FechaArqueo, Cod_Cajero, FondoApertura, EfectivoEsperadoCordobas, EfectivoEsperadoDolares, TasaCambio) " &
                                    "VALUES (@CodArqueo, @FechaArqueo, @CodCajero, @FondoApertura, @EsperadoC, @EsperadoD, @Tasa)", cn, tx)
            cmd.Parameters.Add("@CodArqueo", SqlDbType.VarChar).Value = cab.Codigo
            cmd.Parameters.Add("@FechaArqueo", SqlDbType.SmallDateTime).Value = cab.Fecha.Date
            cmd.Parameters.Add("@CodCajero", SqlDbType.VarChar).Value = cab.CodCajero
            AgregarDecimal(cmd, "@FondoApertura", cab.FondoApertura)
            AgregarDecimal(cmd, "@EsperadoC", cab.EfectivoEsperado.EfectivoCordobas)
            AgregarDecimal(cmd, "@EsperadoD", cab.EfectivoEsperado.EfectivoDolares)
            AgregarDecimal(cmd, "@Tasa", cab.EfectivoEsperado.TasaCambio)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub ActualizarCabecera(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal cab As ArqueoCabecera)
        Using cmd As New SqlCommand("UPDATE Arqueo SET TotalCordobasDolares = @Total, ValorFacturas = @ValorFacturas, " &
                                    "Observaciones = @Observaciones, PracticadoPor = @PracticadoPor, FondoApertura = @FondoApertura " &
                                    "WHERE CodArqueo = @CodArqueo AND FechaArqueo = @FechaArqueo AND Cod_Cajero = @CodCajero", cn, tx)
            AgregarDecimal(cmd, "@Total", cab.TotalCordobasDolares.GetValueOrDefault())
            AgregarDecimal(cmd, "@ValorFacturas", cab.ValorFacturas.GetValueOrDefault())
            cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = If(cab.Observaciones, "")
            cmd.Parameters.Add("@PracticadoPor", SqlDbType.VarChar).Value = If(cab.PracticadoPor, "")
            AgregarDecimal(cmd, "@FondoApertura", cab.FondoApertura)
            cmd.Parameters.Add("@CodArqueo", SqlDbType.VarChar).Value = cab.Codigo
            cmd.Parameters.Add("@FechaArqueo", SqlDbType.SmallDateTime).Value = cab.Fecha.Date
            cmd.Parameters.Add("@CodCajero", SqlDbType.VarChar).Value = cab.CodCajero

            If cmd.ExecuteNonQuery() = 0 Then
                Throw New InvalidOperationException("No se encontró el arqueo " & cab.Codigo & " para actualizarlo.")
            End If
        End Using
    End Sub

    Private Sub InsertarDenominacion(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal cab As ArqueoCabecera, ByVal den As ArqueoDenominacion)
        Using cmd As New SqlCommand("INSERT INTO Detalle_Arqueo (CodArqueo, FechaArqueo, Moneda, idDenominacion, Valor, Canitdad, Monto) " &
                                    "VALUES (@CodArqueo, @FechaArqueo, @Moneda, @IdDenominacion, @Valor, 0, 0)", cn, tx)
            AgregarParametrosDenominacion(cmd, cab, den)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub ActualizarDenominacion(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal cab As ArqueoCabecera, ByVal den As ArqueoDenominacion)
        Using cmd As New SqlCommand("UPDATE Detalle_Arqueo SET Canitdad = @Cantidad, Monto = @Monto " &
                                    "WHERE CodArqueo = @CodArqueo AND FechaArqueo = @FechaArqueo " &
                                    "AND idDenominacion = @IdDenominacion AND Moneda = @Moneda " &
                                    "IF @@ROWCOUNT = 0 " &
                                    "INSERT INTO Detalle_Arqueo (CodArqueo, FechaArqueo, Moneda, idDenominacion, Valor, Canitdad, Monto) " &
                                    "VALUES (@CodArqueo, @FechaArqueo, @Moneda, @IdDenominacion, @Valor, @Cantidad, @Monto)", cn, tx)
            AgregarParametrosDenominacion(cmd, cab, den)
            AgregarDecimal(cmd, "@Cantidad", den.Cantidad)
            AgregarDecimal(cmd, "@Monto", den.Monto)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub AgregarParametrosDenominacion(ByVal cmd As SqlCommand, ByVal cab As ArqueoCabecera, ByVal den As ArqueoDenominacion)
        cmd.Parameters.Add("@CodArqueo", SqlDbType.VarChar).Value = cab.Codigo
        cmd.Parameters.Add("@FechaArqueo", SqlDbType.SmallDateTime).Value = cab.Fecha.Date
        cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = den.Moneda
        cmd.Parameters.Add("@IdDenominacion", SqlDbType.Int).Value = den.IdDenominacion
        AgregarDecimal(cmd, "@Valor", den.Valor)
    End Sub

    Private Sub InsertarPagoDiferido(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal cab As ArqueoCabecera, ByVal pago As ArqueoPagoDiferido)
        Using cmd As New SqlCommand("INSERT INTO Detalle_ArqueoCheque (CodArqueo, FechaArqueo, Modena, NumeroFactura, NombrePago, NumeroTarjeta, Fecha_Vence, Monto) " &
                                    "VALUES (@CodArqueo, @FechaArqueo, @Moneda, @NumeroFactura, @NombrePago, @NumeroTarjeta, @FechaVence, @Monto)", cn, tx)
            cmd.Parameters.Add("@CodArqueo", SqlDbType.VarChar).Value = cab.Codigo
            cmd.Parameters.Add("@FechaArqueo", SqlDbType.SmallDateTime).Value = cab.Fecha.Date
            cmd.Parameters.Add("@Moneda", SqlDbType.VarChar).Value = pago.Moneda
            cmd.Parameters.Add("@NumeroFactura", SqlDbType.VarChar).Value = pago.Documento
            cmd.Parameters.Add("@NombrePago", SqlDbType.VarChar).Value = pago.NombrePago
            cmd.Parameters.Add("@NumeroTarjeta", SqlDbType.VarChar).Value = If(pago.NumeroTarjeta, "")
            cmd.Parameters.Add("@FechaVence", SqlDbType.SmallDateTime).Value = If(pago.FechaVence.HasValue, CObj(pago.FechaVence.Value.Date), CObj(DBNull.Value))
            AgregarDecimal(cmd, "@Monto", pago.Monto)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' <summary>Marca como arqueado solo el pago incluido (documento, fecha y forma de pago), no todo el documento.</summary>
    Private Sub MarcarComoArqueado(ByVal cn As SqlConnection, ByVal tx As SqlTransaction, ByVal pago As ArqueoPagoDiferido)
        Dim sql As String
        If pago.Origen = ArqueoOrigenPago.Recibo Then
            sql = "UPDATE Detalle_MetodoRecibo SET Arqueado = 1 " &
                  "WHERE CodRecibo = @Numero AND Fecha_Recibo = @FechaDocumento AND NombrePago = @NombrePago AND Arqueado = 0"
        Else
            sql = "UPDATE Detalle_MetodoFacturas SET Arqueado = 1 " &
                  "WHERE Numero_Factura = @Numero AND Fecha_Factura = @FechaDocumento AND Tipo_Factura = 'Factura' " &
                  "AND NombrePago = @NombrePago AND Arqueado = 0"
        End If

        Using cmd As New SqlCommand(sql, cn, tx)
            cmd.Parameters.Add("@Numero", SqlDbType.VarChar).Value = pago.Numero
            cmd.Parameters.Add("@FechaDocumento", SqlDbType.DateTime).Value = pago.FechaDocumento
            cmd.Parameters.Add("@NombrePago", SqlDbType.VarChar).Value = pago.NombrePago
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' <summary>Un parámetro Decimal sin precisión/escala trunca los centavos; se fija explícitamente.</summary>
    Private Shared Sub AgregarDecimal(ByVal cmd As SqlCommand, ByVal nombre As String, ByVal valor As Decimal)
        Dim p As SqlParameter = cmd.Parameters.Add(nombre, SqlDbType.Decimal)
        p.Precision = 18
        p.Scale = 4
        p.Value = valor
    End Sub

    Private Shared Function LeerTexto(ByVal rd As SqlDataReader, ByVal indice As Integer) As String
        If rd.IsDBNull(indice) Then Return ""
        Return Convert.ToString(rd.GetValue(indice))
    End Function

    Private Shared Function LeerDecimal(ByVal rd As SqlDataReader, ByVal indice As Integer) As Decimal
        If rd.IsDBNull(indice) Then Return 0D
        Return Convert.ToDecimal(rd.GetValue(indice))
    End Function

    Private Shared Function LeerDecimalNulo(ByVal rd As SqlDataReader, ByVal indice As Integer) As Decimal?
        If rd.IsDBNull(indice) Then Return Nothing
        Return Convert.ToDecimal(rd.GetValue(indice))
    End Function

End Class
