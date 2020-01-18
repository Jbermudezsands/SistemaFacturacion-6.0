Public Class FrmReportes
    Public NombreEmpresa As String, DireccionEmpresa As String, Ruc As String, RutaLogo As String, MostrarImagen As Boolean = False
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodigoInicio As String, CodigoFin As String, ImagenReporte As Integer
    Public Function SaldoInicialCliente(ByVal CodigoCliente As String, ByVal FechaFin As Date, ByVal Moneda As String) As Double
        Dim SQlString As String, NumeroRecibo As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0
        Dim MontoRecibo As Double, MontoMetodoFactura As Double = 0, TotalFactura As Double, MontoFactura As Double = 0
        Dim TotalCreditos As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0


        'SQlString = "SELECT DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / TasaCambio.MontoTasa END AS MontoDolares, Recibo.Cod_Cliente FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa WHERE (DetalleRecibo.Fecha_Recibo < CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Recibo.Cod_Cliente = '" & CodigoCliente & "')"
        SQlString = "SELECT DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE CASE WHEN TasaCambio.MontoTasa <> 0 THEN DetalleRecibo.MontoPagado / TasaCambio.MontoTasa ELSE 0 END END AS MontoDolares, Recibo.Cod_Cliente FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa WHERE  (DetalleRecibo.Fecha_Recibo < CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Recibo.Cod_Cliente = '" & CodigoCliente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recibos")
        Registros = DataSet.Tables("Recibos").Rows.Count
        i = 0
        TotalCreditos = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = DataSet.Tables("Recibos").Rows.Count
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoRecibo = DataSet.Tables("Recibos").Rows(i)("MontoCordobas")
            Else
                MontoRecibo = DataSet.Tables("Recibos").Rows(i)("MontoDolares")
            End If
            TotalCreditos = TotalCreditos + MontoRecibo
            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Loop

        SQlString = "SELECT Detalle_Nota.Numero_Nota AS Expr1, CASE WHEN IndiceNota.MonedaNota = 'Cordobas' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN IndiceNota.MonedaNota = 'Dolares' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_Nota INNER JOIN  NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN TasaCambio ON IndiceNota.Fecha_Nota = TasaCambio.FechaTasa WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota < CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotasCredito")
        Registros = DataSet.Tables("NotasCredito").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = Registros
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoNota = DataSet.Tables("NotasCredito").Rows(i)("MontoCordobas")
            Else
                MontoNota = DataSet.Tables("NotasCredito").Rows(i)("MontoDolares")
            End If
            TotalCreditos = TotalCreditos + MontoNota
            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Loop



        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO EL DETALLE DE METODO PARA LAS FACTURAS DE CONTADO //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        MontoMetodoFactura = 0
        SQlString = "SELECT Facturas.Cod_Cliente, CASE WHEN MetodoPago.Moneda = 'Cordobas' THEN Detalle_MetodoFacturas.Monto ELSE Detalle_MetodoFacturas.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN MetodoPago.Moneda = 'Dolares' THEN Detalle_MetodoFacturas.Monto ELSE Detalle_MetodoFacturas.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                    "WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Facturas.Cod_Cliente = '" & CodigoCliente & "') AND (Detalle_MetodoFacturas.Fecha_Factura < CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Facturas.Nombre_Cliente <> N'******CANCELADO')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoFactura")
        Registros = DataSet.Tables("MetodoFactura").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = Registros
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoNota = DataSet.Tables("MetodoFactura").Rows(i)("MontoCordobas")
            Else
                MontoNota = DataSet.Tables("MetodoFactura").Rows(i)("MontoDolares")
            End If
            TotalCreditos = TotalCreditos + MontoNota
            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Loop

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal / TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.IVA * TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.IVA / TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.NetoPagar * TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.NetoPagar / TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoDolares FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                    "WHERE (Facturas.Fecha_Factura < CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Clientes.Cod_Cliente = '" & CodigoCliente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Facturas")


        Registros = DataSet.Tables("Facturas").Rows.Count
        i = 0
        TotalFactura = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = DataSet.Tables("Facturas").Rows.Count
        Do While Registros > i
            My.Application.DoEvents()
            If Not IsDBNull(DataSet.Tables("Facturas").Rows(i)("NetoCordobas")) Then
                If Moneda = "Cordobas" Then
                    MontoFactura = DataSet.Tables("Facturas").Rows(i)("ImporteCordobas") + DataSet.Tables("Facturas").Rows(i)("IvaCordobas")
                Else
                    MontoFactura = DataSet.Tables("Facturas").Rows(i)("ImporteDolares") + DataSet.Tables("Facturas").Rows(i)("IvaDolares")
                End If
                TotalFactura = TotalFactura + MontoFactura
            End If

            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Loop


        SQlString = "SELECT Detalle_Nota.Numero_Nota AS Expr1, CASE WHEN IndiceNota.MonedaNota = 'Cordobas' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN IndiceNota.MonedaNota = 'Dolares' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_Nota INNER JOIN  NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN TasaCambio ON IndiceNota.Fecha_Nota = TasaCambio.FechaTasa WHERE (NotaDebito.Tipo = 'Debito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota < CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotasDebito")
        Registros = DataSet.Tables("NotasDebito").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = Registros
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoNota = DataSet.Tables("NotasDebito").Rows(i)("MontoCordobas")
            Else
                MontoNota = DataSet.Tables("NotasDebito").Rows(i)("MontoDolares")
            End If
            TotalFactura = TotalFactura + MontoNota
            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Loop


        SaldoInicialCliente = TotalFactura - TotalCreditos


    End Function


    Public Function ConsultaCreditosCliente(ByVal CodigoCliente As String, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Moneda As String) As Double
        Dim SQlString As String, NumeroRecibo As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0
        Dim MontoRecibo As Double, MontoMetodoFactura As Double = 0
        Dim TotalCreditos As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0

        '---------------------------------------------------------------------------------------------------------------------------------------
        '------------------------------------------CONSULTA DE RECIBOS DE CAJA ----------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------------------------------------------
        SQlString = "SELECT DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / TasaCambio.MontoTasa END AS MontoDolares, Recibo.Cod_Cliente FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa WHERE (DetalleRecibo.Fecha_Recibo BETWEEN CONVERT(DATETIME, '" & Format(FechaInicio, "yyyy-MM-dd") & "',102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Recibo.Cod_Cliente = '" & CodigoCliente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Facturas")


        Registros = DataSet.Tables("Facturas").Rows.Count
        i = 0
        TotalCreditos = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = DataSet.Tables("Facturas").Rows.Count
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoRecibo = DataSet.Tables("Facturas").Rows(i)("MontoCordobas")
            Else
                MontoRecibo = DataSet.Tables("Facturas").Rows(i)("MontoDolares")
            End If
            TotalCreditos = TotalCreditos + MontoRecibo
            i = i + 1
            Me.ProgressBar1.Value = i
        Loop

        '-------------------------------------------------------------------------------------------------------------------------------------------
        '-----------------------CONSULTO NOTAS DE CREDITOS CLIENTES --------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------------
        SQlString = "SELECT Detalle_Nota.Numero_Nota AS Expr1, CASE WHEN IndiceNota.MonedaNota = 'Cordobas' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN IndiceNota.MonedaNota = 'Dolares' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_Nota INNER JOIN  NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN TasaCambio ON IndiceNota.Fecha_Nota = TasaCambio.FechaTasa WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota BETWEEN CONVERT(DATETIME, '" & Format(FechaInicio, "yyyy-MM-dd") & "',102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        Registros = DataSet.Tables("Notas").Rows.Count
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = Registros
        i = 0
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoNota = DataSet.Tables("Notas").Rows(i)("MontoCordobas")
            Else
                MontoNota = DataSet.Tables("Notas").Rows(i)("MontoDolares")
            End If
            TotalCreditos = TotalCreditos + MontoNota
            i = i + 1
            Me.ProgressBar1.Value = i
        Loop



        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO EL DETALLE DE METODO PARA LAS FACTURAS DE CONTADO //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        MontoMetodoFactura = 0
        SQlString = "SELECT Facturas.Cod_Cliente, CASE WHEN MetodoPago.Moneda = 'Cordobas' THEN Detalle_MetodoFacturas.Monto ELSE Detalle_MetodoFacturas.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN MetodoPago.Moneda = 'Dolares' THEN Detalle_MetodoFacturas.Monto ELSE Detalle_MetodoFacturas.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                    "WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Facturas.Cod_Cliente = '" & CodigoCliente & "') AND (Detalle_MetodoFacturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(FechaInicio, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Facturas.Nombre_Cliente <> N'******CANCELADO')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "MetodoFactura")
        Registros = DataSet.Tables("MetodoFactura").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = Registros
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoNota = DataSet.Tables("MetodoFactura").Rows(i)("MontoCordobas")
            Else
                MontoNota = DataSet.Tables("MetodoFactura").Rows(i)("MontoDolares")
            End If
            TotalCreditos = TotalCreditos + MontoNota
            i = i + 1
            Me.ProgressBar1.Value = i
        Loop

        ConsultaCreditosCliente = TotalCreditos


    End Function
    Public Function ConsultaSaldoCliente(ByVal CodigoCliente As String, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Moneda As String, ByVal DiasIni As Double, ByVal DiasFin As Double) As Double

        Dim SQlString As String, NumeroRecibo As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0, MontoRecibo As Double = 0
        Dim MontoFactura As Double, NumeroFactura As String, MontoMetodoFactura As Double = 0
        Dim TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0
        Dim Registros2 As Double, j As Double, TasaCambioRecibo As Double = 0

        My.Application.DoEvents()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal / TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.IVA * TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.IVA / TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.NetoPagar * TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.NetoPagar / TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoDolares, DATEDIFF(day, Facturas.Fecha_Vencimiento, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias,Facturas.Numero_Factura FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                    "WHERE   (Facturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (DATEDIFF(day, Facturas.Fecha_Vencimiento, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & " ) AND (Clientes.Cod_Cliente = '" & CodigoCliente & "') ORDER BY DATEDIFF(day, Facturas.Fecha_Vencimiento, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"

        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Facturas")


        Registros = DataSet.Tables("Facturas").Rows.Count
        i = 0
        TotalFactura = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = DataSet.Tables("Facturas").Rows.Count
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoFactura = DataSet.Tables("Facturas").Rows(i)("ImporteCordobas") + DataSet.Tables("Facturas").Rows(i)("IvaCordobas")
            Else
                MontoFactura = DataSet.Tables("Facturas").Rows(i)("ImporteDolares") + DataSet.Tables("Facturas").Rows(i)("IvaDolares")
            End If


            NumeroFactura = DataSet.Tables("Facturas").Rows(i)("Numero_Factura")
            'FechaFactura = DataSet.Tables("Facturas").Rows(i)("Fecha_Factura")
            'FechaVence = DataSet.Tables("Facturas").Rows(i)("Fecha_Vencimiento")
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS PARA LA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente " & _
                        "HAVING (DetalleRecibo.Numero_Factura = '" & NumeroFactura & "') AND (Recibo.Cod_Cliente = '" & CodigoCliente & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "Recibos")
            Registros2 = DataSet.Tables("Recibos").Rows.Count
            j = 0
            MontoRecibo = 0
            Do While Registros2 > j

                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                    End If
                Else
                    If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                    End If
                End If
                If NumeroRecibo = "" Then
                    NumeroRecibo = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                Else
                    NumeroRecibo = NumeroRecibo & "," & DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                End If
                MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoPagado") * TasaCambioRecibo

                j = j + 1
            Loop
            DataSet.Tables("Recibos").Reset()


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Debito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaDB")
            Registros2 = DataSet.Tables("NotaDB").Rows.Count
            NumeroNota = ""
            j = 0
            MontoNota = 0
            TotalMontoNotaDB = 0
            Do While Registros2 > j

                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                    End If
                End If
                If NumeroNota = "" Then
                    NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                Else
                    NumeroNota = NumeroNota & "," & DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
                End If
                MontoNota = MontoNota + DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
                TotalMontoNotaDB = TotalMontoNotaDB + MontoNota
                j = j + 1
            Loop

            DataSet.Tables("NotaDB").Reset()
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO PARA ESTA FACTURA //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
            SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "NotaCR")
            Registros2 = DataSet.Tables("NotaCR").Rows.Count
            NumeroNotaCR = ""
            j = 0
            MontoNotaCR = 0
            TotalMontoNotaCR = 0
            Do While Registros2 > j

                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                    End If
                Else
                    If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                    End If
                End If
                If NumeroNotaCR = "" Then
                    NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                Else
                    NumeroNotaCR = NumeroNotaCR & "," & DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
                End If
                MontoNotaCR = DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
                TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR
                j = j + 1
            Loop
            DataSet.Tables("NotaCR").Reset()

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////BUSCO EL DETALLE DE METODO PARA LAS FACTURAS DE CONTADO //////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MontoMetodoFactura = 0
            'SQlString = "SELECT * FROM Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Detalle_MetodoFacturas.Numero_Factura = '" & NumeroFactura & "') AND (Facturas.Nombre_Cliente <> N'******CANCELADO')"
            SQlString = "SELECT Detalle_MetodoFacturas.Numero_Factura, Detalle_MetodoFacturas.Fecha_Factura, Detalle_MetodoFacturas.Tipo_Factura, Detalle_MetodoFacturas.NombrePago, Detalle_MetodoFacturas.Monto, Detalle_MetodoFacturas.NumeroTarjeta, Detalle_MetodoFacturas.FechaVence, Detalle_MetodoFacturas.Arqueado, MetodoPago.NombrePago AS Expr1, MetodoPago.TipoPago, MetodoPago.Cod_Cuenta, MetodoPago.Moneda FROM Detalle_MetodoFacturas INNER JOIN  MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura  " & _
                        "WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Detalle_MetodoFacturas.Numero_Factura = '" & NumeroFactura & "') AND (Facturas.Nombre_Cliente <> N'******CANCELADO') "
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "MetodoFactura")
            If DataSet.Tables("MetodoFactura").Rows.Count <> 0 Then
                If Me.OptCordobas.Checked = True Then
                    If DataSet.Tables("MetodoFactura").Rows(0)("Moneda") = "Cordobas" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("MetodoFactura").Rows(0)("Fecha_Factura"))
                    End If
                Else
                    If DataSet.Tables("MetodoFactura").Rows(0)("Moneda") = "Dolares" Then
                        TasaCambioRecibo = 1
                    Else
                        TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("MetodoFactura").Rows(0)("Fecha_Factura"))
                    End If
                End If

                MontoMetodoFactura = DataSet.Tables("MetodoFactura").Rows(0)("Monto") * TasaCambioRecibo

            End If
            DataSet.Tables("MetodoFactura").Reset()


            TotalFactura = TotalFactura + MontoFactura - MontoRecibo - MontoMetodoFactura - TotalMontoNotaCR + TotalMontoNotaDB
            i = i + 1
            Me.ProgressBar1.Value = i

        Loop

        MontoRecibo = 0
        MontoMetodoFactura = 0
        TotalMontoNotaCR = 0
        TotalMontoNotaDB = 0


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota  " & _
                    "WHERE (DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & ") AND (NotaDebito.Tipo = 'Debito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (Detalle_Nota.Numero_Factura = '0000')"


        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaDB")
        Registros2 = DataSet.Tables("NotaDB").Rows.Count
        NumeroNota = ""
        j = 0
        MontoNota = 0
        Do While Registros2 > j

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                End If
            Else
                If DataSet.Tables("NotaDB").Rows(j)("MonedaNota") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaDB").Rows(j)("Fecha_Nota"))
                End If
            End If
            If NumeroNota = "" Then
                NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
            Else
                NumeroNota = DataSet.Tables("NotaDB").Rows(j)("Numero_Nota")
            End If
            MontoNota = DataSet.Tables("NotaDB").Rows(j)("Monto") * TasaCambioRecibo
            TotalMontoNotaDB = TotalMontoNotaDB + MontoNota

            j = j + 1
        Loop

        DataSet.Tables("NotaDB").Reset()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "')  AND (Detalle_Nota.Numero_Factura = '0000')"
        SQlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AS Dias FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota  " & _
                     "WHERE (DATEDIFF(day, Detalle_Nota.Fecha_Nota, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) BETWEEN " & DiasIni & " AND " & DiasFin & ") AND (NotaDebito.Tipo =  'Credito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (Detalle_Nota.Numero_Factura = '0000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "NotaCR")
        Registros2 = DataSet.Tables("NotaCR").Rows.Count
        NumeroNotaCR = ""
        j = 0
        MontoNotaCR = 0
        Do While Registros2 > j

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                End If
            Else
                If DataSet.Tables("NotaCR").Rows(j)("MonedaNota") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("NotaCR").Rows(j)("Fecha_Nota"))
                End If
            End If
            If NumeroNotaCR = "" Then
                NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
            Else
                NumeroNotaCR = DataSet.Tables("NotaCR").Rows(j)("Numero_Nota")
            End If
            MontoNotaCR = MontoNotaCR + DataSet.Tables("NotaCR").Rows(j)("Monto") * TasaCambioRecibo
            TotalMontoNotaCR = TotalMontoNotaCR + MontoNotaCR

            j = j + 1
        Loop
        DataSet.Tables("NotaCR").Reset()


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////BUSCO SI EXISTEN RECIBOS SIN FACTURAS //////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo, Recibo.Cod_Cliente, SUM(DATEDIFF(day, DetalleRecibo.Fecha_Recibo, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))) AS Dias FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente  " & _
                    "HAVING (SUM(DATEDIFF(day, DetalleRecibo.Fecha_Recibo, CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))) BETWEEN " & DiasIni & " AND " & DiasFin & ") AND (DetalleRecibo.Numero_Factura = '0') AND (Recibo.Cod_Cliente = '" & CodigoCliente & "')"


        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recibos")
        Registros2 = DataSet.Tables("Recibos").Rows.Count
        j = 0

        Do While Registros2 > j

            If Me.OptCordobas.Checked = True Then
                If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Cordobas" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                End If
            Else
                If DataSet.Tables("Recibos").Rows(j)("MonedaRecibo") = "Dolares" Then
                    TasaCambioRecibo = 1
                Else
                    TasaCambioRecibo = 1 / BuscaTasaCambio(DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo"))
                End If
            End If
            If NumeroRecibo = "" Then
                NumeroRecibo = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
            Else
                NumeroRecibo = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
            End If
            MontoRecibo = MontoRecibo + DataSet.Tables("Recibos").Rows(j)("MontoPagado") * TasaCambioRecibo

            TotalAbonos = TotalAbonos + MontoRecibo
            j = j + 1
        Loop




        ConsultaSaldoCliente = TotalFactura + TotalMontoNotaDB - TotalMontoNotaCR - TotalAbonos



    End Function


    Public Function ConsultaDebitosCliente(ByVal CodigoCliente As String, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Moneda As String) As Double

        Dim SQlString As String, NumeroRecibo As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Registros As Double, i As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer = 0
        Dim MontoFactura As Double
        Dim TotalFactura As Double = 0, TotalAbonos As Double = 0, TotalCargos As Double = 0
        Dim TotalMora As Double = 0, NumeroNota As String = "", MontoNota As Double = 0, NumeroNotaCR As String = "", MontoNotaCR As Double = 0, TotalMontoNotaCR As Double = 0, TotalMontoNotaDB As Double = 0


        My.Application.DoEvents()
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SQlString = "SELECT CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal / TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.IVA * TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.IVA / TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.NetoPagar * TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.NetoPagar / TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoDolares FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                    "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(FechaInicio, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Clientes.Cod_Cliente = '" & CodigoCliente & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Facturas")


        Registros = DataSet.Tables("Facturas").Rows.Count
        i = 0
        TotalFactura = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = DataSet.Tables("Facturas").Rows.Count
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoFactura = DataSet.Tables("Facturas").Rows(i)("ImporteCordobas") + DataSet.Tables("Facturas").Rows(i)("IvaCordobas")
            Else
                MontoFactura = DataSet.Tables("Facturas").Rows(i)("ImporteDolares") + DataSet.Tables("Facturas").Rows(i)("IvaDolares")
            End If
            TotalFactura = TotalFactura + MontoFactura
            i = i + 1
            Me.ProgressBar1.Value = i
        Loop


        SQlString = "SELECT Detalle_Nota.Numero_Nota AS Expr1, CASE WHEN IndiceNota.MonedaNota = 'Cordobas' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN IndiceNota.MonedaNota = 'Dolares' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_Nota INNER JOIN  NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN TasaCambio ON IndiceNota.Fecha_Nota = TasaCambio.FechaTasa WHERE (NotaDebito.Tipo = 'Debito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota BETWEEN CONVERT(DATETIME, '" & Format(FechaInicio, "yyyy-MM-dd") & "',102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Notas")
        Registros = DataSet.Tables("Notas").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = Registros
        Do While Registros > i
            My.Application.DoEvents()
            If Moneda = "Cordobas" Then
                MontoNota = DataSet.Tables("Notas").Rows(i)("MontoCordobas")
            Else
                MontoNota = DataSet.Tables("Notas").Rows(i)("MontoDolares")
            End If
            TotalFactura = TotalFactura + MontoNota
            i = i + 1
            Me.ProgressBar1.Value = i
        Loop



        ConsultaDebitosCliente = TotalFactura



    End Function





    Private Sub FrmReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String, PosicionUltimo As Double


        Me.GroupBox1.Visible = False
        Me.GroupBoxProductos.Visible = False
        Me.GroupBox3.Visible = False

        Me.DTPFechaFin.Value = Now
        Me.DTPFechaIni.Value = Now

        Select Case Quien
            Case "Reporte General"
                Me.PictureBox3.Visible = False
                Me.PictureBox2.Visible = True
                Me.LblTitulo.Text = "REPORTE GENERAL"
                Me.ListBox.Items.Add("Listado de Clientes")
                Me.ListBox.Items.Add("Listado de Proveedores")
                Me.ListBox.Items.Add("Listado de Vendedores")
                Me.ListBox.Items.Add("Listado de Bodegas")
                Me.ListBox.Items.Add("Catalogo de Productos")
                Me.ListBox.Items.Add("Catalogo de Productos x Fotos")
                Me.ListBox.Items.Add("Informe de Caja General")
                Me.ListBox.Items.Add("Comprobantes de Caja General")
            Case "Reporte Inventario"
                Me.PictureBox2.Visible = False
                Me.PictureBox3.Visible = True
                Me.LblTitulo.Text = "REPORTE DE INVENTARIO"
                Me.GroupBox1.Visible = True
                Me.GroupBoxProductos.Visible = True
                Me.GroupBox3.Visible = True
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.ListBox.Items.Add("Actividad por Producto")
                Me.ListBox.Items.Add("Reporte de Kardex")
                Me.ListBox.Items.Add("Reporte de Kardex Unidades")
                Me.ListBox.Items.Add("Productos Bajo Minimo")
                'Me.ListBox.Items.Add("Historico de Productos")
                Me.ListBox.Items.Add("Movimientos de Productos")
                'Me.ListBox.Items.Add("Actividad en Unidades")
                Me.ListBox.Items.Add("Entrada de Productos")
                Me.ListBox.Items.Add("Salida de Productos")
                Me.ListBox.Items.Add("Control de Entradas y Salidas")
                Me.ListBox.Items.Add("Reporte de Productos mas Inventarios")
                Me.ListBox.Items.Add("Reporte Rotacion de Inventario")
                Me.ListBox.Items.Add("Reporte Salidas de Productos x Tipo")
                Me.ListBox.Items.Add("Reporte Existencia Productos")
                Me.ListBox.Items.Add("Reporte Existencia Costos")

            Case "Reporte Ventas"
                Me.PictureBox2.Visible = False
                Me.PictureBox3.Visible = True
                Me.LblTitulo.Text = "REPORTE DE Ventas/Compras"
                Me.GroupBox1.Visible = True
                Me.GroupBoxProductos.Visible = False
                Me.GroupBox3.Visible = False
                Me.GroupClientes.Visible = True
                Me.GroupVendedor.Visible = True
                Me.ListBox.Items.Add("Reporte de Ventas")
                Me.ListBox.Items.Add("Reporte Grafico de Ventas x Vendedor")
                Me.ListBox.Items.Add("Reporte de Facturas x Vendedor")
                Me.ListBox.Items.Add("Reporte de Ventas Productos x Vendedor")
                Me.ListBox.Items.Add("Reporte de Cotizaciones x Vendedor")
                Me.ListBox.Items.Add("Reporte de Productos mas Vendidos")
                Me.ListBox.Items.Add("Reporte de Utilidad por Factura")
                Me.ListBox.Items.Add("Reporte de Ventas x Productos al Contado")
                Me.ListBox.Items.Add("Reporte de Ventas x Productos al Credito")
                Me.ListBox.Items.Add("Reporte de Ventas x Productos")
                Me.ListBox.Items.Add("Reporte de Ventas x Clientes al Contado")
                Me.ListBox.Items.Add("Reporte de Ventas x Clientes al Credito")
                Me.ListBox.Items.Add("Reporte de Ventas x Clientes")
                Me.ListBox.Items.Add("Reporte Grafico x Proveedor")
                Me.ListBox.Items.Add("Reporte Grafico x Clientes")
                Me.ListBox.Items.Add("Reporte Ventas x Categorias Resumen")
                Me.ListBox.Items.Add("Reporte Ventas x Categorias Detalle")
                Me.ListBox.Items.Add("Reporte de Salidas x Tipo")
                Me.ListBox.Items.Add("Reporte Lista de Precios Vrs Costo")

            Case "Reporte Cuentas x Cobrar"
                Me.ListBox.Items.Add("Reporte de Saldo de Clientes")
                Me.ListBox.Items.Add("Reporte de Historico de Saldo Clientes")
                Me.ListBox.Items.Add("Estado de Cuentas x Cliente")
                Me.ListBox.Items.Add("Reporte de Notas Debito/Credito")
                Me.ListBox.Items.Add("Listado de Recibos de Caja")

        End Select

        '/////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////CARGO LOS COMBOS DEL FORMULARIO REPORTES/////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////
        SqlProductos = "SELECT CodigoNB, Descripcion, Tipo FROM NotaDebito"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaNotas")
        If Not DataSet.Tables("ListaNotas").Rows.Count = 0 Then
            Me.CmbNotas.DataSource = DataSet.Tables("ListaNotas")
            Me.CmbNotas.Splits.Item(0).DisplayColumns(1).Width = 350
        End If


        DataAdapterProductos.Fill(DataSet, "ListaNotas2")
        If Not DataSet.Tables("ListaNotas2").Rows.Count = 0 Then
            Me.CmbNotas2.DataSource = DataSet.Tables("ListaNotas2")
            Me.CmbNotas2.Splits.Item(0).DisplayColumns(1).Width = 350
        End If


        '/////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////CARGO LOS COMBOS DEL FORMULARIO REPORTES/////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////
        SqlProductos = "SELECT DISTINCT Tipo_Factura FROM Facturas"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaTipo")
        If Not DataSet.Tables("ListaTipo").Rows.Count = 0 Then
            Me.CmbTipoDesde.DataSource = DataSet.Tables("ListaTipo")
            Me.CmbTipoDesde.Text = DataSet.Tables("ListaTipo").Rows(0)("Tipo_Factura")
            Me.CmbTipoDesde.Splits.Item(0).DisplayColumns(0).Width = 350
        End If



        DataAdapterProductos.Fill(DataSet, "ListaTipo2")
        If Not DataSet.Tables("ListaTipo2").Rows.Count = 0 Then
            Me.CmbTipoHasta.DataSource = DataSet.Tables("ListaTipo2")
            Me.CmbTipoHasta.Text = DataSet.Tables("ListaTipo2").Rows(0)("Tipo_Factura")
            Me.CmbTipoHasta.Splits.Item(0).DisplayColumns(0).Width = 350
        End If



        '/////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////CARGO LOS COMBOS DEL FORMULARIO REPORTES/////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////
        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboCodProducto.DataSource = DataSet.Tables("ListaProductos")
            Me.CboCodProducto.Splits.Item(0).DisplayColumns(1).Width = 350
        End If


        DataAdapterProductos.Fill(DataSet, "ListaProductos2")
        If Not DataSet.Tables("ListaProductos2").Rows.Count = 0 Then
            Me.CboCodProducto2.DataSource = DataSet.Tables("ListaProductos2")
            Me.CboCodProducto2.Splits.Item(0).DisplayColumns(1).Width = 350
        End If



        '/////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////CARGO LAS LINEAS DEL FORMULARIO REPORTES/////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////
        SqlProductos = "SELECT dbo.Lineas.* FROM  dbo.Lineas"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaLinea")
        If Not DataSet.Tables("ListaLinea").Rows.Count = 0 Then
            Me.CboCodigoLinea.DataSource = DataSet.Tables("ListaLinea")
            Me.CboCodigoLinea.Splits.Item(0).DisplayColumns(1).Width = 350
        End If


        DataAdapterProductos.Fill(DataSet, "ListaLinea2")
        If Not DataSet.Tables("ListaLinea2").Rows.Count = 0 Then
            Me.CboCodigoLinea2.DataSource = DataSet.Tables("ListaLinea2")
            Me.CboCodigoLinea2.Splits.Item(0).DisplayColumns(1).Width = 350
        End If


        '/////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////CARGO LOS COMBOS DE CLIENTES/////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////
        SqlProductos = "SELECT Cod_Cliente, Nombre_Cliente, Apellido_Cliente FROM Clientes"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaClientes")
        If Not DataSet.Tables("ListaClientes").Rows.Count = 0 Then
            Me.CmbClientes.DataSource = DataSet.Tables("ListaClientes")
        End If

        DataAdapterProductos.Fill(DataSet, "ListaClientes2")
        If Not DataSet.Tables("ListaClientes2").Rows.Count = 0 Then
            Me.CmbClientes2.DataSource = DataSet.Tables("ListaClientes2")
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////CARGO LOS COMBOS DE VENDEDORES/////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////
        SqlProductos = "SELECT Cod_Vendedor, Nombre_Vendedor, Apellido_Vendedor FROM  Vendedores"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaVendedores")
        If Not DataSet.Tables("ListaVendedores").Rows.Count = 0 Then
            Me.CmbVendedores.DataSource = DataSet.Tables("ListaVendedores")
        End If

        DataAdapterProductos.Fill(DataSet, "ListaVendedores2")
        If Not DataSet.Tables("ListaVendedores2").Rows.Count = 0 Then
            Me.CmbVendedores2.DataSource = DataSet.Tables("ListaVendedores2")
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////CARGO EL PRODUCTOS EN LAS VARIABLES///////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        CodigoInicio = 0
        CodigoFin = 0
        If Not DataSet.Tables("ListaProductos2").Rows.Count = 0 Then
            CodigoInicio = DataSet.Tables("ListaProductos2").Rows(0)("Cod_Productos")
            PosicionUltimo = DataSet.Tables("ListaProductos2").Rows.Count - 1
            CodigoFin = DataSet.Tables("ListaProductos2").Rows(PosicionUltimo)("Cod_Productos")
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            NombreEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            DireccionEmpresa = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                Ruc = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Imagen.Visible = True
        MostrarImagen = True
        My.Application.DoEvents()

        Dim DataAdapterProductos As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlDatos As String, SQlDatosSuma As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource


        Dim Fecha1 As Date, Fecha2 As Date

        Imagen.Visible = True
        MostrarImagen = True
        My.Application.DoEvents()


        Me.Timer1.Enabled = True
        Me.Button2.Enabled = False
        Me.Button8.Enabled = False
        Me.LblProcesando.Visible = True
        My.Application.DoEvents()

        'Try

        Fecha1 = Me.DTPFechaIni.Value
        Fecha2 = Me.DTPFechaFin.Value
        My.Application.DoEvents()
        Select Case Me.ListBox.Text
            Case "Reporte de Ventas Productos x Vendedor"
                Dim ArepProductoVendedor As New ArepProductoVendedor

                ArepProductoVendedor.LblTitulo.Text = NombreEmpresa
                ArepProductoVendedor.LblDireccion.Text = DireccionEmpresa
                ArepProductoVendedor.LblRuc.Text = Ruc

                SqlDatos = "SELECT Detalle_Facturas.Cod_Producto, MAX(Detalle_Facturas.Descripcion_Producto) AS Descripcion_Producto, SUM(Detalle_Facturas.Cantidad) AS Cantidad, Vendedores.Cod_Vendedor, MAX(Vendedores.Nombre_Vendedor) AS Nombre_Vendedor, SUM(CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Detalle_Facturas.Importe * TasaCambio.MontoTasa ELSE Detalle_Facturas.Importe END) AS ImporteCordobas, MAX(Facturas.MonedaFactura) AS Moneda, SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Detalle_Facturas.Importe / TasaCambio.MontoTasa ELSE Detalle_Facturas.Importe END) AS ImporteDolares, SUM(Detalle_Facturas.Importe) AS Importe, MAX(Lineas.Descripcion_Linea) AS Descripcion_Linea, Lineas.Cod_Linea FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea " & _
                           "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') GROUP BY Detalle_Facturas.Cod_Producto, Vendedores.Cod_Vendedor, Lineas.Cod_Linea "

                If Me.CmbVendedores.Text <> "" And Me.CmbVendedores2.Text <> "" Then
                    If Me.CboCodigoLinea.Text <> "" And Me.CboCodigoLinea2.Text <> "" Then
                        SqlDatos = SqlDatos & " HAVING  (Vendedores.Cod_Vendedor BETWEEN '" & Me.CmbVendedores.Text & "' AND '" & Me.CmbVendedores2.Text & "') AND (Lineas.Cod_Linea BETWEEN '" & Me.CboCodigoLinea.Text & "' AND '" & Me.CboCodigoLinea2.Text & "')"
                    Else
                        SqlDatos = SqlDatos & " HAVING  (Vendedores.Cod_Vendedor BETWEEN '" & Me.CmbVendedores.Text & "' AND '" & Me.CmbVendedores2.Text & "')"
                    End If
                ElseIf Me.CboCodigoLinea.Text <> "" And Me.CboCodigoLinea2.Text <> "" Then
                    SqlDatos = SqlDatos & " HAVING  (Lineas.Cod_Linea BETWEEN '" & Me.CboCodigoLinea.Text & "' AND '" & Me.CboCodigoLinea.Text & "')"
                End If


                SqlDatos = SqlDatos & " ORDER BY Vendedores.Cod_Vendedor, Lineas.Cod_Linea, Detalle_Facturas.Cod_Producto "

                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ArepProductoVendedor.DataSource = SQL
                ViewerForm.arvMain.Document = ArepProductoVendedor.Document

                My.Application.DoEvents()
                ArepProductoVendedor.Run(False)
                ViewerForm.Show()

            Case "Reporte Lista de Precios Vrs Costo"
                Dim ArepPrecioVrsCosto As New ArepPrecioVrsCosto
                Dim SQLString As String, Registro As Double = 0, Iposicion As Double = 0
                Dim CodProducto As String, Compras As Double, FechaIni As String, FechaFin As String, Ventas As Double
                Dim CostoPromedio As Double, Existencia As Double, Inicial As Double, CodBodega As String, Total As Double = 0
                Dim oDataRow As DataRow, NombreProducto As String, NombreBodega As String, Cadena As String
                Dim PrecioUnitario As Double = 0

                'If Dir(RutaLogo) <> "" Then
                '    ArepReporteKardex.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                '    ArepReporteKardexLinea.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                'End If

                ArepPrecioVrsCosto.LblTitulo.Text = NombreEmpresa
                ArepPrecioVrsCosto.LblDireccion.Text = DireccionEmpresa
                ArepPrecioVrsCosto.LblRuc.Text = Ruc

                If Me.CmbAgrupado.Text = "" Then
                    MsgBox("Se necesita Agrupado", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If
                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQLString = "SELECT  Cod_Productos, Descripcion_Producto, Cod_Linea AS Cod_Bodega, Cod_Cuenta_Inventario AS Nombre_Bodega, Cod_Cuenta_Costo AS Inicial, Cod_Cuenta_Ventas AS Entrada, Cod_Cuenta_GastoAjuste AS Salida, Cod_Cuenta_IngresoAjuste AS Saldo, Unidad_Medida AS CostoVenta, Precio_Venta AS InicialD, Precio_Lista AS EntradaD, Descuento AS SalidaD, Existencia_Negativa AS SaldoD, Precio_Venta, Descripcion_Producto As Categoria  FROM Productos WHERE (Cod_Productos = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalKARDEX")


                SqlDatos = ""
                Select Case Me.CmbAgrupado.Text
                    Case "Codigo Producto"
                        If Me.CboCodProducto.Text = "" Then
                            If Me.CboCodProducto2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Productos"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & CodigoInicio & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                            End If
                        ElseIf Me.CboCodProducto2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & CodigoFin & "') ORDER BY Productos.Cod_Productos"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                        End If

                    Case "Linea"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Linea"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Linea"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                        End If


                    Case "Bodega"
                        If Me.CboCodProducto.Text = "" And Me.CboCodProducto2.Text = "" Then
                            If Me.CmbRango1.Text = "" Then
                                If Me.CmbRango2.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                End If
                            ElseIf Me.CmbRango2.Text = "" Then
                                If Me.CmbRango1.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                End If
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            End If
                        Else

                            Cadena = " AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            If Me.CmbRango1.Text = "" Then
                                If Me.CmbRango2.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) " & Cadena
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                                End If
                            ElseIf Me.CmbRango2.Text = "" Then
                                If Me.CmbRango1.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                                End If
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                            End If
                        End If

                    Case "Rubro"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"

                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                        Else
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"
                        End If



                End Select

                '*****************************************************************************************************************************************
                '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
                '*****************************************************************************************************************************************
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                Iposicion = 0
                Do While Iposicion < Registro


                    FechaIni = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
                    FechaFin = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                    CodProducto = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Productos")
                    PrecioUnitario = DataSet.Tables("Productos").Rows(Iposicion)("Precio_Venta")
                    NombreProducto = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Producto")
                    NombreBodega = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Linea")
                    CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")
                    '/////////////////ESTE ES EL COSTO PROMEDIO GENERAL ////////////////////
                    'CostoPromedio = DataSet.Tables("Productos").Rows(Iposicion)("Costo_Promedio")

                    If Me.CmbAgrupado.Text = "Bodega" Then
                        CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")

                        Compras = Format(BuscaCompraBodega(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        Ventas = Format(BuscaVentaBodega(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        'Inicial = Format(BuscaInventarioInicialBodegaMov(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        Inicial = Format(BuscaInventarioInicialBodega(CodProducto, FechaIni, CodBodega), "####0.00")
                        Existencia = Inicial + Compras - Ventas

                        CostoPromedio = CostoPromedioKardexBodega(CodProducto, FechaFin, CodBodega)
                        'CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)

                    Else
                        CodBodega = 1
                        CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)
                        Compras = Format(BuscaCompra(CodProducto, FechaIni, FechaFin), "####0.00")
                        Ventas = Format(BuscaVenta(CodProducto, FechaIni, FechaFin), "####0.00")
                        Inicial = Format(BuscaInventarioInicial(CodProducto, FechaIni), "####0.00")
                        Existencia = Inicial + Compras - Ventas
                    End If


                    'Me.TxtInicialM.Text = Format(Inicial * CostoPromedio, "##,##0.00")
                    'Me.TxtEntradaM.Text = Format(Compras * CostoPromedio, "##,##0.00")
                    'Me.TxtSalidaM.Text = Format(Ventas * CostoPromedio, "##,##0.00")
                    'Me.TxtSaldoM.Text = Format(Existencia * CostoPromedio, "##,##0.00")


                    ''///////////////////////////////SUMO LAS VARIABLES ///////////////////////////////////////
                    'TotalInicial = TotalInicial + Inicial
                    'TotalCompras = TotalCompras + Compras
                    'TotalVentas = TotalVentas + Ventas
                    'TotalExistencia = TotalInicial + TotalCompras - TotalVentas

                    'TotalInicialM = TotalInicialM + (Inicial * CostoPromedio)
                    'TotalComprasM = TotalComprasM + (Compras * CostoPromedio)
                    'TotalVentasM = TotalVentasM + (Ventas * CostoPromedio)
                    'TotalExistenciaM = TotalExistenciaM + (Existencia * CostoPromedio)


                    'MontoSalida = Ventas * CostoPromedio
                    'MontoSalidaD = Ventas * CostoPromedioDolar
                    If DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Descuento" And DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Servicio" Then
                        'If (Inicial + Compras + Ventas) <> 0 Then
                        If Format(MontoInicial + MontoEntrada + MontoSalida, "##,##0.00") <> "0.00" Then
                            oDataRow = DataSet.Tables("TotalKARDEX").NewRow
                            oDataRow("Cod_Productos") = CodProducto
                            oDataRow("Precio_Venta") = PrecioUnitario
                            oDataRow("Descripcion_Producto") = NombreProducto
                            oDataRow("Cod_Bodega") = CodBodega
                            oDataRow("Nombre_Bodega") = NombreBodega
                            oDataRow("Categoria") = NombreBodega
                            oDataRow("Inicial") = Inicial
                            oDataRow("Entrada") = Compras
                            oDataRow("Salida") = Ventas
                            oDataRow("Saldo") = Existencia
                            If Me.OptCordobas.Checked = True Then
                                oDataRow("CostoVenta") = CostoPromedio
                                oDataRow("InicialD") = MontoInicial 'Inicial * CostoPromedio  
                                oDataRow("EntradaD") = MontoEntrada 'Compras * CostoPromedio 
                                oDataRow("SalidaD") = MontoSalida  'MontoSalida
                                'If Existencia <> 0 Then
                                'If (MontoInicial + MontoEntrada - MontoSalida) > 1 Then
                                oDataRow("SaldoD") = MontoInicial + MontoEntrada - MontoSalida  'Existencia * CostoPromedio
                                'Else
                                '    oDataRow("SaldoD") = 0
                                'End If
                                'End If
                            Else
                                oDataRow("CostoVenta") = CostoPromedioDolar
                                oDataRow("InicialD") = MontoInicialD
                                oDataRow("EntradaD") = MontoEntradaD
                                oDataRow("SalidaD") = MontoSalidaD
                                'If Existencia <> 0 Then
                                '    If (MontoInicialD + MontoEntradaD - MontoSalidaD) > 1 Then
                                oDataRow("SaldoD") = MontoInicialD + MontoEntradaD - MontoSalidaD
                                '    Else
                                'oDataRow("SaldoD") = 0
                                '    End If
                                'End If
                            End If
                            DataSet.Tables("TotalKARDEX").Rows.Add(oDataRow)
                        End If
                    End If


                    Me.Text = "Procesando: " & CodProducto

                    If Me.ProgressBar.Maximum <> 0 Then
                        Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    End If

                    My.Application.DoEvents()



                    Iposicion = Iposicion + 1
                Loop






                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos




                If Me.CmbAgrupado.Text = "Codigo Producto" Then
                    ArepPrecioVrsCosto.GroupHeader1.Visible = False
                    ArepPrecioVrsCosto.LblCodigo.Visible = False
                    ArepPrecioVrsCosto.TxtCodLinea.Visible = False
                    ArepPrecioVrsCosto.LblNombre.Visible = False
                    ArepPrecioVrsCosto.Label20.Visible = False
                    ArepPrecioVrsCosto.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepPrecioVrsCosto.LblTitulo.Text = NombreEmpresa
                    ArepPrecioVrsCosto.LblDireccion.Text = DireccionEmpresa
                    ArepPrecioVrsCosto.LblRuc.Text = Ruc
                    ArepPrecioVrsCosto.DataSource = SQL
                    ArepPrecioVrsCosto.Document.Name = "REPORTE EXISTENCIA COSTOS"
                    ArepPrecioVrsCosto.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepPrecioVrsCosto.Document
                    My.Application.DoEvents()
                    ArepPrecioVrsCosto.Run(False)
                    ViewerForm.Show()

                    'ArepActividadProducto.Show()
                ElseIf Me.CmbAgrupado.Text = "Linea" Then
                    ArepPrecioVrsCosto.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepPrecioVrsCosto.LblTitulo.Text = NombreEmpresa
                    ArepPrecioVrsCosto.LblDireccion.Text = DireccionEmpresa
                    ArepPrecioVrsCosto.LblRuc.Text = Ruc
                    ArepPrecioVrsCosto.DataSource = SQL
                    ArepPrecioVrsCosto.Document.Name = "ACTIVIDAD PRODUCTOS POR LINEA"
                    ArepPrecioVrsCosto.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepPrecioVrsCosto.Document
                    My.Application.DoEvents()
                    ArepPrecioVrsCosto.Run(False)
                    ViewerForm.Show()
                    'ArepActividadProductoLinea.Show()
                ElseIf Me.CmbAgrupado.Text = "Bodega" Then
                    ArepPrecioVrsCosto.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepPrecioVrsCosto.LblTitulo.Text = NombreEmpresa
                    ArepPrecioVrsCosto.LblDireccion.Text = DireccionEmpresa
                    ArepPrecioVrsCosto.LblRuc.Text = Ruc
                    'ArepReporteKardexLinea.DataSource = SQL
                    ArepPrecioVrsCosto.Document.Name = "ACTIVIDAD PRODUCTOS POR BODEGA"
                    ArepPrecioVrsCosto.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    ArepPrecioVrsCosto.LblCodigo.Text = "Codigo Bodega"
                    ArepPrecioVrsCosto.LblNombre.Text = "Nombre Bodega"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepPrecioVrsCosto.Document
                    My.Application.DoEvents()
                    ArepPrecioVrsCosto.Run(False)
                    ViewerForm.Show()
                    'ArepActividadProductoLinea.Show()
                ElseIf Me.CmbAgrupado.Text = "Rubro" Then
                    ArepPrecioVrsCosto.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepPrecioVrsCosto.LblTitulo.Text = NombreEmpresa
                    ArepPrecioVrsCosto.LblDireccion.Text = DireccionEmpresa
                    ArepPrecioVrsCosto.LblRuc.Text = Ruc
                    ArepPrecioVrsCosto.DataSource = SQL
                    ArepPrecioVrsCosto.Document.Name = "ACTIVIDAD PRODUCTOS POR RUBRO"
                    ArepPrecioVrsCosto.LblCodigo.Text = "Codigo Rubro"
                    ArepPrecioVrsCosto.LblNombre.Text = "Nombre Rubro"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepPrecioVrsCosto.Document
                    My.Application.DoEvents()
                    ArepPrecioVrsCosto.Run(False)
                    ViewerForm.Show()

                End If


            Case "Reporte Existencia Costos"
                Dim ArepExistenciaCostos As New ArepExistenciaCostos
                Dim SQLString As String, Registro As Double = 0, Iposicion As Double = 0
                Dim CodProducto As String, Compras As Double, FechaIni As String, FechaFin As String, Ventas As Double
                Dim CostoPromedio As Double, Existencia As Double, Inicial As Double, CodBodega As String, Total As Double = 0
                Dim oDataRow As DataRow, NombreProducto As String, NombreBodega As String, Cadena As String

                'If Dir(RutaLogo) <> "" Then
                '    ArepReporteKardex.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                '    ArepReporteKardexLinea.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                'End If

                ArepExistenciaCostos.LblTitulo.Text = NombreEmpresa
                ArepExistenciaCostos.LblDireccion.Text = DireccionEmpresa
                ArepExistenciaCostos.LblRuc.Text = Ruc

                If Me.CmbAgrupado.Text = "" Then
                    MsgBox("Se necesita Agrupado", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If
                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQLString = "SELECT  Cod_Productos, Descripcion_Producto, Cod_Linea AS Cod_Bodega, Cod_Cuenta_Inventario AS Nombre_Bodega, Cod_Cuenta_Costo AS Inicial, Cod_Cuenta_Ventas AS Entrada, Cod_Cuenta_GastoAjuste AS Salida, Cod_Cuenta_IngresoAjuste AS Saldo, Unidad_Medida AS CostoVenta, Precio_Venta AS InicialD, Precio_Lista AS EntradaD, Descuento AS SalidaD, Existencia_Negativa AS SaldoD  FROM Productos WHERE (Cod_Productos = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalKARDEX")


                SqlDatos = ""
                Select Case Me.CmbAgrupado.Text
                    Case "Codigo Producto"
                        If Me.CboCodProducto.Text = "" Then
                            If Me.CboCodProducto2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Productos"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & CodigoInicio & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                            End If
                        ElseIf Me.CboCodProducto2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & CodigoFin & "') ORDER BY Productos.Cod_Productos"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                        End If

                    Case "Linea"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Linea"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Linea"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                        End If


                    Case "Bodega"
                        If Me.CboCodProducto.Text = "" And Me.CboCodProducto2.Text = "" Then
                            If Me.CmbRango1.Text = "" Then
                                If Me.CmbRango2.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                End If
                            ElseIf Me.CmbRango2.Text = "" Then
                                If Me.CmbRango1.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                End If
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            End If
                        Else

                            Cadena = " AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            If Me.CmbRango1.Text = "" Then
                                If Me.CmbRango2.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) " & Cadena
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                                End If
                            ElseIf Me.CmbRango2.Text = "" Then
                                If Me.CmbRango1.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                                End If
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                            End If
                        End If

                    Case "Rubro"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"

                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                        Else
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"
                        End If



                End Select

                '*****************************************************************************************************************************************
                '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
                '*****************************************************************************************************************************************
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                Iposicion = 0
                Do While Iposicion < Registro


                    FechaIni = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
                    FechaFin = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                    CodProducto = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Productos")
                    NombreProducto = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Producto")
                    NombreBodega = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Linea")
                    CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")
                    '/////////////////ESTE ES EL COSTO PROMEDIO GENERAL ////////////////////
                    'CostoPromedio = DataSet.Tables("Productos").Rows(Iposicion)("Costo_Promedio")

                    If Me.CmbAgrupado.Text = "Bodega" Then
                        CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")

                        Compras = Format(BuscaCompraBodega(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        Ventas = Format(BuscaVentaBodega(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        'Inicial = Format(BuscaInventarioInicialBodegaMov(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        Inicial = Format(BuscaInventarioInicialBodega(CodProducto, FechaIni, CodBodega), "####0.00")
                        Existencia = Inicial + Compras - Ventas

                        CostoPromedio = CostoPromedioKardexBodega(CodProducto, FechaFin, CodBodega)
                        'CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)

                    Else
                        CodBodega = 1
                        CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)
                        Compras = Format(BuscaCompra(CodProducto, FechaIni, FechaFin), "####0.00")
                        Ventas = Format(BuscaVenta(CodProducto, FechaIni, FechaFin), "####0.00")
                        Inicial = Format(BuscaInventarioInicial(CodProducto, FechaIni), "####0.00")
                        Existencia = Inicial + Compras - Ventas
                    End If


                    'Me.TxtInicialM.Text = Format(Inicial * CostoPromedio, "##,##0.00")
                    'Me.TxtEntradaM.Text = Format(Compras * CostoPromedio, "##,##0.00")
                    'Me.TxtSalidaM.Text = Format(Ventas * CostoPromedio, "##,##0.00")
                    'Me.TxtSaldoM.Text = Format(Existencia * CostoPromedio, "##,##0.00")


                    ''///////////////////////////////SUMO LAS VARIABLES ///////////////////////////////////////
                    'TotalInicial = TotalInicial + Inicial
                    'TotalCompras = TotalCompras + Compras
                    'TotalVentas = TotalVentas + Ventas
                    'TotalExistencia = TotalInicial + TotalCompras - TotalVentas

                    'TotalInicialM = TotalInicialM + (Inicial * CostoPromedio)
                    'TotalComprasM = TotalComprasM + (Compras * CostoPromedio)
                    'TotalVentasM = TotalVentasM + (Ventas * CostoPromedio)
                    'TotalExistenciaM = TotalExistenciaM + (Existencia * CostoPromedio)


                    'MontoSalida = Ventas * CostoPromedio
                    'MontoSalidaD = Ventas * CostoPromedioDolar
                    If DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Descuento" And DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Servicio" Then
                        'If (Inicial + Compras + Ventas) <> 0 Then
                        If Format(MontoInicial + MontoEntrada + MontoSalida, "##,##0.00") <> "0.00" Then
                            oDataRow = DataSet.Tables("TotalKARDEX").NewRow
                            oDataRow("Cod_Productos") = CodProducto
                            oDataRow("Descripcion_Producto") = NombreProducto
                            oDataRow("Cod_Bodega") = CodBodega
                            oDataRow("Nombre_Bodega") = NombreBodega
                            oDataRow("Inicial") = Inicial
                            oDataRow("Entrada") = Compras
                            oDataRow("Salida") = Ventas
                            oDataRow("Saldo") = Existencia
                            If Me.OptCordobas.Checked = True Then
                                oDataRow("CostoVenta") = CostoPromedio
                                oDataRow("InicialD") = MontoInicial 'Inicial * CostoPromedio  
                                oDataRow("EntradaD") = MontoEntrada 'Compras * CostoPromedio 
                                oDataRow("SalidaD") = MontoSalida  'MontoSalida
                                'If Existencia <> 0 Then
                                'If (MontoInicial + MontoEntrada - MontoSalida) > 1 Then
                                oDataRow("SaldoD") = MontoInicial + MontoEntrada - MontoSalida  'Existencia * CostoPromedio
                                'Else
                                '    oDataRow("SaldoD") = 0
                                'End If
                                'End If
                            Else
                                oDataRow("CostoVenta") = CostoPromedioDolar
                                oDataRow("InicialD") = MontoInicialD
                                oDataRow("EntradaD") = MontoEntradaD
                                oDataRow("SalidaD") = MontoSalidaD
                                'If Existencia <> 0 Then
                                '    If (MontoInicialD + MontoEntradaD - MontoSalidaD) > 1 Then
                                oDataRow("SaldoD") = MontoInicialD + MontoEntradaD - MontoSalidaD
                                '    Else
                                'oDataRow("SaldoD") = 0
                                '    End If
                                'End If
                            End If
                            DataSet.Tables("TotalKARDEX").Rows.Add(oDataRow)
                        End If
                    End If


                    Me.Text = "Procesando: " & CodProducto

                    If Me.ProgressBar.Maximum <> 0 Then
                        Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    End If

                    My.Application.DoEvents()



                    Iposicion = Iposicion + 1
                Loop






                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos




                If Me.CmbAgrupado.Text = "Codigo Producto" Then
                    ArepExistenciaCostos.GroupHeader1.Visible = False
                    ArepExistenciaCostos.LblCodigo.Visible = False
                    ArepExistenciaCostos.TxtCodLinea.Visible = False
                    ArepExistenciaCostos.LblNombre.Visible = False
                    ArepExistenciaCostos.Label20.Visible = False
                    ArepExistenciaCostos.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepExistenciaCostos.LblTitulo.Text = NombreEmpresa
                    ArepExistenciaCostos.LblDireccion.Text = DireccionEmpresa
                    ArepExistenciaCostos.LblRuc.Text = Ruc
                    ArepExistenciaCostos.DataSource = SQL
                    ArepExistenciaCostos.Document.Name = "REPORTE EXISTENCIA COSTOS"
                    ArepExistenciaCostos.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepExistenciaCostos.Document
                    My.Application.DoEvents()
                    ArepExistenciaCostos.Run(False)
                    ViewerForm.Show()

                    'ArepActividadProducto.Show()
                ElseIf Me.CmbAgrupado.Text = "Linea" Then
                    ArepExistenciaCostos.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepExistenciaCostos.LblTitulo.Text = NombreEmpresa
                    ArepExistenciaCostos.LblDireccion.Text = DireccionEmpresa
                    ArepExistenciaCostos.LblRuc.Text = Ruc
                    ArepExistenciaCostos.DataSource = SQL
                    ArepExistenciaCostos.Document.Name = "ACTIVIDAD PRODUCTOS POR LINEA"
                    ArepExistenciaCostos.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepExistenciaCostos.Document
                    My.Application.DoEvents()
                    ArepExistenciaCostos.Run(False)
                    ViewerForm.Show()
                    'ArepActividadProductoLinea.Show()
                ElseIf Me.CmbAgrupado.Text = "Bodega" Then
                    ArepExistenciaCostos.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepExistenciaCostos.LblTitulo.Text = NombreEmpresa
                    ArepExistenciaCostos.LblDireccion.Text = DireccionEmpresa
                    ArepExistenciaCostos.LblRuc.Text = Ruc
                    'ArepReporteKardexLinea.DataSource = SQL
                    ArepExistenciaCostos.Document.Name = "ACTIVIDAD PRODUCTOS POR BODEGA"
                    ArepExistenciaCostos.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    ArepExistenciaCostos.LblCodigo.Text = "Codigo Bodega"
                    ArepExistenciaCostos.LblNombre.Text = "Nombre Bodega"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepExistenciaCostos.Document
                    My.Application.DoEvents()
                    ArepExistenciaCostos.Run(False)
                    ViewerForm.Show()
                    'ArepActividadProductoLinea.Show()
                ElseIf Me.CmbAgrupado.Text = "Rubro" Then
                    ArepExistenciaCostos.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepExistenciaCostos.LblTitulo.Text = NombreEmpresa
                    ArepExistenciaCostos.LblDireccion.Text = DireccionEmpresa
                    ArepExistenciaCostos.LblRuc.Text = Ruc
                    ArepExistenciaCostos.DataSource = SQL
                    ArepExistenciaCostos.Document.Name = "ACTIVIDAD PRODUCTOS POR RUBRO"
                    ArepExistenciaCostos.LblCodigo.Text = "Codigo Rubro"
                    ArepExistenciaCostos.LblNombre.Text = "Nombre Rubro"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepExistenciaCostos.Document
                    My.Application.DoEvents()
                    ArepExistenciaCostos.Run(False)
                    ViewerForm.Show()

                End If



            Case "Reporte Salidas de Productos x Tipo"
                Dim ArepSalidaProductosTipo2 As New ArepSalidaProductosTipo2

                If Dir(RutaLogo) <> "" Then
                    ArepSalidaProductosTipo2.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepSalidaProductosTipo2.LblTitulo.Text = NombreEmpresa
                ArepSalidaProductosTipo2.LblDireccion.Text = DireccionEmpresa
                ArepSalidaProductosTipo2.LblRuc.Text = Ruc

                Select Case Me.CmbAgrupado.Text
                    Case "Linea"
                        SqlDatos = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, ROUND(Detalle_Facturas.Costo_Unitario, 4) AS Costo, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Cantidad * ROUND(Detalle_Facturas.Costo_Unitario, 4)) AS Total, Lineas.Descripcion_Linea, Lineas.Cod_Linea FROM  Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea  " & _
                                   "WHERE (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Facturas.Tipo_Factura BETWEEN '" & Me.CmbTipoDesde.Text & "' AND '" & Me.CmbTipoHasta.Text & "') GROUP BY Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, ROUND(Detalle_Facturas.Costo_Unitario, 4), Lineas.Descripcion_Linea, Lineas.Cod_Linea HAVING  (Lineas.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Lineas.Descripcion_Linea, Detalle_Facturas.Cod_Producto"
                    Case "Bodega"
                        SqlDatos = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, ROUND(Detalle_Facturas.Costo_Unitario, 4) AS Costo, Bodegas.Nombre_Bodega, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Cantidad * ROUND(Detalle_Facturas.Costo_Unitario, 4)) AS Total FROM  Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega  " & _
                                   "WHERE (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Facturas.Tipo_Factura BETWEEN '" & Me.CmbTipoDesde.Text & "' AND '" & Me.CmbTipoHasta.Text & "') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') GROUP BY Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, ROUND(Detalle_Facturas.Costo_Unitario, 4), Bodegas.Nombre_Bodega,Facturas.Cod_Bodega ORDER BY  Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                        ArepSalidaProductosTipo2.GroupHeader1.Visible = True
                    Case "Codigo Producto"
                        SqlDatos = "SELECT Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, ROUND(Detalle_Facturas.Costo_Unitario, 4) AS Costo, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Cantidad * ROUND(Detalle_Facturas.Costo_Unitario, 4)) AS Total FROM Detalle_Facturas INNER JOIN  Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega  " & _
                                   "WHERE (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Facturas.Tipo_Factura BETWEEN '" & Me.CmbTipoDesde.Text & "' AND '" & Me.CmbTipoHasta.Text & "') GROUP BY Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, ROUND(Detalle_Facturas.Costo_Unitario, 4) ORDER BY Detalle_Facturas.Cod_Producto"
                        ArepSalidaProductosTipo2.GroupHeader1.Visible = False
                End Select

                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepSalidaProductosTipo2.Document
                My.Application.DoEvents()
                ArepSalidaProductosTipo2.DataSource = SQL
                ArepSalidaProductosTipo2.Run(False)
                ViewerForm.Show()



            Case "Reporte Existencia Productos"
                Dim SqlString As String, Existencia As Double = 0, iPosicionFila As Double = 0, CodigoBodega As String
                Dim oDataRow As DataRow, i As Double, Registro As Double = 0
                Dim CodigoProducto As String
                Dim ArepExistencia As New ArepExistencia

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SqlString = "SELECT Cod_Productos, Tipo_Producto, Descripcion_Producto, Unidad_Medida, Existencia_Unidades FROM Productos WHERE  (Tipo_Producto <> N'Servicio') AND (Cod_Productos = N'-10000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Existencia")


                SqlString = "SELECT Cod_Productos, Tipo_Producto, Descripcion_Producto, Unidad_Medida, Existencia_Unidades FROM Productos WHERE  (Tipo_Producto <> N'Servicio') "
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                i = 0
                Do While i < Registro


                    '//////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////BUSCO LAS BODEGAS DEL PRODUCTO/////////////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////
                    CodigoProducto = DataSet.Tables("Productos").Rows(i)("Cod_Productos")
                    SqlString = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega,DetalleBodegas.Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & _
                                "WHERE (DetalleBodegas.Cod_Productos = '" & CodigoProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Bodegas")

                    '//////////////////////////////////////////////////////////////////////////////////////////////////////
                    '////////////////////////BUSCO LA EXISTENCIA DE ESTE PRODUCTO PARA CADA BODEGA//////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Existencia = 0
                    iPosicionFila = 0
                    Do While iPosicionFila < (DataSet.Tables("Bodegas").Rows.Count)
                        My.Application.DoEvents()
                        CodigoBodega = DataSet.Tables("Bodegas").Rows(iPosicionFila)("Cod_Bodegas")
                        ExistenciaBodega = BuscaExistenciaBodega(CodigoProducto, CodigoBodega)

                        Existencia = Existencia + ExistenciaBodega
                        MiConexion.Close()
                        iPosicionFila = iPosicionFila + 1
                    Loop
                    DataSet.Tables("Bodegas").Reset()

                    oDataRow = DataSet.Tables("Existencia").NewRow
                    oDataRow("Cod_Productos") = DataSet.Tables("Productos").Rows(i)("Cod_Productos")
                    oDataRow("Descripcion_Producto") = DataSet.Tables("Productos").Rows(i)("Descripcion_Producto")
                    oDataRow("Tipo_Producto") = DataSet.Tables("Productos").Rows(i)("Tipo_Producto")
                    oDataRow("Unidad_Medida") = DataSet.Tables("Productos").Rows(i)("Unidad_Medida")
                    oDataRow("Existencia_Unidades") = Existencia

                    DataSet.Tables("Existencia").Rows.Add(oDataRow)


                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    i = i + 1
                Loop

                ArepExistencia.DataSource = DataSet.Tables("Existencia")
                ArepExistencia.LblTitulo.Text = NombreEmpresa
                ArepExistencia.LblDireccion.Text = DireccionEmpresa
                ArepExistencia.LblRuc.Text = Ruc
                ArepExistencia.Document.Name = "REPORTE EXISTENCIA POR PRODUCTOS"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepExistencia.Document
                My.Application.DoEvents()
                ArepExistencia.Run(False)
                ViewerForm.Show()


            Case "Reporte de Kardex Unidades"

                Dim ArepReporteKardex As New ArepKardexUnidades
                Dim SQLString As String, Registro As Double = 0, Iposicion As Double = 0
                Dim CodProducto As String, Compras As Double, FechaIni As String, FechaFin As String, Ventas As Double
                Dim CostoPromedio As Double, Existencia As Double, Inicial As Double, CodBodega As String, Total As Double = 0
                Dim oDataRow As DataRow, NombreProducto As String, NombreBodega As String, Cadena As String

                'If Dir(RutaLogo) <> "" Then
                '    ArepReporteKardex.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                '    ArepReporteKardexLinea.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                'End If

                ArepReporteKardex.LblTitulo.Text = NombreEmpresa
                ArepReporteKardex.LblDireccion.Text = DireccionEmpresa
                ArepReporteKardex.LblRuc.Text = Ruc

                If Me.CmbAgrupado.Text = "" Then
                    MsgBox("Se necesita Agrupado", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If
                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQLString = "SELECT  Cod_Productos, Descripcion_Producto, Cod_Linea AS Cod_Bodega, Cod_Cuenta_Inventario AS Nombre_Bodega, Cod_Cuenta_Costo AS Inicial, Cod_Cuenta_Ventas AS Entrada, Cod_Cuenta_GastoAjuste AS Salida, Cod_Cuenta_IngresoAjuste AS Saldo, Unidad_Medida AS CostoVenta, Precio_Venta AS InicialD, Precio_Lista AS EntradaD, Descuento AS SalidaD, Existencia_Negativa AS SaldoD  FROM Productos WHERE (Cod_Productos = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalKARDEX")


                SqlDatos = ""
                Select Case Me.CmbAgrupado.Text
                    Case "Codigo Producto"
                        If Me.CboCodProducto.Text = "" Then
                            If Me.CboCodProducto2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Productos"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Productos BETWEEN '" & CodigoInicio & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                            End If
                        ElseIf Me.CboCodProducto2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & CodigoFin & "') ORDER BY Productos.Cod_Productos"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                        End If

                    Case "Linea"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Linea"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Linea"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                        End If


                    Case "Bodega"
                        If Me.CboCodProducto.Text = "" And Me.CboCodProducto2.Text = "" Then
                            If Me.CmbRango1.Text = "" Then
                                If Me.CmbRango2.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                End If
                            ElseIf Me.CmbRango2.Text = "" Then
                                If Me.CmbRango1.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                End If
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            End If
                        Else

                            Cadena = " AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            If Me.CmbRango1.Text = "" Then
                                If Me.CmbRango2.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) " & Cadena
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                                End If
                            ElseIf Me.CmbRango2.Text = "" Then
                                If Me.CmbRango1.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                                End If
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                            End If
                        End If

                    Case "Rubro"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"

                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                        Else
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"
                        End If



                End Select

                '*****************************************************************************************************************************************
                '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
                '*****************************************************************************************************************************************
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                Iposicion = 0
                Do While Iposicion < Registro


                    FechaIni = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
                    FechaFin = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                    CodProducto = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Productos")
                    NombreProducto = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Producto")
                    NombreBodega = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Linea")
                    CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")
                    '/////////////////ESTE ES EL COSTO PROMEDIO GENERAL ////////////////////
                    'CostoPromedio = DataSet.Tables("Productos").Rows(Iposicion)("Costo_Promedio")

                    If Me.CmbAgrupado.Text = "Bodega" Then
                        CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")

                        Compras = Format(BuscaCompraBodega(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        Ventas = Format(BuscaVentaBodega(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        Inicial = Format(BuscaInventarioInicialBodega(CodProducto, FechaIni, CodBodega), "####0.00")
                        Existencia = Inicial + Compras - Ventas

                        'CostoPromedio = CostoPromedioKardexBodega(CodProducto, FechaFin, CodBodega)

                    Else

                        'CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)
                        Compras = Format(BuscaCompra(CodProducto, FechaIni, FechaFin), "####0.00")
                        Ventas = Format(BuscaVenta(CodProducto, FechaIni, FechaFin), "####0.00")
                        Inicial = Format(BuscaInventarioInicial(CodProducto, FechaIni), "####0.00")
                        Existencia = Inicial + Compras - Ventas
                    End If


                    If DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Descuento" And DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Servicio" Then
                        If (Inicial + Compras + Ventas) <> 0 Then
                            oDataRow = DataSet.Tables("TotalKARDEX").NewRow
                            oDataRow("Cod_Productos") = CodProducto
                            oDataRow("Descripcion_Producto") = NombreProducto
                            oDataRow("Cod_Bodega") = CodBodega
                            oDataRow("Nombre_Bodega") = NombreBodega
                            oDataRow("Inicial") = Inicial
                            oDataRow("Entrada") = Compras
                            oDataRow("Salida") = Ventas
                            oDataRow("Saldo") = Existencia
                            If Me.OptCordobas.Checked = True Then
                                oDataRow("CostoVenta") = CostoPromedio
                                oDataRow("InicialD") = MontoInicial 'Inicial * CostoPromedio  
                                oDataRow("EntradaD") = MontoEntrada 'Compras * CostoPromedio 
                                oDataRow("SalidaD") = MontoSalida  'MontoSalida
                                If Existencia <> 0 Then
                                    oDataRow("SaldoD") = MontoInicial + MontoEntrada - MontoSalida  'Existencia * CostoPromedio
                                Else
                                    oDataRow("SaldoD") = 0
                                End If
                            Else
                                oDataRow("CostoVenta") = CostoPromedioDolar
                                oDataRow("InicialD") = MontoInicialD
                                oDataRow("EntradaD") = MontoEntradaD
                                oDataRow("SalidaD") = MontoSalidaD
                                If Existencia <> 0 Then
                                    oDataRow("SaldoD") = MontoInicialD + MontoEntradaD - MontoSalidaD
                                Else
                                    oDataRow("SaldoD") = 0
                                End If
                            End If
                            DataSet.Tables("TotalKARDEX").Rows.Add(oDataRow)
                        End If
                    End If


                    Me.Text = "Procesando: " & CodProducto

                    If Me.ProgressBar.Maximum <> 0 Then
                        Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    End If

                    My.Application.DoEvents()



                    Iposicion = Iposicion + 1
                Loop






                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos



                ArepReporteKardex.DataSource = DataSet.Tables("TotalKARDEX")
                ArepReporteKardex.LblTitulo.Text = NombreEmpresa
                ArepReporteKardex.LblDireccion.Text = DireccionEmpresa
                ArepReporteKardex.LblRuc.Text = Ruc
                'ArepReporteKardexLinea.DataSource = SQL
                ArepReporteKardex.Document.Name = "ACTIVIDAD PRODUCTOS POR BODEGA"
                ArepReporteKardex.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                'ArepReporteKardex.LblCodigo.Text = "Codigo Bodega"
                'ArepReporteKardex.LblNombre.Text = "Nombre Bodega"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepReporteKardex.Document
                My.Application.DoEvents()
                ArepReporteKardex.Run(False)
                ViewerForm.Show()


            Case "Reporte de Salidas x Tipo"
                Dim ArepDevolucionVentas As New ArepDevolucionVentas

                If Dir(RutaLogo) <> "" Then
                    ArepDevolucionVentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepDevolucionVentas.LblTitulo.Text = NombreEmpresa
                ArepDevolucionVentas.LblDireccion.Text = DireccionEmpresa
                ArepDevolucionVentas.LblRuc.Text = Ruc
                If Me.OptDolares.Checked = True Then
                    ArepDevolucionVentas.LblMoneda.Text = "Expresado en Dolares"
                    SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, MAX(Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente) AS Nombres, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Detalle_Facturas.Importe ELSE Detalle_Facturas.Importe / TasaCambio.MontoTasa END) AS Importe, Bodegas.Cod_Bodega, Bodegas.Nombre_Bodega, MAX(Facturas.Tipo_Factura) AS Tipo_Factura FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega  " & _
                               "WHERE (Detalle_Facturas.Tipo_Factura BETWEEN '" & Me.CmbTipoDesde.Text & "' AND '" & Me.CmbTipoHasta.Text & "') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') GROUP BY Facturas.Numero_Factura, Facturas.Fecha_Factura, Bodegas.Cod_Bodega, Bodegas.Nombre_Bodega HAVING (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Bodegas.Cod_Bodega,Facturas.Fecha_Factura"
                Else
                    ArepDevolucionVentas.LblMoneda.Text = "Expresado en Cordobas"
                    SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, MAX(Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente) AS Nombres, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Detalle_Facturas.Importe ELSE Detalle_Facturas.Importe * TasaCambio.MontoTasa END) AS Importe, Bodegas.Cod_Bodega, Bodegas.Nombre_Bodega, MAX(Facturas.Tipo_Factura) AS Tipo_Factura FROM Detalle_Facturas INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega  " & _
                               "WHERE (Detalle_Facturas.Tipo_Factura BETWEEN '" & Me.CmbTipoDesde.Text & "' AND '" & Me.CmbTipoHasta.Text & "') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') GROUP BY Facturas.Numero_Factura, Facturas.Fecha_Factura, Bodegas.Cod_Bodega, Bodegas.Nombre_Bodega HAVING (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Bodegas.Cod_Bodega,Facturas.Fecha_Factura"
                End If


                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepDevolucionVentas.Document
                My.Application.DoEvents()
                ArepDevolucionVentas.DataSource = SQL
                ArepDevolucionVentas.Run(False)
                ViewerForm.Show()



            Case "Reporte Ventas x Categorias Resumen"
                Dim SqlString As String, Registros As Double, i As Double, oDataRow As DataRow
                Dim Cantidad As Double, Importe As Double, CostoUnitario As Double = 0, Utilidad As Double = 0, Porciento As Double = 0, Costo As Double = 0
                Dim CodBodega As String, CodigoProducto As String = "", TipoProducto As String = ""
                Dim ArepVentasCategoria As New ArepVentasCategoriaResumen, TasaCambio As Double = 0
                Dim Buscar_Fila() As DataRow, Criterios As String, Posicion As Integer, MontoAcumulado As Double = 0, CantidadAcumulada As Double = 0
                Dim DvProductos As DataView

                If Dir(RutaLogo) <> "" Then
                    ArepVentasCategoria.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepVentasCategoria.LblTitulo.Text = NombreEmpresa
                ArepVentasCategoria.LblDireccion.Text = DireccionEmpresa
                ArepVentasCategoria.LblRuc.Text = Ruc
                ArepVentasCategoria.Label1.Text = "Ventas por Categorias"
                ArepVentasCategoria.Label7.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")
                If Me.OptDolares.Checked = True Then
                    ArepVentasCategoria.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepVentasCategoria.LblMoneda.Text = "Expresado en Cordobas"
                End If


                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Productos.Cod_Productos, Detalle_Compras.Cantidad, Productos.Descripcion_Producto, Detalle_Compras.Precio_Unitario AS Importe,Productos.Descripcion_Producto AS Cod_Bodega, Detalle_Compras.Precio_Neto AS Costo, Compras.Su_Referencia AS Utilidad, Compras.Nuestra_Referencia AS Porciento, Productos.Cod_Linea, Lineas.Descripcion_Linea, Bodegas.Nombre_Bodega FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea INNER JOIN Bodegas ON Compras.Cod_Bodega = Bodegas.Cod_Bodega WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS//////////////////////////////////////
                'SqlDatos = "SELECT  Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura " & _
                '           "WHERE  (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"

                If Me.CmbAgrupado.Text = "Bodega" Then
                    If Me.CboCodigoLinea.Text = "" And Me.CboCodigoLinea2.Text = "" Then
                        SqlDatos = "SELECT Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega, Lineas.Descripcion_Linea, Lineas.Cod_Linea FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea  " & _
                                   "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                    Else
                        SqlDatos = "SELECT Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega, Lineas.Descripcion_Linea, Lineas.Cod_Linea FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea  " & _
                                    "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Lineas.Cod_Linea BETWEEN '" & Me.CboCodigoLinea.Text & "' AND '" & Me.CboCodigoLinea2.Text & "')  ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                    End If
                ElseIf Me.CmbAgrupado.Text = "Linea" Then
                    If Me.CmbRango1.Text = "" And Me.CmbRango2.Text = "" Then
                        SqlDatos = "SELECT Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.MonedaFactura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega, Lineas.Descripcion_Linea, Lineas.Cod_Linea AS Cod_Bodega,Lineas.Cod_Linea  FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea  " & _
                                   "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Lineas.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea, Detalle_Facturas.Cod_Producto"
                    Else
                        SqlDatos = "SELECT Detalle_Facturas.Costo_Unitario, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.MonedaFactura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega, Lineas.Descripcion_Linea, Lineas.Cod_Linea AS Cod_Bodega, Lineas.Cod_Linea FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea  " & _
                                  "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Lineas.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea, Detalle_Facturas.Cod_Producto"
                    End If

                    ArepVentasCategoria.GroupHeader1.Visible = False
                    ArepVentasCategoria.GroupFooter1.Visible = False
                End If
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                MontoAcumulado = 0
                CantidadAcumulada = 0
                Do While Registros > i
                    My.Application.DoEvents()
                    If DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") <> 0 Then
                        Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                        Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                        CodBodega = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                        CodigoProducto = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto")
                        CostoUnitario = 0
                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL COSTO DEL PRODUCTO PARA ESTA BODEGA //////////////////////////////////////////////////////////
                        ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        'SqlDatos = "SELECT  *  FROM DetalleBodegas WHERE (Cod_Bodegas = '" & CodBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        'DataAdapter.Fill(DataSet, "CostoBodega")
                        'If DataSet.Tables("CostoBodega").Rows.Count <> 0 Then
                        '    If Me.OptCordobas.Checked = True Then
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo")
                        '        End If
                        '    Else
                        '        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo") / TasaCambio
                        '        End If
                        '    End If
                        'End If
                        'DataSet.Tables("CostoBodega").Reset()

                        If Me.OptCordobas.Checked = True Then
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario")
                            End If
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario") / TasaCambio
                            End If
                        End If

                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL TIPO DE PRODUCTO //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT  *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "Producto")
                        If DataSet.Tables("Producto").Rows.Count <> 0 Then
                            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Tipo_Producto")) Then
                                TipoProducto = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
                            End If
                        End If
                        DataSet.Tables("Producto").Reset()

                        If TipoProducto <> "Descuento" Then
                            Costo = Cantidad * CostoUnitario
                            Utilidad = Importe - Costo
                            Porciento = Utilidad / Importe
                        Else
                            Costo = 0
                            Utilidad = 0
                            Porciento = 0
                        End If

                        If Me.OptCordobas.Checked = True Then
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        Else
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        End If

                        'Criterios = "Cod_Productos= '" & DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto") & "'"
                        Criterios = "Cod_Bodega= '" & CodBodega & "' And Cod_Linea= '" & DataSet.Tables("TotalFacturas").Rows(i)("Cod_Linea") & "'"
                        Buscar_Fila = DataSet.Tables("TotalVentas").Select(Criterios)
                        If Buscar_Fila.Length > 0 Then
                            Posicion = DataSet.Tables("TotalVentas").Rows.IndexOf(Buscar_Fila(0))
                            Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                            MontoAcumulado = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                            Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                            CantidadAcumulada = DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") + Importe * TasaCambio
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad") = Cantidad + DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Costo") = DataSet.Tables("TotalVentas").Rows(Posicion)("Costo") + Costo
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") - DataSet.Tables("TotalVentas").Rows(Posicion)("Costo")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Porciento") = DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") / DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cod_Bodega") = CodBodega
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Nombre_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Nombre_Bodega")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cod_Linea") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Linea")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Descripcion_Linea") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Linea")
                        Else
                            Utilidad = (Importe * TasaCambio) - Costo
                            Porciento = Utilidad / Costo

                            oDataRow = DataSet.Tables("TotalVentas").NewRow
                            oDataRow("Cod_Productos") = CodigoProducto
                            oDataRow("Cantidad") = Cantidad
                            oDataRow("Descripcion_Producto") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Producto")
                            oDataRow("Importe") = Importe * TasaCambio
                            oDataRow("Costo") = Costo
                            oDataRow("Utilidad") = Utilidad
                            oDataRow("Porciento") = Porciento
                            oDataRow("Cod_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                            oDataRow("Nombre_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Nombre_Bodega")
                            oDataRow("Cod_Linea") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Linea")
                            oDataRow("Descripcion_Linea") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Linea")
                            DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        End If




                    End If

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop

                Dim ViewerForm As New FrmViewer()

                DvProductos = New DataView(DataSet.Tables("TotalVentas"))
                DvProductos.Sort = "Cod_Bodega, Cod_Linea,Cod_Productos"
                ArepVentasCategoria.DataSource = DvProductos



                ViewerForm.arvMain.Document = ArepVentasCategoria.Document
                My.Application.DoEvents()
                ArepVentasCategoria.DataSource = DataSet.Tables("TotalVentas")
                ArepVentasCategoria.Run(False)
                ViewerForm.Show()

            Case "Reporte Ventas x Categorias Detalle"
                Dim SqlString As String, Registros As Double, i As Double, oDataRow As DataRow
                Dim Cantidad As Double, Importe As Double, CostoUnitario As Double = 0, Utilidad As Double = 0, Porciento As Double = 0, Costo As Double = 0
                Dim CodBodega As String, CodigoProducto As String = "", TipoProducto As String = ""
                Dim ArepVentasCategoria As New ArepVentasCategorias, TasaCambio As Double = 0
                Dim Buscar_Fila() As DataRow, Criterios As String, Posicion As Integer, MontoAcumulado As Double = 0, CantidadAcumulada As Double = 0
                Dim DvProductos As DataView

                If Dir(RutaLogo) <> "" Then
                    ArepVentasCategoria.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepVentasCategoria.LblTitulo.Text = NombreEmpresa
                ArepVentasCategoria.LblDireccion.Text = DireccionEmpresa
                ArepVentasCategoria.LblRuc.Text = Ruc
                ArepVentasCategoria.Label1.Text = "Ventas por Categorias"
                ArepVentasCategoria.Label7.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")
                If Me.OptDolares.Checked = True Then
                    ArepVentasCategoria.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepVentasCategoria.LblMoneda.Text = "Expresado en Cordobas"
                End If


                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Productos.Cod_Productos, Detalle_Compras.Cantidad, Productos.Descripcion_Producto, Detalle_Compras.Precio_Unitario AS Importe,Productos.Descripcion_Producto AS Cod_Bodega, Detalle_Compras.Precio_Neto AS Costo, Compras.Su_Referencia AS Utilidad, Compras.Nuestra_Referencia AS Porciento, Productos.Cod_Linea, Lineas.Descripcion_Linea, Bodegas.Nombre_Bodega FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea INNER JOIN Bodegas ON Compras.Cod_Bodega = Bodegas.Cod_Bodega WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS//////////////////////////////////////
                'SqlDatos = "SELECT  Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura " & _
                '           "WHERE  (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"

                If Me.CboCodigoLinea.Text = "" And Me.CboCodigoLinea2.Text = "" Then
                    SqlDatos = "SELECT Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega, Lineas.Descripcion_Linea, Lineas.Cod_Linea FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea  " & _
                               "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                Else
                    SqlDatos = "SELECT Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura, Bodegas.Nombre_Bodega, Lineas.Descripcion_Linea, Lineas.Cod_Linea FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Bodegas ON Facturas.Cod_Bodega = Bodegas.Cod_Bodega INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea  " & _
                                "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Lineas.Cod_Linea BETWEEN '" & Me.CboCodigoLinea.Text & "' AND '" & Me.CboCodigoLinea2.Text & "')  ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                End If
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Do While Registros > i
                    My.Application.DoEvents()
                    If DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") <> 0 Then
                        Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                        Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                        CodBodega = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")


                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL COSTO DEL PRODUCTO PARA ESTA BODEGA //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        'SqlDatos = "SELECT  *  FROM DetalleBodegas WHERE (Cod_Bodegas = '" & CodBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        'DataAdapter.Fill(DataSet, "CostoBodega")
                        'If DataSet.Tables("CostoBodega").Rows.Count <> 0 Then
                        '    If Me.OptCordobas.Checked = True Then
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo")
                        '        End If
                        '    Else
                        '        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo") / TasaCambio
                        '        End If
                        '    End If
                        'End If
                        'DataSet.Tables("CostoBodega").Reset()

                        If Me.OptCordobas.Checked = True Then
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario")
                            End If
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario") / TasaCambio
                            End If
                        End If

                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL TIPO DE PRODUCTO //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT  *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "Producto")
                        If DataSet.Tables("Producto").Rows.Count <> 0 Then
                            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Tipo_Producto")) Then
                                TipoProducto = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
                            End If
                        End If
                        DataSet.Tables("Producto").Reset()

                        If TipoProducto <> "Descuento" Then
                            Costo = Cantidad * CostoUnitario
                            Utilidad = Importe - Costo
                            Porciento = Utilidad / Importe
                        Else
                            Costo = 0
                            Utilidad = 0
                            Porciento = 0
                        End If

                        If Me.OptCordobas.Checked = True Then
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        Else
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        End If

                        Criterios = "Cod_Productos= '" & DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto") & "'"
                        Buscar_Fila = DataSet.Tables("TotalVentas").Select(Criterios)
                        If Buscar_Fila.Length > 0 Then
                            Posicion = DataSet.Tables("TotalVentas").Rows.IndexOf(Buscar_Fila(0))
                            Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                            MontoAcumulado = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                            Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                            CantidadAcumulada = DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") = MontoAcumulado + Importe * TasaCambio
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad") = Cantidad + CantidadAcumulada
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Costo") = (Cantidad + CantidadAcumulada) * CostoUnitario
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") - DataSet.Tables("TotalVentas").Rows(Posicion)("Costo")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Porciento") = DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") / DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cod_Bodega") = CodBodega
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Nombre_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Nombre_Bodega")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cod_Linea") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Linea")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Descripcion_Linea") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Linea")
                        Else
                            Utilidad = (Importe * TasaCambio) - Costo
                            Porciento = Utilidad / Costo

                            oDataRow = DataSet.Tables("TotalVentas").NewRow
                            oDataRow("Cod_Productos") = CodigoProducto
                            oDataRow("Cantidad") = Cantidad
                            oDataRow("Descripcion_Producto") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Producto")
                            oDataRow("Importe") = Importe * TasaCambio
                            oDataRow("Costo") = Costo
                            oDataRow("Utilidad") = Utilidad
                            oDataRow("Porciento") = Porciento
                            oDataRow("Cod_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                            oDataRow("Nombre_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Nombre_Bodega")
                            oDataRow("Cod_Linea") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Linea")
                            oDataRow("Cod_Linea") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Linea")
                            DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        End If




                    End If

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop

                Dim ViewerForm As New FrmViewer()

                DvProductos = New DataView(DataSet.Tables("TotalVentas"))
                DvProductos.Sort = "Cod_Bodega, Cod_Linea,Cod_Productos"
                ArepVentasCategoria.DataSource = DvProductos

                ViewerForm.arvMain.Document = ArepVentasCategoria.Document
                My.Application.DoEvents()
                ArepVentasCategoria.DataSource = DataSet.Tables("TotalVentas")
                ArepVentasCategoria.Run(False)
                ViewerForm.Show()

            Case "Listado de Recibos de Caja"
                Dim SqlString As String
                Dim ArepListaRecibos As New ArepListaRecibos


                If Dir(RutaLogo) <> "" Then
                    ArepListaRecibos.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepListaRecibos.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepListaRecibos.LblTitulo.Text = NombreEmpresa
                ArepListaRecibos.LblDireccion.Text = DireccionEmpresa
                ArepListaRecibos.LblRango.Text = "Impreso: Desde " & Format(Fecha1, "dd/MM/yyyy") & " Hasta " & Format(Fecha2, "dd/MM/yyyy")

                If Me.OptDolares.Checked = True Then
                    ArepListaRecibos.LblMoneda.Text = "Expresado en Dolares"
                    SqlString = "SELECT Recibo.CodReciboPago, Recibo.Fecha_Recibo, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombres, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, Recibo.MonedaRecibo, TasaCambio.MontoTasa, CASE WHEN MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado / TasaCambio.MontoTasa ELSE DetalleRecibo.MontoPagado END AS MontoRecibo,Recibo.Activo FROM Recibo INNER JOIN Clientes ON Recibo.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN DetalleRecibo ON Recibo.CodReciboPago = DetalleRecibo.CodReciboPago AND Recibo.Fecha_Recibo = DetalleRecibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa  " & _
                                "WHERE (Recibo.Fecha_Recibo BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Recibo.Fecha_Recibo"
                Else
                    ArepListaRecibos.LblMoneda.Text = "Expresado en Cordobas"
                    SqlString = "SELECT Recibo.CodReciboPago, Recibo.Fecha_Recibo, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombres, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, Recibo.MonedaRecibo, TasaCambio.MontoTasa, CASE WHEN MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado * TasaCambio.MontoTasa ELSE DetalleRecibo.MontoPagado END AS MontoRecibo,Recibo.Activo FROM Recibo INNER JOIN Clientes ON Recibo.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN DetalleRecibo ON Recibo.CodReciboPago = DetalleRecibo.CodReciboPago AND Recibo.Fecha_Recibo = DetalleRecibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa  " & _
                                "WHERE (Recibo.Fecha_Recibo BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Recibo.Fecha_Recibo"
                End If

                SQL.ConnectionString = Conexion
                SQL.SQL = SqlString

                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepListaRecibos.Document
                My.Application.DoEvents()
                ArepListaRecibos.DataSource = SQL
                ArepListaRecibos.Run(False)
                ViewerForm.Show()

            Case "Reporte de Ventas x Clientes"
                Dim SqlString As String, Registros As Double
                Dim CostoUnitario As Double = 0, Utilidad As Double = 0, Porciento As Double = 0, Costo As Double = 0
                Dim CodigoProducto As String = "", TipoProducto As String = ""
                Dim ArepVentasClientes As New ArepVentasClientes, i As Double
                Dim oDataRow As DataRow, TasaCambio As Double

                If Dir(RutaLogo) <> "" Then
                    ArepVentasClientes.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepVentasClientes.LblTitulo.Text = NombreEmpresa
                ArepVentasClientes.LblDireccion.Text = DireccionEmpresa
                ArepVentasClientes.LblRuc.Text = Ruc
                ArepVentasClientes.Label1.Text = "Ventas de Clientes"
                ArepVentasClientes.Label7.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")
                If Me.OptDolares.Checked = True Then
                    ArepVentasClientes.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepVentasClientes.LblMoneda.Text = "Expresado en Cordobas"
                End If

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                'SqlString = "SELECT Productos.Cod_Productos,Detalle_Compras.Cantidad, Productos.Descripcion_Producto,Detalle_Compras.Precio_Unitario As Importe, Detalle_Compras.Descuento As Cod_Bodega, Detalle_Compras.Precio_Neto As Costo, Compras.Su_Referencia As Utilidad, Compras.Nuestra_Referencia As Porciento FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                SqlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nomibres, Facturas.SubTotal, Facturas.IVA, Facturas.Descuento, Facturas.MetodoPago, Facturas.SubTotal + Facturas.IVA AS Total FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                            "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")


                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS DE CONTADO//////////////////////////////////////
                SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Nomibres, Facturas.SubTotal, Facturas.IVA, Facturas.Descuento, Facturas.MetodoPago, Facturas.SubTotal + Facturas.IVA AS Total,Facturas.MonedaFactura FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                           "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Do While Registros > i
                    My.Application.DoEvents()

                    If Me.OptCordobas.Checked = True Then
                        If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                            TasaCambio = 1
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        End If
                    Else
                        If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                            TasaCambio = 1
                        Else
                            TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        End If
                    End If

                    oDataRow = DataSet.Tables("TotalVentas").NewRow
                    oDataRow("Fecha_Factura") = DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura")
                    oDataRow("Numero_Factura") = DataSet.Tables("TotalFacturas").Rows(i)("Numero_Factura")
                    oDataRow("Nomibres") = DataSet.Tables("TotalFacturas").Rows(i)("Nomibres")
                    oDataRow("SubTotal") = DataSet.Tables("TotalFacturas").Rows(i)("SubTotal") * TasaCambio
                    oDataRow("IVA") = DataSet.Tables("TotalFacturas").Rows(i)("IVA") * TasaCambio
                    oDataRow("MetodoPago") = DataSet.Tables("TotalFacturas").Rows(i)("MetodoPago")
                    oDataRow("Total") = DataSet.Tables("TotalFacturas").Rows(i)("Total") * TasaCambio
                    DataSet.Tables("TotalVentas").Rows.Add(oDataRow)

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop




                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepVentasClientes.Document
                My.Application.DoEvents()
                'ArepVentasClientes.DataSource = SQL
                ArepVentasClientes.DataSource = DataSet.Tables("TotalVentas")
                ArepVentasClientes.Run(False)
                ViewerForm.Show()

            Case "Reporte de Ventas x Productos"
                Dim SqlString As String, Registros As Double, i As Double, oDataRow As DataRow
                Dim Cantidad As Double, Importe As Double, CostoUnitario As Double = 0, Utilidad As Double = 0, Porciento As Double = 0, Costo As Double = 0
                Dim CodBodega As String, CodigoProducto As String = "", TipoProducto As String = ""
                Dim ArepVentas As New ArepVentasProductos, TasaCambio As Double = 0
                Dim Buscar_Fila() As DataRow, Criterios As String, Posicion As Integer, MontoAcumulado As Double = 0, CantidadAcumulada As Double = 0

                If Dir(RutaLogo) <> "" Then
                    ArepVentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepVentas.LblTitulo.Text = NombreEmpresa
                ArepVentas.LblDireccion.Text = DireccionEmpresa
                ArepVentas.LblRuc.Text = Ruc
                ArepVentas.Label1.Text = "Ventas de Productos al Credito"
                ArepVentas.Label7.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")
                If Me.OptDolares.Checked = True Then
                    ArepVentas.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepVentas.LblMoneda.Text = "Expresado en Cordobas"
                End If


                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Productos.Cod_Productos,Detalle_Compras.Cantidad, Productos.Descripcion_Producto,Detalle_Compras.Precio_Unitario As Importe, Productos.Descripcion_Producto As Cod_Bodega, Detalle_Compras.Precio_Neto As Costo, Compras.Su_Referencia As Utilidad, Compras.Nuestra_Referencia As Porciento FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS DE CONTADO//////////////////////////////////////
                'SqlDatos = "SELECT Detalle_Facturas.Cod_Producto, MAX(Detalle_Facturas.Descripcion_Producto) AS Descripcion_Producto, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Importe) AS Importe, Facturas.Cod_Bodega,Facturas.MonedaFactura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura  " & _
                '           "WHERE (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME,'" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') GROUP BY Detalle_Facturas.Cod_Producto, Facturas.Cod_Bodega HAVING  (MAX(Detalle_Facturas.Descripcion_Producto) <> '-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                SqlDatos = "SELECT  Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura " & _
                           "WHERE  (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Do While Registros > i
                    My.Application.DoEvents()
                    If DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") <> 0 Then
                        Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                        Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                        CodBodega = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                        CodigoProducto = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto")
                        CostoUnitario = 0
                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL COSTO DEL PRODUCTO PARA ESTA BODEGA //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        'SqlDatos = "SELECT  *  FROM DetalleBodegas WHERE (Cod_Bodegas = '" & CodBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        'DataAdapter.Fill(DataSet, "CostoBodega")
                        'If DataSet.Tables("CostoBodega").Rows.Count <> 0 Then
                        '    If Me.OptCordobas.Checked = True Then
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo")
                        '        End If
                        '    Else
                        '        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo") / TasaCambio
                        '        End If
                        '    End If
                        'End If
                        'DataSet.Tables("CostoBodega").Reset()

                        If Me.OptCordobas.Checked = True Then
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario")
                            End If
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario") / TasaCambio
                            End If
                        End If


                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL TIPO DE PRODUCTO //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT  *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "Producto")
                        If DataSet.Tables("Producto").Rows.Count <> 0 Then
                            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Tipo_Producto")) Then
                                TipoProducto = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
                            End If
                        End If
                        DataSet.Tables("Producto").Reset()

                        If TipoProducto <> "Descuento" Then
                            Costo = Cantidad * CostoUnitario
                            Utilidad = Importe - Costo
                            Porciento = Utilidad / Importe
                        Else
                            Costo = 0
                            Utilidad = 0
                            Porciento = 0
                        End If

                        If Me.OptCordobas.Checked = True Then
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        Else
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        End If

                        Criterios = "Cod_Productos= '" & DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto") & "'"
                        Buscar_Fila = DataSet.Tables("TotalVentas").Select(Criterios)
                        If Buscar_Fila.Length > 0 Then
                            Posicion = DataSet.Tables("TotalVentas").Rows.IndexOf(Buscar_Fila(0))
                            Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                            MontoAcumulado = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                            Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                            CantidadAcumulada = DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") = MontoAcumulado + Importe * TasaCambio
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad") = Cantidad + CantidadAcumulada
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Costo") = (Cantidad + CantidadAcumulada) * CostoUnitario
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") - DataSet.Tables("TotalVentas").Rows(Posicion)("Costo")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Porciento") = DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") / DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                        Else
                            Utilidad = (Importe * TasaCambio) - Costo
                            Porciento = Utilidad / Costo

                            oDataRow = DataSet.Tables("TotalVentas").NewRow
                            oDataRow("Cod_Productos") = CodigoProducto
                            oDataRow("Cantidad") = Cantidad
                            oDataRow("Descripcion_Producto") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Producto")
                            oDataRow("Importe") = Importe * TasaCambio
                            oDataRow("Costo") = Costo
                            oDataRow("Utilidad") = Utilidad
                            oDataRow("Porciento") = Porciento
                            oDataRow("Cod_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                            DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        End If




                    End If

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop

                Dim ViewerForm As New FrmViewer()

                ViewerForm.arvMain.Document = ArepVentas.Document
                My.Application.DoEvents()
                ArepVentas.DataSource = DataSet.Tables("TotalVentas")
                ArepVentas.Run(False)
                ViewerForm.Show()





            Case "Reporte de Notas Debito/Credito"
                Dim ArepNotasDebitoCredito As New ArepNotasDebitoCredito


                If Dir(RutaLogo) <> "" Then
                    ArepNotasDebitoCredito.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepNotasDebitoCredito.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepNotasDebitoCredito.LblTitulo.Text = NombreEmpresa
                ArepNotasDebitoCredito.LblDireccion.Text = DireccionEmpresa
                ArepNotasDebitoCredito.LblRango.Text = "Impreso: Desde " & Format(Fecha1, "dd/MM/yyyy") & " Hasta " & Format(Fecha2, "dd/MM/yyyy")

                If Me.CmbNotas.Text = "" And Me.CmbNotas2.Text = "" Then
                    SqlDatos = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombres FROM Detalle_Nota INNER JOIN Facturas ON Detalle_Nota.Numero_Factura = Facturas.Numero_Factura INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE  (Detalle_Nota.Fecha_Nota BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Nota.Tipo_Nota, Detalle_Nota.Fecha_Nota DESC"
                Else
                    SqlDatos = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombres FROM Detalle_Nota INNER JOIN Facturas ON Detalle_Nota.Numero_Factura = Facturas.Numero_Factura INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE  (Detalle_Nota.Fecha_Nota BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Nota.Tipo_Nota BETWEEN '" & Me.CmbNotas.Text & "' AND '" & Me.CmbNotas2.Text & "') ORDER BY Detalle_Nota.Tipo_Nota, Detalle_Nota.Fecha_Nota DESC"
                End If
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepNotasDebitoCredito.Document
                My.Application.DoEvents()
                ArepNotasDebitoCredito.DataSource = SQL
                ArepNotasDebitoCredito.Run(False)
                ViewerForm.Show()


            Case "Reporte de Utilidad por Factura"
                Dim ArepUtilidadVentas As New ArepUtilidadVentas
                Dim SQLString As String, Registro As Double = 0, Iposicion As Double = 0
                Dim FechaFin As String
                Dim Existencia As Double, NumeroFactura As String, Total As Double = 0
                Dim oDataRow As DataRow, CtoFactura As Double, Utilidad As String, Porciento As Double
                Dim DvProductos As DataView

                If Dir(RutaLogo) <> "" Then
                    ArepUtilidadVentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepUtilidadVentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepUtilidadVentas.LblTitulo.Text = NombreEmpresa
                ArepUtilidadVentas.LblDireccion.Text = DireccionEmpresa
                ArepUtilidadVentas.LblRuc.Text = Ruc
                ArepUtilidadVentas.LblImpreso.Text = "Impreso: Desde " & Format(Fecha1, "dd/MM/yyyy") & " Hasta " & Format(Fecha2, "dd/MM/yyyy")

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQLString = "SELECT  Facturas.Numero_Factura, Facturas.Tipo_Factura AS Costo, Facturas.Nombre_Cliente, Vendedores.Nombre_Vendedor,CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa END AS Importe, Facturas.NetoPagar AS Utilidad, Facturas.NetoPagar AS PorcientoUtilidad FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor WHERE (CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN (Facturas.SubTotal) * TasaCambio.MontoTasa END <> 0) AND (Facturas.Tipo_Factura = N'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '2014-01-11 00:00:00', 102) AND CONVERT(DATETIME, '2014-11-30 00:00:00', 102)) AND (Facturas.Numero_Factura = N'-10000') ORDER BY Facturas.Numero_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
                DataAdapter.Fill(DataSet, "Utilidad")

                If Me.OptCordobas.Checked = True Then
                    SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Tipo_Factura AS Costo, Facturas.Nombre_Cliente, Vendedores.Nombre_Vendedor, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS Importe, Facturas.NetoPagar AS Utilidad, Facturas.NetoPagar AS PorcientoUtilidad,Facturas.Fecha_Factura FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN  Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor WHERE  (Facturas.Tipo_Factura = N'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Nombre_Vendedor,Facturas.Numero_Factura"
                Else
                    SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Tipo_Factura AS Costo, Facturas.Nombre_Cliente, Vendedores.Nombre_Vendedor, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal / TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS Importe, Facturas.NetoPagar AS Utilidad, Facturas.NetoPagar AS PorcientoUtilidad,Facturas.Fecha_Factura FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN  Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor WHERE (Facturas.Tipo_Factura = N'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Nombre_Vendedor,Facturas.Numero_Factura"
                End If

                '*****************************************************************************************************************************************
                '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
                '*****************************************************************************************************************************************
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                Iposicion = 0
                Existencia = 0
                Do While Iposicion < Registro
                    'FechaIni = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
                    'Fecha = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                    FechaFin = DataSet.Tables("Productos").Rows(Iposicion)("Fecha_Factura")
                    NumeroFactura = DataSet.Tables("Productos").Rows(Iposicion)("Numero_Factura")
                    If Me.OptCordobas.Checked = True Then
                        CtoFactura = CostoFactura(NumeroFactura, FechaFin, "Cordobas")
                    Else
                        CtoFactura = CostoFactura(NumeroFactura, FechaFin, "Dolares")
                    End If
                    Utilidad = DataSet.Tables("Productos").Rows(Iposicion)("Importe") - CtoFactura
                    If Val(DataSet.Tables("Productos").Rows(Iposicion)("Importe")) <> 0 Then
                        Porciento = Utilidad / DataSet.Tables("Productos").Rows(Iposicion)("Importe")
                    Else
                        Porciento = 0
                    End If

                    oDataRow = DataSet.Tables("Utilidad").NewRow
                    oDataRow("Numero_Factura") = DataSet.Tables("Productos").Rows(Iposicion)("Numero_Factura")
                    oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(Iposicion)("Nombre_Cliente")
                    oDataRow("Nombre_Vendedor") = DataSet.Tables("Productos").Rows(Iposicion)("Nombre_Vendedor")
                    oDataRow("Importe") = DataSet.Tables("Productos").Rows(Iposicion)("Importe")
                    oDataRow("Costo") = CtoFactura
                    oDataRow("Utilidad") = Utilidad
                    oDataRow("PorcientoUtilidad") = Porciento
                    DataSet.Tables("Utilidad").Rows.Add(oDataRow)


                    Me.Text = "Procesando: " & NumeroFactura

                    If Me.ProgressBar.Maximum <> 0 Then
                        Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    End If

                    My.Application.DoEvents()
                    Iposicion = Iposicion + 1

                Loop

                DvProductos = New DataView(DataSet.Tables("Utilidad"))
                DvProductos.Sort = "Nombre_Vendedor,Numero_Factura DESC"

                ArepUtilidadVentas.DataSource = DvProductos
                'ArepUtilidadVentas.Document.Name = "Reporte de Productos com mas Inventarios"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepUtilidadVentas.Document
                My.Application.DoEvents()
                ArepUtilidadVentas.Run(False)
                ViewerForm.Show()

            Case "Reporte Rotacion de Inventario"
                Dim ArepRotacionInventario As New ArepRotacionInventario
                Dim SQLString As String, Registro As Double = 0, Iposicion As Double = 0
                Dim CodProducto As String, FechaIni As String, FechaFin As String
                Dim Existencia As Double, CodBodega As String, Total As Double = 0
                Dim oDataRow As DataRow, NombreProducto As String, NombreBodega As String
                Dim Fecha As Date, CostoPromedio As Double, Rotacion As Double, Indice As Double
                Dim DvProductos As DataView

                If Dir(RutaLogo) <> "" Then
                    ArepRotacionInventario.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepRotacionInventario.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepRotacionInventario.LblTitulo.Text = NombreEmpresa
                ArepRotacionInventario.LblDireccion.Text = DireccionEmpresa
                ArepRotacionInventario.LblRuc.Text = Ruc

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQLString = "SELECT Cod_Productos As Cod_Producto, Descripcion_Producto, Unidad_Medida, Minimo, Existencia_Unidades AS Cantidad, Existencia_DineroDolar AS Costo, Existencia_DineroDolar AS Rotacion, Existencia_DineroDolar AS Indice FROM Productos WHERE (Activo = Activo) AND (Tipo_Producto <> N'Descuento') AND (Cod_Productos = N'-100000') ORDER BY Cantidad DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
                DataAdapter.Fill(DataSet, "Rotacion")

                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Productos"

                '*****************************************************************************************************************************************
                '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
                '*****************************************************************************************************************************************
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                Iposicion = 0
                Existencia = 0
                Do While Iposicion < Registro
                    FechaIni = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
                    Fecha = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                    FechaFin = Format(Fecha.AddDays(1), "yyyy-MM-dd")
                    CodProducto = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Productos")
                    NombreProducto = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Producto")
                    NombreBodega = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Linea")
                    CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")
                    'Existencia = ExistenciaProductoFecha(CodProducto, FechaFin)
                    Existencia = Format(BuscaInventarioInicial(CodProducto, FechaFin))
                    CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)

                    'If CodProducto = "102-08-119" Then
                    '    CodProducto = "102-08-119"
                    'End If
                    If Existencia <> 0 Then
                        If DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Descuento" And DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Servicio" Then
                            oDataRow = DataSet.Tables("Rotacion").NewRow
                            oDataRow("Cod_Producto") = CodProducto
                            oDataRow("Descripcion_Producto") = NombreProducto
                            oDataRow("Unidad_Medida") = DataSet.Tables("Productos").Rows(Iposicion)("Unidad_Medida")
                            oDataRow("Minimo") = DataSet.Tables("Productos").Rows(Iposicion)("Minimo")
                            oDataRow("Cantidad") = Existencia
                            If Me.OptCordobas.Checked = True Then
                                oDataRow("Costo") = Existencia * CostoPromedio
                                Rotacion = Format(CostoPromedio / Existencia, "##,##0.0000")
                            Else
                                oDataRow("Costo") = Existencia * CostoPromedioDolar
                                Rotacion = Format(CostoPromedioDolar / Existencia, "##,##0.0000")
                            End If

                            If Rotacion <> 0 Then
                                oDataRow("Rotacion") = Rotacion
                                oDataRow("Indice") = 360 / Rotacion
                            Else
                                Indice = 0
                            End If


                            DataSet.Tables("Rotacion").Rows.Add(oDataRow)

                        End If
                    End If


                    Me.Text = "Procesando: " & CodProducto

                    If Me.ProgressBar.Maximum <> 0 Then
                        Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    End If

                    My.Application.DoEvents()
                    Iposicion = Iposicion + 1

                Loop

                'DvProductos = New DataView(DataSet.Tables("BajoMinimo"), "Descripcion_Producto like '%'", "Cantidad DESC", DataViewRowState.OriginalRows)
                DvProductos = New DataView(DataSet.Tables("Rotacion"))
                DvProductos.Sort = "Costo DESC"

                ArepRotacionInventario.DataSource = DvProductos
                ArepRotacionInventario.Document.Name = "Reporte de Productos com mas Inventarios"
                ArepRotacionInventario.Label1.Text = "Reporte de Productos com mas Inventarios"
                ArepRotacionInventario.Label14.Text = "Existencia"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepRotacionInventario.Document
                My.Application.DoEvents()
                ArepRotacionInventario.Run(False)
                ViewerForm.Show()
            Case "Reporte de Productos mas Inventarios"
                Dim ArepProductosMasInventarios As New ArepProductosVendidos
                Dim SQLString As String, Registro As Double = 0, Iposicion As Double = 0
                Dim CodProducto As String, FechaIni As String, FechaFin As String
                Dim Existencia As Double, CodBodega As String, Total As Double = 0
                Dim oDataRow As DataRow, NombreProducto As String, NombreBodega As String
                Dim Fecha As Date, CostoPromedio As Double
                Dim DvProductos As DataView

                If Dir(RutaLogo) <> "" Then
                    ArepProductosMasInventarios.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepProductosMasInventarios.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepProductosMasInventarios.LblTitulo.Text = NombreEmpresa
                ArepProductosMasInventarios.LblDireccion.Text = DireccionEmpresa
                ArepProductosMasInventarios.LblRuc.Text = Ruc

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQLString = "SELECT Cod_Productos As Cod_Producto, Descripcion_Producto, Unidad_Medida, Minimo, Existencia_Unidades AS Cantidad, Existencia_DineroDolar AS Costo FROM Productos WHERE (Activo = Activo) AND (Tipo_Producto <> N'Descuento') AND (Cod_Productos = N'-100000') ORDER BY Cantidad DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
                DataAdapter.Fill(DataSet, "BajoMinimo")

                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Productos"

                '*****************************************************************************************************************************************
                '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
                '*****************************************************************************************************************************************
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                Iposicion = 0
                Existencia = 0
                Do While Iposicion < Registro
                    FechaIni = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
                    Fecha = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                    FechaFin = Format(Fecha.AddDays(1), "yyyy-MM-dd")
                    CodProducto = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Productos")
                    NombreProducto = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Producto")
                    NombreBodega = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Linea")
                    CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")
                    'Existencia = ExistenciaProductoFecha(CodProducto, FechaFin)
                    Existencia = Format(BuscaInventarioInicial(CodProducto, FechaFin))
                    CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)
                    If Existencia <> 0 Then
                        If DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Descuento" And DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Servicio" Then
                            oDataRow = DataSet.Tables("BajoMinimo").NewRow
                            oDataRow("Cod_Producto") = CodProducto
                            oDataRow("Descripcion_Producto") = NombreProducto
                            oDataRow("Unidad_Medida") = DataSet.Tables("Productos").Rows(Iposicion)("Unidad_Medida")
                            oDataRow("Minimo") = DataSet.Tables("Productos").Rows(Iposicion)("Minimo")
                            oDataRow("Cantidad") = Existencia
                            If Me.OptCordobas.Checked = True Then
                                oDataRow("Costo") = Existencia * CostoPromedio
                            Else
                                oDataRow("Costo") = Existencia * CostoPromedioDolar
                            End If
                            DataSet.Tables("BajoMinimo").Rows.Add(oDataRow)

                        End If
                    End If


                    Me.Text = "Procesando: " & CodProducto

                    If Me.ProgressBar.Maximum <> 0 Then
                        Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    End If

                    My.Application.DoEvents()
                    Iposicion = Iposicion + 1

                Loop

                'DvProductos = New DataView(DataSet.Tables("BajoMinimo"), "Descripcion_Producto like '%'", "Cantidad DESC", DataViewRowState.OriginalRows)
                DvProductos = New DataView(DataSet.Tables("BajoMinimo"))
                DvProductos.Sort = "Costo DESC"

                ArepProductosMasInventarios.DataSource = DvProductos
                ArepProductosMasInventarios.Document.Name = "Reporte de Productos com mas Inventarios"
                ArepProductosMasInventarios.LblReporte.Text = "Reporte de Productos com mas Inventarios"
                ArepProductosMasInventarios.Label14.Text = "Existencia"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepProductosMasInventarios.Document
                My.Application.DoEvents()
                ArepProductosMasInventarios.Run(False)
                ViewerForm.Show()

            Case "Reporte de Productos mas Vendidos"
                Dim ArepProductosMasVendidos As New ArepProductosVendidos
                ArepProductosMasVendidos.LblTitulo.Text = NombreEmpresa
                ArepProductosMasVendidos.LblDireccion.Text = DireccionEmpresa
                ArepProductosMasVendidos.LblRuc.Text = Ruc
                ArepProductosMasVendidos.LblRango.Text = "DESDE: " & Format(Fecha1, "dd/MM/yyyy") & "       HASTA: " & Format(Fecha2, "dd/MM/yyyy")
                If Dir(RutaLogo) <> "" Then
                    ArepProductosMasVendidos.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                SqlDatos = "SELECT  Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Importe) AS Importe FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND  Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Facturas.Tipo_Factura, Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto HAVING (Facturas.Tipo_Factura = 'Factura') ORDER BY Cantidad DESC"

                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos
                ArepProductosMasVendidos.DataSource = SQL
                ArepProductosMasVendidos.Document.Name = "Reporte de Productos mas Vendidos"
                ArepProductosMasVendidos.LblReporte.Text = "Reporte de Productos mas Vendidos"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepProductosMasVendidos.Document
                My.Application.DoEvents()
                ArepProductosMasVendidos.Run(False)
                ViewerForm.Show()

            Case "Reporte Grafico x Clientes"
                Dim ArepReporteVentasClientes As New ArepGraficoVentasClientes

                ArepReporteVentasClientes.LblTitulo.Text = NombreEmpresa
                ArepReporteVentasClientes.LblDireccion.Text = DireccionEmpresa
                ArepReporteVentasClientes.LblRuc.Text = Ruc
                ArepReporteVentasClientes.LblRango.Text = "DESDE: " & Format(Fecha1, "dd/MM/yyyy") & "       HASTA: " & Format(Fecha2, "dd/MM/yyyy")
                'SQlDatosSuma = "SELECT MAX(Vendedores.Cod_Vendedor) AS Expr1, MAX(Vendedores.Nombre_Vendedor + N' ' + Vendedores.Apellido_Vendedor) AS NombreVendedor, SUM(Facturas.SubTotal) AS MontoVendido FROM  Vendedores INNER JOIN Facturas ON Vendedores.Cod_Vendedor = Facturas.Cod_Vendedor "
                If Me.OptDolares.Checked = True Then
                    SQlDatosSuma = "SELECT SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal ELSE Facturas.SubTotal/TasaCambio.MontoTasa END) AS MontoVendido,MAX(Clientes.Cod_Cliente) AS Cod_Cliente, MAX(Clientes.Nombre_Cliente) AS Nombre_Cliente FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY MontoVendido DESC"

                    SqlDatos = "SELECT SUM(CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal ELSE Facturas.SubTotal/TasaCambio.MontoTasa END) AS MontoVendido, Clientes.Cod_Cliente, Clientes.Nombre_Cliente FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente " & _
                             "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Clientes.Cod_Cliente, Clientes.Nombre_Cliente ORDER BY MontoVendido DESC"
                    ArepReporteVentasClientes.LblMoneda.Text = "Expresado en Dolares"
                Else
                    SQlDatosSuma = "SELECT SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal ELSE Facturas.SubTotal * TasaCambio.MontoTasa END) AS MontoVendido,MAX(Clientes.Cod_Cliente) AS Cod_Cliente, MAX(Clientes.Nombre_Cliente) AS Nombre_Cliente FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY MontoVendido DESC"

                    SqlDatos = "SELECT SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal ELSE Facturas.SubTotal * TasaCambio.MontoTasa END) AS MontoVendido, Clientes.Cod_Cliente, Clientes.Nombre_Cliente FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente " & _
                               "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Clientes.Cod_Cliente, Clientes.Nombre_Cliente ORDER BY MontoVendido DESC"
                    ArepReporteVentasClientes.LblMoneda.Text = "Expresado en Cordobas"
                End If
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos


                ArepReporteVentasClientes.ChartControl1.DataSource = SQL
                ArepReporteVentasClientes.DataSource = SQL

                DataAdapter = New SqlClient.SqlDataAdapter(SQlDatosSuma, MiConexion)
                DataAdapter.Fill(DataSet, "VentasTotales")
                If Not DataSet.Tables("VentasTotales").Rows.Count = 0 Then
                    If Not IsDBNull(DataSet.Tables("VentasTotales").Rows(0)("MontoVendido")) Then
                        ArepReporteVentasClientes.VentasTotales = DataSet.Tables("VentasTotales").Rows(0)("MontoVendido")
                    Else
                        MsgBox("No existen Registros", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                        Exit Select
                        ArepReporteVentasClientes.VentasTotales = 0
                    End If
                Else
                    ArepReporteVentasClientes.VentasTotales = 0
                End If


                ArepReporteVentasClientes.Document.Name = "Reporte de Ventas x Clientes"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepReporteVentasClientes.Document
                My.Application.DoEvents()
                ArepReporteVentasClientes.Run(False)
                ViewerForm.Show()

            Case "Productos Bajo Minimo"
                Dim ArepProductosBajoMinimo As New ArepProductosBajoMinimo
                Dim SQLString As String, Registro As Double = 0, Iposicion As Double = 0
                Dim CodProducto As String, FechaIni As String, FechaFin As String
                Dim Existencia As Double, CodBodega As String, Total As Double = 0
                Dim oDataRow As DataRow, NombreProducto As String, NombreBodega As String
                Dim Fecha As Date

                If Dir(RutaLogo) <> "" Then
                    ArepProductosBajoMinimo.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepProductosBajoMinimo.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepProductosBajoMinimo.LblTitulo.Text = NombreEmpresa
                ArepProductosBajoMinimo.LblDireccion.Text = DireccionEmpresa
                ArepProductosBajoMinimo.LblRuc.Text = Ruc

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQLString = "SELECT Cod_Productos, Descripcion_Producto, Unidad_Medida, Minimo, Existencia_Unidades AS Existencia, Existencia_DineroDolar AS Diferencia FROM Productos WHERE (Activo = Activo) AND (Tipo_Producto <> N'Descuento') AND (Cod_Productos = N'-100000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
                DataAdapter.Fill(DataSet, "BajoMinimo")

                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Productos"
                'Select Case Me.CmbAgrupado.Text
                '    Case "Codigo Producto"
                '        If Me.CboCodigoProducto.Text = "" Then
                '            If Me.CboCodigoProducto2.Text = "" Then
                '                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Productos"
                '            Else
                '                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & CodigoInicio & "' AND '" & Me.CboCodigoProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                '            End If
                '        ElseIf Me.CboCodigoProducto2.Text = "" Then
                '            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodigoProducto.Text & "' AND '" & CodigoFin & "') ORDER BY Productos.Cod_Productos"
                '        Else
                '            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodigoProducto.Text & "' AND '" & Me.CboCodigoProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                '        End If

                '    Case "Linea"
                '        If Me.CmbRango1.Text = "" Then
                '            If Me.CmbRango2.Text = "" Then
                '                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Linea"
                '            Else
                '                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                '            End If

                '        ElseIf Me.CmbRango2.Text = "" Then
                '            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Linea"
                '        Else
                '            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                '        End If


                '    Case "Bodega"
                '        If Me.CboCodigoProducto.Text = "" And Me.CboCodigoProducto2.Text = "" Then
                '            If Me.CmbRango1.Text = "" Then
                '                If Me.CmbRango2.Text = "" Then
                '                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                '                Else
                '                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                '                End If
                '            ElseIf Me.CmbRango2.Text = "" Then
                '                If Me.CmbRango1.Text = "" Then
                '                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                '                Else
                '                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                '                End If
                '            Else
                '                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                '            End If
                '        Else

                '            Cadena = "WHERE (Productos.Cod_Productos BETWEEN '" & Me.CboCodigoProducto.Text & "' AND '" & Me.CboCodigoProducto2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                '            If Me.CmbRango1.Text = "" Then
                '                If Me.CmbRango2.Text = "" Then
                '                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  " & Cadena
                '                Else
                '                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                '                End If
                '            ElseIf Me.CmbRango2.Text = "" Then
                '                If Me.CmbRango1.Text = "" Then
                '                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                '                Else
                '                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                '                End If
                '            Else
                '                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                '            End If
                '        End If

                '    Case "Rubro"
                '        If Me.CmbRango1.Text = "" Then
                '            If Me.CmbRango2.Text = "" Then
                '                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                '                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                '            Else
                '                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                '                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"

                '            End If

                '        ElseIf Me.CmbRango2.Text = "" Then
                '            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                '                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                '        Else
                '            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                '                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"
                '        End If



                'End Select

                '*****************************************************************************************************************************************
                '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
                '*****************************************************************************************************************************************
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                Iposicion = 0
                Existencia = 0
                Do While Iposicion < Registro
                    FechaIni = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
                    Fecha = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                    FechaFin = Format(Fecha.AddDays(1), "yyyy-MM-dd")
                    CodProducto = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Productos")
                    NombreProducto = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Producto")
                    NombreBodega = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Linea")
                    CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")
                    'Existencia = ExistenciaProductoFecha(CodProducto, FechaFin)
                    Existencia = Format(BuscaInventarioInicial(CodProducto, FechaFin))
                    If Existencia <> 0 Then
                        If DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Descuento" And DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Servicio" Then
                            If DataSet.Tables("Productos").Rows(Iposicion)("Minimo") >= Existencia Then
                                oDataRow = DataSet.Tables("BajoMinimo").NewRow
                                oDataRow("Cod_Productos") = CodProducto
                                oDataRow("Descripcion_Producto") = NombreProducto
                                oDataRow("Unidad_Medida") = DataSet.Tables("Productos").Rows(Iposicion)("Unidad_Medida")
                                oDataRow("Minimo") = DataSet.Tables("Productos").Rows(Iposicion)("Minimo")
                                oDataRow("Existencia") = Existencia
                                oDataRow("Diferencia") = Existencia - DataSet.Tables("Productos").Rows(Iposicion)("Minimo")
                                DataSet.Tables("BajoMinimo").Rows.Add(oDataRow)
                            End If
                        End If
                    End If





                    Me.Text = "Procesando: " & CodProducto

                    If Me.ProgressBar.Maximum <> 0 Then
                        Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    End If

                    My.Application.DoEvents()
                    Iposicion = Iposicion + 1

                Loop

                ArepProductosBajoMinimo.Label7.Text = "Impreso: " & Format(Now, "Long Date")
                ArepProductosBajoMinimo.DataSource = DataSet.Tables("BajoMinimo")
                ArepProductosBajoMinimo.LblTitulo.Text = NombreEmpresa
                ArepProductosBajoMinimo.LblDireccion.Text = DireccionEmpresa
                ArepProductosBajoMinimo.LblRuc.Text = Ruc
                ArepProductosBajoMinimo.DataSource = SQL
                ArepProductosBajoMinimo.Document.Name = "PRODUCTOS BAJO MINIMO"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepProductosBajoMinimo.Document
                My.Application.DoEvents()
                ArepProductosBajoMinimo.Run(False)
                ViewerForm.Show()


            Case "Reporte Grafico x Proveedor"
                Dim ArepReporteProveedores As New ArepProveedores
                Dim SqlString As String, Registros As Double, i As Double
                Dim Buscar_Fila() As DataRow, Criterios As String, Posicion As Integer, oDataRow As DataRow
                Dim NetoPagar As Double, MontoCompra As Double, MontoCompraD As Double

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Compras.Tipo_Compra, Compras.Nombre_Proveedor, Compras.SubTotal + Compras.IVA AS NetoPagar, CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN Compras.SubTotal + Compras.IVA WHEN Compras.MonedaCompra = 'Dolares' THEN (Compras.SubTotal + Compras.IVA) * TasaCambio.MontoTasa END AS MontoCompra, CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN (Compras.SubTotal + Compras.IVA) / TasaCambio.MontoTasa WHEN Compras.MonedaCompra = 'Dolares' THEN Compras.SubTotal + Compras.IVA END AS MontoCompraD, Compras.Cod_Proveedor FROM Compras INNER JOIN TasaCambio ON Compras.Fecha_Compra = TasaCambio.FechaTasa " & _
                            "WHERE (Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '2013-11-01 00:00:00', 102) AND CONVERT(DATETIME, '2013-11-01 00:00:00', 102)) AND (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.Nombre_Proveedor <> N'******CANCELADO') AND (Compras.MonedaCompra = N'11111') ORDER BY Compras.Nombre_Proveedor"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalProveedor")

                ArepReporteProveedores.LblTitulo.Text = NombreEmpresa
                ArepReporteProveedores.LblDireccion.Text = DireccionEmpresa
                ArepReporteProveedores.LblRuc.Text = Ruc
                ArepReporteProveedores.LblRango.Text = "DESDE: " & Format(Fecha1, "dd/MM/yyyy") & "       HASTA: " & Format(Fecha2, "dd/MM/yyyy")

                SqlDatos = "SELECT Compras.Tipo_Compra, Compras.Nombre_Proveedor, Compras.SubTotal + Compras.IVA AS NetoPagar, CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN Compras.SubTotal + Compras.IVA WHEN Compras.MonedaCompra = 'Dolares' THEN (Compras.SubTotal + Compras.IVA) * TasaCambio.MontoTasa END AS MontoCompra, CASE WHEN Compras.MonedaCompra = 'Cordobas' THEN (Compras.SubTotal + Compras.IVA) / TasaCambio.MontoTasa WHEN Compras.MonedaCompra = 'Dolares' THEN Compras.SubTotal + Compras.IVA END AS MontoCompraD, Compras.MonedaCompra,Compras.Cod_Proveedor FROM Compras INNER JOIN TasaCambio ON Compras.Fecha_Compra = TasaCambio.FechaTasa " & _
                            "WHERE (Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Compras.Tipo_Compra = N'Mercancia Recibida') AND (Compras.Nombre_Proveedor <> N'******CANCELADO') ORDER BY Compras.Nombre_Proveedor"

                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalCompras")
                Registros = DataSet.Tables("TotalCompras").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                ArepReporteProveedores.ComprasTotales = 0

                Do While Registros > i
                    My.Application.DoEvents()

                    Criterios = "Cod_Proveedor= '" & DataSet.Tables("TotalCompras").Rows(i)("Cod_Proveedor") & "'"
                    Buscar_Fila = DataSet.Tables("TotalProveedor").Select(Criterios)
                    If Buscar_Fila.Length > 0 Then
                        Posicion = DataSet.Tables("TotalProveedor").Rows.IndexOf(Buscar_Fila(0))
                        NetoPagar = DataSet.Tables("TotalCompras").Rows(i)("NetoPagar")
                        If Me.OptDolares.Checked = True Then
                            MontoCompra = DataSet.Tables("TotalCompras").Rows(i)("MontoCompraD")
                            MontoCompraD = DataSet.Tables("TotalCompras").Rows(i)("MontoCompraD")
                        Else
                            MontoCompra = DataSet.Tables("TotalCompras").Rows(i)("MontoCompra")
                            MontoCompraD = DataSet.Tables("TotalCompras").Rows(i)("MontoCompraD")
                        End If
                        DataSet.Tables("TotalProveedor").Rows(Posicion)("NetoPagar") = DataSet.Tables("TotalProveedor").Rows(Posicion)("NetoPagar") + NetoPagar
                        DataSet.Tables("TotalProveedor").Rows(Posicion)("MontoCompra") = DataSet.Tables("TotalProveedor").Rows(Posicion)("MontoCompra") + MontoCompra
                        DataSet.Tables("TotalProveedor").Rows(Posicion)("MontoCompraD") = DataSet.Tables("TotalProveedor").Rows(Posicion)("MontoCompraD") + MontoCompraD
                    Else


                        oDataRow = DataSet.Tables("TotalProveedor").NewRow
                        oDataRow("Tipo_Compra") = "Mercancia Recibida"
                        oDataRow("Nombre_Proveedor") = DataSet.Tables("TotalCompras").Rows(i)("Nombre_Proveedor")
                        oDataRow("NetoPagar") = DataSet.Tables("TotalCompras").Rows(i)("NetoPagar")
                        If Me.OptDolares.Checked = True Then
                            oDataRow("MontoCompra") = DataSet.Tables("TotalCompras").Rows(i)("MontoCompraD")
                            oDataRow("MontoCompraD") = DataSet.Tables("TotalCompras").Rows(i)("MontoCompraD")
                        Else
                            oDataRow("MontoCompra") = DataSet.Tables("TotalCompras").Rows(i)("MontoCompra")
                            oDataRow("MontoCompraD") = DataSet.Tables("TotalCompras").Rows(i)("MontoCompraD")
                        End If
                        oDataRow("Cod_Proveedor") = DataSet.Tables("TotalCompras").Rows(i)("Cod_Proveedor")
                        DataSet.Tables("TotalProveedor").Rows.Add(oDataRow)
                    End If

                    If Me.OptDolares.Checked = True Then
                        ArepReporteProveedores.ComprasTotales = ArepReporteProveedores.ComprasTotales + DataSet.Tables("TotalCompras").Rows(i)("MontoCompraD")
                    Else
                        ArepReporteProveedores.ComprasTotales = ArepReporteProveedores.ComprasTotales + DataSet.Tables("TotalCompras").Rows(i)("MontoCompra")
                    End If
                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1

                Loop

                ArepReporteProveedores.ChartControl.DataSource = DataSet.Tables("TotalProveedor")
                ArepReporteProveedores.DataSource = DataSet.Tables("TotalProveedor")
                ArepReporteProveedores.Document.Name = "Reporte por Proveedor"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepReporteProveedores.Document
                My.Application.DoEvents()
                ArepReporteProveedores.Run(False)
                ViewerForm.Show()

            Case "Reporte de Facturas x Vendedor"
                Dim ArepFacturasVendedor As New ArepFacturasVendedor
                Dim SqlString As String, Registros As Double, TasaCambio As Double, i As Double
                Dim oDataRow As DataRow

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                'SqlString = "SELECT Productos.Cod_Productos,Detalle_Compras.Cantidad, Productos.Descripcion_Producto,Detalle_Compras.Precio_Unitario As Importe, Detalle_Compras.Descuento As Cod_Bodega, Detalle_Compras.Precio_Neto As Costo, Compras.Su_Referencia As Utilidad, Compras.Nuestra_Referencia As Porciento FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                SqlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nombre_Cliente, Facturas.SubTotal, Facturas.IVA, Facturas.Descuento, Facturas.MetodoPago, Facturas.SubTotal + Facturas.IVA AS TotalFactura,Facturas.Cod_Vendedor, Facturas.Cod_Vendedor As NombreVendedor  FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                            "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS DE CONTADO//////////////////////////////////////
                If Me.CmbVendedores.Text <> "" And Me.CmbVendedores2.Text <> "" Then
                    SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MonedaFactura, Facturas.Cod_Cliente, Facturas.Cod_Cajero, Facturas.Nombre_Cliente, Facturas.Apellido_Cliente, Facturas.NetoPagar, Facturas.MontoCredito, Facturas.SubTotal, Facturas.IVA, Facturas.MetodoPago, Facturas.Cod_Vendedor, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS NombreVendedor, Facturas.SubTotal + Facturas.IVA AS TotalFactura FROM Facturas INNER JOIN " & _
                               "Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor WHERE  (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Nombre_Cliente <> N'******CANCELADO') AND (Facturas.Cod_Vendedor BETWEEN '" & Me.CmbVendedores.Text & "' AND '" & Me.CmbVendedores2.Text & "') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102)) ORDER BY Facturas.Cod_Vendedor, Facturas.MetodoPago"
                Else
                    SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.MonedaFactura, Facturas.Cod_Cliente, Facturas.Cod_Cajero, Facturas.Nombre_Cliente, Facturas.Apellido_Cliente, Facturas.NetoPagar, Facturas.MontoCredito, Facturas.SubTotal, Facturas.IVA, Facturas.MetodoPago, Facturas.Cod_Vendedor, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS NombreVendedor, Facturas.SubTotal + Facturas.IVA AS TotalFactura FROM Facturas INNER JOIN " & _
                               "Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor WHERE  (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Nombre_Cliente <> N'******CANCELADO') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Facturas.Cod_Vendedor, Facturas.MetodoPago"
                End If
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Do While Registros > i
                    My.Application.DoEvents()

                    If Me.OptCordobas.Checked = True Then
                        If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                            TasaCambio = 1
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        End If
                    Else
                        If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                            TasaCambio = 1
                        Else
                            TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        End If
                    End If

                    oDataRow = DataSet.Tables("TotalVentas").NewRow
                    oDataRow("Fecha_Factura") = DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura")
                    oDataRow("Numero_Factura") = DataSet.Tables("TotalFacturas").Rows(i)("Numero_Factura")
                    oDataRow("Nombre_Cliente") = DataSet.Tables("TotalFacturas").Rows(i)("Nombre_Cliente")
                    oDataRow("SubTotal") = DataSet.Tables("TotalFacturas").Rows(i)("SubTotal") * TasaCambio
                    oDataRow("IVA") = DataSet.Tables("TotalFacturas").Rows(i)("IVA") * TasaCambio
                    oDataRow("MetodoPago") = DataSet.Tables("TotalFacturas").Rows(i)("MetodoPago")
                    oDataRow("TotalFactura") = DataSet.Tables("TotalFacturas").Rows(i)("TotalFactura") * TasaCambio
                    oDataRow("Cod_Vendedor") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Vendedor")
                    oDataRow("NombreVendedor") = DataSet.Tables("TotalFacturas").Rows(i)("NombreVendedor")
                    DataSet.Tables("TotalVentas").Rows.Add(oDataRow)

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop


                If Dir(RutaLogo) <> "" Then
                    ArepFacturasVendedor.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepFacturasVendedor.LblTitulo.Text = NombreEmpresa
                ArepFacturasVendedor.LblDireccion.Text = DireccionEmpresa
                ArepFacturasVendedor.LblRuc.Text = Ruc
                If Me.OptDolares.Checked = True Then
                    ArepFacturasVendedor.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepFacturasVendedor.LblMoneda.Text = "Expresado en Cordobas"
                End If

                ArepFacturasVendedor.LblReporte.Text = "Reporte de Facturas x Vendedor"

                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepFacturasVendedor.Document
                My.Application.DoEvents()
                'ArepVentasClientes.DataSource = SQL
                ArepFacturasVendedor.DataSource = DataSet.Tables("TotalVentas")
                ArepFacturasVendedor.Run(False)
                ViewerForm.Show()

            Case "Control de Entradas y Salidas"
                Dim ArepControlProductos As New ArepControlProductos

                If Dir(RutaLogo) <> "" Then
                    ArepControlProductos.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepControlProductos.LblTitulo.Text = NombreEmpresa
                ArepControlProductos.LblDireccion.Text = DireccionEmpresa
                ArepControlProductos.LblRuc.Text = Ruc

                SqlDatos = "SELECT  Cod_Productos, Descripcion_Producto FROM Productos "
                If Me.CboCodProducto.Text = "" Then
                    If Me.CboCodProducto2.Text = "" Then
                        SqlDatos = SqlDatos & " ORDER BY Cod_Productos"
                    Else
                        SqlDatos = SqlDatos & " WHERE (Cod_Productos BETWEEN '" & CodigoInicio & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Cod_Productos"
                    End If
                ElseIf Me.CboCodProducto2.Text = "" Then
                    SqlDatos = SqlDatos & " WHERE (Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & CodigoFin & "') ORDER BY Cod_Productos"
                Else
                    SqlDatos = SqlDatos & " WHERE (Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Cod_Productos"
                End If


                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Movimientos")
                Me.ProgressBar.Maximum = DataSet.Tables("Movimientos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepControlProductos.Document
                My.Application.DoEvents()
                ArepControlProductos.DataSource = SQL
                ArepControlProductos.Run(False)
                ViewerForm.Show()


            Case "Reporte de Ventas x Clientes al Credito"
                Dim SqlString As String, Registros As Double
                Dim CostoUnitario As Double = 0, Utilidad As Double = 0, Porciento As Double = 0, Costo As Double = 0
                Dim CodigoProducto As String = "", TipoProducto As String = ""
                Dim ArepVentasClientes As New ArepVentasClientes, i As Double
                Dim oDataRow As DataRow, TasaCambio As Double

                If Dir(RutaLogo) <> "" Then
                    ArepVentasClientes.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepVentasClientes.LblTitulo.Text = NombreEmpresa
                ArepVentasClientes.LblDireccion.Text = DireccionEmpresa
                ArepVentasClientes.LblRuc.Text = Ruc
                ArepVentasClientes.Label1.Text = "Ventas de Clientes al Credito"
                ArepVentasClientes.Label7.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")
                If Me.OptDolares.Checked = True Then
                    ArepVentasClientes.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepVentasClientes.LblMoneda.Text = "Expresado en Cordobas"
                End If

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                'SqlString = "SELECT Productos.Cod_Productos,Detalle_Compras.Cantidad, Productos.Descripcion_Producto,Detalle_Compras.Precio_Unitario As Importe, Detalle_Compras.Descuento As Cod_Bodega, Detalle_Compras.Precio_Neto As Costo, Compras.Su_Referencia As Utilidad, Compras.Nuestra_Referencia As Porciento FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                SqlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nomibres, Facturas.SubTotal, Facturas.IVA, Facturas.Descuento, Facturas.MetodoPago, Facturas.SubTotal + Facturas.IVA AS Total FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                            "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")


                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS DE CONTADO//////////////////////////////////////
                SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Nomibres, Facturas.SubTotal, Facturas.IVA, Facturas.Descuento, Facturas.MetodoPago, Facturas.SubTotal + Facturas.IVA AS Total,Facturas.MonedaFactura FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                           "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Do While Registros > i
                    My.Application.DoEvents()

                    If Me.OptCordobas.Checked = True Then
                        If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                            TasaCambio = 1
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        End If
                    Else
                        If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                            TasaCambio = 1
                        Else
                            TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        End If
                    End If

                    oDataRow = DataSet.Tables("TotalVentas").NewRow
                    oDataRow("Fecha_Factura") = DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura")
                    oDataRow("Numero_Factura") = DataSet.Tables("TotalFacturas").Rows(i)("Numero_Factura")
                    oDataRow("Nomibres") = DataSet.Tables("TotalFacturas").Rows(i)("Nomibres")
                    oDataRow("SubTotal") = DataSet.Tables("TotalFacturas").Rows(i)("SubTotal") * TasaCambio
                    oDataRow("IVA") = DataSet.Tables("TotalFacturas").Rows(i)("IVA") * TasaCambio
                    oDataRow("MetodoPago") = DataSet.Tables("TotalFacturas").Rows(i)("MetodoPago")
                    oDataRow("Total") = DataSet.Tables("TotalFacturas").Rows(i)("Total") * TasaCambio
                    DataSet.Tables("TotalVentas").Rows.Add(oDataRow)

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop




                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepVentasClientes.Document
                My.Application.DoEvents()
                'ArepVentasClientes.DataSource = SQL
                ArepVentasClientes.DataSource = DataSet.Tables("TotalVentas")
                ArepVentasClientes.Run(False)
                ViewerForm.Show()



            Case "Reporte de Ventas x Clientes al Contado"
                Dim SqlString As String, Registros As Double
                Dim CostoUnitario As Double = 0, Utilidad As Double = 0, Porciento As Double = 0, Costo As Double = 0
                Dim CodigoProducto As String = "", TipoProducto As String = ""
                Dim ArepVentasClientes As New ArepVentasClientes, TasaCambio As Double = 0, i As Double = 0
                Dim oDataRow As DataRow

                If Dir(RutaLogo) <> "" Then
                    ArepVentasClientes.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepVentasClientes.LblTitulo.Text = NombreEmpresa
                ArepVentasClientes.LblDireccion.Text = DireccionEmpresa
                ArepVentasClientes.LblRuc.Text = Ruc
                ArepVentasClientes.Label1.Text = "Ventas de Clientes al Contado"
                ArepVentasClientes.Label7.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")
                If Me.OptDolares.Checked = True Then
                    ArepVentasClientes.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepVentasClientes.LblMoneda.Text = "Expresado en Cordobas"
                End If

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                'SqlString = "SELECT Productos.Cod_Productos,Detalle_Compras.Cantidad, Productos.Descripcion_Producto,Detalle_Compras.Precio_Unitario As Importe, Detalle_Compras.Descuento As Cod_Bodega, Detalle_Compras.Precio_Neto As Costo, Compras.Su_Referencia As Utilidad, Compras.Nuestra_Referencia As Porciento FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                SqlString = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Clientes.Nombre_Cliente + ' ' + Clientes.Apellido_Cliente AS Nomibres, Facturas.SubTotal, Facturas.IVA, Facturas.Descuento, Facturas.MetodoPago, Facturas.SubTotal + Facturas.IVA AS Total FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                            "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago <> 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '01/01/1900', 102) AND CONVERT(DATETIME, '01/01/1900', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")


                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS DE CONTADO//////////////////////////////////////
                'SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Nomibres, Facturas.SubTotal, Facturas.IVA, Facturas.Descuento, Facturas.MetodoPago, Facturas.SubTotal + Facturas.IVA AS Total,Facturas.MonedaFactura FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                '           "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago <> 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura"
                SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Numero_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Nomibres, Facturas.SubTotal, Facturas.IVA, Facturas.Descuento, Facturas.MetodoPago, Facturas.SubTotal + Facturas.IVA AS Total, Facturas.MonedaFactura, Facturas.Cod_Bodega FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                                            "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.MetodoPago <> 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND  CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Fecha_Factura, Facturas.Numero_Factura  "

                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Do While Registros > i
                    My.Application.DoEvents()

                    If Me.OptCordobas.Checked = True Then
                        If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                            TasaCambio = 1
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        End If
                    Else
                        If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                            TasaCambio = 1
                        Else
                            TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        End If
                    End If



                    oDataRow = DataSet.Tables("TotalVentas").NewRow
                    oDataRow("Fecha_Factura") = DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura")
                    oDataRow("Numero_Factura") = DataSet.Tables("TotalFacturas").Rows(i)("Numero_Factura")
                    oDataRow("Nomibres") = DataSet.Tables("TotalFacturas").Rows(i)("Nomibres")
                    oDataRow("SubTotal") = DataSet.Tables("TotalFacturas").Rows(i)("SubTotal") * TasaCambio
                    oDataRow("IVA") = DataSet.Tables("TotalFacturas").Rows(i)("IVA") * TasaCambio
                    oDataRow("MetodoPago") = DataSet.Tables("TotalFacturas").Rows(i)("MetodoPago")
                    oDataRow("Total") = DataSet.Tables("TotalFacturas").Rows(i)("Total") * TasaCambio
                    DataSet.Tables("TotalVentas").Rows.Add(oDataRow)

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop

                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepVentasClientes.Document
                My.Application.DoEvents()
                'ArepVentasClientes.DataSource = SQL
                ArepVentasClientes.DataSource = DataSet.Tables("TotalVentas")
                ArepVentasClientes.Run(False)
                ViewerForm.Show()




            Case "Reporte de Ventas x Productos al Credito"
                Dim SqlString As String, Registros As Double, i As Double, oDataRow As DataRow
                Dim Cantidad As Double, Importe As Double, CostoUnitario As Double = 0, Utilidad As Double = 0, Porciento As Double = 0, Costo As Double = 0
                Dim CodBodega As String, CodigoProducto As String = "", TipoProducto As String = ""
                Dim ArepVentas As New ArepVentasProductos, TasaCambio As Double = 0
                Dim Buscar_Fila() As DataRow, Criterios As String, Posicion As Integer, MontoAcumulado As Double = 0, CantidadAcumulada As Double = 0

                If Dir(RutaLogo) <> "" Then
                    ArepVentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepVentas.LblTitulo.Text = NombreEmpresa
                ArepVentas.LblDireccion.Text = DireccionEmpresa
                ArepVentas.LblRuc.Text = Ruc
                ArepVentas.Label1.Text = "Ventas de Productos al Credito"
                ArepVentas.Label7.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")
                If Me.OptDolares.Checked = True Then
                    ArepVentas.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepVentas.LblMoneda.Text = "Expresado en Cordobas"
                End If


                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Productos.Cod_Productos,Detalle_Compras.Cantidad, Productos.Descripcion_Producto,Detalle_Compras.Precio_Unitario As Importe, Productos.Descripcion_Producto As Cod_Bodega, Detalle_Compras.Precio_Neto As Costo, Compras.Su_Referencia As Utilidad, Compras.Nuestra_Referencia As Porciento FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS DE CONTADO//////////////////////////////////////
                'SqlDatos = "SELECT Detalle_Facturas.Cod_Producto, MAX(Detalle_Facturas.Descripcion_Producto) AS Descripcion_Producto, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Importe) AS Importe, Facturas.Cod_Bodega,Facturas.MonedaFactura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura  " & _
                '           "WHERE (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME,'" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') GROUP BY Detalle_Facturas.Cod_Producto, Facturas.Cod_Bodega HAVING  (MAX(Detalle_Facturas.Descripcion_Producto) <> '-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                SqlDatos = "SELECT  Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura " & _
                           "WHERE  (Facturas.MetodoPago = 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Do While Registros > i
                    My.Application.DoEvents()
                    If DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") <> 0 Then
                        Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                        Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                        CodBodega = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                        CodigoProducto = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto")
                        CostoUnitario = 0
                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL COSTO DEL PRODUCTO PARA ESTA BODEGA //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        'SqlDatos = "SELECT  *  FROM DetalleBodegas WHERE (Cod_Bodegas = '" & CodBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        'DataAdapter.Fill(DataSet, "CostoBodega")
                        'If DataSet.Tables("CostoBodega").Rows.Count <> 0 Then
                        '    If Me.OptCordobas.Checked = True Then
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo")
                        '        End If
                        '    Else
                        '        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo") / TasaCambio
                        '        End If
                        '    End If
                        'End If
                        'DataSet.Tables("CostoBodega").Reset()

                        If Me.OptCordobas.Checked = True Then
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario")
                            End If
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario") / TasaCambio
                            End If
                        End If


                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL TIPO DE PRODUCTO //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT  *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "Producto")
                        If DataSet.Tables("Producto").Rows.Count <> 0 Then
                            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Tipo_Producto")) Then
                                TipoProducto = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
                            End If
                        End If
                        DataSet.Tables("Producto").Reset()

                        If TipoProducto <> "Descuento" Then
                            Costo = Cantidad * CostoUnitario
                            Utilidad = Importe - Costo
                            Porciento = Utilidad / Importe
                        Else
                            Costo = 0
                            Utilidad = 0
                            Porciento = 0
                        End If

                        If Me.OptCordobas.Checked = True Then
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        Else
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        End If

                        Criterios = "Cod_Productos= '" & DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto") & "'"
                        Buscar_Fila = DataSet.Tables("TotalVentas").Select(Criterios)
                        If Buscar_Fila.Length > 0 Then
                            Posicion = DataSet.Tables("TotalVentas").Rows.IndexOf(Buscar_Fila(0))
                            Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                            MontoAcumulado = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                            Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                            CantidadAcumulada = DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") = MontoAcumulado + Importe * TasaCambio
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad") = Cantidad + CantidadAcumulada
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Costo") = (Cantidad + CantidadAcumulada) * CostoUnitario
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") - DataSet.Tables("TotalVentas").Rows(Posicion)("Costo")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Porciento") = DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") / DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                        Else
                            Utilidad = (Importe * TasaCambio) - Costo
                            Porciento = Utilidad / Costo

                            oDataRow = DataSet.Tables("TotalVentas").NewRow
                            oDataRow("Cod_Productos") = CodigoProducto
                            oDataRow("Cantidad") = Cantidad
                            oDataRow("Descripcion_Producto") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Producto")
                            oDataRow("Importe") = Importe * TasaCambio
                            oDataRow("Costo") = Costo
                            oDataRow("Utilidad") = Utilidad
                            oDataRow("Porciento") = Porciento
                            oDataRow("Cod_Bodega") = CodBodega
                            DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        End If




                    End If

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop

                Dim ViewerForm As New FrmViewer()

                ViewerForm.arvMain.Document = ArepVentas.Document
                My.Application.DoEvents()
                ArepVentas.DataSource = DataSet.Tables("TotalVentas")
                ArepVentas.Run(False)
                ViewerForm.Show()

            Case "Reporte de Ventas x Productos al Contado"
                Dim SqlString As String, Registros As Double, i As Double, oDataRow As DataRow
                Dim Cantidad As Double, Importe As Double, CostoUnitario As Double = 0, Utilidad As Double = 0, Porciento As Double = 0, Costo As Double = 0
                Dim CodBodega As String, CodigoProducto As String = "", TipoProducto As String = ""
                Dim ArepVentas As New ArepVentasProductos, TasaCambio As Double = 0, CantidadAcumulada As Double = 0
                Dim Buscar_Fila() As DataRow, Criterios As String, Posicion As Integer, MontoAcumulado As Double = 0

                If Dir(RutaLogo) <> "" Then
                    ArepVentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepVentas.LblTitulo.Text = NombreEmpresa
                ArepVentas.LblDireccion.Text = DireccionEmpresa
                ArepVentas.LblRuc.Text = Ruc
                ArepVentas.Label1.Text = "Ventas de Productos al Contado"
                ArepVentas.Label7.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")
                If Me.OptDolares.Checked = True Then
                    ArepVentas.LblMoneda.Text = "Expresado en Dolares"
                Else
                    ArepVentas.LblMoneda.Text = "Expresado en Cordobas"
                End If


                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Productos.Cod_Productos,Detalle_Compras.Cantidad, Productos.Descripcion_Producto,Detalle_Compras.Precio_Unitario As Importe, Productos.Cod_Productos As Cod_Bodega, Detalle_Compras.Precio_Neto As Costo, Compras.Su_Referencia As Utilidad, Compras.Nuestra_Referencia As Porciento FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS DE CONTADO//////////////////////////////////////

                'SqlDatos = "SELECT Detalle_Facturas.Cod_Producto, MAX(Detalle_Facturas.Descripcion_Producto) AS Descripcion_Producto, SUM(Detalle_Facturas.Cantidad) AS Cantidad, SUM(Detalle_Facturas.Importe) AS Importe, Facturas.Cod_Bodega, MAX(Facturas.MonedaFactura) AS MonedaFactura, MAX(Facturas.Fecha_Factura) AS Fecha_Factura FROM  Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND  Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura  " & _
                '           "WHERE     (Facturas.MetodoPago <> 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') GROUP BY Detalle_Facturas.Cod_Producto, Facturas.Cod_Bodega HAVING (MAX(Detalle_Facturas.Descripcion_Producto) <> '-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto "
                SqlDatos = "SELECT  Detalle_Facturas.Cod_Producto, Detalle_Facturas.Descripcion_Producto, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Facturas.Cod_Bodega, Facturas.MonedaFactura, Facturas.Fecha_Factura,Detalle_Facturas.Costo_Unitario FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura " & _
                           "WHERE  (Facturas.MetodoPago <> 'Credito') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Cod_Bodega, Detalle_Facturas.Cod_Producto"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "TotalFacturas")
                Registros = DataSet.Tables("TotalFacturas").Rows.Count
                i = 0
                Me.ProgressBar.Maximum = Registros
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Do While Registros > i
                    My.Application.DoEvents()
                    If DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") <> 0 Then
                        Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                        Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                        CodBodega = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                        CodigoProducto = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto")
                        CostoUnitario = 0
                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL COSTO DEL PRODUCTO PARA ESTA BODEGA //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        'SqlDatos = "SELECT  *  FROM DetalleBodegas WHERE (Cod_Bodegas = '" & CodBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                        'DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        'DataAdapter.Fill(DataSet, "CostoBodega")
                        'If DataSet.Tables("CostoBodega").Rows.Count <> 0 Then
                        '    If Me.OptCordobas.Checked = True Then
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo")
                        '        End If
                        '    Else
                        '        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                        '        If Not IsDBNull(DataSet.Tables("CostoBodega").Rows(0)("Costo")) Then
                        '            CostoUnitario = DataSet.Tables("CostoBodega").Rows(0)("Costo") / TasaCambio
                        '        End If


                        '    End If
                        'End If
                        'DataSet.Tables("CostoBodega").Reset()

                        If Me.OptCordobas.Checked = True Then
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario")
                            End If
                        Else
                            TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(0)("Costo_Unitario")) Then
                                CostoUnitario = DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario") / TasaCambio
                            End If
                        End If


                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////BUSCO EL TIPO DE PRODUCTO //////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT  *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "Producto")
                        If DataSet.Tables("Producto").Rows.Count <> 0 Then
                            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Tipo_Producto")) Then
                                TipoProducto = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
                            End If
                        End If
                        DataSet.Tables("Producto").Reset()

                        If TipoProducto <> "Descuento" Then
                            Costo = Cantidad * CostoUnitario
                            Utilidad = Importe - Costo
                            Porciento = Utilidad / Importe
                        Else
                            Costo = 0
                            Utilidad = 0
                            Porciento = 0
                        End If



                        If Me.OptCordobas.Checked = True Then
                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If
                        Else

                            If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                                TasaCambio = 1
                            Else
                                TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                            End If


                        End If



                        Criterios = "Cod_Productos= '" & DataSet.Tables("TotalFacturas").Rows(i)("Cod_Producto") & "'"
                        Buscar_Fila = DataSet.Tables("TotalVentas").Select(Criterios)
                        If Buscar_Fila.Length > 0 Then
                            Posicion = DataSet.Tables("TotalVentas").Rows.IndexOf(Buscar_Fila(0))
                            Importe = DataSet.Tables("TotalFacturas").Rows(i)("Importe")
                            MontoAcumulado = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                            Cantidad = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                            CantidadAcumulada = DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") = MontoAcumulado + Importe * TasaCambio
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Cantidad") = Cantidad + CantidadAcumulada
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Costo") = (Cantidad + CantidadAcumulada) * CostoUnitario
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") = DataSet.Tables("TotalVentas").Rows(Posicion)("Importe") - DataSet.Tables("TotalVentas").Rows(Posicion)("Costo")
                            DataSet.Tables("TotalVentas").Rows(Posicion)("Porciento") = DataSet.Tables("TotalVentas").Rows(Posicion)("Utilidad") / DataSet.Tables("TotalVentas").Rows(Posicion)("Importe")
                        Else
                            Utilidad = (Importe * TasaCambio) - Costo
                            Porciento = Utilidad / Costo

                            oDataRow = DataSet.Tables("TotalVentas").NewRow
                            oDataRow("Cod_Productos") = CodigoProducto
                            oDataRow("Cantidad") = Cantidad
                            oDataRow("Descripcion_Producto") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Producto")
                            oDataRow("Importe") = Importe * TasaCambio
                            oDataRow("Costo") = Costo
                            oDataRow("Utilidad") = Utilidad
                            oDataRow("Porciento") = Porciento
                            oDataRow("Cod_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                            DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        End If


                    End If

                    i = i + 1
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                Loop

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepVentas.Document
                My.Application.DoEvents()
                ArepVentas.DataSource = DataSet.Tables("TotalVentas")
                ArepVentas.Run(False)
                ViewerForm.Show()


            Case "Salida de Productos"
                Dim ArepSalidaProductos As New ArepSalidaProductos, SqlString As String = ""
                Dim Registros As Double, i As Double, oDataRow As DataRow, TasaCambio As Double = 0


                If Dir(RutaLogo) <> "" Then
                    ArepSalidaProductos.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepSalidaProductos.LblTitulo.Text = NombreEmpresa
                ArepSalidaProductos.LblDireccion.Text = DireccionEmpresa
                ArepSalidaProductos.LblRuc.Text = Ruc

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia, Productos.Cod_Cuenta_Ventas AS CodTarea,Productos.Unidad_Medida FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalSalida")




                SqlDatos = "SELECT  Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  "



                If Me.CmbAgrupado.Text = "Bodega" Then
                    If Me.CmbRango1.Text = "" And Me.CmbRango2.Text = "" Then
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN  Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                                   "WHERE (Detalle_Compras.Tipo_Compra = N'Transferencia Recibida') OR (Detalle_Compras.Tipo_Compra = N'Mercancia Recibida') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME,'" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND  CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalSalida")


                    ElseIf Me.CboCodProducto.Text = "" And Me.CboCodProducto2.Text = "" Then

                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS //////////////////////////////////////

                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Detalle_Facturas.Costo_Unitario,Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia, Detalle_Facturas.CodTarea,Productos.Unidad_Medida, Facturas.MonedaFactura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos " & _
                                   "WHERE (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalFacturas")
                        Registros = DataSet.Tables("TotalFacturas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") <> 0 Then

                                If Me.OptCordobas.Checked = True Then
                                    If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Cordobas" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                                    End If
                                Else
                                    If DataSet.Tables("TotalFacturas").Rows(i)("MonedaFactura") = "Dolares" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                                    End If
                                End If

                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalFacturas").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                                If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario")) Then
                                    oDataRow("Importe") = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") * DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario") * TasaCambio 'DataSet.Tables("TotalFacturas").Rows(i)("Importe") * TasaCambio
                                End If
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalFacturas").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalFacturas").Rows(i)("Precio_Unitario") * TasaCambio
                                oDataRow("Descuento") = DataSet.Tables("TotalFacturas").Rows(i)("Descuento") * TasaCambio
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalFacturas").Rows(i)("Precio_Neto") * TasaCambio
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalFacturas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalFacturas").Rows(i)("Nuestra_Referencia")
                                End If
                                oDataRow("CodTarea") = DataSet.Tables("TotalFacturas").Rows(i)("CodTarea")
                                oDataRow("Unidad_Medida") = DataSet.Tables("TotalFacturas").Rows(i)("Unidad_Medida")
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS TRANSFERENCIAS ENVIADAS //////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia, Detalle_Facturas.CodTarea, Productos.Unidad_Medida, Facturas.MonedaFactura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos " & _
                                   "WHERE (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Tipo_Factura = 'Transferencia Enviada') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalTransferenciaEnviada")
                        Registros = DataSet.Tables("TotalTransferenciaEnviada").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cantidad") <> 0 Then

                                If Me.OptCordobas.Checked = True Then
                                    If DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("MonedaFactura") = "Cordobas" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Fecha_Factura"))
                                    End If
                                Else
                                    If DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("MonedaFactura") = "Dolares" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Fecha_Factura"))
                                    End If
                                End If

                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cantidad") * DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Costo_Unitario") * TasaCambio
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Precio_Unitario") * TasaCambio
                                oDataRow("Descuento") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Descuento") * TasaCambio
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Precio_Unitario") * TasaCambio
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Nuestra_Referencia")
                                End If
                                oDataRow("CodTarea") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("CodTarea")
                                oDataRow("Unidad_Medida") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Unidad_Medida")
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)

                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '/////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS DEVOLUCIONES DE COMPRAS ////////////////////////////////////////////////////////////
                        'SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia,Detalle_Facturas.CodTarea,Productos.Unidad_Medida FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                        '           "WHERE (Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia, Compras.MonedaCompra FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Devolucion de Compra') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalDevolucionVentas")
                        Registros = DataSet.Tables("TotalDevolucionVentas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") <> 0 Then

                                If Me.OptCordobas.Checked = True Then
                                    If DataSet.Tables("TotalDevolucionVentas").Rows(i)("MonedaCompra") = "Cordobas" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Compra"))
                                    End If
                                Else
                                    If DataSet.Tables("TotalDevolucionVentas").Rows(i)("MonedaCompra") = "Dolares" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Compra"))
                                    End If
                                End If

                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") * DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario") * TasaCambio
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario") * TasaCambio
                                oDataRow("Descuento") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descuento") * TasaCambio
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto") * TasaCambio
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")
                                End If
                                'oDataRow("CodTarea") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("CodTarea")
                                'oDataRow("Unidad_Medida") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Unidad_Medida")
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS SALIDAS DE BODEGAS //////////////////////////////////////


                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia, Detalle_Facturas.CodTarea, Productos.Unidad_Medida, Facturas.MonedaFactura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos " & _
                                   "WHERE (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Tipo_Factura = 'Salida Bodega') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalSalidaBodega")
                        Registros = DataSet.Tables("TotalSalidaBodega").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalSalidaBodega").Rows(i)("Cantidad") <> 0 Then

                                If Me.OptCordobas.Checked = True Then
                                    If DataSet.Tables("TotalSalidaBodega").Rows(i)("MonedaFactura") = "Cordobas" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                                    End If
                                Else
                                    If DataSet.Tables("TotalSalidaBodega").Rows(i)("MonedaFactura") = "Dolares" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalSalidaBodega").Rows(i)("Fecha_Factura"))
                                    End If
                                End If

                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Cantidad")
                                If Not IsDBNull(DataSet.Tables("TotalSalidaBodega").Rows(i)("Costo_Unitario")) Then
                                    oDataRow("Importe") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Cantidad") * DataSet.Tables("TotalSalidaBodega").Rows(i)("Costo_Unitario") * TasaCambio
                                End If
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Precio_Unitario") * TasaCambio
                                oDataRow("Descuento") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Descuento") * TasaCambio
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Precio_Neto") * TasaCambio
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalSalidaBodega").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Nuestra_Referencia")
                                End If
                                oDataRow("CodTarea") = DataSet.Tables("TotalSalidaBodega").Rows(i)("CodTarea")
                                oDataRow("Unidad_Medida") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Unidad_Medida")
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                    Else

                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS FACTURAS //////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia, Detalle_Facturas.CodTarea,Productos.Unidad_Medida, Facturas.MonedaFactura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos " & _
                                   "WHERE (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "')  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalFacturas")
                        Registros = DataSet.Tables("TotalFacturas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            'My.Application.DoEvents()
                            If DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalFacturas").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalFacturas").Rows(i)("Cantidad") * DataSet.Tables("TotalFacturas").Rows(i)("Costo_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalFacturas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalFacturas").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalFacturas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalFacturas").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalFacturas").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalFacturas").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalFacturas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalFacturas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalFacturas").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS TRANSFERENCIAS ENVIADAS //////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia, Detalle_Facturas.CodTarea, Productos.Unidad_Medida, Facturas.MonedaFactura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos " & _
                                   "WHERE (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Tipo_Factura = 'Transferencia Enviada') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalTransferenciaEnviada")
                        Registros = DataSet.Tables("TotalTransferenciaEnviada").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cantidad") * DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Precio_Unitario")  'DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Importe")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalTransferenciaEnviada").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '/////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS DEVOLUCIONES DE COMPRAS ////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia, Compras.MonedaCompra FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Devolucion de Compra')  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalDevolucionVentas")
                        Registros = DataSet.Tables("TotalDevolucionVentas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") * DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS SALIDAS DE BODEGAS //////////////////////////////////////
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Detalle_Facturas.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia, Detalle_Facturas.CodTarea, Productos.Unidad_Medida, Facturas.MonedaFactura FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos " & _
                                   "WHERE (Detalle_Facturas.Descripcion_Producto <> N'-------CANCELADO-------') AND (Facturas.Tipo_Factura = 'Salida Bodega') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalSalidaBodega")
                        Registros = DataSet.Tables("TotalSalidaBodega").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalSalidaBodega").Rows(i)("Cantidad") <> 0 Then

                                If Me.OptCordobas.Checked = True Then
                                    If DataSet.Tables("TotalSalidaBodega").Rows(i)("MonedaFactura") = "Cordobas" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = BuscaTasaCambio(DataSet.Tables("TotalFacturas").Rows(i)("Fecha_Factura"))
                                    End If
                                Else
                                    If DataSet.Tables("TotalSalidaBodega").Rows(i)("MonedaFactura") = "Dolares" Then
                                        TasaCambio = 1
                                    Else
                                        TasaCambio = 1 / BuscaTasaCambio(DataSet.Tables("TotalSalidaBodega").Rows(i)("Fecha_Factura"))
                                    End If
                                End If

                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Cantidad") * DataSet.Tables("TotalSalidaBodega").Rows(i)("Costo_Unitario") * TasaCambio
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Precio_Unitario") * TasaCambio
                                oDataRow("Descuento") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Descuento") * TasaCambio
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Precio_Neto") * TasaCambio
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalSalidaBodega").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Nuestra_Referencia")
                                End If
                                oDataRow("CodTarea") = DataSet.Tables("TotalSalidaBodega").Rows(i)("CodTarea")
                                oDataRow("Unidad_Medida") = DataSet.Tables("TotalSalidaBodega").Rows(i)("Unidad_Medida")
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                    End If

                Else
                    If Me.CboCodProducto.Text = "" And Me.CboCodProducto2.Text = "" Then
                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS MERCANCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalMercanciaRecibida")
                        Registros = DataSet.Tables("TotalMercanciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS TRANSFERENCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Transferencia Recibida') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalTransferenciaRecibida")
                        Registros = DataSet.Tables("TotalTransferenciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '/////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS DEVOLUCIONES DE VENTAS ////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalDevolucionVentas")
                        Registros = DataSet.Tables("TotalDevolucionVentas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") * DataSet.Tables("TotalDevolucionVentas").Rows(i)("Costo_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                    Else
                        'SqlDatos = "SELECT  Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  WHERE (Detalle_Compras.Tipo_Compra = N'Transferencia Recibida') OR (Productos.Cod_Productos BETWEEN '" & Me.CboCodigoProducto.Text & "' AND '" & Me.CboCodigoProducto2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = N'Mercancia Recibida') ORDER BY Detalle_Compras.Fecha_Compra"
                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS MERCANCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida')  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalMercanciaRecibida")
                        Registros = DataSet.Tables("TotalMercanciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS TRANSFERENCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Transferencia Recibida') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalTransferenciaRecibida")
                        Registros = DataSet.Tables("TotalTransferenciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '/////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS DEVOLUCIONES DE VENTAS ////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalDevolucionVentas")
                        Registros = DataSet.Tables("TotalDevolucionVentas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalSalida").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") * DataSet.Tables("TotalDevolucionVentas").Rows(i)("Costo_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalSalida").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        'SqlDatos = "SELECT  Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                        '"WHERE  (Detalle_Compras.Tipo_Compra = N'Transferencia Recibida') AND (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango1.Text & "') OR (Detalle_Compras.Tipo_Compra = N'Mercancia Recibida') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodigoProducto.Text & "' AND '" & Me.CboCodigoProducto2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME,  '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Compras.Fecha_Compra"

                    End If
                End If



                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepSalidaProductos.Document
                My.Application.DoEvents()
                'ArepEntradaProductos.DataSource = SQL
                ArepSalidaProductos.DataSource = DataSet.Tables("TotalSalida")
                ArepSalidaProductos.Run(False)
                ViewerForm.Show()

            Case "Entrada de Productos"
                Dim ArepEntradaProductos As New ArepEntradaProductos, SqlString As String = ""
                Dim Registros As Double, i As Double, oDataRow As DataRow


                If Dir(RutaLogo) <> "" Then
                    ArepEntradaProductos.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepEntradaProductos.LblTitulo.Text = NombreEmpresa
                ArepEntradaProductos.LblDireccion.Text = DireccionEmpresa
                ArepEntradaProductos.LblRuc.Text = Ruc
                ArepEntradaProductos.Label9.Text = "Impreso Desde " & Format(Fecha1, "dd/MM/yyyy") & "   Hasta    " & Format(Fecha2, "dd/MM/yyyy")

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra WHERE (Compras.Cod_Bodega = N'-1000') ORDER BY Detalle_Compras.Fecha_Compra"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalEntrada")



                SqlDatos = "SELECT  Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  "



                If Me.CmbAgrupado.Text = "Bodega" Then
                    If Me.CmbRango1.Text = "" And Me.CmbRango2.Text = "" Then
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN  Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                                   "WHERE (Detalle_Compras.Tipo_Compra = N'Transferencia Recibida') OR (Detalle_Compras.Tipo_Compra = N'Mercancia Recibida') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME,'" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND  CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalEntrada")


                    ElseIf Me.CboCodProducto.Text = "" And Me.CboCodProducto2.Text = "" Then



                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS MERCANCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalMercanciaRecibida")
                        Registros = DataSet.Tables("TotalMercanciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop



                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS TRANSFERENCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Transferencia Recibida') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalTransferenciaRecibida")
                        Registros = DataSet.Tables("TotalTransferenciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '/////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS DEVOLUCIONES DE VENTAS ////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalDevolucionVentas")
                        Registros = DataSet.Tables("TotalDevolucionVentas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") * DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                    Else

                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS MERCANCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida')  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalMercanciaRecibida")
                        Registros = DataSet.Tables("TotalMercanciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS TRANSFERENCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Transferencia Recibida') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalTransferenciaRecibida")
                        Registros = DataSet.Tables("TotalTransferenciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '/////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS DEVOLUCIONES DE VENTAS ////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Cantidad, Detalle_Facturas.Costo_Unitario,Detalle_Facturas.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalDevolucionVentas")
                        Registros = DataSet.Tables("TotalDevolucionVentas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Factura")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Tipo_Factura")
                                oDataRow("Cantidad") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") * DataSet.Tables("TotalDevolucionVentas").Rows(i)("Costo_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Numero_Factura")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        'SqlDatos = "SELECT  Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                        '"WHERE  (Detalle_Compras.Tipo_Compra = N'Transferencia Recibida') AND (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango1.Text & "') OR (Detalle_Compras.Tipo_Compra = N'Mercancia Recibida') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodigoProducto.Text & "' AND '" & Me.CboCodigoProducto2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME,  '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Compras.Fecha_Compra"
                    End If

                Else
                    If Me.CboCodProducto.Text = "" And Me.CboCodProducto2.Text = "" Then
                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS MERCANCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalMercanciaRecibida")
                        Registros = DataSet.Tables("TotalMercanciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS TRANSFERENCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Transferencia Recibida') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalTransferenciaRecibida")
                        Registros = DataSet.Tables("TotalTransferenciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '/////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS DEVOLUCIONES DE VENTAS ////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalDevolucionVentas")
                        Registros = DataSet.Tables("TotalDevolucionVentas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") * DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                    Else
                        'SqlDatos = "SELECT  Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  WHERE (Detalle_Compras.Tipo_Compra = N'Transferencia Recibida') OR (Productos.Cod_Productos BETWEEN '" & Me.CboCodigoProducto.Text & "' AND '" & Me.CboCodigoProducto2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = N'Mercancia Recibida') ORDER BY Detalle_Compras.Fecha_Compra"
                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS MERCANCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Mercancia Recibida')  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalMercanciaRecibida")
                        Registros = DataSet.Tables("TotalMercanciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalMercanciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        '//////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS TRANSFERENCIAS RECIBIDAS //////////////////////////////////////
                        SqlDatos = "SELECT Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra " & _
                                   "WHERE  (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Detalle_Compras.Tipo_Compra = 'Transferencia Recibida') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Detalle_Compras.Fecha_Compra"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalTransferenciaRecibida")
                        Registros = DataSet.Tables("TotalTransferenciaRecibida").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cantidad") * DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Precio_Unitario")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalTransferenciaRecibida").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop

                        '/////////////////////CON ESTA CONSULTA SELECCIONO TODAS LAS DEVOLUCIONES DE VENTAS ////////////////////////////////////////////////////////////
                        SqlDatos = "SELECT Facturas.Fecha_Factura, Facturas.Tipo_Factura, Detalle_Facturas.Cantidad, Detalle_Facturas.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Facturas.Numero_Factura, Facturas.Cod_Bodega, Detalle_Facturas.Precio_Unitario, Detalle_Facturas.Descuento, Detalle_Facturas.Precio_Neto, Facturas.Su_Referencia, Facturas.Nuestra_Referencia FROM Facturas INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Devolucion de Venta') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Facturas.Fecha_Factura"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                        DataAdapter.Fill(DataSet, "TotalDevolucionVentas")
                        Registros = DataSet.Tables("TotalDevolucionVentas").Rows.Count
                        i = 0
                        Me.ProgressBar.Maximum = Registros
                        Me.ProgressBar.Minimum = 0
                        Me.ProgressBar.Value = 0
                        Me.ProgressBar.Visible = True
                        Do While Registros > i
                            My.Application.DoEvents()
                            If DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") <> 0 Then
                                oDataRow = DataSet.Tables("TotalEntrada").NewRow
                                oDataRow("Fecha_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Fecha_Compra")
                                oDataRow("Tipo_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Tipo_Compra")
                                oDataRow("Cantidad") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad")
                                oDataRow("Importe") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cantidad") * DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Cod_Productos") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Productos")
                                oDataRow("Descripcion_Producto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descripcion_Producto")
                                oDataRow("Numero_Compra") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Numero_Compra")
                                oDataRow("Cod_Bodega") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Cod_Bodega")
                                oDataRow("Precio_Unitario") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Unitario")
                                oDataRow("Descuento") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Descuento")
                                oDataRow("Precio_Neto") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Precio_Neto")
                                oDataRow("Su_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Su_Referencia")
                                If Not IsDBNull(DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")) Then
                                    oDataRow("Nuestra_Referencia") = DataSet.Tables("TotalDevolucionVentas").Rows(i)("Nuestra_Referencia")
                                End If
                                DataSet.Tables("TotalEntrada").Rows.Add(oDataRow)
                            End If
                            i = i + 1
                            Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                        Loop


                        'SqlDatos = "SELECT  Detalle_Compras.Fecha_Compra, Detalle_Compras.Tipo_Compra, Detalle_Compras.Cantidad, Detalle_Compras.Importe, Productos.Cod_Productos, Productos.Descripcion_Producto, Detalle_Compras.Numero_Compra, Compras.Cod_Bodega, Detalle_Compras.Precio_Unitario, Detalle_Compras.Descuento, Detalle_Compras.Precio_Neto, Compras.Su_Referencia, Compras.Nuestra_Referencia FROM  Detalle_Compras INNER JOIN Productos ON Detalle_Compras.Cod_Producto = Productos.Cod_Productos INNER JOIN Compras ON Detalle_Compras.Numero_Compra = Compras.Numero_Compra AND Detalle_Compras.Fecha_Compra = Compras.Fecha_Compra AND Detalle_Compras.Tipo_Compra = Compras.Tipo_Compra  " & _
                        '"WHERE  (Detalle_Compras.Tipo_Compra = N'Transferencia Recibida') AND (Compras.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango1.Text & "') OR (Detalle_Compras.Tipo_Compra = N'Mercancia Recibida') AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodigoProducto.Text & "' AND '" & Me.CboCodigoProducto2.Text & "') AND (Detalle_Compras.Fecha_Compra BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME,  '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Detalle_Compras.Fecha_Compra"

                    End If
                End If



                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepEntradaProductos.Document
                My.Application.DoEvents()
                'ArepEntradaProductos.DataSource = SQL
                ArepEntradaProductos.DataSource = DataSet.Tables("TotalEntrada")
                ArepEntradaProductos.Run(False)
                ViewerForm.Show()

            Case "Estado de Cuentas x Cliente"
                Dim ArepEstadoCuentasClientes As New ArepEstadoCuentasClientes
                Dim SqlString As String, Registros As Double, CodigoCliente As String
                Dim oDataRow As DataRow, i As Double = 0, Debito As Double = 0, SaldoInicial As Double
                Dim Moneda As String = "", Balance As Double, Registros1 As Double
                Dim MontoFactura As Double = 0, MontoNota As Double = 0, MonedaRecibo As Double = 0, MontoRecibo As Double = 0, MontoMetodoFactura
                Dim MontoNotaCredito As Double = 0, j As Double = 0
                Dim DvProductos As DataView

                If Dir(RutaLogo) <> "" Then
                    ArepEstadoCuentasClientes.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepEstadoCuentasClientes.LblTitulo.Text = NombreEmpresa
                ArepEstadoCuentasClientes.LblDireccion.Text = DireccionEmpresa
                ArepEstadoCuentasClientes.LblRuc.Text = Ruc

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Clientes.Cod_Cliente, Clientes.Nombre_Cliente, Facturas.Fecha_Factura AS Fecha, Facturas.Numero_Factura AS Numero, Facturas.Tipo_Factura AS TipoDocumento, Clientes.Nombre_Cliente AS Concepto, Facturas.NetoPagar AS SaldoInicial, Facturas.IVA AS Debito, Facturas.NetoPagar AS Credito, Facturas.NetoPagar AS Balance FROM  Clientes INNER JOIN Facturas ON Clientes.Cod_Cliente = Facturas.Cod_Cliente WHERE  (Clientes.Cod_Cliente = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                'If Me.CmbClientes.Text = "" And Me.CmbClientes2.Text = "" Then
                '    SqlDatos = "SELECT DISTINCT SUM(Facturas.MontoCredito) AS MontoCredito, Facturas.Cod_Cliente, Clientes.Nombre_Cliente,Clientes.Apellido_Cliente FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102))  GROUP BY Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente ORDER BY Facturas.Cod_Cliente"
                'Else
                '    SqlDatos = "SELECT DISTINCT SUM(Facturas.MontoCredito) AS MontoCredito, Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente HAVING (Facturas.Cod_Cliente BETWEEN '" & Me.CmbClientes.Text & "' AND '" & Me.CmbClientes2.Text & "')  ORDER BY Facturas.Cod_Cliente"
                'End If
                If Me.CmbClientes.Text = "" And Me.CmbClientes2.Text = "" Then
                    SqlDatos = "SELECT DISTINCT Nombre_Cliente, Apellido_Cliente, Cod_Cliente FROM  Clientes GROUP BY Nombre_Cliente, Apellido_Cliente, Cod_Cliente  ORDER BY Clientes.Cod_Cliente"
                Else
                    SqlDatos = "SELECT DISTINCT Nombre_Cliente, Apellido_Cliente, Cod_Cliente FROM  Clientes GROUP BY Nombre_Cliente, Apellido_Cliente, Cod_Cliente HAVING  (Clientes.Cod_Cliente BETWEEN '" & Me.CmbClientes.Text & "' AND '" & Me.CmbClientes2.Text & "') ORDER BY Clientes.Cod_Cliente"
                End If


                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registros1 = DataSet.Tables("Productos").Rows.Count
                i = 0
                Do While Registros1 > i
                    CodigoCliente = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                    'If Trim(CodigoCliente) = "1032" Then
                    '    CodigoCliente = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                    'End If

                    If Me.OptCordobas.Checked = True Then
                        Moneda = "Cordobas"
                    Else
                        Moneda = "Dolares"
                    End If


                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS FACTURAS DE CREDITO //////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    SqlString = "SELECT Clientes.Apellido_Cliente,Facturas.Tipo_Factura,Facturas.Numero_Factura,Facturas.Fecha_Factura,CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal / TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.IVA * TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.IVA / TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN (Facturas.SubTotal + Facturas.IVA) * TasaCambio.MontoTasa ELSE (Facturas.SubTotal + Facturas.IVA) END AS NetoCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN (Facturas.SubTotal + Facturas.IVA) / TasaCambio.MontoTasa ELSE (Facturas.SubTotal + Facturas.IVA) END AS NetoDolares FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN  TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') AND (Clientes.Cod_Cliente = '" & CodigoCliente & "') AND (Facturas.Nombre_Cliente <> N'******CANCELADO')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Facturas")


                    Registros = DataSet.Tables("Facturas").Rows.Count
                    j = 0
                    Me.ProgressBar1.Minimum = 0
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar1.Value = 0
                    Me.ProgressBar1.Maximum = DataSet.Tables("Facturas").Rows.Count
                    Do While Registros > j
                        My.Application.DoEvents()
                        If Moneda = "Cordobas" Then
                            MontoFactura = DataSet.Tables("Facturas").Rows(j)("NetoCordobas")
                        Else
                            MontoFactura = DataSet.Tables("Facturas").Rows(j)("NetoDolares")
                        End If

                        'If Format(MontoFactura + Balance, "##,##0.00") <> "0.00" Then
                        oDataRow = DataSet.Tables("TotalVentas").NewRow
                        oDataRow("Cod_Cliente") = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                        oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(i)("Nombre_Cliente")
                        oDataRow("SaldoInicial") = Balance
                        oDataRow("Fecha") = DataSet.Tables("Facturas").Rows(j)("Fecha_Factura")
                        oDataRow("Numero") = DataSet.Tables("Facturas").Rows(j)("Numero_Factura")
                        oDataRow("TipoDocumento") = DataSet.Tables("Facturas").Rows(j)("Tipo_Factura")
                        oDataRow("Concepto") = "Venta"
                        oDataRow("Debito") = MontoFactura
                        oDataRow("Credito") = 0
                        oDataRow("Balance") = Balance + MontoFactura
                        DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        'End If
                        Balance = Balance + MontoFactura

                        j = j + 1
                        Me.ProgressBar1.Value = j
                    Loop
                    DataSet.Tables("Facturas").Reset()

                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '/////////////////////////AGREGO LA CONSULTA PARA TODAS LAS NOTAS //////////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    SqlString = "SELECT Detalle_Nota.Descripcion,IndiceNota.Fecha_Nota,Detalle_Nota.Numero_Nota, Detalle_Nota.Numero_Factura, CASE WHEN IndiceNota.MonedaNota = 'Cordobas' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN IndiceNota.MonedaNota = 'Dolares' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_Nota INNER JOIN  NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN TasaCambio ON IndiceNota.Fecha_Nota = TasaCambio.FechaTasa WHERE (NotaDebito.Tipo = 'Debito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "',102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) ORDER BY IndiceNota.Fecha_Nota"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Notas")
                    Registros = DataSet.Tables("Notas").Rows.Count
                    j = 0
                    Me.ProgressBar1.Minimum = 0
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar1.Value = 0
                    Me.ProgressBar1.Maximum = Registros
                    Do While Registros > j
                        My.Application.DoEvents()
                        If Moneda = "Cordobas" Then
                            MontoNota = DataSet.Tables("Notas").Rows(j)("MontoCordobas")
                        Else
                            MontoNota = DataSet.Tables("Notas").Rows(j)("MontoDolares")
                        End If

                        'If Format(Balance + MontoNota, "##,##0.00") <> "0.00" Then
                        oDataRow = DataSet.Tables("TotalVentas").NewRow
                        oDataRow("Cod_Cliente") = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                        oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(i)("Nombre_Cliente") & " " & DataSet.Tables("Productos").Rows(i)("Apellido_Cliente")
                        oDataRow("SaldoInicial") = Balance
                        oDataRow("Fecha") = DataSet.Tables("Notas").Rows(j)("Fecha_Nota")
                        oDataRow("Numero") = DataSet.Tables("Notas").Rows(j)("Numero_Nota")
                        oDataRow("TipoDocumento") = "N/D"
                        If DataSet.Tables("Notas").Rows(j)("Descripcion") <> "*******ANULADO*******" Then
                            oDataRow("Concepto") = DataSet.Tables("Notas").Rows(j)("Descripcion") & " Factura No " & DataSet.Tables("Notas").Rows(j)("Numero_Factura")
                        Else
                            oDataRow("Concepto") = DataSet.Tables("Notas").Rows(j)("Descripcion")
                        End If
                        oDataRow("Debito") = MontoNota
                        oDataRow("Credito") = 0
                        oDataRow("Balance") = Balance + MontoNota
                        DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        'End If
                        Balance = Balance + MontoNota
                        j = j + 1
                        Me.ProgressBar1.Value = j
                    Loop
                    DataSet.Tables("Notas").Reset()

                    '---------------------------------------------------------------------------------------------------------------------------------------
                    '------------------------------------------CONSULTA DE RECIBOS DE CAJA ----------------------------------------------------------------
                    '---------------------------------------------------------------------------------------------------------------------------------------
                    SqlString = "SELECT DetalleRecibo.CodReciboPago, DetalleRecibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.MontoPagado, CASE WHEN Recibo.MonedaRecibo = 'Cordobas' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN Recibo.MonedaRecibo = 'Dolares' THEN DetalleRecibo.MontoPagado ELSE DetalleRecibo.MontoPagado / TasaCambio.MontoTasa END AS MontoDolares, Recibo.Cod_Cliente FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa WHERE (DetalleRecibo.Fecha_Recibo BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "',102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (Recibo.Cod_Cliente = '" & CodigoCliente & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Recibos")


                    Registros = DataSet.Tables("Recibos").Rows.Count
                    j = 0
                    Me.ProgressBar1.Minimum = 0
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar1.Value = 0
                    Me.ProgressBar1.Maximum = DataSet.Tables("Recibos").Rows.Count
                    Do While Registros > j
                        My.Application.DoEvents()
                        If Moneda = "Cordobas" Then
                            MontoRecibo = DataSet.Tables("Recibos").Rows(j)("MontoCordobas")
                        Else
                            MontoRecibo = DataSet.Tables("Recibos").Rows(j)("MontoDolares")
                        End If

                        'If Format(Balance + MontoRecibo, "##,##0.00") <> "0.00" Then
                        oDataRow = DataSet.Tables("TotalVentas").NewRow
                        oDataRow("Cod_Cliente") = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                        oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(i)("Nombre_Cliente") & " " & DataSet.Tables("Productos").Rows(i)("Apellido_Cliente")
                        oDataRow("SaldoInicial") = Balance
                        oDataRow("Fecha") = DataSet.Tables("Recibos").Rows(j)("Fecha_Recibo")
                        oDataRow("Numero") = DataSet.Tables("Recibos").Rows(j)("CodReciboPago")
                        oDataRow("TipoDocumento") = "Recibo"
                        oDataRow("Concepto") = "Pago de la Factura No " & DataSet.Tables("Recibos").Rows(j)("Numero_Factura")
                        oDataRow("Debito") = 0
                        oDataRow("Credito") = MontoRecibo
                        oDataRow("Balance") = Balance - MontoRecibo
                        DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        'End If

                        j = j + 1
                        Me.ProgressBar1.Value = j
                    Loop
                    DataSet.Tables("Recibos").Reset()

                    '-------------------------------------------------------------------------------------------------------------------------------------------
                    '-----------------------CONSULTO NOTAS DE CREDITOS CLIENTES --------------------------------------------------------------------------------
                    '-------------------------------------------------------------------------------------------------------------------------------------------
                    SqlString = "SELECT NotaDebito.Descripcion,IndiceNota.Fecha_Nota,Detalle_Nota.Numero_Nota, Detalle_Nota.Numero_Factura,CASE WHEN IndiceNota.MonedaNota = 'Cordobas' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN IndiceNota.MonedaNota = 'Dolares' THEN Detalle_Nota.Monto ELSE Detalle_Nota.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_Nota INNER JOIN  NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota INNER JOIN TasaCambio ON IndiceNota.Fecha_Nota = TasaCambio.FechaTasa WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (IndiceNota.Cod_Cliente = '" & CodigoCliente & "') AND (IndiceNota.Fecha_Nota BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "',102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102))"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "NotasCredito")
                    Registros = DataSet.Tables("NotasCredito").Rows.Count
                    Me.ProgressBar1.Minimum = 0
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar1.Value = 0
                    Me.ProgressBar1.Maximum = Registros
                    j = 0
                    Do While Registros > j
                        My.Application.DoEvents()
                        If Moneda = "Cordobas" Then
                            MontoNotaCredito = DataSet.Tables("NotasCredito").Rows(j)("MontoCordobas")
                        Else
                            MontoNotaCredito = DataSet.Tables("NotasCredito").Rows(j)("MontoDolares")
                        End If


                        oDataRow = DataSet.Tables("TotalVentas").NewRow
                        oDataRow("Cod_Cliente") = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                        oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(i)("Nombre_Cliente") & " " & DataSet.Tables("Productos").Rows(i)("Apellido_Cliente")
                        oDataRow("SaldoInicial") = Balance
                        oDataRow("Fecha") = DataSet.Tables("NotasCredito").Rows(j)("Fecha_Nota")
                        oDataRow("Numero") = DataSet.Tables("NotasCredito").Rows(j)("Numero_Nota")
                        oDataRow("TipoDocumento") = "N/C"
                        oDataRow("Concepto") = DataSet.Tables("NotasCredito").Rows(j)("Descripcion") & " Factura No " & DataSet.Tables("NotasCredito").Rows(j)("Numero_Factura")
                        oDataRow("Debito") = 0
                        oDataRow("Credito") = MontoNotaCredito
                        oDataRow("Balance") = Balance - MontoNotaCredito
                        DataSet.Tables("TotalVentas").Rows.Add(oDataRow)

                        j = j + 1
                        Me.ProgressBar1.Value = j
                    Loop
                    DataSet.Tables("NotasCredito").Reset()


                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////BUSCO EL DETALLE DE METODO PARA LAS FACTURAS DE CONTADO //////////////////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    MontoMetodoFactura = 0
                    SqlString = "SELECT Facturas.Tipo_Factura,Facturas.Numero_Factura,Facturas.Fecha_Factura,Facturas.Cod_Cliente, CASE WHEN MetodoPago.Moneda = 'Cordobas' THEN Detalle_MetodoFacturas.Monto ELSE Detalle_MetodoFacturas.Monto * TasaCambio.MontoTasa END AS MontoCordobas, CASE WHEN MetodoPago.Moneda = 'Dolares' THEN Detalle_MetodoFacturas.Monto ELSE Detalle_MetodoFacturas.Monto / TasaCambio.MontoTasa END AS MontoDolares FROM Detalle_MetodoFacturas INNER JOIN MetodoPago ON Detalle_MetodoFacturas.NombrePago = MetodoPago.NombrePago INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                "WHERE (Detalle_MetodoFacturas.Tipo_Factura = 'Factura') AND (Facturas.Cod_Cliente = '" & CodigoCliente & "') AND (Detalle_MetodoFacturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & "', 102)) AND (Facturas.Nombre_Cliente <> N'******CANCELADO')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "MetodoFactura")
                    Registros = DataSet.Tables("MetodoFactura").Rows.Count
                    j = 0
                    Me.ProgressBar1.Minimum = 0
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar1.Value = 0
                    Me.ProgressBar1.Maximum = Registros
                    Do While Registros > j
                        My.Application.DoEvents()
                        If Moneda = "Cordobas" Then
                            MontoMetodoFactura = DataSet.Tables("MetodoFactura").Rows(j)("MontoCordobas")
                        Else
                            MontoMetodoFactura = DataSet.Tables("MetodoFactura").Rows(j)("MontoDolares")
                        End If

                        oDataRow = DataSet.Tables("TotalVentas").NewRow
                        oDataRow("Cod_Cliente") = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                        oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(i)("Nombre_Cliente") & " " & DataSet.Tables("Productos").Rows(i)("Apellido_Cliente")
                        oDataRow("SaldoInicial") = Balance
                        oDataRow("Fecha") = DataSet.Tables("MetodoFactura").Rows(j)("Fecha_Factura")
                        oDataRow("Numero") = DataSet.Tables("MetodoFactura").Rows(j)("Numero_Factura")
                        oDataRow("TipoDocumento") = "Efectivo"
                        oDataRow("Concepto") = "Pago De Contado Factura No: " & DataSet.Tables("MetodoFactura").Rows(j)("Numero_Factura")
                        oDataRow("Debito") = 0
                        oDataRow("Credito") = MontoMetodoFactura
                        oDataRow("Balance") = Balance - MontoMetodoFactura
                        DataSet.Tables("TotalVentas").Rows.Add(oDataRow)



                        j = j + 1
                        Me.ProgressBar1.Value = j
                    Loop
                    DataSet.Tables("MetodoFactura").Reset()


                    SaldoInicial = SaldoInicialCliente(CodigoCliente, Me.DTPFechaIni.Value, Moneda)

                    If Format(SaldoInicial, "##,##0.00") <> "0.00" Then
                        If Format(Balance + MontoMetodoFactura + MontoNotaCredito + MontoRecibo + MontoNota, "##,##0.00") = "0.00" Then
                            oDataRow = DataSet.Tables("TotalVentas").NewRow
                            oDataRow("Cod_Cliente") = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                            oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(i)("Nombre_Cliente")
                            DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                        End If
                    End If


                    Me.Text = "Procesando: " & CodigoCliente & " " & DataSet.Tables("Productos").Rows(i)("Nombre_Cliente")
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    i = i + 1
                Loop

                Me.ProgressBar1.Visible = False

                DvProductos = New DataView(DataSet.Tables("TotalVentas"))
                DvProductos.Sort = "Cod_Cliente,Fecha"
                ArepEstadoCuentasClientes.DataSource = DvProductos

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepEstadoCuentasClientes.Document
                My.Application.DoEvents()
                ArepEstadoCuentasClientes.LblDesde.Text = "Desde " & Format(Me.DTPFechaIni.Value, "dd/MM/yyyy") & "   Hasta   " & Format(Me.DTPFechaFin.Value, "dd/MM/yyyy")
                ArepEstadoCuentasClientes.TxtSaldoInicial.Text = Format(SaldoInicial, "##,##0.00")
                ArepEstadoCuentasClientes.LblImpreso.Text = "Impreso: " & Format(Now, "Long Date")
                ArepEstadoCuentasClientes.DataSource = DataSet.Tables("TotalVentas")
                ArepEstadoCuentasClientes.Run(False)
                ViewerForm.Show()

                Me.Label1.Visible = True
                Me.DTPFechaIni.Visible = True
                Me.GroupVendedor.Visible = True

            Case "Reporte de Historico de Saldo Clientes"
                Dim ArepSaldoClientes As New ArepSaldoClientesHistoricos
                Dim SqlString As String, Registros As Double, CodigoCliente As String
                Dim oDataRow As DataRow, i As Double = 0, Debito As Double = 0, Credito As Double, SaldoInicial As Double
                Dim Moneda As String = "", SaldoCorriente As Double, Saldo30Dias As Double, Saldo60Dias As Double, Saldo90Dias As Double, SaldoMas90Dias As Double

                If Dir(RutaLogo) <> "" Then
                    ArepSaldoClientes.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepSaldoClientes.LblTitulo.Text = NombreEmpresa
                ArepSaldoClientes.LblDireccion.Text = DireccionEmpresa
                ArepSaldoClientes.LblRuc.Text = Ruc

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Clientes.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente, Facturas.SubTotal AS Corriente, Facturas.IVA AS  [30Dias], Facturas.NetoPagar AS [60Dias], Facturas.NetoPagar AS [90Dias], Facturas.NetoPagar AS [mas90], Facturas.NetoPagar AS SaldoFinal, Clientes.Cod_Cliente As Orden FROM  Clientes INNER JOIN Facturas ON Clientes.Cod_Cliente = Facturas.Cod_Cliente WHERE (Clientes.Cod_Cliente = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                If Me.CmbClientes.Text = "" And Me.CmbClientes2.Text = "" Then
                    SqlDatos = "SELECT DISTINCT Nombre_Cliente, Apellido_Cliente, Cod_Cliente FROM  Clientes GROUP BY Nombre_Cliente, Apellido_Cliente, Cod_Cliente  ORDER BY Clientes.Cod_Cliente"
                Else
                    SqlDatos = "SELECT DISTINCT Nombre_Cliente, Apellido_Cliente, Cod_Cliente FROM  Clientes GROUP BY Nombre_Cliente, Apellido_Cliente, Cod_Cliente HAVING  (Clientes.Cod_Cliente BETWEEN '" & Me.CmbClientes.Text & "' AND '" & Me.CmbClientes2.Text & "') ORDER BY Clientes.Cod_Cliente"
                End If


                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registros = DataSet.Tables("Productos").Rows.Count
                i = 0
                Do While Registros > i
                    CodigoCliente = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")

                    If Me.OptCordobas.Checked = True Then
                        Moneda = "Cordobas"
                    Else
                        Moneda = "Dolares"
                    End If

                    SaldoCorriente = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, -100, 0)
                    Saldo30Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 1, 30)
                    Saldo60Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 31, 60)
                    Saldo90Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 61, 90)
                    SaldoMas90Dias = ConsultaSaldoCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda, 91, 1000)

                    If Format(SaldoCorriente + Saldo30Dias + Saldo60Dias + Saldo90Dias + SaldoMas90Dias, "##,##0.00") <> "0.00" Then
                        oDataRow = DataSet.Tables("TotalVentas").NewRow
                        oDataRow("Cod_Cliente") = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                        oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(i)("Nombre_Cliente") & " " & DataSet.Tables("Productos").Rows(i)("Apellido_Cliente")
                        oDataRow("Corriente") = SaldoCorriente
                        oDataRow("30Dias") = Saldo30Dias
                        oDataRow("60Dias") = Saldo60Dias
                        oDataRow("90Dias") = Saldo90Dias
                        oDataRow("mas90") = SaldoMas90Dias
                        oDataRow("SaldoFinal") = SaldoCorriente + Saldo30Dias + Saldo60Dias + Saldo90Dias + SaldoMas90Dias
                        oDataRow("Orden") = "01"
                        DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                    End If

                    Me.Text = "Procesando: " & CodigoCliente & " " & DataSet.Tables("Productos").Rows(i)("Nombre_Cliente")
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    i = i + 1
                Loop

                Me.ProgressBar1.Visible = False

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepSaldoClientes.Document
                My.Application.DoEvents()
                ArepSaldoClientes.LblImpreso.Text = "Impreso: " & Format(Now, "Long Date")
                ArepSaldoClientes.DataSource = DataSet.Tables("TotalVentas")
                ArepSaldoClientes.Run(False)
                ViewerForm.Show()

                Me.Label1.Visible = True
                Me.DTPFechaIni.Visible = True
                Me.GroupVendedor.Visible = True


            Case "Reporte de Saldo de Clientes"
                Dim ArepSaldoClientes As New ArepSaldoClientes
                Dim SqlString As String, Registros As Double, CodigoCliente As String
                Dim oDataRow As DataRow, i As Double = 0, Debito As Double = 0, Credito As Double, SaldoInicial As Double
                Dim Moneda As String = "", Registros2 As Double, j As Double


                If Dir(RutaLogo) <> "" Then
                    ArepSaldoClientes.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepSaldoClientes.LblTitulo.Text = NombreEmpresa
                ArepSaldoClientes.LblDireccion.Text = DireccionEmpresa
                ArepSaldoClientes.LblRuc.Text = Ruc

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                DataSet.Reset()
                SqlString = "SELECT Clientes.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente, Facturas.SubTotal AS SaldoInicial, Facturas.IVA AS Debito, Facturas.NetoPagar AS Credito, Facturas.NetoPagar AS SaldoFinal FROM  Clientes INNER JOIN Facturas ON Clientes.Cod_Cliente = Facturas.Cod_Cliente WHERE (Clientes.Cod_Cliente = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalVentas")

                If Me.CmbClientes.Text = "" And Me.CmbClientes2.Text = "" Then
                    'SqlDatos = "SELECT DISTINCT SUM(Facturas.MontoCredito) AS MontoCredito, Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Facturas.Cod_Cliente, Clientes.Nombre_Cliente,Clientes.Apellido_Cliente ORDER BY Facturas.Cod_Cliente"
                    SqlDatos = "SELECT DISTINCT Nombre_Cliente, Apellido_Cliente, Cod_Cliente FROM  Clientes GROUP BY Nombre_Cliente, Apellido_Cliente, Cod_Cliente  ORDER BY Clientes.Cod_Cliente"
                Else
                    'SqlDatos = "SELECT DISTINCT SUM(Facturas.MontoCredito) AS MontoCredito, Facturas.Cod_Cliente, Clientes.Nombre_Cliente, Clientes.Apellido_Cliente FROM Facturas INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura <= CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Facturas.Cod_Cliente, Clientes.Nombre_Cliente,Clientes.Apellido_Cliente HAVING (Facturas.Cod_Cliente BETWEEN '" & Me.CmbClientes.Text & "' AND '" & Me.CmbClientes2.Text & "') ORDER BY Facturas.Cod_Cliente"
                    SqlDatos = "SELECT DISTINCT Nombre_Cliente, Apellido_Cliente, Cod_Cliente FROM  Clientes GROUP BY Nombre_Cliente, Apellido_Cliente, Cod_Cliente HAVING  (Clientes.Cod_Cliente BETWEEN '" & Me.CmbClientes.Text & "' AND '" & Me.CmbClientes2.Text & "') ORDER BY Clientes.Cod_Cliente"
                End If

                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos

                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registros = DataSet.Tables("Productos").Rows.Count
                i = 0
                Do While Registros > i
                    CodigoCliente = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")

                    If Me.OptCordobas.Checked = True Then
                        Moneda = "Cordobas"
                    Else
                        Moneda = "Dolares"
                    End If
                    Credito = ConsultaCreditosCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda)
                    Debito = ConsultaDebitosCliente(CodigoCliente, Me.DTPFechaIni.Value, Me.DTPFechaFin.Value, Moneda)
                    SaldoInicial = SaldoInicialCliente(CodigoCliente, Me.DTPFechaIni.Value, Moneda)

                    'If CodigoCliente = "1144          " Then
                    '    CodigoCliente = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                    'End If


                    ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ''//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE DEBITO SIN FACTURAS //////////////////////////////////////////////////////
                    ''////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'SqlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Debito Clientes') AND (IndiceNota.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')  AND (Detalle_Nota.Numero_Factura = '0000')"

                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    'DataAdapter.Fill(DataSet, "NotaDB")
                    'Registros2 = DataSet.Tables("NotaDB").Rows.Count
                    'j = 0
                    'Do While Registros2 > j
                    '    Debito = Debito + DataSet.Tables("NotaDB").Rows(j)("Monto")

                    '    j = j + 1
                    'Loop

                    'DataSet.Tables("NotaDB").Reset()
                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////BUSCO SI EXISTEN NOTAS DE CREDITO SIN FACTURAS //////////////////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ''SQlString = "SELECT Detalle_Nota.*, NotaDebito.Tipo, IndiceNota.MonedaNota FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota WHERE  (NotaDebito.Tipo = 'Credito Clientes') AND (Detalle_Nota.Numero_Factura = '" & NumeroFactura & "')"
                    'SqlString = "SELECT Detalle_Nota.id_Detalle_Nota, Detalle_Nota.Numero_Nota, Detalle_Nota.Fecha_Nota, Detalle_Nota.Tipo_Nota, Detalle_Nota.CodigoNB, Detalle_Nota.Descripcion, Detalle_Nota.Numero_Factura, Detalle_Nota.Monto, NotaDebito.Tipo, IndiceNota.MonedaNota, IndiceNota.Fecha_Nota AS Expr1, IndiceNota.Tipo_Nota AS Expr2 FROM Detalle_Nota INNER JOIN NotaDebito ON Detalle_Nota.Tipo_Nota = NotaDebito.CodigoNB INNER JOIN IndiceNota ON Detalle_Nota.Numero_Nota = IndiceNota.Numero_Nota AND Detalle_Nota.Fecha_Nota = IndiceNota.Fecha_Nota AND Detalle_Nota.Tipo_Nota = IndiceNota.Tipo_Nota WHERE (NotaDebito.Tipo = 'Credito Clientes') AND (IndiceNota.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')  AND (Detalle_Nota.Numero_Factura = '0000')"

                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    'DataAdapter.Fill(DataSet, "NotaCR")
                    'Registros2 = DataSet.Tables("NotaCR").Rows.Count
                    'j = 0
                    'Do While Registros2 > j
                    '    Credito = Credito + DataSet.Tables("NotaCR").Rows(j)("Monto")

                    '    j = j + 1
                    'Loop
                    'DataSet.Tables("NotaCR").Reset()


                    ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ''//////////////////////////////////////BUSCO SI EXISTEN RECIBOS SIN FACTURAS //////////////////////////////////////////////////////
                    ''////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'SqlString = "SELECT  MAX(DetalleRecibo.CodReciboPago) AS CodReciboPago, MAX(DetalleRecibo.Fecha_Recibo) AS Fecha_Recibo, DetalleRecibo.Numero_Factura, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, Recibo.MonedaRecibo FROM DetalleRecibo INNER JOIN Recibo ON DetalleRecibo.CodReciboPago = Recibo.CodReciboPago AND DetalleRecibo.Fecha_Recibo = Recibo.Fecha_Recibo GROUP BY DetalleRecibo.Numero_Factura, Recibo.MonedaRecibo, Recibo.Cod_Cliente " & _
                    '            "HAVING (DetalleRecibo.Numero_Factura = '0') AND (Recibo.Cod_Cliente = '" & Me.CboCodigoCliente.Text & "')"


                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    'DataAdapter.Fill(DataSet, "Recibos")
                    'Registros2 = DataSet.Tables("Recibos").Rows.Count
                    'j = 0

                    'Do While Registros2 > j
                    '    Credito = Credito + DataSet.Tables("Recibos").Rows(j)("MontoPagado")
                    '    j = j + 1
                    'Loop
                    If Format(SaldoInicial + Debito + Credito, "##,##0.00") <> "0.00" Then
                        oDataRow = DataSet.Tables("TotalVentas").NewRow
                        oDataRow("Cod_Cliente") = DataSet.Tables("Productos").Rows(i)("Cod_Cliente")
                        oDataRow("Nombre_Cliente") = DataSet.Tables("Productos").Rows(i)("Nombre_Cliente") & " " & DataSet.Tables("Productos").Rows(i)("Apellido_Cliente")
                        oDataRow("SaldoInicial") = SaldoInicial
                        oDataRow("Debito") = Debito
                        oDataRow("Credito") = Credito
                        oDataRow("SaldoFinal") = SaldoInicial + Debito - Credito
                        DataSet.Tables("TotalVentas").Rows.Add(oDataRow)
                    End If

                    Me.Text = "Procesando: " & CodigoCliente & " " & DataSet.Tables("Productos").Rows(i)("Nombre_Cliente")
                    Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    i = i + 1
                Loop


                Me.ProgressBar1.Visible = False

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepSaldoClientes.Document
                My.Application.DoEvents()
                ArepSaldoClientes.LblImpreso.Text = "Impreso: " & Format(Now, "Long Date")
                ArepSaldoClientes.DataSource = DataSet.Tables("TotalVentas")
                ArepSaldoClientes.Run(False)
                ViewerForm.Show()

                Me.Label1.Visible = True
                Me.DTPFechaIni.Visible = True
                Me.GroupVendedor.Visible = True

            Case "Movimientos de Productos"
                Dim ArepMovimientoProductos As New ArepMovimientoProductos

                If Dir(RutaLogo) <> "" Then
                    ArepMovimientoProductos.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepMovimientoProductos.LblTitulo.Text = NombreEmpresa
                ArepMovimientoProductos.LblDireccion.Text = DireccionEmpresa
                ArepMovimientoProductos.LblRuc.Text = Ruc

                SqlDatos = "SELECT  Cod_Productos, Descripcion_Producto FROM Productos "
                If Me.CboCodProducto.Text = "" Then
                    If Me.CboCodProducto2.Text = "" Then
                        SqlDatos = SqlDatos & " ORDER BY Cod_Productos"
                    Else
                        SqlDatos = SqlDatos & " WHERE (Cod_Productos BETWEEN '" & CodigoInicio & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Cod_Productos"
                    End If
                ElseIf Me.CboCodProducto2.Text = "" Then
                    SqlDatos = SqlDatos & " WHERE (Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & CodigoFin & "') ORDER BY Cod_Productos"
                Else
                    SqlDatos = SqlDatos & " WHERE (Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Cod_Productos"
                End If


                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Movimientos")
                Me.ProgressBar.Maximum = DataSet.Tables("Movimientos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True

                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepMovimientoProductos.Document
                My.Application.DoEvents()
                ArepMovimientoProductos.DataSource = SQL
                ArepMovimientoProductos.Run(False)
                ViewerForm.Show()


            Case "Comprobantes de Caja General"
                Dim ArepComprobantesCaja As New ArepIngresoCaja
                Dim ArepInformeCaja As New ArepInformeCaja
                Dim SQlString As String = "", Registros As Double, i As Double, oDataRow As DataRow, Registros2 As Double = 0
                Dim Monto As Double = 0, NombreRubro As String = ""

                If Dir(RutaLogo) <> "" Then
                    ArepComprobantesCaja.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepComprobantesCaja.LblTitulo.Text = NombreEmpresa
                ArepComprobantesCaja.LblDireccion.Text = DireccionEmpresa
                ArepComprobantesCaja.LblRuc.Text = Ruc
                ArepComprobantesCaja.LblFecha.Text = "Desde " & Format(Fecha1, "dd/MM/yyyy") & " Hasta " & Format(Fecha2, "dd/MM/yyyy")

                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQlString = "SELECT Rubro.Nombre_Rubro, MAX(Detalle_MetodoFacturas.NombrePago) AS NombrePago, SUM(Detalle_MetodoFacturas.Monto * ROUND(Detalle_Facturas.TasaCambio, 2)) AS Monto, MAX(Facturas.MonedaFactura) AS MonedaFactura, MAX(Facturas.Numero_Factura) AS Numero_Factura FROM   Detalle_MetodoFacturas INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro WHERE (Facturas.FechaPago = CONVERT(DATETIME, '1900-01-01 00:00:00', 102)) AND (Facturas.FechaPago = CONVERT(DATETIME, '1900-01-01 00:00:00', 102)) GROUP BY Rubro.Nombre_Rubro HAVING  (MAX(Facturas.Numero_Factura) = N'-111121') ORDER BY Rubro.Nombre_Rubro DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalRecibidos")
                '*************************************************************************************************************************************************************************
                '//////////////////////CON ESTA CONSULTA BUSCO TODO LO RECIBIDO EN LAS FACTURAS ///////////////////////////////////////////////////////////////////////////////////////////
                '*************************************************************************************************************************************************************************
                'SqlDatos = "SELECT  Rubro.Nombre_Rubro, MAX(Detalle_MetodoFacturas.NombrePago) AS NombrePago, SUM(Detalle_MetodoFacturas.Monto * ROUND(Detalle_Facturas.TasaCambio, 2)) AS Monto, MAX(Facturas.MonedaFactura) AS MonedaFactura, MAX(Facturas.Numero_Factura) AS Numero_Factura FROM  Detalle_MetodoFacturas INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                '           "WHERE (Facturas.FechaPago = CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND Facturas.FechaPago = CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Rubro.Nombre_Rubro ORDER BY Rubro.Nombre_Rubro DESC"

                SqlDatos = "SELECT  Rubro.Nombre_Rubro, MAX(Detalle_MetodoFacturas.NombrePago) AS NombrePago, SUM(Detalle_MetodoFacturas.Monto * ROUND(Detalle_Facturas.TasaCambio, 2)) AS Montos, MAX(Facturas.MonedaFactura) AS MonedaFactura, MAX(Facturas.Numero_Factura) AS Numero_Factura, SUM(Detalle_Facturas.Importe * ROUND(Detalle_Facturas.TasaCambio, 2)) AS Monto FROM  Detalle_MetodoFacturas INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                           "WHERE (Facturas.FechaPago = CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102)) AND (Facturas.FechaPago = CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Rubro.Nombre_Rubro ORDER BY Rubro.Nombre_Rubro DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Facturas")
                Registros = DataSet.Tables("Facturas").Rows.Count
                i = 0
                Do While Registros > i
                    oDataRow = DataSet.Tables("TotalRecibidos").NewRow
                    oDataRow("Nombre_Rubro") = DataSet.Tables("Facturas").Rows(i)("Nombre_Rubro")
                    oDataRow("NombrePago") = DataSet.Tables("Facturas").Rows(i)("NombrePago")
                    oDataRow("Monto") = DataSet.Tables("Facturas").Rows(i)("Monto")
                    oDataRow("MonedaFactura") = DataSet.Tables("Facturas").Rows(i)("MonedaFactura")
                    oDataRow("Numero_Factura") = DataSet.Tables("Facturas").Rows(i)("Numero_Factura")
                    DataSet.Tables("TotalRecibidos").Rows.Add(oDataRow)
                    i = i + 1
                Loop




                '///////////////////////////////////BUSCO SI EL RUBRO YA FUE AGREGADO ////////////////////////////////////////7
                'Registros2 = DataSet.Tables("TotalRecibidos").Rows.Count
                'iPosicion = 0
                'Do While Registros2 > iPosicion

                '    NombreRubro = DataSet.Tables("TotalRecibidos").Rows(iPosicion)("Nombre_Rubro")
                '***************************************************************************************************************************+
                '//////////////////////CON ESTA CONSULTA BUSTO TODO EL DINERO  EN RECIBOS/////////////////////////////////////////////////////
                '****************************************************************************************************************************
                SQlString = "SELECT  MAX(Recibo.MonedaRecibo) AS MonedaRecibido, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, MAX(Rubro.Codigo_Rubro) AS Codigo_Rubro, Rubro.Nombre_Rubro, MAX(DetalleRecibo.TasaCambio) AS TasaCambio, SUM(DetalleRecibo.MontoPagado * DetalleRecibo.TasaCambio) AS Monto FROM Recibo INNER JOIN DetalleRecibo ON Recibo.CodReciboPago = DetalleRecibo.CodReciboPago AND Recibo.Fecha_Recibo = DetalleRecibo.Fecha_Recibo INNER JOIN Facturas ON DetalleRecibo.Numero_Factura = Facturas.Numero_Factura INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa  GROUP BY Recibo.Fecha_Recibo, Rubro.Nombre_Rubro  " & _
                            "HAVING (Recibo.Fecha_Recibo BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102))  ORDER BY MAX(Rubro.Codigo_Rubro), Recibo.Fecha_Recibo "
                'AND (Rubro.Nombre_Rubro = '" & NombreRubro & "')
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Recibos")
                Registros = DataSet.Tables("Recibos").Rows.Count
                i = 0
                Do While Registros > i

                    NombreRubro = "Nombre_Rubro=" & DataSet.Tables("Recibos").Rows(i)("Nombre_Rubro")
                    'DataSet.Tables("TotalRecibidos").Rows.Find(NombreRubro)


                    'If DataSet.Tables("Recibos").Rows(i)("Nombre_Rubro") = DataSet.Tables("TotalRecibidos").Rows(iPosicion)("Nombre_Rubro") Then
                    '    '/////////////////////////////////////////// SI EXISTE LO EDITO ///////////////////////////////////////////
                    '    Monto = DataSet.Tables("TotalRecibidos").Rows(iPosicion)("Monto")
                    '    oDataRow = DataSet.Tables("TotalRecibidos").Rows(iPosicion)
                    '    oDataRow("Monto") = Monto + DataSet.Tables("Recibos").Rows(i)("Monto")
                    'Else
                    '//////////////////////////////////////SI NO EXISTE LO AGREGO ///////////////////////////////////////////////
                    oDataRow = DataSet.Tables("TotalRecibidos").NewRow
                    oDataRow("Nombre_Rubro") = DataSet.Tables("Recibos").Rows(i)("Nombre_Rubro")
                    oDataRow("NombrePago") = DataSet.Tables("Recibos").Rows(i)("Nombre_Rubro")
                    oDataRow("Monto") = DataSet.Tables("Recibos").Rows(i)("Monto")
                    oDataRow("MonedaFactura") = DataSet.Tables("Recibos").Rows(i)("MonedaRecibido")
                    oDataRow("Numero_Factura") = DataSet.Tables("Recibos").Rows(i)("Codigo_Rubro")
                    DataSet.Tables("TotalRecibidos").Rows.Add(oDataRow)
                    'End If

                    i = i + 1
                Loop



                DataSet.Tables("Recibos").Clear()
                'iPosicion = iPosicion + 1
                'Loop

                '***************************************************************************************************************************+
                '//////////////////////BUSCO LOS RECIBOS SIN FACTURAS/////////////////////////////////////////////////////
                '****************************************************************************************************************************
                SQlString = "SELECT MAX(Recibo.MonedaRecibo) AS MonedaRecibido, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, MAX(DetalleRecibo.TasaCambio) AS TasaCambio, SUM(DetalleRecibo.MontoPagado * DetalleRecibo.TasaCambio) AS Monto, DetalleRecibo.Numero_Factura, DetalleRecibo.Descripcion, MAX(DetalleRecibo.NombrePago) AS NombrePago FROM  Recibo INNER JOIN DetalleRecibo ON Recibo.CodReciboPago = DetalleRecibo.CodReciboPago AND Recibo.Fecha_Recibo = DetalleRecibo.Fecha_Recibo INNER JOIN  TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa GROUP BY Recibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.Descripcion  " & _
                            "HAVING (Recibo.Fecha_Recibo BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (DetalleRecibo.Numero_Factura = '0') ORDER BY Recibo.Fecha_Recibo"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "RecibosFac")
                If DataSet.Tables("RecibosFac").Rows.Count <> 0 Then
                    oDataRow = DataSet.Tables("TotalRecibidos").NewRow
                    oDataRow("Nombre_Rubro") = DataSet.Tables("RecibosFac").Rows(0)("Descripcion") & "Recibo"
                    oDataRow("NombrePago") = DataSet.Tables("RecibosFac").Rows(0)("NombrePago")
                    oDataRow("Monto") = DataSet.Tables("RecibosFac").Rows(0)("Monto")
                    oDataRow("MonedaFactura") = DataSet.Tables("RecibosFac").Rows(0)("MonedaRecibido")
                    oDataRow("Numero_Factura") = 0
                    DataSet.Tables("TotalRecibidos").Rows.Add(oDataRow)
                End If
                DataSet.Tables("RecibosFac").Clear()

                'SqlDatos = "SELECT Rubro.Nombre_Rubro, Detalle_MetodoFacturas.NombrePago, SUM(Detalle_MetodoFacturas.Monto) AS Monto, MAX(Detalle_Facturas.Numero_Factura) AS Numero_Factura, Detalle_Facturas.Fecha_Factura, Facturas.MetodoPago FROM  Detalle_Facturas INNER JOIN  Detalle_MetodoFacturas ON Detalle_Facturas.Numero_Factura = Detalle_MetodoFacturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Detalle_MetodoFacturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Detalle_MetodoFacturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro INNER JOIN  Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura GROUP BY Rubro.Nombre_Rubro, Detalle_MetodoFacturas.NombrePago, Detalle_Facturas.Fecha_Factura, Facturas.MetodoPago  " & _
                '           "HAVING (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME,'" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Rubro.Nombre_Rubro DESC "

                'SqlDatos = "SELECT Rubro.Nombre_Rubro, Detalle_MetodoFacturas.NombrePago, SUM(Detalle_MetodoFacturas.Monto * Detalle_Facturas.TasaCambio) AS Monto, MAX(Detalle_Facturas.Numero_Factura) AS Numero_Factura, Detalle_Facturas.Fecha_Factura, Facturas.MetodoPago, MAX(Detalle_Facturas.TasaCambio) AS Expr1 FROM  Detalle_Facturas INNER JOIN Detalle_MetodoFacturas ON Detalle_Facturas.Numero_Factura = Detalle_MetodoFacturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Detalle_MetodoFacturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Detalle_MetodoFacturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  GROUP BY Rubro.Nombre_Rubro, Detalle_MetodoFacturas.NombrePago, Detalle_Facturas.Fecha_Factura, Facturas.MetodoPago " & _
                '           "HAVING  (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Rubro.Nombre_Rubro DESC"
                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                'ArepComprobantesCaja.DataSource = SQL
                ArepComprobantesCaja.DataSource = DataSet.Tables("TotalRecibidos")
                ViewerForm.arvMain.Document = ArepComprobantesCaja.Document
                My.Application.DoEvents()
                ArepComprobantesCaja.Run(False)
                ViewerForm.Show()

            Case "Informe de Caja General"
                Dim ArepInformeCaja As New ArepInformeCaja
                Dim SQlString As String = "", Registros As Double, i As Double, oDataRow As DataRow, iPosicion As Double = 0, Registros2 As Double = 0
                Dim Monto As Double = 0, NombreRubro As String = ""

                If Dir(RutaLogo) <> "" Then
                    ArepInformeCaja.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepInformeCaja.LblTitulo.Text = NombreEmpresa
                ArepInformeCaja.LblDireccion.Text = DireccionEmpresa
                ArepInformeCaja.LblRuc.Text = Ruc
                ArepInformeCaja.LblFecha.Text = "Desde " & Format(Fecha1, "dd/MM/yyyy") & " Hasta " & Format(Fecha2, "dd/MM/yyyy")
                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQlString = "SELECT Rubro.Nombre_Rubro, MAX(Detalle_MetodoFacturas.NombrePago) AS NombrePago, SUM(Detalle_MetodoFacturas.Monto * ROUND(Detalle_Facturas.TasaCambio, 2)) AS Monto, MAX(Facturas.MonedaFactura) AS MonedaFactura, MAX(Facturas.Numero_Factura) AS Numero_Factura FROM   Detalle_MetodoFacturas INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro WHERE (Facturas.FechaPago = CONVERT(DATETIME, '1900-01-01 00:00:00', 102)) AND (Facturas.FechaPago = CONVERT(DATETIME, '1900-01-01 00:00:00', 102)) GROUP BY Rubro.Nombre_Rubro HAVING  (MAX(Facturas.Numero_Factura) = N'-111121') ORDER BY Rubro.Nombre_Rubro DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalRecibidos")
                '*************************************************************************************************************************************************************************
                '//////////////////////CON ESTA CONSULTA BUSCO TODO LO RECIBIDO EN LAS FACTURAS ///////////////////////////////////////////////////////////////////////////////////////////
                '*************************************************************************************************************************************************************************
                'SqlDatos = "SELECT  Rubro.Nombre_Rubro, MAX(Detalle_MetodoFacturas.NombrePago) AS NombrePago, SUM(Detalle_MetodoFacturas.Monto * ROUND(Detalle_Facturas.TasaCambio, 2)) AS Monto, MAX(Facturas.MonedaFactura) AS MonedaFactura, MAX(Facturas.Numero_Factura) AS Numero_Factura FROM  Detalle_MetodoFacturas INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                '           "WHERE (Facturas.FechaPago = CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND Facturas.FechaPago = CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Rubro.Nombre_Rubro ORDER BY Rubro.Nombre_Rubro DESC"

                SqlDatos = "SELECT  Rubro.Nombre_Rubro, MAX(Detalle_MetodoFacturas.NombrePago) AS NombrePago, SUM(Detalle_MetodoFacturas.Monto * ROUND(Detalle_Facturas.TasaCambio, 2)) AS Montos, MAX(Facturas.MonedaFactura) AS MonedaFactura, MAX(Facturas.Numero_Factura) AS Numero_Factura, SUM(Detalle_Facturas.Importe * ROUND(Detalle_Facturas.TasaCambio, 2)) AS Monto FROM  Detalle_MetodoFacturas INNER JOIN Facturas ON Detalle_MetodoFacturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_MetodoFacturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_MetodoFacturas.Tipo_Factura = Facturas.Tipo_Factura INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                           "WHERE (Facturas.FechaPago = CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102)) AND (Facturas.FechaPago = CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Rubro.Nombre_Rubro ORDER BY Rubro.Nombre_Rubro DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Facturas")
                Registros = DataSet.Tables("Facturas").Rows.Count
                i = 0
                Do While Registros > i
                    oDataRow = DataSet.Tables("TotalRecibidos").NewRow
                    oDataRow("Nombre_Rubro") = DataSet.Tables("Facturas").Rows(i)("Nombre_Rubro")
                    oDataRow("NombrePago") = DataSet.Tables("Facturas").Rows(i)("NombrePago")
                    oDataRow("Monto") = DataSet.Tables("Facturas").Rows(i)("Monto")
                    oDataRow("MonedaFactura") = DataSet.Tables("Facturas").Rows(i)("MonedaFactura")
                    oDataRow("Numero_Factura") = DataSet.Tables("Facturas").Rows(i)("Numero_Factura")
                    DataSet.Tables("TotalRecibidos").Rows.Add(oDataRow)
                    i = i + 1
                Loop




                '///////////////////////////////////BUSCO SI EL RUBRO YA FUE AGREGADO ////////////////////////////////////////7
                'Registros2 = DataSet.Tables("TotalRecibidos").Rows.Count
                'iPosicion = 0
                'Do While Registros2 > iPosicion

                '    NombreRubro = DataSet.Tables("TotalRecibidos").Rows(iPosicion)("Nombre_Rubro")
                '***************************************************************************************************************************+
                '//////////////////////CON ESTA CONSULTA BUSTO TODO EL DINERO  EN RECIBOS/////////////////////////////////////////////////////
                '****************************************************************************************************************************
                SQlString = "SELECT  MAX(Recibo.MonedaRecibo) AS MonedaRecibido, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, MAX(Rubro.Codigo_Rubro) AS Codigo_Rubro, Rubro.Nombre_Rubro, MAX(DetalleRecibo.TasaCambio) AS TasaCambio, SUM(DetalleRecibo.MontoPagado * DetalleRecibo.TasaCambio) AS Monto FROM Recibo INNER JOIN DetalleRecibo ON Recibo.CodReciboPago = DetalleRecibo.CodReciboPago AND Recibo.Fecha_Recibo = DetalleRecibo.Fecha_Recibo INNER JOIN Facturas ON DetalleRecibo.Numero_Factura = Facturas.Numero_Factura INNER JOIN Detalle_Facturas ON Facturas.Numero_Factura = Detalle_Facturas.Numero_Factura AND Facturas.Fecha_Factura = Detalle_Facturas.Fecha_Factura AND Facturas.Tipo_Factura = Detalle_Facturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro INNER JOIN TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa  GROUP BY Recibo.Fecha_Recibo, Rubro.Nombre_Rubro  " & _
                            "HAVING (Recibo.Fecha_Recibo BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102))  ORDER BY MAX(Rubro.Codigo_Rubro), Recibo.Fecha_Recibo "
                'AND (Rubro.Nombre_Rubro = '" & NombreRubro & "')
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "Recibos")
                Registros = DataSet.Tables("Recibos").Rows.Count
                i = 0
                Do While Registros > i

                    NombreRubro = "Nombre_Rubro=" & DataSet.Tables("Recibos").Rows(i)("Nombre_Rubro")
                    'DataSet.Tables("TotalRecibidos").Rows.Find(NombreRubro)


                    'If DataSet.Tables("Recibos").Rows(i)("Nombre_Rubro") = DataSet.Tables("TotalRecibidos").Rows(iPosicion)("Nombre_Rubro") Then
                    '    '/////////////////////////////////////////// SI EXISTE LO EDITO ///////////////////////////////////////////
                    '    Monto = DataSet.Tables("TotalRecibidos").Rows(iPosicion)("Monto")
                    '    oDataRow = DataSet.Tables("TotalRecibidos").Rows(iPosicion)
                    '    oDataRow("Monto") = Monto + DataSet.Tables("Recibos").Rows(i)("Monto")
                    'Else
                    '//////////////////////////////////////SI NO EXISTE LO AGREGO ///////////////////////////////////////////////
                    Monto = DataSet.Tables("Recibos").Rows(i)("Monto")
                    oDataRow = DataSet.Tables("TotalRecibidos").NewRow
                    oDataRow("Nombre_Rubro") = DataSet.Tables("Recibos").Rows(i)("Nombre_Rubro")
                    oDataRow("NombrePago") = DataSet.Tables("Recibos").Rows(i)("Nombre_Rubro")
                    oDataRow("Monto") = DataSet.Tables("Recibos").Rows(i)("Monto")
                    oDataRow("MonedaFactura") = DataSet.Tables("Recibos").Rows(i)("MonedaRecibido")
                    oDataRow("Numero_Factura") = DataSet.Tables("Recibos").Rows(i)("Codigo_Rubro")
                    DataSet.Tables("TotalRecibidos").Rows.Add(oDataRow)
                    'End If

                    i = i + 1
                Loop



                DataSet.Tables("Recibos").Clear()
                'iPosicion = iPosicion + 1
                'Loop

                '***************************************************************************************************************************+
                '//////////////////////BUSCO LOS RECIBOS SIN FACTURAS/////////////////////////////////////////////////////
                '****************************************************************************************************************************
                SQlString = "SELECT MAX(Recibo.MonedaRecibo) AS MonedaRecibido, SUM(DetalleRecibo.MontoPagado) AS MontoPagado, MAX(DetalleRecibo.TasaCambio) AS TasaCambio, SUM(DetalleRecibo.MontoPagado * DetalleRecibo.TasaCambio) AS Monto, DetalleRecibo.Numero_Factura, DetalleRecibo.Descripcion, MAX(DetalleRecibo.NombrePago) AS NombrePago FROM  Recibo INNER JOIN DetalleRecibo ON Recibo.CodReciboPago = DetalleRecibo.CodReciboPago AND Recibo.Fecha_Recibo = DetalleRecibo.Fecha_Recibo INNER JOIN  TasaCambio ON Recibo.Fecha_Recibo = TasaCambio.FechaTasa GROUP BY Recibo.Fecha_Recibo, DetalleRecibo.Numero_Factura, DetalleRecibo.Descripcion  " & _
                            "HAVING (Recibo.Fecha_Recibo BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (DetalleRecibo.Numero_Factura = '0') ORDER BY Recibo.Fecha_Recibo"
                DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                DataAdapter.Fill(DataSet, "RecibosFac")
                If DataSet.Tables("RecibosFac").Rows.Count <> 0 Then
                    oDataRow = DataSet.Tables("TotalRecibidos").NewRow
                    oDataRow("Nombre_Rubro") = DataSet.Tables("RecibosFac").Rows(0)("Descripcion") & "Recibo"
                    oDataRow("NombrePago") = DataSet.Tables("RecibosFac").Rows(0)("NombrePago")
                    oDataRow("Monto") = DataSet.Tables("RecibosFac").Rows(0)("Monto")
                    oDataRow("MonedaFactura") = DataSet.Tables("RecibosFac").Rows(0)("MonedaRecibido")
                    oDataRow("Numero_Factura") = 0
                    DataSet.Tables("TotalRecibidos").Rows.Add(oDataRow)
                End If
                DataSet.Tables("RecibosFac").Clear()

                '/////////////////////////////////////////////AHORA RECORRO LAS FACTURAS Y RECIBOS /////////////////////////////////////////////////






                'SqlDatos = "SELECT Rubro.Nombre_Rubro, Detalle_MetodoFacturas.NombrePago, SUM(Detalle_MetodoFacturas.Monto * Detalle_Facturas.TasaCambio) AS Monto, MAX(Detalle_Facturas.Numero_Factura) AS Numero_Factura, Detalle_Facturas.Fecha_Factura, Facturas.MetodoPago, MAX(Detalle_Facturas.TasaCambio) AS Expr1 FROM  Detalle_Facturas INNER JOIN Detalle_MetodoFacturas ON Detalle_Facturas.Numero_Factura = Detalle_MetodoFacturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Detalle_MetodoFacturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Detalle_MetodoFacturas.Tipo_Factura INNER JOIN Productos ON Detalle_Facturas.Cod_Producto = Productos.Cod_Productos INNER JOIN Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro INNER JOIN Facturas ON Detalle_Facturas.Numero_Factura = Facturas.Numero_Factura AND Detalle_Facturas.Fecha_Factura = Facturas.Fecha_Factura AND Detalle_Facturas.Tipo_Factura = Facturas.Tipo_Factura  GROUP BY Rubro.Nombre_Rubro, Detalle_MetodoFacturas.NombrePago, Detalle_Facturas.Fecha_Factura, Facturas.MetodoPago " & _
                '           "HAVING  (Detalle_Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) ORDER BY Rubro.Nombre_Rubro DESC"
                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos

                Dim ViewerForm As New FrmViewer()
                'ArepInformeCaja.DataSource = SQL
                ArepInformeCaja.DataSource = DataSet.Tables("TotalRecibidos")
                ViewerForm.arvMain.Document = ArepInformeCaja.Document
                My.Application.DoEvents()
                ArepInformeCaja.Run(False)
                ViewerForm.Show()

            Case "Reporte de Kardex"

                Dim ArepReporteKardex As New ArepKardex
                Dim ArepReporteKardexLinea As New ArepKardexLinea
                Dim SQLString As String, Registro As Double = 0, Iposicion As Double = 0
                Dim CodProducto As String, Compras As Double, FechaIni As String, FechaFin As String, Ventas As Double
                Dim CostoPromedio As Double, Existencia As Double, Inicial As Double, CodBodega As String, Total As Double = 0
                Dim oDataRow As DataRow, NombreProducto As String, NombreBodega As String, Cadena As String

                'If Dir(RutaLogo) <> "" Then
                '    ArepReporteKardex.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                '    ArepReporteKardexLinea.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                'End If

                ArepReporteKardex.LblTitulo.Text = NombreEmpresa
                ArepReporteKardex.LblDireccion.Text = DireccionEmpresa
                ArepReporteKardex.LblRuc.Text = Ruc

                If Me.CmbAgrupado.Text = "" Then
                    MsgBox("Se necesita Agrupado", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If
                '*******************************************************************************************************************************
                '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
                '*******************************************************************************************************************************
                SQLString = "SELECT  Cod_Productos, Descripcion_Producto, Cod_Linea AS Cod_Bodega, Cod_Cuenta_Inventario AS Nombre_Bodega, Cod_Cuenta_Costo AS Inicial, Cod_Cuenta_Ventas AS Entrada, Cod_Cuenta_GastoAjuste AS Salida, Cod_Cuenta_IngresoAjuste AS Saldo, Unidad_Medida AS CostoVenta, Precio_Venta AS InicialD, Precio_Lista AS EntradaD, Descuento AS SalidaD, Existencia_Negativa AS SaldoD  FROM Productos WHERE (Cod_Productos = N'-1000000')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
                DataAdapter.Fill(DataSet, "TotalKARDEX")


                SqlDatos = ""
                Select Case Me.CmbAgrupado.Text
                    Case "Codigo Producto"
                        If Me.CboCodProducto.Text = "" Then
                            If Me.CboCodProducto2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Productos"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & CodigoInicio & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                            End If
                        ElseIf Me.CboCodProducto2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & CodigoFin & "') ORDER BY Productos.Cod_Productos"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                        End If

                    Case "Linea"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  ORDER BY Productos.Cod_Linea"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo)  AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Linea"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                        End If


                    Case "Bodega"
                        If Me.CboCodProducto.Text = "" And Me.CboCodProducto2.Text = "" Then
                            If Me.CmbRango1.Text = "" Then
                                If Me.CmbRango2.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                End If
                            ElseIf Me.CmbRango2.Text = "" Then
                                If Me.CmbRango1.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                End If
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            End If
                        Else

                            Cadena = " AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            If Me.CmbRango1.Text = "" Then
                                If Me.CmbRango2.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) " & Cadena
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                                End If
                            ElseIf Me.CmbRango2.Text = "" Then
                                If Me.CmbRango1.Text = "" Then
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                                Else
                                    SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                                End If
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Tipo_Producto FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') " & Cadena
                            End If
                        End If

                    Case "Rubro"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                           "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"

                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Rubro"
                        Else
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Tipo_Producto, Productos.Descripcion_Producto, Productos.Ubicacion, Productos.Cod_Linea, Productos.Cod_Cuenta_Inventario, Productos.Cod_Cuenta_Costo, Productos.Cod_Cuenta_Ventas, Productos.Cod_Cuenta_GastoAjuste, Productos.Cod_Cuenta_IngresoAjuste, Productos.Unidad_Medida, Productos.Precio_Venta, Productos.Precio_Lista, Productos.Descuento, Productos.Existencia_Negativa, Productos.Cod_Iva, Productos.Activo, Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar, Productos.Ultimo_Precio_Venta, Productos.Ultimo_Precio_Compra, Productos.Existencia_Dinero, Productos.Existencia_Unidades, Productos.Existencia_DineroDolar, Productos.Minimo, Productos.Reorden, Productos.Nota, Productos.CodComponente, Productos.Cod_Rubro, Rubro.Nombre_Rubro FROM Productos INNER JOIN  Rubro ON Productos.Cod_Rubro = Rubro.Codigo_Rubro  " & _
                                       "WHERE  (Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Rubro BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Rubro"
                        End If



                End Select

                '*****************************************************************************************************************************************
                '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
                '*****************************************************************************************************************************************
                DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
                Me.ProgressBar.Minimum = 0
                Me.ProgressBar.Value = 0
                Me.ProgressBar.Visible = True
                Registro = DataSet.Tables("Productos").Rows.Count
                Iposicion = 0
                Do While Iposicion < Registro


                    FechaIni = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd")
                    FechaFin = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd")
                    CodProducto = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Productos")
                    NombreProducto = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Producto")
                    NombreBodega = DataSet.Tables("Productos").Rows(Iposicion)("Descripcion_Linea")
                    CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")
                    '/////////////////ESTE ES EL COSTO PROMEDIO GENERAL ////////////////////
                    'CostoPromedio = DataSet.Tables("Productos").Rows(Iposicion)("Costo_Promedio")

                    If Me.CmbAgrupado.Text = "Bodega" Then
                        CodBodega = DataSet.Tables("Productos").Rows(Iposicion)("Cod_Linea")

                        Compras = Format(BuscaCompraBodega(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        Ventas = Format(BuscaVentaBodega(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        'Inicial = Format(BuscaInventarioInicialBodegaMov(CodProducto, FechaIni, FechaFin, CodBodega), "####0.00")
                        Inicial = Format(BuscaInventarioInicialBodega(CodProducto, FechaIni, CodBodega), "####0.00")
                        Existencia = Inicial + Compras - Ventas

                        CostoPromedio = CostoPromedioKardexBodega(CodProducto, FechaFin, CodBodega)
                        'CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)

                    Else
                        CodBodega = 1
                        CostoPromedio = CostoPromedioKardex(CodProducto, FechaFin)
                        Compras = Format(BuscaCompra(CodProducto, FechaIni, FechaFin), "####0.00")
                        Ventas = Format(BuscaVenta(CodProducto, FechaIni, FechaFin), "####0.00")
                        Inicial = Format(BuscaInventarioInicial(CodProducto, FechaIni), "####0.00")
                        Existencia = Inicial + Compras - Ventas
                    End If


                    'Me.TxtInicialM.Text = Format(Inicial * CostoPromedio, "##,##0.00")
                    'Me.TxtEntradaM.Text = Format(Compras * CostoPromedio, "##,##0.00")
                    'Me.TxtSalidaM.Text = Format(Ventas * CostoPromedio, "##,##0.00")
                    'Me.TxtSaldoM.Text = Format(Existencia * CostoPromedio, "##,##0.00")


                    ''///////////////////////////////SUMO LAS VARIABLES ///////////////////////////////////////
                    'TotalInicial = TotalInicial + Inicial
                    'TotalCompras = TotalCompras + Compras
                    'TotalVentas = TotalVentas + Ventas
                    'TotalExistencia = TotalInicial + TotalCompras - TotalVentas

                    'TotalInicialM = TotalInicialM + (Inicial * CostoPromedio)
                    'TotalComprasM = TotalComprasM + (Compras * CostoPromedio)
                    'TotalVentasM = TotalVentasM + (Ventas * CostoPromedio)
                    'TotalExistenciaM = TotalExistenciaM + (Existencia * CostoPromedio)


                    'MontoSalida = Ventas * CostoPromedio
                    'MontoSalidaD = Ventas * CostoPromedioDolar
                    If DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Descuento" And DataSet.Tables("Productos").Rows(Iposicion)("Tipo_Producto") <> "Servicio" Then
                        'If (Inicial + Compras + Ventas) <> 0 Then
                        If Format(MontoInicial + MontoEntrada + MontoSalida, "##,##0.00") <> "0.00" Then
                            oDataRow = DataSet.Tables("TotalKARDEX").NewRow
                            oDataRow("Cod_Productos") = CodProducto
                            oDataRow("Descripcion_Producto") = NombreProducto
                            oDataRow("Cod_Bodega") = CodBodega
                            oDataRow("Nombre_Bodega") = NombreBodega
                            oDataRow("Inicial") = Inicial
                            oDataRow("Entrada") = Compras
                            oDataRow("Salida") = Ventas
                            oDataRow("Saldo") = Existencia
                            If Me.OptCordobas.Checked = True Then
                                oDataRow("CostoVenta") = CostoPromedio
                                oDataRow("InicialD") = MontoInicial 'Inicial * CostoPromedio  
                                oDataRow("EntradaD") = MontoEntrada 'Compras * CostoPromedio 
                                oDataRow("SalidaD") = MontoSalida  'MontoSalida
                                'If Existencia <> 0 Then
                                'If (MontoInicial + MontoEntrada - MontoSalida) > 1 Then
                                oDataRow("SaldoD") = MontoInicial + MontoEntrada - MontoSalida  'Existencia * CostoPromedio
                                'Else
                                '    oDataRow("SaldoD") = 0
                                'End If
                                'End If
                            Else
                                oDataRow("CostoVenta") = CostoPromedioDolar
                                oDataRow("InicialD") = MontoInicialD
                                oDataRow("EntradaD") = MontoEntradaD
                                oDataRow("SalidaD") = MontoSalidaD
                                'If Existencia <> 0 Then
                                '    If (MontoInicialD + MontoEntradaD - MontoSalidaD) > 1 Then
                                oDataRow("SaldoD") = MontoInicialD + MontoEntradaD - MontoSalidaD
                                '    Else
                                'oDataRow("SaldoD") = 0
                                '    End If
                                'End If
                            End If
                            DataSet.Tables("TotalKARDEX").Rows.Add(oDataRow)
                        End If
                    End If


                    Me.Text = "Procesando: " & CodProducto

                    If Me.ProgressBar.Maximum <> 0 Then
                        Me.ProgressBar.Value = Me.ProgressBar.Value + 1
                    End If

                    My.Application.DoEvents()



                    Iposicion = Iposicion + 1
                Loop






                'SQL.ConnectionString = Conexion
                'SQL.SQL = SqlDatos




                If Me.CmbAgrupado.Text = "Codigo Producto" Then
                    ArepReporteKardex.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepReporteKardex.LblTitulo.Text = NombreEmpresa
                    ArepReporteKardex.LblDireccion.Text = DireccionEmpresa
                    ArepReporteKardex.LblRuc.Text = Ruc
                    ArepReporteKardex.DataSource = SQL
                    ArepReporteKardex.Document.Name = "KARDEX POR PRODUCTOS"
                    ArepReporteKardex.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepReporteKardex.Document
                    My.Application.DoEvents()
                    ArepReporteKardex.Run(False)
                    ViewerForm.Show()

                    'ArepActividadProducto.Show()
                ElseIf Me.CmbAgrupado.Text = "Linea" Then
                    ArepReporteKardexLinea.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepReporteKardexLinea.LblTitulo.Text = NombreEmpresa
                    ArepReporteKardexLinea.LblDireccion.Text = DireccionEmpresa
                    ArepReporteKardexLinea.LblRuc.Text = Ruc
                    ArepReporteKardexLinea.DataSource = SQL
                    ArepReporteKardexLinea.Document.Name = "ACTIVIDAD PRODUCTOS POR LINEA"
                    ArepReporteKardexLinea.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepReporteKardexLinea.Document
                    My.Application.DoEvents()
                    ArepReporteKardexLinea.Run(False)
                    ViewerForm.Show()
                    'ArepActividadProductoLinea.Show()
                ElseIf Me.CmbAgrupado.Text = "Bodega" Then
                    ArepReporteKardexLinea.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepReporteKardexLinea.LblTitulo.Text = NombreEmpresa
                    ArepReporteKardexLinea.LblDireccion.Text = DireccionEmpresa
                    ArepReporteKardexLinea.LblRuc.Text = Ruc
                    'ArepReporteKardexLinea.DataSource = SQL
                    ArepReporteKardexLinea.Document.Name = "ACTIVIDAD PRODUCTOS POR BODEGA"
                    ArepReporteKardexLinea.LblRango.Text = "REPORTE DE INVENTARIO AL: " & Me.DTPFechaFin.Value
                    ArepReporteKardexLinea.LblCodigo.Text = "Codigo Bodega"
                    ArepReporteKardexLinea.LblNombre.Text = "Nombre Bodega"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepReporteKardexLinea.Document
                    My.Application.DoEvents()
                    ArepReporteKardexLinea.Run(False)
                    ViewerForm.Show()
                    'ArepActividadProductoLinea.Show()
                ElseIf Me.CmbAgrupado.Text = "Rubro" Then
                    ArepReporteKardexLinea.DataSource = DataSet.Tables("TotalKARDEX")
                    ArepReporteKardexLinea.LblTitulo.Text = NombreEmpresa
                    ArepReporteKardexLinea.LblDireccion.Text = DireccionEmpresa
                    ArepReporteKardexLinea.LblRuc.Text = Ruc
                    ArepReporteKardexLinea.DataSource = SQL
                    ArepReporteKardexLinea.Document.Name = "ACTIVIDAD PRODUCTOS POR RUBRO"
                    ArepReporteKardexLinea.LblCodigo.Text = "Codigo Rubro"
                    ArepReporteKardexLinea.LblNombre.Text = "Nombre Rubro"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepReporteKardexLinea.Document
                    My.Application.DoEvents()
                    ArepReporteKardexLinea.Run(False)
                    ViewerForm.Show()

                End If

            Case "Reporte Grafico de Ventas x Vendedor"

                Dim ArepReporteVentasVendedor As New ArepVentasVendedor

                If Dir(RutaLogo) <> "" Then
                    ArepReporteVentasVendedor.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepReporteVentasVendedor.LblTitulo.Text = NombreEmpresa
                ArepReporteVentasVendedor.LblDireccion.Text = DireccionEmpresa
                ArepReporteVentasVendedor.LblRuc.Text = Ruc
                ArepReporteVentasVendedor.LblRango.Text = "DESDE: " & Format(Fecha1, "dd/MM/yyyy") & "       HASTA: " & Format(Fecha2, "dd/MM/yyyy")
                'SQlDatosSuma = "SELECT MAX(Vendedores.Cod_Vendedor) AS Expr1, MAX(Vendedores.Nombre_Vendedor + N' ' + Vendedores.Apellido_Vendedor) AS NombreVendedor, SUM(Facturas.SubTotal) AS MontoVendido FROM  Vendedores INNER JOIN Facturas ON Vendedores.Cod_Vendedor = Facturas.Cod_Vendedor "
                If Me.OptDolares.Checked = True Then
                    SQlDatosSuma = "SELECT MAX(Vendedores.Cod_Vendedor) AS Expr1, MAX(Vendedores.Nombre_Vendedor + N' ' + Vendedores.Apellido_Vendedor) AS NombreVendedor, SUM(CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal ELSE Facturas.SubTotal / TasaCambio.MontoTasa END) AS MontoVendido FROM Vendedores INNER JOIN Facturas ON Vendedores.Cod_Vendedor = Facturas.Cod_Vendedor INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                   "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102))"

                    SqlDatos = "SELECT Vendedores.Cod_Vendedor, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS NombreVendedor, SUM(CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal ELSE Facturas.SubTotal / TasaCambio.MontoTasa END) AS MontoVendido FROM  Vendedores INNER JOIN Facturas ON Vendedores.Cod_Vendedor = Facturas.Cod_Vendedor INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                               "WHERE (Facturas.Tipo_Factura = N'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor, Vendedores.Cod_Vendedor"
                    'SqlDatos = "SELECT Vendedores.Cod_Vendedor, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS NombreVendedor, SUM(Facturas.SubTotal) AS MontoVendido FROM Vendedores INNER JOIN Facturas ON Vendedores.Cod_Vendedor = Facturas.Cod_Vendedor  " & _
                    '           "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = N'Factura') GROUP BY Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor, Vendedores.Cod_Vendedor"
                    'CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal ELSE Facturas.SubTotal / TasaCambio.MontoTasa END
                    ArepReporteVentasVendedor.LblMoneda.Text = "Expresado en Dolares"
                Else
                    SQlDatosSuma = "SELECT MAX(Vendedores.Cod_Vendedor) AS Expr1, MAX(Vendedores.Nombre_Vendedor + N' ' + Vendedores.Apellido_Vendedor) AS NombreVendedor, SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal ELSE Facturas.SubTotal * TasaCambio.MontoTasa END) AS MontoVendido FROM Vendedores INNER JOIN Facturas ON Vendedores.Cod_Vendedor = Facturas.Cod_Vendedor INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                                    "WHERE (Facturas.Tipo_Factura = 'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102))"

                    SqlDatos = "SELECT Vendedores.Cod_Vendedor, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS NombreVendedor, SUM(CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal ELSE Facturas.SubTotal * TasaCambio.MontoTasa END) AS MontoVendido FROM  Vendedores INNER JOIN Facturas ON Vendedores.Cod_Vendedor = Facturas.Cod_Vendedor INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa  " & _
                               "WHERE (Facturas.Tipo_Factura = N'Factura') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) GROUP BY Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor, Vendedores.Cod_Vendedor"
                    'SqlDatos = "SELECT Vendedores.Cod_Vendedor, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS NombreVendedor, SUM(Facturas.SubTotal) AS MontoVendido FROM Vendedores INNER JOIN Facturas ON Vendedores.Cod_Vendedor = Facturas.Cod_Vendedor  " & _
                    '           "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = N'Factura') GROUP BY Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor, Vendedores.Cod_Vendedor"
                    'CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal ELSE Facturas.SubTotal / TasaCambio.MontoTasa END
                    ArepReporteVentasVendedor.LblMoneda.Text = "Expresado en Cordobas"
                End If
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos
                ArepReporteVentasVendedor.ChartControl.DataSource = SQL
                ArepReporteVentasVendedor.DataSource = SQL

                DataAdapter = New SqlClient.SqlDataAdapter(SQlDatosSuma, MiConexion)
                DataAdapter.Fill(DataSet, "VentasTotales")
                If Not DataSet.Tables("VentasTotales").Rows.Count = 0 Then
                    If Not IsDBNull(DataSet.Tables("VentasTotales").Rows(0)("MontoVendido")) Then
                        ArepReporteVentasVendedor.VentasTotales = DataSet.Tables("VentasTotales").Rows(0)("MontoVendido")
                    Else
                        MsgBox("No existen Registros", MsgBoxStyle.Exclamation, "Zeus Facturacion")
                        Exit Select
                        ArepReporteVentasVendedor.VentasTotales = 0
                    End If
                Else
                    ArepReporteVentasVendedor.VentasTotales = 0
                End If

                'ArepReporteVentas.DataSource = S

                ArepReporteVentasVendedor.Document.Name = "Reporte de Ventas x Vendedor"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepReporteVentasVendedor.Document
                My.Application.DoEvents()
                ArepReporteVentasVendedor.Run(False)
                ViewerForm.Show()

            Case "Reporte de Ventas"

                Dim ArepReporteVentas As New ArepReporteVentas

                ArepReporteVentas.LblRango.Text = "Fecha Inicio: " & Format(Fecha1, "dd/MM/yyyy") & "   Fecha Fin:" & Format(Fecha2, "dd/MM/yyyy")
                If Dir(RutaLogo) <> "" Then
                    ArepReporteVentas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepReporteVentas.LblTitulo.Text = NombreEmpresa
                ArepReporteVentas.LblDireccion.Text = DireccionEmpresa
                ArepReporteVentas.LblRuc.Text = Ruc
                'SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente,Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS Vendedor, Facturas.MonedaFactura, Facturas.MetodoPago, Facturas.SubTotal,Facturas.IVA, Facturas.Pagado, Facturas.NetoPagar FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente  " & _
                '           "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') "

                SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS Vendedor, Facturas.MonedaFactura, Facturas.MetodoPago, Facturas.SubTotal, Facturas.IVA, Facturas.Pagado, Facturas.NetoPagar, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal / TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS ImporteDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.IVA * TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.IVA / TasaCambio.MontoTasa ELSE Facturas.IVA END AS IvaDolares, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.NetoPagar * TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoCordobas, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.NetoPagar / TasaCambio.MontoTasa ELSE Facturas.NetoPagar END AS NetoDolares FROM  Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor INNER JOIN Clientes ON Facturas.Cod_Cliente = Clientes.Cod_Cliente INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa " & _
                           "WHERE (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) AND (Facturas.Tipo_Factura = 'Factura') "
                If Me.CmbVendedores.Text <> "" Then
                    If Me.CmbVendedores2.Text <> "" Then
                        SqlDatos = SqlDatos & " AND (Vendedores.Cod_Vendedor BETWEEN '" & Me.CmbVendedores.Text & "' AND '" & Me.CmbVendedores2.Text & "') "
                        ArepReporteVentas.LblRango.Text = ArepReporteVentas.LblRango.Text & " Vendedor Ini:" & Me.CmbVendedores.Text & " Vendedor Fin:" & Me.CmbVendedores2.Text
                    End If
                ElseIf Me.CmbVendedores2.Text = "" Then
                    ArepReporteVentas.LblRango.Text = ArepReporteVentas.LblRango.Text & " Vendedores: TODOS"
                End If



                If Me.CmbClientes.Text <> "" Then
                    If Me.CmbClientes2.Text <> "" Then
                        SqlDatos = SqlDatos & " AND (Clientes.Cod_Cliente BETWEEN '" & Me.CmbClientes.Text & "' AND '" & Me.CmbClientes2.Text & "') "
                        ArepReporteVentas.LblRango.Text = ArepReporteVentas.LblRango.Text & " Vendedor Ini: " & Me.CmbClientes.Text & " Vendedor Fin " & Me.CmbClientes2.Text
                    End If
                ElseIf Me.CmbClientes2.Text = "" Then
                    ArepReporteVentas.LblRango.Text = ArepReporteVentas.LblRango.Text & " Clientes: TODOS"
                End If

                SqlDatos = SqlDatos & "ORDER BY Facturas.MonedaFactura"

                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos
                ArepReporteVentas.DataSource = SQL
                ArepReporteVentas.Document.Name = "Listado de Ventas"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepReporteVentas.Document
                My.Application.DoEvents()
                ArepReporteVentas.Run(False)
                ViewerForm.Show()

            Case "Catalogo de Productos"
                Dim ArepCatalogoProductos As New ArepCatalogoProductos

                If Dir(RutaLogo) <> "" Then
                    ArepCatalogoProductos.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepCatalogoProductos.LblTitulo.Text = NombreEmpresa
                ArepCatalogoProductos.LblDireccion.Text = DireccionEmpresa
                ArepCatalogoProductos.LblRuc.Text = Ruc

                SqlDatos = "SELECT *  FROM Productos"
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos
                ArepCatalogoProductos.DataSource = SQL
                ArepCatalogoProductos.Document.Name = "Catalogo de Productos"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepCatalogoProductos.Document
                My.Application.DoEvents()
                ArepCatalogoProductos.Run(False)
                ViewerForm.Show()

                'ArepCatalogoProductos.Show()
            Case "Listado de Clientes"

                Dim ArepListadoClientes As New ArepListadoClientes

                If Dir(RutaLogo) <> "" Then
                    ArepListadoClientes.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepListadoClientes.LblTitulo.Text = NombreEmpresa
                ArepListadoClientes.LblDireccion.Text = DireccionEmpresa
                ArepListadoClientes.LblRuc.Text = Ruc
                SqlDatos = "SELECT Cod_Cliente, Nombre_Cliente, Apellido_Cliente, Direccion_Cliente, Telefono, Cod_Cuenta_Cliente, Nombre_Cliente + ' ' + Apellido_Cliente AS Nombres FROM Clientes "
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                ArepListadoClientes.DataSource = SQL
                ArepListadoClientes.Document.Name = "Listado de Clientes"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepListadoClientes.Document
                My.Application.DoEvents()
                ArepListadoClientes.Run(False)
                ViewerForm.Show()

                'ArepListadoClientes.Show()

            Case "Listado de Proveedores"

                Dim ArepListadoProveedores As New ArepListadoProveedores

                If Dir(RutaLogo) <> "" Then
                    ArepListadoProveedores.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepListadoProveedores.LblTitulo.Text = NombreEmpresa
                ArepListadoProveedores.LblDireccion.Text = DireccionEmpresa
                ArepListadoProveedores.LblRuc.Text = Ruc
                SqlDatos = "SELECT  Cod_Proveedor, Nombre_Proveedor, Apellido_Proveedor, Direccion_Proveedor, Telefono, Cod_Cuenta_Proveedor, Cod_Cuenta_Pagar, Cod_Cuenta_Cobrar, Merma, Nombre_Proveedor + ' ' + Apellido_Proveedor AS Nombres  FROM Proveedor"
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                ArepListadoProveedores.DataSource = SQL
                ArepListadoProveedores.Document.Name = "Listado de Proveedores"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepListadoProveedores.Document
                My.Application.DoEvents()
                ArepListadoProveedores.Run(False)
                ViewerForm.Show()

                'ArepListadoProveedores.Show()

            Case "Listado de Vendedores"

                Dim ArepListadoVendedores As New ArepListadoVendedores

                If Dir(RutaLogo) <> "" Then
                    ArepListadoVendedores.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepListadoVendedores.LblTitulo.Text = NombreEmpresa
                ArepListadoVendedores.LblDireccion.Text = DireccionEmpresa
                ArepListadoVendedores.LblRuc.Text = Ruc
                SqlDatos = "SELECT Cod_Vendedor, Nombre_Vendedor, Apellido_Vendedor, Direccion_Vendedor, Telefono_Vendedor, Cod_Cuenta_Vendedor, Nombre_Vendedor + ' ' + Apellido_Vendedor AS Nombres FROM Vendedores"
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                ArepListadoVendedores.DataSource = SQL
                ArepListadoVendedores.Document.Name = "Listado de Vendedores"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepListadoVendedores.Document
                My.Application.DoEvents()
                ArepListadoVendedores.Run(False)
                ViewerForm.Show()

                'ArepListadoVendedores.Show()

            Case "Listado de Bodegas"

                Dim ArepListadoBodegas As New ArepListadoBodegas

                If Dir(RutaLogo) <> "" Then
                    ArepListadoBodegas.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepListadoBodegas.LblTitulo.Text = NombreEmpresa
                ArepListadoBodegas.LblDireccion.Text = DireccionEmpresa
                ArepListadoBodegas.LblRuc.Text = Ruc
                SqlDatos = "SELECT  DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega, SUM(DetalleBodegas.Existencia) AS Existencia FROM DetalleBodegas INNER JOIN Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega GROUP BY DetalleBodegas.Cod_Bodegas, Bodegas.Nombre_Bodega"
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                ArepListadoBodegas.DataSource = SQL
                ArepListadoBodegas.Document.Name = "Listado de Bodegas"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepListadoBodegas.Document
                My.Application.DoEvents()
                ArepListadoBodegas.Run(False)
                ViewerForm.Show()

                'ArepListadoBodegas.Show()

            Case "Catalogo de Productos x Fotos"

                Dim ArepCatalogoFoto As New ArepCatalogoFoto

                If Dir(RutaLogo) <> "" Then
                    ArepCatalogoFoto.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepCatalogoFoto.LblTitulo.Text = NombreEmpresa
                ArepCatalogoFoto.LblDireccion.Text = DireccionEmpresa
                'ArepCatalogoFoto.LblRuc.Text = Ruc

                SqlDatos = "SELECT *  FROM Productos"
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos
                ArepCatalogoFoto.DataSource = SQL
                ArepCatalogoFoto.Document.Name = "Catalogo de Productos x Fotos"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepCatalogoFoto.Document
                My.Application.DoEvents()
                ArepCatalogoFoto.Run(False)
                ViewerForm.Show()

                'ArepCatalogoFoto.Show()

            Case "Actividad por Producto"

                Dim ArepActividadProductoLinea As New ArepActividadProductoLinea

                Dim ArepActividadProducto As New ArepActividadProducto

                If Dir(RutaLogo) <> "" Then
                    ArepActividadProducto.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

                ArepActividadProducto.LblTitulo.Text = NombreEmpresa
                ArepActividadProducto.LblDireccion.Text = DireccionEmpresa
                ArepActividadProducto.LblRuc.Text = Ruc

                If Me.CmbAgrupado.Text = "" Then
                    MsgBox("Se necesita Agrupado", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Exit Sub
                End If

                SqlDatos = ""
                Select Case Me.CmbAgrupado.Text
                    Case "Codigo Producto"
                        If Me.CboCodProducto.Text = "" Then
                            If Me.CboCodProducto2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Productos"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Productos BETWEEN '" & CodigoInicio & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                            End If
                        ElseIf Me.CboCodProducto2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & CodigoFin & "') ORDER BY Productos.Cod_Productos"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Productos BETWEEN '" & Me.CboCodProducto.Text & "' AND '" & Me.CboCodProducto2.Text & "') ORDER BY Productos.Cod_Productos"
                        End If
                    Case "Linea"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Linea"
                            Else
                                SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                            End If

                        ElseIf Me.CmbRango2.Text = "" Then
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) ORDER BY Productos.Cod_Linea"
                        Else
                            SqlDatos = "SELECT * FROM Productos INNER JOIN Lineas ON Productos.Cod_Linea = Lineas.Cod_Linea WHERE(Productos.Activo = Productos.Activo) AND (Productos.Costo_Promedio <> 0) AND (Productos.Cod_Linea BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') ORDER BY Productos.Cod_Linea"
                        End If


                    Case "Bodega"
                        If Me.CmbRango1.Text = "" Then
                            If Me.CmbRango2.Text = "" Then
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega WHERE (Productos.Costo_Promedio <> 0) ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Productos.Costo_Promedio <> 0) ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            End If
                        ElseIf Me.CmbRango2.Text = "" Then
                            If Me.CmbRango1.Text = "" Then
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            Else
                                SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Productos.Costo_Promedio <> 0) ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                            End If
                        Else
                            SqlDatos = "SELECT Productos.Cod_Productos, Productos.Descripcion_Producto, Bodegas.Cod_Bodega As Cod_Linea, Bodegas.Nombre_Bodega As Descripcion_Linea, DetalleBodegas.Existencia,Productos.Costo_Promedio, Productos.Costo_Promedio_Dolar FROM Productos INNER JOIN DetalleBodegas ON Productos.Cod_Productos = DetalleBodegas.Cod_Productos INNER JOIN  Bodegas ON DetalleBodegas.Cod_Bodegas = Bodegas.Cod_Bodega  WHERE (Bodegas.Cod_Bodega BETWEEN '" & Me.CmbRango1.Text & "' AND '" & Me.CmbRango2.Text & "') AND (Productos.Costo_Promedio <> 0) ORDER BY Bodegas.Cod_Bodega, Productos.Cod_Productos"
                        End If

                End Select
                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos

                If Me.CmbAgrupado.Text = "Codigo Producto" Then
                    ArepActividadProducto.LblTitulo.Text = NombreEmpresa
                    ArepActividadProducto.LblDireccion.Text = DireccionEmpresa
                    ArepActividadProducto.LblRuc.Text = Ruc
                    ArepActividadProducto.DataSource = SQL
                    ArepActividadProducto.Document.Name = "ACTIVIDAD POR PRODUCTOS"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepActividadProducto.Document
                    My.Application.DoEvents()
                    ArepActividadProducto.Run(False)
                    ViewerForm.Show()

                    'ArepActividadProducto.Show()
                ElseIf Me.CmbAgrupado.Text = "Linea" Then
                    ArepActividadProductoLinea.LblTitulo.Text = NombreEmpresa
                    ArepActividadProductoLinea.LblDireccion.Text = DireccionEmpresa
                    ArepActividadProductoLinea.LblRuc.Text = Ruc
                    ArepActividadProductoLinea.DataSource = SQL
                    ArepActividadProductoLinea.Document.Name = "ACTIVIDAD PRODUCTOS POR LINEA"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepActividadProductoLinea.Document
                    My.Application.DoEvents()
                    ArepActividadProductoLinea.Run(False)
                    ViewerForm.Show()
                    'ArepActividadProductoLinea.Show()
                ElseIf Me.CmbAgrupado.Text = "Bodega" Then
                    ArepActividadProductoLinea.LblTitulo.Text = NombreEmpresa
                    ArepActividadProductoLinea.LblDireccion.Text = DireccionEmpresa
                    ArepActividadProductoLinea.LblRuc.Text = Ruc
                    ArepActividadProductoLinea.DataSource = SQL
                    ArepActividadProductoLinea.Document.Name = "ACTIVIDAD PRODUCTOS POR BODEGA"
                    ArepActividadProductoLinea.LblCodigo.Text = "Codigo Bodega"
                    ArepActividadProductoLinea.LblNombre.Text = "Nombre Bodega"
                    Dim ViewerForm As New FrmViewer()
                    ViewerForm.arvMain.Document = ArepActividadProductoLinea.Document
                    My.Application.DoEvents()
                    ArepActividadProductoLinea.Run(False)
                    ViewerForm.Show()
                    'ArepActividadProductoLinea.Show()

                End If

            Case "Reporte de Cotizaciones x Vendedor"

                Dim ArepListadoCotizaciones As New ArepListadoCotizaciones
                Dim ArepReporteVentas As New ArepReporteVentas

                ArepListadoCotizaciones.LblRango.Text = "Fecha Inicio: " & Format(Fecha1, "dd/MM/yyyy") & "   Fecha Fin:" & Format(Fecha2, "dd/MM/yyyy")
                If Dir(RutaLogo) <> "" Then
                    ArepListadoCotizaciones.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
                ArepListadoCotizaciones.LblTitulo.Text = NombreEmpresa
                ArepListadoCotizaciones.LblDireccion.Text = DireccionEmpresa
                ArepListadoCotizaciones.LblRuc.Text = Ruc

                'SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.Tipo_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente,Facturas.SubTotal, Facturas.IVA, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS Vendedor, Facturas.Cod_Cliente,Facturas.Cod_Vendedor, Facturas.SubTotal + Facturas.IVA AS Neto FROM Facturas INNER JOIN Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor " & _
                '"WHERE (Facturas.Tipo_Factura = 'Cotizacion') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "',102))"

                If Me.OptCordobas.Checked = True Then
                    SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.Tipo_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente,Facturas.SubTotal, Facturas.IVA, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS Vendedor, Facturas.Cod_Cliente,Facturas.Cod_Vendedor, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.SubTotal * TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS SubTotal, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN Facturas.IVA * TasaCambio.MontoTasa ELSE Facturas.IVA END AS IVA, CASE WHEN Facturas.MonedaFactura = 'Dolares' THEN (Facturas.SubTotal + Facturas.IVA) * TasaCambio.MontoTasa ELSE Facturas.SubTotal + Facturas.IVA END AS Neto FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN  Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor WHERE  (Facturas.Tipo_Factura = N'Cotizacion') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) "
                    ArepListadoCotizaciones.LblRango.Text = ArepListadoCotizaciones.LblRango.Text & "Reporte Expresado en Cordobas"
                Else
                    SqlDatos = "SELECT Facturas.Numero_Factura, Facturas.Fecha_Factura, Facturas.Tipo_Factura, Facturas.Nombre_Cliente + ' ' + Facturas.Apellido_Cliente AS Cliente,Facturas.SubTotal, Facturas.IVA, Vendedores.Nombre_Vendedor + ' ' + Vendedores.Apellido_Vendedor AS Vendedor, Facturas.Cod_Cliente,Facturas.Cod_Vendedor, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.SubTotal / TasaCambio.MontoTasa ELSE Facturas.SubTotal END AS SubTotal, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN Facturas.IVA / TasaCambio.MontoTasa ELSE Facturas.IVA END AS IVA, CASE WHEN Facturas.MonedaFactura = 'Cordobas' THEN (Facturas.SubTotal + Facturas.IVA) / TasaCambio.MontoTasa ELSE Facturas.SubTotal + Facturas.IVA END AS Neto FROM Facturas INNER JOIN TasaCambio ON Facturas.Fecha_Factura = TasaCambio.FechaTasa INNER JOIN  Vendedores ON Facturas.Cod_Vendedor = Vendedores.Cod_Vendedor WHERE  (Facturas.Tipo_Factura = N'Cotizacion') AND (Facturas.Fecha_Factura BETWEEN CONVERT(DATETIME, '" & Format(Fecha1, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Fecha2, "yyyy-MM-dd") & "', 102)) "
                    ArepListadoCotizaciones.LblRango.Text = ArepListadoCotizaciones.LblRango.Text & "Reporte Expresado en Dolares"
                End If

                If Me.CmbVendedores.Text <> "" Then
                    If Me.CmbVendedores2.Text <> "" Then
                        SqlDatos = SqlDatos & " AND (Vendedores.Cod_Vendedor BETWEEN '" & Me.CmbVendedores.Text & "' AND '" & Me.CmbVendedores2.Text & "') "
                        ArepListadoCotizaciones.LblRango.Text = ArepListadoCotizaciones.LblRango.Text & " Vendedor Ini:" & Me.CmbVendedores.Text & " Vendedor Fin:" & Me.CmbVendedores2.Text
                    End If
                ElseIf Me.CmbVendedores2.Text = "" Then
                    ArepListadoCotizaciones.LblRango.Text = ArepListadoCotizaciones.LblRango.Text & " Vendedores: TODOS"
                End If



                If Me.CmbClientes.Text <> "" Then
                    If Me.CmbClientes2.Text <> "" Then
                        SqlDatos = SqlDatos & " AND (Facturas.Cod_Cliente BETWEEN '" & Me.CmbClientes.Text & "' AND '" & Me.CmbClientes2.Text & "') "
                        ArepListadoCotizaciones.LblRango.Text = ArepListadoCotizaciones.LblRango.Text & " Vendedor Ini: " & Me.CmbClientes.Text & " Vendedor Fin " & Me.CmbClientes2.Text
                    End If
                ElseIf Me.CmbClientes2.Text = "" Then
                    ArepListadoCotizaciones.LblRango.Text = ArepListadoCotizaciones.LblRango.Text & " Clientes: TODOS"
                End If

                SqlDatos = SqlDatos & " ORDER BY Facturas.Numero_Factura, Facturas.Fecha_Factura"

                SQL.ConnectionString = Conexion
                SQL.SQL = SqlDatos
                ArepListadoCotizaciones.DataSource = SQL
                ArepListadoCotizaciones.Document.Name = "Listado de Cotizaciones"
                Dim ViewerForm As New FrmViewer()
                ViewerForm.arvMain.Document = ArepListadoCotizaciones.Document
                My.Application.DoEvents()
                ArepListadoCotizaciones.Run(False)
                ViewerForm.Show()

        End Select




        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        Imagen.Visible = False
        MostrarImagen = False
        Me.Timer1.Enabled = False
        Me.Button2.Enabled = True
        Me.Button8.Enabled = True
        Me.LblProcesando.Visible = False
        Me.ProgressBar.Visible = False

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodProducto2.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmbAgrupado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAgrupado.SelectedIndexChanged
        Dim DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String
        Dim DataSet As New DataSet, Registros As Double

        Me.CmbRango1.Text = ""
        Me.CmbRango2.Text = ""

        Me.Label5.Visible = True
        Me.Label6.Visible = True
        Me.CmbRango1.Visible = True
        Me.CmbRango2.Visible = True
        Me.Button3.Visible = True
        Me.Button4.Visible = True

        Select Case Me.CmbAgrupado.Text
            Case "Codigo Producto"
                '/////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////CARGO LOS COMBOS DEL FORMULARIO REPORTES/////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////
                SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos"
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapterProductos.Fill(DataSet, "ListaProductos")
                If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                    Me.CmbRango1.DataSource = DataSet.Tables("ListaProductos")
                    Me.CmbRango1.Columns(0).Caption = "Codigo"
                    Me.CmbRango1.Splits.Item(0).DisplayColumns(0).Width = 50
                    Me.CmbRango1.Columns(1).Caption = "Descripcion"
                End If

                DataAdapterProductos.Fill(DataSet, "ListaProductos2")
                If Not DataSet.Tables("ListaProductos2").Rows.Count = 0 Then
                    Me.CmbRango2.DataSource = DataSet.Tables("ListaProductos2")
                    Me.CmbRango2.Columns(0).Caption = "Codigo"
                    Me.CmbRango2.Splits.Item(0).DisplayColumns(0).Width = 50
                    Me.CmbRango2.Columns(1).Caption = "Descripcion"
                End If

                Me.Label5.Visible = False
                Me.Label6.Visible = False
                Me.CmbRango1.Visible = False
                Me.CmbRango2.Visible = False
                Me.Button3.Visible = False
                Me.Button4.Visible = False

                If Me.ListBox.Text = "Reporte Ventas x Categorias Resumen" Then
                    GroupBoxLinea.Location = New Point(280, 123)
                End If


            Case "Linea"
                '/////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////CARGO LOS COMBOS DEL FORMULARIO REPORTES/////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////
                SqlProductos = "SELECT * FROM Lineas"
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapterProductos.Fill(DataSet, "ListaProductos")
                If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                    Me.CmbRango1.DataSource = DataSet.Tables("ListaProductos")
                    Me.CmbRango1.Columns(0).Caption = "Linea"
                    If DataSet.Tables("ListaProductos").Rows.Count >= 1 Then
                        Me.CmbRango1.Text = DataSet.Tables("ListaProductos").Rows(0)("Cod_Linea")
                    End If
                End If

                DataAdapterProductos.Fill(DataSet, "ListaProductos2")
                If Not DataSet.Tables("ListaProductos2").Rows.Count = 0 Then
                    Registros = DataSet.Tables("ListaProductos2").Rows.Count - 1
                    Me.CmbRango2.DataSource = DataSet.Tables("ListaProductos2")
                    Me.CmbRango2.Columns(0).Caption = "Linea"
                    If DataSet.Tables("ListaProductos2").Rows.Count >= 1 Then
                        Me.CmbRango2.Text = DataSet.Tables("ListaProductos2").Rows(Registros)("Cod_Linea")
                    End If
                End If

                If Me.ListBox.Text = "Reporte Ventas x Categorias Resumen" Then
                    GroupBoxLinea.Location = New Point(1103, 12)
                End If
            Case "Descripcion"
                '/////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////CARGO LOS COMBOS DEL FORMULARIO REPORTES/////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////
                SqlProductos = "SELECT Descripcion_Producto FROM Productos"
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapterProductos.Fill(DataSet, "ListaProductos")
                If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                    Me.CmbRango1.DataSource = DataSet.Tables("ListaProductos")
                    Me.CmbRango1.Columns(0).Caption = "Descripcion"
                End If

                DataAdapterProductos.Fill(DataSet, "ListaProductos2")
                If Not DataSet.Tables("ListaProductos2").Rows.Count = 0 Then
                    Me.CmbRango2.DataSource = DataSet.Tables("ListaProductos2")
                    Me.CmbRango2.Columns(0).Caption = "Descripcion"
                End If

            Case "Bodega"
                '/////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////CARGO LOS COMBOS DEL FORMULARIO REPORTES/////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////
                SqlProductos = "SELECT * FROM Bodegas"
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapterProductos.Fill(DataSet, "Bodegas")
                If Not DataSet.Tables("Bodegas").Rows.Count = 0 Then
                    Me.CmbRango1.DataSource = DataSet.Tables("Bodegas")
                    Me.CmbRango1.Columns(0).Caption = "Bodega"
                    If DataSet.Tables("Bodegas").Rows.Count >= 1 Then
                        Me.CmbRango1.Text = DataSet.Tables("Bodegas").Rows(0)("Cod_Bodega")
                    End If
                End If

                DataAdapterProductos.Fill(DataSet, "Bodegas2")
                If Not DataSet.Tables("Bodegas2").Rows.Count = 0 Then
                    Me.CmbRango2.DataSource = DataSet.Tables("Bodegas2")
                    Me.CmbRango2.Columns(0).Caption = "Bodega"
                    If DataSet.Tables("Bodegas2").Rows.Count >= 1 Then
                        Me.CmbRango2.Text = DataSet.Tables("Bodegas2").Rows(0)("Cod_Bodega")
                    End If
                End If
            Case "Rubro"
                '/////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////CARGO LOS COMBOS DEL FORMULARIO REPORTES/////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////
                SqlProductos = "SELECT  * FROM  Rubro"
                DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
                DataAdapterProductos.Fill(DataSet, "Rubro")
                If Not DataSet.Tables("Rubro").Rows.Count = 0 Then
                    Me.CmbRango1.DataSource = DataSet.Tables("Rubro")
                    Me.CmbRango1.Columns(0).Caption = "Rubro"
                End If

                DataAdapterProductos.Fill(DataSet, "Rubro2")
                If Not DataSet.Tables("Rubro2").Rows.Count = 0 Then
                    Me.CmbRango2.DataSource = DataSet.Tables("Rubro2")
                    Me.CmbRango2.Columns(0).Caption = "Rubro"
                End If

        End Select
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Select Case Me.CmbAgrupado.Text
            Case "Codigo Producto"
                Quien = "CodigoProductos"
                My.Forms.FrmConsultas.ShowDialog()
                Me.CmbRango1.Text = My.Forms.FrmConsultas.Codigo
            Case "Linea"
                Quien = "CodigoLinea"
                My.Forms.FrmConsultas.ShowDialog()
                Me.CmbRango1.Text = My.Forms.FrmConsultas.Descripcion
            Case "Descripcion"
                Quien = "CodigoProductos"
                My.Forms.FrmConsultas.ShowDialog()
                Me.CmbRango1.Text = My.Forms.FrmConsultas.Descripcion

        End Select
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Select Case Me.CmbAgrupado.Text
            Case "Codigo Producto"
                Quien = "CodigoProductos"
                My.Forms.FrmConsultas.ShowDialog()
                Me.CmbRango2.Text = My.Forms.FrmConsultas.Codigo
            Case "Linea"
                Quien = "CodigoLinea"
                My.Forms.FrmConsultas.ShowDialog()
                Me.CmbRango2.Text = My.Forms.FrmConsultas.Descripcion
            Case "Descripcion"
                Quien = "CodigoProductos"
                My.Forms.FrmConsultas.ShowDialog()
                Me.CmbRango2.Text = My.Forms.FrmConsultas.Descripcion

        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        My.Application.DoEvents()

        If MostrarImagen = False Then
            Me.Imagen.Visible = False
        Else
            Me.Imagen.Visible = True
        End If

        If ImagenReporte = 5 Then
            Imagen.Image = ListaImagenes.Images(ImagenReporte)
            Me.LblProcesando.Text = Me.LblProcesando.Text & "."
            ImagenReporte = 0

        ElseIf ImagenReporte = 0 Then
            Imagen.Image = ListaImagenes.Images(ImagenReporte)
            Me.LblProcesando.Text = "Procesando,Espere."
            ImagenReporte = ImagenReporte + 1

        Else
            Imagen.Image = ListaImagenes.Images(ImagenReporte)
            Me.LblProcesando.Text = Me.LblProcesando.Text & "."
            ImagenReporte = ImagenReporte + 1

        End If


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CmbClientes.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoCliente"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CmbClientes2.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub ListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox.SelectedIndexChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.GroupBox2.Visible = True
        Me.GroupBox3.Visible = False
        Me.GroupBoxProductos.Visible = False
        Me.GroupClientes.Visible = False
        Me.GroupVendedor.Visible = False
        Me.GroupBoxNotas.Visible = False
        Me.GroupBoxLinea.Visible = False

        Select Case ListBox.Text
            Case "Reporte de Ventas Productos x Vendedor"
                Me.GroupVendedor.Visible = True
                Me.GroupVendedor.Location = New Point(280, 123)
                Me.GroupBoxLinea.Visible = True
                Me.GroupBoxLinea.Location = New Point(280, 216)
                Me.GroupBox2.Visible = False

            Case "Reporte Lista de Precios Vrs Costo"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Codigo Producto"
            Case "Reporte Existencia Costos"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Codigo Producto"

            Case "Reporte de Historico de Saldo Clientes"
                Me.GroupBox1.Visible = True
                Me.GroupClientes.Location = New Point(280, 123)
                Me.GroupClientes.Visible = True

            Case "Reporte de Ventas x Clientes al Contado"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"

            Case "Reporte Salidas de Productos x Tipo"
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
                Me.GroupBoxTipo.Visible = True
                Me.GroupBoxTipo.Location = New Point(280, 123)

            Case "Reporte de Salidas x Tipo"
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
                Me.GroupBoxTipo.Visible = True
                Me.GroupBoxTipo.Location = New Point(280, 123)

            Case "Reporte Ventas x Categorias Resumen"
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
                Me.GroupBoxLinea.Visible = True
                Me.GroupBoxLinea.Location = New Point(280, 123)
            Case "Reporte Ventas x Categorias Detalle"
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
                Me.GroupBoxLinea.Visible = True
                Me.GroupBoxLinea.Location = New Point(280, 123)
            Case "Listado de Recibos de Caja"
                Me.GroupBox1.Visible = True
                Me.GroupClientes.Visible = False
                Me.GroupBoxNotas.Visible = False
            Case "Reporte de Notas Debito/Credito"
                Me.GroupBox1.Visible = True
                Me.GroupBoxNotas.Location = New Point(280, 123)
                Me.GroupClientes.Visible = False
                Me.GroupBoxNotas.Visible = True

            Case "Reporte de Saldo de Clientes"
                Me.GroupBox1.Visible = True
                Me.GroupClientes.Location = New Point(280, 123)
                Me.GroupClientes.Visible = True

            Case "Estado de Cuentas x Cliente"
                Me.GroupBox1.Visible = True
                Me.GroupClientes.Location = New Point(280, 123)
                Me.GroupClientes.Visible = True

            Case "Reporte de Cotizaciones x Vendedor"
                Me.GroupVendedor.Visible = True
                Me.GroupVendedor.Location = New Point(280, 123)
                Me.GroupClientes.Visible = False
                Me.GroupBoxProductos.Visible = False
            Case "Reporte Grafico de Ventas x Vendedor"
                Me.GroupVendedor.Visible = False
                Me.GroupClientes.Visible = False

            Case "Reporte de Productos mas Vendidos"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupBox2.Visible = False
                Me.GroupBox3.Visible = False
                Me.GroupBoxProductos.Visible = False
            Case "Reporte de Productos mas Inventarios"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupBox2.Visible = True
                Me.GroupBox3.Visible = False
                Me.GroupBoxProductos.Visible = False
            Case "Reporte de Facturas x Vendedor"
                Me.GroupBoxProductos.Visible = False
                Me.GroupVendedor.Visible = True
                Me.GroupVendedor.Location = New Point(280, 123)
                Me.GroupClientes.Visible = False
            Case "Control de Entradas y Salidas"
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
            Case "Comprobantes de Caja General"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupBox1.Visible = True
            Case "Informe de Caja General"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupBox1.Visible = True
            Case "Reporte de Saldo de Clientes"
                Me.Label1.Visible = False
                Me.DTPFechaIni.Visible = False
                Me.GroupVendedor.Visible = False
            Case "Reporte de Ventas x Vendedor"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
            Case "Reporte de Ventas"
                'Me.GroupClientes.Visible = True
                Me.GroupVendedor.Visible = True
                Me.GroupVendedor.Location = New Point(280, 123)
                Me.GroupBox2.Visible = True
                Me.GroupBoxProductos.Visible = False
            Case "Reporte de Ventas x Productos"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupBox3.Visible = True
                Me.GroupBoxProductos.Visible = True
                Me.CmbAgrupado.Text = "Bodega"

            Case "Reporte de Ventas x Productos al Contado"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
            Case "Reporte de Ventas x Productos al Credito"
                Me.GroupClientes.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
            Case "Reporte de Kardex"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Codigo Producto"
            Case "Reporte de Kardex Unidades"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
            Case "Movimientos de Productos"
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Codigo Producto"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
            Case "Entrada de Productos"
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
            Case "Salida de Productos"
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
            Case "Listado de Clientes"
                Me.GroupBoxProductos.Visible = False
                Me.GroupBox2.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupClientes.Visible = False
            Case "Listado de Proveedores"
                Me.GroupBoxProductos.Visible = False
                Me.GroupBox2.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupClientes.Visible = False
            Case "Listado de Vendedores"
                Me.GroupBoxProductos.Visible = False
                Me.GroupBox2.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupClientes.Visible = False
            Case "Listado de Bodegas"
                Me.GroupBoxProductos.Visible = False
                Me.GroupBox2.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupClientes.Visible = False
            Case "Catalogo de Productos"
                Me.GroupBoxProductos.Visible = False
                Me.GroupBox2.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupClientes.Visible = False
            Case "Catalogo de Productos x Fotos"
                Me.GroupBoxProductos.Visible = False
                Me.GroupBox2.Visible = False
                Me.GroupVendedor.Visible = False
                Me.GroupClientes.Visible = False

            Case "Actividad por Producto"
                Me.GroupBoxProductos.Visible = True
                Me.GroupBoxProductos.Location = New Point(280, 123)
                Me.GroupBox3.Visible = True
                Me.CmbAgrupado.Text = "Bodega"

        End Select
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CodigoVendedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CmbVendedores.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CodigoVendedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CmbVendedores2.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodProducto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdProducto2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodProducto2.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodProducto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClientes1.Click
        Quien = "CodigoVendedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CmbVendedores.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdClientes2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClientes2.Click
        Quien = "CodigoVendedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CmbVendedores2.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmbRango1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbRango1.TextChanged

    End Sub

    Private Sub CmdProductos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdProducto2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboCodiProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodProducto.TextChanged

    End Sub

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodProducto.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodProducto2.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Quien = "CodigoLinea"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoLinea.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Quien = "CodigoLinea"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoLinea2.Text = My.Forms.FrmConsultas.Codigo
    End Sub
End Class